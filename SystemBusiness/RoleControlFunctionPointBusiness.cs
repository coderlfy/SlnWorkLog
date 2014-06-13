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
    public class RoleControlFunctionPointBusiness : GeneralBusinesser
    {
        private RoleControlFunctionPointClass _rolecontrolfunctionpointclass = new RoleControlFunctionPointClass();
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
        /// 根据条件筛选所有RoleControlFunctionPoint指定页码的数据（分页型）
        /// </summary>
        /// <param name="rolecontrolfunctionpoint">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityRoleControlFunctionPoint rolecontrolfunctionpoint, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            RoleControlFunctionPointClass rolecontrolfunctionpointclass = new RoleControlFunctionPointClass();
            DataSet rolecontrolfunctionpointdata = this.GetData(rolecontrolfunctionpoint, pageparams, out totalCount);
            return base.GetJson(rolecontrolfunctionpointdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存rolecontrolfunctionpointdata数据集数据
        /// </summary>
        /// <param name="rolecontrolfunctionpointdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveRoleControlFunctionPoint(RoleControlFunctionPointData rolecontrolfunctionpointdata)
        {
            #region
            RoleControlFunctionPointClass rolecontrolfunctionpointclass = new RoleControlFunctionPointClass();
            return base.Save(rolecontrolfunctionpointdata, rolecontrolfunctionpointclass);
            #endregion
        }
                
        /// <summary>
        /// 添加RoleControlFunctionPoint表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="rolecontrolfunctionpointdata">数据集对象</param>
        /// <param name="rolecontrolfunctionpoint">实体对象</param>
        public void AddRow(ref RoleControlFunctionPointData rolecontrolfunctionpointdata, EntityRoleControlFunctionPoint rolecontrolfunctionpoint)
        {
            #region
            DataRow dr = rolecontrolfunctionpointdata.Tables[0].NewRow();
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.setId, rolecontrolfunctionpoint.setId);
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.functionId, rolecontrolfunctionpoint.functionId);
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.roleId, rolecontrolfunctionpoint.roleId);
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.userid, rolecontrolfunctionpoint.userid);
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.writeIp, rolecontrolfunctionpoint.writeIp);
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.writeTime, rolecontrolfunctionpoint.writeTime);
            rolecontrolfunctionpointdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑rolecontrolfunctionpointdata数据集中指定的行数据
        /// </summary>
        /// <param name="rolecontrolfunctionpointdata">数据集对象</param>
        /// <param name="rolecontrolfunctionpoint">实体对象</param>
        public void EditRow(ref RoleControlFunctionPointData rolecontrolfunctionpointdata, EntityRoleControlFunctionPoint rolecontrolfunctionpoint)
        {
            #region
            if (rolecontrolfunctionpointdata.Tables[0].Rows.Count <= 0)
                rolecontrolfunctionpointdata = this.getData(rolecontrolfunctionpoint.setId);
            DataRow dr = rolecontrolfunctionpointdata.Tables[0].Rows.Find(new object[1] {rolecontrolfunctionpoint.setId});
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.setId, rolecontrolfunctionpoint.setId);
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.functionId, rolecontrolfunctionpoint.functionId);
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.roleId, rolecontrolfunctionpoint.roleId);
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.userid, rolecontrolfunctionpoint.userid);
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.writeIp, rolecontrolfunctionpoint.writeIp);
            rolecontrolfunctionpointdata.Assign(dr, RoleControlFunctionPointData.writeTime, rolecontrolfunctionpoint.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除rolecontrolfunctionpointdata数据集中指定的行数据
        /// </summary>
        /// <param name="rolecontrolfunctionpointdata">数据集对象</param>
        /// <param name="setId">主键-功能点设置-编号</param>
        public void DeleteRow(ref RoleControlFunctionPointData rolecontrolfunctionpointdata,string setId)
        {
            #region
            if (rolecontrolfunctionpointdata.Tables[0].Rows.Count <= 0)
                rolecontrolfunctionpointdata = this.getData(setId);
            DataRow dr = rolecontrolfunctionpointdata.Tables[0].Rows.Find(new object[1] { setId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取RoleControlFunctionPoint数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            RoleControlFunctionPointData rolecontrolfunctionpointdata = this.getData(null);
            totalCount = rolecontrolfunctionpointdata.Tables[0].Rows.Count;
            return base.GetJson(rolecontrolfunctionpointdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityRoleControlFunctionPoint rolecontrolfunctionpoint)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(rolecontrolfunctionpoint, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="setId">主键-功能点设置-编号</param>
        /// <returns></returns>
        private RoleControlFunctionPointData getData(string setId)
        {
            #region
            RoleControlFunctionPointData rolecontrolfunctionpointdata = new RoleControlFunctionPointData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(RoleControlFunctionPointData.setId, EnumSqlType.sqlint, EnumCondition.Equal, setId);
            this._rolecontrolfunctionpointclass.GetSingleTAllWithoutCount(rolecontrolfunctionpointdata, querybusinessparams);
            return rolecontrolfunctionpointdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有RoleControlFunctionPoint指定页码的数据（分页型）
        /// </summary>
        /// <param name="rolecontrolfunctionpoint">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityRoleControlFunctionPoint rolecontrolfunctionpoint, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(RoleControlFunctionPointData.setId, EnumSqlType.sqlint, 
                EnumCondition.Equal, rolecontrolfunctionpoint.setId);
            querybusinessparams.Add(RoleControlFunctionPointData.functionId, EnumSqlType.sqlint, 
                EnumCondition.Equal, rolecontrolfunctionpoint.functionId);
            querybusinessparams.Add(RoleControlFunctionPointData.roleId, EnumSqlType.tinyint, 
                EnumCondition.Equal, rolecontrolfunctionpoint.roleId);
            querybusinessparams.Add(RoleControlFunctionPointData.userid, EnumSqlType.sqlint, 
                EnumCondition.Equal, rolecontrolfunctionpoint.userid);
            querybusinessparams.Add(RoleControlFunctionPointData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, rolecontrolfunctionpoint.writeIp);
            querybusinessparams.Add(RoleControlFunctionPointData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, rolecontrolfunctionpoint.writeTime);
            RoleControlFunctionPointData rolecontrolfunctionpointdata = new RoleControlFunctionPointData();
            totalCount = this._rolecontrolfunctionpointclass.GetSingleT(rolecontrolfunctionpointdata, querybusinessparams);
            return rolecontrolfunctionpointdata;
            #endregion
        }
        #endregion

        #endregion
    }
}


