using System;
using System.Collections.Generic;
using System.Web.UI;

using OdnShop.Core.Model;
using OdnShop.Core.Factory;
using OdnShop.Core.Common;
namespace OdnShop.Web.vshop
{
    public partial class user_order : OdnShop.Core.PageControler.WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string action = HYRequest.GetQueryString("action");
                if (action == "cancelorder") //取消订单
                {
                    int orderid = HYRequest.GetQueryInt("orderid", 0);
                    OrderFactory.UpdateStatus(99, orderid);
                    Response.Redirect("user_order.aspx");
                }

                int s = HYRequest.GetQueryInt("s", 0);
                int pageindex = HYRequest.GetQueryInt("p", 1);
                int pagesize = 5;
                int totalcount = 0;
                if (s == 0)
                {
                    OrderList = OrderFactory.GetOrderList(pagesize, pageindex, " where uid=" + this.LoginUser.uid + " and orderstatus>1 ", " order by orderid desc ", out totalcount);
                }
                else if (s == 1) //已下单未付款
                {
                    OrderList = OrderFactory.GetOrderList(pagesize, pageindex, " where uid=" + this.LoginUser.uid + " and (orderstatus=2 or orderstatus=3) ", " order by orderid desc ", out totalcount);
                }
                else if (s == 2) //已付款
                {
                    OrderList = OrderFactory.GetOrderList(pagesize, pageindex, " where uid=" + this.LoginUser.uid + " and orderstatus=5 ", " order by orderid desc ", out totalcount);
                }
            }
        }

        public List<OrderModel> OrderList { get; set; }
    }
}