<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productedit.aspx.cs" Inherits="OdnShop.Web.backend.productedit" ValidateRequest="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>产品管理</title>
<link href="images/style.css?v=201709010954" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="demo.css" media="all">
<style type="text/css">
<!--
body { padding:10px }
-->
</style>
    <script type="text/javascript" charset="utf-8" src="images/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="images/jquery/Validform_v5.3.2_min.js"></script>
    <link rel="stylesheet" href="editor/themes/default/default.css" />
	<link rel="stylesheet" href="editor/plugins/code/prettify.css" />
	<script charset="utf-8" src="editor/kindeditor.js" type="text/javascript"></script>
	<script charset="utf-8" src="editor/lang/zh_CN.js" type="text/javascript"></script>
	<script charset="utf-8" src="editor/plugins/code/prettify.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="images/webuploader.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="images/uploader.js"></script>
	<script type="text/javascript">
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#editorcontent', {
	            cssPath: 'editor/plugins/code/prettify.css',
	            uploadJson: 'editor/upload_json.ashx',
	            fileManagerJson: 'editor/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=Form1]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=Form1]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	</script>
<script type="text/javascript">
    KindEditor.ready(function (K) {
        var uploadbutton = K.uploadbutton({
            button: K('#uploadButton')[0],
            fieldName: 'imgFile',
            url: 'editor/upload_json.ashx',
            afterUpload: function (data) {
                if (data.error === 0) {
                    var txtincludepicpath = K.formatUrl(data.url, 'absolute');
                    K('#txtincludepicpath').val(txtincludepicpath);
                } else {
                    alert(data.message);
                }
            },
            afterError: function (str) {
                alert('自定义错误信息: ' + str);
            }
        });
        uploadbutton.fileBox.change(function (e) {
            uploadbutton.submit();
        });
    });

    $(function () {
        //初始化表单验证
        //$("#form1").initValidform();

        $(".upload-album").InitUploader({ btntext: "批量上传", multiple: true, water: true, thumbnail: true, filesize: "1024", sendurl: "../tools/upload_ajax.ashx", swf: "images/uploader.swf" });
        //设置封面图片的样式
        $(".photo-list ul li .img-box img").each(function () {
            if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                $(this).parent().addClass("selected");
            }
        });
    });

</script>
</head>
<body>
<form id="Form1" runat="server">
<h3 class="boxtitle">后台管理 &gt;&gt; 产品管理</h3>
<table height="0" border="0" cellpadding="0" cellspacing="1" class="tabBgColor">
<tr>
  <td height="25" background="Images/Top.gif"></td>
</tr>
</table>
  <table width="98%" border="0" align="center" cellpadding="3" cellspacing="1" id="tagContent0">
	<tr>
      <td width="100" align="center" class="tdbg">产品名称：      </td>
      <td  class="tdbg"><asp:TextBox runat="server" ID="txtproductname" CssClass="input" Width="270px" />
      </td>
    </tr>
    <tr class="tdbg" id="sdcms_pic">
      <td align="center" >产品封面图：</td>
      <td><asp:TextBox runat="server" ID="txtincludepicpath" name="txtincludepicpath" CssClass="inputs" Width="270px" /> <input type="button" id="uploadButton" value="上传" />  <span></span></td>
    </tr>
    <tr>
      <td align="center" class="tdbg">产品相册：      </td>
      <td  class="tdbg">
      <div class="upload-box upload-album"></div>
      <input type="hidden" name="hidFocusPhoto" id="hidFocusPhoto" runat="server" class="focus-photo" />
      <div class="photo-list">
        <ul>
          <asp:Repeater ID="rptAlbumList" runat="server">
            <ItemTemplate>
            <li>
              <input type="hidden" name="hid_photo_name" value="<%#Eval("picsrc")%>" />
              <div class="img-box" onclick="setFocusImg(this);">
                <img src="<%#Eval("picsrc")%>" bigsrc="<%#Eval("picsrc")%>" />
              </div>
              <a href="javascript:;" onclick="delImg(this);">删除</a>
            </li>
            </ItemTemplate>
          </asp:Repeater>
        </ul>
      </div>
      </td>
    </tr>
	<tr>
      <td  align="center" class="tdbg">产品分类：      </td>
      <td class="tdbg"><asp:DropDownList runat="server" ID="ddlProductCategory" DataTextField="categoryname" DataValueField="categoryid"></asp:DropDownList> <asp:CheckBox runat="server" ID="chkiscommend"  /><label for="t6">推荐产品</label></td>
    </tr>
    <tr>
      <td align="center" class="tdbg">产品状态：      </td>
      <td  class="tdbg">
      <asp:RadioButtonList runat="server" ID="rblproductcode" RepeatLayout="Flow" RepeatDirection="Horizontal">
         <asp:ListItem Text="上架产品" Value="1" Selected="True" />
         <asp:ListItem Text="下架产品" Value="0" />
      </asp:RadioButtonList>
      </td>
    </tr>
    <tr>
      <td align="center" class="tdbg">销量：      </td>
      <td  class="tdbg"><asp:TextBox runat="server" ID="txtsalecount" CssClass="input" Width="150px" Text="0" />　<span>初始销量，成功付款会自动增量，用于显示；</span></td>
    </tr>
    <tr>
      <td align="center" class="tdbg">库存：      </td>
      <td  class="tdbg"><asp:TextBox runat="server" ID="txtproductcount" CssClass="input" Width="150px" Text="0" />　<span>库存量，成功付款后会自动减量，用于显示；</span></td>
    </tr>
    <tr>
      <td align="center" class="tdbg">市场单价：      </td>
      <td  class="tdbg"><asp:TextBox runat="server" ID="txtprice" CssClass="input" Width="150px" /> <span></span></td>
    </tr>
    <tr style="display:none">
      <td align="center" class="tdbg">属性价格：      </td>
      <td  class="tdbg"><asp:TextBox runat="server" ID="txtitemprice" CssClass="input" 
              Width="250px" TextMode="MultiLine" Rows="10" />
              <span>格式为：属性名称|价格 每行一个</span>
              </td>
    </tr>
    <tr class="tdbg">
      <td align="center">产品详情：      </td>
      <td valign="top">
        <textarea name="editorcontent" id="editorcontent" style="width:700px;height:460px;visibility:hidden;" runat="server"></textarea>
      </td>
    </tr>
  </table>  
<table width="98%" border="0" align="center" cellpadding="3" cellspacing="1" >
    <tr class="tdbg">
	  <td width="100">&nbsp;</td>
      <td><asp:Button runat="server" CssClass="bnt" Text="保存" ID="btnSave" onclick="btnSave_Click" /> </td>
	  </tr>
  </table>
</form>
</body>
</html>