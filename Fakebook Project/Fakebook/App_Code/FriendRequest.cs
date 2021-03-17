using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FriendRequest
/// </summary>
public class FriendRequest
{
    private int userID;
    private int friendID;
    private DateTime date;

    public FriendRequest(int userID, int friendID, DateTime date)
	{
        this.userID = userID;
        this.friendID = friendID;
        this.date = date;
	}

    public static DataSet GetPending(int gotInvite)
    {
        string strSql = string.Format("select * from FriendRequest where FriendID='{0}'", gotInvite);
        DataSet ds = DataService.GetDataSet(strSql, "FriendRequests");

        if (ds == null || ds.Tables[0].Rows.Count == 0)
            return null;
        return ds;
    }

    public static DataSet SentRequests(int sentID)
    {
        string strSql = string.Format("select * from FriendRequest where UserID='{0}'", sentID);
        DataSet ds = DataService.GetDataSet(strSql, "FriendRequests");

        if (ds == null || ds.Tables[0].Rows.Count == 0)
            return null;
        return ds;
    }

    public static bool ExistFriendRequest(int sentInvite, int gotInvite)
    {
        string strSql = string.Format("select Date from FriendRequest where (UserID='{0}' AND FriendID='{1}')", sentInvite, gotInvite);
        Object obj = DataService.ExecuteScalar(strSql);
        strSql = string.Format("select Date from FriendRequest where (UserID='{1}' AND FriendID='{0}')", sentInvite, gotInvite);
        Object obj2 = DataService.ExecuteScalar(strSql);
        return obj != null || obj2 != null;
    }

    public static bool GotFriendRequestFrom(int gotInvite, int sentInvite)
    {
        string strSql = string.Format("select Date from FriendRequest where (UserID='{0}' AND FriendID='{1}')", sentInvite, gotInvite);
        Object obj = DataService.ExecuteScalar(strSql);
        return obj != null;
    }

    public static void AcceptFriendRequest(int sentInvite, int gotInvite)
    {
        FriendRequest.DeleteFriendRequest(sentInvite, gotInvite);
        new Friendships(sentInvite, gotInvite, DateTime.Now).Insert();
    }

    public static void DeleteFriendRequest(int sentInvite, int gotInvite)
    {
        string strSql = string.Format("Delete From FriendRequest Where UserID={0} And FriendID={1}", sentInvite, gotInvite);
        DataService.ExecuteNonQuery(strSql);
    }

    public static void DeletedUserFriendRequests(int userID)
    {
        string strSql = string.Format("Delete From FriendRequest Where UserID={0} OR FriendID={0}", userID);
        DataService.ExecuteNonQuery(strSql);
    }

    public int Insert()
    {
        int rowsAffected;
        string strSql = String.Format("Insert into FriendRequest(UserID,FriendID,Date) Values ('{0}','{1}','{2}')", userID, friendID, date.ToString("MM/dd/yyyy HH:mm:ss"));
        rowsAffected = (int)DataService.ExecuteNonQuery(strSql);
        return rowsAffected;
    }
}