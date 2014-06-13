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
    public class ExamPaperTemplateData : DataLibBase
    {
        
        /// <summary>
        /// 考卷模版编号。
        /// </summary>
        public const string examTemplateId = "examTemplateId";
        /// <summary>
        /// 考卷模版名称。
        /// </summary>
        public const string examTemplateName = "examTemplateName";
        /// <summary>
        /// 是否随机生成。
        /// </summary>
        public const string isRandomGen = "isRandomGen";
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
        public const string ExamPaperTemplate = "ExamPaperTemplate";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(ExamPaperTemplate);
            
            dt.Columns.Add(examTemplateId, typeof(System.Int32));
            dt.Columns.Add(examTemplateName, typeof(System.String));
            dt.Columns.Add(isRandomGen, typeof(System.Boolean));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(remark, typeof(System.String));
            dt.Columns.Add(sort, typeof(System.Byte));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[examTemplateId] };
            dt.TableName = ExamPaperTemplate;
            this.Tables.Add(dt);
            this.DataSetName = "TExamPaperTemplate";
        }

        public ExamPaperTemplateData()
        {
            this.BuildData();
        }
    }
}
#endregion

