using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SendFinalValue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "FName: " + Request.QueryString["FName"];
        Label2.Text = "LName: " + Request.QueryString["LName"];
        Label3.Text = "Address1: " + Request.QueryString["Address1"];
        Label4.Text = "Address2: " + Request.QueryString["Address2"];
        Label5.Text = "City: " + Request.QueryString["City"];
        Label6.Text = "Zip: " + Request.QueryString["Zip"];
        Label7.Text = "Country: " + Request.QueryString["Country"];
        Label8.Text = "Phone: " + Request.QueryString["Phone"];
        Label9.Text = "Email: " + Request.QueryString["Email"];
        Label10.Text = "CardType: " + Request.QueryString["CardType"];
        Label11.Text = "CardNo: " + Request.QueryString["CardNo"];
        Label12.Text = "Month: " + Request.QueryString["Month"];
        Label13.Text = "ExpYear: " + Request.QueryString["ExpYear"];
        Label14.Text = "VerificationNo: " + Request.QueryString["VerificationNo"];
        Label15.Text = "TotalCost: " + Request.QueryString["TotalCost"];
        Label17.Text = "Tax: " + Request.QueryString["Tax"];
    }
}
