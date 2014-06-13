using BusinessBase;
using ExamSystemConfig.common;
using Fundation.Core;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;

namespace ExamSystemConfig.frm
{
    /// <summary>
    /// DBConfig.xaml 的交互逻辑
    /// </summary>
    public partial class DBConfig
    {
        private bool _isTestSuccessfull = false;
        private string _cfgFileName = "ExamSystemConfig.exe.config";
        private const string connectdbHelp = @"1.如果目标数据库实例未找到，有可能会延时较长，请耐心等待！
2.如果目标数据库服务器上有多次安装数据库实例的情况，请确保实例名要正确。";
        /// <summary>
        /// 
        /// </summary>
        public DBConfig()
        {
            #region
            InitializeComponent();

            WpfStyle.Init(this);

            InitUI();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitUI()
        {
            #region
            this.tbHelp.Text = connectdbHelp;
            if (File.Exists(_cfgFileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_cfgFileName);
                //找出名称为“add”的所有元素
                XmlNodeList nodes = doc.GetElementsByTagName("add");
                for (int i = 0; i < nodes.Count; i++)
                {
                    //获得将当前元素的key属性
                    XmlAttribute att = nodes[i].Attributes["name"];
                    //根据元素的第一个属性来判断当前的元素是不是目标元素
                    if (att == null)
                        continue;

                    if (att.Value == "ConnectString")
                    {
                        //对目标元素中的第二个属性赋值
                        att = nodes[i].Attributes["connectionString"];
                        this.tbDataSource.Text = this.GetValue(att.Value, "Data Source=");
                        this.tbDataBase.Text = this.GetValue(att.Value, "Initial Catalog=");
                        this.tbUsername.Text = this.GetValue(att.Value, "User ID=");
                        this.tbPassword.Text = this.GetValue(att.Value, "Password=");
                        break;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 获取对应的键值
        /// </summary>
        /// <param name="destStr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetValue(string destStr, string key)
        {
            #region
            string value = "";
            int idx = destStr.IndexOf(key);
            if (idx >= 0)
            {
                idx = idx + key.Length;
                while (destStr[idx++] != ';')
                {
                    value += destStr[idx - 1];
                }
            }
            return value;
            #endregion
        }

        private delegate void DLConnectDB(string connectString);
        private delegate void DLControlProgress();
        private void ConnectDB(string connectString)
        {
            #region
            try
            {
                DateTime dt = CustomTime.GetDBServerTime(connectString);
                ExtMessage.Show(@"连接成功，返回服务器时间" + dt.ToString() +
                    "\r\n现在可以点击“保存数据库参数”确保下次程序开启后能正确连接数据库！");
                this._isTestSuccessfull = true;
            }
            catch
            {
                ExtMessage.ShowError("连接不成功！");
            }
            finally {
                this.Dispatcher.BeginInvoke(
                    new DLControlProgress(() => {
                    this.ctlprogress.IsActive = false;
                    }), null);
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testDbConnect(object sender
            , RoutedEventArgs e)
        {
            #region
            this.ctlprogress.IsActive = true;
            string newConnectString = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};";

            string[] cStrArr = new string[4];
            cStrArr[0] = this.tbDataSource.Text.Trim();
            cStrArr[1] = this.tbDataBase.Text.Trim();
            cStrArr[2] = this.tbUsername.Text.Trim();
            cStrArr[3] = this.tbPassword.Text.Trim();
            newConnectString = String.Format(newConnectString, cStrArr);
            DLConnectDB connectdb = new DLConnectDB(this.ConnectDB);
            connectdb.BeginInvoke(newConnectString, null, null);
            #endregion
        }

        private void saveDbConnectParams(object sender
            , RoutedEventArgs e)
        {
            #region
            if (!_isTestSuccessfull)
            {
                ExtMessage.Show(@"请先测试连接成功后再进行保存！");
            }
            else
            {
                string newConnectString = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};";
                string[] cStrArr = new string[4];
                cStrArr[0] = this.tbDataSource.Text.Trim();
                cStrArr[1] = this.tbDataBase.Text.Trim();
                cStrArr[2] = this.tbUsername.Text.Trim();
                cStrArr[3] = this.tbPassword.Text.Trim();
                
                newConnectString = String.Format(newConnectString, cStrArr);

                XmlDocument doc = new XmlDocument();
                doc.Load(_cfgFileName);
                //找出名称为“add”的所有元素
                XmlNodeList nodes = doc.GetElementsByTagName("add");
                for (int i = 0; i < nodes.Count; i++)
                {
                    //获得将当前元素的key属性
                    XmlAttribute att = nodes[i].Attributes["name"];
                    //根据元素的第一个属性来判断当前的元素是不是目标元素
                    if (att.Value == "ConnectString")
                    {
                        //对目标元素中的第二个属性赋值
                        att = nodes[i].Attributes["connectionString"];
                        att.Value = newConnectString;
                        break;
                    }
                }
                doc.Save(_cfgFileName);
                System.Diagnostics.Process.Start("RestartApplication.exe", "ExamSystemConfig.exe");
                System.Environment.Exit(0);
                this.Close();

            }
            #endregion
        }

        void tb_TextChanged(object sender
            , System.Windows.Controls.TextChangedEventArgs e)
        {
            if (_isTestSuccessfull)
                if (e.UndoAction != System.Windows.Controls.UndoAction.Merge)
                    _isTestSuccessfull = false;
        }
    }
}
