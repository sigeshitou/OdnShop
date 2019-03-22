using System;
using System.Web.SessionState;
using System.Web;

using OdnShop.Core.Common;
using OdnShop.Core.Business;
using OdnShop.Core.UI;
namespace OdnShop.Web.tools
{
    /// <summary>
    /// upload_ajax 的摘要说明
    /// </summary>
    public class upload_ajax : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            Security.CheckAdministerAndCloseReq();

            //取得处事类型
            string action = HYRequest.GetQueryString("action");

            switch (action)
            {
                default: //普通上传
                    UpLoadFile(context);
                    break;
            }

        }

        #region 上传文件处理===================================
        private void UpLoadFile(HttpContext context)
        {
            //Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            string _delfile = HYRequest.GetString("DelFilePath");
            HttpPostedFile _upfile = context.Request.Files["Filedata"];
            bool _iswater = false; //默认不打水印
            bool _isthumbnail = false; //默认不生成缩略图

            if (HYRequest.GetQueryString("IsWater") == "1")
                _iswater = true;
            if (HYRequest.GetQueryString("IsThumbnail") == "1")
                _isthumbnail = true;
            if (_upfile == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"请选择要上传文件！\"}");
                return;
            }
            UpLoad upFiles = new UpLoad();
            string msg = upFiles.fileSaveAs(_upfile, _isthumbnail, _iswater);
            //删除已存在的旧文件，旧文件不为空且应是上传文件，防止跨目录删除
            if (!string.IsNullOrEmpty(_delfile) && _delfile.IndexOf("../") == -1
                && _delfile.ToLower().StartsWith(SiteConfig.Instance().FileUpLoadPath.ToLower()))
            {
                Utils.DeleteUpFile(_delfile);
            }
            //返回成功信息
            context.Response.Write(msg);
            context.Response.End();
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}