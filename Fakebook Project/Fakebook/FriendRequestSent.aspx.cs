using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class FriendRequestSent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null || Session["User"] == "")
        {
            Response.Redirect("FirstPage.aspx");
            return;
        }
        if (!IsPostBack)
        {
            FriendRequestRefresh();
        }
    }

    private void FriendRequestRefresh()
    {
        DataSet ds = FriendRequest.SentRequests(((Users)Session["User"]).UserID);
        DataList1.DataSource = ds;
        DataList1.DataBind();

        if (DataList1.Items.Count == 0)
        {
            lblResponse.Text = "No Sent Friend Requests";
        }
        else
            lblResponse.Text = "Friend Requests Sent";
    }

    protected void DataList1_ItemCommand1(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "DeleteClick")
        {
            int i = e.Item.ItemIndex;
            Image img = (Image)(DataList1.Items[i].FindControl("profileImage"));
            FriendRequest.DeleteFriendRequest(((Users)Session["User"]).UserID, int.Parse(img.AlternateText));
            FriendRequestRefresh();
        }
    }
}