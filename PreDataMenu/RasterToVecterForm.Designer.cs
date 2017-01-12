namespace PreDataMenu
{
    partial class RasterToVecterForm
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.comboBox2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.textBox1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
            this.command1 = new DevComponents.DotNetBar.Command(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbInput = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 44);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(96, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "输入栅格要素：";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(33, 99);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "字段：";
            // 
            // comboBox2
            // 
            this.comboBox2.DisplayMember = "Text";
            this.comboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.ItemHeight = 15;
            this.comboBox2.Location = new System.Drawing.Point(106, 101);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(208, 21);
            this.comboBox2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 162);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(88, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "输出面要素：";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(320, 162);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(35, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 5;
            this.buttonX1.Text = "...";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // textBox1
            // 
            // 
            // 
            // 
            this.textBox1.Border.Class = "TextBoxBorder";
            this.textBox1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox1.ButtonCustom.Tooltip = "";
            this.textBox1.ButtonCustom2.Tooltip = "";
            this.textBox1.Location = new System.Drawing.Point(106, 162);
            this.textBox1.Name = "textBox1";
            this.textBox1.PreventEnterBeep = true;
            this.textBox1.Size = new System.Drawing.Size(208, 21);
            this.textBox1.TabIndex = 6;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(33, 239);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(89, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "是否简化面：";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(128, 243);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "SIMPLIFY";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(205, 243);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(89, 16);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "NO_SIMPLIFY";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(89, 309);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 11;
            this.buttonX2.Text = "确定";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(219, 309);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 12;
            this.buttonX3.Text = "取消";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // command1
            // 
            this.command1.Name = "command1";
            // 
            // circularProgress1
            // 
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(320, 344);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.Size = new System.Drawing.Size(75, 23);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 0;
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX5.Location = new System.Drawing.Point(320, 42);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(35, 23);
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX5.TabIndex = 14;
            this.buttonX5.Text = "...";
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbInput
            // 
            // 
            // 
            // 
            this.tbInput.Border.Class = "TextBoxBorder";
            this.tbInput.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbInput.ButtonCustom.Tooltip = "";
            this.tbInput.ButtonCustom2.Tooltip = "";
            this.tbInput.Location = new System.Drawing.Point(106, 44);
            this.tbInput.Name = "tbInput";
            this.tbInput.PreventEnterBeep = true;
            this.tbInput.Size = new System.Drawing.Size(208, 21);
            this.tbInput.TabIndex = 15;
            this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
            // 
            // RasterToVecterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 368);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.buttonX5);
            this.Controls.Add(this.circularProgress1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Name = "RasterToVecterForm";
            this.Text = "栅格转矢量";
            this.Load += new System.EventHandler(this.RasterToVecterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBox2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.BalloonTip balloonTip1;
        private DevComponents.DotNetBar.Command command1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbInput;
    }
}