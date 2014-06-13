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
    public class ExamHistoryEssayBusiness : GeneralBusinesser
    {
        private ExamHistoryEssayClass _examhistoryessayclass = new ExamHistoryEssayClass();
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
        /// 根据条件筛选所有ExamHistoryEssay指定页码的数据（分页型）
        /// </summary>
        /// <param name="examhistoryessay">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamHistoryEssay examhistoryessay, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examhistoryessaydata = this.GetData(examhistoryessay, pageparams, out totalCount);
            return base.GetJson(examhistoryessaydata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examhistoryessaydata数据集数据
        /// </summary>
        /// <param name="examhistoryessaydata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamHistoryEssay(ExamHistoryEssayData examhistoryessaydata)
        {
            #region
            return base.Save(examhistoryessaydata, this._examhistoryessayclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamHistoryEssay表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examhistoryessaydata">数据集对象</param>
        /// <param name="examhistoryessay">实体对象</param>
        public void AddRow(ref ExamHistoryEssayData examhistoryessaydata, EntityExamHistoryEssay examhistoryessay)
        {
            #region
            DataRow dr = examhistoryessaydata.Tables[0].NewRow();
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.answerHistoryId, examhistoryessay.answerHistoryId);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.questionId, examhistoryessay.questionId);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.writeUser, examhistoryessay.writeUser);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.examHistoryId, examhistoryessay.examHistoryId);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.answer, examhistoryessay.answer);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.score, examhistoryessay.score);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.remark, examhistoryessay.remark);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.writeIp, examhistoryessay.writeIp);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.writeTime, examhistoryessay.writeTime);
            examhistoryessaydata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examhistoryessaydata数据集中指定的行数据
        /// </summary>
        /// <param name="examhistoryessaydata">数据集对象</param>
        /// <param name="examhistoryessay">实体对象</param>
        public void EditRow(ref ExamHistoryEssayData examhistoryessaydata, EntityExamHistoryEssay examhistoryessay)
        {
            #region
            if (examhistoryessaydata.Tables[0].Rows.Count <= 0)
                examhistoryessaydata = this.getData(examhistoryessay.answerHistoryId);
            DataRow dr = examhistoryessaydata.Tables[0].Rows.Find(new object[1] {examhistoryessay.answerHistoryId});
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.answerHistoryId, examhistoryessay.answerHistoryId);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.questionId, examhistoryessay.questionId);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.writeUser, examhistoryessay.writeUser);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.examHistoryId, examhistoryessay.examHistoryId);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.answer, examhistoryessay.answer);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.score, examhistoryessay.score);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.remark, examhistoryessay.remark);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.writeIp, examhistoryessay.writeIp);
            examhistoryessaydata.Assign(dr, ExamHistoryEssayData.writeTime, examhistoryessay.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examhistoryessaydata数据集中指定的行数据
        /// </summary>
        /// <param name="examhistoryessaydata">数据集对象</param>
        /// <param name="answerHistoryId">主键-问答题答题流水号</param>
        public void DeleteRow(ref ExamHistoryEssayData examhistoryessaydata,string answerHistoryId)
        {
            #region
            if (examhistoryessaydata.Tables[0].Rows.Count <= 0)
                examhistoryessaydata = this.getData(answerHistoryId);
            DataRow dr = examhistoryessaydata.Tables[0].Rows.Find(new object[1] { answerHistoryId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamHistoryEssay数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamHistoryEssayData examhistoryessaydata = this.getData(null);
            totalCount = examhistoryessaydata.Tables[0].Rows.Count;
            return base.GetJson(examhistoryessaydata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="answerHistoryId">主键-问答题答题流水号</param>
        /// <returns></returns>
        private ExamHistoryEssayData getData(string answerHistoryId)
        {
            #region
            ExamHistoryEssayData examhistoryessaydata = new ExamHistoryEssayData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamHistoryEssayData.answerHistoryId, EnumSqlType.sqlint, EnumCondition.Equal, answerHistoryId);
            this._examhistoryessayclass.GetSingleTAllWithoutCount(examhistoryessaydata, querybusinessparams);   
            return examhistoryessaydata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamHistoryEssay指定页码的数据（分页型）
        /// </summary>
        /// <param name="examhistoryessay">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamHistoryEssayData GetData(EntityExamHistoryEssay examhistoryessay, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamHistoryEssayData.answerHistoryId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryessay.answerHistoryId);
            querybusinessparams.Add(ExamHistoryEssayData.questionId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryessay.questionId);
            querybusinessparams.Add(ExamHistoryEssayData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryessay.writeUser);
            querybusinessparams.Add(ExamHistoryEssayData.examHistoryId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryessay.examHistoryId);
            querybusinessparams.Add(ExamHistoryEssayData.answer, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examhistoryessay.answer);
            querybusinessparams.Add(ExamHistoryEssayData.score, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryessay.score);
            querybusinessparams.Add(ExamHistoryEssayData.remark, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examhistoryessay.remark);
            querybusinessparams.Add(ExamHistoryEssayData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examhistoryessay.writeIp);
            querybusinessparams.Add(ExamHistoryEssayData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examhistoryessay.writeTime);
            ExamHistoryEssayData examhistoryessaydata = new ExamHistoryEssayData();
            totalCount = this._examhistoryessayclass.GetSingleT(examhistoryessaydata, querybusinessparams);
            return examhistoryessaydata;
            #endregion
        }
        #endregion

        #endregion
    }
}


