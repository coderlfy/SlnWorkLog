using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SystemDataLibrary;

namespace ExportExcelLib.business
{
    public class ExcelAddressBook
    {
        private ApplicationUserData applicationUserData = null;
        private Style titleStyle = null;
        private Style contentStyle = null;
        private Style titleChildren = null;
        private string filename = "temp.xls";
        private Cells excelCells = null;
        public ExcelAddressBook(string filename, ApplicationUserData applicationUserData)
        {
            #region
            this.filename = filename;
            this.applicationUserData = applicationUserData;
            this.titleStyle = new CellsStyle(StyleType.title);
            this.contentStyle = new CellsStyle(StyleType.content);
            this.titleChildren = new CellsStyle(StyleType.titlechildren);
            #endregion
        }
        /// <summary>
        /// 设定列宽
        /// </summary>
        /// <param name="excelCells"></param>
        private void SetColumnsWidth()
        {
            #region
            double[] widths = new double[6] { 4.25, 11.13, 7.25, 26.25, 20.63, 15.50 };
            //设定列宽
            for (int i = 0; i < widths.Length;i++ )
                excelCells.SetColumnWidth(i, widths[i]);
            #endregion
        }
        /// <summary>
        /// 公开接口函数，输出Excel
        /// </summary>
        public void Output()
        {
            #region
            string path = System.Web.HttpContext.Current.Server.MapPath("~");
            path = path.Substring(0, path.LastIndexOf("\\"));
            path += @"\temp\temp.xls";

            Workbook workbook = new Workbook(path);
            Worksheet worksheet = workbook.Worksheets[0];

            this.excelCells = worksheet.Cells;
            this.BindDataAndStyle();

            AutoFitterOptions options = new AutoFitterOptions();
            options.AutoFitMergedCells = true;
            worksheet.AutoFitRows(options);
            int[] heights = new int[2] { 50, 22 };
            int[] specialRow = new int[2] { 0, 1 };
            for (int i = 0; i < specialRow.Length; i++)
                excelCells.SetRowHeight(specialRow[i], heights[i]);

            workbook.Settings.IsWriteProtected = true;
            workbook.Settings.WriteProtectedPassword = "007";
            workbook.Save(System.Web.HttpContext.Current.Response,
                this.filename, ContentDisposition.Attachment,
                new XlsSaveOptions(SaveFormat.Excel97To2003));

            #endregion
        }
        /// <summary>
        /// 添加头标题/头子信息
        /// </summary>
        /// <param name="excelCells"></param>
        /// <param name="startRowIndex"></param>
        private void AddHeader(ref int startRowIndex)
        {
            #region
            //添加头标题
            excelCells.Merge(startRowIndex, 0, 1, 6);
            for (int n = 0; n < 6; n++)
                excelCells[startRowIndex, n].SetStyle(this.titleStyle);
            excelCells[startRowIndex, 0].PutValue("研发一部所有部门成员通讯录");
            startRowIndex++;

            
            #endregion
        }
        /// <summary>
        /// 添加工作日志
        /// </summary>
        /// <param name="excelCells"></param>
        /// <param name="startRowIndex"></param>
        private void AddUserInformation(ref int startRowIndex)
        {
            #region
            this.applicationUserData.Tables[0].DefaultView.Sort = ApplicationUserData.roleId;
            DataRowCollection applicationuser = this.applicationUserData.Tables[0].DefaultView.ToTable().Rows;


            for (int m = 0; m < applicationuser.Count + 1; m++)
            {
                for (int n = 0; n < 6; n++)
                    excelCells[startRowIndex + m, n].SetStyle(this.contentStyle);
            }
            excelCells[startRowIndex, 0].PutValue("序号");
            excelCells[startRowIndex, 1].PutValue("QQ");
            excelCells[startRowIndex, 2].PutValue("姓名");
            excelCells[startRowIndex, 3].PutValue("电话号码");
            excelCells[startRowIndex, 4].PutValue("电子邮箱");
            excelCells[startRowIndex, 5].PutValue("上次使用时刻");
            startRowIndex++;

            for (int m = 0; m < applicationuser.Count; m++)
            {
                excelCells[startRowIndex, 0].PutValue((m + 1).ToString());
                excelCells[startRowIndex, 1].PutValue(applicationuser[m][ApplicationUserData.Username]);
                excelCells[startRowIndex, 2].PutValue(applicationuser[m][ApplicationUserData.fullName]);
                excelCells[startRowIndex, 3].PutValue(applicationuser[m][ApplicationUserData.telephone]);
                excelCells[startRowIndex, 4].PutValue(applicationuser[m][ApplicationUserData.email]);
                excelCells[startRowIndex, 5].PutValue(Convert.ToDateTime(applicationuser[m][ApplicationUserData.lastLoginTime]).ToString("yyyy-MM-dd HH:mm"));
                startRowIndex++;
            }
            #endregion
        }
        /// <summary>
        /// 绑定数据和样式。
        /// </summary>
        private void BindDataAndStyle()
        {
            #region
            //初始化行索引
            int startrowindex = 0;

            this.SetColumnsWidth();

            this.AddHeader(ref startrowindex);

            this.AddUserInformation(ref startrowindex);
            #endregion
        }

    }
}
