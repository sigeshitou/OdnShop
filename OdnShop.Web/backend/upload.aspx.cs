using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;

using OdnShop.Core.Common;
using OdnShop.Core.Factory;
using OdnShop.Core.Model;
namespace OdnShop.Web.backend
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OdnShop.Core.Business.Security.CheckAdministerAndRedirect();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.FileUpload1.FileContent.Length > 0)
            {
                //文件存放规则：attachments + 年月 + 文件名+ 后缀
                string fileext = Path.GetExtension(this.FileUpload1.FileName).ToLower();
                string filename = Utils.GetRandomFilename(this.FileUpload1.FileName);

                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();

                string rootPath = Path.Combine("/attachments", year.ToString() + month.ToString());
                rootPath = Server.MapPath(rootPath);

                if (!Directory.Exists(rootPath))
                    Directory.CreateDirectory(rootPath);

                //保存文件的路径
                string savePath = Path.Combine(rootPath, filename);

                this.FileUpload1.SaveAs(savePath);

                //Thumbnail.MakeThumbnailImage(

                //需返回到父页面的路径
                string returnPath = string.Format("/{0}/{1}{2}/{3}", "attachments", year, month, filename); //string.Format("{0}{1}/{2}", year, month, filename);
                string parentobj = HYRequest.GetString("parentobj");
                ClientScript.RegisterStartupScript(this.GetType(), "UpfileTips", "<script language=\"javascript\">window.parent.opener.document.getElementById(\"" + parentobj + "\").value=\"" + returnPath + "\";window.close();</script>");
            }
        }
    }
}
