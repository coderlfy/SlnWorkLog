#region Create by iCat Assist Tools
/****************************************
***生成器版本：V2.0.0.32008
***创建人：bhlfy
***生成时间：2013-10-27 08:26:12
***公司：山西博华科技有限公司
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
            
namespace ExamDataLibrary
{
    public class EntityExamHistory
    {
        
        /// <summary>
        /// 考试成绩单编号。
        /// </summary>
        public string examHistoryId { get; set; }
        /// <summary>
        /// 考卷编号。
        /// </summary>
        public string examPaperId { get; set; }
        /// <summary>
        /// 评分人评语。
        /// </summary>
        public string giveScoreRemark { get; set; }
        /// <summary>
        /// 评分人。
        /// </summary>
        public string giveScoreUser { get; set; }
        /// <summary>
        /// 评卷时间。
        /// </summary>
        public string giveScoreTime { get; set; }
        /// <summary>
        /// 答题人。
        /// </summary>
        public string writeUser { get; set; }
        /// <summary>
        /// 答题提交时间。
        /// </summary>
        public string examSubmitTime { get; set; }
        /// <summary>
        /// 录入人IP地址。
        /// </summary>
        public string writeIp { get; set; }
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public string writeTime { get; set; }
    }
}
#endregion

