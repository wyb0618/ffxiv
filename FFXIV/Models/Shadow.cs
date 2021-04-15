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
        private Dictionary<int, string> dic;
        private int max_id = 0;
        private string bossname = "";
        private string channel = "";

        public Shadow()
        {
            dic = new Dictionary<int, string>();
            int max_id = 0;
            string bossname = "";
            string channel = "";
        }

        public void clear()
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
        public  void add(string player_name, int shadow_id)
        {
            if (dic == null)
            {
                dic = new Dictionary<int, string>();
                max_id = 0;
            }

            if (shadow_id > max_id) max_id = shadow_id;

            dic.Add(shadow_id, player_name);
        }

        public  Boolean outputAlexA()
        {
            if (dic.Count == 8)
            {
                if(!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id]).Equals(bossname))
                    //左右是，面朝亚历山大方向
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id]) + "：分摊，右侧");
                if (bossname.Equals(""))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 1]).Equals(bossname))
                    //人群对面指其他7个人穿过场地圆心的斜对面
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 1]) + "：大圈大圈，人群中间（不是");

                if (bossname.Equals(""))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 2]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 2]) + "：闪电，请去人群左侧");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 3]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 3]) + "：闪电，请去人群左侧");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 4]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 4]) + "：闪电，请去人群左侧");
                BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 5]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 5]) + "：分摊，右侧");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 6]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 6]) + "：分摊，右侧");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 7]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 7]) + "：分摊，右侧");

                dic.Clear();
                max_id = 0;

                return true;
            }
            return false;
        }

        public bool outputAlexB()
        {
            if (dic.Count == 8)
            {
                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id]) + "：大暗，站对角");

                if (bossname.Equals(""))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 1]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 1]) + "：大光，贴电网");

                if (bossname.Equals(""))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 3]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 3]) + "：小光，判定后注意集合");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 7]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 7]) + "：小光，判定后注意集合");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 5]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 5]) + "：小光，判定后注意集合");

                if (bossname.Equals(""))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" ----------");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 6]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 6]) + "：小暗蓝线，注意引！导！超！级！跳！");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 2]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 2]) + "：小暗无线，注意引！导！超！级！跳！");

                if (!bossname.Equals("") && MsgUtils.RmServerFromName(dic[max_id - 4]).Equals(bossname))
                    BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(channel+" " + MsgUtils.RmServerFromName(dic[max_id - 4]) + "：小暗近线，注意集合");

                dic.Clear();
                max_id = 0;

                return true;
            }
            return false;
        }
    }
}

