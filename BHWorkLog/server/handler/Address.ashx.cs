using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemBusiness;

namespace BHWorkLog.server.handler
{
    /// <summary>
    /// Address 的摘要说明
    /// </summary>
    public class Address : PageHandlerBase, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            #region
            HttpRequest requestobject = context.Request;
            AddressBusiness addressbusiness = new AddressBusiness();
            String action = requestobject.QueryString["action"];
            String json = "";
            //同业务层开始交互
            switch (action)
            {
                case "viewcity":
                    json = addressbusiness.GetCity(23);
                    break;
                case "viewcounty":
                    json = addressbusiness.GetCounty(23);
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