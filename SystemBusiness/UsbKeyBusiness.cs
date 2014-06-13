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
    public class UsbKeyBusiness : GeneralBusinesser
    {
        private UsbKeyClass _usbkeyclass = new UsbKeyClass();
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
        /// 根据条件筛选所有UsbKey指定页码的数据（分页型）
        /// </summary>
        /// <param name="usbkey">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityUsbKey usbkey, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            UsbKeyClass usbkeyclass = new UsbKeyClass();
            DataSet usbkeydata = this.GetData(usbkey, pageparams, out totalCount);
            return base.GetJson(usbkeydata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 保存usbkeydata数据集数据
        /// </summary>
        /// <param name="usbkeydata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveUsbKey(UsbKeyData usbkeydata)
        {
            #region
            UsbKeyClass usbkeyclass = new UsbKeyClass();
            return base.Save(usbkeydata, usbkeyclass);
            #endregion
        }
                
        /// <summary>
        /// 添加UsbKey表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="usbkeydata">数据集对象</param>
        /// <param name="usbkey">实体对象</param>
        public void AddRow(ref UsbKeyData usbkeydata, EntityUsbKey usbkey)
        {
            #region
            DataRow dr = usbkeydata.Tables[0].NewRow();
            usbkeydata.Assign(dr, UsbKeyData.keyId, usbkey.keyId);
            usbkeydata.Assign(dr, UsbKeyData.userid, usbkey.userid);
            usbkeydata.Assign(dr, UsbKeyData.writeUserid, usbkey.writeUserid);
            usbkeydata.Assign(dr, UsbKeyData.fullname, usbkey.fullname);
            usbkeydata.Assign(dr, UsbKeyData.giveoutTime, usbkey.giveoutTime);
            usbkeydata.Assign(dr, UsbKeyData.giveoutPerson, usbkey.giveoutPerson);
            usbkeydata.Assign(dr, UsbKeyData.usable, usbkey.usable);
            usbkeydata.Assign(dr, UsbKeyData.writeTime, usbkey.writeTime);
            usbkeydata.Assign(dr, UsbKeyData.writeIp, usbkey.writeIp);
            usbkeydata.Tables[0].Rows.Add(dr);
            #endregion
        }
        
        /// <summary>
        /// 编辑usbkeydata数据集中指定的行数据
        /// </summary>
        /// <param name="usbkeydata">数据集对象</param>
        /// <param name="usbkey">实体对象</param>
        public void EditRow(ref UsbKeyData usbkeydata, EntityUsbKey usbkey)
        {
            #region
            if (usbkeydata.Tables[0].Rows.Count <= 0)
                usbkeydata = this.getData(usbkey.keyId);
            DataRow dr = usbkeydata.Tables[0].Rows.Find(new object[1] {usbkey.keyId});
            usbkeydata.Assign(dr, UsbKeyData.keyId, usbkey.keyId);
            usbkeydata.Assign(dr, UsbKeyData.userid, usbkey.userid);
            usbkeydata.Assign(dr, UsbKeyData.writeUserid, usbkey.writeUserid);
            usbkeydata.Assign(dr, UsbKeyData.fullname, usbkey.fullname);
            usbkeydata.Assign(dr, UsbKeyData.giveoutTime, usbkey.giveoutTime);
            usbkeydata.Assign(dr, UsbKeyData.giveoutPerson, usbkey.giveoutPerson);
            usbkeydata.Assign(dr, UsbKeyData.usable, usbkey.usable);
            usbkeydata.Assign(dr, UsbKeyData.writeTime, usbkey.writeTime);
            usbkeydata.Assign(dr, UsbKeyData.writeIp, usbkey.writeIp);
            #endregion
        }
        		
        /// <summary>
        /// 删除usbkeydata数据集中指定的行数据
        /// </summary>
        /// <param name="usbkeydata">数据集对象</param>
        /// <param name="keyId">主键-密钥编号</param>
        public void DeleteRow(ref UsbKeyData usbkeydata,string keyId)
        {
            #region
            if (usbkeydata.Tables[0].Rows.Count <= 0)
                usbkeydata = this.getData(keyId);
            DataRow dr = usbkeydata.Tables[0].Rows.Find(new object[1] { keyId });
            if (dr != null)
                dr.Delete();
            #endregion
        }
        
        /// <summary>
        /// 获取UsbKey数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            UsbKeyData usbkeydata = this.getData(null);
            totalCount = usbkeydata.Tables[0].Rows.Count;
            return base.GetJson(usbkeydata, totalCount);
            #endregion
        }
        
        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityUsbKey usbkey)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(usbkey, queryparams, out totalcount);
            
            ExportExcel exportexcel = new ExportExcel(filename, ds, grid);
            exportexcel.Output();
            #endregion
        }
        #endregion

        #region private members methods
        
        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="keyId">主键-密钥编号</param>
        /// <returns></returns>
        private UsbKeyData getData(string keyId)
        {
            #region
            UsbKeyData usbkeydata = new UsbKeyData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(UsbKeyData.keyId, EnumSqlType.sqlint, EnumCondition.Equal, keyId);
            this._usbkeyclass.GetSingleTAllWithoutCount(usbkeydata, querybusinessparams);
            return usbkeydata;
            #endregion
        }
        
        /// <summary>
        /// 根据条件筛选所有UsbKey指定页码的数据（分页型）
        /// </summary>
        /// <param name="usbkey">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityUsbKey usbkey, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(UsbKeyData.keyId, EnumSqlType.sqlint, 
                EnumCondition.Equal, usbkey.keyId);
            querybusinessparams.Add(UsbKeyData.userid, EnumSqlType.sqlint, 
                EnumCondition.Equal, usbkey.userid);
            querybusinessparams.Add(UsbKeyData.writeUserid, EnumSqlType.sqlint, 
                EnumCondition.Equal, usbkey.writeUserid);
            querybusinessparams.Add(UsbKeyData.fullname, EnumSqlType.nvarchar, 
                EnumCondition.Equal, usbkey.fullname);
            querybusinessparams.Add(UsbKeyData.giveoutTime, EnumSqlType.datetime, 
                EnumCondition.Equal, usbkey.giveoutTime);
            querybusinessparams.Add(UsbKeyData.giveoutPerson, EnumSqlType.sqlint, 
                EnumCondition.Equal, usbkey.giveoutPerson);
            querybusinessparams.Add(UsbKeyData.usable, EnumSqlType.bit, 
                EnumCondition.Equal, usbkey.usable);
            querybusinessparams.Add(UsbKeyData.writeTime, EnumSqlType.datetime, 
                EnumCondition.Equal, usbkey.writeTime);
            querybusinessparams.Add(UsbKeyData.writeIp, EnumSqlType.nvarchar, 
                EnumCondition.Equal, usbkey.writeIp);
            UsbKeyData usbkeydata = new UsbKeyData();
            totalCount = this._usbkeyclass.GetSingleT(usbkeydata, querybusinessparams);
            return usbkeydata;
            #endregion
        }
        #endregion

        #endregion
    }
}


