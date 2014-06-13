using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemBusiness;
using SystemDataLibrary;


namespace BHWorkLog.server.handler.manage
{
    /// <summary>
    /// updapwd 的摘要说明
    /// </summary>
    public class ModifyPassword : PageHandlerBase, IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            #region
            HttpRequest requestobject = context.Request;
            String action = requestobject.QueryString["action"];
            String json = "";
            //同业务层开始交互
            ApplicationUserBusiness applicationuserclass = new ApplicationUserBusiness();
            ApplicationUserData applicationuserdata = new ApplicationUserData();
            switch (action)
            {
                case "update":
                    string userid = context.Request.Params["userid"];
                    string clientip = context.Request.Params["clientip"];
                    string oldPwd = context.Request.Params["oldpwd"];
                    string newpwd = context.Request.Params["newpwd"];


                    json = applicationuserclass.UpdateSysUserPwd(userid, oldPwd, newpwd);

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
}