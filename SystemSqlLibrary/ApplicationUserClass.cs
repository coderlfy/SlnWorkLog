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
    public class ApplicationUserClass : GeneralAccessor
    {
        #region Create by iCat Assist Tools
        #endregion
        /// <summary>
        /// 检索数据并分页返回数据集
        /// </summary>
        /// <param name="recordCount">符合条件的总记录数</param>
        /// <param name="qParams">分页对象</param>
        /// <param name="conditions">查询条件集合</param>
        /// <returns>分页数据</returns>
        public int SelectApplicationUserByPage(ApplicationUserData applicationuserdata, DBConditions conditions)
        {
            #region
            string sqlformat = @"SELECT {0} FROM [ApplicationUser] a
                                               left join SystemRole b on a.roleId = b.roleId";
            string businesssql = string.Format(sqlformat, "a.*,(DATEPART(year, GETDATE())-DATEPART(year,birthday)) as age,(DATEPART(year, GETDATE())-DATEPART(year,intoCompanyDate)) as totalYear,b.roleName");
            string countsql = string.Format(sqlformat, "count(*)");
            conditions.AddKeys(ApplicationUserData.userid);
            return base.GetCustomBusiness(businesssql, countsql, applicationuserdata, conditions);
            #endregion
        }
    }
}


