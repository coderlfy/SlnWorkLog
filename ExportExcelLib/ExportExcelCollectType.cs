using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportExcelLib
{
    public class ExportExcelCollectType
    {
        private DataSet datasetExport = null;
        private string filename = "temp.xls";
        private Style titleStyle = null;
        private Style titlechildren = null;
        private Style contentStyle = null;
        private string[] columns = null;
        private string[] columnsHidden = null;
        private string[] columnsTitle = null;
        private string[] IsColumns = new string[] { "roleId", "isTotal", "usable", "writeTime", "lastLoginTime" };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="datasetExport"></param>
        /// <param name="gridpanel"></param>
        public ExportExcelCollectType(string filename, DataSet datasetExport, ExtjsGrid gridpanel)
        {
            #region
            this.filename = filename;
            this.datasetExport = datasetExport;

            this.titleStyle = new CellsStyle(StyleType.title);
            this.titlechildren = new CellsStyle(StyleType.titlechildren);
            this.contentStyle = new CellsStyle(StyleType.content);

            this.columns = gridpanel.ViewColumnNames.Split(',');
            this.columnsHidden = gridpanel.ColumnsHidden.Split(',');
            this.columnsTitle = gridpanel.ViewTitleNames.Split(',');
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public void Output()
        {
            #region
            string path = System.Web.HttpContext.Current.Server.MapPath("~");
            path = path.Substring(0, path.LastIndexOf("\\"));
            path += @"\temp\temp.xls";

            Workbook workbook = new Workbook(path);
            Worksheet worksheet = workbook.Worksheets[0];
            Cells cells = worksheet.Cells;
            cells.StandardHeight = 22;

            this.BindDataAndStyle(cells);

            #region 列宽设定
            cells.SetColumnWidth(0, 6);
            cells.SetColumnWidth(1, 15);
            cells.SetColumnWidth(2, 15);
            cells.SetColumnWidth(3, 15);
            cells.SetColumnWidth(4, 15);
            cells.SetColumnWidth(5, 10);
            cells.SetColumnWidth(6, 15);
            cells.SetColumnWidth(7, 15);
            #endregion

            worksheet.AutoFitRows();
            workbook.Save(System.Web.HttpContext.Current.Response,
                filename, ContentDisposition.Attachment,
                new XlsSaveOptions(SaveFormat.Excel97To2003));

            #endregion
        }
        /// <summary>
        /// 绑定数据和设置单元格样式
        /// </summary>
        /// <param name="excelCells"></param>
        private void BindDataAndStyle(Cells excelCells)
        {
            #region
            DataRowCollection drbookcollect = datasetExport.Tables[0].Rows;
            int rowsmax = drbookcollect.Count;
            int colsmax = columns.Length;
            int startrowsindex = 2;
            excelCells.Merge(0, 0, 2, 9);//合并单元格 
            excelCells[0, 0].SetStyle(titleStyle);
            excelCells[0, 0].PutValue("汇总分类信息");
            //int noshow = 0;//不显示的列数量
            for (int n = 0; n < colsmax; n++)
            {
                if (!IsColumns.Contains(columns[n]))
                {
                    excelCells[startrowsindex, n].SetStyle(this.titlechildren);
                    excelCells[startrowsindex++, n].PutValue(this.columnsTitle[n]);
                    for (int m = 0; m < rowsmax; m++)
                    {
                        string convertedString = "";
                        excelCells[m + startrowsindex, n].SetStyle(this.contentStyle);
                        if (columns[n] == "")
                            convertedString = (m + 1).ToString();//excelCells[m + startrowsindex, n].PutValue((m + 1).ToString());
                        else
                            convertedString = convertBusiness(drbookcollect[m][this.columns[n]].ToString(), columns[n].ToString());
                        excelCells[m + startrowsindex, n].PutValue(convertedString);                 
                    }
                    startrowsindex = 2;
                }        
            }
            excelCells.DeleteBlankColumns(); //去掉空白列
            #endregion
        }

        /// <summary>
        /// 数据库中数据转换为业务表述
        /// </summary>
        /// <param name="sourceData">数据库存的实际数据</param>
        /// <param name="colName">列名称</param>
        /// <returns></returns>
        private string convertBusiness(string sourceData, string colName)
        {
            string retrunString = "";
            switch (colName)
            {
                case "releaseType":
                    if (sourceData == "1")
                    {
                        retrunString = "对内发布";
                    }
                    else if (sourceData == "2")
                    {
                        retrunString = "对生产部发布";
                    }
                    else if (sourceData == "3")
                    {
                        retrunString = "对工程部发布";
                    }
                    break;
                default:
                    retrunString = sourceData;
                    break;
            }
            return retrunString;
        }
    }
}
