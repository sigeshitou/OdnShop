using System;
using System.Collections.Generic;
using System.Web.UI;

using OdnShop.Core.Common;
using OdnShop.Core.Model;
using OdnShop.Core.Factory;
namespace OdnShop.Web.vshop
{
    public partial class search : OdnShop.Core.PageControler.WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int totalcount = 0;
                int pagesize = 10;
                int pageindex = HYRequest.GetQueryInt("p", 1);
                string kw = Utils.SafeCheckSearchKw(HYRequest.GetQueryString("kw"));
                this.SearchKw = kw;
                string whereSql = string.Empty;

                //List<ProductModel> list;
                if (!string.IsNullOrEmpty(kw))
                {
                    whereSql = string.Format(" where productname like '%{0}%' ", kw);
                    searchProducts = ProductFactory.GetList(pagesize, pageindex, whereSql, " order by productid desc ", out totalcount);
                }
                else
                {
                    searchProducts = ProductFactory.GetList(10, string.Empty);
                }

                PagerHtml = Utils.BuildProductListPager(totalcount, pagesize, pageindex, "search.aspx?p={0}&kw=" + kw);
            }
        }

        public List<ProductModel> searchProducts { get; set; }

        private string _searchkw = string.Empty;
        public string SearchKw
        {
            get { return _searchkw; }
            set { _searchkw = value; }
        }

        public string PagerHtml = string.Empty;
    }
}