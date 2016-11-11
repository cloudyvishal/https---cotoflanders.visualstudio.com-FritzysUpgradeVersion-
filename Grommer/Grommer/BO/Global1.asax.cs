using System;
using System.Configuration;
using CyberSource.Clients.SoapServiceReference;

namespace CyberSource.Client
{
    public struct Items
    {
        public string productName;
        public decimal unitPrice;
        public int quantity;
    }
    public struct Shopper
    {
        public string firstName;
        public string lastName;
        public string street1;
        public string city;
        public string state;
        public string postalCode;
        public string country;
        public string email;
    }
    public struct CreditCard
    {
        public string accountNumber;
        public string expirationMonth;
        public string expirationYear;
        public string cvNumber;
    }
    public class Global1 : System.Web.HttpApplication
    {
        private System.ComponentModel.IContainer components;

        public Global1()
        {
            InitializeComponent();
        }

        protected void Application_Start(Object sender, EventArgs e)
        {

        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            if (Session["HomePath"] == null)
            {
                Session["HomePath"] = ConfigurationManager.AppSettings["HomePath"];
            }

            if (CheckBrowser.isMobileBrowser())
            {
                Session["Style"] = CheckBrowser.MobileCss;
                Session["HomePath"] = ConfigurationManager.AppSettings["HomePath"] + "mobileweb/";
            }
            else
            {
                Session["Style"] = CheckBrowser.DeviceCss;
            }
        }
       
        public static void AddShopperFields(ref BillTo billTo, Shopper shopper)
        {
            billTo.firstName = shopper.firstName;
            billTo.lastName = shopper.lastName;
            billTo.street1 = shopper.street1;
            billTo.city = shopper.city;
            billTo.state = shopper.state;
            billTo.country = shopper.country;
            billTo.postalCode = shopper.postalCode;
            billTo.email = shopper.email;
        }

        public static void AddItemFields(ref RequestMessage request, Items itm)
        {
            request.item = new Item[1];
            Item item = new Item();
            itm.productName = itm.productName.ToString();
            item.quantity = itm.quantity.ToString();
            item.unitPrice = itm.unitPrice.ToString();
            request.item[0] = item;
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_Error(Object sender, EventArgs e)
        {

        }

        protected void Session_End(Object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Redirect("Index.aspx");
            // Server.Transfer("Index.aspx");
        }

        protected void Application_End(Object sender, EventArgs e)
        {

        }

        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            AppSettingsReader configurationAppSettings = new AppSettingsReader();
        }
        #endregion
    }
}