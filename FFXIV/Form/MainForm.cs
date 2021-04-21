using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;

namespace BLMHelper
{
    public class MainForm : UserControl
    {
        private GroupBox groupBox1;
        private TextBox Alex_channel;
        private Label label2;
        private TextBox Alex_bossname;
        private Label label1;
        private CheckBox Alex_on;
        private CheckBox AutoInvite;

        private BLMHelper bLMHelper;
        private TextBox logta;
        private Label label3;
        private GroupBox groupBox2;
        private CheckBox checkBox1;
        private CheckBox Chat_on;
        private CheckBox LogLine;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Alex_on = new System.Windows.Forms.CheckBox();
            this.Alex_channel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Alex_bossname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AutoInvite = new System.Windows.Forms.CheckBox();
            this.logta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Chat_on = new System.Windows.Forms.CheckBox();
            this.LogLine = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Alex_on);
            this.groupBox1.Controls.Add(this.Alex_channel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Alex_bossname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(19, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "绝亚笨比提示装置";
            // 
            // Alex_on
            // 
            this.Alex_on.AutoSize = true;
            this.Alex_on.Location = new System.Drawing.Point(19, 24);
            this.Alex_on.Name = "Alex_on";
            this.Alex_on.Size = new System.Drawing.Size(59, 19);
            this.Alex_on.TabIndex = 2;
            this.Alex_on.Text = "启动";
            this.Alex_on.UseVisualStyleBackColor = true;
            this.Alex_on.CheckedChanged += new System.EventHandler(this.Alex_on_CheckedChanged);
            // 
            // Alex_channel
            // 
            this.Alex_channel.Location = new System.Drawing.Point(101, 75);
            this.Alex_channel.Name = "Alex_channel";
            this.Alex_channel.Size = new System.Drawing.Size(263, 25);
            this.Alex_channel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Channel";
            // 
            // Alex_bossname
            // 
            this.Alex_bossname.Location = new System.Drawing.Point(101, 44);
            this.Alex_bossname.Name = "Alex_bossname";
            this.Alex_bossname.Size = new System.Drawing.Size(263, 25);
            this.Alex_bossname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Boss Name";
            // 
            // AutoInvite
            // 
            this.AutoInvite.AutoSize = true;
            this.AutoInvite.Location = new System.Drawing.Point(17, 50);
            this.AutoInvite.Name = "AutoInvite";
            this.AutoInvite.Size = new System.Drawing.Size(367, 19);
            this.AutoInvite.TabIndex = 4;
            this.AutoInvite.Text = "自动邀请 -> /tell 女拳斗士蒂法@静语庄园 123 ";
            this.AutoInvite.UseVisualStyleBackColor = true;
            // 
            // logta
            // 
            this.logta.Location = new System.Drawing.Point(19, 176);
            this.logta.Multiline = true;
            this.logta.Name = "logta";
            this.logta.ReadOnly = true;
            this.logta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logta.Size = new System.Drawing.Size(370, 234);
            this.logta.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.Chat_on);
            this.groupBox2.Controls.Add(this.AutoInvite);
            this.groupBox2.Location = new System.Drawing.Point(427, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 110);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FF14聊天增强";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 78);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(143, 19);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "自动TTS小队语音";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Chat_on
            // 
            this.Chat_on.AutoSize = true;
            this.Chat_on.Location = new System.Drawing.Point(17, 24);
            this.Chat_on.Name = "Chat_on";
            this.Chat_on.Size = new System.Drawing.Size(59, 19);
            this.Chat_on.TabIndex = 4;
            this.Chat_on.Text = "启动";
            this.Chat_on.UseVisualStyleBackColor = true;
            // 
            // LogLine
            // 
            this.LogLine.AutoSize = true;
            this.LogLine.Location = new System.Drawing.Point(304, 151);
            this.LogLine.Name = "LogLine";
            this.LogLine.Size = new System.Drawing.Size(85, 19);
            this.LogLine.TabIndex = 6;
            this.LogLine.Text = "LogLine";
            this.LogLine.UseVisualStyleBackColor = true;
            this.LogLine.CheckedChanged += new System.EventHandler(this.LogLine_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LogLine);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.logta);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(915, 443);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #endregion

        public MainForm(BLMHelper bLMHelper)
        {
            this.bLMHelper = bLMHelper;
            InitializeComponent();
        }
        
        public string GetALexBossName()
        {
            return Alex_bossname.Text;

        }

        public string GetALexChannel()
        {
            return Alex_channel.Text;

        }

        public Boolean GetAlexOn()
        {
            return Alex_on.Checked;
        }

        public Boolean GetAutoInvite()
        {
            return AutoInvite.Checked;
        }

        private void Alex_on_CheckedChanged(object sender, EventArgs e)
        {
            if (!Alex_on.Checked)
            {
                bLMHelper.InitMainListener();
            }
            else
            {
                bLMHelper.DeinitMainListener();
            }

        }

        public void Log(String logtext)
        {
            logta.Text += logtext;
            logta.Text += "\r\n";
        }

        private void LogLine_CheckedChanged(object sender, EventArgs e)
        {
            if (!Alex_on.Checked)
            {
                bLMHelper.InitLogLineOut();
            }
            else
            {
                bLMHelper.DeinitLogLineOut();
            }
        }
    }
}
