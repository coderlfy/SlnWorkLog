using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.BookDataLibrary.entity
{
    public class EntityComputer
    {
        /// <summary>
        /// 计算机Id(序列号)
        /// </summary>
        public string computerId { get; set; }
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 使用人Ip
        /// </summary>
        public string userIp { get; set; }
        /// <summary>
        /// MAC地址
        /// </summary>
        public string MACAddress { get; set; }
        /// <summary>
        /// Ip使用状态（1 使用中 2 未使用）
        /// </summary>
        public string IpUseStatus { get; set; }
        /// <summary>
        /// 工作状态（1 在职 2 离职）
        /// </summary>
        public string workStatus { get; set; }
        /// <summary>
        /// 计算机类型（1 台式 2 笔记本）
        /// </summary>
        public string computerType { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        public string writeUser { get; set; }
        /// <summary>
        /// 录入时刻
        /// </summary>
        public string writeTime { get; set; }
        /// <summary>
        /// 录入人Ip
        /// </summary>
        public string writeIp { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }
}
