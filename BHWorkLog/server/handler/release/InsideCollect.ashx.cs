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
    /// InsideCollect 的摘要说明
    /// </summary>
    public class InsideCollect :PageHandlerBase, IHttpHandler
    {

        #region Create by iCat Assist Tools

        #region private member variables
        private EntityInsideCollect insidecollect = new EntityInsideCollect();
        private InsideCollectBusiness insidecollectclass = new InsideCollectBusiness();
        private InsideCollectData insidecollectdata = new InsideCollectData();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region

            this.insidecollect.insideCollectId = requestObject.Params[InsideCollectData.insideCollectId];
            this.insidecollect.collectTypeId = requestObject.Params[InsideCollectData.collectTypeId];
            this.insidecollect.systemName = requestObject.Params[InsideCollectData.systemName];
            this.insidecollect.fileNo = requestObject.Params[InsideCollectData.fileNo];
            this.insidecollect.fileTime = requestObject.Params[InsideCollectData.fileTime];
            this.insidecollect.writeUser = requestObject.Params[InsideCollectData.writeUser];
            this.insidecollect.writeTime = requestObject.Params[InsideCollectData.writeTime];
            this.insidecollect.writeIp = requestObject.Params[InsideCollectData.writeIp];

            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.insidecollectclass.GetJsonByPage(insidecollect, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.insidecollectclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            insidecollect.writeUser = this.SessionUserId;
            insidecollect.writeIp = this.SessionUserIp;

            this.insidecollectclass.AddRow(ref insidecollectdata, insidecollect);

            json = this.insidecollectclass.SaveInsideCollect(insidecollectdata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            insidecollect.writeUser = this.SessionUserId;

            this.insidecollectclass.EditRow(ref insidecollectdata, insidecollect);

            json = this.insidecollectclass.SaveInsideCollect(insidecollectdata);
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.insidecollectclass.DeleteRow(ref insidecollectdata, insidecollect.insideCollectId);
            json = this.insidecollectclass.SaveInsideCollect(insidecollectdata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            insidecollectclass.OutputExcel(fileName, base.GetExcelParams(), this.insidecollect);
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
                    this.ActionOutputExcel("内部汇总信息.xls");
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