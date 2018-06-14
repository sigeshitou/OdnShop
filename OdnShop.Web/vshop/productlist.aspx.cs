using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Text;

using OdnShop.Core.Common;
using OdnShop.Core.Model;
using OdnShop.Core.Factory;
namespace OdnShop.Web.vshop
{
    public partial class productlist : OdnShop.Core.PageControler.WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int totalcount = 0;
                int pagesize = 12;
                int cid = HYRequest.GetQueryInt("cid", 0);
                int pageindex = HYRequest.GetQueryInt("p", 1);
                int od = HYRequest.GetQueryInt("od", 0);
                string whereSql = " where productcode=1 ";

                string orderby = " order by productid desc ";
                string url = "productlist.aspx?p={0}";


                if (cid > 0)
                {
                    whereSql = " where productcode=1 and categoryid=" + cid;
                    url += "&cid=" + cid;
                }

                if (od == 1)
                {
                    orderby = " order by salecount desc ";
                }
                else if (od == 2)
                {
                    orderby = " order by price desc ";
                }

                listProducts = ProductFactory.GetList(pagesize, pageindex, whereSql, orderby, out totalcount);

                //this.rptProducts.DataSource = list;
                //this.rptProducts.DataBind();

                //this.rptAddToCarPopWin.DataSource = list; 
                //this.rptAddToCarPopWin.DataBind();

                pagerHtml = Utils.BuildProductListPager(totalcount, pagesize, pageindex, url);

                if (cid == 0)
                    this.CategoryName = "全部商品";
                else
                {
                    ProductCategoryModel pcm = ProductCategoryFactory.Get(cid);
                    if (pcm != null)
                        this.CategoryName = pcm.categoryname;
                }
            }

            string action = HYRequest.GetQueryString("action");
            if (action == "ajaxloadlist")
            {
                int cid = HYRequest.GetInt("cid", 0);
                int pageindex = HYRequest.GetInt("p", 1);
                int pagesize = 12;
                int totalcount = 0;

                string wheresql = " where productcode=1 ";
                if (cid > 0)
                    wheresql = string.Format(" where productcode=1 and categoryid={0} ",cid.ToString());

                List<ProductModel> list = ProductFactory.GetList(pagesize, pageindex, wheresql, string.Empty, out totalcount);
                StringBuilder sbhtml = new StringBuilder();
                foreach (ProductModel pm in list)
                {
                    sbhtml.AppendLine("<li class=\"item\">");
                    sbhtml.AppendLine(string.Format("<a href=\"productshow.aspx?id={0}\"><img src=\"{1}\" alt=\"item\" /></a>",pm.productid,pm.includepicpath));
                    sbhtml.AppendLine(string.Format("<h4><a href=\"productshow.aspx?id={0}\">{1}</a></h4>",pm.productid,pm.productname));
                    sbhtml.AppendLine(string.Format("<span>&yen;{0}</span><del style=\"display:none\">&yen;{0}</del><em>库存：{1} &nbsp; 销量：{2}</em>",pm.price.ToString(),pm.productcount,pm.salecount));
                    sbhtml.AppendLine(string.Format("<p class=\"add-to-cart\" onClick=\"toshare({0})\"><span>添加到购物车</span></p>", pm.productid));

                    sbhtml.AppendLine("</li>");
               }
                Response.Write(sbhtml.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public List<ProductModel> listProducts { get; set; }
        public string pagerHtml { get; set; }

        public int CagetoryId
        {
            get { return HYRequest.GetQueryInt("cid", 0); }
        }

        public string CategoryName { get; set; }
    }
}