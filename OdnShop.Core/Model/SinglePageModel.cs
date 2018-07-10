using System;
namespace OdnShop.Core.Model
{
    public class SinglePageModel
    {
        #region Model
        private int _pageid;
        private string _serialno;
        private string _title;
        private string _content;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int pageid
        {
            set { _pageid = value; }
            get { return _pageid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string serialno
        {
            set { _serialno = value; }
            get { return _serialno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        #endregion Model
    }
}
