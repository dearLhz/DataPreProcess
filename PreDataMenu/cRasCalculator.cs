using MyPluginEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreDataMenu
{
    class cRasCalculator : MyPluginEngine.ICommand
    {
       private MyPluginEngine.IApplication hk;
        private Bitmap m_hBitmap;
        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;
        RasTercalForm rastercalculator;
        //private ESRI.ArcGIS.SystemUI.ICommand cmd = null;

        public cRasCalculator()
        {
            string str = @"..\Data\Image\DatapreMenu\rastercal.ico";
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
            get { return "栅格计算器"; }
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
            get { return "栅格计算器"; }
        }

        public string Name
        {
            get { return "DataPreProcess"; }
        }

        public void OnClick()
        {
            rastercalculator.ShowDialog();

        }

        public void OnCreate(IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
                //cmd = new ControlsAddDataCommandCalss();
                //cmd.OnCreate(this.hk.MapControl);
                rastercalculator = new RasTercalForm();
                rastercalculator.pMap = hk.MapControl.Map;
                rastercalculator.Visible = false;
            }
        }

        public string Tooltip
        {
            get { return "栅格计算器"; }
        }
    }
}
