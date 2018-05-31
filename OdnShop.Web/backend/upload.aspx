<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="OdnShop.Web.backend.upload" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>文件上传</title>
<link href="images/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
body { padding:10px }
-->
</style>
</head>
</head>
<body>
<form id="Form1" runat="server">
<h3 class="boxtitle">后台管理 &gt;&gt; 文件上传</h3>
<table height="0" border="0" cellpadding="0" cellspacing="1" class="tabBgColor">
<tr align="center">
  <td height="25" background="Images/Top.gif"></td>
</tr>
</table>
  <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1">
    <tr>
      <td width="18%" align="center" class="tdbg">选择文件：</td>
      <td class="tdbg"><asp:FileUpload ID="FileUpload1" runat="server" Width="95%" CssClass="input" /></td>
    </tr>
    <tr class="tdbg" style="display:none">
      <td align="center">缩图选项：      </td>
      <td>暂无</td>
    </tr>
    <tr class="tdbg">
	  <td>&nbsp;</td>
      <td><asp:Button runat="server" Text="上 传" ID="btnSave" CssClass="bnt" onclick="btnSave_Click" /></td>
    </tr>
	
  </table>
  
</form>
</body>
</html>