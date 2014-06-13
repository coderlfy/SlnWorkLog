#region Create by iCat Assist Tools
/****************************************
***生成器版本：V2.0.0.27745
***创建人：bhlfy
***生成时间：2013-09-23 14:31:07
***公司：山西ICat Studio有限公司
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Fundation.Core;

namespace SystemDataLibrary
{
    public class ApplicationUserData : DataLibBase
    {

        /// <summary>
        /// 用户编号。
        /// </summary>
        public const string userid = "userid";
        /// <summary>
        /// 用户名。
        /// </summary>
        public const string Username = "Username";
        /// <summary>
        /// 所属角色编号。
        /// </summary>
        public const string roleId = "roleId";
        /// <summary>
        /// 组织机构编号。
        /// </summary>
        public const string organizationId = "organizationId";
        /// <summary>
        /// 全名。
        /// </summary>
        public const string fullName = "fullName";
        /// <summary>
        /// 密码（MD5）。
        /// </summary>
        public const string passWord = "passWord";
        /// <summary>
        /// 电话号码。
        /// </summary>
        public const string telephone = "telephone";
        /// <summary>
        /// 是否统计。
        /// </summary>
        public const string isTotal = "isTotal";
        /// <summary>
        /// 电子邮箱地址。
        /// </summary>
        public const string email = "email";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 登录次数。
        /// </summary>
        public const string loginTimes = "loginTimes";
        /// <summary>
        /// 上次登录时刻。
        /// </summary>
        public const string lastLoginTime = "lastLoginTime";
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public const string writeTime = "writeTime";
        /// <summary>
        /// 录入人。
        /// </summary>
        public const string writeUser = "writeUser";
        /// <summary>
        /// ip地址。
        /// </summary>
        public const string writeIp = "writeIp";
        /// <summary>
        /// 婚否。
        /// </summary>
        public const string isMarry = "isMarry";
        /// <summary>
        /// 生日。
        /// </summary>
        public const string birthday = "birthday";
        /// <summary>
        /// 户口所在地。
        /// </summary>
        public const string household = "household";
        /// <summary>
        /// 老家。
        /// </summary>
        public const string oldHome = "oldHome";
        /// <summary>
        /// 现居住地。
        /// </summary>
        public const string nowLiveHome = "nowLiveHome";
        /// <summary>
        /// 入职时刻。
        /// </summary>
        public const string intoCompanyDate = "intoCompanyDate";
        /// <summary>
        /// 工作年限。
        /// </summary>
        public const string workTotalYear = "workTotalYear";
        /// <summary>
        /// 专业技能。
        /// </summary>
        public const string still = "still";
        /// <summary>
        /// 最高学历。
        /// </summary>
        public const string maxEducation = "maxEducation";
        /// <summary>
        /// 最高学历大学。
        /// </summary>
        public const string maxEduCollege = "maxEduCollege";
        /// <summary>
        /// 毕业时间。
        /// </summary>
        public const string maxEduLeaveTime = "maxEduLeaveTime";
        /// <summary>
        /// 工作经验。
        /// </summary>
        public const string workExperiences = "workExperiences";
        /// <summary>
        /// 学习经验。
        /// </summary>
        public const string studyExperiences = "studyExperiences";
        /// <summary>
        /// 个人照片。
        /// </summary>
        public const string photoUrl = "photoUrl";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string ApplicationUser = "ApplicationUser";

        private void BuildData()
        {
            DataTable dt = new DataTable(ApplicationUser);

            dt.Columns.Add(userid, typeof(System.Int32));
            dt.Columns.Add(Username, typeof(System.String));
            dt.Columns.Add(roleId, typeof(System.Byte));
            dt.Columns.Add(organizationId, typeof(System.Int32));
            dt.Columns.Add(fullName, typeof(System.String));
            dt.Columns.Add(passWord, typeof(System.String));
            dt.Columns.Add(telephone, typeof(System.String));
            dt.Columns.Add(isTotal, typeof(System.Boolean));
            dt.Columns.Add(email, typeof(System.String));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(loginTimes, typeof(System.Int32));
            dt.Columns.Add(lastLoginTime, typeof(System.DateTime));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(isMarry, typeof(System.Boolean));
            dt.Columns.Add(birthday, typeof(System.DateTime));
            dt.Columns.Add(household, typeof(System.String));
            dt.Columns.Add(oldHome, typeof(System.String));
            dt.Columns.Add(nowLiveHome, typeof(System.String));
            dt.Columns.Add(intoCompanyDate, typeof(System.DateTime));
            dt.Columns.Add(workTotalYear, typeof(System.Byte));
            dt.Columns.Add(still, typeof(System.String));
            dt.Columns.Add(maxEducation, typeof(System.Byte));
            dt.Columns.Add(maxEduCollege, typeof(System.String));
            dt.Columns.Add(maxEduLeaveTime, typeof(System.DateTime));
            dt.Columns.Add(workExperiences, typeof(System.String));
            dt.Columns.Add(studyExperiences, typeof(System.String));
            dt.Columns.Add(photoUrl, typeof(System.String));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[userid] };
            dt.TableName = ApplicationUser;
            this.Tables.Add(dt);
            this.DataSetName = "TApplicationUser";
        }

        public ApplicationUserData()
        {
            this.BuildData();
        }
    }
}
#endregion