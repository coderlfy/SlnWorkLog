/****************************************
###创建人：lify
###创建时间：2012-10-29
###公司：山西ICat Studio有限公司
###摘要：主要针对考题进行事件管理。
****************************************/
using ExamDataLibrary;
using ExamSystemConfig.common;
using ExamSystemConfig.frm;
using Fundation.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;

namespace ExamSystemConfig
{
    public partial class MainWindow
    {
        /// <summary>
        /// (button)添加新试题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showAddNewQuestion(object sender, RoutedEventArgs e)
        {
            #region
            NewQuestion frmquestion = new NewQuestion(ExamQuestionState.NormalAdd);
            frmquestion.InitUI();
            frmquestion.ShowDialog();
            #endregion
        }
        /// <summary>
        /// 编辑选中考题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showEditQuestion(object sender, RoutedEventArgs e)
        {
            #region
            this.AddDBCheck(() =>
            {
                DataRowView drvquestion = null;
                if (this.dgQuestion.SelectedItem != null)
                    drvquestion = this.dgQuestion.SelectedItem as DataRowView;
                else
                {
                    ExtMessage.Show("请选中要编辑的数据！");
                    return;
                }
                NewQuestion frmquestion = new NewQuestion(ExamQuestionState.NormalEdit);
                frmquestion.QuestionRow = QuestionController.QuestionData.Tables[0]
                    .Rows.Find(drvquestion[ExamQuestionData.questionId]);
                frmquestion.InitUI();
                frmquestion.ShowDialog();
            });
            #endregion
        }
        /// <summary>
        /// (linkbutton)添加新试题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addQuestion(object sender, RoutedEventArgs e)
        {
            #region
            this.AddDBCheck(() =>
            {
                this.tcMainWindowTab.SelectedIndex = 1;
                showAddNewQuestion(null, null);
            });
            #endregion
        }
        /// <summary>
        ///  (linkbutton)查询试题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryQuestion(object sender, RoutedEventArgs e)
        {
            #region
            this.AddDBCheck(() =>
            {
                this.tcMainWindowTab.SelectedIndex = 1;
                ExtMessage.Show("在列表顶端的查询区域输入关键字或按照试题类型、试题领域进行组合查询！");
            });
            #endregion
        }
        /// <summary>
        /// tbar上查询试题事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarQueryQuestion(object sender, RoutedEventArgs e)
        {
            #region
            this.AddDBCheck(() =>
            {
                this.CtrlToEntityQuestion();
                TimeManager.CaculateQuerySpan(() =>
                {
                    QuestionController.InitDB();
                }, () =>
                {
                    QuestionController.BindDgQuestion(this.dgQuestion);
                }, this.btnQuerySpan, this.ctlProgress);

            });
            #endregion
        }
    }
}
