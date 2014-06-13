/****************************************
***创建人：bhwyc
***创建时间：2013-09-05 09:14:50
***公司：山西博华科技有限公司
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
    public class BookInformationBusiness : GeneralBusinesser
    {
        private BookInformationClass _bookinformationclass = new BookInformationClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-09-05 09:14:50
        ***公司：山西博华科技有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods

        /// <summary>
        /// 根据条件筛选所有BookInformation指定页码的数据（分页型）
        /// </summary>
        /// <param name="bookinformation">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityBookInformation bookinformation, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            BookInformationClass bookinformationclass = new BookInformationClass();
            DataSet bookinformationdata = this.GetData(bookinformation, pageparams, out totalCount);
            return base.GetJson(bookinformationdata, totalCount);
            #endregion
        }

        /// <summary>
        /// 保存bookinformationdata数据集数据
        /// </summary>
        /// <param name="bookinformationdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveBookInformation(BookInformationData bookinformationdata)
        {
            #region
            BookInformationClass bookinformationclass = new BookInformationClass();
            return base.Save(bookinformationdata, bookinformationclass);
            #endregion
        }

        /// <summary>
        /// 添加BookInformation表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="bookinformationdata">数据集对象</param>
        /// <param name="bookinformation">实体对象</param>
        public void AddRow(ref BookInformationData bookinformationdata, EntityBookInformation bookinformation)
        {
            #region
            DataRow dr = bookinformationdata.Tables[0].NewRow();
            bookinformationdata.Assign(dr, BookInformationData.bookId, bookinformation.bookId);
            bookinformationdata.Assign(dr, BookInformationData.domainTypeId, bookinformation.domainTypeId);
            bookinformationdata.Assign(dr, BookInformationData.publisherId, bookinformation.publisherId);
            bookinformationdata.Assign(dr, BookInformationData.belongtoId, bookinformation.belongtoId);
            bookinformationdata.Assign(dr, BookInformationData.countryId, bookinformation.countryId);
            bookinformationdata.Assign(dr, BookInformationData.userId, bookinformation.userId);
            bookinformationdata.Assign(dr, BookInformationData.bookTitle, bookinformation.bookTitle);
            bookinformationdata.Assign(dr, BookInformationData.author, bookinformation.author);
            bookinformationdata.Assign(dr, BookInformationData.translator, bookinformation.translator);
            bookinformationdata.Assign(dr, BookInformationData.bookurl, bookinformation.bookurl);
            bookinformationdata.Assign(dr, BookInformationData.publishDate, bookinformation.publishDate);
            bookinformationdata.Assign(dr, BookInformationData.isbn, bookinformation.isbn);
            bookinformationdata.Assign(dr, BookInformationData.buyTime, bookinformation.buyTime);
            bookinformationdata.Assign(dr, BookInformationData.paymoney, bookinformation.paymoney);
            bookinformationdata.Assign(dr, BookInformationData.writeTime, bookinformation.writeTime);
            bookinformationdata.Tables[0].Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 编辑bookinformationdata数据集中指定的行数据
        /// </summary>
        /// <param name="bookinformationdata">数据集对象</param>
        /// <param name="bookinformation">实体对象</param>
        public void EditRow(ref BookInformationData bookinformationdata, EntityBookInformation bookinformation)
        {
            #region
            if (bookinformationdata.Tables[0].Rows.Count <= 0)
                bookinformationdata = this.getData(bookinformation.bookId);
            DataRow dr = bookinformationdata.Tables[0].Rows.Find(new object[1] { bookinformation.bookId });
            bookinformationdata.Assign(dr, BookInformationData.bookId, bookinformation.bookId);
            bookinformationdata.Assign(dr, BookInformationData.domainTypeId, bookinformation.domainTypeId);
            bookinformationdata.Assign(dr, BookInformationData.publisherId, bookinformation.publisherId);
            bookinformationdata.Assign(dr, BookInformationData.belongtoId, bookinformation.belongtoId);
            bookinformationdata.Assign(dr, BookInformationData.countryId, bookinformation.countryId);
            bookinformationdata.Assign(dr, BookInformationData.userId, bookinformation.userId);
            bookinformationdata.Assign(dr, BookInformationData.bookTitle, bookinformation.bookTitle);
            bookinformationdata.Assign(dr, BookInformationData.author, bookinformation.author);
            bookinformationdata.Assign(dr, BookInformationData.translator, bookinformation.translator);
            bookinformationdata.Assign(dr, BookInformationData.bookurl, bookinformation.bookurl);
            bookinformationdata.Assign(dr, BookInformationData.publishDate, bookinformation.publishDate);
            bookinformationdata.Assign(dr, BookInformationData.isbn, bookinformation.isbn);
            bookinformationdata.Assign(dr, BookInformationData.buyTime, bookinformation.buyTime);
            bookinformationdata.Assign(dr, BookInformationData.paymoney, bookinformation.paymoney);
            bookinformationdata.Assign(dr, BookInformationData.writeTime, bookinformation.writeTime);
            #endregion
        }

        /// <summary>
        /// 删除bookinformationdata数据集中指定的行数据
        /// </summary>
        /// <param name="bookinformationdata">数据集对象</param>
        /// <param name="bookId">主键-</param>
        public void DeleteRow(ref BookInformationData bookinformationdata, string bookId)
        {
            #region
            if (bookinformationdata.Tables[0].Rows.Count <= 0)
                bookinformationdata = this.getData(bookId);
            DataRow dr = bookinformationdata.Tables[0].Rows.Find(new object[1] { bookId });
            if (dr != null)
                dr.Delete();
            #endregion
        }

        /// <summary>
        /// 获取BookInformation数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            BookInformationData bookinformationdata = this.getData(null);
            totalCount = bookinformationdata.Tables[0].Rows.Count;
            return base.GetJson(bookinformationdata, totalCount);
            #endregion
        }

        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityBookInformation bookinformation)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(bookinformation, queryparams, out totalcount);

            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="bookId">主键-</param>
        /// <returns></returns>
        private BookInformationData getData(string bookId)
        {
            #region
            BookInformationData bookinformationdata = new BookInformationData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(BookInformationData.bookId, EnumSqlType.sqlint, EnumCondition.Equal, bookId);
            this._bookinformationclass.GetSingleT(bookinformationdata, querybusinessparams);
            return bookinformationdata;
            #endregion
        }

        /// <summary>
        /// 根据条件筛选所有BookInformation指定页码的数据（分页型）
        /// </summary>
        /// <param name="bookinformation">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityBookInformation bookinformation, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(BookInformationData.bookId, EnumSqlType.sqlint,
                EnumCondition.Equal, bookinformation.bookId);
            querybusinessparams.Add(BookInformationData.domainTypeId, EnumSqlType.sqlint,
                EnumCondition.Equal, bookinformation.domainTypeId);
            querybusinessparams.Add(BookInformationData.publisherId, EnumSqlType.tinyint,
                EnumCondition.Equal, bookinformation.publisherId);
            querybusinessparams.Add(BookInformationData.belongtoId, EnumSqlType.sqlint,
                EnumCondition.Equal, bookinformation.belongtoId);
            querybusinessparams.Add(BookInformationData.countryId, EnumSqlType.sqlint,
                EnumCondition.Equal, bookinformation.countryId);
            querybusinessparams.Add(BookInformationData.userId, EnumSqlType.nvarchar,
                EnumCondition.Equal, bookinformation.userId);
            querybusinessparams.Add(BookInformationData.bookTitle, EnumSqlType.nvarchar,
                EnumCondition.Equal, bookinformation.bookTitle);
            querybusinessparams.Add(BookInformationData.author, EnumSqlType.nvarchar,
                EnumCondition.Equal, bookinformation.author);
            querybusinessparams.Add(BookInformationData.translator, EnumSqlType.nvarchar,
                EnumCondition.Equal, bookinformation.translator);
            querybusinessparams.Add(BookInformationData.bookurl, EnumSqlType.nvarchar,
                EnumCondition.Equal, bookinformation.bookurl);
            querybusinessparams.Add(BookInformationData.publishDate, EnumSqlType.datetime,
                EnumCondition.Equal, bookinformation.publishDate);
            querybusinessparams.Add(BookInformationData.isbn, EnumSqlType.nvarchar,
                EnumCondition.Equal, bookinformation.isbn);
            querybusinessparams.Add(BookInformationData.buyTime, EnumSqlType.datetime,
                EnumCondition.Equal, bookinformation.buyTime);
            querybusinessparams.Add(BookInformationData.paymoney, EnumSqlType.sqldecimal,
                EnumCondition.Equal, bookinformation.paymoney);
            querybusinessparams.Add(BookInformationData.writeTime, EnumSqlType.datetime,
                EnumCondition.Equal, bookinformation.writeTime);
            BookInformationData bookinformationdata = new BookInformationData();
            totalCount = this._bookinformationclass.GetSingleT(bookinformationdata, querybusinessparams);
            return bookinformationdata;
            #endregion
        }
        #endregion

        #endregion
    }
}
