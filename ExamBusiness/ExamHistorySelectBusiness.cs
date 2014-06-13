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
    public class ExamHistorySelectBusiness : GeneralBusinesser
    {
        private ExamHistorySelectClass _examhistoryselectclass = new ExamHistorySelectClass();
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
        /// 根据条件筛选所有ExamHistorySelect指定页码的数据（分页型）
        /// </summary>
        /// <param name="examhistoryselect">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamHistorySelect examhistoryselect, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examhistoryselectdata = this.GetData(examhistoryselect, pageparams, out totalCount);
            return base.GetJson(examhistoryselectdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examhistoryselectdata数据集数据
        /// </summary>
        /// <param name="examhistoryselectdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamHistorySelect(ExamHistorySelectData examhistoryselectdata)
        {
            #region
            return base.Save(examhistoryselectdata, this._examhistoryselectclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamHistorySelect表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examhistoryselectdata">数据集对象</param>
        /// <param name="examhistoryselect">实体对象</param>
        public void AddRow(ref ExamHistorySelectData examhistoryselectdata, EntityExamHistorySelect examhistoryselect)
        {
            #region
            DataRow dr = examhistoryselectdata.Tables[0].NewRow();
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.answerHistoryId, examhistoryselect.answerHistoryId);
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.examHistoryId, examhistoryselect.examHistoryId);
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.questionId, examhistoryselect.questionId);
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.writeUser, examhistoryselect.writeUser);
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.writeIp, examhistoryselect.writeIp);
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.writeTime, examhistoryselect.writeTime);
            examhistoryselectdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examhistoryselectdata数据集中指定的行数据
        /// </summary>
        /// <param name="examhistoryselectdata">数据集对象</param>
        /// <param name="examhistoryselect">实体对象</param>
        public void EditRow(ref ExamHistorySelectData examhistoryselectdata, EntityExamHistorySelect examhistoryselect)
        {
            #region
            if (examhistoryselectdata.Tables[0].Rows.Count <= 0)
                examhistoryselectdata = this.getData(examhistoryselect.answerHistoryId);
            DataRow dr = examhistoryselectdata.Tables[0].Rows.Find(new object[1] {examhistoryselect.answerHistoryId});
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.answerHistoryId, examhistoryselect.answerHistoryId);
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.examHistoryId, examhistoryselect.examHistoryId);
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.questionId, examhistoryselect.questionId);
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.writeUser, examhistoryselect.writeUser);
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.writeIp, examhistoryselect.writeIp);
            examhistoryselectdata.Assign(dr, ExamHistorySelectData.writeTime, examhistoryselect.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examhistoryselectdata数据集中指定的行数据
        /// </summary>
        /// <param name="examhistoryselectdata">数据集对象</param>
        /// <param name="answerHistoryId">主键-选择题答题编号</param>
        public void DeleteRow(ref ExamHistorySelectData examhistoryselectdata,string answerHistoryId)
        {
            #region
            if (examhistoryselectdata.Tables[0].Rows.Count <= 0)
                examhistoryselectdata = this.getData(answerHistoryId);
            DataRow dr = examhistoryselectdata.Tables[0].Rows.Find(new object[1] { answerHistoryId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamHistorySelect数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamHistorySelectData examhistoryselectdata = this.getData(null);
            totalCount = examhistoryselectdata.Tables[0].Rows.Count;
            return base.GetJson(examhistoryselectdata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="answerHistoryId">主键-选择题答题编号</param>
        /// <returns></returns>
        private ExamHistorySelectData getData(string answerHistoryId)
        {
            #region
            ExamHistorySelectData examhistoryselectdata = new ExamHistorySelectData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamHistorySelectData.answerHistoryId, EnumSqlType.sqlint, EnumCondition.Equal, answerHistoryId);
            this._examhistoryselectclass.GetSingleTAllWithoutCount(examhistoryselectdata, querybusinessparams);   
            return examhistoryselectdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamHistorySelect指定页码的数据（分页型）
        /// </summary>
        /// <param name="examhistoryselect">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamHistorySelectData GetData(EntityExamHistorySelect examhistoryselect, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamHistorySelectData.answerHistoryId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryselect.answerHistoryId);
            querybusinessparams.Add(ExamHistorySelectData.examHistoryId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryselect.examHistoryId);
            querybusinessparams.Add(ExamHistorySelectData.questionId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryselect.questionId);
            querybusinessparams.Add(ExamHistorySelectData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryselect.writeUser);
            querybusinessparams.Add(ExamHistorySelectData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examhistoryselect.writeIp);
            querybusinessparams.Add(ExamHistorySelectData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examhistoryselect.writeTime);
            ExamHistorySelectData examhistoryselectdata = new ExamHistorySelectData();
            totalCount = this._examhistoryselectclass.GetSingleT(examhistoryselectdata, querybusinessparams);
            return examhistoryselectdata;
            #endregion
        }
        #endregion

        #endregion
    }
}


