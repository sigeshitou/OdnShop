using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OdnShop.Core.Tenpay
{
    public class TenpayConfig
    {
        private static TenpayConfig config = null;
        private static string configFilePath = System.Web.HttpContext.Current.Server.MapPath("~/config/tenpayconfig.config");
        private static DateTime configFileModifyDate = DateTime.Now; //配置文件最后一次修改时间

        static TenpayConfig()
        {
            LoadConfig();
        }

        public static TenpayConfig Instance()
        {
            //如果当前配置文件的修改时间小于上次的修改时间，则认为配置文件已经被修改，需重新加载
            if (configFileModifyDate < System.IO.File.GetLastWriteTime(configFilePath))
                LoadConfig();

            return config;
        }

        /// <summary>
        /// 加载配置信息
        /// </summary>
        public static void LoadConfig()
        {

            config = new TenpayConfig();

            #region ==Load Config Logic==
            config = new TenpayConfig();
            XmlDocument doc = new XmlDocument();
            doc.Load(configFilePath);

            XmlNode node = null;
            node = doc.SelectSingleNode("//TenpayConfig/APPID");
            if (node != null)
            {
                config.APPID = node.InnerText.Trim();
            }

            node = doc.SelectSingleNode("//TenpayConfig/APPSECRET"); 
            if (node != null)
            {
                config.APPSECRET = node.InnerText.Trim();
            }

            node = doc.SelectSingleNode("//TenpayConfig/MCHID");
            if (node != null)
            {
                config.MCHID = node.InnerText.Trim();
            }

            node = doc.SelectSingleNode("//TenpayConfig/KEY");
            if (node != null)
            {
                config.KEY = node.InnerText.Trim();
            }

            node = doc.SelectSingleNode("//TenpayConfig/NOTIFYURL");
            if (node != null)
            {
                config.NOTIFYURL = node.InnerText.Trim();
            }

            configFileModifyDate = DateTime.Now;
            #endregion
        }

        #region ==属性字段==
        public string APPID = "";
        public string APPSECRET = "";
        public string MCHID = "";     //商户号
        public string KEY = "";       //商户支付密钥
        public string NOTIFYURL = ""; //支付结果通知回调url，用于商户接收支付结果
        #endregion
    }
}