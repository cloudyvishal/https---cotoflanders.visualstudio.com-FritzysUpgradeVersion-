using System;
using System.Data;
using System.Web.UI;

public partial class Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberName"] != null)
        {
            divUserName.Attributes.Add("style", "Display:block");
            lblWelcome.Text = "Welcome - " + Session["MemberName"].ToString();

            DataSet ds = new DataSet();
            if (!(null == Session["UserName"]))
            {
                ctlZipcode.Visible = false;
                imgbtnMakePayment.Visible = true;
            }
            else
            {
                divUserName.Attributes.Add("style", "Display:none");
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

