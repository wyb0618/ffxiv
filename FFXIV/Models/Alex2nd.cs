using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV.Models
{
    class Alex2nd:IDisposable
    {
        private string name;
        private string posX;
        private string posY;
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin ffxiv_Plugin = null;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Alex2nd(string name)
        {
            ffxiv_Plugin = BLMHelper.BLMHelper.staticBlm.ffxiv_Plugin;
            this.name = name;

        }

        public void Pos(bool isImport, LogLineEventArgs logInfo)
        {
            string message = logInfo.originalLogLine;
            string type = message.Substring(15, 2);
        }
}
