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
    public class WLOGWeekSummaryData : DataLibBase
    {
        
        /// <summary>
        /// 周总结流水号。
        /// </summary>
        public const string summaryId = "summaryId";
        /// <summary>
        /// 用户编号。
        /// </summary>
        public const string writeUser = "writeUser";
        /// <summary>
        /// 周编号。
        /// </summary>
        public const string weekBH = "weekBH";
        /// <summary>
        /// 开始日期。
        /// </summary>
        public const string startDate = "startDate";
        /// <summary>
        /// 结束日期。
        /// </summary>
        public const string endDate = "endDate";
        /// <summary>
        /// 是否提交。
        /// </summary>
        public const string submited = "submited";
        /// <summary>
        /// 提交时刻。
        /// </summary>
        public const string submitTime = "submitTime";
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
        public const string WLOGWeekSummary = "WLOGWeekSummary";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(WLOGWeekSummary);
            
            dt.Columns.Add(summaryId, typeof(System.Int32));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(weekBH, typeof(System.String));
            dt.Columns.Add(startDate, typeof(System.DateTime));
            dt.Columns.Add(endDate, typeof(System.DateTime));
            dt.Columns.Add(submited, typeof(System.Boolean));
            dt.Columns.Add(submitTime, typeof(System.DateTime));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[summaryId] };
            dt.TableName = WLOGWeekSummary;
            this.Tables.Add(dt);
            this.DataSetName = "TWLOGWeekSummary";
        }

        public WLOGWeekSummaryData()
        {
            this.BuildData();
        }
    }
}
#endregion

