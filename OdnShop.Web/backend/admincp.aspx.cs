using System;
using System.Collections;
using System.Configuration;
using OdnShop.Core.Business;
namespace OdnShop.Web.backend
{
    public partial class admincp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Security.CheckAdministerAndRedirect();

            LoginMember m = Security.Check();
            if (m != null)
            {
                this.LoginAdminid = m.adminid;
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
