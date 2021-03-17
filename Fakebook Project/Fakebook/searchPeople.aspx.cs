using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Search_people : System.Web.UI.Page
{
    static PagedDataSource pg;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null || Session["User"] == "")
        {
            Response.Redirect("FirstPage.aspx");
            return;
        }
        if (!IsPostBack)
        {
            pg = new PagedDataSource();
            SearchRefresh();
        }
    }

    private void SearchRefresh()
    {
        if (Request["q"] != null)
        {
            string strSearch = Request["q"].ToString();
            DataSet ds = Users.GetAllUsers(strSearch);
            if (ds != null)
            {
                pg.DataSource = ds.Tables[0].DefaultView;
                pg.AllowPaging = true;
                pg.PageSize = 5;
                searchPeopleList.DataSource = pg;
                searchPeopleList.DataBind();
            }
            else
            {
                lblNonFound.Visible = true;
            }
        }
        else
        {
            lblNonFound.Visible = true;
        }
    }

    protected void searchPeopleList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "AddClick")
        {
            int i = e.Item.ItemIndex;
            int id = int.Parse(((Image)(searchPeopleList.Items[i].FindControl("profileImage"))).AlternateText);
            FriendRequest add = new FriendRequest(((Users)Session["User"]).UserID, id, DateTime.Now);
            add.Insert();
            searchPeopleList.DataSource = pg;
            searchPeopleList.DataBind();
        }
        else if (e.CommandName == "DeleteClick")
        {
            int i = e.Item.ItemIndex;
            int id = int.Parse(((Image)(searchPeopleList.Items[i].FindControl("profileImage"))).AlternateText);
            FriendRequest.DeleteFriendRequest(id,((Users)Session["User"]).UserID);
            FriendRequest.DeleteFriendRequest(((Users)Session["User"]).UserID, id);
            Friendships.DeleteFriendship(((Users)Session["User"]).UserID, id);
            searchPeopleList.DataSource = pg;
            searchPeopleList.DataBind();
        }
        else if (e.CommandName == "NextPage")
        {
            if (pg.CurrentPageIndex + 1 < pg.PageCount)
            {
                pg.CurrentPageIndex++;
                searchPeopleList.DataSource = pg;
                searchPeopleList.DataBind();
            }
        }
        else if (e.CommandName == "PrevPage")
        {
            if (pg.CurrentPageIndex - 1 >= 0)
            {
                pg.CurrentPageIndex--;
                searchPeopleList.DataSource = pg;
                searchPeopleList.DataBind();
            }
        }
        else if (e.CommandName == "GoToProfile")
        {
            Response.Redirect((e.Item.FindControl("PersonLink") as HyperLink).NavigateUrl);
        }
    }
}