<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="linklist.aspx.cs" Inherits="OdnShop.Web.backend.linklist" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>链接管理</title>
<link href="images/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
body { padding:10px }
-->
</style>
<script language="javascript" type="text/javascript">
function SelectAll(theBox)
{
    var elm=document.Form1.elements;
    for(i=0;i<elm.length;i++)
    if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
    {
        elm[i].checked=theBox.checked ;
    }
}

function CheckDeleteHandle(btn)
{
    var elm=document.Form1.elements;
    var flag = false ;
    for(i=0;i<elm.length;i++) 
    if(elm[i].type=="checkbox")
    {
        if (elm[i].checked)
        {
          flag = true ;
          break ;
        }
    }
    
    if (flag)
    { 
        return confirm('是否要删除选择的链接？') ;
    }
    else
    {
        alert("你没有选择任何链接，请选择！") ;
        return false ;
    }
}
</script>
</head>
<body>
<form id="Form1" runat="server">
<h3 class="boxtitle">后台管理 &gt;&gt; <%= possymbol %>管理</h3>
<table height="0" border="0" cellpadding="0" cellspacing="1" class="tabBgColor">
<tr align="left">
  <td height="25">
    管理导航：<a href="vshopconfig.aspx">基本信息设置</a> | <a href="linklist.aspx?pb=首页幻灯片">首页幻灯片</a> | <a href="singlepageedit.aspx?action=edit&pageid=2">关于我们</a>
  </td>
</tr>
</table>
  <asp:DataGrid runat="server" ID="dgLinkList" AutoGenerateColumns="false" 
            BorderWidth="1" HorizontalAlign="Center" CellPadding="3" CellSpacing="1" 
            CssClass="boxtd" HeaderStyle-CssClass="title_bg" 
            FooterStyle-BackColor="#ffffff" FooterStyle-HorizontalAlign="Center" FooterStyle-Height="33"
            UseAccessibleHeader="true" ShowFooter="false" ShowHeader="true" 
            DataKeyField="linkid" onitemcommand="dgLinkList_ItemCommand" 
        onitemcreated="dgLinkList_ItemCreated">
<FooterStyle HorizontalAlign="Center" BackColor="White" Height="33px"></FooterStyle>
      <PagerStyle Mode="NumericPages" />
     <Columns>
        <asp:TemplateColumn HeaderText="选择" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <asp:CheckBox runat="server" ID="chkIsSelect" />
           </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Height="33px"></ItemStyle>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="名称" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "linkname")%>
           </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Height="33px"></ItemStyle>
        </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="排序号" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "orderno")%>
           </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Height="33px"></ItemStyle>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="链接URL" ItemStyle-Height="33" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <%# DataBinder.Eval(Container.DataItem, "linkurl")%>
           </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Height="33px"></ItemStyle>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="图片" ItemStyle-Height="33" HeaderStyle-Width="150" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
              <img src="<%# DataBinder.Eval(Container.DataItem, "includepic")%>" width="150" />
           </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Height="33px"></ItemStyle>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="操作" ItemStyle-HorizontalAlign="Center">
             <ItemTemplate>
                <a href='linkedit.aspx?action=edit&linkid=<%# DataBinder.Eval(Container.DataItem, "linkid")%>&pb=<%# DataBinder.Eval(Container.DataItem, "possymbol")%>'>
                 编辑</a>
                <asp:LinkButton runat="server" ID="lnkDelete" CommandArgument="DeleteInfo" Text="删除" Visible="false" />
             </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:TemplateColumn>
     </Columns>

<HeaderStyle CssClass="title_bg"></HeaderStyle>
  </asp:DataGrid> 
    <table border="0" align="center" cellpadding="3" cellspacing="1" class="table_b">
  <tr>
    <td colspan="9" class="tdbg" align="center">
    <asp:CheckBox runat="server" ID="chkSelectAll" ToolTip="全选/否选" />全选/否选 
        <asp:Button runat="server" ID="btnBatchDelete" Text="删除所选" 
            onclick="btnBatchDelete_Click" /> 
     </td>
  </tr>
  </table>
</form>
</body>
</html>
