/****************************************
***创建人：bhlfy
***创建时间：2013-08-29 03:00:29
***公司：iCat Studio
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Fundation.Core
{
    public class SystemPlatform
    {
        /// <summary>
        /// 因为程序部署在服务端，对于最终用户来说，localAddr指向的是服务端本身。
        /// </summary>
        private const string serverIpName = "Local_Addr";
        private const string clientIpName = "Remote_Addr";
        private const string developbyName = "developby";
        private const string contactusName = "contactus";
        private const string developbyDefault = "iCat Studio";
        private const string contactusDefault = "13403692778";

        private HttpContext _context = null;

        public SystemPlatform(HttpContext context)
        {
            this._context = context;
        }

        public string GetServerIp()
        {
            return this._context.Request.ServerVariables.Get(serverIpName);
        }

        public string GetClientIp()
        {
            return this._context.Request.ServerVariables.Get(clientIpName);
        }

        public string GetBrowserName()
        {
            return this._context.Request.Browser.Browser;
        }

        public string GetBrowserVersion()
        {
            return this._context.Request.Browser.MajorVersion.ToString();
        }

        public string GetClientOS()
        {
            return this._context.Request.Browser.Platform;
        }

        public string GetDevelopBy()
        {
            string developby = Config.Get(developbyName);
            return developby == null ? developbyDefault : developby;
        }

        public string GetContactUs()
        {
            string contactus = Config.Get(contactusName);
            return contactus == null ? contactusDefault : contactus;
        }
    }
}
