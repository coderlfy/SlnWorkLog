/****************************************
###创建人：lify
###创建时间：2012-10-29
###公司：山西博华科技有限公司
###摘要：主要针对数据库参数配置事件管理。
****************************************/
using ExamSystemConfig.common;
using ExamSystemConfig.frm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ExamSystemConfig
{
    public partial class MainWindow
    {

        private void setDBConnectConfig(object sender
            , RoutedEventArgs e)
        {
            #region
            (new DBConfig()).ShowDialog();
            #endregion
        }

        private void resetConnectDB(object sender
            , RoutedEventArgs e)
        {
            #region
            if (isTestConnectDBing)
                ExtMessage.Show("正在尝试连接数据库……");
            else
            {
                if (IsConnectingDB)
                    ExtMessage.Show("已连接上数据库，软件可以正常使用！");
                else
                {
                    if (ExtMessage.ShowConfirm("您确认要重新连接数据库吗？")
                        == System.Windows.Forms.DialogResult.OK)
                    {
                        this.getDBDataToUI();
                    }
                }
            }
            #endregion
        }

    }
}
