#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhlfy
***生成时间：2013-05-04 20:32:25
***公司：山西博华科技有限公司
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
    public class WLOGPersonLogData : DataLibBase
    {
        
        /// <summary>
        /// 任务项流水号。
        /// </summary>
        public const string missionId = "missionId";
        /// <summary>
        /// 日志流水号。
        /// </summary>
        public const string logId = "logId";
        /// <summary>
        /// 录入人编号。
        /// </summary>
        public const string writeUser = "writeUser";
        /// <summary>
        /// 当前项目节点编号。
        /// </summary>
        public const string projectItem = "projectItem";
        /// <summary>
        /// 日志内容。
        /// </summary>
        public const string logContent = "logContent";
        /// <summary>
        /// 当天日期。
        /// </summary>
        public const string logDate = "logDate";
        /// <summary>
        /// 工作完成状态。
        /// </summary>
        public const string workState = "workState";
        /// <summary>
        /// 是否为任务项内工作日。
        /// </summary>
        public const string isMission = "isMission";
        /// <summary>
        /// 工作成果。
        /// </summary>
        public const string workResult = "workResult";
        /// <summary>
        /// 是否提交。
        /// </summary>
        public const string submited = "submited";
        /// <summary>
        /// 是否删除。
        /// </summary>
        public const string deleted = "deleted";
        /// <summary>
        /// 删除时刻。
        /// </summary>
        public const string deleteTime = "deleteTime";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
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
        public const string WLOGPersonLog = "WLOGPersonLog";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(WLOGPersonLog);
            
            dt.Columns.Add(missionId, typeof(System.Int32));
            dt.Columns.Add(logId, typeof(System.Int32));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(projectItem, typeof(System.Int32));
            dt.Columns.Add(logContent, typeof(System.String));
            dt.Columns.Add(logDate, typeof(System.DateTime));
            dt.Columns.Add(workState, typeof(System.Byte));
            dt.Columns.Add(isMission, typeof(System.Boolean));
            dt.Columns.Add(workResult, typeof(System.String));
            dt.Columns.Add(submited, typeof(System.Boolean));
            dt.Columns.Add(deleted, typeof(System.Boolean));
            dt.Columns.Add(deleteTime, typeof(System.DateTime));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[logId] };
            dt.TableName = WLOGPersonLog;
            this.Tables.Add(dt);
            this.DataSetName = "TWLOGPersonLog";
        }

        public WLOGPersonLogData()
        {
            this.BuildData();
        }
    }
}
#endregion

