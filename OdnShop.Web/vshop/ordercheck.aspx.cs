using System;
using System.Web.UI;

using OdnShop.Core.Model;
using OdnShop.Core.Factory;
using OdnShop.Core.Common;
namespace OdnShop.Web.vshop
{
    public partial class ordercheck : OdnShop.Core.PageControler.WebPageBase
    {
        VShopConfig vsconfig = VShopConfigHelper.Get();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserModel userInfo = this.LoginUser;
                string orderno = HYRequest.GetQueryString("orderno");

                CartOrder = OrderFactory.Get(orderno);

                //需要判断是否选中所有产品，如不是，则新增加一个订单作为购物车，保留未选中的产品；
                if (CartOrder != null && CartOrder.orderstatus == 1) //购物车订单
                {
                    if (!CartOrder.selectallproduct)
                    {
                        OrderModel om = new OrderModel();
                        om.orderstatus = 1;//购物车
                        om.address = userInfo.address; //CartOrder.address;
                        om.createtime = CartOrder.createtime;
                        om.customername = userInfo.fullname; //CartOrder.customername;
                        om.tel = userInfo.tel;
                        om.uid = CartOrder.uid;
                        om.orderno = Utils.GenerateOutTradeNo(CartOrder.uid);

                        foreach (OrderProduct op in CartOrder.productlist)
                        {
                            if (!op.isselected)
                            {
                                om.productlist.Add(op);
                            }
                        }

                        foreach (OrderProduct op in om.productlist)
                        {
                            CartOrder.productlist.Remove(op);
                        }

                        CartOrder.orderstatus = 2; //更新为已下单
                        CartOrder.createtime = DateTime.Now;
                        OrderFactory.Update(CartOrder);

                        OrderFactory.Add(om);
                    }
                }

                //if (CartOrder != null && CartOrder.orderstatus == 1) //购物车订单
                //    OrderFactory.UpdateStatus(2, CartOrder.orderid);//更新为已下单

                this.txtaddress.Value = userInfo.address; //CartOrder.address;
                this.txtcustomername.Value = userInfo.fullname;
                this.txttel.Value = userInfo.tel;
                this.txtordermessage.Value = CartOrder.ordermessage;

                //this.ltlPostAge.Text = vsconfig.PostAge.ToString();
            }
        }

        public OrderModel CartOrder = null;

        protected void lnkBuy_Click(object sender, EventArgs e)
        {
            bool iswxpay = true; //this.payment_2.Checked; //是否微信支付
            string orderno = HYRequest.GetQueryString("orderno");
            UserModel userInfo = this.LoginUser;
            CartOrder = OrderFactory.Get(orderno);
            CartOrder.address = this.txtaddress.Value;
            CartOrder.customername = this.txtcustomername.Value;
            CartOrder.tel = this.txttel.Value;
            CartOrder.shippingdesc = "快递"; //this.shipping_1.Checked ? "市内" : "市外";
            CartOrder.paymentdesc = iswxpay ? "微信支付" : "货到付款";
            CartOrder.ordermessage = this.txtordermessage.Value;
            //CartOrder.ordersysdesc = userInfo.usertypedesc;
            CartOrder.orderpostage = CartOrder.postage.ToString() ;

            //如果用户信息不全，则补充完整
            if (string.IsNullOrEmpty(userInfo.fullname) || string.IsNullOrEmpty(userInfo.tel) || string.IsNullOrEmpty(userInfo.address))
            {
                userInfo.fullname = (string.IsNullOrEmpty(userInfo.fullname) ? CartOrder.customername : userInfo.fullname);
                userInfo.tel = (string.IsNullOrEmpty(userInfo.tel) ? CartOrder.tel : userInfo.tel);
                userInfo.address = (string.IsNullOrEmpty(userInfo.address) ? CartOrder.address : userInfo.address);

                UserFactory.Update(userInfo);
            }

            if (iswxpay)
            {
                CartOrder.totalprice = CartOrder.productprice;
                CartOrder.totalyfprice = CartOrder.productprice + CartOrder.postage;
                CartOrder.orderstatus = 3;
                //CartOrder.totalyfprice = getyifuprice(CartOrder.totalprice);

                OrderFactory.Update(CartOrder);

                //前往微信支付JS API接口页面
                string url = "pay/wxpay.aspx?orderno=" + CartOrder.orderno + "&total_fee=" + (CartOrder.totalyfprice * 100).ToString("0");
                Response.Redirect(url);
            }
        }
    }
}