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
    public class ExamHistoryEstimateBusiness : GeneralBusinesser
    {
        private ExamHistoryEstimateClass _examhistoryestimateclass = new ExamHistoryEstimateClass();
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
        /// 根据条件筛选所有ExamHistoryEstimate指定页码的数据（分页型）
        /// </summary>
        /// <param name="examhistoryestimate">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamHistoryEstimate examhistoryestimate, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examhistoryestimatedata = this.GetData(examhistoryestimate, pageparams, out totalCount);
            return base.GetJson(examhistoryestimatedata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examhistoryestimatedata数据集数据
        /// </summary>
        /// <param name="examhistoryestimatedata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamHistoryEstimate(ExamHistoryEstimateData examhistoryestimatedata)
        {
            #region
            return base.Save(examhistoryestimatedata, this._examhistoryestimateclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamHistoryEstimate表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examhistoryestimatedata">数据集对象</param>
        /// <param name="examhistoryestimate">实体对象</param>
        public void AddRow(ref ExamHistoryEstimateData examhistoryestimatedata, EntityExamHistoryEstimate examhistoryestimate)
        {
            #region
            DataRow dr = examhistoryestimatedata.Tables[0].NewRow();
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.answerHistoryId, examhistoryestimate.answerHistoryId);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.examHistoryId, examhistoryestimate.examHistoryId);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.questionId, examhistoryestimate.questionId);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.writeUser, examhistoryestimate.writeUser);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.answer, examhistoryestimate.answer);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.writeIp, examhistoryestimate.writeIp);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.writeTime, examhistoryestimate.writeTime);
            examhistoryestimatedata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examhistoryestimatedata数据集中指定的行数据
        /// </summary>
        /// <param name="examhistoryestimatedata">数据集对象</param>
        /// <param name="examhistoryestimate">实体对象</param>
        public void EditRow(ref ExamHistoryEstimateData examhistoryestimatedata, EntityExamHistoryEstimate examhistoryestimate)
        {
            #region
            if (examhistoryestimatedata.Tables[0].Rows.Count <= 0)
                examhistoryestimatedata = this.getData(examhistoryestimate.answerHistoryId);
            DataRow dr = examhistoryestimatedata.Tables[0].Rows.Find(new object[1] {examhistoryestimate.answerHistoryId});
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.answerHistoryId, examhistoryestimate.answerHistoryId);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.examHistoryId, examhistoryestimate.examHistoryId);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.questionId, examhistoryestimate.questionId);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.writeUser, examhistoryestimate.writeUser);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.answer, examhistoryestimate.answer);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.writeIp, examhistoryestimate.writeIp);
            examhistoryestimatedata.Assign(dr, ExamHistoryEstimateData.writeTime, examhistoryestimate.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examhistoryestimatedata数据集中指定的行数据
        /// </summary>
        /// <param name="examhistoryestimatedata">数据集对象</param>
        /// <param name="answerHistoryId">主键-判断题答题编号</param>
        public void DeleteRow(ref ExamHistoryEstimateData examhistoryestimatedata,string answerHistoryId)
        {
            #region
            if (examhistoryestimatedata.Tables[0].Rows.Count <= 0)
                examhistoryestimatedata = this.getData(answerHistoryId);
            DataRow dr = examhistoryestimatedata.Tables[0].Rows.Find(new object[1] { answerHistoryId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamHistoryEstimate数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamHistoryEstimateData examhistoryestimatedata = this.getData(null);
            totalCount = examhistoryestimatedata.Tables[0].Rows.Count;
            return base.GetJson(examhistoryestimatedata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="answerHistoryId">主键-判断题答题编号</param>
        /// <returns></returns>
        private ExamHistoryEstimateData getData(string answerHistoryId)
        {
            #region
            ExamHistoryEstimateData examhistoryestimatedata = new ExamHistoryEstimateData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamHistoryEstimateData.answerHistoryId, EnumSqlType.sqlint, EnumCondition.Equal, answerHistoryId);
            this._examhistoryestimateclass.GetSingleTAllWithoutCount(examhistoryestimatedata, querybusinessparams);   
            return examhistoryestimatedata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamHistoryEstimate指定页码的数据（分页型）
        /// </summary>
        /// <param name="examhistoryestimate">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamHistoryEstimateData GetData(EntityExamHistoryEstimate examhistoryestimate, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamHistoryEstimateData.answerHistoryId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryestimate.answerHistoryId);
            querybusinessparams.Add(ExamHistoryEstimateData.examHistoryId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryestimate.examHistoryId);
            querybusinessparams.Add(ExamHistoryEstimateData.questionId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryestimate.questionId);
            querybusinessparams.Add(ExamHistoryEstimateData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryestimate.writeUser);
            querybusinessparams.Add(ExamHistoryEstimateData.answer, EnumSqlType.bit, 
                EnumCondition.Equal, examhistoryestimate.answer);
            querybusinessparams.Add(ExamHistoryEstimateData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examhistoryestimate.writeIp);
            querybusinessparams.Add(ExamHistoryEstimateData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examhistoryestimate.writeTime);
            ExamHistoryEstimateData examhistoryestimatedata = new ExamHistoryEstimateData();
            totalCount = this._examhistoryestimateclass.GetSingleT(examhistoryestimatedata, querybusinessparams);
            return examhistoryestimatedata;
            #endregion
        }
        #endregion

        #endregion
    }
}


