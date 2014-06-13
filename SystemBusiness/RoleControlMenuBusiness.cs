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
    public class RoleControlMenuBusiness : GeneralBusinesser
    {
        private RoleControlMenuClass _rolecontrolmenuclass = new RoleControlMenuClass();
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
        /// 根据条件筛选所有RoleControlMenu指定页码的数据（分页型）
        /// </summary>
        /// <param name="rolecontrolmenu">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityRoleControlMenu rolecontrolmenu, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            RoleControlMenuClass rolecontrolmenuclass = new RoleControlMenuClass();
            DataSet rolecontrolmenudata = this.GetData(rolecontrolmenu, pageparams, out totalCount);
            return base.GetJson(rolecontrolmenudata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存rolecontrolmenudata数据集数据
        /// </summary>
        /// <param name="rolecontrolmenudata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveRoleControlMenu(RoleControlMenuData rolecontrolmenudata)
        {
            #region
            RoleControlMenuClass rolecontrolmenuclass = new RoleControlMenuClass();
            return base.Save(rolecontrolmenudata, rolecontrolmenuclass);
            #endregion
        }
                
        /// <summary>
        /// 添加RoleControlMenu表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="rolecontrolmenudata">数据集对象</param>
        /// <param name="rolecontrolmenu">实体对象</param>
        public void AddRow(ref RoleControlMenuData rolecontrolmenudata, EntityRoleControlMenu rolecontrolmenu)
        {
            #region
            DataRow dr = rolecontrolmenudata.Tables[0].NewRow();
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.setId, rolecontrolmenu.setId);
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.menuId, rolecontrolmenu.menuId);
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.roleId, rolecontrolmenu.roleId);
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.userid, rolecontrolmenu.userid);
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.writeIp, rolecontrolmenu.writeIp);
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.writeTime, rolecontrolmenu.writeTime);
            rolecontrolmenudata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑rolecontrolmenudata数据集中指定的行数据
        /// </summary>
        /// <param name="rolecontrolmenudata">数据集对象</param>
        /// <param name="rolecontrolmenu">实体对象</param>
        public void EditRow(ref RoleControlMenuData rolecontrolmenudata, EntityRoleControlMenu rolecontrolmenu)
        {
            #region
            if (rolecontrolmenudata.Tables[0].Rows.Count <= 0)
                rolecontrolmenudata = this.getData(rolecontrolmenu.setId);
            DataRow dr = rolecontrolmenudata.Tables[0].Rows.Find(new object[1] {rolecontrolmenu.setId});
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.setId, rolecontrolmenu.setId);
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.menuId, rolecontrolmenu.menuId);
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.roleId, rolecontrolmenu.roleId);
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.userid, rolecontrolmenu.userid);
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.writeIp, rolecontrolmenu.writeIp);
            rolecontrolmenudata.Assign(dr, RoleControlMenuData.writeTime, rolecontrolmenu.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除rolecontrolmenudata数据集中指定的行数据
        /// </summary>
        /// <param name="rolecontrolmenudata">数据集对象</param>
        /// <param name="setId">主键-角色控制菜单-编号</param>
        public void DeleteRow(ref RoleControlMenuData rolecontrolmenudata,string setId)
        {
            #region
            if (rolecontrolmenudata.Tables[0].Rows.Count <= 0)
                rolecontrolmenudata = this.getData(setId);
            DataRow dr = rolecontrolmenudata.Tables[0].Rows.Find(new object[1] { setId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取RoleControlMenu数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            RoleControlMenuData rolecontrolmenudata = this.getData(null);
            totalCount = rolecontrolmenudata.Tables[0].Rows.Count;
            return base.GetJson(rolecontrolmenudata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityRoleControlMenu rolecontrolmenu)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(rolecontrolmenu, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="setId">主键-角色控制菜单-编号</param>
        /// <returns></returns>
        private RoleControlMenuData getData(string setId)
        {
            #region
            RoleControlMenuData rolecontrolmenudata = new RoleControlMenuData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(RoleControlMenuData.setId, EnumSqlType.sqlint, EnumCondition.Equal, setId);
            this._rolecontrolmenuclass.GetSingleTAllWithoutCount(rolecontrolmenudata, querybusinessparams);
            return rolecontrolmenudata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有RoleControlMenu指定页码的数据（分页型）
        /// </summary>
        /// <param name="rolecontrolmenu">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityRoleControlMenu rolecontrolmenu, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(RoleControlMenuData.setId, EnumSqlType.sqlint, 
                EnumCondition.Equal, rolecontrolmenu.setId);
            querybusinessparams.Add(RoleControlMenuData.menuId, EnumSqlType.sqlint, 
                EnumCondition.Equal, rolecontrolmenu.menuId);
            querybusinessparams.Add(RoleControlMenuData.roleId, EnumSqlType.tinyint, 
                EnumCondition.Equal, rolecontrolmenu.roleId);
            querybusinessparams.Add(RoleControlMenuData.userid, EnumSqlType.sqlint, 
                EnumCondition.Equal, rolecontrolmenu.userid);
            querybusinessparams.Add(RoleControlMenuData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, rolecontrolmenu.writeIp);
            querybusinessparams.Add(RoleControlMenuData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, rolecontrolmenu.writeTime);
            RoleControlMenuData rolecontrolmenudata = new RoleControlMenuData();
            totalCount = this._rolecontrolmenuclass.GetSingleT(rolecontrolmenudata, querybusinessparams);
            return rolecontrolmenudata;
            #endregion
        }
        #endregion

        #endregion

        public string updateRoleControlMenu(string setId, string menuId,
            string roleId, string userid, string writeIp,
            string writeTime)
        {
            #region
            JsonHelper jsonhlp = new JsonHelper();
            if (roleId.ToString() != "")
            {
                RoleControlMenuData rolecontrolmenudata = new RoleControlMenuData();
                if (menuId != null)
                {
                    string[] strArray = menuId.Split(',');
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i] == "root")
                            continue;
                        EntityRoleControlMenu rolecontrolmenu = new EntityRoleControlMenu();
                        rolecontrolmenu.setId = i.ToString();
                        rolecontrolmenu.menuId = strArray[i];
                        rolecontrolmenu.roleId = roleId;
                        rolecontrolmenu.userid = userid;
                        rolecontrolmenu.writeIp = writeIp;
                        rolecontrolmenu.writeTime = DateTime.Now.ToString();
                        this.AddRow(ref rolecontrolmenudata, rolecontrolmenu);
                    }
                    this._rolecontrolmenuclass.UpdateRoleControl(roleId, rolecontrolmenudata);
                    jsonhlp.AddObjectToJson("success", true);
                }
            }
            return jsonhlp.ToString();
            #endregion
        }
    }
}


