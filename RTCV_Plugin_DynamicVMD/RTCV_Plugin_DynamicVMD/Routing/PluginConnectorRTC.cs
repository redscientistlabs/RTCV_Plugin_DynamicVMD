using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYNAMICVMD;
using RTCV.CorruptCore;
using RTCV.NetCore;
using System.Windows.Forms;
using DYNAMICVMD.UI;
using RTCV.Common;

namespace DYNAMICVMD
{
    /// <summary>
    /// This lies on the emulator side
    /// </summary>
    class PluginConnectorRTC : IRoutable
    {
        DYNAMICVMD plugin;
        public PluginConnectorRTC(DYNAMICVMD _plugin)
        {
            plugin = _plugin;

            LocalNetCoreRouter.registerEndpoint(this, Ep.RTC_SIDE);
        }

        public object OnMessageReceived(object sender, NetCoreEventArgs e)
        {
            var message = e.message;
            var advancedMessage = message as NetCoreAdvancedMessage;

            switch (e.message.Type)
            {
                case Commands.SHOW_WINDOW:
                    try
                    {
                        SyncObjectSingleton.FormExecute(() =>
                        {
                            if (((Control)S.GET<UI.PluginForm>()).IsDisposed)
                            {
                                DYNAMICVMD.PluginForm = new PluginForm(plugin);
                                S.SET<PluginForm>(DYNAMICVMD.PluginForm);
                            }
                            ((Control)S.GET<PluginForm>()).Show();
                            ((Form)S.GET<PluginForm>()).Activate();
                        });
                        break;
                    }
                    catch
                    {
                        Logging.GlobalLogger.Error($"{nameof(PluginConnectorEMU)}: SHOW_WINDOW failed Reason:\r\n" + e.ToString());
                        break;
                    }
                //case Commands.SPECUPDATE:
                //    SyncObjectSingleton.FormExecute(() =>
                //    {
                //        Spec.VisualizerSpec?.Update((PartialSpec)advancedMessage.objectValue, false);
                //    });
                //    break;

                //case Commands.SPECPUSH:
                //    SyncObjectSingleton.FormExecute(() =>
                //    {
                //        var temp = new FullSpec((PartialSpec)advancedMessage.objectValue, !RtcCore.Attached);

                //        Spec.VisualizerSpec = new FullSpec(temp.GetPartialSpec(), !RtcCore.Attached);
                //        Spec.VisualizerSpec.SpecUpdated += (ob, eas) =>
                //        {
                //            PartialSpec partial = eas.partialSpec;
                //            LocalNetCoreRouter.Route(Ep.EMU_SIDE, Commands.SPECPUSH, partial, true);
                //        };
                //        RTCV.CorruptCore.MemoryDomains.RefreshDomains();
                //    });
                //    e.setReturnValue(true);
                //    break;
                //case Commands.

            break;
                default:
                    break;
            }





            //switch (e.message.Type)
            //{
            //    case NetcoreCommands.REMOTE_OPENHEXEDITOR:
            //        {
            //            SyncObjectSingleton.FormExecute(() =>
            //            {
            //                if (S.GET<HexEditor>().IsDisposed)
            //                {
            //                    S.SET(new HexEditor());
            //                }
            //                S.GET<HexEditor>().Restart();
            //                S.GET<HexEditor>().Show();
            //            });
            //        }
            //        break;

            //    case NetcoreCommands.EMU_OPEN_HEXEDITOR_ADDRESS:
            //        {
            //            var temp = advancedMessage.objectValue as object[];
            //            string domain = (string)temp[0];
            //            long address = (long)temp[1];

            //            MemoryInterface mi = MemoryDomains.GetInterface(domain);
            //            if (mi == null)
            //                break;

            //            SyncObjectSingleton.FormExecute(() =>
            //            {
            //                if (S.GET<HexEditor>().IsDisposed)
            //                {
            //                    S.SET(new HexEditor());
            //                }
            //                S.GET<HexEditor>().Restart();
            //                S.GET<HexEditor>().Show();
            //                S.GET<HexEditor>().SetDomain(mi);
            //                S.GET<HexEditor>().GoToAddress(address);
            //            });
            //        }
            //        break;
            //}
            return e.returnMessage;
        }
    }
}
