using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FFXIV_WYB
{
    public class MPTimer:Form
    {
        private ProgressBar progressBar1;
        private static MPTimer mpTimer;
        private MPTimer()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.MarqueeAnimationSpeed = 3000;
            this.progressBar1.Maximum = 3;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(130, 13);
            this.progressBar1.TabIndex = 0;
            // 
            // MPTimer
            // 
            this.ClientSize = new System.Drawing.Size(130, 13);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "MPTimer";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        public static MPTimer GetTimer()
        {
            if (mpTimer == null)
                return (mpTimer = new MPTimer());
            else
                return mpTimer;
        }

        public void StartTimer()
        {
            GetTimer().Show();
        }

        private void darwingTimer()
        {

        }
    }
}
