using System;
using System.Web.UI;

public partial class DCommingSoon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberName"] != null)
        {
            if (!(null == Session["UserName"]))
            {
                ctlZipcode.Visible = false;
                imgbtnMakePayment.Visible = true;
            }
            else
            {
                ctlZipcode.Visible = true;
                imgbtnMakePayment.Visible = false;
            }
        }
        if (Session["MemberName"] != null)
        {
            ctlZipcode.Visible = false;
            imgbtnMakePayment.Visible = true;
        }
        else
        {
            ctlZipcode.Visible = true;
            imgbtnMakePayment.Visible = false;
        }
    }
    protected void imgbtnMakePayment_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/PaymentPrepaid.aspx");
    }
}
