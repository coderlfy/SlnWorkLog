/****************************************
***创建人：bhwyc
***创建时间：2013-09-12 10:28:01
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
    public class BookBelongToBusiness : GeneralBusinesser
    {
        private BookBelongToClass _bookbelongtoclass = new BookBelongToClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-09-12 10:28:01
        ***公司：山西ICat Studio有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods

        /// <summary>
        /// 根据条件筛选所有BookBelongTo指定页码的数据（分页型）
        /// </summary>
        /// <param name="bookbelongto">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityBookBelongTo bookbelongto, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            BookBelongToClass bookbelongtoclass = new BookBelongToClass();
            DataSet bookbelongtodata = this.GetData(bookbelongto, pageparams, out totalCount);
            return base.GetJson(bookbelongtodata, totalCount);
            #endregion
        }

        /// <summary>
        /// 保存bookbelongtodata数据集数据
        /// </summary>
        /// <param name="bookbelongtodata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveBookBelongTo(BookBelongToData bookbelongtodata)
        {
            #region
            return base.Save(bookbelongtodata, this._bookbelongtoclass);
            #endregion
        }

        /// <summary>
        /// 添加BookBelongTo表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="bookbelongtodata">数据集对象</param>
        /// <param name="bookbelongto">实体对象</param>
        public void AddRow(ref BookBelongToData bookbelongtodata, EntityBookBelongTo bookbelongto)
        {
            #region
            DataRow dr = bookbelongtodata.Tables[0].NewRow();
            bookbelongtodata.Assign(dr, BookBelongToData.belongtoId, bookbelongto.belongtoId);
            bookbelongtodata.Assign(dr, BookBelongToData.fullname, bookbelongto.fullname);
            bookbelongtodata.Assign(dr, BookBelongToData.usable, bookbelongto.usable);
            bookbelongtodata.Assign(dr, BookBelongToData.sort, bookbelongto.sort);
            bookbelongtodata.Tables[0].Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 编辑bookbelongtodata数据集中指定的行数据
        /// </summary>
        /// <param name="bookbelongtodata">数据集对象</param>
        /// <param name="bookbelongto">实体对象</param>
        public void EditRow(ref BookBelongToData bookbelongtodata, EntityBookBelongTo bookbelongto)
        {
            #region
            if (bookbelongtodata.Tables[0].Rows.Count <= 0)
                bookbelongtodata = this.getData(bookbelongto.belongtoId);
            DataRow dr = bookbelongtodata.Tables[0].Rows.Find(new object[1] { bookbelongto.belongtoId });
            bookbelongtodata.Assign(dr, BookBelongToData.belongtoId, bookbelongto.belongtoId);
            bookbelongtodata.Assign(dr, BookBelongToData.fullname, bookbelongto.fullname);
            bookbelongtodata.Assign(dr, BookBelongToData.usable, bookbelongto.usable);
            bookbelongtodata.Assign(dr, BookBelongToData.sort, bookbelongto.sort);
            #endregion
        }

        /// <summary>
        /// 删除bookbelongtodata数据集中指定的行数据
        /// </summary>
        /// <param name="bookbelongtodata">数据集对象</param>
        /// <param name="belongtoId">主键-</param>
        public void DeleteRow(ref BookBelongToData bookbelongtodata, string belongtoId)
        {
            #region
            if (bookbelongtodata.Tables[0].Rows.Count <= 0)
                bookbelongtodata = this.getData(belongtoId);
            DataRow dr = bookbelongtodata.Tables[0].Rows.Find(new object[1] { belongtoId });
            if (dr != null)
                dr.Delete();
            #endregion
        }

        /// <summary>
        /// 获取BookBelongTo数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            BookBelongToData bookbelongtodata = this.getData(null);
            totalCount = bookbelongtodata.Tables[0].Rows.Count;
            return base.GetJson(bookbelongtodata, totalCount);
            #endregion
        }

        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityBookBelongTo bookbelongto)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(bookbelongto, queryparams, out totalcount);

            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="belongtoId">主键-</param>
        /// <returns></returns>
        private BookBelongToData getData(string belongtoId)
        {
            #region
            BookBelongToData bookbelongtodata = new BookBelongToData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(BookBelongToData.belongtoId, EnumSqlType.sqlint, EnumCondition.Equal, belongtoId);
            this._bookbelongtoclass.GetSingleT(bookbelongtodata, querybusinessparams);
            return bookbelongtodata;
            #endregion
        }

        /// <summary>
        /// 根据条件筛选所有BookBelongTo指定页码的数据（分页型）
        /// </summary>
        /// <param name="bookbelongto">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityBookBelongTo bookbelongto, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(BookBelongToData.belongtoId, EnumSqlType.sqlint,
                EnumCondition.Equal, bookbelongto.belongtoId);
            querybusinessparams.Add(BookBelongToData.fullname, EnumSqlType.nvarchar,
                EnumCondition.Equal, bookbelongto.fullname);
            querybusinessparams.Add(BookBelongToData.usable, EnumSqlType.bit,
                EnumCondition.Equal, bookbelongto.usable);
            querybusinessparams.Add(BookBelongToData.sort, EnumSqlType.sqlint,
                EnumCondition.Equal, bookbelongto.sort);
            BookBelongToData bookbelongdata = new BookBelongToData();
            totalCount = this._bookbelongtoclass.GetSingleT(bookbelongdata, querybusinessparams);
            return bookbelongdata;
            #endregion
        }
        #endregion

        #endregion
    }
}
