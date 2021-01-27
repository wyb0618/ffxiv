
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV.Utils
{
    class MsgUtils
    {
        private static string[] server = new string[] { "紫水栈桥", "延夏", "静语庄园", "摩杜纳", "海猫茶屋", "柔风海湾", "琥珀原" };

        //从名字中去除猫区服务器
        public static string RmServerFromName(string name)
        {
            foreach(string sv in server)
            {
                if (sv.Equals(name)) return name;
                if (name.EndsWith(sv))
                {
                    return name.Replace(sv, "");
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

        public static void logs(string message) {

        }
    }
}
