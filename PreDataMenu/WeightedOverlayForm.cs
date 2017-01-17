using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.SpatialAnalystTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreDataMenu
{
    public partial class WeightedOverlayForm : DevComponents.DotNetBar.OfficeForm
    {
        public WeightedOverlayForm()
        {
            InitializeComponent();
        }

        //启动项
        private void WeightedOverlayForm_Load(object sender, EventArgs e)
        {


        }
        //输出路径
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

                tbOutput.Text = pFilePath + "\\" + pFileName;
            }
        }
        //打开
        private void bOpen_Click(object sender, EventArgs e)
        {
            
        }
        //保存
        private void bSave_Click(object sender, EventArgs e)
        {

        }
        //add
        private void buttonX2_Click(object sender, EventArgs e)
        {

        }
        //删除
        private void buttonX3_Click(object sender, EventArgs e)
        {

        }
        //上移
        private void buttonX4_Click(object sender, EventArgs e)
        {

        }
        //下移
        private void buttonX5_Click(object sender, EventArgs e)
        {

        }
        //设置等效影响
        private void buttonX8_Click(object sender, EventArgs e)
        {

        }     
        //确定
        private void buttonX9_Click(object sender, EventArgs e)
        {
            #region GP工具的使用
            //得到参数
            ////string expression = richTextBox1.Text;
            //实例化GP工具
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            //设置RasterCalculator参数
            WeightedOverlay rastercalculator = new WeightedOverlay();
            //rastercalculator.in_weighted_overlay_table = expression;
            rastercalculator.out_raster = tbOutput.Text;
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
        //取消
        private void buttonX10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
