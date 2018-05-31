using System;
using System.Collections.Generic;
using System.Web.UI;

using OdnShop.Core.Model;
using OdnShop.Core.Factory;
using OdnShop.Core.Common;
namespace OdnShop.Web.vshop
{
    public partial class cart : OdnShop.Core.PageControler.WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserModel userInfo = this.LoginUser;
                OrderModel myorder = OrderFactory.GetCartOrder(userInfo.uid);

                int pid = HYRequest.GetQueryInt("pid", 0);
                int itemflag = HYRequest.GetQueryInt("itemflag", 0);
                string action = HYRequest.GetQueryString("action");

                if (action == "add") //添加商品
                {
                    OrderModel myof = myorder;
                    if (myof == null)
                    {
                        myof = new OrderModel();
                        myof.orderno = Utils.GenerateOutTradeNo(userInfo.uid); //Utils.GetRandomOrderNo();
                        myof.uid = userInfo.uid;
                        myof.customername = userInfo.fullname;
                        myof.tel = userInfo.tel;
                        myof.address = userInfo.address;
                    }

                    ProductModel p = ProductFactory.Get(pid);
                    OrderProduct op = new OrderProduct();
                    op.count = 1;
                    op.productinfo = p;
                    op.price = p.price;

                    //判断是否有属性
                    if (itemflag > 0)
                    {
                        int tmpflag = 1;
                        foreach (KeyValuePair<string, decimal> kvp in p.itempricelist)
                        {
                            if (itemflag == tmpflag)
                            {
                                op.item = kvp.Key;
                                op.price = kvp.Value;
                                break;
                            }
                            tmpflag++;
                        }
                    }

                    CheckIsAdd(myof.productlist, op);

                    if (myorder == null)
                        OrderFactory.Add(myof);
                    else
                        OrderFactory.Update(myof);

                    Response.Redirect("cart.aspx");
                }
                else if (action == "del")
                {
                    OrderModel myof = myorder;
                    ProductModel p = ProductFactory.Get(pid);

                    OrderProduct op = new OrderProduct();
                    op.productinfo = p;
                    op.item = HYRequest.GetQueryString("item");

                    CheckIsDel(myof.productlist, op);

                    OrderFactory.Update(myof);
                    Response.Redirect("cart.aspx");
                }
                else if (action == "ajaxupdate")   //更新数量
                {
                    int goods_selected = HYRequest.GetInt("goods_selected", 1);
                    int goods_number = HYRequest.GetInt("goods_number", 1);
                    int rec_id = HYRequest.GetInt("rec_id", 0);
                    string item = HYRequest.GetString("item");

                    OrderModel myof = myorder;
                    ProductModel p = ProductFactory.Get(rec_id);
                    OrderProduct op = new OrderProduct();
                    op.isselected = (goods_selected == 1) ? true : false;
                    op.count = goods_number;
                    op.item = item;
                    op.productinfo = p;
                    CheckIsUpdate(myof.productlist, op);

                    OrderFactory.Update(myof);

                    string json = "{\"rec_id\":" + rec_id + ",\"goods_number\":" + goods_number + ",\"total_number\":" + myof.productcount + ",\"total_desc\":" + myof.productprice.ToString() + ",\"postage\":" + myof.postage.ToString() + ",\"error\":0}";
                    Response.Write(json);
                    Response.Flush();
                    Response.End();
                    return;
                }
                else if (action == "ajaxupdateall")  //全选状态处理
                {
                    int goods_selected = HYRequest.GetInt("goods_selected", 1);
                    int rec_id = HYRequest.GetInt("rec_id", 0);
                    OrderModel myof = myorder;
                    foreach (OrderProduct o in myof.productlist)
                    {
                        o.isselected = (goods_selected == 1) ? true : false;
                    }

                    OrderFactory.Update(myof);

                    string json = "{\"rec_id\":" + rec_id + ",\"total_number\":" + myof.productcount + ",\"total_desc\":" + myof.productprice.ToString() + ",\"postage\":" + myof.postage.ToString() + ",\"error\":0}";
                    Response.Write(json);
                    Response.Flush();
                    Response.End();
                    return;
                }

                if (myorder != null && myorder.productcount > 0)
                {
                    this.phNoProduct.Visible = false;
                    CartOrder = myorder;
                }
                else
                {
                    this.phNoProduct.Visible = true;
                }
            }
        }

        public OrderModel CartOrder = null;

        private void CheckIsAdd(List<OrderProduct> list, OrderProduct op)
        {
            bool isadd = true;
            foreach (OrderProduct o in list)
            {
                if (o.productinfo.productid == op.productinfo.productid && o.item == op.item)
                {
                    isadd = false;
                    break;
                }
            }

            if (isadd)
                list.Add(op);
        }

        private void CheckIsDel(List<OrderProduct> list, OrderProduct p)
        {
            OrderProduct op = null;
            foreach (OrderProduct o in list)
            {
                //需要ID和属性相同，才认为是同一个订购产品
                if (o.productinfo.productid == p.productinfo.productid && o.item == p.item)
                {
                        op = o;
                        break;
                }
            }

            if (op != null)
                list.Remove(op);
        }

        private void CheckIsUpdate(List<OrderProduct> list, OrderProduct op)
        {
            foreach (OrderProduct o in list)
            {
                if (o.productinfo.productid == op.productinfo.productid && o.item == op.item)
                {
                    o.isselected = op.isselected;
                    o.count = op.count;
                    break;
                }
            }
        }

        private void CheckIsUpdateSelected(List<OrderProduct> list, OrderProduct op)
        {
            foreach (OrderProduct o in list)
            {
                if (o.productinfo.productid == op.productinfo.productid && o.item == op.item)
                {
                    o.isselected = op.isselected;
                    break;
                }
            }
        }
    }
}