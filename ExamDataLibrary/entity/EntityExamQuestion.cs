#region Create by iCat Assist Tools
/****************************************
***生成器版本：V2.0.0.32008
***创建人：bhlfy
***生成时间：2013-10-27 08:26:12
***公司：山西ICat Studio有限公司
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
            
namespace ExamDataLibrary
{
    public class EntityExamQuestion
    {
        
        /// <summary>
        /// 问题编号。
        /// </summary>
        public string questionId { get; set; }
        /// <summary>
        /// 问题类型（选择题、判断题、问答题）。
        /// </summary>
        public string questionTypeId { get; set; }
        /// <summary>
        /// 问题领域编号。
        /// </summary>
        public string questionScopeId { get; set; }
        /// <summary>
        /// 问题标题。
        /// </summary>
        public string questionName { get; set; }
        /// <summary>
        /// 可用性。
        /// </summary>
        public string usable { get; set; }
        /// <summary>
        /// 排序号。
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 录入人。
        /// </summary>
        public string writeUser { get; set; }
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

