namespace PreDataMenu
{
    partial class RasReclassForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsvValue = new System.Windows.Forms.ListView();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cmbLayer = new System.Windows.Forms.ComboBox();
            this.cmbFieldsName = new System.Windows.Forms.ComboBox();
            this.txtPathSave = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvValue);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(14, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 268);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置重分类栅格值";
            // 
            // lsvValue
            // 
            this.lsvValue.FullRowSelect = true;
            this.lsvValue.GridLines = true;
            this.lsvValue.Location = new System.Drawing.Point(6, 20);
            this.lsvValue.Name = "lsvValue";
            this.lsvValue.Size = new System.Drawing.Size(320, 237);
            this.lsvValue.TabIndex = 13;
            this.lsvValue.UseCompatibleStateImageBehavior = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(332, 152);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(69, 23);
            this.button7.TabIndex = 12;
            this.button7.Text = "删除";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(332, 114);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(69, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "添加";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(332, 71);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(69, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "唯一值";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(332, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "分类";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmbLayer
            // 
            this.cmbLayer.FormattingEnabled = true;
            this.cmbLayer.Location = new System.Drawing.Point(75, 45);
            this.cmbLayer.Name = "cmbLayer";
            this.cmbLayer.Size = new System.Drawing.Size(309, 20);
            this.cmbLayer.TabIndex = 3;
            this.cmbLayer.SelectedIndexChanged += new System.EventHandler(this.cmbLayer_SelectedIndexChanged_1);
            // 
            // cmbFieldsName
            // 
            this.cmbFieldsName.FormattingEnabled = true;
            this.cmbFieldsName.Location = new System.Drawing.Point(75, 87);
            this.cmbFieldsName.Name = "cmbFieldsName";
            this.cmbFieldsName.Size = new System.Drawing.Size(309, 20);
            this.cmbFieldsName.TabIndex = 4;
            this.cmbFieldsName.SelectedIndexChanged += new System.EventHandler(this.cmbFieldsName_SelectedIndexChanged_1);
            // 
            // txtPathSave
            // 
            this.txtPathSave.Location = new System.Drawing.Point(75, 441);
            this.txtPathSave.Name = "txtPathSave";
            this.txtPathSave.Size = new System.Drawing.Size(309, 21);
            this.txtPathSave.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 482);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(309, 482);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(390, 439);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "输入栅格:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "字段名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "输出栅格:";
            // 
            // RasReclassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 534);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPathSave);
            this.Controls.Add(this.cmbFieldsName);
            this.Controls.Add(this.cmbLayer);
            this.Controls.Add(this.groupBox1);
            this.Name = "RasReclassForm";
            this.Text = "影像重分类";
            this.Load += new System.EventHandler(this.RasReclassForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cmbLayer;
        private System.Windows.Forms.ComboBox cmbFieldsName;
        private System.Windows.Forms.TextBox txtPathSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lsvValue;
    }
}