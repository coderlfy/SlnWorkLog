/****************************************
***创建人：bhlfy
***创建时间：2013-04-06 17:16:15
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
using Fundation.Core;

namespace SystemSqlLibrary
{
    public class MenuClass : GeneralAccessor
    {
        public DataSet GetMenuByRole(DBConditions conditions)
        {
            #region
            DataSet menudata = new DataSet();
            string businessSql = @"SELECT a.*,b.roleId FROM [Menu] a 
                inner join [RoleControlMenu] b on a.menuId = b.menuId ";
            conditions.AddKeys(MenuData.menuId);
            base.GetCustomBusiness(businessSql, menudata, conditions);
            return menudata;
            #endregion
        }
    }
}


