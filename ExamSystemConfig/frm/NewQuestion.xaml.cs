
using System.Linq;
using MahApps.Metro;
using System.Windows;
using ExamSystemConfig.common;
using Fundation.Core;
using ExamDataLibrary;
using System;
using ExamBusiness;
using System.Data;

namespace ExamSystemConfig.frm
{
    /// <summary>
    /// NewQuestion.xaml 的交互逻辑
    /// </summary>
    public partial class NewQuestion
    {
        private string questiontype = "";

        private ExamQuestionState _frmState = ExamQuestionState.NormalAdd;
        private ExamAnswerEstimateData _answerEstimateData = null;
        private EntityExamAnswerEstimate _entityAnswerEstimate = null;

        public DataRow QuestionRow = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public NewQuestion(ExamQuestionState frmState)
        {
            #region
            InitializeComponent();
            this._frmState = frmState;

            WpfStyle.Init(this);

            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void showFirstTab()
        {
            #region
            this.tpQuestion.SelectedIndex = 0;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void showEstimateTab()
        {
            #region
            this.tpQuestion.SelectedIndex = 2;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void showEssayTab()
        {
            #region
            this.tpQuestion.SelectedIndex = 1;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void showSelectTab()
        {
            #region
            this.tpQuestion.SelectedIndex = 3;
            #endregion
        }
        /// <summary>
        /// 提交考题内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitQuestionContent(object sender
            , RoutedEventArgs e)
        {
            #region
            if (this.cbQuestiontype.SelectedValue != null)
                questiontype = this.cbQuestiontype.SelectedValue.ToString();

            switch (questiontype)
            {
                case "1":
                    this.tbQuestionSelect.Text = this.tbQuestion.Text;
                    this.showSelectTab();
                    break;
                case "2":
                    this.showEstimateTab();
                    if (_frmState == ExamQuestionState.NormalEdit)
                        this.initEstimate();
                    break;
                case "3":
                    this.tbQuestionEssay.Text = this.tbQuestion.Text;
                    this.showEssayTab();
                    break;
                default:
                    ExtMessage.Show("请选择考题类型！");
                    break;
            }
            #endregion
        }
        /// <summary>
        /// 返回到问题内容界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backToQuestionContent(object sender
            , RoutedEventArgs e)
        {
            #region
            this.tpQuestion.SelectedIndex = 0;
            #endregion
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeForm(object sender
            , RoutedEventArgs e)
        {
            #region
            this.Close();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        private void initEstimate()
        {
            #region
            this.tbQuestionEstimate.Text = this.tbQuestion.Text;
            int totalcount = 0;
            ExamAnswerEstimateBusiness answerestimatebusiness = 
                new ExamAnswerEstimateBusiness();
            _entityAnswerEstimate = new EntityExamAnswerEstimate();
            _entityAnswerEstimate.questionId = QuestionRow[ExamQuestionData.questionId].ToString();
            this._answerEstimateData = answerestimatebusiness.GetData(_entityAnswerEstimate, null, out totalcount);

            if (totalcount == 1)
            {
                this.cbAnswerEstimate.IsChecked = Convert
                    .ToBoolean(this._answerEstimateData.Tables[0]
                    .Rows[0][ExamAnswerEstimateData.answer]);
            }
            else
                ExtMessage.Show("数据错误，请将此项数据进行删除！");
            #endregion
        }
        /// <summary>
        /// 初始化UI
        /// </summary>
        public void InitUI()
        {
            #region
            OtherController.BindCBQuestionType(this.cbQuestiontype);
            OtherController.BindCBQuestionScope(this.cbQuestionScope);

            if (this._frmState != ExamQuestionState.NormalAdd)
            { 
                this.tbQuestion.Text = this.QuestionRow[ExamQuestionData.questionName].ToString();
                this.cbQuestiontype.SelectedValue = this.QuestionRow[ExamQuestionData.questionTypeId];
                this.cbQuestionScope.SelectedValue = this.QuestionRow[ExamQuestionData.questionScopeId];
            }
            switch (this._frmState)
            { 
                case ExamQuestionState.NormalAdd:
                    this.showFirstTab();
                    break;
                case ExamQuestionState.NormalEdit:
                    this.cbQuestiontype.IsEnabled = false;
                    this.showFirstTab();
                    break;
                case ExamQuestionState.DirectEditEssay:
                    this.showEssayTab();
                    break;
                case ExamQuestionState.DirectEditEstimate:
                    
                    this.showEstimateTab();
                    break;
                case ExamQuestionState.DirectEditSelect:
                    this.tbQuestionSelect.Text = this.tbQuestion.Text;
                    this.showSelectTab();
                    break;
                default:
                    break;
            }
            #endregion
        }
        /// <summary>
        /// 保存考题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveQuestion(object sender
            , RoutedEventArgs e)
        {
            #region
            switch (questiontype)
            {
                case "2":
                    if (_frmState == ExamQuestionState.NormalAdd)
                        addEstimateQuestion();
                    else
                        updateEstimateQuestion();
                    break;
                default:
                    break;
            }
            ExtMessage.Show("已成功提交考题！");
            this.Close();
            #endregion
        }
        /// <summary>
        /// 新增保存
        /// </summary>
        private void addEstimateQuestion()
        {
            #region
            EntityExamQuestion entityquestion = new EntityExamQuestion();
            entityquestion.questionName = this.tbQuestion.Text;
            entityquestion.questionScopeId = this.cbQuestionScope.SelectedValue.ToString();
            entityquestion.questionTypeId = this.cbQuestiontype.SelectedValue.ToString();
            entityquestion.usable = "true";
            entityquestion.writeTime = TimeManager.CurrentDBServerTime.ToString();

            this._entityAnswerEstimate = new EntityExamAnswerEstimate();
            this._entityAnswerEstimate.answer = this.cbAnswerEstimate.IsChecked.ToString();
            this._entityAnswerEstimate.writeTime = TimeManager.CurrentDBServerTime.ToString();

            ExamAnswerEstimateData answerestimatedata = new ExamAnswerEstimateData();
            ExamQuestionBusiness questionbusiness = new ExamQuestionBusiness();

            questionbusiness.AddEstimateQuestion(
                ref QuestionController.QuestionData, entityquestion,
                ref answerestimatedata, this._entityAnswerEstimate);
            #endregion
        }
        /// <summary>
        /// 新增保存
        /// </summary>
        private void updateEstimateQuestion()
        {
            #region
            this.QuestionRow[ExamQuestionData.questionName] = this.tbQuestion.Text;
            this.QuestionRow[ExamQuestionData.questionScopeId] = this.cbQuestionScope.SelectedValue.ToString();

            this._answerEstimateData.Tables[0].Rows[0][ExamAnswerEstimateData.answer] = this.cbAnswerEstimate.IsChecked;

            ExamQuestionBusiness questionbusiness = new ExamQuestionBusiness();

            questionbusiness.EditEstimateQuestion(
                ref QuestionController.QuestionData,
                ref this._answerEstimateData);
            #endregion
        }
    }
}
