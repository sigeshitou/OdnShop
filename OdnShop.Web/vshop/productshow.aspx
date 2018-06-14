<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productshow.aspx.cs" Inherits="OdnShop.Web.vshop.productshow" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title><%= productinfo.productname %>-<%= shopconfig.ShopName %></title>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link href="images/style.css" rel="stylesheet" type="text/css" media="all" />
<link href="images/font-awesome.min.css" rel="stylesheet" type="text/css" media="all" />
<link href="images/flexslider.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="images/jquery.min.js"></script>
<script type="text/javascript" src="images/jquery-ui.min.js"></script>
<script type="text/javascript" src="images/switchable.js"></script>
</head>
<body>
<header id="pageheader">
<nav>
<p class="navleft"><a href="javascript:history.go(-1)"><span>返回</span></a></p>
<p class="navright"><a href="index.aspx"><span>首页</span></a></p>
</nav>
</header>

<!-- 三个产品图幻灯片s -->
<script type="text/javascript" src="images/jquery.flexslider-min.js"></script>
<script type="text/javascript">
$(function() {
    $(".flexslider").flexslider();
});	
</script>
<div class="flexslider">
<ul class="slides">
<%
    if (!String.IsNullOrEmpty(productinfo.productpics))
    {
        string[] pics = productinfo.productpics.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string picurl in pics)
        {
            Response.Write( string.Format("<li><img src=\"{0}\" /></li>",picurl) );
        }
    }
%>
</ul>
</div>
<!-- 三个产品图幻灯片e -->
<main class="mainpage">
<div class="prosay">
<dl>
<dt>
<h4><%= productinfo.productname %></h4>
<span>&yen;<%= productinfo.price %></span><del style="display:none">市场价：&yen;<%= productinfo.price %></del>
<p>库存：<%= productinfo.productcount %> &nbsp; 销量：<%= productinfo.salecount %></p>
</dt>
<dd>
    <% if (!IsFav)
        { %>
<a href="javascript:void(0)" onclick="addtofav(<%= productinfo.productid %>)" class="favme"></a><span id="favtip">收藏</span>
    <% } %>

</dd>
</dl>
</div>
</main>

<main class="mainpage">
<section<%= productinfo.moneytojf == 0 ? " style='display:none'" : "" %>>
<a href="javascript:void(0)">
<p><span>购买送积分：</span><%= productinfo.moneytojf %></p>
<i class="fa fa-angle-right fa-2x"></i>
</a>
</section>


<section>
<h4 class="">商品描述</h4>
</section>
</main>

<main class="mainpage">
<div class="probox">
<h3><%= productinfo.productname %></h3>
<!-- 产品详细s -->
<%= productinfo.specification %>
 <!-- 产品详细e -->     
</div>
</main>


<!-- 弹出购物车s -->
<script type="text/javascript">
	function toshare(){
		$(".am-share").addClass("am-modal-active");	
		if($(".sharebg").length>0){
			$(".sharebg").addClass("sharebg-active");
		}else{
			$("body").append('<div class="sharebg"></div>');
			$(".sharebg").addClass("sharebg-active");
		}
		$(".sharebg-active,.share_btn").click(function(){
			$(".am-share").removeClass("am-modal-active");	
			setTimeout(function(){
				$(".sharebg-active").removeClass("sharebg-active");	
				$(".sharebg").remove();	
			},300);
		})
	}	
</script>
<div class="am-share">
<dl>
<dt><img src="<%= productinfo.includepicpath %>" alt=""/></dt>
<dd>
<h4><%= productinfo.productname %></h4>
<span id="showprice<%=productinfo.productid%>">&yen;<%= productinfo.price %></span>
<p>库存：<%= productinfo.productcount %></p>
<!--规格属性-->
    <div class="iteminfo_buying" style="<%=productinfo.itemprice == "" ? "display:none" : "" %>">
        <div class="sys_item_spec">
            <dl class="iteminfo_parameter sys_item_specpara" data-sid="<%=productinfo.productid %>">
                <dt>属性<input type="hidden" id="itemvalue<%= productinfo.productid%>" /></dt>
                <dd>
                    <ul class="sys_spec_img">
                    <%= getitems(productinfo.itemprice,"showprice"+productinfo.productid) %>
                    </ul>
                </dd>
            </dl>
        </div>
    </div>
<!--规格属性-->
</dd>
</dl>

<div class="changegoodsnumber">
<h4>数量：</h4><p><span onClick="change_goods_number('1',<%= productinfo.productid %>)" >-</span><input type="hidden" id="back_number<%= productinfo.productid %>" value="1" /><input type="text" class="formnum"  name="<%= productinfo.productid %>" id="goods_number<%= productinfo.productid %>" autocomplete="off" value="1" onFocus="back_goods_number(<%= productinfo.productid %>)"  onblur="change_goods_number('2',<%= productinfo.productid %>)" /><span onClick="change_goods_number('3',<%= productinfo.productid %>)">+</span></p>
</div>

<ul class="gocartli">
<li><a href="javascript:void(0)" onclick="addtocart(<%= productinfo.productid %>);">加入购物车</a></li>
<li><a href="cart.aspx?action=add&pid=<%= productinfo.productid %>" id="gotobuy<%= productinfo.productid %>">立即购买</a></li>
</ul>

<button class="share_btn"><span>取消</span></button>
</div>
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
} 
//处理返回信息并显示
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

<footer class="profooter">
<ol>
<li><a href="index.aspx" class="forshop"><i></i><span>首页</span></a></li>
<li><a href="tel:<%= shopconfig.ShopTel %>" class="fortel"><i></i><span>客服</span></a></li>
</ol>
<ul>
<li><a href="javascript:void(0)" onClick="toshare()">加入购物车</a></li>
<li><a href="javascript:void(0)" onClick="toshare()">立即购买</a></li>
</ul>
</footer>

<!-- 返回顶部s -->
<script type="text/javascript" src="images/move-top.js"></script>
<script type="text/javascript" src="images/easing.js"></script>
<script type="text/javascript">
$(document).ready(function() {
$().UItoTop({ easingType: 'easeOutQuart' });
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
            //$("#cartnum").html(data.shopcount);
        }, 'json');

        $(".am-share").removeClass("am-modal-active");
        setTimeout(function () {
            $(".sharebg-active").removeClass("sharebg-active");
            $(".sharebg").remove();
        }, 300);
    }

    function addtofav(id)
    {
        $.post('cart_ajax.aspx?action=addtofav', {
            pid: id
        }, function (data) {
            $("#favtip").html(data.favtip);
        }, 'json');
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
