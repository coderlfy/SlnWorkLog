using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemBusiness;
using SystemDataLibrary;

namespace BHWorkLog.server.handler.manage
{

    public class SystemRole : PageHandlerBase, IHttpHandler
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-06 18:46:21
        ***公司：山西ICat Studio有限公司
        ***友情提示：本处业务可根据实际业务进行修改；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region private member variables
        private EntitySystemRole systemrole = new EntitySystemRole();
        private SystemRoleBusiness systemroleclass = new SystemRoleBusiness();
        private SystemRoleData systemroledata = new SystemRoleData();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region

            this.systemrole.roleId = requestObject.Params[SystemRoleData.roleId];
            this.systemrole.roleName = requestObject.Params[SystemRoleData.roleName];
            this.systemrole.usable = requestObject.Params[SystemRoleData.usable];
            this.systemrole.remark = requestObject.Params[SystemRoleData.remark];
            this.systemrole.sort = requestObject.Params[SystemRoleData.sort];
            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.systemroleclass.GetJsonByPage(systemrole, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.systemroleclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            //systemrole.writeUser = this.SessionUserId;
            //systemrole.writeIp = this.SessionUserIp;

            this.systemroleclass.AddRow(ref systemroledata, systemrole);

            json = this.systemroleclass.SaveSystemRole(systemroledata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            //systemrole.writeUser = this.SessionUserId;

            this.systemroleclass.EditRow(ref systemroledata, systemrole);

            json = this.systemroleclass.SaveSystemRole(systemroledata);
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.systemroleclass.DeleteRow(ref systemroledata, systemrole.roleId);
            json = this.systemroleclass.SaveSystemRole(systemroledata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            systemroleclass.OutputExcel(fileName, base.GetExcelParams(), this.systemrole);
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
    /// SystemRole 的摘要说明
    /// </summary>
    public class SystemRole : PageHandlerBase, IHttpHandler
    {

        /// <summary>
        /// 获取从前台post来的各参数
        /// </summary>
        /// <param name="requestObject">post来的请求对象</param>
        /// <param name="roleId">权限角色编号</param>
        /// <param name="roleName">权限组名称（角色）</param>
        /// <param name="usable">是否可用（true可用）</param>
        /// <param name="remark">备注</param>
        /// <param name="sort">排序</param>
        private void getPostParams(HttpRequest requestObject, out String roleId, out String roleName, out String usable, out String remark, out String sort)
        {
            #region
            roleId = requestObject.Params[SystemRoleData.roleId];
            roleName = requestObject.Params[SystemRoleData.roleName];
            usable = requestObject.Params[SystemRoleData.usable];
            remark = requestObject.Params[SystemRoleData.remark];
            sort = requestObject.Params[SystemRoleData.sort];
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
            String roleid, rolename, usable, remark, sort;
            int start = Convert.ToInt32(context.Request.Params["start"]);
            int limit = Convert.ToInt32(context.Request.Params["limit"]);

            String json = "";
            //同业务层开始交互
            SystemRoleBusiness systemroleclass = new SystemRoleBusiness();
            SystemRoleData systemroledata = new SystemRoleData();

            this.getPostParams(requestobject, out roleid, out rolename, out usable, out remark, out sort);
            int pageindex = 0;
            if (limit != 0)
                pageindex = (limit + start) / limit;
            switch (action)
            {
                case "list":
                    json = systemroleclass.GetJsonByPage(limit, pageindex, roleid, rolename, usable, remark, sort);
                    break;
                case "all":
                    json = "{\"good\":true}";
                    break;
                case "viewall":
                    json = systemroleclass.GetJsonByAll();
                    break;
                default:
                    break;
            }
            context.Response.ContentType = "text/json";
            context.Response.Write(json);
            #endregion
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
     * */
}