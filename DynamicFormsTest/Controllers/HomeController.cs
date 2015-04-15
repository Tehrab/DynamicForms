using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicFormsTest.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //call the Data() method will which give us an object with
            //which to send to the view
            return View(Data());
        }

        //let's take a look at the posted results with a fancy
        //breakpoint
        [HttpPost]
        public ActionResult Index(List<PCardData> list)
        {
            return View();
        }

        //method that whips together some dummy data into the
        //List<PCardDat> object that the non-HttpPost Index()
        //action will send to the view
        public List<PCardData> Data()
        {
            List<PCardData> data = new List<PCardData>();                                           //create a new list to hold our data

            List<AccountInfo> accounts = new List<AccountInfo>();                                   //prep an Account list to hold our child object
            accounts.Add(new AccountInfo() { Account = "test" });                                   //and add an Account to it

            data.Add(new PCardData() { CardNum = "1234", Amount = 12.00, Accounts = accounts });    //begin populating our list from above with new
            data.Add(new PCardData() { CardNum = "5678", Amount = 22.00, Accounts = accounts });    //PCardData objects and assign the "accounts"
            data.Add(new PCardData() { CardNum = "9101", Amount = 32.00, Accounts = accounts });    //object to the PCardData.Accounts property

            //send our data object back to the view!
            return data;
        }
    }

    //This is just my dummy class that I send to the view
    //in a List<> object
    public class PCardData
    {
        public string CardNum { get; set; }
        public double Amount { get; set; }
        public List<AccountInfo> Accounts { get; set; }

        public PCardData()
        {
            Accounts = new List<AccountInfo>();
        }
    }

    //the class for the PCardData.Accounts property
    public class AccountInfo
    {
        public string Account { get; set; }
    }
}
