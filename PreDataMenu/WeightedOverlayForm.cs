using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
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
    public partial class WeightedOverlayForm : DevComponents.DotNetBar.OfficeForm
    {

        private IRasterLayer pRLayer = null;
        private ITable pTable;
        int rasteCount = 0;

        #region 禁止最大化窗体
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")] //导入API函数
        extern static System.IntPtr GetSystemMenu(System.IntPtr hWnd, System.IntPtr bRevert);

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        extern static int RemoveMenu(IntPtr hMenu, int nPos, int flags);
        static int MF_BYPOSITION = 0x400;
        static int MF_REMOVE = 0x1000;
        #endregion

        public WeightedOverlayForm()
        {
            InitializeComponent();
            ////禁用Glass主题
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //改变窗体风格，使之不能用鼠标拖拽改变大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //去除图标
            this.ShowIcon = false;
        }

        //启动项
        private void WeightedOverlayForm_Load(object sender, EventArgs e)
        {
            lsvValue.Columns.Clear();
            this.lsvValue.GridLines = true;     //显示各个记录的分隔线
            lsvValue.View = View.Details;       //定义列表显示的方式
            lsvValue.Scrollable = true;         //需要时候显示滚动条
            lsvValue.MultiSelect = false;             // 不可以多行选择
            lsvValue.HeaderStyle = ColumnHeaderStyle.Nonclickable;// 不执行操作
            lsvValue.Columns.Add("栅格", 270, HorizontalAlignment.Center);
            lsvValue.Columns.Add("%影响", 90, HorizontalAlignment.Center);
            lsvValue.Columns.Add("字段", 90, HorizontalAlignment.Center);
            lsvValue.Columns.Add("比例值", 90, HorizontalAlignment.Center);
            lsvValue.LabelEdit = true;
            //设置行高
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 20);
            lsvValue.SmallImageList = imgList;

            tbInput.Text = "";
            tbOutput.Text = "";
            tbStart.Text = "";
            tbOver.Text = "";
            tbPlus.Text = "";
            cmbFieldsName.Text = "";
            cmbFieldsName.Items.Clear();
            lsvValue.Items.Clear();
            rasteCount = 0;
        }
        //输出路径
        private void buttonX1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "TIFF tif|*.tif|All files (*.*)|*.*";
            //saveDlg.Filter = "栅格数据|*.*";
            saveDlg.OverwritePrompt = true;
            saveDlg.Title = "保存栅格文件到...";
            saveDlg.RestoreDirectory = true;

            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                this.tbOutput.Text = saveDlg.FileName;
        }
        //打开
        private void bOpen_Click(object sender, EventArgs e)
        {
            
        }
        //保存
        private void bSave_Click(object sender, EventArgs e)
        {

        }

        
        //输入栅格
        private void buttonX2_Click(object sender, EventArgs e)
        {
            pRLayer = new RasterLayer();
            openFileDialog1.Filter = "栅格数据|*.*";
            //openFileDialog1.Filter = "TIFF tif|*.tif|All files (*.*)|*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                

                string pFilePath, pFileName;
                int index = this.openFileDialog1.FileName.LastIndexOf("\\");
                pFilePath = this.openFileDialog1.FileName.Substring(0, index);
                pFileName = this.openFileDialog1.FileName.Substring(index + 1);

                //tbInput.Text = pFilePath + "\\" + pFileName;

                //pRLayer.CreateFromFilePath(openFileDialog1.FileName);

                //setRasterLayerFiledName(pRLayer, this.cmbFieldsName);




                IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactory();
                IWorkspace workspace;
                workspace = workspaceFactory.OpenFromFile(pFilePath, 0); //inPath栅格数据存储路径
                if (workspace == null)
                {
                    return;
                }
                IRasterWorkspace rastWork = (IRasterWorkspace)workspace;
                IRasterDataset pRasterDataset;

                pFileName = pFileName.Substring(pFileName.LastIndexOf("\\") + 1, (pFileName.LastIndexOf(".") - pFileName.LastIndexOf("\\") - 1)); ;
                pFileName = pFileName.Substring(pFileName.LastIndexOf("\\") + 1, (pFileName.LastIndexOf(".") - pFileName.LastIndexOf("\\") - 1)); ;


                pRasterDataset = rastWork.OpenRasterDataset(pFileName);//inName栅格文件名
                if (pRasterDataset == null)
                {
                    return;
                }

                //影像金字塔的判断与创建
                IRasterPyramid pRasPyrmid;
                pRasPyrmid = pRasterDataset as IRasterPyramid;

                if (pRasPyrmid != null)
                {
                    if (!(pRasPyrmid.Present))
                    {
                        pRasPyrmid.Create();
                    }
                }

                IRaster pRaster;
                pRaster = pRasterDataset.CreateDefaultRaster();

                pRLayer = new RasterLayerClass();
                pRLayer.CreateFromRaster(pRaster);

                tbInput.Text = pFilePath + "\\" + pFileName;

                setRasterLayerFiledName(pRLayer, this.cmbFieldsName);

            
            }
        }

        //添加至表格中
        private void buttonX6_Click(object sender, EventArgs e)
        {
            #region 装载数据

            
            //头数据
            rasteCount++;
            if (rasteCount == 1)
            {
                lsvValue.Items.Add(new ListViewItem(new string[] { tbInput.Text, "100", cmbFieldsName.SelectedItem.ToString(), "" }));
            }
            else
            {
                lsvValue.Items.Add(new ListViewItem(new string[] { tbInput.Text, "0", cmbFieldsName.SelectedItem.ToString(), "" }));
            }


            //字段值数据
            IRaster pRaster = pRLayer.Raster;
            IRasterBandCollection pRasterBC = (IRasterBandCollection)pRaster;
            IRasterBand pRasterBand = pRasterBC.Item(0);
            ITable pTable = pRasterBand.AttributeTable;
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.WhereClause = "";
            ICursor pCursor = pTable.Search(pQueryFilter, false);
            IRow pRow = pCursor.NextRow();

            while (pRow != null)
            {
                //以下显示COUNT字段的值
                string s = Convert.ToString(pRow.get_Value(pTable.Fields.FindField(cmbFieldsName.SelectedItem.ToString())));
                if (0 < Convert.ToInt32(s) && Convert.ToInt32(s)<10)
                {
                    lsvValue.Items.Add(new ListViewItem(new string[] { "", "", s, s }));
                }
                else
                {
                    lsvValue.Items.Add(new ListViewItem(new string[] { "", "", s, "1" }));
                }
                pRow = pCursor.NextRow();
            }
            
            //结尾数据
            lsvValue.Items.Add(new ListViewItem(new string[] { "", "", "", "" }));

            #endregion
        }

        //当combox1选择不同比例值时，级别值相应改变
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "1   至   9   由   1":
                    for (int i = 1; i < lsvValue.Items.Count; i++)
                    {
                        if (lsvValue.Items[i].SubItems[2].Text != "" && lsvValue.Items[i].SubItems[3].Text != "")
                        {
                            int a = int.Parse(lsvValue.Items[i].SubItems[2].Text.ToString());
                            if (0 < a && a < 10)
                            {
                                switch (a)
                                {
                                    case 1:
                                        lsvValue.Items[i].SubItems[3].Text = "1";
                                        break;
                                    case 2:
                                        lsvValue.Items[i].SubItems[3].Text = "2";
                                        break;
                                    case 3:
                                        lsvValue.Items[i].SubItems[3].Text = "3";
                                        break;
                                    case 4:
                                        lsvValue.Items[i].SubItems[3].Text = "4";
                                        break;
                                    case 5:
                                        lsvValue.Items[i].SubItems[3].Text = "5";
                                        break;
                                    case 6:
                                        lsvValue.Items[i].SubItems[3].Text = "6";
                                        break;
                                    case 7:
                                        lsvValue.Items[i].SubItems[3].Text = "7";
                                        break;
                                    case 8:
                                        lsvValue.Items[i].SubItems[3].Text = "8";
                                        break;
                                    case 9:
                                        lsvValue.Items[i].SubItems[3].Text = "9";
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                lsvValue.Items[i].SubItems[3].Text = "1";
                            }
                        }
                    }
                    break;
                case "1   至   5   由   1":
                    for (int i = 1; i < lsvValue.Items.Count; i++)
                    {
                        if (lsvValue.Items[i].SubItems[2].Text != "" && lsvValue.Items[i].SubItems[3].Text != "")
                        {
                            int a = int.Parse(lsvValue.Items[i].SubItems[2].Text.ToString());
                            if (0 < a && a < 10)
                            {
                                switch (a)
                                {
                                    case 1:
                                        lsvValue.Items[i].SubItems[3].Text = "1";
                                        break;
                                    case 2:
                                        lsvValue.Items[i].SubItems[3].Text = "2";
                                        break;
                                    case 3:
                                        lsvValue.Items[i].SubItems[3].Text = "2";
                                        break;
                                    case 4:
                                        lsvValue.Items[i].SubItems[3].Text = "3";
                                        break;
                                    case 5:
                                        lsvValue.Items[i].SubItems[3].Text = "3";
                                        break;
                                    case 6:
                                        lsvValue.Items[i].SubItems[3].Text = "4";
                                        break;
                                    case 7:
                                        lsvValue.Items[i].SubItems[3].Text = "4";
                                        break;
                                    case 8:
                                        lsvValue.Items[i].SubItems[3].Text = "5";
                                        break;
                                    case 9:
                                        lsvValue.Items[i].SubItems[3].Text = "5";
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                lsvValue.Items[i].SubItems[3].Text = "1";
                            }
                        }
                    }
                    break;
                case "1   至   3   由   1":
                    for (int i = 1; i < lsvValue.Items.Count; i++)
                    {
                        if (lsvValue.Items[i].SubItems[2].Text != "" && lsvValue.Items[i].SubItems[3].Text != "")
                        {
                            int a = int.Parse(lsvValue.Items[i].SubItems[2].Text.ToString());
                            if (0 < a && a < 10)
                            {
                                switch (a)
                                {
                                    case 1:
                                        lsvValue.Items[i].SubItems[3].Text = "1";
                                        break;
                                    case 2:
                                        lsvValue.Items[i].SubItems[3].Text = "1";
                                        break;
                                    case 3:
                                        lsvValue.Items[i].SubItems[3].Text = "2";
                                        break;
                                    case 4:
                                        lsvValue.Items[i].SubItems[3].Text = "2";
                                        break;
                                    case 5:
                                        lsvValue.Items[i].SubItems[3].Text = "2";
                                        break;
                                    case 6:
                                        lsvValue.Items[i].SubItems[3].Text = "2";
                                        break;
                                    case 7:
                                        lsvValue.Items[i].SubItems[3].Text = "3";
                                        break;
                                    case 8:
                                        lsvValue.Items[i].SubItems[3].Text = "3";
                                        break;
                                    case 9:
                                        lsvValue.Items[i].SubItems[3].Text = "3";
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                lsvValue.Items[i].SubItems[3].Text = "1";
                            }
                        }
                    }
                    break;
                case "-1   至   1  由   1":
                    for (int i = 1; i < lsvValue.Items.Count; i++)
                    {
                        if (lsvValue.Items[i].SubItems[2].Text != "" && lsvValue.Items[i].SubItems[3].Text != "")
                        {
                            int a = int.Parse(lsvValue.Items[i].SubItems[2].Text.ToString());
                            if (0 < a && a < 10)
                            {
                                switch (a)
                                {
                                    case 1:
                                        lsvValue.Items[i].SubItems[3].Text = "-1";
                                        break;
                                    case 2:
                                        lsvValue.Items[i].SubItems[3].Text = "-1";
                                        break;
                                    case 3:
                                        lsvValue.Items[i].SubItems[3].Text = "0";
                                        break;
                                    case 4:
                                        lsvValue.Items[i].SubItems[3].Text = "0";
                                        break;
                                    case 5:
                                        lsvValue.Items[i].SubItems[3].Text = "0";
                                        break;
                                    case 6:
                                        lsvValue.Items[i].SubItems[3].Text = "0";
                                        break;
                                    case 7:
                                        lsvValue.Items[i].SubItems[3].Text = "1";
                                        break;
                                    case 8:
                                        lsvValue.Items[i].SubItems[3].Text = "1";
                                        break;
                                    case 9:
                                        lsvValue.Items[i].SubItems[3].Text = "1";
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                lsvValue.Items[i].SubItems[3].Text = "-1";
                            }
                        }
                    }
                    break;
                case "-5   至   5   由   1":
                    for (int i = 1; i < lsvValue.Items.Count; i++)
                    {
                        if (lsvValue.Items[i].SubItems[2].Text != "" && lsvValue.Items[i].SubItems[3].Text != "")
                        {
                            int a = int.Parse(lsvValue.Items[i].SubItems[2].Text.ToString());
                            if (0 < a && a < 10)
                            {
                                switch (a)
                                {
                                    case 1:
                                        lsvValue.Items[i].SubItems[3].Text = "-5";
                                        break;
                                    case 2:
                                        lsvValue.Items[i].SubItems[3].Text = "-4";
                                        break;
                                    case 3:
                                        lsvValue.Items[i].SubItems[3].Text = "-2";
                                        break;
                                    case 4:
                                        lsvValue.Items[i].SubItems[3].Text = "-1";
                                        break;
                                    case 5:
                                        lsvValue.Items[i].SubItems[3].Text = "0";
                                        break;
                                    case 6:
                                        lsvValue.Items[i].SubItems[3].Text = "1";
                                        break;
                                    case 7:
                                        lsvValue.Items[i].SubItems[3].Text = "3";
                                        break;
                                    case 8:
                                        lsvValue.Items[i].SubItems[3].Text = "4";
                                        break;
                                    case 9:
                                        lsvValue.Items[i].SubItems[3].Text = "5";
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                lsvValue.Items[i].SubItems[3].Text = "-5";
                            }
                        }
                    }
                    break;
                case "-10  至   10   由   2":
                    for (int i = 1; i < lsvValue.Items.Count; i++)
                    {
                        if (lsvValue.Items[i].SubItems[2].Text != "" && lsvValue.Items[i].SubItems[3].Text != "")
                        {
                            int a = int.Parse(lsvValue.Items[i].SubItems[2].Text.ToString());
                            if (0 < a && a < 10)
                            {
                                switch (a)
                                {
                                    case 1:
                                        lsvValue.Items[i].SubItems[3].Text = "-10";
                                        break;
                                    case 2:
                                        lsvValue.Items[i].SubItems[3].Text = "-8";
                                        break;
                                    case 3:
                                        lsvValue.Items[i].SubItems[3].Text = "-4";
                                        break;
                                    case 4:
                                        lsvValue.Items[i].SubItems[3].Text = "-2";
                                        break;
                                    case 5:
                                        lsvValue.Items[i].SubItems[3].Text = "0";
                                        break;
                                    case 6:
                                        lsvValue.Items[i].SubItems[3].Text = "2";
                                        break;
                                    case 7:
                                        lsvValue.Items[i].SubItems[3].Text = "6";
                                        break;
                                    case 8:
                                        lsvValue.Items[i].SubItems[3].Text = "8";
                                        break;
                                    case 9:
                                        lsvValue.Items[i].SubItems[3].Text = "10";
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                lsvValue.Items[i].SubItems[3].Text = "-10";
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        //删除
        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (this.lsvValue.SelectedItems.Count > 0)
            {        
                this.lsvValue.Items.RemoveAt(this.lsvValue.SelectedItems[0].Index);
            }
        }
        //上移
        private void buttonX4_Click(object sender, EventArgs e)
        {
            ListViewUpMove(lsvValue);
        }
        //下移
        private void buttonX5_Click(object sender, EventArgs e)
        {
            ListViewDownMove(lsvValue);
        }

        //设置等效影响     
        private void buttonX8_Click(object sender, EventArgs e)
        {

            int sum = 0;
            
            for (int i = 1; i < lsvValue.Items.Count; i++)
            {
                if (lsvValue.Items[i].SubItems[0].Text != "" && lsvValue.Items[i].SubItems[1].Text != "")
                {
                    lsvValue.Items[i].SubItems[1].Text = (100 / rasteCount).ToString();
                    sum += 100 / rasteCount;
                }
            }
            lsvValue.Items[0].SubItems[1].Text = (100 - sum).ToString();
        }    
 
        //确定
        private void buttonX9_Click(object sender, EventArgs e)
        {
            #region GP工具的使用

            //实例化GP工具
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            //设置RasterCalculator参数
            WeightedOverlay rastercalculator = new WeightedOverlay();

            string fromTo = comboBox1.Text.ToString();
            string value = "1 9 1";
            if (tbStart.Text != "" && tbOver.Text != "" && tbPlus.Text != "")
            {
                value = tbStart.Text + " " + tbOver.Text + " " + tbPlus.Text;
            }
            else
            {
                switch (fromTo)
                {
                    case "1   至   9   由   1":
                        value = "1 9 1";
                        break;
                    case "1   至   5   由   1":
                        value = "1 5 1";
                        break;
                    case "1   至   3   由   1":
                        value = "1, 3, 1";
                        break;
                    case "-1   至   1  由   1":
                        value = "-1 1 1";
                        break;
                    case "-5   至   5   由   1":
                        value = "-5 5 1";
                        break;
                    case "-10  至   10   由   2":
                        value = "-10 10 2";
                        break;
                    default:
                        break;
                }
            }
            string table=null;
            for (int i = 0; i < lsvValue.Items.Count; i++)
            {
                if (lsvValue.Items[i].SubItems[0].Text != "" && lsvValue.Items[i].SubItems[1].Text != "")
                {
                    if (i == 0)
                    {
                        table = lsvValue.Items[i].SubItems[0].Text.ToString() + " " + lsvValue.Items[i].SubItems[1].Text.ToString() + " " + lsvValue.Items[i].SubItems[2].Text.ToString() + " (";
                    }
                    else
                    {
                        table +="); "+ lsvValue.Items[i].SubItems[0].Text.ToString() + " " + lsvValue.Items[i].SubItems[1].Text.ToString() + " " + lsvValue.Items[i].SubItems[2].Text.ToString() + " (";
                    }
                }
                if (lsvValue.Items[i].SubItems[0].Text == "" && lsvValue.Items[i].SubItems[1].Text == "")
                {
                    table += lsvValue.Items[i].SubItems[2].Text.ToString() + " " + lsvValue.Items[i].SubItems[3].Text.ToString() + ";";
                }
                if (lsvValue.Items[i].SubItems[0].Text == "" && lsvValue.Items[i].SubItems[1].Text == "" && lsvValue.Items[i].SubItems[2].Text == "" && lsvValue.Items[i].SubItems[3].Text == "")
                {
                    table += "));";
                }
            }
            //table = table.Substring(0, table.Length - 1);

            object myWOTable=null;   
       
            //inRaster1 = "snow"
            //inRaster2 = "land"
            //inRaster3 = "soil"

            //remapsnow = RemapValue([[0,1],[1,1],[5,5],[9,9],["NODATA","NODATA"]])
            //remapland = RemapValue([[1,1],[5,5],[6,6],[7,7],[8,8],[9,9],["NODATA","Restricted"]])
            //remapsoil = RemapValue([[0,1],[1,1],[5,5],[6,6],[7,7],[8,8],[9,9],["NODATA", "NODATA"]])

            //myWOTable = WOTable([[inRaster1, 50, "VALUE", remapsnow],
            //                     [inRaster2, 20, "VALUE", remapland],
            //                     [inRaster3, 30, "VALUE", remapsoil]
            //                                                        ], [value]) 


            myWOTable = table+value;
            rastercalculator.in_weighted_overlay_table = myWOTable;
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



        //上移
        private void ListViewUpMove(ListView listView)
        {
            if (listView.SelectedItems.Count == 0)
            {
                return;
            }
            listView.BeginUpdate();
            if (listView.SelectedItems[0].Index > 0)
            {
                foreach (ListViewItem lvi in listView.SelectedItems)
                {
                    ListViewItem lviSelectedItem = lvi;
                    int indexSelectedItem = lvi.Index;
                    listView.Items.RemoveAt(indexSelectedItem);
                    listView.Items.Insert(indexSelectedItem - 1, lviSelectedItem);
                }
            }
            listView.EndUpdate();
            if (listView.Items.Count > 0 && listView.SelectedItems.Count > 0)
            {
                listView.Focus();
                listView.SelectedItems[0].Focused = true;
                listView.SelectedItems[0].EnsureVisible();
            }
        }
        //下移
        private void ListViewDownMove(ListView listView)
        {
            if (listView.SelectedItems.Count == 0)
            {
                return;
            }
            listView.BeginUpdate();
            int indexMaxSelectedItem = listView.SelectedItems[listView.SelectedItems.Count - 1].Index;
            if (indexMaxSelectedItem < listView.Items.Count - 1)
            {
                for (int i = listView.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem lviSelectedItem = listView.SelectedItems[i];
                    int indexSelectedItem = lviSelectedItem.Index;
                    listView.Items.RemoveAt(indexSelectedItem);
                    listView.Items.Insert(indexSelectedItem + 1, lviSelectedItem);
                }
            }
            listView.EndUpdate();
            if (listView.Items.Count > 0 && listView.SelectedItems.Count > 0)
            {
                listView.Focus();
                listView.SelectedItems[listView.SelectedItems.Count - 1].Focused = true;
                listView.SelectedItems[listView.SelectedItems.Count - 1].EnsureVisible();
            }
        }

    }
}
