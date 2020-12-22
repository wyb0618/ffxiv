using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using FFXIV_WYB;

namespace FFXIV_WYB
{
    public class BLMHelper : IActPluginV1
    {
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin _ffxiv_Plugin = null;
        private BLMForm BlmForm = null;
        
        public BLMHelper()
        {
        }

        public void DeInitPlugin()
        {
            //_ffxivPlugin.DataSubscription.ProcessChanged -= ProcessChanged;
        }

        void IActPluginV1.InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            BlmForm = new BLMForm();
            pluginScreenSpace.Text = "黑魔助手";
            pluginScreenSpace.Controls.Add(BlmForm);

            _ffxiv_Plugin = GetFfxivPlugin();
            BLMListener bLMListener = new BLMListener(_ffxiv_Plugin, BlmForm);

            pluginStatusText.Text = "黑魔助手启动";
        }

        /// <summary>
        ///     取得解析插件的进程（从獭爹那里偷来的）
        /// </summary>
        /// <returns></returns>
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin GetFfxivPlugin()
        {
            FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxivActPlugin = null;
            foreach (var actPluginData in ActGlobals.oFormActMain.ActPlugins)
                if (actPluginData.pluginFile.Name.ToUpper().Contains("FFXIV_ACT_Plugin".ToUpper()) &&
                    actPluginData.lblPluginStatus.Text.ToUpper().Contains("FFXIV Plugin Started.".ToUpper()))
                    ffxivActPlugin = (FFXIV_ACT_Plugin.FFXIV_ACT_Plugin)actPluginData.pluginObj;
            return ffxivActPlugin ?? throw new Exception("找不到FFXIV解析插件");
        }
    }
}
