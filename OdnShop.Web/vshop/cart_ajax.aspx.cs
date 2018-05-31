using System;
using System.Collections.Generic;
using System.Web.UI;

using OdnShop.Core.Model;
using OdnShop.Core.Factory;
using OdnShop.Core.Common;
namespace OdnShop.Web.vshop
{
    public partial class cart_ajax : OdnShop.Core.PageControler.WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string action = HYRequest.GetQueryString("action");

                UserModel userInfo = this.LoginUser;
                OrderModel myorder = OrderFactory.GetCartOrder(userInfo.uid);

                

                if (action == "addtocart")       //添加到购物车
                {
                    #region ==addtocart==
                    int pid = HYRequest.GetFormInt("pid", 0);
                    int buycount = HYRequest.GetFormInt("buycount", 0);
                    int itemflag = HYRequest.GetFormInt("itemflag",0) ;

                    OrderModel myof = myorder;
                    if (myof == null)
                    {
                        myof = new OrderModel();
                        myof.orderno = Utils.GenerateOutTradeNo(this.LoginUser.uid);
                        myof.uid = userInfo.uid;
                        myof.customername = userInfo.fullname;
                        myof.tel = userInfo.tel;
                        myof.address = userInfo.address;
                    }

                    ProductModel p = ProductFactory.Get(pid);
                    OrderProduct op = new OrderProduct();
                    op.count = buycount;
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

                    string json = "{\"shopcount\":" + myof.productlist.Count + ",\"error\":0}";
                    Response.Write(json);
                    Response.Flush();
                    Response.End();
                    return;
                    #endregion
                }
                else if (action == "addtofav")   //添加到收藏夹
                {
                    #region ==addtofav==
                    int pid = HYRequest.GetFormInt("pid", 0);
                    bool isfav = FavoriteFactory.IsFavorite(this.LoginUser.uid, pid);
                    if (!isfav)
                    {
                        FavoriteModel fm = new FavoriteModel();
                        fm.product = ProductFactory.Get(pid);
                        fm.uid = this.LoginUser.uid;
                        fm.productid = pid;

                        FavoriteFactory.Add(fm);
                    }
                    string json = "{\"favtip\":\"已收藏\",\"error\":0}";
                    Response.Write(json);
                    Response.Flush();
                    Response.End();
                    return;
                    #endregion
                }
                else if (action == "delfav")     //删除收藏夹
                {
                    int fid = HYRequest.GetFormInt("fid", 0);
                    FavoriteFactory.Delete(fid);
                }
            }
        }

        private void CheckIsAdd(List<OrderProduct> list, OrderProduct op)
        {
            bool isadd = true;
            foreach (OrderProduct o in list)
            {
                if (o.productinfo.productid == op.productinfo.productid) 
                {
                    if (op.item == string.Empty || op.item == o.item)  //如果是相同产品，则需要判断是否有属性，无属性，则表示不添加
                    {
                        isadd = false;
                        break;
                    }
                }
            }

            if (isadd)
                list.Add(op);
        }

        private void CheckIsDel(List<OrderProduct> list, ProductModel p)
        {
            OrderProduct op = null;
            foreach (OrderProduct o in list)
            {
                if (o.productinfo.productid == p.productid)
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
                if (o.productinfo.productid == op.productinfo.productid)
                {
                    o.count = op.count;
                    break;
                }
            }
        }

    }
}