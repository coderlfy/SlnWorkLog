#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhlfy
***生成时间：2013-05-04 20:32:25
***公司：山西ICat Studio有限公司
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
            
namespace WorkLogDataLibrary
{
    public class EntityWLOGProjectTree
    {
        
        /// <summary>
        /// 父节点编号。
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 当前项目节点编号。
        /// </summary>
        public string currentId { get; set; }
        /// <summary>
        /// 用户编号。
        /// </summary>
        public string writeUser { get; set; }
        /// <summary>
        /// 项目节点名称。
        /// </summary>
        public string dirName { get; set; }
        /// <summary>
        /// 可用性。
        /// </summary>
        public string usable { get; set; }
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

