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
    public class ExamHistoryScoreBusiness : GeneralBusinesser
    {
        private ExamHistoryScoreClass _examhistoryscoreclass = new ExamHistoryScoreClass();
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
        /// 根据条件筛选所有ExamHistoryScore指定页码的数据（分页型）
        /// </summary>
        /// <param name="examhistoryscore">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamHistoryScore examhistoryscore, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examhistoryscoredata = this.GetData(examhistoryscore, pageparams, out totalCount);
            return base.GetJson(examhistoryscoredata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examhistoryscoredata数据集数据
        /// </summary>
        /// <param name="examhistoryscoredata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamHistoryScore(ExamHistoryScoreData examhistoryscoredata)
        {
            #region
            return base.Save(examhistoryscoredata, this._examhistoryscoreclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamHistoryScore表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examhistoryscoredata">数据集对象</param>
        /// <param name="examhistoryscore">实体对象</param>
        public void AddRow(ref ExamHistoryScoreData examhistoryscoredata, EntityExamHistoryScore examhistoryscore)
        {
            #region
            DataRow dr = examhistoryscoredata.Tables[0].NewRow();
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.examHistoryFullScoreId, examhistoryscore.examHistoryFullScoreId);
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.examPaperId, examhistoryscore.examPaperId);
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.questionId, examhistoryscore.questionId);
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.fullScore, examhistoryscore.fullScore);
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.writeIp, examhistoryscore.writeIp);
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.writeTime, examhistoryscore.writeTime);
            examhistoryscoredata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examhistoryscoredata数据集中指定的行数据
        /// </summary>
        /// <param name="examhistoryscoredata">数据集对象</param>
        /// <param name="examhistoryscore">实体对象</param>
        public void EditRow(ref ExamHistoryScoreData examhistoryscoredata, EntityExamHistoryScore examhistoryscore)
        {
            #region
            if (examhistoryscoredata.Tables[0].Rows.Count <= 0)
                examhistoryscoredata = this.getData(examhistoryscore.examHistoryFullScoreId);
            DataRow dr = examhistoryscoredata.Tables[0].Rows.Find(new object[1] {examhistoryscore.examHistoryFullScoreId});
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.examHistoryFullScoreId, examhistoryscore.examHistoryFullScoreId);
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.examPaperId, examhistoryscore.examPaperId);
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.questionId, examhistoryscore.questionId);
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.fullScore, examhistoryscore.fullScore);
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.writeIp, examhistoryscore.writeIp);
            examhistoryscoredata.Assign(dr, ExamHistoryScoreData.writeTime, examhistoryscore.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examhistoryscoredata数据集中指定的行数据
        /// </summary>
        /// <param name="examhistoryscoredata">数据集对象</param>
        /// <param name="examHistoryFullScoreId">主键-考题历史分数编号</param>
        public void DeleteRow(ref ExamHistoryScoreData examhistoryscoredata,string examHistoryFullScoreId)
        {
            #region
            if (examhistoryscoredata.Tables[0].Rows.Count <= 0)
                examhistoryscoredata = this.getData(examHistoryFullScoreId);
            DataRow dr = examhistoryscoredata.Tables[0].Rows.Find(new object[1] { examHistoryFullScoreId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamHistoryScore数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamHistoryScoreData examhistoryscoredata = this.getData(null);
            totalCount = examhistoryscoredata.Tables[0].Rows.Count;
            return base.GetJson(examhistoryscoredata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="examHistoryFullScoreId">主键-考题历史分数编号</param>
        /// <returns></returns>
        private ExamHistoryScoreData getData(string examHistoryFullScoreId)
        {
            #region
            ExamHistoryScoreData examhistoryscoredata = new ExamHistoryScoreData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamHistoryScoreData.examHistoryFullScoreId, EnumSqlType.sqlint, EnumCondition.Equal, examHistoryFullScoreId);
            this._examhistoryscoreclass.GetSingleTAllWithoutCount(examhistoryscoredata, querybusinessparams);   
            return examhistoryscoredata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamHistoryScore指定页码的数据（分页型）
        /// </summary>
        /// <param name="examhistoryscore">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamHistoryScoreData GetData(EntityExamHistoryScore examhistoryscore, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamHistoryScoreData.examHistoryFullScoreId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryscore.examHistoryFullScoreId);
            querybusinessparams.Add(ExamHistoryScoreData.examPaperId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryscore.examPaperId);
            querybusinessparams.Add(ExamHistoryScoreData.questionId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryscore.questionId);
            querybusinessparams.Add(ExamHistoryScoreData.fullScore, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistoryscore.fullScore);
            querybusinessparams.Add(ExamHistoryScoreData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examhistoryscore.writeIp);
            querybusinessparams.Add(ExamHistoryScoreData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examhistoryscore.writeTime);
            ExamHistoryScoreData examhistoryscoredata = new ExamHistoryScoreData();
            totalCount = this._examhistoryscoreclass.GetSingleT(examhistoryscoredata, querybusinessparams);
            return examhistoryscoredata;
            #endregion
        }
        #endregion

        #endregion
    }
}


