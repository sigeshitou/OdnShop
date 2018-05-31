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

using OdnShop.Core;
using OdnShop.Core.Business;
namespace OdnShop.Web.backend
{
    public partial class adminlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = this.txtusername.Text.Trim();
            string password = this.txtpassword.Text.Trim();

            string logintips = string.Empty;
            if (Security.Login(username, password, out logintips))
            {
                Response.Redirect("admincp.aspx");

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "RegisterTips", "<script language=\"javascript\">alert('" + logintips + "');window.location='adminlogin.aspx';</script>");
            }
        }

    }
}
