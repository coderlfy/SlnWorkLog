/****************************************
###创建人：lify
###创建时间：2012-10-29
###公司：山西ICat Studio有限公司
###摘要：针对线程自定义管理（如果添加或减少后台线程数量请维护此处ThreadsMaxCount值）。
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSystemConfig
{
    class ThreadsCustom
    {
        public static int ThreadsMaxCount = 1;
        public static List<bool> _threadSuccessful;
        public static int init()
        {
            if (_threadSuccessful != null)
                _threadSuccessful.Clear();
            _threadSuccessful = new List<bool>(ThreadsMaxCount);
            for (int i = 0; i < ThreadsMaxCount; i++)
                _threadSuccessful.Add(false);
            return ThreadsMaxCount;
        }
    }
}
