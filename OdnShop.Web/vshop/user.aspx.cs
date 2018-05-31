using System;
using System.Web.UI;

using OdnShop.Core.Model;
namespace OdnShop.Web.vshop
{
    public partial class user : OdnShop.Core.PageControler.WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserModel userInfo = this.LoginUser;
                this.ltlNickname.Text = userInfo.nickname;
                this.ltlUsertypedesc.Text = userInfo.usertypedesc;
                this.ltlUid.Text = userInfo.uid.ToString();
                this.ltljf.Text = userInfo.jfnum.ToString();

                if (userInfo.headpicurl != string.Empty)
                {
                    this.ltlheaderpic.Text = string.Format("<img src='{0}' />", userInfo.headpicurl);
                }
            }
        }
    }
}