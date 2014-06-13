/****************************************
###创建人：lify
###创建时间：2012-10-29
###公司：山西博华科技有限公司
###摘要：针对问题领域转换显示。
****************************************/
using ExamDataLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ExamSystemConfig
{
    class QuestionScopeConverter : IValueConverter
    {
        public object Convert(object value,
           Type targetType, object parameter
           , CultureInfo culture)
        {
            #region
            DataRow temprow = OtherController.QuestionScopeData
                .Tables[0].Rows.Find(value);

            if (temprow != null)
                return temprow[ExamQuestionScopeData.questionScopeName].ToString();
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
