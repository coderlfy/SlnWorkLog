using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using SystemBusiness;
using SystemDataLibrary;

namespace BHWorkLog
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            #region
            
            Exception ex = Server.GetLastError();
            if (this.Session["userId"].ToString() != "")
            {
                string userid, userip;
                userid = this.Session["userId"].ToString();
                userip = Request.UserHostAddress;
                ErrorLogsBusiness errorlogclass = new ErrorLogsBusiness();
                ErrorLogsData errorlogsdata = new ErrorLogsData();
                EntityErrorLogs errorlogs = new EntityErrorLogs();
                errorlogs.errorId = "1";
                errorlogs.userid = userid;
                errorlogs.writeIp = userip;
                errorlogs.writeTime = DateTime.Now.ToString();
                errorlogs.Content = ex.ToString().Replace("\"", "").Replace("\r\n", "");

                errorlogclass.AddRow(ref errorlogsdata, errorlogs);

                errorlogclass.SaveErrorLogs(errorlogsdata);
            }
            
            #endregion
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}