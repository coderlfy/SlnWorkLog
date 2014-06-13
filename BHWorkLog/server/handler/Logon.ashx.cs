using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SystemBusiness;
using SystemDataLibrary;

namespace BHWorkLog.server.handler
{
    /// <summary>
    /// Logon 的摘要说明
    /// </summary>
    public class Logon : PageHandlerBase, IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string json = "";
            String action = context.Request.QueryString["action"];
            string roleid = "", userid = "", fullname = "";

            ApplicationUserBusiness applicationuserclass = new ApplicationUserBusiness();
            ApplicationUserData applicationuserdata = new ApplicationUserData();
            switch (action)
            {
                case "logon":
                    string username = context.Request.Params["userName"];
                    string password = context.Request.Params["passWord"];

                    json = applicationuserclass.CheckUserlogon(username, password, ref roleid, ref userid, ref fullname);
                    this.SessionUserId = userid;
                    this.SessionRoleId = roleid;
                    this.SessionUserName = username;
                    this.SessionFullname = fullname;
                    break;
                case "indexgetsession":
                    json = applicationuserclass.GetAppParameters(context, this.SessionUserName, this.SessionFullname);
                    break;
                default:
                    break;
            }

            context.Response.ContentType = "text/json";
            context.Response.Write(json);
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
