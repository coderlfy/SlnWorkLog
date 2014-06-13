#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.28380
***创建人：bhlfy
***生成时间：2013-04-06 17:01:08
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
            
namespace SystemDataLibrary
{
    public class UsbKeyData : DataLibBase
    {
        
        /// <summary>
        /// 密钥编号。
        /// </summary>
        public const string keyId = "keyId";
        /// <summary>
        /// 持有人用户编号。
        /// </summary>
        public const string userid = "userid";
        /// <summary>
        /// 录入人编号。
        /// </summary>
        public const string writeUserid = "writeUserid";
        /// <summary>
        /// 持有人姓名。
        /// </summary>
        public const string fullname = "fullname";
        /// <summary>
        /// 发放时刻。
        /// </summary>
        public const string giveoutTime = "giveoutTime";
        /// <summary>
        /// （不用）。
        /// </summary>
        public const string giveoutPerson = "giveoutPerson";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 录入时刻。
        /// </summary>
        public const string writeTime = "writeTime";
        /// <summary>
        /// 录入人IP地址。
        /// </summary>
        public const string writeIp = "writeIp";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string UsbKey = "UsbKey";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(UsbKey);
            
            dt.Columns.Add(keyId, typeof(System.Int32));
            dt.Columns.Add(userid, typeof(System.Int32));
            dt.Columns.Add(writeUserid, typeof(System.Int32));
            dt.Columns.Add(fullname, typeof(System.String));
            dt.Columns.Add(giveoutTime, typeof(System.DateTime));
            dt.Columns.Add(giveoutPerson, typeof(System.Int32));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.Columns.Add(writeTime, typeof(System.DateTime));
            dt.Columns.Add(writeIp, typeof(System.String));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[keyId] };
            dt.TableName = UsbKey;
            this.Tables.Add(dt);
            this.DataSetName = "TUsbKey";
        }

        public UsbKeyData()
        {
            this.BuildData();
        }
    }
}
#endregion

