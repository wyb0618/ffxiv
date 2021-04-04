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
            this.Alex_channel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Alex_bossname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Alex_channel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Alex_bossname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(19, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "绝亚笨比提示装置";
            // 
            // Alex_channel
            // 
            this.Alex_channel.Location = new System.Drawing.Point(92, 53);
            this.Alex_channel.Name = "Alex_channel";
            this.Alex_channel.Size = new System.Drawing.Size(263, 25);
            this.Alex_channel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Channel";
            // 
            // Alex_bossname
            // 
            this.Alex_bossname.Location = new System.Drawing.Point(92, 22);
            this.Alex_bossname.Name = "Alex_bossname";
            this.Alex_bossname.Size = new System.Drawing.Size(263, 25);
            this.Alex_bossname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Boss Name";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(915, 443);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion

        #endregion
        public MainForm()
        {
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
    }
}
