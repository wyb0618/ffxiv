using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACTWarlock.Form
{
    public partial class AWForm : UserControl
    {
        private LogWriter logWriter;

        public AWForm()
        {
            InitializeComponent();
            logWriter = new LogWriter(logta);
        }

        internal LogWriter GetLogWriter()
        {
            return logWriter;
        }
    }
}
