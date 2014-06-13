/****************************************
***创建人：bhwyc
***创建时间：2013-09-04 15:21:58
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
    public class BookDomainTypeBusiness : GeneralBusinesser
    {
        private BookDomainTypeClass _bookdomaintypeclass = new BookDomainTypeClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-09-04 15:21:58
        ***公司：山西ICat Studio有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods

        /// <summary>
        /// 根据条件筛选所有BookDomainType指定页码的数据（分页型）
        /// </summary>
        /// <param name="bookdomaintype">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityBookDomainType bookdomaintype, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            BookDomainTypeClass bookdomaintypeclass = new BookDomainTypeClass();
            DataSet bookdomaintypedata = this.GetData(bookdomaintype, pageparams, out totalCount);
            return base.GetJson(bookdomaintypedata, totalCount);
            #endregion
        }

        /// <summary>
        /// 保存bookdomaintypedata数据集数据
        /// </summary>
        /// <param name="bookdomaintypedata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveBookDomainType(BookDomainTypeData bookdomaintypedata)
        {
            #region
            BookDomainTypeClass bookdomaintypeclass = new BookDomainTypeClass();
            return base.Save(bookdomaintypedata, bookdomaintypeclass);
            #endregion
        }

        /// <summary>
        /// 添加BookDomainType表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="bookdomaintypedata">数据集对象</param>
        /// <param name="bookdomaintype">实体对象</param>
        public void AddRow(ref BookDomainTypeData bookdomaintypedata, EntityBookDomainType bookdomaintype)
        {
            #region
            DataRow dr = bookdomaintypedata.Tables[0].NewRow();
            bookdomaintypedata.Assign(dr, BookDomainTypeData.domainTypeId, bookdomaintype.domainTypeId);
            bookdomaintypedata.Assign(dr, BookDomainTypeData.domainName, bookdomaintype.domainName);
            bookdomaintypedata.Assign(dr, BookDomainTypeData.usable, bookdomaintype.usable);
            bookdomaintypedata.Assign(dr, BookDomainTypeData.remark, bookdomaintype.remark);
            bookdomaintypedata.Assign(dr, BookDomainTypeData.sort, bookdomaintype.sort);
            bookdomaintypedata.Tables[0].Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 编辑bookdomaintypedata数据集中指定的行数据
        /// </summary>
        /// <param name="bookdomaintypedata">数据集对象</param>
        /// <param name="bookdomaintype">实体对象</param>
        public void EditRow(ref BookDomainTypeData bookdomaintypedata, EntityBookDomainType bookdomaintype)
        {
            #region
            if (bookdomaintypedata.Tables[0].Rows.Count <= 0)
                bookdomaintypedata = this.getData(bookdomaintype.domainTypeId);
            DataRow dr = bookdomaintypedata.Tables[0].Rows.Find(new object[1] { bookdomaintype.domainTypeId });
            bookdomaintypedata.Assign(dr, BookDomainTypeData.domainTypeId, bookdomaintype.domainTypeId);
            bookdomaintypedata.Assign(dr, BookDomainTypeData.domainName, bookdomaintype.domainName);
            bookdomaintypedata.Assign(dr, BookDomainTypeData.usable, bookdomaintype.usable);
            bookdomaintypedata.Assign(dr, BookDomainTypeData.remark, bookdomaintype.remark);
            bookdomaintypedata.Assign(dr, BookDomainTypeData.sort, bookdomaintype.sort);
            #endregion
        }

        /// <summary>
        /// 删除bookdomaintypedata数据集中指定的行数据
        /// </summary>
        /// <param name="bookdomaintypedata">数据集对象</param>
        /// <param name="domainTypeId">主键-</param>
        public void DeleteRow(ref BookDomainTypeData bookdomaintypedata, string domainTypeId)
        {
            #region
            if (bookdomaintypedata.Tables[0].Rows.Count <= 0)
                bookdomaintypedata = this.getData(domainTypeId);
            DataRow dr = bookdomaintypedata.Tables[0].Rows.Find(new object[1] { domainTypeId });
            if (dr != null)
                dr.Delete();
            #endregion
        }

        /// <summary>
        /// 获取BookDomainType数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            BookDomainTypeData bookdomaintypedata = this.getData(null);
            totalCount = bookdomaintypedata.Tables[0].Rows.Count;
            return base.GetJson(bookdomaintypedata, totalCount);
            #endregion
        }

        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityBookDomainType bookdomaintype)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(bookdomaintype, queryparams, out totalcount);

            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="domainTypeId">主键-</param>
        /// <returns></returns>
        private BookDomainTypeData getData(string domainTypeId)
        {
            #region
            BookDomainTypeData bookvomaintypedata = new BookDomainTypeData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(BookDomainTypeData.domainTypeId, EnumSqlType.sqlint, EnumCondition.Equal, domainTypeId);
            this._bookdomaintypeclass.GetSingleT(bookvomaintypedata, querybusinessparams);
            return bookvomaintypedata;
            #endregion
        }

        /// <summary>
        /// 根据条件筛选所有BookDomainType指定页码的数据（分页型）
        /// </summary>
        /// <param name="bookdomaintype">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityBookDomainType bookdomaintype, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(BookDomainTypeData.domainTypeId, EnumSqlType.sqlint,
                EnumCondition.Equal, bookdomaintype.domainTypeId);
            querybusinessparams.Add(BookDomainTypeData.domainName, EnumSqlType.nvarchar,
                EnumCondition.Equal, bookdomaintype.domainName);
            querybusinessparams.Add(BookDomainTypeData.usable, EnumSqlType.bit,
                EnumCondition.Equal, bookdomaintype.usable);
            querybusinessparams.Add(BookDomainTypeData.remark, EnumSqlType.nvarchar,
                EnumCondition.Equal, bookdomaintype.remark);
            querybusinessparams.Add(BookDomainTypeData.sort, EnumSqlType.sqlint,
                EnumCondition.Equal, bookdomaintype.sort);
            BookDomainTypeData bookvomaintypedata = new BookDomainTypeData();
            totalCount = this._bookdomaintypeclass.GetSingleT(bookvomaintypedata, querybusinessparams);
            return bookvomaintypedata;
            #endregion
        }
        #endregion

        #endregion
    }
}
