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
    public class ExamScoreRateData : DataLibBase
    {
        
        /// <summary>
        /// 考卷比例编号。
        /// </summary>
        public const string examScoreId = "examScoreId";
        /// <summary>
        /// 考卷模版编号。
        /// </summary>
        public const string examTemplateId = "examTemplateId";
        /// <summary>
        /// 问题类型。
        /// </summary>
        public const string questionTypeId = "questionTypeId";
        /// <summary>
        /// 比例值。
        /// </summary>
        public const string rate = "rate";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 用户编号。
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
        public const string ExamScoreRate = "ExamScoreRate";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(ExamScoreRate);
            
            dt.Columns.Add(examScoreId, typeof(System.Int32));
            dt.Columns.Add(examTemplateId, typeof(System.Int32));
            dt.Columns.Add(questionTypeId, typeof(System.Byte));
            dt.Columns.Add(rate, typeof(System.Decimal));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[examScoreId] };
            dt.TableName = ExamScoreRate;
            this.Tables.Add(dt);
            this.DataSetName = "TExamScoreRate";
        }

        public ExamScoreRateData()
        {
            this.BuildData();
        }
    }
}
#endregion

