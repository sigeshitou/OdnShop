using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdnShop.Core.Model
{
    public class FavoriteModel
    {
        private int _fid = 0;
        public int fid
        {
            get { return _fid; }
            set { _fid = value; }
        }

        private int _uid = 0;
        public int uid
        {
            get { return _uid; }
            set { _uid = value; }
        }

        private int _productid = 0;
        public int productid
        {
            get { return _productid; }
            set { _productid = value; }
        }

        private ProductModel _product;
        public ProductModel product
        {
            get { return _product; }
            set { _product = value; }
        }

        private DateTime _createtime = DateTime.Now;
        public DateTime createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
    }
}
