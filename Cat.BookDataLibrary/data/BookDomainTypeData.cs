#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***生成时间：2013-08-16 17:46:25
***公司：山西ICat Studio有限公司
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Fundation.Core;

namespace Cat.BookDataLibrary
{
    public class BookDomainTypeData : DataLibBase
    {

        /// <summary>
        ///所属领域的编号 。
        /// </summary>
        public const string domainTypeId = "domainTypeId";
        /// <summary>
        /// 领域名称。
        /// </summary>
        public const string domainName = "domainName";
        /// <summary>
        /// 是否可用。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 简短描述。
        /// </summary>
        public const string remark = "remark";
        /// <summary>
        ///排序号 。
        /// </summary>
        public const string sort = "sort";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string BookDomainType = "BookDomainType";

        private void BuildData()
        {
            DataTable dt = new DataTable(BookDomainType);

            dt.Columns.Add(domainTypeId, typeof(System.Int32));
            dt.Columns.Add(domainName, typeof(System.String));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(remark, typeof(System.String));
            dt.Columns.Add(sort, typeof(System.Int32));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[domainTypeId] };
            dt.TableName = BookDomainType;
            this.Tables.Add(dt);
            this.DataSetName = "TBookDomainType";
        }

        public BookDomainTypeData()
        {
            this.BuildData();
        }
    }
}
#endregion