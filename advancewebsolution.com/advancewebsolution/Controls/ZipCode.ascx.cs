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
using advancewebtosolution.BO;

public partial class Controls_ZipCode : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberName"] != null)
        {
            lblWelcome.Text = "Welcome - " + Session["MemberName"].ToString();
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        PanelFiveImg.Attributes.Add("Style", "display: block");
        if (txtZip.Text == "")
        {
            lblResult.Text = "Please enter zipcode";
            btnOk.Visible = false;
            btnCancel.Visible = true;
        }
        else
        {
            btnCancel.Visible = false;
            btnOk.Visible = true;
            Global ObjZipcode = new Global();
            DataSet ds = new DataSet();
            ds = ObjZipcode.GetZipCodeFront(txtZip.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblResult.Text = txtZip.Text + " Yes we provide service in this area";
                ViewState["IsZip"] = "1";
            }
            else
            {
                lblResult.Text = "We’re sorry, we aren’t yet in that area. Please join Fritzy’s Club and we will let you know as soon as we are.";
                ViewState["IsZip"] = "0";
                txtZip.Text = "";
            }
        }
        
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
         
    }
}
