#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.31494
***创建人：bhlfy
***生成时间：2013-05-04 20:32:25
***公司：山西ICat Studio有限公司
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Fundation.Core;
            
namespace WorkLogDataLibrary
{
    public class WLOGProjectTreeData : DataLibBase
    {
        
        /// <summary>
        /// 父节点编号。
        /// </summary>
        public const string parentId = "parentId";
        /// <summary>
        /// 当前项目节点编号。
        /// </summary>
        public const string currentId = "currentId";
        /// <summary>
        /// 用户编号。
        /// </summary>
        public const string writeUser = "writeUser";
        /// <summary>
        /// 项目节点名称。
        /// </summary>
        public const string dirName = "dirName";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 录入人IP地址。
        /// </summary>
        public const string writeIp = "writeIp";
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public const string writeTime = "writeTime";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string WLOGProjectTree = "WLOGProjectTree";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(WLOGProjectTree);
            
            dt.Columns.Add(parentId, typeof(System.Int32));
            dt.Columns.Add(currentId, typeof(System.Int32));
            dt.Columns.Add(writeUser, typeof(System.Int32));
            dt.Columns.Add(dirName, typeof(System.String));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[currentId] };
            dt.TableName = WLOGProjectTree;
            this.Tables.Add(dt);
            this.DataSetName = "TWLOGProjectTree";
        }

        public WLOGProjectTreeData()
        {
            this.BuildData();
        }
    }
}
#endregion

