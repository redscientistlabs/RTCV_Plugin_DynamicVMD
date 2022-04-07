using System;
using System.IO;
using System.Windows.Forms;

namespace DYNAMICVMD.UI
{

    partial class PluginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.mtbRange = new RTCV.UI.Components.Controls.MultiTrackBar();
            this.mtbStartAddress = new RTCV.UI.Components.Controls.MultiTrackBar();
            this.pnRange = new System.Windows.Forms.Panel();
            this.btnSendToStatic = new System.Windows.Forms.Button();
            this.cbSelectedMemoryDomain = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnRefreshDomains = new System.Windows.Forms.Button();
            this.pnDomain = new System.Windows.Forms.Panel();
            this.lbEndianTypeValue = new System.Windows.Forms.Label();
            this.lbWordSizeValue = new System.Windows.Forms.Label();
            this.lbDomainSizeValue = new System.Windows.Forms.Label();
            this.lbEndianTypeLabel = new System.Windows.Forms.Label();
            this.lbWordSizeLabel = new System.Windows.Forms.Label();
            this.lbDomainSizeLabel = new System.Windows.Forms.Label();
            this.cbForceSolo = new System.Windows.Forms.CheckBox();
            this.tbRangeExpression = new System.Windows.Forms.TextBox();
            this.pnRange.SuspendLayout();
            this.pnDomain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Dynamic VMD";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.ForeColor = System.Drawing.Color.White;
            this.version.Location = new System.Drawing.Point(162, 35);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(14, 13);
            this.version.TabIndex = 41;
            this.version.Text = "v";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(215, 22);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(103, 27);
            this.btnStart.TabIndex = 45;
            this.btnStart.Tag = "color:dark2";
            this.btnStart.Text = "Start Plugin";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // mtbRange
            // 
            this.mtbRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mtbRange.Checked = false;
            this.mtbRange.DisplayCheckbox = true;
            this.mtbRange.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.mtbRange.Hexadecimal = true;
            this.mtbRange.Label = "Range";
            this.mtbRange.Location = new System.Drawing.Point(6, 70);
            this.mtbRange.Maximum = ((long)(65535));
            this.mtbRange.Minimum = ((long)(0));
            this.mtbRange.Name = "mtbRange";
            this.mtbRange.Size = new System.Drawing.Size(188, 60);
            this.mtbRange.TabIndex = 141;
            this.mtbRange.Tag = "color:dark2";
            this.mtbRange.UncapNumericBox = false;
            this.mtbRange.Value = ((long)(0));
            this.mtbRange.ValueChanged += new System.EventHandler<RTCV.UI.Components.Controls.ValueUpdateEventArgs>(this.ComputeRangeExpression);
            this.mtbRange.CheckChanged += new System.EventHandler<System.EventArgs>(this.ComputeRangeExpression);
            // 
            // mtbStartAddress
            // 
            this.mtbStartAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mtbStartAddress.Checked = false;
            this.mtbStartAddress.DisplayCheckbox = false;
            this.mtbStartAddress.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.mtbStartAddress.Hexadecimal = true;
            this.mtbStartAddress.Label = "Start Address";
            this.mtbStartAddress.Location = new System.Drawing.Point(7, 5);
            this.mtbStartAddress.Maximum = ((long)(65535));
            this.mtbStartAddress.Minimum = ((long)(0));
            this.mtbStartAddress.Name = "mtbStartAddress";
            this.mtbStartAddress.Size = new System.Drawing.Size(188, 60);
            this.mtbStartAddress.TabIndex = 142;
            this.mtbStartAddress.Tag = "color:dark2";
            this.mtbStartAddress.UncapNumericBox = false;
            this.mtbStartAddress.Value = ((long)(0));
            this.mtbStartAddress.ValueChanged += new System.EventHandler<RTCV.UI.Components.Controls.ValueUpdateEventArgs>(this.ComputeRangeExpression);
            // 
            // pnRange
            // 
            this.pnRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnRange.Controls.Add(this.btnSendToStatic);
            this.pnRange.Controls.Add(this.mtbStartAddress);
            this.pnRange.Controls.Add(this.mtbRange);
            this.pnRange.Location = new System.Drawing.Point(238, 58);
            this.pnRange.Name = "pnRange";
            this.pnRange.Size = new System.Drawing.Size(200, 180);
            this.pnRange.TabIndex = 143;
            this.pnRange.Tag = "color:dark2";
            this.pnRange.Visible = false;
            // 
            // btnSendToStatic
            // 
            this.btnSendToStatic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendToStatic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnSendToStatic.FlatAppearance.BorderSize = 0;
            this.btnSendToStatic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendToStatic.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSendToStatic.ForeColor = System.Drawing.Color.White;
            this.btnSendToStatic.Location = new System.Drawing.Point(16, 142);
            this.btnSendToStatic.Name = "btnSendToStatic";
            this.btnSendToStatic.Size = new System.Drawing.Size(169, 27);
            this.btnSendToStatic.TabIndex = 143;
            this.btnSendToStatic.Tag = "color:dark3";
            this.btnSendToStatic.Text = "Send to Static VMD";
            this.btnSendToStatic.UseVisualStyleBackColor = false;
            this.btnSendToStatic.Click += new System.EventHandler(this.btnSendToStatic_Click);
            // 
            // cbSelectedMemoryDomain
            // 
            this.cbSelectedMemoryDomain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbSelectedMemoryDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectedMemoryDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectedMemoryDomain.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbSelectedMemoryDomain.ForeColor = System.Drawing.Color.White;
            this.cbSelectedMemoryDomain.FormattingEnabled = true;
            this.cbSelectedMemoryDomain.Location = new System.Drawing.Point(14, 69);
            this.cbSelectedMemoryDomain.Name = "cbSelectedMemoryDomain";
            this.cbSelectedMemoryDomain.Size = new System.Drawing.Size(173, 25);
            this.cbSelectedMemoryDomain.TabIndex = 144;
            this.cbSelectedMemoryDomain.Tag = "color:dark1";
            this.cbSelectedMemoryDomain.SelectedIndexChanged += new System.EventHandler(this.HandleSelectedMemoryDomainChange);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(11, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 13);
            this.label17.TabIndex = 145;
            this.label17.Text = "Memory Domain";
            // 
            // btnRefreshDomains
            // 
            this.btnRefreshDomains.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshDomains.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnRefreshDomains.FlatAppearance.BorderSize = 0;
            this.btnRefreshDomains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDomains.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefreshDomains.ForeColor = System.Drawing.Color.White;
            this.btnRefreshDomains.Location = new System.Drawing.Point(14, 15);
            this.btnRefreshDomains.Name = "btnRefreshDomains";
            this.btnRefreshDomains.Size = new System.Drawing.Size(173, 27);
            this.btnRefreshDomains.TabIndex = 147;
            this.btnRefreshDomains.Tag = "color:dark3";
            this.btnRefreshDomains.Text = "Refresh Domains";
            this.btnRefreshDomains.UseVisualStyleBackColor = false;
            this.btnRefreshDomains.Click += new System.EventHandler(this.btnRefreshDomains_Click);
            // 
            // pnDomain
            // 
            this.pnDomain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnDomain.Controls.Add(this.lbEndianTypeValue);
            this.pnDomain.Controls.Add(this.lbWordSizeValue);
            this.pnDomain.Controls.Add(this.lbDomainSizeValue);
            this.pnDomain.Controls.Add(this.lbEndianTypeLabel);
            this.pnDomain.Controls.Add(this.lbWordSizeLabel);
            this.pnDomain.Controls.Add(this.lbDomainSizeLabel);
            this.pnDomain.Controls.Add(this.btnRefreshDomains);
            this.pnDomain.Controls.Add(this.cbSelectedMemoryDomain);
            this.pnDomain.Controls.Add(this.label17);
            this.pnDomain.Location = new System.Drawing.Point(16, 58);
            this.pnDomain.Name = "pnDomain";
            this.pnDomain.Size = new System.Drawing.Size(200, 180);
            this.pnDomain.TabIndex = 144;
            this.pnDomain.Tag = "color:dark2";
            this.pnDomain.Visible = false;
            // 
            // lbEndianTypeValue
            // 
            this.lbEndianTypeValue.AutoSize = true;
            this.lbEndianTypeValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbEndianTypeValue.ForeColor = System.Drawing.Color.White;
            this.lbEndianTypeValue.Location = new System.Drawing.Point(91, 151);
            this.lbEndianTypeValue.Name = "lbEndianTypeValue";
            this.lbEndianTypeValue.Size = new System.Drawing.Size(42, 13);
            this.lbEndianTypeValue.TabIndex = 152;
            this.lbEndianTypeValue.Text = "#####";
            // 
            // lbWordSizeValue
            // 
            this.lbWordSizeValue.AutoSize = true;
            this.lbWordSizeValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbWordSizeValue.ForeColor = System.Drawing.Color.White;
            this.lbWordSizeValue.Location = new System.Drawing.Point(91, 133);
            this.lbWordSizeValue.Name = "lbWordSizeValue";
            this.lbWordSizeValue.Size = new System.Drawing.Size(42, 13);
            this.lbWordSizeValue.TabIndex = 151;
            this.lbWordSizeValue.Text = "#####";
            // 
            // lbDomainSizeValue
            // 
            this.lbDomainSizeValue.AutoSize = true;
            this.lbDomainSizeValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbDomainSizeValue.ForeColor = System.Drawing.Color.White;
            this.lbDomainSizeValue.Location = new System.Drawing.Point(91, 115);
            this.lbDomainSizeValue.Name = "lbDomainSizeValue";
            this.lbDomainSizeValue.Size = new System.Drawing.Size(42, 13);
            this.lbDomainSizeValue.TabIndex = 150;
            this.lbDomainSizeValue.Text = "#####";
            // 
            // lbEndianTypeLabel
            // 
            this.lbEndianTypeLabel.AutoSize = true;
            this.lbEndianTypeLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbEndianTypeLabel.ForeColor = System.Drawing.Color.White;
            this.lbEndianTypeLabel.Location = new System.Drawing.Point(13, 151);
            this.lbEndianTypeLabel.Name = "lbEndianTypeLabel";
            this.lbEndianTypeLabel.Size = new System.Drawing.Size(72, 13);
            this.lbEndianTypeLabel.TabIndex = 149;
            this.lbEndianTypeLabel.Text = "Endian Type:";
            // 
            // lbWordSizeLabel
            // 
            this.lbWordSizeLabel.AutoSize = true;
            this.lbWordSizeLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbWordSizeLabel.ForeColor = System.Drawing.Color.White;
            this.lbWordSizeLabel.Location = new System.Drawing.Point(12, 133);
            this.lbWordSizeLabel.Name = "lbWordSizeLabel";
            this.lbWordSizeLabel.Size = new System.Drawing.Size(62, 13);
            this.lbWordSizeLabel.TabIndex = 148;
            this.lbWordSizeLabel.Text = "Word Size:";
            // 
            // lbDomainSizeLabel
            // 
            this.lbDomainSizeLabel.AutoSize = true;
            this.lbDomainSizeLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbDomainSizeLabel.ForeColor = System.Drawing.Color.White;
            this.lbDomainSizeLabel.Location = new System.Drawing.Point(12, 115);
            this.lbDomainSizeLabel.Name = "lbDomainSizeLabel";
            this.lbDomainSizeLabel.Size = new System.Drawing.Size(73, 13);
            this.lbDomainSizeLabel.TabIndex = 145;
            this.lbDomainSizeLabel.Text = "Domain Size:";
            // 
            // cbForceSolo
            // 
            this.cbForceSolo.AutoSize = true;
            this.cbForceSolo.Checked = true;
            this.cbForceSolo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbForceSolo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbForceSolo.ForeColor = System.Drawing.Color.White;
            this.cbForceSolo.Location = new System.Drawing.Point(383, 32);
            this.cbForceSolo.Name = "cbForceSolo";
            this.cbForceSolo.Size = new System.Drawing.Size(55, 17);
            this.cbForceSolo.TabIndex = 145;
            this.cbForceSolo.Text = "SOLO";
            this.cbForceSolo.UseVisualStyleBackColor = true;
            this.cbForceSolo.Visible = false;
            // 
            // tbRangeExpression
            // 
            this.tbRangeExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRangeExpression.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbRangeExpression.Font = new System.Drawing.Font("Consolas", 8F);
            this.tbRangeExpression.ForeColor = System.Drawing.Color.White;
            this.tbRangeExpression.Location = new System.Drawing.Point(324, 12);
            this.tbRangeExpression.Multiline = true;
            this.tbRangeExpression.Name = "tbRangeExpression";
            this.tbRangeExpression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRangeExpression.Size = new System.Drawing.Size(53, 40);
            this.tbRangeExpression.TabIndex = 146;
            this.tbRangeExpression.Tag = "color:dark1";
            this.tbRangeExpression.Visible = false;
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.tbRangeExpression);
            this.Controls.Add(this.cbForceSolo);
            this.Controls.Add(this.pnDomain);
            this.Controls.Add(this.pnRange);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.version);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(390, 250);
            this.Name = "PluginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "color:dark1";
            this.Text = "Plugin Form";
            this.Load += new System.EventHandler(this.PluginForm_Load);
            this.pnRange.ResumeLayout(false);
            this.pnDomain.ResumeLayout(false);
            this.pnDomain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PluginForm_Load(object sender, EventArgs e)
        {
            setDllDir();
        }

        public string setDllDir()
        {
            //get the full location of the assembly with DaoTests in it
            string fullPath = System.Reflection.Assembly.GetAssembly(typeof(DYNAMICVMD)).Location;

            //get the folder that's in
            dlldir = Path.GetDirectoryName(fullPath);
            return dlldir;

        }


        #endregion
        private System.Windows.Forms.Label label1;
        private string dlldir;
        private Label version;
        private Button btnStart;
        private RTCV.UI.Components.Controls.MultiTrackBar mtbRange;
        private RTCV.UI.Components.Controls.MultiTrackBar mtbStartAddress;
        private Panel pnRange;
        public ComboBox cbSelectedMemoryDomain;
        private Label label17;
        private Button btnRefreshDomains;
        private Panel pnDomain;
        public Label lbDomainSizeLabel;
        public Label lbWordSizeLabel;
        public Label lbEndianTypeLabel;
        public Label lbDomainSizeValue;
        public Label lbWordSizeValue;
        public Label lbEndianTypeValue;
        private Button btnSendToStatic;
        public CheckBox cbForceSolo;
        private TextBox tbRangeExpression;
    }
}
