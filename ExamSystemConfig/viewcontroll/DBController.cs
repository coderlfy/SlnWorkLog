/****************************************
###创建人：lify
###创建时间：2012-10-29
###公司：山西ICat Studio有限公司
###摘要：主要针对数据库相关操作（方法封装）管理。
****************************************/
using BusinessBase;
using ExamSystemConfig.common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ExamSystemConfig
{
    public partial class MainWindow
    {
        /// <summary>
        /// 从数据库获取数据到绑定UI
        /// </summary>
        private void getDBDataToUI()
        {
            #region

            string connectString = ConfigurationManager
                .ConnectionStrings["ConnectString"].ConnectionString;

            if (string.IsNullOrEmpty(connectString))
            {
                this.btnConnectDBState.Content = "数据库状态：程序无配置！";
                return;
            }
            //异步连接数据库，防止阻塞UI造成假死现象。
            DLConnectDB testconnectdb = new
                DLConnectDB(this.testConnectDB);

            testconnectdb.BeginInvoke(connectString,
                new AsyncCallback((IAsyncResult) =>
                {
                    //Wpf中UI线程中处理控件
                    this.Dispatcher.BeginInvoke(
                    new DLControlProgress(() =>
                    {
                        //TimeManager.CaculateQuerySpan(() =>
                        //{
                            initController();
                        //}, this.btnQuerySpan, this.ctlProgress);
                    }), null);
                })
                , testconnectdb);

            #endregion
        }
        /// <summary>
        /// 连接数据库代理
        /// </summary>
        /// <param name="connectString"></param>
        private delegate void DLConnectDB(string connectString);
        /// <summary>
        /// 进度空间处理代理
        /// </summary>
        private delegate void DLControlProgress();
        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <param name="connectString"></param>
        private void testConnectDB(string connectString)
        {
            #region
            try
            {
                isTestConnectDBing = true;
                this.Dispatcher.BeginInvoke(
                    new DLControlProgress(() =>
                    {
                        this.btnConnectDBState.Content = "数据库状态：正在连接中…";
                        this.ctlProgress.IsActive = true;
                    }), null);

                DateTime dt = CustomTime.GetDBServerTime(connectString);
                IsConnectingDB = true;

                this.Dispatcher.BeginInvoke(
                    new DLControlProgress(() =>
                    {
                        this.btnConnectDBState.Content = "数据库状态：已连接！";
                    }), null);
            }
            catch
            {
                this.Dispatcher.BeginInvoke(
                    new DLControlProgress(() =>
                    {
                        this.btnConnectDBState.Content = "数据库状态：连接失败，点击可重连！";
                    }), null);
            }
            finally
            {
                this.Dispatcher.BeginInvoke(
                    new DLControlProgress(() =>
                    {
                        this.ctlProgress.IsActive = false;
                    }), null);
                isTestConnectDBing = false;
            }
            #endregion
        }
        /// <summary>
        /// 定义了个虚架子，下面方法参数要用。
        /// </summary>
        private delegate void DLBusinessProcess();
        /// <summary>
        /// 进行数据库检测
        /// </summary>
        /// <param name="businessProcess"></param>
        private void AddDBCheck(DLBusinessProcess businessProcess)
        {
            #region
            if (IsConnectingDB)
                businessProcess();
            else
                ExtMessage.Show("数据库连接失败！");
            #endregion
        }
    }
}
