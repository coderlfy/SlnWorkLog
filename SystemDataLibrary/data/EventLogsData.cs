#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.28380
***创建人：bhlfy
***生成时间：2013-04-06 17:01:07
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
            
namespace SystemDataLibrary
{
    public class EventLogsData : DataLibBase
    {
        
        /// <summary>
        /// 事件编号。
        /// </summary>
        public const string eventId = "eventId";
        /// <summary>
        /// 用户编号。
        /// </summary>
        public const string userid = "userid";
        /// <summary>
        /// 录入人IP地址。
        /// </summary>
        public const string writeIp = "writeIp";
        /// <summary>
        /// 事件类型。
        /// </summary>
        public const string eventType = "eventType";
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public const string writeTime = "writeTime";
        /// <summary>
        /// 事件内容。
        /// </summary>
        public const string Content = "Content";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string EventLogs = "EventLogs";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(EventLogs);
            
            dt.Columns.Add(eventId, typeof(System.Int32));
            dt.Columns.Add(userid, typeof(System.Int32));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(eventType, typeof(System.Int32));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.Columns.Add(Content, typeof(System.Object));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[eventId] };
            dt.TableName = EventLogs;
            this.Tables.Add(dt);
            this.DataSetName = "TEventLogs";
        }

        public EventLogsData()
        {
            this.BuildData();
        }
    }
}
#endregion

