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
    /// BookFromCountry 的摘要说明
    /// </summary>


    public class BookFromCountry : PageHandlerBase, IHttpHandler
    {
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-09-05 09:05:30
        ***公司：山西ICat Studio有限公司
        ***友情提示：本处业务可根据实际业务进行修改；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region private member variables
        private EntityBookFromCountry bookfromcountry = new EntityBookFromCountry();
        private BookFromCountryBusiness bookfromcountryclass = new BookFromCountryBusiness();
        private BookFromCountryData bookfromcountrydata = new BookFromCountryData();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region

            this.bookfromcountry.countryId = requestObject.Params[BookFromCountryData.countryId];
            this.bookfromcountry.countryName = requestObject.Params[BookFromCountryData.countryName];
            this.bookfromcountry.usable = requestObject.Params[BookFromCountryData.usable];
            this.bookfromcountry.sort = requestObject.Params[BookFromCountryData.sort];
            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.bookfromcountryclass.GetJsonByPage(bookfromcountry, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.bookfromcountryclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            bookfromcountry.writeUser = this.SessionUserId;
            bookfromcountry.writeIp = this.SessionUserIp;

            this.bookfromcountryclass.AddRow(ref bookfromcountrydata, bookfromcountry);

            json = this.bookfromcountryclass.SaveBookFromCountry(bookfromcountrydata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            bookfromcountry.writeUser = this.SessionUserId;

            this.bookfromcountryclass.EditRow(ref bookfromcountrydata, bookfromcountry);

            json = this.bookfromcountryclass.SaveBookFromCountry(bookfromcountrydata);
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.bookfromcountryclass.DeleteRow(ref bookfromcountrydata, bookfromcountry.countryId);
            json = this.bookfromcountryclass.SaveBookFromCountry(bookfromcountrydata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            bookfromcountryclass.OutputExcel(fileName, base.GetExcelParams(), this.bookfromcountry);
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