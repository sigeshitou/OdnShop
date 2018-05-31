<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminedit.aspx.cs" Inherits="OdnShop.Web.backend.memberedit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>管理员管理</title>
<link href="images/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
body { padding:10px }
-->
</style>
</head>
<body>
<form id="Form1" runat="server">
<h3 class="boxtitle">后台管理 &gt;&gt; 管理员管理</h3>
<table height="0" border="0" cellpadding="0" cellspacing="1" class="tabBgColor">
<tr align="center">
  <td height="25" background="Images/Top.gif"><a href="adminlist.aspx">管理员管理</a></td>
</tr>
</table>
  <table width="98%" border="0" align="center" cellpadding="3" cellspacing="1">
    <tr>
      <td width="12%" align="center" class="tdbg">帐 户：      </td>
      <td class="tdbg"><asp:TextBox runat="server" ID="txtusername" CssClass="input" /></td>
    </tr>
    <tr class="tdbg">
      <td align="center">密 码：      </td>
      <td><asp:TextBox runat="server" ID="txtpassword" CssClass="input" /></td>
    </tr>
    <tr class="tdbg">
	  <td>&nbsp;</td>
      <td><asp:Button runat="server" Text="保 存" ID="btnSave" CssClass="bnt" onclick="btnSave_Click" /></td>
    </tr>
	
  </table>

</form>
</body>
</html>
