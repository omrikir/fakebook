using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ChatMessages : System.Web.UI.Page
{
    public static int id;
    public static int items;
    public static PagedDataSource pg;

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
            items = 0;

            try
            {
                id = int.Parse(Request["id"]);
            }
            catch (Exception ex)
            {
                Response.Redirect("FakebookPage.aspx");
            }

            lblHeader.Text = "Chat With: " + Users.GetUser(id).FirstName + " " + Users.GetUser(id).LastName;

            if (Users.Exist(id) && id != ((Users)Session["User"]).UserID)
            {
                UpdateMessages();
            }
            else
                Response.Redirect("FakebookPage.aspx");
        }
    }

    public void UpdateMessages(int pageSize = 10)
    {
        try
        {
            id = int.Parse(Request["id"]);
        }
        catch (Exception ex)
        {
            Response.Redirect("FakebookPage.aspx");
        }
        DataSet ds = Messages.GetMessages(id, ((Users)Session["User"]).UserID);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            items = ds.Tables[0].Rows.Count;
            pg.DataSource = ds.Tables[0].DefaultView;
            pg.AllowPaging = true;
            pg.PageSize = pageSize;
            MessageList.DataSource = pg;
            MessageList.DataBind();
        }
    }

    public static string FormatText(string testString)
    {
        return testString.Replace("[/r/n];", "<br />");
    }

    protected void btnSubmitMessage_Click(object sender, EventArgs e)
    {
        if (txtMessage.Text != "")
        {
            try
            {
                id = int.Parse(Request["id"]);
            }
            catch (Exception ex)
            {
                Response.Redirect("FakebookPage.aspx");
            }
            string strPost = txtMessage.Text;
            strPost = strPost.Replace("'", "''");
            strPost = strPost.Replace("\r\n", "[/r/n];");
            Messages temp = new Messages(((Users)Session["User"]).UserID, id, DateTime.Now, @strPost);
            temp.Insert();
            UpdateMessages();
            txtMessage.Text = "";
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        UpdateMessages();
    }
    protected void tim_Tick(object sender, EventArgs e)
    {
        UpdateMessages();
    }
    protected void MessageList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "LoadMore")
        {
            DataList list = (DataList)source;
            DataSet ds = Messages.GetMessages(id, ((Users)Session["User"]).UserID);
            if (ds.Tables[0].Rows.Count > list.Items.Count)
            {
                UpdateMessages((list.Items.Count / 10) * 10 + 10);
            }
            
        }
    }
    //protected void timerRefresh_Tick(object sender, EventArgs e)
    //{
    //    int amount = int.Parse("" + Math.Ceiling(MessageList.Items.Count / 10.0) * 10);
    //    UpdateMessages(amount);
    //}
}