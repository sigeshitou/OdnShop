using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data ;

using OdnShop.Core.Factory;
using OdnShop.Core.Common;
using OdnShop.Core.Model;
namespace OdnShop.Core.PageControler
{
    public class WebPageBase : System.Web.UI.Page
    {
        public VShopConfig shopconfig = VShopConfigHelper.Get();
        public WebPageBase()
        {
            //用户未登陆，则跳转到
            if (LoginUser == null)
            {
                string url = HYRequest.GetUrl();
                string reurl = SiteConfig.Instance().SiteDomain + "login.aspx?reurl=" + url ;
                HttpContext.Current.Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + SiteConfig.Instance().WxAppId + "&redirect_uri=" + reurl + "&response_type=code&scope=snsapi_userinfo&state=1#wechat_redirect");
            }
        }

        //当前登陆用户，未登陆则返回null
        public UserModel LoginUser
        {
            get
            {
                if (SiteConfig.Instance().VShopShowMode)
                    return UserFactory.GetFirst();
                else
                {
                    return CheckLogin();
                }
            }
        }

        //购物车物品数量
        public int ShopCartNumber
        {
            get
            {
                OrderModel myorder = OrderFactory.GetCartOrder(this.LoginUser.uid);
                if (myorder != null && myorder.productlist != null)
                    return myorder.productlist.Count;

                return 0;
            }
        }

        public static UserModel CheckLogin()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[SiteConfig.Instance().CookieName + "_front"];

            if (cookie == null)
            {
                return null;
            }

            int uid = 0;
            Int32.TryParse(cookie.Values["uid"].Trim(), out uid);
            string auth = cookie.Values["auth"].Trim();

            if (uid == 0)
                return null;

            if (auth != BuildAuthCode(uid))
                return null;

            return UserFactory.Get(uid);
        }

        //登陆授权相关帮助方法
        public static void WriteUidCookie(int uid, int expires)
        {
            HttpCookie cookie = new HttpCookie(SiteConfig.Instance().CookieName+"_front");
            cookie.Values["uid"] = uid.ToString();
            cookie.Values["auth"] = BuildAuthCode(uid);
            cookie.Values["expires"] = expires.ToString();

            if (expires > 0)
            {
                cookie.Expires = DateTime.Now.AddMinutes(expires);
            }

            cookie.Domain = SiteConfig.Instance().CookieDomain.Trim();
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static string BuildAuthCode(int uid)
        {
            return Utils.MD5(uid + "front" + SiteConfig.Instance().CookieEncryptionSalt);
        }

        public string getlinks(string pb, string tpl)
        {
            StringBuilder sb = new StringBuilder();
            DataTable links = LinkFactory.GetList(pb);
            foreach (DataRow dr in links.Rows)
            {
                string lnk = tpl;
                lnk = lnk.Replace("{linkurl}", dr["linkurl"].ToString());
                lnk = lnk.Replace("{linkname}", dr["linkname"].ToString());
                lnk = lnk.Replace("{includepic}", dr["includepic"].ToString());

                sb.AppendLine(lnk);
                //sb.AppendFormat(tpl, dr["linkurl"].ToString(), dr["linkname"].ToString());
            }

            return sb.ToString();
        }

        public string getadlinks(int linkid)
        {
            LinkModel l = LinkFactory.Get(linkid);
            if (l != null)
            {
                return string.Format("<a href=\"{0}\" target=\"_blank\"><img src=\"{1}\" width=\"1000\" height=\"80\" /></a>",l.linkurl ,l.includepic);
            }

            return string.Empty;
        }

        public string getadlinks(int linkid,string tpl)
        {
            LinkModel l = LinkFactory.Get(linkid);
            if (l != null)
            {
                return string.Format(tpl, l.linkurl, l.includepic);
            }

            return string.Empty;
        }

        //TODO:已废除
        public string getitems(string itemprice)
        {
            Dictionary<string, decimal> list = new Dictionary<string, decimal>();
            if (itemprice.Trim() == string.Empty)
                return string.Empty;

            StringBuilder sbhtml = new StringBuilder();
            string[] items = itemprice.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int j = 1;
            foreach (string i in items)
            {
                string[] item = i.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                if (item.Length == 2 && !list.ContainsKey(item[0]))
                {
                    list.Add(item[0], decimal.Parse(item[1]));
                    sbhtml.AppendLine(string.Format("<li data-aid=\"{0}\"><a href=\"javascript:\" title=\"{1}\">{2}({3})</a></li>", j, item[0], item[0],item[1]));
                    j++;
                }
            }

            return sbhtml.ToString();
        }

        public string getitems(string itemprice,string showpriceid)
        {
            Dictionary<string, decimal> list = new Dictionary<string, decimal>();
            if (itemprice.Trim() == string.Empty)
                return string.Empty;

            StringBuilder sbhtml = new StringBuilder();
            string[] items = itemprice.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int j = 1;
            foreach (string i in items)
            {
                string[] item = i.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                string selectedclass = (j == 1 ? " class='selected'" : "");
                if (item.Length == 2 && !list.ContainsKey(item[0]))
                {
                    list.Add(item[0], decimal.Parse(item[1]));
                    sbhtml.AppendLine(string.Format("<li data-aid=\"{0}\""+ selectedclass + "><a href=\"javascript:\" onclick=\"document.getElementById('{1}').innerHTML='&yen;{3}';\" title=\"{2}\">{2}</a></li>", j, showpriceid, item[0], item[1]));
                    j++;
                }
            }

            return sbhtml.ToString();
        }
    }

}
