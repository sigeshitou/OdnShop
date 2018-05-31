using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.IO;

using OdnShop.Core.Model;
namespace OdnShop.Core.Common
{
    public class VShopConfigHelper
    {
        private static VShopConfig config = null;
        private static DateTime configFileModifyDate = DateTime.Now; //配置文件最后一次修改时间
        private static string _DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
        private static string _VShopConfigPath = Path.Combine(_DataPath, "vshopconfig.config");

        public static VShopConfig Get()
        {
            if (!File.Exists(_VShopConfigPath))
            {
                 Save(new VShopConfig()); //如果文件不存在，则生成一个默认的配置文件。
            }

            //如果当前配置文件的修改时间小于上次的修改时间，则认为配置文件已经被修改，需重新加载
            if (config == null || configFileModifyDate < System.IO.File.GetLastWriteTime(_VShopConfigPath))
            {
                try
                {
                    config = (VShopConfig)SerializeHelper.LoadFromFile(new VShopConfig().GetType(), _VShopConfigPath);
                    configFileModifyDate = DateTime.Now;
                }
                catch { }
            }
            

            return config ;
        }

        public static void Save(VShopConfig info)
        {
            SerializeHelper.SaveToFile(info, _VShopConfigPath);
        }
    }
}
