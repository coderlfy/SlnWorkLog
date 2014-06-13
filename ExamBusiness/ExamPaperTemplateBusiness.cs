/****************************************
***创建人：bhlfy
***创建时间：2013-10-27 08:26:06
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using BusinessBase;
using Fundation.Core;
using System;
using System.Data;
using ExamDataLibrary;
using ExamSqlLibrary;

namespace ExamBusiness
{
    public class ExamPaperTemplateBusiness : GeneralBusinesser
    {
        private ExamPaperTemplateClass _exampapertemplateclass = new ExamPaperTemplateClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V2.0.0.32008
        ***生成时间：2013-10-27 08:26:06
        ***公司：山西ICat Studio有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        
        /// <summary>
        /// 根据条件筛选所有ExamPaperTemplate指定页码的数据（分页型）
        /// </summary>
        /// <param name="exampapertemplate">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamPaperTemplate exampapertemplate, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet exampapertemplatedata = this.GetData(exampapertemplate, pageparams, out totalCount);
            return base.GetJson(exampapertemplatedata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存exampapertemplatedata数据集数据
        /// </summary>
        /// <param name="exampapertemplatedata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamPaperTemplate(ExamPaperTemplateData exampapertemplatedata)
        {
            #region
            return base.Save(exampapertemplatedata, this._exampapertemplateclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamPaperTemplate表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="exampapertemplatedata">数据集对象</param>
        /// <param name="exampapertemplate">实体对象</param>
        public void AddRow(ref ExamPaperTemplateData exampapertemplatedata, EntityExamPaperTemplate exampapertemplate)
        {
            #region
            DataRow dr = exampapertemplatedata.Tables[0].NewRow();
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.examTemplateId, exampapertemplate.examTemplateId);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.examTemplateName, exampapertemplate.examTemplateName);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.isRandomGen, exampapertemplate.isRandomGen);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.usable, exampapertemplate.usable);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.remark, exampapertemplate.remark);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.sort, exampapertemplate.sort);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.writeUser, exampapertemplate.writeUser);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.writeIp, exampapertemplate.writeIp);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.writeTime, exampapertemplate.writeTime);
            exampapertemplatedata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑exampapertemplatedata数据集中指定的行数据
        /// </summary>
        /// <param name="exampapertemplatedata">数据集对象</param>
        /// <param name="exampapertemplate">实体对象</param>
        public void EditRow(ref ExamPaperTemplateData exampapertemplatedata, EntityExamPaperTemplate exampapertemplate)
        {
            #region
            if (exampapertemplatedata.Tables[0].Rows.Count <= 0)
                exampapertemplatedata = this.getData(exampapertemplate.examTemplateId);
            DataRow dr = exampapertemplatedata.Tables[0].Rows.Find(new object[1] {exampapertemplate.examTemplateId});
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.examTemplateId, exampapertemplate.examTemplateId);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.examTemplateName, exampapertemplate.examTemplateName);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.isRandomGen, exampapertemplate.isRandomGen);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.usable, exampapertemplate.usable);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.remark, exampapertemplate.remark);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.sort, exampapertemplate.sort);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.writeUser, exampapertemplate.writeUser);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.writeIp, exampapertemplate.writeIp);
            exampapertemplatedata.Assign(dr, ExamPaperTemplateData.writeTime, exampapertemplate.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除exampapertemplatedata数据集中指定的行数据
        /// </summary>
        /// <param name="exampapertemplatedata">数据集对象</param>
        /// <param name="examTemplateId">主键-考卷模版编号</param>
        public void DeleteRow(ref ExamPaperTemplateData exampapertemplatedata,string examTemplateId)
        {
            #region
            if (exampapertemplatedata.Tables[0].Rows.Count <= 0)
                exampapertemplatedata = this.getData(examTemplateId);
            DataRow dr = exampapertemplatedata.Tables[0].Rows.Find(new object[1] { examTemplateId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamPaperTemplate数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamPaperTemplateData exampapertemplatedata = this.getData(null);
            totalCount = exampapertemplatedata.Tables[0].Rows.Count;
            return base.GetJson(exampapertemplatedata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="examTemplateId">主键-考卷模版编号</param>
        /// <returns></returns>
        private ExamPaperTemplateData getData(string examTemplateId)
        {
            #region
            ExamPaperTemplateData exampapertemplatedata = new ExamPaperTemplateData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamPaperTemplateData.examTemplateId, EnumSqlType.sqlint, EnumCondition.Equal, examTemplateId);
            this._exampapertemplateclass.GetSingleTAllWithoutCount(exampapertemplatedata, querybusinessparams);   
            return exampapertemplatedata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamPaperTemplate指定页码的数据（分页型）
        /// </summary>
        /// <param name="exampapertemplate">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamPaperTemplateData GetData(EntityExamPaperTemplate exampapertemplate, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamPaperTemplateData.examTemplateId, EnumSqlType.sqlint, 
                EnumCondition.Equal, exampapertemplate.examTemplateId);
            querybusinessparams.Add(ExamPaperTemplateData.examTemplateName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, exampapertemplate.examTemplateName);
            querybusinessparams.Add(ExamPaperTemplateData.isRandomGen, EnumSqlType.bit, 
                EnumCondition.Equal, exampapertemplate.isRandomGen);
            querybusinessparams.Add(ExamPaperTemplateData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, exampapertemplate.usable);
            querybusinessparams.Add(ExamPaperTemplateData.remark, EnumSqlType.nvarchar, 
                EnumCondition.Equal, exampapertemplate.remark);
            querybusinessparams.Add(ExamPaperTemplateData.sort, EnumSqlType.tinyint, 
                EnumCondition.Equal, exampapertemplate.sort);
            querybusinessparams.Add(ExamPaperTemplateData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, exampapertemplate.writeUser);
            querybusinessparams.Add(ExamPaperTemplateData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, exampapertemplate.writeIp);
            querybusinessparams.Add(ExamPaperTemplateData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, exampapertemplate.writeTime);
            ExamPaperTemplateData exampapertemplatedata = new ExamPaperTemplateData();
            totalCount = this._exampapertemplateclass.GetSingleT(exampapertemplatedata, querybusinessparams);
            return exampapertemplatedata;
            #endregion
        }
        #endregion

        #endregion
    }
}


