using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemBusiness;
using SystemDataLibrary;

namespace BHWorkLog.server.handler.manage
{
    public class Menu : PageHandlerBase, IHttpHandler
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-06 18:02:12
        ***公司：山西博华科技有限公司
        ***友情提示：本处业务可根据实际业务进行修改；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region private member variables
        private EntityMenu menu = new EntityMenu();
        private MenuBusiness menuclass = new MenuBusiness();
        private MenuData menudata = new MenuData();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region

            this.menu.menuId = requestObject.Params[MenuData.menuId];
            this.menu.currentId = requestObject.Params[MenuData.currentId];
            this.menu.parentId = requestObject.Params["parentId_new"];
            this.menu.menuName = requestObject.Params[MenuData.menuName];
            this.menu.iconCls = requestObject.Params[MenuData.iconCls];
            this.menu.htmlurl = requestObject.Params[MenuData.htmlurl];
            this.menu.eventName = requestObject.Params[MenuData.eventName];
            this.menu.sort = requestObject.Params[MenuData.sort];
            this.menu.usable = requestObject.Params[MenuData.usable];
            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.menuclass.GetJsonByPage(menu,base.GetPageParamsFromClient()); 
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.menuclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            //menu.writeUser = this.SessionUserId;
            //menu.writeIp = this.SessionUserIp;

            this.menuclass.AddRow(ref menudata, menu);

            json = this.menuclass.SaveMenu(menudata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            //menu.writeUser = this.SessionUserId;

            this.menuclass.EditRow(ref menudata, menu);

            json = this.menuclass.SaveMenu(menudata);
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.menuclass.DeleteRow(ref menudata, menu.menuId);
            json = this.menuclass.SaveMenu(menudata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            menuclass.OutputExcel(fileName, base.GetExcelParams(), this.menu);
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
                    this.ActionEdit(ref json);
                    break;
                case "delete":
                    this.ActionDelete(ref json);
                    break;
                case "outputexcel":
                    this.ActionOutputExcel("文件名.xls");
                    break;
                case "listtree":
                    json = this.menuclass.GetMenuTree(null);
                    break;
                case "logon":               
                    json = this.menuclass.GetSystemMenuList(base.SessionRoleId, base.SessionUserId);
                    break;                
                case "listbyrolecontrol":
                    String roleid = requestobject.QueryString["roleId"];
                    json = this.menuclass.GetRoleControlMenu(roleid);
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
}