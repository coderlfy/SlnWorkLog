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
    public class InsideCollectBusiness : GeneralBusinesser
    {
        private InsideCollectClass _insidecollectclass = new InsideCollectClass();
        #region Create by iCat Assist Tools
        #region public members methods

        /// <summary>
        /// 根据条件筛选所有InsideCollect指定页码的数据（分页型）
        /// </summary>
        /// <param name="insidecollect">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityInsideCollect insidecollect, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            pageparams.PageSorts.Add(new PageSort(InsideCollectData.fileNo, EnumSQLOrderBY.ASC));
            DataSet insidecollectdata = this.GetData(insidecollect, pageparams, out totalCount);
            return base.GetJson(insidecollectdata, totalCount);
            #endregion
        }

        /// <summary>
        /// 保存insidecollectdata数据集数据
        /// </summary>
        /// <param name="insidecollectdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveInsideCollect(InsideCollectData insidecollectdata)
        {
            #region
            InsideCollectClass insidecollectclass = new InsideCollectClass();
            return base.SaveRelease(insidecollectdata, insidecollectclass);
            #endregion
        }

        /// <summary>
        /// 添加InsideCollect表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="insidecollectdata">数据集对象</param>
        /// <param name="insidecollect">实体对象</param>
        public void AddRow(ref InsideCollectData insidecollectdata, EntityInsideCollect insidecollect)
        {
            #region
            DataRow dr = insidecollectdata.Tables[0].NewRow();
            insidecollectdata.Assign(dr, InsideCollectData.insideCollectId, insidecollect.insideCollectId);
            insidecollectdata.Assign(dr, InsideCollectData.collectTypeId, insidecollect.collectTypeId);
            insidecollectdata.Assign(dr, InsideCollectData.systemName, insidecollect.systemName);
            insidecollectdata.Assign(dr, InsideCollectData.fileNo, insidecollect.fileNo);
            insidecollectdata.Assign(dr, InsideCollectData.fileTime, insidecollect.fileTime);
            insidecollectdata.Assign(dr, InsideCollectData.writeUser, insidecollect.writeUser);
            insidecollectdata.Assign(dr, InsideCollectData.writeTime, insidecollect.writeTime);
            insidecollectdata.Assign(dr, InsideCollectData.writeIp, insidecollect.writeIp);
            insidecollectdata.Tables[0].Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 编辑insidecollectdata数据集中指定的行数据
        /// </summary>
        /// <param name="insidecollectdata">数据集对象</param>
        /// <param name="insidecollect">实体对象</param>
        public void EditRow(ref InsideCollectData insidecollectdata, EntityInsideCollect insidecollect)
        {
            #region
            if (insidecollectdata.Tables[0].Rows.Count <= 0)
                insidecollectdata = this.getData(insidecollect.insideCollectId);
            DataRow dr = insidecollectdata.Tables[0].Rows.Find(new object[1] { insidecollect.insideCollectId });
            insidecollectdata.Assign(dr, InsideCollectData.insideCollectId, insidecollect.insideCollectId);
            insidecollectdata.Assign(dr, InsideCollectData.collectTypeId, insidecollect.collectTypeId);
            insidecollectdata.Assign(dr, InsideCollectData.systemName, insidecollect.systemName);
            insidecollectdata.Assign(dr, InsideCollectData.fileNo, insidecollect.fileNo);
            insidecollectdata.Assign(dr, InsideCollectData.fileTime, insidecollect.fileTime);
            insidecollectdata.Assign(dr, InsideCollectData.writeUser, insidecollect.writeUser);
            insidecollectdata.Assign(dr, InsideCollectData.writeTime, insidecollect.writeTime);
            insidecollectdata.Assign(dr, InsideCollectData.writeIp, insidecollect.writeIp);
            #endregion
        }

        /// <summary>
        /// 编辑insidecollectdata数据集中指定的行数据
        /// </summary>
        /// <param name="insidecollectdata">数据集对象</param>
        /// <param name="insidecollect">实体对象</param>
        public void EditRowByCollectTypeId(ref InsideCollectData insidecollectdata, EntityInsideCollect insidecollect)
        {
            #region
            if (insidecollectdata.Tables[0].Rows.Count <= 0)
                insidecollectdata = this.getDataByCollectTypeId(insidecollect.collectTypeId);
            DataRow dr = insidecollectdata.Tables[0].Rows.Find(new object[1] { insidecollect.insideCollectId });
            insidecollectdata.Assign(dr, InsideCollectData.insideCollectId, insidecollect.insideCollectId);
            insidecollectdata.Assign(dr, InsideCollectData.collectTypeId, insidecollect.collectTypeId);
            insidecollectdata.Assign(dr, InsideCollectData.systemName, insidecollect.systemName);
            insidecollectdata.Assign(dr, InsideCollectData.fileNo, insidecollect.fileNo);
            insidecollectdata.Assign(dr, InsideCollectData.fileTime, insidecollect.fileTime);
            insidecollectdata.Assign(dr, InsideCollectData.writeUser, insidecollect.writeUser);
            insidecollectdata.Assign(dr, InsideCollectData.writeTime, insidecollect.writeTime);
            insidecollectdata.Assign(dr, InsideCollectData.writeIp, insidecollect.writeIp);
            #endregion
        }

        /// <summary>
        /// 删除insidecollectdata数据集中指定的行数据
        /// </summary>
        /// <param name="insidecollectdata">数据集对象</param>
        /// <param name="insideCollectId">主键-</param>
        public void DeleteRow(ref InsideCollectData insidecollectdata, string insideCollectId)
        {
            #region
            if (insidecollectdata.Tables[0].Rows.Count <= 0)
                insidecollectdata = this.getData(insideCollectId);
            DataRow dr = insidecollectdata.Tables[0].Rows.Find(new object[1] { insideCollectId });
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
            InsideCollectData insidecollectdata = this.getData(null);
            totalCount = insidecollectdata.Tables[0].Rows.Count;
            return base.GetJson(insidecollectdata, totalCount);
            #endregion
        }

        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityInsideCollect insidecollect)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(insidecollect, queryparams, out totalcount);

            ExportExcelInsideCollect exportexcelinsidecollect = new ExportExcelInsideCollect(filename, ds, grid);
            exportexcelinsidecollect.Output();
            #endregion
        }
        #endregion

        #region private members methods

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="insideCollectId">主键-</param>
        /// <returns></returns>
        private InsideCollectData getData(string insideCollectId)
        {
            #region
            InsideCollectData insidecollectdata = new InsideCollectData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(InsideCollectData.insideCollectId, EnumSqlType.sqlint, EnumCondition.Equal, insideCollectId);
            this._insidecollectclass.GetSingleT(insidecollectdata, querybusinessparams);
            return insidecollectdata;
            #endregion
        }

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="collectTypeId">关系建</param>
        /// <returns></returns>
        private InsideCollectData getDataByCollectTypeId(string collectTypeId)
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
        /// 根据条件筛选所有InsideCollect指定页码的数据（分页型）
        /// </summary>
        /// <param name="insidecollect">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityInsideCollect insidecollect, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(InsideCollectData.insideCollectId, EnumSqlType.sqlint,
                EnumCondition.Equal, insidecollect.insideCollectId);
            querybusinessparams.Add(InsideCollectData.collectTypeId, EnumSqlType.sqlint,
                EnumCondition.Equal, insidecollect.collectTypeId);
            querybusinessparams.Add(InsideCollectData.systemName, EnumSqlType.nvarchar,
                EnumCondition.Equal, insidecollect.systemName);
            querybusinessparams.Add(InsideCollectData.fileNo, EnumSqlType.nvarchar,
                EnumCondition.Equal, insidecollect.fileNo);
            querybusinessparams.Add(InsideCollectData.fileTime, EnumSqlType.datetime,
                EnumCondition.Equal, insidecollect.fileTime);
            querybusinessparams.Add(InsideCollectData.writeUser, EnumSqlType.sqlint,
                EnumCondition.Equal, insidecollect.writeUser);
            querybusinessparams.Add(InsideCollectData.writeTime, EnumSqlType.datetime,
                EnumCondition.Equal, insidecollect.writeTime);
            querybusinessparams.Add(InsideCollectData.writeIp, EnumSqlType.nvarchar,
                EnumCondition.Equal, insidecollect.writeIp);
            InsideCollectData insidecollectdata = new InsideCollectData();
            totalCount = this._insidecollectclass.GetSingleT(insidecollectdata, querybusinessparams);
            return insidecollectdata;
            #endregion
        }
        #endregion

        #endregion
    }
}
