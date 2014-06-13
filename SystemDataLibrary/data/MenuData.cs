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
    public class MenuData : DataLibBase
    {
        
        /// <summary>
        /// 自动编号。
        /// </summary>
        public const string menuId = "menuId";
        /// <summary>
        /// 当前菜单编号。
        /// </summary>
        public const string currentId = "currentId";
        /// <summary>
        /// 父菜单编号。
        /// </summary>
        public const string parentId = "parentId";
        /// <summary>
        /// 菜单名称。
        /// </summary>
        public const string menuName = "menuName";
        /// <summary>
        /// 图标类名。
        /// </summary>
        public const string iconCls = "iconCls";
        /// <summary>
        /// HTML链接。
        /// </summary>
        public const string htmlurl = "htmlurl";
        /// <summary>
        /// 点击事件名。
        /// </summary>
        public const string eventName = "eventName";
        /// <summary>
        /// 排序号。
        /// </summary>
        public const string sort = "sort";
        /// <summary>
        /// 可用性。
        /// </summary>
        public const string usable = "usable";
        /// <summary>
        /// 表名。
        /// </summary>
        public const string Menu = "Menu";
        
        private void BuildData()
        {
            DataTable dt = new DataTable(Menu);
            
            dt.Columns.Add(menuId, typeof(System.Int32));
            dt.Columns.Add(currentId, typeof(System.Int32));
            dt.Columns.Add(parentId, typeof(System.Int32));
            dt.Columns.Add(menuName, typeof(System.String));
            dt.Columns.Add(iconCls, typeof(System.String));
            dt.Columns.Add(htmlurl, typeof(System.String));
            dt.Columns.Add(eventName, typeof(System.String));
            dt.Columns.Add(sort, typeof(System.Int32));
            dt.Columns.Add(usable, typeof(System.Boolean));
            dt.PrimaryKey = new DataColumn[1] { dt.Columns[menuId] };
            dt.TableName = Menu;
            this.Tables.Add(dt);
            this.DataSetName = "TMenu";
        }

        public MenuData()
        {
            this.BuildData();
        }
    }
}
#endregion

