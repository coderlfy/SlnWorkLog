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
    public class ExamAnswerEssayBusiness : GeneralBusinesser
    {
        private ExamAnswerEssayClass _examansweressayclass = new ExamAnswerEssayClass();
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
        /// 根据条件筛选所有ExamAnswerEssay指定页码的数据（分页型）
        /// </summary>
        /// <param name="examansweressay">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamAnswerEssay examansweressay, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examansweressaydata = this.GetData(examansweressay, pageparams, out totalCount);
            return base.GetJson(examansweressaydata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examansweressaydata数据集数据
        /// </summary>
        /// <param name="examansweressaydata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamAnswerEssay(ExamAnswerEssayData examansweressaydata)
        {
            #region
            return base.Save(examansweressaydata, this._examansweressayclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamAnswerEssay表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examansweressaydata">数据集对象</param>
        /// <param name="examansweressay">实体对象</param>
        public void AddRow(ref ExamAnswerEssayData examansweressaydata, EntityExamAnswerEssay examansweressay)
        {
            #region
            DataRow dr = examansweressaydata.Tables[0].NewRow();
            examansweressaydata.Assign(dr, ExamAnswerEssayData.answerId, examansweressay.answerId);
            examansweressaydata.Assign(dr, ExamAnswerEssayData.questionId, examansweressay.questionId);
            examansweressaydata.Assign(dr, ExamAnswerEssayData.answer, examansweressay.answer);
            examansweressaydata.Assign(dr, ExamAnswerEssayData.writeUser, examansweressay.writeUser);
            examansweressaydata.Assign(dr, ExamAnswerEssayData.writeIp, examansweressay.writeIp);
            examansweressaydata.Assign(dr, ExamAnswerEssayData.writeTime, examansweressay.writeTime);
            examansweressaydata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examansweressaydata数据集中指定的行数据
        /// </summary>
        /// <param name="examansweressaydata">数据集对象</param>
        /// <param name="examansweressay">实体对象</param>
        public void EditRow(ref ExamAnswerEssayData examansweressaydata, EntityExamAnswerEssay examansweressay)
        {
            #region
            if (examansweressaydata.Tables[0].Rows.Count <= 0)
                examansweressaydata = this.getData(examansweressay.answerId);
            DataRow dr = examansweressaydata.Tables[0].Rows.Find(new object[1] {examansweressay.answerId});
            examansweressaydata.Assign(dr, ExamAnswerEssayData.answerId, examansweressay.answerId);
            examansweressaydata.Assign(dr, ExamAnswerEssayData.questionId, examansweressay.questionId);
            examansweressaydata.Assign(dr, ExamAnswerEssayData.answer, examansweressay.answer);
            examansweressaydata.Assign(dr, ExamAnswerEssayData.writeUser, examansweressay.writeUser);
            examansweressaydata.Assign(dr, ExamAnswerEssayData.writeIp, examansweressay.writeIp);
            examansweressaydata.Assign(dr, ExamAnswerEssayData.writeTime, examansweressay.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examansweressaydata数据集中指定的行数据
        /// </summary>
        /// <param name="examansweressaydata">数据集对象</param>
        /// <param name="answerId">主键-问答题答案编号</param>
        public void DeleteRow(ref ExamAnswerEssayData examansweressaydata,string answerId)
        {
            #region
            if (examansweressaydata.Tables[0].Rows.Count <= 0)
                examansweressaydata = this.getData(answerId);
            DataRow dr = examansweressaydata.Tables[0].Rows.Find(new object[1] { answerId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamAnswerEssay数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamAnswerEssayData examansweressaydata = this.getData(null);
            totalCount = examansweressaydata.Tables[0].Rows.Count;
            return base.GetJson(examansweressaydata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="answerId">主键-问答题答案编号</param>
        /// <returns></returns>
        private ExamAnswerEssayData getData(string answerId)
        {
            #region
            ExamAnswerEssayData examansweressaydata = new ExamAnswerEssayData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamAnswerEssayData.answerId, EnumSqlType.sqlint, EnumCondition.Equal, answerId);
            this._examansweressayclass.GetSingleTAllWithoutCount(examansweressaydata, querybusinessparams);   
            return examansweressaydata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamAnswerEssay指定页码的数据（分页型）
        /// </summary>
        /// <param name="examansweressay">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamAnswerEssayData GetData(EntityExamAnswerEssay examansweressay, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamAnswerEssayData.answerId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examansweressay.answerId);
            querybusinessparams.Add(ExamAnswerEssayData.questionId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examansweressay.questionId);
            querybusinessparams.Add(ExamAnswerEssayData.answer, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examansweressay.answer);
            querybusinessparams.Add(ExamAnswerEssayData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examansweressay.writeUser);
            querybusinessparams.Add(ExamAnswerEssayData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examansweressay.writeIp);
            querybusinessparams.Add(ExamAnswerEssayData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examansweressay.writeTime);
            ExamAnswerEssayData examansweressaydata = new ExamAnswerEssayData();
            totalCount = this._examansweressayclass.GetSingleT(examansweressaydata, querybusinessparams);
            return examansweressaydata;
            #endregion
        }
        #endregion

        #endregion
    }
}


