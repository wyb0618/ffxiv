
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV.Utils
{
    class MsgUtils
    {
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
    }
}
