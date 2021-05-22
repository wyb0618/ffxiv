using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using Advanced_Combat_Tracker;
using FFXIV.Models;
using FFXIV.Models.Msg;
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
        private Timer timer;

        public MyListener()
        {
            string temp = "";
            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(ZoneChange);
            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(PlayerChange);
            me = new Person();
            timer = new Timer();

        }

        public void Dispose()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= ZoneChange;
            ActGlobals.oFormActMain.OnLogLineRead -= PlayerChange;
        }

        private void WhereAmI()
        {
            string msg = "";
            msg = "小鬼（" + me.name + "）目前正在 " + me.zone;
            HttpUtils.sendWhereAmI(msg);
        }

        //ZoneChange
        private void ZoneChange(bool isImport, LogLineEventArgs logInfo)
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
                PostUtils.sendCommand("/e Zone Change To " + me.zone);
            }
        }

        //PlayerChange
        private void PlayerChange(bool isImport, LogLineEventArgs logInfo)
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
                PostUtils.sendCommand("/e PlayerName Change To " + me.name);
            }
        }
        
        }
    }