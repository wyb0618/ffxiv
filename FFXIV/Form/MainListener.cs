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

        public MainListener(FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin)
        {
            this.ffxiv_Plugin = ffxiv_Plugin;

            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(LogLineDelegateHandler);
            ffxiv_Plugin.DataSubscription.ParsedLogLine += new ParsedLogLineDelegate(ParsedLogLineHandler);
        }

        public void Dispose()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= LogLineDelegateHandler;
            ffxiv_Plugin.DataSubscription.ParsedLogLine -= ParsedLogLineHandler;
        }

        public void LogLineDelegateHandler(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

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

        public void ParsedLogLineHandler(uint sequence, int messagetype, string message)
        {

            if(messagetype == 00)
            {
                //亚历山大错误记录
                string[] obj = message.Split('|');
                if (obj[2].Equals("000e")&& obj[4].Length>5 && obj[4].StartsWith("alex："))
                {
                    string name = MsgUtils.RmServerFromName(obj[3]);
                    string result = obj[4].Substring(5);
                    string rdmsg = "{\"name\":\"" + name + "\",\"result\":\"" + result + "\"}";
                    HttpUtils.sendRecord(rdmsg);
                }
            }
        }
    }
        
    }
