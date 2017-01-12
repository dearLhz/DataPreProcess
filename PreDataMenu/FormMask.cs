using DevComponents.DotNetBar;
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
    public partial class FormMask : Form
    {
        public IMap pMap;
        public int layerIndex;
        private IFeatureLayer pLayer;

        #region 禁止最大化窗体
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")] //导入API函数
        extern static System.IntPtr GetSystemMenu(System.IntPtr hWnd, System.IntPtr bRevert);

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        extern static int RemoveMenu(IntPtr hMenu, int nPos, int flags);
        static int MF_BYPOSITION = 0x400;
        static int MF_REMOVE = 0x1000;
        #endregion

        //启动项
        private void FormMask_Load(object sender, EventArgs e)
        {
            textBoxX1.Text = "";
            textBoxX2.Text = "";
            textBoxX3.Text = "";
            //改变窗体风格，使之不能用鼠标拖拽改变大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public FormMask()
        {
            InitializeComponent();
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //去除图标
            this.ShowIcon = false;
            //改变窗体风格，使之不能用鼠标拖拽改变大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        //输入
        private void buttonX3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TIFF tif|*.tif|All files (*.*)|*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pFilePath, pFileName;
                int index = this.openFileDialog1.FileName.LastIndexOf("\\");
                pFilePath = this.openFileDialog1.FileName.Substring(0, index);
                pFileName = this.openFileDialog1.FileName.Substring(index + 1);

                textBoxX1.Text = pFilePath + "\\" + pFileName;
            }
        }
        //掩膜
        private void buttonX4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TIFF tif|*.tif|All files (*.*)|*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pFilePath, pFileName;
                int index = this.openFileDialog1.FileName.LastIndexOf("\\");
                pFilePath = this.openFileDialog1.FileName.Substring(0, index);
                pFileName = this.openFileDialog1.FileName.Substring(index + 1);

                textBoxX2.Text = pFilePath + "\\" + pFileName;
            }
        }
        
        //输出
        private void buttonX5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "TIFF tif|*.tif|All files (*.*)|*";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pFilePath, pFileName;
                int index = this.saveFileDialog1.FileName.LastIndexOf("\\");
                pFilePath = this.saveFileDialog1.FileName.Substring(0, index);
                pFileName = this.saveFileDialog1.FileName.Substring(index + 1);

                textBoxX3.Text = pFilePath + "\\" + pFileName;
            }
        }
        //执行
        private void buttonX1_Click(object sender, EventArgs e)
        {

            command1.Execute();
            circularProgress1.IsRunning = true;
            #region GP工具的使用
            //得到参数

            string in_polygon = textBoxX1.Text;
            string upd_polygon = textBoxX2.Text;

            //IFeatureLayer layer1 = GetFeatureLayer((string)comboBox1.SelectedItem);
            //IFeatureLayer layer2 = GetFeatureLayer((string)comboBox2.SelectedItem);
            string out_polygon = textBoxX3.Text;


            //实例化GP工具
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            //设置矢量转栅格参数 

            ExtractByMask maskpolygon = new ExtractByMask();
            maskpolygon.in_raster = in_polygon;
            maskpolygon.in_mask_data = upd_polygon;
            maskpolygon.out_raster = out_polygon;
            ////执行GP工具
            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(maskpolygon, null);
            //object sev = null;
            //try
            //{
            //    // Execute the tool.
            //    gp.Execute(SymDiffpolygon, null);

            //    //Console.WriteLine(GP.GetMessages(ref sev));
            //    MessageBox.Show(gp.GetMessages(ref sev));
            //}
            //catch (Exception ex)
            //{
            //    // Print geoprocessing execution error messages.
            //    //Console.WriteLine(GP.GetMessages(ref sev));
            //    MessageBox.Show(gp.GetMessages(ref sev));
            //}
            #endregion
            circularProgress1.IsRunning = false;
            #region 运行完成之后的信息提示窗口
            balloonTip1.Enabled = true;

            DevComponents.DotNetBar.Balloon b = new DevComponents.DotNetBar.Balloon();
            b.Style = eBallonStyle.Alert;
            //b.CaptionImage = balloonTipFocus.CaptionImage.Clone() as Image;
            b.CaptionText = "信息提示";
            b.Text = "运行成功！";
            b.AlertAnimation = eAlertAnimation.TopToBottom;
            b.AutoResize();
            b.AutoClose = true;
            b.AutoCloseTimeOut = 4;
            b.Owner = this;
            b.Show(buttonX1, false);
            #endregion
        }
        //取消
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
