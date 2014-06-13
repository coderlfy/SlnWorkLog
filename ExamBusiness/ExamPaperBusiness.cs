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
    public class ExamPaperBusiness : GeneralBusinesser
    {
        private ExamPaperClass _exampaperclass = new ExamPaperClass();
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
        /// 根据条件筛选所有ExamPaper指定页码的数据（分页型）
        /// </summary>
        /// <param name="exampaper">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamPaper exampaper, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet exampaperdata = this.GetData(exampaper, pageparams, out totalCount);
            return base.GetJson(exampaperdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存exampaperdata数据集数据
        /// </summary>
        /// <param name="exampaperdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamPaper(ExamPaperData exampaperdata)
        {
            #region
            return base.Save(exampaperdata, this._exampaperclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamPaper表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="exampaperdata">数据集对象</param>
        /// <param name="exampaper">实体对象</param>
        public void AddRow(ref ExamPaperData exampaperdata, EntityExamPaper exampaper)
        {
            #region
            DataRow dr = exampaperdata.Tables[0].NewRow();
            exampaperdata.Assign(dr, ExamPaperData.examPaperId, exampaper.examPaperId);
            exampaperdata.Assign(dr, ExamPaperData.examTemplateId, exampaper.examTemplateId);
            exampaperdata.Assign(dr, ExamPaperData.exampaperName, exampaper.exampaperName);
            exampaperdata.Assign(dr, ExamPaperData.usable, exampaper.usable);
            exampaperdata.Assign(dr, ExamPaperData.remark, exampaper.remark);
            exampaperdata.Assign(dr, ExamPaperData.sort, exampaper.sort);
            exampaperdata.Assign(dr, ExamPaperData.writeUser, exampaper.writeUser);
            exampaperdata.Assign(dr, ExamPaperData.writeIp, exampaper.writeIp);
            exampaperdata.Assign(dr, ExamPaperData.writeTime, exampaper.writeTime);
            exampaperdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑exampaperdata数据集中指定的行数据
        /// </summary>
        /// <param name="exampaperdata">数据集对象</param>
        /// <param name="exampaper">实体对象</param>
        public void EditRow(ref ExamPaperData exampaperdata, EntityExamPaper exampaper)
        {
            #region
            if (exampaperdata.Tables[0].Rows.Count <= 0)
                exampaperdata = this.getData(exampaper.examPaperId);
            DataRow dr = exampaperdata.Tables[0].Rows.Find(new object[1] {exampaper.examPaperId});
            exampaperdata.Assign(dr, ExamPaperData.examPaperId, exampaper.examPaperId);
            exampaperdata.Assign(dr, ExamPaperData.examTemplateId, exampaper.examTemplateId);
            exampaperdata.Assign(dr, ExamPaperData.exampaperName, exampaper.exampaperName);
            exampaperdata.Assign(dr, ExamPaperData.usable, exampaper.usable);
            exampaperdata.Assign(dr, ExamPaperData.remark, exampaper.remark);
            exampaperdata.Assign(dr, ExamPaperData.sort, exampaper.sort);
            exampaperdata.Assign(dr, ExamPaperData.writeUser, exampaper.writeUser);
            exampaperdata.Assign(dr, ExamPaperData.writeIp, exampaper.writeIp);
            exampaperdata.Assign(dr, ExamPaperData.writeTime, exampaper.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除exampaperdata数据集中指定的行数据
        /// </summary>
        /// <param name="exampaperdata">数据集对象</param>
        /// <param name="examPaperId">主键-考卷编号</param>
        public void DeleteRow(ref ExamPaperData exampaperdata,string examPaperId)
        {
            #region
            if (exampaperdata.Tables[0].Rows.Count <= 0)
                exampaperdata = this.getData(examPaperId);
            DataRow dr = exampaperdata.Tables[0].Rows.Find(new object[1] { examPaperId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamPaper数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamPaperData exampaperdata = this.getData(null);
            totalCount = exampaperdata.Tables[0].Rows.Count;
            return base.GetJson(exampaperdata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="examPaperId">主键-考卷编号</param>
        /// <returns></returns>
        private ExamPaperData getData(string examPaperId)
        {
            #region
            ExamPaperData exampaperdata = new ExamPaperData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamPaperData.examPaperId, EnumSqlType.sqlint, EnumCondition.Equal, examPaperId);
            this._exampaperclass.GetSingleTAllWithoutCount(exampaperdata, querybusinessparams);   
            return exampaperdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamPaper指定页码的数据（分页型）
        /// </summary>
        /// <param name="exampaper">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamPaperData GetData(EntityExamPaper exampaper, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamPaperData.examPaperId, EnumSqlType.sqlint, 
                EnumCondition.Equal, exampaper.examPaperId);
            querybusinessparams.Add(ExamPaperData.examTemplateId, EnumSqlType.sqlint, 
                EnumCondition.Equal, exampaper.examTemplateId);
            querybusinessparams.Add(ExamPaperData.exampaperName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, exampaper.exampaperName);
            querybusinessparams.Add(ExamPaperData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, exampaper.usable);
            querybusinessparams.Add(ExamPaperData.remark, EnumSqlType.nvarchar, 
                EnumCondition.Equal, exampaper.remark);
            querybusinessparams.Add(ExamPaperData.sort, EnumSqlType.tinyint, 
                EnumCondition.Equal, exampaper.sort);
            querybusinessparams.Add(ExamPaperData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, exampaper.writeUser);
            querybusinessparams.Add(ExamPaperData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, exampaper.writeIp);
            querybusinessparams.Add(ExamPaperData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, exampaper.writeTime);
            ExamPaperData exampaperdata = new ExamPaperData();
            totalCount = this._exampaperclass.GetSingleT(exampaperdata, querybusinessparams);
            return exampaperdata;
            #endregion
        }
        #endregion

        #endregion
    }
}


