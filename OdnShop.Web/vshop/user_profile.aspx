<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_profile.aspx.cs" Inherits="OdnShop.Web.vshop.user_profile" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>我的资料-<%= shopconfig.ShopName %></title>
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
<h2>编辑我的资料</h2>
</div>
<div class="headerightsetup"><a href="user_profile.aspx"><span>设置</span></a></div>
</header>

<form name="formEdit" runat="server">
<main class="usermainedit">
<dl>
<dt><img src="<%= userInfo.headpicurl %>" alt=""/></dt>
<dd><h4><%= userInfo.nickname %></h4> <span></span> 您的ID号：<%= userInfo.uid %></dd>
<dd></dd>
</dl>
<ul>
<li><h4>收货人姓名：</h4><p><input class="cartinput" name="fullname" id="fullname" type="text" placeholder="请输入您的姓名" required="required" runat="server"></p></li>
<li><h4>您的性别：</h4><p>
<input type="radio" id="radioboy" name="radio1set" class="myradiobox" runat="server" /><label for="radioboy"></label> 先生 &nbsp;&nbsp;
<input type="radio" id="radiogirl" name="radio1set" class="myradiobox" runat="server" /><label for="radiogirl"></label> 女士
</p></li>
<li><h4>手机号码：</h4><p><input class="cartinput" name="tel" id="tel" type="text" placeholder="请输入您的手机号" required="required"  runat="server"></p></li>
<li><h4>收货地址：</h4><p><input class="cartinput" name="address" id="address" type="text" required="required" placeholder="请输入您的收货地址"  runat="server"></p></li>
<asp:LinkButton runat="server" CssClass="btnforpage" Text="确定修改" ID="btnSave" OnClick="btnSave_Click" />
</ul>

</main>
</form>
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

