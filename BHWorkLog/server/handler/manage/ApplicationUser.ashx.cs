using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SystemBusiness;
using SystemDataLibrary;

namespace BHWorkLog.server.handler.manage
{

    public class ApplicationUser : PageHandlerBase, IHttpHandler
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-06 18:45:16
        ***公司：山西博华科技有限公司
        ***友情提示：本处业务可根据实际业务进行修改；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region private member variables
        private EntityApplicationUser applicationuser = new EntityApplicationUser();
        private ApplicationUserBusiness applicationuserclass = new ApplicationUserBusiness();
        private ApplicationUserData applicationuserdata = new ApplicationUserData();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region
            this.applicationuser.telephone = requestObject.Params[ApplicationUserData.telephone];
            this.applicationuser.isTotal = requestObject.Params[ApplicationUserData.isTotal];
            this.applicationuser.userid = requestObject.Params[ApplicationUserData.userid];
            this.applicationuser.Username = requestObject.Params[ApplicationUserData.Username];
            this.applicationuser.roleId = requestObject.Params[ApplicationUserData.roleId];
            this.applicationuser.organizationId = requestObject.Params[ApplicationUserData.organizationId];
            this.applicationuser.fullName = requestObject.Params[ApplicationUserData.fullName];
            this.applicationuser.passWord = requestObject.Params[ApplicationUserData.passWord];
            this.applicationuser.email = requestObject.Params[ApplicationUserData.email];
            this.applicationuser.usable = requestObject.Params[ApplicationUserData.usable];
            this.applicationuser.loginTimes = requestObject.Params[ApplicationUserData.loginTimes];
            this.applicationuser.lastLoginTime = requestObject.Params[ApplicationUserData.lastLoginTime];
            this.applicationuser.writeTime = requestObject.Params[ApplicationUserData.writeTime];
            this.applicationuser.writeUser = requestObject.Params[ApplicationUserData.writeUser];
            this.applicationuser.writeIp = requestObject.Params[ApplicationUserData.writeIp];
            this.applicationuser.isMarry = requestObject.Params[ApplicationUserData.isMarry];
            this.applicationuser.birthday = requestObject.Params[ApplicationUserData.birthday];
            this.applicationuser.household = requestObject.Params[ApplicationUserData.household];
            this.applicationuser.oldHome = requestObject.Params[ApplicationUserData.oldHome];
            this.applicationuser.nowLiveHome = requestObject.Params[ApplicationUserData.nowLiveHome];
            this.applicationuser.intoCompanyDate = requestObject.Params[ApplicationUserData.intoCompanyDate];
            this.applicationuser.workTotalYear = requestObject.Params[ApplicationUserData.workTotalYear];
            this.applicationuser.still = requestObject.Params[ApplicationUserData.still];
            this.applicationuser.maxEducation = requestObject.Params[ApplicationUserData.maxEducation];
            this.applicationuser.maxEduCollege = requestObject.Params[ApplicationUserData.maxEduCollege];
            this.applicationuser.maxEduLeaveTime = requestObject.Params[ApplicationUserData.maxEduLeaveTime];
            this.applicationuser.workExperiences = requestObject.Params[ApplicationUserData.workExperiences];
            this.applicationuser.studyExperiences = requestObject.Params[ApplicationUserData.studyExperiences];
            this.applicationuser.photoUrl = requestObject.Params[ApplicationUserData.photoUrl];
            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.applicationuserclass.GetJsonByPage(applicationuser, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.applicationuserclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            applicationuser.writeUser = this.SessionUserId;
            applicationuser.writeIp = this.SessionUserIp;

            this.applicationuserclass.AddRow(ref applicationuserdata, applicationuser);

            json = this.applicationuserclass.SaveApplicationUser(applicationuserdata);
            #endregion
        }
        /// <summary>
        /// 注册新用户（首页）
        /// </summary>
        /// <param name="json"></param>
        private void ActionRegister(ref string json)
        {
            #region
            this.applicationuser.lastLoginTime = DateTime.Now.ToString();
            this.applicationuser.loginTimes = "1";
            this.ActionAddNew(ref json);
            this.SessionUserId = this.applicationuser.userid;
            this.SessionRoleId = this.applicationuser.roleId;
            this.SessionUserName = this.applicationuser.Username;
            this.SessionFullname = this.applicationuser.fullName;

            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            applicationuser.writeUser = this.SessionUserId;

            this.applicationuserclass.EditRow(ref applicationuserdata, applicationuser);

            json = this.applicationuserclass.SaveApplicationUser(applicationuserdata);
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.applicationuserclass.DeleteRow(ref applicationuserdata, applicationuser.userid);
            json = this.applicationuserclass.SaveApplicationUser(applicationuserdata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            applicationuserclass.OutputExcel(fileName, base.GetExcelParams(), this.applicationuser);
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
            string username = context.Request.Params["userName"];
            string password = context.Request.Params["passWord"];
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
                    this.ActionOutputExcel("用户信息.xls");
                    break;
                case "outputaddress":
                    this.applicationuserclass.OutputAddressBook("address.xls");
                    break;
                //用户注册
                case "register":
                    json = applicationuserclass.CheckUserregister(username);
                    if (json == "{\"success\":\"true\"}")
                    {
                        this.ActionRegister(ref json);
                    }
                    break;
                case "registercheck":                                                           
                     json=applicationuserclass.CheckUserregister(username) ;//判断用户名是否可用                                                                                                 
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
    /// ApplicationUser 的摘要说明
    /// </summary>
    public class ApplicationUser : PageHandlerBase, IHttpHandler
    {

        /// <summary>
        /// 获取从前台post来的各参数
        /// </summary>
        /// <param name="requestObject">post来的请求对象</param>
        /// <param name="userid">用户编号</param>
        /// <param name="Username">用户名</param>
        /// <param name="roleId">所属角色编号</param>
        /// <param name="organizationId">组织机构编号</param>
        /// <param name="fullName">全名</param>
        /// <param name="passWord">密码（MD5）</param>
        /// <param name="email">电子邮箱地址</param>
        /// <param name="usable">可用性</param>
        /// <param name="loginTimes">登录次数</param>
        /// <param name="lastLoginTime">上次登录时刻</param>
        /// <param name="writeTime">录入时刻</param>
        /// <param name="writeUser">录入人</param>
        /// <param name="writeIp">ip地址</param>
        private void getPostParams(HttpRequest requestObject, out String userid, 
            out String Username, out String roleId, out String organizationId, 
            out String fullName, out String passWord, out String email, 
            out String usable, out String loginTimes, out String lastLoginTime, 
            out String writeTime, out String writeUser, out String writeIp)
        {
            #region
            userid = requestObject.Params[ApplicationUserData.userid];
            Username = requestObject.Params[ApplicationUserData.Username];
            roleId = requestObject.Params[ApplicationUserData.roleId];
            organizationId = requestObject.Params[ApplicationUserData.organizationId];
            fullName = requestObject.Params[ApplicationUserData.fullName];
            passWord = requestObject.Params[ApplicationUserData.passWord];
            email = requestObject.Params[ApplicationUserData.email];
            usable = requestObject.Params[ApplicationUserData.usable];
            loginTimes = requestObject.Params[ApplicationUserData.loginTimes];
            lastLoginTime = requestObject.Params[ApplicationUserData.lastLoginTime];
            writeTime = requestObject.Params[ApplicationUserData.writeTime];
            writeUser = requestObject.Params[ApplicationUserData.writeUser];
            writeIp = requestObject.Params[ApplicationUserData.writeIp];
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
            String userid, username, roleid, organizationid, fullname, password, 
                email, usable, logintimes, lastlogintime, writetime, writeuser, writeip;

            int start = Convert.ToInt32(context.Request.Params["start"]);
            int limit = Convert.ToInt32(context.Request.Params["limit"]);
            int pageindex = 0;
            if (limit != 0)
                pageindex = (limit + start) / limit;
            String json = "";
            //同业务层开始交互
            ApplicationUserBusiness applicationuserclass = new ApplicationUserBusiness();
            ApplicationUserData applicationuserdata = new ApplicationUserData();
            this.getPostParams(requestobject, out userid, out username, 
                out roleid, out organizationid, out fullname, 
                out password, out email, out usable, out logintimes, 
                out lastlogintime, out writetime, out writeuser, 
                out writeip);

            switch (action)
            {
                case "list":
                    json = applicationuserclass.GetJsonByPage(limit, pageindex, userid, username, 
                        roleid, organizationid, fullname, password, email, 
                        usable, logintimes, lastlogintime, writetime, writeuser, writeip);
                    break;
                case "viewall":
                    json = applicationuserclass.GetJsonByAll();
                    break;
                case "add":
                    applicationuserclass.AddRow(ref applicationuserdata, userid, username, 
                        roleid, organizationid, fullname, password, email, usable, logintimes, 
                        lastlogintime, writetime, this.SessionUserId, this.SessionUserIp);
                    json = applicationuserclass.SaveApplicationUser(applicationuserdata);
                    break;
                case "update":
                    applicationuserclass.EditRow(ref applicationuserdata, userid, username, 
                        roleid, organizationid, fullname, password, email, usable, logintimes, 
                        lastlogintime, writetime, writeuser, writeip);
                    json = applicationuserclass.SaveApplicationUser(applicationuserdata);
                    break;
                case "delete":
                    applicationuserclass.DeleteRow(ref applicationuserdata, userid);
                    json = applicationuserclass.SaveApplicationUser(applicationuserdata);
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