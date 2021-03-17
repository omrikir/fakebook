using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {
        DataService.Path = Server.MapPath("~/App_Data/CreditCard.mdf");
    }

    [WebMethod]
    public bool CheckValidCreditCardInfo(string cardNumber,string ownerID, string type, int expirationMonth, int expirationYear, string cvv)
    {
        return CreditCards.Exist(cardNumber, ownerID, type, expirationMonth, expirationYear, cvv);
    }

    [WebMethod]
    public bool IsEnoughMoney(string ownerID, string cardNumber, double amountToPay)
    {
        return CreditCards.EnoughMoney(ownerID, cardNumber, amountToPay);
    }

    [WebMethod]
    public bool BuyItem(string ownerID, string cardNumber, double amountToPay)
    {
        return CreditCards.Update(ownerID, cardNumber, amountToPay);
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    
}
