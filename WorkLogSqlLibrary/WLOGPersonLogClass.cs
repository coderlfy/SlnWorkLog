/****************************************
***创建人：bhlfy
***创建时间：2013-04-24 18:44:01
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WorkLogDataLibrary;
using BusinessBase;
using Fundation.Core;

namespace WorkLogSqlLibrary
{
    public class WLOGPersonLogClass : GeneralAccessor
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-24 18:44:01
        ***公司：山西ICat Studio有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照复制之用；
        ***         如需有其他业务要求，则可在region外添加新的业务关联方法；
        ***         如发现任何编译错误，请联系QQ：330669393。
        *****************************************/
       
        public DataSet SelectLogsTimes(DBConditions conditions,
    string startDate, string endDate)
        {
            #region
            DataSet worktotaldata = new DataSet();
            string[] innerconditions = new string[2] { "", "" };
            string businessSql = @"select count(*) as '满足时效日志数',a.writeUser, b.fullName from dbo.WLOGPersonLog a inner join dbo.ApplicationUser b
on a.writeuser = b.userid where datediff(Hour
, a.logdate, a.writetime )<34 and (b.istotal = 1){0}{1} group by a.writeUser , b.fullname ";
            if (!string.IsNullOrEmpty(startDate))
                innerconditions[0] = " and (a.logdate >= '" + startDate + "') ";
            if (!string.IsNullOrEmpty(endDate))
                innerconditions[1] = " and (a.logdate <= '" + endDate + "') ";

            businessSql = string.Format(businessSql, innerconditions);

            conditions.AddKeys(WLOGMissionData.missionId);
            base.GetWithoutPageBusiness(businessSql, worktotaldata, conditions);
            return worktotaldata;
            #endregion
        }
        #endregion
    }
}


