/****************************************
###创建人：lify
###创建时间：2012-10-29
###公司：山西ICat Studio有限公司
###摘要：主要针对未归类的全局数据源管理。
****************************************/
using ExamBusiness;
using ExamDataLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ExamSystemConfig
{
    class OtherController
    {
        /// <summary>
        /// 问题领域
        /// </summary>
        public static ExamQuestionScopeData QuestionScopeData = null;
        /// <summary>
        /// 问题类型
        /// </summary>
        public static ExamQuestionTypeData QusestionTypeData = null;
        /// <summary>
        /// 初始化访问数据
        /// </summary>
        public static void InitDB()
        {
            #region
            int totalcount = 0;
            ExamQuestionTypeBusiness questiontype = new ExamQuestionTypeBusiness();
            EntityExamQuestionType entityquestiontype = new EntityExamQuestionType();
            ExamQuestionScopeBusiness questionscope = new ExamQuestionScopeBusiness();
            EntityExamQuestionScope entityquestionscope = new EntityExamQuestionScope();

            QusestionTypeData = questiontype.GetData(entityquestiontype, null, out totalcount);
            QuestionScopeData = questionscope.GetData(entityquestionscope, null, out totalcount);
            #endregion
        }
        /// <summary>
        /// 绑定试题类型下拉框
        /// </summary>
        /// <param name="cbQuestionType"></param>
        public static void BindCBQuestionType(ComboBox cbQuestionType)
        {
            #region
            utiBindCombobox(cbQuestionType, QusestionTypeData.Tables[0],
                ExamQuestionTypeData.questionTypeName, ExamQuestionTypeData.questionTypeId);
            #endregion
        }
        /// <summary>
        /// 绑定试题领域下拉框
        /// </summary>
        /// <param name="cbQuestionScope"></param>
        public static void BindCBQuestionScope(ComboBox cbQuestionScope)
        {
            #region
            utiBindCombobox(cbQuestionScope, QuestionScopeData.Tables[0],
    ExamQuestionScopeData.questionScopeName, ExamQuestionScopeData.questionScopeId);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="dt"></param>
        /// <param name="displayName"></param>
        /// <param name="valueName"></param>
        private static void utiBindCombobox(ComboBox cmb, 
            DataTable dt, string displayName, 
            string valueName)
        { 
            #region

            insert0Select(dt, displayName, valueName);

            cmb.ItemsSource = dt.DefaultView;
            cmb.DisplayMemberPath = displayName;
            cmb.SelectedValuePath = "idstring";

            cmb.SelectedIndex = 0;

            #endregion
        }
        /// <summary>
        /// 插入“请选择”
        /// </summary>
        /// <param name="cmb"></param>
        private static void insert0Select(DataTable dt, 
            string displayName, string valueName)
        {
            #region
            if (dt.Columns["idstring"] == null)
            {
                dt.Columns.Add("idstring", typeof(System.String));
                for (int i = 0; i < dt.Rows.Count; i++)
                    dt.Rows[i]["idstring"] = dt.Rows[i][valueName];

                DataRow dr = dt.NewRow();
                dr[displayName] = "请选择";
                dr[valueName] = "0";
                dr["idstring"] = "";

                dt.Rows.InsertAt(dr, 0);
            }
            #endregion
        }
    }
}
