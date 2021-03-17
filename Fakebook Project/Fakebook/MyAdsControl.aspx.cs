using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MyAdsControl : System.Web.UI.Page
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
            DataSet ads = Ads.GetUserAds(((Users)Session["User"]).UserID);
            if (ads != null)
            {
                AdsView.DataSource = Ads.GetUserAds(((Users)Session["User"]).UserID);
                AdsView.DataBind();
            }
            else
                lblNoAds.Visible = true;
        }
    }
    protected void AdsView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        panelAds.Visible = false;
        panelSelectedAd.Visible = true;
        int index = e.NewSelectedIndex;
        txtAdvertiserName.Text = AdsView.Rows[index].Cells[2].Text;
        txtURL.Text = ((HyperLink)AdsView.Rows[index].Cells[3].Controls[0]).Text;
        imageSelectedAd.ImageUrl = ((Image)AdsView.Rows[index].Cells[4].Controls[0]).ImageUrl;
        HiddenField1.Value = AdsView.DataKeys[index].Value.ToString();
    }
    protected void btnOut_Click(object sender, EventArgs e)
    {
        panelSelectedAd.Visible = false;
        panelAds.Visible = true;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (FileUpload1.FileName != "")
        {
            FileUpload1.SaveAs(Server.MapPath("~/" + imageSelectedAd.ImageUrl));
        }
        Ads.UpdateAd(int.Parse(HiddenField1.Value), txtAdvertiserName.Text, txtURL.Text);
        Response.Redirect(Request.RawUrl);
    }
    protected void btnCancelAdChanging_Click(object sender, EventArgs e)
    {
        FileUpload1.Dispose();
    }
}