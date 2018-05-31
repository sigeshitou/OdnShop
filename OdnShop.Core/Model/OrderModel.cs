using System;
using System.Collections.Generic;
using System.Text;

using OdnShop.Core.Common;
namespace OdnShop.Core.Model
{
    /// <summary>
    /// 订单类
    /// </summary>
    [Serializable]
    public class OrderModel
    {
        private int _orderid = 0;
        [System.Xml.Serialization.XmlIgnore]
        public int orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        private string _orderno = string.Empty;
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderno
        {
            get { return _orderno; }
            set { _orderno = value; }
        }

        private int _uid = 0;
        public int uid
        {
            get { return _uid; }
            set { _uid = value; }
        }

        private string _customername = string.Empty;
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string customername
        {
            get { return _customername; }
            set { _customername = value; }
        }

        private string _tel = string.Empty;
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        private string _address = string.Empty;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        private int _totaljifen = 0;
        /// <summary>
        /// 兑换总积分
        /// </summary>
        public int totaljifen
        {
            set { _totaljifen = value; }
            get { return _totaljifen; }
        }

        private decimal _totalprice;
        /// <summary>
        /// 产品总价
        /// </summary>
        public decimal totalprice
        {
            get { return _totalprice; }
            set { _totalprice = value; }
        }

        private int _totalyfjifen = 0;
        /// <summary>
        /// 应扣总积分
        /// </summary>
        public int totalyfjifen
        {
            set { _totalyfjifen = value; }
            get { return _totalyfjifen; }
        }

        private decimal _totalyfprice;
        /// <summary>
        /// 应付产品总价
        /// </summary>
        public decimal totalyfprice
        {
            get { return _totalyfprice; }
            set { _totalyfprice = value; }
        }

        private string _ordersysdesc = string.Empty;
        //订单系统的说明，方便后台查看和了解信息
        public string ordersysdesc
        {
            get { return _ordersysdesc; }
            set { _ordersysdesc = value; }
        }

        private int _orderstatus = 1;
        /// <summary>
        /// 订单状态(1,购物车；2已下单；3已下单且等待支付中,5成功下单且确认支付,99表示订单取消)
        /// </summary>
        public int orderstatus
        {
            get { return _orderstatus; }
            set { _orderstatus = value; }
        }

        private int _deliverstatus = 1;
        /// <summary>
        /// 送货状态，1未送货，2已送货，3已收货
        /// </summary>
        public int deliverstatus
        {
            get { return _deliverstatus; }
            set { _deliverstatus = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public string orderstatusdesc
        {
            get
            {
                switch (orderstatus)
                {
                    case 1:
                        return "购物车";
                    case 2:
                        return "未付款";
                    case 3:
                        return "等待支付";
                    case 5:
                        return "已支付";

                    case 99:
                        return "订单取消";

                    default:
                        return "";
                }
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public string deliverstatusdesc
        {
            get
            {
                switch (deliverstatus)
                {
                    case 1:
                        return "未送货";
                    case 2 :
                        return "已送货";
                    case 3 :
                        return "确认收货";

                    default :
                        return "";
                }
            }
        }

        private DateTime _createtime = DateTime.Now;
        /// <summary>
        /// 订单创建时间
        /// </summary>
        public DateTime createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public int productcount
        {
            get
            {
                int count = 0;
                if (this.productlist == null)
                    return count;

                foreach (OrderProduct op in this.productlist)
                {
                    count += op.count;
                }

                return count;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public decimal productprice
        {
            get
            {
                decimal tp = decimal.Zero;
                if (this.productlist == null || this.productlist.Count == 0)
                    return tp;

                foreach (OrderProduct op in this.productlist)
                {
                    if (!op.isselected)
                        continue;

                    tp += (op.count * op.price); 
                }

                return tp;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public decimal postage
        {
            get
            {
                VShopConfig config = VShopConfigHelper.Get();
                if (config.PostAge == decimal.Zero)   //是否免邮
                {
                    return decimal.Zero;
                }
                else if (config.FreePostAge == decimal.Zero)  //如不是，则判断是否有免邮额
                {
                    return config.PostAge;
                }
                else
                {
                    if (productprice >= config.FreePostAge)
                        return decimal.Zero;
                    else
                        return config.PostAge;
                }
            }
        }

        /// <summary>
        /// 是否选中全部产品
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public bool selectallproduct
        {
            get
            {
                if (this.productlist == null)
                    return false;

                foreach (OrderProduct op in this.productlist)
                {
                    if (!op.isselected)
                        return false;
                }

                return true;
            }
        }

        /// <summary>
        /// 是否有选择产品
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public bool hasselectproduct
        {
            get
            {
                if (this.productlist == null)
                    return false;

                foreach (OrderProduct op in this.productlist)
                {
                    if (op.isselected)
                        return true;
                }

                return false;
            }
        }

        //一些订单详细
        public string shippingdesc { get; set; } //配送方式
        public string paymentdesc {get;set ;} //支付方式
        public string ordermessage { get; set; }//订单附言
        public string orderpostage { get; set; } //订单下单后的邮费,用于记录和显示。

        private List<OrderProduct> _productlist=new List<OrderProduct>();
        public List<OrderProduct> productlist
        {
            get { return _productlist; }
            set { _productlist = value; }
        }
    }

    [Serializable]
    public class OrderProduct
    {
        private ProductModel _productinfo;
        public ProductModel productinfo
        {
            get { return _productinfo; }
            set { _productinfo = value; }
        }

        private string _item = string.Empty;
        /// <summary>
        /// 属性名称，如有
        /// </summary>
        public string item
        {
            get { return _item; }
            set { _item = value; }
        }

        private decimal _price = decimal.Zero;
        /// <summary>
        /// 本产品价格
        /// </summary>
        public decimal price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _count;
        public int count
        {
            get { return _count; }
            set { _count = value; }
        }

        private bool _isselected = true;
        /// <summary>
        /// 是否选中,如为false，不参与总价计算，且从购物车转为订单的时候。
        /// </summary>
        public bool isselected
        {
            get { return _isselected; }
            set { _isselected = value; }
        }
    }
}
