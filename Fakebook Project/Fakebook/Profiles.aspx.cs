using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Profiles : System.Web.UI.Page
{
    public static bool friends;
    public static bool edit;
    public static int currentID;
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
            currentID = ID();

            if (Users.Exist(ID()))
            {
                //Request.QueryString["id"];
                friends = false;
                edit = false;

                //----Showing user's first name and last name in label
                Users user = Users.GetUser(ID());
                lblProfileName.Text = user.FirstName + " " + user.LastName;
                imgProfile.ImageUrl = user.ProfileImage;
                //

                postsList.Visible = false;
                lblFriend.Visible = false;
                btnEditProfile.Visible = false;
                btnAddFriend.Visible = false;
                btnDeleteFriend.Visible = false;
                btnGoToChat.Visible = false;
                btnConfirm.Visible = false;

                if (ID() == ((Users)Session["User"]).UserID)
                {
                    btnEditProfile.Visible = true;
                    btnAddFriend.Visible = false;
                }
                else
                {
                    if (!Friendships.ExistFriendship(((Users)Session["User"]).UserID, ID()) && !FriendRequest.ExistFriendRequest(((Users)Session["User"]).UserID, ID()))//לא חבר ולא שלח חברות
                    {
                        btnAddFriend.Visible = true;
                        txtPost.Enabled = false;
                        txtPost.Text = "You can't post on this person's wall";
                        btnSubmitPost.Enabled = false;
                    }
                    else
                    {
                        if (Friendships.ExistFriendship(((Users)Session["User"]).UserID, ID()))//כן חבר
                        {
                            lblFriend.Visible = true;
                            btnDeleteFriend.Text = "Delete Friendship";
                            btnDeleteFriend.Visible = true;
                            btnGoToChat.Visible = true;
                        }
                        else if (FriendRequest.GotFriendRequestFrom(((Users)Session["User"]).UserID, ID()))
                        {
                            btnDeleteFriend.Visible = true;
                            btnConfirm.Visible = true;
                            btnDeleteFriend.Text = "Cancel Friend Request";
                        }
                        else
                        {
                            btnDeleteFriend.Visible = true;
                            btnDeleteFriend.Text = "Delete Friend Request";
                        }
                    }

                }

                if (Request["friends"] != null)
                {
                    try
                    {
                        friends = bool.Parse(Request["friends"]);
                    }
                    catch
                    { Response.Redirect("FakebookPage.aspx"); }
                }
                if (Request["edit"] != null)
                {
                    try { edit = bool.Parse(Request["edit"]); }
                    catch { Response.Redirect("FakebookPage.aspx"); }
                }
                if (friends)
                {
                    ShowFriendList();
                }
                else if (edit && ID() == ((Users)Session["User"]).UserID)
                {
                    EditProfile();
                }
                else
                {
                    TimeLine();
                }
            }
            else
                Response.Redirect("FakebookPage.aspx");
        }
    }

    private int ID()
    {
        int id = -1;
        try
        {
            id = int.Parse(Request["id"]);
        }
        catch (Exception ex)
        {
            Response.Redirect("FakebookPage.aspx");
        }
        return id;
    }

    private void ShowFriendList()
    {
        panelFriendList.Visible = true;
        DataSet ds = Friendships.GetFriends(ID());
        if (ds != null)
        {
            pg.DataSource = ds.Tables[0].DefaultView;
            pg.AllowPaging = true;
            pg.PageSize = 5;
            friendList.DataSource = pg;
            friendList.DataBind();
        }
        else
        {
            lblNoFriends.Visible = true;
        }
    }

    private void LikedOnPost(int postID)
    {
        panelPostList.Visible = false;
        panelShowLiked.Visible = true;
        DataSet ds = Likes.GetAllLikes(postID);
        if (ds != null)
        {
            LikesList.Visible = true;
            LikesList.DataSource = ds;
            LikesList.DataBind();
            lblNoLikes.Text = "Who Liked This Post";
            lblAmountLikes.Text = "Like Count: " + Likes.LikesAmount(postID);
            lblAmountLikes.Visible = true;
        }
        else
        {
            lblNoLikes.Text = "No Likes On The Post";
            lblAmountLikes.Visible = false;
            LikesList.Visible = false;
        }
    }

    private void TimeLine()
    {
        postsList.Visible = true;
        panelPostNew.Visible = true;
        DataSet ds = Posts.GetAllPosts(ID());
        if (ds != null)
        {
            postsList.DataSource = ds;
            postsList.DataBind();
        }
        else
            lblNoPosts.Visible = true;
    }

    private void EditProfile()
    {
        panelUpdate.Visible = true;
        RefreshGridview1();
    }

    private void RefreshGridview1()
    {
        GridView1.DataSource = Users.GetDataSetUser(((Users)Session["User"]).UserID);
        GridView1.DataBind();
    }

    protected void btnUploadImage_Click(object sender, EventArgs e)
    {
        //Server.MapPath("~/App_Data/Database.mdf");
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Server.MapPath("~/Photos"));
        int count = dir.GetFiles().Length;
        if (FileUpload1.HasFile)
        {
            string strPathName = "Photos/" + count + "." + (FileUpload1.FileName).Split('.')[1];
            FileUpload1.SaveAs(Server.MapPath(strPathName));
            ((Users)Session["User"]).ProfileImage = strPathName;
            ((Users)Session["User"]).Update();
            Response.Redirect(Request.RawUrl);
        }
        else { Response.Write("<script>alert('Please select your file');</script>"); }

    }

    public static string FormatText(string testString)
    {
        return testString.Replace("[/r/n];", "<br />");
    }

    protected void btnSubmitPost_Click(object sender, EventArgs e)
    {
        if (txtPost.Text != "" && ((Users)Session["User"]).UserID == ID() || Friendships.ExistFriendship(((Users)Session["User"]).UserID, ID()))
        {
            string strPost = txtPost.Text;
            strPost = strPost.Replace("'", "''");
            strPost = strPost.Replace("\r\n", "[/r/n];");
            Posts temp = new Posts(((Users)Session["User"]).UserID, @strPost, DateTime.Now, -1, ID());
            temp.Insert();
            Response.Redirect(Request.RawUrl);
        }
    }
    protected void btnFriends_Click(object sender, EventArgs e)
    {
        Response.Redirect("Profiles.aspx?id=" + ID() + "&friends=true");
    }
    protected void btnTimeLine_Click(object sender, EventArgs e)
    {
        Response.Redirect("Profiles.aspx?id=" + ID());
    }
    protected void btnAddFriend_Click(object sender, EventArgs e)
    {
        FriendRequest add = new FriendRequest(((Users)Session["User"]).UserID, ID(), DateTime.Now);
        add.Insert();
        Response.Redirect(Request.RawUrl);
    }
    protected void btnEditProfile_Click(object sender, EventArgs e)
    {
        Response.Redirect("Profiles.aspx?id=" + ID() + "&edit=true");
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        RefreshGridview1();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        RefreshGridview1();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string txtFirstName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        string txtLastName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        string txtPassword = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        string txtEmail = GridView1.Rows[e.RowIndex].Cells[4].Text;
        string txtGender = GridView1.Rows[e.RowIndex].Cells[5].Text;
        DateTime birthday = DateTime.Parse(GridView1.Rows[e.RowIndex].Cells[6].Text);
        int userID = ((Users)Session["User"]).UserID;
        string profileImagePath = ((Users)Session["User"]).ProfileImage;
        Users user = new Users(txtFirstName, txtLastName, txtEmail, txtPassword, txtGender, birthday, profileImagePath, userID);
        user.Update();
        if (user.UserID == ((Users)Session["User"]).UserID)
        {
            Session["User"] = user;
        }
        GridView1.EditIndex = -1;
        RefreshGridview1();
        Response.Redirect(Request.RawUrl);
    }

    protected void postsList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "DeletePost")
        {
            int i = e.Item.ItemIndex;
            Label lbl = (Label)(postsList.Items[i].FindControl("lblPostID"));
            Posts.DeletePost(int.Parse(lbl.Text));
            Response.Redirect(Request.RawUrl);
        }
        else if (e.CommandName == "AddPostComment")
        {
            int i = e.Item.ItemIndex;
            if (((TextBox)((DataList)source).Items[i].FindControl("txtComment")).Text != "")
            {
                string content = ((TextBox)postsList.Items[i].FindControl("txtComment")).Text.Replace("'", "''");
                content = content.Replace("\r\n", "[/r/n];");
                Posts temp = new Posts(((Users)Session["User"]).UserID, content, DateTime.Now, -1, -1, int.Parse(((Label)((DataList)source).Items[i].FindControl("lblPostID")).Text));
                temp.Insert();
                Response.Redirect(Request.RawUrl);
            }
        }
        else if (e.CommandName == "LikePost")
        {
            int i = e.Item.ItemIndex;
            int postID = int.Parse(((Label)(postsList.Items[i].FindControl("lblPostID"))).Text);
            int userID = ((Users)Session["User"]).UserID;
            if(!Likes.LikeExist(postID,userID))//Like
                new Likes(postID,userID,DateTime.Now).Insert();
            else
                Likes.DeleteLike(-1,userID,postID);

            Response.Redirect(Request.RawUrl);
        }
        else if (e.CommandName == "ShowLiked")
        {
            int i = e.Item.ItemIndex;
            int postID = int.Parse(((Label)(postsList.Items[i].FindControl("lblPostID"))).Text);
            LikedOnPost(postID);
        }
    }
    protected void commentList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "DeleteComment")
        {
            int i = e.Item.ItemIndex;
            Label lbl = (Label)(((DataList)source).Items[i].FindControl("lblPostID"));
            Posts.DeletePost(int.Parse(lbl.Text));
            Response.Redirect(Request.RawUrl);
        }
        else if (e.CommandName == "AddPostComment")
        {
            int i = e.Item.ItemIndex;
            if (((TextBox)((DataList)source).Items[i].FindControl("txtComment")).Text != "")
            {
                string content = ((TextBox)((DataList)source).Items[i].FindControl("txtComment")).Text.Replace("'", "''");
                content = content.Replace("\r\n", "[/r/n];");
                Posts temp = new Posts(((Users)Session["User"]).UserID, content, DateTime.Now, -1, -1, int.Parse(((Label)((DataList)source).Items[i].FindControl("lblPostID")).Text));
                temp.Insert();
                Response.Redirect(Request.RawUrl);
            }
        }
        else if (e.CommandName == "LikePost")
        {
            int i = e.Item.ItemIndex;
            int postID = int.Parse(((Label)(((DataList)source).Items[i].FindControl("lblPostID"))).Text);
            int userID = ((Users)Session["User"]).UserID;
            if (!Likes.LikeExist(postID, userID))//Like
                new Likes(postID, userID, DateTime.Now).Insert();
            else
                Likes.DeleteLike(-1, userID, postID);

            Response.Redirect(Request.RawUrl);
        }
        else if (e.CommandName == "ShowLiked")
        {
            int i = e.Item.ItemIndex;
            int postID = int.Parse(((Label)(((DataList)source).Items[i].FindControl("lblPostID"))).Text);
            LikedOnPost(postID);
        }
    }
    protected void commentsOnComments_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "DeleteComment")
        {

            int i = e.Item.ItemIndex;
            Label lbl = (Label)(((DataList)source).Items[i].FindControl("lblPostID"));
            Posts.DeletePost(int.Parse(lbl.Text));
            Response.Redirect(Request.RawUrl);
        }
        else if (e.CommandName == "LikePost")
        {
            int i = e.Item.ItemIndex;
            int postID = int.Parse(((Label)(((DataList)source).Items[i].FindControl("lblPostID"))).Text);
            int userID = ((Users)Session["User"]).UserID;
            if (!Likes.LikeExist(postID, userID))//Like
                new Likes(postID, userID, DateTime.Now).Insert();
            else
                Likes.DeleteLike(-1, userID, postID);

            Response.Redirect(Request.RawUrl);
        }
        else if (e.CommandName == "ShowLiked")
        {
            int i = e.Item.ItemIndex;
            int postID = int.Parse(((Label)(((DataList)source).Items[i].FindControl("lblPostID"))).Text);
            LikedOnPost(postID);
        }
    }
    protected void friendList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "NextPage")
        {
            if (pg.CurrentPageIndex + 1 < pg.PageCount)
            {
                pg.CurrentPageIndex++;
                friendList.DataSource = pg;
                friendList.DataBind();
            }
        }
        else if (e.CommandName == "PrevPage")
        {
            if (pg.CurrentPageIndex - 1 >= 0)
            {
                pg.CurrentPageIndex--;
                friendList.DataSource = pg;
                friendList.DataBind();
            }
        }
    }
    protected void btnDeleteFriend_Click(object sender, EventArgs e)
    {
        if (Friendships.ExistFriendship(ID(), ((Users)Session["User"]).UserID))
        {
            Friendships.DeleteFriendship(ID(), ((Users)Session["User"]).UserID);
            Response.Redirect(Request.RawUrl);
        }
        else if (FriendRequest.GotFriendRequestFrom(ID(), ((Users)Session["User"]).UserID))
        {
            FriendRequest.DeleteFriendRequest(((Users)Session["User"]).UserID, ID());
            Response.Redirect(Request.RawUrl);
        }
        else if (FriendRequest.GotFriendRequestFrom((((Users)Session["User"]).UserID), ID()))
        {
            FriendRequest.DeleteFriendRequest(ID(), ((Users)Session["User"]).UserID);
            Response.Redirect(Request.RawUrl);
        }
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        panelShowLiked.Visible = false;
        panelPostList.Visible = true;
    }
    protected void btnGoToChat_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChatMessages.aspx?id=" + ID());
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        FriendRequest.AcceptFriendRequest(ID(), ((Users)Session["User"]).UserID);
        Response.Redirect(Request.RawUrl);
    }
}