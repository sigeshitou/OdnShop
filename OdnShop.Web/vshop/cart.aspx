<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="OdnShop.Web.vshop.cart" %>
<%@ Import Namespace="OdnShop.Core.Model" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>购物车-<%= shopconfig.ShopName %></title>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link href="images/style.css" rel="stylesheet" type="text/css" media="all" />
<link href="images/font-awesome.min.css" rel="stylesheet" type="text/css" media="all" />
<link href="images/flexslider.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="images/jquery.min.js"></script>
<script type="text/javascript" src="images/jquery-ui.min.js"></script>
<script type="text/javascript" src="images/switchable.js"></script>
</head>
<body>

<header class="topheader">
<div class="headerleft"><a href="javascript:history.go(-1)"><span>返回</span></a></div>
<div class="headercenter">
<h2>购物车</h2>
</div>
<div class="headeright"><a href="index.aspx"><span>首页</span></a></div>
</header>

<!-- 如果购物车为空,开始 -->
<asp:PlaceHolder runat="server" ID="phNoProduct">
<main class="main">
<div class="flownopro">
<img src="images/gwc.png" alt="">
<p>购物车什么都没有，赶快去购物吧</p>
<a type="button" href="productlist.aspx" class="btngobuy">去逛逛</a> 
</div>
</main>
</asp:PlaceHolder>
<!-- 购物车为空结束 -->

<!-- 购物车列表开始 -->
<main class="mainooo">
    <%
        if (this.CartOrder != null && this.CartOrder.productcount > 0)
        {
            int pchkid = 0;
            foreach (OrderProduct op in this.CartOrder.productlist)
            {
       %>
<section>
<div class="leftcar">
<input type="checkbox" id="pchk<%= pchkid %>" pid="<%= op.productinfo.productid %>" item="<%=op.item %>" class="mycheckbox"  <%= op.isselected ? "checked='checked'" : "" %> onchange="changeall(this)" /><label for="pchk<%= pchkid %>"></label>
</div>
<dl>
<dt>
<img src="<%= op.productinfo.includepicpath %>" alt="">
</dt>
<dd>
<h4><%= op.productinfo.productname %></h4>
<span>&yen;<%= op.price %></span> <%= op.item== string.Empty ? "":"<em>("+op.item+")</em>" %> <a class="modifyme" onClick="toshare()" style="display:none">修改</a>

<div class="changenumber">
<p><span onClick="change_goods_number('1',<%= pchkid %>)" >-</span><input type="hidden" id="back_number<%= pchkid %>" value="<%=op.count %>" /><input type="text" class="formnum"  name="<%= pchkid %>" id="goods_number<%= pchkid %>" autocomplete="off" value="<%=op.count %>" onFocus="back_goods_number(<%= pchkid %>)"  onblur="change_goods_number('2',<%= pchkid %>)" /><span onClick="change_goods_number('3',<%= pchkid %>)">+</span></p>
</div>
<article>
<a href="javascript:if (confirm('您确实要把该商品移出购物车吗？')) location.href='cart.aspx?action=del&pid=<%= op.productinfo.productid %>&item=<%= op.item %>';"><span>删除</span></a>
</article>
</dd>
</dl>
</section>
    <%
                pchkid++;
            }
        }
%>
</main>
<!-- 购物车列表结束 -->

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
<script>
function back_goods_number(id){
 var goods_number = document.getElementById('goods_number'+id).value;
  document.getElementById('back_number'+id).value = goods_number;
}
function change_goods_number(type, id)
{
    var goods_number = document.getElementById('goods_number' + id).value;
    var goods_selected = document.getElementById('pchk' + id).checked ? 1 : 0;
    var pid = $("#pchk" + id).attr("pid");
    var item = $("#pchk" + id).attr("item");
  if(type != 2){back_goods_number(id)}
  if(type == 1){goods_number--;}
  if(type == 3){goods_number++;}
  if(goods_number <=0 ){goods_number=1;}
  if(!/^[0-9]*$/.test(goods_number)){goods_number = document.getElementById('back_number'+id).value;}
  document.getElementById('goods_number'+id).value = goods_number;
    $.post('cart.aspx?action=ajaxupdate', {
        rec_id: pid, goods_number: goods_number, goods_selected: goods_selected, item: item
    }, function (data) {
        change_goods_number_response(data, id);
    }, 'json');
} 
//处理返回信息并显示
function change_goods_number_response(result,id)
{
	if (result.error == 0){
		var rec_id = result.rec_id;
		$("#goods_number_"+rec_id).val(result.goods_number);
		//document.getElementById('total_number').innerHTML = result.total_number;//更新数量
        document.getElementById('goods_subtotal').innerHTML = "&yen;" + result.total_desc;//更新小计
        document.getElementById('goods_postage').innerHTML = "邮费:&yen;" + result.postage;//更新邮费
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

<!-- 结算s -->
    <% if (this.CartOrder != null)
        { %>
<section class="ettle">
<ul>
<li><p><input type="checkbox" id="SelAll" name="SelAll" class="mycheckbox" onclick="SelectAll(this)" <%= this.CartOrder.selectallproduct ? "checked='checked'" : "" %> /><label for="SelAll"></label></p>全选</li>
<li>合计：<span id="goods_subtotal">&yen;<%= this.CartOrder == null ? 0 : this.CartOrder.productprice %></span> <em id="goods_postage">邮费:&yen;<%= this.CartOrder.postage == decimal.Zero ? "免邮" : this.CartOrder.postage.ToString() %></em></li>
<li><a href="ordercheck.aspx?orderno=<%= this.CartOrder.orderno %>" id="gotopaylink">结算</a></li>
</ul>
</section>
    <% } %>
<!-- 结算e -->

<!-- 底部菜单s -->
<footer class="footer">
<a href="productcategory.aspx"><i class="footer-category"></i>分类</a>
<a href="search.aspx"><i class="footer-search"></i>搜索</a>
<a href="index.aspx"><i class="footer-home"></i>首页</a> <!-- 如是当前页a里加id="active" -->
<a href="cart.aspx" id="active"><i class="footer-cart"></i>购物车</a> <!-- 如果购物车没数据就不显示<span id="cartnum">3</span> -->
<a href="user.aspx"><i class="footer-user"></i>我的</a>
</footer>
<!-- 底部菜单e -->
    <script type="text/javascript">
        function SelectAll(theBox) {
            var elm = document.getElementsByTagName("input");
            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && elm[i].name != theBox.name) {
                    elm[i].checked = theBox.checked;
                }

            selall_change_selected(theBox.checked);
            if (theBox.checked) {
                $("#gotopaylink").removeAttr("onclick");
            }
            else
            { $("#gotopaylink").attr("onclick", "alert('请至少选择一个产品!');return false;");}
        }

        function changeall(theBox)
        {
            document.getElementById("SelAll").checked = true;
            var elm = document.getElementsByTagName("input");
            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && !elm[i].checked) {
                    document.getElementById("SelAll").checked = false;
                    break;
                }

            //change_selected(theBox.name.replace("pchk", ""));
            var pid = $("#"+theBox.id).attr("pid");
            var item = $("#"+theBox.id).attr("item");
            change_selected(theBox.id.replace("pchk", ""), pid, item);
            if (theBox.checked) {
                $("#gotopaylink").removeAttr("onclick");
            }
        }

        function change_selected(id, pid, item) {
            var goods_number = document.getElementById('goods_number' + id).value;
            var goods_selected = document.getElementById('pchk'+id).checked ? 1 : 0;
            $.post('cart.aspx?action=ajaxupdate', {
                rec_id: pid, goods_number: goods_number, goods_selected: goods_selected, item: item
            }, function (data) {
                document.getElementById('goods_subtotal').innerHTML = "&yen;" + data.total_desc;//更新小计
                document.getElementById('goods_postage').innerHTML = "邮费:&yen;" + data.postage;//更新邮费
                }, 'json');
        }

        function selall_change_selected(chk) {
            var goods_selected = chk ? 1 : 0;
            $.post('cart.aspx?action=ajaxupdateall', {
                goods_selected: goods_selected
            }, function (data) {
                document.getElementById('goods_subtotal').innerHTML = "&yen;" + data.total_desc;//更新小计
                document.getElementById('goods_postage').innerHTML = "邮费:&yen;" + data.postage;//更新邮费
            }, 'json');
        }

        <% if (this.CartOrder!=null && !this.CartOrder.hasselectproduct)
        { %>
        $("#gotopaylink").attr("onclick", "alert('请至少选择一个产品!');return false;");
        <%}%>
    </script>
</body>
</html>
