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
    public class WLOGWeekSummaryClass : GeneralAccessor
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
        /// <summary>
        /// 检索数据并分页返回数据集
        /// </summary>
        /// <param name="recordCount">符合条件的总记录数</param>
        /// <param name="qParams">分页对象</param>
        /// <param name="conditions">查询条件集合</param>
        /// <returns>分页数据</returns>
        public int SelectWLOGWeekSummaryByPage(WLOGWeekSummaryData wlogweeksummarydata, DBConditions conditions)
        {
            #region
            string sqlformat = @"SELECT {0} FROM WLOGWeekSummary a 
                                          left join 
                                               (select count(missionId) as missioncount,summaryid from dbo.WLOGMission group by summaryid) b 
                                                       on a.summaryid = b.summaryid";
            string businesssql = string.Format(sqlformat, "a.*, b.missioncount");
            string countsql = string.Format(sqlformat, "count(*)");
            conditions.AddKeys(WLOGWeekSummaryData.summaryId);
            return base.GetCustomBusiness(businesssql, countsql, wlogweeksummarydata, conditions);
            #endregion
        }
        #endregion
    }
}


