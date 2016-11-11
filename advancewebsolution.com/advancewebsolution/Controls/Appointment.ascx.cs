using System;
using System.Data;
using System.Web.UI;
using advancewebtosolution.BO;

/*
    Appointment control is used on Index page function 
    display appointment logo and as per User redirect takes place 
    First check user from session UserType
    as new user will redirect to registration full
    If registered but not eligible for the schecdule appointment will redirect to Update Account
    If registered and eligible for the schecdule appointment will redirect to Update Account
 */

public partial class Controls_Appointment : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if ((Session["MemberName"] == null) || (Session["MemberName"].ToString() == ""))
            {
                logAppointment.Visible = true;
                NormalAppointment.Visible = false;
            }
            else
            {
                NormalAppointment.Visible = true;
                logAppointment.Visible = false;
            }
       
    }
    protected void ImgAppointment_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["MemberName"] != null)
        {
            StoreFrontUser ObjUserCheck = new StoreFrontUser();
            DataSet ds = new DataSet();
            ds = ObjUserCheck.IsFullProfile(Convert.ToInt32(Session["UserID"].ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    Response.Redirect("AppointmentNew.aspx");
                }
                else
                {
                    Response.Redirect("MyAccount.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("Registration_Full.aspx");
        }
    }
}
