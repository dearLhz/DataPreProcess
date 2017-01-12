﻿namespace PreDataMenu
{
    partial class FormClip
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClip));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtTolerance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnClips = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.txtClipsFile = new System.Windows.Forms.TextBox();
            this.TxtInputFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.timerPro = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Unknown",
            "Inches",
            "Points",
            "Feet",
            "Yards",
            "Miles",
            "NauticalMiles",
            "Millimeters",
            "Centimeters",
            "Meters",
            "Kilometers",
            "DecimalDegrees",
            "Decimeters"});
            this.comboBox1.Location = new System.Drawing.Point(167, 156);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(89, 20);
            this.comboBox1.TabIndex = 42;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(323, 187);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 23);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确 定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTolerance
            // 
            this.txtTolerance.Location = new System.Drawing.Point(95, 156);
            this.txtTolerance.Name = "txtTolerance";
            this.txtTolerance.Size = new System.Drawing.Size(55, 21);
            this.txtTolerance.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 40;
            this.label4.Text = "误差容限值：";
            // 
            // btnOutput
            // 
            this.btnOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnOutput.Image")));
            this.btnOutput.Location = new System.Drawing.Point(385, 121);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(25, 25);
            this.btnOutput.TabIndex = 39;
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnClips
            // 
            this.btnClips.Image = ((System.Drawing.Image)(resources.GetObject("btnClips.Image")));
            this.btnClips.Location = new System.Drawing.Point(385, 77);
            this.btnClips.Name = "btnClips";
            this.btnClips.Size = new System.Drawing.Size(25, 25);
            this.btnClips.TabIndex = 38;
            this.btnClips.UseVisualStyleBackColor = true;
            this.btnClips.Click += new System.EventHandler(this.btnClips_Click);
            // 
            // btnInput
            // 
            this.btnInput.Image = ((System.Drawing.Image)(resources.GetObject("btnInput.Image")));
            this.btnInput.Location = new System.Drawing.Point(385, 32);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(25, 25);
            this.btnInput.TabIndex = 37;
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(14, 124);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(365, 21);
            this.txtOutputPath.TabIndex = 36;
            // 
            // txtClipsFile
            // 
            this.txtClipsFile.Location = new System.Drawing.Point(14, 80);
            this.txtClipsFile.Name = "txtClipsFile";
            this.txtClipsFile.Size = new System.Drawing.Size(365, 21);
            this.txtClipsFile.TabIndex = 35;
            // 
            // TxtInputFile
            // 
            this.TxtInputFile.Location = new System.Drawing.Point(14, 35);
            this.TxtInputFile.Name = "TxtInputFile";
            this.TxtInputFile.Size = new System.Drawing.Size(365, 21);
            this.TxtInputFile.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "输出图层要素：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "裁剪图层要素：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "输入图层要素：";
            // 
            // txtMessages
            // 
            this.txtMessages.Location = new System.Drawing.Point(14, 239);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ReadOnly = true;
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(396, 126);
            this.txtMessages.TabIndex = 44;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(323, 388);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 23);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timerPro
            // 
            this.timerPro.Tick += new System.EventHandler(this.timerPro_Tick);
            // 
            // FormClip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 443);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTolerance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnClips);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.txtClipsFile);
            this.Controls.Add(this.TxtInputFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormClip";
            this.Text = "图层裁剪";
            this.Load += new System.EventHandler(this.FormClip_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtTolerance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnClips;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.TextBox txtClipsFile;
        private System.Windows.Forms.TextBox TxtInputFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timerPro;
    }
}