using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;

namespace BLMHelper
{
    public class BLMForm : UserControl
    {
        private TextBox act_msg;
        private TextBox output_msg;
        private CheckBox mpTicker_check;
        private TextBox bar_x;
        private TextBox bar_y;
        private Label label1;
        private Label label2;
        private Button reset_button;
        private Button button1;
        private GroupBox groupBox1;

        #region Designer Created Code (Avoid editing)
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.act_msg = new System.Windows.Forms.TextBox();
            this.output_msg = new System.Windows.Forms.TextBox();
            this.mpTicker_check = new System.Windows.Forms.CheckBox();
            this.bar_x = new System.Windows.Forms.TextBox();
            this.bar_y = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reset_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // act_msg
            // 
            this.act_msg.Location = new System.Drawing.Point(44, 132);
            this.act_msg.Multiline = true;
            this.act_msg.Name = "act_msg";
            this.act_msg.Size = new System.Drawing.Size(831, 115);
            this.act_msg.TabIndex = 2;
            this.act_msg.Text = "测试消息：";
            // 
            // output_msg
            // 
            this.output_msg.Location = new System.Drawing.Point(44, 267);
            this.output_msg.Multiline = true;
            this.output_msg.Name = "output_msg";
            this.output_msg.Size = new System.Drawing.Size(831, 115);
            this.output_msg.TabIndex = 3;
            this.output_msg.Text = "OUTPUT：";
            // 
            // mpTicker_check
            // 
            this.mpTicker_check.AutoSize = true;
            this.mpTicker_check.Location = new System.Drawing.Point(25, 24);
            this.mpTicker_check.Name = "mpTicker_check";
            this.mpTicker_check.Size = new System.Drawing.Size(89, 19);
            this.mpTicker_check.TabIndex = 2;
            this.mpTicker_check.Text = "回蓝监视";
            this.mpTicker_check.UseVisualStyleBackColor = true;
            this.mpTicker_check.CheckedChanged += new System.EventHandler(this.mpTicker_check_CheckedChanged);
            // 
            // bar_x
            // 
            this.bar_x.Location = new System.Drawing.Point(159, 22);
            this.bar_x.Name = "bar_x";
            this.bar_x.Size = new System.Drawing.Size(100, 25);
            this.bar_x.TabIndex = 5;
            this.bar_x.Text = "0";
            // 
            // bar_y
            // 
            this.bar_y.Location = new System.Drawing.Point(159, 53);
            this.bar_y.Name = "bar_y";
            this.bar_y.Size = new System.Drawing.Size(100, 25);
            this.bar_y.TabIndex = 4;
            this.bar_y.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y:";
            // 
            // reset_button
            // 
            this.reset_button.Location = new System.Drawing.Point(284, 25);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(75, 23);
            this.reset_button.TabIndex = 8;
            this.reset_button.Text = "reset";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.reset_button);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bar_y);
            this.groupBox1.Controls.Add(this.bar_x);
            this.groupBox1.Controls.Add(this.mpTicker_check);
            this.groupBox1.Location = new System.Drawing.Point(19, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "资源监视";
            // 
            // BLMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.output_msg);
            this.Controls.Add(this.act_msg);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "BLMForm";
            this.Size = new System.Drawing.Size(915, 443);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            MPTicker.GetMpTicker().SetLocation(this.bar_x.Text, this.bar_y.Text);
        }

        #endregion

        #endregion
        public BLMForm()
        {
            InitializeComponent();
        }

        private void mpTicker_check_CheckedChanged(object sender, EventArgs e)
        {
            if (mpTicker_check.Checked)
            {
                MPTicker.GetMpTicker().ShowTicker();
            }
            else
            {
                MPTicker.GetMpTicker().HideTicker();
            }
        }

        public void add_msg(String str)
        {
            this.act_msg.Text += str; 
        }
        public void add_msg2(String str)
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
            this.output_msg.Text += str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MPTicker.GetMpTicker().TickerEnable())
               MPTicker.GetMpTicker().Stop();
            else
               MPTicker.GetMpTicker().Start();
        }
    }
}
