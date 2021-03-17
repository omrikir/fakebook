using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BuyAd : System.Web.UI.Page
{
    ServiceReference1.WebServiceSoapClient service = new ServiceReference1.WebServiceSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null || Session["User"] == "")
        {
            Response.Redirect("FirstPage.aspx");
            return;
        }
        else if(!IsPostBack)
        {
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 5; i++)
            {
                dropListYear.Items.Add(new ListItem(i.ToString().Substring(2, 2), i.ToString().Substring(2, 2)));
            }
        }
    }
    protected void btnUploadImage_Click(object sender, EventArgs e)
    {
    }

    private void UpdateIt()
    {
        lblHeader.Text = "";
        timeDropList.SelectedIndex = -1;
        txtAdvertiserName.Text = "";
        txtURL.Text = "";
        FileUpload1.Dispose();
        if (HiddenField1.Value == "1")
        {
            lblHeader.Text = "Low Plan - 10$ per month";
        }
        else if (HiddenField1.Value == "2")
        {
            lblHeader.Text = "Normal Plan - 20$ per month";
        }
        else if (HiddenField1.Value == "3")
        {
            lblHeader.Text = "High Plan - 30$ per month";
        }
    }

    protected void btnOut_Click(object sender, EventArgs e)
    {
        panelChoose.Visible = true;
        panelBuy.Visible = false;
    }
    protected void btnChooseLow_Click(object sender, EventArgs e)
    {
        panelChoose.Visible = false;
        panelBuy.Visible = true;
        HiddenField1.Value = "1";
        UpdateIt();
    }
    protected void btnChooseNormal_Click(object sender, EventArgs e)
    {
        panelChoose.Visible = false;
        panelBuy.Visible = true;
        HiddenField1.Value = "2";
        UpdateIt();
    }
    protected void btnChooseHigh_Click(object sender, EventArgs e)
    {
        panelChoose.Visible = false;
        panelBuy.Visible = true;
        HiddenField1.Value = "3";
        UpdateIt();
    }
    protected void btnBuy_Click(object sender, EventArgs e)
    {
        panelBuy.Visible = false;
        panelCC.Visible = true;
        Session["Image"] = FileUpload1.PostedFile;
    }
    protected void dropListMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropListYear.SelectedValue != "0" && dropListMonth.SelectedValue != "0")
            txtExpirationDate.Text = "1";
        else
            txtExpirationDate.Text = "0";
    }
    protected void dropListYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropListYear.SelectedValue != "0" && dropListMonth.SelectedValue != "0")
            txtExpirationDate.Text = "1";
        else
            txtExpirationDate.Text = "0";
    }
    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        string ownerID = txtOwnerID.Text;
        string cardNumber = txtCardNumber.Text;
        string cvv = txtCvv.Text;
        string type = dropListType.SelectedValue;
        string expirationMonth = dropListMonth.SelectedValue;
        string expirationYear = dropListYear.SelectedValue;

        if (service.CheckValidCreditCardInfo(cardNumber, ownerID, type, int.Parse(expirationMonth), int.Parse(expirationYear), cvv))
        {
            if (service.IsEnoughMoney(ownerID, cardNumber, int.Parse(HiddenField1.Value) * 10))
            {
                service.BuyItem(ownerID, cardNumber, int.Parse(HiddenField1.Value) * 10);

                string advertiserName = txtAdvertiserName.Text;
                string adURL = txtURL.Text;
                int months = int.Parse(timeDropList.SelectedValue);
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Server.MapPath("~/Ads"));
                int count = dir.GetFiles().Length;
                System.Web.HttpPostedFile image = (System.Web.HttpPostedFile)Session["Image"];
                string strPathName = "Ads/" + count + "." + (image.FileName).Split('.')[1];
                {
                    image.SaveAs(Server.MapPath(strPathName));
                }
                try
                {
                    new Ads(DateTime.Now.AddMonths(months), advertiserName, adURL, strPathName, ((Users)Session["User"]).UserID, int.Parse(HiddenField1.Value)).Insert();
                    Response.Redirect("MyAdsControl.aspx");
                }
                catch
                {

                }
            }
            else
            {
                lblResult.Text = "You don't have enough credit in your account";
            }
        }
        else
        {
            lblResult.Text = "Invalid credit card info";
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        panelCC.Visible = false;
        panelBuy.Visible = true;
    }

}