/****************************************
###创建人：lify
###创建时间：2012-10-29
###公司：山西博华科技有限公司
###摘要：主要针对考题维护状态进行管理。
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSystemConfig
{
    public enum ExamQuestionState
    {
        /// <summary>
        /// 普通添加
        /// </summary>
        NormalAdd,
        /// <summary>
        /// 普通编辑
        /// </summary>
        NormalEdit,
        /// <summary>
        /// 直接编辑判断题
        /// </summary>
        DirectEditEstimate,
        /// <summary>
        /// 直接编辑选择题
        /// </summary>
        DirectEditSelect,
        /// <summary>
        /// 直接编辑问答题
        /// </summary>
        DirectEditEssay
    }
}
