using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using PostNamazu;

namespace BLMHelper
{
    public class BLMHelper : IActPluginV1
    {
        public FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin = null;
        public PostNamazu.PostNamazu postNamazu = null;
        private MainListener mainListener;


        public BLMHelper()
        {
        }

        public void DeInitPlugin()
        {
        }

        void IActPluginV1.InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            pluginScreenSpace.Text = "小鬼的助手";
            pluginScreenSpace.Controls.Add(null);

            ffxiv_Plugin = GetFfxivPlugin();
            postNamazu = GetPostNamazuPlugin();

            mainListener = new MainListener(this);

            pluginStatusText.Text = "小鬼的act助手启动！！！";
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

        /// <summary>
        ///     取得鲶鱼精邮差插件的进程
        /// </summary>
        /// <returns></returns>
        private PostNamazu.PostNamazu GetPostNamazuPlugin()
        {
            PostNamazu.PostNamazu postNamazu = null;
            foreach (var actPluginData in ActGlobals.oFormActMain.ActPlugins)
                if (actPluginData.pluginFile.Name.ToUpper().Contains("鲶鱼精邮差".ToUpper()) &&
                    actPluginData.lblPluginStatus.Text.ToUpper().Contains("鲶鱼精邮差已启动".ToUpper()))
                    postNamazu = (PostNamazu.PostNamazu)actPluginData.pluginObj;
            return postNamazu ?? throw new Exception("找不到鲶鱼精邮差插件");
        }
    }
}
