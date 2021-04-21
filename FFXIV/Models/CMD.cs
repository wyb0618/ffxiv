using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV.Models
{
    class CMD
    {
        private string cmd_name { get; set; }
        private string help { get; set; }
        private string cmd { get; set; }
        private string description { get; set; }

        public CMD(string cmd_name, string cmd, string help, string description)
        {
            this.cmd_name = cmd_name;
            this.cmd = cmd;
            this.help = help;
            this.description = description;
        }

        internal static CMD parseString(string temp)
        {
            string[] obj = temp.Split('|');
            return new CMD(obj[0], obj[1], obj[2], obj[3]);
        }
    }
}
