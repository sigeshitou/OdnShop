using System;
using System.Web.UI;

using OdnShop.Core.Common;
using OdnShop.Core.Factory;
using OdnShop.Core.Model;
using OdnShop.Core.Business;
namespace OdnShop.Web.backend
{
    public partial class memberedit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Security.CheckAdministerAndRedirect();
            if (!Page.IsPostBack)
            {
                if (this.Action == "edit")
                {
                    int adminid = HYRequest.GetQueryInt("adminid", 0);
                    AdminModel info = AdminFactory.Get(adminid);

                    this.txtusername.Text = info.username;
                    this.txtusername.Enabled = false;
                }
            }
        }

        private string Action
        {
            get
            {
                return HYRequest.GetQueryString("action");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Action == "edit")
            {
                int adminid = HYRequest.GetQueryInt("adminid", 0);
                AdminModel info = AdminFactory.Get(adminid);
                if (info != null)
                {
                    string pwdstr = this.txtpassword.Text.Trim();
                    if (!string.IsNullOrEmpty(pwdstr))
                    {
                        info.userpwd = Utils.MD5(pwdstr);
                    }

                    AdminFactory.Update(info);
                    Response.Redirect("adminlist.aspx");
                }
            }
            else if (this.Action == "add")
            {
                //验证是否存在同名的帐号
                AdminModel info = null;
                string username = this.txtusername.Text.Trim();
                info = AdminFactory.Get(username);
                if (info != null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "AddEditTips", "<script language=\"javascript\">alert('已存在相同的帐号！');window.location='adminedit.aspx?action=add';</script>");
                    return;
                }

                info = new AdminModel();
                info.username = this.txtusername.Text.Trim();
                info.userpwd = Utils.MD5(this.txtpassword.Text.Trim());

                AdminFactory.Add(info);

                Response.Redirect("adminlist.aspx");
            }
        }
    }
}
