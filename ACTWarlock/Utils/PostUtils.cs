using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostNamazu;

namespace ACTWarlock.Utils
{

    public class PostUtils
    {
        private static PostNamazu.PostNamazu postNamazu = null;

        public static void sendCommand(string cmd)
        {
            if (postNamazu != null)
            {
                postNamazu.DoTextCommand(cmd);
            }
        }

        public static void sendWayMark(string cmd)
        {
            if (postNamazu != null)
            {
                postNamazu.WriteWaymark(null,-1);
            }
        }

        internal static void Register(PostNamazu.PostNamazu postNamazu)
        {
            PostUtils.postNamazu = postNamazu;
        }
    }
}
