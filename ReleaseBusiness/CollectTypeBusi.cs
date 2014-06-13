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
    public class CollectTypeBusiness : GeneralBusinesser
    {
        private CollectTypeClass _collecttypeclass = new CollectTypeClass();
        private InsideCollectClass _insidecollectclass = new InsideCollectClass();
        private ProductionCollectClass _productioncollectclass = new ProductionCollectClass();
        private ProjectCollectClass _projectcollectclass = new ProjectCollectClass();
        #region Create by iCat Assist Tools
        #region public members methods

        /// <summary>
        /// 根据条件筛选所有CollectType指定页码的数据（分页型）
        /// </summary>
        /// <param name="collecttype">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityCollectType collecttype, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            pageparams.PageSorts.Add(new PageSort(CollectTypeData.releaseNo, EnumSQLOrderBY.ASC));
            DataSet collecttypedata = this.GetData(collecttype, pageparams, out totalCount);
            return base.GetJson(collecttypedata, totalCount);
            #endregion
        }

        /// <summary>
        /// 保存collecttypedata数据集数据
        /// </summary>
        /// <param name="collecttypedata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveCollectType(CollectTypeData collecttypedata)
        {
            #region
            CollectTypeClass collecttypeclass = new CollectTypeClass();
            return base.Save(collecttypedata, collecttypeclass);
            #endregion
        }

        /// <summary>
        /// 添加CollectType表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="collecttypedata">数据集对象</param>
        /// <param name="collecttype">实体对象</param>
        public void AddRow(ref CollectTypeData collecttypedata, EntityCollectType collecttype)
        {
            #region
            DataRow dr = collecttypedata.Tables[0].NewRow();
            collecttypedata.Assign(dr, CollectTypeData.collectTypeId, collecttype.collectTypeId);
            collecttypedata.Assign(dr, CollectTypeData.releaseNo, collecttype.releaseNo);
            collecttypedata.Assign(dr, CollectTypeData.releaseType, collecttype.releaseType);
            collecttypedata.Assign(dr, CollectTypeData.releaseTime, collecttype.releaseTime);
            collecttypedata.Assign(dr, CollectTypeData.writeUser, collecttype.writeUser);
            collecttypedata.Assign(dr, CollectTypeData.writeTime, collecttype.writeTime);
            collecttypedata.Assign(dr, CollectTypeData.writeIp, collecttype.writeIp);
            collecttypedata.Tables[0].Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 编辑collecttypedata数据集中指定的行数据
        /// </summary>
        /// <param name="collecttypedata">数据集对象</param>
        /// <param name="collecttype">实体对象</param>
        public void EditRow(ref CollectTypeData collecttypedata, EntityCollectType collecttype)
        {
            #region
            if (collecttypedata.Tables[0].Rows.Count <= 0)
                collecttypedata = this.getData(collecttype.collectTypeId);
            DataRow dr = collecttypedata.Tables[0].Rows.Find(new object[1] { collecttype.collectTypeId });
            collecttypedata.Assign(dr, CollectTypeData.collectTypeId, collecttype.collectTypeId);
            collecttypedata.Assign(dr, CollectTypeData.releaseNo, collecttype.releaseNo);
            collecttypedata.Assign(dr, CollectTypeData.releaseType, collecttype.releaseType);
            collecttypedata.Assign(dr, CollectTypeData.releaseTime, collecttype.releaseTime);
            collecttypedata.Assign(dr, CollectTypeData.writeUser, collecttype.writeUser);
            collecttypedata.Assign(dr, CollectTypeData.writeTime, collecttype.writeTime);
            collecttypedata.Assign(dr, CollectTypeData.writeIp, collecttype.writeIp);
            #endregion
        }

        /// <summary>
        /// 删除collecttypedata数据集中指定的行数据
        /// </summary>
        /// <param name="collecttypedata">数据集对象</param>
        /// <param name="collectTypeId">主键-</param>
        public void DeleteRow(ref CollectTypeData collecttypedata, string collectTypeId)
        {
            #region
            if (collecttypedata.Tables[0].Rows.Count <= 0)
                collecttypedata = this.getData(collectTypeId);
            DataRow dr = collecttypedata.Tables[0].Rows.Find(new object[1] { collectTypeId });
            if (dr != null)
                dr.Delete();
            #endregion
        }

        /// <summary>
        /// 根据发布Id判断是否存在对内发布内容(true表示存在数据)
        /// </summary>
        /// <param name="insidecollectdata">数据集对象</param>
        /// <param name="collectTypeId">关联键</param>
        public bool ExitInsideCollectRecord(ref InsideCollectData insidecollectdata, string collectTypeId)
        {
            #region
            if (insidecollectdata.Tables[0].Rows.Count <= 0)
                insidecollectdata = this.getInsideCollectData(collectTypeId);
            if (insidecollectdata.Tables[0].Rows.Count > 0)
                return false;
            else
                return true;
            #endregion
        }
        /// <summary>
        /// 根据发布Id判断是否存在对生产部发布内容(true表示存在数据)
        /// </summary>
        /// <param name="productioncollectdata">数据集对象</param>
        /// <param name="collectTypeId">关联键</param>
        public bool ExitProductionCollectRecord(ref ProductionCollectData productioncollectdata, string collectTypeId)
        {
            #region
            if (productioncollectdata.Tables[0].Rows.Count <= 0)
                productioncollectdata = this.getProductionCollectData(collectTypeId);
            if (productioncollectdata.Tables[0].Rows.Count > 0)
                return false;
            else
                return true;
            #endregion
        }
        /// <summary>
        /// 根据发布Id判断是否存在对工程部发布内容(true表示存在数据)
        /// </summary>
        /// <param name="projectcollectdata">数据集对象</param>
        /// <param name="collectTypeId">关联键</param>
        public bool ExitProjectCollectRecord(ref ProjectCollectData projectcollectdata, string collectTypeId)
        {
            #region
            if (projectcollectdata.Tables[0].Rows.Count <= 0)
                projectcollectdata = this.getProjectCollectData(collectTypeId);
            if (projectcollectdata.Tables[0].Rows.Count > 0)
                return false;
            else
                return true;
            #endregion
        }

        /// <summary>
        /// 获取CollectType数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            CollectTypeData collecttypedata = this.getData(null);
            totalCount = collecttypedata.Tables[0].Rows.Count;
            return base.GetJson(collecttypedata, totalCount);
            #endregion
        }

        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityCollectType collecttype)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(collecttype, queryparams, out totalcount);

            ExportExcelCollectType exportexcelcollecttype = new ExportExcelCollectType(filename, ds, grid);
            exportexcelcollecttype.Output();
            #endregion
        }
        #endregion

        #region private members methods

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="collectTypeId">主键-</param>
        /// <returns></returns>
        private CollectTypeData getData(string collectTypeId)
        {
            #region
            CollectTypeData collecttypedata = new CollectTypeData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(CollectTypeData.collectTypeId, EnumSqlType.sqlint, EnumCondition.Equal, collectTypeId);
            this._collecttypeclass.GetSingleT(collecttypedata, querybusinessparams);
            return collecttypedata;
            #endregion
        }

        /// <summary>
        /// 根据关系键值检索符合该条件的对内发布记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="collectTypeId">关系键</param>
        /// <returns></returns>
        private InsideCollectData getInsideCollectData(string collectTypeId)
        {
            #region
            InsideCollectData insidecollectdata = new InsideCollectData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(InsideCollectData.collectTypeId, EnumSqlType.sqlint, EnumCondition.Equal, collectTypeId);
            this._insidecollectclass.GetSingleT(insidecollectdata, querybusinessparams);
            return insidecollectdata;
            #endregion
        }
        /// <summary>
        /// 根据关系键值检索符合该条件的对生产部发布记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="collectTypeId">关系键</param>
        /// <returns></returns>
        private ProductionCollectData getProductionCollectData(string collectTypeId)
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
        /// 根据关系键值检索符合该条件的对工程部发布记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="collectTypeId">关系键</param>
        /// <returns></returns>
        private ProjectCollectData getProjectCollectData(string collectTypeId)
        {
            #region
            ProjectCollectData projectcollectdata = new ProjectCollectData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ProjectCollectData.collectTypeId, EnumSqlType.sqlint, EnumCondition.Equal, collectTypeId);
            this._projectcollectclass.GetSingleT(projectcollectdata, querybusinessparams);
            return projectcollectdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有CollectType指定页码的数据（分页型）
        /// </summary>
        /// <param name="collecttype">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityCollectType collecttype, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(CollectTypeData.collectTypeId, EnumSqlType.sqlint,
                EnumCondition.Equal, collecttype.collectTypeId);
            querybusinessparams.Add(CollectTypeData.releaseNo, EnumSqlType.nvarchar,
                EnumCondition.Equal, collecttype.releaseNo);
            querybusinessparams.Add(CollectTypeData.releaseType, EnumSqlType.tinyint,
                EnumCondition.Equal, collecttype.releaseType);
            querybusinessparams.Add(CollectTypeData.releaseTime, EnumSqlType.datetime,
                EnumCondition.Equal, collecttype.releaseTime);
            querybusinessparams.Add(CollectTypeData.writeUser, EnumSqlType.sqlint,
                EnumCondition.Equal, collecttype.writeUser);
            querybusinessparams.Add(CollectTypeData.writeTime, EnumSqlType.datetime,
                EnumCondition.Equal, collecttype.writeTime);
            querybusinessparams.Add(CollectTypeData.writeIp, EnumSqlType.nvarchar,
                EnumCondition.Equal, collecttype.writeIp);
            CollectTypeData collecttypedata = new CollectTypeData();
            totalCount = this._collecttypeclass.GetSingleT(collecttypedata, querybusinessparams);
            return collecttypedata;
            #endregion
        }
        #endregion

        #endregion
    }
}
