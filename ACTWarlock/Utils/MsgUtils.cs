
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Advanced_Combat_Tracker;

namespace ACTWarlock.Utils
{
    class MsgUtils
    {
        private static string[] server = new string[] { "紫水栈桥", "延夏", "静语庄园", "摩杜纳", "海猫茶屋", "柔风海湾", "琥珀原" };
        public static StreamWriter sw = new StreamWriter("blmHelper_logline.log", false);

        //从名字中去除猫区服务器
        public static string RmServerFromName(string name)
        {
            foreach(string sv in server)
            {
                if (sv.Equals(name)) return name;
                if (name.EndsWith(sv))
                {
                    return name.Remove(name.Length-sv.Length);
                }
            }
            return name;
        }

        public static string GetZoneFromMsg(string message)
        {
            string temp = "01:Changed Zone to ";
            int index = message.LastIndexOf(temp);
            string rs = message.Substring(index + temp.Length);
            rs = rs.Remove(rs.Length - 1, 1);
            return rs;
        }


        public static string GetPlayerNameFromMsg(string message)
        {
            string temp = "02:Changed primary player to ";
            int index = message.LastIndexOf(temp);
            string rs = message.Substring(index + temp.Length);
            rs = rs.Remove(rs.Length - 1, 1);
            return rs;
        }

        //获取日志行时间：系统年月日+日志行时间
        public static DateTime GetTimeFromMsg(string message)
        {
            string dt_str = DateTime.Now.ToString("yyyy:MM:dd") + " " + message.Substring(1, 12);
            DateTime dt =  DateTime.ParseExact(dt_str, "yyyy:MM:dd hh:mm:ss.fff", System.Globalization.CultureInfo.CurrentCulture);
            return dt;
        }

        //获取日志行时间：系统年月日+日志行时间 格式：yyyy-MM-dd hh:mm:ss.fff
        public static string GetTimeStringFromMsg(string message)
        {
            return DateTime.Now.ToString("yyyy-MM-dd") + " " + message.Substring(1, 12);
        }

        //输出本插件logline至根目录
        public static void logs(string message) {
            sw.Flush();
            sw.WriteLine(message);
        }

        //输出本插件logline至根目录
        public static void WriteToLogline(string message)
        {
        }
    }
}
