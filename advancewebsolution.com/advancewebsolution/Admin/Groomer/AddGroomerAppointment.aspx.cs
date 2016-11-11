using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using advancewebtosolution.BO;
using System.Globalization;

public partial class Admin_Groomer_AddGroomerAppointment : System.Web.UI.Page
{
    #region Var
    Groomer objGroomer = new Groomer();
    DataSet ds = new DataSet();
    int UserAppId;
    #endregion Var

    #region GetAdimn Date
    DateTime adminConfirmtxtDate = Convert.ToDateTime(DateTime.Now);
    string adminConfirmDate = string.Empty;
    string[] calYearMonthDate = new string[2];
    string calYear = string.Empty;
    string calMonth = string.Empty;
    string calDate = string.Empty;
    string[] calCompleteTime = new string[2];
    string calStartTime = string.Empty;
    string calStartMinute = string.Empty;
    string calStartHour = string.Empty;
    string calEndTime = string.Empty;
    string calEndMinute = string.Empty;
    string calEndHour = string.Empty;
    string calStartSecond = string.Empty;
    string calEndSecond = string.Empty;
    string DateReturn = string.Empty;
    string AMPMStart = string.Empty;
    string AMPMEnd = string.Empty;
    string StartTime, EndTime;
    #endregion GetAdimn Date

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGroomers();
            if (txtSequence.Text != "" && txtSequence.Text != "1" && txtSequence.Text != "0")
            {
                lblDoubleBook.Visible = true;
                txtOthers.Focus();
            }
            else
                lblDoubleBook.Visible = false;
        }
    }
    #endregion PageLoad

    #region Messages
    public void ErrorMessage(string Message)
    {
        lblDoubleBook.Visible = false;
        divError.Visible = true;
        lblError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    public void SuccessMessage(string Message)
    {
        lblDoubleBook.Visible = false;
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    #endregion Messages

    #region Bind Groomer
    public void BindGroomers()
    {
        ddlGroomerlist.Items.Clear();
        Groomer objGroomer = new Groomer();
        DataSet ds = new DataSet();
        ds = objGroomer.BindGroomers();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ListItem lst = new ListItem();
            lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
            ddlGroomerlist.DataTextField = "Name";
            ddlGroomerlist.DataValueField = "Gid";
            ddlGroomerlist.DataSource = ds.Tables[0];
            ddlGroomerlist.DataBind();
            ddlGroomerlist.Items.Insert(0, lst);
        }
    }
    #endregion Bind Groomer

    #region Add Appointment
    protected void btnSave_Click(object sender, EventArgs e)
    {
        GetAdminConfirmDate();
        if (!string.IsNullOrEmpty(DateReturn.ToString()))
        {
            Groomer objGroomer = new Groomer();
            DataSet dsseq = new DataSet();
            DataSet ds4 = new DataSet();
            string ApptString = txtOthers.Text;
            if (ApptString.Contains('!'))
            {
                string[] getId = ApptString.Split('!');
                string tempappid = getId[1];
                UserAppId = (tempappid == "") ? 0 : Convert.ToInt32(tempappid);
            }
            dsseq = objGroomer.GetMaxSequencenoOfGroomer(Convert.ToInt32(ddlGroomerlist.SelectedValue), DateReturn.ToString());

            #region 1
            if (dsseq.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(txtSequence.Text) > Convert.ToInt32(dsseq.Tables[0].Rows[0]["sequence"]))
                {
                    //ErrorMessage("Please enter sequence no in proper order.");
                    lblDoubleBook.Visible = true;
                    txtSequence.Text = dsseq.Tables[0].Rows[0]["sequence"].ToString();
                }
                else
                {
                    //Get Next groomer sequence and update the sequence and then insert new appointment
                    //  ds4 = objGroomer.GetGroomerNextsequenceForupdate(Convert.ToInt32(dsseq.Tables[0].Rows[0]["GId"]), Session["SelectedDate"].ToString(), Convert.ToInt32(txtSequence.Text));
                    ds4 = objGroomer.GetGroomerNextsequenceForupdate(Convert.ToInt32(dsseq.Tables[0].Rows[0]["GId"]), Convert.ToDateTime(DateReturn.ToString()), Convert.ToInt32(txtSequence.Text));
                    if (ds4.Tables[0].Rows.Count > 0)
                    {
                        for (int m = 0; m < ds4.Tables[0].Rows.Count; m++)
                        {
                            int h = Convert.ToInt32(ds4.Tables[0].Rows[m]["SequenceNo"]) + 1;
                            objGroomer.UpdateGroomerSequence(Convert.ToInt32(ds4.Tables[0].Rows[0]["GId"]), Convert.ToDateTime(Session["SelectedDate"]), h, Convert.ToInt32(ds4.Tables[0].Rows[m]["AppointmentId"]));
                        }
                    }

                    int i = objGroomer.AddGroomerAppointmentByAdmin(Convert.ToInt32(ddlGroomerlist.SelectedValue), Convert.ToDateTime(DateReturn), "", "", txtTotalRevnueExpected.Text, txtOthers.Text,
                        txtDate.Text, Convert.ToInt32(txtSequence.Text), Convert.ToDecimal(txtExpectedpettime.Text), txtCustomerName.Text, txtCustEmail.Text, StartTime.ToString(), EndTime.ToString());//, breakAppt, txtBreakPeriod.Text);

                    if (i > 0)
                    {
                        // MakeRecConfirmAppointment(i, txtOthers.Text);
                        Response.Redirect("ViewGroomerAppointment.aspx");
                    }
                }
            }
            #endregion 1 if

            #region 2 else
            else
            {
                if (Convert.ToInt32(txtSequence.Text) == 1)
                {

                    txtSequence.Text = "1";
                    int i = objGroomer.AddGroomerAppointmentByAdmin(Convert.ToInt32(ddlGroomerlist.SelectedValue), Convert.ToDateTime(DateReturn.ToString()), "", "",
                       txtTotalRevnueExpected.Text, txtOthers.Text, txtDate.Text, Convert.ToInt32(txtSequence.Text), Convert.ToDecimal(txtExpectedpettime.Text),
                       txtCustomerName.Text, txtCustEmail.Text, StartTime.ToString(), EndTime.ToString());//, breakAppt, txtBreakPeriod.Text);
                    if (i > 0)
                    {
                        // MakeRecConfirmAppointment(i, txtOthers.Text);
                        Response.Redirect("ViewGroomerAppointment.aspx");
                    }
                }
                else
                {
                    ErrorMessage("Please enter sequence no in proper order.");
                }
            }
            #endregion 2 else
        }
        else
        {
            ErrorMessage("Please Follow Military date format and enter time  in proper order. ");
            txtDate.Focus();
        }


    }
    #endregion Add Appointment

    #region BtnCancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewGroomerAppointment.aspx");
    }
    #endregion BtnCancel

    #region Functions
    public void GetMaxSequencenoOfGroomer()
    {
        if (DateReturn != null || DateReturn != "")
        {
            Groomer objGroomer = new Groomer();
            DataSet dsseq = new DataSet();
            dsseq = objGroomer.GetMaxSequencenoOfGroomer(Convert.ToInt32(ddlGroomerlist.SelectedValue), DateReturn.ToString());
            if (dsseq.Tables[0].Rows.Count > 0)
            {
                if (dsseq.Tables[0].Rows[0]["sequence"].ToString() != "")
                {
                    lblDoubleBook.Visible = true;
                    txtSequence.Text = dsseq.Tables[0].Rows[0]["sequence"].ToString();
                    txtOthers.Focus();
                }
                else
                {
                    txtSequence.Text = "1";
                }
            }
            else
            {
                lblDoubleBook.Visible = false;
                txtSequence.Text = "1";
            }
        }
    }
    protected void GetAdminConfirmDate()
    {
        if (txtDate.Text != "")
        {
            #region GetAdimn Date
            try
            {
                adminConfirmDate = txtDate.Text;
                calYearMonthDate = adminConfirmDate.Split('.');
                if (!(calYearMonthDate[0].Length > 6))
                {
                    calCompleteTime = calYearMonthDate[1].Split('-');
                    var startDate = DateTime.ParseExact(calYearMonthDate[0] + " " + calCompleteTime[0], "yyMMdd HHmm", CultureInfo.InvariantCulture);
                    var endDate = DateTime.ParseExact(calYearMonthDate[0] + " " + calCompleteTime[1], "yyMMdd HHmm", CultureInfo.InvariantCulture);
                    if (startDate <= endDate)
                    {
                        if (startDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            ErrorMessage("Sorry ! You have selected a sunday for Groomer Service please choose another day.");
                            txtDate.Focus();
                            return;
                        }
                        else
                        {
                            DateReturn = startDate.ToString();
                            DateTime dtstart1 = DateTime.ParseExact(calCompleteTime[0], "HHmm", CultureInfo.InvariantCulture);
                            StartTime = dtstart1.ToString("hh:mm tt");
                            DateTime dtend1 = DateTime.ParseExact(calCompleteTime[1], "HHmm", CultureInfo.InvariantCulture);
                            EndTime = dtend1.ToString("hh:mm tt");
                            btnSave.Enabled = true;
                            txtExpectedpettime.Text = (dtend1.Subtract(dtstart1)).TotalHours.ToString("N2");
                            divError.Visible = false;
                        }
                    }
                    else
                    {
                        ErrorMessage("Start date must be less than end date.");
                        txtDate.Focus();
                        return;
                    }
                }
                else
                {
                    ErrorMessage("Please Check Date..Please follow Military Date Format (yyMMdd.HHmm-HHmm)");
                    txtDate.Focus();
                    return;
                }
            }
            catch
            {
                ErrorMessage("Please Check Date Formate must match Military Date Formate(yyMMdd.HHmm-HHmm) ");
                txtDate.Focus();
                return;
            }
            #endregion GetAdimn Date
        }
    }
    #endregion

    #region Popup Controls Events
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        GetAdminConfirmDate();
        if (DateReturn.ToString() != "")
        {
            Groomer objGroomer = new Groomer();
            DataSet dsseq = new DataSet();
            dsseq = objGroomer.GetMaxSequencenoOfGroomer(Convert.ToInt32(ddlGroomerlist.SelectedValue), DateReturn.ToString());
            if (dsseq.Tables[0].Rows.Count > 0)
            {
                if (dsseq.Tables[0].Rows[0]["sequence"].ToString() != "")
                {
                    lblDoubleBook.Visible = true;
                    txtSequence.Text = dsseq.Tables[0].Rows[0]["sequence"].ToString();
                }
                else
                {
                    lblDoubleBook.Visible = false;
                    txtSequence.Text = "1";
                }
            }
            else
            {
                lblDoubleBook.Visible = false;
                txtSequence.Text = "1";
            }
            txtOthers.Focus();
        }
    }
    protected void txtCustEmail_Chenged(object sender, EventArgs e)
    {
        if (txtCustEmail.Text != "")
        {
            Groomer objGroomer = new Groomer();
            DataSet ds = new DataSet();
            ds = objGroomer.GetUserInfoUsingEmail(txtCustEmail.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    txtCustomerName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    btnSave.Enabled = true;
                    txtTotalRevnueExpected.Focus();
                    divError.Visible = false;
                }
            }
            else
            {
                txtCustomerName.Text = string.Empty;
                ErrorMessage("Incorrect Member Email...Please Try Again");
                txtCustEmail.Focus();
            }
        }
        else
        {
            txtCustomerName.Text = string.Empty;
            ErrorMessage("Please Fill Member Email to connect to Member Profile");
            txtCustEmail.Focus();
        }
    }
    protected void ddlGroomerlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroomerlist.SelectedValue != "0")
        {
            GetAdminConfirmDate();
            if (DateReturn.ToString() != "")
            {
                GetMaxSequencenoOfGroomer();
                divError.Visible = false;
            }
            txtDate.Focus();
        }
    }
    #endregion Popup Controls Events

    #region Rec Appoinment
    protected void MakeRecConfirmAppointment(int GAppId, string AppString)
    {
        List<DateTime> dtToSetRecAppointment = new List<DateTime>();
        try
        {
            if (!(string.IsNullOrEmpty(AppString)))
            {
                string AppointmentsSpan = "";
                string[] apptstr = AppString.Split(',');
                if (apptstr.Length > 0)
                {
                    #region Get Rec Number Irespective Of Position 
                    for (int i = 0; i < apptstr.Length; i++)
                    {
                        if (!(null == apptstr[i]))
                        {
                            if (apptstr[i].ToLower().ToString().Trim().StartsWith("rec") && apptstr[i].ToString().Trim().Length <= 5)
                            {
                                AppointmentsSpan = apptstr[i].ToString().Trim().Substring(3).ToString();
                                break;
                            }
                        }
                    }
                    #endregion Get Rec Number Irespective Of Position 
                }

                int number = AppointmentsSpan != "" ? Convert.ToInt32(AppointmentsSpan) : 0;
                if (number > 0)
                {
                    dtToSetRecAppointment = SetAppointmentAfterWeekRecurrence(number, Convert.ToDateTime(DateReturn.ToString()));
                }
                #region Insert/Update Rec Appointment in Appointment Table to view Member
                Groomer objGroomer = new Groomer();
                if (dtToSetRecAppointment.Count > 0)
                {
                    foreach (DateTime dt in (List<DateTime>)dtToSetRecAppointment)
                    {
                        string MilitaryDateTime = ConvertToMilitaryDatatime(dt);
                        objGroomer.MakeRecConfirmAppointmentByGroomer(GAppId, dt, txtCustEmail.Text, MilitaryDateTime);

                    }
                }
                #endregion Insert/Update Rec Appointment in Appointment Table to view Member
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region COnvert Date To Military Date Time Formate
    private string ConvertToMilitaryDatatime(DateTime dt)
    {
        string militaryDateTime = string.Empty;
        try
        {
            if (dt.ToString().Contains("AM"))
            {
                if (dt.Minute == 0)
                {
                    militaryDateTime = dt.Date.ToString("yyMMdd") + "." + dt.Hour + "00-" + (dt.Hour + 2) + "00";
                }
                else
                {
                    militaryDateTime = dt.Date.ToString("yyMMdd") + "." + dt.Hour + dt.Minute + "-" + (dt.Hour + 2) + "00"; ;
                }
            }
            else if (dt.ToString().Contains("PM"))
            {
                if (dt.Minute == 0)
                {
                    militaryDateTime = dt.Date.ToString("yyMMdd") + "." + dt.Hour + "00-" + (dt.Hour + 2) + "00";
                }
                else
                {
                    militaryDateTime = dt.Date.ToString("yyMMdd") + "." + dt.Hour + dt.Minute + "-" + (dt.Hour + 2) + "00"; ;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return militaryDateTime;
    }
    #endregion COnvert Date To Military Date Time Formate

    #region Get All Date Between date choosen By Admin and next Six Month
    protected List<DateTime> SetAppointmentAfterWeekRecurrence(int i, DateTime dtPresent)
    {
        DateTime dtFutureSixMonthDay = dtPresent.AddMonths(6);
        List<DateTime> dts = new List<DateTime>();
        for (DateTime dtPresent1 = dtPresent.AddDays(i * 7); dtPresent1.Date <= dtFutureSixMonthDay; dtPresent1 = dtPresent1.AddDays(i * 7))
        {
            dts.Add(dtPresent1);
        }
        return dts;
    }
    #endregion  Get All Date Between date choosen By Admin and next Six Month

    #endregion Rec Appoinment

    #region Break Point
    protected void ddlApptType_SelectedIndexChanged(object sender, EventArgs e)
    {



        RequiredFieldValidator rfv = new RequiredFieldValidator();

        rfv.ErrorMessage = "Please enter appointment break period.";

        rfv.BorderColor = Color.Red;

        rfv.ValidationGroup = "valContactus";

        rfv.Display = ValidatorDisplay.Dynamic;
    }
    #endregion
}
