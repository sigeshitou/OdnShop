using System;
using System.Collections.Generic;

using OdnShop.Core.Model;
namespace OdnShop.Web.vshop
{
    public partial class productcategory : OdnShop.Core.PageControler.WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void AddProductToList(List<ProductModel> list , List<ProductModel> addlist)
        {
            foreach (ProductModel pm in addlist)
            {
                if (list.Contains(pm)) continue;

                list.Add(pm);
            }
        }
    }
}