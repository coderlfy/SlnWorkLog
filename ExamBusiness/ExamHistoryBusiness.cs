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
    public class ExamHistoryBusiness : GeneralBusinesser
    {
        private ExamHistoryClass _examhistoryclass = new ExamHistoryClass();
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
        /// 根据条件筛选所有ExamHistory指定页码的数据（分页型）
        /// </summary>
        /// <param name="examhistory">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamHistory examhistory, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examhistorydata = this.GetData(examhistory, pageparams, out totalCount);
            return base.GetJson(examhistorydata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examhistorydata数据集数据
        /// </summary>
        /// <param name="examhistorydata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamHistory(ExamHistoryData examhistorydata)
        {
            #region
            return base.Save(examhistorydata, this._examhistoryclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamHistory表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examhistorydata">数据集对象</param>
        /// <param name="examhistory">实体对象</param>
        public void AddRow(ref ExamHistoryData examhistorydata, EntityExamHistory examhistory)
        {
            #region
            DataRow dr = examhistorydata.Tables[0].NewRow();
            examhistorydata.Assign(dr, ExamHistoryData.examHistoryId, examhistory.examHistoryId);
            examhistorydata.Assign(dr, ExamHistoryData.examPaperId, examhistory.examPaperId);
            examhistorydata.Assign(dr, ExamHistoryData.giveScoreRemark, examhistory.giveScoreRemark);
            examhistorydata.Assign(dr, ExamHistoryData.giveScoreUser, examhistory.giveScoreUser);
            examhistorydata.Assign(dr, ExamHistoryData.giveScoreTime, examhistory.giveScoreTime);
            examhistorydata.Assign(dr, ExamHistoryData.writeUser, examhistory.writeUser);
            examhistorydata.Assign(dr, ExamHistoryData.examSubmitTime, examhistory.examSubmitTime);
            examhistorydata.Assign(dr, ExamHistoryData.writeIp, examhistory.writeIp);
            examhistorydata.Assign(dr, ExamHistoryData.writeTime, examhistory.writeTime);
            examhistorydata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examhistorydata数据集中指定的行数据
        /// </summary>
        /// <param name="examhistorydata">数据集对象</param>
        /// <param name="examhistory">实体对象</param>
        public void EditRow(ref ExamHistoryData examhistorydata, EntityExamHistory examhistory)
        {
            #region
            if (examhistorydata.Tables[0].Rows.Count <= 0)
                examhistorydata = this.getData(examhistory.examHistoryId);
            DataRow dr = examhistorydata.Tables[0].Rows.Find(new object[1] {examhistory.examHistoryId});
            examhistorydata.Assign(dr, ExamHistoryData.examHistoryId, examhistory.examHistoryId);
            examhistorydata.Assign(dr, ExamHistoryData.examPaperId, examhistory.examPaperId);
            examhistorydata.Assign(dr, ExamHistoryData.giveScoreRemark, examhistory.giveScoreRemark);
            examhistorydata.Assign(dr, ExamHistoryData.giveScoreUser, examhistory.giveScoreUser);
            examhistorydata.Assign(dr, ExamHistoryData.giveScoreTime, examhistory.giveScoreTime);
            examhistorydata.Assign(dr, ExamHistoryData.writeUser, examhistory.writeUser);
            examhistorydata.Assign(dr, ExamHistoryData.examSubmitTime, examhistory.examSubmitTime);
            examhistorydata.Assign(dr, ExamHistoryData.writeIp, examhistory.writeIp);
            examhistorydata.Assign(dr, ExamHistoryData.writeTime, examhistory.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examhistorydata数据集中指定的行数据
        /// </summary>
        /// <param name="examhistorydata">数据集对象</param>
        /// <param name="examHistoryId">主键-考试成绩单编号</param>
        public void DeleteRow(ref ExamHistoryData examhistorydata,string examHistoryId)
        {
            #region
            if (examhistorydata.Tables[0].Rows.Count <= 0)
                examhistorydata = this.getData(examHistoryId);
            DataRow dr = examhistorydata.Tables[0].Rows.Find(new object[1] { examHistoryId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamHistory数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamHistoryData examhistorydata = this.getData(null);
            totalCount = examhistorydata.Tables[0].Rows.Count;
            return base.GetJson(examhistorydata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="examHistoryId">主键-考试成绩单编号</param>
        /// <returns></returns>
        private ExamHistoryData getData(string examHistoryId)
        {
            #region
            ExamHistoryData examhistorydata = new ExamHistoryData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamHistoryData.examHistoryId, EnumSqlType.sqlint, EnumCondition.Equal, examHistoryId);
            this._examhistoryclass.GetSingleTAllWithoutCount(examhistorydata, querybusinessparams);   
            return examhistorydata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamHistory指定页码的数据（分页型）
        /// </summary>
        /// <param name="examhistory">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamHistoryData GetData(EntityExamHistory examhistory, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamHistoryData.examHistoryId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistory.examHistoryId);
            querybusinessparams.Add(ExamHistoryData.examPaperId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistory.examPaperId);
            querybusinessparams.Add(ExamHistoryData.giveScoreRemark, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examhistory.giveScoreRemark);
            querybusinessparams.Add(ExamHistoryData.giveScoreUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistory.giveScoreUser);
            querybusinessparams.Add(ExamHistoryData.giveScoreTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examhistory.giveScoreTime);
            querybusinessparams.Add(ExamHistoryData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examhistory.writeUser);
            querybusinessparams.Add(ExamHistoryData.examSubmitTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examhistory.examSubmitTime);
            querybusinessparams.Add(ExamHistoryData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examhistory.writeIp);
            querybusinessparams.Add(ExamHistoryData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examhistory.writeTime);
            ExamHistoryData examhistorydata = new ExamHistoryData();
            totalCount = this._examhistoryclass.GetSingleT(examhistorydata, querybusinessparams);
            return examhistorydata;
            #endregion
        }
        #endregion

        #endregion
    }
}


