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
    /// IsExitReleaseConent 的摘要说明
    /// </summary>
    public class IsExitReleaseConent : PageHandlerBase, IHttpHandler
    {
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

        private void ActionInsideCollectEdit(ref string json)
        {
            #region
            this.collecttypeclass.ExitInsideCollectRecord(ref insidecollectdata, insidecollect.collectTypeId);
            json = this.insidecollectclass.SaveInsideCollect(insidecollectdata);
            #endregion
        }

        private void ActionProductionCollectEdit(ref string json)
        {
            #region
            this.collecttypeclass.ExitProductionCollectRecord(ref productioncollectdata, productioncollect.collectTypeId);
            json = this.productioncollectclass.SaveProductionCollect(productioncollectdata);
            #endregion
        }

        private void ActionProjectCollectEdit(ref string json)
        {
            #region
            this.collecttypeclass.ExitProjectCollectRecord(ref projectcollectdata, projectcollect.collectTypeId);
            json = this.projectcollectclass.SaveProjectCollect(projectcollectdata);
            #endregion
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            HttpRequest requestobject = context.Request;
            String releaseType = requestobject.QueryString["releaseType"];
            String collectTypeId = requestobject.QueryString["collectTypeId"];
            this.getPostParams(requestobject);
            String json = "";
            //判断是否存在记录
            if (releaseType == "1")
            {
                this.ActionInsideCollectEdit(ref json);
            }
            else if (releaseType == "2")
            {
                this.ActionProductionCollectEdit(ref json);
            }
            else if (releaseType == "3")
            {
                this.ActionProjectCollectEdit(ref json);
            }
            try
            {
                context.Response.Write(json);
            }
            catch(Exception e)
            {
                context.Response.Write(e.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}