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

    class LogLineOut : IDisposable
    {
        private StreamWriter sw;

        public LogLineOut()
        {
            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(LLO);
            sw = new StreamWriter("act_logline.log", true);
        }

        public void Dispose()
        {
            sw.Close();
        }

        public void LLO(bool isImport, LogLineEventArgs logInfo)
        {
            sw.Flush();
            sw.WriteLine(logInfo.originalLogLine);
        }
    }
}
