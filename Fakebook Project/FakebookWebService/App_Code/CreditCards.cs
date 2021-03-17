using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CreditCards
/// </summary>
public class CreditCards
{
    private string cardNumber;
    private string type;
    private string ownerID;
    private string expirationDate;
    private double balance;
    private string cvv;

    public CreditCards(string cardNumber, string type, string ownerID, string expirationDate,double balance, string cvv)
	{
        this.cardNumber = cardNumber;
        this.type = type;
        this.ownerID = ownerID;
        this.expirationDate = expirationDate;
        this.balance = balance;
        this.cvv = cvv;
	}

    public static int Delete(int cardNumber, int ownerID)
    {
        string st = String.Format("Delete from CreditCards where(CardNumber='{0}') And OwnerID='{1}'",cardNumber, ownerID);
        int row = (int)DataService.ExecuteNonQuery(st);
        return row;
    }

    public bool Insert()
    {
        string st = String.Format("insert into CreditCards (CardNumber, Type, OwnerID, ExpirationDate, Balance, cvv) values('{0}','{1}','{2}','{3}','{4}','{5}'", cardNumber, type, ownerID, expirationDate, balance, cvv);
        int row = (int)DataService.ExecuteNonQuery(st);
        if (row > 0)
            return true;
        return false;
    }

    public static bool Exist(string cardNumber,string ownerID, string type, int expirationMonth, int expirationYear, string cvv)
    {
        string expirationDate = "";
        if (expirationYear.ToString().Length == 2)
            expirationDate = expirationMonth.ToString("D2") + "/" + expirationYear.ToString("D2");
        else
            expirationDate = expirationMonth.ToString("D2") + "/" + expirationYear.ToString().Substring(2, 2);

        string st = String.Format("select * from CreditCards where  (CardNumber = '{0}') AND (Type = '{1}') AND (OwnerID = '{2}') AND (ExpirationDate = '{3}') AND (cvv = '{4}')", cardNumber, type, ownerID, expirationDate, cvv);
        object obj = DataService.ExecuteScalar(st);
        if (obj == null)
            return false;
        return true;
    }

    public static double GetBalance(string ownerID, string cardNumber)
    {
        string strSql = string.Format("select Balance from CreditCards where (OwnerID='{0}') And CardNumber='{1}'", ownerID,cardNumber);
        object balance= DataService.ExecuteScalar(strSql);

        if (balance == null)
            return 0;

        return double.Parse(balance.ToString());
    }

    public static bool Update(string ownerID, string cardNumber, double amountToPay)
    {
        double amount = CreditCards.GetBalance(ownerID,cardNumber);
        if (amount >= amountToPay)
        {
            string st = String.Format("update CreditCards set Balance='{0}' Where (OwnerID='{1}') And CardNumber='{2}'", amount - amountToPay, ownerID, cardNumber);
            int row = (int)DataService.ExecuteNonQuery(st);
            if (row > 0)
                return true;
            return false;
        }
        return false;
    }

    public static bool EnoughMoney(string ownerID, string cardNumber, double amountToPay)
    {
        double amount = CreditCards.GetBalance(ownerID, cardNumber);
        return amount >= amountToPay;
    }
}