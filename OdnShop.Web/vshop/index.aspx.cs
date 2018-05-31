using System;
using System.Collections.Generic;
using System.Web.UI;

using OdnShop.Core.Model;
using OdnShop.Core.Factory;
namespace OdnShop.Web.vshop
{
    public partial class index : OdnShop.Core.PageControler.WebPageBase 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<ProductModel> cps = ProductFactory.GetList(6, " where iscommend=1 and productcode=1 ");
                this.rptCommendProducts.DataSource = cps;
                this.rptCommendProducts.DataBind();

                List<ProductModel> lps = ProductFactory.GetList(12, " where productcode=1 ");
                this.rptLatestProducts.DataSource = lps;
                this.rptLatestProducts.DataBind();

                List<ProductModel> addps = new List<ProductModel>();
                foreach (ProductModel pm in cps)
                {
                    addps.Add(pm);
                }

                foreach (ProductModel pm in lps)
                {
                    if (addps.Contains(pm)) continue;

                    addps.Add(pm);
                }

                this.rptAddToCarPopWin.DataSource = addps;
                this.rptAddToCarPopWin.DataBind();
            }
        }
    }
}