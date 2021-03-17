using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Messages
/// </summary>
public class Messages
{
    private int senderUserID;
    private int gettingUserID;
    private DateTime date;
    private string contents;

	public Messages(int senderUserID, int gettingUserID, DateTime date, string contents)
	{
        this.senderUserID = senderUserID;
        this.gettingUserID = gettingUserID;
        this.date = date;
        this.contents = contents;
	}

    public static DataSet GetMessages(int userID1, int userID2)
    {
        string strSql = string.Format("select * from Messages where (SenderUserID='{0}' And GettingUserID='{1}') OR (SenderUserID='{1}' And GettingUserID='{0}') Order By MessageID Desc", userID1,userID2);
        DataSet ds = DataService.GetDataSet(strSql, "Messages");
        return ds;
    }

    public int Insert()
    {
        int rowsAffected;
        string strSql = String.Format("Insert into Messages(SenderUserID,GettingUserID,Date,Contents) Values ('{0}','{1}','{2}','{3}')", senderUserID, gettingUserID, date.ToString("MM/dd/yyyy HH:mm:ss"),contents);
        rowsAffected = (int)DataService.ExecuteNonQuery(strSql);

        return rowsAffected;
    }

    public static void DeleteAllMessages(int userID)
    {
        string strSql = String.Format("Delete From Messages Where SenderUSerID='{0}' OR GettingUserID='{0)'", userID);
        DataService.ExecuteNonQuery(strSql);
    }
}