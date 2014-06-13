#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***生成时间：2013-08-20 09:14:41
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
    public class BookPublisherData : DataLibBase
    {

        /// <summary>
        /// 。
        /// </summary>
        public const string publisherId = "publisherId";
        /// <summary>
        /// 。
        /// </summary>
        public const string publisherName = "publisherName";
        /// <summary>
        /// 。
        /// </summary>
        public const string address = "address";
        /// <summary>
        /// 。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 。
        /// </summary>
        public const string sort = "sort";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string BookPublisher = "BookPublisher";

        private void BuildData()
        {
            DataTable dt = new DataTable(BookPublisher);

            dt.Columns.Add(publisherId, typeof(System.Byte));
            dt.Columns.Add(publisherName, typeof(System.String));
            dt.Columns.Add(address, typeof(System.String));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(sort, typeof(System.Int32));
            dt.TableName = BookPublisher;
            this.Tables.Add(dt);
            this.DataSetName = "TBookPublisher";
        }

        public BookPublisherData()
        {
            this.BuildData();
        }
    }
}
#endregion