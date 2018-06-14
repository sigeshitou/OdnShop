<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="OdnShop.Web.vshop.user" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>用户中心-<%= shopconfig.ShopName %></title>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link href="images/style.css" rel="stylesheet" type="text/css" media="all" />
<link href="images/font-awesome.min.css" rel="stylesheet" type="text/css" media="all" />
<link href="images/flexslider.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="images/jquery.min.js"></script>
<script type="text/javascript" src="images/jquery-ui.min.js"></script>
<script type="text/javascript" src="images/switchable.js"></script>
<link rel="stylesheet" href="images/LArea.css">
</head>
<body>

<header class="topheader">
<div class="headerleft"><a href="javascript:history.go(-1)"><span>返回</span></a></div>
<div class="headercenter">
<h2>用户中心</h2>
</div>
<div class="headerightsetup"><a href="user_profile.aspx"><span>设置</span></a></div>
</header>

<div class="userinfo">
<div class="userimg"><%= headerpic %></div>
<dl>
<dt><h4><%= nickname %></h4></dt>
<dd>您好，欢迎登陆<%=shopconfig.ShopName %></dd>
<dd>您是 <span><%= usertypedesc %></span> 您的ID号：<%= userId %></dd>
</dl>
</div>

<main class="usermainicon">
<ul>
<li><a href="user_fav.aspx"><i class="fa fa-heart-o"></i>我的收藏</a></li>
<li><a href="user_order.aspx"><i class="fa fa-file-text-o"></i>我的订单</a></li>
<li><a href="user_order.aspx?s=1"><i class="fa fa-credit-card"></i>待付款</a></li>
<li><a href="userqrcode.aspx"><i class="fa fa-share-alt"></i>我的分享</a></li>
<li><a href="user_profile.aspx"><i class="fa fa-user-circle-o"></i>我的资料</a></li>
</ul>
</main>

<main class="usermain">

<a href="javascript:void(0)">
<dl>
<dt><i class="fa fa-diamond"></i> 我的积分 <span><%= userJf %></span></dt>
<dd><i class="fa fa-angle-right"></i></dd>
</dl>
</a>

<a href="user_profile.aspx">
<dl>
<dt><i class="fa fa-map-marker"></i> 收货地址</dt>
<dd><i class="fa fa-angle-right"></i></dd>
</dl>
</a>

<a href="userqrcode.aspx">
<dl>
<dt><i class="fa fa-qrcode"></i> 推广二维码</dt>
<dd><i class="fa fa-angle-right"></i></dd>
</dl>
</a>

<a href="tel:<%= shopconfig.ShopTel %>">
<dl>
<dt><i class="fa fa-phone-square"></i> 联系客服 <em><%= shopconfig.ShopTel %></em></dt>
<dd><i class="fa fa-angle-right"></i></dd>
</dl>
</a>

</main>

<!-- 底部菜单s -->
<footer class="footer">
<a href="productcategory.aspx"><i class="footer-category"></i>分类</a>
<a href="search.aspx"><i class="footer-search"></i>搜索</a>
<a href="index.aspx"><i class="footer-home"></i>首页</a> 
<a href="cart.aspx"><i class="footer-cart"></i>购物车<span id="cartnum"><%= ShopCartNumber %></span></a> <!-- 如果购物车没数据就不显示<span id="cartnum">3</span> -->
<a href="user.aspx" id="active"><i class="footer-user"></i>我的</a><!-- 如是当前页a里加id="active" -->
</footer>
<!-- 底部菜单e -->
    <script type="text/javascript">
    $(document).ready(function () {
        if (<%= ShopCartNumber %> == 0)
            $("#cartnum").hide();
        });
     </script>
</body>
</html>
