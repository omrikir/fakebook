using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Registeration : System.Web.UI.Page
{
    private readonly int[] MAX_DAY = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        
        object obj = DataService.ExecuteScalar("select * from Users where (Email='" + txtEmailReg.Text + "')");
        if (Users.Exist(txtEmailReg.Text) != false)
        {
            lblError.Text = "Email already exists";
        }
        else
        {
            Users register = new Users(txtFirstName.Text,txtLastName.Text,txtEmailReg.Text,txtPassReg.Text,radioGender.SelectedItem.Value,new DateTime(int.Parse(dropListYear.SelectedValue), int.Parse(dropListMonth.SelectedValue), int.Parse(dropListDay.SelectedValue)));
            register.Insert();
            Session["User"] = register;
            Response.Redirect("FakebookPage.aspx");
        }
    }
    protected void dropListYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateDays();
    }
    protected void dropListMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateDays();
    }

    private bool isLeap(int y)
    {
        return y % 4 == 0 && (y % 100 != 0 || y % 400 == 0);
    }

    private void UpdateDays()
    {
        if (dropListYear.SelectedIndex == 0 || dropListMonth.SelectedIndex == 0)
        {
            dropListDay.CssClass = "hidden";
        }
        else
        {
            dropListDay.CssClass = "";
            dropListDay.Items.Clear();
            int daysInMonth = 0;
            if (dropListMonth.SelectedIndex == 2 && isLeap(int.Parse(dropListYear.SelectedValue)))
            {
                daysInMonth = 29;
            }
            else
                daysInMonth = MAX_DAY[dropListMonth.SelectedIndex];
            dropListDay.Items.Add(new ListItem("Day","0"));
            for (int i = 1; i <= daysInMonth; i++)
            {
                dropListDay.Items.Add(new ListItem("" + i, "" + i));
            }
        }
    }
}