#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhwyc
***生成时间：2013-08-16 14:57:56
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
    public class BookFromCountryData : DataLibBase
    {

        /// <summary>
        ///国家的编号 。
        /// </summary>
        public const string countryId = "countryId";
        /// <summary>
        ///国家名称 。
        /// </summary>
        public const string countryName = "countryName";
        /// <summary>
        /// 是否可用。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 排序号。
        /// </summary>
        public const string sort = "sort";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string BookFromCountry = "BookFromCountry";

        private void BuildData()
        {
            DataTable dt = new DataTable(BookFromCountry);

            dt.Columns.Add(countryId, typeof(System.Int32));
            dt.Columns.Add(countryName, typeof(System.String));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(sort, typeof(System.Int32));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[countryId] };
            dt.TableName = BookFromCountry;
            this.Tables.Add(dt);
            this.DataSetName = "TBookFromCountry";
        }

        public BookFromCountryData()
        {
            this.BuildData();
        }
    }
}
#endregion