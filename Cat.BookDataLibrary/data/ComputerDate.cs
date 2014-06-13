using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Fundation.Core;

namespace Cat.BookDataLibrary
{
    public class ComputerData : DataLibBase
    {

        /// <summary>
        ///计算机Id(序列号) 。
        /// </summary>
        public const string computerId = "computerId";
        /// <summary>
        ///人员姓名 。
        /// </summary>
        public const string userName = "userName";
        /// <summary>
        /// 使用人Ip。
        /// </summary>
        public const string userIp = "userIp";
        /// <summary>
        /// MAC地址。
        /// </summary>
        public const string MACAddress = "MACAddress";
        /// <summary>
        /// Ip使用状态（1 使用中 2 未使用）。
        /// </summary>
        public const string IpUseStatus = "IpUseStatus";
        /// <summary>
        /// 工作状态（1 在职 2 离职）。
        /// </summary>
        public const string workStatus = "workStatus";
        /// <summary>
        /// 计算机类型（1 台式 2 笔记本）。
        /// </summary>
        public const string computerType = "computerType";
        /// <summary>
        /// 录入人。
        /// </summary>
        public const string writeUser = "writeUser";
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public const string writeTime = "writeTime";
        /// <summary>
        /// 录入人Ip。
        /// </summary>
        public const string writeIp = "writeIp";
        /// <summary>
        /// 备注。
        /// </summary>
        public const string remark = "remark";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string Computer = "Computer";

        private void BuildData()
        {
            DataTable dt = new DataTable(Computer);

            dt.Columns.Add(computerId, typeof(System.Int32));
            dt.Columns.Add(userName, typeof(System.String));
            dt.Columns.Add(userIp, typeof(System.String));
            dt.Columns.Add(MACAddress, typeof(System.String));
            dt.Columns.Add(IpUseStatus, typeof(System.Byte));
            dt.Columns.Add(workStatus, typeof(System.Byte));
            dt.Columns.Add(computerType, typeof(System.Byte));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(remark, typeof(System.String));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[computerId] };
            dt.TableName = Computer;
            this.Tables.Add(dt);
            this.DataSetName = "TComputer";
        }

        public ComputerData()
        {
            this.BuildData();
        }
    }
}
