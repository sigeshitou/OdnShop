<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlist.aspx.cs" Inherits="OdnShop.Web.backend.userlist" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>用户管理</title>
<link href="images/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
body { padding:10px }
-->
</style>
</head>
<body>
<form id="Form1" runat="server">
<h3 class="boxtitle">后台管理 &gt;&gt; 用户管理</h3>
<table height="0" border="0" cellpadding="0" cellspacing="1" class="tabBgColor">
<tr align="center">
  <td height="25">
  <!--用户类别：-->
  <asp:DropDownList ID="ddlusertype" runat="server" Visible="false">
     <asp:ListItem Text="所有类别" Value="0" Selected="True" />
     <asp:ListItem Text="普通用户" Value="1" />
     <asp:ListItem Text="VIP" Value="10" />
     <asp:ListItem Text="代理商" Value="100" />
  </asp:DropDownList>
  
  关键词：<asp:TextBox runat="server" ID="txtSearchKeyword" />
  <asp:Button runat="server" ID="btnSearch" Text="搜索" onclick="btnSearch_Click" />
  </td>
</tr>
</table>
  <asp:DataGrid runat="server" ID="dgUserList" AutoGenerateColumns="false" 
            BorderWidth="1" HorizontalAlign="Center" CellPadding="3" CellSpacing="1" 
            CssClass="boxtd" HeaderStyle-CssClass="title_bg" 
            FooterStyle-BackColor="#ffffff" 
    FooterStyle-HorizontalAlign="Center" FooterStyle-Height="33"
            UseAccessibleHeader="true" ShowFooter="false" ShowHeader="true" 
            DataKeyField="uid" onitemcommand="dgUserList_ItemCommand" 
      onitemcreated="dgUserList_ItemCreated" AllowPaging="True" 
    onpageindexchanged="dgUserList_PageIndexChanged">
      <PagerStyle Mode="NumericPages" CssClass="showpage" />
     <Columns>
        <asp:TemplateColumn HeaderText="UID" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "uid")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="昵称" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "nickname")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="姓名" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "fullname")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="电话" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "tel")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="地址" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "address")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="积分" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "jfnum")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="操作" ItemStyle-HorizontalAlign="Center">
             <ItemTemplate>
                <a href="useredit.aspx?uid=<%# DataBinder.Eval(Container.DataItem, "uid")%>&action=edit">修改</a>
                | <asp:LinkButton runat="server" ID="lnkDelete" CommandArgument="DeleteInfo" Text="删除" />
             </ItemTemplate>
          </asp:TemplateColumn>
     </Columns>
  </asp:DataGrid>
  </form>
</body>
</html>