/****************************************
***创建人：bhlfy
***创建时间：2013-08-29 03:00:29
***公司：iCat Studio
***修改人：
***修改时间：
***文件描述：。
*****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fundation.Core
{
    
    public class PageParams
    {
        private string _TableName;
        private string _ReturnFields;
        private int _PageIndex = 1;
        private int _PageSize = int.MaxValue;
        private PageSortCollection _pagesorts = new PageSortCollection();
        private string _Orderfld;
        private int _OrderType = 0;

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                _TableName = value;
            }

        }
        /// <summary>
        /// 返回字段
        /// </summary>
        public string ReturnFields
        {
            get
            {
                return _ReturnFields;
            }
            set
            {
                _ReturnFields = value;
            }
        }
        /// <summary>
        /// 排序条件
        /// </summary>
        public PageSortCollection PageSorts 
        {
            get
            {
                return _pagesorts;
            }
            set
            {
                _pagesorts = value;
            }
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex
        {
            get
            {
                return _PageIndex;
            }
            set
            {
                _PageIndex = value;
            }

        }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = value;
            }
        }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Orderfld
        {
            get
            {
                return _Orderfld;
            }
            set
            {
                _Orderfld = value;
            }
        }
        /// <summary>
        /// 排序类型 1:降序 其它为升序
        /// </summary>
        public int OrderType
        {
            get
            {
                return _OrderType;
            }
            set
            {
                _OrderType = value;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_mPageIndex">当前页码</param>
        /// <param name="_mPageSize">每页记录数</param>
        public PageParams(int _mPageIndex, int _mPageSize)
        {
            _PageIndex = _mPageIndex;
            _PageSize = _mPageSize;
        }
        public PageParams()
        {
        }
        /*
        public void SetDefaultOrderBy(string orderfld, EnumSQLOrderBY orderByType)
        {
            #region
            if (_Orderfld == null)
                this.Orderfld = orderfld;
            switch (orderByType)
            {
                case EnumSQLOrderBY.ASC:
                    this.OrderType = 0;
                    break;
                case EnumSQLOrderBY.DESC:
                    this.OrderType = 1;
                    break;
                default:
                    this.OrderType = 0;
                    break;
            }
            #endregion
        }*/
    }
}
