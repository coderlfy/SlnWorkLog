using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkLogBusiness;
using WorkLogDataLibrary;
using BusinessBase;

namespace BHWorkLog.server.handler.worklog
{
    /// <summary>
    /// WLOGWeekSummary 的摘要说明
    /// </summary>

    public class WLOGWeekSummary : PageHandlerBase, IHttpHandler
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-25 22:26:27
        ***公司：山西博华科技有限公司
        ***友情提示：本处业务可根据实际业务进行修改；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region private member variables
        private EntityWLOGWeekSummary wlogweeksummary = new EntityWLOGWeekSummary();
        private WLOGWeekSummaryBusiness wlogweeksummaryclass = new WLOGWeekSummaryBusiness();
        private WLOGWeekSummaryData wlogweeksummarydata = new WLOGWeekSummaryData();
        private EntityWLOGMission wlogmission = new EntityWLOGMission();
        private WLOGMissionBusiness wlogmissionclass = new WLOGMissionBusiness();
        private string oldmissionsid = "";
        private string summaryExcelWriteUser = "";
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region
            oldmissionsid = requestObject.Params["oldMissionId"];
            summaryExcelWriteUser = requestObject.Params["summaryFullName"];
            this.wlogmission.missionId = requestObject.Params[WLOGMissionData.missionId];
            this.wlogweeksummary.summaryId = requestObject.Params[WLOGWeekSummaryData.summaryId];
            this.wlogweeksummary.writeUser = requestObject.Params[WLOGWeekSummaryData.writeUser];
            this.wlogweeksummary.weekBH = requestObject.Params[WLOGWeekSummaryData.weekBH];
            this.wlogweeksummary.startDate = requestObject.Params[WLOGWeekSummaryData.startDate];
            this.wlogweeksummary.endDate = requestObject.Params[WLOGWeekSummaryData.endDate];
            this.wlogweeksummary.submited = requestObject.Params[WLOGWeekSummaryData.submited];
            this.wlogweeksummary.submitTime = requestObject.Params[WLOGWeekSummaryData.submitTime];
            this.wlogweeksummary.writeTime = requestObject.Params[WLOGWeekSummaryData.writeTime];
            this.wlogweeksummary.writeIp = requestObject.Params[WLOGWeekSummaryData.writeIp];
            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.wlogweeksummaryclass.GetJsonByPage(wlogweeksummary, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.wlogweeksummaryclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            if (WLOGWeekSummaryBusiness.SessionCheckValid(this.SessionUserId, ref json))
            {
                wlogweeksummary.writeUser = this.SessionUserId;
                wlogweeksummary.writeIp = this.SessionUserIp;

                if (!this.wlogweeksummaryclass.FindUserWeekSummary(wlogweeksummary, ref json))
                {
                    this.wlogweeksummaryclass.AddRow(ref wlogweeksummarydata, wlogweeksummary);
                    json = this.wlogweeksummaryclass.SaveWLOGWeekSummary(wlogweeksummarydata);
                    this.wlogmissionclass.UpdateMissionSummaryId("", this.wlogmission.missionId, this.wlogweeksummary.summaryId);
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
            if (WLOGWeekSummaryBusiness.SessionCheckValid(this.SessionUserId, ref json))
            {
                wlogweeksummary.writeUser = this.SessionUserId;
                wlogmission.writeIp = this.SessionUserIp;
                this.wlogweeksummaryclass.EditRow(ref wlogweeksummarydata, wlogweeksummary);
                json = this.wlogweeksummaryclass.SaveWLOGWeekSummary(wlogweeksummarydata);
                if (this.oldmissionsid != this.wlogmission.missionId)
                    this.wlogmissionclass.UpdateMissionSummaryId(this.oldmissionsid,
                        this.wlogmission.missionId, this.wlogweeksummary.summaryId);
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
            this.wlogweeksummaryclass.DeleteRow(ref wlogweeksummarydata, wlogweeksummary.summaryId);
            json = this.wlogweeksummaryclass.SaveWLOGWeekSummary(wlogweeksummarydata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            wlogweeksummaryclass.OutputExcel(fileName, base.GetExcelParams(), this.wlogweeksummary);
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
                case "update":
                    this.ActionEdit(ref json);
                    break;
                case "delete":
                    this.ActionDelete(ref json);
                    break;
                case "outputexcel":
                    this.ActionOutputExcel("文件名.xls");
                    break;
                case "outputsummary":
                    this.ActionOutputSummaryExcel();
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

        private void ActionOutputSummaryExcel()
        {
            #region
            wlogweeksummaryclass.OutputSummaryExcel(this.wlogweeksummary.summaryId, this.summaryExcelWriteUser);
            #endregion
        }
    }
}