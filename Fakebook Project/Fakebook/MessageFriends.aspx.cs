using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

public partial class MessageFriends : System.Web.UI.Page
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
            lblID.Text = "" + ((Users)Session["User"]).UserID;
            friendsView.DataSource = Friendships.GetFriendsWithName(((Users)Session["User"]).UserID);
            friendsView.DataBind();
        }
    }

    [WebMethod]
    public static string[] GetFriends(string prefix, string id)
    {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection(DataService.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandText = String.Format("SELECT  a.*,b.* FROM Friendships AS a INNER JOIN Users AS b ON a.FriendID = b.UserID WHERE  (a.UserID = '{0}') AND (b.FirstName + ' ' + b.LastName LIKE '{1}%')", id, prefix);
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0} {1}-{2}-{3}", sdr["FirstName"], sdr["LastName"], sdr["FriendID"], sdr["ProfileImage"]));
                    }
                }
                conn.Close();
            }
        }
        return customers.ToArray();
    }
}