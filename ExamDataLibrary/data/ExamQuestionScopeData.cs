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
    public class ExamQuestionScopeData : DataLibBase
    {
        
        /// <summary>
        /// 问题领域编号。
        /// </summary>
        public const string questionScopeId = "questionScopeId";
        /// <summary>
        /// 父级编号。
        /// </summary>
        public const string parent_ID = "parent_ID";
        /// <summary>
        /// 问题领域名称。
        /// </summary>
        public const string questionScopeName = "questionScopeName";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 备注。
        /// </summary>
        public const string remark = "remark";
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
        public const string ExamQuestionScope = "ExamQuestionScope";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(ExamQuestionScope);
            
            dt.Columns.Add(questionScopeId, typeof(System.Int32));
            dt.Columns.Add(parent_ID, typeof(System.Int32));
            dt.Columns.Add(questionScopeName, typeof(System.String));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(remark, typeof(System.String));
            dt.Columns.Add(sort, typeof(System.Byte));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[questionScopeId] };
            dt.TableName = ExamQuestionScope;
            this.Tables.Add(dt);
            this.DataSetName = "TExamQuestionScope";
        }

        public ExamQuestionScopeData()
        {
            this.BuildData();
        }
    }
}
#endregion

