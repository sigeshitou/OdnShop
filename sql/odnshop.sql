-- --------------------------------------------------------
-- 主机:                           127.0.0.1
-- 服务器版本:                        5.0.90-community-nt - MySQL Community Edition (GPL)
-- 服务器操作系统:                      Win32
-- HeidiSQL 版本:                  9.4.0.5125
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 导出  表 odnshop.odnshop_admin 结构
DROP TABLE IF EXISTS `odnshop_admin`;
CREATE TABLE IF NOT EXISTS `odnshop_admin` (
  `adminid` int(11) NOT NULL auto_increment,
  `username` varchar(45) default NULL,
  `userpwd` varchar(45) default NULL,
  `email` varchar(45) default NULL,
  `tel` varchar(45) default NULL,
  `usertype` int(11) default NULL,
  `lastlogindate` datetime default NULL,
  `createdate` datetime default NULL,
  `lastloginip` varchar(45) default NULL,
  `logincount` int(11) default NULL,
  `adminqx` mediumtext,
  PRIMARY KEY  (`adminid`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- 正在导出表  odnshop.odnshop_admin 的数据：1 rows
DELETE FROM `odnshop_admin`;
/*!40000 ALTER TABLE `odnshop_admin` DISABLE KEYS */;
INSERT INTO `odnshop_admin` (`adminid`, `username`, `userpwd`, `email`, `tel`, `usertype`, `lastlogindate`, `createdate`, `lastloginip`, `logincount`, `adminqx`) VALUES
	(1, 'admin', '7fef6171469e80d32c0559f88b377245', '', '', 2, '2017-08-15 10:36:45', '2017-08-15 10:36:45', '', 0, '');
/*!40000 ALTER TABLE `odnshop_admin` ENABLE KEYS */;

-- 导出  表 odnshop.odnshop_favorite 结构
DROP TABLE IF EXISTS `odnshop_favorite`;
CREATE TABLE IF NOT EXISTS `odnshop_favorite` (
  `fid` int(11) NOT NULL auto_increment,
  `uid` int(11) default '0',
  `productid` int(11) default '0',
  `productxml` mediumtext,
  `createtime` datetime default NULL,
  PRIMARY KEY  (`fid`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- 正在导出表  odnshop.odnshop_favorite 的数据：0 rows
DELETE FROM `odnshop_favorite`;
/*!40000 ALTER TABLE `odnshop_favorite` DISABLE KEYS */;
/*!40000 ALTER TABLE `odnshop_favorite` ENABLE KEYS */;

-- 导出  表 odnshop.odnshop_link 结构
DROP TABLE IF EXISTS `odnshop_link`;
CREATE TABLE IF NOT EXISTS `odnshop_link` (
  `linkid` int(11) NOT NULL auto_increment,
  `linkname` varchar(45) default '0',
  `linkurl` varchar(200) default '0',
  `includepic` varchar(200) default '0',
  `possymbol` varchar(45) default '0',
  `createtime` datetime default NULL,
  `orderno` int(11) default '0',
  PRIMARY KEY  (`linkid`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- 正在导出表  odnshop.odnshop_link 的数据：3 rows
DELETE FROM `odnshop_link`;
/*!40000 ALTER TABLE `odnshop_link` DISABLE KEYS */;
INSERT INTO `odnshop_link` (`linkid`, `linkname`, `linkurl`, `includepic`, `possymbol`, `createtime`, `orderno`) VALUES
	(4, '独立部署，掌控自在由你！', 'http://www.qizhanbang.com', '/vshop/images/b1.jpg', '首页幻灯片', '2017-09-10 20:27:04', 3),
	(5, '好而不贵，省心毫无压力！', 'http://www.qizhanbang.com', '/vshop/images/b2.jpg', '首页幻灯片', '2017-09-10 20:27:20', 6),
	(6, '持续迭代，专注成就专业！', 'http://www.qizhanbang.com', '/vshop/images/b3.jpg', '首页幻灯片', '2017-09-10 20:27:34', 9);
/*!40000 ALTER TABLE `odnshop_link` ENABLE KEYS */;

-- 导出  表 odnshop.odnshop_order 结构
DROP TABLE IF EXISTS `odnshop_order`;
CREATE TABLE IF NOT EXISTS `odnshop_order` (
  `orderid` int(11) NOT NULL auto_increment,
  `orderno` varchar(50) default NULL,
  `uid` int(11) default NULL,
  `customername` varchar(50) default NULL,
  `tel` varchar(50) default NULL,
  `address` varchar(50) default NULL,
  `orderstatus` int(11) default NULL,
  `deliverstatus` int(11) default NULL,
  `createtime` datetime default NULL,
  `orderxml` mediumtext,
  PRIMARY KEY  (`orderid`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- 正在导出表  odnshop.odnshop_order 的数据：6 rows
DELETE FROM `odnshop_order`;
/*!40000 ALTER TABLE `odnshop_order` DISABLE KEYS */;
INSERT INTO `odnshop_order` (`orderid`, `orderno`, `uid`, `customername`, `tel`, `address`, `orderstatus`, `deliverstatus`, `createtime`, `orderxml`) VALUES
	(15, '10000000020171006164026521152578', 1, '阿科科11', '123456789', '河源市中心区11', 2, 1, '2017-10-06 00:00:00', '<?xml version="1.0"?>\r\n<OrderModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">\r\n  <orderno>10000000020171006164026521152578</orderno>\r\n  <uid>1</uid>\r\n  <customername>阿科科11</customername>\r\n  <tel>123456789</tel>\r\n  <address>河源市中心区11</address>\r\n  <totaljifen>0</totaljifen>\r\n  <totalprice>0</totalprice>\r\n  <totalyfjifen>0</totalyfjifen>\r\n  <totalyfprice>0</totalyfprice>\r\n  <ordersysdesc />\r\n  <orderstatus>2</orderstatus>\r\n  <deliverstatus>1</deliverstatus>\r\n  <createtime>2017-10-06T16:40:26.2533306+08:00</createtime>\r\n  <productlist>\r\n    <OrderProduct>\r\n      <productinfo>\r\n        <productid>15</productid>\r\n        <productname>好吃到没法形容的茶油15</productname>\r\n        <includepicpath>/data/image/20170909/20170909002152_1302.jpg</includepicpath>\r\n        <productpics>/data/pic/201709/09/201709090021578895.jpg|/data/pic/201709/09/201709090021579447.jpg</productpics>\r\n        <productcode>1</productcode>\r\n        <description />\r\n        <specification>&lt;img src="/data/image/20170909/20170909002103_1111.jpg" alt="" /&gt;</specification>\r\n        <salecount>6</salecount>\r\n        <productcount>89</productcount>\r\n        <hits>0</hits>\r\n        <price>235.00</price>\r\n        <itemprice />\r\n        <categoryid>2</categoryid>\r\n        <createtime>2017-09-10T13:37:00</createtime>\r\n        <iscommend>0</iscommend>\r\n      </productinfo>\r\n      <item />\r\n      <price>235.00</price>\r\n      <count>1</count>\r\n      <isselected>true</isselected>\r\n    </OrderProduct>\r\n  </productlist>\r\n  <sharelist />\r\n</OrderModel>\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0'),
	(16, '10000000020171006164038937470344', 1, '阿科科11', '123456789', '河源市中心区11', 2, 1, '2017-10-06 00:00:00', '<?xml version="1.0"?>\r\n<OrderModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">\r\n  <orderno>10000000020171006164038937470344</orderno>\r\n  <uid>1</uid>\r\n  <customername>阿科科11</customername>\r\n  <tel>123456789</tel>\r\n  <address>河源市中心区11</address>\r\n  <totaljifen>0</totaljifen>\r\n  <totalprice>0</totalprice>\r\n  <totalyfjifen>0</totalyfjifen>\r\n  <totalyfprice>0</totalyfprice>\r\n  <ordersysdesc />\r\n  <orderstatus>2</orderstatus>\r\n  <deliverstatus>1</deliverstatus>\r\n  <createtime>2017-10-06T16:42:28.9108557+08:00</createtime>\r\n  <productlist />\r\n  <sharelist />\r\n</OrderModel>'),
	(17, '10000000020171006164228160556042', 1, '阿科科11', '123456789', '河源市中心区11', 2, 1, '2017-10-06 00:00:00', '<?xml version="1.0"?>\r\n<OrderModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">\r\n  <orderno>10000000020171006164228160556042</orderno>\r\n  <uid>1</uid>\r\n  <customername>阿科科11</customername>\r\n  <tel>123456789</tel>\r\n  <address>河源市中心区11</address>\r\n  <totaljifen>0</totaljifen>\r\n  <totalprice>0</totalprice>\r\n  <totalyfjifen>0</totalyfjifen>\r\n  <totalyfprice>0</totalyfprice>\r\n  <ordersysdesc />\r\n  <orderstatus>2</orderstatus>\r\n  <deliverstatus>1</deliverstatus>\r\n  <createtime>2017-10-06T16:42:57.9341959+08:00</createtime>\r\n  <productlist>\r\n    <OrderProduct>\r\n      <productinfo>\r\n        <productid>13</productid>\r\n        <productname>好吃到没法形容的茶油13</productname>\r\n        <includepicpath>/data/image/20170909/20170909002152_1302.jpg</includepicpath>\r\n        <productpics>/data/pic/201709/09/201709090021578895.jpg|/data/pic/201709/09/201709090021579447.jpg</productpics>\r\n        <productcode>1</productcode>\r\n        <description />\r\n        <specification>&lt;img src="/data/image/20170909/20170909002103_1111.jpg" alt="" /&gt;</specification>\r\n        <salecount>6</salecount>\r\n        <productcount>89</productcount>\r\n        <hits>0</hits>\r\n        <price>235.00</price>\r\n        <itemprice />\r\n        <categoryid>2</categoryid>\r\n        <createtime>2017-09-10T13:37:00</createtime>\r\n        <iscommend>0</iscommend>\r\n      </productinfo>\r\n      <item />\r\n      <price>235.00</price>\r\n      <count>1</count>\r\n      <isselected>true</isselected>\r\n    </OrderProduct>\r\n  </productlist>\r\n  <sharelist />\r\n</OrderModel>\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0'),
	(18, '10000000020171006164257784180902', 1, '阿科科11', '123456789', '河源市中心区11', 5, 3, '2017-10-06 00:00:00', '<?xml version="1.0"?>\r\n<OrderModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">\r\n  <orderno>10000000020171006164257784180902</orderno>\r\n  <uid>1</uid>\r\n  <customername>阿科科11</customername>\r\n  <tel>123456789</tel>\r\n  <address>河源市中心区11</address>\r\n  <totaljifen>0</totaljifen>\r\n  <totalprice>0</totalprice>\r\n  <totalyfjifen>0</totalyfjifen>\r\n  <totalyfprice>0</totalyfprice>\r\n  <ordersysdesc />\r\n  <orderstatus>5</orderstatus>\r\n  <deliverstatus>3</deliverstatus>\r\n  <createtime>2017-10-06T16:40:38.2690946+08:00</createtime>\r\n  <productlist />\r\n  <sharelist />\r\n</OrderModel>'),
	(19, '10000000020171014140831295550795', 1, 'd', '123456789', '河源市中心区11', 3, 1, '2017-10-14 00:00:00', '<?xml version="1.0"?>\r\n<OrderModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">\r\n  <orderno>10000000020171014140831295550795</orderno>\r\n  <uid>1</uid>\r\n  <customername>d</customername>\r\n  <tel>123456789</tel>\r\n  <address>河源市中心区11</address>\r\n  <totaljifen>0</totaljifen>\r\n  <totalprice>0.01</totalprice>\r\n  <totalyfjifen>0</totalyfjifen>\r\n  <totalyfprice>8.01</totalyfprice>\r\n  <ordersysdesc>VIP用户</ordersysdesc>\r\n  <orderstatus>3</orderstatus>\r\n  <deliverstatus>1</deliverstatus>\r\n  <createtime>2017-10-14T14:08:31.840006+08:00</createtime>\r\n  <shippingdesc>快递</shippingdesc>\r\n  <paymentdesc>微信支付</paymentdesc>\r\n  <ordermessage />\r\n  <productlist>\r\n    <OrderProduct>\r\n      <productinfo>\r\n        <productid>17</productid>\r\n        <productname>好吃到没法形容的茶油17</productname>\r\n        <includepicpath>/data/image/20170909/20170909002152_1302.jpg</includepicpath>\r\n        <productpics>/data/pic/201709/09/201709090021578895.jpg|/data/pic/201709/09/201709090021579447.jpg</productpics>\r\n        <productcode>1</productcode>\r\n        <description />\r\n        <specification>&lt;img src="/data/image/20170909/20170909002103_1111.jpg" alt="" /&gt;</specification>\r\n        <salecount>6</salecount>\r\n        <productcount>89</productcount>\r\n        <hits>0</hits>\r\n        <price>0.01</price>\r\n        <itemprice>美白款|0.01\n美肤款|0.02\n美容款|0.03</itemprice>\r\n        <categoryid>2</categoryid>\r\n        <createtime>2017-10-15T11:15:14</createtime>\r\n        <iscommend>1</iscommend>\r\n      </productinfo>\r\n      <item />\r\n      <price>0.01</price>\r\n      <count>1</count>\r\n      <isselected>true</isselected>\r\n    </OrderProduct>\r\n  </productlist>\r\n  <sharelist />\r\n</OrderModel>\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0'),
	(20, '10000000020171205221153133178044', 1, '企站帮测试', '123456789', 'qizhanbang.com', 1, 1, '2017-12-05 00:00:00', '<?xml version="1.0"?>\r\n<OrderModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">\r\n  <orderno>10000000020171205221153133178044</orderno>\r\n  <uid>1</uid>\r\n  <customername>企站帮测试</customername>\r\n  <tel>123456789</tel>\r\n  <address>qizhanbang.com</address>\r\n  <totaljifen>0</totaljifen>\r\n  <totalprice>0</totalprice>\r\n  <totalyfjifen>0</totalyfjifen>\r\n  <totalyfprice>0</totalyfprice>\r\n  <ordersysdesc />\r\n  <orderstatus>1</orderstatus>\r\n  <deliverstatus>1</deliverstatus>\r\n  <createtime>2017-12-05T22:11:53.6230751+08:00</createtime>\r\n  <productlist>\r\n    <OrderProduct>\r\n      <productinfo>\r\n        <productid>19</productid>\r\n        <productname>产品安装套餐包</productname>\r\n        <includepicpath>/data/image/20171127/20171127230003_8039.jpg</includepicpath>\r\n        <productpics>/data/pic/201711/27/201711272300123044.jpg</productpics>\r\n        <productcode>1</productcode>\r\n        <description />\r\n        <specification>此价格包括服务器环境配置，产品安装服务</specification>\r\n        <salecount>3</salecount>\r\n        <productcount>9999</productcount>\r\n        <hits>0</hits>\r\n        <price>1000.00</price>\r\n        <itemprice />\r\n        <categoryid>2</categoryid>\r\n        <createtime>2017-11-27T23:00:58</createtime>\r\n        <iscommend>1</iscommend>\r\n      </productinfo>\r\n      <item />\r\n      <price>1000.00</price>\r\n      <count>2</count>\r\n      <isselected>true</isselected>\r\n    </OrderProduct>\r\n    <OrderProduct>\r\n      <productinfo>\r\n        <productid>18</productid>\r\n        <productname>微商城系统</productname>\r\n        <includepicpath>/data/image/20171127/20171127225705_5110.jpg</includepicpath>\r\n        <productpics>/data/pic/201711/27/201711272257227766.jpg|/data/pic/201711/27/201711272257229412.jpg|/data/pic/201711/27/201711272257229672.jpg</productpics>\r\n        <productcode>1</productcode>\r\n        <description />\r\n        <specification>基于ASP.NET平台的微商城系统，致力于为千万线下商家提供可独立部署，用的起的微商城解决方案。</specification>\r\n        <salecount>3</salecount>\r\n        <productcount>9999</productcount>\r\n        <hits>0</hits>\r\n        <price>1280.00</price>\r\n        <itemprice />\r\n        <categoryid>1</categoryid>\r\n        <createtime>2017-11-27T22:59:04</createtime>\r\n        <iscommend>1</iscommend>\r\n      </productinfo>\r\n      <item />\r\n      <price>1280.00</price>\r\n      <count>1</count>\r\n      <isselected>true</isselected>\r\n    </OrderProduct>\r\n  </productlist>\r\n  <sharelist />\r\n</OrderModel>\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0');
/*!40000 ALTER TABLE `odnshop_order` ENABLE KEYS */;

-- 导出  表 odnshop.odnshop_product 结构
DROP TABLE IF EXISTS `odnshop_product`;
CREATE TABLE IF NOT EXISTS `odnshop_product` (
  `productid` int(11) NOT NULL auto_increment,
  `productname` varchar(50) default NULL,
  `includepicpath` varchar(50) default NULL,
  `productpics` mediumtext,
  `productcode` int(11) default NULL,
  `description` mediumtext,
  `specification` mediumtext,
  `salecount` int(11) default NULL,
  `hits` int(11) default NULL,
  `productcount` int(11) default NULL,
  `price` decimal(10,2) default NULL,
  `itemprice` varchar(500) default NULL,
  `categoryid` int(11) default NULL,
  `createtime` datetime default NULL,
  `iscommend` tinyint(4) default NULL,
  PRIMARY KEY  (`productid`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;

-- 正在导出表  odnshop.odnshop_product 的数据：2 rows
DELETE FROM `odnshop_product`;
/*!40000 ALTER TABLE `odnshop_product` DISABLE KEYS */;
INSERT INTO `odnshop_product` (`productid`, `productname`, `includepicpath`, `productpics`, `productcode`, `description`, `specification`, `salecount`, `hits`, `productcount`, `price`, `itemprice`, `categoryid`, `createtime`, `iscommend`) VALUES
	(18, '微商城系统', '/data/image/20171127/20171127225705_5110.jpg', '/data/pic/201711/27/201711272257227766.jpg|/data/pic/201711/27/201711272257229412.jpg|/data/pic/201711/27/201711272257229672.jpg', 1, '', '基于ASP.NET平台的微商城系统，致力于为千万线下商家提供可独立部署，用的起的微商城解决方案。', 3, 0, 9999, 1280.00, '', 1, '2017-11-27 22:59:04', 1),
	(19, '产品安装套餐包', '/data/image/20171127/20171127230003_8039.jpg', '/data/pic/201711/27/201711272300123044.jpg', 1, '', '此价格包括服务器环境配置，产品安装服务', 3, 0, 9999, 1000.00, '', 2, '2017-11-27 23:00:58', 1);
/*!40000 ALTER TABLE `odnshop_product` ENABLE KEYS */;

-- 导出  表 odnshop.odnshop_productcategory 结构
DROP TABLE IF EXISTS `odnshop_productcategory`;
CREATE TABLE IF NOT EXISTS `odnshop_productcategory` (
  `categoryid` int(11) NOT NULL auto_increment,
  `categoryname` varchar(50) default NULL,
  `orderid` int(11) default NULL,
  `parentid` int(11) default NULL,
  PRIMARY KEY  (`categoryid`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- 正在导出表  odnshop.odnshop_productcategory 的数据：3 rows
DELETE FROM `odnshop_productcategory`;
/*!40000 ALTER TABLE `odnshop_productcategory` DISABLE KEYS */;
INSERT INTO `odnshop_productcategory` (`categoryid`, `categoryname`, `orderid`, `parentid`) VALUES
	(1, '商城解决方案', 1, 0),
	(2, '技术升级服务', 3, 0),
	(3, '定制开发服务', 5, 0);
/*!40000 ALTER TABLE `odnshop_productcategory` ENABLE KEYS */;

-- 导出  表 odnshop.odnshop_user 结构
DROP TABLE IF EXISTS `odnshop_user`;
CREATE TABLE IF NOT EXISTS `odnshop_user` (
  `uid` int(11) NOT NULL auto_increment,
  `nickname` varchar(50) default NULL,
  `openid` varchar(50) default NULL,
  `fullname` varchar(50) default NULL,
  `sex` varchar(50) default NULL,
  `tel` varchar(50) default NULL,
  `address` varchar(50) default NULL,
  `headpicurl` varchar(255) default NULL,
  `jbnum` int(11) default NULL,
  `jfnum` int(11) default NULL,
  `createdate` datetime default NULL,
  `fromuid` int(11) default NULL,
  `usertype` int(11) default NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- 正在导出表  odnshop.odnshop_user 的数据：1 rows
DELETE FROM `odnshop_user`;
/*!40000 ALTER TABLE `odnshop_user` DISABLE KEYS */;
INSERT INTO `odnshop_user` (`uid`, `nickname`, `openid`, `fullname`, `sex`, `tel`, `address`, `headpicurl`, `jbnum`, `jfnum`, `createdate`, `fromuid`, `usertype`) VALUES
	(1, 'OdnShop', 'dfdflkdlfkdlfkdl', 'OdnShop测试', '男', '123456789', 'OdnShop.com', '/data/image/20170909/20170909002152_1302.jpg', 0, 0, '2017-09-09 00:00:00', 0, 1);
/*!40000 ALTER TABLE `odnshop_user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
