/****************************************
***创建人：bhlfy
***创建时间：2013-04-24 18:43:49
***公司：山西博华科技有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using System;
using System.Data;

using WorkLogDataLibrary;
using WorkLogSqlLibrary;
using ExportExcelLib;
using ExportExcelLib.business;
using SystemDataLibrary;
using NPinyin;
using BusinessBase;
using Fundation.Core;

namespace WorkLogBusiness
{
    public class WLOGWeekSummaryBusiness : GeneralBusinesser
    {
        private WLOGWeekSummaryClass _wlogweeksummaryclass = new WLOGWeekSummaryClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-24 18:43:49
        ***公司：山西博华科技有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        
        /// <summary>
        /// 根据条件筛选所有WLOGWeekSummary指定页码的数据（分页型）
        /// </summary>
        /// <param name="wlogweeksummary">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityWLOGWeekSummary wlogweeksummary, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            WLOGWeekSummaryClass wlogweeksummaryclass = new WLOGWeekSummaryClass();
            pageparams.PageSorts.Add(new PageSort(WLOGWeekSummaryData.writeTime, EnumSQLOrderBY.DESC));
            DataSet wlogweeksummarydata = this.GetData(wlogweeksummary, pageparams, out totalCount);
            return base.GetJson(wlogweeksummarydata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存wlogweeksummarydata数据集数据
        /// </summary>
        /// <param name="wlogweeksummarydata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveWLOGWeekSummary(WLOGWeekSummaryData wlogweeksummarydata)
        {
            #region
            WLOGWeekSummaryClass wlogweeksummaryclass = new WLOGWeekSummaryClass();
            return base.Save(wlogweeksummarydata, wlogweeksummaryclass);
            #endregion
        }
                
        /// <summary>
        /// 添加WLOGWeekSummary表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="wlogweeksummarydata">数据集对象</param>
        /// <param name="wlogweeksummary">实体对象</param>
        public void AddRow(ref WLOGWeekSummaryData wlogweeksummarydata, EntityWLOGWeekSummary wlogweeksummary)
        {
            #region
            DataRow dr = wlogweeksummarydata.Tables[0].NewRow();
            wlogweeksummary.summaryId = this._wlogweeksummaryclass.GetMaxAddOne(wlogweeksummarydata).ToString();
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.summaryId, wlogweeksummary.summaryId);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.writeUser, wlogweeksummary.writeUser);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.startDate, wlogweeksummary.startDate);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.endDate, wlogweeksummary.endDate);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.weekBH, wlogweeksummary.weekBH);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.submited, wlogweeksummary.submited);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.submitTime, wlogweeksummary.submitTime);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.writeTime, wlogweeksummary.writeTime);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.writeIp, wlogweeksummary.writeIp);
            wlogweeksummarydata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑wlogweeksummarydata数据集中指定的行数据
        /// </summary>
        /// <param name="wlogweeksummarydata">数据集对象</param>
        /// <param name="wlogweeksummary">实体对象</param>
        public void EditRow(ref WLOGWeekSummaryData wlogweeksummarydata, EntityWLOGWeekSummary wlogweeksummary)
        {
            #region
            if (wlogweeksummarydata.Tables[0].Rows.Count <= 0)
                wlogweeksummarydata = this.getData(wlogweeksummary.summaryId);
            DataRow dr = wlogweeksummarydata.Tables[0].Rows.Find(new object[1] {wlogweeksummary.summaryId});
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.summaryId, wlogweeksummary.summaryId);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.writeUser, wlogweeksummary.writeUser);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.startDate, wlogweeksummary.startDate);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.endDate, wlogweeksummary.endDate);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.weekBH, wlogweeksummary.weekBH);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.submited, wlogweeksummary.submited);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.submitTime, wlogweeksummary.submitTime);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.writeTime, wlogweeksummary.writeTime);
            wlogweeksummarydata.Assign(dr, WLOGWeekSummaryData.writeIp, wlogweeksummary.writeIp);
            #endregion
        }
        		
        /// <summary>
        /// 删除wlogweeksummarydata数据集中指定的行数据
        /// </summary>
        /// <param name="wlogweeksummarydata">数据集对象</param>
        /// <param name="summaryId">主键-周总结流水号</param>
        public void DeleteRow(ref WLOGWeekSummaryData wlogweeksummarydata,string summaryId)
        {
            #region
            if (wlogweeksummarydata.Tables[0].Rows.Count <= 0)
                wlogweeksummarydata = this.getData(summaryId);
            DataRow dr = wlogweeksummarydata.Tables[0].Rows.Find(new object[1] { summaryId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取WLOGWeekSummary数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            WLOGWeekSummaryData wlogweeksummarydata = this.getData(null);
            totalCount = wlogweeksummarydata.Tables[0].Rows.Count;
            return base.GetJson(wlogweeksummarydata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityWLOGWeekSummary wlogweeksummary)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(wlogweeksummary, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="summaryId">主键-周总结流水号</param>
        /// <returns></returns>
        private WLOGWeekSummaryData getData(string summaryId)
        {
            #region
            WLOGWeekSummaryData wlogweeksummarydata = new WLOGWeekSummaryData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(WLOGWeekSummaryData.summaryId, EnumSqlType.sqlint, EnumCondition.Equal, summaryId);
            this._wlogweeksummaryclass.GetSingleTAllWithoutCount(wlogweeksummarydata, querybusinessparams);
            return wlogweeksummarydata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有WLOGWeekSummary指定页码的数据（分页型）
        /// </summary>
        /// <param name="wlogweeksummary">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityWLOGWeekSummary wlogweeksummary, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(WLOGWeekSummaryData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, wlogweeksummary.writeUser);
            querybusinessparams.Add(WLOGWeekSummaryData.weekBH, EnumSqlType.nvarchar, 
                EnumCondition.Equal, wlogweeksummary.weekBH);
            querybusinessparams.Add(WLOGWeekSummaryData.startDate, EnumSqlType.datetime,
                EnumCondition.GreaterOrEqual, wlogweeksummary.startDate);
            querybusinessparams.Add(WLOGWeekSummaryData.endDate, EnumSqlType.datetime,
                EnumCondition.LessOrEqual, wlogweeksummary.endDate);
            querybusinessparams.Add(WLOGWeekSummaryData.submited, EnumSqlType.bit, 
                EnumCondition.Equal, wlogweeksummary.submited);
            WLOGWeekSummaryData wlogweeksummarydata = new WLOGWeekSummaryData();
            totalCount = this._wlogweeksummaryclass.SelectWLOGWeekSummaryByPage(wlogweeksummarydata,querybusinessparams);
            return wlogweeksummarydata;
            #endregion
        }
        #endregion

        #endregion
        /// <summary>
        /// 查找是否存在所选周日志。
        /// </summary>
        /// <param name="wlogweeksummary"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public bool FindUserWeekSummary(EntityWLOGWeekSummary wlogweeksummary, ref string json)
        {
            #region
            int totalCount = 0;
            PageParams pageparams = new PageParams();
            WLOGWeekSummaryData wlogweeksummarydata = new WLOGWeekSummaryData();
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(WLOGWeekSummaryData.writeUser, EnumSqlType.sqlint, EnumCondition.Equal, wlogweeksummary.writeUser);
            querybusinessparams.Add(WLOGWeekSummaryData.startDate, EnumSqlType.datetime, EnumCondition.Equal, wlogweeksummary.startDate);
            WLOGWeekSummaryData weeksummarydata = new WLOGWeekSummaryData();
            totalCount = this._wlogweeksummaryclass.GetSingleT(weeksummarydata, querybusinessparams);
            JsonHelper jsonhlp = new JsonHelper();
            if (weeksummarydata.Tables[0].Rows.Count > 0)
            {
                jsonhlp.AddObjectToJson("msg", "请注意：每人每周只限一篇总结！");
                jsonhlp.SetResult(false);
                json = jsonhlp.ToString();
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }

        private string getFilename(WLOGWeekSummaryData weeksummarydata, string summaryExcelWriteUser)
        {
            #region
            string filenameformat = "{0}{1}.xls";
            string filename = "";
            if (weeksummarydata.Tables[0].Rows.Count == 1)
            {
                DataRow dr = weeksummarydata.Tables[0].Rows[0];
                string date = Convert.ToDateTime(dr[WLOGWeekSummaryData.startDate]).ToString("yyyy-MM-dd");
                if (summaryExcelWriteUser != "")
                {
                    DataRow druser = weeksummarydata.Tables[0].Rows[0];
                    filename = string.Format(filenameformat,
                        Pinyin.GetPinyin(summaryExcelWriteUser).Replace(" ", ""),
                        date);

                }
                else
                    filename = string.Format(filenameformat, "noname", date);
            }
            else
                filename = string.Format(filenameformat, "noname", "");
            return filename;
            #endregion
        }
        /// <summary>
        /// 导出工作总结。
        /// </summary>
        /// <param name="summaryId"></param>
        /// <param name="summaryExcelWriteUser"></param>
        public void OutputSummaryExcel(string summaryId, string summaryExcelWriteUser)
        {
            #region
            WLOGWeekSummaryData weeksummarydata = this.getData(summaryId);
            PageParams pageparams = new PageParams();
            WLOGWeekSummaryData wlogweeksummarydata = new WLOGWeekSummaryData();
            DBConditions querybusinessparams = new DBConditions(pageparams);

            querybusinessparams.Add(WLOGMissionData.summaryId, 
                EnumSqlType.sqlint, EnumCondition.Equal, summaryId);
            WLOGMissionData missiondata = new WLOGMissionData();
            this._wlogweeksummaryclass.GetSingleT(missiondata, querybusinessparams);

            string missionsid = "";
            DataRowCollection drcollect = missiondata.Tables[0].Rows;
            for (int i = 0; i < drcollect.Count; i++)
            {
                string temp = drcollect[i][WLOGMissionData.missionId].ToString();
                if (i != drcollect.Count - 1)
                    temp += ',';
                missionsid += temp;
            }

            DataRow drsummary = weeksummarydata.Tables[0].Rows[0];
            DBConditions personlogquerybusinessparams = new DBConditions();
            personlogquerybusinessparams.Add(WLOGPersonLogData.writeUser, EnumSqlType.sqlint, EnumCondition.Equal, drsummary[WLOGWeekSummaryData.writeUser]);
            personlogquerybusinessparams.Add(WLOGPersonLogData.logDate, EnumSqlType.datetime, EnumCondition.GreaterOrEqual, drsummary[WLOGWeekSummaryData.startDate]);
            personlogquerybusinessparams.Add(WLOGPersonLogData.logDate, EnumSqlType.datetime, EnumCondition.LessOrEqual, drsummary[WLOGWeekSummaryData.endDate]);
            WLOGPersonLogData wlogpersonlogdata = new WLOGPersonLogData();
            this._wlogweeksummaryclass.GetSingleT(wlogpersonlogdata, personlogquerybusinessparams); 

            ExcelSummary excelsummary = new ExcelSummary(this.getFilename(weeksummarydata, summaryExcelWriteUser), weeksummarydata, missiondata, wlogpersonlogdata, summaryExcelWriteUser);
            excelsummary.Output();
            #endregion
        }
    }
}


