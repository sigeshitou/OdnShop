<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_fav.aspx.cs" Inherits="OdnShop.Web.vshop.user_fav" %>
<%@ Import Namespace="OdnShop.Core.Common" %>
<%@ Import Namespace="OdnShop.Core.Model" %>
<%@ Import Namespace="OdnShop.Core.Factory" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>我的收藏-<%= shopconfig.ShopName %></title>
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
<h2>我收藏的商品</h2>
</div>
<div class="headerightsetup"><a href="user_profile.aspx"><span>设置</span></a></div>
</header>

<main class="userfav">
<!-- 可以30条为一页 -->
<%
    int totalcount = 0;
    int pageindex = HYRequest.GetQueryInt("p",1);
    List<FavoriteModel> favlist = FavoriteFactory.GetListByUid(this.LoginUser.uid, 30, 1, out totalcount);
    foreach (FavoriteModel fm in favlist)
    {
    %>
<dl id="fav<%= fm.fid %>">
<dt>
<a href="productshow.aspx?id=<%= fm.productid %>"><img src="<%= fm.product.includepicpath %>" alt=""></a>
</dt>
<dd>
<h4><a href="productshow.aspx?id=<%= fm.productid %>"><%= fm.product.productname %></a></h4>
<span>&yen;<%= fm.product.price %></span>
<article>
<a href="javascript:void(0)" onClick="delfav(<%= fm.fid %>)"><span>删除</span></a>
</article>
</dd>
</dl>
    <% } %>

<div class="showpagesg">
<%
    Utils.BuildPager(totalcount, 30, pageindex, "user_fav.aspx?p={0}");
%>
</div>

</main>


<!-- 底部菜单s -->
<footer class="footer">
<a href="productcategory.aspx"><i class="footer-category"></i>分类</a>
<a href="search.aspx"><i class="footer-search"></i>搜索</a>
<a href="index.aspx"><i class="footer-home"></i>首页</a> 
<a href="cart.aspx"><i class="footer-cart"></i>购物车<span id="cartnum"><%= ShopCartNumber %></span></a>
<a href="user.aspx" id="active"><i class="footer-user"></i>我的</a><!-- 如是当前页a里加id="active" -->
</footer>
<!-- 底部菜单e -->
    <script type="text/javascript">
        $(document).ready(function () {
            if (<%= ShopCartNumber %> == 0)
            $("#cartnum").hide();
        });

        function delfav(id) {
            $.post('cart_ajax.aspx?action=delfav', {
                fid: id
            }, function (data) {
                //alert($("#fav" + id));
                }, 'json');
            $("#fav" + id).attr("style", "display:none");
        }
    </script>
</body>
</html>
