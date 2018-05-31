using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WxPayAPI;
using OdnShop.Core.Model;
using OdnShop.Core.Factory;
using OdnShop.Core.Common;
namespace OdnShop.Web.vshop.pay
{
    public partial class wxpay : OdnShop.Core.PageControler.WebPageBase 
    {
        public string wxJsApiParam { get; set; } //H5调起JS API参数
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string openid = Request.QueryString["openid"];
                string orderno = HYRequest.GetQueryString("orderno");
                OrderModel orderinfo = OrderFactory.Get(orderno);

                int total_fee = HYRequest.GetQueryInt("total_fee", 0) ;//单位为分

                //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
                JsApiPay jsApiPay = new JsApiPay(this);

                if (orderinfo != null && orderinfo.productlist.Count > 0)
                {
                    jsApiPay.body_desc = orderinfo.productlist[0].productinfo.productname + "等";
                }
                else
                {
                    jsApiPay.body_desc = shopconfig.ShopName + "购物";
                }

                    //单独测试，先微信登陆一下,整合后，有openid了，就无需重复获取授权了。 
                    //jsApiPay.GetOpenidAndAccessToken();
                jsApiPay.openid = this.LoginUser.openid;

                jsApiPay.total_fee = total_fee;
                jsApiPay.out_trade_no = orderno; //WxPayApi.GenerateOutTradeNo(321);  //此处订单号，整合到系统后，从订单产生开始就确立，无需在支付页面生成

                //JSAPI支付预处理
                try
                {
                    WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult();
                    wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数                    
                    //在页面上显示订单信息
                    //Response.Write("<span style='color:#00CD00;font-size:20px'>订单详情：</span><br/>");
                    //Response.Write("<span style='color:#00CD00;font-size:20px'>" + unifiedOrderResult.ToPrintStr() + "</span>");
                    //Response.Write(string.Format("<span style='color:#00CD00;font-size:20px'>订单号：{0}</span><br/>", orderinfo.orderno));
                    //Response.Write(string.Format("<span style='color:#00CD00;font-size:20px'>支付额：{0}</span><br/>", orderinfo.totalyfprice));

                    System.Text.StringBuilder sbtips = new System.Text.StringBuilder();
                    sbtips.Append("<span style='color:#00CD00;font-size:20px'>订单详情：</span><br/>");
                    sbtips.Append(string.Format("<span style='color:#00CD00;font-size:16px'>订单编号：{0}</span><br/>", orderinfo.orderno));
                    sbtips.Append(string.Format("<span style='color:#00CD00;font-size:16px'>支付总额：{0}</span><br/>", orderinfo.totalyfprice));

                    this.ltlTips.Text = sbtips.ToString();

                }
                catch
                {
                    this.ltlTips.Text = "<span style='color:#FF0000;font-size:20px'>" + "下单失败，请返回重试" + "</span>";
                }


            }
        }
    }
}