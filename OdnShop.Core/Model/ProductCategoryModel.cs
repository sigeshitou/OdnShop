using System;
using System.Collections.Generic;
using System.Text;

namespace OdnShop.Core.Model
{
    public class ProductCategoryModel
    {
        #region Model
        private int _categoryid = 0;
        private string _categoryname = string.Empty;
        private int _orderid = 0;
        private int _parentid = 0;
        /// <summary>
        /// 
        /// </summary>
        public int categoryid
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string categoryname
        {
            set { _categoryname = value; }
            get { return _categoryname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int orderid
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int parentid
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        #endregion Model
    }
}
