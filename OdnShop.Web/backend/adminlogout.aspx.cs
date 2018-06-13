using System;
using System.Web.UI;

using OdnShop.Core.Business;
namespace OdnShop.Web.backend
{
    public partial class adminlogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Security.Logout();

                Response.Redirect("admincp.aspx");
            }
        }
    }
}
