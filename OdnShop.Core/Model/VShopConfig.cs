using System;
namespace OdnShop.Core.Model
{
    public class VShopConfig
    {
        //商城基本信息设置
        public string ShopName = "OdnShop";
        public string ShopAddress = string.Empty;
        public string ShopTel = string.Empty;
        public string ShopLogo = string.Empty;

        public int MoneyToJfRate = 10; //人民币到积分的转换比率，也就是一元钱等于多少积分

        public decimal PostAge = 10; //统一邮递费,0表示免邮
        public decimal FreePostAge = 0; //免邮额(含)，既超过多少钱可以免邮费，0表示无

        //首页定义
        public int HomeCommendProductCount = 6;
        public int HomeLatestProductCount = 8;
    }
}
