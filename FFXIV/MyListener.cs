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

    class MyListener : IDisposable
    {
        private string channel = "/s";

        public MyListener()
        {
            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(CMD);
        }

        public void Dispose()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= CMD;
        }

        public void CMD(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("00"))
            {
                string rs = message.Substring(15);
                string[] obj = rs.Split(':');

                if (obj[1].Equals("0010"))
                {

                    //设置afk自动回复
                    if (obj[2].Equals("chats"))
                    {

                    }

                    //切换频道
                    if (obj[2].StartsWith("cto "))
                    {
                        PostUtils.sendCommand("/e ---- Chat Status ----");
                        PostUtils.sendCommand("/e 当前频道->'" + channel + "'");
                        return;
                    }

                }

            }
        }
    }
}
