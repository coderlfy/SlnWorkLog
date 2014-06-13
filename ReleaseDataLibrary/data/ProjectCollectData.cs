using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Fundation.Core;

namespace ReleaseDataLibrary
{
    public class ProjectCollectData : DataLibBase
    {

        /// <summary>
        /// 工程部汇总Id 。
        /// </summary>
        public const string projectCollectId = "projectCollectId";
        /// <summary>
        /// 汇总分类Id 。
        /// </summary>
        public const string collectTypeId = "collectTypeId";
        /// <summary>
        /// 工程部项目名称。
        /// </summary>
        public const string projectItemName = "projectItemName";
        /// <summary>
        /// 系统名称。
        /// </summary>
        public const string systemName = "systemName";
        /// <summary>
        /// 归档编号。
        /// </summary>
        public const string fileNo = "fileNo";
        /// <summary>
        /// 归档时间。
        /// </summary>
        public const string fileTime = "fileTime";
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
        public const string ProjectCollect = "ProjectCollect";

        private void BuildData()
        {
            DataTable dt = new DataTable(ProjectCollect);

            dt.Columns.Add(projectCollectId, typeof(System.Int32));
            dt.Columns.Add(collectTypeId, typeof(System.Int32));
            dt.Columns.Add(projectItemName, typeof(System.String));
            dt.Columns.Add(systemName, typeof(System.String));
            dt.Columns.Add(fileNo, typeof(System.String));
            dt.Columns.Add(fileTime, typeof(System.DateTime));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[projectCollectId] };
            dt.TableName = ProjectCollect;
            this.Tables.Add(dt);
            this.DataSetName = "TProjectCollect";
        }

        public ProjectCollectData()
        {
            this.BuildData();
        }

    }
}
