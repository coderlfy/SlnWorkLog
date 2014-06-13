using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHWorkLog.server.handler
{
    public enum UploadFileType { 
        jpg,
        doc,
        docx,
        xls,
        xlsx
    }
    public class UploadFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filetype"></param>
        /// <returns></returns>
        private static string getFileType(UploadFileType filetype)
        {
            #region
            string strfiletype = "";
            switch (filetype)
            {
                case UploadFileType.doc:
                    strfiletype = "doc";
                    break;
                case UploadFileType.jpg:
                    strfiletype = "jpg";
                    break;
                case UploadFileType.docx:
                    strfiletype = "docx";
                    break;
                case UploadFileType.xls:
                    strfiletype = "xls";
                    break;
                case UploadFileType.xlsx:
                    strfiletype = "xlsx";
                    break;
                default:
                    break;
            }
            return strfiletype;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="saveFolderName"></param>
        /// <param name="filetype"></param>
        /// <param name="photoRelativeSrc"></param>
        public static void Save(HttpContext context,string saveFolderName, 
            UploadFileType filetype, ref object photoRelativeSrc)
        {
            #region
            HttpPostedFile file;
            if (context.Request.Files.Count > 0)
            {
                file = context.Request.Files[0];
                if (file.ContentLength > 0)
                {
                    Guid imagesfilename = Guid.NewGuid();
                    string orginalpath = string.Format("server\\uploadfiles\\{0}",saveFolderName);
                    string dirrelative = "~/" + orginalpath;

                    string filestorepath = context.Server.MapPath(string.Format("{1}\\{0}.{2}", imagesfilename, dirrelative, getFileType(filetype)));
                    photoRelativeSrc = string.Format("{1}\\{0}.{2}", imagesfilename, orginalpath, getFileType(filetype));
                    //可将大图转成像素合适的小图？？
                    file.SaveAs(filestorepath);
                }
            }
            #endregion
        }
    }
}