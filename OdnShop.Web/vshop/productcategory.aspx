<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productcategory.aspx.cs" Inherits="OdnShop.Web.vshop.productcategory" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="OdnShop.Core.Factory" %>
<%@ Import Namespace="OdnShop.Core.Model" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title><%= shopconfig.ShopName %></title>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link href="images/style.css" rel="stylesheet" type="text/css" media="all" />
<link href="images/font-awesome.min.css" rel="stylesheet" type="text/css" media="all" />
<link href="images/flexslider.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="images/jquery.min.js"></script>
<script type="text/javascript" src="images/jquery-ui.min.js"></script>
<script type="text/javascript" src="images/switchable.js"></script>
</head>
<body>
<main class="mainall">
  <div class="mainleft" >
<ul>
<li class="active">全部分类</li>
    <%
        List<ProductCategoryModel> pcates = ProductCategoryFactory.GetListAll();
        foreach (ProductCategoryModel cat in pcates)
        {
            Response.Write(string.Format("<li>{0}</li>",cat.categoryname));
        }
        %>
</ul>
  </div>
  <div class="mainright">
<div class="blsit-list">

<li><!-- 全部分类下10个商品dl -->
    <%
        List<ProductModel> pageAllProducts = new List<ProductModel>();
        List<ProductModel> allP = ProductFactory.GetList(10, " where productcode=1 ");

        AddProductToList(pageAllProducts, allP);
        foreach (ProductModel pm in allP)
        {
        %>
<dl><dt><a href="productshow.aspx?id=<%= pm.productid %>"><img src="<%= pm.includepicpath %>" alt="" /></a></dt><dd><h3><%= pm.productname %></h3><span>&yen;<%= pm.price %></span><p class="add-to-cart" onClick="toshare(<%= pm.productid %>)"><span>添加到购物车</span></p></dd></dl>
<% } %>
<div class="mores"><a href="productlist.aspx">查看本分类全部商品</a></div>
</li>
    <%
        foreach (ProductCategoryModel cat in pcates)
        {

        %>
<li><!-- 分类下10个商品dl -->
<%
        //输出二级分类
        List<ProductCategoryModel> catelist = ProductCategoryFactory.GetListAll(cat.categoryid) ;
        int childcatecount = 0;
        foreach (ProductCategoryModel subcate in catelist)
        {
            childcatecount++;
            Response.Write(String.Format("<p><a class='clid' href='productlist.aspx?cid={0}'>{1}</a></p>", subcate.categoryid, subcate.categoryname));
        }

        allP = ProductFactory.GetList(10, string.Format(" where productcode=1 and categoryid={0} ",cat.categoryid));
        AddProductToList(pageAllProducts, allP);
        foreach (ProductModel pm in allP)
        {
        %>
<dl><dt><a href="productshow.aspx?id=<%= pm.productid %>"><img src="<%= pm.includepicpath %>" alt="" /></a></dt><dd><h3><%= pm.productname %></h3><span>&yen;<%= pm.price %></span><p class="add-to-cart" onClick="toshare(<%= pm.productid %>)"><span>添加到购物车</span></p></dd></dl>
<% } %>
<div class="mores"><a href="productlist.aspx?cid=<%= cat.categoryid %>">查看本分类全部商品</a></div>
</li>
    <% }%>
</div>
  </div>
</main>
<script type="text/javascript">
    $(function(){
       $(".mainleft li").on("mouseenter",function(){
         var index = $(this).index();
         $(this).addClass("active").siblings().removeClass("active"); 
         $(this).parents(".mainall").find(".blsit-list li").eq(index).show().siblings().hide();
       })
    })
</script>

<!-- 弹出购物车s -->
<script type="text/javascript">
    function toshare(pid) {
        $("#showproduct" + pid).addClass("am-modal-active");
        //$(".am-share").addClass("am-modal-active");
        if ($(".sharebg").length > 0) {
            $(".sharebg").addClass("sharebg-active");
        } else {
            $("body").append('<div class="sharebg"></div>');
            $(".sharebg").addClass("sharebg-active");
        }
        $(".sharebg-active,.share_btn").click(function () {
            $("#showproduct" + pid).removeClass("am-modal-active");
            //$(".am-share").removeClass("am-modal-active");
            setTimeout(function () {
                $(".sharebg-active").removeClass("sharebg-active");
                $(".sharebg").remove();
            }, 300);
        })
    }	
</script>
<%
    foreach(ProductModel pm in pageAllProducts)
    { 
%>
<div class="am-share" id="showproduct<%=pm.productid%>">
<dl>
<dt><img src="<%= pm.includepicpath %>" alt=""/></dt>
<dd>
<h4><%= pm.productname %></h4>
<span id="showprice<%# Eval("productid")%>">&yen;<%= pm.price %></span>
<p>库存：<%= pm.productcount %></p>
<!--规格属性-->
    <div class="iteminfo_buying" style="<%= pm.itemprice == "" ? "display:none" : "" %>">
        <div class="sys_item_spec">
            <dl class="iteminfo_parameter sys_item_specpara" data-sid="<%=pm.productid%>">
                <dt>属性<input type="hidden" id="itemvalue<%=pm.productid%>" /></dt>
                <dd>
                    <ul class="sys_spec_img">
                    <%= getitems(pm.itemprice,"showprice"+pm.productid) %>
                    </ul>
                </dd>
            </dl>
        </div>
    </div>
<!--规格属性-->,
</dd>
</dl>

<div class="changegoodsnumber">
<h4>数量：</h4><p><span onClick="change_goods_number('1',<%= pm.productid %>)" >-</span><input type="hidden" id="back_number<%= pm.productid %>" value="1" /><input type="text" class="formnum"  name="<%= pm.productid %>" id="goods_number<%= pm.productid %>" autocomplete="off" value="1" onFocus="back_goods_number(<%= pm.productid %>)"  onblur="change_goods_number('2',<%= pm.productid %>)" /><span onClick="change_goods_number('3',<%= pm.productid %>)">+</span></p>
</div>

<ul class="gocartli">
<ul class="gocartli">
<li><a href="javascript:void(0)" onclick="addtocart(<%= pm.productid %>);">加入购物车</a></li>
<li><a href="cart.aspx?action=add&pid=<%= pm.productid %>" id="gotobuy<%= pm.productid %>">立即购买</a></li>
</ul>
</ul>

<button class="share_btn"><span>取消</span></button>
</div>
    <%} %>
<script>
function back_goods_number(id){
 var goods_number = document.getElementById('goods_number'+id).value;
  document.getElementById('back_number'+id).value = goods_number;
}
function change_goods_number(type, id)
{
  var goods_number = document.getElementById('goods_number'+id).value;
  if(type != 2){back_goods_number(id)}
  if(type == 1){goods_number--;}
  if(type == 3){goods_number++;}
  if(goods_number <=0 ){goods_number=1;}
  if(!/^[0-9]*$/.test(goods_number)){goods_number = document.getElementById('back_number'+id).value;}
  document.getElementById('goods_number'+id).value = goods_number;
	$.post('/mobile/index.php?m=default&c=flow&a=ajax_update_cart', {
		rec_id : id,goods_number : goods_number
	}, function(data) {
		change_goods_number_response(data,id);
	}, 'json');  
} 
// 处理返回信息并显示
function change_goods_number_response(result,id)
{
	if (result.error == 0){
		var rec_id = result.rec_id;
		$("#goods_number_"+rec_id).val(result.goods_number);
		document.getElementById('total_number').innerHTML = result.total_number;//更新数量
		document.getElementById('goods_subtotal').innerHTML = result.total_desc;//更新小计
		if (document.getElementById('ECS_CARTINFO')){
			//更新购物车数量
			document.getElementById('ECS_CARTINFO').innerHTML = result.cart_info;
		}
	}else if (result.message != ''){
		alert(result.message);
		var goods_number = document.getElementById('back_number'+id).value;
 		document.getElementById('goods_number'+id).value = goods_number;
	}                
}

	/*点击下拉手风琴效果*/
	$('.collapse').collapse()
	$(".checkout-select a").click(function(){
		if(!$(this).hasClass("select")){
			$(this).addClass("select");
		}else{	
			$(this).removeClass("select");
		}
	});
	
</script>
<!-- 弹出购物车e -->



<!-- 底部菜单s -->
<footer class="footer">
<a href="productcategory.aspx" id="active"><i class="footer-category"></i>分类</a><!-- 如是当前页a里加id="active" -->
<a href="search.aspx"><i class="footer-search"></i>搜索</a>
<a href="index.aspx"><i class="footer-home"></i>首页</a>
<a href="cart.aspx"><i class="footer-cart"></i>购物车<span id="cartnum"><%= ShopCartNumber %></span></a> <!-- 如果购物车没数据就不显示<span>6</span> -->
<a href="user.aspx"><i class="footer-user"></i>我的</a>
</footer>
<!-- 底部菜单e -->
<!-- 返回顶部s -->
<script type="text/javascript" src="images/move-top.js"></script>
<script type="text/javascript" src="images/easing.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $().UItoTop({ easingType: 'easeOutQuart' });
        if (<%= ShopCartNumber %> == 0)
            $("#cartnum").hide();
    });

    function addtocart(id) {
        var itemflag = 0;
        //if ($(".sys_item_spec .sys_item_specpara").attr("data-attrval") != "undefined")
        //    itemflag = $(".sys_item_spec .sys_item_specpara").attr("data-attrval");

        if ($("#itemvalue" + id).val() != "")
            itemflag = $("#itemvalue" + id).val();

        var buycount = document.getElementById('goods_number' + id).value;
        $.post('cart_ajax.aspx?action=addtocart', {
            pid: id, buycount: buycount, itemflag: itemflag
        }, function (data) {
            $("#cartnum").html(data.shopcount);
        }, 'json');

        $("#cartnum").show();

        $("#showproduct" + id).removeClass("am-modal-active");
        //$(".am-share").removeClass("am-modal-active");
        setTimeout(function () {
            $(".sharebg-active").removeClass("sharebg-active");
            $(".sharebg").remove();
        }, 300);
    }
</script>
<script>
    //商品规格选择
    $(function () {
        $(".sys_item_spec .sys_item_specpara").each(function () {
            var i = $(this);
            var p = i.find("ul>li");
            p.click(function () {
                if (!!$(this).hasClass("selected")) {
                    $(this).removeClass("selected");
                    i.removeAttr("data-attrval");
                    $("#itemvalue" + i.attr("data-sid")).val(0);
                    $("#gotobuy" + i.attr("data-sid")).attr("href", "cart.aspx?action=add&pid=" + i.attr("data-sid") + "&buycount=" + $("#goods_number" + i.attr("data-sid")).val());
                } else {
                    $(this).addClass("selected").siblings("li").removeClass("selected");
                    i.attr("data-attrval", $(this).attr("data-aid"));
                    $("#itemvalue" + i.attr("data-sid")).val($(this).attr("data-aid"));
                    $("#gotobuy" + i.attr("data-sid")).attr("href", "cart.aspx?action=add&pid=" + i.attr("data-sid") + "&itemflag=" + $(this).attr("data-aid") + "&buycount=" + $("#goods_number" + i.attr("data-sid")).val());
                }
            })
        })
    })
</script>
<a href="#head" id="toTop" style="display: block;"> <span id="toTopHover" style="opacity:1;"> </span></a>
<!-- 返回顶部e -->
</body>
</html>
