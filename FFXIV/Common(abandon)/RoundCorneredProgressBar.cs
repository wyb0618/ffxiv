﻿/*License 
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
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace RoundCorneredProgressBar
{
    public partial class RoundCorneredProgressBar : PictureBox
    {
        private static System.Threading.Timer t;
        private static Stopwatch stw_total;
        private static bool TimerStatus = false;

        double pbUnit;
        int pbWIDTH, pbHEIGHT;
        long pbComplete;

        Bitmap bmp;
        Graphics g;

        public RoundCorneredProgressBar()
        {
            DoubleBuffered = true;
            // 
            // rcp 初始化
            // 
            BackColor = System.Drawing.SystemColors.ButtonShadow;
            Location = new System.Drawing.Point(1, 1);
            Name = "rcp";
            ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            ProgressBarColor = System.Drawing.Color.OrangeRed;
            ProgressFont = new System.Drawing.Font("宋体", 35F, System.Drawing.FontStyle.Bold);
            ProgressFontColor = System.Drawing.Color.Black;
            Size = new System.Drawing.Size(150, 15);
            TabIndex = 2;
            TabStop = false;
            Value = 3000;

            pbWIDTH = this.Width;
            pbHEIGHT = this.Height;

            pbUnit = pbWIDTH / 3000.0;

            //% [min = 0 max = 300]
            pbComplete = 0;

            bmp = new Bitmap(pbWIDTH, pbHEIGHT);
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

        private void t_Tick(Object state)
        {
            //update pbComplete
            pbComplete = stw_total.ElapsedMilliseconds%3000;

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
            
            //draw string
            g.DrawString(String.Format("{0:0.0}", (double)pbComplete / (double)3000 * 3.0), new Font(ProgressFont.FontFamily, (int)(pbHEIGHT * 0.6), ProgressFont.Style), new SolidBrush(ProgressFontColor), new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));

            //load bitmap in picturebox picboxPB
            this.Image = bmp;
        }

        /// <summary>
        /// 同步回蓝时间
        /// </summary>
        public void SyncMP()
        {
            Stop();
            Start();
        }

        /// <summary>
        /// 从0开始计时
        /// </summary>
        public void Start()
        {
            stw_total = new Stopwatch();
            if (t != null)
            {
                t.Dispose();
            }
            pbComplete = 0;
            stw_total.Start();
            //new timer
            t = new System.Threading.Timer(t_Tick,null,0,25);
            TimerStatus = true;
        }

        /// <summary>
        /// 标志置为0，并停止计时
        /// </summary>
        public void Stop()
        {
            if (t != null)
            {
                t.Dispose();
            }
            stw_total.Reset();
            pbComplete = 0;
            TimerStatus = false;
        }

        /// <summary>
        /// 获取计时器标志位
        /// </summary>
        public long GetSign()
        {
            return pbComplete;
        }

        /// <summary>
        /// 获取计时器运行状态
        /// </summary>
        public bool TickerEnable()
        {
            return TimerStatus;
        }
    }
}
