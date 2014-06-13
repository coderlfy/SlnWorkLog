using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Cat.BookBusinessLibrary;
using Cat.BookDataLibrary;
using BHWorkLog.server.handler;

namespace BHWorkLog.server.book.handler
{
    /// <summary>
    /// BookPublisher 的摘要说明
    /// </summary>

    public class BookPublisher : PageHandlerBase, IHttpHandler
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-08-20 09:11:39
        ***公司：山西博华科技有限公司
        ***友情提示：本处业务可根据实际业务进行修改；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region private member variables
        private EntityBookPublisher bookpublisher = new EntityBookPublisher();
        private BookPublisherBusiness bookpublisherclass = new BookPublisherBusiness();
        private BookPublisherData bookpublisherdata = new BookPublisherData();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region

            this.bookpublisher.publisherId = requestObject.Params[BookPublisherData.publisherId];
            this.bookpublisher.publisherName = requestObject.Params[BookPublisherData.publisherName];
            this.bookpublisher.address = requestObject.Params[BookPublisherData.address];
            this.bookpublisher.usable = requestObject.Params[BookPublisherData.usable];
            this.bookpublisher.sort = requestObject.Params[BookPublisherData.sort];
            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.bookpublisherclass.GetJsonByPage(bookpublisher, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.bookpublisherclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            bookpublisher.writeUser = this.SessionUserId;
            bookpublisher.writeIp = this.SessionUserIp;

            this.bookpublisherclass.AddRow(ref bookpublisherdata, bookpublisher);

            json = this.bookpublisherclass.SaveBookPublisher(bookpublisherdata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            bookpublisher.writeUser = this.SessionUserId;

            this.bookpublisherclass.EditRow(ref bookpublisherdata, bookpublisher);

            json = this.bookpublisherclass.SaveBookPublisher(bookpublisherdata);
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.bookpublisherclass.DeleteRow(ref bookpublisherdata, bookpublisher.publisherId);
            json = this.bookpublisherclass.SaveBookPublisher(bookpublisherdata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            bookpublisherclass.OutputExcel(fileName, base.GetExcelParams(), this.bookpublisher);
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