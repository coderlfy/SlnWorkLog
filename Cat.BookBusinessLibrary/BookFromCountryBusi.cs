/****************************************
***创建人：bhwyc
***创建时间：2013-09-05 09:05:58
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using System;
using System.Data;

using ExportExcelLib;
using Cat.BookDataLibrary;
using Cat.BookSqlLibrary;
using BusinessBase;
using Fundation.Core;

namespace Cat.BookBusinessLibrary
{
    public class BookFromCountryBusiness : GeneralBusinesser
    {
        private BookFromCountryClass _bookfromcountryclass = new BookFromCountryClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-09-05 09:05:58
        ***公司：山西ICat Studio有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods

        /// <summary>
        /// 根据条件筛选所有BookFromCountry指定页码的数据（分页型）
        /// </summary>
        /// <param name="bookfromcountry">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityBookFromCountry bookfromcountry, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            BookFromCountryClass bookfromcountryclass = new BookFromCountryClass();
            DataSet bookfromcountrydata = this.GetData(bookfromcountry, pageparams, out totalCount);
            return base.GetJson(bookfromcountrydata, totalCount);
            #endregion
        }

        /// <summary>
        /// 保存bookfromcountrydata数据集数据
        /// </summary>
        /// <param name="bookfromcountrydata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveBookFromCountry(BookFromCountryData bookfromcountrydata)
        {
            #region
            BookFromCountryClass bookfromcountryclass = new BookFromCountryClass();
            return base.Save(bookfromcountrydata, bookfromcountryclass);
            #endregion
        }

        /// <summary>
        /// 添加BookFromCountry表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="bookfromcountrydata">数据集对象</param>
        /// <param name="bookfromcountry">实体对象</param>
        public void AddRow(ref BookFromCountryData bookfromcountrydata, EntityBookFromCountry bookfromcountry)
        {
            #region
            DataRow dr = bookfromcountrydata.Tables[0].NewRow();
            bookfromcountrydata.Assign(dr, BookFromCountryData.countryId, bookfromcountry.countryId);
            bookfromcountrydata.Assign(dr, BookFromCountryData.countryName, bookfromcountry.countryName);
            bookfromcountrydata.Assign(dr, BookFromCountryData.usable, bookfromcountry.usable);
            bookfromcountrydata.Assign(dr, BookFromCountryData.sort, bookfromcountry.sort);
            bookfromcountrydata.Tables[0].Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 编辑bookfromcountrydata数据集中指定的行数据
        /// </summary>
        /// <param name="bookfromcountrydata">数据集对象</param>
        /// <param name="bookfromcountry">实体对象</param>
        public void EditRow(ref BookFromCountryData bookfromcountrydata, EntityBookFromCountry bookfromcountry)
        {
            #region
            if (bookfromcountrydata.Tables[0].Rows.Count <= 0)
                bookfromcountrydata = this.getData(bookfromcountry.countryId);
            DataRow dr = bookfromcountrydata.Tables[0].Rows.Find(new object[1] { bookfromcountry.countryId });
            bookfromcountrydata.Assign(dr, BookFromCountryData.countryId, bookfromcountry.countryId);
            bookfromcountrydata.Assign(dr, BookFromCountryData.countryName, bookfromcountry.countryName);
            bookfromcountrydata.Assign(dr, BookFromCountryData.usable, bookfromcountry.usable);
            bookfromcountrydata.Assign(dr, BookFromCountryData.sort, bookfromcountry.sort);
            #endregion
        }

        /// <summary>
        /// 删除bookfromcountrydata数据集中指定的行数据
        /// </summary>
        /// <param name="bookfromcountrydata">数据集对象</param>
        /// <param name="countryId">主键-</param>
        public void DeleteRow(ref BookFromCountryData bookfromcountrydata, string countryId)
        {
            #region
            if (bookfromcountrydata.Tables[0].Rows.Count <= 0)
                bookfromcountrydata = this.getData(countryId);
            DataRow dr = bookfromcountrydata.Tables[0].Rows.Find(new object[1] { countryId });
            if (dr != null)
                dr.Delete();
            #endregion
        }

        /// <summary>
        /// 获取BookFromCountry数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            BookFromCountryData bookfromcountrydata = this.getData(null);
            totalCount = bookfromcountrydata.Tables[0].Rows.Count;
            return base.GetJson(bookfromcountrydata, totalCount);
            #endregion
        }

        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityBookFromCountry bookfromcountry)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(bookfromcountry, queryparams, out totalcount);

            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="countryId">主键-</param>
        /// <returns></returns>
        private BookFromCountryData getData(string countryId)
        {
            #region
            BookFromCountryData bookfromcountrydata = new BookFromCountryData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(BookFromCountryData.countryId, EnumSqlType.sqlint, EnumCondition.Equal, countryId);
            this._bookfromcountryclass.GetSingleT(bookfromcountrydata, querybusinessparams);
            return bookfromcountrydata;
            #endregion
        }

        /// <summary>
        /// 根据条件筛选所有BookFromCountry指定页码的数据（分页型）
        /// </summary>
        /// <param name="bookfromcountry">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityBookFromCountry bookfromcountry, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(BookFromCountryData.countryId, EnumSqlType.sqlint,
                EnumCondition.Equal, bookfromcountry.countryId);
            querybusinessparams.Add(BookFromCountryData.countryName, EnumSqlType.nvarchar,
                EnumCondition.Equal, bookfromcountry.countryName);
            querybusinessparams.Add(BookFromCountryData.usable, EnumSqlType.bit,
                EnumCondition.Equal, bookfromcountry.usable);
            querybusinessparams.Add(BookFromCountryData.sort, EnumSqlType.sqlint,
                EnumCondition.Equal, bookfromcountry.sort);
            BookFromCountryData bookfromcountrydata = new BookFromCountryData();
            totalCount = this._bookfromcountryclass.GetSingleT(bookfromcountrydata, querybusinessparams);
            return bookfromcountrydata;
            #endregion
        }
        #endregion

        #endregion
    }
}
