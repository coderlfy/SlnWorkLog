/****************************************
***创建人：bhlfy
***创建时间：2013-04-06 17:31:07
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using System;
using System.Data;

using SystemDataLibrary;
using SystemSqlLibrary;
using ExportExcelLib;
using BusinessBase;
using Fundation.Core;

namespace SystemBusiness
{
    public class ErrorLogsBusiness : GeneralBusinesser
    {
        private ErrorLogsClass _errorlogsclass = new ErrorLogsClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-06 17:31:07
        ***公司：山西ICat Studio有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        
        /// <summary>
        /// 根据条件筛选所有ErrorLogs指定页码的数据（分页型）
        /// </summary>
        /// <param name="errorlogs">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityErrorLogs errorlogs, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            ErrorLogsClass errorlogsclass = new ErrorLogsClass();
            DataSet errorlogsdata = this.GetData(errorlogs, pageparams, out totalCount);
            return base.GetJson(errorlogsdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存errorlogsdata数据集数据
        /// </summary>
        /// <param name="errorlogsdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveErrorLogs(ErrorLogsData errorlogsdata)
        {
            #region
            ErrorLogsClass errorlogsclass = new ErrorLogsClass();
            return base.Save(errorlogsdata, errorlogsclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ErrorLogs表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="errorlogsdata">数据集对象</param>
        /// <param name="errorlogs">实体对象</param>
        public void AddRow(ref ErrorLogsData errorlogsdata, EntityErrorLogs errorlogs)
        {
            #region
            DataRow dr = errorlogsdata.Tables[0].NewRow();
            errorlogsdata.Assign(dr, ErrorLogsData.errorId, errorlogs.errorId);
            errorlogsdata.Assign(dr, ErrorLogsData.userid, errorlogs.userid);
            errorlogsdata.Assign(dr, ErrorLogsData.writeIp, errorlogs.writeIp);
            errorlogsdata.Assign(dr, ErrorLogsData.writeTime, errorlogs.writeTime);
            errorlogsdata.Assign(dr, ErrorLogsData.Content, errorlogs.Content);
            errorlogsdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑errorlogsdata数据集中指定的行数据
        /// </summary>
        /// <param name="errorlogsdata">数据集对象</param>
        /// <param name="errorlogs">实体对象</param>
        public void EditRow(ref ErrorLogsData errorlogsdata, EntityErrorLogs errorlogs)
        {
            #region
            if (errorlogsdata.Tables[0].Rows.Count <= 0)
                errorlogsdata = this.getData(errorlogs.errorId);
            DataRow dr = errorlogsdata.Tables[0].Rows.Find(new object[1] {errorlogs.errorId});
            errorlogsdata.Assign(dr, ErrorLogsData.errorId, errorlogs.errorId);
            errorlogsdata.Assign(dr, ErrorLogsData.userid, errorlogs.userid);
            errorlogsdata.Assign(dr, ErrorLogsData.writeIp, errorlogs.writeIp);
            errorlogsdata.Assign(dr, ErrorLogsData.writeTime, errorlogs.writeTime);
            errorlogsdata.Assign(dr, ErrorLogsData.Content, errorlogs.Content);
            #endregion
        }
        		
        /// <summary>
        /// 删除errorlogsdata数据集中指定的行数据
        /// </summary>
        /// <param name="errorlogsdata">数据集对象</param>
        /// <param name="errorId">主键-错误日志编号</param>
        public void DeleteRow(ref ErrorLogsData errorlogsdata,string errorId)
        {
            #region
            if (errorlogsdata.Tables[0].Rows.Count <= 0)
                errorlogsdata = this.getData(errorId);
            DataRow dr = errorlogsdata.Tables[0].Rows.Find(new object[1] { errorId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ErrorLogs数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ErrorLogsData errorlogsdata = this.getData(null);
            totalCount = errorlogsdata.Tables[0].Rows.Count;
            return base.GetJson(errorlogsdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityErrorLogs errorlogs)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(errorlogs, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="errorId">主键-错误日志编号</param>
        /// <returns></returns>
        private ErrorLogsData getData(string errorId)
        {
            #region
            ErrorLogsData errorlogsdata = new ErrorLogsData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ErrorLogsData.errorId, EnumSqlType.sqlint, EnumCondition.Equal, errorId);
            this._errorlogsclass.GetSingleTAllWithoutCount(errorlogsdata, querybusinessparams);
            return errorlogsdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ErrorLogs指定页码的数据（分页型）
        /// </summary>
        /// <param name="errorlogs">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityErrorLogs errorlogs, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ErrorLogsData.errorId, EnumSqlType.sqlint, 
                EnumCondition.Equal, errorlogs.errorId);
            querybusinessparams.Add(ErrorLogsData.userid, EnumSqlType.sqlint, 
                EnumCondition.Equal, errorlogs.userid);
            querybusinessparams.Add(ErrorLogsData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, errorlogs.writeIp);
            querybusinessparams.Add(ErrorLogsData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, errorlogs.writeTime);
            querybusinessparams.Add(ErrorLogsData.Content, EnumSqlType.text, 
                EnumCondition.Equal, errorlogs.Content);
            ErrorLogsData errorlogsdata = new ErrorLogsData();
            totalCount = this._errorlogsclass.GetSingleT(errorlogsdata, querybusinessparams);
            return errorlogsdata;
            #endregion
        }
        #endregion

        #endregion
    }
}


