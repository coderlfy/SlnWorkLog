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
    /// BookInformation 的摘要说明
    /// </summary>


    public class BookInformation : PageHandlerBase, IHttpHandler
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-09-05 09:14:08
        ***公司：山西博华科技有限公司
        ***友情提示：本处业务可根据实际业务进行修改；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region private member variables
        private EntityBookInformation bookinformation = new EntityBookInformation();
        private BookInformationBusiness bookinformationclass = new BookInformationBusiness();
        private BookInformationData bookinformationdata = new BookInformationData();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region

            this.bookinformation.bookId = requestObject.Params[BookInformationData.bookId];
            this.bookinformation.domainTypeId = requestObject.Params[BookInformationData.domainTypeId];
            this.bookinformation.publisherId = requestObject.Params[BookInformationData.publisherId];
            this.bookinformation.belongtoId = requestObject.Params[BookInformationData.belongtoId];
            this.bookinformation.countryId = requestObject.Params[BookInformationData.countryId];
            this.bookinformation.userId = requestObject.Params[BookInformationData.userId];
            this.bookinformation.bookTitle = requestObject.Params[BookInformationData.bookTitle];
            this.bookinformation.author = requestObject.Params[BookInformationData.author];
            this.bookinformation.translator = requestObject.Params[BookInformationData.translator];
            this.bookinformation.bookurl = requestObject.Params[BookInformationData.bookurl];
            this.bookinformation.publishDate = requestObject.Params[BookInformationData.publishDate];
            this.bookinformation.isbn = requestObject.Params[BookInformationData.isbn];
            this.bookinformation.buyTime = requestObject.Params[BookInformationData.buyTime];
            this.bookinformation.paymoney = requestObject.Params[BookInformationData.paymoney];
            this.bookinformation.writeTime = requestObject.Params[BookInformationData.writeTime];
            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.bookinformationclass.GetJsonByPage(bookinformation, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.bookinformationclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            bookinformation.writeUser = this.SessionUserId;
            bookinformation.writeIp = this.SessionUserIp;

            this.bookinformationclass.AddRow(ref bookinformationdata, bookinformation);

            json = this.bookinformationclass.SaveBookInformation(bookinformationdata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            bookinformation.writeUser = this.SessionUserId;

            this.bookinformationclass.EditRow(ref bookinformationdata, bookinformation);

            json = this.bookinformationclass.SaveBookInformation(bookinformationdata);
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.bookinformationclass.DeleteRow(ref bookinformationdata, bookinformation.bookId);
            json = this.bookinformationclass.SaveBookInformation(bookinformationdata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            bookinformationclass.OutputExcel(fileName, base.GetExcelParams(), this.bookinformation);
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
