using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdnShop.Core.Factory;
using OdnShop.Core.Business;
namespace OdnShop.Web.backend
{
    public partial class userlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Security.CheckAdministerAndRedirect();
            if (!Page.IsPostBack)
            {
                LoadListData();
            }
        }

        private void LoadListData()
        {
            string ut = this.ddlusertype.SelectedValue;
            string searchkw = this.txtSearchKeyword.Text.Trim();

            string whereSql = string.Empty;
            if (ut != "0")
            {
                whereSql += " [usertype]=" + ut;
            }

            if (searchkw != string.Empty)
            {
                if (whereSql != string.Empty)
                {
                    whereSql += string.Format(" and (uid='{0}' or nickname like '%{0}%' or fullname like '%{0}%' or tel like '%{0}%' or address like '%{0}%')", searchkw);
                }
                else
                {
                    whereSql += string.Format(" uid='{0}' or nickname like '%{0}%' or fullname like '%{0}%' or tel like '%{0}%' or address like '%{0}%'", searchkw);
                }
            }

            if (whereSql != string.Empty)
                whereSql = " where " + whereSql;

            this.dgUserList.DataSource = UserFactory.GetList(whereSql); 
            this.dgUserList.DataBind();
        }

        protected void dgUserList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "DeleteInfo")
            {
                int dataKey = Convert.ToInt32(this.dgUserList.DataKeys[e.Item.ItemIndex]);
                UserFactory.Delete(dataKey);

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

                ((LinkButton)e.Item.FindControl("lnkDelete")).Attributes.Add("onclick", @"javascript:return confirm('提示:删除信息后不可恢复．\r\n确定删除？');");
            }
        }

        protected void dgUserList_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgUserList.CurrentPageIndex = e.NewPageIndex;
            this.LoadListData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.dgUserList.CurrentPageIndex = 0;
            this.LoadListData();
        }

        public string getusertypedesc(int usertype)
        {
            switch (usertype)
            {
                case 1:
                    return string.Empty; //"普通用户";
                case 10:
                    return "VIP用户";
                case 100:
                    return "代理商";

                default: return string.Empty; // "普通用户";
            }
        }
    }
}