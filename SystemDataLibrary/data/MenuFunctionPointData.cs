#region Create by iCat Assist Tools
/****************************************
***生成器版本：V1.0.1.28380
***创建人：bhlfy
***生成时间：2013-04-06 17:01:07
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
    public class MenuFunctionPointData : DataLibBase
    {
        
        /// <summary>
        /// 功能点编号。
        /// </summary>
        public const string functionId = "functionId";
        /// <summary>
        /// 菜单编号。
        /// </summary>
        public const string menuId = "menuId";
        /// <summary>
        /// 功能点名称。
        /// </summary>
        public const string functionPointName = "functionPointName";
        /// <summary>
        /// 时间名称。
        /// </summary>
        public const string eventName = "eventName";
        /// <summary>
        /// 排序号。
        /// </summary>
        public const string sort = "sort";
        /// <summary>
        /// 备注。
        /// </summary>
        public const string remark = "remark";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string MenuFunctionPoint = "MenuFunctionPoint";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(MenuFunctionPoint);
            
            dt.Columns.Add(functionId, typeof(System.Int32));
            dt.Columns.Add(menuId, typeof(System.Int32));
            dt.Columns.Add(functionPointName, typeof(System.String));
            dt.Columns.Add(eventName, typeof(System.String));
            dt.Columns.Add(sort, typeof(System.Int32));
            dt.Columns.Add(remark, typeof(System.String));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[functionId] };
            dt.TableName = MenuFunctionPoint;
            this.Tables.Add(dt);
            this.DataSetName = "TMenuFunctionPoint";
        }

        public MenuFunctionPointData()
        {
            this.BuildData();
        }
    }
}
#endregion

