using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OdnShop.Core.Common
{
    public class SiteConfig
    {
        private static SiteConfig config = null;
        private static string configFilePath = System.Web.HttpContext.Current.Server.MapPath("~/config/siteconfig.config");
        private static DateTime configFileModifyDate = DateTime.Now; //配置文件最后一次修改时间

        static SiteConfig()
        {
            LoadConfig();
        }

        public static SiteConfig Instance()
        {
            //如果当前配置文件的修改时间小于上次的修改时间，则认为配置文件已经被修改，需重新加载
            if (configFileModifyDate < System.IO.File.GetLastWriteTime(configFilePath))
                LoadConfig();

            return config;
        }

        #region ==属性字段==
        private string _sitedomain = "http://www.odnshop.com/";
        /// <summary>
        /// 网站域名
        /// </summary>
        public string SiteDomain
        {
            get
            {
                if (_sitedomain.EndsWith("/"))
                    return _sitedomain;

                return _sitedomain + "/";
            }
            set { _sitedomain = value; }
        }

        private string _DBConnStr = "";
        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        public string DBConnStr
        {
            get { return _DBConnStr; }
            set { _DBConnStr = value; }
        }


        private string _cookiedomain = ".odnshop.com";
        /// <summary>
        /// 写入Cookies的Domain
        /// </summary>
        public string CookieDomain
        {
            get { return _cookiedomain; }
            set { _cookiedomain = value; }
        }

        private string _cookiename = "odnshop";
        /// <summary>
        /// 写入Cookies的名字
        /// </summary>
        public string CookieName
        {
            get { return _cookiename; }
            set { _cookiename = value; }
        }

        private string _fileUpLoadPath = "/data/pic/";
        /// <summary>
        /// 上传文件目录
        /// </summary>
        public string FileUpLoadPath
        {
            get { return _fileUpLoadPath; }
            set { _fileUpLoadPath = value; }
        }
 

        private string _cookieencryptionsalt = string.Empty;
        /// <summary>
        /// Cookie信息加密附加字符
        /// </summary>
        public string CookieEncryptionSalt
        {
            get { return _cookieencryptionsalt; }
            set { _cookieencryptionsalt = value; }
        }

        private string _wxappid = string.Empty;
        public string WxAppId
        {
            get { return _wxappid; }
            set { _wxappid = value; }
        }

        private string _appsecret = string.Empty;
        public string WxAppSecret
        {
            get { return _appsecret; }
            set { _appsecret = value; }
        }

        private bool _VShopShowMode = true;
        /// <summary>
        /// 商城本地演示模式
        /// </summary>
        public bool VShopShowMode
        {
            get { return _VShopShowMode; }
            set { _VShopShowMode = value; }
        }
        #endregion

        /// <summary>
        /// 加载配置信息
        /// </summary>
        public static void LoadConfig()
        {

            config = new SiteConfig();

            #region ==Load Config Logic==
            config = new SiteConfig();
            XmlDocument doc = new XmlDocument();
            doc.Load(configFilePath);

            XmlNode node = null;
            node = doc.SelectSingleNode("//siteconfig/sitedomain");
            if (node != null)
            {
                config.SiteDomain = node.InnerText.Trim();
            }

            node = doc.SelectSingleNode("//siteconfig/dbconnstr");
            if (node != null)
            {
                config.DBConnStr = node.InnerText.Trim();
            }

            node = doc.SelectSingleNode("//siteconfig/cookiedomain");
            if (node != null)
            {
                config.CookieDomain = node.InnerText.Trim();
            }


            node = doc.SelectSingleNode("//siteconfig/cookiename");
            if (node != null)
            {
                config.CookieName = node.InnerText.Trim();
            }

            node = doc.SelectSingleNode("//siteconfig/cookieencryptionsalt");
            if (node != null)
            {
                config.CookieEncryptionSalt = node.InnerText.Trim();
            }

            node = doc.SelectSingleNode("//siteconfig/wxappid");
            if (node != null)
            {
                config.WxAppId = node.InnerText.Trim();
            }

            node = doc.SelectSingleNode("//siteconfig/wxappsecret");
            if (node != null)
            {
                config.WxAppSecret = node.InnerText.Trim();
            }

            node = doc.SelectSingleNode("//siteconfig/VShopShowMode");
            if (node != null)
            {
                config.VShopShowMode = Boolean.Parse(node.InnerText.Trim());
            }

            configFileModifyDate = DateTime.Now;
            #endregion
        }
    }
}
