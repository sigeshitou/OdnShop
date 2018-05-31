using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdnShop.Core.Model
{
    /// <summary>
    /// 前台用户类
    /// </summary>
    public class UserModel
    {
        public int uid { get; set; }
        public string nickname { get; set; }
        public string openid { get; set; }
        public string fullname { get; set; }
        public string sex { get; set; }
        public string tel { get; set; }
        public string address { get; set; }
        public string headpicurl { get; set; }
        public int jbnum { get; set; }
        public int jfnum { get; set; }
        public DateTime createdate { get; set; }
        public int fromuid { get; set; }

        /// <summary>
        /// 1是普通用户，10是VIP，100是代理商
        /// </summary>
        private int _usertype = 1;
        public int usertype
        {
            get { return _usertype; }
            set { _usertype = value; }
        }

        public string usertypedesc
        {
            get
            {
                switch (usertype)
                {
                    case 1:
                        return "普通用户";
                    case 10:
                        return "VIP用户";
                    case 100:
                        return "代理商";

                    default: return "普通用户";
                }
            }
        }
    }
}
