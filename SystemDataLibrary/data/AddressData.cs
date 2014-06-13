#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.28380
***创建人：bhlfy
***生成时间：2013-04-06 17:01:07
***公司：山西博华科技有限公司
***友情提示：本文件为生成器自动生成，切勿手动更改
***         如发现任何编译和运行时的错误，请联系QQ：330669393。
*****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Fundation.Core;
            
namespace SystemDataLibrary
{
    public class AddressData : DataLibBase
    {
        
        /// <summary>
        /// 地市编号。
        /// </summary>
        public const string addrId = "addrId";
        /// <summary>
        /// 地市名称。
        /// </summary>
        public const string addrName = "addrName";
        /// <summary>
        /// 父级地市。
        /// </summary>
        public const string parentId = "parentId";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string Address = "Address";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(Address);
            
            dt.Columns.Add(addrId, typeof(System.Int32));
            dt.Columns.Add(addrName, typeof(System.String));
            dt.Columns.Add(parentId, typeof(System.Int32));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[addrId] };
            dt.TableName = Address;
            this.Tables.Add(dt);
            this.DataSetName = "TAddress";
        }

        public AddressData()
        {
            this.BuildData();
        }
    }
}
#endregion

