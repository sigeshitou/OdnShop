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

using OdnShop.Core.Common;
using OdnShop.Core.Factory;
using OdnShop.Core.Model;
namespace OdnShop.Web.backend
{
    public partial class memberlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OdnShop.Core.Business.Security.CheckAdministerAndRedirect();
            if (!Page.IsPostBack)
            {
                this.LoadListData();
            }
        }

        private void LoadListData()
        {
            //int totalcount = 0;
            this.dgUserList.DataSource = AdminFactory.GetAll() ;
            this.dgUserList.DataBind();
        }

        protected void dgUserList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            

            if (e.CommandArgument.ToString() == "DeleteInfo")
            {
                int dataKey = Convert.ToInt32(this.dgUserList.DataKeys[e.Item.ItemIndex]);
                AdminFactory.Delete(dataKey);

                this.LoadListData();
            }
        }

        protected void dgUserList_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Attributes.Add("bgcolor", "#ffffff");
                e.Item.Attributes.Add("onmouseover", @"this.bgColor='#EBFFDC';");
                e.Item.Attributes.Add("onmouseout", @"this.bgColor='#ffffff';");

                ((LinkButton)e.Item.FindControl("lnkDelete")).Attributes.Add("onclick", @"javascript:return confirm('提示:删除后不可恢复．\r\n确定删除？');");
            }
        }
    }
}
