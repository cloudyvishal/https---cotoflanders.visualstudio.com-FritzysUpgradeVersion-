using System;
using System.Configuration;
using advancewebtosolution.BO;
using System.Data.SqlClient;
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
    public partial class Global1 : System.Web.HttpApplication
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
            try
            {
                if (Session["HomePath"] == null)
                {
                    Session["HomePath"] = ConfigurationManager.AppSettings["HomePath"].ToString();     // Session["Homepath"] use to set root directory path and this path can be set from Web.config
                    Session["AdminPath"] = Session["HomePath"] + "Admin/";                             // Session["AdminPath"] use to set root directory path of admin folder 
                    Session["StaticContentPhysicalPath"] = Session["HomePath"] + "StoreData/";
                    Session["MemberName"] = null;                                                      // Session["MemberName"] Use to store member name display on home page 
                    Session["IsLogin"] = "0";                                                          // Session["IsLogin"] is use to check whether user is Loged in or not default Not  
                    Session["UserType"] = "4";                                                         // Session["UserType"] is use to set UseType 4 (Guest/Annonymus) ,1(Cat), 2(Dog) ,3(catDog)
                    Session["AdminUserType"] = "1";                                                    // Session["AdminUserType"] is user to set Admin user type 0 for admin and 1 for Subadmin
                    Session["MobilePath"] = Session["HomePath"] + "mobileweb/";
                }

            }
            catch (SqlException ex) { throw ex; }

            if (Session["HomePath"] == null)
            {
                Session["HomePath"] = ConfigurationManager.AppSettings["HomePath"];
            }
            if (CheckBrowser.isMobileBrowser())
            {
                Session["Mobile"] = CheckBrowser.Mobile;
            }
            else
            {
                Session["Desktop"] = CheckBrowser.Desktop;
            }

            if (Convert.ToString(Session["Desktop"]) == "Desktop")
            {
                Uri refUrl = Request.UrlReferrer;
                string stringRefUrl = Convert.ToString(refUrl).ToLower();
                if (stringRefUrl.Contains("admin") == true)
                {
                    Response.Redirect("~/Admin/default.aspx");
                }
                else {
                    Response.Redirect("~/Index.aspx");
                }
            }

            else if (Convert.ToString(Session["Mobile"]) == "Mobile")
            {
                Response.Redirect("~/mobileweb/MB_index.aspx");
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
            //Server.Transfer("Index.aspx");
        }

        protected void Application_End(Object sender, EventArgs e)
        {

        }

        #region Web Form Designer generated code
        // <summary>
        // Required method for Designer support - do not modify
        // the contents of this method with the code editor.
        // </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            AppSettingsReader configurationAppSettings = new AppSettingsReader();
        }
        #endregion
    }
}