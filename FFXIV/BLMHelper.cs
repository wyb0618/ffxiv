﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
//using PostNamazu;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FFXIV.Utils;

namespace BLMHelper
{
    public class BLMHelper : IActPluginV1
    {
        public FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin = null;

        public PostNamazu.PostNamazu postNamazu = null;
        
        public static MainForm mainForm = null;
        public static BLMHelper bLMHelper = null;

        private  MainListener mainListener = null;
        private  ChatListener chatListener = null;
        private  LogLineOut logLineOut = null;


        public BLMHelper()
        {
        }

        public void DeInitPlugin()
        {
            if (mainListener != null)
                mainListener.Dispose();
            if (chatListener != null)
                chatListener.Dispose();
            if (logLineOut != null)
                chatListener.Dispose();
            mainForm.Dispose();
            postNamazu.PostNamazuDeinit();
            MsgUtils.sw.Close();
        }
        
        void IActPluginV1.InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            bLMHelper = this;

            pluginScreenSpace.Text = "小鬼的助手";

            mainForm = new MainForm(this);

            pluginScreenSpace.Controls.Add(mainForm);

            //ffxiv_Plugin = GetFfxivPlugin();

            pluginStatusText.Text = "小鬼的act助手启动！！！";

            postNamazu = new PostNamazu.PostNamazu(mainForm);


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

        internal void InitMainListener()
        {
            if(mainListener==null)
                mainListener = new MainListener();
        }

        internal void DeinitMainListener()
        {
            if (mainListener != null)
            {  
                mainListener.Dispose();
                mainListener = null;
            }
        }

        internal void InitLogLineOut()
        {
            if (logLineOut == null)
                logLineOut = new LogLineOut();
        }

        internal void DeinitLogLineOut()
        {
            if (logLineOut != null)
            {
                logLineOut.Dispose();
                logLineOut = null;
            }
        }

        /// <summary>
        ///     取得鲶鱼精邮差插件的进程
        /// </summary>
        /// <returns></returns>
        //private PostNamazu.PostNamazu GetPostNamazuPlugin()
        //{
        //    PostNamazu.PostNamazu pn = null;
        //    foreach (var actPluginData in ActGlobals.oFormActMain.ActPlugins)
        //        if (actPluginData.pluginFile.Name.ToUpper().Contains("PostNamazu".ToUpper()) &&
        //            actPluginData.lblPluginStatus.Text.ToUpper().Contains("鲶鱼精邮差已启动".ToUpper())) {
        //            pn = (PostNamazu.PostNamazu)actPluginData.pluginObj;
        //        }
        //    return pn ?? throw new Exception("找不到鲶鱼精邮差插件");
        //}
    }
}
