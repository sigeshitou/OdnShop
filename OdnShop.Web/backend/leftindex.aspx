<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leftindex.aspx.cs" Inherits="OdnShop.Web.backend.leftindex" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=uft-8" />
<title>管理顶部</title>
<link href="images/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
body { background:#dce9f1; }
-->
</style>
</head>
<body>
<ul id="left">
<li><a href="orderlist.aspx" target="MainFrame" onFocus="this.blur()">购物订单管理</a></li>
<li><a href="userlist.aspx" target="MainFrame" onFocus="this.blur()">用户管理</a></li>
<li><a href="productlist.aspx" target="MainFrame" onFocus="this.blur()">产品管理</a>|<a href="productcategorylist.aspx" target="MainFrame" onFocus="this.blur()">分类</a></li>
<li><a href="vshopconfig.aspx" target="MainFrame" onFocus="this.blur()">商城设置</a></li>
<li><a href="adminlist.aspx" target="MainFrame" onFocus="this.blur()">管理员管理</a></li>
</ul>
</body>
</html>
