﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkLogDataLibrary.business
{
    public class EntityLogsTimes
    {
        /// <summary>
        /// 用户编号（串）。
        /// </summary>
        public string writeUser { get; set; }
        /// <summary>
        /// 开始日期。
        /// </summary>
        public string startDate { get; set; }
        /// <summary>
        /// 结束日期。
        /// </summary>
        public string endDate { get; set; }

    }
}
