/****************************************
***创建人：bhlfy
***创建时间：2013-04-24 18:44:01
***公司：山西博华科技有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WorkLogDataLibrary;
using Fundation.Core;
using BusinessBase;

namespace WorkLogSqlLibrary
{
    public class WLOGMissionClass : GeneralAccessor
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-24 18:44:01
        ***公司：山西博华科技有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照复制之用；
        ***         如需有其他业务要求，则可在region外添加新的业务关联方法；
        ***         如发现任何编译错误，请联系QQ：330669393。
        *****************************************/
        /// <summary>
        /// 检索数据并分页返回数据集
        /// </summary>
        /// <param name="recordCount">符合条件的总记录数</param>
        /// <param name="qParams">分页对象</param>
        /// <param name="conditions">查询条件集合</param>
        /// <returns>分页数据</returns>
        public int SelectWLOGMissionByPage(WLOGMissionData wlogmissiondata, DBConditions conditions)
        {
            #region
            string sqlformat = @"SELECT {0} FROM [WLOGMission] a 
                                         left join 
                                              (select count(logId) as personlogcount,missionid from dbo.WLOGPersonLog group by missionid) b 
                                                      on a.missionid = b.missionid";
            string businesssql = string.Format(sqlformat, "a.*, b.personlogcount");
            string countsql = string.Format(sqlformat, "count(*)");
            conditions.AddKeys(WLOGMissionData.missionId);
            return base.GetCustomBusiness(businesssql, countsql, wlogmissiondata, conditions);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="missionState"></param>
        /// <param name="reviewState"></param>
        /// <returns></returns>
        public DataSet SelectWorktotal(DBConditions conditions,
            string startDate, string endDate, string missionState,
            string reviewState)
        {
            #region
            DataSet worktotaldata = new DataSet();
            string[] innerconditions = new string[4] { "", "", "", "" };
            string businessSql = @"SELECT a.userid, a.fullName, a.isTotal, 
            isnull(c.missiondays, 0) as 计划内工作量, 
            isnull(b.missiondays, 0) as 计划外工作量, 
            isnull(b.missiondays, 0)+isnull(c.missiondays, 0) as 所有工作量 FROM [ApplicationUser] a
left join 
(
select a1.writeuser, sum(missionday) as missiondays from dbo.WLOGMission a1 left join 
(select missionid, count(*) as missionday from dbo.WLOGPersonLog group by missionid ) b1
on a1.missionid = b1.missionid where a1.planned = 0{0}{1}{2}{3} group by a1.writeuser) b 
on a.userid = b.writeuser 
left join 
(
select a1.writeuser, sum(plantimelimit) as missiondays from dbo.WLOGMission a1 
where a1.planned = 1{0}{1}{2}{3} group by a1.writeuser) c 
on a.userid = c.writeuser ";
            if (!string.IsNullOrEmpty(startDate))
                innerconditions[0] = " and (a1.startDate >= '" + startDate + "') ";
            if (!string.IsNullOrEmpty(endDate))
                innerconditions[1] = " and (a1.startDate <= '" + endDate + "') ";
            if (!string.IsNullOrEmpty(missionState))
                innerconditions[2] = " and (a1.missionState = '" + missionState + "') ";
            if (!string.IsNullOrEmpty(reviewState))
                innerconditions[3] = " and (a1.reviewState = " + ((reviewState.ToLower() == "true") ? "1" : "0") + ") ";

            businessSql = string.Format(businessSql, innerconditions);
            conditions.AddKeys(WLOGMissionData.missionId);

            base.GetWithoutPageBusiness(businessSql, worktotaldata, conditions);
            return worktotaldata;
            #endregion
        }

        public DataSet SelectAllocMissions(DBConditions conditions)
        {
            #region
            DataSet wlogmissiondata = new DataSet();
            string businessSql = @"SELECT missionId as id, missionName as text FROM [WLOGMission]";
            conditions.AddKeys(WLOGMissionData.missionId);
            base.GetCustomBusiness(businessSql, wlogmissiondata, conditions);
            return wlogmissiondata;
            #endregion
        }
        #endregion
    }
}


