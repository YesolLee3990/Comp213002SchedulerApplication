using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Comp213002SchedulerApplication.SharedCode.controls.util
{
    public static class StyleMaker
    {
        private static Style preStyle = new Style();
        public static string theme;
        public static Style makingStyle(string fontName, string fontSize, string fontColor)
        {
            Style primaryStyle = new Style();
            int tempSize = 10;


            if (fontName != null)
            {
                if (!(fontName.Equals("No change")))
                {
                    primaryStyle.Font.Name = fontName;
                    preStyle.Font.Name = primaryStyle.Font.Name;
                }
                else
                {
                    primaryStyle.Font.Name = preStyle.Font.Name;
                }

                
            }

            switch (fontSize)
            {
                case "No change":
                    primaryStyle.Font.Size = preStyle.Font.Size;
                    break;
                case "Small":
                    primaryStyle.Font.Size = 8;
                    tempSize = 8;
                    break;
                case "Medium":
                    primaryStyle.Font.Size = 10;
                    tempSize = 10;
                    break;
                case "Large":
                    primaryStyle.Font.Size = 12;
                    tempSize = 12;
                    break;
                case "XLarge":
                    primaryStyle.Font.Size = 14;
                    tempSize = 14;
                    break;
                default:
                    break;
            }

            switch (fontColor)
            {
                case "No change":
                    primaryStyle.ForeColor = preStyle.ForeColor;
                    break;
                case "Black":
                    primaryStyle.ForeColor = System.Drawing.Color.Black;
                    break;
                case "Red":
                    primaryStyle.ForeColor = System.Drawing.Color.Red;
                    break;
                case "Blue":
                    primaryStyle.ForeColor = System.Drawing.Color.Blue;
                    break;
                case "Green":
                    primaryStyle.ForeColor = System.Drawing.Color.Green;
                    break;
                case "White":
                    primaryStyle.ForeColor = System.Drawing.Color.White;
                    break;
                case "Yellow":
                    primaryStyle.ForeColor = System.Drawing.Color.Yellow;
                    break;
                default:
                    break;
            }
            if(fontSize!= null && !(fontSize.Equals("No change")))
            {
                preStyle.Font.Size = primaryStyle.Font.Size;
            }
            
            if (fontColor != null && !(fontColor.Equals("No change")))
            {
                preStyle.ForeColor = primaryStyle.ForeColor;
            }
                


            return primaryStyle;
        }
    }
}