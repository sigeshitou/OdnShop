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
    public partial class wxpaynotify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ResultNotify resultNotify = new ResultNotify(this);
            //resultNotify.ProcessNotify();

            WxPayResultNotify resultNotify = new WxPayResultNotify(this);
            resultNotify.ProcessNotify();
        }
    }

    public class WxPayResultNotify : Notify
    {
        public WxPayResultNotify(Page page):base(page)
        {
        }

        public override void ProcessNotify()
        {
            WxPayData notifyData = GetNotifyData();

            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                Log.Error(this.GetType().ToString(), "The Pay result is error : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }

            string transaction_id = notifyData.GetValue("transaction_id").ToString();

            //查询订单，判断订单真实性
            if (!QueryOrder(transaction_id))
            {
                //若订单查询失败，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                Log.Error(this.GetType().ToString(), "Order query failure : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }
            //查询订单成功
            else
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");

                string attach = notifyData.GetValue("attach").ToString();
                if (!string.IsNullOrEmpty(attach))
                {
                    OrderFactory.UpdateOrderStatus(attach, 5);//更新订单支付状态

                    //更新产品销量和库存
                    OrderModel orderinfo = OrderFactory.Get(attach);
                    foreach (OrderProduct op in orderinfo.productlist)
                    {
                        ProductFactory.UpdateSalecount(op.productinfo.productid,op.count);
                    }

                    //更新用户积分，按照支付产品总价计算积分，邮费不产生积分
                    VShopConfig shopconfig = VShopConfigHelper.Get();
                    UserFactory.UpdateJf(orderinfo.uid, Int32.Parse(orderinfo.productprice.ToString()) * shopconfig.MoneyToJfRate);
                }

                Log.Info(this.GetType().ToString(), "order query success : " + res.ToXml());
                page.Response.Write(res.ToXml());
                page.Response.End();
            }
        }

        //查询订单
        private bool QueryOrder(string transaction_id)
        {
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res = WxPayApi.OrderQuery(req);
            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}