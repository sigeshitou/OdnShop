<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userqrcode.aspx.cs" Inherits="OdnShop.Web.vshop.userqrcode" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title><%= shopconfig.ShopName  %></title>
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
<h2>我的分享</h2>
</div>
<div class="headerightsetup"><a href="user_profile.aspx"><span>设置</span></a></div>
</header>

<main class="usermainedit">

<section class="shareqrcode">
<h5>二维码分享</h5>
<asp:Image runat="server" ID="imQrCode" />
把以上二维码保存下来，发到朋友圈或微信群即可分享
</section>

<section class="shareqrcode">
<h5>链接分享</h5>
在本页面(只能在本页面哦)，点击微信右上角的“三个点”标志，然后点击分享到朋友圈或分享到微信群等按钮即可。
</section>

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
