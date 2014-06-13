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
    public class ExamScoreRateBusiness : GeneralBusinesser
    {
        private ExamScoreRateClass _examscorerateclass = new ExamScoreRateClass();
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
        /// 根据条件筛选所有ExamScoreRate指定页码的数据（分页型）
        /// </summary>
        /// <param name="examscorerate">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamScoreRate examscorerate, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examscoreratedata = this.GetData(examscorerate, pageparams, out totalCount);
            return base.GetJson(examscoreratedata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examscoreratedata数据集数据
        /// </summary>
        /// <param name="examscoreratedata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamScoreRate(ExamScoreRateData examscoreratedata)
        {
            #region
            return base.Save(examscoreratedata, this._examscorerateclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamScoreRate表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examscoreratedata">数据集对象</param>
        /// <param name="examscorerate">实体对象</param>
        public void AddRow(ref ExamScoreRateData examscoreratedata, EntityExamScoreRate examscorerate)
        {
            #region
            DataRow dr = examscoreratedata.Tables[0].NewRow();
            examscoreratedata.Assign(dr, ExamScoreRateData.examScoreId, examscorerate.examScoreId);
            examscoreratedata.Assign(dr, ExamScoreRateData.examTemplateId, examscorerate.examTemplateId);
            examscoreratedata.Assign(dr, ExamScoreRateData.questionTypeId, examscorerate.questionTypeId);
            examscoreratedata.Assign(dr, ExamScoreRateData.rate, examscorerate.rate);
            examscoreratedata.Assign(dr, ExamScoreRateData.usable, examscorerate.usable);
            examscoreratedata.Assign(dr, ExamScoreRateData.writeUser, examscorerate.writeUser);
            examscoreratedata.Assign(dr, ExamScoreRateData.writeIp, examscorerate.writeIp);
            examscoreratedata.Assign(dr, ExamScoreRateData.writeTime, examscorerate.writeTime);
            examscoreratedata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examscoreratedata数据集中指定的行数据
        /// </summary>
        /// <param name="examscoreratedata">数据集对象</param>
        /// <param name="examscorerate">实体对象</param>
        public void EditRow(ref ExamScoreRateData examscoreratedata, EntityExamScoreRate examscorerate)
        {
            #region
            if (examscoreratedata.Tables[0].Rows.Count <= 0)
                examscoreratedata = this.getData(examscorerate.examScoreId);
            DataRow dr = examscoreratedata.Tables[0].Rows.Find(new object[1] {examscorerate.examScoreId});
            examscoreratedata.Assign(dr, ExamScoreRateData.examScoreId, examscorerate.examScoreId);
            examscoreratedata.Assign(dr, ExamScoreRateData.examTemplateId, examscorerate.examTemplateId);
            examscoreratedata.Assign(dr, ExamScoreRateData.questionTypeId, examscorerate.questionTypeId);
            examscoreratedata.Assign(dr, ExamScoreRateData.rate, examscorerate.rate);
            examscoreratedata.Assign(dr, ExamScoreRateData.usable, examscorerate.usable);
            examscoreratedata.Assign(dr, ExamScoreRateData.writeUser, examscorerate.writeUser);
            examscoreratedata.Assign(dr, ExamScoreRateData.writeIp, examscorerate.writeIp);
            examscoreratedata.Assign(dr, ExamScoreRateData.writeTime, examscorerate.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examscoreratedata数据集中指定的行数据
        /// </summary>
        /// <param name="examscoreratedata">数据集对象</param>
        /// <param name="examScoreId">主键-考卷比例编号</param>
        public void DeleteRow(ref ExamScoreRateData examscoreratedata,string examScoreId)
        {
            #region
            if (examscoreratedata.Tables[0].Rows.Count <= 0)
                examscoreratedata = this.getData(examScoreId);
            DataRow dr = examscoreratedata.Tables[0].Rows.Find(new object[1] { examScoreId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamScoreRate数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamScoreRateData examscoreratedata = this.getData(null);
            totalCount = examscoreratedata.Tables[0].Rows.Count;
            return base.GetJson(examscoreratedata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="examScoreId">主键-考卷比例编号</param>
        /// <returns></returns>
        private ExamScoreRateData getData(string examScoreId)
        {
            #region
            ExamScoreRateData examscoreratedata = new ExamScoreRateData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamScoreRateData.examScoreId, EnumSqlType.sqlint, EnumCondition.Equal, examScoreId);
            this._examscorerateclass.GetSingleTAllWithoutCount(examscoreratedata, querybusinessparams);   
            return examscoreratedata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamScoreRate指定页码的数据（分页型）
        /// </summary>
        /// <param name="examscorerate">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamScoreRateData GetData(EntityExamScoreRate examscorerate, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamScoreRateData.examScoreId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examscorerate.examScoreId);
            querybusinessparams.Add(ExamScoreRateData.examTemplateId, EnumSqlType.sqlint, 
                EnumCondition.Equal, examscorerate.examTemplateId);
            querybusinessparams.Add(ExamScoreRateData.questionTypeId, EnumSqlType.tinyint, 
                EnumCondition.Equal, examscorerate.questionTypeId);
            querybusinessparams.Add(ExamScoreRateData.rate, EnumSqlType.sqldecimal, 
                EnumCondition.Equal, examscorerate.rate);
            querybusinessparams.Add(ExamScoreRateData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, examscorerate.usable);
            querybusinessparams.Add(ExamScoreRateData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examscorerate.writeUser);
            querybusinessparams.Add(ExamScoreRateData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examscorerate.writeIp);
            querybusinessparams.Add(ExamScoreRateData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examscorerate.writeTime);
            ExamScoreRateData examscoreratedata = new ExamScoreRateData();
            totalCount = this._examscorerateclass.GetSingleT(examscoreratedata, querybusinessparams);
            return examscoreratedata;
            #endregion
        }
        #endregion

        #endregion
    }
}


