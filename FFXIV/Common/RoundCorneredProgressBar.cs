/*License 
 * MIT License

Copyright (c) 2016 Open-SL https://github.com/Open-SL/RCProgressBar

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoundCorneredProgressBar
{
    public partial class RoundCorneredProgressBar : PictureBox
    {
        private Timer t = new Timer();

        double pbUnit;
        int pbWIDTH, pbHEIGHT, pbComplete;

        Bitmap bmp;
        Graphics g;

        public RoundCorneredProgressBar()
        {
            DoubleBuffered = true;
            ProgressBarColor = Color.FromArgb(224, 224, 224);
            ProgressBackColor = Color.FromArgb(255, 128, 255);
            ProgressFont = new Font(Font.FontFamily, (int)(this.Height * 0.7), FontStyle.Bold);
            ProgressFontColor = Color.Black;
            Value = 300;
        }

        public int Value { get; set; }

        [Category("Appearance")]
        public Color ProgressBarColor { get; set; }

        [Category("Appearance")]
        public Color ProgressBackColor { get; set; }

        [Category("Appearance")]
        public Font ProgressFont { get; set; }

        [Category("Appearance")]
        public Color ProgressFontColor { get; set; }


        private GraphicsPath GetRoundRectagle(Rectangle bounds)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = bounds.Height;
            if (bounds.Height <= 0) radius = 20;
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius,
                        radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }
        private void RecreateRegion()
        {
            var bounds = new Rectangle(this.ClientRectangle.Location, this.ClientRectangle.Size);
            bounds.Inflate(-1, -1);
            this.Region = new Region(GetRoundRectagle(bounds));
            this.Invalidate();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.RecreateRegion();
        }

        /// <summary>
        /// 初始化计时条 
        /// </summary>
        public void Animate()
        {
            pbWIDTH = this.Width;
            pbHEIGHT = this.Height;

            pbUnit = pbWIDTH / 300.0;

            //% [min = 0 max = 300]
            pbComplete = 0;

            bmp = new Bitmap(pbWIDTH, pbHEIGHT);

            //timer
            this.t.Interval = 10;    
            this.t.Tick += new EventHandler(this.t_Tick);
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //graphics
            g = Graphics.FromImage(bmp);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;

            //clear graphics
            g.Clear(ProgressBackColor);

            GraphicsPath path = new GraphicsPath();
            Rectangle innerBounds = new Rectangle(0, 0, (int)(pbComplete * pbUnit), pbHEIGHT);

            //progressbar region filling
            Region r = new Region(GetRoundRectagle(innerBounds));

            g.FillRegion(new SolidBrush(ProgressBarColor), r);

            Console.WriteLine((double)pbComplete / (double)300 * 3.0);
            //draw string
            g.DrawString(String.Format("{0:0.0}", (double)pbComplete / (double)300 * 3.0), new Font(ProgressFont.FontFamily, (int)(pbHEIGHT * 0.6), ProgressFont.Style), new SolidBrush(ProgressFontColor), new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));

            //load bitmap in picturebox picboxPB
            this.Image = bmp;

            //update pbComplete
            pbComplete++;
            if (pbComplete > Value)
            {
                pbComplete = 0;
            }
        }

        /// <summary>
        /// 同步回蓝时间
        /// </summary>
        public void SyncMP()
        {
            this.t.Stop();
            pbComplete = 0;
            this.t.Start();
        }

        /// <summary>
        /// 从0开始计时
        /// </summary>
        public void Start()
        {
            pbComplete = 0;
            this.t.Start();
        }


        /// <summary>
        /// 标志置为0，并停止计时
        /// </summary>
        public void Stop()
        {
            pbComplete = 0;
            this.t.Stop();
        }

        /// <summary>
        /// 获取计时器标志位
        /// </summary>
        public int GetSign()
        {
            return pbComplete;
        }

        /// <summary>
        /// 获取计时器运行状态
        /// </summary>
        public bool TickerEnable()
        {
            return t.Enabled;
        }


    }
}
