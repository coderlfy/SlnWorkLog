#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***生成时间：2013-08-16 11:47:40
***公司：山西博华科技有限公司
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
    public class BookBelongToData : DataLibBase
    {

        /// <summary>
        /// 书籍所属人的编号。
        /// </summary>
        public const string belongtoId = "belongtoId";
        /// <summary>
        /// 所属人全称。
        /// </summary>
        public const string fullname = "fullname";
        /// <summary>
        ///是否可用（0不可用，1可用） 。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        ///排序号 。
        /// </summary>
        public const string sort = "sort";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string BookBelongTo = "BookBelongTo";

        private void BuildData()
        {
            DataTable dt = new DataTable(BookBelongTo);

            dt.Columns.Add(belongtoId, typeof(System.Int32));
            dt.Columns.Add(fullname, typeof(System.String));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(sort, typeof(System.Int32));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[belongtoId] };
            dt.TableName = BookBelongTo;
            this.Tables.Add(dt);
            this.DataSetName = "TBookBelongTo";
        }

        public BookBelongToData()
        {
            this.BuildData();
        }
    }
}
#endregion