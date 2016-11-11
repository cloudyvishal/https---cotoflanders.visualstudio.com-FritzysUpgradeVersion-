using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using advancewebtosolution.BO.CaptchaClass;
using advancewebtosolution.BO;
using System.Globalization;

public partial class Admin_ConfirmAppointment : System.Web.UI.Page
{
    #region Global Var
    int AppointmentId, GID;
    Groomer objGroomer = new Groomer();
    DataSet ds = new DataSet();
    string UserAppId;
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
    string StartTime = string.Empty;
    string EndTime = string.Empty;
    #endregion GetAdimn Date

    #endregion Global Var

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DateTime dt = DateTime.Now;

                BindGroomers();

                #region If  Query String Present
                if (!string.IsNullOrEmpty(Request.QueryString.ToString()))
                {
                    string strReq = "";
                    strReq = Request.RawUrl;
                    strReq = strReq.Substring(strReq.IndexOf('?') + 1);

                    if (!strReq.Equals(""))
                    {
                        strReq = DecryptQueryString(strReq);
                        string[] arrMsgs = strReq.Split('&');
                        string[] arrIndMsg;
                        arrIndMsg = arrMsgs[0].Split('=');
                        CustName.Text = arrIndMsg[1].ToString().Trim();

                        arrIndMsg = arrMsgs[1].Split('=');
                        CustEmail.Text = arrIndMsg[1].ToString().Trim();

                        arrIndMsg = arrMsgs[2].Split('=');
                        dt = Convert.ToDateTime(arrIndMsg[1].ToString().Trim());

                        arrIndMsg = arrMsgs[3].Split('=');
                        AppointmentId = Convert.ToInt32(arrIndMsg[1].ToString().Trim());
                        Session["AppointmentId"] = arrIndMsg[1].ToString().Trim();
                        Session["GAppointmentId"] = "";
                        BindInsertUpdateAdminRevenue(AppointmentId);
                    }
                }
                #endregion If  Query String Present

                #region If No  Query String Present
                else
                {
                    if (Request.Cookies["AppCookies"] != null)
                    {
                        CustName.Text = Request.Cookies["AppCookies"]["CustomerName"].ToString();
                        CustEmail.Text = Request.Cookies["AppCookies"]["CustomerEmail"].ToString();
                        AppointmentId = Convert.ToInt32(Request.Cookies["AppCookies"]["AppointmentID"].ToString());
                        BindInsertUpdateAdminRevenue(AppointmentId);
                        string dtcoo = Request.Cookies["AppCookies"]["AppointmentDate"].ToString();
                        dt = Convert.ToDateTime(Request.Cookies["AppCookies"]["AppointmentDate"]);
                    }
                    else
                    {
                        Response.Redirect("Appointment.aspx");
                    }
                }
                #endregion If No  Query String Present

                txtDate.Text = ConvertToMilitaryDatatime(dt);
                btnSave.Enabled = true;
                #region Double Book
                #endregion Double Book
            }
        }
        catch  { }
    }
    private string DecryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
    }
    #endregion Page Load

    #region Bind Data
    protected void BindInsertUpdateAdminRevenue(int AppId)
    {
        try
        {
            Groomer objGroomer = new Groomer();
            DataSet ds = new DataSet();
            ds = objGroomer.BindInsertUpdateAdminRevenue(AppId);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["UserScheduledID"].ToString()) > 0)
                    {
                        Session["AppointmentId"] = Convert.ToInt32(ds.Tables[0].Rows[0]["UserScheduledID"].ToString());
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["appointmentID"].ToString()) > 0)
                    {
                        Session["GAppointmentId"] = Convert.ToInt32(ds.Tables[0].Rows[0]["appointmentID"].ToString());
                    }

                    ddlGroomerlist.SelectedValue = ds.Tables[0].Rows[0]["GID"].ToString();
                    GID = Convert.ToInt32(ds.Tables[0].Rows[0]["GID"].ToString());
                    txtDate.Text = ds.Tables[0].Rows[0]["AppointmentDate"].ToString();
                    txtOthers.Text = ds.Tables[0].Rows[0]["Others"].ToString();
                    txtTotalRevnueExpected.Text = ds.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString();
                    txtExpectedpettime.Text = ds.Tables[0].Rows[0]["ExpPetTime"].ToString();
                    txtSequence.Text = ds.Tables[0].Rows[0]["SequenceNo"].ToString();
                }
                else
                {
                    Session["AppointmentId"] = AppointmentId;
                    Session["GAppointmentId"] = 0;
                }
            }
        }
        catch  { }
    }
    public void BindGroomers()
    {
        try
        {
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
        catch  { }
    }
    #endregion Bind Data

    #region Message

    public void ErrorMessage(string Message)
    {
        lblDoubleBook.Visible = false;
        divError.Visible = true;
        lblError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
        btnSave.Enabled = false;
    }

    public void SuccessMessage(string Message)
    {
        lblDoubleBook.Visible = false;
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    #endregion Message

    #region COnvert Date To Military Date Time Formate
    private string ConvertToMilitaryDatatime(DateTime dt)
    {
        string militaryDateTime = string.Empty;
        try
        {
            if (dt.ToString("dd/MM/yyyy hh:mm:ss tt").Contains("AM"))
            {
                if (dt.Minute == 0)
                {
                    if (dt.Hour > 9)
                    {
                        militaryDateTime = dt.Date.ToString("yyMMdd") + "." + dt.Hour + "00-" + (dt.Hour + 2) + "00";
                    }
                    else
                    {
                        militaryDateTime = dt.Date.ToString("yyMMdd") + ".0" + dt.Hour + "00-" + (dt.Hour + 2) + "00";
                    }

                }
                else
                {
                    militaryDateTime = dt.Date.ToString("yyMMdd") + "." + dt.Hour + dt.Minute + "-" + (dt.Hour + 2) + "00";
                }
            }
            else if (dt.ToString("dd/MM/yyyy hh:mm:ss tt").Contains("PM"))
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
            CalculateTimeDifference(new DateTime().Add(new TimeSpan(dt.Hour, dt.Minute, 0)).ToString("yy/MM/dd hh:mm tt"), new DateTime().Add(new TimeSpan(dt.Hour + 2, dt.Minute, 0)).ToString("yy/MM/dd hh:mm tt"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return militaryDateTime;
    }
    #endregion COnvert Date To Military Date Time Formate

    #region Save Appointment
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            GetAdminConfirmDate();
            if (!string.IsNullOrEmpty(DateReturn.ToString()))
            {
                Groomer objGroomer = new Groomer();
                DataSet dsseq = new DataSet();
                DataSet ds4 = new DataSet();
                string ApptString = txtOthers.Text;
                UserAppId = AppointmentId.ToString();
                #region MaxSequencenoOfGroomer
                dsseq = objGroomer.GetMaxSequencenoOfGroomer(Convert.ToInt32(ddlGroomerlist.SelectedValue), DateReturn.ToString());
                if (dsseq.Tables[0].Rows.Count > 0)
                {
                    #region MaxSequencenoOfGroomer To Changed
                    if (Convert.ToInt32(txtSequence.Text) > Convert.ToInt32(dsseq.Tables[0].Rows[0]["sequence"]))
                    {
                        //ErrorMessage("Please enter sequence no in proper order.");
                        // lblDoubleBook.Visible = true;
                        txtSequence.Text = dsseq.Tables[0].Rows[0]["sequence"].ToString();
                    }
                    #endregion MaxSequencenoOfGroomer To Changed


                    #region MaxSequencenoOfGroomer To Update
                    else
                    {
                        //Get Next groomer sequence and update the sequence and then insert new appointment
                        //ds4 = objGroomer.GetGroomerNextsequenceForupdate(Convert.ToInt32(dsseq.Tables[0].Rows[0]["GId"]), Session["SelectedDate"].ToString(), Convert.ToInt32(txtSequence.Text));
                        ds4 = objGroomer.GetGroomerNextsequenceForupdate(Convert.ToInt32(dsseq.Tables[0].Rows[0]["GId"]), Convert.ToDateTime(DateReturn.ToString()), Convert.ToInt32(txtSequence.Text));
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            for (int m = 0; m < ds4.Tables[0].Rows.Count; m++)
                            {
                                int h = Convert.ToInt32(ds4.Tables[0].Rows[m]["SequenceNo"]) + 1;
                                // lblDoubleBook.Visible = true;
                                objGroomer.UpdateGroomerSequence(Convert.ToInt32(ds4.Tables[0].Rows[0]["GId"]), Convert.ToDateTime(DateReturn), h, Convert.ToInt32(ds4.Tables[0].Rows[m]["AppointmentId"]));
                            }
                        }

                        #region Confirm Appointment & Rec Tech
                        int i = objGroomer.ConfirmAppointment(Convert.ToInt32(Session["GAppointmentId"].ToString()), Convert.ToInt32(ddlGroomerlist.SelectedValue), Convert.ToDateTime(DateReturn.ToString()), "", "", txtTotalRevnueExpected.Text, txtOthers.Text, txtDate.Text, Convert.ToInt32(txtSequence.Text), Convert.ToDecimal(txtExpectedpettime.Text), CustName.Text, CustEmail.Text, StartTime, EndTime, Convert.ToInt32(Session["AppointmentId"].ToString()));

                        #endregion Confirm Appointment & Rec Tech

                        if (i > 0)
                        {
                            // MakeRecConfirmAppointment(i, txtOthers.Text);
                            RemoveCookiesSession();
                            Response.Redirect("Appointment.aspx");
                        }
                    }
                    #endregion MaxSequencenoOfGroomer To Update
                }
                else
                {
                    if (Convert.ToInt32(txtSequence.Text) == 1)
                    {
                        txtSequence.Text = "1";
                        int i = objGroomer.ConfirmAppointment(Convert.ToInt32(Session["GAppointmentId"].ToString()), Convert.ToInt32(ddlGroomerlist.SelectedValue), Convert.ToDateTime(DateReturn.ToString()), "", "", txtTotalRevnueExpected.Text, txtOthers.Text, txtDate.Text, Convert.ToInt32(txtSequence.Text), Convert.ToDecimal(txtExpectedpettime.Text), CustName.Text, CustEmail.Text, StartTime, EndTime, Convert.ToInt32(Session["AppointmentId"].ToString()));

                        if (i > 0)
                        {
                            // MakeRecConfirmAppointment(i, txtOthers.Text);
                            RemoveCookiesSession();
                            Response.Redirect("Appointment.aspx");
                        }
                    }
                    else
                    {
                        ErrorMessage("Please enter sequence no in proper order.");
                    }
                }
                #endregion MaxSequencenoOfGroomer
            }
            else
            {
                ErrorMessage("Error: Date Can't be null");
                txtDate.Focus();
            }
        }
        catch  { }
    }

    #endregion Save Appointment

    #region Remove CookiesSession
    protected void RemoveCookiesSession()
    {
        if (Request.Cookies["AppCookies"] != null)
        {
            Request.Cookies["AppCookies"].Expires = DateTime.Now.AddDays(-1);
        }
        Session.Remove("AppointmentId");
        Session.Remove("GAppointmentId");
    }
    #endregion Remove CookiesSession

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
                        objGroomer.MakeRecConfirmAppointment(int.Parse(Request.Cookies["AppCookies"]["AppointmentID"]), GAppId, dt, CustEmail.Text, MilitaryDateTime);
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

    #region Page Control Events Handler
    protected void ddlGroomerlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroomerlist.SelectedValue != "0")
        {
            GetAdminConfirmDate();
            GetMaxSequencenoOfGroomer();
            divError.Visible = false;
            txtDate.Focus();
        }
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GetAdminConfirmDate();
            if (DateReturn != "")
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
        catch  { }
    }
    #endregion Page Control Events Handler

    #region Cancel 
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Appointment.aspx");
    }

    #endregion Cancel 

    #region Other Functions 
    public void GetMaxSequencenoOfGroomer()
    {
        try
        {
            if (DateReturn != null || DateReturn != "")
            {
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
        }
        catch  { }
    }
    protected void GetAdminConfirmDate()
    {
        try
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
        catch  { }
    }
    #endregion Other Functions 

    #region Calculate Pet Time
    private void CalculateTimeDifference(string d1, string d2)
    {
        if (d1 != "" && d2 != "")
        {
            try
            {
                txtExpectedpettime.Text = (Convert.ToDateTime(d2) - Convert.ToDateTime(d1)).TotalHours.ToString("N4");
            }
            catch
            {
                txtExpectedpettime.Text = "0";
            }
        }
    }
    #endregion
}