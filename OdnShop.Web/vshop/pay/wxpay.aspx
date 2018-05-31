<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wxpay.aspx.cs" Inherits="OdnShop.Web.vshop.pay.wxpay" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>微信支付</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link href="../images/style.css" rel="stylesheet" type="text/css" media="all" />
<link href="../images/font-awesome.min.css" rel="stylesheet" type="text/css" media="all" />
<link href="../images/flexslider.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../images/jquery.min.js"></script>
<script type="text/javascript" src="../images/jquery-ui.min.js"></script>
<script type="text/javascript" src="../images/switchable.js"></script>
    <script type="text/javascript">
               //调用微信JS api 支付
               function jsApiCall()
               {
                   WeixinJSBridge.invoke(
                   'getBrandWCPayRequest',
                   <%=wxJsApiParam%>,//josn串
                    function (res)
                    {
                        WeixinJSBridge.log(res.err_msg);
                        //alert(res.err_code + res.err_desc + res.err_msg);
                        if (res.err_msg == "get_brand_wcpay_request:ok") //支付成功
                        {
                            alert("微信支付已成功！");
                            window.location.href = "../user_order.aspx";
                        }
                     }
                    );
               }

               function callpay()
               {
                   if (typeof WeixinJSBridge == "undefined")
                   {
                       if (document.addEventListener)
                       {
                           document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
                       }
                       else if (document.attachEvent)
                       {
                           document.attachEvent('WeixinJSBridgeReady', jsApiCall);
                           document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
                       }
                   }
                   else
                   {
                       jsApiCall();
                   }
        }

               callpay();
               
     </script>
</head>
<body>

<header class="topheader">
<div class="headerleft"><a href="javascript:history.go(-1)"><span>返回</span></a></div>
<div class="headercenter">
<h2>订单支付</h2>
</div>
<div class="headeright"><a href="../index.aspx"><span>首页</span></a></div>

</header>

<main class="usernewspage">
<!-- 开始 -->
  <div class="articleinfo">
    <div class="articleinfocon">
        <asp:Literal runat="server" ID="ltlTips" />
    </div>
  </div>  
<!-- 结束 -->
</main>


<!-- 底部菜单s -->
<footer class="footer" style="display:none">
<a href="category.html"><i class="footer-category"></i>分类</a>
<a href="search.html"><i class="footer-search"></i>搜索</a>
<a href="index.html"><i class="footer-home"></i>首页</a> 
<a href="cart.html"><i class="footer-cart"></i>购物车<span id="cartnum">3</span></a> <!-- 如果购物车没数据就不显示<span id="cartnum">3</span> -->
<a href="user.html"><i class="footer-user"></i>我的</a><!-- 如是当前页a里加id="active" -->
</footer>
<!-- 底部菜单e -->
</body>
</html>
