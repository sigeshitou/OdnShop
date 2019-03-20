using System;
using System.Collections.Generic;
using System.Web.UI;

using OdnShop.Core.Model;
using OdnShop.Core.Factory;
namespace OdnShop.Web.vshop
{
    public partial class index : OdnShop.Core.PageControler.WebPageBase 
    {
        public List<ProductModel> commendProducts = new List<ProductModel>();
        public List<ProductModel> latestProducts = new List<ProductModel>();
        public List<ProductModel> addCarPopWinProducts = new List<ProductModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                commendProducts = ProductFactory.GetList(shopconfig.HomeCommendProductCount, " where iscommend=1 and productcode=1 ");
                latestProducts = ProductFactory.GetList(shopconfig.HomeLatestProductCount, " where productcode=1 ");

                foreach (ProductModel pm in commendProducts)
                {
                    addCarPopWinProducts.Add(pm);
                }

                foreach (ProductModel pm in latestProducts)
                {
                    if (addCarPopWinProducts.Contains(pm)) continue;

                    addCarPopWinProducts.Add(pm);
                }
            }
        }
    }
}