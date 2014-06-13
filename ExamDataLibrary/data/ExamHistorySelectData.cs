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
    public class ExamHistorySelectData : DataLibBase
    {
        
        /// <summary>
        /// 选择题答题编号。
        /// </summary>
        public const string answerHistoryId = "answerHistoryId";
        /// <summary>
        /// 成绩单编号。
        /// </summary>
        public const string examHistoryId = "examHistoryId";
        /// <summary>
        /// 问题编号。
        /// </summary>
        public const string questionId = "questionId";
        /// <summary>
        /// 答题人。
        /// </summary>
        public const string writeUser = "writeUser";
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
        public const string ExamHistorySelect = "ExamHistorySelect";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(ExamHistorySelect);
            
            dt.Columns.Add(answerHistoryId, typeof(System.Int32));
            dt.Columns.Add(examHistoryId, typeof(System.Int32));
            dt.Columns.Add(questionId, typeof(System.Int32));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[answerHistoryId] };
            dt.TableName = ExamHistorySelect;
            this.Tables.Add(dt);
            this.DataSetName = "TExamHistorySelect";
        }

        public ExamHistorySelectData()
        {
            this.BuildData();
        }
    }
}
#endregion

