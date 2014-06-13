using ExamBusiness;
using ExamDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ExamSystemConfig
{
    class QuestionController
    {
        public static ExamQuestionData QuestionData = null;
        public static EntityExamQuestion EntityQuestion = new EntityExamQuestion();

        public static void InitDB()
        {
            int totalcount = 0;
            ExamQuestionBusiness question = new ExamQuestionBusiness();

            QuestionData = question.GetData(EntityQuestion, null, out totalcount);

        }

        public static void BindDgQuestion(DataGrid dgQuestion)
        {
            if (QuestionData!=null)
                dgQuestion.ItemsSource = QuestionData.Tables[0].DefaultView;
        }
    }
}
