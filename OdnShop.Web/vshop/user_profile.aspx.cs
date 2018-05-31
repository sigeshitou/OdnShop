using System;
using System.Web.UI;

using OdnShop.Core.Model;
using OdnShop.Core.Factory;
namespace OdnShop.Web.vshop
{
    public partial class user_profile : OdnShop.Core.PageControler.WebPageBase
    {
        public static string wxEditAddrParam { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserModel userInfo = this.LoginUser;
                this.userInfo = userInfo;
                //this.nickname.Value = userInfo.nickname;
                this.fullname.Value = userInfo.fullname;
                this.tel.Value = userInfo.tel;
                this.address.Value = userInfo.address;
                if (userInfo.sex == "男")
                {
                    this.radioboy.Checked = true;
                    this.radiogirl.Checked = false;
                }
                else
                {
                    this.radioboy.Checked = false;
                    this.radiogirl.Checked = true;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserModel userInfo = this.LoginUser;
            this.userInfo = userInfo;

            userInfo.fullname = this.fullname.Value;
            userInfo.tel = this.tel.Value;
            userInfo.address = this.address.Value;
            userInfo.sex = this.radioboy.Checked ? "男" : "女";

            UserFactory.Update(userInfo);

            ClientScript.RegisterStartupScript(this.GetType(), "AddEditTips", "<script language=\"javascript\">alert('个人信息修改成功！');window.location='user_profile.aspx';</script>");
        }

        public UserModel userInfo { get; set; }
    }
}