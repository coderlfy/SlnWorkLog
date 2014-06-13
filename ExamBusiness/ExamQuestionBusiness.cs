/****************************************
***创建人：bhlfy
***创建时间：2013-10-27 08:26:06
***公司：山西博华科技有限公司
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
    public class ExamQuestionBusiness : GeneralBusinesser
    {
        private ExamQuestionClass _examquestionclass = new ExamQuestionClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V2.0.0.32008
        ***生成时间：2013-10-27 08:26:06
        ***公司：山西博华科技有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        
        /// <summary>
        /// 根据条件筛选所有ExamQuestion指定页码的数据（分页型）
        /// </summary>
        /// <param name="examquestion">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamQuestion examquestion, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examquestiondata = this.GetData(examquestion, pageparams, out totalCount);
            return base.GetJson(examquestiondata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examquestiondata数据集数据
        /// </summary>
        /// <param name="examquestiondata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamQuestion(ExamQuestionData examquestiondata)
        {
            #region
            return base.Save(examquestiondata, this._examquestionclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamQuestion表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examquestiondata">数据集对象</param>
        /// <param name="examquestion">实体对象</param>
        public void AddRow(ref ExamQuestionData examquestiondata, EntityExamQuestion examquestion)
        {
            #region
            DataRow dr = examquestiondata.Tables[0].NewRow();
            examquestiondata.Assign(dr, ExamQuestionData.questionId, examquestion.questionId);
            examquestiondata.Assign(dr, ExamQuestionData.questionTypeId, examquestion.questionTypeId);
            examquestiondata.Assign(dr, ExamQuestionData.questionScopeId, examquestion.questionScopeId);
            examquestiondata.Assign(dr, ExamQuestionData.questionName, examquestion.questionName);
            examquestiondata.Assign(dr, ExamQuestionData.usable, examquestion.usable);
            examquestiondata.Assign(dr, ExamQuestionData.sort, examquestion.sort);
            examquestiondata.Assign(dr, ExamQuestionData.writeUser, examquestion.writeUser);
            examquestiondata.Assign(dr, ExamQuestionData.writeIp, examquestion.writeIp);
            examquestiondata.Assign(dr, ExamQuestionData.writeTime, examquestion.writeTime);
            examquestiondata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examquestiondata数据集中指定的行数据
        /// </summary>
        /// <param name="examquestiondata">数据集对象</param>
        /// <param name="examquestion">实体对象</param>
        public void EditRow(ref ExamQuestionData examquestiondata, EntityExamQuestion examquestion)
        {
            #region
            if (examquestiondata.Tables[0].Rows.Count <= 0)
                examquestiondata = this.getData(examquestion.questionId);
            DataRow dr = examquestiondata.Tables[0].Rows.Find(new object[1] {examquestion.questionId});
            examquestiondata.Assign(dr, ExamQuestionData.questionId, examquestion.questionId);
            examquestiondata.Assign(dr, ExamQuestionData.questionTypeId, examquestion.questionTypeId);
            examquestiondata.Assign(dr, ExamQuestionData.questionScopeId, examquestion.questionScopeId);
            examquestiondata.Assign(dr, ExamQuestionData.questionName, examquestion.questionName);
            examquestiondata.Assign(dr, ExamQuestionData.usable, examquestion.usable);
            examquestiondata.Assign(dr, ExamQuestionData.sort, examquestion.sort);
            examquestiondata.Assign(dr, ExamQuestionData.writeUser, examquestion.writeUser);
            examquestiondata.Assign(dr, ExamQuestionData.writeIp, examquestion.writeIp);
            examquestiondata.Assign(dr, ExamQuestionData.writeTime, examquestion.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examquestiondata数据集中指定的行数据
        /// </summary>
        /// <param name="examquestiondata">数据集对象</param>
        /// <param name="questionId">主键-问题编号</param>
        public void DeleteRow(ref ExamQuestionData examquestiondata,string questionId)
        {
            #region
            if (examquestiondata.Tables[0].Rows.Count <= 0)
                examquestiondata = this.getData(questionId);
            DataRow dr = examquestiondata.Tables[0].Rows.Find(new object[1] { questionId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamQuestion数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamQuestionData examquestiondata = this.getData(null);
            totalCount = examquestiondata.Tables[0].Rows.Count;
            return base.GetJson(examquestiondata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="questionId">主键-问题编号</param>
        /// <returns></returns>
        private ExamQuestionData getData(string questionId)
        {
            #region
            ExamQuestionData examquestiondata = new ExamQuestionData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamQuestionData.questionId, EnumSqlType.sqlint, EnumCondition.Equal, questionId);
            this._examquestionclass.GetSingleTAllWithoutCount(examquestiondata, querybusinessparams);   
            return examquestiondata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamQuestion指定页码的数据（分页型）
        /// </summary>
        /// <param name="examquestion">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamQuestionData GetData(EntityExamQuestion examquestion, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamQuestionData.questionId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examquestion.questionId);
            querybusinessparams.Add(ExamQuestionData.questionTypeId, EnumSqlType.tinyint, 
                EnumCondition.Equal, examquestion.questionTypeId);
            querybusinessparams.Add(ExamQuestionData.questionScopeId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examquestion.questionScopeId);
            querybusinessparams.Add(ExamQuestionData.questionName, EnumSqlType.nvarchar, 
                EnumCondition.LikeBoth, examquestion.questionName);
            querybusinessparams.Add(ExamQuestionData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, examquestion.usable);
            querybusinessparams.Add(ExamQuestionData.sort, EnumSqlType.tinyint, 
                EnumCondition.Equal, examquestion.sort);
            querybusinessparams.Add(ExamQuestionData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examquestion.writeUser);
            querybusinessparams.Add(ExamQuestionData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examquestion.writeIp);
            querybusinessparams.Add(ExamQuestionData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examquestion.writeTime);
            ExamQuestionData examquestiondata = new ExamQuestionData();
            totalCount = this._examquestionclass.GetSingleT(examquestiondata, querybusinessparams);
            return examquestiondata;
            #endregion
        }
        #endregion

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="examquestiondata"></param>
        /// <param name="entityQuestion"></param>
        /// <param name="examAnswerestimateData"></param>
        /// <param name="entityAnswer"></param>
        public void AddEstimateQuestion(ref ExamQuestionData examquestiondata
            , EntityExamQuestion entityQuestion,ref ExamAnswerEstimateData examAnswerestimateData
            , EntityExamAnswerEstimate entityAnswer)
        {
            #region
            entityQuestion.questionId = this._examquestionclass.GetMaxAddOne(examquestiondata).ToString();
            ExamAnswerEstimateClass answerestimateclass = new ExamAnswerEstimateClass();
            ExamAnswerEstimateBusiness answerestimatebusiness = new ExamAnswerEstimateBusiness();

            entityAnswer.answerId = answerestimateclass.GetMaxAddOne(examAnswerestimateData).ToString();
            entityAnswer.questionId = entityQuestion.questionId;

            this.AddRow(ref examquestiondata, entityQuestion);
            answerestimatebusiness.AddRow(ref examAnswerestimateData, entityAnswer);

            this.SaveExamQuestion(examquestiondata);
            answerestimateclass.SaveSingleT(examAnswerestimateData);

            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="examquestiondata"></param>
        /// <param name="entityQuestion"></param>
        /// <param name="examAnswerestimateData"></param>
        /// <param name="entityAnswer"></param>
        public void EditEstimateQuestion(ref ExamQuestionData examquestiondata
            , ref ExamAnswerEstimateData examAnswerestimateData)
        {
            #region
            ExamAnswerEstimateClass answerestimateclass = new ExamAnswerEstimateClass();
            this.SaveExamQuestion(examquestiondata);
            answerestimateclass.SaveSingleT(examAnswerestimateData);

            #endregion
        }
    }
}


