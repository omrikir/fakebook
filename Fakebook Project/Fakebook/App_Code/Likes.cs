using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Like
/// </summary>
public class Likes
{
    private int likeID;
    private int postID;
    private int userID;
    private DateTime date;

    public Likes(int postID, int userID, DateTime date, int likeID = -1)
    {
        this.likeID = likeID;
        this.postID = postID;
        this.userID = userID;
        this.date = date;
    }

    public int Insert()
    {
        int rowsAffected;
        string strSql = String.Format("Insert into Likes(PostID,UserID,Date) Values ('{0}','{1}','{2}')", postID, userID, date.ToString("MM/dd/yyyy HH:mm:ss"));
        rowsAffected = (int)DataService.ExecuteNonQuery(strSql);

        if (this.likeID == -1)
        {
            strSql = String.Format("Select LikeID from Likes Where (PostID='{0}' And UserID = '{1}' And Date = '{2}')", postID, userID, date.ToString("MM/dd/yyyy HH:mm:ss"));
            this.likeID = int.Parse(DataService.ExecuteScalar(strSql).ToString());
        }

        return rowsAffected;
    }

    public static bool LikeExist(int postID, int userID)
    {
        string strSql = string.Format("select * from Likes where PostID='{0}' And UserID='{1}'", postID,userID);
        DataSet ds = DataService.GetDataSet(strSql, "Likes");
        return ds != null;
    }

    public static DataSet GetAllLikes(int postID)
    {
        string strSql = string.Format("select * from Likes where PostID='{0}'", postID);
        DataSet ds = DataService.GetDataSet(strSql, "Likes");
        return ds;
    }

    public static int LikesAmount(int postID)
    {
        string strSql = string.Format("select Count(PostID) from Likes where PostID='{0}'", postID);
        return int.Parse(DataService.ExecuteScalar(strSql).ToString());
    }

    public static void DeleteLike(int likeID = -1, int userID = -1, int postID = -1)
    {
        if (likeID != -1)
        {
            string strSql = String.Format("Delete From Likes Where LikeID='{0}'", likeID);
            DataService.ExecuteNonQuery(strSql);
        }
        else if (userID != -1 && postID != -1)
        {
            string strSql = String.Format("Delete From Likes Where userID='{0}' And postID='{1}'", userID, postID);
            DataService.ExecuteNonQuery(strSql);
        }
    }

    public static void DeleteLikeAllLikes(int userID)
    {
            string strSql = String.Format("Delete From Likes Where userID='{0}'", userID);
            DataService.ExecuteNonQuery(strSql);
    }
}