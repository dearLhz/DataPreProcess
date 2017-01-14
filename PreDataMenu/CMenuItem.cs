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
                    itemDef.ID = "DataPreProcess.cClip";
                    itemDef.Group = false;
                    break;

                case 1:
                    itemDef.ID = "DataPreProcess.cMask";
                    itemDef.Group = false;
                    break;

                case 2:
                    itemDef.ID = "DataPreProcess.cRasCalculator";
                    itemDef.Group = false;
                    break;

                case 3:
                    itemDef.ID = "DataPreProcess.cRasReclass";
                    itemDef.Group = false;
                    break;

                case 4:
                    itemDef.ID = "DataPreProcess.cRasterToVecter";
                    itemDef.Group = false;
                    break;

                case 5:
                    itemDef.ID = "DataPreProcess.cVecterToRaster";
                    itemDef.Group = false;
                    break;

                case 6:
                    itemDef.ID = "DataPreProcess.cWeigOverlay";
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
