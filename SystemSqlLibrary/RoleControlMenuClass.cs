/****************************************
***创建人：bhlfy
***创建时间：2013-04-06 17:16:16
***公司：山西博华科技有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SystemDataLibrary;
using BusinessBase;
using AccessLibrary;
using Fundation.Core;

namespace SystemSqlLibrary
{
    public class RoleControlMenuClass : GeneralAccessor
    {
        #region 自定义业务关联访问
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="updateAfterDs"></param>
        public void UpdateRoleControl(string roleId, RoleControlMenuData updateAfterDs)
        {
            #region
            IDBAccess dbaccess = new DBAccess();
            try
            {
                DBConditions deletecondition = new DBConditions();
                deletecondition.Add(RoleControlMenuData.roleId, EnumSqlType.smallint, EnumCondition.Equal, roleId);

                string sql = "delete from [RoleControlMenu] ";
                dbaccess.AddAction(sql, EnumDBReturnAccess.ExeNoQuery, deletecondition);
                dbaccess.AddAction(updateAfterDs);
                dbaccess.StartActions();
                dbaccess.ClearActions();
            }
            finally
            {
                dbaccess.Dispose();
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public DataSet GetControlMenu(int roleId)
        {
            #region
            DataSet rolecontrolmenudata = new DataSet();
            string businessSql = @"SELECT a.*,
                            case when b.menuId is NULL then 'false' else 'true' end as Checked 
                            FROM [Menu] a 
                            left join (select * from [RoleControlMenu] where roleid = {0}) b on a.menuId = b.menuId";
            businessSql = String.Format(businessSql, roleId);
            DBConditions conditions = new DBConditions();
            conditions.AddKeys(RoleControlMenuData.roleId);
            conditions.AddKeys(RoleControlMenuData.menuId);
            base.GetWithoutPageBusiness(businessSql, rolecontrolmenudata, conditions);
            return rolecontrolmenudata;
            #endregion
        }

        #endregion
    }
}


