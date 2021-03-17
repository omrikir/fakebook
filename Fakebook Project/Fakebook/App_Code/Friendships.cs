using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Friendships
/// </summary>
public class Friendships
{
    private int userID;
    private int friendID;
    private DateTime date;

	public Friendships(int userID, int friendID, DateTime date)
	{
        this.userID = userID;
        this.friendID = friendID;
        this.date = date;
	}

    public static DataSet GetFriends(int userID)
    {
        string strSql = string.Format("select * from Friendships where (UserID='{0}')", userID);
        DataSet ds = DataService.GetDataSet(strSql, "Friendships");

        if (ds == null || ds.Tables[0].Rows.Count == 0)
            return null;

        return ds;
    }

    public static DataSet GetFriendsWithName(int userID)
    {
        string strSql = string.Format("SELECT a.*, b.FirstName + ' ' + b.LastName AS FriendName FROM Friendships AS a INNER JOIN Users AS b ON a.FriendID = b.UserID WHERE  (a.UserID = {0})", userID);
        DataSet ds = DataService.GetDataSet(strSql, "Friendships");

        if (ds == null || ds.Tables[0].Rows.Count == 0)
            return null;

        return ds;
    }

    public static bool ExistFriendship(int userID, int friendID)
    {
        string strSql = string.Format("select Date from Friendships where (UserID='{0}' AND FriendID='{1}')", userID,friendID);
        Object obj = DataService.ExecuteScalar(strSql);
        return obj != null;
    }

    public static void DeleteFriendship(int userID, int friendID)
    {
        string strSql = string.Format("Delete From Friendships Where UserID={0} And FriendID={1}", userID, friendID);
        DataService.ExecuteNonQuery(strSql);
        strSql = string.Format("Delete From Friendships Where UserID={1} And FriendID={0}", userID, friendID);
        DataService.ExecuteNonQuery(strSql);
    }

    public static void DeletedUserFriendships(int userID)
    {
        string strSql = string.Format("Delete From Friendships Where UserID={0} OR FriendID={0}", userID);
        DataService.ExecuteNonQuery(strSql);
    }

    public int Insert()
    {
        int rowsAffected;
        string strSql = String.Format("Insert into Friendships(UserID,FriendID,Date) Values ('{0}','{1}','{2}')", userID, friendID, date.ToString("MM/dd/yyyy HH:mm:ss"));
        rowsAffected = (int)DataService.ExecuteNonQuery(strSql);
        strSql = String.Format("Insert into Friendships(UserID,FriendID,Date) Values ('{0}','{1}','{2}')", friendID, userID, date.ToString("MM/dd/yyyy HH:mm:ss"));
        rowsAffected += (int)DataService.ExecuteNonQuery(strSql);
        return rowsAffected;
    }
}