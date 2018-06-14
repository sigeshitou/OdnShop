<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productlist.aspx.cs" Inherits="OdnShop.Web.vshop.productlist" %>
<%@ Import Namespace="System.Collections.Generic" %>
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
<style type="text/css">
body { padding-bottom:0; }
</style>
</head>
<body>
<header class="topheader">
<div class="headerleft"><a href="javascript:history.go(-1)"><span>返回</span></a></div>
<div class="headercenter">
<h2><%= CategoryName %></h2>
</div>
<div class="headeright"><a href="index.aspx"><span>首页</span></a></div>
</header>



<div class="pgaemu">
<ul>
<li class="active"><a href="?od=0">新品</a></li><!-- 点击到当前就加class active -->
<li><a href="?od=1">销量</a></li><!-- 点击到当前就加class active -->
<li><a href="?od=2">价格</a></li><!-- 点击到当前就加class active -->
<li class="chlass1" id="chicon" onClick="changeclass()"><span>改变布局</span></li>
</ul>
</div>

<script><!-- 点击变换列表样式js -->
function changeclass(){
if ($("#gallery-wrapper").attr("class")=="prolist")
  {
    $("#gallery-wrapper").attr("class","prolist2");
  }
  else
  {
    $("#gallery-wrapper").attr("class","prolist");
  }
  $("#").toggle();

  
if ($("#chicon").attr("class")=="chlass1")
  {
    $("#chicon").attr("class","chlass2");
  }
  else
  {
    $("#chicon").attr("class","chlass1");
  }
  $("#").toggle();  
}
</script>

<!-- 产品列表先显示12个，更多的下拉加载分页s -->
<div class="prolist" id="gallery-wrapper">
<ul>
<% foreach (ProductModel pm in listProducts)
    { %>
<li class="item">
<a href="productshow.aspx?id=<%=pm.productid%>"><img src="<%=pm.includepicpath%>" alt="item" /></a>
<h4><a href="productshow.aspx?id=<%=pm.productid%>"><%=pm.productname%></a></h4>
<span>&yen;<%=pm.price%></span>
<em>库存：<%=pm.productcount%> &nbsp; 销量：<%=pm.salecount%></em>
<p class="add-to-cart" onClick="toshare(<%=pm.productid%>)"><span>添加到购物车</span></p>
</li>
<% } %>
</ul>
<!-- 没有分页点击，改为下拉加载，详细查看最后js -->
<!-- 分页开始，说明：不能点击用span，能点击用a -->
<div class="showpage">
<%= pagerHtml %>
</div>
<!-- 分页end -->
</div>
<!-- 产品列表e -->

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
<% foreach (ProductModel pm in listProducts)
    { %>
<div class="am-share" id="showproduct<%=pm.productid%>">
<dl>
<dt><img src="<%=pm.includepicpath%>" alt=""/></dt>
<dd>
<h4><%=pm.productname%></h4>
<span id="showprice<%=pm.productid%>">&yen;<%=pm.price%></span>
<p>库存：<%=pm.productcount%></p>
<!--规格属性-->
    <div class="iteminfo_buying" style="<%= (pm.itemprice == "" ? "display:none" : "") %>">
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
<!--规格属性-->
</dd>
</dl>

<div class="changegoodsnumber">
<h4>数量：</h4><p><span onClick="change_goods_number('1',<%=pm.productid%>)" >-</span><input type="hidden" id="back_number<%=pm.productid%>" value="1" /><input type="text" class="formnum"  name="<%=pm.productid%>" id="goods_number<%=pm.productid%>" autocomplete="off" value="1" onFocus="back_goods_number(<%=pm.productid%>)"  onblur="change_goods_number('2',<%=pm.productid%>)" /><span onClick="change_goods_number('3',<%=pm.productid%>)">+</span></p>
</div>

<ul class="gocartli">
<li><a href="javascript:void(0)" onclick="addtocart(<%=pm.productid%>);">加入购物车</a></li>
<li><a href="cart.aspx?action=add&pid=<%=pm.productid%>" id="gotobuy<%=pm.productid%>">立即购买</a></li>
</ul>

<button class="share_btn"><span>取消</span></button>
</div>
<% } %>
<script>
    function back_goods_number(id) {
        var goods_number = document.getElementById('goods_number' + id).value;
        document.getElementById('back_number' + id).value = goods_number;
    }
    function change_goods_number(type, id) {
        var goods_number = document.getElementById('goods_number' + id).value;
        if (type != 2) { back_goods_number(id) }
        if (type == 1) { goods_number--; }
        if (type == 3) { goods_number++; }
        if (goods_number <= 0) { goods_number = 1; }
        if (!/^[0-9]*$/.test(goods_number)) { goods_number = document.getElementById('back_number' + id).value; }
        document.getElementById('goods_number' + id).value = goods_number;
    }
    // 处理返回信息并显示
    function change_goods_number_response(result, id) {
        if (result.error == 0) {
            var rec_id = result.rec_id;
            $("#goods_number_" + rec_id).val(result.goods_number);
            document.getElementById('total_number').innerHTML = result.total_number; //更新数量
            document.getElementById('goods_subtotal').innerHTML = result.total_desc; //更新小计
            if (document.getElementById('ECS_CARTINFO')) {
                //更新购物车数量
                document.getElementById('ECS_CARTINFO').innerHTML = result.cart_info;
            }
        } else if (result.message != '') {
            alert(result.message);
            var goods_number = document.getElementById('back_number' + id).value;
            document.getElementById('goods_number' + id).value = goods_number;
        }
    }

    /*点击下拉手风琴效果*/
    $('.collapse').collapse()
    $(".checkout-select a").click(function () {
        if (!$(this).hasClass("select")) {
            $(this).addClass("select");
        } else {
            $(this).removeClass("select");
        }
    });

</script>
<!-- 弹出购物车e -->

<!-- 返回顶部s -->
<script type="text/javascript" src="images/move-top.js"></script>
<script type="text/javascript" src="images/easing.js"></script>
<script type="text/javascript">
$(document).ready(function() {
$().UItoTop({ easingType: 'easeOutQuart' });
});
</script>
<a href="#head" id="toTop" style="display: block;"> <span id="toTopHover" style="opacity:1;"> </span></a>
<!-- 返回顶部e -->

<script><!-- 下拉加载更多 -->
var page=2;  
var finished=0;  
var sover=0;  
  
//如果屏幕未到整屏自动加载下一页补满  
//var setdefult=setInterval(function (){  
//    if(sover==1)  
//        clearInterval(setdefult);     
//    else if($("#gallery-wrapper").height()<$(window).height())
//        loadmore($(window));  
//    else  
//        clearInterval(setdefult);  
//},500);  
  
//加载完  
function loadover(){  
    if(sover==1)  
    {     
        var overtext="--- 我是有底线的 ---";  
        $(".loadmore").remove();  
        if($(".loadover").length>0)  
        {  
            $(".loadover span").eq(0).html(overtext);  
        }  
        else  
        {  
            var txt='<div class="loadover"><span>'+overtext+'</span></div>'  
            $("body").append(txt);  
        }  
    }  
}  
  
//加载更多  
var vid=0;  
function loadmore(obj){  
    if(finished==0 && sover==0)  
    {  
        var scrollTop = $(obj).scrollTop();  
        var scrollHeight = $(document).height();  
        var windowHeight = $(obj).height();  
          
        if($(".loadmore").length==0)  
        {  
            var txt='<div class="loadmore">加载中..</div>'  
            $("body").append(txt);  
        }  
          
        if (scrollTop + windowHeight -scrollHeight<=50 ) {  
            //此处是滚动条到底部时候触发的事件，在这里写要加载的数据，或者是拉动滚动条的操作  
             
            //防止未加载完再次执行  
            finished=1;  
              
            var result = "";  
            var timeStr = new Date().getTime();
            var loadurl = 'productlist.aspx?action=ajaxloadlist&v=' + timeStr + '&cid=<%=CagetoryId %>&p=';

            $.get(loadurl + page, {},
                function (data) {
                    result = data;
                });

//            setTimeout(function(){  
//                //$(".loadmore").remove();  
//                $('#gallery-wrapper').append(result);  
//                page+=1;  
//                finished=0;  
//                //最后一页  
//                if (result.length == 0 || page == 10)
//                //if(page==10)  
//                {  
//                    sover=1;  
//                    loadover();  
//                }  
//            },1000);  
        }  
    }  
}  
//页面滚动执行事件  
//$(window).scroll(function (){  
//    loadmore($(this));  
//});  
</script>
    <script type="text/javascript">
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
</body>
</html>
