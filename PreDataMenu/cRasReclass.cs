using MyPluginEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreDataMenu
{
    class cRasReclass : MyPluginEngine.ICommand
    {
        private MyPluginEngine.IApplication hk;
        private Bitmap m_hBitmap;

        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;
        RasReclassForm rasterReClass1;

        public cRasReclass()
        {
            string str = @"..\Data\Image\DatapreMenu\\RasterReClass.png";
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
            get { return "影像重分类"; }
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
            get { return "影像重分类"; }
        }

        public string Name
        {
            get { return "DataPreProcess"; }
        }

        public void OnClick()
        {
            rasterReClass1.ShowDialog();

        }

        public void OnCreate(IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
                rasterReClass1 = new RasReclassForm(hook.MapControl.Map);
                rasterReClass1.Visible = false;
                //cmd = new ControlsAddDataCommandCalss();
                //cmd.OnCreate(this.hk.MapControl);
            }
        }

        public string Tooltip
        {
            get { return "影像重分类"; }
        }
    }
}
