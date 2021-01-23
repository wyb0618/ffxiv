using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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

    class MainListener : IDisposable
    {
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin = null;
        private string playername = "女拳斗士蒂法";
        private string zonename = "";

        public MainListener(FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin)
        {
            this.ffxiv_Plugin = ffxiv_Plugin;

            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(LogLineDelegateHandler);
            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(AlexAandB);
            //ffxiv_Plugin.DataSubscription.ParsedLogLine += new ParsedLogLineDelegate(ParsedLogLineHandler);
        }

        public void Dispose()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= LogLineDelegateHandler;
            ActGlobals.oFormActMain.OnLogLineRead -= AlexA;
            ActGlobals.oFormActMain.OnLogLineRead -= AlexB;
            ActGlobals.oFormActMain.OnLogLineRead -= AlexAandB;
            //ffxiv_Plugin.DataSubscription.ParsedLogLine -= ParsedLogLineHandler;
        }

        public void LogLineDelegateHandler(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("01"))
            {
            }

            if (type!=null&&type.Equals("15"))
            {
                string rs = message.Substring(15);
                string[] obj = rs.Split(':');
                if (playername != null && playername.Equals(obj[2]) && obj[4].Equals("以太步"))
                {
                    double dis = MathUtils.calDistance(double.Parse(obj[29]), double.Parse(obj[39]), double.Parse(obj[30]), double.Parse(obj[40]));
                    string dis_str = "";
                    if (dis < 5)
                    {
                        dis_str = "太短了，就这？就这？";
                    }
                    else if (dis < 10)
                    {
                        dis_str = "用腿跑都比这快";
                    }
                    else if (dis > 25)
                    {
                        dis_str = "太酷了，这就是核动力轮椅吗？";
                    }
                    else
                    {
                        dis_str = "(*^▽^*)";
                    }
                    string party_str = "/p " + playername + "使用以太步飞到" + obj[6] + "身边，飞行距离" + String.Format("{0:N1}", dis) + "米（" + dis_str + "）。";

                    HttpUtils.sendCommand(party_str);
                }
            }
        }

        //Alex 未来观测
        public void AlexAandB(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("14"))
            {
                string[] obj = message.Substring(15).Split(':');
                if (obj[1].Equals("487B"))
                {
                    HttpUtils.sendCommand("/p ----- @一测开始@ -----");
                    ActGlobals.oFormActMain.OnLogLineRead -= AlexA;
                    ActGlobals.oFormActMain.OnLogLineRead -= AlexB;
                    Shadow.clear();
                    ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(AlexA);
                }
                else if (obj[1].Equals("4B13"))
                {
                    HttpUtils.sendCommand("/p ----- @二测开始@ -----");
                    ActGlobals.oFormActMain.OnLogLineRead -= AlexA;
                    ActGlobals.oFormActMain.OnLogLineRead -= AlexB;
                    Shadow.clear();
                    ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(AlexB);
                }
            }
        }

        //未来观测a
        public void AlexA(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("23"))
            {
                string rs = message.Substring(15);
                string[] obj = rs.Split(':');
                if (obj[1].StartsWith("1") && obj[3].StartsWith("4") && obj[5].Equals("0062") && obj[6].StartsWith("4") && obj[6].Equals("000F"))
                {
                    int shadowid = Convert.ToInt32(obj[3], 16);
                    lock (typeof(Shadow)) {
                        Shadow.add(obj[2], shadowid);
                        if (Shadow.outputAlexA())
                        {
                            ActGlobals.oFormActMain.OnLogLineRead -= AlexA;
                            HttpUtils.sendCommand("----- @一测结束@ -----");
                        }
                    }

                }
            }

        }

        //未来观测b
        public void AlexB(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("23"))
            {
                string rs = message.Substring(15);
                string[] obj = rs.Split(':');
                if (obj[1].StartsWith("1") && obj[3].StartsWith("4") && obj[5].Equals("0062") && obj[6].StartsWith("4") && obj[6].Equals("000F"))
                {
                    int shadowid = Convert.ToInt32(obj[3], 16);
                    lock (typeof(Shadow))
                    {
                        Shadow.add(obj[2], shadowid);
                        if (Shadow.outputAlexB())
                        {
                            ActGlobals.oFormActMain.OnLogLineRead -= AlexB;
                            HttpUtils.sendCommand("----- @二测结束@ -----");
                        }
                    }

                }
            }
        }

        //地火3穿1 L 型
        public void Exflare(bool isImport, LogLineEventArgs logInfo)
        {

            //^.{14} 15:4[0-9A-F]{7}:[^:]*?:488F:.*?:44:44:0:10000:0:1000:(?<x>[^:]*?):(?<y>[^:]*?):

            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("15"))
            {
            }
        }


        //public void ParsedLogLineHandler(uint sequence, int messagetype, string message)
        //{

        //    if(messagetype == 00)
        //    {
        //        //亚历山大错误记录
        //        string[] obj = message.Split('|');
        //        if (obj[2].Equals("000e")&& obj[4].Length>5 && obj[4].StartsWith("alex："))
        //        {
        //            string name = MsgUtils.RmServerFromName(obj[3]);
        //            string result = obj[4].Substring(5);
        //            string rdmsg = "{\"name\":\"" + name + "\",\"result\":\"" + result + "\"}";
        //            HttpUtils.sendRecord(rdmsg);
        //        }

        //        //亚历山大错误记录指名
        //        if (obj[2].Equals("000e") && obj[4].Length > 5 && obj[4].StartsWith("Alex："))
        //        {
        //            try {
        //               string result_name = obj[4].Substring(5);
        //               string[] rs = result_name.Split('@');
        //               string rdmsg = "{\"name\":\"" + rs[0] + "\",\"result\":\"" + rs[1] + "\"}";
        //               HttpUtils.sendRecord(rdmsg);
        //            }catch(Exception e)
        //            {

        //            }
        //        }
        //    }
        //}
    }
        
    }
