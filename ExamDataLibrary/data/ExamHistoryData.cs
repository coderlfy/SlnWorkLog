#region Create by iCat Assist Tools
/****************************************
***生成器版本：V2.0.0.32008
***创建人：bhlfy
***生成时间：2013-10-27 08:26:12
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
            
namespace ExamDataLibrary
{
    public class ExamHistoryData : DataLibBase
    {
        
        /// <summary>
        /// 考试成绩单编号。
        /// </summary>
        public const string examHistoryId = "examHistoryId";
        /// <summary>
        /// 考卷编号。
        /// </summary>
        public const string examPaperId = "examPaperId";
        /// <summary>
        /// 评分人评语。
        /// </summary>
        public const string giveScoreRemark = "giveScoreRemark";
        /// <summary>
        /// 评分人。
        /// </summary>
        public const string giveScoreUser = "giveScoreUser";
        /// <summary>
        /// 评卷时间。
        /// </summary>
        public const string giveScoreTime = "giveScoreTime";
        /// <summary>
        /// 答题人。
        /// </summary>
        public const string writeUser = "writeUser";
        /// <summary>
        /// 答题提交时间。
        /// </summary>
        public const string examSubmitTime = "examSubmitTime";
        /// <summary>
        /// 录入人IP地址。
        /// </summary>
        public const string writeIp = "writeIp";
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public const string writeTime = "writeTime";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string ExamHistory = "ExamHistory";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(ExamHistory);
            
            dt.Columns.Add(examHistoryId, typeof(System.Int32));
            dt.Columns.Add(examPaperId, typeof(System.Int32));
            dt.Columns.Add(giveScoreRemark, typeof(System.String));
            dt.Columns.Add(giveScoreUser, typeof(System.Int32));
            dt.Columns.Add(giveScoreTime, typeof(System.DateTime));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(examSubmitTime, typeof(System.DateTime));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[examHistoryId] };
            dt.TableName = ExamHistory;
            this.Tables.Add(dt);
            this.DataSetName = "TExamHistory";
        }

        public ExamHistoryData()
        {
            this.BuildData();
        }
    }
}
#endregion

