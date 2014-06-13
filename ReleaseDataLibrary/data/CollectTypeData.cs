using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Fundation.Core;

namespace ReleaseDataLibrary
{
    public class CollectTypeData : DataLibBase
    {

        /// <summary>
        /// 汇总分类Id 。
        /// </summary>
        public const string collectTypeId = "collectTypeId";
        /// <summary>
        /// 发布编号 。
        /// </summary>
        public const string releaseNo = "releaseNo";
        /// <summary>
        /// 发布类型（1 对内 2 对生产 3 对工程）。
        /// </summary>
        public const string releaseType = "releaseType";
        /// <summary>
        /// 发布时间。
        /// </summary>
        public const string releaseTime = "releaseTime";
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
        /// 表名。
        /// </summary>
        public const string CollectType = "CollectType";

        private void BuildData()
        {
            DataTable dt = new DataTable(CollectType);

            dt.Columns.Add(collectTypeId, typeof(System.Int32));
            dt.Columns.Add(releaseNo, typeof(System.String));
            dt.Columns.Add(releaseType, typeof(System.Int32));
            dt.Columns.Add(releaseTime, typeof(System.DateTime));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[collectTypeId] };
            dt.TableName = CollectType;
            this.Tables.Add(dt);
            this.DataSetName = "TCollectType";
        }

        public CollectTypeData()
        {
            this.BuildData();
        }

    }
}
