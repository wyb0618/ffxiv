using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV.Utils
{
    public static class PostUtils
    {
        public static void sendCommand(string cmd)
        {
            if (BLMHelper.BLMHelper.bLMHelper != null)
            {
                BLMHelper.BLMHelper.bLMHelper.postNamazu.DoTextCommand(cmd);
            }
        }

        public static void sendWayMark(string cmd)
        {
            if (BLMHelper.BLMHelper.bLMHelper != null)
            {
                BLMHelper.BLMHelper.bLMHelper.postNamazu.WriteWaymark(null,-1);
            }
        }
    }
}
