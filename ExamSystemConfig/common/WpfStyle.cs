using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ExamSystemConfig
{
    class WpfStyle
    {
        public static void Init(Window r)
        {
            ThemeManager.ChangeTheme(r, ThemeManager
            .DefaultAccents.First(x => x.Name == "Blue"), Theme.Dark);
        }
    }
}
