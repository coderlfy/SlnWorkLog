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
    /// ProductionCollect 的摘要说明
    /// </summary>
    public class ProductionCollect :PageHandlerBase, IHttpHandler
    {

        #region Create by iCat Assist Tools

        #region private member variables
        private EntityProductionCollect productioncollect = new EntityProductionCollect();
        private ProductionCollectBusiness productioncollectclass = new ProductionCollectBusiness();
        private ProductionCollectData productioncollectdata = new ProductionCollectData();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region

            this.productioncollect.productionCollectId = requestObject.Params[ProductionCollectData.productionCollectId];
            this.productioncollect.collectTypeId = requestObject.Params[ProductionCollectData.collectTypeId];
            this.productioncollect.systemName = requestObject.Params[ProductionCollectData.systemName];
            this.productioncollect.fileNo = requestObject.Params[ProductionCollectData.fileNo];
            this.productioncollect.fileTime = requestObject.Params[ProductionCollectData.fileTime];
            this.productioncollect.writeUser = requestObject.Params[ProductionCollectData.writeUser];
            this.productioncollect.writeTime = requestObject.Params[ProductionCollectData.writeTime];
            this.productioncollect.writeIp = requestObject.Params[ProductionCollectData.writeIp];

            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.productioncollectclass.GetJsonByPage(productioncollect, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.productioncollectclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            productioncollect.writeUser = this.SessionUserId;
            productioncollect.writeIp = this.SessionUserIp;

            this.productioncollectclass.AddRow(ref productioncollectdata, productioncollect);

            json = this.productioncollectclass.SaveProductionCollect(productioncollectdata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            productioncollect.writeUser = this.SessionUserId;

            this.productioncollectclass.EditRow(ref productioncollectdata, productioncollect);

            json = this.productioncollectclass.SaveProductionCollect(productioncollectdata);
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.productioncollectclass.DeleteRow(ref productioncollectdata, productioncollect.productionCollectId);
            json = this.productioncollectclass.SaveProductionCollect(productioncollectdata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            productioncollectclass.OutputExcel(fileName, base.GetExcelParams(), this.productioncollect);
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
                    this.ActionOutputExcel("生产部汇总信息.xls");
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