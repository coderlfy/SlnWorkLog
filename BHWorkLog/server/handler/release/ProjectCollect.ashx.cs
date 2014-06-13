using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ReleaseBusiness;
using ReleaseDataLibrary;
using ReleaseDataLibrary.entity;

namespace BHWorkLog.server.handler.release
{
    /// <summary>
    /// ProjectCollect 的摘要说明
    /// </summary>
    public class ProjectCollect :PageHandlerBase, IHttpHandler
    {

        #region Create by iCat Assist Tools

        #region private member variables
        private EntityProjectCollect projectcollect = new EntityProjectCollect();
        private ProjectCollectBusiness projectcollectclass = new ProjectCollectBusiness();
        private ProjectCollectData projectcollectdata = new ProjectCollectData();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region

            this.projectcollect.projectCollectId = requestObject.Params[ProjectCollectData.projectCollectId];
            this.projectcollect.collectTypeId = requestObject.Params[ProjectCollectData.collectTypeId];
            this.projectcollect.projectItemName = requestObject.Params[ProjectCollectData.projectItemName];
            this.projectcollect.systemName = requestObject.Params[ProjectCollectData.systemName];
            this.projectcollect.fileNo = requestObject.Params[ProjectCollectData.fileNo];
            this.projectcollect.fileTime = requestObject.Params[ProjectCollectData.fileTime];
            this.projectcollect.writeUser = requestObject.Params[ProjectCollectData.writeUser];
            this.projectcollect.writeTime = requestObject.Params[ProjectCollectData.writeTime];
            this.projectcollect.writeIp = requestObject.Params[ProjectCollectData.writeIp];

            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.projectcollectclass.GetJsonByPage(projectcollect, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.projectcollectclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            projectcollect.writeUser = this.SessionUserId;
            projectcollect.writeIp = this.SessionUserIp;

            this.projectcollectclass.AddRow(ref projectcollectdata, projectcollect);

            json = this.projectcollectclass.SaveProjectCollect(projectcollectdata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            projectcollect.writeUser = this.SessionUserId;

            this.projectcollectclass.EditRow(ref projectcollectdata, projectcollect);

            json = this.projectcollectclass.SaveProjectCollect(projectcollectdata);
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.projectcollectclass.DeleteRow(ref projectcollectdata, projectcollect.projectCollectId);
            json = this.projectcollectclass.SaveProjectCollect(projectcollectdata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            projectcollectclass.OutputExcel(fileName, base.GetExcelParams(), this.projectcollect);
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
                    this.ActionOutputExcel("工程部汇总信息.xls");
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