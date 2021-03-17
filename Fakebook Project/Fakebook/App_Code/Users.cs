using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Users
/// </summary>
public class Users
{
    private string firstName;
    private string lastName;
    private int userId;
    private string email;
    private string userPassword;
    private string gender;
    private string profileImage;
    private DateTime date;

    public Users(string firstName, string lastName, string email, string userPassword, string gender, DateTime date, string profileImage = "", int userId = -1)
	{
        this.firstName = firstName;
        this.lastName = lastName;
        this.userId = userId;
        this.email = email;
        this.userPassword = userPassword;
        this.gender = gender;
        if (profileImage != "")
            this.profileImage = profileImage;
        else
        {
            if (gender == "Male")
                this.profileImage = "images/Male.gif";
            else
                this.profileImage = "images/Female.jpg";
        }
        this.date = date;
	}

    public int UserID
    {
        get { return this.userId; }
    }

    public string FirstName
    {
        get { return this.firstName; }
    }

    public string LastName
    {
        get { return this.lastName; }
    }

    public string Gender
    {
        get { return this.gender; }
    }

    public string ProfileImage
    {
        get { return this.profileImage; }
        set { this.profileImage = value; }
    }

    public string Email
    {
        get { return this.email; }
    }

    public static bool Exist(string email)
    {
        string strSql = string.Format("select * from Users where Email='{0}'", email);
        Object obj = DataService.ExecuteScalar(strSql);
        return obj != null;
    }

    public static bool Exist(int userID)
    {
        string strSql = string.Format("select * from Users where userID='{0}'", userID);
        Object obj = DataService.ExecuteScalar(strSql);
        return obj != null;
    }

    public static bool Exist(string email, string password)
    {
        string strSql = string.Format("select * from Users where Email='{0}' AND Password='{1}'", email,password);
        Object obj = DataService.ExecuteScalar(strSql);
        return obj != null;
    }

    public static Users GetUser(string email, string password)
    {
        string strSql = string.Format("select * from Users where Email='{0}' AND Password='{1}'", email, password);
        DataSet ds = DataService.GetDataSet(strSql,"User");
        if (ds == null || ds.Tables[0].Rows.Count == 0)
            return null;
        int userID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
        string firstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
        string lastName = ds.Tables[0].Rows[0]["LastName"].ToString();
        string gender = ds.Tables[0].Rows[0]["Gender"].ToString();
        string profileImage = ds.Tables[0].Rows[0]["ProfileImage"].ToString();
        DateTime date = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
        return new Users(firstName, lastName, email, password, gender, date, profileImage, userID);
    }

    public static DataSet GetAllUsers()
    {
        string strSql = string.Format("select * from Users");
        DataSet ds = DataService.GetDataSet(strSql, "User");
        if (ds == null || ds.Tables[0].Rows.Count == 0)
            return null;
        return ds;
    }

    public static DataSet GetAllUsers(string name)
    {
        string strSql = string.Format("select * from Users Where (FirstName + ' ' + LastName Like '{0}%')", name);
        DataSet ds = DataService.GetDataSet(strSql, "User");
        if (ds == null || ds.Tables[0].Rows.Count == 0)
            return null;
        return ds;
    }

    public static DataSet GetDataSetUser(int userID)
    {
        string strSql = string.Format("select * from Users where UserID='{0}'", userID);
        DataSet ds = DataService.GetDataSet(strSql, "User");
        if (ds == null || ds.Tables[0].Rows.Count == 0)
            return null;
        return ds;
    }

    public static Users GetUser(int userID)
    {
        string strSql = string.Format("select * from Users where UserID='{0}'", userID);
        DataSet ds = DataService.GetDataSet(strSql, "User");
        if (ds == null || ds.Tables[0].Rows.Count == 0)
            return null;
        string email = ds.Tables[0].Rows[0]["Email"].ToString();
        string password = ds.Tables[0].Rows[0]["Password"].ToString();
        string firstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
        string lastName = ds.Tables[0].Rows[0]["LastName"].ToString();
        string gender = ds.Tables[0].Rows[0]["Gender"].ToString();
        string profileImage = ds.Tables[0].Rows[0]["ProfileImage"].ToString();
        DateTime date = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
        return new Users(firstName, lastName, email, password, gender, date, profileImage, userID);
    }

    public int Update()
    {
        int rowsAffected;
        string strSql = string.Format("Update Users Set FirstName='{0}', LastName='{1}', Email='{2}', Password='{3}', Gender='{4}', ProfileImage='{5}' Where UserID={6}", firstName, lastName, email, userPassword, gender, profileImage,userId);
        rowsAffected = (int)DataService.ExecuteNonQuery(strSql);
        return rowsAffected;
    }

    public static int Delete(int userID)
    {
        int rowsAffected;
        string strSql = string.Format("Delete From Users Where UserID={0}", userID);
        FriendRequest.DeletedUserFriendRequests(userID);
        Friendships.DeletedUserFriendships(userID);
        Likes.DeleteLikeAllLikes(userID);
        Posts.DeleteAllUserPosts(userID);
        Messages.DeleteAllMessages(userID);
        rowsAffected = (int)DataService.ExecuteNonQuery(strSql);
        return rowsAffected;
    }

    public int Insert()
    {
        int rowsAffected;
        string strSql = "Insert into Users(FirstName,LastName,Password,Email,Gender,Birthday,ProfileImage) Values ('" + firstName + "','" + lastName + "','" + userPassword + "','" + email + "','" + gender + "','" + date.ToString("MM/dd/yyyy") + "','" + profileImage + "')";
        rowsAffected = (int)DataService.ExecuteNonQuery(strSql);
        this.userId = GetUser(email, userPassword).UserID;
        return rowsAffected;
    }
}