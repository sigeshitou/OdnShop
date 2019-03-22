using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using OdnShop.Core.Model;
using OdnShop.Core.Factory;
using OdnShop.Core.Common;

namespace OdnShop.Core.Business
{

    public class Security
    {
        public static bool Login(string username, string password, out string tips)
        {
            AdminModel info = AdminFactory.Get(username);
            if (info == null)
            {
                tips = "此用户不存在！";
                return false;
            }

            if (info.userpwd != Utils.MD5(password))
            {
                tips = "密码不正确！";
                return false;
            }

            WriteUserCookie(info, 0);
            tips = "登陆成功！";
            return true;
        }

        public static LoginMember Check()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[SiteConfig.Instance().CookieName];

            if (cookie == null)
            {
                return null;
            }

            int adminid = 0;
            int usertype = 1;
            Int32.TryParse(cookie.Values["adminid"].Trim(), out adminid);
            Int32.TryParse(cookie.Values["usertype"].Trim(), out usertype);
            string username = HttpUtility.UrlDecode(cookie.Values["username"].Trim());
            string auth = cookie.Values["auth"].Trim();

            if (adminid == 0 || username == string.Empty || auth == string.Empty)
                return null;

            if (auth != BuildAuthCode(adminid, username, usertype))
                return null;

            return new LoginMember(adminid, username, usertype);
        }

        //检查是否是超级管理员，不是则跳转到登陆页
        public static void CheckAdministerAndRedirect()
        {
            LoginMember info = Security.Check();
            if (info == null)
            {
                HttpContext.Current.Response.Redirect("adminlogin.aspx");
                HttpContext.Current.Response.End();
            }

            if (!info.IsAdministrator)
            {
                HttpContext.Current.Response.Redirect("adminlogin.aspx");
                HttpContext.Current.Response.End();
            }

        }

        public static void CheckAdministerAndCloseReq()
        {
            LoginMember info = Security.Check();
            if (info == null)
            {
                HttpContext.Current.Response.End();
                return;
            }

            if (!info.IsAdministrator)
            {
                HttpContext.Current.Response.End();
                return;
            }
        }

        public static void Logout()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[SiteConfig.Instance().CookieName];
            cookie.Values["adminid"] = string.Empty;
            cookie.Values["username"] = string.Empty;
            cookie.Values["usertype"] = string.Empty;
            cookie.Values["auth"] = string.Empty;
            cookie.Values["expires"] = string.Empty;

            cookie.Expires = DateTime.Now.AddYears(-1);
            cookie.Domain = SiteConfig.Instance().CookieDomain;

            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void Logout(string reurl)
        {
            Logout();
            HttpContext.Current.Response.Redirect(reurl);
        }

        protected static void WriteUserCookie(AdminModel info, int expires)
        {
            HttpCookie cookie = new HttpCookie(SiteConfig.Instance().CookieName);
            cookie.Values["adminid"] = info.adminid.ToString();
            cookie.Values["username"] = HttpUtility.UrlEncode(info.username);
            cookie.Values["usertype"] = info.usertype.ToString();
            cookie.Values["auth"] = BuildAuthCode(info.adminid, info.username, info.usertype);
            cookie.Values["expires"] = expires.ToString();

            if (expires > 0)
            {
                cookie.Expires = DateTime.Now.AddMinutes(expires);
            }

            cookie.Domain = SiteConfig.Instance().CookieDomain.Trim();
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        protected static string BuildAuthCode(int adminid, string username, int usertype)
        {
            return Utils.MD5(adminid + username + usertype + SiteConfig.Instance().CookieEncryptionSalt);
        }
    }

    public class LoginMember
    {
        private int _adminid = 0;
        private string _username = string.Empty;
        private int _usertype = 1;

        public LoginMember(int adminid, string username, int usertype)
        {
            this.adminid = adminid;
            this.username = username;
            this.usertype = usertype;
        }

        public int adminid
        {
            get { return _adminid; }
            set { _adminid = value; }
        }

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// 1 表示创始人；2表示网站管理员；3表示信息管理员 ；10以上表示其他用户
        /// </summary>
        public int usertype
        {
            get { return _usertype; }
            set { _usertype = value; }
        }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdministrator
        {
            get
            {
                if (this.usertype >= 1 && this.usertype <= 3)
                    return true;

                return false;
            }
        }
    }
}
