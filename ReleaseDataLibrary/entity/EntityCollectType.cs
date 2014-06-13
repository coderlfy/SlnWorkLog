using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseDataLibrary.entity
{
    public class EntityCollectType
    {
        /// <summary>
        /// 汇总分类Id。
        /// </summary>
        public string collectTypeId { get; set; }
        /// <summary>
        /// 发布编号。
        /// </summary>
        public string releaseNo { get; set; }
        /// <summary>
        /// 发布类型。
        /// </summary>
        public string releaseType { get; set; }
        /// <summary>
        /// 发布时间。
        /// </summary>
        public string releaseTime { get; set; }
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
