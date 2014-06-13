/****************************************
***创建人：bhlfy
***创建时间：2013-04-24 18:43:49
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using System;
using System.Data;

using WorkLogDataLibrary;
using WorkLogSqlLibrary;
using ExportExcelLib;
using WorkLogDataLibrary.business;
using SystemDataLibrary;
using BusinessBase;
using Fundation.Core;

namespace WorkLogBusiness
{
    public class WLOGPersonLogBusiness : GeneralBusinesser
    {
        private WLOGPersonLogClass _wlogpersonlogclass = new WLOGPersonLogClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-24 18:43:49
        ***公司：山西ICat Studio有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        
        /// <summary>
        /// 根据条件筛选所有WLOGPersonLog指定页码的数据（分页型）
        /// </summary>
        /// <param name="wlogpersonlog">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityWLOGPersonLog wlogpersonlog, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            WLOGPersonLogClass wlogpersonlogclass = new WLOGPersonLogClass();
            pageparams.PageSorts.Add(new PageSort(WLOGPersonLogData.writeTime, EnumSQLOrderBY.DESC));
            DataSet wlogpersonlogdata = this.GetData(wlogpersonlog, pageparams, out totalCount);
            return base.GetJson(wlogpersonlogdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存wlogpersonlogdata数据集数据
        /// </summary>
        /// <param name="wlogpersonlogdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveWLOGPersonLog(WLOGPersonLogData wlogpersonlogdata)
        {
            #region
            WLOGPersonLogClass wlogpersonlogclass = new WLOGPersonLogClass();
            return base.Save(wlogpersonlogdata, wlogpersonlogclass);
            #endregion
        }
                
        /// <summary>
        /// 添加WLOGPersonLog表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="wlogpersonlogdata">数据集对象</param>
        /// <param name="wlogpersonlog">实体对象</param>
        public void AddRow(ref WLOGPersonLogData wlogpersonlogdata, EntityWLOGPersonLog wlogpersonlog)
        {
            #region
            DataRow dr = wlogpersonlogdata.Tables[0].NewRow();
            wlogpersonlog.logId = this._wlogpersonlogclass.GetMaxAddOne(wlogpersonlogdata).ToString();
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.missionId, wlogpersonlog.missionId);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.logId, wlogpersonlog.logId);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.writeUser, wlogpersonlog.writeUser);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.projectItem, wlogpersonlog.projectItem);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.logContent, wlogpersonlog.logContent);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.logDate, wlogpersonlog.logDate);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.isMission, wlogpersonlog.isMission);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.workState, wlogpersonlog.workState);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.workResult, wlogpersonlog.workResult);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.submited, wlogpersonlog.submited);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.deleted, wlogpersonlog.deleted);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.deleteTime, wlogpersonlog.deleteTime);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.usable, wlogpersonlog.usable);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.writeTime, DateTime.Now.ToString());
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.writeIp, wlogpersonlog.writeIp);
            wlogpersonlogdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑wlogpersonlogdata数据集中指定的行数据
        /// </summary>
        /// <param name="wlogpersonlogdata">数据集对象</param>
        /// <param name="wlogpersonlog">实体对象</param>
        public void EditRow(ref WLOGPersonLogData wlogpersonlogdata, EntityWLOGPersonLog wlogpersonlog)
        {
            #region
            if (wlogpersonlogdata.Tables[0].Rows.Count <= 0)
                wlogpersonlogdata = this.getData(wlogpersonlog.logId);
            DataRow dr = wlogpersonlogdata.Tables[0].Rows.Find(new object[1] {wlogpersonlog.logId});
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.missionId, wlogpersonlog.missionId);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.logId, wlogpersonlog.logId);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.writeUser, wlogpersonlog.writeUser);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.projectItem, wlogpersonlog.projectItem);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.logContent, wlogpersonlog.logContent);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.logDate, wlogpersonlog.logDate);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.isMission, wlogpersonlog.isMission);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.workState, wlogpersonlog.workState);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.workResult, wlogpersonlog.workResult);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.submited, wlogpersonlog.submited);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.deleted, wlogpersonlog.deleted);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.deleteTime, wlogpersonlog.deleteTime);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.usable, wlogpersonlog.usable);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.writeTime, wlogpersonlog.writeTime);
            wlogpersonlogdata.Assign(dr, WLOGPersonLogData.writeIp, wlogpersonlog.writeIp);
            #endregion
        }
        		
        /// <summary>
        /// 删除wlogpersonlogdata数据集中指定的行数据
        /// </summary>
        /// <param name="wlogpersonlogdata">数据集对象</param>
        /// <param name="logId">主键-日志流水号</param>
        public void DeleteRow(ref WLOGPersonLogData wlogpersonlogdata,string logId)
        {
            #region
            if (wlogpersonlogdata.Tables[0].Rows.Count <= 0)
                wlogpersonlogdata = this.getData(logId);
            DataRow dr = wlogpersonlogdata.Tables[0].Rows.Find(new object[1] { logId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取WLOGPersonLog数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            WLOGPersonLogData wlogpersonlogdata = this.getData(null);
            totalCount = wlogpersonlogdata.Tables[0].Rows.Count;
            return base.GetJson(wlogpersonlogdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityWLOGPersonLog wlogpersonlog)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(wlogpersonlog, queryparams, out totalcount);
            
            ExportExcelPersonLog exportexcel = new ExportExcelPersonLog(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="logId">主键-日志流水号</param>
        /// <returns></returns>
        private WLOGPersonLogData getData(string logId)
        {
            #region
            WLOGPersonLogData wlogpersonLogData = new WLOGPersonLogData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(WLOGPersonLogData.logId, EnumSqlType.sqlint, EnumCondition.Equal, logId);
            this._wlogpersonlogclass.GetSingleTAllWithoutCount(wlogpersonLogData, querybusinessparams);
            return wlogpersonLogData;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有WLOGPersonLog指定页码的数据（分页型）
        /// </summary>
        /// <param name="wlogpersonlog">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public WLOGPersonLogData GetData(EntityWLOGPersonLog wlogpersonlog, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(WLOGPersonLogData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, wlogpersonlog.writeUser);
            querybusinessparams.Add(WLOGPersonLogData.logContent, EnumSqlType.nvarchar, 
                EnumCondition.LikeBoth, wlogpersonlog.logContent);
            querybusinessparams.Add(WLOGPersonLogData.logDate, EnumSqlType.datetime,
                EnumCondition.Equal, wlogpersonlog.logDate);
            querybusinessparams.Add(WLOGPersonLogData.workState, EnumSqlType.tinyint, 
                EnumCondition.Equal, wlogpersonlog.workState);
            querybusinessparams.Add(WLOGPersonLogData.workResult, EnumSqlType.nvarchar, 
                EnumCondition.LikeBoth, wlogpersonlog.workResult);
            querybusinessparams.Add(WLOGPersonLogData.submited, EnumSqlType.bit, 
                EnumCondition.Equal, wlogpersonlog.submited);
            querybusinessparams.Add(WLOGPersonLogData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, wlogpersonlog.usable);
            WLOGPersonLogData wlogpersonlogdata = new WLOGPersonLogData();
            totalCount = this._wlogpersonlogclass.GetSingleT(wlogpersonlogdata, querybusinessparams);
            return wlogpersonlogdata;
            #endregion
        }
        #endregion

        #endregion
        public bool FindUserCurrentDayLog(EntityWLOGPersonLog wlogpersonlog, ref string json)
        {
            #region
            PageParams pageparams = new PageParams();
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(WLOGPersonLogData.writeUser, EnumSqlType.sqlint, EnumCondition.Equal, wlogpersonlog.writeUser);
            querybusinessparams.Add(WLOGPersonLogData.logDate, EnumSqlType.datetime, EnumCondition.Equal, wlogpersonlog.logDate);
            WLOGPersonLogData personlog = new WLOGPersonLogData();
            this._wlogpersonlogclass.GetSingleT(personlog, querybusinessparams);
            JsonHelper jsonhlp = new JsonHelper();
            if (personlog.Tables[0].Rows.Count > 0)
            {
                jsonhlp.AddObjectToJson("msg", "请注意：每人每天只限一篇日志！");
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldLogsId"></param>
        /// <param name="newLogsId"></param>
        /// <param name="missionId"></param>
        /// <returns></returns>
        public string UpdatePersonLogMissionId(string oldLogsId, string newLogsId, string missionId)
        {
            #region
            PageParams pageparams = new PageParams();
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Or(WLOGPersonLogData.logId, EnumSqlType.sqlint, EnumCondition.InValues, oldLogsId);
            querybusinessparams.Or(WLOGPersonLogData.logId, EnumSqlType.sqlint, EnumCondition.InValues, newLogsId);
            WLOGPersonLogData personlogdata = new WLOGPersonLogData();
            this._wlogpersonlogclass.GetSingleT(personlogdata, querybusinessparams);

            string[] oldlogid = oldLogsId.Split(',');
            string[] newlogid = newLogsId.Split(',');
            DataRow dr;
            for (int i = 0; i < oldlogid.Length; i++)
            {
                if (oldlogid[i] != "")
                {
                    dr = personlogdata.Tables[0].Rows.Find(oldlogid[i]);
                    personlogdata.Assign(dr, WLOGPersonLogData.missionId, "");
                }
            }
            for (int i = 0; i < newlogid.Length; i++)
            {
                if (newlogid[i] != "")
                {
                    dr = personlogdata.Tables[0].Rows.Find(newlogid[i]);
                    personlogdata.Assign(dr, WLOGPersonLogData.missionId, missionId);
                }
            }

            return this.SaveWLOGPersonLog(personlogdata);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="personlog"></param>
        /// <param name="isAddMissionIdNull"></param>
        /// <returns></returns>
        public string GetPersonLogByMissionId(EntityWLOGPersonLog personlog, SceneMission scene)
        {
            #region
            PageParams pageparams = new PageParams();
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(WLOGPersonLogData.writeUser, 
                EnumSqlType.sqlint, EnumCondition.Equal, personlog.writeUser);
            querybusinessparams.Add(WLOGPersonLogData.isMission,
                EnumSqlType.bit, EnumCondition.Equal, true);

            switch (scene)
            {
                case SceneMission.ViewPersonlogs:
                    querybusinessparams.Add(WLOGPersonLogData.missionId, 
                        EnumSqlType.sqlint, EnumCondition.Equal, personlog.missionId);
                    break;
                case SceneMission.AddMission:
                    querybusinessparams.Add(WLOGPersonLogData.missionId, 
                        EnumSqlType.sqlint, EnumCondition.EmptyIsNull, "");
                    break;
                case SceneMission.EditMission:
                    querybusinessparams.Or(WLOGPersonLogData.missionId, 
                        EnumSqlType.sqlint, EnumCondition.EmptyIsNull, "");
                    querybusinessparams.Add(WLOGPersonLogData.missionId, 
                        EnumSqlType.sqlint, EnumCondition.Equal, personlog.missionId);
                    querybusinessparams.Add(WLOGPersonLogData.writeUser, 
                        EnumSqlType.sqlint, EnumCondition.Equal, personlog.writeUser);
                    querybusinessparams.Add(WLOGPersonLogData.isMission,
                        EnumSqlType.bit, EnumCondition.Equal, true);

                    break;
                default:
                    break;
            }


            int totalCount = 0;
            WLOGPersonLogData wlogpersonlogdata = new WLOGPersonLogData();
            this._wlogpersonlogclass.GetSingleT(wlogpersonlogdata, querybusinessparams);
            totalCount = wlogpersonlogdata.Tables[0].Rows.Count;
            return base.GetJson(wlogpersonlogdata, totalCount);

            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="personlog"></param>
        /// <returns></returns>
        public string GetPersonLogsIdByMissionId(EntityWLOGPersonLog personlog)
        {
            #region
            PageParams pageparams = new PageParams();
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(WLOGPersonLogData.writeUser, EnumSqlType.sqlint, EnumCondition.Equal, personlog.writeUser);
            querybusinessparams.Add(WLOGPersonLogData.missionId, EnumSqlType.sqlint, EnumCondition.Equal, personlog.missionId);
            WLOGPersonLogData wlogpersonlogdata = new WLOGPersonLogData();
            this._wlogpersonlogclass.GetSingleT(wlogpersonlogdata, querybusinessparams);
            JsonHelper jsonhlp = new JsonHelper();
            string logsid = "";
            DataRowCollection drcollect = wlogpersonlogdata.Tables[0].Rows;
            for (int i = 0; i < drcollect.Count; i++)
            { 
                string temp = drcollect[i][WLOGPersonLogData.logId].ToString();
                if(i != drcollect.Count-1)
                    temp += ',';
                logsid += temp;
            }
            jsonhlp.AddObjectToJson("logsid", logsid);
            jsonhlp.SetResult(true);
            return jsonhlp.ToString();
            #endregion
        }

        public string GetLogsTimes(EntityLogsTimes logstimes)
        {
            #region
            PageParams pageparams = new PageParams();
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(WLOGPersonLogData.writeUser, EnumSqlType.sqlint,
                EnumCondition.InValues, logstimes.writeUser);
            DataSet logstimesdata = this._wlogpersonlogclass.SelectLogsTimes(querybusinessparams,
                logstimes.startDate, logstimes.endDate);
            int totalCount = logstimesdata.Tables[0].Rows.Count;
            return base.GetJson(logstimesdata, totalCount);
            #endregion
        }

    }
}


