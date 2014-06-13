/****************************************
***创建人：bhlfy
***创建时间：2013-04-06 17:31:07
***公司：山西博华科技有限公司
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
    public class AddressBusiness : GeneralBusinesser
    {
        private AddressClass _addressclass = new AddressClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-04-06 17:31:07
        ***公司：山西博华科技有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods
        
        /// <summary>
        /// 根据条件筛选所有Address指定页码的数据（分页型）
        /// </summary>
        /// <param name="address">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityAddress address, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            DataSet addressdata = this.GetData(address, pageparams, out totalCount);
            return base.GetJson(addressdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存addressdata数据集数据
        /// </summary>
        /// <param name="addressdata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveAddress(AddressData addressdata)
        {
            #region
            AddressClass addressclass = new AddressClass();
            return base.Save(addressdata, addressclass);
            #endregion
        }
                
        /// <summary>
        /// 添加Address表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="addressdata">数据集对象</param>
        /// <param name="address">实体对象</param>
        public void AddRow(ref AddressData addressdata, EntityAddress address)
        {
            #region
            DataRow dr = addressdata.Tables[0].NewRow();
            addressdata.Assign(dr, AddressData.addrId, address.addrId);
            addressdata.Assign(dr, AddressData.addrName, address.addrName);
            addressdata.Assign(dr, AddressData.parentId, address.parentId);
            addressdata.Assign(dr, AddressData.usable, address.usable);
            addressdata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑addressdata数据集中指定的行数据
        /// </summary>
        /// <param name="addressdata">数据集对象</param>
        /// <param name="address">实体对象</param>
        public void EditRow(ref AddressData addressdata, EntityAddress address)
        {
            #region
            if (addressdata.Tables[0].Rows.Count <= 0)
                addressdata = this.getData(address.addrId);
            DataRow dr = addressdata.Tables[0].Rows.Find(new object[1] {address.addrId});
            addressdata.Assign(dr, AddressData.addrId, address.addrId);
            addressdata.Assign(dr, AddressData.addrName, address.addrName);
            addressdata.Assign(dr, AddressData.parentId, address.parentId);
            addressdata.Assign(dr, AddressData.usable, address.usable);
            #endregion
        }
        		
        /// <summary>
        /// 删除addressdata数据集中指定的行数据
        /// </summary>
        /// <param name="addressdata">数据集对象</param>
        /// <param name="addrId">主键-地市编号</param>
        public void DeleteRow(ref AddressData addressdata,string addrId)
        {
            #region
            if (addressdata.Tables[0].Rows.Count <= 0)
                addressdata = this.getData(addrId);
            DataRow dr = addressdata.Tables[0].Rows.Find(new object[1] { addrId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取Address数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            AddressData addressdata = this.getData(null);
            totalCount = addressdata.Tables[0].Rows.Count;
            return base.GetJson(addressdata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityAddress address)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(address, queryparams, out totalcount);
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="addrId">主键-地市编号</param>
        /// <returns></returns>
        private AddressData getData(string addrId)
        {
            #region
            AddressData addressdata = new AddressData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(AddressData.addrId, EnumSqlType.sqlint, EnumCondition.Equal, addrId);
            this._addressclass.GetSingleTAllWithoutCount(addressdata, querybusinessparams);
            return addressdata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有Address指定页码的数据（分页型）
        /// </summary>
        /// <param name="address">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityAddress address, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(AddressData.addrId, EnumSqlType.sqlint,
                EnumCondition.Equal, address.addrId);
            querybusinessparams.Add(AddressData.addrName, EnumSqlType.nvarchar,
                EnumCondition.Equal, address.addrName);
            querybusinessparams.Add(AddressData.parentId, EnumSqlType.sqlint,
                EnumCondition.Equal, address.parentId);
            querybusinessparams.Add(AddressData.usable, EnumSqlType.bit,
                EnumCondition.Equal, address.usable);
            AddressData addressdata = new AddressData();
            totalCount = this._addressclass.GetSingleT(addressdata, querybusinessparams);
            return addressdata;
            #endregion
        }
        #endregion

        #endregion

        public string GetCity(int parentId)
        {
            #region
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(AddressData.parentId, EnumSqlType.sqlint, EnumCondition.Equal, parentId);
            int totalCount = 0;
            AddressData addressdata = new AddressData();
            totalCount = this._addressclass.GetSingleTAll(addressdata, querybusinessparams);
            return base.GetJson(addressdata, totalCount);
            #endregion
        }

        public string GetCounty(int parentId)
        {
            #region
            int totalCount = 0;
            AddressData addressdata = this._addressclass.SelectCountyByParentID(parentId);
            totalCount = addressdata.Tables[0].Rows.Count;
            return base.GetJson(addressdata, totalCount);
            #endregion
        }
    }
}


