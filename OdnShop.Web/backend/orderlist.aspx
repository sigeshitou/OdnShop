<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderlist.aspx.cs" Inherits="OdnShop.Web.backend.orderlist" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>订单管理</title>
<link href="images/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
body { padding:10px }
-->
</style>
<script language="javascript" type="text/javascript">
    function SelectAll(theBox) {
        var elm = document.Form1.elements;
        for (i = 0; i < elm.length; i++)
            if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                elm[i].checked = theBox.checked;
            }
    }

    function CheckDeleteHandle(btn) {
        var elm = document.Form1.elements;
        var flag = false;
        for (i = 0; i < elm.length; i++)
            if (elm[i].type == "checkbox") {
                if (elm[i].checked) {
                    flag = true;
                    break;
                }
            }

        if (flag) {
            return confirm('是否要删除选择的订单？');
        }
        else {
            alert("你没有选择任何订单，请选择！");
            return false;
        }
    }
</script>
</head>
<body>
<form id="Form1" runat="server">
<h3 class="boxtitle">后台管理 &gt;&gt; 订单管理</h3>
<table height="0" border="0" cellpadding="0" cellspacing="1" class="tabBgColor">
<tr align="center">
  <td height="25" background="Images/Top.gif">
  关键词：<asp:TextBox runat="server" ID="txtSearchKeyword" />
  <asp:Button runat="server" ID="btnSearch" Text="搜索" onclick="btnSearch_Click" /> (可以搜索姓名，电话，地址等)
  </td>
</tr>
<tr style="display:none">
  <td height="25" background="Images/Top.gif">
  <a href="orderlist.aspx?status=1">未取货订单</a> | <a href="orderlist.aspx?status=2">已取货订单</a>
  </td>
</tr>
</table>
  <asp:DataGrid runat="server" ID="dgOrderList" AutoGenerateColumns="false" 
            BorderWidth="1" HorizontalAlign="Center" CellPadding="3" CellSpacing="1" 
            CssClass="boxtd" HeaderStyle-CssClass="title_bg" 
            FooterStyle-BackColor="#ffffff" 
    FooterStyle-HorizontalAlign="Center" FooterStyle-Height="33"
            UseAccessibleHeader="true" ShowFooter="false" ShowHeader="true" 
            DataKeyField="orderid" AllowPaging="True" 
    onitemcommand="dgOrderList_ItemCommand" onitemcreated="dgOrderList_ItemCreated" 
    onpageindexchanged="dgOrderList_PageIndexChanged">
<FooterStyle HorizontalAlign="Center" BackColor="White" Height="33px"></FooterStyle>
      <PagerStyle Mode="NumericPages" />
     <Columns>
        <asp:TemplateColumn HeaderText="选择" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <asp:CheckBox runat="server" ID="chkIsSelect" CssClass="input" />
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="订单号" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "orderno")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="支付信息" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# getzhifuinfo(Container.DataItem) %>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="送货信息" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              联系信息：<%# DataBinder.Eval(Container.DataItem, "customername")%>/<%# DataBinder.Eval(Container.DataItem, "tel")%> <br />
              送货地址：<%# DataBinder.Eval(Container.DataItem, "address")%> <br />
              附加留言：<%# DataBinder.Eval(Container.DataItem, "ordermessage")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="下单时间" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "createtime")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="订单详细" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# getorderproductlist(DataBinder.Eval(Container.DataItem, "productlist"))%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="处理状态" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "deliverstatusdesc")%>
           </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="操作" ItemStyle-HorizontalAlign="Center">
             <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkChuhuo" CommandArgument="OrderChuhuo" Text="送货" /> | 
                <asp:LinkButton runat="server" ID="lnkShouhuo" CommandArgument="OrderShouhuo" Text="收货" />
             </ItemTemplate>
        </asp:TemplateColumn>
     </Columns>

<HeaderStyle CssClass="title_bg"></HeaderStyle>
  </asp:DataGrid> 
</form>
</body>
</html>
