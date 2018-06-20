<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productcategorylist.aspx.cs" Inherits="OdnShop.Web.backend.productcategorylist" %>
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
  <td height="25" background="Images/Top.gif"><a href="productcategoryedit.aspx?action=add">添加分类</a></td>
</tr>
</table>
  <asp:DataGrid runat="server" ID="dgProductCategoryList" AutoGenerateColumns="false" 
            BorderWidth="1" HorizontalAlign="Center" CellPadding="3" CellSpacing="1" 
            CssClass="boxtd" HeaderStyle-CssClass="title_bg" 
            FooterStyle-BackColor="#ffffff" FooterStyle-HorizontalAlign="Center" FooterStyle-Height="33"
            UseAccessibleHeader="true" ShowFooter="true" ShowHeader="true" 
            DataKeyField="categoryid" 
        oncancelcommand="dgProductCategoryList_CancelCommand" 
        oneditcommand="dgProductCategoryList_EditCommand" 
        onitemcommand="dgProductCategoryList_ItemCommand" 
        onitemcreated="dgProductCategoryList_ItemCreated" 
        onupdatecommand="dgProductCategoryList_UpdateCommand">
     <Columns>
        <asp:TemplateColumn HeaderText="ID" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "categoryid")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="分类名称" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "categoryname")%>
           </ItemTemplate>
           <EditItemTemplate>
              <asp:TextBox CssClass="input" runat="server" ID="txteditname" Text='<%# DataBinder.Eval(Container.DataItem, "categoryname")%>' />
           </EditItemTemplate>
           <FooterTemplate>
              <asp:TextBox CssClass="input" runat="server" ID="txtaddname" />
           </FooterTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="排序号" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "orderid")%>
           </ItemTemplate>
           <EditItemTemplate>
              <asp:TextBox CssClass="input" runat="server" ID="txteditorderid" Text='<%# DataBinder.Eval(Container.DataItem, "orderid")%>' />
           </EditItemTemplate>
           <FooterTemplate>
              <asp:TextBox CssClass="input" runat="server" ID="txtaddorderid" Text="0" />
           </FooterTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="操作" ItemStyle-HorizontalAlign="Center">
             <ItemTemplate>
                <a href='productcategoryedit.aspx?action=edit&categoryid=<%# DataBinder.Eval(Container.DataItem, "categoryid")%>'>编辑</a> | 
                <asp:LinkButton runat="server" ID="lnkDelete" CommandArgument="DeleteInfo" Text="删除" />
             </ItemTemplate>
             <FooterTemplate>
                <asp:LinkButton runat="server" ID="lnkAdd" CommandArgument="AddInfo" Text="添加" />
             </FooterTemplate>
          </asp:TemplateColumn>
     </Columns>
  </asp:DataGrid>
</form>
</body>
</html>
