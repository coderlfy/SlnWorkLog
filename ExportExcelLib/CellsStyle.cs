using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ExportExcelLib
{
    class CellsStyle : Style
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="styleType"></param>
        public CellsStyle(StyleType styleType)
        {
            #region
            this.Font.Name = "Tahoma";
            this.Borders[BorderType.LeftBorder].Color = Color.Black;
            this.Borders[BorderType.RightBorder].Color = Color.Black;
            this.Borders[BorderType.TopBorder].Color = Color.Black;
            this.Borders[BorderType.BottomBorder].Color = Color.Black;

            this.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            this.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
            this.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            this.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            this.IsTextWrapped = true;
            switch (styleType)
            {
                case StyleType.title:
                    this.ForegroundColor = Color.FromArgb(100,208,255);
                    this.Pattern = BackgroundType.Solid;
                    this.Font.Size = 16;
                    this.Font.IsBold = true;
                    this.Font.Name = "宋体";
                    this.HorizontalAlignment = TextAlignmentType.Center;
                    break;

                case StyleType.titlechildren:
                    this.ForegroundColor = Color.FromArgb(100, 208, 255);
                    this.Pattern = BackgroundType.Solid;
                    this.Font.Size = 10;
                    this.Font.IsBold = true;
                    this.Font.Name = "宋体";
                    this.HorizontalAlignment = TextAlignmentType.Center;
                    break;
                case StyleType.titleInLeft:
                    //this.BackgroundColor = Color.Aqua;
                    this.Font.Size = 10;
                    this.Font.Name = "宋体";
                    this.Font.IsBold = true;
                    this.HorizontalAlignment = TextAlignmentType.Left;
                    break;
                case StyleType.content:
                    //this.BackgroundColor = Color.Aqua;
                    this.Font.Size = 10;
                    break;
                default:
                    break;
            }
            #endregion
        }
    }
}
