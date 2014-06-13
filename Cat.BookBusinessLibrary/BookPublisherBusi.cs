/****************************************
***创建人：bhwyc
***创建时间：2013-08-20 09:13:26
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
    public class BookPublisherBusiness : GeneralBusinesser
    {
        private BookPublisherClass _bookpublisherclass = new BookPublisherClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-08-20 09:13:26
        ***公司：山西ICat Studio有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        
        /// <summary>
        /// 根据条件筛选所有BookPublisher指定页码的数据（分页型）
        /// </summary>
        /// <param name="bookpublisher">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityBookPublisher bookpublisher, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            BookPublisherClass bookpublisherclass = new BookPublisherClass();
            DataSet bookpublisherdata = this.GetData(bookpublisher, pageparams, out totalCount);
            return base.GetJson(bookpublisherdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存bookpublisherdata数据集数据
        /// </summary>
        /// <param name="bookpublisherdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveBookPublisher(BookPublisherData bookpublisherdata)
        {
            #region
            BookPublisherClass bookpublisherclass = new BookPublisherClass();
            return base.Save(bookpublisherdata, bookpublisherclass);
            #endregion
        }
                
        /// <summary>
        /// 添加BookPublisher表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="bookpublisherdata">数据集对象</param>
        /// <param name="bookpublisher">实体对象</param>
        public void AddRow(ref BookPublisherData bookpublisherdata, EntityBookPublisher bookpublisher)
        {
            #region
            DataRow dr = bookpublisherdata.Tables[0].NewRow();
            bookpublisherdata.Assign(dr, BookPublisherData.publisherId, bookpublisher.publisherId);
            bookpublisherdata.Assign(dr, BookPublisherData.publisherName, bookpublisher.publisherName);
            bookpublisherdata.Assign(dr, BookPublisherData.address, bookpublisher.address);
            bookpublisherdata.Assign(dr, BookPublisherData.usable, bookpublisher.usable);
            bookpublisherdata.Assign(dr, BookPublisherData.sort, bookpublisher.sort);
            bookpublisherdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑bookpublisherdata数据集中指定的行数据
        /// </summary>
        /// <param name="bookpublisherdata">数据集对象</param>
        /// <param name="bookpublisher">实体对象</param>
        public void EditRow(ref BookPublisherData bookpublisherdata, EntityBookPublisher bookpublisher)
        {
            #region
            if (bookpublisherdata.Tables[0].Rows.Count <= 0)
                bookpublisherdata = this.getData(bookpublisher.publisherId);
            DataRow dr = bookpublisherdata.Tables[0].Rows.Find(new object[1] {bookpublisher.publisherId});
            bookpublisherdata.Assign(dr, BookPublisherData.publisherId, bookpublisher.publisherId);
            bookpublisherdata.Assign(dr, BookPublisherData.publisherName, bookpublisher.publisherName);
            bookpublisherdata.Assign(dr, BookPublisherData.address, bookpublisher.address);
            bookpublisherdata.Assign(dr, BookPublisherData.usable, bookpublisher.usable);
            bookpublisherdata.Assign(dr, BookPublisherData.sort, bookpublisher.sort);
            #endregion
        }
        		
        /// <summary>
        /// 删除bookpublisherdata数据集中指定的行数据
        /// </summary>
        /// <param name="bookpublisherdata">数据集对象</param>
        public void DeleteRow(ref BookPublisherData bookpublisherdata, string publisherId)
        {
            #region
            if (bookpublisherdata.Tables[0].Rows.Count <= 0)
                bookpublisherdata = this.getData(publisherId);
            DataRow dr = bookpublisherdata.Tables[0].Rows.Find(new object[1] { publisherId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取BookPublisher数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            BookPublisherData bookpublisherdata = this.getData(null);
            totalCount = bookpublisherdata.Tables[0].Rows.Count;
            return base.GetJson(bookpublisherdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityBookPublisher bookpublisher)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(bookpublisher, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <returns></returns>
        private BookPublisherData getData(string publisherId)
        {
            #region
            BookPublisherData bookpublisherdata = new BookPublisherData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(BookPublisherData.publisherId, EnumSqlType.sqlint, EnumCondition.Equal, publisherId);
            this._bookpublisherclass.GetSingleTAllWithoutCount(bookpublisherdata, querybusinessparams);
            return bookpublisherdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有BookPublisher指定页码的数据（分页型）
        /// </summary>
        /// <param name="bookpublisher">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityBookPublisher bookpublisher, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(BookPublisherData.publisherId, EnumSqlType.tinyint, 
                EnumCondition.Equal, bookpublisher.publisherId);
            querybusinessparams.Add(BookPublisherData.publisherName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, bookpublisher.publisherName);
            querybusinessparams.Add(BookPublisherData.address, EnumSqlType.nvarchar, 
                EnumCondition.Equal, bookpublisher.address);
            querybusinessparams.Add(BookPublisherData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, bookpublisher.usable);
            querybusinessparams.Add(BookPublisherData.sort, EnumSqlType.sqlint, 
                EnumCondition.Equal, bookpublisher.sort);
            BookPublisherData bookpublisherdata = new BookPublisherData();
            totalCount = this._bookpublisherclass.GetSingleT(bookpublisherdata, querybusinessparams);
            return bookpublisherdata;
            #endregion
        }
        #endregion

        #endregion
    }
}
