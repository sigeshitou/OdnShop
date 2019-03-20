<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vshopconfig.aspx.cs" Inherits="OdnShop.Web.backend.vshopconfig" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>微商城配置管理</title>
<link href="images/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
body { padding:10px }
-->
</style>
</head>
<body>
<form id="Form1" runat="server">
<h3 class="boxtitle">后台管理 &gt;&gt; 微商城设置</h3>
<table height="0" border="0" cellpadding="0" cellspacing="1" class="tabBgColor">
<tr align="left">
  <td height="25">
    管理导航：<a href="vshopconfig.aspx">基本信息设置</a> | <a href="linklist.aspx?pb=首页幻灯片">首页幻灯片</a>
  </td>
</tr>
</table>
  <table width="98%" border="0" align="center" cellpadding="3" cellspacing="1">
    <tr>
      <td width="12%" align="center" class="tdbg">商城名称：      </td>
      <td class="tdbg"><asp:TextBox runat="server" ID="txtShopName" CssClass="input" /></td>
    </tr>
    <tr>
      <td width="12%" align="center" class="tdbg">联系地址：      </td>
      <td class="tdbg"><asp:TextBox runat="server" ID="txtShopAddress" CssClass="input" /></td>
    </tr>
    <tr>
      <td width="12%" align="center" class="tdbg">联系电话：      </td>
      <td class="tdbg"><asp:TextBox runat="server" ID="txtShopTel" CssClass="input" /></td>
    </tr>
    <tr>
      <td width="12%" align="center" class="tdbg">消费送积分：      </td>
      <td class="tdbg"><asp:TextBox runat="server" ID="txtMoneyToJfRate" CssClass="input" />(消费一元钱送的积分数)</td>
    </tr>
    <tr>
      <td width="12%" align="center" class="tdbg">商城LOGO地址：      </td>
      <td class="tdbg"><asp:TextBox runat="server" ID="txtShopLogo" CssClass="input" /></td>
    </tr>
    <tr>
      <td width="12%" align="center" class="tdbg">快递邮费：      </td>
      <td class="tdbg"><asp:TextBox runat="server" ID="txtPostAge" CssClass="input" />（0表示免邮）</td>
    </tr>
    <tr>
      <td width="12%" align="center" class="tdbg">免邮额：      </td>
      <td class="tdbg"><asp:TextBox runat="server" ID="txtFreePostAge" CssClass="input" />（免邮费得消费额，0表示无）</td>
    </tr>
    <tr>
      <td width="12%" align="center" class="tdbg">首页优品推荐数量：      </td>
      <td class="tdbg"><asp:TextBox runat="server" ID="txtHomeCommendProductCount" CssClass="input" /></td>
    </tr>
    <tr>
      <td width="12%" align="center" class="tdbg">首页最新上架数量：      </td>
      <td class="tdbg"><asp:TextBox runat="server" ID="txtHomeLatestProductCount" CssClass="input" /></td>
    </tr>
    <tr class="tdbg">
	  <td>&nbsp;</td>
      <td><asp:Button runat="server" Text="保 存" ID="btnSave" CssClass="bnt" onclick="btnSave_Click" /></td>
    </tr>
	
  </table>

</form>
</body>
</html>
