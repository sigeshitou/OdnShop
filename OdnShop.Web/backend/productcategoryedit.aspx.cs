using System;
using System.Web.UI;
using System.Web.UI.WebControls;


using OdnShop.Core.Model;
using OdnShop.Core.Factory;
using OdnShop.Core.Common;
namespace OdnShop.Web.backend
{
    public partial class productcategoryedit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ddlParentCategory.DataTextField = "categoryname";
                this.ddlParentCategory.DataValueField = "categoryid";

                this.ddlParentCategory.DataSource = ProductCategoryFactory.GetAll(0);
                this.ddlParentCategory.DataBind();

                this.ddlParentCategory.Items.Insert(0, new ListItem("作为顶级分类", "0"));

                this.LoadCateData();

                int parentid = HYRequest.GetQueryInt("parentid", 0);
                if (parentid != 0)
                {
                    this.ddlParentCategory.Items.FindByValue(parentid.ToString()).Selected = true;
                }
            }
        }

        private void LoadCateData()
        {
            if (this.Action == "edit")
            {
                int categoryid = HYRequest.GetQueryInt("categoryid", 0);
                ProductCategoryModel cate = ProductCategoryFactory.Get(categoryid);
                if (cate != null)
                {
                    this.txtcategoryname.Text = cate.categoryname;
                    this.txtorderid.Text = cate.orderid.ToString();

                    this.ddlParentCategory.Items.FindByValue(cate.parentid.ToString()).Selected = true;
                }
            }
        }

        public string Action
        {
            get
            {
                return HYRequest.GetQueryString("action");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Action == "edit")
            {
                int categoryid = HYRequest.GetQueryInt("categoryid", 0);
                ProductCategoryModel cate = ProductCategoryFactory.Get(categoryid);
                cate.categoryname = this.txtcategoryname.Text.Trim();
                cate.orderid = Int32.Parse(this.txtorderid.Text.Trim());
                cate.parentid = Int32.Parse(this.ddlParentCategory.SelectedValue);

                ProductCategoryFactory.Update(cate);

                ClientScript.RegisterStartupScript(this.GetType(), "AddEditTips", "<script language=\"javascript\">alert('修改分类成功！');window.location='productcategorylist.aspx';</script>");
            }
            else if (this.Action == "add")
            {
                ProductCategoryModel cate = new ProductCategoryModel();
                cate.categoryname = this.txtcategoryname.Text.Trim();
                cate.orderid = Int32.Parse(this.txtorderid.Text.Trim());
                cate.parentid = Int32.Parse(this.ddlParentCategory.SelectedValue);

                ProductCategoryFactory.Add(cate);

                ClientScript.RegisterStartupScript(this.GetType(), "AddEditTips", "<script language=\"javascript\">alert('添加分类成功！');window.location='productcategorylist.aspx';</script>");
            }
        }
    }
}