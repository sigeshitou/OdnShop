<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlist.aspx.cs" Inherits="OdnShop.Web.backend.memberlist" %>

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
</head>
<body>
<form id="Form1" runat="server">
<h3 class="boxtitle">后台管理 &gt;&gt; 管理员管理</h3>
<table height="0" border="0" cellpadding="0" cellspacing="1" class="tabBgColor">
<tr align="center">
  <td height="25" background="Images/Top.gif"><a href="adminedit.aspx?action=add">添加管理员</a></td>
</tr>
</table>
  <asp:DataGrid runat="server" ID="dgUserList" AutoGenerateColumns="false" 
            BorderWidth="1" HorizontalAlign="Center" CellPadding="3" CellSpacing="1" 
            CssClass="boxtd" HeaderStyle-CssClass="title_bg" 
            FooterStyle-BackColor="#ffffff" FooterStyle-HorizontalAlign="Center" FooterStyle-Height="33"
            UseAccessibleHeader="true" ShowFooter="false" ShowHeader="true" 
            DataKeyField="adminid" onitemcommand="dgUserList_ItemCommand" 
      onitemcreated="dgUserList_ItemCreated">
     <Columns>
        <asp:TemplateColumn HeaderText="Adminid" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "adminid")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="管理员名称" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "username")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="类型" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center" Visible="false">
           <ItemTemplate>
              网站管理员
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="操作" ItemStyle-HorizontalAlign="Center">
             <ItemTemplate>
                <a href='adminedit.aspx?action=edit&adminid=<%# DataBinder.Eval(Container.DataItem, "adminid")%>'>修改密码</a> | 
                <asp:LinkButton runat="server" ID="lnkDelete" CommandArgument="DeleteInfo" Text="删除" />
             </ItemTemplate>
          </asp:TemplateColumn>
     </Columns>
  </asp:DataGrid>  
  </form>
</body>
</html>

