using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using advancewebtosolution.BO;

public partial class MB_index : System.Web.UI.Page
{ 
    StoreFront objStoreFront = new StoreFront();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != null)
            {
                divpayment.Visible = true;
            }
            else
            {
                divpayment.Visible = false;
            }
        }
        catch(Exception ex) { throw ex; }
    }

    protected void lnkPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/mobileweb/PaymentInfo.aspx");
    }
}