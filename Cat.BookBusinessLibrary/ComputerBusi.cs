using System;
using System.Data;

using ExportExcelLib;
using Cat.BookDataLibrary;
using Cat.BookSqlLibrary;
using BusinessBase;
using Fundation.Core;
using Cat.BookDataLibrary.entity;

namespace Cat.BookBusinessLibrary
{
    public class ComputerBusiness : GeneralBusinesser
    {
        private ComputerClass _computerclass = new ComputerClass();
        #region Create by iCat Assist Tools
        /****************************************
        ***生成器版本：V1.0.1.31494
        ***生成时间：2013-09-05 09:05:58
        ***公司：山西博华科技有限公司
        ***友情提示：以下代码为生成器自动生成，可做参照修改之用；
        ***         如需有其他业务要求，可在region外添加新方法；
        ***         如发现任何编译和运行时错误，请联系QQ：330669393。
        *****************************************/

        #region public members methods

        /// <summary>
        /// 根据条件筛选所有Computer指定页码的数据（分页型）
        /// </summary>
        /// <param name="bookfromcountry">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <returns></returns>
        public string GetJsonByPage(EntityComputer computer, PageParams pageparams)
        {
            #region
            int totalCount = 0;
            ComputerClass computerclass = new ComputerClass();
            DataSet computerdata = this.GetData(computer, pageparams, out totalCount);
            return base.GetJson(computerdata, totalCount);
            #endregion
        }

        /// <summary>
        /// 保存computerdata数据集数据
        /// </summary>
        /// <param name="bookfromcountrydata">数据集对象</param>
        /// <returns>返回保存后的响应信息</returns>
        public String SaveComputer(ComputerData computerdata)
        {
            #region
            ComputerClass computerclass = new ComputerClass();
            return base.Save(computerdata, computerclass);
            #endregion
        }

        /// <summary>
        /// 添加Computer表行数据（如主键为非自增型字段，则自行修改代码）
        /// </summary>
        /// <param name="computerdata">数据集对象</param>
        /// <param name="computer">实体对象</param>
        public void AddRow(ref ComputerData computerdata, EntityComputer computer)
        {
            #region
            DataRow dr = computerdata.Tables[0].NewRow();
            computerdata.Assign(dr, ComputerData.computerId, computer.computerId);
            computerdata.Assign(dr, ComputerData.userName, computer.userName);
            computerdata.Assign(dr, ComputerData.userIp, computer.userIp);
            computerdata.Assign(dr, ComputerData.MACAddress, computer.MACAddress);
            computerdata.Assign(dr, ComputerData.IpUseStatus, computer.IpUseStatus);
            computerdata.Assign(dr, ComputerData.workStatus, computer.workStatus);
            computerdata.Assign(dr, ComputerData.computerType, computer.computerType);
            computerdata.Assign(dr, ComputerData.writeUser, computer.writeUser);
            computerdata.Assign(dr, ComputerData.writeTime, computer.writeTime);
            computerdata.Assign(dr, ComputerData.writeIp, computer.writeIp);
            computerdata.Assign(dr, ComputerData.remark, computer.remark);
            computerdata.Tables[0].Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 编辑computerdata数据集中指定的行数据
        /// </summary>
        /// <param name="computerdata">数据集对象</param>
        /// <param name="computer">实体对象</param>
        public void EditRow(ref ComputerData computerdata, EntityComputer computer)
        {
            #region
            if (computerdata.Tables[0].Rows.Count <= 0)
                computerdata = this.getData(computer.computerId);
            DataRow dr = computerdata.Tables[0].Rows.Find(new object[1] { computer.computerId });
            computerdata.Assign(dr, ComputerData.computerId, computer.computerId);
            computerdata.Assign(dr, ComputerData.userName, computer.userName);
            computerdata.Assign(dr, ComputerData.userIp, computer.userIp);
            computerdata.Assign(dr, ComputerData.MACAddress, computer.MACAddress);
            computerdata.Assign(dr, ComputerData.IpUseStatus, computer.IpUseStatus);
            computerdata.Assign(dr, ComputerData.workStatus, computer.workStatus);
            computerdata.Assign(dr, ComputerData.computerType, computer.computerType);
            computerdata.Assign(dr, ComputerData.writeUser, computer.writeUser);
            computerdata.Assign(dr, ComputerData.writeTime, computer.writeTime);
            computerdata.Assign(dr, ComputerData.writeIp, computer.writeIp);
            computerdata.Assign(dr, ComputerData.remark, computer.remark);
            #endregion
        }

        /// <summary>
        /// 删除computerdata数据集中指定的行数据
        /// </summary>
        /// <param name="computerdata">数据集对象</param>
        /// <param name="computerId">主键-</param>
        public void DeleteRow(ref ComputerData computerdata, string computerId)
        {
            #region
            if (computerdata.Tables[0].Rows.Count <= 0)
                computerdata = this.getData(computerId);
            DataRow dr = computerdata.Tables[0].Rows.Find(new object[1] { computerId });
            if (dr != null)
                dr.Delete();
            #endregion
        }

        /// <summary>
        /// 获取Computer数据表的全部数据
        /// </summary>
        /// <returns>Json字符串</returns>
        public string GetJsonByAll()
        {
            #region
            int totalCount = 0;
            ComputerData computerdata = this.getData(null);
            totalCount = computerdata.Tables[0].Rows.Count;
            return base.GetJson(computerdata, totalCount);
            #endregion
        }

        /// <summary>
        /// 将符合查询的数据导出Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="grid"></param>
        /// <param name="httplink"></param>
        public void OutputExcel(string filename, ExtjsGrid grid, EntityComputer computer)
        {
            #region
            int totalcount = 0;
            PageParams queryparams = new PageParams(1, 65536);
            DataSet ds = this.GetData(computer, queryparams, out totalcount);

            ExportExcelComputer exportexcelcomputer = new ExportExcelComputer(filename, ds, grid);
            exportexcelcomputer.Output();
            #endregion
        }
        #endregion

        #region private members methods

        /// <summary>
        /// 根据主键值检索符合该条件的记录，用于编辑和删除记录时。
        /// </summary>
        /// <param name="computerId">主键-</param>
        /// <returns></returns>
        private ComputerData getData(string computerId)
        {
            #region
            ComputerData computerdata = new ComputerData();
            DBConditions querybusinessparams = new DBConditions();
            querybusinessparams.Add(ComputerData.computerId, EnumSqlType.sqlint, EnumCondition.Equal, computerId);
            this._computerclass.GetSingleT(computerdata, querybusinessparams);
            return computerdata;
            #endregion
        }

        /// <summary>
        /// 根据条件筛选所有Computer指定页码的数据（分页型）
        /// </summary>
        /// <param name="computer">实体对象</param>
        /// <param name="pageparams">分页对象</param>
        /// <param name="totalCount">符合条件的记录总数量</param>
        /// <returns></returns>
        public DataSet GetData(EntityComputer computer, PageParams pageparams, out int totalCount)
        {
            #region
            DBConditions querybusinessparams = new DBConditions(pageparams);
            querybusinessparams.Add(ComputerData.computerId, EnumSqlType.sqlint,
                EnumCondition.Equal, computer.computerId);
            querybusinessparams.Add(ComputerData.userName, EnumSqlType.nvarchar,
                EnumCondition.Equal, computer.userName);
            querybusinessparams.Add(ComputerData.userIp, EnumSqlType.nvarchar,
                EnumCondition.Equal, computer.userIp);
            querybusinessparams.Add(ComputerData.MACAddress, EnumSqlType.nvarchar,
                EnumCondition.Equal, computer.MACAddress);
            querybusinessparams.Add(ComputerData.IpUseStatus, EnumSqlType.tinyint,
                EnumCondition.Equal, computer.IpUseStatus);
            querybusinessparams.Add(ComputerData.workStatus, EnumSqlType.tinyint,
                EnumCondition.Equal, computer.workStatus);
            querybusinessparams.Add(ComputerData.computerType, EnumSqlType.tinyint,
                EnumCondition.Equal, computer.computerType);
            querybusinessparams.Add(ComputerData.writeUser, EnumSqlType.sqlint,
                EnumCondition.Equal, computer.writeUser);
            querybusinessparams.Add(ComputerData.writeTime, EnumSqlType.datetime,
                EnumCondition.Equal, computer.writeTime);
            querybusinessparams.Add(ComputerData.writeIp, EnumSqlType.nvarchar,
                EnumCondition.Equal, computer.writeIp);
            querybusinessparams.Add(ComputerData.remark, EnumSqlType.nvarchar,
                EnumCondition.Equal, computer.remark);
            ComputerData computerdata = new ComputerData();
            totalCount = this._computerclass.GetSingleT(computerdata, querybusinessparams);
            return computerdata;
            #endregion
        }
        #endregion

        #endregion
    }
}
