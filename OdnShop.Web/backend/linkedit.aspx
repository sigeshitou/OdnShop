<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="linkedit.aspx.cs" Inherits="OdnShop.Web.backend.linkedit" %>
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
    <link rel="stylesheet" href="editor/themes/default/default.css" />
	<link rel="stylesheet" href="editor/plugins/code/prettify.css" />
	<script charset="utf-8" src="editor/kindeditor.js" type="text/javascript"></script>
	<script charset="utf-8" src="editor/lang/zh_CN.js" type="text/javascript"></script>
	<script charset="utf-8" src="editor/plugins/code/prettify.js" type="text/javascript"></script>
<script type="text/javascript">
			KindEditor.ready(function(K) {
				var uploadbutton = K.uploadbutton({
					button : K('#uploadButton')[0],
					fieldName : 'imgFile',
					url : 'editor/upload_json.ashx',
					afterUpload : function(data) {
						if (data.error === 0) {
							var txtincludepic = K.formatUrl(data.url, 'absolute');
							K('#txtincludepic').val(txtincludepic);
						} else {
							alert(data.message);
						}
					},
					afterError : function(str) {
						alert('自定义错误信息: ' + str);
					}
				});
				uploadbutton.fileBox.change(function(e) {
					uploadbutton.submit();
				});
			});
</script>
</head>
<body>
<form id="Form1" runat="server">
<h3 class="boxtitle">后台管理 &gt;&gt; <%= possymbol %>管理</h3>
<table height="0" border="0" cellpadding="0" cellspacing="1" class="tabBgColor">
<tr align="center">
  <td height="25" background="Images/Top.gif"></td>
</tr>
</table>
  <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="boxtd">
    <tr>
      <td width="12%" align="center" class="tdbg">名称：      </td>
      <td class="tdbg"><asp:TextBox ID="txttitle" runat="server" Width="433px" CssClass="input"></asp:TextBox></td>
    </tr>
    <tr class="tdbg">
      <td align="center">链接：      </td>
      <td><asp:TextBox ID="txtlinkurl" runat="server" Width="431px" CssClass="input"></asp:TextBox></td>
    </tr>
    <tr class="tdbg">
      <td align="center">图片：      </td>
      <td>
         <asp:TextBox ID="txtincludepic" runat="server" Width="430px" CssClass="input"></asp:TextBox>
        &nbsp;
        <input type="button" id="uploadButton" value="上传" />
      </td>
    </tr>
	<tr class="tdbg">
      <td align="center">排序：      </td>
      <td><asp:TextBox ID="txtorderno" runat="server" Width="223px" CssClass="input">50</asp:TextBox> 数字越小，越靠前</td>
    </tr>
    <tr class="tdbg">
	  <td>&nbsp;</td>
      <td><asp:Button runat="server" ID="btnSave" CssClass="bnt" Text="保 存" onclick="btnSave_Click" /> </td>
    </tr>
  </table>
</form>
</body>
</html>