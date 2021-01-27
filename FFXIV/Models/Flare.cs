using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFXIV.Utils;

namespace FFXIV.Models
{
    class Flare
    {
        public static string str1 = "";
        public static string str2 = "";

        public static string rs1 = "";
        public static string rs2 = "";

        public static int max_id = 0;

        public static bool sleep = false;

        public static bool AddTime(string time, int id, string x)
        {
            if (!sleep)
            {
                if (str1.Equals("") || str1.Equals(time))
                {
                    if(str1.Equals(""))
                        HttpUtils.sendCommand("-----地火预警<se.1>-----");
                    str1 = time;
                    if (id > max_id)
                    {
                        max_id = id;
                        rs1 = TransXtoNum(x);
                    }
                }else if (max_id == id){

                   rs2 = TransXtoNum(x);
                }

                if (!rs1.Equals("") && !rs2.Equals(""))
                {
                    string rs = rs1 + rs2;

                    switch (rs)
                    {
                        case "12":
                            HttpUtils.sendCommand("/p     □  ↑↑");
                            HttpUtils.sendCommand("/p □□■  ↑↑");
                            break;
                        case "13":
                            HttpUtils.sendCommand("/p     □  ←←");
                            HttpUtils.sendCommand("/p □■□  ←←");
                            break;
                        case "23":
                            HttpUtils.sendCommand("/p     □  →→");
                            HttpUtils.sendCommand("/p ■□□  →→");
                            break;
                        case "21":
                            HttpUtils.sendCommand("/p     □  ←←");
                            HttpUtils.sendCommand("/p □□■  ←←");
                            break;
                        case "32":
                            HttpUtils.sendCommand("/p     ■  ↓↓");
                            HttpUtils.sendCommand("/p □□□  ↓↓");
                            break;
                        case "31":
                            HttpUtils.sendCommand("/p     □  →→");
                            HttpUtils.sendCommand("/p □■□  →→");
                            break;
                        default:
                            ;
                            break;
                    };
                    clear();
                    return true;
                }
                return false;
            }
            return false;
        }

        public static string TransXtoNum(string x)
        {
            if (x.Equals("84")) return "1";
            if (x.Equals("92")) return "3";
            if (x.Equals("100")) return "2";
            return "Error";
        }

        public static void clear()
        {
            str1 = "";
            str2 = "";
            rs1 = "";
            rs2 = "";
            max_id = 0;
        }

        public static void setSleep()
        {
            sleep = true;
        }

        public static void setAlive()
        {
            sleep = false;
        }
    }
}
