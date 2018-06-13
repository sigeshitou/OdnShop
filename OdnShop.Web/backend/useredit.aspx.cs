using System;
using System.Web.UI;

using OdnShop.Core.Common;
using OdnShop.Core.Factory;
using OdnShop.Core.Model;
using OdnShop.Core.Business;
namespace OdnShop.Web.backend
{
    public partial class useredit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Security.CheckAdministerAndRedirect();
            if (!Page.IsPostBack)
            {
                if (this.Action == "edit")
                {
                    int uid = HYRequest.GetQueryInt("uid", 0);
                    UserModel u = UserFactory.Get(uid);

                    this.ltlUid.Text = uid.ToString();
                    this.txtnickname.Text = u.nickname;
                    this.txtfullname.Text = u.fullname;
                    this.txtsex.Text = u.sex;
                    this.txttel.Text = u.tel;
                    this.txtaddress.Text = u.address;
                    this.txtjfnum.Text = u.jfnum.ToString();

                    this.rblusertype.Items.FindByValue(u.usertype.ToString()).Selected = true;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Action == "edit")
            {
                int uid = HYRequest.GetQueryInt("uid", 0);
                UserModel u = UserFactory.Get(uid);

                u.nickname = this.txtnickname.Text;
                u.fullname = this.txtfullname.Text;
                u.sex = this.txtsex.Text;
                u.tel = this.txttel.Text;
                u.address = this.txtaddress.Text;
                u.jfnum = Int32.Parse( this.txtjfnum.Text.Trim() ) ;
                u.usertype = Int32.Parse( this.rblusertype.SelectedValue );

                UserFactory.Update(u);

                ClientScript.RegisterStartupScript(this.GetType(), "AddEditTips", "<script language=\"javascript\">alert('用户信息修改成功！');window.location='userlist.aspx';</script>");
            }
        }

        private string Action
        {
            get
            {
                return HYRequest.GetQueryString("action");
            }
        }
    }
}