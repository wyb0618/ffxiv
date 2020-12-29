using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLMHelper
{
    public class MPTicker: Form
    {
        public ProgressBar progressBar1;
        private static MPTicker mpTicker;
        private MPTicker()
        {
            this.InitializeComponent();
        }
        public static MPTicker GetMpTicker()
        {
            if (mpTicker == null)
            {
                return (mpTicker = new MPTicker());
            }
            else
            {
                return mpTicker;
            }
        }

        public void Start()
        {
            
        }

        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.MarqueeAnimationSpeed = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(150, 10);
            this.progressBar1.TabIndex = 0;
            // 
            // MPTicker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(150, 10);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MPTicker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);

        }
    }
}
