/****************************************
***创建人：bhlfy
***创建时间：2013-04-06 17:31:07
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using System;
using System.Data;

using SystemDataLibrary;
using SystemSqlLibrary;
using System.Web;
using System.Reflection;
using ExportExcelLib;
using ExportExcelLib.business;
using BusinessBase;
using Fundation.Core;

namespace SystemBusiness
{
    public class ApplicationUserBusiness : GeneralBusinesser
    {
        private ApplicationUserClass _applicationuserclass = new ApplicationUserClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-06 17:31:07
        ***公司：山西ICat Studio有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        
        /// <summary>
        /// 根据条件筛选所有ApplicationUser指定页码的数据（分页型）
        /// </summary>
        /// <param name="applicationuser">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityApplicationUser applicationuser, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet applicationuserdata = this.GetData(applicationuser, pageparams, out totalCount);
            return base.GetJson(applicationuserdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存applicationuserdata数据集数据
        /// </summary>
        /// <param name="applicationuserdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveApplicationUser(ApplicationUserData applicationuserdata)
        {
            #region
            ApplicationUserClass applicationuserclass = new ApplicationUserClass();
            return base.Save(applicationuserdata, applicationuserclass);
            #endregion
        }
                
        /// <summary>
        /// 添加ApplicationUser表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="applicationuserdata">数据集对象</param>
        /// <param name="applicationuser">实体对象</param>
        public void AddRow(ref ApplicationUserData applicationuserdata, EntityApplicationUser applicationuser)
        {
            #region
            applicationuser.userid = _applicationuserclass.GetMaxAddOne(applicationuserdata).ToString();
            DataRow dr = applicationuserdata.Tables[0].NewRow();
            applicationuserdata.Assign(dr, ApplicationUserData.userid, applicationuser.userid);
            applicationuserdata.Assign(dr, ApplicationUserData.Username, applicationuser.Username);
            applicationuserdata.Assign(dr, ApplicationUserData.roleId, applicationuser.roleId);
            applicationuserdata.Assign(dr, ApplicationUserData.organizationId, applicationuser.organizationId);
            applicationuserdata.Assign(dr, ApplicationUserData.fullName, applicationuser.fullName);
            applicationuserdata.Assign(dr, ApplicationUserData.passWord, Password.ToMD5(applicationuser.passWord));
            applicationuserdata.Assign(dr, ApplicationUserData.telephone, applicationuser.telephone);
            applicationuserdata.Assign(dr, ApplicationUserData.isTotal, applicationuser.isTotal);
            applicationuserdata.Assign(dr, ApplicationUserData.email, applicationuser.email);
            applicationuserdata.Assign(dr, ApplicationUserData.usable, applicationuser.usable);
            applicationuserdata.Assign(dr, ApplicationUserData.loginTimes, applicationuser.loginTimes);
            applicationuserdata.Assign(dr, ApplicationUserData.lastLoginTime, applicationuser.lastLoginTime);
            applicationuserdata.Assign(dr, ApplicationUserData.writeTime, applicationuser.writeTime);
            applicationuserdata.Assign(dr, ApplicationUserData.writeUser, applicationuser.writeUser);
            applicationuserdata.Assign(dr, ApplicationUserData.writeIp, applicationuser.writeIp);
            applicationuserdata.Assign(dr, ApplicationUserData.isMarry, applicationuser.isMarry);
            applicationuserdata.Assign(dr, ApplicationUserData.birthday, applicationuser.birthday);
            applicationuserdata.Assign(dr, ApplicationUserData.household, applicationuser.household);
            applicationuserdata.Assign(dr, ApplicationUserData.oldHome, applicationuser.oldHome);
            applicationuserdata.Assign(dr, ApplicationUserData.nowLiveHome, applicationuser.nowLiveHome);
            applicationuserdata.Assign(dr, ApplicationUserData.intoCompanyDate, applicationuser.intoCompanyDate);
            applicationuserdata.Assign(dr, ApplicationUserData.workTotalYear, applicationuser.workTotalYear);
            applicationuserdata.Assign(dr, ApplicationUserData.still, applicationuser.still);
            applicationuserdata.Assign(dr, ApplicationUserData.maxEducation, applicationuser.maxEducation);
            applicationuserdata.Assign(dr, ApplicationUserData.maxEduCollege, applicationuser.maxEduCollege);
            applicationuserdata.Assign(dr, ApplicationUserData.maxEduLeaveTime, applicationuser.maxEduLeaveTime);
            applicationuserdata.Assign(dr, ApplicationUserData.workExperiences, applicationuser.workExperiences);
            applicationuserdata.Assign(dr, ApplicationUserData.studyExperiences, applicationuser.studyExperiences);
            applicationuserdata.Assign(dr, ApplicationUserData.photoUrl, applicationuser.photoUrl);
            applicationuserdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑applicationuserdata数据集中指定的行数据
        /// </summary>
        /// <param name="applicationuserdata">数据集对象</param>
        /// <param name="applicationuser">实体对象</param>
        public void EditRow(ref ApplicationUserData applicationuserdata, EntityApplicationUser applicationuser)
        {
            #region
            if (applicationuserdata.Tables[0].Rows.Count <= 0)
                applicationuserdata = this.getData(applicationuser.userid);
            DataRow dr = applicationuserdata.Tables[0].Rows.Find(new object[1] {applicationuser.userid});
            applicationuserdata.Assign(dr, ApplicationUserData.userid, applicationuser.userid);
            applicationuserdata.Assign(dr, ApplicationUserData.Username, applicationuser.Username);
            applicationuserdata.Assign(dr, ApplicationUserData.roleId, applicationuser.roleId);
            applicationuserdata.Assign(dr, ApplicationUserData.organizationId, applicationuser.organizationId);
            applicationuserdata.Assign(dr, ApplicationUserData.fullName, applicationuser.fullName);
            //编辑的时候不动人家密码
            //applicationuserdata.Assign(dr, ApplicationUserData.passWord, Password.ToMD5(applicationuser.passWord));
            applicationuserdata.Assign(dr, ApplicationUserData.telephone, applicationuser.telephone);
            applicationuserdata.Assign(dr, ApplicationUserData.isTotal, applicationuser.isTotal);
            applicationuserdata.Assign(dr, ApplicationUserData.email, applicationuser.email);
            applicationuserdata.Assign(dr, ApplicationUserData.usable, applicationuser.usable);
            applicationuserdata.Assign(dr, ApplicationUserData.loginTimes, applicationuser.loginTimes);
            applicationuserdata.Assign(dr, ApplicationUserData.lastLoginTime, applicationuser.lastLoginTime);
            applicationuserdata.Assign(dr, ApplicationUserData.writeTime, applicationuser.writeTime);
            applicationuserdata.Assign(dr, ApplicationUserData.writeUser, applicationuser.writeUser);
            applicationuserdata.Assign(dr, ApplicationUserData.writeIp, applicationuser.writeIp);
            applicationuserdata.Assign(dr, ApplicationUserData.isMarry, applicationuser.isMarry);
            applicationuserdata.Assign(dr, ApplicationUserData.birthday, applicationuser.birthday);
            applicationuserdata.Assign(dr, ApplicationUserData.household, applicationuser.household);
            applicationuserdata.Assign(dr, ApplicationUserData.oldHome, applicationuser.oldHome);
            applicationuserdata.Assign(dr, ApplicationUserData.nowLiveHome, applicationuser.nowLiveHome);
            applicationuserdata.Assign(dr, ApplicationUserData.intoCompanyDate, applicationuser.intoCompanyDate);
            applicationuserdata.Assign(dr, ApplicationUserData.workTotalYear, applicationuser.workTotalYear);
            applicationuserdata.Assign(dr, ApplicationUserData.still, applicationuser.still);
            applicationuserdata.Assign(dr, ApplicationUserData.maxEducation, applicationuser.maxEducation);
            applicationuserdata.Assign(dr, ApplicationUserData.maxEduCollege, applicationuser.maxEduCollege);
            applicationuserdata.Assign(dr, ApplicationUserData.maxEduLeaveTime, applicationuser.maxEduLeaveTime);
            applicationuserdata.Assign(dr, ApplicationUserData.workExperiences, applicationuser.workExperiences);
            applicationuserdata.Assign(dr, ApplicationUserData.studyExperiences, applicationuser.studyExperiences);
            applicationuserdata.Assign(dr, ApplicationUserData.photoUrl, applicationuser.photoUrl);
            #endregion
        }
        		
        /// <summary>
        /// 删除applicationuserdata数据集中指定的行数据
        /// </summary>
        /// <param name="applicationuserdata">数据集对象</param>
        /// <param name="userid">主键-用户编号</param>
        public void DeleteRow(ref ApplicationUserData applicationuserdata,string userid)
        {
            #region
            if (applicationuserdata.Tables[0].Rows.Count <= 0)
                applicationuserdata = this.getData(userid);
            DataRow dr = applicationuserdata.Tables[0].Rows.Find(new object[1] { userid });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取ApplicationUser数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ApplicationUserData applicationuserdata = this.getData(null);
            totalCount = applicationuserdata.Tables[0].Rows.Count;
            return base.GetJson(applicationuserdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityApplicationUser applicationuser)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(applicationuser, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="userid">主键-用户编号</param>
        /// <returns></returns>
        public ApplicationUserData getData(string userid)
        {
            #region
            ApplicationUserData applicationuserdata = new ApplicationUserData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ApplicationUserData.userid, EnumSqlType.sqlint, EnumCondition.Equal, userid);
            this._applicationuserclass.GetSingleTAllWithoutCount(applicationuserdata, querybusinessparams);
            return applicationuserdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有ApplicationUser指定页码的数据（分页型）
        /// </summary>
        /// <param name="applicationuser">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public ApplicationUserData GetData(EntityApplicationUser applicationuser, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ApplicationUserData.userid, EnumSqlType.sqlint, 
                EnumCondition.Equal, applicationuser.userid);
            querybusinessparams.Add(ApplicationUserData.Username, EnumSqlType.nvarchar, 
                EnumCondition.LikeBoth, applicationuser.Username);
            querybusinessparams.Add(ApplicationUserData.roleId, EnumSqlType.tinyint, 
                EnumCondition.Equal, applicationuser.roleId);
            querybusinessparams.Add(ApplicationUserData.organizationId, EnumSqlType.sqlint, 
                EnumCondition.Equal, applicationuser.organizationId);
            querybusinessparams.Add(ApplicationUserData.fullName, EnumSqlType.nvarchar, 
                EnumCondition.LikeBoth, applicationuser.fullName);
            querybusinessparams.Add(ApplicationUserData.passWord, EnumSqlType.nvarchar, 
                EnumCondition.Equal, applicationuser.passWord);
            querybusinessparams.Add(ApplicationUserData.telephone, EnumSqlType.nvarchar,
                EnumCondition.Equal, applicationuser.telephone);
            querybusinessparams.Add(ApplicationUserData.isTotal, EnumSqlType.bit,
                EnumCondition.Equal, applicationuser.isTotal);
            querybusinessparams.Add(ApplicationUserData.email, EnumSqlType.nvarchar,
                EnumCondition.LikeBoth, applicationuser.email);
            querybusinessparams.Add(ApplicationUserData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, applicationuser.usable);
            querybusinessparams.Add(ApplicationUserData.loginTimes, EnumSqlType.sqlint, 
                EnumCondition.Equal, applicationuser.loginTimes);
            querybusinessparams.Add(ApplicationUserData.lastLoginTime, EnumSqlType.datetime, 
                EnumCondition.Equal, applicationuser.lastLoginTime);
            querybusinessparams.Add(ApplicationUserData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, applicationuser.writeTime);
            querybusinessparams.Add(ApplicationUserData.writeUser, EnumSqlType.sqlint, 
                EnumCondition.Equal, applicationuser.writeUser);
            querybusinessparams.Add(ApplicationUserData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, applicationuser.writeIp);
            ApplicationUserData applicationuserdata = new ApplicationUserData();
            totalCount = this._applicationuserclass.SelectApplicationUserByPage(applicationuserdata, querybusinessparams);
            return applicationuserdata;
            #endregion
        }
        #endregion

        #endregion
        /// <summary>
        /// 登录界面判定用户名密码是否有效，并返回相关用户信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">未加密的密码字符串</param>
        /// <param name="roleid">角色编号</param>
        /// <param name="userid">用户编号</param>
        /// <param name="fullname">用户全名</param>
        /// <returns>返回json串</returns>
        public string CheckUserlogon(string username, string password,
            ref string roleid, ref string userid, ref string fullname)
        {
            #region
            int totalCount = 0;
            string encodemd5 = Password.ToMD5(password);
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ApplicationUserData.Username, EnumSqlType.nvarchar, EnumCondition.Equal, username);
            querybusinessparams.Add(ApplicationUserData.passWord, EnumSqlType.nvarchar, EnumCondition.Equal, encodemd5);
            ApplicationUserData applicationuserdata = new ApplicationUserData();
            totalCount = this._applicationuserclass.GetSingleTAll(applicationuserdata, querybusinessparams);
            if (applicationuserdata.Tables[0].Rows.Count > 0)
            {
                int currentlogintimes = 0;

                DataRow dr = applicationuserdata.Tables[0].Rows[0];
                roleid = dr[ApplicationUserData.roleId].ToString();
                userid = dr[ApplicationUserData.userid].ToString();
                fullname = dr[ApplicationUserData.fullName].ToString();

                //更新用户登录次数和上次登录时刻
                dr[ApplicationUserData.lastLoginTime] = DateTime.Now;
                int.TryParse(dr[ApplicationUserData.loginTimes].ToString(), out currentlogintimes);
                dr[ApplicationUserData.loginTimes] = currentlogintimes + 1;
                this._applicationuserclass.SaveSingleT(applicationuserdata);

                return base.GetJson(applicationuserdata, totalCount);
            }
            else
            {
                JsonHelper jsonhlp = new JsonHelper();
                jsonhlp.AddObjectToJson("success", "false");
                jsonhlp.AddObjectToJson("msg", "用户名密码不正确，请重新输入！");
                return jsonhlp.ToString();

            }


            #endregion
        }
        /// <summary>
        /// 获取系统登录信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="username"></param>
        /// <param name="fullname"></param>
        /// <returns></returns>
        public string GetAppParameters(HttpContext context, string username,
             string fullname)//string roleId, string userid
        {
            #region
            SystemPlatform platform = new SystemPlatform(context);
            JsonHelper jsonhlp = new JsonHelper();

            jsonhlp.AddObjectToJson("contactus", platform.GetContactUs());
            jsonhlp.AddObjectToJson("developby", platform.GetDevelopBy());
            jsonhlp.AddObjectToJson("systemversion", "V " + Assembly.GetCallingAssembly().GetName().Version.ToString());
            jsonhlp.AddObjectToJson("serverIp", platform.GetServerIp());
            jsonhlp.AddObjectToJson("browserversion", platform.GetBrowserVersion());
            jsonhlp.AddObjectToJson("browser", platform.GetBrowserName());
            jsonhlp.AddObjectToJson("osname", platform.GetClientOS());
            jsonhlp.AddObjectToJson("clientIp", platform.GetClientIp());
            jsonhlp.AddObjectToJson("logontime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            jsonhlp.AddObjectToJson("fullname", fullname);
            //jsonhlp.AddObjectToJson("rolename", rolename);
            jsonhlp.AddObjectToJson(ApplicationUserData.Username, username);

            return jsonhlp.ToString();
            #endregion
        }

        public string UpdateSysUserPwd(string userid, string oldPassword, string newPassword)
        {
            #region
            JsonHelper jsonhlp = new JsonHelper();

            if (oldPassword == newPassword)
            {
                jsonhlp.AddObjectToJson("success", "false");
                jsonhlp.AddObjectToJson("msg", "新旧密码相同！");
                return jsonhlp.ToString();
            }
            else
            {
                string encodemd5 = Password.ToMD5(oldPassword);
                DBConditions querybusinessparams = new DBConditions();
                querybusinessparams.Add(ApplicationUserData.userid, EnumSqlType.sqlint, EnumCondition.Equal, userid);
                querybusinessparams.Add(ApplicationUserData.passWord, EnumSqlType.nvarchar, EnumCondition.Equal, encodemd5);
                ApplicationUserData applicationuserdata = new ApplicationUserData();
                this._applicationuserclass.GetSingleTAll(applicationuserdata, querybusinessparams);
                if (applicationuserdata.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = applicationuserdata.Tables[0].Rows[0];
                    applicationuserdata.Assign(dr, ApplicationUserData.passWord, Password.ToMD5(newPassword));
                    //applicationuserclass.Save(applicationuserdata);
                    return this.SaveApplicationUser(applicationuserdata);
                }
                else
                {
                    jsonhlp.AddObjectToJson("success", "false");
                    jsonhlp.AddObjectToJson("msg", "用户名密码不正确，请重新输入！");
                    return jsonhlp.ToString();

                }
            }

            #endregion
        }
        /// <summary>
        /// 导出通讯录
        /// </summary>
        /// <param name="filename"></param>
        public void OutputAddressBook(string filename)
        {
            #region
            ExcelAddressBook addressbook = new ExcelAddressBook(filename, this.getData(""));
            addressbook.Output();
            #endregion
        }


        /// <summary>
        /// 注册界面判定用户名是否可用
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>返回json串</returns>
        public String CheckUserregister(string username)
        {
            #region
            JsonHelper jsonhelp = new JsonHelper();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ApplicationUserData.Username, EnumSqlType.nvarchar, EnumCondition.Equal, username);
            ApplicationUserData applicationuserdata = new ApplicationUserData();
            this._applicationuserclass.GetSingleTAll(applicationuserdata, querybusinessparams);        
            if (applicationuserdata.Tables[0].Rows.Count == 0)
            {
                jsonhelp.AddObjectToJson("success", "true");   
            }
            else
            {
                jsonhelp.AddObjectToJson("success", "false");
                jsonhelp.AddObjectToJson("msg", "用户名已经存在");
            }
            return jsonhelp.ToString();
            #endregion
        }
    }
}


