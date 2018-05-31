using System;
using System.Collections.Generic;
using System.Text;

namespace OdnShop.Core.Model
{
    public class LinkModel
    {
        #region Model
        private int _linkid;
        private string _linkname;
        private string _linkurl;
        private string _includepic;
        private string _possymbol;
        private DateTime _createtime;
        private int _orderno;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int linkid
        {
            set { _linkid = value; }
            get { return _linkid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string linkname
        {
            set { _linkname = value; }
            get { return _linkname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string linkurl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string includepic
        {
            set { _includepic = value; }
            get { return _includepic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string possymbol
        {
            set { _possymbol = value; }
            get { return _possymbol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int orderno
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        #endregion Model
    }
}
