using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFXIV.Models;
using FFXIV.Utils;
using FFXIV_ACT_Plugin;
using FFXIV_ACT_Plugin.Common;
using FFXIV_ACT_Plugin.Common.Models;


namespace BLMHelper
{
    //public delegate void PlayerMPChangeDelegate();

    //public event PlayerMPChangeDelegate OnPlayerMPChange;

    class MainListener
    {
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin = null;
        private PostNamazu.PostNamazu postNamazu = null;
        private BLMHelper blmHelper;
        private string playername = null;

        public MainListener(BLMHelper blmHelper)
        {
            this.blmHelper = blmHelper;
            this.ffxiv_Plugin = blmHelper.ffxiv_Plugin;
            this.postNamazu = blmHelper.postNamazu;
        }
        
        public void ParsedLogLineDelegateHandler(uint sequence, int messagetype, String message)
        {

            if (messagetype == 15)
            {
                string rs = message.Substring(15);
                string[] obj = rs.Split(':');
                if (playername != null&& playername.Equals(obj[6])&& obj[4].Equals("以太步")) {
                    double dis =  MathUtils.calDistance(double.Parse(obj[29]), double.Parse(obj[38]), double.Parse(obj[30]), double.Parse(obj[39]));
                    string dis_str = "";
                    if (dis < 5)
                    {
                        dis_str = "太短了，就这？就这？";
                    }
                    else if (dis < 10)
                    {
                        dis_str = "用腿跑都比这快";
                    }
                    else if (dis > 20)
                    {
                        dis_str = "太酷了，这就是核动力轮椅吗";
                    }
                    else
                    {
                        dis_str = "非常感谢！";
                    }
                    string party_str = "/p " + playername + "使用以太步飞到" + obj + "身边！，";
                    postNamazu.DoTextCommand(party_str);
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
}
