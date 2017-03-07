using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPreProcess
{
    public partial class RasReclassForm : DevComponents.DotNetBar.OfficeForm
    {
        private IMap pMap = null;

        private static int iReClassCount = 5;
        private IRasterLayer pRLayer = null;

        //int gClassCount = 5;
        double[] gClassbreaks;
        string strClassifyMethod = "自然裂点分类";
        private IClassBreaksRenderer m_classBreaksRenderer;


        private string strOutDir = "";
        public RasReclassForm(IMap _pMap)
        {
            InitializeComponent();
            pMap = _pMap;
            //禁用Glass主题
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //去除图标
            this.ShowIcon = false;
        }

        private void RasReclassForm_Load(object sender, EventArgs e)
        {
            try
            {
                //初始化pMap变量
                strOutDir = Application.StartupPath.Replace("\\bin\\Debug", "\\Data\\data");
                this.txtPathSave.Text = strOutDir;
                //添加栅格图层名称到cmbLayer
                //if (pMap != null)
                //{
                //    for (int i = 0; i < pMap.LayerCount; i++)
                //    {
                //        if (pMap.get_Layer(i) is IRasterLayer)
                //            this.cmbLayer.Items.Add(pMap.get_Layer(i).Name);
                //    }
                //    if (this.cmbLayer.Items.Count > 0)
                //        this.cmbLayer.SelectedIndex = 0;
                //}
                //初始化lsvView
                lsvValue.Columns.Clear();
                this.lsvValue.GridLines = true;     //显示各个记录的分隔线
                lsvValue.View = View.Details;       //定义列表显示的方式
                lsvValue.Scrollable = true;         //需要时候显示滚动条
                lsvValue.MultiSelect = false;             // 不可以多行选择
                lsvValue.HeaderStyle = ColumnHeaderStyle.Nonclickable;// 不执行操作
                lsvValue.Columns.Add("原值", 136, HorizontalAlignment.Center);
                lsvValue.Columns.Add("新值", 136, HorizontalAlignment.Center);
                lsvValue.LabelEdit = true;
                //设置行高
                ImageList imgList = new ImageList();
                imgList.ImageSize = new Size(1, 20);
                lsvValue.SmallImageList = imgList;

                tbInput.Text = "";
                txtPathSave.Text = "";
                cmbFieldsName.Text = "";
                cmbFieldsName.Items.Clear();
                lsvValue.Items.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private IRasterLayer SetViewShedRenderer(IRaster pInRaster, string sField, string sPath, double[,] dValue)
        {
            try
            {
                if (dValue == null)
                    return null;
                if (sField.Trim() == "")
                    return null;
                string path = "";
                string fileName = "";
                int iPath = sPath.LastIndexOf('\\');
                path = sPath.Substring(0, iPath);
                fileName = sPath.Substring(iPath + 1, sPath.Length - iPath - 1);

                IRasterDescriptor pRD = new RasterDescriptorClass();
                pRD.Create(pInRaster, null, sField);
                IReclassOp pReclassOp = new RasterReclassOpClass();

                IGeoDataset pGeodataset = pInRaster as IGeoDataset;
                IRasterAnalysisEnvironment pEnv = pReclassOp as IRasterAnalysisEnvironment;
                IWorkspaceFactory pWSF = new RasterWorkspaceFactoryClass();
                IWorkspace pWS = pWSF.OpenFromFile(path, 0);
                //pEnv.OutWorkspace = pWS;
                //object objSnap = null;
                //object objExtent = pGeodataset.Extent;
                //pEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref objExtent, ref objSnap);
                //pEnv.OutSpatialReference = pGeodataset.SpatialReference;

                IRasterBandCollection pRsBandCol = pGeodataset as IRasterBandCollection;
                IRasterBand pRasterBand = pRsBandCol.Item(0);
                pRasterBand.ComputeStatsAndHist();
                IRasterStatistics pRasterStatistic = pRasterBand.Statistics;
                double dMaxValue = pRasterStatistic.Maximum;
                double dMinValue = pRasterStatistic.Minimum;

                INumberRemap pNumRemap = new NumberRemapClass();
                for (int i = 0; i < (dValue.Length / 3); i++)
                {
                    pNumRemap.MapRange(dValue[i, 0], dValue[i, 1], (Int32)dValue[i, 2]);
                }
                IRemap pRemap = pNumRemap as IRemap;

                IGeoDataset pGeoDs = new RasterDatasetClass();
                pGeoDs = pReclassOp.ReclassByRemap(pGeodataset, pRemap, false);
                IRasterBandCollection pRasBandCol = (IRasterBandCollection)pGeoDs;
                pRasBandCol.SaveAs(fileName, pWS, "GRID");//"IMAGINE Image"
                IRaster pOutRaster = pGeoDs as IRaster;
                IRasterLayer pRLayer = new RasterLayerClass();

                pRLayer.CreateFromRaster(pOutRaster);
                pRLayer.Name = fileName;
                return pRLayer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        //确定
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(lsvValue.Items.Count.ToString());
            try
            {
                if (pRLayer == null)
                    return;
                pMap.AddLayer(SetViewShedRenderer(pRLayer.Raster, this.cmbFieldsName.Text, this.txtPathSave.Text, getReClassValue()) as ILayer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //分类
        private void button4_Click(object sender, EventArgs e)
        {
            iReClassCount = (int)nudClassCount.Value;
            if (pRLayer == null)
                return;
            setViewValue(pRLayer.Raster, this.cmbFieldsName.Text);
        }
        //唯一
        private void button5_Click(object sender, EventArgs e)
        {
            setOnlyValue(pRLayer.Raster, this.cmbFieldsName.Text);
        }
        //添加
        private void button6_Click(object sender, EventArgs e)
        {
            ListViewItem li = new ListViewItem();
            li.SubItems.Clear();
            li.SubItems[0].Text = "";
            li.SubItems.Add("");
            this.lsvValue.Items.Add(li);
            iReClassCount++;
        }
        //删除
        private void button7_Click(object sender, EventArgs e)
        {
            if (this.lsvValue.SelectedItems.Count > 0)
            {
                iReClassCount--;
                this.lsvValue.Items.RemoveAt(this.lsvValue.SelectedItems[0].Index);
            }
        }
        //浏览
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "栅格数据|*.*";
            saveDlg.OverwritePrompt = true;
            saveDlg.Title = "保存栅格文件到...";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = "reclass1";

            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                this.txtPathSave.Text = saveDlg.FileName;
        }
        ////图层选择框 选择不同的图层
        //private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < pMap.LayerCount; i++)
        //    {
        //        string name = pMap.get_Layer(i).Name;
        //        if (pMap.get_Layer(i).Name == this.cmbLayer.Text)
        //        {
        //            pRLayer = pMap.get_Layer(i) as IRasterLayer;
        //            setRasterLayerFiledName(pRLayer, this.cmbFieldsName);
        //            break;
        //        }
        //    }
        //}

        //打开
        private void button8_Click(object sender, EventArgs e)
        {
            pRLayer = new RasterLayer();

            openFileDialog1.Filter = "TIFF tif|*.tif|All files (*.*)|*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pFilePath, pFileName;
                int index = this.openFileDialog1.FileName.LastIndexOf("\\");
                pFilePath = this.openFileDialog1.FileName.Substring(0, index);
                pFileName = this.openFileDialog1.FileName.Substring(index + 1);

                tbInput.Text = pFilePath + "\\" + pFileName;

                pRLayer.CreateFromFilePath(openFileDialog1.FileName);
           
                setRasterLayerFiledName(pRLayer, this.cmbFieldsName);
   

                //#region 读取字段
                //comboBox2.Enabled = true;

                //pTable = (ITable)pRLayer;

                //int fieldCount, i;
                //fieldCount = pTable.Fields.FieldCount;
                //comboBox2.Items.Clear();

                //for (i = 0; i < fieldCount; i++)
                //{
                //    comboBox2.Items.Add(pTable.Fields.get_Field(i).Name);
                //}
                //#endregion
            }
        }
        /// <summary>
        /// 添加字段列表到指定的Combobox
        /// </summary>
        /// <param name="pRlyr">栅格图层</param>
        /// <param name="cmb">要显示字段的Combobox</param>
        private void setRasterLayerFiledName(IRasterLayer pRlyr, ComboBox cmb)
        {
            try
            {
                //清空字段列表
                cmb.Items.Clear();

                IRaster pRaster = pRlyr.Raster;
                IRasterProps pProp = pRaster as IRasterProps;
                pProp.PixelType = rstPixelType.PT_LONG;
                if (pProp.PixelType == rstPixelType.PT_LONG)
                {
                    IRasterBandCollection pBcol = pRaster as IRasterBandCollection;
                    IRasterBand pBand = pBcol.Item(0);
                    ITable pRTable = pBand.AttributeTable;

                    string strFieldName = "";
                    for (int i = 0; i < pRTable.Fields.FieldCount; i++)
                    {
                        strFieldName = pRTable.Fields.get_Field(i).Name;
                        if (strFieldName.ToUpper() != "ROWID" && strFieldName.ToUpper() != "COUNT")
                            cmb.Items.Add(strFieldName);
                    }
                    if (cmbFieldsName.Items.Count > 0)
                        cmbFieldsName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        double MaxValue;
        /// <summary>
        /// 设置显示的原值--新值
        /// </summary>
        /// <param name="pInRaster"></param>
        /// <param name="sField"></param>
        /// <returns></returns>
        public void setViewValue(IRaster pInRaster, string sField)
        {
            try
            {
                IRasterDescriptor pRD = new RasterDescriptorClass();
                pRD.Create(pInRaster, new QueryFilterClass(), sField);
                IGeoDataset pGeodataset = pInRaster as IGeoDataset;
                IRasterLayer pRLayer = new RasterLayerClass();
                IRasterBandCollection pRsBandCol = pGeodataset as IRasterBandCollection;
                IRasterBand pRasterBand = pRsBandCol.Item(0);
                pRasterBand.ComputeStatsAndHist();
                IRasterStatistics pRasterStatistic = pRasterBand.Statistics;

                double dMaxValue = pRasterStatistic.Maximum;
                double dMinValue = pRasterStatistic.Minimum;

                MaxValue = dMaxValue;

                if ((dMaxValue - dMinValue) / iReClassCount >= 1)
                {
                    double dItemInterval = (dMaxValue - dMinValue) / iReClassCount;
                    double dMinTemp = dMinValue;
                    if (this.cmbFieldsName.Items.Count > 0)
                        this.lsvValue.Items.Clear();
                    for (int i = 0; i < iReClassCount; i++)
                    {
                        ListViewItem li = new ListViewItem();
                        li.SubItems.Clear();
                        li.SubItems[0].Text = dMinTemp.ToString() + " - " + (dMinTemp + dItemInterval).ToString("N4");
                        li.SubItems.Add(i.ToString());
                        this.lsvValue.Items.Add(li);
                        dMinTemp = dMinTemp + dItemInterval;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 设置显示唯一值
        /// </summary>
        /// <param name="pInRaster"></param>
        /// <param name="sField"></param>
        /// <returns></returns>
        double dMaxValue;
        public void setOnlyValue(IRaster pInRaster, string sField)
        {
            try
            {
                //IRasterDescriptor pRD = new RasterDescriptorClass();
                //pRD.Create(pInRaster, new QueryFilterClass(), sField);
                //IGeoDataset pGeodataset = pInRaster as IGeoDataset;
                //IRasterLayer pRLayer = new RasterLayerClass();
                //IRasterBandCollection pRsBandCol = pGeodataset as IRasterBandCollection;
                //IRasterBand pRasterBand = pRsBandCol.Item(0);
                //pRasterBand.ComputeStatsAndHist();
                //IRasterStatistics pRasterStatistic = pRasterBand.Statistics;

                //double dMaxValue = pRasterStatistic.Maximum;
                //double dMinValue = pRasterStatistic.Minimum;

                if (this.cmbFieldsName.Items.Count > 0)
                    this.lsvValue.Items.Clear();
                for (int i = 0; i <= MaxValue; i++)
                {
                    ListViewItem li = new ListViewItem();
                    li.SubItems.Clear();
                    li.SubItems[0].Text = i.ToString();
                    li.SubItems.Add(i.ToString());
                    this.lsvValue.Items.Add(li);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //选择不同的字段时 相应的改变lstview显示的值
        private void cmbFieldsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pRLayer == null)
                return;
            setViewValue(pRLayer.Raster, this.cmbFieldsName.Text);
        }

        /// <summary>
        /// 返回【最小值，最大值，新值】的数组,异常返回null
        /// </summary>
        /// <returns>返回【最小值，最大值，新值】的数组（ireclass-1,3）</returns>
        private double[,] getReClassValue()
        {
            try
            {
                int n = this.lsvValue.Items.Count;
                iReClassCount = n;
                ListViewItem lvt = null;
                for (int i = n - 1; i >= 0; i--)
                {
                    lvt = this.lsvValue.Items[i];
                    if (lvt.SubItems[0].Text.Trim() == "" && lvt.SubItems[1].Text.Trim() == "")
                    {
                        iReClassCount--;
                    }
                    else if (lvt.SubItems[0].Text.Trim() == "" || lvt.SubItems[1].Text.Trim() == "")
                    {
                        MessageBox.Show("第" + i.ToString() + "有误，请重新输入或者删除！");
                        return null;
                    }
                }

                double[,] dValue = new double[iReClassCount, 3];
                //注意最后一行是nodata(不考虑)
                for (int i = 0; i < iReClassCount; i++)
                {
                    string[] temp = this.lsvValue.Items[i].SubItems[0].Text.Split('-');
                    dValue[i, 0] = double.Parse(temp[0].Trim());
                    dValue[i, 1] = double.Parse(temp[1].Trim());
                    dValue[i, 2] = double.Parse(this.lsvValue.Items[i].SubItems[1].Text.Trim());
                }
                return dValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }

        }

        ////选择分类数目
        //private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        //{
        //    iReClassCount = Convert.ToInt32(nudClassCount.Value);
        //}

        ////执行分类
        //private void classify()
        //{
        //    if (layer2Symbolize == null) return;
        //    IFeatureClass featureClass = layer2Symbolize.FeatureClass;
        //    ITable pTable = (ITable)featureClass;

        //    ITableHistogram pTableHistogram = new BasicTableHistogramClass();
        //    IBasicHistogram pHistogram = (IBasicHistogram)pTableHistogram;
        //    pTableHistogram.Field = strRendererField;
        //    if (strNormalizeField.ToLower() != "none")
        //        pTableHistogram.NormField = strNormalizeField;
        //    pTableHistogram.Table = pTable;
        //    object dataFrequency;
        //    object dataValues;
        //    pHistogram.GetHistogram(out dataValues, out dataFrequency);
        //    //下面是分级方法，用于根据获得的值计算得出符合要求的数据
        //    //根据条件计算出Classes和ClassesCount，numDesiredClasses为预定的分级数目
        //    IClassifyGEN pClassify = new NaturalBreaksClass();
        //    switch (strClassifyMethod)
        //    {
        //        case "等间隔分类":
        //            pClassify = new EqualIntervalClass();
        //            break;
        //        //case "预定义间隔分类":
        //        //    pClassify = new DefinedIntervalClass();
        //        //    break;
        //        case "分位数分类":
        //            pClassify = new QuantileClass();
        //            break;
        //        case "自然裂点分类":
        //            pClassify = new NaturalBreaksClass();
        //            break;
        //        case "标准差分类":
        //            pClassify = new StandardDeviationClass();
        //            break;
        //        case "几何间隔分类":
        //            pClassify = new GeometricalIntervalClass();
        //            break;
        //        default:
        //            break;
        //    }
        //    int numDesiredClasses = iReClassCount;
        //    pClassify.Classify(dataValues, dataFrequency, ref numDesiredClasses);
        //    gClassbreaks = (double[])pClassify.ClassBreaks;

        //}

        

        
    }
}
