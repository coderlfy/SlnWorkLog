using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseDataLibrary.entity
{
    public class EntityProjectCollect
    {
        /// <summary>
        /// 工程部汇总Id。
        /// </summary>
        public string projectCollectId { get; set; }
        /// <summary>
        /// 汇总分类Id。
        /// </summary>
        public string collectTypeId { get; set; }
        /// <summary>
        /// 工程部项目名称。
        /// </summary>
        public string projectItemName { get; set; }
        /// <summary>
        /// 系统名称。
        /// </summary>
        public string systemName { get; set; }
        /// <summary>
        /// 归档编号。
        /// </summary>
        public string fileNo { get; set; }
        /// <summary>
        /// 归档时间。
        /// </summary>
        public string fileTime { get; set; }
        /// <summary>
        /// 登记人。
        /// </summary>
        public string writeUser { get; set; }
        /// <summary>
        /// 登记时间。
        /// </summary>
        public string writeTime { get; set; }
        /// <summary>
        /// 登记人Ip。
        /// </summary>
        public string writeIp { get; set; }
    }
}
