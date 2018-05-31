using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using System.Web;

namespace OdnShop.Core.PageControler
{
    /// <summary>
    /// 验证码图片页面类
    /// </summary>
    public class VerifyImagePage : System.Web.UI.Page
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);

            string checkCode = CreateRandomCode(4).ToUpper();
            HttpContext.Current.Session["verifycode"] = checkCode.ToLower();
            CreateImage(checkCode, HttpContext.Current);
        }

        //产生字母数字随机串
        private string CreateRandomCode(int codeCount)
        {
            #region ==CreateRandomCode==
            //验证码中的出现的字符，避免了一些容易混淆的字符。
            string allChar = "3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,K,M,N,P,Q,R,S,T,U,W,X,Y";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(allCharArray.Length);
                if (temp == t)
                {
                    return CreateRandomCode(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }

            return randomCode;
            #endregion
        }

        /// <summary>
        /// 创建图片
        /// </summary>
        /// <param name="checkCode"></param>
        /// <param name="context"></param>
        private void CreateImage(string checkCode, HttpContext context)
        {
            #region ==CreateImage==
            int iwidth = (int)(checkCode.Length * 12);
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 20);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.Clear(System.Drawing.Color.White);
            //定义颜色
            System.Drawing.Color[] c = { System.Drawing.Color.DimGray, System.Drawing.Color.DimGray, System.Drawing.Color.DimGray };
            //定义字体            
            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
            Random rand = new Random();
            //随机输出噪点
            for (int i = 0; i < 50; i++)
            {
                int x = rand.Next(image.Width);
                int y = rand.Next(image.Height);
                g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.LightGray, 0), x, y, 1, 1);
            }

            //输出不同字体和颜色的验证码字符

            for (int i = 0; i < checkCode.Length; i++)
            {
                int cindex = rand.Next(3);
                int findex = rand.Next(1);

                System.Drawing.Font f = new System.Drawing.Font(font[findex], 10, System.Drawing.FontStyle.Bold);
                System.Drawing.Brush b = new System.Drawing.SolidBrush(c[cindex]);
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * 10), ii);
            }
            //画一个边框

            g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.DarkGray, 0), 0, 0, image.Width - 1, image.Height - 1);

            //输出到浏览器
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            context.Response.ClearContent();
            context.Response.ContentType = "image/Jpeg";
            context.Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            image.Dispose();
            #endregion
        }
    }
}
