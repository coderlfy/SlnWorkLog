
namespace ExamSystemConfig
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            #region
            InitializeComponent();

            WpfStyle.Init(this);

            this.InitUI();

            this.getDBDataToUI();
            #endregion
        }
    }
}
