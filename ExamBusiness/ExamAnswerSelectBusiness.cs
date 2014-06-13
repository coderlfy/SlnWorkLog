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
    public class ExamAnswerSelectBusiness : GeneralBusinesser
    {
        private ExamAnswerSelectClass _examanswerselectclass = new ExamAnswerSelectClass();
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
        /// 根据条件筛选所有ExamAnswerSelect指定页码的数据（分页型）
        /// </summary>
        /// <param name="examanswerselect">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamAnswerSelect examanswerselect, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examanswerselectdata = this.GetData(examanswerselect, pageparams, out totalCount);
            return base.GetJson(examanswerselectdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examanswerselectdata数据集数据
        /// </summary>
        /// <param name="examanswerselectdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamAnswerSelect(ExamAnswerSelectData examanswerselectdata)
        {
            #region
            return base.Save(examanswerselectdata, this._examanswerselectclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamAnswerSelect表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examanswerselectdata">数据集对象</param>
        /// <param name="examanswerselect">实体对象</param>
        public void AddRow(ref ExamAnswerSelectData examanswerselectdata, EntityExamAnswerSelect examanswerselect)
        {
            #region
            DataRow dr = examanswerselectdata.Tables[0].NewRow();
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.answerId, examanswerselect.answerId);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.questionId, examanswerselect.questionId);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.selectContent, examanswerselect.selectContent);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.answer, examanswerselect.answer);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.writeUser, examanswerselect.writeUser);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.writeIp, examanswerselect.writeIp);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.writeTime, examanswerselect.writeTime);
            examanswerselectdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examanswerselectdata数据集中指定的行数据
        /// </summary>
        /// <param name="examanswerselectdata">数据集对象</param>
        /// <param name="examanswerselect">实体对象</param>
        public void EditRow(ref ExamAnswerSelectData examanswerselectdata, EntityExamAnswerSelect examanswerselect)
        {
            #region
            if (examanswerselectdata.Tables[0].Rows.Count <= 0)
                examanswerselectdata = this.getData(examanswerselect.answerId);
            DataRow dr = examanswerselectdata.Tables[0].Rows.Find(new object[1] {examanswerselect.answerId});
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.answerId, examanswerselect.answerId);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.questionId, examanswerselect.questionId);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.selectContent, examanswerselect.selectContent);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.answer, examanswerselect.answer);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.writeUser, examanswerselect.writeUser);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.writeIp, examanswerselect.writeIp);
            examanswerselectdata.Assign(dr, ExamAnswerSelectData.writeTime, examanswerselect.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examanswerselectdata数据集中指定的行数据
        /// </summary>
        /// <param name="examanswerselectdata">数据集对象</param>
        /// <param name="answerId">主键-选择题答案编号</param>
        public void DeleteRow(ref ExamAnswerSelectData examanswerselectdata,string answerId)
        {
            #region
            if (examanswerselectdata.Tables[0].Rows.Count <= 0)
                examanswerselectdata = this.getData(answerId);
            DataRow dr = examanswerselectdata.Tables[0].Rows.Find(new object[1] { answerId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamAnswerSelect数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamAnswerSelectData examanswerselectdata = this.getData(null);
            totalCount = examanswerselectdata.Tables[0].Rows.Count;
            return base.GetJson(examanswerselectdata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="answerId">主键-选择题答案编号</param>
        /// <returns></returns>
        private ExamAnswerSelectData getData(string answerId)
        {
            #region
            ExamAnswerSelectData examanswerselectdata = new ExamAnswerSelectData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamAnswerSelectData.answerId, EnumSqlType.sqlint, EnumCondition.Equal, answerId);
            this._examanswerselectclass.GetSingleTAllWithoutCount(examanswerselectdata, querybusinessparams);   
            return examanswerselectdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamAnswerSelect指定页码的数据（分页型）
        /// </summary>
        /// <param name="examanswerselect">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamAnswerSelectData GetData(EntityExamAnswerSelect examanswerselect, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamAnswerSelectData.answerId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examanswerselect.answerId);
            querybusinessparams.Add(ExamAnswerSelectData.questionId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examanswerselect.questionId);
            querybusinessparams.Add(ExamAnswerSelectData.selectContent, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examanswerselect.selectContent);
            querybusinessparams.Add(ExamAnswerSelectData.answer, EnumSqlType.bit, 
                EnumCondition.Equal, examanswerselect.answer);
            querybusinessparams.Add(ExamAnswerSelectData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examanswerselect.writeUser);
            querybusinessparams.Add(ExamAnswerSelectData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examanswerselect.writeIp);
            querybusinessparams.Add(ExamAnswerSelectData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examanswerselect.writeTime);
            ExamAnswerSelectData examanswerselectdata = new ExamAnswerSelectData();
            totalCount = this._examanswerselectclass.GetSingleT(examanswerselectdata, querybusinessparams);
            return examanswerselectdata;
            #endregion
        }
        #endregion

        #endregion
    }
}


