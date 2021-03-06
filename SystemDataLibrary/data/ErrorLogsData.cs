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
    public class ErrorLogsData : DataLibBase
    {
        
        /// <summary>
        /// 错误日志编号。
        /// </summary>
        public const string errorId = "errorId";
        /// <summary>
        /// 用户编号。
        /// </summary>
        public const string userid = "userid";
        /// <summary>
        /// 录入人IP地址。
        /// </summary>
        public const string writeIp = "writeIp";
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public const string writeTime = "writeTime";
        /// <summary>
        /// 错误日志内容。
        /// </summary>
        public const string Content = "Content";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string ErrorLogs = "ErrorLogs";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(ErrorLogs);
            
            dt.Columns.Add(errorId, typeof(System.Int32));
            dt.Columns.Add(userid, typeof(System.Int32));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.Columns.Add(Content, typeof(System.Object));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[errorId] };
            dt.TableName = ErrorLogs;
            this.Tables.Add(dt);
            this.DataSetName = "TErrorLogs";
        }

        public ErrorLogsData()
        {
            this.BuildData();
        }
    }
}
#endregion

