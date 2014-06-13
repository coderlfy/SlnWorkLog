/****************************************
###创建人：lify
###创建时间：2012-10-29
###公司：山西ICat Studio有限公司
###摘要：针对当前时间（数据库服务器）处理。
****************************************/
using BusinessBase;
using Fundation.Core;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;

namespace ExamSystemConfig.common
{
    class TimeManager
    {
        /// <summary>
        /// 更新当前数据库服务器时间的频率。
        /// </summary>
        private static int freqUpdateMS = 100;
        /// <summary>
        /// 读取数据库时间的频率。
        /// </summary>
        private static int freqReadDBTimeMinute = 60;
        /// <summary>
        /// 当前数据库服务器的时间。
        /// </summary>
        public static DateTime CurrentDBServerTime = DateTime.Now;
        /// <summary>
        /// 开启服务时的时间（每次开启服务时赋值）。
        /// </summary>
        public static DateTime StartServiceTime = DateTime.Now;
        /// <summary>
        /// 同步数据库服务器时间。
        /// </summary>
        public static void SyncDBServerTime(object state)
        {
            #region
            CurrentDBServerTime = CustomTime.GetDBServerTime();
            StartServiceTime = CurrentDBServerTime;
            int timespan = 0;
            while (true)
            {
                if ((timespan % (freqReadDBTimeMinute * 60 * 1000)) == 0
                    && timespan != 0)
                {
                    timespan = 0;
                    CurrentDBServerTime = CustomTime.GetDBServerTime();
                }

                CurrentDBServerTime = CurrentDBServerTime
                    .AddMilliseconds(freqUpdateMS);

                //绝对不能去掉哈，不懂去问（影响到线程重启的信号量）
                ThreadsCustom._threadSuccessful[(int)state] = true;

                Thread.Sleep(freqUpdateMS);
                timespan+=freqUpdateMS;
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetDBServerTime()
        {
            #region
            return CurrentDBServerTime.ToString("yyyy-MM-dd hh:mm:ss");
            #endregion
        }
        public delegate void UIShow();
        public delegate void WillCaculatefn();
        public static void CaculateQuerySpan(WillCaculatefn fn, UIShow uishow,
            ContentControl ctl, ProgressRing progress)
        {
            #region
            string tmp = "";
            progress.IsActive = true;
            DateTime starttime = DateTime.Now;
            fn.BeginInvoke(new AsyncCallback((IAsyncResult) =>
            {
                DateTime endtime = DateTime.Now;
                if (MainWindow.IsConnectingDB)
                {
                    tmp = string.Format("上次查询时长：{0}ms",
                        (endtime - starttime).TotalMilliseconds);
                }
                else
                    tmp = "上次查询时长：超时！";

                ctl.Dispatcher.BeginInvoke(new UIShow(() =>
                {
                    ctl.Content = tmp;
                    progress.IsActive = false;
                    uishow.Invoke();
                }));
            }), fn);
            #endregion
        }
    }
}
