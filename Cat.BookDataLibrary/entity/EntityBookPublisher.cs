#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***生成时间：2013-08-20 09:16:58
***公司：山西博华科技有限公司
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/

namespace Cat.BookDataLibrary
{
    public class EntityBookPublisher
    {

        /// <summary>
        ///出版社的编号 。
        /// </summary>
        public string publisherId { get; set; }
        /// <summary>
        ///出版社名称 。
        /// </summary>
        public string publisherName { get; set; }
        /// <summary>
        ///地址 。
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 是否可用。
        /// </summary>
        public string usable { get; set; }
        /// <summary>
        /// 上次登录时刻。
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 排序号。
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