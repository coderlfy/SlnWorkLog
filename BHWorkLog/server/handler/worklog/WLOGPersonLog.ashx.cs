using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkLogBusiness;
using WorkLogDataLibrary;
using WorkLogDataLibrary.business;

namespace BHWorkLog.server.handler.worklog
{
    /// <summary>
    /// WLOGPersonLog 的摘要说明
    /// </summary>

    public class WLOGPersonLog : PageHandlerBase, IHttpHandler
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-25 19:05:01
        ***公司：山西ICat Studio有限公司
        ***友情提示：本处业务可根据实际业务进行修改；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region private member variables
        private EntityWLOGPersonLog wlogpersonlog = new EntityWLOGPersonLog();
        private WLOGPersonLogBusiness wlogpersonlogclass = new WLOGPersonLogBusiness();
        private WLOGPersonLogData wlogpersonlogdata = new WLOGPersonLogData();
        private EntityLogsTimes logstimes = new EntityLogsTimes();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region
            this.logstimes.startDate = requestObject.Params[WLOGWeekSummaryData.startDate];
            this.logstimes.endDate = requestObject.Params[WLOGWeekSummaryData.endDate];
            this.logstimes.writeUser = requestObject.Params[WLOGPersonLogData.writeUser];

            this.wlogpersonlog.missionId = requestObject.Params[WLOGPersonLogData.missionId];
            this.wlogpersonlog.logId = requestObject.Params[WLOGPersonLogData.logId];
            this.wlogpersonlog.writeUser = requestObject.Params[WLOGPersonLogData.writeUser];
            this.wlogpersonlog.projectItem = requestObject.Params[WLOGPersonLogData.projectItem];
            this.wlogpersonlog.logContent = requestObject.Params[WLOGPersonLogData.logContent];
            this.wlogpersonlog.logDate = requestObject.Params[WLOGPersonLogData.logDate];
            this.wlogpersonlog.isMission = requestObject.Params[WLOGPersonLogData.isMission];
            this.wlogpersonlog.workState = requestObject.Params[WLOGPersonLogData.workState];
            this.wlogpersonlog.workResult = requestObject.Params[WLOGPersonLogData.workResult];
            this.wlogpersonlog.submited = requestObject.Params[WLOGPersonLogData.submited];
            this.wlogpersonlog.deleted = requestObject.Params[WLOGPersonLogData.deleted];
            this.wlogpersonlog.deleteTime = requestObject.Params[WLOGPersonLogData.deleteTime];
            this.wlogpersonlog.usable = requestObject.Params[WLOGPersonLogData.usable];
            this.wlogpersonlog.writeTime = requestObject.Params[WLOGPersonLogData.writeTime];
            this.wlogpersonlog.writeIp = requestObject.Params[WLOGPersonLogData.writeIp];
            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.wlogpersonlogclass.GetJsonByPage(wlogpersonlog, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.wlogpersonlogclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetPersonLogByMissionId(ref string json)
        {
            #region
            json = this.wlogpersonlogclass.GetPersonLogByMissionId(this.wlogpersonlog, SceneMission.ViewPersonlogs);
            #endregion
        }

        private void ActionGetPersonLogByMissionIdNULL(ref string json)
        {
            #region
            json = this.wlogpersonlogclass.GetPersonLogByMissionId(this.wlogpersonlog, SceneMission.AddMission);
            #endregion
        }

        private void ActionGetPersonLogByMissionIdAndNULL(ref string json)
        {
            #region
            json = this.wlogpersonlogclass.GetPersonLogByMissionId(this.wlogpersonlog, SceneMission.EditMission);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetPersonLogsIdByMissionId(ref string json)
        {
            #region
            json = this.wlogpersonlogclass.GetPersonLogsIdByMissionId(this.wlogpersonlog);
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            if (WLOGPersonLogBusiness.SessionCheckValid(this.SessionUserId, ref json))
            {
                wlogpersonlog.writeUser = this.SessionUserId;
                wlogpersonlog.writeIp = this.SessionUserIp;

                if (!this.wlogpersonlogclass.FindUserCurrentDayLog(wlogpersonlog, ref json))
                {
                    this.wlogpersonlogclass.AddRow(ref wlogpersonlogdata, wlogpersonlog);

                    json = this.wlogpersonlogclass.SaveWLOGPersonLog(wlogpersonlogdata);
                }
            }
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            if (WLOGPersonLogBusiness.SessionCheckValid(this.SessionUserId, ref json))
            {
                wlogpersonlog.writeUser = this.SessionUserId;

                this.wlogpersonlogclass.EditRow(ref wlogpersonlogdata, wlogpersonlog);

                json = this.wlogpersonlogclass.SaveWLOGPersonLog(wlogpersonlogdata);
            }
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.wlogpersonlogclass.DeleteRow(ref wlogpersonlogdata, wlogpersonlog.logId);
            json = this.wlogpersonlogclass.SaveWLOGPersonLog(wlogpersonlogdata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            wlogpersonlogclass.OutputExcel(fileName, base.GetExcelParams(), this.wlogpersonlog);
            #endregion
        }
        #endregion

        #region public member functons entry point
        /// <summary>
        /// 处理请求的过程，当前台页面调用本文件时，自动执行本方法。
        /// </summary>
        /// <param name="context">上下文</param>
        public void ProcessRequest(HttpContext context)
        {
            #region
            HttpRequest requestobject = context.Request;
            String action = requestobject.QueryString["action"];
            String json = "";
            //同业务层开始交互

            this.getPostParams(requestobject);

            context.Response.ContentType = "text/json";
            switch (action)
            {
                case "list":
                    this.ActionList(ref json);
                    break;
                case "viewall":
                    this.ActionGetAll(ref json);
                    break;
                case "missonspersonlogs":
                    this.ActionGetPersonLogByMissionId(ref json);
                    break;
                case "missonspersonlogsnull":
                    this.ActionGetPersonLogByMissionIdNULL(ref json);
                    break;
                case "missionupdateviewpersonlogs":
                    this.ActionGetPersonLogByMissionIdAndNULL(ref json);
                    break;
                case "missionpersonlogsid":
                    this.ActionGetPersonLogsIdByMissionId(ref json);
                    break;
                case "logstimes":
                    json = this.wlogpersonlogclass.GetLogsTimes(this.logstimes);
                    break;
                case "add":
                    this.ActionAddNew(ref json);
                    break;
                case "update":
                    this.ActionEdit(ref json);
                    break;
                case "delete":
                    this.ActionDelete(ref json);
                    break;
                case "outputexcel":
                    this.ActionOutputExcel("工作日志信息.xls");
                    break;
                default:
                    break;
            }
            context.Response.Write(json);
            #endregion
        }

        public bool IsReusable
        {
            #region
            get
            {
                return false;
            }
            #endregion
        }
        #endregion

        #endregion
    }
}