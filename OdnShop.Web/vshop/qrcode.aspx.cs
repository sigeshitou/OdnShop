using System;
using System.Web.UI;
using System.Drawing;

using ThoughtWorks.QRCode.Codec;
using OdnShop.Core.Common;
namespace OdnShop.Web.vshop
{
    public partial class qrcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int u = HYRequest.GetQueryInt("u", 0);
                if (u == 0)
                    return;

                string rootUrl = SiteConfig.Instance().SiteDomain;
                if (!rootUrl.EndsWith("/"))
                    rootUrl += "/";

                //string url = rootUrl + "vshop/share.aspx?u=" + u;
                string url = rootUrl + "vshop/index.aspx";

                var qrCodeEncoder = new QRCodeEncoder
                {
                    QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
                    QRCodeScale = 4,
                    QRCodeVersion = 8,
                    QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M
                };
                Bitmap image = qrCodeEncoder.Encode(url);

                //输出到浏览器
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Response.ClearContent();
                Response.ContentType = "image/Jpeg";
                Response.BinaryWrite(ms.ToArray());
                image.Dispose();
            }
        }
    }
}