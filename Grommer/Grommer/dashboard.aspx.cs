using System;
using System.Data;

public partial class dashboard : System.Web.UI.Page
{
    #region Global Variable
    string strMsg = string.Empty;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["GroomerUserName"] != null && Session["GId"] != null)
            {
                if (!IsPostBack)
                {
                    if (Session["PageFrom"] != null)
                    {
                        if (Session["PageFrom"].ToString() == "Operations")
                        {
                            SuccesfullMessage("Appointment Completed successfully.");
                        }
                        else if (Session["PageFrom"].ToString() == "DailyOperationLog")
                        {
                            SuccesfullMessage("Appointment details submitted successfully.");
                        }
                    }

                    getAppointmentDtls(strMsg);
                    Button1.Focus();
                }
            }
            else Response.Redirect("Default.aspx?Msg=Timeout", false);
        }
        catch
        {
        }
    }

    #endregion

    #region Present All  Uncomplete Appointment
    public void getAppointmentDtls(string str)
    {
        try
        {
            Groomer objgroomer = new Groomer();
            DataSet dsDtls = objgroomer.getAppointmentDtls(Session["GId"].ToString());


            if (dsDtls.Tables.Count > 0)
            {
                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    Session["PreviousPendingAppointment"] = dsDtls.Tables[0].Rows[0]["PreviousPendingAppointment"].ToString();
                    Session["PreviousBMNeed"] = Convert.ToBoolean(dsDtls.Tables[0].Rows[0]["PreviousBMNeed"].ToString());
                    Session["PreviousEMNeed"] = Convert.ToBoolean(dsDtls.Tables[0].Rows[0]["PreviousEMNeed"].ToString());

                    Session["PresentPendingAppointment"] = dsDtls.Tables[0].Rows[0]["PresentPendingAppointment"].ToString();
                    Session["PresentBMNeed"] = Convert.ToBoolean(dsDtls.Tables[0].Rows[0]["PresentBMNeed"].ToString());
                    Session["PresentEMNeed"] = Convert.ToBoolean(dsDtls.Tables[0].Rows[0]["PresentEMNeed"].ToString());

                    Session["FutureAppointment"] = dsDtls.Tables[0].Rows[0]["FutureAppointment"].ToString();
                    Session["FutureBMNeed"] = Convert.ToBoolean(dsDtls.Tables[0].Rows[0]["FutureBMNeed"].ToString());
                    Session["FutureEMNeed"] = Convert.ToBoolean(dsDtls.Tables[0].Rows[0]["FutureEMNeed"].ToString());

                    Session["ShowGoButton"] = Convert.ToBoolean(dsDtls.Tables[0].Rows[0]["ShowGoButton"].ToString());
                    Session["NoAppointment"] = Convert.ToBoolean(dsDtls.Tables[0].Rows[0]["NoAppointment"].ToString());
                    Session["EM_AppointmentDate"] = dsDtls.Tables[0].Rows[0]["EMAppointmentDate"].ToString().Trim();
                }

                if (dsDtls.Tables[1].Rows.Count > 0)
                {
                    lbl_time.Text = dsDtls.Tables[1].Rows[0]["DateTimeFormat"].ToString().Trim();
                    lbl_description.Text = dsDtls.Tables[1].Rows[0]["Others"].ToString().Trim();

                    Session["GroomerAppointmentId"] = dsDtls.Tables[1].Rows[0]["AppointmentId"].ToString().Trim();
                    Session["UserAppointmentId"] = dsDtls.Tables[1].Rows[0]["UserScheduledId"].ToString().Trim();
                    Session["Status"] = dsDtls.Tables[1].Rows[0]["Status"].ToString().Trim();
                    Session["AppointmentDate"] = dsDtls.Tables[1].Rows[0]["AppointmentDate"].ToString().Trim();
                    Session["ExpectedRev"] = dsDtls.Tables[1].Rows[0]["ExpectedTotalRevenue"].ToString().Trim();
                    Session["ExpectedPetTime"] = dsDtls.Tables[1].Rows[0]["ExpPetTime"].ToString().Trim();
                    Session["breakPeriod"] = dsDtls.Tables[1].Rows[0]["breakPeriod"].ToString().Trim();
                    divDetails.Visible = true;

                    if (!(null == Session["UserTimeZone"]))
                    {
                        string userZone = Session["UserTimeZone"].ToString();
                        var info = TimeZoneInfo.FindSystemTimeZoneById(userZone);
                        DateTimeOffset localServerTime = DateTimeOffset.Now;
                        DateTimeOffset usersTime = TimeZoneInfo.ConvertTime(localServerTime, info);
                        string convertedTime = usersTime.DateTime.ToLongTimeString();
                        objgroomer.GroomerUpdateApptPresentedStatus(Convert.ToInt32(Session["GroomerAppointmentId"]), convertedTime);
                    }
                }
                else
                {
                    divDetails.Visible = false;
                    Button1.Visible = false;
                    ErrMessage("No Appointments Available");
                }
                if (Convert.ToInt32(Session["PreviousPendingAppointment"]) == 0 && Convert.ToInt32(Session["PresentPendingAppointment"]) == 0 && !Convert.ToBoolean(Session["PreviousEMNeed"]) && !Convert.ToBoolean(Session["PresentEMNeed"]) && Convert.ToInt32(Session["ShowGoButton"]) == 0)
                {
                    Button1 .Visible = false;
                }
                else
                {
                    bool prevBM = Convert.ToBoolean(Session["PreviousBMNeed"]);
                    bool presBM = Convert.ToBoolean(Session["PresentBMNeed"]);
                    bool presEM = Convert.ToBoolean(Session["PresentEMNeed"]);
                    bool prevEM = Convert.ToBoolean(Session["PreviousEMNeed"]);
                    int presentAppCount = Convert.ToInt32(Session["PresentPendingAppointment"]);
                    if ((prevBM == false && presBM == false) && (Convert.ToInt32(Session["FutureAppointment"]) > 0))
                    {
                        if ((prevEM == true && presentAppCount == 0) || (presEM==true && presentAppCount==0))
                        {
                            SuccesfullMessage("Appointment Completed successfully. There is no appointment available for today.");
                            divDetails.Visible = false;
                            Button1.Visible = true;
                        }
                        else {
                            Button1.Visible = true;
                        }
                    }
                    else {
                        Button1.Visible = true;
                    }

                }
            }
        }
        catch 
        {
            ErrMessage("Server Error.");
            Session.Remove("PreviousBMNeed");
            Session.Remove("PreviousEMNeed");
            Session.Remove("PresentBMNeed");
            Session.Remove("PresentEMNeed");
            Session.Remove("FutureBMNeed");
            Session.Remove("PreviousBMNeed");
        }
    }

    #endregion

    #region Message
    public void ErrMessage(string Message)
    {
        divMsg.Visible = true;
        divMsg.Attributes.Add("Class", "errorTable2");
        lblMsg.Visible = true;
        lblMsg.Text = Message;
    }

    public void SuccesfullMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    #endregion

    #region Button Click Check Redirection
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["PageFrom"] = "Dashboard.aspx";
        if (Convert.ToBoolean(Session["PreviousBMNeed"]) || Convert.ToBoolean(Session["PresentBMNeed"]))
            Response.Redirect("DailyOperationLog.aspx");
        else if ((Convert.ToInt32(Session["PreviousPendingAppointment"]) == 0 || Convert.ToInt32(Session["PresentPendingAppointment"]) == 0) && Convert.ToBoolean(Session["PreviousEMNeed"]) || Convert.ToBoolean(Session["PresentEMNeed"]))
            Response.Redirect("DailyOperationLog.aspx");
        else
            Response.Redirect("operations.aspx");
    }
    #endregion

    #region Enc/Desc
    public string EncryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
    }
    private string DecryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
    }
    #endregion
}
