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
    public class RoleControlFunctionPointData : DataLibBase
    {
        
        /// <summary>
        /// 功能点设置-编号。
        /// </summary>
        public const string setId = "setId";
        /// <summary>
        /// 功能点编号。
        /// </summary>
        public const string functionId = "functionId";
        /// <summary>
        /// 所属角色编号。
        /// </summary>
        public const string roleId = "roleId";
        /// <summary>
        /// 用户编号。
        /// </summary>
        public const string userid = "userid";
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
        public const string RoleControlFunctionPoint = "RoleControlFunctionPoint";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(RoleControlFunctionPoint);
            
            dt.Columns.Add(setId, typeof(System.Int32));
            dt.Columns.Add(functionId, typeof(System.Int32));
            dt.Columns.Add(roleId, typeof(System.Byte));
            dt.Columns.Add(userid, typeof(System.Int32));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[setId] };
            dt.TableName = RoleControlFunctionPoint;
            this.Tables.Add(dt);
            this.DataSetName = "TRoleControlFunctionPoint";
        }

        public RoleControlFunctionPointData()
        {
            this.BuildData();
        }
    }
}
#endregion

