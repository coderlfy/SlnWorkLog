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
    public class MenuBusiness : GeneralBusinesser
    {
        private MenuClass _menuclass = new MenuClass();
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
        /// 根据条件筛选所有Menu指定页码的数据（分页型）
        /// </summary>
        /// <param name="menu">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityMenu menu, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet menudata = this.GetData(menu, pageparams, out totalCount);
            return base.GetJson(menudata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存menudata数据集数据
        /// </summary>
        /// <param name="menudata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveMenu(MenuData menudata)
        {
            #region
            MenuClass menuclass = new MenuClass();
            return base.Save(menudata, menuclass);
            #endregion
        }
                
        /// <summary>
        /// 添加Menu表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="menudata">数据集对象</param>
        /// <param name="menu">实体对象</param>
        public void AddRow(ref MenuData menudata, EntityMenu menu)
        {
            #region
            DataRow dr = menudata.Tables[0].NewRow();
            menudata.Assign(dr, MenuData.menuId, menu.menuId);
            menudata.Assign(dr, MenuData.currentId, menu.currentId);
            menudata.Assign(dr, MenuData.parentId, menu.parentId);
            menudata.Assign(dr, MenuData.menuName, menu.menuName);
            menudata.Assign(dr, MenuData.iconCls, menu.iconCls);
            menudata.Assign(dr, MenuData.htmlurl, menu.htmlurl);
            menudata.Assign(dr, MenuData.eventName, menu.eventName);
            menudata.Assign(dr, MenuData.sort, menu.sort);
            menudata.Assign(dr, MenuData.usable, menu.usable);
            menudata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑menudata数据集中指定的行数据
        /// </summary>
        /// <param name="menudata">数据集对象</param>
        /// <param name="menu">实体对象</param>
        public void EditRow(ref MenuData menudata, EntityMenu menu)
        {
            #region
            if (menudata.Tables[0].Rows.Count <= 0)
                menudata = this.getData(menu.menuId);
            DataRow dr = menudata.Tables[0].Rows.Find(new object[1] {menu.menuId});
            menudata.Assign(dr, MenuData.menuId, menu.menuId);
            menudata.Assign(dr, MenuData.currentId, menu.currentId);
            menudata.Assign(dr, MenuData.parentId, menu.parentId);
            menudata.Assign(dr, MenuData.menuName, menu.menuName);
            menudata.Assign(dr, MenuData.iconCls, menu.iconCls);
            menudata.Assign(dr, MenuData.htmlurl, menu.htmlurl);
            menudata.Assign(dr, MenuData.eventName, menu.eventName);
            menudata.Assign(dr, MenuData.sort, menu.sort);
            menudata.Assign(dr, MenuData.usable, menu.usable);
            #endregion
        }
        		
        /// <summary>
        /// 删除menudata数据集中指定的行数据
        /// </summary>
        /// <param name="menudata">数据集对象</param>
        /// <param name="menuId">主键-自动编号</param>
        public void DeleteRow(ref MenuData menudata,string menuId)
        {
            #region
            if (menudata.Tables[0].Rows.Count <= 0)
                menudata = this.getData(menuId);
            DataRow dr = menudata.Tables[0].Rows.Find(new object[1] { menuId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取Menu数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            MenuData menudata = this.getData(null);
            totalCount = menudata.Tables[0].Rows.Count;
            return base.GetJson(menudata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityMenu menu)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(menu, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="menuId">主键-自动编号</param>
        /// <returns></returns>
        private MenuData getData(string menuId)
        {
            #region
            MenuData menudata = new MenuData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(MenuData.menuId, EnumSqlType.sqlint, EnumCondition.Equal, menuId);
            this._menuclass.GetSingleTAllWithoutCount(menudata, querybusinessparams);
            return menudata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有Menu指定页码的数据（分页型）
        /// </summary>
        /// <param name="menu">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityMenu menu, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(MenuData.menuId, EnumSqlType.sqlint, 
                EnumCondition.Equal, menu.menuId);
            querybusinessparams.Add(MenuData.currentId, EnumSqlType.sqlint, 
                EnumCondition.Equal, menu.currentId);
            querybusinessparams.Add(MenuData.parentId, EnumSqlType.sqlint, 
                EnumCondition.Equal, menu.parentId);
            querybusinessparams.Add(MenuData.menuName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, menu.menuName);
            querybusinessparams.Add(MenuData.iconCls, EnumSqlType.nvarchar, 
                EnumCondition.Equal, menu.iconCls);
            querybusinessparams.Add(MenuData.htmlurl, EnumSqlType.nvarchar, 
                EnumCondition.Equal, menu.htmlurl);
            querybusinessparams.Add(MenuData.eventName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, menu.eventName);
            querybusinessparams.Add(MenuData.sort, EnumSqlType.sqlint, 
                EnumCondition.Equal, menu.sort);
            querybusinessparams.Add(MenuData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, menu.usable);
            MenuData menudata = new MenuData();
            totalCount = this._menuclass.GetSingleT(menudata, querybusinessparams);
            return menudata;
            #endregion
        }
        #endregion

        #endregion
        /// <summary>
        /// 根据权限组获取菜单json（系统左边菜单列表显示）
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public string GetSystemMenuList(string roleId, string userId)
        {
            #region
            string menulistjson = "";
            MenuClass menuclass = new MenuClass();
            if (String.IsNullOrEmpty(roleId))
                return "{ topics:[]}";

            DBConditions queryconditions = new DBConditions();
            queryconditions.Add(RoleControlMenuData.roleId, EnumSqlType.tinyint, EnumCondition.Equal, roleId);
            queryconditions.Add(MenuData.usable, EnumSqlType.bit, EnumCondition.Equal, true);

            DataSet menulistdata = menuclass.GetMenuByRole(queryconditions);

            menulistjson += string.Format("{{ roleId:'{0}',userid:'{1}', topics:[", roleId, userId);

            DataRow[] menucollect = menulistdata.Tables[0].Select(MenuData.parentId + " = 0");

            foreach (DataRow dr in menucollect)
            {
                string treejson = "";
                string currentmenuid = dr[MenuData.currentId].ToString();
                this.iteratorSystemMenu(menulistdata, currentmenuid, ref treejson);
                menulistjson += "{menuid:'" + currentmenuid + "',menuname:'" + dr[MenuData.menuName].ToString() + "',children:[" + treejson;
                if (menulistdata.Tables[0].Select(MenuData.parentId + " = " + currentmenuid).Length == 0)
                    menulistjson += "]";
                menulistjson += "},";
            }
            //去掉json中多余的逗号
            if (menucollect.Length > 0)
                menulistjson = menulistjson.Remove(menulistjson.Length - 1, 1);

            menulistjson += "]}";
            return menulistjson;
            #endregion
        }
        /// <summary>
        /// 递归获取各系统下的树形列表
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="parentId"></param>
        /// <param name="json"></param>
        private void iteratorSystemMenu(DataSet ds, string parentId, ref String json)
        {
            #region
            DataRow[] drArr = ds.Tables[0].Select(MenuData.parentId + "=" + parentId.ToString()); //可取记录数到最后条数时卡符号
            DataRow[] drparent;
            int i = 0;
            string eventname = "";
            foreach (DataRow dr in drArr)
            {
                drparent = ds.Tables[0].Select(MenuData.parentId + "=" + dr[MenuData.currentId].ToString());
                eventname = dr[MenuData.eventName].ToString();
                json += "{";
                json += "id:'" + dr[MenuData.currentId].ToString() + "',";
                json += "text:'" + dr[MenuData.menuName].ToString() + "',";
                json += "expanded:true,";
                if (eventname != "")
                    json += "hrefTarget:'" + dr[MenuData.eventName].ToString() + "',";

                json += "iconCls:'" + dr[MenuData.iconCls].ToString() + "'";
                if (drparent.Length > 0)
                    json += ",children:[";
                else
                    json += ",leaf:true";

                i++;
                iteratorSystemMenu(ds, dr[MenuData.currentId].ToString(), ref json);
                json += "},";
                if (i == drArr.Length)
                {
                    json = json.Remove(json.Length - 1);
                    json += "]";
                }
            }
            #endregion
        }
        /// <summary>
        /// 菜单维护时获取菜单数据
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public string GetMenuTree(string roleId)
        {
            #region
            string menulistjson = "";
            MenuData menulistdata = new MenuData();
            this._menuclass.GetSingleTAllWithoutCount(menulistdata, null);
            menulistjson += "{ \"text\":\".\",\"children\": [";

            string treejson = "";
            this.iteratorTree(menulistdata, "0", ref treejson);

            treejson = treejson.Remove(treejson.Length - 1, 1);

            menulistjson += treejson + "]}";
            return menulistjson;
            #endregion
        }
        /// <summary>
        /// 递归获取各系统下的树形列表
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="parentId"></param>
        /// <param name="json"></param>
        private void iteratorTree(DataSet ds, string parentId, ref String json)
        {
            #region
            DataRow[] drArr = ds.Tables[0].Select(MenuData.parentId + "=" + parentId.ToString()); //可取记录数到最后条数时卡符号
            DataRow[] drparent;
            int i = 0;
            string eventname = "";
            foreach (DataRow dr in drArr)
            {
                drparent = ds.Tables[0].Select(MenuData.parentId + "=" + dr[MenuData.currentId].ToString());
                eventname = dr[MenuData.eventName].ToString();
                if (string.IsNullOrEmpty(eventname))
                    eventname = dr[MenuData.htmlurl].ToString();

                json += "{";
                json += MenuData.menuId + ":'" + dr[MenuData.menuId].ToString() + "',";
                json += MenuData.currentId + ":'" + dr[MenuData.currentId].ToString() + "',";
                json += "parentId_new:'" + dr[MenuData.parentId].ToString() + "',";
                json += MenuData.menuName + ":'" + dr[MenuData.menuName].ToString() + "',";
                json += MenuData.iconCls + ":'" + dr[MenuData.iconCls].ToString() + "',";
                json += MenuData.htmlurl + ":'" + dr[MenuData.htmlurl].ToString() + "',";
                json += MenuData.eventName + ":'" + eventname + "',";
                json += MenuData.sort + ":'" + dr[MenuData.sort].ToString() + "',";
                json += MenuData.usable + ":" + dr[MenuData.usable].ToString().ToLower() + ",";
                json += "expanded:true,";

                if (drparent.Length > 0)
                    json += "children:[";
                else
                    json += "leaf:true";

                i++;
                iteratorTree(ds, dr[MenuData.currentId].ToString(), ref json);
                json += "},";
                if (i == drArr.Length)
                {
                    json = json.Remove(json.Length - 1);
                    json += "]";
                }
            }
            #endregion
        }

        /// <summary>
        /// 维护权限时显示的菜单（附带是否赋予权限）
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="usable"></param>
        /// <returns></returns>
        public string GetRoleControlMenu(string roleId)
        {
            #region
            string menulistjson = "";
            RoleControlMenuClass rolecontrolmenuclass = new RoleControlMenuClass();

            DataSet menulistdata = rolecontrolmenuclass.GetControlMenu(Convert.ToInt16(roleId));
            menulistjson += "{ \"text\":\".\",\"checked\": true,\"children\": [";

            string treejson = "";
            this.iteratorControlMenu(menulistdata, "0", ref treejson);

            treejson = treejson.Remove(treejson.Length - 1, 1);

            menulistjson += treejson + "]}";
            return menulistjson;
            #endregion
        }
        /// <summary>
        /// 递归获取各系统下的树形列表
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="parentId"></param>
        /// <param name="json"></param>
        private void iteratorControlMenu(DataSet ds, string parentId, ref String json)
        {
            #region
            DataRow[] drArr = ds.Tables[0].Select(MenuData.parentId + "=" + parentId.ToString()); //可取记录数到最后条数时卡符号
            DataRow[] drparent;
            int i = 0;
            string eventname = "";
            foreach (DataRow dr in drArr)
            {
                drparent = ds.Tables[0].Select(MenuData.parentId + "=" + dr[MenuData.currentId].ToString());
                eventname = dr[MenuData.eventName].ToString();
                if (string.IsNullOrEmpty(eventname))
                    eventname = dr[MenuData.htmlurl].ToString();

                json += "{";
                json += "id:'" + dr[MenuData.menuId].ToString() + "',";
                json += MenuData.currentId + ":'" + dr[MenuData.currentId].ToString() + "',";
                json += "parentId:'" + dr[MenuData.parentId].ToString() + "',";
                json += "text:'" + dr[MenuData.menuName].ToString() + "',";
                json += MenuData.iconCls + ":'" + dr[MenuData.iconCls].ToString() + "',";
                json += MenuData.htmlurl + ":'" + dr[MenuData.htmlurl].ToString() + "',";
                json += MenuData.eventName + ":'" + eventname + "',";
                json += MenuData.sort + ":'" + dr[MenuData.sort].ToString() + "',";
                json += MenuData.usable + ":'" + dr[MenuData.usable].ToString() + "',";
                json += "expanded: true,";
                json += "checked:" + dr["Checked"].ToString() + ",";

                if (drparent.Length > 0)
                    json += "children:[";
                else
                    json += "leaf:true";

                i++;
                iteratorControlMenu(ds, dr[MenuData.currentId].ToString(), ref json);
                json += "},";
                if (i == drArr.Length)
                {
                    json = json.Remove(json.Length - 1);
                    json += "]";
                }
            }
            #endregion
        }
    }
}


