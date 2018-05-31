using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using OdnShop.Core.Business;
namespace OdnShop.Web.backend
{
    public partial class admincp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OdnShop.Core.Business.Security.CheckAdministerAndRedirect();

            LoginMember m = OdnShop.Core.Business.Security.Check();
            if (m != null)
            {
                this.LoginAdminid = m.adminid;
                //this.ltlUsername.Text = m.username ;
            }
        }

        private int _loginAdminid = 0;
        public int LoginAdminid
        {
            get { return _loginAdminid; }
            set { _loginAdminid = value; }
        }
    }
}
