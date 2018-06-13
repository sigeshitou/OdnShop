using System;
using System.Web.UI;


using OdnShop.Core.Common;
using OdnShop.Core.Factory;
using OdnShop.Core.Model;
using OdnShop.Core.Business;
namespace OdnShop.Web.backend
{
    public partial class linkedit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Security.CheckAdministerAndRedirect();
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Action == "add")
            {
                LinkModel info = new LinkModel();
                info.possymbol = possymbol;
                info.includepic = this.txtincludepic.Text.Trim();
                info.linkurl = this.txtlinkurl.Text.Trim();
                info.orderno = Int32.Parse(this.txtorderno.Text.Trim());
                info.linkname = this.txttitle.Text.Trim();
                info.createtime = DateTime.Now;

                LinkFactory.Add(info);

                ClientScript.RegisterStartupScript(this.GetType(), "AddEditTips", "<script language=\"javascript\">alert('添加成功！');window.location='linklist.aspx?pb="+possymbol+"';</script>");
            }
            else if (this.Action == "edit")
            {
                int linkid = HYRequest.GetInt("linkid", 0);
                LinkModel info = LinkFactory.Get(linkid);

                info.includepic = this.txtincludepic.Text.Trim();
                info.linkurl = this.txtlinkurl.Text.Trim();
                info.orderno = Int32.Parse(this.txtorderno.Text.Trim());
                info.linkname = this.txttitle.Text.Trim();

                LinkFactory.Update(info);
                ClientScript.RegisterStartupScript(this.GetType(), "AddEditTips", "<script language=\"javascript\">alert('修改成功！');window.location='linklist.aspx?pb="+possymbol+"';</script>");
            }
        }

        public string possymbol
        {
            get
            {
                return HYRequest.GetQueryString("pb");
            }
        }

        private void LoadData()
        {
            if (this.Action == "edit")
            {
                int linkid = HYRequest.GetInt("linkid", 0);
                LinkModel info = LinkFactory.Get(linkid);

                this.txtincludepic.Text = info.includepic;
                this.txtlinkurl.Text = info.linkurl;
                this.txtorderno.Text = info.orderno.ToString();
                this.txttitle.Text = info.linkname;
            }
        }

        private string Action
        {
            get
            {
                return HYRequest.GetString("action");
            }
        }
    }
}
