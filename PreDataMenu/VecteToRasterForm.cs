using DevComponents.DotNetBar;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
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

    public partial class VecteToRasterForm : DevComponents.DotNetBar.OfficeForm
    {
        public IMap pMap;
        public int layerIndex;
        private IFeatureLayer pFLayer;
        private ITable pTable;
        int m_nFieldIndex;
        string pFilePath, pFileName;

        #region 禁止最大化窗体
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")] //导入API函数
        extern static System.IntPtr GetSystemMenu(System.IntPtr hWnd, System.IntPtr bRevert);

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        extern static int RemoveMenu(IntPtr hMenu, int nPos, int flags);
        static int MF_BYPOSITION = 0x400;
        static int MF_REMOVE = 0x1000;
        #endregion

        public VecteToRasterForm()
        {
            InitializeComponent();
            //不显示最大化最小化按钮
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //去除图标
            this.ShowIcon = false;
        }

        //窗体启动项
        private void VecteToRasterForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            tbInput.Text = "";
            comboBox2.Text = "";
            comboBox2.Items.Clear();

            //改变窗体风格，使之不能用鼠标拖拽改变大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        int a=0;
        //打开
        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();
            //pFLayer = new FeatureLayerClass();
            openFileDialog1.Filter = "shp|*.shp|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pFilePath, pFileName;
                int index = this.openFileDialog1.FileName.LastIndexOf("\\");
                pFilePath = this.openFileDialog1.FileName.Substring(0, index);
                pFileName = this.openFileDialog1.FileName.Substring(index + 1);

                tbInput.Text = pFilePath + "\\" + pFileName;

                IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(pFilePath, 0); // 2
                IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                IFeatureClass pFC = pFeatureWorkspace.OpenFeatureClass(pFileName); //3

                pFLayer = new FeatureLayerClass(); // 4
                pFLayer.FeatureClass = pFC;
                pFLayer.Name = pFC.AliasName; // 5   

                #region 读取字段
                comboBox2.Enabled = true;

                pTable = (ITable)pFLayer;

                int fieldCount, i;
                fieldCount = pTable.Fields.FieldCount;
                comboBox2.Items.Clear();

                for (i = 0; i < fieldCount; i++)
                {
                    comboBox2.Items.Add(pTable.Fields.get_Field(i).Name);
                }
                #endregion;
                
            }

            
        }


        #region 读取当前图层要素，放入相应容器
        /// <summary>
        /// //从地图上得到图层
        /// </summary>
        /// <param name="layerName"></param>
        /// <returns></returns>
        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            IEnumLayer layers = GetLayers();
            layers.Reset();

            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                    return layer as IFeatureLayer;
            }

            return null;
        }
        /// <summary>
        /// //得到矢量图层
        /// </summary>
        /// <returns></returns>
        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";//得到矢量图层
            IEnumLayer layers = pMap.get_Layers(uid, true);

            return layers;
        }

        # endregion
        #region 读取当前要素字段，放入下拉菜单
        ///// <summary>
        ///// /加载主窗体已经打开的所有图层名称
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void comboBox1_Click(object sender, EventArgs e)
        //{
        //    comboBox1.Items.Clear();
        //    int i, layerCount;
        //    layerCount = pMap.LayerCount;
        //    for (i = 0; i < layerCount; i++)
        //    comboBox1.Items.Add(pMap.get_Layer(i).Name);
        //}
        ///// <summary>
        ///// //待转换数据的选择并更新下拉菜单控件2的下拉选项
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    layerIndex = comboBox1.SelectedIndex;
        //    string text = comboBox1.SelectedText;
        //    if (layerIndex == -1)
        //    {
        //        MessageBox.Show("必须选择一个图层");
        //        return;
        //    }
        //    comboBox2.Enabled = true;
        //    try
        //    {
        //        pLayer = (IFeatureLayer)pMap.get_Layer(layerIndex);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("请选择矢量图像！");
        //        comboBox1.SelectedText = "";
        //        return;
        //    }
        //    pTable = (ITable)pFLayer;

        //    int fieldCount, i;
        //    fieldCount = pTable.Fields.FieldCount;
        //    comboBox2.Items.Clear();

        //    for (i = 0; i < fieldCount; i++)
        //    {
        //        comboBox2.Items.Add(pTable.Fields.get_Field(i).Name);
        //    }
        //}
       

        /// <summary>
        /// tb1与combox联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            m_nFieldIndex = comboBox2.SelectedIndex;
        }
        # endregion
        
        #region 执行转换
        

        /// <summary>
        /// 栅格存储路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "TIFF tif|*.tif|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                int index = this.saveFileDialog1.FileName.LastIndexOf("\\");
                pFilePath = this.saveFileDialog1.FileName.Substring(0, index);
                pFileName = this.saveFileDialog1.FileName.Substring(index + 1);

                textBox1.Text = pFilePath + "\\" + pFileName;
            }
        }
        /// <summary>
        /// 像元大小的textbox只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.') || e.KeyChar == (char)8)   //(char)8是退格键
            {
                e.Handled = false;
                return;
            }
            e.Handled = true;
        }
        /// <summary>
        /// 执行按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            //IFeatureClass feaureClass=;
            //string fieldName=comboBoxEx2.Text.ToString();
            //String rasterWorkspace=;
            //int cellSize=int.Parse(textBoxX2.Text);
            //ToRaster( feaureClass,  fieldName, rasterWorkspace,  rasterName,  cellSize);
            command1.Execute();
            circularProgress1.IsRunning = true;
            #region GP工具的使用
            //得到参数
            //IFeatureLayer layer = GetFeatureLayer((string)comboBox1.SelectedItem);
            string field = (string)comboBox2.SelectedItem;
            string out_raster = textBox1.Text;
            object cellSize = textBox2.Text;
            //实例化GP工具
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            //设置矢量转栅格参数            
            FeatureToRaster featuretoraster = new FeatureToRaster();
            featuretoraster.in_features = tbInput.Text;
            featuretoraster.field = field;
            featuretoraster.cell_size = cellSize;
            featuretoraster.out_raster = out_raster;
            //执行GP工具
            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(featuretoraster, null);
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
            b.Show(button2, false);
            #endregion
        }
      
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        # endregion



        
       

     
    }
}

