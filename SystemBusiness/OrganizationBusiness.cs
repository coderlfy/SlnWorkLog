/****************************************
***创建人：bhlfy
***创建时间：2013-04-06 17:31:07
***公司：山西ICat Studio有限公司
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using System;
using System.Data;

using SystemDataLibrary;
using SystemSqlLibrary;
using ExportExcelLib;
using BusinessBase;
using Fundation.Core;

namespace SystemBusiness
{
    public class OrganizationBusiness : GeneralBusinesser
    {
        private OrganizationClass _organizationclass = new OrganizationClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-06 17:31:07
        ***公司：山西ICat Studio有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        
        /// <summary>
        /// 根据条件筛选所有Organization指定页码的数据（分页型）
        /// </summary>
        /// <param name="organization">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityOrganization organization, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            OrganizationClass organizationclass = new OrganizationClass();
            DataSet organizationdata = this.GetData(organization, pageparams, out totalCount);
            return base.GetJson(organizationdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存organizationdata数据集数据
        /// </summary>
        /// <param name="organizationdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveOrganization(OrganizationData organizationdata)
        {
            #region
            OrganizationClass organizationclass = new OrganizationClass();
            return base.Save(organizationdata, organizationclass);
            #endregion
        }
                
        /// <summary>
        /// 添加Organization表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="organizationdata">数据集对象</param>
        /// <param name="organization">实体对象</param>
        public void AddRow(ref OrganizationData organizationdata, EntityOrganization organization)
        {
            #region
            DataRow dr = organizationdata.Tables[0].NewRow();
            organizationdata.Assign(dr, OrganizationData.organizationId, organization.organizationId);
            organizationdata.Assign(dr, OrganizationData.userid, organization.userid);
            organizationdata.Assign(dr, OrganizationData.organizationName, organization.organizationName);
            organizationdata.Assign(dr, OrganizationData.currentId, organization.currentId);
            organizationdata.Assign(dr, OrganizationData.parentId, organization.parentId);
            organizationdata.Assign(dr, OrganizationData.usable, organization.usable);
            organizationdata.Assign(dr, OrganizationData.writeIp, organization.writeIp);
            organizationdata.Assign(dr, OrganizationData.writeTime, organization.writeTime);
            organizationdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑organizationdata数据集中指定的行数据
        /// </summary>
        /// <param name="organizationdata">数据集对象</param>
        /// <param name="organization">实体对象</param>
        public void EditRow(ref OrganizationData organizationdata, EntityOrganization organization)
        {
            #region
            if (organizationdata.Tables[0].Rows.Count <= 0)
                organizationdata = this.getData(organization.organizationId);
            DataRow dr = organizationdata.Tables[0].Rows.Find(new object[1] {organization.organizationId});
            organizationdata.Assign(dr, OrganizationData.organizationId, organization.organizationId);
            organizationdata.Assign(dr, OrganizationData.userid, organization.userid);
            organizationdata.Assign(dr, OrganizationData.organizationName, organization.organizationName);
            organizationdata.Assign(dr, OrganizationData.currentId, organization.currentId);
            organizationdata.Assign(dr, OrganizationData.parentId, organization.parentId);
            organizationdata.Assign(dr, OrganizationData.usable, organization.usable);
            organizationdata.Assign(dr, OrganizationData.writeIp, organization.writeIp);
            organizationdata.Assign(dr, OrganizationData.writeTime, organization.writeTime);
            #endregion
        }
        		
        /// <summary>
        /// 删除organizationdata数据集中指定的行数据
        /// </summary>
        /// <param name="organizationdata">数据集对象</param>
        /// <param name="organizationId">主键-组织机构编号</param>
        public void DeleteRow(ref OrganizationData organizationdata,string organizationId)
        {
            #region
            if (organizationdata.Tables[0].Rows.Count <= 0)
                organizationdata = this.getData(organizationId);
            DataRow dr = organizationdata.Tables[0].Rows.Find(new object[1] { organizationId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取Organization数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            OrganizationData organizationdata = this.getData(null);
            totalCount = organizationdata.Tables[0].Rows.Count;
            return base.GetJson(organizationdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityOrganization organization)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(organization, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="organizationId">主键-组织机构编号</param>
        /// <returns></returns>
        private OrganizationData getData(string organizationId)
        {
            #region
            OrganizationData organizationdata = new OrganizationData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(OrganizationData.organizationId, EnumSqlType.sqlint, EnumCondition.Equal, organizationId);
            this._organizationclass.GetSingleTAllWithoutCount(organizationdata, querybusinessparams);
            return organizationdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有Organization指定页码的数据（分页型）
        /// </summary>
        /// <param name="organization">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityOrganization organization, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(OrganizationData.organizationId, EnumSqlType.sqlint, 
                EnumCondition.Equal, organization.organizationId);
            querybusinessparams.Add(OrganizationData.userid, EnumSqlType.sqlint, 
                EnumCondition.Equal, organization.userid);
            querybusinessparams.Add(OrganizationData.organizationName, EnumSqlType.nvarchar, 
                EnumCondition.Equal, organization.organizationName);
            querybusinessparams.Add(OrganizationData.currentId, EnumSqlType.sqlint, 
                EnumCondition.Equal, organization.currentId);
            querybusinessparams.Add(OrganizationData.parentId, EnumSqlType.sqlint, 
                EnumCondition.Equal, organization.parentId);
            querybusinessparams.Add(OrganizationData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, organization.usable);
            querybusinessparams.Add(OrganizationData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, organization.writeIp);
            querybusinessparams.Add(OrganizationData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, organization.writeTime);
            OrganizationData organizationdata = new OrganizationData();
            totalCount = this._organizationclass.GetSingleT(organizationdata, querybusinessparams);
            return organizationdata;
            #endregion
        }
        #endregion

        #endregion
    }
}


