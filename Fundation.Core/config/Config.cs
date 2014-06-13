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
using System.Configuration;
using System.Linq;
using System.Text;

namespace Fundation.Core
{
    public class Config
    {
        public static string Get(string name)
        {
            return System.Configuration.ConfigurationManager.AppSettings[name];
        }

        public static string GetConnectString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        /// <summary>
        /// 获取config键值
        /// </summary>
        /// <param name="keyName">键名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string Get(string keyName, string defaultValue)
        {
            #region
            string value = "";
            if (System.Configuration.ConfigurationManager.AppSettings[keyName] == null)
            {
                Save(keyName, defaultValue);
                value = defaultValue.ToString();
            }
            else
                value = System.Configuration.ConfigurationManager.AppSettings[keyName];
            return value;
            #endregion
        }
        /// <summary>
        /// 保存App.config
        /// </summary>
        /// <param name="keyName">键名</param>
        /// <param name="value">目标值</param>
        public static string Save(string keyName, string value)
        {
            #region
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (System.Configuration.ConfigurationManager.AppSettings[keyName] != null)
                configuration.AppSettings.Settings[keyName].Value = value;
            else
                configuration.AppSettings.Settings.Add(keyName, value);
            configuration.Save();
            return value;
            #endregion
        }
        /// <summary>
        /// 更新App.config文件
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="value"></param>
        public static string Update(string keyName, string value)
        {
            #region
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[keyName].Value = value;
            configuration.Save();
            return value;
            #endregion
        }
    

    }
}
