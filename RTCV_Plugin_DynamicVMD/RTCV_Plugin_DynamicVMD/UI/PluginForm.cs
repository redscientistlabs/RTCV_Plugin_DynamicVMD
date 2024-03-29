namespace DYNAMICVMD.UI
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using NLog;
    using RTCV.CorruptCore;

    using RTCV.Common;
    using RTCV.UI;
    using static RTCV.CorruptCore.RtcCore;
    using RTCV.Vanguard;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Runtime.InteropServices;
    using System.Drawing.Imaging;
    using RTCV.NetCore;
    using System.Diagnostics;
    using System.Net;
    using System.Collections.Specialized;

    using System.IO.Compression;
    using System.Windows.Documents.Serialization;
    using RTCV.UI.Modular;
    using RTCV.UI.Components.Controls;
    using RTCV.NetCore.Commands;

    //using System.Windows;

    public partial class PluginForm : ComponentForm, IColorize
    {
        public DYNAMICVMD plugin;

        public volatile bool HideOnClose = true;

        Logger logger = NLog.LogManager.GetCurrentClassLogger();

        WebClient wc = new WebClient();

        //This dictionary will inflate forever but it would take quite a while to be noticeable.
        Dictionary<string, bool> encounteredIds = new Dictionary<string, bool>();

        private long currentDomainSize = 0;

        public PluginForm(DYNAMICVMD _plugin)
        {
            plugin = _plugin;

            this.InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.PluginForm_FormClosing);
            this.Text = "Dynamic VMD";// CORRUPTCLOUD_LIVE.CamelCase(nameof(CORRUPTCLOUD_LIVE).Replace("_", " ")); //automatic window title

            this.version.Text = $"{plugin.Version.ToString()}"; //automatic window title
        }


        private void PluginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            encounteredIds.Clear();

            if (HideOnClose)
            {
                e.Cancel = true;
                this.Hide();
            }    
        }





        private void Ticker_Tick(object sender, EventArgs e)
        {

            SyncObjectSingleton.FormExecute(() =>
            {
                S.GET<GlitchHarvesterBlastForm>().loadBeforeOperation = true;
                S.GET<GlitchHarvesterBlastForm>().Corrupt(null, null);
            });
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            btnRefreshDomains_Click(null, null);



            GenerateDynamicVMD();


            pnDomain.Visible = true;
            pnRange.Visible = true;
            cbForceSolo.Visible = true;
            btnStart.Visible = false;
        }

        private void btnRefreshDomains_Click(object sender, EventArgs e)
        {
            S.GET<MemoryDomainsForm>().RefreshDomainsAndKeepSelected();
            
            cbSelectedMemoryDomain.Items.Clear();
            var domains = MemoryDomains.MemoryInterfaces?.Keys.Where(it => !it.Contains("[V]")).ToArray();
            if (domains?.Length > 0)
            {
                cbSelectedMemoryDomain.Items.AddRange(domains);
            }

            if (cbSelectedMemoryDomain.Items.Count > 0)
            {
                cbSelectedMemoryDomain.SelectedIndex = 0;
            }
        }

        public void GenerateDynamicVMD()
        {
            if (cbSelectedMemoryDomain.SelectedIndex == -1)
                return;


            GenerateVMD();
        }

        private void HandleSelectedMemoryDomainChange(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbSelectedMemoryDomain.SelectedItem?.ToString()) || !MemoryDomains.MemoryInterfaces.ContainsKey(cbSelectedMemoryDomain.SelectedItem.ToString()))
            {
                cbSelectedMemoryDomain.Items.Clear();
                return;
            }

            MemoryInterface mi = MemoryDomains.MemoryInterfaces[cbSelectedMemoryDomain.SelectedItem.ToString()];

            lbDomainSizeValue.Text = "0x" + mi.Size.ToString("X");
            lbWordSizeValue.Text = $"{mi.WordSize * 8} bits";
            lbEndianTypeValue.Text = (mi.BigEndian ? "Big" : "Little");

            currentDomainSize = Convert.ToInt64(mi.Size);

            updateInterface();
        }

        private void updateInterface()
        {
            MemoryInterface mi = MemoryDomains.MemoryInterfaces[cbSelectedMemoryDomain.SelectedItem.ToString()];

            long fullRange = mi.Size;

            if (mtbStartAddress.Value > fullRange)
            {
                mtbStartAddress.Value = fullRange;
            }

            if (mtbStartAddress.Maximum != fullRange)
            {
                mtbStartAddress.Maximum = fullRange;
            }

            if (mtbRange.Maximum != fullRange)
            {
                mtbRange.Maximum = fullRange;
            }

            mtbStartAddress.Enabled = true;
            mtbRange.Enabled = true;
        }

        private bool GenerateVMD()
        {
            if (string.IsNullOrWhiteSpace(cbSelectedMemoryDomain.SelectedItem?.ToString()) || !MemoryDomains.MemoryInterfaces.ContainsKey(cbSelectedMemoryDomain.SelectedItem.ToString()))
            {
                cbSelectedMemoryDomain.Items.Clear();
                return false;
            }


            MemoryInterface mi = MemoryDomains.MemoryInterfaces[cbSelectedMemoryDomain.SelectedItem.ToString()];
            VirtualMemoryDomain VMD = new VirtualMemoryDomain();
            VmdPrototype proto = new VmdPrototype
            {
                GenDomain = cbSelectedMemoryDomain.SelectedItem.ToString()
            };

            proto.VmdName = "DynamicVMD";

            proto.BigEndian = mi.BigEndian;
            proto.WordSize = mi.WordSize;
            proto.Padding = 0;

            foreach (string line in tbRangeExpression.Lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string trimmedLine = line.Trim();

                bool remove = false;

                if (trimmedLine[0] == '-')
                {
                    remove = true;
                    trimmedLine = trimmedLine.Substring(1);
                }

                proto.AddFromTrimmedLine(trimmedLine, currentDomainSize, remove);
            }

            if (proto.AddRanges.Count == 0 && proto.AddSingles.Count == 0)
            {
                //No add range was specified, use entire domain
                proto.AddRanges.Add(new long[] { 0, (currentDomainSize > long.MaxValue ? long.MaxValue : Convert.ToInt64(currentDomainSize)) });
            }

            //Precalc the size of the vmd
            //Ignore the fact that addranges and subtractranges can overlap. Only account for add
            long size = 0;
            foreach (var v in proto.AddSingles)
            {
                size++;
            }

            foreach (var v in proto.AddRanges)
            {
                long x = v[1] - v[0];
                size += x;
            }
            //If the size is still 0 and we have removals, we're gonna use the entire range then sub from it so size is now the size of the domain
            if (size == 0 &&
                (proto.RemoveSingles.Count > 0 || proto.RemoveRanges.Count > 0) ||
                (proto.RemoveSingles.Count == 0 && proto.RemoveRanges.Count == 0 && size == 0))
            {
                size = currentDomainSize;
            }

            foreach (var v in proto.RemoveSingles)
            {
                size--;
            }

            foreach (var v in proto.RemoveRanges)
            {
                long x = v[1] - v[0];
                size -= x;
            }




            VMD = proto.Generate();

            if (VMD.Size == 0)
            {
                MessageBox.Show("The resulting VMD had no pointers so the operation got cancelled.");
                return false;
            }

            var backupDomains = (AllSpec.UISpec[UISPEC.SELECTEDDOMAINS] as string[]);

            if (!backupDomains.Contains("[V]DynamicVMD"))
            {
                var listBackupDomains = backupDomains.ToList();
                listBackupDomains.Add("[V]DynamicVMD");
                backupDomains = listBackupDomains.ToArray();
            }

            MemoryDomains.RemoveVMD("DynamicVMD", true);
            MemoryDomains.AddVMD(VMD, true);

            //Refresh the domains in the VMD pool
            S.GET<VmdPoolForm>().RefreshVMDs();

            //update backup domains
            backupDomains = (AllSpec.UISpec[UISPEC.SELECTEDDOMAINS] as string[]);

            if (cbForceSolo.Checked)
            {
                if(backupDomains.Length == 1 && backupDomains[0] == "[V]DynamicVMD")
                {
                    //we all good, what what if not?
                }
                else
                {
                    S.GET<MemoryDomainsForm>().RefreshDomainsAndKeepSelected(new string[] { "[V]DynamicVMD" });
                }
                
            }
            else
            {
                S.GET<MemoryDomainsForm>().RefreshDomainsAndKeepSelected(backupDomains);
            }

            return true;
        }

        private void ComputeRangeExpression(object sender, EventArgs e)
        {
            long maxAddress = mtbStartAddress.Maximum;
            long startAddress = mtbStartAddress.Value;
            long range = mtbRange.Value;
            long addressPlusRange = (startAddress + range > mtbStartAddress.Maximum) ? mtbStartAddress.Maximum : startAddress + range;
            bool rangeUsed = mtbRange.Checked;

            string generatedExpression = $"{startAddress.ToHexString()}-{(rangeUsed ? addressPlusRange.ToHexString() : maxAddress.ToHexString())}";
            tbRangeExpression.Text = generatedExpression;

            GenerateDynamicVMD();
        }

        private void btnSendToStatic_Click(object sender, EventArgs e)
        {
            S.GET<VmdGenForm>().tbCustomAddresses.Text = tbRangeExpression.Text;

            var items = UICore.GetSafeDynamicComboboxItems(UICore.mtForm.cbSelectBox);

            //Selects back the VMD Pool menu
            foreach (var item in items)
            {

                if (item.value is VmdGenForm)
                {
                    UICore.SetSelectedComboboxItemFromDynamic(UICore.mtForm.cbSelectBox, item);
                    break;
                }
            }

            S.GET<VmdGenForm>().btnLoadDomains_Click(null,null);

            var dynVmdDomain = cbSelectedMemoryDomain.SelectedItem.ToString();
            var vmdGenFormDomainsComboBox = S.GET<VmdGenForm>().cbSelectedMemoryDomain;

            for(int i = 0; i < vmdGenFormDomainsComboBox.Items.Count; i++)
            {
                if(vmdGenFormDomainsComboBox.Items[i].ToString() == dynVmdDomain)
                {
                    vmdGenFormDomainsComboBox.SelectedIndex = i;
                    return;
                }
            }

        }
    }



}
