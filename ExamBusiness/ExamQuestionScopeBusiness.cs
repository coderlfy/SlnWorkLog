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
    public class ExamQuestionScopeBusiness : GeneralBusinesser
    {
        private ExamQuestionScopeClass _examquestionscopeclass = new ExamQuestionScopeClass();
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
        /// 根据条件筛选所有ExamQuestionScope指定页码的数据（分页型）
        /// </summary>
        /// <param name="examquestionscope">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamQuestionScope examquestionscope, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examquestionscopedata = this.GetData(examquestionscope, pageparams, out totalCount);
            return base.GetJson(examquestionscopedata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examquestionscopedata数据集数据
        /// </summary>
        /// <param name="examquestionscopedata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamQuestionScope(ExamQuestionScopeData examquestionscopedata)
        {
            #region
            return base.Save(examquestionscopedata, this._examquestionscopeclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamQuestionScope表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examquestionscopedata">数据集对象</param>
        /// <param name="examquestionscope">实体对象</param>
        public void AddRow(ref ExamQuestionScopeData examquestionscopedata, EntityExamQuestionScope examquestionscope)
        {
            #region
            DataRow dr = examquestionscopedata.Tables[0].NewRow();
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.questionScopeId, examquestionscope.questionScopeId);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.parent_ID, examquestionscope.parent_ID);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.questionScopeName, examquestionscope.questionScopeName);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.usable, examquestionscope.usable);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.remark, examquestionscope.remark);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.sort, examquestionscope.sort);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.writeUser, examquestionscope.writeUser);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.writeIp, examquestionscope.writeIp);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.writeTime, examquestionscope.writeTime);
            examquestionscopedata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examquestionscopedata数据集中指定的行数据
        /// </summary>
        /// <param name="examquestionscopedata">数据集对象</param>
        /// <param name="examquestionscope">实体对象</param>
        public void EditRow(ref ExamQuestionScopeData examquestionscopedata, EntityExamQuestionScope examquestionscope)
        {
            #region
            if (examquestionscopedata.Tables[0].Rows.Count <= 0)
                examquestionscopedata = this.getData(examquestionscope.questionScopeId);
            DataRow dr = examquestionscopedata.Tables[0].Rows.Find(new object[1] {examquestionscope.questionScopeId});
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.questionScopeId, examquestionscope.questionScopeId);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.parent_ID, examquestionscope.parent_ID);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.questionScopeName, examquestionscope.questionScopeName);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.usable, examquestionscope.usable);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.remark, examquestionscope.remark);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.sort, examquestionscope.sort);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.writeUser, examquestionscope.writeUser);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.writeIp, examquestionscope.writeIp);
            examquestionscopedata.Assign(dr, ExamQuestionScopeData.writeTime, examquestionscope.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examquestionscopedata数据集中指定的行数据
        /// </summary>
        /// <param name="examquestionscopedata">数据集对象</param>
        /// <param name="questionScopeId">主键-问题领域编号</param>
        public void DeleteRow(ref ExamQuestionScopeData examquestionscopedata,string questionScopeId)
        {
            #region
            if (examquestionscopedata.Tables[0].Rows.Count <= 0)
                examquestionscopedata = this.getData(questionScopeId);
            DataRow dr = examquestionscopedata.Tables[0].Rows.Find(new object[1] { questionScopeId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamQuestionScope数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamQuestionScopeData examquestionscopedata = this.getData(null);
            totalCount = examquestionscopedata.Tables[0].Rows.Count;
            return base.GetJson(examquestionscopedata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="questionScopeId">主键-问题领域编号</param>
        /// <returns></returns>
        private ExamQuestionScopeData getData(string questionScopeId)
        {
            #region
            ExamQuestionScopeData examquestionscopedata = new ExamQuestionScopeData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamQuestionScopeData.questionScopeId, EnumSqlType.sqlint, EnumCondition.Equal, questionScopeId);
            this._examquestionscopeclass.GetSingleTAllWithoutCount(examquestionscopedata, querybusinessparams);   
            return examquestionscopedata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamQuestionScope指定页码的数据（分页型）
        /// </summary>
        /// <param name="examquestionscope">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamQuestionScopeData GetData(EntityExamQuestionScope examquestionscope, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamQuestionScopeData.questionScopeId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examquestionscope.questionScopeId);
            querybusinessparams.Add(ExamQuestionScopeData.parent_ID, EnumSqlType.sqlint, 
                EnumCondition.Equal, examquestionscope.parent_ID);
            querybusinessparams.Add(ExamQuestionScopeData.questionScopeName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examquestionscope.questionScopeName);
            querybusinessparams.Add(ExamQuestionScopeData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, examquestionscope.usable);
            querybusinessparams.Add(ExamQuestionScopeData.remark, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examquestionscope.remark);
            querybusinessparams.Add(ExamQuestionScopeData.sort, EnumSqlType.tinyint, 
                EnumCondition.Equal, examquestionscope.sort);
            querybusinessparams.Add(ExamQuestionScopeData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examquestionscope.writeUser);
            querybusinessparams.Add(ExamQuestionScopeData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examquestionscope.writeIp);
            querybusinessparams.Add(ExamQuestionScopeData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examquestionscope.writeTime);
            ExamQuestionScopeData examquestionscopedata = new ExamQuestionScopeData();
            totalCount = this._examquestionscopeclass.GetSingleT(examquestionscopedata, querybusinessparams);
            return examquestionscopedata;
            #endregion
        }
        #endregion

        #endregion
    }
}


