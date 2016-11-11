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

public partial class Admin_ViewAppointment : System.Web.UI.Page
{
    int AppointmentId;
    public void BindData()
    {
        UserAppointment App = new UserAppointment();
        DataSet ds = new DataSet();
        if (Request.QueryString["ID"] != null)
        {
            ds = App.GetAppointment(Convert.ToInt32(Request.QueryString["ID"].ToString()));
            #region Paid Ammount and Status
            string ExpectedTotalRevenue = "";
            if (ds.Tables.Count >0)
            {
                 #region Table 0
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                    lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    lblPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                    txt1.Value = ds.Tables[0].Rows[0]["AppointmentID"].ToString();
                    lblDate.Text = ds.Tables[0].Rows[0]["Date"].ToString() + " " + ds.Tables[0].Rows[0]["T"].ToString();
                    lblConfirmBy.Text = ds.Tables[0].Rows[0]["ConfirmBy"].ToString();
                    lblFlex.Text = ds.Tables[0].Rows[0]["Flex"].ToString();
                    lblNote.Text = ds.Tables[0].Rows[0]["Note"].ToString();
                    lblEmail.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                    lblPetName.Text = ds.Tables[0].Rows[0]["PetName"].ToString();
                    lblConfirm.Text = ds.Tables[0].Rows[0]["ConfirmStatus"].ToString();
                    lblPaidStatus.Text = ds.Tables[0].Rows[0]["PaymentStatus"].ToString();
                   
                    #region not Paid
                    if (ds.Tables[0].Rows[0]["PaymentStatus"].ToString() == "Pending")
                    {
                        #region set Revenue Amount set By Admin  
                        if (ds.Tables[0].Rows[0]["Status"].ToString() == "Pending")
                        {
                            try
                            {
                                ExpectedTotalRevenue = ds.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString() != "" ?
                                   ds.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString() : ds.Tables[0].Rows[0]["RevenueCreditCard"].ToString() != "" ?
                                   ds.Tables[0].Rows[0]["RevenueCreditCard"].ToString() : ds.Tables[0].Rows[0]["RevenueCreditCard"].ToString() != "" ?
                                   ds.Tables[0].Rows[0]["RevenueCreditCard"].ToString() : ds.Tables[0].Rows[0]["RevenueCash"].ToString() != "" ?
                                   ds.Tables[0].Rows[0]["RevenueCash"].ToString() : ds.Tables[0].Rows[0]["RevenueInvoice"].ToString() != "" ?
                                   ds.Tables[0].Rows[0]["RevenueInvoice"].ToString() : ds.Tables[0].Rows[0]["RevenueCCY"].ToString() != "" ?
                                   ds.Tables[0].Rows[0]["RevenueCCY"].ToString() : "0.00";
                            }
                            catch
                            {
                                ExpectedTotalRevenue = "0.00";
                            }
                        }
                        #endregion set Revenue Amount set By Admin

                        #region set Revenue Amount set By Groomer
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "Completed")
                        {
                            try
                            {
                                //if (ds.Tables[0].Rows[0]["PaymentStatus"].ToString() == "Paid")
                                //{
                                //    PaidStatus = "Paid";
                                //}
                                //else if (ds.Tables[0].Rows[0]["PaymentStatus"].ToString() == "Pending")
                                //{
                                //    PaidStatus = "Pending";
                                //}
                                if (ds.Tables[0].Rows[0]["RevAmt"].ToString() != "")
                                {
                                    ExpectedTotalRevenue = ds.Tables[0].Rows[0]["RevAmt"].ToString();
                                    ExpectedTotalRevenue = ExpectedTotalRevenue.Replace(".0000", ".00");
                                }
                                else if (ds.Tables[0].Rows[0]["RevAmt"].ToString() == "" || ds.Tables[0].Rows[0]["RevAmt"].ToString() == null)
                                {
                                    ExpectedTotalRevenue = "0.00";
                                }
                            }
                            catch
                            {
                                ExpectedTotalRevenue = "0.00";
                            }
                        }
                        #endregion set Revenue Amount set By Groomer

                        else
                        {
                            ExpectedTotalRevenue = "0.00";
                        }
                    }
                    #endregion not Paid

                    #region Paid Then Show the Paid Revenue

                    else if (ds.Tables[0].Rows[0]["PaymentStatus"].ToString() == "Paid")
                    {
                        if(ds.Tables[1].Rows.Count>0)
                        {
                            ExpectedTotalRevenue = ds.Tables[1].Rows[0]["RevAmt"].ToString() != "" ? ds.Tables[1].Rows[0]["RevAmt"].ToString() : "0.00";
                          }
                    }
                    #endregion Paid Then Show the Paid Revenue
                   

                    lblPaidAmount.Text = (string)"$ " + ExpectedTotalRevenue;
                    if (ds.Tables[0].Rows.Count >0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (i != ds.Tables[0].Rows.Count - 1)
                                lblPetServices.Text += ds.Tables[0].Rows[i]["ServiceName"].ToString() + ",";
                            else
                                lblPetServices.Text += ds.Tables[0].Rows[i]["ServiceName"].ToString();

                        }

                    }
                    Session["SelectedDate"] = lblDate.Text;
                }
                #endregion Table 0
            }
            #endregion Paid Ammount and Status
            else
            {
                lblError.Text = "No record found";
            }
        }
       
    }

    public void SuccessMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"].ToString() != string.Empty)
        {
            AppointmentId = Convert.ToInt32(Request.QueryString["ID"].ToString());
        }
        if (!IsPostBack)
        {

            BindData();
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["p"] == "0")
            Response.Redirect("AdminHome.aspx");
        else
            Response.Redirect("Appointment.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlConfirm.Visible == true && ddlConfirm.SelectedValue == "No")
        {
            Groomer objGroomer = new Groomer();
            int i = objGroomer.DeleteConfirmGroomerAppointment(int.Parse(txt1.Value));
            if (i > 0)
            {
                SuccessMessage("Your content has been updated successfully");
                lblConfirm.Text = "No";
                lblConfirm.Visible = true;
                ddlConfirm.Visible = false;
            }
        }
        else if (lblConfirm.Text == "Yes")
        {
            Response.Cookies["AppCookies"]["CustomerName"] = lblName.Text;
            Response.Cookies["AppCookies"]["CustomerEmail"] = lblEmail.Text;
            Response.Cookies["AppCookies"]["AppointmentDate"] = lblDate.Text;
            Response.Cookies["AppCookies"]["AppointmentID"] = txt1.Value;
            Response.Cookies["AppCookies"].Expires = DateTime.Now.AddDays(1);
            Response.Redirect("ConfirmAppointment.aspx");
        }

    }
    protected void ddlConfirm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlConfirm.SelectedValue == "Yes")
        {
            Response.Cookies["AppCookies"]["CustomerName"] = lblName.Text;
            Response.Cookies["AppCookies"]["CustomerEmail"] = lblEmail.Text;
            Response.Cookies["AppCookies"]["AppointmentDate"] = lblDate.Text;
            Response.Cookies["AppCookies"]["AppointmentID"] = txt1.Value;
            Response.Cookies["AppCookies"].Expires = DateTime.Now.AddDays(1);
            Response.Redirect("ConfirmAppointment.aspx");
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (ddlConfirm.Visible == false)
        {
            ddlConfirm.Visible = true;
            ddlConfirm.SelectedValue = lblConfirm.Text;
            lblConfirm.Visible = false;
        }
        else
        {
            lblConfirm.Visible = false;
            ddlConfirm.SelectedValue = lblConfirm.Text;
            ddlConfirm.Visible = true;
        }
    }
}
