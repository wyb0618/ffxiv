using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV.Models.Msg
{
    class CastingMsg
    {
        public string logline { get; set; }
        public string system_datetime { get; set; }
        public string caster { get; set; }
        public string target { get; set; }
        public string cast_name { get; set; }
        public string logline_time { get; set; }

        public CastingMsg()
        {
            logline = "";
            system_datetime = "";
            caster = "";
            target = "";
            cast_name = "";
            logline_time = "";
        }
    }
}
