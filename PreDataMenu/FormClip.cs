using DevComponents.DotNetBar;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreDataMenu
{
    public partial class FormClip : DevComponents.DotNetBar.OfficeForm
    {
        private IMap pMap;
        public FormClip(IMap _pMap)
        {
            InitializeComponent();
            ////禁用Glass主题
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //去除图标
            this.ShowIcon = false;
            //改变窗体风格，使之不能用鼠标拖拽改变大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.pMap = _pMap;
        }

        //确定
        private void btnOK_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    IFeatureClass featureclassInput = null;
            //    IFeatureClass featureclassClip = null;

            //    IFields outfields = null;

            //    // Create a new ShapefileWorkspaceFactory CoClass to create a new workspace
            //    IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();

            //    // System.IO.Path.GetDirectoryName(shapefileLocation) returns the directory part of the string. Example: "C:\test\"
            //    // System.IO.Path.GetFileNameWithoutExtension(shapefileLocation) returns the base filename (without extension). Example: "cities"
            //    //IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(shapefileLocation));

            //    IFeatureWorkspace featureWorkspaceInput = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(TxtInputFile.Text), 0); // Explicit Cast
            //    IFeatureWorkspace featureWorkspaceOut = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(txtOutputPath.Text), 0);
            //    IFeatureWorkspace featureWorkspaceClip = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(txtClipsFile.Text), 0);

            //    //timer 控件可用
            //    timerPro.Enabled = true;
            //    //scroll the textbox to the bottom

            //    txtMessages.Text = "\r\n分析开始,这可能需要几分钟时间,请稍候..\r\n";
            //    txtMessages.Update();

            //    //inputfeatureclass = featureWorkspace.OpenFeatureClass("land00_ws");
            //    //clipfeatureclass = featureWorkspace.OpenFeatureClass("drain_ws_buffer");

            //    featureclassInput = featureWorkspaceInput.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(TxtInputFile.Text));
            //    featureclassClip = featureWorkspaceClip.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(txtClipsFile.Text));
            //    outfields = featureclassInput.Fields;

            //    Geoprocessor gp = new Geoprocessor();
            //    gp.OverwriteOutput = true;
            //    //IFeatureClass outfeatureclass = featureWorkspace.CreateFeatureClass("Clip_result", outfields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
            //    IFeatureClass featureclassOut = null;

            //    //文件存在的处理
            //    if (File.Exists(txtOutputPath.Text.Trim()) == true)
            //    {
            //        featureclassOut = featureWorkspaceOut.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(txtOutputPath.Text));
            //        DelFeatureFile(featureclassOut, txtOutputPath.Text.Trim());
            //    }

            //    featureclassOut = featureWorkspaceOut.CreateFeatureClass(System.IO.Path.GetFileNameWithoutExtension(txtOutputPath.Text), outfields, null, null, esriFeatureType.esriFTSimple, "Shape", "");

            //    ESRI.ArcGIS.AnalysisTools.Clip clipTool =
            //        new ESRI.ArcGIS.AnalysisTools.Clip(featureclassInput, featureclassClip, featureclassOut);

            //    gp.Execute(clipTool, null);
            //    workspaceFactory = null;

            //    //复制feature层
            //    //IDataset pDataset = outfeatureclass as IDataset;
            //    //pDataset.Copy("Clip_result1", featureWorkspace as IWorkspace);   

            //    //添加图层到当前地图
            //    IFeatureLayer outlayer = new FeatureLayerClass();
            //    outlayer.FeatureClass = featureclassOut;
            //    outlayer.Name = featureclassOut.AliasName;
            //    pMap.AddLayer((ILayer)outlayer);
            //    //
            //    txtMessages.Text += "\r\n分析完成.\r\n";
            //    timerPro.Enabled = false;
            //}
            //catch (Exception ex)
            //{
            //    //
            //    txtMessages.Text += "\r\n分析失败.\r\n";
            //    timerPro.Enabled = false;
            //    MessageBox.Show(ex.Message.ToString());
            //}



            command1.Execute();
            circularProgress1.IsRunning = true;
            #region GP工具的使用
            //得到参数

            string in_polygon = TxtInputFile.Text;
            string upd_polygon = txtClipsFile.Text;
            string out_polygon = txtOutputPath.Text;
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            //设置矢量转栅格参数 

            ESRI.ArcGIS.AnalysisTools.Clip Clippolygon = new Clip();
            Clippolygon.in_features = in_polygon;
            Clippolygon.clip_features = upd_polygon;
            Clippolygon.out_feature_class = out_polygon;
            if (txtTolerance.Text != "")
            {
                Clippolygon.cluster_tolerance = double.Parse(txtTolerance.Text) + " " + (string)comboBox1.SelectedItem;
            }
            ////执行GP工具
            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(Clippolygon, null);
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
            b.Show(btnOK, false);
            #endregion
        }

        //输入图层
        private void btnInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.CheckPathExists = true;
            openDlg.Filter = "Shapefile (*.shp)|*.shp";
            openDlg.Title = "open input Layer";
            openDlg.RestoreDirectory = true;

            DialogResult dr = openDlg.ShowDialog();
            if (dr == DialogResult.OK)
                TxtInputFile.Text = openDlg.FileName;
        }
        //裁剪图层
        private void btnClips_Click(object sender, EventArgs e)
        {
            // Use the OpenFileDialog Class to choose which shapefile to load.
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // The user chose a particular shapefile.

                // The returned string will be the full path, filename and file-extension for the chosen shapefile. Example: "C:\test\cities.shp"
                string shapefileLocation = openFileDialog.FileName;
                txtClipsFile.Text = shapefileLocation;

                if (shapefileLocation != "")
                {
                    // Ensure the user chooses a shapefile

                    // Create a new ShapefileWorkspaceFactory CoClass to create a new workspace
                    ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();

                    // System.IO.Path.GetDirectoryName(shapefileLocation) returns the directory part of the string. Example: "C:\test\"
                    ESRI.ArcGIS.Geodatabase.IFeatureWorkspace featureWorkspace = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(shapefileLocation), 0); // Explicit Cast

                    // System.IO.Path.GetFileNameWithoutExtension(shapefileLocation) returns the base filename (without extension). Example: "cities"
                    ESRI.ArcGIS.Geodatabase.IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(shapefileLocation));

                    ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = new ESRI.ArcGIS.Carto.FeatureLayerClass();
                    featureLayer.FeatureClass = featureClass;
                    featureLayer.Name = featureClass.AliasName;
                    featureLayer.Visible = true;
                    //activeView.FocusMap.AddLayer(featureLayer);

                    // Zoom the display to the full extent of all layers in the map
                    //activeView.Extent = activeView.FullExtent;
                    // activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                }
                else
                {
                    // The user did not choose a shapefile.
                    // Do whatever remedial actions as necessary
                    System.Windows.Forms.MessageBox.Show("No shapefile chosen", "No Choice #1",
                                                        System.Windows.Forms.MessageBoxButtons.OK,
                                                        System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                // The user did not choose a shapefile. They clicked Cancel or closed the dialog by the "X" button.
                // Do whatever remedial actions as necessary.
                System.Windows.Forms.MessageBox.Show("No shapefile chosen", "No Choice #2",
                                                     System.Windows.Forms.MessageBoxButtons.OK,
                                                     System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }
        //输出图层
        private void btnOutput_Click(object sender, EventArgs e)
        {
            //set the output layer

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "Shapefile (*.shp)|*.shp";
            saveDlg.OverwritePrompt = true;
            saveDlg.Title = "Output Layer";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = "clips.shp";

            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                txtOutputPath.Text = saveDlg.FileName;
        }

        public static void DelFeatureFile(IFeatureClass pFeatureClass, string sName)
        {
            if (pFeatureClass != null)
            {
                IDataset dataset = pFeatureClass as IDataset;
                dataset.Delete();
            }

        }
        //获得Shape文件 by gisoracle   
        public static IFeatureClass GetFeatureClassByFileName(string fileName)
        {
            /* IWorkspace shapeWorkspace = GetWorkSpaceByPath(fileName);
             IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)shapeWorkspace;


             string extfileName = System.IO.Path.GetFileNameWithoutExtension(fileName); //文件名   
             IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(extfileName);

             return featureClass;*/
            return null;

        }
        //取消
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //启动项
        private void FormClip_Load(object sender, EventArgs e)
        {
            txtClipsFile.Text = "";
            TxtInputFile.Text = "";
            txtOutputPath.Text = "";
            txtTolerance.Text = "";
            comboBox1.Text = "Unknown";
        }
        
    }
}
