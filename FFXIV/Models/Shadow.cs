using FFXIV.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV.Models
{
    class Shadow
    {
        private static Dictionary<int, string> dic;
        private static int max_id = 0;
        private static string bossname = "";
        private static string channel = "";

        public static void clear()
        {
            bossname = BLMHelper.BLMHelper.mainForm.GetALexBossName();
            channel = BLMHelper.BLMHelper.mainForm.GetALexChannel();

            if (channel.Equals(""))
            {
                channel = "/p";
            }

            if (dic != null)
            {
                dic.Clear();
            }
            max_id = 0;
        }
        public static void add(string player_name, int shadow_id)
        {
            if (dic == null)
            {
                dic = new Dictionary<int, string>();
                max_id = 0;
            }

            if (shadow_id > max_id) max_id = shadow_id;

            dic.Add(shadow_id, player_name);
        }

        public static Boolean outputAlexA()
        {
            if (dic.Count == 8)
            {
                if(!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id]).Equals(bossname))
                //左右是，面朝亚历山大方向
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id]) + "：分摊，右侧");
                if (bossname.Equals(""))
                    HttpUtils.sendCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 1]).Equals(bossname))
                    //人群对面指其他7个人穿过场地圆心的斜对面
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 1]) + "：大圈，请去对面");

                if (bossname.Equals(""))
                    HttpUtils.sendCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 2]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 2]) + "：闪电，请去人群左侧");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 3]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 3]) + "：闪电，请去人群左侧");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 4]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 4]) + "：闪电，请去人群左侧");
                HttpUtils.sendCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 5]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 5]) + "：分摊，右侧");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 6]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 6]) + "：分摊，右侧");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 7]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 7]) + "：分摊，右侧");

                dic.Clear();
                max_id = 0;

                return true;
            }
            return false;
        }

        internal static bool outputAlexB()
        {
            if (dic.Count == 8)
            {
                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id]) + "：大暗！3、4对角线交点，站3、4中间的鲨了吧");

                if (bossname.Equals(""))
                    HttpUtils.sendCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 1]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 1]) + "：大光，请在A点侧和电！网！贴！贴！");

                if (bossname.Equals(""))
                    HttpUtils.sendCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 3]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 3]) + "：小光，站在3点，注意集合");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 7]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 7]) + "：小光，站在3点，注意集合");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 5]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 5]) + "：小光，站在3点，注意集合");

                if (bossname.Equals(""))
                    HttpUtils.sendCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 6]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 6]) + "：小暗蓝线，站在4点；注意引！导！超！级！跳！");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 2]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 2]) + "：小暗无线，3、4点中间；注意引！导！超！级！跳！");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 4]).Equals(bossname))
                    HttpUtils.sendCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 4]) + "：小暗近线，站在3点；注意集合");

                dic.Clear();
                max_id = 0;

                return true;
            }
            return false;
        }
    }
}

