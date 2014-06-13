/****************************************
***创建人：bhlfy
***创建时间：2013-04-06 17:31:07
***公司：山西博华科技有限公司
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
    public class SystemRoleBusiness : GeneralBusinesser
    {
        private SystemRoleClass _systemroleclass = new SystemRoleClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-06 17:31:07
        ***公司：山西博华科技有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        
        /// <summary>
        /// 根据条件筛选所有SystemRole指定页码的数据（分页型）
        /// </summary>
        /// <param name="systemrole">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntitySystemRole systemrole, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            SystemRoleClass systemroleclass = new SystemRoleClass();
            DataSet systemroledata = this.GetData(systemrole, pageparams, out totalCount);
            return base.GetJson(systemroledata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存systemroledata数据集数据
        /// </summary>
        /// <param name="systemroledata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveSystemRole(SystemRoleData systemroledata)
        {
            #region
            SystemRoleClass systemroleclass = new SystemRoleClass();
            return base.Save(systemroledata, systemroleclass);
            #endregion
        }
                
        /// <summary>
        /// 添加SystemRole表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="systemroledata">数据集对象</param>
        /// <param name="systemrole">实体对象</param>
        public void AddRow(ref SystemRoleData systemroledata, EntitySystemRole systemrole)
        {
            #region
            DataRow dr = systemroledata.Tables[0].NewRow();
            systemroledata.Assign(dr, SystemRoleData.roleId, systemrole.roleId);
            systemroledata.Assign(dr, SystemRoleData.roleName, systemrole.roleName);
            systemroledata.Assign(dr, SystemRoleData.usable, systemrole.usable);
            systemroledata.Assign(dr, SystemRoleData.remark, systemrole.remark);
            systemroledata.Assign(dr, SystemRoleData.sort, systemrole.sort);
            systemroledata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑systemroledata数据集中指定的行数据
        /// </summary>
        /// <param name="systemroledata">数据集对象</param>
        /// <param name="systemrole">实体对象</param>
        public void EditRow(ref SystemRoleData systemroledata, EntitySystemRole systemrole)
        {
            #region
            if (systemroledata.Tables[0].Rows.Count <= 0)
                systemroledata = this.getData(systemrole.roleId);
            DataRow dr = systemroledata.Tables[0].Rows.Find(new object[1] {systemrole.roleId});
            systemroledata.Assign(dr, SystemRoleData.roleId, systemrole.roleId);
            systemroledata.Assign(dr, SystemRoleData.roleName, systemrole.roleName);
            systemroledata.Assign(dr, SystemRoleData.usable, systemrole.usable);
            systemroledata.Assign(dr, SystemRoleData.remark, systemrole.remark);
            systemroledata.Assign(dr, SystemRoleData.sort, systemrole.sort);
            #endregion
        }
        		
        /// <summary>
        /// 删除systemroledata数据集中指定的行数据
        /// </summary>
        /// <param name="systemroledata">数据集对象</param>
        /// <param name="roleId">主键-角色编号</param>
        public void DeleteRow(ref SystemRoleData systemroledata,string roleId)
        {
            #region
            if (systemroledata.Tables[0].Rows.Count <= 0)
                systemroledata = this.getData(roleId);
            DataRow dr = systemroledata.Tables[0].Rows.Find(new object[1] { roleId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取SystemRole数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            SystemRoleData systemroledata = this.getData(null);
            totalCount = systemroledata.Tables[0].Rows.Count;
            return base.GetJson(systemroledata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntitySystemRole systemrole)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(systemrole, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="roleId">主键-角色编号</param>
        /// <returns></returns>
        private SystemRoleData getData(string roleId)
        {
            #region
            SystemRoleData systemroledata = new SystemRoleData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(SystemRoleData.roleId, EnumSqlType.tinyint, EnumCondition.Equal, roleId);
            this._systemroleclass.GetSingleTAllWithoutCount(systemroledata, querybusinessparams);
            return systemroledata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有SystemRole指定页码的数据（分页型）
        /// </summary>
        /// <param name="systemrole">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntitySystemRole systemrole, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(SystemRoleData.roleId, EnumSqlType.tinyint, 
                EnumCondition.Equal, systemrole.roleId);
            querybusinessparams.Add(SystemRoleData.roleName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, systemrole.roleName);
            querybusinessparams.Add(SystemRoleData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, systemrole.usable);
            querybusinessparams.Add(SystemRoleData.remark, EnumSqlType.nvarchar, 
                EnumCondition.Equal, systemrole.remark);
            querybusinessparams.Add(SystemRoleData.sort, EnumSqlType.tinyint, 
                EnumCondition.Equal, systemrole.sort);
            SystemRoleData systemroledata = new SystemRoleData();
            totalCount = this._systemroleclass.GetSingleT(systemroledata, querybusinessparams);
            return systemroledata;
            #endregion
        }
        #endregion

        #endregion
    }
}


