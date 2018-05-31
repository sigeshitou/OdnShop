<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ordercheck.aspx.cs" Inherits="OdnShop.Web.vshop.ordercheck" %>
<%@ Import Namespace="OdnShop.Core.Model" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>订单确认-<%= shopconfig.ShopName %></title>
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
    <form runat="server" onsubmit="return form_check()">
<header class="topheader">
<div class="headerleft"><a href="javascript:history.go(-1)"><span>返回</span></a></div>
<div class="headercenter">
<h2>购物车结算</h2>
</div>
<div class="headeright"><a href="index.aspx"><span>首页</span></a></div>
</header>

<main class="mainpages">
  <section class="carcheckout">
<ul>
<li><h4>收货人姓名：</h4><p><input class="cartinput" name="yourname" id="txtcustomername" type="text" placeholder="请输入您的姓名" runat="server"></p></li>
<li><h4>手机号码：</h4><p><input class="cartinput" name="yourname" id="txttel" type="text" placeholder="请输入您的手机号"  value="" runat="server"></p></li>
<li><h4>收货地址：</h4><p><input class="cartinput" id="txtaddress" type="text" placeholder="请输入您的收货地址"  runat="server"/></p></li>
<li><h4>配送方式：</h4><p>
<input type="radio" id="radio-1-1" name="radio-1-set" class="myradiobox" checked /><label for="radio-1-1"></label> 快递 &nbsp;&nbsp;</p>
</li>
<li><h4>支付方式：</h4><p>
<input type="radio" id="radio-2-1" name="radio-2-set" class="myradiobox" checked /><label for="radio-2-1"></label> 微信支付 &nbsp;&nbsp;</p>
</li>

<li><h4>商品列表：</h4>
<%
    if (this.CartOrder != null)
    {
        foreach (OrderProduct op in this.CartOrder.productlist)
        {
%>
<dl>
<dt> 
<a href="javascript:void(0)"><%= op.productinfo.productname %></a> 
</dt>
<dd>x <%= op.count %></dd>
<dd class="listnumyuan">&yen;<%= op.price %></dd>
</dl>
    <% }
    } %>

<article>共 <%= this.CartOrder.productcount %> 件商品 邮费：<span>&yen;<%= this.CartOrder.postage.ToString() %></span> &nbsp; 合计：<span>&yen;<%= this.CartOrder.productprice + this.CartOrder.postage %></span></article>

</li>

<li><h4>订单附言：</h4><p>
<input name="postscript" type="text" id="txtordermessage" class="fuyan" placeholder="请输入订单附言(限50字)" runat="server">
</li>

</ul>
  </section>
</main>






<!-- 结算s -->
<section class="ettlego">
<ul>
<li>需支付：<span>&yen;<%= this.CartOrder.productprice + this.CartOrder.postage %></span></li>
<li>
    <asp:LinkButton runat="server" ID="lnkBuy" Text="提交订单" OnClick="lnkBuy_Click" />
</li>
</ul>
</section>
<!-- 结算e -->

<!-- 底部菜单s -->
<footer class="footer">
<a href="productcategory.aspx"><i class="footer-category"></i>分类</a>
<a href="search.aspx"><i class="footer-search"></i>搜索</a>
<a href="index.aspx"><i class="footer-home"></i>首页</a> <!-- 如是当前页a里加id="active" -->
<a href="cart.aspx" id="active"><i class="footer-cart"></i>购物车<span id="cartnum"><%= ShopCartNumber %></span></a> <!-- 如果购物车没数据就不显示<span id="cartnum">3</span> -->
<a href="user.aspx"><i class="footer-user"></i>我的</a>
</footer>
<!-- 底部菜单e -->
    <script type="text/javascript">
        $(document).ready(function () {
            //if (<%= ShopCartNumber %> == 0)
            $("#cartnum").hide();
        });
        function form_check() {
            if (document.getElementById("txtcustomername").value == "") {
                alert("请填写收货人姓名！");
                return false;
            }
            else if (document.getElementById("txttel").value == "") {
                alert("请填写手机号码！");
                return false;
            }
            else if (document.getElementById("txtaddress").value == "") {
                alert("请填写收货地址！");
                return false;
            }
            else {
                return true;
            }
        } 
    </script>
</form>
</body>
</html>
