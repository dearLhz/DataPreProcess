using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPluginEngine;

namespace PreDataMenu
{
    class CMenuItem : IMenuDef
    {
        public string Caption//标题
        {
            get { return "数据预处理"; }
        }

        public void GetItemInfo(int pos, ItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "PreDataMenu.ReSmaple";
                    itemDef.Group = false;
                    break;

                case 1:
                    itemDef.ID = "PreDataMenu.RasterToVecter";
                    itemDef.Group = false;
                    break;

                case 2:
                    itemDef.ID = "PreDataMenu.VecterToRaster";
                    itemDef.Group = false;
                    break;

                case 3:
                    itemDef.ID = "PreDataMenu.RasReclass";
                    itemDef.Group = false;
                    break;

                case 4:
                    itemDef.ID = "PreDataMenu.RasTercal";
                    itemDef.Group = false;
                    break;

                case 5:
                    itemDef.ID = "PreDataMenu.cProject";
                    itemDef.Group = false;
                    break;
                default:
                    break;
            }
        }

        public long ItemCount//项目数量
        {
            get { return 6; }
        }

        public string Name
        {
            get { return "All"; }
        }
    }
}
