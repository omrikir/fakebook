using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Ads
/// </summary>
public class Ads
{
    private DateTime lastDate;
    private string advertiserName;
    private string websiteUrl;
    private string imagePath;
    private int userID;
    private int planLevel;

	public Ads(DateTime lastDate, string advertiserName, string websiteUrl, string imagePath, int userID, int planLevel)
	{
        this.lastDate = lastDate;
        this.advertiserName = advertiserName;
        this.websiteUrl = websiteUrl;
        this.imagePath = imagePath;
        this.userID = userID;
        this.planLevel = planLevel;
	}

    public static DataSet GetAllAds()
    {
        string strSql = string.Format("select * from Ads");
        return DataService.GetDataSet(strSql,"Ads");
    }

    public static DataSet GetUserAds(int userID)
    {
        string strSql = string.Format("select * from Ads Where UserID={0}",userID);
        return DataService.GetDataSet(strSql, "Ads");
    }

    public static void DeleteAd(int adID)
    {
        string strSql = String.Format("Delete From Ads Where AdID='{0}'", adID);
        DataService.ExecuteNonQuery(strSql);
    }

    public static int UpdateAd(int adID, string advertiserName, string website)
    {
        string strSql = String.Format("Update Ads Set AdvertiserName='{0}', Website='{1}' Where AdID={2}", advertiserName, website, adID);
        int rowsAffected = (int)DataService.ExecuteNonQuery(strSql);
        return rowsAffected;
    }

    public int Insert()
    {
        int rowsAffected;
        string strSql = String.Format("Insert into Ads(LastDate,AdvertiserName,Website,AdImage,UserID,PlanLevel) Values ('{0}','{1}','{2}','{3}','{4}','{5}')", lastDate.ToString("MM/dd/yyyy HH:mm:ss"), advertiserName, websiteUrl, imagePath, userID,planLevel);
        rowsAffected = (int)DataService.ExecuteNonQuery(strSql);
        return rowsAffected;
    }
}