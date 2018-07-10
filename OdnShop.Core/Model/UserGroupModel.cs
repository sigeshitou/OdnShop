using System;

namespace OdnShop.Core.Model
{
    public class UserGroupModel
    {
        public int groupid { get; set; }
        public string groupname { get; set; }
        public string picurl { get; set; }
        public int grouplevel { get; set; } //等级，从1开始，数字越大，级别越高
        public bool isdefalut { get; set; }
        public int upgradejf { get; set; }
        public int discount { get; set; }   //折扣，取值范围：1-100
    }
}
