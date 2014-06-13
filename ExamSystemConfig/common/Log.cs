/****************************************
###创建人：lify
###创建时间：2012-06-29
###公司：山西博华科技有限公司
###最后修改时间：2012-06-29
###最后修改人：lify
###修改摘要：
****************************************/
using ExamSystemConfig.custom;
using Fundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace ExamSystemConfig.common
{
    class Log
    {
        private static bool _viewConsole = true;
        public static readonly object LogLockObject = 0;
        /// <summary>
        /// 日志文件名称
        /// </summary>
        public static String LogFileName
        {
            #region
            get
            {
                return DateTime.Now.ToString("yyyyMMdd") + ".txt";
            }
            #endregion
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="error"></param>
        public static void Write(string error)
        {
            #region
            lock (LogLockObject)
            {
                LogBusiness log = new LogBusiness(
                    CustomConfig.LogDirectoryName, LogFileName);

                string logTemplate = "错误发生在：{0}\r\n{1}";
                string logContent = String.Format(logTemplate, DateTime.Now.ToString(), error);
                log.writefile(logContent);
                ExtConsole.WriteWithColor(logContent);
                //if(_viewConsole)
                //    MainView.AsyncAppendContent(error+"\r\n\r\n");
            }
            #endregion
        }
        /// <summary>
        /// 是否显示错误在控制台
        /// </summary>
        /// <param name="enable"></param>
        public static void EnableViewError(bool enable)
        {
            #region
            _viewConsole = enable;
            #endregion
        }
        /// <summary>
        /// 系统错误捕捉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            #region
            Write(e.Exception.ToString());
            e.Handled = true; 
            #endregion
        }
        /// <summary>
        /// 安排事件侦听错误
        /// </summary>
        public static void Listen(App application)
        {
            #region
            application.DispatcherUnhandledException += new
                System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(Application_ThreadException);
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static WaitCallback Wrap(WaitCallback callback,
            object state)
        {
            #region
            return new WaitCallback(
                delegate
                {
                    try
                    {
                        callback(state);

                    }
                    catch (Exception ex)
                    {
                        ThreadsCustom._threadSuccessful[(int)state] = false;
                        ExtConsole.WriteWithColor(ex.ToString());
                    }
                });
            #endregion
        }

    }
}
