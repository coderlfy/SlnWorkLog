#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhlfy
***生成时间：2013-05-04 20:32:25
***公司：山西博华科技有限公司
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
            
namespace WorkLogDataLibrary
{
    public class EntityWLOGPersonLog
    {
        
        /// <summary>
        /// 任务项流水号。
        /// </summary>
        public string missionId { get; set; }
        /// <summary>
        /// 日志流水号。
        /// </summary>
        public string logId { get; set; }
        /// <summary>
        /// 录入人编号。
        /// </summary>
        public string writeUser { get; set; }
        /// <summary>
        /// 当前项目节点编号。
        /// </summary>
        public string projectItem { get; set; }
        /// <summary>
        /// 是否为任务项内工作日。
        /// </summary>
        public string isMission { get; set; }
        /// <summary>
        /// 日志内容。
        /// </summary>
        public string logContent { get; set; }
        /// <summary>
        /// 当天日期。
        /// </summary>
        public string logDate { get; set; }
        /// <summary>
        /// 工作完成状态。
        /// </summary>
        public string workState { get; set; }
        /// <summary>
        /// 工作成果。
        /// </summary>
        public string workResult { get; set; }
        /// <summary>
        /// 是否提交。
        /// </summary>
        public string submited { get; set; }
        /// <summary>
        /// 是否删除。
        /// </summary>
        public string deleted { get; set; }
        /// <summary>
        /// 删除时刻。
        /// </summary>
        public string deleteTime { get; set; }
        /// <summary>
        /// 可用性。
        /// </summary>
        public string usable { get; set; }
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public string writeTime { get; set; }
        /// <summary>
        /// 录入人IP地址。
        /// </summary>
        public string writeIp { get; set; }
    }
}
#endregion

