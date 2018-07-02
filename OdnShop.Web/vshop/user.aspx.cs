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
                nickname = userInfo.nickname;
                //usertypedesc = userInfo.usertypedesc;
                userId = userInfo.uid.ToString();
                userJf = userInfo.jfnum.ToString();

                if (userInfo.headpicurl != string.Empty)
                {
                    headerpic = string.Format("<img src='{0}' />", userInfo.headpicurl);
                }
            }
        }

        public string nickname { get; set; }
        public string usertypedesc { get; set; }
        public string userId { get; set; }
        public string userJf { get; set; }
        public string headerpic { get; set; }

    }
}