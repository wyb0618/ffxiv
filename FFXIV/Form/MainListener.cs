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

    class MainListener : IDisposable
    {
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin = null;
        private string playername = "女拳斗士蒂法";
        private string zonename = "";

        public MainListener(FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin)
        {
            this.ffxiv_Plugin = ffxiv_Plugin;

            //ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(Alex2ndPractice);

            //ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(BLM);
            //ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(AlexRecorder);
            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(ZoneChange);
            //ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(AlexAandB);

            //ffxiv_Plugin.DataSubscription.ParsedLogLine += new ParsedLogLineDelegate(ParsedLogLineHandler);
        }

        public void Dispose()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= BLM;
            ActGlobals.oFormActMain.OnLogLineRead -= AlexA;
            ActGlobals.oFormActMain.OnLogLineRead -= AlexB;
            ActGlobals.oFormActMain.OnLogLineRead -= AlexAandB;
            ActGlobals.oFormActMain.OnLogLineRead -= Exflare;
            ActGlobals.oFormActMain.OnLogLineRead -= AlexRecorder;
            ActGlobals.oFormActMain.OnLogLineRead -= ZoneChange;
            ActGlobals.oFormActMain.OnLogLineRead -= Alex2ndPractice;

            //ffxiv_Plugin.DataSubscription.ParsedLogLine -= ParsedLogLineHandler;
        }

        public void BLM(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);
            
            //以太步
            if (type!=null&&type.Equals("15"))
            {
                string rs = message.Substring(15);
                string[] obj = rs.Split(':');
                if (playername != null && playername.Equals(obj[2]) && obj[4].Equals("以太步"))
                {
                    double dis = MathUtils.calDistance(double.Parse(obj[29]), double.Parse(obj[39]), double.Parse(obj[30]), double.Parse(obj[40]));
                    string dis_str = "";
                    if (dis < 4)
                    {
                        dis_str = "太短了，就这？就这？";
                    }
                    else if (dis < 8)
                    {
                        dis_str = "用腿跑都比这快";
                    }
                    else if (dis > 25)
                    {
                        dis_str = "太酷了，这就是核动力轮椅吗？";
                    }
                    else
                    {
                        dis_str = obj[6]+"...我的超人";
                    }
                    string party_str = "/p 使用以太步飞到" + obj[6] + "身边，飞行距离" + String.Format("{0:N1}", dis) + "米（" + dis_str + "）。";

                    HttpUtils.sendCommand(party_str);
                }
            }
        }


        //亚历山大犯错记录
        public void AlexRecorder(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("00"))
            {
                string rs = message.Substring(15);
                string[] obj = rs.Split(':');
                if (obj[1].Equals("000e") && obj[3].Length > 5 && obj[3].StartsWith("alex："))
                {
                    if (!obj[3].Equals("alex：记录成功"))
                    {
                        string name = MsgUtils.RmServerFromName(obj[2].Substring(1));
                        string result = obj[3].Substring(5);
                        string rdmsg = "{\"name\":\"" + name + "\",\"result\":\"" + result + "\"}";
                        HttpUtils.sendRecord(rdmsg);
                    }
                }

                if (obj[1].Equals("000e") && obj[3].Length > 5 && obj[3].StartsWith("Alex：") && MsgUtils.RmServerFromName(obj[2].Substring(1)).Equals(playername))
                {
                    string[] name_result = obj[3].Substring(5).Split('@');
                    string name = name_result[0];
                    string result = name_result[1];
                    string rdmsg = "{\"name\":\"" + name + "\",\"result\":\"" + result + "\"}";
                    HttpUtils.sendRecord(rdmsg);
                }

            }
        }

        //Zone change
        public void ZoneChange(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("01"))
            {
                string zn = MsgUtils.GetZoneFromMsg(message);
                zonename = zn;

                HttpUtils.sendCommand("/e Zone change to" + zonename);

                if (zn.Equals("亚历山大绝境战"))
                {
                    ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(AlexAandB);
                    ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(Exflare);
                    HttpUtils.sendCommand("/e P4 笨比提示器启动");
                }
                else
                {
                    ActGlobals.oFormActMain.OnLogLineRead -= AlexA;
                    ActGlobals.oFormActMain.OnLogLineRead -= AlexB;
                    ActGlobals.oFormActMain.OnLogLineRead -= AlexAandB;
                    ActGlobals.oFormActMain.OnLogLineRead -= Exflare;
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
                if (obj[1].StartsWith("1") && obj[3].StartsWith("4") && obj[7].Equals("0062") && obj[8].StartsWith("4") && obj[9].Equals("000F"))
                {
                    int shadowid = Convert.ToInt32(obj[3], 16);
                    lock (typeof(Shadow)) {
                        Shadow.add(obj[2], shadowid);
                        if (Shadow.outputAlexA())
                        {
                            ActGlobals.oFormActMain.OnLogLineRead -= AlexA;
                            HttpUtils.sendCommand("/p ----- @一测结束@ -----");
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
                if (obj[1].StartsWith("1") && obj[3].StartsWith("4") && obj[7].Equals("0062") && obj[8].StartsWith("4") && obj[9].Equals("000F"))
                {
                    int shadowid = Convert.ToInt32(obj[3], 16);
                    lock (typeof(Shadow))
                    {
                        Shadow.add(obj[2], shadowid);
                        if (Shadow.outputAlexB())
                        {
                            ActGlobals.oFormActMain.OnLogLineRead -= AlexB;
                            HttpUtils.sendCommand("/p ----- @二测结束@ -----");
                        }
                    }

                }
            }
        }

        //地火3穿1 L 型
        public void Exflare(bool isImport, LogLineEventArgs logInfo)
        {

            //15:400115BB:完美亚历山大:488F:神圣大审判:E0000000:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0:44(33):44:0:10000:0:1000:84:116:
            //^.{14} 15:4[0-9A-F]{7}:[^:]*?:488F:.*?:44:44:0:10000:0:1000:(?<x>[^:]*?):(?<y>[^:]*?):


            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            if (type != null && type.Equals("15"))
            {
                string rs = message.Substring(15);
                string[] obj = rs.Split(':');
                if(obj[1].StartsWith("4")&& obj[3].StartsWith("488F") && obj[4].StartsWith("神圣大审判") && obj[33].StartsWith("44") && obj[34].StartsWith("44")
                    && obj[35].StartsWith("0") && obj[36].StartsWith("10000") && obj[37].StartsWith("0") && obj[38].StartsWith("1000"))
                {
                    lock (typeof(Flare))
                    {
                        //左中右 顺序是84、100、92
                        if (Flare.AddTime(message.Substring(0, 9), Convert.ToInt32(obj[1], 16), obj[39]))
                        {
                            Flare.setSleep();
                            ActGlobals.oFormActMain.OnLogLineRead -= Exflare;
                            new Thread(() => {
                                Thread.Sleep(15000);
                                Flare.setAlive();
                                ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(Exflare);
                            }).Start();
                        }
                    }
                }

            }


            }


        public void Alex2ndPractice(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);

            //[01:38:47.000] 00:000e:女拳斗士蒂法:1

            if (type != null && type.Equals("00"))
            {
                string rs = message.Substring(15);
                string[] obj = rs.Split(':');

                if (obj[1].Equals("000a"))
                {
                    if (obj[3].StartsWith("Alex2nd"))
                    {
                        new Thread(() => {
                            Alex2nd.Timeline();
                        }).Start();
                    }
                }
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
