<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="OdnShop.Web.backend.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=uft-8" />
    <title>main</title>
    <link href="images/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        <!
        -- body
        {
            padding: 10px;
        }
        -- ></style>
</head>
<body>
    <h3 class="boxtitle">
        后台管理 &gt;&gt; 系统信息</h3>
    <div class="box">
       您好：<asp:Literal runat="server" ID="ltlUsername" />　[ <a href="adminedit.aspx?action=edit&adminid=<%= LoginAdminid %>">修改密码</a> ]
    </div>
    <div class="box">
        服务器类型：<%= SiteServerInfo.ServerOS %><br />
        脚本解析引擎：<%= SiteServerInfo.DotNetVersion %><br />
    </div>
    <div class="box">
        程序名称：OdnShop V1.2<br />
        程序官网：<a href="https://gitee.com/keke11/OdnShop" target="_blank">https://gitee.com/keke11/OdnShop</a><br />
    </div>
</body>
</html>
