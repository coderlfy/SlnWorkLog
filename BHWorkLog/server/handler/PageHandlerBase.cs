using ExportExcelLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Fundation.Core;

namespace BHWorkLog.server.handler
{
    public class PageHandlerBase : IRequiresSessionState
    {
        #region 定义全局Session
        /// <summary>
        /// 用户编号
        /// </summary>
        private const string constUserId = "userId";
        public String SessionUserId
        {
            #region
            get
            {
                object ret = HttpContext.Current.Session[constUserId];
                if (ret == null)
                    HttpContext.Current.Session[constUserId] = "";
                return (String)HttpContext.Current.Session[constUserId];
            }
            set
            {
                HttpContext.Current.Session[constUserId] = value;
            }
            #endregion
        }
        /// <summary>
        /// 用户名
        /// </summary>
        private const string constUserName = "username";
        public String SessionUserName
        {
            #region
            get
            {
                object ret = HttpContext.Current.Session[constUserName];
                if (ret == null)
                    HttpContext.Current.Session[constUserName] = "";
                return (String)HttpContext.Current.Session[constUserName];
            }
            set
            {
                HttpContext.Current.Session[constUserName] = value;
            }
            #endregion
        }
        /// <summary>
        /// 权限角色编号
        /// </summary>
        private const string constRoleId = "roleId";
        public String SessionRoleId
        {
            #region
            get
            {
                object ret = HttpContext.Current.Session[constRoleId];
                if (ret == null)
                    HttpContext.Current.Session[constRoleId] = "";
                return (String)HttpContext.Current.Session[constRoleId];
            }
            set
            {
                HttpContext.Current.Session[constRoleId] = value;
            }
            #endregion
        }
        /// <summary>
        /// 全名（普通用户为applicationuser表的fullname，其他级别用户为usbkey中的fullname）
        /// </summary>
        private const string constFullname = "fullname";
        public String SessionFullname
        {
            #region
            get
            {
                object ret = HttpContext.Current.Session[constFullname];
                if (ret == null)
                    HttpContext.Current.Session[constFullname] = "";
                return (String)HttpContext.Current.Session[constFullname];
            }
            set
            {
                HttpContext.Current.Session[constFullname] = value;
            }
            #endregion
        }
        private const string constUserIp = "userIp";
        /// <summary>
        /// 用户IP
        /// </summary>
        public String SessionUserIp
        {
            #region
            get
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            #endregion
        }
        #endregion

        #region Handle全局方法
        /// <summary>
        /// 获取页面传来的分页参数（显示分页列表时可用）
        /// </summary>
        /// <returns></returns>
        public PageParams GetPageParamsFromClient()
        {
            #region
            PageParams pageparams = new PageParams();
            int start = Convert.ToInt32(HttpContext.Current.Request.Params["start"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request.Params["limit"]);
            int pageindex = 0;
            if (limit != 0)
                pageindex = (limit + start) / limit;

            pageparams.PageIndex = pageindex;
            pageparams.PageSize = limit;

            return pageparams;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ExtjsGrid GetExcelParams()
        {
            #region
            string viewcolumnnames = HttpContext.Current.Request.Params["viewcolumnnames"];
            string hiddens = HttpContext.Current.Request.Params["hiddens"];
            string columnstitle = HttpContext.Current.Request.Params["columnstitle"];

            ExtjsGrid grid = new ExtjsGrid();
            grid.ViewColumnNames = viewcolumnnames;
            grid.ColumnsHidden = hiddens;
            grid.ViewTitleNames = columnstitle;

            return grid;
            #endregion
        }
        #endregion
    }
}
