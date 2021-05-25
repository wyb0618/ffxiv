using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACTWarlock.Form
{
    class LogWriter
    {
        private TextBox logta;

        public LogWriter(TextBox logta)
        {
            this.logta = logta;
        }

        public void WriteLine(string log)
        {
            logta.Text += log + "\r\n";
        }
    }
}
