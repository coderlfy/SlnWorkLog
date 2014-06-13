#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.28380
***创建人：bhlfy
***生成时间：2013-04-06 17:01:08
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
    public class OrganizationData : DataLibBase
    {
        
        /// <summary>
        /// 组织机构编号。
        /// </summary>
        public const string organizationId = "organizationId";
        /// <summary>
        /// 用户编号。
        /// </summary>
        public const string userid = "userid";
        /// <summary>
        /// 组织机构名称。
        /// </summary>
        public const string organizationName = "organizationName";
        /// <summary>
        /// 当前机构编号。
        /// </summary>
        public const string currentId = "currentId";
        /// <summary>
        /// 父机构编号。
        /// </summary>
        public const string parentId = "parentId";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 录入人IP地址。
        /// </summary>
        public const string writeIp = "writeIp";
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public const string writeTime = "writeTime";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string Organization = "Organization";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(Organization);
            
            dt.Columns.Add(organizationId, typeof(System.Int32));
            dt.Columns.Add(userid, typeof(System.Int32));
            dt.Columns.Add(organizationName, typeof(System.String));
            dt.Columns.Add(currentId, typeof(System.Int32));
            dt.Columns.Add(parentId, typeof(System.Int32));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[organizationId] };
            dt.TableName = Organization;
            this.Tables.Add(dt);
            this.DataSetName = "TOrganization";
        }

        public OrganizationData()
        {
            this.BuildData();
        }
    }
}
#endregion

