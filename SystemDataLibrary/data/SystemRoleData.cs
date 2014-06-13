#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.28380
***创建人：bhlfy
***生成时间：2013-04-06 17:01:08
***公司：山西博华科技有限公司
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
    public class SystemRoleData : DataLibBase
    {
        
        /// <summary>
        /// 角色编号。
        /// </summary>
        public const string roleId = "roleId";
        /// <summary>
        /// 角色名称。
        /// </summary>
        public const string roleName = "roleName";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 备注。
        /// </summary>
        public const string remark = "remark";
        /// <summary>
        /// 排序号。
        /// </summary>
        public const string sort = "sort";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string SystemRole = "SystemRole";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(SystemRole);
            
            dt.Columns.Add(roleId, typeof(System.Byte));
            dt.Columns.Add(roleName, typeof(System.String));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(remark, typeof(System.String));
            dt.Columns.Add(sort, typeof(System.Byte));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[roleId] };
            dt.TableName = SystemRole;
            this.Tables.Add(dt);
            this.DataSetName = "TSystemRole";
        }

        public SystemRoleData()
        {
            this.BuildData();
        }
    }
}
#endregion

