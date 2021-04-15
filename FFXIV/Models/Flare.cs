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
        public string str1;
        public string str2;

        public string rs1;
        public string rs2;

        public int max_id;

        public bool sleep;

        public Flare()
        {
            str1 = "";
            str2 = "";
            rs1 = "";
            rs2 = "";
            max_id = 0;
            sleep = false;
        }


        public bool AddTime(string time, int id, string x)
        {
            if (!sleep)
            {
                if (str1.Equals("") || str1.Equals(time))
                {
                    if(str1.Equals(""))
                        BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p -----地火预警<se.1>-----");
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
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p        □  ↑↑");
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p □□■  ↑↑");
                            break;
                        case "13":
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p        □  ←←");
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p □■□  ←←");
                            break;
                        case "23":
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p        □  →→");
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p ■□□  →→");
                            break;
                        case "21":
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p        □  ←←");
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p □□■  ←←");
                            break;
                        case "32":
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p        ■  ↓↓");
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p □□□  ↓↓");
                            break;
                        case "31": 
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p        □  →→");
                            BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand("/p □■□  →→");
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

        public  string TransXtoNum(string x)
        {
            if (x.Equals("84")) return "1";
            if (x.Equals("92")) return "3";
            if (x.Equals("100")) return "2";
            return "Error";
        }

        public  void clear()
        {
            str1 = "";
            str2 = "";
            rs1 = "";
            rs2 = "";
            max_id = 0;
        }

        public void setSleep()
        {
            sleep = true;
        }

        public void setAlive()
        {
            sleep = false;
        }
    }
}
