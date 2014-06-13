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
    public class ProjectCollectBusiness : GeneralBusinesser
    {
        private ProjectCollectClass _projectcollectclass = new ProjectCollectClass();
        #region Create by iCat Assist Tools
        #region public members methods

        /// <summary>
        /// 根据条件筛选所有ProjectCollect指定页码的数据（分页型）
        /// </summary>
        /// <param name="projectcollect">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityProjectCollect projectcollect, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            pageparams.PageSorts.Add(new PageSort(ProjectCollectData.fileNo, EnumSQLOrderBY.ASC));
            DataSet projectcollectdata = this.GetData(projectcollect, pageparams, out totalCount);
            return base.GetJson(projectcollectdata, totalCount);
            #endregion
        }

        /// <summary>
        /// 保存projectcollectdata数据集数据
        /// </summary>
        /// <param name="projectcollectdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveProjectCollect(ProjectCollectData projectcollectdata)
        {
            #region
            ProjectCollectClass projectcollectclass = new ProjectCollectClass();
            return base.SaveRelease(projectcollectdata, projectcollectclass);
            #endregion
        }

        /// <summary>
        /// 添加ProjectCollect表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="projectcollectdata">数据集对象</param>
        /// <param name="projectcollect">实体对象</param>
        public void AddRow(ref ProjectCollectData projectcollectdata, EntityProjectCollect projectcollect)
        {
            #region
            DataRow dr = projectcollectdata.Tables[0].NewRow();
            projectcollectdata.Assign(dr, ProjectCollectData.projectCollectId, projectcollect.projectCollectId);
            projectcollectdata.Assign(dr, ProjectCollectData.collectTypeId, projectcollect.collectTypeId);
            projectcollectdata.Assign(dr, ProjectCollectData.projectItemName, projectcollect.projectItemName);
            projectcollectdata.Assign(dr, ProjectCollectData.systemName, projectcollect.systemName);
            projectcollectdata.Assign(dr, ProjectCollectData.fileNo, projectcollect.fileNo);
            projectcollectdata.Assign(dr, ProjectCollectData.fileTime, projectcollect.fileTime);
            projectcollectdata.Assign(dr, ProjectCollectData.writeUser, projectcollect.writeUser);
            projectcollectdata.Assign(dr, ProjectCollectData.writeTime, projectcollect.writeTime);
            projectcollectdata.Assign(dr, ProjectCollectData.writeIp, projectcollect.writeIp);
            projectcollectdata.Tables[0].Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 编辑projectcollectdata数据集中指定的行数据
        /// </summary>
        /// <param name="projectcollectdata">数据集对象</param>
        /// <param name="projectcollect">实体对象</param>
        public void EditRow(ref ProjectCollectData projectcollectdata, EntityProjectCollect projectcollect)
        {
            #region
            if (projectcollectdata.Tables[0].Rows.Count <= 0)
                projectcollectdata = this.getData(projectcollect.projectCollectId);
            DataRow dr = projectcollectdata.Tables[0].Rows.Find(new object[1] { projectcollect.projectCollectId });
            projectcollectdata.Assign(dr, ProjectCollectData.projectCollectId, projectcollect.projectCollectId);
            projectcollectdata.Assign(dr, ProjectCollectData.collectTypeId, projectcollect.collectTypeId);
            projectcollectdata.Assign(dr, ProjectCollectData.projectItemName, projectcollect.projectItemName);
            projectcollectdata.Assign(dr, ProjectCollectData.systemName, projectcollect.systemName);
            projectcollectdata.Assign(dr, ProjectCollectData.fileNo, projectcollect.fileNo);
            projectcollectdata.Assign(dr, ProjectCollectData.fileTime, projectcollect.fileTime);
            projectcollectdata.Assign(dr, ProjectCollectData.writeUser, projectcollect.writeUser);
            projectcollectdata.Assign(dr, ProjectCollectData.writeTime, projectcollect.writeTime);
            projectcollectdata.Assign(dr, ProjectCollectData.writeIp, projectcollect.writeIp);
            #endregion
        }

        /// <summary>
        /// 编辑projectcollectdata数据集中指定的行数据
        /// </summary>
        /// <param name="projectcollectdata">数据集对象</param>
        /// <param name="projectcollect">实体对象</param>
        public void EditRowByCollectTypeId(ref ProjectCollectData projectcollectdata, EntityProjectCollect projectcollect)
        {
            #region
            if (projectcollectdata.Tables[0].Rows.Count <= 0)
                projectcollectdata = this.getDataByCollectTypeId(projectcollect.collectTypeId);
            DataRow dr = projectcollectdata.Tables[0].Rows.Find(new object[1] { projectcollect.projectCollectId });
            projectcollectdata.Assign(dr, ProjectCollectData.projectCollectId, projectcollect.projectCollectId);
            projectcollectdata.Assign(dr, ProjectCollectData.collectTypeId, projectcollect.collectTypeId);
            projectcollectdata.Assign(dr, ProjectCollectData.projectItemName, projectcollect.projectItemName);
            projectcollectdata.Assign(dr, ProjectCollectData.systemName, projectcollect.systemName);
            projectcollectdata.Assign(dr, ProjectCollectData.fileNo, projectcollect.fileNo);
            projectcollectdata.Assign(dr, ProjectCollectData.fileTime, projectcollect.fileTime);
            projectcollectdata.Assign(dr, ProjectCollectData.writeUser, projectcollect.writeUser);
            projectcollectdata.Assign(dr, ProjectCollectData.writeTime, projectcollect.writeTime);
            projectcollectdata.Assign(dr, ProjectCollectData.writeIp, projectcollect.writeIp);
            #endregion
        }

        /// <summary>
        /// 删除projectcollectdata数据集中指定的行数据
        /// </summary>
        /// <param name="projectcollectdata">数据集对象</param>
        /// <param name="projectCollectId">主键-</param>
        public void DeleteRow(ref ProjectCollectData projectcollectdata, string projectCollectId)
        {
            #region
            if (projectcollectdata.Tables[0].Rows.Count <= 0)
                projectcollectdata = this.getData(projectCollectId);
            DataRow dr = projectcollectdata.Tables[0].Rows.Find(new object[1] { projectCollectId });
            if (dr != null)
                dr.Delete();
            #endregion
        }

        /// <summary>
        /// 获取ProjectCollect数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ProjectCollectData projectcollectdata = this.getData(null);
            totalCount = projectcollectdata.Tables[0].Rows.Count;
            return base.GetJson(projectcollectdata, totalCount);
            #endregion
        }

        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityProjectCollect projectcollect)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(projectcollect, queryparams, out totalcount);

            ExportExcelProjectCollect exportexcelprojectcollect = new ExportExcelProjectCollect(filename, ds, grid);
            exportexcelprojectcollect.Output();
            #endregion
        }
        #endregion

        #region private members methods

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="projectCollectId">主键-</param>
        /// <returns></returns>
        private ProjectCollectData getData(string projectCollectId)
        {
            #region
            ProjectCollectData projectcollectdata = new ProjectCollectData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ProjectCollectData.projectCollectId, EnumSqlType.sqlint, EnumCondition.Equal, projectCollectId);
            this._projectcollectclass.GetSingleT(projectcollectdata, querybusinessparams);
            return projectcollectdata;
            #endregion
        }

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="collectTypeId">主键-</param>
        /// <returns></returns>
        private ProjectCollectData getDataByCollectTypeId(string collectTypeId)
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
        /// 根据条件筛选所有ProjectCollect指定页码的数据（分页型）
        /// </summary>
        /// <param name="projectcollect">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityProjectCollect projectcollect, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ProjectCollectData.projectCollectId, EnumSqlType.sqlint,
                EnumCondition.Equal, projectcollect.projectCollectId);
            querybusinessparams.Add(ProjectCollectData.collectTypeId, EnumSqlType.sqlint,
                EnumCondition.Equal, projectcollect.collectTypeId);
            querybusinessparams.Add(ProjectCollectData.projectItemName, EnumSqlType.nvarchar,
                EnumCondition.Equal, projectcollect.projectItemName);
            querybusinessparams.Add(ProjectCollectData.systemName, EnumSqlType.nvarchar,
                EnumCondition.Equal, projectcollect.systemName);
            querybusinessparams.Add(ProjectCollectData.fileNo, EnumSqlType.nvarchar,
                EnumCondition.Equal, projectcollect.fileNo);
            querybusinessparams.Add(ProjectCollectData.fileTime, EnumSqlType.datetime,
                EnumCondition.Equal, projectcollect.fileTime);
            querybusinessparams.Add(ProjectCollectData.writeUser, EnumSqlType.sqlint,
                EnumCondition.Equal, projectcollect.writeUser);
            querybusinessparams.Add(ProjectCollectData.writeTime, EnumSqlType.datetime,
                EnumCondition.Equal, projectcollect.writeTime);
            querybusinessparams.Add(ProjectCollectData.writeIp, EnumSqlType.nvarchar,
                EnumCondition.Equal, projectcollect.writeIp);
            ProjectCollectData projectcollectdata = new ProjectCollectData();
            totalCount = this._projectcollectclass.GetSingleT(projectcollectdata, querybusinessparams);
            return projectcollectdata;
            #endregion
        }
        #endregion

        #endregion
    }
}
