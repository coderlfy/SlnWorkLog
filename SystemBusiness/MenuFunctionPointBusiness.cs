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
    public class MenuFunctionPointBusiness : GeneralBusinesser
    {
        private MenuFunctionPointClass _menufunctionpointclass = new MenuFunctionPointClass();
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
        /// 根据条件筛选所有MenuFunctionPoint指定页码的数据（分页型）
        /// </summary>
        /// <param name="menufunctionpoint">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityMenuFunctionPoint menufunctionpoint, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet menufunctionpointdata = this.GetData(menufunctionpoint, pageparams, out totalCount);
            return base.GetJson(menufunctionpointdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存menufunctionpointdata数据集数据
        /// </summary>
        /// <param name="menufunctionpointdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveMenuFunctionPoint(MenuFunctionPointData menufunctionpointdata)
        {
            #region
            MenuFunctionPointClass menufunctionpointclass = new MenuFunctionPointClass();
            return base.Save(menufunctionpointdata, menufunctionpointclass);
            #endregion
        }
                
        /// <summary>
        /// 添加MenuFunctionPoint表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="menufunctionpointdata">数据集对象</param>
        /// <param name="menufunctionpoint">实体对象</param>
        public void AddRow(ref MenuFunctionPointData menufunctionpointdata, EntityMenuFunctionPoint menufunctionpoint)
        {
            #region
            DataRow dr = menufunctionpointdata.Tables[0].NewRow();
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.functionId, menufunctionpoint.functionId);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.menuId, menufunctionpoint.menuId);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.functionPointName, menufunctionpoint.functionPointName);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.eventName, menufunctionpoint.eventName);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.sort, menufunctionpoint.sort);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.remark, menufunctionpoint.remark);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.usable, menufunctionpoint.usable);
            menufunctionpointdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑menufunctionpointdata数据集中指定的行数据
        /// </summary>
        /// <param name="menufunctionpointdata">数据集对象</param>
        /// <param name="menufunctionpoint">实体对象</param>
        public void EditRow(ref MenuFunctionPointData menufunctionpointdata, EntityMenuFunctionPoint menufunctionpoint)
        {
            #region
            if (menufunctionpointdata.Tables[0].Rows.Count <= 0)
                menufunctionpointdata = this.getData(menufunctionpoint.functionId);
            DataRow dr = menufunctionpointdata.Tables[0].Rows.Find(new object[1] {menufunctionpoint.functionId});
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.functionId, menufunctionpoint.functionId);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.menuId, menufunctionpoint.menuId);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.functionPointName, menufunctionpoint.functionPointName);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.eventName, menufunctionpoint.eventName);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.sort, menufunctionpoint.sort);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.remark, menufunctionpoint.remark);
            menufunctionpointdata.Assign(dr, MenuFunctionPointData.usable, menufunctionpoint.usable);
            #endregion
        }
        		
        /// <summary>
        /// 删除menufunctionpointdata数据集中指定的行数据
        /// </summary>
        /// <param name="menufunctionpointdata">数据集对象</param>
        /// <param name="functionId">主键-功能点编号</param>
        public void DeleteRow(ref MenuFunctionPointData menufunctionpointdata,string functionId)
        {
            #region
            if (menufunctionpointdata.Tables[0].Rows.Count <= 0)
                menufunctionpointdata = this.getData(functionId);
            DataRow dr = menufunctionpointdata.Tables[0].Rows.Find(new object[1] { functionId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取MenuFunctionPoint数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            MenuFunctionPointData menufunctionpointdata = this.getData(null);
            totalCount = menufunctionpointdata.Tables[0].Rows.Count;
            return base.GetJson(menufunctionpointdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityMenuFunctionPoint menufunctionpoint)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(menufunctionpoint, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="functionId">主键-功能点编号</param>
        /// <returns></returns>
        private MenuFunctionPointData getData(string functionId)
        {
            #region
            MenuFunctionPointData menufunctionpointdata = new MenuFunctionPointData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(MenuFunctionPointData.functionId, EnumSqlType.sqlint, EnumCondition.Equal, functionId);
            this._menufunctionpointclass.GetSingleTAllWithoutCount(menufunctionpointdata, querybusinessparams);
            return menufunctionpointdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有MenuFunctionPoint指定页码的数据（分页型）
        /// </summary>
        /// <param name="menufunctionpoint">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityMenuFunctionPoint menufunctionpoint, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(MenuFunctionPointData.functionId, EnumSqlType.sqlint, 
                EnumCondition.Equal, menufunctionpoint.functionId);
            querybusinessparams.Add(MenuFunctionPointData.menuId, EnumSqlType.sqlint, 
                EnumCondition.Equal, menufunctionpoint.menuId);
            querybusinessparams.Add(MenuFunctionPointData.functionPointName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, menufunctionpoint.functionPointName);
            querybusinessparams.Add(MenuFunctionPointData.eventName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, menufunctionpoint.eventName);
            querybusinessparams.Add(MenuFunctionPointData.sort, EnumSqlType.sqlint, 
                EnumCondition.Equal, menufunctionpoint.sort);
            querybusinessparams.Add(MenuFunctionPointData.remark, EnumSqlType.nvarchar, 
                EnumCondition.Equal, menufunctionpoint.remark);
            querybusinessparams.Add(MenuFunctionPointData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, menufunctionpoint.usable);
            MenuFunctionPointData menufunctionpointdata = new MenuFunctionPointData();
            totalCount = this._menufunctionpointclass.GetSingleT(menufunctionpointdata, querybusinessparams);
            return menufunctionpointdata;
            #endregion
        }
        #endregion

        #endregion
    }
}


