/****************************************
***创建人：bhlfy
***创建时间：2013-04-26 18:05:16
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
    public class WLOGMissionBusiness : GeneralBusinesser
    {
        private WLOGMissionClass _wlogmissionclass = new WLOGMissionClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-26 18:05:16
        ***公司：山西ICat Studio有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods

        /// <summary>
        /// 根据条件筛选所有WLOGMission指定页码的数据（分页型）
        /// </summary>
        /// <param name="wlogmission">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityWLOGMission wlogmission, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            WLOGMissionClass wlogmissionclass = new WLOGMissionClass();
            pageparams.PageSorts.Add(new PageSort(WLOGMissionData.writeTime, EnumSQLOrderBY.DESC));
            DataSet wlogmissiondata = this.GetData(wlogmission, pageparams, out totalCount);
            return base.GetJson(wlogmissiondata, totalCount);
            #endregion
        }

        /// <summary>
        /// 保存wlogmissiondata数据集数据
        /// </summary>
        /// <param name="wlogmissiondata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveWLOGMission(WLOGMissionData wlogmissiondata)
        {
            #region
            WLOGMissionClass wlogmissionclass = new WLOGMissionClass();
            return base.Save(wlogmissiondata, this._wlogmissionclass);
            #endregion
        }

        /// <summary>
        /// 添加WLOGMission表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="wlogmissiondata">数据集对象</param>
        /// <param name="wlogmission">实体对象</param>
        public void AddRow(ref WLOGMissionData wlogmissiondata, EntityWLOGMission wlogmission)
        {
            #region
            DataRow dr = wlogmissiondata.Tables[0].NewRow();
            wlogmission.missionId = this._wlogmissionclass.GetMaxAddOne(wlogmissiondata).ToString();
            wlogmissiondata.Assign(dr, WLOGMissionData.missionId, wlogmission.missionId);
            wlogmissiondata.Assign(dr, WLOGMissionData.summaryId, wlogmission.summaryId);
            wlogmissiondata.Assign(dr, WLOGMissionData.writeUser, wlogmission.writeUser);
            wlogmissiondata.Assign(dr, WLOGMissionData.projectId, wlogmission.projectId);
            wlogmissiondata.Assign(dr, WLOGMissionData.missionBH, wlogmission.missionBH);
            wlogmissiondata.Assign(dr, WLOGMissionData.missionName, wlogmission.missionName);
            wlogmissiondata.Assign(dr, WLOGMissionData.missionRemark, wlogmission.missionRemark);
            wlogmissiondata.Assign(dr, WLOGMissionData.planned, wlogmission.planned);
            wlogmissiondata.Assign(dr, WLOGMissionData.plantimelimit, wlogmission.plantimelimit);
            wlogmissiondata.Assign(dr, WLOGMissionData.outputResult, wlogmission.outputResult);
            wlogmissiondata.Assign(dr, WLOGMissionData.startDate, wlogmission.startDate);
            wlogmissiondata.Assign(dr, WLOGMissionData.reviewState, wlogmission.reviewState);
            wlogmissiondata.Assign(dr, WLOGMissionData.missionState, wlogmission.missionState);
            wlogmissiondata.Assign(dr, WLOGMissionData.deleted, wlogmission.deleted);
            wlogmissiondata.Assign(dr, WLOGMissionData.usable, wlogmission.usable);
            wlogmissiondata.Assign(dr, WLOGMissionData.updated, wlogmission.updated);
            wlogmissiondata.Assign(dr, WLOGMissionData.deleteTime, wlogmission.deleteTime);
            wlogmissiondata.Assign(dr, WLOGMissionData.writeTime, wlogmission.writeTime);
            wlogmissiondata.Assign(dr, WLOGMissionData.writeIp, wlogmission.writeIp);
            wlogmissiondata.Tables[0].Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 编辑wlogmissiondata数据集中指定的行数据
        /// </summary>
        /// <param name="wlogmissiondata">数据集对象</param>
        /// <param name="wlogmission">实体对象</param>
        public void EditRow(ref WLOGMissionData wlogmissiondata, EntityWLOGMission wlogmission)
        {
            #region
            if (wlogmissiondata.Tables[0].Rows.Count <= 0)
                wlogmissiondata = this.getData(wlogmission.missionId);
            DataRow dr = wlogmissiondata.Tables[0].Rows.Find(new object[1] { wlogmission.missionId });
            wlogmissiondata.Assign(dr, WLOGMissionData.missionId, wlogmission.missionId);
            wlogmissiondata.Assign(dr, WLOGMissionData.summaryId, wlogmission.summaryId);
            wlogmissiondata.Assign(dr, WLOGMissionData.writeUser, wlogmission.writeUser);
            wlogmissiondata.Assign(dr, WLOGMissionData.projectId, wlogmission.projectId);
            wlogmissiondata.Assign(dr, WLOGMissionData.missionBH, wlogmission.missionBH);
            wlogmissiondata.Assign(dr, WLOGMissionData.missionName, wlogmission.missionName);
            wlogmissiondata.Assign(dr, WLOGMissionData.missionRemark, wlogmission.missionRemark);
            wlogmissiondata.Assign(dr, WLOGMissionData.planned, wlogmission.planned);
            wlogmissiondata.Assign(dr, WLOGMissionData.plantimelimit, wlogmission.plantimelimit);
            wlogmissiondata.Assign(dr, WLOGMissionData.outputResult, wlogmission.outputResult);
            wlogmissiondata.Assign(dr, WLOGMissionData.startDate, wlogmission.startDate);
            wlogmissiondata.Assign(dr, WLOGMissionData.reviewState, wlogmission.reviewState);
            wlogmissiondata.Assign(dr, WLOGMissionData.missionState, wlogmission.missionState);
            wlogmissiondata.Assign(dr, WLOGMissionData.deleted, wlogmission.deleted);
            wlogmissiondata.Assign(dr, WLOGMissionData.usable, wlogmission.usable);
            wlogmissiondata.Assign(dr, WLOGMissionData.updated, wlogmission.updated);
            wlogmissiondata.Assign(dr, WLOGMissionData.deleteTime, wlogmission.deleteTime);
            wlogmissiondata.Assign(dr, WLOGMissionData.writeTime, wlogmission.writeTime);
            wlogmissiondata.Assign(dr, WLOGMissionData.writeIp, wlogmission.writeIp);
            #endregion
        }



        /// <summary>
        /// 删除wlogmissiondata数据集中指定的行数据
        /// </summary>
        /// <param name="wlogmissiondata">数据集对象</param>
        /// <param name="missionId">主键-任务项流水号</param>
        public void DeleteRow(ref WLOGMissionData wlogmissiondata, string missionId)
        {
            #region
            if (wlogmissiondata.Tables[0].Rows.Count <= 0)
                wlogmissiondata = this.getData(missionId);
            DataRow dr = wlogmissiondata.Tables[0].Rows.Find(new object[1] { missionId });
            if (dr != null)
                dr.Delete();
            #endregion
        }

        /// <summary>
        /// 获取WLOGMission数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            WLOGMissionData wlogmissiondata = this.getData(null);
            totalCount = wlogmissiondata.Tables[0].Rows.Count;
            return base.GetJson(wlogmissiondata, totalCount);
            #endregion
        }

        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityWLOGMission wlogmission)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(wlogmission, queryparams, out totalcount);

            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="missionId">主键-任务项流水号</param>
        /// <returns></returns>
        private WLOGMissionData getData(string missionId)
        {
            #region
            WLOGMissionData wlogmissiondata = new WLOGMissionData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(WLOGMissionData.missionId, EnumSqlType.sqlint, EnumCondition.Equal, missionId);
            this._wlogmissionclass.GetSingleTAllWithoutCount(wlogmissiondata, querybusinessparams);
            return wlogmissiondata;
            #endregion
        }

        /// <summary>
        /// 根据条件筛选所有WLOGMission指定页码的数据（分页型）
        /// </summary>
        /// <param name="wlogmission">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityWLOGMission wlogmission, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(WLOGMissionData.writeUser, EnumSqlType.sqlint,
                EnumCondition.Equal, wlogmission.writeUser);
            querybusinessparams.Add(WLOGMissionData.missionBH, EnumSqlType.nvarchar,
                EnumCondition.LikeRight, wlogmission.missionBH);
            querybusinessparams.Add(WLOGMissionData.missionName, EnumSqlType.nvarchar,
                EnumCondition.LikeBoth, wlogmission.missionName);
            querybusinessparams.Add(WLOGMissionData.planned, EnumSqlType.bit,
                EnumCondition.Equal, wlogmission.planned);
            querybusinessparams.Add(WLOGMissionData.reviewState, EnumSqlType.bit,
                EnumCondition.Equal, wlogmission.reviewState);
            querybusinessparams.Add(WLOGMissionData.missionState, EnumSqlType.tinyint,
                EnumCondition.Equal, wlogmission.missionState);
            querybusinessparams.Add(WLOGMissionData.usable, EnumSqlType.bit,
                EnumCondition.Equal, wlogmission.usable);
            WLOGMissionData wlogmissiondata = new WLOGMissionData();
            totalCount = this._wlogmissionclass.SelectWLOGMissionByPage(wlogmissiondata, querybusinessparams);
            return wlogmissiondata;
            #endregion
        }
        #endregion

        #endregion

        public string UpdateMissionSummaryId(string oldMisssionsId, string newMissionsId, string summaryId)
        {
            #region
            int totalCount = 0;
            PageParams pageparams = new PageParams();
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Or(WLOGMissionData.missionId, EnumSqlType.sqlint, EnumCondition.InValues, oldMisssionsId);
            querybusinessparams.Or(WLOGMissionData.missionId, EnumSqlType.sqlint, EnumCondition.InValues, newMissionsId);
            WLOGMissionData missiondata = new WLOGMissionData();
            totalCount = this._wlogmissionclass.GetSingleT(missiondata, querybusinessparams);

            string[] oldmissionid = oldMisssionsId.Split(',');
            string[] newmissionid = newMissionsId.Split(',');
            DataRow dr;
            for (int i = 0; i < oldmissionid.Length; i++)
            {
                if (oldmissionid[i] != "")
                {
                    dr = missiondata.Tables[0].Rows.Find(oldmissionid[i]);
                    missiondata.Assign(dr, WLOGMissionData.summaryId, "");
                }
            }
            for (int i = 0; i < newmissionid.Length; i++)
            {
                if (newmissionid[i] != "")
                {
                    dr = missiondata.Tables[0].Rows.Find(newmissionid[i]);
                    missiondata.Assign(dr, WLOGMissionData.summaryId, summaryId);
                }
            }

            return this.SaveWLOGMission(missiondata);
            #endregion
        }

        public string GetAllocMissions()
        {
            #region
            int totalCount = 0;
            WLOGMissionClass wlogmissionclass = new WLOGMissionClass();
            DataSet wlogmissiondata = wlogmissionclass.SelectAllocMissions(null);
            totalCount = wlogmissiondata.Tables[0].Rows.Count;
            return base.GetJson(wlogmissiondata, totalCount);
            #endregion
        }


        public string GetMissionBySummaryId(EntityWLOGMission mission, SceneWeekSummary scene)
        {
            #region
            WLOGMissionClass wlogmissionclass = new WLOGMissionClass();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(WLOGMissionData.writeUser, EnumSqlType.sqlint, EnumCondition.Equal, mission.writeUser);
            switch (scene)
            {
                case SceneWeekSummary.ViewMissions:
                    querybusinessparams.Or(WLOGMissionData.summaryId,
                        EnumSqlType.sqlint, EnumCondition.Equal, mission.summaryId);
                    break;
                case SceneWeekSummary.AddWeekSummary:
                    querybusinessparams.Or(WLOGMissionData.summaryId,
                        EnumSqlType.sqlint, EnumCondition.EmptyIsNull, "");
                    break;
                case SceneWeekSummary.EditWeekSummary:
                    querybusinessparams.Or(WLOGMissionData.summaryId,
                        EnumSqlType.sqlint, EnumCondition.EmptyIsNull, "");
                    querybusinessparams.Add(WLOGMissionData.summaryId,
                        EnumSqlType.sqlint, EnumCondition.Equal, mission.summaryId);
                    querybusinessparams.Add(WLOGMissionData.writeUser,
                        EnumSqlType.sqlint, EnumCondition.Equal, mission.writeUser);
                    break;
                default:
                    break;
            }
            int totalCount = 0;
            WLOGMissionData missiondata = new WLOGMissionData();
            totalCount = this._wlogmissionclass.GetSingleT(missiondata, querybusinessparams);
            return base.GetJson(missiondata, totalCount);

            #endregion
        }

        public string GetMissionsIdBySummaryId(EntityWLOGMission mission)
        {
            #region
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(WLOGMissionData.writeUser, EnumSqlType.sqlint, EnumCondition.Equal, mission.writeUser);
            querybusinessparams.Add(WLOGMissionData.summaryId, EnumSqlType.sqlint, EnumCondition.Equal, mission.summaryId);
            WLOGMissionData missiondata = new WLOGMissionData();
            this._wlogmissionclass.GetSingleT(missiondata, querybusinessparams);

            JsonHelper jsonhlp = new JsonHelper();
            string missionsid = "";
            DataRowCollection drcollect = missiondata.Tables[0].Rows;
            for (int i = 0; i < drcollect.Count; i++)
            {
                string temp = drcollect[i][WLOGMissionData.missionId].ToString();
                if (i != drcollect.Count - 1)
                    temp += ',';
                missionsid += temp;
            }
            jsonhlp.AddObjectToJson("missionId", missionsid);
            jsonhlp.SetResult(true);
            return jsonhlp.ToString();
            #endregion
        }

        public string GetWorkTotal(EntityMissionReport missionReport)
        {
            #region
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ApplicationUserData.userid, EnumSqlType.sqlint,
                EnumCondition.InValues, missionReport.writeUser);
            querybusinessparams.Add(ApplicationUserData.isTotal, EnumSqlType.bit,
                EnumCondition.Equal, true);
            DataSet wlogmissiondata = this._wlogmissionclass.SelectWorktotal(querybusinessparams,
                missionReport.startDate, missionReport.endDate, missionReport.missionState, missionReport.reviewState);
            int totalCount = wlogmissiondata.Tables[0].Rows.Count;
            return base.GetJson(wlogmissiondata, totalCount);
            #endregion
        }
    }
}
