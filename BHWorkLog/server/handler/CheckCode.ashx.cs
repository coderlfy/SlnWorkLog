using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace BHWorkLog.server.handler
{
    /// <summary>
    /// CheckCode 的摘要说明
    /// </summary>
    public class CheckCode : PageHandlerBase, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/gif";
            String allidentifyid = context.Request.QueryString["id"];
            String checkcode = allidentifyid.Substring(2, 6);
            this.CreateCheckCodeImage(context, checkcode);
            context.Response.End();
        }

        private void CreateCheckCodeImage(HttpContext context, string checkCode)
        {
            //将验证码生成图片显示
            int imgwidth = 80, imgheight = 22;
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(imgwidth, imgheight);
            Graphics g = Graphics.FromImage(image);

            try
            {
                //生成随机生成器 
                Random random = new Random();
                //清空图片背景色 
                g.Clear(Color.White);
                //画图片的背景噪音线
                for (int i = 0; i < 8; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255))
                    ), x1, y1, x2, y2);
                }
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                List<FontStyle> a = GetColorList;
                for (int i = 0; i < checkCode.Length; i++)
                {
                    FontStyle Ftyle = GetColor(a);
                    Font font = new System.Drawing.Font("Verdana", Ftyle.FontSize, (System.Drawing.FontStyle.Bold));
                    SolidBrush brush = new SolidBrush(Ftyle.FontColor);
                    g.DrawString(checkCode.Substring(i, 1), font, brush, GetCodeRect(i, imgwidth, imgheight, checkCode.Length), sf);
                }
                //画图片的边框线 
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                context.Response.ClearContent();
                context.Response.ContentType = "image/Gif";
                context.Response.BinaryWrite(ms.ToArray());


            }
            catch
            {
                throw;
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        /// <summary>
        /// 获取颜色列表
        /// </summary>
        private List<FontStyle> GetColorList
        {
            get
            {
                List<FontStyle> a = new List<FontStyle>(6);
                a.Add(new FontStyle(Color.Red, 12));
                a.Add(new FontStyle(Color.Green, 12));
                a.Add(new FontStyle(Color.Blue, 12));
                a.Add(new FontStyle(Color.Black, 12));
                a.Add(new FontStyle(Color.Aqua, 12));
                a.Add(new FontStyle(Color.Tomato, 12));
                return a;
            }
        }
        /// <summary>
        /// 字体类
        /// </summary>
        public class FontStyle
        {
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="FontColor">颜色</param>
            /// <param name="FontSize">字体大小</param>
            public FontStyle(Color FontColor, int FontSize)
            {
                _FontColor = FontColor;
                _FontSize = FontSize;
            }
            #region "Private Variables"
            private Color _FontColor;
            private int _FontSize;
            #endregion

            #region "Public Variables"
            /// <summary>
            /// 字体颜色
            /// </summary>
            public Color FontColor
            {
                get
                {
                    return _FontColor;
                }
                set
                {
                    _FontColor = value;
                }
            }
            /// <summary>
            /// 字体大小
            /// </summary>
            public int FontSize
            {
                get
                {
                    return _FontSize;
                }
                set
                {
                    _FontSize = value;
                }
            }
            #endregion
        }
        /// <summary>
        /// 从颜色列表中随机选取颜色
        /// </summary>
        /// <param name="Color_L"></param>
        /// <returns></returns>
        private FontStyle GetColor(List<FontStyle> Color_L)
        {
            Random rnd = new Random();
            int i = rnd.Next(0, Color_L.Count);
            FontStyle l = Color_L[i];
            Color_L.RemoveAt(i);
            return l;
        }
        /// <summary>
        /// 获取单个字符的绘制区域
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Rectangle GetCodeRect(int index,int imgWidth, int imgHeight, int checkcodelength)
        {
            // 计算一个字符应该分配有多宽的绘制区域（等分为CodeLength份）
            int subWidth = imgWidth / checkcodelength;
            // 计算该字符左边的位置
            int subLeftPosition = subWidth * index;

            return new Rectangle(subLeftPosition + 1, 1, subWidth, imgHeight);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}