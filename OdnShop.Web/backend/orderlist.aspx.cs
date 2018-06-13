using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using OdnShop.Core.Common;
using OdnShop.Core.Factory;
using OdnShop.Core.Model;
using OdnShop.Core.Business;
namespace OdnShop.Web.backend
{
    public partial class orderlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Security.CheckAdministerAndRedirect();
            if (!Page.IsPostBack)
            {
                  LoadListData();
            }
        }

        private void LoadListData()
        {
            string searchkw = this.txtSearchKeyword.Text.Trim();

            string searchstatus = HYRequest.GetQueryInt("status",5).ToString();

            string whereSql = " where orderstatus=" + searchstatus;

            if (searchkw != string.Empty)
            {
                whereSql += string.Format(" and (customername like '%{0}%' or tel like '%{0}%' or address like '%{0}%')", searchkw);
            }

            this.dgOrderList.DataSource = OrderFactory.GetOrderList(whereSql); //OrderFactory.GetList(whereSql);
            this.dgOrderList.DataBind();
        }

        protected void dgOrderList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "OrderChuhuo")  //已送货
            {
                int dataKey = Convert.ToInt32(this.dgOrderList.DataKeys[e.Item.ItemIndex]);

                OrderModel of = OrderFactory.Get(dataKey);
                if (of.deliverstatus == 1)
                {
                    of.deliverstatus = 2;
                    OrderFactory.Update(of);
                }
                this.LoadListData();
            }
            else if (e.CommandArgument.ToString() == "OrderShouhuo")
            {
                int dataKey = Convert.ToInt32(this.dgOrderList.DataKeys[e.Item.ItemIndex]);

                OrderModel of = OrderFactory.Get(dataKey);
                if (of.deliverstatus == 1 || of.deliverstatus == 2)
                {
                    of.deliverstatus = 3;
                    OrderFactory.Update(of);

                    
                }
                this.LoadListData();
            }
        }

        protected void dgOrderList_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("bgcolor", "#ffffff");
                e.Item.Attributes.Add("onmouseover", @"this.bgColor='#EBFFDC';");
                e.Item.Attributes.Add("onmouseout", @"this.bgColor='#ffffff';");

                ((LinkButton)e.Item.FindControl("lnkShouhuo")).Attributes.Add("onclick", @"javascript:return confirm('提示:你正在确认客户收货．\r\n是否确定？');");
            }
        }

        public string getorderproductlist(object productlist)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            List<OrderProduct> pl = (List<OrderProduct>)productlist;

            foreach (OrderProduct op in pl)
            {
                string item = op.item == string.Empty ? "" : string.Format("属性：{0},",op.item) ;
                sb.Append(op.productinfo.productname + "("+item+"数量：" + op.count + ") <br />");
            }

            return sb.ToString();
        }

        protected void dgOrderList_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgOrderList.CurrentPageIndex = e.NewPageIndex;
            this.LoadListData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.dgOrderList.CurrentPageIndex = 0;
            this.LoadListData();
        }

        public string getzhifuinfo(object obj)
        {
            OrderModel info = obj as OrderModel;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (info.paymentdesc == "微信支付")
            {
                sb.Append("支付方式：" + info.paymentdesc + "<br />");
                sb.Append("产品总额：" + info.totalprice + "<br />");
                sb.Append("快递费用：" + info.orderpostage + "<br />");
                sb.Append("实付总额：" + info.totalyfprice + "(" + info.ordersysdesc + ")<br />");
            }
            else
            {
                sb.Append("支付方式：" + info.paymentdesc + "<br />");
                sb.Append("兑换积分：" + info.totaljifen + "<br />");
                sb.Append("实扣积分：" + info.totalyfjifen + "(" + info.ordersysdesc + ")<br />");
            }

            return sb.ToString();
        }
    }
}