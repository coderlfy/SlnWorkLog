#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.28380
***创建人：bhlfy
***生成时间：2013-04-06 17:01:07
***公司：山西博华科技有限公司
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
            
namespace SystemDataLibrary
{
    public class EntityErrorLogs
    {
        
        /// <summary>
        /// 错误日志编号。
        /// </summary>
        public string errorId { get; set; }
        /// <summary>
        /// 用户编号。
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 录入人IP地址。
        /// </summary>
        public string writeIp { get; set; }
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public string writeTime { get; set; }
        /// <summary>
        /// 错误日志内容。
        /// </summary>
        public string Content { get; set; }
    }
}
#endregion
