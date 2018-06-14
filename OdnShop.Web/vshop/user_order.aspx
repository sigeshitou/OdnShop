<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_order.aspx.cs" Inherits="OdnShop.Web.vshop.user_order" %>
<%@ Import Namespace="OdnShop.Core.Model" %>
<%@ Import Namespace="OdnShop.Core.Common" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>我的订单-<%= shopconfig.ShopName %></title>
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

<% int sarg = HYRequest.GetQueryInt("s",0) ; %>
<nav class="dingmu">
<ul>
<li><a <%= (sarg == 0 ? "id='activemu'":"") %> href="user_order.aspx">全部订单</a></li>
<li><a <%= (sarg == 1 ? "id='activemu'":"") %> href="user_order.aspx?s=1">待付款</a></li>
<li><a <%= (sarg == 2 ? "id='activemu'":"") %> href="user_order.aspx?s=2">已付款</a></li>
</ul>
</nav>

<main class="userding">
<!-- 可以10条为一页 -->
<ul>
<% if (OrderList != null)
    {
        foreach (OrderModel om in OrderList)
        { %>
<li><!-- 一个li为一个订单，一个订单可以有多个商品dl -->
<aside>
订单号：<%= om.orderno %> 状态：<strong><%= om.orderstatusdesc %></strong> <span><%= om.createtime.ToString("yyyy/MM/dd hh:mm:ss") %></span>
</aside>
<% foreach (OrderProduct op in om.productlist)
    { %>
<dl>
<dt>
<a href="javascript:void(0);"><img src="<%= op.productinfo.includepicpath %>" alt=""></a>
</dt>
<dd>
<h4><a href="javascript:void(0);"><%= op.productinfo.productname + (op.item == string.Empty ? "" : "(" + op.item + ")") %></a></h4>
<span>&yen;<%= op.price %></span> <em>数量 x<%= op.count %></em>
</dd>
</dl>
<% } %>
<p>
配送方式：<%= om.shippingdesc + "(" + om.deliverstatusdesc + ")" %> 支付方式：<%= om.paymentdesc %>
</p>
<p>总金额：<span>&yen;<%= om.productprice %></span></p>
<% if (om.orderstatus == 2 || om.orderstatus== 3)
    { %>
<article>
<a class="ordercancel" href="user_order.aspx?action=cancelorder&orderid=<%=om.orderid %>">取消订单</a>
<a class="orderbuy" href="ordercheck.aspx?orderno=<%=om.orderno %>">立即支付</a>
</article>
<% }%>
</li>
    <%}
        }%>
</ul>
<div class="showpagesg" style="display:none"><a href="">&lt;&lt;</a> <span>1</span> <a href="">2</a>  <a href="">3</a> <a href="">&gt;</a> <a href="">&gt;&gt;</a></div>
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
