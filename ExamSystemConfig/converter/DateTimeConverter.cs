/****************************************
###创建人：lify
###创建时间：2012-10-29
###公司：山西ICat Studio有限公司
###摘要：时间格式进行转换（长时间格式）。
****************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ExamSystemConfig
{
    class DateTimeConverter : IValueConverter
    {
        public object Convert(object value,
           Type targetType, object parameter
           , CultureInfo culture)
        {
            #region
            DateTime temp;
            DateTime.TryParse(value.ToString(), out temp);

            if (temp != null)
                return temp.ToString("yyyy-MM-dd HH:mm:ss");
            else
                return value;
            #endregion
        }
        //ConvertBack方法将显示值转换成原来的格式,因为我不需要反向转换,所以直接抛出个异常  
        public object ConvertBack(object value
            , Type targetType, object parameter
            , CultureInfo culture)
        {
            #region
            throw new NotImplementedException();
            #endregion
        }
    }
}
