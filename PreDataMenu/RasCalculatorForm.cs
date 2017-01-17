using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.SpatialAnalystTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreDataMenu
{
    public partial class RasTercalForm : DevComponents.DotNetBar.OfficeForm
    {
        public IMap pMap;
        string s=null;//表达式参数
        IRasterLayer RLayer;
        string pFullPath;
        #region 禁止最大化窗体
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")] //导入API函数
        extern static System.IntPtr GetSystemMenu(System.IntPtr hWnd, System.IntPtr bRevert);

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        extern static int RemoveMenu(IntPtr hMenu, int nPos, int flags);
        static int MF_BYPOSITION = 0x400;
        static int MF_REMOVE = 0x1000;
        #endregion

        public RasTercalForm()
        {
            InitializeComponent();
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //去除图标
            this.ShowIcon = false;
        }
        /// <summary>
        /// 读取当前图层地图
        /// 显示在listbox1中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RasTercalForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";

            //改变窗体风格，使之不能用鼠标拖拽改变大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
          
            listBox1.Items.Clear();
            int i, layerCount;
            layerCount = pMap.LayerCount;
            for (i = 0; i < layerCount; i++)
            listBox1.Items.Add(pMap.get_Layer(i).Name);
        }
        #region  点击输入按钮参数
        /// <summary>
        /// 输入的raster两边需要加上“\”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i, layerCount;
            layerCount = pMap.LayerCount;
            for (i = 0; i < layerCount; i++)
            {
                if (pMap.get_Layer(i).Name == listBox1.SelectedItem.ToString())
                {
                    RLayer = (RasterLayer)pMap.get_Layer(i);
                    pFullPath = RLayer.FilePath;
                }
            }
            richTextBox1.SelectedText += "\"" + pFullPath + "\"";
            s += "\"" + pFullPath + "\"";
        }
        /// <summary>
        /// 输入函数表达式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text += listBox2.SelectedItem;
            s += listBox2.SelectedItem;
        }
        private void buttonX7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "0";
            s += "0";
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "1";
            s += "1";
        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "2";
            s += "2";
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "3";
            s += "3";
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "4";
            s += "4";
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "5";
            s += "5";
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "6";
            s += "6";
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "7";
            s += "7";
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "8";
            s += "8";
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "9";
            s += "9";
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += ".";
            s += ".";
        }

        private void buttonX21_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "+" + " ";
            s += " " + "+" + " ";
        }

        private void buttonX22_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "-" + " ";
            s += " " + "-" + " ";
        }

        private void buttonX23_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "*" + " ";
            s += " " + "*" + " ";
        }

        private void buttonX24_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "/" + " ";
            s += " " + "/" + " ";
        }

        private void buttonX20_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "<" + " ";
            s += " " + "<" + " ";
        }

        private void buttonX19_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + ">" + " ";
            s += " " + ">" + " ";
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "<=" + " ";
            s += " " + "<=" + " ";
        }

        private void buttonX17_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + ">=" + " ";
            s += " " + ">=" + " ";
        }

        private void buttonX31_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "==" + " ";
            s += " " + "==" + " ";
        }

        private void buttonX26_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "!=" + " ";
            s += " " + "!=" + " ";
        }

        private void buttonX30_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "(";
            s += "(";
        }

        private void buttonX29_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += ")";
            s += ")";
        }

        private void buttonX27_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "|" + " ";
            s += " " + "|" + " ";
        }

        private void buttonX28_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "&" + " ";
            s += " " + "&" + " ";
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "^" + " ";
            s += " " + "^" + " ";
        }

        private void buttonX16_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + "~";
            s += " " + "~";
        }

        #endregion
     
        /// <summary>
        /// 输出位置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "TIFF tif|*.tif|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pFilePath, pFileName;
                int index = this.saveFileDialog1.FileName.LastIndexOf("\\");
                pFilePath = this.saveFileDialog1.FileName.Substring(0, index);
                pFileName = this.saveFileDialog1.FileName.Substring(index + 1);

                textBox1.Text = pFilePath + "\\" + pFileName;
            }
        }
        /// <summary>
        /// 执行栅格计算
        /// 调用gp中的RasterCalculator实例
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            #region GP工具的使用
            //得到参数
            string expression = richTextBox1.Text;
            string outputRaster = textBox1.Text;
            //实例化GP工具
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            //设置RasterCalculator参数
            RasterCalculator rastercalculator = new RasterCalculator();
            rastercalculator.expression = expression;
            rastercalculator.output_raster = outputRaster;
            //执行GP工具
            //IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(rastercalculator, null);
            object sev = null;
            try
            {
                // Execute the tool.
                gp.Execute(rastercalculator, null);

                //Console.WriteLine(GP.GetMessages(ref sev));
                MessageBox.Show(gp.GetMessages(ref sev));
            }
            catch (Exception ex)
            {
                // Print geoprocessing execution error messages.
                //Console.WriteLine(GP.GetMessages(ref sev));
                MessageBox.Show(gp.GetMessages(ref sev));
            }
            #endregion
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}

