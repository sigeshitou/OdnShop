using System;
using System.Web.UI;

using OdnShop.Core.Common;
using OdnShop.Core.Model;
using OdnShop.Core.Factory;
namespace OdnShop.Web.vshop
{
    public partial class productshow : OdnShop.Core.PageControler.WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = HYRequest.GetQueryInt("id", 0);
                if (id == 0)
                    Response.Redirect("index.aspx");

                this.productinfo = ProductFactory.Get(id);


            }
        }

        private ProductModel _productinfo = null;
        public ProductModel productinfo
        {
            get { return _productinfo; }
            set { _productinfo = value; }
        }

        public bool IsFav
        {
            get
            {
                int id = HYRequest.GetQueryInt("id", 0);
                return FavoriteFactory.IsFavorite(this.LoginUser.uid, id);
            }
        }
    }
}