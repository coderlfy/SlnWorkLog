#region Create by iCat Assist Tools
/****************************************
***生成器版本：V2.0.0.32008
***创建人：bhlfy
***生成时间：2013-10-27 08:26:12
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
            
namespace ExamDataLibrary
{
    public class ExamQuestionData : DataLibBase
    {
        
        /// <summary>
        /// 问题编号。
        /// </summary>
        public const string questionId = "questionId";
        /// <summary>
        /// 问题类型（选择题、判断题、问答题）。
        /// </summary>
        public const string questionTypeId = "questionTypeId";
        /// <summary>
        /// 问题领域编号。
        /// </summary>
        public const string questionScopeId = "questionScopeId";
        /// <summary>
        /// 问题标题。
        /// </summary>
        public const string questionName = "questionName";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 排序号。
        /// </summary>
        public const string sort = "sort";
        /// <summary>
        /// 录入人。
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
        public const string ExamQuestion = "ExamQuestion";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(ExamQuestion);
            
            dt.Columns.Add(questionId, typeof(System.Int32));
            dt.Columns.Add(questionTypeId, typeof(System.Byte));
            dt.Columns.Add(questionScopeId, typeof(System.Int32));
            dt.Columns.Add(questionName, typeof(System.String));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(sort, typeof(System.Byte));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[questionId] };
            dt.TableName = ExamQuestion;
            this.Tables.Add(dt);
            this.DataSetName = "TExamQuestion";
        }

        public ExamQuestionData()
        {
            this.BuildData();
        }
    }
}
#endregion

