using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Cat.BookBusinessLibrary;
using Cat.BookDataLibrary;
using BHWorkLog.server.handler;
using Cat.BookDataLibrary.entity;

namespace BHWorkLog.server.book.handler
{
    /// <summary>
    /// Computer 的摘要说明
    /// </summary>
    public class Computer : PageHandlerBase, IHttpHandler
    {

        #region Create by iCat Assist Tools

        #region private member variables
        private EntityComputer computer = new EntityComputer();
        private ComputerBusiness computerclass = new ComputerBusiness();
        private ComputerData computerdata = new ComputerData();
        #endregion

        #region private member functions
        /// <summary>
        /// 截取页面传来的各参数。
        /// </summary>
        /// <param name="requestObject"></param>
        private void getPostParams(HttpRequest requestObject)
        {
            #region

            this.computer.computerId = requestObject.Params[ComputerData.computerId];
            this.computer.userName = requestObject.Params[ComputerData.userName];
            this.computer.userIp = requestObject.Params[ComputerData.userIp];
            this.computer.MACAddress = requestObject.Params[ComputerData.MACAddress];
            this.computer.IpUseStatus = requestObject.Params[ComputerData.IpUseStatus];
            this.computer.workStatus = requestObject.Params[ComputerData.workStatus];
            this.computer.computerType = requestObject.Params[ComputerData.computerType];
            this.computer.writeUser = requestObject.Params[ComputerData.writeUser];
            this.computer.writeTime = requestObject.Params[ComputerData.writeTime];
            this.computer.writeIp = requestObject.Params[ComputerData.writeIp];
            this.computer.remark = requestObject.Params[ComputerData.remark];

            #endregion
        }
        /// <summary>
        /// 获取分页列表信息
        /// </summary>
        /// <param name="json"></param>
        private void ActionList(ref string json)
        {
            #region
            json = this.computerclass.GetJsonByPage(computer, base.GetPageParamsFromClient());
            #endregion
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="json"></param>
        private void ActionGetAll(ref string json)
        {
            #region
            json = this.computerclass.GetJsonByAll();
            #endregion
        }
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionAddNew(ref string json)
        {
            #region
            computer.writeUser = this.SessionUserId;
            computer.writeIp = this.SessionUserIp;

            this.computerclass.AddRow(ref computerdata, computer);

            json = this.computerclass.SaveComputer(computerdata);
            #endregion
        }
        /// <summary>
        /// 编辑指定行的记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionEdit(ref string json)
        {
            #region
            computer.writeUser = this.SessionUserId;

            this.computerclass.EditRow(ref computerdata, computer);

            json = this.computerclass.SaveComputer(computerdata);
            #endregion
        }
        /// <summary>
        /// 删除指定记录
        /// </summary>
        /// <param name="json"></param>
        private void ActionDelete(ref string json)
        {
            #region
            this.computerclass.DeleteRow(ref computerdata, computer.computerId);
            json = this.computerclass.SaveComputer(computerdata);
            #endregion
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        private void ActionOutputExcel(string fileName)
        {
            #region
            computerclass.OutputExcel(fileName, base.GetExcelParams(), this.computer);
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
                    this.ActionOutputExcel("计算机参数信息.xls");
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