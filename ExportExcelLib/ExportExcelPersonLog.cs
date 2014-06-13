using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SystemSqlLibrary;
//using BusinessCommon;
using SystemDataLibrary;

namespace ExportExcelLib
{
    public class ExportExcelPersonLog
    {
        private DataSet datasetExport = null;
        private string filename = "temp.xls";
        private Style titleStyle = null;
        private Style titlechildren = null;
        private Style contentStyle = null;
        private string[] columns = null;
        private string[] columnsHidden = null;
        private string[] columnsTitle = null;       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="datasetExport"></param>
        /// <param name="gridpanel"></param>
        public ExportExcelPersonLog(string filename, DataSet datasetExport, ExtjsGrid gridpanel)
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
            cells.SetColumnWidth(0, 4);
            cells.SetColumnWidth(1, 62);
            cells.SetColumnWidth(2, 6);
            cells.SetColumnWidth(3, 14);
            cells.SetColumnWidth(4, 12);
            cells.SetColumnWidth(5, 8);
            cells.SetColumnWidth(6, 6);
            cells.SetColumnWidth(7, 15);
            #endregion

            worksheet.AutoFitRows();
            workbook.Save(System.Web.HttpContext.Current.Response, filename, ContentDisposition.Attachment, new XlsSaveOptions(SaveFormat.Excel97To2003));
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
            excelCells[0, 0].PutValue("个人工作日志");
            int noshow = 0;//不显示的列数量
            for (int n = 0; n < colsmax; n++)
            {
                if (columnsHidden[n] != "1")//不显示隐藏列
                {
                    excelCells[startrowsindex, n - noshow].SetStyle(this.titlechildren);
                    excelCells[startrowsindex++, n - noshow].PutValue(this.columnsTitle[n]);
                    for (int m = 0; m < rowsmax; m++)
                    {
                        string convertedString = "";
                        excelCells[m + startrowsindex, n - noshow].SetStyle(this.contentStyle);
                        if (columns[n] == "")
                            convertedString = (m + 1).ToString();
                        else
                            convertedString = convertBusiness(drbookcollect[m][this.columns[n]].ToString(), columns[n].ToString());
                        excelCells[m + startrowsindex, n - noshow].PutValue(convertedString);
                    }
                    startrowsindex = 2;
                }
                else {
                    noshow++;
                }              
            }
            excelCells.DeleteBlankColumns(); //去掉空白列
            #endregion
        }
        /// <summary>
        /// 绑定用户用全名和用用户ID
        /// </summary>
        //private static string BindUserFullName(string userid)
        //{
        //    ApplicationUserClass applyuser = new ApplicationUserClass();
        //    ApplicationUserData ds = new ApplicationUserData();
        //    Conditions querybusinessparams = new Conditions();
        //    string userfullname = "";
        //    ds = applyuser.SelectApplicationUser(querybusinessparams);
        //    DataTable dt = new DataTable();
        //    dt = ds.Tables[0];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        if (userid == dt.Rows[i]["userid"].ToString())
        //        {
        //            userfullname = dt.Rows[i]["fullName"].ToString();
        //        }
        //    }
        //    return userfullname;
        //}
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
                //case "writeUser":
                //    retrunString = BindUserFullName(sourceData);
                //    break;
                case "workState":
                    if (sourceData != "1")
                    {
                        retrunString = "已完成";
                    }
                    else
                    {
                        retrunString = "未完成";
                    }
                    break;
                case "submited":
                    if (sourceData != "1")
                    {
                        retrunString = "已提交";
                    }
                    else
                    {
                        retrunString = "未提交";
                    }
                    break;
                case "usable":
                    if (sourceData != "1")
                    {
                        retrunString = "是";
                    }
                    else
                    {
                        retrunString = "否";
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
