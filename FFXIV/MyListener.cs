using System;
using System.Collections.Generic;
using System.IO;
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
        private Person me;

        public MyListener()
        {
            string temp = "";
            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(WhereAmI);
            me = new Person();
        }

        public void Dispose()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= WhereAmI;
        }

        private void WhereAmI(bool isImport, LogLineEventArgs logInfo)
        {

        }

        //ZoneChange
        public void ZoneChange(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("01"))
            {
                string zn = MsgUtils.GetZoneFromMsg(message);
                lock (me)
                {
                    me.zone = zn;
                }
                PostUtils.sendCommand("/e Zone change to " + me.zone);
            }
        }

        //PlayerChange
        public void PlayerChange(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("02"))
            {
                string name = MsgUtils.GetPlayerNameFromMsg(message);
                lock (me)
                {
                    me.name = name;
                }
                PostUtils.sendCommand("/e PlayerName change to " + me.name);
            }
        }
    }
}
