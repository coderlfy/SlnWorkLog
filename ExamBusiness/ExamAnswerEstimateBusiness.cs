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
    public class ExamAnswerEstimateBusiness : GeneralBusinesser
    {
        private ExamAnswerEstimateClass _examanswerestimateclass = new ExamAnswerEstimateClass();
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
        /// 根据条件筛选所有ExamAnswerEstimate指定页码的数据（分页型）
        /// </summary>
        /// <param name="examanswerestimate">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamAnswerEstimate examanswerestimate, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examanswerestimatedata = this.GetData(examanswerestimate, pageparams, out totalCount);
            return base.GetJson(examanswerestimatedata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examanswerestimatedata数据集数据
        /// </summary>
        /// <param name="examanswerestimatedata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamAnswerEstimate(ExamAnswerEstimateData examanswerestimatedata)
        {
            #region
            return base.Save(examanswerestimatedata, this._examanswerestimateclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamAnswerEstimate表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examanswerestimatedata">数据集对象</param>
        /// <param name="examanswerestimate">实体对象</param>
        public void AddRow(ref ExamAnswerEstimateData examanswerestimatedata, EntityExamAnswerEstimate examanswerestimate)
        {
            #region
            DataRow dr = examanswerestimatedata.Tables[0].NewRow();
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.answerId, examanswerestimate.answerId);
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.questionId, examanswerestimate.questionId);
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.answer, examanswerestimate.answer);
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.writeUser, examanswerestimate.writeUser);
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.writeIp, examanswerestimate.writeIp);
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.writeTime, examanswerestimate.writeTime);
            examanswerestimatedata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examanswerestimatedata数据集中指定的行数据
        /// </summary>
        /// <param name="examanswerestimatedata">数据集对象</param>
        /// <param name="examanswerestimate">实体对象</param>
        public void EditRow(ref ExamAnswerEstimateData examanswerestimatedata, EntityExamAnswerEstimate examanswerestimate)
        {
            #region
            if (examanswerestimatedata.Tables[0].Rows.Count <= 0)
                examanswerestimatedata = this.GetData(examanswerestimate.answerId);
            DataRow dr = examanswerestimatedata.Tables[0].Rows.Find(new object[1] {examanswerestimate.answerId});
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.answerId, examanswerestimate.answerId);
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.questionId, examanswerestimate.questionId);
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.answer, examanswerestimate.answer);
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.writeUser, examanswerestimate.writeUser);
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.writeIp, examanswerestimate.writeIp);
            examanswerestimatedata.Assign(dr, ExamAnswerEstimateData.writeTime, examanswerestimate.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examanswerestimatedata数据集中指定的行数据
        /// </summary>
        /// <param name="examanswerestimatedata">数据集对象</param>
        /// <param name="answerId">主键-判断题答案编号</param>
        public void DeleteRow(ref ExamAnswerEstimateData examanswerestimatedata,string answerId)
        {
            #region
            if (examanswerestimatedata.Tables[0].Rows.Count <= 0)
                examanswerestimatedata = this.GetData(answerId);
            DataRow dr = examanswerestimatedata.Tables[0].Rows.Find(new object[1] { answerId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamAnswerEstimate数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamAnswerEstimateData examanswerestimatedata = this.GetData(null);
            totalCount = examanswerestimatedata.Tables[0].Rows.Count;
            return base.GetJson(examanswerestimatedata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="answerId">主键-判断题答案编号</param>
        /// <returns></returns>
        public ExamAnswerEstimateData GetData(string answerId)
        {
            #region
            ExamAnswerEstimateData examanswerestimatedata = new ExamAnswerEstimateData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamAnswerEstimateData.answerId, EnumSqlType.sqlint, EnumCondition.Equal, answerId);
            this._examanswerestimateclass.GetSingleTAllWithoutCount(examanswerestimatedata, querybusinessparams);   
            return examanswerestimatedata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamAnswerEstimate指定页码的数据（分页型）
        /// </summary>
        /// <param name="examanswerestimate">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamAnswerEstimateData GetData(EntityExamAnswerEstimate examanswerestimate, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamAnswerEstimateData.answerId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examanswerestimate.answerId);
            querybusinessparams.Add(ExamAnswerEstimateData.questionId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examanswerestimate.questionId);
            querybusinessparams.Add(ExamAnswerEstimateData.answer, EnumSqlType.bit, 
                EnumCondition.Equal, examanswerestimate.answer);
            querybusinessparams.Add(ExamAnswerEstimateData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examanswerestimate.writeUser);
            querybusinessparams.Add(ExamAnswerEstimateData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examanswerestimate.writeIp);
            querybusinessparams.Add(ExamAnswerEstimateData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examanswerestimate.writeTime);
            ExamAnswerEstimateData examanswerestimatedata = new ExamAnswerEstimateData();
            totalCount = this._examanswerestimateclass.GetSingleT(examanswerestimatedata, querybusinessparams);
            return examanswerestimatedata;
            #endregion
        }
        #endregion

        #endregion
    }
}


