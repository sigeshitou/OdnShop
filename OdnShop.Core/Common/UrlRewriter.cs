using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
namespace OdnShop.Core.Common
{
    public class UrlRewriter
    {
        public static void Rewrite(HttpContext context)
        {

            string requestPath = context.Request.Path.ToLower();
            //主站通用重写部分
            Dictionary<string, SiteUrl> urls = GetSiteUrls();
            foreach (SiteUrl url in urls.Values)
            {
                if (Regex.IsMatch(requestPath, url.Pattern))
                {
                    context.RewritePath(Regex.Replace(requestPath, url.Pattern, url.ToPage));
                }
            }
        }

        protected static Dictionary<string, SiteUrl> GetSiteUrls()
        {
            #region ==code==
            Dictionary<string, SiteUrl> urls = new Dictionary<string, SiteUrl>();
            SiteUrl url = null;

            #region ==deleted code==
            //url = new SiteUrl();
            //url.Name = "newsdetail";
            //url.Description = "资讯详细页URL";  //"news/2010-5-1/333.aspx"
            //url.Path = "news/{0}-{1}-{2}/{3}.aspx";
            //url.Pattern = @"news/(\d+)-(\d+)-(\d+)/(\d+).aspx";
            //url.ToPage = "newsview.aspx?aid=$4";
            //urls.Add(url.Name, url);

            //url = new SiteUrl();
            //url.Name = "sellhouseviewdetail";
            //url.Description = "出售房源详细页URL";  //"house/sell/333.aspx"
            //url.Path = "house/sell/{0}.aspx";
            //url.Pattern = @"house/sell/(\d+).aspx";
            //url.ToPage = "houseview.aspx?hid=$1";
            //urls.Add(url.Name, url);

            //url = new SiteUrl();
            //url.Name = "rentalhouseviewdetail";
            //url.Description = "出租房源详细页URL";  //"house/rental/333.aspx"
            //url.Path = "house/sell/{0}.aspx";
            //url.Pattern = @"house/rental/(\d+).aspx";
            //url.ToPage = "houseview.aspx?hid=$1";
            //urls.Add(url.Name, url);

            //url = new SiteUrl();
            //url.Name = "buyrequestviewdetail";
            //url.Description = "求购房源详细页URL";  //"request/buy/333.aspx"
            //url.Path = "request/buy/{0}.aspx";
            //url.Pattern = @"request/buy/(\d+).aspx";
            //url.ToPage = "requestview.aspx?hid=$1";
            //urls.Add(url.Name, url);

            //url = new SiteUrl();
            //url.Name = "hiringrequestviewdetail";
            //url.Description = "求租房源详细页URL";  //"request/buy/333.aspx"
            //url.Path = "request/hiring/{0}.aspx";
            //url.Pattern = @"request/hiring/(\d+).aspx";
            //url.ToPage = "requestview.aspx?hid=$1";
            //urls.Add(url.Name, url);
            #endregion

            url = new SiteUrl();
            url.Name = "helptopic";
            url.Description = "帮助文档文章URL";
            url.Path = "helptopic-{0}.aspx";
            url.Pattern = @"helptopic-(\d+).aspx";
            url.ToPage = "helptopic.aspx?articleid=$1";
            urls.Add(url.Name, url);

            url = new SiteUrl();
            url.Name = "newstopic";
            url.Description = "最新动态文章URL";
            url.Path = "newstopic-{0}.aspx";
            url.Pattern = @"newstopic-(\d+).aspx";
            url.ToPage = "newstopic.aspx?articleid=$1";
            urls.Add(url.Name, url);

            //newstopic.aspx
            return urls;
            #endregion
        }
    }

    public class SiteUrl
    {
        private string _name = string.Empty;
        /// <summary>
        /// url名称，名称必须唯一
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description = string.Empty;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _path = string.Empty;
        /// <summary>
        /// 路径
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private string _pattern = string.Empty;
        /// <summary>
        /// 正则
        /// </summary>
        public string Pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
        }

        private string _topage = string.Empty;
        /// <summary>
        /// 跳转页面
        /// </summary>
        public string ToPage
        {
            get { return _topage; }
            set { _topage = value; }
        }
    }
}
