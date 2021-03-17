using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class FirstPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnGoSignup_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registeration.aspx");
    }
    protected void btnGoLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}