using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Payment : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PaymentInfo.aspx");
    }
}
