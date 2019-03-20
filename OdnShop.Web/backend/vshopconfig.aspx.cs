using System;
using System.Web.UI;

using OdnShop.Core.Common;
using OdnShop.Core.Business;
using OdnShop.Core.Model;
namespace OdnShop.Web.backend
{
    public partial class vshopconfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Security.CheckAdministerAndRedirect();
            if (!Page.IsPostBack)
            {
                VShopConfig vs = VShopConfigHelper.Get();

                this.txtShopName.Text = vs.ShopName;
                this.txtShopAddress.Text = vs.ShopAddress;
                this.txtShopTel.Text = vs.ShopTel;
                this.txtMoneyToJfRate.Text = vs.MoneyToJfRate.ToString();
                this.txtShopLogo.Text = vs.ShopLogo;

                this.txtPostAge.Text = vs.PostAge.ToString();
                this.txtFreePostAge.Text = vs.FreePostAge.ToString();

                this.txtHomeCommendProductCount.Text = vs.HomeCommendProductCount.ToString();
                this.txtHomeLatestProductCount.Text = vs.HomeLatestProductCount.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            VShopConfig vs = VShopConfigHelper.Get();

            vs.ShopName = this.txtShopName.Text.Trim();
            vs.ShopAddress = this.txtShopAddress.Text.Trim();
            vs.ShopTel = this.txtShopTel.Text.Trim();
            vs.MoneyToJfRate = Int32.Parse(this.txtMoneyToJfRate.Text.Trim());
            vs.ShopLogo = this.txtShopLogo.Text.Trim();

            vs.HomeCommendProductCount = Int32.Parse(this.txtHomeCommendProductCount.Text.Trim());
            vs.HomeLatestProductCount = Int32.Parse(this.txtHomeLatestProductCount.Text.Trim());

            vs.PostAge = Decimal.Parse(this.txtPostAge.Text.Trim());
            vs.FreePostAge = Decimal.Parse(this.txtFreePostAge.Text.Trim());

            VShopConfigHelper.Save(vs);

            ClientScript.RegisterStartupScript(this.GetType(), "AddEditTips", "<script language=\"javascript\">alert('配置信息修改成功！');window.location='vshopconfig.aspx';</script>");
        }
    }
}