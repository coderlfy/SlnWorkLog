#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***生成时间：2013-08-16 16:19:12
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
    public class BookInformationData : DataLibBase
    {

        /// <summary>
        /// 。
        /// </summary>
        public const string bookId = "bookId";
        /// <summary>
        /// 。
        /// </summary>
        public const string domainTypeId = "domainTypeId";
        /// <summary>
        /// 。
        /// </summary>
        public const string publisherId = "publisherId";
        /// <summary>
        /// 。
        /// </summary>
        public const string belongtoId = "belongtoId";
        /// <summary>
        /// 。
        /// </summary>
        public const string countryId = "countryId";
        /// <summary>
        /// 。
        /// </summary>
        public const string userId = "userId";
        /// <summary>
        /// 。
        /// </summary>
        public const string bookTitle = "bookTitle";
        /// <summary>
        /// 。
        /// </summary>
        public const string author = "author";
        /// <summary>
        /// 。
        /// </summary>
        public const string translator = "translator";
        /// <summary>
        /// 。
        /// </summary>
        public const string bookurl = "bookurl";
        /// <summary>
        /// 。
        /// </summary>
        public const string publishDate = "publishDate";
        /// <summary>
        /// 。
        /// </summary>
        public const string isbn = "isbn";
        /// <summary>
        /// 。
        /// </summary>
        public const string buyTime = "buyTime";
        /// <summary>
        /// 。
        /// </summary>
        public const string paymoney = "paymoney";
        /// <summary>
        /// 。
        /// </summary>
        public const string writeTime = "writeTime";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string BookInformation = "BookInformation";

        private void BuildData()
        {
            DataTable dt = new DataTable(BookInformation);

            dt.Columns.Add(bookId, typeof(System.Int32));
            dt.Columns.Add(domainTypeId, typeof(System.Int32));
            dt.Columns.Add(publisherId, typeof(System.Byte));
            dt.Columns.Add(belongtoId, typeof(System.Int32));
            dt.Columns.Add(countryId, typeof(System.Int32));
            dt.Columns.Add(userId, typeof(System.String));
            dt.Columns.Add(bookTitle, typeof(System.String));
            dt.Columns.Add(author, typeof(System.String));
            dt.Columns.Add(translator, typeof(System.String));
            dt.Columns.Add(bookurl, typeof(System.String));
            dt.Columns.Add(publishDate, typeof(System.DateTime));
            dt.Columns.Add(isbn, typeof(System.String));
            dt.Columns.Add(buyTime, typeof(System.DateTime));
            dt.Columns.Add(paymoney, typeof(System.Decimal));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[bookId] };
            dt.TableName = BookInformation;
            this.Tables.Add(dt);
            this.DataSetName = "TBookInformation";
        }

        public BookInformationData()
        {
            this.BuildData();
        }
    }
}
#endregion