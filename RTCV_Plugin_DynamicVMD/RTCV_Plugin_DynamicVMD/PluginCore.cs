using DYNAMICVMD.UI;
using NLog;
using RTCV.Common;
using RTCV.NetCore;
using RTCV.PluginHost;
using RTCV.UI;
using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using RTCV.UI.Modular;

namespace DYNAMICVMD
{
    [Export(typeof(IPlugin))]
    public class DYNAMICVMD : IPlugin, IDisposable
    {
        //-------[ Plugin metadata ]-------

        // >>> Make sure you rename BOTH the namespace and class (Very important)
        public string Description => "Manipulate a VMD on the fly";
        public string Author => "ircluzar";
        public Version Version => new Version(1, 0, 1);

        //-----[ Plugin loading workflow ]-----

        //Server is StandaloneRTC process (RTCV UI)
        //Client is Emulator process

        //Tells on which sides the plugin has to load
        public RTCSide SupportedSide => RTCSide.Server;

        //Tells where we want the form to load when OpenTools button is pressed
        public static RTCSide FormRequestSide = RTCSide.Server;     

        //-----[ Additional information ]------

        //Don't forget to also change the following values in the project Application properties:
        // - Assembly name
        // - Default namespace
        // - Assembly Information



        #region Plugin Implementation mechanics

        public static RTCSide CurrentSide = RTCSide.Both;
        public static PluginForm PluginForm = (PluginForm)null;
        internal static PluginConnectorEMU connectorEMU = (PluginConnectorEMU)null;
        internal static PluginConnectorRTC connectorRTC = (PluginConnectorRTC)null;

        // the name of the plugin is auto-generated from the class name.
        public string Name => nameof(DYNAMICVMD).Replace("_"," ");

        public void Dispose()
        {
        }

        public bool Start(RTCSide side)
        {
            Logging.GlobalLogger.Info(string.Format("{0} v{1} initializing on {2} side.", (object)this.Name, (object)this.Version, (object)side));
            if (side == RTCSide.Client) // Emulator Process
            {
                //Plugin initialization
                connectorEMU = new PluginConnectorEMU(this);
                PluginForm = new PluginForm(this);
                S.SET<PluginForm>(PluginForm);
            }
            else if (side == RTCSide.Server || side == RTCSide.Both) // StandaloneRTC Process (RTCV UI) or Attached mode
            {
                //Plugin initialization

                if (side == RTCSide.Both)
                    connectorEMU = new PluginConnectorEMU(this);

                connectorRTC = new PluginConnectorRTC(this);
                PluginForm = new PluginForm(this);
                S.SET<PluginForm>(PluginForm);


                string cname = CamelCase(Name);
                //Registers the plugin in RTC's OpenTools form (in the Advanced Memory Tools)
                switch (FormRequestSide)
                {
                    case RTCSide.Client:
                        //S.GET<OpenToolsForm>().RegisterTool(cname, $"Open {cname}", () => { LocalNetCoreRouter.Route(Ep.EMU_SIDE, Commands.SHOW_WINDOW, true); });
                        break;
                    case RTCSide.Server:
                        //S.GET<OpenToolsForm>().RegisterTool(cname, $"Open {cname}", () => { LocalNetCoreRouter.Route(Ep.RTC_SIDE, Commands.SHOW_WINDOW, true); });
                        UICore.mtForm.cbSelectBox.Items.Insert(UICore.mtForm.cbSelectBox.Items.Count - 1, PluginForm);
                        break;
                    case RTCSide.Both: //if you use this, you might want to pop a different form on each side. see SHOW_WINDOW in PluginConnectorEMU.cs and PluginConnectorRTC.cs
                        //S.GET<OpenToolsForm>().RegisterTool(cname, $"Open {cname}", () => { 
                        //    LocalNetCoreRouter.Route(Ep.EMU_SIDE, Commands.SHOW_WINDOW, true);
                        //    LocalNetCoreRouter.Route(Ep.RTC_SIDE, Commands.SHOW_WINDOW, true);
                        //});
                        break;
                }

            }


            Logging.GlobalLogger.Info(string.Format("{0} v{1} initialized.", (object)this.Name, (object)this.Version));
            CurrentSide = side;
            return true;
        }

        public bool StopPlugin()
        {
            if (!S.ISNULL<PluginForm>() && !S.GET<PluginForm>().IsDisposed)
            {
                S.GET<PluginForm>().HideOnClose = false;
                S.GET<PluginForm>().Close();
            }
            return true;
        }

        //this should be in a helper class 
        public static string CamelCase(string text)
        {
            char[] a = text.ToLower().ToCharArray();

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i == 0 || a[i - 1] == ' ' ? char.ToUpper(a[i]) : a[i];

            }
            return new string(a);
        }

        #endregion

    }
}
