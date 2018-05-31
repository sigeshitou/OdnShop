<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="OdnShop.Web.backend.top" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<title>top</title>
<link href="images/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="top">
<h2>OdnShop管理后台</h2>
<ul>
<li><a href="/" target="_blank" onFocus="this.blur()">网站首页</a></li>
<li><a href="main.aspx" target="MainFrame" onFocus="this.blur()">后台首页</a></li>
<li><a href="adminlogout.aspx" target="_parent" onFocus="this.blur()">退出管理</a></li>
</ul>
</div>
<div id="mu">
<ul>
<li><a href="leftindex.aspx" target="MenuFrame" onFocus="this.blur()">微商城管理</a></li>
</ul>
</div>
</body>
</html>
