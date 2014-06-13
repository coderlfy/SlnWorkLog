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
    /// CollectType 的摘要说明
    /// </summary>
    public class CollectType : PageHandlerBase, IHttpHandler
    {

        #region Create by iCat Assist Tools

        #region private member variables

        private EntityCollectType collecttype = new EntityCollectType();
        private CollectTypeBusiness collecttypeclass = new CollectTypeBusiness();
        private CollectTypeData collecttypedata = new CollectTypeData();

        private EntityInsideCollect insidecollect = new EntityInsideCollect();
        private InsideCollectBusiness insidecollectclass = new InsideCollectBusiness();
        private InsideCollectData insidecollectdata = new InsideCollectData();

        private EntityProductionCollect productioncollect = new EntityProductionCollect();
        private ProductionCollectBusiness productioncollectclass = new ProductionCollectBusiness();
        private ProductionCollectData productioncollectdata = new ProductionCollectData();

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

            this.collecttype.collectTypeId = requestObject.Params[CollectTypeData.collectTypeId];
            this.collecttype.releaseNo = requestObject.Params[CollectTypeData.releaseNo];
            this.collecttype.releaseType = requestObject.Params[CollectTypeData.releaseType];
            this.collecttype.releaseTime = requestObject.Params[CollectTypeData.releaseTime];
            this.collecttype.writeUser = requestObject.Params[CollectTypeData.writeUser];
            this.collecttype.writeTime = requestObject.Params[CollectTypeData.writeTime];
            this.collecttype.writeIp = requestObject.Params[CollectTypeData.writeIp];

            this.insidecollect.insideCollectId = requestObject.Params[InsideCollectData.insideCollectId];
            this.insidecollect.collectTypeId = requestObject.Params[InsideCollectData.collectTypeId];
            this.insidecollect.systemName = requestObject.Params[InsideCollectData.systemName];
            this.insidecollect.fileNo = requestObject.Params[InsideCollectData.fileNo];
            this.insidecollect.fileTime = requestObject.Params[InsideCollectData.fileTime];
            this.insidecollect.writeUser = requestObject.Params[InsideCollectData.writeUser];
            this.insidecollect.writeTime = requestObject.Params[InsideCollectData.writeTime];
            this.insidecollect.writeIp = requestObject.Params[InsideCollectData.writeIp];

            this.productioncollect.productionCollectId = requestObject.Params[ProductionCollectData.productionCollectId];
            this.productioncollect.collectTypeId = requestObject.Params[ProductionCollectData.collectTypeId];
            this.productioncollect.systemName = requestObject.Params[ProductionCollectData.systemName];
            this.productioncollect.fileNo = requestObject.Params[ProductionCollectData.fileNo];
            this.productioncollect.fileTime = requestObject.Params[ProductionCollectData.fileTime];
            this.productioncollect.writeUser = requestObject.Params[ProductionCollectData.writeUser];
            this.productioncollect.writeTime = requestObject.Params[ProductionCollectData.writeTime];
            this.productioncollect.writeIp = requestObject.Params[ProductionCollectData.writeIp];

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
            json = this.collecttypeclass.GetJsonByPage(collecttype, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.collecttypeclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            collecttype.writeUser = this.SessionUserId;
            collecttype.writeIp = this.SessionUserIp;

            this.collecttypeclass.AddRow(ref collecttypedata, collecttype);

            json = this.collecttypeclass.SaveCollectType(collecttypedata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            collecttype.writeUser = this.SessionUserId;

            this.collecttypeclass.EditRow(ref collecttypedata, collecttype);

            json = this.collecttypeclass.SaveCollectType(collecttypedata);
            #endregion
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionInsideCollectAddNew(ref string json, string collectTypeId)
        {
            #region
            insidecollect.writeUser = this.SessionUserId;
            insidecollect.writeIp = this.SessionUserIp;
            insidecollect.collectTypeId = collectTypeId;

            this.insidecollectclass.AddRow(ref insidecollectdata, insidecollect);

            json = this.insidecollectclass.SaveInsideCollect(insidecollectdata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionInsideCollectEdit(ref string json, string collectTypeId)
        {
            #region
            insidecollect.writeUser = this.SessionUserId;
            insidecollect.writeIp = this.SessionUserIp;
            insidecollect.collectTypeId = collectTypeId;

            this.insidecollectclass.EditRowByCollectTypeId(ref insidecollectdata, insidecollect);

            json = this.insidecollectclass.SaveInsideCollect(insidecollectdata);
            #endregion
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionProjectCollectAddNew(ref string json, string collectTypeId)
        {
            #region
            projectcollect.writeUser = this.SessionUserId;
            projectcollect.writeIp = this.SessionUserIp;
            projectcollect.collectTypeId = collectTypeId;

            this.projectcollectclass.AddRow(ref projectcollectdata, projectcollect);

            json = this.projectcollectclass.SaveProjectCollect(projectcollectdata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionProjectCollectEdit(ref string json, string collectTypeId)
        {
            #region
            projectcollect.writeUser = this.SessionUserId;
            projectcollect.collectTypeId = collectTypeId;

            this.projectcollectclass.EditRowByCollectTypeId(ref projectcollectdata, projectcollect);

            json = this.projectcollectclass.SaveProjectCollect(projectcollectdata);
            #endregion
        }

        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionProductionCollectAddNew(ref string json, string collectTypeId)
        {
            #region
            productioncollect.writeUser = this.SessionUserId;
            productioncollect.writeIp = this.SessionUserIp;
            productioncollect.collectTypeId = collectTypeId;

            this.productioncollectclass.AddRow(ref productioncollectdata, productioncollect);

            json = this.productioncollectclass.SaveProductionCollect(productioncollectdata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionProductionCollectEdit(ref string json, string collectTypeId)
        {
            #region
            productioncollect.writeUser = this.SessionUserId;
            productioncollect.collectTypeId = collectTypeId;

            this.productioncollectclass.EditRowByCollectTypeId(ref productioncollectdata, productioncollect);

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
            this.collecttypeclass.DeleteRow(ref collecttypedata, collecttype.collectTypeId);
            json = this.collecttypeclass.SaveCollectType(collecttypedata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            collecttypeclass.OutputExcel(fileName, base.GetExcelParams(), this.collecttype);
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
            String releaseType = requestobject.QueryString["releaseType"];
            String collectTypeId = requestobject.QueryString["collectTypeId"];
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
                    this.ActionOutputExcel("汇总分类信息.xls");
                    break;
                default:
                    break;
            }
            if (action == "_add" && releaseType == "1")
            {
                this.ActionInsideCollectAddNew(ref json, collectTypeId);
            }
            else if (action == "_update" && releaseType == "1")
            {
                this.ActionInsideCollectEdit(ref json, collectTypeId);
            }
            else if (action == "_add" && releaseType == "2")
            {
                this.ActionProductionCollectAddNew(ref json, collectTypeId);
            }
            else if (action == "_update" && releaseType == "2")
            {
                this.ActionProductionCollectEdit(ref json, collectTypeId);
            }
            else if (action == "_add" && releaseType == "3")
            {
                this.ActionProjectCollectAddNew(ref json, collectTypeId);
            }
            else if (action == "_update" && releaseType == "3")
            {
                this.ActionProjectCollectEdit(ref json, collectTypeId);
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