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

    class MainListener: IDisposable
    {
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin = null;
        private string playername = "女拳斗士蒂法";

        public MainListener(FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin)
        {
            this.ffxiv_Plugin = ffxiv_Plugin;

            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(LogLineDelegateHandler);
        }

        public void Dispose()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= LogLineDelegateHandler;
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
                            dis_str = "非常感谢！";
                        }
                        string party_str = "/p " + playername + "使用以太步飞到" + obj[6] + "身边，飞行了" + String.Format("{0:N1}", dis) + "米（" + dis_str + "）。";

                        WebClient client = new WebClient();
                        client.Encoding = Encoding.UTF8;
                        client.Headers[HttpRequestHeader.ContentType] = "text";
                        string response = client.UploadString("http://127.0.0.1:4869/command", party_str);
                        client.Dispose();
                    }
                }
            }

            //if(messagetype == "casting")
            //{
            //    lock (this)
            //    {
            //        if (!mpTicker.Visible)
            //            mpTicker.ShowTicker();
            //    }
            //}

        }
        
    }
