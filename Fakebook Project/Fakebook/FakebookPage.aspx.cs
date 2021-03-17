using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class FakebookPage : System.Web.UI.Page
{
    private static Random rndNum = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null || Session["User"] == "")
        {
            Response.Redirect("FirstPage.aspx");
            return;
        }
        else
        {
            AdChoose();
        }
    }
    protected void btnProfile_Click(object sender, EventArgs e)
    {
        int id = ((Users)Session["User"]).UserID;
        Response.Redirect("Profiles.aspx?id=" + id);
    }

    private void AdChoose()
    {
        DataSet ads = Ads.GetAllAds();
        if (ads != null)
        {
            if (ads.Tables[0].Rows.Count == 1)
            {
                if (DateTime.Now.CompareTo(DateTime.Parse(ads.Tables[0].Rows[0]["LastDate"].ToString())) <= 0)
                {
                    DataRow randomAd = ads.Tables[0].Rows[0];
                    adLink.NavigateUrl = randomAd["Website"].ToString();
                    ImageAd.ImageUrl = randomAd["AdImage"].ToString();
                    lblAdvertiserName.Text = randomAd["AdvertiserName"].ToString();
                    PanelAd.Visible = true;
                }
                else
                {
                    ads.Tables[0].Rows[0].Delete();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("Select * From Ads", new SqlConnection(DataService.ConnectionString));
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.DeleteCommand = builder.GetDeleteCommand();
                    adapter.Update(ads, "Ads");
                }
            }
            else
            {
                List<DataRow> list = new List<DataRow>();
                int countGoodAds = 0;
                for (int i = 0; i < ads.Tables[0].Rows.Count; i++)
                {
                    if (DateTime.Now.CompareTo(DateTime.Parse(ads.Tables[0].Rows[i]["LastDate"].ToString())) <= 0)
                    {
                        int planLevel = int.Parse(ads.Tables[0].Rows[i]["PlanLevel"].ToString());
                        countGoodAds++;
                        for (int j = 0; j < planLevel; j++)
                        {
                            list.Add(ads.Tables[0].Rows[i]);
                        }
                    }
                    else
                    {
                        ads.Tables[0].Rows[i].Delete();
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("Select * From Ads", new SqlConnection(DataService.ConnectionString));
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.DeleteCommand = builder.GetDeleteCommand();
                adapter.Update(ads, "Ads");
                if (countGoodAds > 1)
                {
                    DataRow randomAd = list[rndNum.Next(list.Count)];
                    adLink.NavigateUrl = randomAd["Website"].ToString();
                    ImageAd.ImageUrl = randomAd["AdImage"].ToString();
                    lblAdvertiserName.Text = randomAd["AdvertiserName"].ToString();
                    DataRow randomAd2 = list[rndNum.Next(list.Count)];
                    while (randomAd2.Equals(randomAd))
                    {
                        randomAd2 = list[rndNum.Next(list.Count)];
                    }
                    adLink1.NavigateUrl = randomAd2["Website"].ToString();
                    ImageAd1.ImageUrl = randomAd2["AdImage"].ToString();
                    lblAdvertiserName1.Text = randomAd2["AdvertiserName"].ToString();
                    PanelAd.Visible = true;
                }
                else if(countGoodAds == 1)
                {
                    DataRow randomAd = list[rndNum.Next(list.Count)];
                    adLink.NavigateUrl = randomAd["Website"].ToString();
                    ImageAd.ImageUrl = randomAd["AdImage"].ToString();
                    lblAdvertiserName.Text = randomAd["AdvertiserName"].ToString();
                    PanelAd.Visible = true;
                }
            }
        }
    }
    protected void adChange_Tick(object sender, EventArgs e)
    {
        AdChoose();
    }
}