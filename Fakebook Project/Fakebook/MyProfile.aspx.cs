using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class MyProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null || Session["User"] == "")
        {
            Response.Redirect("FirstPage.aspx");
            return;
        }
        Response.Redirect("Profiles.aspx?id=" + ((Users)Session["User"]).UserID);
    }

    public static string[] GetFriends(string prefix)
    {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection(DataService.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select FirstName, LastName,UserID,ProfileImage from Users where (FirstName + ' ' + LastName LIKE '" + prefix + "%')";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0} {1}-{2}-{3}", sdr["FirstName"], sdr["LastName"], sdr["UserID"], sdr["ProfileImage"]));
                    }
                }
                conn.Close();
            }
        }
        return customers.ToArray();
    }
}