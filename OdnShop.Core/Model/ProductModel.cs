using System;
using System.Collections.Generic;
using System.Text;

namespace OdnShop.Core.Model
{
    /// <summary>
    /// 产品
    /// </summary>
     [Serializable]
    public class ProductModel
    {
        private int _productid = 0 ;
        public int productid
        {
            set { _productid = value; }
            get { return _productid; }
        }

        private string _productname = string.Empty ;
        /// <summary>
        /// 产品名称
        /// </summary>
        public string productname
        {
            set { _productname = value; }
            get { return _productname; }
        }

        private string _includepicpath = string.Empty;
        /// <summary>
        /// 缩略图(封面图),单张
        /// </summary>
        public string includepicpath
        {
            set { _includepicpath = value; }
            get { return _includepicpath; }
        }

        private string _productpics = string.Empty;
         /// <summary>
         /// 产品图地址，多张用|分割
         /// </summary>
        public string productpics
        {
            get { return _productpics; }
            set { _productpics = value; }
        }

        private int _productcode = 1;
        /// <summary>
        /// 产品状态(0未上架，1为已上架)
        /// </summary>
        public int productcode
        {
            set { _productcode = value; }
            get { return _productcode; }
        }

        private string _description = string.Empty;
        /// <summary>
        /// 商品简要
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }

        private string _specification = string.Empty;
        /// <summary>
        /// 商品详情
        /// </summary>
        public string specification
        {
            set { _specification = value; }
            get { return _specification; }
        }

        private int _salecount = 0;
        /// <summary>
        /// 销售数量
        /// </summary>
        public int salecount
        {
            set { _salecount = value; }
            get { return _salecount; }
        }

        private int _productcount = 0;
        /// <summary>
        /// 库存数量
        /// </summary>
        public int productcount
        {
            get { return _productcount; }
            set { _productcount = value; }
        }

        public int moneytojf
        {
            get
            {
                return Common.VShopConfigHelper.Get().MoneyToJfRate * (int)this.price;
            }
        }

        private int _hits = 0;
        public int hits
        {
            set { _hits = value; }
            get { return _hits; }
        }

        private decimal _price;
        /// <summary>
        /// 市场价,产品价格
        /// </summary>
        public decimal price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _itemprice = string.Empty;
         /// <summary>
         /// 属性价格，格式为：属性名称|价格 每行一个
         /// </summary>
        public string itemprice
        {
            get { return _itemprice; }
            set { _itemprice = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public Dictionary<string, decimal> itempricelist
        {
            get
            {
                Dictionary<string, decimal> list = new Dictionary<string,decimal>() ;
                if (this.itemprice.Trim() == string.Empty)
                    return list;

                string[] items = this.itemprice.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string i in items)
                {
                    string[] item = i.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    if (item.Length == 2 && !list.ContainsKey(item[0]))
                    {
                        list.Add(item[0], decimal.Parse(item[1]));
                    }
                }

                return list;
            }
        }

        private int _categoryid = 0;
        public int categoryid
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }

        private DateTime _createtime = DateTime.Now ;
        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

        private int _iscommend;
        public int iscommend
        {
            set { _iscommend = value; }
            get { return _iscommend; }
        }
    }
}
