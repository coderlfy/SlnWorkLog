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
using ExportExcelLib;
using BusinessBase;
using Fundation.Core;

namespace SystemBusiness
{
    public class EventLogsBusiness : GeneralBusinesser
    {
        private EventLogsClass _eventlogsclass = new EventLogsClass();
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
        /// 根据条件筛选所有EventLogs指定页码的数据（分页型）
        /// </summary>
        /// <param name="eventlogs">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityEventLogs eventlogs, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet eventlogsdata = this.GetData(eventlogs, pageparams, out totalCount);
            return base.GetJson(eventlogsdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存eventlogsdata数据集数据
        /// </summary>
        /// <param name="eventlogsdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveEventLogs(EventLogsData eventlogsdata)
        {
            #region
            return base.Save(eventlogsdata, this._eventlogsclass);
            #endregion
        }
                
        /// <summary>
        /// 添加EventLogs表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="eventlogsdata">数据集对象</param>
        /// <param name="eventlogs">实体对象</param>
        public void AddRow(ref EventLogsData eventlogsdata, EntityEventLogs eventlogs)
        {
            #region
            DataRow dr = eventlogsdata.Tables[0].NewRow();
            eventlogsdata.Assign(dr, EventLogsData.eventId, eventlogs.eventId);
            eventlogsdata.Assign(dr, EventLogsData.userid, eventlogs.userid);
            eventlogsdata.Assign(dr, EventLogsData.writeIp, eventlogs.writeIp);
            eventlogsdata.Assign(dr, EventLogsData.eventType, eventlogs.eventType);
            eventlogsdata.Assign(dr, EventLogsData.writeTime, eventlogs.writeTime);
            eventlogsdata.Assign(dr, EventLogsData.Content, eventlogs.Content);
            eventlogsdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑eventlogsdata数据集中指定的行数据
        /// </summary>
        /// <param name="eventlogsdata">数据集对象</param>
        /// <param name="eventlogs">实体对象</param>
        public void EditRow(ref EventLogsData eventlogsdata, EntityEventLogs eventlogs)
        {
            #region
            if (eventlogsdata.Tables[0].Rows.Count <= 0)
                eventlogsdata = this.getData(eventlogs.eventId);
            DataRow dr = eventlogsdata.Tables[0].Rows.Find(new object[1] {eventlogs.eventId});
            eventlogsdata.Assign(dr, EventLogsData.eventId, eventlogs.eventId);
            eventlogsdata.Assign(dr, EventLogsData.userid, eventlogs.userid);
            eventlogsdata.Assign(dr, EventLogsData.writeIp, eventlogs.writeIp);
            eventlogsdata.Assign(dr, EventLogsData.eventType, eventlogs.eventType);
            eventlogsdata.Assign(dr, EventLogsData.writeTime, eventlogs.writeTime);
            eventlogsdata.Assign(dr, EventLogsData.Content, eventlogs.Content);
            #endregion
        }
        		
        /// <summary>
        /// 删除eventlogsdata数据集中指定的行数据
        /// </summary>
        /// <param name="eventlogsdata">数据集对象</param>
        /// <param name="eventId">主键-事件编号</param>
        public void DeleteRow(ref EventLogsData eventlogsdata,string eventId)
        {
            #region
            if (eventlogsdata.Tables[0].Rows.Count <= 0)
                eventlogsdata = this.getData(eventId);
            DataRow dr = eventlogsdata.Tables[0].Rows.Find(new object[1] { eventId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取EventLogs数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            EventLogsData eventlogsdata = this.getData(null);
            totalCount = eventlogsdata.Tables[0].Rows.Count;
            return base.GetJson(eventlogsdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityEventLogs eventlogs)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(eventlogs, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="eventId">主键-事件编号</param>
        /// <returns></returns>
        private EventLogsData getData(string eventId)
        {
            #region
            EventLogsData eventlogsdata = new EventLogsData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(EventLogsData.eventId, EnumSqlType.sqlint, EnumCondition.Equal, eventId);
            this._eventlogsclass.GetSingleTAllWithoutCount(eventlogsdata, querybusinessparams);
            return eventlogsdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有EventLogs指定页码的数据（分页型）
        /// </summary>
        /// <param name="eventlogs">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityEventLogs eventlogs, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(EventLogsData.eventId, EnumSqlType.sqlint, 
                EnumCondition.Equal, eventlogs.eventId);
            querybusinessparams.Add(EventLogsData.userid, EnumSqlType.sqlint, 
                EnumCondition.Equal, eventlogs.userid);
            querybusinessparams.Add(EventLogsData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, eventlogs.writeIp);
            querybusinessparams.Add(EventLogsData.eventType, EnumSqlType.sqlint, 
                EnumCondition.Equal, eventlogs.eventType);
            querybusinessparams.Add(EventLogsData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, eventlogs.writeTime);
            querybusinessparams.Add(EventLogsData.Content, EnumSqlType.text, 
                EnumCondition.Equal, eventlogs.Content);
            EventLogsData eventlogsdata = new EventLogsData();
            totalCount = this._eventlogsclass.GetSingleT(eventlogsdata, querybusinessparams);
            return eventlogsdata;
            #endregion
        }
        #endregion

        #endregion
    }
}


