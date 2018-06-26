<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="OdnShop.Web.backend.adminlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=uft-8" />
<title>登录OdnShop</title>
<style type="text/css">

</style>
<link href="images/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="login">
<div id="tit"><h1>登陆OdnShop管理后台</h1></div>

<form id="Form2" runat="server">
<table width="100%" border="0" cellspacing="8" cellpadding="0">
  <tr>
    <td width="20%" align="right">账 号：</td>
    <td width="80%"><asp:TextBox runat="server" ID="txtusername" CssClass="input" 
              Width="192px" /></td>
  </tr>
  <tr>
    <td align="right">密 码：</td>
    <td><asp:TextBox runat="server" ID="txtpassword" CssClass="input" 
              TextMode="Password" Width="192px" />
      </td>
  </tr>

</table>
<p><asp:Button runat="server" Text="登 录" ID="btnSave" CssClass="bnt" onclick="btnSave_Click" /></p>
</form>
</div>

<div id="footer">
Copyright &copy;<a href="http://www.odnshop.com" target="_blank">OdnShop</a>  All Rights Reserved<br />
</div>
</body>
</html>