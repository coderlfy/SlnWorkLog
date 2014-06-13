using Aspose.Cells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WorkLogDataLibrary;

namespace ExportExcelLib.business
{
    public class ExcelSummary
    {
        private WLOGMissionData missionData = null;
        private WLOGWeekSummaryData summaryData = null;
        private WLOGPersonLogData personlogData = null;
        private Style titleStyle = null;
        private Style contentStyle = null;
        private Style titleChildren = null;
        private Style titleInleft = null;
        private Cells excelCells = null;
        private string logsFullname = "";
        private Hashtable workState = new Hashtable();
        private string remarkAddFormat = "->详见（{0}）的日志。";
        private string filename = "temp.xls";
        private int[] specialRow = new int[8];
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workStateId"></param>
        /// <returns></returns>
        private string getWorkStateName(object workStateId)
        {
            #region
            foreach(DictionaryEntry de in workState)
            {
                if (de.Key.ToString() == workStateId.ToString())
                    return de.Value.ToString();
            }
            return "";
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void createWorkState()
        {
            #region
            workState.Add("2", "已完成");
            workState.Add("1", "未完成");
            #endregion
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="summaryData"></param>
        /// <param name="missionData"></param>
        /// <param name="personlogData"></param>
        /// <param name="fullname"></param>
        public ExcelSummary(string filename, WLOGWeekSummaryData summaryData
            , WLOGMissionData missionData, WLOGPersonLogData personlogData, string fullname)
        {
            #region
            this.filename = filename;
            this.summaryData = summaryData;
            this.missionData = missionData;
            this.personlogData = personlogData;
            this.titleStyle = new CellsStyle(StyleType.title);
            this.contentStyle = new CellsStyle(StyleType.content);
            this.titleChildren = new CellsStyle(StyleType.titlechildren);
            this.titleInleft = new CellsStyle(StyleType.titleInLeft);
            this.logsFullname = fullname;
            this.createWorkState();
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

            int[] heights = new int[8] { 50, 22, 22, 35, 22, 22, 22, 22};
            for (int i = 0; i < specialRow.Length;i++ )
                excelCells.SetRowHeight(this.specialRow[i], heights[i]);

            workbook.Settings.IsWriteProtected = true;
            workbook.Settings.WriteProtectedPassword = "007";
            workbook.Save(System.Web.HttpContext.Current.Response,
                this.filename, ContentDisposition.Attachment,
                new XlsSaveOptions(SaveFormat.Excel97To2003));

            #endregion
        }
        /// <summary>
        /// 设定列宽
        /// </summary>
        /// <param name="excelCells"></param>
        private void SetColumnsWidth()
        {
            #region
            double[] widths = new double[9] { 6.13, 9, 11, 10.25, 6.38, 10.25, 9.38, 8, 9.52 };
            //设定列宽
            for (int i = 0; i < widths.Length; i++)
                excelCells.SetColumnWidth(i, widths[i]);
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
            string submitRemark = "";
            excelCells.Merge(startRowIndex, 0, 1, 9);
            for (int n = 0; n < 9; n++)
                excelCells[startRowIndex, n].SetStyle(this.titleStyle);
            excelCells[startRowIndex, 0].PutValue("研发一部部门成员工作日志和总结");
            startRowIndex++;

            //添加头子信息
            excelCells.Merge(startRowIndex, 7, 1, 2);
            for (int n = 0; n < 9; n++)
                excelCells[startRowIndex, n].SetStyle(this.titleChildren);

            DataRow dr = this.summaryData.Tables[0].Rows[0];

            excelCells[startRowIndex, 0].PutValue("姓名：");
            excelCells[startRowIndex, 1].PutValue(this.logsFullname);
            excelCells[startRowIndex, 2].PutValue("日志时段从：");
            excelCells[startRowIndex, 3].PutValue(Convert.ToDateTime(dr[WLOGWeekSummaryData.startDate]).ToString("yyyy-MM-dd"));
            excelCells[startRowIndex, 4].PutValue("至");
            excelCells[startRowIndex, 5].PutValue(Convert.ToDateTime(dr[WLOGWeekSummaryData.endDate]).ToString("yyyy-MM-dd"));
            excelCells[startRowIndex, 6].PutValue("提交时刻：");

            submitRemark = (dr[WLOGWeekSummaryData.submitTime] != System.DBNull.Value) ? 
                Convert.ToDateTime(dr[WLOGWeekSummaryData.submitTime]).ToString("yyyy-MM-dd HH:mm") 
                : "未提交";
            excelCells[startRowIndex, 7].PutValue(submitRemark);
            startRowIndex++;
            specialRow[0] = 0;
            specialRow[1] = 1;
            #endregion
        }
        /// <summary>
        /// 添加工作日志
        /// </summary>
        /// <param name="excelCells"></param>
        /// <param name="startRowIndex"></param>
        private void AddPersonLogs(ref int startRowIndex)
        {
            #region
            //添加工作日志
            specialRow[2] = 2;
            //排了下序
            personlogData.Tables[0].DefaultView.Sort = WLOGPersonLogData.logDate;
            DataRowCollection personlogcollect = personlogData.Tables[0].DefaultView.ToTable().Rows;
            for (int m = 0; m < personlogcollect.Count + 1; m++)
            {
                excelCells.Merge(startRowIndex + m, 2, 1, 4);
                excelCells.Merge(startRowIndex + m, 6, 1, 2);
            }

            for (int m = 0; m < personlogcollect.Count + 1; m++)
            {
                for (int n = 0; n < 9; n++)
                    excelCells[startRowIndex + m, n].SetStyle(this.contentStyle);
            }
            excelCells[startRowIndex, 0].PutValue("序号");
            excelCells[startRowIndex, 1].PutValue("日期");
            excelCells[startRowIndex, 2].PutValue("工作内容描述");
            excelCells[startRowIndex, 6].PutValue("输出结果");
            excelCells[startRowIndex, 8].PutValue("完成状态");
            startRowIndex++;

            for (int m = 0; m < personlogcollect.Count; m++)
            {
                excelCells[startRowIndex, 0].PutValue((m + 1).ToString());
                excelCells[startRowIndex, 1].PutValue(Convert.ToDateTime(personlogcollect[m][WLOGPersonLogData.logDate]).ToString("MM-dd"));
                excelCells[startRowIndex, 2].PutValue(personlogcollect[m][WLOGPersonLogData.logContent]);
                excelCells[startRowIndex, 6].PutValue(personlogcollect[m][WLOGPersonLogData.workResult]);
                excelCells[startRowIndex, 8].PutValue(this.getWorkStateName(personlogcollect[m][WLOGPersonLogData.workState]));
                startRowIndex++;
            }
            #endregion
        }
        /// <summary>
        /// 添加工作项
        /// </summary>
        /// <param name="excelCells"></param>
        /// <param name="startRowIndex"></param>
        private void AddMissions(ref int startRowIndex)
        {
            #region
            //添加工作总结
            excelCells.Merge(startRowIndex, 0, 1, 9);
            for (int n = 0; n < 9; n++)
                excelCells[startRowIndex, n].SetStyle(this.titleStyle);

            excelCells[startRowIndex, 0].PutValue("工作总结");
            specialRow[3] = startRowIndex;

            startRowIndex++;

            this.AddPlannedMissions(ref startRowIndex);
            this.AddOutPlanMissions(ref startRowIndex);
            #endregion
        }
        /// <summary>
        /// 添加计划内工作项
        /// </summary>
        /// <param name="startRowIndex"></param>
        private void AddPlannedMissions(ref int startRowIndex)
        {
            #region
            //添加计划内工作项
            excelCells.Merge(startRowIndex, 0, 1, 9); //合并单元格
            //设置首行样式
            for (int n = 0; n < 9; n++)
                excelCells[startRowIndex, n].SetStyle(this.titleInleft);

            excelCells[startRowIndex, 0].PutValue("计划内工作项");
            specialRow[4] = startRowIndex;
            startRowIndex++;

            //过滤出计划内任务
            DataRow[] missionsinplan = this.missionData.Tables[0].Select(WLOGMissionData.planned + "=1");

            //设置样式
            for (int m = 0; m < missionsinplan.Length + 1; m++)
                for (int n = 0; n < 9; n++)
                    excelCells[startRowIndex + m, n].SetStyle(this.contentStyle);
            //合并单元格
            for (int m = 0; m < missionsinplan.Length + 1; m++)
                excelCells.Merge(startRowIndex + m, 2, 1, 5);

            //添加首行
            excelCells[startRowIndex, 0].PutValue("序号");
            excelCells[startRowIndex, 1].PutValue("任务编号");
            excelCells[startRowIndex, 2].PutValue("工作任务");
            excelCells[startRowIndex, 7].PutValue("完成状态");
            excelCells[startRowIndex, 8].PutValue("备注");
            specialRow[5] = startRowIndex;
            startRowIndex++;

            //添加数据
            for (int m = 0; m < missionsinplan.Length; m++)
            {
                string filterexpression = WLOGPersonLogData.missionId + " = " + missionsinplan[m][WLOGMissionData.missionId].ToString();

                excelCells[startRowIndex, 0].PutValue((m + 1).ToString());
                excelCells[startRowIndex, 1].PutValue(missionsinplan[m][WLOGMissionData.missionBH]);
                excelCells[startRowIndex, 2].PutValue(missionsinplan[m][WLOGMissionData.missionName]);
                excelCells[startRowIndex, 7].PutValue(this.getWorkStateName(missionsinplan[m][WLOGMissionData.missionState]));
                excelCells[startRowIndex, 8].PutValue(this.getMissionRemark(missionsinplan[m], filterexpression));
                startRowIndex++;
            }
            #endregion
        }
        /// <summary>
        /// 添加计划外工作项
        /// </summary>
        /// <param name="startRowIndex"></param>
        private void AddOutPlanMissions(ref int startRowIndex)
        {
            #region
            //添加计划外工作项
            excelCells.Merge(startRowIndex, 0, 1, 9);
            for (int n = 0; n < 9; n++)
                excelCells[startRowIndex, n].SetStyle(this.titleInleft);

            excelCells[startRowIndex, 0].PutValue("计划外工作项");
            specialRow[6] = startRowIndex;
            startRowIndex++;

            DataRow[] missionsoutplan = this.missionData.Tables[0].Select(WLOGMissionData.planned + "=0");

            for (int m = 0; m < missionsoutplan.Length + 1; m++)
                for (int n = 0; n < 9; n++)
                    excelCells[startRowIndex + m, n].SetStyle(this.contentStyle);


            for (int m = 0; m < missionsoutplan.Length + 1; m++)
                excelCells.Merge(startRowIndex + m, 1, 1, 2);

            excelCells[startRowIndex, 0].PutValue("序号");
            excelCells[startRowIndex, 1].PutValue("工作任务");
            excelCells[startRowIndex, 3].PutValue("工作成果");
            excelCells[startRowIndex, 4].PutValue("工期");
            excelCells[startRowIndex, 5].PutValue("起始");
            excelCells[startRowIndex, 6].PutValue("截至");
            excelCells[startRowIndex, 7].PutValue("完成状态");
            excelCells[startRowIndex, 8].PutValue("备注");
            specialRow[7] = startRowIndex;
            startRowIndex++;

            DataSet daycountpersonlog = personlogData.Copy();
            
            for (int m = 0; m < missionsoutplan.Length; m++)
            {
                string startdate = "", enddate = "";
                string filterexpression = WLOGPersonLogData.missionId + " = " + missionsoutplan[m][WLOGMissionData.missionId].ToString();
                DataRow[] daypersonlogrows = daycountpersonlog.Tables[0].Select(filterexpression);
                if (daypersonlogrows.Length > 0)
                    this.getAreaDate(daypersonlogrows, ref startdate, ref enddate);

                excelCells[startRowIndex, 0].PutValue((m + 1).ToString());
                excelCells[startRowIndex, 1].PutValue(missionsoutplan[m][WLOGMissionData.missionName]);
                excelCells[startRowIndex, 3].PutValue(missionsoutplan[m][WLOGMissionData.outputResult]);
                excelCells[startRowIndex, 4].PutValue(daypersonlogrows.Length);
                excelCells[startRowIndex, 5].PutValue(startdate);
                excelCells[startRowIndex, 6].PutValue(enddate);
                excelCells[startRowIndex, 7].PutValue(this.getWorkStateName(missionsoutplan[m][WLOGMissionData.missionState]));
                excelCells[startRowIndex, 8].PutValue(this.getMissionRemark(missionsoutplan[m], filterexpression));
                startRowIndex++;

                foreach (DataRow dr in daypersonlogrows)
                    daycountpersonlog.Tables[0].Rows.Remove(dr);
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="personLogs"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void getAreaDate(DataRow[] personLogs, ref string start, ref string end)
        {
            #region
            DateTime startdate, enddate;
            startdate = enddate = Convert.ToDateTime(personLogs[0][WLOGPersonLogData.logDate]);
            for (int i = 0; i < personLogs.Length; i++)
            { 
                DateTime temp = Convert.ToDateTime(personLogs[i][WLOGPersonLogData.logDate]);

                if (startdate > temp)
                    startdate = temp;
                if (enddate < temp)
                    enddate = temp;
            }

            start = startdate.ToString("MM-dd");
            end = enddate.ToString("MM-dd");
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="missionRow"></param>
        /// <param name="filterExpression"></param>
        /// <returns></returns>
        private string getMissionRemark(DataRow missionRow, string filterExpression)
        {
            #region
            string remark = missionRow[WLOGMissionData.missionRemark].ToString();
            DataRow[] personlogrows = personlogData.Tables[0].Select(filterExpression);
            string days = "";
            for (int i = 0; i < personlogrows.Length; i++)
            {
                string temp = Convert.ToDateTime(personlogrows[i][WLOGPersonLogData.logDate]).ToString("MM-dd");
                if (i != personlogrows.Length - 1)
                    days += temp + ",";
                else
                    days += temp;
            }
            if (personlogrows.Length > 0)
                remark += String.Format(this.remarkAddFormat, days);
            return remark;
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

            this.AddPersonLogs(ref startrowindex);

            this.AddMissions(ref startrowindex);
            #endregion
        }
    }
}
