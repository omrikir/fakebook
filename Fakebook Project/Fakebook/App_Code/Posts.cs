using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Posts
/// </summary>
public class Posts
{
    private int commentUser;
    private int commentPost;
    private int commentPage;
    private int publisherID;
    private int postID;
    private string contents;
    private DateTime date;

	public Posts(int publisherID, string contents, DateTime date, int postID = -1, int commentUser = -1, int commentPost = -1, int commentPage = -1)
	{
        this.commentUser = commentUser;
        this.publisherID = publisherID;
        this.contents = contents;
        this.date = date;
        this.commentPost = commentPost;
        this.commentPage = commentPage;
        this.postID = postID;
	}

    public int PostID
    {
        get { return this.postID; }
        set { this.postID = value; }
    }

    public string Contents
    {
        get { return this.contents; }
        set { this.contents= value; }
    }

    public int Insert()
    {
        int rowsAffected;
        string strSql = String.Format("Insert into Posts(Contents,CommentUser,CommentPost,CommentPage,Date,PublisherID) Values ('{0}','{1}','{2}','{3}','{4}','{5}')", contents, commentUser, commentPost, commentPage, date.ToString("MM/dd/yyyy HH:mm:ss"), publisherID);
        rowsAffected = (int)DataService.ExecuteNonQuery(strSql);

        if (this.postID == -1)
        {
            strSql = String.Format("Select PostID from Posts Where (Contents='{0}' And PublisherID = '{1}' And Date = '{2}')", contents, publisherID, date.ToString("MM/dd/yyyy HH:mm:ss"));
            this.postID = int.Parse(DataService.ExecuteScalar(strSql).ToString());
        }

        return rowsAffected;
    }


    public static DataSet GetAllPosts(int commentUser = -1, int commentPost = -1, int commentPage = -1, int publisherID = -1)
    {
        string strSql="";
        if(publisherID != -1)
            strSql = string.Format("select * from Posts where PublisherID='{0}'", publisherID);
        else if (commentUser != -1 || commentPage != -1)
            strSql = string.Format("select * from Posts where CommentUser='{0}' And CommentPost={1} And CommentPage={2} Order By PostID Desc", commentUser, commentPost, commentPage);
        else
            strSql = string.Format("select * from Posts where CommentUser='{0}' And CommentPost={1} And CommentPage={2}", commentUser, commentPost, commentPage);
        DataSet ds = DataService.GetDataSet(strSql, "Posts");
        return ds;
    }

    public static void DeletePost(int postID)
    {
        string strSql = string.Format("Delete From Posts Where PostID={0}", postID);
        DataService.ExecuteNonQuery(strSql);
        DataSet ds = GetAllPosts(-1,postID);
        if(ds != null)
            foreach (DataRow dr in ds.Tables[0].Rows)
                DeletePost(int.Parse(dr["PostID"].ToString()));
    }

    public static void DeleteAllUserPosts(int userID)
    {
        string strSql = string.Format("Delete From Posts Where PublisherID={0}", userID);
        DataService.ExecuteNonQuery(strSql);
        DataSet ds = GetAllPosts(-1,-1,-1, userID);
        if (ds != null)
            foreach (DataRow dr in ds.Tables[0].Rows)
                DeletePost(int.Parse(dr["PostID"].ToString()));
    }
}