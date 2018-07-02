<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productcategoryedit.aspx.cs" Inherits="OdnShop.Web.backend.productcategoryedit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>产品分类管理</title>
<link href="images/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
body { padding:10px }
-->
</style>
</head>
<body>
<form id="Form1" runat="server">
<h3 class="boxtitle">后台管理 &gt;&gt; 产品分类管理</h3>
<table height="0" border="0" cellpadding="0" cellspacing="1" class="tabBgColor">
<tr align="center">
  <td height="25" background="Images/Top.gif"></td>
</tr>
</table>
  <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="boxtd">
      <tr class="tdbg">
      <td align="center">上级分类：      </td>
      <td>
          <asp:DropDownList runat="server" ID="ddlParentCategory" />
      </td>
    </tr>
    <tr>
      <td width="12%" align="center" class="tdbg">分类名称：      </td>
      <td class="tdbg"><asp:TextBox ID="txtcategoryname" runat="server" Width="433px" CssClass="input"></asp:TextBox></td>
    </tr>
	<tr class="tdbg">
      <td align="center">排序号：      </td>
      <td><asp:TextBox ID="txtorderid" runat="server" Width="223px" CssClass="input">100</asp:TextBox> 数字越小，越靠前</td>
    </tr>
    <tr class="tdbg">
	  <td>&nbsp;</td>
      <td><asp:Button runat="server" ID="btnSave" CssClass="bnt" Text="保 存" onclick="btnSave_Click" /> </td>
    </tr>
  </table>
</form>
</body>
</html>
