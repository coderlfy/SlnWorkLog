/****************************************
###创建人：lify
###创建时间：2012-10-29
###公司：山西ICat Studio有限公司
###摘要：针对本软件固定通用参数的管理。
****************************************/
using Fundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExamSystemConfig.custom
{
    public class CustomConfig
    {
        private const String ServiceURLConfigName = "ServiceURL";
        private const String LogDirectoryKeyName = "LogDirectoryName";
        private const String ApplicationNameKey = "ApplicationName";
        private const String ApplicationVersionKeyName = "ApplicationVersion";
        private const String TextBoxMaxLineKeyName = "TextBoxMaxLine";
        public const String IconStreamName = "CenterServices.App.ico";
        public const String MiddleDBKeyName = "ConnectStringMiddle";

        private static String _defaultServiceURL = "net.tcp://localhost:22222";
        private static String _logDirName = "logs";
        private static String _appName = "博华考试后台管理程序";
        private static String _middleDBConnectionString = "";

        public const String DevCompanyName = "山西ICat Studio有限公司";
        public const String Developer = "Cat";
        public const String HelpTelephone = "0351-7037628";
        public const String DevStartDate = "2013-10-20";
        public const String AboutSoftware = @"该软件定位于为公司内部人员考试或应聘人员面试题目管理等功能，主要包括了有考卷管理、试题模版管理、试题管理等模块。";

        private static int _textBoxMaxLine = 1000;
        /// <summary>
        /// 中心端提供的接口服务地址
        /// </summary>
        public static String ServiceURL
        {
            #region
            get
            {
                return _defaultServiceURL;
            }
            set
            {
                _defaultServiceURL = value;
            }
            #endregion
        }
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static String ApplicationName
        {
            #region
            get
            {
                return _appName;
            }
            #endregion
        }
        /// <summary>
        /// 应用程序版本
        /// </summary>
        public static String ApplicationVersion
        {
            #region
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            #endregion
        }
        /// <summary>
        /// 应用程序日志文件名
        /// </summary>
        public static String LogDirectoryName
        {
            #region
            get
            {
                return _logDirName;
            }
            set
            {
                _logDirName = value;
            }
            #endregion
        }
        /// <summary>
        /// 控制台最大显示行数
        /// </summary>
        public static int TextBoxMaxLine
        {
            #region
            get
            {
                return _textBoxMaxLine;
            }
            set
            {
                _textBoxMaxLine = value;
            }
            #endregion
        }
        /// <summary>
        /// 中间库的连接字符串
        /// </summary>
        public static String MiddleDBConnectionString
        {
            #region
            get
            {
                return _middleDBConnectionString;
            }
            set
            {
                _middleDBConnectionString = value;
            }
            #endregion
        }
        /// <summary>
        /// 获取系统参数
        /// </summary>
        public static void GetSystemParameters()
        {
            #region
            ServiceURL = Config.Get(CustomConfig.ServiceURLConfigName, _defaultServiceURL);

            LogDirectoryName = Config.Get(CustomConfig.LogDirectoryKeyName, _logDirName);

            TextBoxMaxLine = int.Parse(Config.Get(CustomConfig.TextBoxMaxLineKeyName,
                _textBoxMaxLine.ToString()));

            //MiddleDBConnectionString = Config.GetConnectString(MiddleDBKeyName);
            #endregion
        }
    }
}
