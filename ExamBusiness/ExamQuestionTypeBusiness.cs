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
    public class ExamQuestionTypeBusiness : GeneralBusinesser
    {
        private ExamQuestionTypeClass _examquestiontypeclass = new ExamQuestionTypeClass();
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
        /// 根据条件筛选所有ExamQuestionType指定页码的数据（分页型）
        /// </summary>
        /// <param name="examquestiontype">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityExamQuestionType examquestiontype, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet examquestiontypedata = this.GetData(examquestiontype, pageparams, out totalCount);
            return base.GetJson(examquestiontypedata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存examquestiontypedata数据集数据
        /// </summary>
        /// <param name="examquestiontypedata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveExamQuestionType(ExamQuestionTypeData examquestiontypedata)
        {
            #region
            return base.Save(examquestiontypedata, this._examquestiontypeclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ExamQuestionType表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="examquestiontypedata">数据集对象</param>
        /// <param name="examquestiontype">实体对象</param>
        public void AddRow(ref ExamQuestionTypeData examquestiontypedata, EntityExamQuestionType examquestiontype)
        {
            #region
            DataRow dr = examquestiontypedata.Tables[0].NewRow();
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.questionTypeId, examquestiontype.questionTypeId);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.questionTypeName, examquestiontype.questionTypeName);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.usable, examquestiontype.usable);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.remark, examquestiontype.remark);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.sort, examquestiontype.sort);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.writeUser, examquestiontype.writeUser);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.writeIp, examquestiontype.writeIp);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.writeTime, examquestiontype.writeTime);
            examquestiontypedata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑examquestiontypedata数据集中指定的行数据
        /// </summary>
        /// <param name="examquestiontypedata">数据集对象</param>
        /// <param name="examquestiontype">实体对象</param>
        public void EditRow(ref ExamQuestionTypeData examquestiontypedata, EntityExamQuestionType examquestiontype)
        {
            #region
            if (examquestiontypedata.Tables[0].Rows.Count <= 0)
                examquestiontypedata = this.getData(examquestiontype.questionTypeId);
            DataRow dr = examquestiontypedata.Tables[0].Rows.Find(new object[1] {examquestiontype.questionTypeId});
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.questionTypeId, examquestiontype.questionTypeId);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.questionTypeName, examquestiontype.questionTypeName);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.usable, examquestiontype.usable);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.remark, examquestiontype.remark);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.sort, examquestiontype.sort);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.writeUser, examquestiontype.writeUser);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.writeIp, examquestiontype.writeIp);
            examquestiontypedata.Assign(dr, ExamQuestionTypeData.writeTime, examquestiontype.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除examquestiontypedata数据集中指定的行数据
        /// </summary>
        /// <param name="examquestiontypedata">数据集对象</param>
        /// <param name="questionTypeId">主键-问题类型编号</param>
        public void DeleteRow(ref ExamQuestionTypeData examquestiontypedata,string questionTypeId)
        {
            #region
            if (examquestiontypedata.Tables[0].Rows.Count <= 0)
                examquestiontypedata = this.getData(questionTypeId);
            DataRow dr = examquestiontypedata.Tables[0].Rows.Find(new object[1] { questionTypeId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ExamQuestionType数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ExamQuestionTypeData examquestiontypedata = this.getData(null);
            totalCount = examquestiontypedata.Tables[0].Rows.Count;
            return base.GetJson(examquestiontypedata, totalCount);
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="questionTypeId">主键-问题类型编号</param>
        /// <returns></returns>
        private ExamQuestionTypeData getData(string questionTypeId)
        {
            #region
            ExamQuestionTypeData examquestiontypedata = new ExamQuestionTypeData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ExamQuestionTypeData.questionTypeId, EnumSqlType.tinyint, EnumCondition.Equal, questionTypeId);
            this._examquestiontypeclass.GetSingleTAllWithoutCount(examquestiontypedata, querybusinessparams);   
            return examquestiontypedata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ExamQuestionType指定页码的数据（分页型）
        /// </summary>
        /// <param name="examquestiontype">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ExamQuestionTypeData GetData(EntityExamQuestionType examquestiontype, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ExamQuestionTypeData.questionTypeId, EnumSqlType.tinyint, 
                EnumCondition.Equal, examquestiontype.questionTypeId);
            querybusinessparams.Add(ExamQuestionTypeData.questionTypeName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examquestiontype.questionTypeName);
            querybusinessparams.Add(ExamQuestionTypeData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, examquestiontype.usable);
            querybusinessparams.Add(ExamQuestionTypeData.remark, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examquestiontype.remark);
            querybusinessparams.Add(ExamQuestionTypeData.sort, EnumSqlType.tinyint, 
                EnumCondition.Equal, examquestiontype.sort);
            querybusinessparams.Add(ExamQuestionTypeData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, examquestiontype.writeUser);
            querybusinessparams.Add(ExamQuestionTypeData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, examquestiontype.writeIp);
            querybusinessparams.Add(ExamQuestionTypeData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, examquestiontype.writeTime);
            ExamQuestionTypeData examquestiontypedata = new ExamQuestionTypeData();
            totalCount = this._examquestiontypeclass.GetSingleT(examquestiontypedata, querybusinessparams);
            return examquestiontypedata;
            #endregion
        }
        #endregion

        #endregion
    }
}


