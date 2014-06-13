using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestartApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            if (MessageBox.Show("数据库参数配置修改成功，程序自动重新启动！",
                "系统提示", MessageBoxButtons.OK, 
                MessageBoxIcon.Information) == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(args[0]);
                System.Environment.Exit(0);
            }
        }
    }
}
