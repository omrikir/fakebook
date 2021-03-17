using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UsersManager : System.Web.UI.Page
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
            GridView1.AllowPaging = true;
            GridView1.PageSize = 5;
            GridView1.PagerSettings.Mode = PagerButtons.NumericFirstLast;
            RefreshGridview1();
        }
    }

    private void RefreshGridview1()
    {
        GridView1.DataSource = Users.GetAllUsers();
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        RefreshGridview1();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int userID = int.Parse(GridView1.Rows[e.RowIndex].Cells[9].Text);
        int x = Users.Delete(userID);
        GridView1.EditIndex = -1;
        RefreshGridview1();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        RefreshGridview1();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        RefreshGridview1();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string txtFirstName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        string txtLastName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
        string txtPassword= ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
        string txtEmail = GridView1.Rows[e.RowIndex].Cells[6].Text;
        string txtGender = GridView1.Rows[e.RowIndex].Cells[7].Text;
        DateTime birthday = DateTime.Parse(GridView1.Rows[e.RowIndex].Cells[8].Text);
        int userID = int.Parse(GridView1.Rows[e.RowIndex].Cells[9].Text);
        string profileImagePath = ((Image)GridView1.Rows[e.RowIndex].Cells[10].Controls[0]).ImageUrl;
        Users user = new Users(txtFirstName, txtLastName, txtEmail, txtPassword, txtGender, birthday, profileImagePath, userID);
        user.Update();
        if (user.UserID == ((Users)Session["User"]).UserID)
        {
            Session["User"] = user;
        }
        GridView1.EditIndex = -1;
        RefreshGridview1();
    }
}