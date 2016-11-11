using System;
using System.Data;
using System.Web.UI;
public partial class Services : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Session["UserType"] is use to set UseType 0 (Guest/Annonymus) ,1(Cat), 2(Dog) ,3(catDog)
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

       
        if (Session["UserType"].ToString() == "4")
        {
            Control bodyCntrl = LoadControl("Controls/Services_Common.ascx");
            plcServices.Controls.Add(bodyCntrl);
        }

        if (Session["UserType"].ToString() == "1")
        {
            Control bodyCntrl = LoadControl("Controls/Services_Common_cat.ascx");
            plcServices.Controls.Add(bodyCntrl);
        }

        if (Session["UserType"].ToString() == "2")
        {
            Control bodyCntrl = LoadControl("Controls/Services_Common_dog.ascx");

            plcServices.Controls.Add(bodyCntrl);
        }
        if (Session["UserType"].ToString() == "3")
        {
            Control bodyCntrl = LoadControl("Controls/Services_Common.ascx");
            plcServices.Controls.Add(bodyCntrl);
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
