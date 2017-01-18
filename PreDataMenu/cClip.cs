using MyPluginEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreDataMenu
{
    class cClip : MyPluginEngine.ICommand
    {
         private MyPluginEngine.IApplication hk;
        private System.Drawing.Bitmap m_hBitmap;
        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;
        FormClip clip;


        public cClip()
        {
            string str = @"..\Data\Image\DatapreMenu\Clip.png";
            if (System.IO.File.Exists(str))
                m_hBitmap = new Bitmap(str);
            else
                m_hBitmap = null;
        }

        #region ICommand 成员
        public System.Drawing.Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "图层裁剪"; }
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
            get { return "图层裁剪"; }
        }

        public string Name
        {
            get { return "DataPreProcess"; }
        }

        public void OnClick()
        {
            clip.ShowDialog();
        }

        public void OnCreate(IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
                clip = new FormClip(hook.MapControl.Map);
                clip.Visible = false;
            }
        }

        public string Tooltip
        {
            get { return "图层裁剪"; }
        }
        #endregion
    }
}
