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
    /// WLOGMission 的摘要说明
    /// </summary>

    public class WLOGMission : PageHandlerBase, IHttpHandler
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-26 18:05:47
        ***公司：山西ICat Studio有限公司
        ***友情提示：本处业务可根据实际业务进行修改；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region private member variables
        private EntityWLOGMission wlogmission = new EntityWLOGMission();
        private WLOGMissionBusiness wlogmissionclass = new WLOGMissionBusiness();
        private WLOGMissionData wlogmissiondata = new WLOGMissionData();
        private EntityWLOGPersonLog wlogpersonlog = new EntityWLOGPersonLog();
        private WLOGPersonLogBusiness wlogpersonlogclass = new WLOGPersonLogBusiness();
        private EntityMissionReport missionreport = new EntityMissionReport();
        private string oldlogsid = "";
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region
            this.missionreport.writeUser = requestObject.Params[WLOGMissionData.writeUser];
            this.missionreport.startDate = requestObject.Params[WLOGWeekSummaryData.startDate];
            this.missionreport.endDate = requestObject.Params[WLOGWeekSummaryData.endDate];
            this.missionreport.missionState = requestObject.Params[WLOGMissionData.missionState];
            this.missionreport.reviewState = requestObject.Params[WLOGMissionData.reviewState];
            oldlogsid = requestObject.Params["oldlogId"];
            this.wlogpersonlog.logId = requestObject.Params[WLOGPersonLogData.logId];
            this.wlogmission.missionId = requestObject.Params[WLOGMissionData.missionId];
            this.wlogmission.summaryId = requestObject.Params[WLOGMissionData.summaryId];
            this.wlogmission.writeUser = requestObject.Params[WLOGMissionData.writeUser];
            this.wlogmission.projectId = requestObject.Params[WLOGMissionData.projectId];
            this.wlogmission.missionBH = requestObject.Params[WLOGMissionData.missionBH];
            this.wlogmission.missionName = requestObject.Params[WLOGMissionData.missionName];
            this.wlogmission.missionRemark = requestObject.Params[WLOGMissionData.missionRemark];
            this.wlogmission.planned = requestObject.Params[WLOGMissionData.planned];
            this.wlogmission.plantimelimit = requestObject.Params[WLOGMissionData.plantimelimit];
            this.wlogmission.outputResult = requestObject.Params[WLOGMissionData.outputResult];
            this.wlogmission.startDate = requestObject.Params[WLOGMissionData.startDate];
            this.wlogmission.reviewState = requestObject.Params[WLOGMissionData.reviewState];
            this.wlogmission.missionState = requestObject.Params[WLOGMissionData.missionState];
            this.wlogmission.deleted = requestObject.Params[WLOGMissionData.deleted];
            this.wlogmission.usable = requestObject.Params[WLOGMissionData.usable];
            this.wlogmission.updated = requestObject.Params[WLOGMissionData.updated];
            this.wlogmission.deleteTime = requestObject.Params[WLOGMissionData.deleteTime];
            this.wlogmission.writeTime = requestObject.Params[WLOGMissionData.writeTime];
            this.wlogmission.writeIp = requestObject.Params[WLOGMissionData.writeIp];
            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.wlogmissionclass.GetJsonByPage(wlogmission, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.wlogmissionclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            if (WLOGMissionBusiness.SessionCheckValid(this.SessionUserId, ref json))
            {
                wlogmission.writeUser = this.SessionUserId;
                wlogmission.writeIp = this.SessionUserIp;

                this.wlogmissionclass.AddRow(ref wlogmissiondata, wlogmission);
                json = this.wlogmissionclass.SaveWLOGMission(wlogmissiondata);
                wlogpersonlogclass.UpdatePersonLogMissionId("", this.wlogpersonlog.logId, this.wlogmission.missionId);
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
            if (WLOGMissionBusiness.SessionCheckValid(this.SessionUserId, ref json))
            {

                wlogmission.writeUser = this.SessionUserId;

                this.wlogmissionclass.EditRow(ref wlogmissiondata, wlogmission);

                json = this.wlogmissionclass.SaveWLOGMission(wlogmissiondata);
                if (this.oldlogsid != this.wlogpersonlog.logId)
                    wlogpersonlogclass.UpdatePersonLogMissionId(this.oldlogsid, this.wlogpersonlog.logId, this.wlogmission.missionId);
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
            this.wlogmissionclass.DeleteRow(ref wlogmissiondata, wlogmission.missionId);
            json = this.wlogmissionclass.SaveWLOGMission(wlogmissiondata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            wlogmissionclass.OutputExcel(fileName, base.GetExcelParams(), this.wlogmission);
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
                case "add":
                    this.ActionAddNew(ref json);
                    break;
                case "summarymissions":
                    this.ActionGetMissionsBySummaryId(ref json);
                    break;
                case "summarymissionadd":
                    this.ActionGetMissionsBySummaryIdNULL(ref json);
                    break;
                case "summarymissionupdate":
                    this.ActionGetMissionsBySummaryIdAndNULL(ref json);
                    break;
                case "summarymissionsid":
                    this.ActionGetMissionsIdBySummaryId(ref json);
                    break;
                case "allocmissionall":
                    json = this.wlogmissionclass.GetAllocMissions();
                    break;
                case "report":
                    this.ActionWorkTotalReport(ref json);
                    break;
                case "update":
                    this.ActionEdit(ref json);
                    break;
                case "delete":
                    this.ActionDelete(ref json);
                    break;
                case "outputexcel":
                    this.ActionOutputExcel("文件名.xls");
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetMissionsBySummaryId(ref string json)
        {
            #region
            json = this.wlogmissionclass.GetMissionBySummaryId(this.wlogmission, SceneWeekSummary.ViewMissions);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetMissionsBySummaryIdAndNULL(ref string json)
        {
            #region
            json = this.wlogmissionclass.GetMissionBySummaryId(this.wlogmission, SceneWeekSummary.EditWeekSummary);
            #endregion
        }

        private void ActionGetMissionsBySummaryIdNULL(ref string json)
        {
            #region
            json = this.wlogmissionclass.GetMissionBySummaryId(this.wlogmission, SceneWeekSummary.AddWeekSummary);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetMissionsIdBySummaryId(ref string json)
        {
            #region
            json = this.wlogmissionclass.GetMissionsIdBySummaryId(this.wlogmission);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        private void ActionWorkTotalReport(ref string json)
        {
            #region
            json = this.wlogmissionclass.GetWorkTotal(this.missionreport);
            #endregion
        }
    }
}