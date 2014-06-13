#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhlfy
***生成时间：2013-05-04 20:32:25
***公司：山西ICat Studio有限公司
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Fundation.Core;
            
namespace WorkLogDataLibrary
{
    public class WLOGMissionData : DataLibBase
    {
        
        /// <summary>
        /// 任务项流水号。
        /// </summary>
        public const string missionId = "missionId";
        /// <summary>
        /// 周总结流水号。
        /// </summary>
        public const string summaryId = "summaryId";
        /// <summary>
        /// 用户编号。
        /// </summary>
        public const string writeUser = "writeUser";
        /// <summary>
        /// 项目节点ID。
        /// </summary>
        public const string projectId = "projectId";
        /// <summary>
        /// 任务编号。
        /// </summary>
        public const string missionBH = "missionBH";
        /// <summary>
        /// 任务描述。
        /// </summary>
        public const string missionName = "missionName";
        /// <summary>
        /// 备注。
        /// </summary>
        public const string missionRemark = "missionRemark";
        /// <summary>
        /// 是否在计划内。
        /// </summary>
        public const string planned = "planned";
        /// <summary>
        /// 计划工期。
        /// </summary>
        public const string plantimelimit = "plantimelimit";
        /// <summary>
        /// 任务输出。
        /// </summary>
        public const string outputResult = "outputResult";
        /// <summary>
        /// 任务开始日期。
        /// </summary>
        public const string startDate = "startDate";
        /// <summary>
        /// 审核状态。
        /// </summary>
        public const string reviewState = "reviewState";
        /// <summary>
        /// 任务状态。
        /// </summary>
        public const string missionState = "missionState";
        /// <summary>
        /// 是否删除。
        /// </summary>
        public const string deleted = "deleted";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 更新时刻。
        /// </summary>
        public const string updated = "updated";
        /// <summary>
        /// 删除时刻。
        /// </summary>
        public const string deleteTime = "deleteTime";
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public const string writeTime = "writeTime";
        /// <summary>
        /// 录入人IP地址。
        /// </summary>
        public const string writeIp = "writeIp";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string WLOGMission = "WLOGMission";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(WLOGMission);
            
            dt.Columns.Add(missionId, typeof(System.Int32));
            dt.Columns.Add(summaryId, typeof(System.Int32));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(projectId, typeof(System.Int32));
            dt.Columns.Add(missionBH, typeof(System.String));
            dt.Columns.Add(missionName, typeof(System.String));
            dt.Columns.Add(missionRemark, typeof(System.String));
            dt.Columns.Add(planned, typeof(System.Boolean));
            dt.Columns.Add(plantimelimit, typeof(System.Int32));
            dt.Columns.Add(outputResult, typeof(System.String));
            dt.Columns.Add(startDate, typeof(System.DateTime));
            dt.Columns.Add(reviewState, typeof(System.Boolean));
            dt.Columns.Add(missionState, typeof(System.Byte));
            dt.Columns.Add(deleted, typeof(System.Boolean));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(updated, typeof(System.DateTime));
            dt.Columns.Add(deleteTime, typeof(System.DateTime));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[missionId] };
            dt.TableName = WLOGMission;
            this.Tables.Add(dt);
            this.DataSetName = "TWLOGMission";
        }

        public WLOGMissionData()
        {
            this.BuildData();
        }
    }
}
#endregion

