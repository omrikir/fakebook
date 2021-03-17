using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdBuying
{
    class Ads
    {
        private int userID;
        private string url;
        private string advertiserName;
        private string adPath;
        private int adPlan;
        private int entries;


        public Ads(int userID, string url, string advertiserName, string adPath, int adPlan, int entries = 0)
        {
            this.userID = userID;
            this.url = url;
            this.advertiserName = advertiserName;
            this.adPath = adPath;
            this.adPlan = adPlan;
            this.entries = entries;
        }

        public int Insert()
        {
            int rowsAffected;
            string strSql = String.Format("Insert into Ads(UserID,URL,AdvertiserName,AdPath,AdPlan,Entries) Values ('{0}','{1}','{2}','{3}','{4}','{5}')", userID, url, advertiserName, adPath, adPlan,entries);
            rowsAffected = (int)DataService.ExecuteNonQuery(strSql);
            return rowsAffected;
        }
    }
}
