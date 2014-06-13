using Fundation.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBase
{
    public class GeneralBusinesser
    {

        public static bool SessionCheckValid(string sessionUser, ref string json)
        {
            #region
            if (string.IsNullOrEmpty(sessionUser))
            {
                JsonHelper jsonhlp = new JsonHelper();
                jsonhlp.AddObjectToJson("msg", "sessioninvalid");
                jsonhlp.AddObjectToJson("success", "false");
                json = jsonhlp.ToString();
                return false;
            }
            else
                return true;
            #endregion
        }

        protected string GetJson(DataSet businessData, int totalCount)
        {
            #region
            JsonHelper jsonhlp = new JsonHelper();
            jsonhlp.GetTopicsJson(businessData.Tables[0]);
            jsonhlp.AddObjectToJson("total", totalCount.ToString());
            jsonhlp.AddObjectToJson("success", "true");
            return jsonhlp.ToString();
            #endregion
        }

        protected String Save(DataSet data, GeneralAccessor accessor)
        {
            #region
            JsonHelper jsonhlp = new JsonHelper();
            try
            {
                accessor.SaveSingleT(data);
                jsonhlp.AddObjectToJson("success", "true");
            }
            catch (Exception e)
            {
                jsonhlp.AddObjectToJson("success", "false");
                jsonhlp.AddObjectToJson("msg", e.Message);
            }
            return jsonhlp.ToString();
            #endregion
        }

        /// <summary>
        /// 保存发布信息到Json
        /// </summary>
        /// <param name="data">数据集</param>
        /// <param name="accessor"></param>
        /// <returns></returns>
        protected String SaveRelease(DataSet data, GeneralAccessor accessor)
        {
            #region
            JsonHelper jsonhlp = new JsonHelper();
            try
            {
                accessor.SaveSingleT(data);
                jsonhlp.GetTopicsJson(data.Tables[0]);
                jsonhlp.AddObjectToJson("success", "true");
                if (data.Tables[0].Rows.Count > 0)
                    jsonhlp.AddObjectToJson("exit", "false");
                else
                    jsonhlp.AddObjectToJson("exit", "true");
            }
            catch (Exception e)
            {
                jsonhlp.AddObjectToJson("success", "false");
                jsonhlp.AddObjectToJson("msg", e.Message);
            }
            return jsonhlp.ToString();
            #endregion
        }


        protected string ConvertToBool(object dbvalue)
        {
            #region
            return (dbvalue == System.DBNull.Value) ? "null" : Convert.ToBoolean(dbvalue).ToString().ToLower();
            #endregion
        }
        /*
        protected string escape(string s)
        {
            StringBuilder sb = new StringBuilder();
            byte[] ba = System.Text.Encoding.Unicode.GetBytes(s);
            for (int i = 0; i < ba.Length; i += 2)
            {
                sb.Append("%u");
                sb.Append(ba[i + 1].ToString("X2"));

                sb.Append(ba[i].ToString("X2"));
            }
            return sb.ToString();
        }
        */
    }
}
