using System;
using System.Data;
using System.Web.UI;

using OdnShop.Core.Common;
using OdnShop.Core.Factory;
using OdnShop.Core.Model;
using OdnShop.Core.Business;
namespace OdnShop.Web.backend
{
    public partial class productedit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Security.CheckAdministerAndRedirect();
            if (!Page.IsPostBack)
            {
                LoadProductCategorys();
                LoadProductInfo();
            }
        }

        private void LoadProductCategorys()
        {
            this.ddlProductCategory.DataTextField = "categoryname";
            this.ddlProductCategory.DataValueField = "categoryid";
            this.ddlProductCategory.DataSource = ProductCategoryFactory.GetAll();
            this.ddlProductCategory.DataBind();
        }

        private void LoadProductInfo()
        {
            if (this.Action == "edit")
            {
                int productid = HYRequest.GetQueryInt("productid", 0);
                ProductModel info = ProductFactory.Get(productid);

                this.txtincludepicpath.Text = info.includepicpath;
                this.txtprice.Text = info.price.ToString();
                this.txtitemprice.Text = info.itemprice;
                this.txtproductname.Text = info.productname;
                this.txtsalecount.Text = info.salecount.ToString();
                this.txtproductcount.Text = info.productcount.ToString();
                //this.txtspecification.Text = info.specification;
                this.chkiscommend.Checked = info.iscommend == 1 ? true : false;

                this.editorcontent.Value = info.specification;

                try
                {
                    this.rblproductcode.Items.FindByValue(info.productcode.ToString()).Selected = true;
                    this.ddlProductCategory.Items.FindByValue(info.categoryid.ToString()).Selected = true;
                }
                catch { }

                if (info.productpics.Length > 5)
                {
                    string[] picarr = info.productpics.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("picsrc", typeof(System.String));

                    foreach (string pic in picarr)
                    {
                        DataRow dr = dt.NewRow();
                        dr["picsrc"] = pic;

                        dt.Rows.Add(dr);
                    }

                    this.rptAlbumList.DataSource = dt;
                    this.rptAlbumList.DataBind();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Action == "add")
            {
                ProductModel info = new ProductModel();

                info.salecount = Int32.Parse( this.txtsalecount.Text.Trim() );
                info.productcount = Int32.Parse(this.txtproductcount.Text.Trim());
                info.productname = this.txtproductname.Text;
                info.price = Decimal.Parse( this.txtprice.Text.Trim());
                info.itemprice = this.txtitemprice.Text;
                info.includepicpath = this.txtincludepicpath.Text.Trim();
                info.createtime = DateTime.Now;
                info.categoryid = Int32.Parse(this.ddlProductCategory.SelectedItem.Value);
                info.iscommend = this.chkiscommend.Checked ? 1 : 0;
                info.productcode = Int32.Parse( this.rblproductcode.SelectedValue );
                info.specification = this.editorcontent.Value;

                //产品相册
                string[] albumArr = Request.Form.GetValues("hid_photo_name");
                if (albumArr.Length > 0)
                {
                    string pics = string.Empty;
                    string dotstr = "";
                    foreach (string sp in albumArr)
                    {
                        pics += dotstr + sp;
                        dotstr = "|";
                    }

                    info.productpics = pics;
                }

                ProductFactory.Add(info);
            }
            else if (this.Action == "edit")
            {
                int productid = HYRequest.GetQueryInt("productid", 0);
                ProductModel info = ProductFactory.Get(productid);

                info.salecount = Int32.Parse(this.txtsalecount.Text.Trim());
                info.productcount = Int32.Parse(this.txtproductcount.Text.Trim());
                info.productname = this.txtproductname.Text;
                info.price = Decimal.Parse(this.txtprice.Text.Trim());
                info.itemprice = this.txtitemprice.Text;
                info.includepicpath = this.txtincludepicpath.Text.Trim();
                info.createtime = DateTime.Now;
                info.categoryid = Int32.Parse(this.ddlProductCategory.SelectedItem.Value);
                info.iscommend = this.chkiscommend.Checked ? 1 : 0;
                info.productcode = Int32.Parse(this.rblproductcode.SelectedValue);
                info.specification = this.editorcontent.Value;

                //产品相册
                string[] albumArr = Request.Form.GetValues("hid_photo_name");
                if (albumArr.Length > 0)
                {
                    string pics = string.Empty;
                    string dotstr = "";
                    foreach (string sp in albumArr)
                    {
                        pics += dotstr + sp;
                        dotstr = "|";
                    }

                    info.productpics = pics;
                }

                ProductFactory.Update(info);
            }

            ClientScript.RegisterStartupScript(this.GetType(), "AddEditTips", "<script language=\"javascript\">window.location='productlist.aspx';</script>");
        }

        private string Action
        {
            get
            {
                return HYRequest.GetQueryString("action");
            }
        }
    }
}
