using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using CyberSource;


namespace CyberSourceStore 
{
	public struct Item
	{
		public string  ProductName;
		public decimal UnitPrice;
		public int     Quantity;
		public string  TaxwareCode;
	}

	public struct Shopper
	{
		public string FirstName;
		public string LastName;
		public string Email;
	}

	public struct Address
	{
		public string Address1;
		public string Address2;
		public string City;
		public string State;
		public string Zip;
		public string Country;
		public string Phone;
	}

	public struct CreditCard
	{
		public string Number;
		public string ExpMonth;
		public string ExpYear;
		public string CV;
	}

   
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		public CyberSource.ICSClient icsClient;
		private System.ComponentModel.IContainer components;
	
		public Global()
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
                Session["HomePath"] = System.Configuration.ConfigurationManager.AppSettings["HomePath"];
            }


            if (CheckBrowser.isMobileBrowser())
            {
                Session["Style"] = CheckBrowser.MobileCss;
                Session["HomePath"] = System.Configuration.ConfigurationManager.AppSettings["HomePath"]+"mobileweb/";
            }
            else
            {
                Session["Style"] = CheckBrowser.DeviceCss;
            }

        }

		public static string Amount2String( decimal amount )
		{
			return( String.Format( "{0:c}", amount ) );
		}

		public static void AddShopperFields( ICSRequest request, ref Shopper shopper )
		{
			request["customer_firstname"]   = shopper.FirstName;
			request["customer_lastname"]    = shopper.LastName;
			request["customer_email"]       = shopper.Email;
		}
		
		public static void AddBillAddressFields(ICSRequest request, ref Address billAddress )
		{
			request["bill_address1"]	    = billAddress.Address1;
			if (billAddress.Address2 != null && billAddress.Address2.Length > 0)
			{
				request["bill_address2"]    = billAddress.Address2;
			}
			request["bill_city"]		    = billAddress.City;
			request["bill_state"]           = billAddress.State;
			request["bill_zip"]			    = billAddress.Zip;
			request["bill_country"]		    = billAddress.Country;
			request["customer_phone"]       = billAddress.Phone;
		}

		public static void AddShipToAddressFields(ICSRequest request, ref Address shipToAddress )
		{
			request["ship_to_address1"]	    = shipToAddress.Address1;
			if (shipToAddress.Address2 != null && shipToAddress.Address2.Length > 0)
			{
				request["ship_to_address2"] = shipToAddress.Address2;
			}
			request["ship_to_city"]		    = shipToAddress.City;
			request["ship_to_state"]        = shipToAddress.State;
			request["ship_to_zip"]			= shipToAddress.Zip;
			request["ship_to_country"]		= shipToAddress.Country;
			request["ship_to_phone"]       = shipToAddress.Phone;
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            //this.icsClient = new CyberSource.ICSClient(this.components);
          
            //this.icsClient.HTTPProxyPassword = ((string)(configurationAppSettings.GetValue("icsClient.HTTPProxyPassword", typeof(string))));
            //this.icsClient.HTTPProxyURL = ((string)(configurationAppSettings.GetValue("icsClient.HTTPProxyURL", typeof(string))));
            //this.icsClient.HTTPProxyUsername = ((string)(configurationAppSettings.GetValue("icsClient.HTTPProxyUsername", typeof(string))));
            //this.icsClient.KeysDir = ((string)(configurationAppSettings.GetValue("icsClient.KeysDir", typeof(string))));
            //this.icsClient.LogFile = ((string)(configurationAppSettings.GetValue("icsClient.LogFile", typeof(string))));
            //this.icsClient.LogLevel = ((string)(configurationAppSettings.GetValue("icsClient.LogLevel", typeof(string))));
            //this.icsClient.LogMaxSize = ((int)(configurationAppSettings.GetValue("icsClient.LogMaxSize", typeof(int))));
            //this.icsClient.MerchantId = ((string)(configurationAppSettings.GetValue("icsClient.MerchantId", typeof(string))));
            //this.icsClient.RetryEnabled = ((string)(configurationAppSettings.GetValue("icsClient.RetryEnabled", typeof(string))));
            //this.icsClient.RetryStart = ((int)(configurationAppSettings.GetValue("icsClient.RetryStart", typeof(int))));
            //this.icsClient.ServerHost = ((string)(configurationAppSettings.GetValue("icsClient.ServerHost", typeof(string))));
            //this.icsClient.ServerId = ((string)(configurationAppSettings.GetValue("icsClient.ServerId", typeof(string))));
            //this.icsClient.ServerPort = ((int)(configurationAppSettings.GetValue("icsClient.ServerPort", typeof(int))));
            //this.icsClient.ThrowLogException = ((string)(configurationAppSettings.GetValue("icsClient.ThrowLogException", typeof(string))));
            //this.icsClient.Timeout = ((int)(configurationAppSettings.GetValue("icsClient.Timeout", typeof(int))));
           
		}
		#endregion
	}
}

