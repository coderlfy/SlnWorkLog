using System;
using System.Data;
using ExportExcelLib;
using ReleaseDataLibrary;
using ReleaseSqlLibrary;
using BusinessBase;
using Fundation.Core;
using ReleaseDataLibrary.entity;

namespace ReleaseBusiness
{
    public class ProductionCollectBusiness : GeneralBusinesser
    {
        private ProductionCollectClass _productioncollectclass = new ProductionCollectClass();
        #region Create by iCat Assist Tools
        #region public members methods

        /// <summary>
        /// 根据条件筛选所有ProductionCollect指定页码的数据（分页型）
        /// </summary>
        /// <param name="productioncollect">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityProductionCollect productioncollect, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            pageparams.PageSorts.Add(new PageSort(ProductionCollectData.fileNo, EnumSQLOrderBY.ASC));
            DataSet productioncollectdata = this.GetData(productioncollect, pageparams, out totalCount);
            return base.GetJson(productioncollectdata, totalCount);
            #endregion
        }

        /// <summary>
        /// 保存productioncollectdata数据集数据
        /// </summary>
        /// <param name="productioncollectdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveProductionCollect(ProductionCollectData productioncollectdata)
        {
            #region
            ProductionCollectClass productioncollectclass = new ProductionCollectClass();
            return base.SaveRelease(productioncollectdata, productioncollectclass);
            #endregion
        }

        /// <summary>
        /// 添加ProductionCollect表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="productioncollectdata">数据集对象</param>
        /// <param name="productioncollect">实体对象</param>
        public void AddRow(ref ProductionCollectData productioncollectdata, EntityProductionCollect productioncollect)
        {
            #region
            DataRow dr = productioncollectdata.Tables[0].NewRow();
            productioncollectdata.Assign(dr, ProductionCollectData.productionCollectId, productioncollect.productionCollectId);
            productioncollectdata.Assign(dr, ProductionCollectData.collectTypeId, productioncollect.collectTypeId);
            productioncollectdata.Assign(dr, ProductionCollectData.systemName, productioncollect.systemName);
            productioncollectdata.Assign(dr, ProductionCollectData.fileNo, productioncollect.fileNo);
            productioncollectdata.Assign(dr, ProductionCollectData.fileTime, productioncollect.fileTime);
            productioncollectdata.Assign(dr, ProductionCollectData.writeUser, productioncollect.writeUser);
            productioncollectdata.Assign(dr, ProductionCollectData.writeTime, productioncollect.writeTime);
            productioncollectdata.Assign(dr, ProductionCollectData.writeIp, productioncollect.writeIp);
            productioncollectdata.Tables[0].Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 编辑productioncollectdata数据集中指定的行数据
        /// </summary>
        /// <param name="productioncollectdata">数据集对象</param>
        /// <param name="productioncollect">实体对象</param>
        public void EditRow(ref ProductionCollectData productioncollectdata, EntityProductionCollect productioncollect)
        {
            #region
            if (productioncollectdata.Tables[0].Rows.Count <= 0)
                productioncollectdata = this.getData(productioncollect.productionCollectId);
            DataRow dr = productioncollectdata.Tables[0].Rows.Find(new object[1] { productioncollect.productionCollectId });
            productioncollectdata.Assign(dr, ProductionCollectData.productionCollectId, productioncollect.productionCollectId);
            productioncollectdata.Assign(dr, ProductionCollectData.collectTypeId, productioncollect.collectTypeId);
            productioncollectdata.Assign(dr, ProductionCollectData.systemName, productioncollect.systemName);
            productioncollectdata.Assign(dr, ProductionCollectData.fileNo, productioncollect.fileNo);
            productioncollectdata.Assign(dr, ProductionCollectData.fileTime, productioncollect.fileTime);
            productioncollectdata.Assign(dr, ProductionCollectData.writeUser, productioncollect.writeUser);
            productioncollectdata.Assign(dr, ProductionCollectData.writeTime, productioncollect.writeTime);
            productioncollectdata.Assign(dr, ProductionCollectData.writeIp, productioncollect.writeIp);
            #endregion
        }

        /// <summary>
        /// 编辑productioncollectdata数据集中指定的行数据
        /// </summary>
        /// <param name="productioncollectdata">数据集对象</param>
        /// <param name="productioncollect">实体对象</param>
        public void EditRowByCollectTypeId(ref ProductionCollectData productioncollectdata, EntityProductionCollect productioncollect)
        {
            #region
            if (productioncollectdata.Tables[0].Rows.Count <= 0)
                productioncollectdata = this.getDataByCollectTypeId(productioncollect.collectTypeId);
            DataRow dr = productioncollectdata.Tables[0].Rows.Find(new object[1] { productioncollect.productionCollectId });
            productioncollectdata.Assign(dr, ProductionCollectData.productionCollectId, productioncollect.productionCollectId);
            productioncollectdata.Assign(dr, ProductionCollectData.collectTypeId, productioncollect.collectTypeId);
            productioncollectdata.Assign(dr, ProductionCollectData.systemName, productioncollect.systemName);
            productioncollectdata.Assign(dr, ProductionCollectData.fileNo, productioncollect.fileNo);
            productioncollectdata.Assign(dr, ProductionCollectData.fileTime, productioncollect.fileTime);
            productioncollectdata.Assign(dr, ProductionCollectData.writeUser, productioncollect.writeUser);
            productioncollectdata.Assign(dr, ProductionCollectData.writeTime, productioncollect.writeTime);
            productioncollectdata.Assign(dr, ProductionCollectData.writeIp, productioncollect.writeIp);
            #endregion
        }

        /// <summary>
        /// 删除productioncollectdata数据集中指定的行数据
        /// </summary>
        /// <param name="productioncollectdata">数据集对象</param>
        /// <param name="productionCollectId">主键-</param>
        public void DeleteRow(ref ProductionCollectData productioncollectdata, string productionCollectId)
        {
            #region
            if (productioncollectdata.Tables[0].Rows.Count <= 0)
                productioncollectdata = this.getData(productionCollectId);
            DataRow dr = productioncollectdata.Tables[0].Rows.Find(new object[1] { productionCollectId });
            if (dr != null)
                dr.Delete();
            #endregion
        }

        /// <summary>
        /// 获取InsideCollect数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ProductionCollectData productioncollectdata = this.getData(null);
            totalCount = productioncollectdata.Tables[0].Rows.Count;
            return base.GetJson(productioncollectdata, totalCount);
            #endregion
        }

        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityProductionCollect productioncollect)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(productioncollect, queryparams, out totalcount);

            ExportExcelProductionCollect exportexcelproductioncollect = new ExportExcelProductionCollect(filename, ds, grid);
            exportexcelproductioncollect.Output();
            #endregion
        }
        #endregion

        #region private members methods

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="productionCollectId">主键-</param>
        /// <returns></returns>
        private ProductionCollectData getData(string productionCollectId)
        {
            #region
            ProductionCollectData productioncollectdata = new ProductionCollectData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ProductionCollectData.productionCollectId, EnumSqlType.sqlint, EnumCondition.Equal, productionCollectId);
            this._productioncollectclass.GetSingleT(productioncollectdata, querybusinessparams);
            return productioncollectdata;
            #endregion
        }

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="collectTypeId">关系键</param>
        /// <returns></returns>
        private ProductionCollectData getDataByCollectTypeId(string collectTypeId)
        {
            #region
            ProductionCollectData productioncollectdata = new ProductionCollectData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ProductionCollectData.collectTypeId, EnumSqlType.sqlint, EnumCondition.Equal, collectTypeId);
            this._productioncollectclass.GetSingleT(productioncollectdata, querybusinessparams);
            return productioncollectdata;
            #endregion
        }

        /// <summary>
        /// 根据条件筛选所有ProductionCollect指定页码的数据（分页型）
        /// </summary>
        /// <param name="productioncollect">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityProductionCollect productioncollect, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ProductionCollectData.productionCollectId, EnumSqlType.sqlint,
                EnumCondition.Equal, productioncollect.productionCollectId);
            querybusinessparams.Add(ProductionCollectData.collectTypeId, EnumSqlType.sqlint,
                EnumCondition.Equal, productioncollect.collectTypeId);
            querybusinessparams.Add(ProductionCollectData.systemName, EnumSqlType.nvarchar,
                EnumCondition.Equal, productioncollect.systemName);
            querybusinessparams.Add(ProductionCollectData.fileNo, EnumSqlType.nvarchar,
                EnumCondition.Equal, productioncollect.fileNo);
            querybusinessparams.Add(ProductionCollectData.fileTime, EnumSqlType.datetime,
                EnumCondition.Equal, productioncollect.fileTime);
            querybusinessparams.Add(ProductionCollectData.writeUser, EnumSqlType.sqlint,
                EnumCondition.Equal, productioncollect.writeUser);
            querybusinessparams.Add(ProductionCollectData.writeTime, EnumSqlType.datetime,
                EnumCondition.Equal, productioncollect.writeTime);
            querybusinessparams.Add(ProductionCollectData.writeIp, EnumSqlType.nvarchar,
                EnumCondition.Equal, productioncollect.writeIp);
            ProductionCollectData productioncollectdata = new ProductionCollectData();
            totalCount = this._productioncollectclass.GetSingleT(productioncollectdata, querybusinessparams);
            return productioncollectdata;
            #endregion
        }
        #endregion

        #endregion
    }
}
