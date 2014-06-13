using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemBusiness;
using SystemDataLibrary;

namespace BHWorkLog.server.handler.manage
{

    public class RoleControlMenu : PageHandlerBase, IHttpHandler
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-06 18:48:52
        ***公司：山西ICat Studio有限公司
        ***友情提示：本处业务可根据实际业务进行修改；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region private member variables
        private EntityRoleControlMenu rolecontrolmenu = new EntityRoleControlMenu();
        private RoleControlMenuBusiness rolecontrolmenuclass = new RoleControlMenuBusiness();
        private RoleControlMenuData rolecontrolmenudata = new RoleControlMenuData();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region

            this.rolecontrolmenu.setId = requestObject.Params[RoleControlMenuData.setId];
            this.rolecontrolmenu.menuId = requestObject.Params[RoleControlMenuData.menuId];
            this.rolecontrolmenu.roleId = requestObject.Params[RoleControlMenuData.roleId];
            this.rolecontrolmenu.userid = requestObject.Params[RoleControlMenuData.userid];
            this.rolecontrolmenu.writeIp = requestObject.Params[RoleControlMenuData.writeIp];
            this.rolecontrolmenu.writeTime = requestObject.Params[RoleControlMenuData.writeTime];
            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.rolecontrolmenuclass.GetJsonByPage(rolecontrolmenu, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.rolecontrolmenuclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            //rolecontrolmenu.writeUser = this.SessionUserId;
            rolecontrolmenu.writeIp = this.SessionUserIp;

            this.rolecontrolmenuclass.AddRow(ref rolecontrolmenudata, rolecontrolmenu);

            json = this.rolecontrolmenuclass.SaveRoleControlMenu(rolecontrolmenudata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            //rolecontrolmenu.writeUser = this.SessionUserId;

            this.rolecontrolmenuclass.EditRow(ref rolecontrolmenudata, rolecontrolmenu);

            json = this.rolecontrolmenuclass.SaveRoleControlMenu(rolecontrolmenudata);
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.rolecontrolmenuclass.DeleteRow(ref rolecontrolmenudata, rolecontrolmenu.setId);
            json = this.rolecontrolmenuclass.SaveRoleControlMenu(rolecontrolmenudata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            rolecontrolmenuclass.OutputExcel(fileName, base.GetExcelParams(), this.rolecontrolmenu);
            #endregion
        }
        #endregion

        #region public member functons entry point
        /// <summary>
        /// 处理请求的过程，当前台页面调用本文件时，自动执行本方法。
        /// </summary>
        /// <param name="context">上下文</param>
        public void ProcessRequest(HttpContext context)
        {
            #region
            HttpRequest requestobject = context.Request;
            String action = requestobject.QueryString["action"];
            String json = "";
            //同业务层开始交互

            this.getPostParams(requestobject);

            context.Response.ContentType = "text/json";
            switch (action)
            {
                case "list":
                    this.ActionList(ref json);
                    break;
                case "viewall":
                    this.ActionGetAll(ref json);
                    break;
                case "add":
                    this.ActionAddNew(ref json);
                    break;
                case "update":
                    json = rolecontrolmenuclass.updateRoleControlMenu(rolecontrolmenu.setId,
                        rolecontrolmenu.menuId, rolecontrolmenu.roleId, rolecontrolmenu.userid, 
                        rolecontrolmenu.writeIp, rolecontrolmenu.writeTime);
                    break;
                case "delete":
                    this.ActionDelete(ref json);
                    break;
                case "outputexcel":
                    this.ActionOutputExcel("文件名.xls");
                    break;
                default:
                    break;
            }
            context.Response.Write(json);
            #endregion
        }

        public bool IsReusable
        {
            #region
            get
            {
                return false;
            }
            #endregion
        }
        #endregion

        #endregion
    }
    /*
    /// <summary>
    /// RoleControlMenu 的摘要说明
    /// </summary>
    public class RoleControlMenu : PageHandlerBase, IHttpHandler 
    {

        /// <summary>
        /// 获取从前台post来的各参数
        /// </summary>
        /// <param name="requestObject">post来的请求对象</param>
        /// <param name="setId">角色控制菜单-编号</param>
        /// <param name="menuId">菜单编号</param>
        /// <param name="roleId">权限角色编号</param>
        /// <param name="userid">用户编号</param>
        /// <param name="writeIp">录入IP</param>
        /// <param name="writeTime">录入时间</param>
        private void getPostParams(HttpRequest requestObject, out String setId, out String menuId, out String roleId, out String userid, out String writeIp, out String writeTime)
        {
            #region
            setId = requestObject.Params[RoleControlMenuData.setId];
            menuId = requestObject.Params[RoleControlMenuData.menuId];
            roleId = requestObject.Params[RoleControlMenuData.roleId];
            userid = requestObject.Params[RoleControlMenuData.userid];
            writeIp = requestObject.Params[RoleControlMenuData.writeIp];
            writeTime = requestObject.Params[RoleControlMenuData.writeTime];
            #endregion
        }
        /// <summary>
        /// 处理请求的过程，当前台页面调用本文件时，自动执行本方法。
        /// </summary>
        /// <param name="context">上下文</param>
        public void ProcessRequest(HttpContext context)
        {
            #region
            HttpRequest requestobject = context.Request;
            String action = requestobject.QueryString["action"];
            //申明post来的参数
            String setid, menuid, roleid, userid, writeip, writetime;
            int start = 0;// Convert.ToInt32(context.Request.Params["start"]);
            int limit = 15;//Convert.ToInt32(context.Request.Params["limit"]);
            String json = "";
            //同业务层开始交互
            RoleControlMenuBusiness rolecontrolmenuclass = new RoleControlMenuBusiness();
            RoleControlMenuData rolecontrolmenudata = new RoleControlMenuData();
            MenuData menudata = new MenuData();
            this.getPostParams(requestobject, out setid, out menuid, out roleid, out userid, out writeip, out writetime);
            int pageindex = (limit + start) / limit;

            switch (action)
            {
                case "update":
                    json = rolecontrolmenuclass.updateRoleControlMenu(setid,menuid,roleid,userid, writeip,writetime);
                    break;
                default:
                    break;
            }
            context.Response.ContentType = "text/json";
            context.Response.Write(json);
            #endregion
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
     * */
}