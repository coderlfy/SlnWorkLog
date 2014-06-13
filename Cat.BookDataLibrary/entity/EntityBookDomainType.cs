#region Create by iCat Assist Tools

namespace Cat.BookDataLibrary
{
    public class EntityBookDomainType
    {
        /// <summary>
        /// 所属领域的编号。
        /// </summary>
        public string domainTypeId { get; set; }
        /// <summary>
        /// 领域名称。
        /// </summary>
        public string domainName { get; set; }
        /// <summary>
        /// 是否可用。
        /// </summary>
        public string usable { get; set; }
        /// <summary>
        /// 简短描述。
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 排序号。
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 上次登录时刻。
        /// </summary>
        public string lastLoginTime { get; set; }
        /// <summary>
        /// 登陆次数。
        /// </summary>
        public string loginTimes { get; set; }
        /// <summary>
        /// 录入人。
        /// </summary>
        public string writeUser { get; set; }
        /// <summary>
        /// ip地址。
        /// </summary>
        public string writeIp { get; set; }
    }
}
#endregion