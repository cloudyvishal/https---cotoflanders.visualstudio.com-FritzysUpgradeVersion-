using System;
using System.Web.UI;
using System.Data;
using System.Configuration;
public partial class DailyOperationLog : Page
{
    #region Variable
    Groomer objgroomer = new Groomer();
    string strGID = string.Empty, GroomerAppointmentId = string.Empty, Status = string.Empty, AppointmentDate = string.Empty, errorMsg = string.Empty;
    static string Flag = string.Empty, PFieldID = string.Empty;
    string strMsg = string.Empty;
    int iGId;
    bool PreviousBMNeed = false;
    bool PreviousEMNeed = false;
    bool PresentBMNeed = false;
    bool PresentEMNeed = false;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strGID = Session["GId"].ToString();
            iGId = Convert.ToInt32(Session["GId"].ToString());
            if (!(null == Session["GroomerAppointmentId"])) { GroomerAppointmentId = Session["GroomerAppointmentId"].ToString(); }
            if (!(null == Session["Status"])) { Status = Session["Status"].ToString(); }
            if (!(null == Session["AppointmentDate"])) { AppointmentDate = Convert.ToString(Session["AppointmentDate"]); }
            if (!(null == Session["EM_AppointmentDate"])) { AppointmentDate = Convert.ToString(Session["EM_AppointmentDate"]); }

            PreviousBMNeed = Convert.ToBoolean(Session["PreviousBMNeed"]);
            PreviousEMNeed = Convert.ToBoolean(Session["PreviousEMNeed"]);
            PresentBMNeed = Convert.ToBoolean(Session["PresentBMNeed"]);
            PresentEMNeed = Convert.ToBoolean(Session["PresentEMNeed"]);
            if (!IsPostBack)
            {
                txtDate.Text = AppointmentDate != "" ? Convert.ToDateTime(AppointmentDate).ToShortDateString() : DateTime.Now.ToShortDateString();
                getParantFields();
                ClearSession();
            }
        }
        catch
        {
            Response.Redirect("Default.aspx?Msg=Timeout", false);
        }
    }
    #endregion

    #region Clear Session
    protected void ClearSession()
    {
        Session.Remove("ApptTimings");
        Session.Remove("CardDetails");
    }
    #endregion

    #region Check Redirection
    protected void CheckRedirect()
    {
        Session["PageFrom"] = "DailyOperationLog";

        if (PresentBMNeed || PreviousBMNeed)
            Response.Redirect("Operations.aspx", false);

        else if (PresentEMNeed || PresentEMNeed)
        {
            Response.Redirect("Dashboard.aspx", false);
        }
    }
    #endregion

    #region Message
    public void ErrMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    public void SuccesfullMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    #endregion

    #region Submit Daily Operation Log (Only On Start of Day and at End of Day's Appointment)
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (Session["AppointmentDate"] != null)
                {
                    if (txtEndingMileage.Text != string.Empty)
                        if (Convert.ToInt32(txtEndingMileage.Text) <= Convert.ToInt32(txtBeginningMileage.Text))
                        {
                            ErrMessage("Ending mileage should be greater than beginning mileage unless van ID has changed");
                            return;
                        }
                    insertParantFields();
                    Session["VanID"] = txtVanID.Text.Trim();
                    Session["BeginningMileage"] = txtBeginningMileage.Text.Trim();
                    Session["TotalHours"] = txtTotalHours.Text.Trim();
                    Session["EndingMileage"] = txtEndingMileage.Text.Trim();
                    Session["FuelPurchased"] = txtFuelPurchased.Text.Trim();
                    Session["PriceperGallon"] = txtPriceperGallon.Text.Trim();
                    PresentEMNeed = true;
                    CheckRedirect();

                }
                else if (PreviousEMNeed || PresentEMNeed)
                {
                    insertParantFields();

                }
                else
                {
                    Response.Redirect("Dashboard.aspx?msg=S", false);
                }
            }
        }
        catch
        {
        }
    }
    #endregion

    #region Save ParantFields
    public void insertParantFields()
    {
        try
        {
            errorMsg = GetGroomerYesterdayMileage();
            if (errorMsg == "Beginning")
            {
                ErrMessage("Beginning mileage should be greater than or equal to yesterday's ending mileage unless van ID has changed");
                return;
            }
            else if (errorMsg == "SendMail")
            {
                objgroomer.insertParantFields(strGID, txtVanID.Text.Trim(), txtBeginningMileage.Text.Trim(), txtTotalHours.Text.Trim(), txtEndingMileage.Text.Trim(), txtFuelPurchased.Text.Trim(), txtPriceperGallon.Text.Trim(), DateTime.Now.ToString(), Session["Flag"].ToString(), Session["PFieldID"].ToString(), Convert.ToDateTime(Session["AppointmentDate"]));
                Session["DailyLogID"] = string.Empty;
            }
            else if (errorMsg == "")
            {
                objgroomer.insertParantFields(strGID, txtVanID.Text.Trim(), txtBeginningMileage.Text.Trim(), txtTotalHours.Text.Trim(), txtEndingMileage.Text.Trim(), txtFuelPurchased.Text.Trim(), txtPriceperGallon.Text.Trim(), DateTime.Now.ToString(), Session["Flag"].ToString(), Session["PFieldID"].ToString(), Convert.ToDateTime(Session["AppointmentDate"]));
                Session["DailyLogID"] = string.Empty;
            }
        }
        catch
        {
        }
    }
    #endregion

    #region Get Parent Field
    public void getParantFields()
    {
        try
        {
            string flag = null;
            if (PreviousBMNeed)
                flag = "PreviousBMNeed";
            else if (PreviousEMNeed)
                flag = "PreviousEMNeed";
            else if (PresentBMNeed)
                flag = "PresentBMNeed";
            else if (PresentEMNeed)
                flag = "PresentEMNeed";
            DataSet ds = objgroomer.getParantFields(strGID, flag);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (PreviousEMNeed)
                {
                    txtVanID.Text = ds.Tables[0].Rows[0]["VanID"].ToString();
                    txtBeginningMileage.Text = ds.Tables[0].Rows[0]["BeginningMileage"].ToString() != "0" ? ds.Tables[0].Rows[0]["BeginningMileage"].ToString() : string.Empty;
                    txtBeginningMileage.Enabled = false;
                    txtTotalHours.Text = ds.Tables[0].Rows[0]["TotalHours"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["TotalHours"].ToString();
                    divEndingMileage.Visible = true;
                    divEndingMileage.Disabled = false;
                    txtFuelPurchased.Text = ds.Tables[0].Rows[0]["FuelPurchased"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["FuelPurchased"].ToString();
                    txtPriceperGallon.Text = ds.Tables[0].Rows[0]["PriceperGallon"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["PriceperGallon"].ToString();
                    PFieldID = ds.Tables[0].Rows[0]["PFieldID"].ToString();
                    Flag = "U";
                    txtEndingMileage.Focus();
                }
                else if (PresentBMNeed || PreviousBMNeed)
                {
                    Session["VanId"] = ds.Tables[0].Rows[0]["VanID"].ToString();
                    // --> Van ID and Begninning Mileage would not populated automatically.
                    // txtVanID.Text = ds.Tables[0].Rows[0]["VanID"].ToString();
                    // txtBeginningMileage.Text = ds.Tables[0].Rows[0]["EndingMileage"].ToString() != "0" ? ds.Tables[0].Rows[0]["EndingMileage"].ToString() : string.Empty;
                    txtBeginningMileage.Text = string.Empty;
                    Session["YesterdayBeginningMileage"] = ds.Tables[0].Rows[0]["BeginningMileage"].ToString();
                    txtBeginningMileage.Enabled = true;
                    txtTotalHours.Text = ds.Tables[0].Rows[0]["TotalHours"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["TotalHours"].ToString();
                    divEndingMileage.Visible = false;
                    Session["YesterdayEndingMileage"] = ds.Tables[0].Rows[0]["EndingMileage"].ToString();
                    txtFuelPurchased.Text = ds.Tables[0].Rows[0]["FuelPurchased"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["FuelPurchased"].ToString();
                    Session["YesterdayFuelPurchased"] = ds.Tables[0].Rows[0]["FuelPurchased"].ToString();
                    txtPriceperGallon.Text = ds.Tables[0].Rows[0]["PriceperGallon"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["PriceperGallon"].ToString();
                    Session["YesterdayPriceperGallon"] = ds.Tables[0].Rows[0]["PriceperGallon"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["PriceperGallon"].ToString();
                    PFieldID = ds.Tables[0].Rows[0]["PFieldID"].ToString();
                    Flag = "I";
                    // txtBeginningMileage.Focus();
                    txtVanID.Focus();
                }
                else if (PresentEMNeed)
                {
                    txtVanID.Text = ds.Tables[0].Rows[0]["VanID"].ToString();
                    txtBeginningMileage.Text = ds.Tables[0].Rows[0]["BeginningMileage"].ToString() != "0" ? ds.Tables[0].Rows[0]["BeginningMileage"].ToString() : string.Empty;
                    txtBeginningMileage.Enabled = false;
                    txtTotalHours.Text = ds.Tables[0].Rows[0]["TotalHours"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["TotalHours"].ToString();
                    divEndingMileage.Visible = true;
                    divEndingMileage.Disabled = false;
                    txtFuelPurchased.Text = ds.Tables[0].Rows[0]["FuelPurchased"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["FuelPurchased"].ToString();
                    txtPriceperGallon.Text = ds.Tables[0].Rows[0]["PriceperGallon"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["PriceperGallon"].ToString();
                    PFieldID = ds.Tables[0].Rows[0]["PFieldID"].ToString();
                    Flag = "U";
                    txtEndingMileage.Focus();
                }
            }
            else
            {
                Flag = "I";
                PFieldID = "";
                divEndingMileage.Visible = false;
                Session["VanId"] = string.Empty;
                Session["YesterdayBeginningMileage"] = string.Empty;
                Session["YesterdayFuelPurchased"] = string.Empty;
                Session["YesterdayEndingMileage"] = string.Empty;
                Session["YesterdayPriceperGallon"] = string.Empty;
                txtBeginningMileage.Enabled = true;
                txtVanID.Focus();
            }
            Session["Flag"] = Flag;
            Session["PFieldID"] = PFieldID;
        }
        catch
        {
            Response.Redirect("Dashboard.aspx", false);
        }
    }
    #endregion

    #region GetGroomerYesterdayMileage
    public string GetGroomerYesterdayMileage()
    {
        string str = string.Empty;
        try
        {
            DataSet ds = objgroomer.GetGroomerYesterdayMileage(Convert.ToDateTime(DateTime.Now.AddDays(-1)).ToString(), Session["GId"].ToString(), txtVanID.Text.Trim());
            if (ds.Tables.Count > 0)
                if (ds.Tables[0].Rows.Count > 0)
                {
                    #region Check for Todays First Appointment Start or Last
                    if (Convert.ToBoolean(Session["PresentBMNeed"]))
                        if (Convert.ToInt32(txtBeginningMileage.Text) < Convert.ToInt32(ds.Tables[0].Rows[0]["EndingMileage"]))
                            str = "Beginning";
                    #endregion

                    int diff = 0;
                    int endmileage = Convert.ToInt32(ds.Tables[0].Rows[0]["EndingMileage"]);
                    if (endmileage > 0)
                        diff = Convert.ToInt32(txtBeginningMileage.Text) - endmileage;

                    if (diff > 2)
                    {
                        GroomerBegningMileageMail("Beginning mileage is more than 2 miles than yesterday’s ending mileage");
                        str = "SendMail";
                    }
                }
        }
        catch
        {
        }
        return str;
    }
    #endregion

    #region Send Todays Beginig Mileage
    public void GroomerBegningMileageMail(string body)
    {
        try
        {
            string Mailbody = ContentManager.GetStaticeContentEmail("GroomerBegningMileage.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- Update -->", body);
            Mailbody = Mailbody.Replace("<!-- UserName -->", Session["GroomerUserName"].ToString());
            SendMail ObjMail = new SendMail();
            ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), Convert.ToString(Session["GroomerUserName"]) + " begning mileage mismatch yesterdays ending mileage", Mailbody);
        }
        catch
        {
        }
    }
    #endregion

    #region Get groomer Current Appointment Details
    protected void GetgroomerTodaysAppointment(string appointmentDate)
    {
        try
        {
            DataSet ds1 = objgroomer.GetgroomerTodaysAppointment(iGId, appointmentDate);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    if (ds1.Tables[0].Rows[i]["paidStatus"].ToString().ToLower() != "prepaid" && (GroomerAppointmentId == ds1.Tables[0].Rows[i]["AppointmentId"].ToString()))
                    {
                        txtEndingMileage.Enabled = true;
                        txtTotalHours.Enabled = true;
                    }
            }
            else CheckRedirect();
        }
        catch
        {
        }
    }
    #endregion

    #region Change Van Id Control
    protected void txtVanID_TextChanged(object sender, EventArgs e)
    {
        string vanId = txtVanID.Text;
        if (Session["VanId"] != null)
        {
            if (vanId != "" && vanId != Session["VanId"].ToString())
            {
                if (Convert.ToInt32(vanId) > 0) getDailyOperationLogUsingVanIdAndGId(Convert.ToInt32(vanId));
            }
            else if (vanId == Session["VanId"].ToString())
            {
                txtEndingMileage.Text = string.Empty;
                txtEndingMileage.Enabled = true;
                txtBeginningMileage.Text = Session["YesterdayEndingMileage"] != null ? Session["YesterdayEndingMileage"].ToString() : string.Empty;
                if (Session["YesterdayEndingMileage"] != null) txtBeginningMileage.Enabled = false;
                else txtBeginningMileage.Enabled = true;
                txtFuelPurchased.Text = Session["YesterdayFuelPurchased"] != null && Session["YesterdayFuelPurchased"].ToString() != "0.00" ? Session["YesterdayFuelPurchased"].ToString() : string.Empty;
                txtPriceperGallon.Text = Session["YesterdayPriceperGallon"] != null && Session["YesterdayPriceperGallon"].ToString() != "0.00" ? Session["YesterdayPriceperGallon"].ToString() : string.Empty;
                txtTotalHours.Text = string.Empty;
                txtEndingMileage.Focus();
            }
        }
        else if (vanId == "")
        {
            ClearDailyLogFields();
            txtVanID.Focus();
        }
        else if (Convert.ToInt32(vanId) > 0)
        {
            getDailyOperationLogUsingVanIdAndGId(Convert.ToInt32(vanId));
        }
    }
    private void getDailyOperationLogUsingVanIdAndGId(int vanId)
    {
        DataSet ds = objgroomer.getDailyOperationLogUsingVanIdAndGId(strGID, DateTime.Now.ToString(), vanId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["VanId"] = ds.Tables[0].Rows[0]["VanID"] != null ? ds.Tables[0].Rows[0]["VanID"].ToString() : null;
            txtVanID.Text = ds.Tables[0].Rows[0]["VanID"] != null ? ds.Tables[0].Rows[0]["VanID"].ToString() : string.Empty;
            txtBeginningMileage.Text = ds.Tables[0].Rows[0]["EndingMileage"] != null ? ds.Tables[0].Rows[0]["EndingMileage"].ToString() : string.Empty;
            Session["YesterdayBeginningMileage"] = ds.Tables[0].Rows[0]["BeginningMileage"] != null ? ds.Tables[0].Rows[0]["BeginningMileage"].ToString() : string.Empty;
            txtBeginningMileage.Enabled = false;
            txtTotalHours.Text = ds.Tables[0].Rows[0]["TotalHours"] != null ? ds.Tables[0].Rows[0]["TotalHours"].ToString() : string.Empty;
            txtEndingMileage.Text = string.Empty;
            txtEndingMileage.Enabled = true;
            Session["YesterdayEndingMileage"] = ds.Tables[0].Rows[0]["EndingMileage"].ToString();
            txtFuelPurchased.Text = ds.Tables[0].Rows[0]["FuelPurchased"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["FuelPurchased"].ToString();
            Session["YesterdayFuelPurchased"] = ds.Tables[0].Rows[0]["FuelPurchased"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["FuelPurchased"].ToString();
            txtPriceperGallon.Text = ds.Tables[0].Rows[0]["PriceperGallon"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["PriceperGallon"].ToString();
            Session["YesterdayPriceperGallon"] = ds.Tables[0].Rows[0]["PriceperGallon"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["PriceperGallon"].ToString();
            PFieldID = ds.Tables[0].Rows[0]["PFieldID"].ToString();
            Flag = "U";
            txtPriceperGallon.Text = ds.Tables[0].Rows[0]["PriceperGallon"].ToString() == "0.00" ? string.Empty : ds.Tables[0].Rows[0]["PriceperGallon"].ToString();
            Session["YesterdayPriceperGallon"] = ds.Tables[0].Rows[0]["PriceperGallon"].ToString();
            txtEndingMileage.Focus();
        }
        else
        {
            Flag = "I";
            PFieldID = "";
            ClearDailyLogFields();
            txtBeginningMileage.Focus();
        }
        Session["Flag"] = Flag;
        Session["PFieldID"] = PFieldID;
    }
    #endregion

    #region Clear Form
    private void ClearDailyLogFields()
    {
        txtEndingMileage.Enabled = true;
        txtEndingMileage.Text = string.Empty;
        txtBeginningMileage.Text = string.Empty;
        txtBeginningMileage.Enabled = true;
        txtFuelPurchased.Text = string.Empty;
        txtPriceperGallon.Text = string.Empty;
        txtTotalHours.Text = string.Empty;
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
