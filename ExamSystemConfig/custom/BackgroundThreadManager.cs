/****************************************
###创建人：lify
###创建时间：2012-10-29
###公司：山西ICat Studio有限公司
###摘要：针对后台线程的管理。
****************************************/
using ExamSystemConfig.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExamSystemConfig
{
    class BackgroundThreadManager
    {
        public static bool IsStart = false;
        public static bool IsFirstStart = false;
        private static Thread thdAnalysis = null;
        private static int freqCheckThreadMinute = 1;
        private static int threadsTempCount = 0;
        /// <summary>
        /// 启动所有后台线程
        /// </summary>
        public static void StartAll()
        {
            #region
            if (!IsFirstStart)
            {
                IsFirstStart = true;
                thdAnalysis = new Thread(new ThreadStart(start));
                thdAnalysis.IsBackground = true;
                thdAnalysis.Start();
            }
            else
                BackgroundThreadManager.IsStart = true;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public static void StopAll()
        {
            #region
            BackgroundThreadManager.IsStart = false;
            #endregion
        }
        /// <summary>
        /// 将所有线程扔进池（未免池出错，又开启了个轮询功能）
        /// </summary>
        private static void start()
        {
            #region
            BackgroundThreadManager.IsStart = true;
            ThreadsCustom.init();
            while (true)
            {
                threadsTempCount = ThreadsCustom.ThreadsMaxCount;
                addBackGroundThread(TimeManager.SyncDBServerTime);
                Thread.Sleep(freqCheckThreadMinute * 60 * 1000);
            }
            #endregion
        }
        /// <summary>
        /// 添加后台线程。
        /// </summary>
        /// <param name="callback"></param>
        private static void addBackGroundThread(WaitCallback callback)
        {
            #region
            threadsTempCount--;
            if (!ThreadsCustom._threadSuccessful[threadsTempCount])
            {
                ThreadPool.QueueUserWorkItem(
                    Log.Wrap(callback,
                    threadsTempCount));
            }
            #endregion
        }
    }
}
