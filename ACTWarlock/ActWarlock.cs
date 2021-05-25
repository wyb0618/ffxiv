using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACTWarlock.Form;
using ACTWarlock.Utils;
using Advanced_Combat_Tracker;

namespace ACTWarlock
{
    class ActWarlock : IActPluginV1
    {
        private PostNamazu.PostNamazu postNamazu = null;
        private LogWriter postNamazuLog;
        private AWForm awForm;

        public ActWarlock()
        {
        }

        public void DeInitPlugin()
        {
            postNamazu.PostNamazuDeinit();
        }
        
        void IActPluginV1.InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            pluginScreenSpace.Text = "ACT语音识别";
            pluginScreenSpace.Controls.Add(awForm = new AWForm());
            pluginStatusText.Text = "ACT语音识别启动";

            postNamazuLog = awForm.GetLogWriter();

            postNamazu = new PostNamazu.PostNamazu(postNamazuLog);

            PostUtils.Register(postNamazu);
        }
    }
}
