using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Advanced_Combat_Tracker;
using FFXIV.Models;
using FFXIV.Utils;
using FFXIV_ACT_Plugin;
using FFXIV_ACT_Plugin.Common;
using FFXIV_ACT_Plugin.Common.Models;


namespace BLMHelper
{
    //public delegate void PlayerMPChangeDelegate();

    //public event PlayerMPChangeDelegate OnPlayerMPChange;

    class ChatListener : IDisposable
    {
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin = null;
        private string channel = "/s";

        public ChatListener(FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin)
        {
            this.ffxiv_Plugin = ffxiv_Plugin;
            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(AutoInvite);
        }

        public void Dispose()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= CMD;
            ActGlobals.oFormActMain.OnLogLineRead -= AutoInvite;
        }

        //123自动进组
        //-> /tell 女拳斗士蒂法@静语庄园 123 
        public void AutoInvite(bool isImport, LogLineEventArgs logInfo)
        {
            if (BLMHelper.mainForm.GetAutoInvite()) {
                string message = logInfo.originalLogLine;
                string type = message.Substring(15, 2);

                if (type != null && type.Equals("00"))
                {
                    string rs = message.Substring(15);
                    string[] obj = rs.Split(':');

                    if (obj[1].Equals("000d") && obj[3].Equals("123"))
                    {
                        HttpUtils.sendCommand("/pcmd add <r>");
                    }
                }
            }
        }

        //tts小队播报
        public void AutoPartyTTS(bool isImport, LogLineEventArgs logInfo)
        {

        }


        public void CMD(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("00"))
            {
                string rs = message.Substring(15);
                string[] obj = rs.Split(':');

                if (obj[1].Equals("0010")) {

                    //查询频道
                    if (obj[2].Equals("chats"))
                    {
                        HttpUtils.sendCommand("/e ---- Chat Status ----");
                        HttpUtils.sendCommand("/e 当前频道->'"+ channel+"'");
                        return;
                    }

                    //切换频道
                    if (obj[2].StartsWith("cto "))
                    {
                        HttpUtils.sendCommand("/e ---- Chat Status ----");
                        HttpUtils.sendCommand("/e 当前频道->'" + channel + "'");
                        return;
                    }

                }

            }
        }
    }
}
