using MyPluginEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreDataMenu
{
    class cMask: MyPluginEngine.ICommand
    {
        
        private MyPluginEngine.IApplication hk;
        private Bitmap m_hBitmap;
        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;
        FormMask F2Raster;

        public cMask()
        {
            string str = @"..\Data\river-Image\03空间分析\mask.png";
            if (System.IO.File.Exists(str))
                m_hBitmap = new Bitmap(str);
            else
                m_hBitmap = null;

        }

        public System.Drawing.Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "按掩膜提取"; }
        }

        public string Category
        {
            get { return "ALL"; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public bool Enabled
        {
            get { return true; }
        }

        public int HelpContextId
        {
            get { return 0; }
        }

        public string HelpFile
        {
            get { return ""; }
        }
        public string Message
        {
            get { return "按掩膜提取"; }
        }

        public string Name
        {
            get { return "SpatialAnalys"; }
        }

        public void OnClick()
        {
            //RasReclassForm frmCreatSpatialDB = new RasReclassForm();
            //frmCreatSpatialDB.ShowDialog();
            F2Raster.ShowDialog();

        }

        public void OnCreate(IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
                //cmd = new ControlsAddDataCommandCalss();
                //cmd.OnCreate(this.hk.MapControl);
                F2Raster = new FormMask();
                F2Raster.pMap = hk.MapControl.Map;
                F2Raster.Visible = false;
            }
        }

        public string Tooltip
        {
            get { return "按掩膜提取"; }
        }
    }
}
