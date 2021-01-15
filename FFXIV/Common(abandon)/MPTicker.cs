using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BLMHelper
{
    public class MPTicker : Form
    {
        private RoundCorneredProgressBar.RoundCorneredProgressBar rcp;
        private static MPTicker mpTicker;

        public int x { get; set; }
        public int y { get; set; }

        private MPTicker()
        {
            this.InitializeComponent();
            this.x = this.Location.X;
            this.y = this.Location.Y;
        }

        private void InitializeComponent()
        {
            this.rcp = new RoundCorneredProgressBar.RoundCorneredProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.rcp)).BeginInit();
            this.SuspendLayout();
            // 
            // rcp
            // 
            this.rcp.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.rcp.Location = new System.Drawing.Point(4, 4);
            this.rcp.Name = "rcp";
            this.rcp.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rcp.ProgressBarColor = System.Drawing.Color.OrangeRed;
            this.rcp.ProgressFont = new System.Drawing.Font("宋体", 35F, System.Drawing.FontStyle.Bold);
            this.rcp.ProgressFontColor = System.Drawing.Color.Black;
            this.rcp.Size = new System.Drawing.Size(150, 15);
            this.rcp.TabIndex = 2;
            this.rcp.TabStop = false;
            this.rcp.Value = 3000;
            // 
            // MPTicker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(160, 25);
            this.Controls.Add(this.rcp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MPTicker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Red;
            ((System.ComponentModel.ISupportInitialize)(this.rcp)).EndInit();
            this.ResumeLayout(false);

        }

        public static MPTicker GetMpTicker()
        {
            if (mpTicker == null)
            {
                mpTicker = new MPTicker();
            }
            return mpTicker;
        }

        public void SetLocation(String x, String y)
        {
            int x_int, y_int;
            try
            {
                int.TryParse(x, out x_int);
                int.TryParse(y, out y_int);
                this.Location = new System.Drawing.Point(x_int, y_int);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 显示计时器
        /// </summary>
        public void ShowTicker()
        {
            Show();
        }

        /// <summary>
        /// 隐藏计时器
        /// </summary>
        public void HideTicker()
        {
            Hide();
        }

        /// <summary>
        /// 若差异小于200ms，不重置计时器，保持计时器活跃状态
        /// </summary>
        public void SyncAndStart()
        {
            if (rcp.GetSign() > 20 || rcp.GetSign() < 280)
            {
                rcp.SyncMP();
            }
        }

        /// <summary>
        /// 从0开始计时
        /// </summary>
        public void Start()
        {
            rcp.Start();
        }

        /// <summary>
        /// 暂停计时器
        /// </summary>
        public void Stop()
        { 
            rcp.Stop();
        }

        /// <summary>
        /// 返回计时器运行状态
        /// </summary>
        public bool TickerEnable()
        {
            return rcp.TickerEnable();
        }
    }
}
