using System;
using System.Collections.Generic;
using System.Text;

namespace OdnShop.Core.Model
{
    public class AdminModel
    {
        #region Model
        private int _adminid;
        private string _username = "";
        private string _userpwd = "";
        private string _email = "";
        private string _tel = "";
        private int _usertype = 1;
        private DateTime _lastlogindate = DateTime.Now;
        private DateTime _createdate = DateTime.Now;
        private string _lastloginip = "";
        private int _logincount = 0;
        private string _adminqx = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int adminid
        {
            set { _adminid = value; }
            get { return _adminid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userpwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 1 表示超级管理员；2表示网站管理员；3表示内容编辑人员 ；10以上表示其他用户
        /// </summary>
        public int usertype
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime lastlogindate
        {
            set { _lastlogindate = value; }
            get { return _lastlogindate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createdate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lastloginip
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int logincount
        {
            set { _logincount = value; }
            get { return _logincount; }
        }

        public string adminqx
        {
            get { return _adminqx; }
            set { _adminqx = value; }
        }
        #endregion Model
    }
}
