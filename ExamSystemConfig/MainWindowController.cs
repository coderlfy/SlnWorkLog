
using ExamSystemConfig.custom;
using Fundation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ExamSystemConfig
{
    public partial class MainWindow
    {
        public static bool IsConnectingDB = false;
        public static bool isTestConnectDBing = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowTabQuestion(object sender
            , RoutedEventArgs e)
        {
            #region
            this.showTabFirst();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void showTabFirst()
        {
            #region
            this.tcMainWindowTab.SelectedIndex = 0;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void showTabQuestion()
        {
            #region
            this.tcMainWindowTab.SelectedIndex = 1;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void setTitle()
        {
            #region
            string appFullname = string.Format("{0} V{1}", 
                CustomConfig.ApplicationName, 
                CustomConfig.ApplicationVersion);

            this.Title = appFullname;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void setAboutDevelop()
        {
            #region
            this.tbAppName.Text = CustomConfig.ApplicationName;
            this.tbDevCompany.Text = CustomConfig.DevCompanyName;
            this.tbHelpTelephone.Text = CustomConfig.HelpTelephone;
            this.tbDeveloper.Text = CustomConfig.Developer;
            this.tbAboutSoftware.Text = CustomConfig.AboutSoftware;
            this.tbDevStartDate.Text = CustomConfig.DevStartDate;
            this.tbAppVersion.Text = string.Format("V{0}", CustomConfig.ApplicationVersion);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void initController()
        {
            #region
            if (IsConnectingDB)
            {
                OtherController.InitDB();
                OtherController.BindCBQuestionScope(this.cbQuestionScope);
                OtherController.BindCBQuestionType(this.cbQuestiontype);

                this.CtrlToEntityQuestion();
                QuestionController.InitDB();
                QuestionController.BindDgQuestion(this.dgQuestion);

                BackgroundThreadManager.StartAll();
                lazyBindEvent();
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public void InitUI()
        {
            #region
            this.setTitle();
            this.setAboutDevelop();

            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void CtrlToEntityQuestion()
        {
            #region
            QuestionController.EntityQuestion.questionName 
                = this.tbQuestionTitleKey.Text.Trim();

            QuestionController.EntityQuestion.questionScopeId 
                = this.cbQuestionScope.SelectedValue.ToString();

            QuestionController.EntityQuestion.questionTypeId
                = this.cbQuestiontype.SelectedValue.ToString();
            #endregion
        }

        private void lazyBindEvent()
        {
            #region
            this.cbQuestiontype.SelectionChanged += tbarQueryQuestion;
            this.cbQuestionScope.SelectionChanged += tbarQueryQuestion;
            #endregion
        }
    }
}
