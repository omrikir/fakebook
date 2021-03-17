using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataService.Path = Server.MapPath("~/App_Data/Database.mdf");

            if (Session["User"] == null || Session["User"] == "")
            {
                Response.Redirect("FirstPage.aspx");
                return;
            }
            if (FriendRequest.GetPending(((Users)Session["User"]).UserID) != null)
                HyperLink1.ImageUrl = "images/FriendRequestEvent.png";

            lblUsername.Text = "Hello, " + ((Users)Session["User"]).FirstName;
        }
    }

    [WebMethod]
    public static string[] GetCustomers(string prefix)
    {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection(DataService.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select FirstName, LastName,UserID from Users where (FirstName + ' ' + LastName LIKE '" + prefix + "%')";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0} {1}-{2}", sdr["FirstName"], sdr["LastName"], sdr["UserID"]));
                    }
                }
                conn.Close();
            }
        }
        return customers.ToArray();
    }

    protected void LogOut_Click(object sender, EventArgs e)
    {
        Session["User"] = null;
        Response.Redirect("FirstPage.aspx");
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text != "")
        {
            Response.Redirect("searchPeople.aspx?q=" + txtSearch.Text);
        }
    }
}
