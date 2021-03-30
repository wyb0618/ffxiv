using Advanced_Combat_Tracker;
using FFXIV.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FFXIV.Models
{
    class Alex2nd : IDisposable
    {
        private Person p;
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin = null;
        private static string channel = "/s ";

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Alex2nd(string name)
        {
            ffxiv_Plugin = BLMHelper.BLMHelper.staticBlm.ffxiv_Plugin;
            p = new Person(name);

            ActGlobals.oFormActMain.OnLogLineRead += new LogLineEventDelegate(Pos);
        }

        public void Pos(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);
   
            //[19:59:41.798] 27:10086AA3:女拳斗士蒂法:102279:102279:10000:10000:0:0:-22.74041:0.04224195:399.9998:0.08714119:

            if (type != null && type.Equals("27"))
            {
                string rs = message.Substring(15);
                string[] obj = rs.Split(':');

                if (obj[1].Equals(p.name))
                {
                    lock (p)
                    {
                        p.x = Double.Parse(obj[9]);
                        p.y = Double.Parse(obj[10]);
                        p.face = Double.Parse(obj[12]);
                    }

                }
            }
        }

        public static void Timeline()
        {
            Random r = new Random();

            //[01:38:47.000] 00:000e:女拳斗士蒂法:1

            HttpUtils.sendCommand(channel + "-----二运即将开始<se.1>-----");
            Thread.Sleep(1000);
            HttpUtils.sendCommand(channel + "----- 5 <se.1>-----");
            Thread.Sleep(1000);
            HttpUtils.sendCommand(channel + "----- 4 <se.1>-----");
            Thread.Sleep(1000);
            HttpUtils.sendCommand(channel + "----- 3 <se.1>-----");
            Thread.Sleep(1000);
            HttpUtils.sendCommand(channel + "----- 2 <se.1>-----");
            Thread.Sleep(1000);
            HttpUtils.sendCommand(channel + "----- 1 <se.1>-----");
            Thread.Sleep(1000);


            //飞机随机刷新在1-2点
            HttpUtils.sendCommand(channel + "飞机出现在"+(int)(r.NextDouble()*2+1)+"点 <se.1>");
            Thread.Sleep(1000);
            HttpUtils.sendCommand(channel + "残暴出现 <se.1>");
            Thread.Sleep(6000);
            HttpUtils.sendCommand(channel + "麻将出现，你是"+ (int)(r.NextDouble() * 8 + 1) + "<se.1>");
            Thread.Sleep(1000);
            HttpUtils.sendCommand(channel + "飞盘读条<se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "飞盘读条33%<se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "飞盘读条66%<se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "飞盘判定<se.1>");


            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "1号<se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "2号;残暴落地<se.1>");

            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "3号;灵泉1判定<se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "4号<se.1>");


            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "5号;灵泉2判定;末世宣言、十字圣礼结束<se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "6号<se.1>");

            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "7号;灵泉3判定<se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "8号<se.1>");
        }

        //飞机在1点，1号
        public void Situation1_1()
        {
            HttpUtils.sendCommand(channel  + "飞盘读条 <se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "飞盘读条33%<se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "飞盘读条66%<se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "飞盘判定<se.1>");

            lock (p)
            {
                //防击退判断
                if (!p.ablity)
                {
                    HttpUtils.sendCommand(channel + "错误:没有开防击退");
                    return;
                }
                //位置判断
                if (p.Distance(-9.5, -9.5, 2.5))
                {
                    HttpUtils.sendCommand(channel + "错误:没有站在正确的位置上");
                    return;
                }
            }

            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "1号<se.1>");

            //1号位置与面向
            lock (p)
            {
                if (p.FaceBetween(-2.8, -1.8))
                {
                    HttpUtils.sendCommand(channel + "错误:1号没有面向外");
                    return;
                }
            }



            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "2号;残暴落地<se.1>");

            
            lock (p)
            {
                //引导判断
                if (p.Distance(-17.4, -17.4, 1) && Math.Abs(p.x-p.y)<0.5)
                {
                    HttpUtils.sendCommand(channel + "错误:引导没有站在正确的位置上");
                    return;
                }
            }
            
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "3号;灵泉1判定<se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "4号<se.1>");


            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "5号;灵泉2判定;末世宣言、十字圣礼结束<se.1>");

            //安全点回归判定
            lock (p)
            {
                if (p.Distance(-24.0, -24.0, 2))
                {
                    HttpUtils.sendCommand(channel + "错误:1号没有面向外");
                    return;
                }
            }

            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "6号<se.1>");

            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "7号;灵泉3判定<se.1>");
            Thread.Sleep(2000);
            HttpUtils.sendCommand(channel + "8号<se.1>");

        }

    }
}
