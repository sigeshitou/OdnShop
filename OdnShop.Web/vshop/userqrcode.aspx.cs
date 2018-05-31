using System;
using System.Web.UI;

namespace OdnShop.Web.vshop
{
    public partial class userqrcode : OdnShop.Core.PageControler.WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.imQrCode.ImageUrl = "qrcode.aspx?u=" + this.LoginUser.uid;
            }
        }
    }
}