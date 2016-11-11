using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Operations : Page
{
    #region Global Variable
    protected DataSet dsAppointment;
    protected DataSet dsOldAppointment;
    Groomer objGroomer = new Groomer();
    int Revnue01;
    string strVanID = string.Empty, strBeginningMileage = string.Empty, strTotalHours = string.Empty, strEndingMileage = string.Empty, strPriceperGallon = string.Empty, strFuelPurchased = string.Empty;
    int FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham;
    double RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, RevenueCCY, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash;
    string strGId = string.Empty, CustomerName = string.Empty, Job = string.Empty, ZipCode = string.Empty, Pets = string.Empty, Rebook = string.Empty, FromRebook = string.Empty, New = string.Empty, TimeIn = string.Empty, TimeOut = string.Empty, PetTime = string.Empty, ExtraServices = string.Empty, comments = string.Empty, driveTime = string.Empty, rpetTime = string.Empty, CreditCardNo = string.Empty, CreditCardExpir = string.Empty, CreditCardORChkName = string.Empty, CreditCardORChkAddr = string.Empty, SecurityCode = string.Empty, NextAppomentDate = string.Empty, NextAppomentTime = string.Empty, NextAppointmentEndTime = string.Empty, ServicesForPet1 = string.Empty, ServicesForPet2 = string.Empty, ServicesForPet3 = string.Empty, ServicesForPet4 = string.Empty, ServicesForPet5 = string.Empty, ServicesForPet6 = string.Empty, NameOnCheque = string.Empty, Bankname = string.Empty;
    int DLId;
    int GroomerAppointmentId, UserAppointmentId;
    int preGroomerAppointmentId;
    string nextfdate = string.Empty, nextfstart = string.Empty, nextfend = string.Empty;
    DataSet dsDtls;
    decimal revamt, prioramt, tipamt;
    string strMsg = string.Empty;
    bool PreviousBMNeed = false;
    bool PreviousEMNeed = false;
    bool PresentBMNeed = false;
    bool PresentEMNeed = false;

    #region GetAdimn Date
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

    #endregion

    #region Private Field
    private int GId
    {
        get
        {
            if (Session["GId"] != null)
            {
                return int.Parse(Session["GId"].ToString());
            }
            else
                return 0;
        }
    }

    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["GroomerAppointmentId"] != null && Session["AppointmentDate"] != null && Session["GId"] != null)
        {
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
                    strMsg = arrIndMsg[1].ToString().Trim();
                }
            }

            PreviousBMNeed = Convert.ToBoolean(Session["PreviousBMNeed"]);
            PreviousEMNeed = Convert.ToBoolean(Session["PreviousEMNeed"]);
            PresentBMNeed = Convert.ToBoolean(Session["PresentBMNeed"]);
            PresentEMNeed = Convert.ToBoolean(Session["PresentEMNeed"]);

            strGId = Session["GId"].ToString();
            GroomerAppointmentId = Convert.ToInt32(Session["GroomerAppointmentId"].ToString());

            #region Check query string
            GetDOLDetails();

            #region from Successfull/UnScuucessfull Payment comes from Payment Page 
            if (strMsg.ToLower().Trim() == "p")
            {
                SuccesfullMessage("Your payment transaction has been successful!!!");
                btnMakePayment.Visible = false;
                btnRevSync.Enabled = false;
                btnRebookNextApp.Enabled = false;
                btnReSchedule.Enabled = false;
                btnCustSync.Enabled = false;
                txtRevenue.Enabled = false;
                txtTip.Enabled = false;
                txtPriorRevenue.Enabled = false;
                GetDOLDetails();
            }
            else if (strMsg.ToLower().Trim() == "u")
            {
                ErrMessage("Your payment transaction has been Unsuccessful!!!");
            }
            #endregion

            #region to edit appointment  comes from Payment Page 
            else if (strMsg.ToLower().Trim() == "e")
            {
                SuccesfullMessage("Please Edit Your Appointment details");
            }
            #endregion

            #endregion
            if (!IsPostBack)
            {
                try
                {
                    txtDate.Text = Convert.ToDateTime(Session["AppointmentDate"]).ToString("MM/dd/yyyy");

                    #region  Bind  Required Data
                    BindDayYear();
                    getCurrentAppointment();
                    getPrePayDetails();
                    chkdetails.Visible = false;

                    #region Check RBK Details return from Calender
                    if (!(null == Session["PageFrom"]))
                    {
                        if (!(null == Session["rdoRebookD"]))
                        {
                            if ("Yes" == Session["rdoRebookD"].ToString())
                            {
                                rdoRebook.SelectedValue = Session["rdoRebookD"].ToString();
                                rdoRebook.Items.FindByValue("Yes");
                                divNextAppoint.Visible = true;
                                
                                lblNextAppDate.Text = Session["NextDate"].ToString();

                                lblNextStartTime.Text = string.Empty;
                                lblNextEndTime.Text = string.Empty;
                                string checkStart= Session["NextStartTime"].ToString();
                                string checkEnd= Session["NextEndTime"].ToString();
                                lblNextStartTime.Text = Session["NextStartTime"].ToString();
                                lblNextEndTime.Text = Session["NextEndTime"].ToString();
                                

                                if (Session["AppointmentDetails"] != null)
                                {
                                    DataTable dtdetails = (DataTable)Session["AppointmentDetails"];

                                    foreach (DataRow dr in dtdetails.Rows)
                                    {
                                        txtServicesforPet1.Text = dr["ServicesForPet1"].ToString();
                                        txtServicesforPet2.Text = dr["ServicesForPet2"].ToString();
                                        txtServicesforPet3.Text = dr["ServicesForPet3"].ToString();
                                        txtServicesforPet4.Text = dr["ServicesForPet4"].ToString();
                                        txtServicesforPet5.Text = dr["ServicesForPet5"].ToString();
                                        txtServicesforPet6.Text = dr["ServicesForPet6"].ToString();
                                    }
                                }
                            }
                            else
                            {
                                rdoRebook.SelectedValue = Session["rdoRebookD"].ToString();
                                rdoRebook.Items.FindByValue("No");
                                divNextAppoint.Visible = false;
                                //Session["rdoRebookD"] = "";
                                //Session["PageFrom"] = null;
                            }
                        }
                    }
                    #endregion

                    FillAppointmentLogDetails();
                    SetApptCompTime();

                    #region  set the usability for appointment timing buttons.

                    if (lblApptStartTime.Text != "") btnStartApt.Enabled = false;
                    else btnStartApt.Enabled = true;
                    if (lblApptEndTime.Text != "") btnEndApt.Enabled = false;
                    else btnEndApt.Enabled = true;
                    if (lblApptStartTime.Text == "") btnEndApt.Enabled = false;
                    txtJob.Focus();
                    #endregion

                    #endregion

                    btnStartApt.Focus();
                }
                catch
                {
                    Response.Redirect("Dashboard.aspx", false);
                }
            }
        }
        else Response.Redirect("Default.aspx?Msg=Timeout", false);
    }
    #endregion

    #region Get Month Year
    public string getmonth(int mth)
    {
        string month = "";
        switch (mth)
        {
            case 1:
                month = "January";
                break;
            case 2:
                month = "February";
                break;
            case 3:
                month = "March";
                break;
            case 4:
                month = "April";
                break;
            case 5:
                month = "May";
                break;
            case 6:
                month = "June";
                break;
            case 7:
                month = "July";
                break;
            case 8:
                month = "August";
                break;
            case 9:
                month = "September";
                break;
            case 10:
                month = "October";
                break;
            case 11:
                month = "November";
                break;
            case 12:
                month = "December";
                break;
        }
        return month;
    }
    public void BindDayYear()
    {
        try
        {
            string[] day = new string[31];
            for (int i = 0; i < 31; i++)
            {
                day[i] = (i + 1).ToString();
            }
            string[] Years = new string[10];
            for (int i = 0; i < 10; i++)
            {
                Years[i] = (DateTime.Now.Year + i).ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion Get Month Year

    private void GetDOLDetails()
    {
        DataSet ds = Groomer.GetTodaysDailyOperationLog(Convert.ToInt32(Session["GId"]));
        if (ds.Tables.Count > 0)
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["VanID"] = ds.Tables[0].Rows[0]["VanId"].ToString();
                Session["BeginningMileage"] = ds.Tables[0].Rows[0]["BeginningMileage"].ToString();
                Session["TotalHours"] = ds.Tables[0].Rows[0]["TotalHours"].ToString();
                Session["EndingMileage"] = ds.Tables[0].Rows[0]["EndingMileage"].ToString();
                txtJob.Attributes.Add("Title", "Your Current Ending Mileage is  " + Session["EndingMileage"]);
                Session["PriceperGallon"] = ds.Tables[0].Rows[0]["PricePerGallon"].ToString();
                Session["FuelPurchased"] = ds.Tables[0].Rows[0]["FuelPurchased"].ToString();
            }
    }

    #region Function to bind data after redirect from payment page using session 
    public void FillAppointmentLogDetails()
    {
        try
        {
            DataSet dsapt = new DataSet();
            if (Session["AppointmentDetails"] != null)
            {
                DataTable dtdetails = (DataTable)Session["AppointmentDetails"];
                foreach (DataRow dr in dtdetails.Rows)
                {
                    #region Rowstart
                    if (!(String.IsNullOrEmpty(dr["AppStartTime"].ToString())))
                        lblApptStartTime.Text = Convert.ToDateTime(dr["AppStartTime"]).ToString("hh:mm tt");
                    if (!(String.IsNullOrEmpty(dr["AppEndTime"].ToString())))
                        lblApptEndTime.Text = Convert.ToDateTime(dr["AppEndTime"]).ToString("hh:mm tt");
                    if (!(String.IsNullOrEmpty(dr["AppDateTime"].ToString())))
                        lbl_time.Text = dr["AppDateTime"].ToString();
                    if (!(String.IsNullOrEmpty(dr["Description"].ToString())))
                        lbl_description.Text = dr["Description"].ToString();
                    if (!(String.IsNullOrEmpty(dr["CustumerName"].ToString())))
                        txtCustName.Text = dr["CustumerName"].ToString();
                    if (!(String.IsNullOrEmpty(dr["Date"].ToString())))
                        txtDate.Text = dr["Date"].ToString();
                    if (!(String.IsNullOrEmpty(dr["LastName"].ToString())))
                        txtCustLastName.Text = dr["LastName"].ToString();
                    if (!(String.IsNullOrEmpty(dr["JobMileage"].ToString())))
                        txtJob.Text = dr["JobMileage"].ToString();
                    if (!(String.IsNullOrEmpty(dr["ZipCode"].ToString())))
                        txtZipCode.Text = dr["ZipCode"].ToString();
                    if (!(String.IsNullOrEmpty(dr["Pets"].ToString())))
                        txtPets.Text = dr["Pets"].ToString();
                    if (!(String.IsNullOrEmpty(dr["NextAppointmentTime"].ToString())))
                        lblnextapp.Text = dr["NextAppointmentTime"].ToString();
                    if (!(String.IsNullOrEmpty(dr["ExpStartTime"].ToString())))
                        lblexpstart.Text = dr["ExpStartTime"].ToString();
                    if (!(String.IsNullOrEmpty(dr["ExpEndTime"].ToString())))
                        lblexpend.Text = Convert.ToDateTime(dr["ExpEndTime"]).ToString();
                    if (!(String.IsNullOrEmpty(dr["Rebook"].ToString())))
                        rdoRebook.SelectedValue = dr["Rebook"].ToString();
                    if (!(String.IsNullOrEmpty(dr["FromRebook"].ToString())))
                        lblNextAppDate.Text = dr["FromRebook"].ToString();
                    if (!(String.IsNullOrEmpty(dr["NextStartTime"].ToString())))
                    {
                        lblNextStartTime.Text = objGroomer.Time24Formatter(dr["NextStartTime"].ToString());
                    }
                    if (!(String.IsNullOrEmpty(dr["NextEndTime"].ToString())))
                    {
                        lblNextEndTime.Text = objGroomer.Time24Formatter(dr["NextEndTime"].ToString());
                    }
                    // for update rebook start and end date checking into session
                    if (!(String.IsNullOrEmpty(Session["NextStartTime"].ToString())))
                    {
                        lblNextStartTime.Text = Session["NextStartTime"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(Session["NextEndTime"].ToString())))
                    {
                        lblNextEndTime.Text = Session["NextEndTime"].ToString();
                    }

                    #endregion Rowstart
                    #region hidden services
                    if (!(String.IsNullOrEmpty(dr["ServicesforPet1"].ToString())))
                    {
                        txtServicesforPet1.Text = dr["ServicesforPet1"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["ServicesforPet2"].ToString())))
                    {
                        txtServicesforPet2.Text = dr["ServicesforPet2"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["ServicesforPet3"].ToString())))
                    {
                        txtServicesforPet3.Text = dr["ServicesforPet3"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["ServicesforPet4"].ToString())))
                    {
                        txtServicesforPet4.Text = dr["ServicesforPet4"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["ServicesforPet5"].ToString())))
                    {
                        txtServicesforPet5.Text = dr["ServicesforPet5"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["ServicesforPet6"].ToString())))
                    {
                        txtServicesforPet6.Text = dr["ServicesforPet6"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["NewRadio"].ToString())))
                    {
                        rdoNew.SelectedValue = dr["NewRadio"].ToString();
                    }
                    #endregion hidden services
                    #region supplies
                    if (!(String.IsNullOrEmpty(dr["FleaandTick22"].ToString())))
                    {
                        txtFleaandTick22.Text = dr["FleaandTick22"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["FleaandTick44"].ToString())))
                    {
                        txtFleaandTick44.Text = dr["FleaandTick44"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["FleaandTick88"].ToString())))
                    {
                        txtFleaandTick88.Text = dr["FleaandTick88"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["FleaandTick132"].ToString())))
                    {
                        txtFleaandTick132.Text = dr["FleaandTick132"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["FleaandTickCat"].ToString())))
                    {
                        txtFleaandTickCat.Text = dr["FleaandTickCat"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["TB"].ToString())))
                    {
                        txtTB.Text = dr["TB"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["Wham"].ToString())))
                    {
                        txtWham.Text = dr["Wham"].ToString();
                    }
                    #endregion supplies
                    #region Revenue
                    if (!(String.IsNullOrEmpty(dr["RevenueType"].ToString())))
                    {
                        rdoRevenue.SelectedValue = dr["RevenueType"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["RevenueAmount"].ToString())))
                    {
                        txtRevenue.Text = dr["RevenueAmount"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["ApptChanges"].ToString())))
                    {
                        txtExtraServices.Text = dr["ApptChanges"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["CommentDiv"].ToString())))
                    {
                        txtComments.Text = dr["CommentDiv"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["PetTimeGoodBad1"].ToString())))
                    {
                        rdoDriveTime.SelectedValue = dr["PetTimeGoodBad1"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["PetTimeGoodBad2"].ToString())))
                    {
                        rdoPetTime.SelectedValue = dr["PetTimeGoodBad2"].ToString();
                    }
                    #endregion Revenue
                    #region Product
                    if (!(String.IsNullOrEmpty(dr["ProductPrice"].ToString())))
                    {
                        txtProductPrice.Text = dr["ProductPrice"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["ProductSalesTax"].ToString())))
                    {
                        txtSalestax.Text = dr["ProductSalesTax"].ToString();
                    }
                    #endregion Product
                    #region Tip
                    if (!(String.IsNullOrEmpty(dr["Tiptype"].ToString())))
                    {
                        rdoTip.SelectedValue = dr["Tiptype"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["TipAmount"].ToString())))
                    {
                        txtTip.Text = dr["TipAmount"].ToString();
                    }
                    #endregion Tip
                    #region Prior Revenue
                    if (!(String.IsNullOrEmpty(dr["PriorType"].ToString())))
                    {
                        rdoPrior.SelectedValue = dr["PriorType"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["PriorAmount"].ToString())))
                    {
                        txtPriorRevenue.Text = dr["PriorAmount"].ToString();
                    }
                    #endregion Prior Revenue
                    #region CheckDetail
                    if (!(String.IsNullOrEmpty(dr["NameOnCheck"].ToString())))
                    {
                        txtcname.Text = dr["NameOnCheck"].ToString();
                    }
                    if (!(String.IsNullOrEmpty(dr["AddressOnCheck"].ToString())))
                    {
                        txtcaddr.Text = dr["AddressOnCheck"].ToString();
                    }
                    #endregion CheckDetail
                }

                #region disabled after payment
                if (strMsg == "P")
                {
                    txtRevenue.Enabled = false;
                    txtTip.Enabled = false;
                    txtPriorRevenue.Enabled = false;
                    GetDOLDetails();
                }

                if (!(null == Session["CustName"])) txtCustName.Text = Session["CustName"].ToString();
                #endregion disabled after payment
            }
        }
        catch { }
    }
    #endregion

    #region Get All Time
    public void SetApptCompTime()
    {
        try
        {
            if (lblApptCompleteTime.Text == "" && lblApptStartTime.Text != "" && lblApptEndTime.Text != "")
            {
                lblApptCompleteTime.Text = (Convert.ToDateTime(lblApptEndTime.Text) - Convert.ToDateTime(lblApptStartTime.Text)).TotalMinutes.ToString() + "  Minutes";
                Session["AptCompTime"] = lblApptCompleteTime.Text;
            }
        }
        catch
        {
        }
    }
    #endregion

    #region Get Appointment Details
    public void getCurrentAppointment()
    {
        try
        {
            dsDtls = objGroomer.getAppointmentDtlsByAppointmentId(Convert.ToInt32(Session["GroomerAppointmentId"].ToString()));
            if (dsDtls.Tables.Count > 0)
            {
                #region GetAppointment Details
                if (dsDtls.Tables[0].Rows.Count > 0)
                {
                    lbl_time.Text = dsDtls.Tables[0].Rows[0]["DateTimeFormat"].ToString().Trim();
                    lbl_description.Text = dsDtls.Tables[0].Rows[0]["Others"].ToString().Trim();

                    #region Disabled Rebook if REC in the String.
                    if (lbl_description.Text.ToLower().Contains("rec")) rdoRebook.Enabled = false;
                    else rdoRebook.Enabled = true;
                    #endregion

                    string Appt_Status = dsDtls.Tables[0].Rows[0]["StatusPresented"].ToString();

                    #region  get Appt. Start time and end time if any in case of groomer already presented the appt.
                    string ApptStartTime = dsDtls.Tables[0].Rows[0]["StartTime"].ToString();
                    string ApptEndTime = dsDtls.Tables[0].Rows[0]["EndTime"].ToString();

                    #region Save Start Time and End Time  From Admin
                    Session["PreStartTime"] = dsDtls.Tables[0].Rows[0]["ExpStartTime"].ToString();
                    Session["PreEndTime"] = dsDtls.Tables[0].Rows[0]["ExpEndTime"].ToString();
                    #endregion

                    GroomerAppointmentId = Convert.ToInt32(dsDtls.Tables[0].Rows[0]["AppointmentId"]);
                    if (dsDtls.Tables[0].Rows[0]["UserScheduledId"].ToString() != "")
                    {
                        UserAppointmentId = Convert.ToInt32(dsDtls.Tables[0].Rows[0]["UserScheduledId"]);
                        Session["UserScheduledId"] = UserAppointmentId;
                        Session["GroomerAppoinmentId"] = GroomerAppointmentId;
                    }
                    else
                    {
                        UserAppointmentId = 0;
                        Session["UserScheduledId"] = UserAppointmentId;
                        Session["GroomerAppoinmentId"] = GroomerAppointmentId;
                    }
                    #endregion

                    #region Fetched Customer user name  for Synchronization 
                    txtCustName.Text = dsDtls.Tables[0].Rows[0]["custEmail"].ToString().Trim();
                    // txtRevenue.Text = dsDtls.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString().Split('.').First();
                    Session["CustmerEmailId"] = txtCustName.Text;
                    Session["AdminRevenueAmount"] = txtRevenue.Text;

                    lblApptStartTime.Text = string.Empty;
                    lblApptEndTime.Text = string.Empty;
                    #endregion

                    divDetails.Visible = true;

                    #region Show Next Appointment Details If No REC
                    if (lbl_description.Text.ToLower().Contains("rec"))
                    {
                        nextapp.Visible = true;
                        DataSet ds = objGroomer.GetNextrecappdetails(GroomerAppointmentId);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblnextapp.Text = ds.Tables[0].Rows[0]["AppointmentDate"].ToString();
                            lblexpstart.Text = ds.Tables[0].Rows[0]["ExpStartTime"].ToString();
                            lblexpend.Text = ds.Tables[0].Rows[0]["ExpEndTime"].ToString();
                            Session["NextGroomerAppointmentId"] = ds.Tables[0].Rows[0]["AppointmentId"].ToString();
                        }
                        else nextapp.Visible = false;
                    }
                    #endregion
                }
                #endregion
            }
            else divDetails.Visible = false;
        }
        catch
        {
            Response.Redirect("Default.aspx?Msg=Timeout", false);
        }
    }
    #endregion Get Appointment Details

    #region Get Pre Pay Detail
    public void getPrePayDetails()
    {
        DataSet ds = objGroomer.getPrePayAppointmentDtls(GroomerAppointmentId);

        if (ds.Tables[0].Rows.Count > 0)
        {
            #region NotPaid
            if (ds.Tables[0].Rows[0]["Status"].ToString() == "Pending")
            {
                // txtRevenue.Text = ds.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString().Split('.').First();
                txtRevenue.Text = string.Empty;
                txtTip.Text = string.Empty;
                txtPriorRevenue.Text = string.Empty;

                Session["PrePayTotalAmt"] = ds.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString().Split('.').First();
                preGroomerAppointmentId = Convert.ToInt32(GroomerAppointmentId);
                btnMakePayment.Visible = true;
                rdoRevenue.SelectedIndex = 0;
                rdoTip.SelectedIndex = 0;

                Session["PreRevAmt"] = ds.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString().Split('.').First();
                Session["PrePriorAmt"] = string.Empty;
                Session["PreTipAmt"] = string.Empty;
                rdoPrior.SelectedIndex = 0;

                #region session rev for Sync Revenue to cust Pofile if Cancel By Umesh
                Session["RevAmtToSync"] = ds.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString().Split('.').First();
                #endregion
            }
            #endregion NotPaid

            #region Paid
            else if (ds.Tables[0].Rows[0]["Status"].ToString() == "Completed")
            {
                if (!(null == dsDtls.Tables[0].Rows[0]["paidStatus"].ToString()))
                {
                    Label5.Visible = true;
                }
                btnMakePayment.Visible = false;
            }
            #endregion Paid

            txtCustLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            txtZipCode.Text = ds.Tables[0].Rows[0]["Zip"].ToString();
        }
    }
    #endregion

    #region Submit Appointment and redirection check

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lblApptStartTime.Text != "" && lblApptEndTime.Text != "")
        {
            #region Code
            try
            {
                lblAppSubmit.Text = "";
                lbldatevalmsg.Text = "";
                bool IsValidApt = true;
                string AptID = Session["GroomerAppointmentId"].ToString();
                if (txtRevenue.Text != "")
                {
                    #region Insert/Update Appt.  Start and End time for the ongoing appt.
                    Groomer objGroomer = new Groomer();
                    objGroomer.GroomerUpdateApptSTimeETime(Convert.ToInt32(Session["GroomerAppointmentId"]), Convert.ToDateTime(lblApptStartTime.Text).ToString("hh:mm tt"), Convert.ToDateTime(lblApptEndTime.Text).ToString("hh:mm tt"));
                    #endregion Insert/Update Start and End  time for the ongoing appt.

                    #region To Check Revenue Ammount not less Than Admin Revenue Set
                    DataSet dsDetails = objGroomer.getAppointmentDetails(AptID);
                    Session["AptString"] = lbl_description.Text;
                    string[] tmInlastpart = new string[2];
                    string[] tmOutlastpart = new string[2];
                    string[] arrcalcinhours = new string[3];
                    string[] arrcalcouthours = new string[3];

                    #region To Appointment Changes Required Condition Check

                    double tmDifferenceMinutes = (Convert.ToDateTime(lblApptEndTime.Text) - Convert.ToDateTime(lblApptStartTime.Text)).TotalMinutes;

                    if (dsDetails.Tables.Count > 0)
                    {
                        if (dsDetails.Tables[0].Rows.Count > 0)
                        {
                            string exprevamt = dsDetails.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString();
                            string exppettimeout = dsDetails.Tables[0].Rows[0]["ExpPetTime"].ToString();
                            decimal Revenue_Amount = 0;
                            Revenue_Amount = Math.Round(Convert.ToDecimal(exprevamt), 0);
                            bool IsAllocatedTime = false;
                            if (!string.IsNullOrEmpty(exppettimeout))
                                if ((Convert.ToDecimal(exppettimeout) * 60) - Convert.ToDecimal(tmDifferenceMinutes) > 15)
                                    IsAllocatedTime = true;
                            decimal Rev_Amount = Convert.ToDecimal(txtRevenue.Text.Trim());
                            if ((Rev_Amount != Revenue_Amount && txtExtraServices.Text.Trim() == "") || (IsAllocatedTime.Equals(false) && txtExtraServices.Text == ""))
                                IsValidApt = false;
                        }
                    }
                    #endregion

                    #endregion
                }

                #region Appointment Changes Required 
                if (IsValidApt.Equals(false))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertMsg", "AppChangesError();", true);
                    divaptchangesrequired.Visible = true;
                    lblaptchangesreq.Visible = true;
                    txtExtraServices.Focus();
                }
                else
                {
                    divaptchangesrequired.Visible = false;
                    lblaptchangesreq.Visible = false;
                }
                #endregion

                if (IsValid && IsValidApt.Equals(true))
                {
                    if (txtJob.Text.Trim() != "")
                    {

                        //check whether there is no any same appointment details present for the processing appointment to avoid duplicate records in Daily Operation Log
                        bool IsAppointmentExists = objGroomer.CheckAppointment(Convert.ToInt32(AptID));
                        // check whether the appointment same record exists in case of back button click and to avoid record duplication.
                        Job = txtJob.Text;
                        ExtraServices = txtExtraServices.Text;
                        comments = txtComments.Text;
                        driveTime = rdoDriveTime.SelectedValue;
                        rpetTime = rdoPetTime.SelectedValue;
                        CustomerName = txtCustLastName.Text;
                        ZipCode = txtZipCode.Text;
                        Pets = txtPets.Text;
                        PetTime = lblApptCompleteTime.Text;
                        TimeIn = lblApptStartTime.Text;
                        TimeOut = lblApptEndTime.Text;

                        //if needed add txtComments value Here

                        //check in DailyOperatrionLog for the same appointment 
                        bool IsAppExists = objGroomer.CheckAppRecordinDB(AptID, Session["VanID"].ToString(), Session["BeginningMileage"].ToString(), ExtraServices, CustomerName, Job, ZipCode, Pets, PetTime, Session["AppointmentDate"].ToString(), TimeIn, TimeOut);


                        if (IsAppointmentExists.Equals(false) && IsAppExists.Equals(false))
                        {
                            InsertDailyOperationLog();

                            if (HttpContext.Current.Session["PayID"] != null)
                                if (!(string.IsNullOrEmpty(HttpContext.Current.Session["PayID"].ToString())))
                                    objGroomer.UpdateLogID(DLId, HttpContext.Current.Session["PayID"].ToString());
                            if (HttpContext.Current.Session["SyncId"] != null)
                                if (!(string.IsNullOrEmpty(HttpContext.Current.Session["SyncId"].ToString())))
                                    objGroomer.UpdateLogIDInSyncApp(DLId, Convert.ToInt32(Session["SyncId"]));

                            #region Check for RBK  and insert to member profile
                            if (HttpContext.Current.Session["AppointmentDetails"] != null)
                            {
                                DataTable dtdetails = (DataTable)Session["AppointmentDetails"];
                                DateTime nextDt = Session["NextDate"] != null ? Convert.ToDateTime(Session["NextDate"].ToString()) : DateTime.Now;
                                string st = Session["NextStartTime"] != null ? Convert.ToDateTime(Session["NextStartTime"]).ToString("hh:mm tt") : "";
                                string et = Session["NextEndTime"] != null ? Convert.ToDateTime(Session["NextEndTime"]).ToString("hh:mm tt") : "";

                                if (nextDt.Date > DateTime.Now.Date)
                                {
                                    string militaryDateTime = ConvertToMilitaryDatatime(nextDt, st, et);
                                    objGroomer.SetRBKAppointmentToMemberProfile(txtCustName.Text, Convert.ToInt32(Session["GroomerAppointmentId"].ToString()), nextDt, st, et, militaryDateTime, txtRevenue.Text);
                                }
                            }
                            #endregion

                            ClearSession();
                            CheckRedirect();
                        }
                        else
                        {
                            ErrMessage("This Appointment has  already been submitted <br> Please Login again to proceed Next Appointment.");
                            CheckRedirect();
                            lblAppSubmit.Text = "";
                            lblAppSubmit1.Text = "";
                        }
                    }
                    else
                    {
                        ErrMessage("Please Enter Job Mileage");
                        txtJob.Focus();
                    }
                }
                else ErrMessage("Please fill All Field on the page");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion Code
        }
        else
        {
            if (lblApptStartTime.Text == "") ErrMessage("Please provide Appointment Start time ..");
            else ErrMessage("Please provide Appointment End  time ..");
        }
    }
    #endregion

    #region Insert DailyOperationLog
    public void InsertDailyOperationLog()
    {
        try
        {
            CustomerName = txtCustLastName.Text.Trim();
            Job = txtJob.Text.Trim();
            ZipCode = txtZipCode.Text.Trim();
            Pets = txtPets.Text.Trim();
            Rebook = rdoRebook.SelectedValue;
            string lbldesc = lbl_description.Text;

            if (lbldesc.ToLower().Contains("rbk") || lbldesc.ToLower().Contains("rec"))
                FromRebook = "1";
            else
                FromRebook = "0";
            if (lbldesc.Contains("*"))
                New = "1";
            else
                New = "0";

            TimeIn = Convert.ToDateTime(lblApptStartTime.Text).ToString("hh:mm tt");
            TimeOut = Convert.ToDateTime(lblApptEndTime.Text).ToString("hh:mm tt");

            PetTime = lblApptCompleteTime.Text;
            ExtraServices = txtExtraServices.Text.Trim();

            comments = txtComments.Text.Trim();
            driveTime = rdoDriveTime.SelectedValue;
            rpetTime = rdoPetTime.SelectedValue;

            #region Other Details
            if (txtFleaandTick22.Text.Trim() != "") { FleaandTick22 = Convert.ToInt32(txtFleaandTick22.Text.Trim()); }
            if (txtFleaandTick44.Text.Trim() != "") { FleaandTick44 = Convert.ToInt32(txtFleaandTick44.Text.Trim()); }
            if (txtFleaandTick88.Text.Trim() != "") { FleaandTick88 = Convert.ToInt32(txtFleaandTick88.Text.Trim()); }
            if (txtFleaandTick132.Text.Trim() != "") { FleaandTick132 = Convert.ToInt32(txtFleaandTick132.Text.Trim()); }
            if (txtFleaandTickCat.Text.Trim() != "") { FleaandTickCat = Convert.ToInt32(txtFleaandTickCat.Text.Trim()); }
            if (txtTB.Text.Trim() != "") { TB = Convert.ToInt32(txtTB.Text.Trim()); }
            if (txtWham.Text.Trim() != "") { Wham = Convert.ToInt32(txtWham.Text.Trim()); }

            if (rdoRevenue.SelectedValue != "0") { RevenueCreditCard = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCreditCard = Convert.ToDouble(txtRevenue.Text.Trim()); } }
            if (rdoRevenue.SelectedValue != "1") { RevenueCCY = 0; } else { if (txtRevenue.Text != "") { RevenueCCY = Convert.ToDouble(txtRevenue.Text.Trim()); } }
            if (rdoRevenue.SelectedValue != "2") { RevenueCheck = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCheck = Convert.ToDouble(txtRevenue.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
            if (rdoRevenue.SelectedValue != "3") { RevenueCash = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCash = Convert.ToDouble(txtRevenue.Text.Trim()); } }
            if (rdoRevenue.SelectedValue != "4") { RevenueInvoice = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueInvoice = Convert.ToDouble(txtRevenue.Text.Trim()); } }

            if (rdoTip.SelectedValue != "0") { TipCreditCard = 0; } else { if (txtTip.Text.Trim() != "") { TipCreditCard = Convert.ToDouble(txtTip.Text.Trim()); } }
            if (rdoTip.SelectedValue != "1") { TipCheck = 0; } else { if (txtTip.Text.Trim() != "") { TipCheck = Convert.ToDouble(txtTip.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
            if (rdoTip.SelectedValue != "2") { TipCash = 0; } else { if (txtTip.Text.Trim() != "") { TipCash = Convert.ToDouble(txtTip.Text.Trim()); } }
            if (rdoTip.SelectedValue != "3") { TipInvoice = 0; } else { if (txtTip.Text.Trim() != "") { TipInvoice = Convert.ToDouble(txtTip.Text.Trim()); } }

            if (rdoPrior.SelectedValue != "0") { PriorCreditCard = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCreditCard = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } }
            if (rdoPrior.SelectedValue != "1") { PriorCheck = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCheck = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
            if (rdoPrior.SelectedValue != "2") { PriorCash = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCash = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } }

            if (txtProductPrice.Text == "")
                txtProductPrice.Text = "0.0";
            if (txtSalestax.Text == "")
                txtSalestax.Text = "0.0";

            if (rdoRevenue.SelectedValue == "0" || rdoRevenue.SelectedValue == "3")
                Revnue01 = 0;
            else
                Revnue01 = 1;
            if (rdoRevenue.SelectedValue == "0" || rdoTip.SelectedValue == "0" || rdoPrior.SelectedValue == "0")
            {
            }
            else
            {
                CreditCardExpir = "";
            }
            #endregion Other Details

            #region Collect Services 
            ServicesForPet1 = txtServicesforPet1.Text.Trim();
            ServicesForPet2 = txtServicesforPet2.Text.Trim();
            ServicesForPet3 = txtServicesforPet3.Text.Trim();
            ServicesForPet4 = txtServicesforPet4.Text.Trim();
            ServicesForPet5 = txtServicesforPet5.Text.Trim();
            ServicesForPet6 = txtServicesforPet6.Text.Trim();
            #endregion

            #region Collect Data and time Rebook Option Data and Save
            if (rdoRebook.SelectedValue == "1")
            {
                NextAppomentDate = lblNextAppDate.Text;
                NextAppomentTime = lblNextStartTime.Text;
                NextAppointmentEndTime = lblNextEndTime.Text;
            }
            else
            {
                NextAppomentDate = "";
                NextAppomentTime = "";
                NextAppointmentEndTime = "";
            }
            // Save Rebook /NonRebbok
            InsertRebookNoRebookData();
            #endregion

            #region Update All Other  Groomer  Appointment Status
            //update Amount if any changes
            if (PriorCreditCard > Convert.ToDouble(Session["PrePayTotalAmt"]) || PriorCreditCard < Convert.ToDouble(Session["PrePayTotalAmt"]))
                objGroomer.UpdatePrePayAppointmentDtls(Convert.ToInt32(Session["GroomerAppointmentId"].ToString()), RevenueCreditCard, PriorCreditCard, TipCreditCard, Convert.ToDouble(RevenueCreditCard + PriorCreditCard + TipCreditCard));
            // Update Groomer Appointment Status from Pending to Complete,StatusPresented=1
            //Update DOL Details Status :ExcelExported=0 , ExportedEndingMileage=0 and Insert Appointment txn date
            objGroomer.Modify_AppointmentStatus(Convert.ToInt32(GroomerAppointmentId), Convert.ToInt32(DLId), 0, 0, TimeIn.ToString(), TimeOut.ToString());
            #endregion
        }
        catch
        {

        }
    }
    #endregion

    #region Insert Rebook/NonReebook Log Details on Submit Appointment
    protected void InsertRebookNoRebookData()
    {
        try
        {

            CreditCardNo = "";
            CreditCardExpir = "";
            CreditCardORChkName = "";
            CreditCardORChkAddr = "";
            SecurityCode = "";
            //add txtComments variable here
            DLId = objGroomer.InsertDailyOperationLog(strGId, Session["VanID"].ToString(), Session["BeginningMileage"].ToString(), Session["TotalHours"].ToString(), Session["EndingMileage"].ToString(), Session["FuelPurchased"].ToString(), Session["PriceperGallon"].ToString(),
                CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, comments, driveTime, rpetTime,
                FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham,
                RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, RevenueCCY,
                TipCreditCard, TipCheck, TipCash, TipInvoice,
                PriorCreditCard, PriorCheck, PriorCash,
                CreditCardNo, CreditCardExpir, CreditCardORChkName, CreditCardORChkAddr, SecurityCode,
                NextAppomentDate, NextAppomentTime, NextAppointmentEndTime,
                ServicesForPet1, ServicesForPet2, ServicesForPet3, ServicesForPet4, ServicesForPet5, ServicesForPet6,
                Convert.ToInt32(GroomerAppointmentId), Session["AppointmentDate"].ToString(),
                Convert.ToDouble(txtProductPrice.Text), Convert.ToDouble(txtSalestax.Text), Revnue01, NameOnCheque, Bankname);

            if (DLId > 0)
            {
                Session["appt_end_time"] = null;
                Session["appt_start_time"] = null;
                Session["AptCompTime"] = null;
                Session["LogID"] = DLId.ToString();
            }
        }
        catch
        {
            Session["LogID"] = "0";
        }
    }
    #endregion

    #region Check Redirection
    protected void CheckRedirect()
    {
        Session["PageFrom"] = "Operations";
        Session.Remove("AppointmentDetails");
        Session.Remove("AptDateFormat");
        Session.Remove("AptString");
        Session.Remove("AppStartTime");
        Session.Remove("AppEndTime");
        Response.Redirect("Dashboard.aspx", false);
    }
    #endregion

    #region COnvert Date To Military Date Time Formate
    private string ConvertToMilitaryDatatime(DateTime dt, string st, string et)
    {
        string militaryDateTime = string.Empty;
        try
        {
            militaryDateTime = dt.Date.ToString("yyMMdd") + ".";
            string startHour = (Convert.ToDateTime(st).Hour).ToString().Length == 1 ? "0" + (Convert.ToDateTime(st).Hour).ToString() : (Convert.ToDateTime(st).Hour).ToString();
            string startMinute = (Convert.ToDateTime(st).Minute).ToString().Length == 1 ? "0" + (Convert.ToDateTime(st).Minute).ToString() : (Convert.ToDateTime(st).Minute).ToString();
            string endtHour = (Convert.ToDateTime(et).Hour).ToString().Length == 1 ? "0" + (Convert.ToDateTime(et).Hour).ToString() : (Convert.ToDateTime(et).Hour).ToString();
            string endtMinute = (Convert.ToDateTime(et).Minute).ToString().Length == 1 ? "0" + (Convert.ToDateTime(et).Minute).ToString() : (Convert.ToDateTime(et).Minute).ToString();
            militaryDateTime += startHour + startMinute + "-" + endtHour + endtMinute;
            return militaryDateTime;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion COnvert Date To Military Date Time Formate

    #region Comment
    //protected int AddAppointmentDetails()
    //{
    //    int ID = 0;
    //    try
    //    {
    //        //Inserts the appointment details to appointment log table.
    //        DataSet dsapt = new DataSet();
    //        if (!(null == Session["DailyLogID"]))
    //        {
    //            dsapt = objGroomer.GetAptdetails(Convert.ToInt32(Session["DailyLogID"].ToString()));
    //        }
    //        if (dsapt.Tables.Count > 0)
    //        {
    //            if (dsapt.Tables[0].Rows.Count > 0)
    //            {
    //                foreach (DataRow dr in dsapt.Tables[0].Rows)
    //                {
    //                    try
    //                    {
    //                        ID = objGroomer.InsertDailyOperationLog(dr["Gid"].ToString(), dr["VanId"].ToString(), dr["BeginningMileage"].ToString(), dr["TotlaHours"].ToString(), dr["EndingMileage"].ToString(), dr["FuelPurchased"].ToString(), dr["PricePerGallon"].ToString(), dr["CustomerName"].ToString(), dr["Job"].ToString(), dr["ZipCode"].ToString(), dr["Pets"].ToString(), dr["Rebook"].ToString(), dr["FromRebook"].ToString(), dr["New"].ToString(), dr["TimeIn"].ToString(), dr["TimeOut"].ToString(), dr["PetTime"].ToString(), dr["ExtraServices"].ToString(), dr["Comments"].ToString(), dr["Drive_Time"].ToString(), dr["Pet_Time"].ToString(), Convert.ToInt32(dr["FleaandTick22"].ToString()), Convert.ToInt32(dr["FleaandTick44"].ToString()), Convert.ToInt32(dr["FleaandTick88"].ToString()), Convert.ToInt32(dr["FleaandTick132"].ToString()), Convert.ToInt32(dr["FleaandTickCat"].ToString()), Convert.ToInt32(dr["TB"].ToString()), Convert.ToInt32(dr["Wham"].ToString()), Convert.ToDouble(dr["RevenueCreditCard"].ToString()), Convert.ToDouble(Session["GroomerAppointmentId"].ToString()), Convert.ToDouble(dr["RevenueCash"].ToString()), Convert.ToDouble(dr["RevenueInvoice"].ToString()), Convert.ToDouble(dr["RevenueCCY"].ToString()), Convert.ToDouble(dr["TipCreditCard"].ToString()), Convert.ToDouble(dr["TipCheck"].ToString()), Convert.ToDouble(dr["TipCash"].ToString()), Convert.ToDouble(dr["TipInvoice"].ToString()), Convert.ToDouble(dr["PriorCreditCard"].ToString()), Convert.ToDouble(dr["PriorCheck"].ToString()), Convert.ToDouble(dr["PriorCash"].ToString()), dr["CreditCardNo"].ToString(), dr["CreditCardExpir"].ToString(), dr["CreditCardORChkName"].ToString(), dr["CreditCardORChkAddr"].ToString(), dr["SecurityCode"].ToString(), dr["NextAppointmentDate"].ToString(), dr["NextAppointmentTime"].ToString(), dr["NextAppointmentEndTime"].ToString(), dr["ServicesForPet1"].ToString(), dr["ServicesForPet2"].ToString(), dr["ServicesForPet3"].ToString(), dr["ServicesForPet4"].ToString(), dr["ServicesForPet5"].ToString(), dr["ServicesForPet6"].ToString(), Convert.ToInt32(dr["GroomerAppointmentId"].ToString()), Session["AppointmentDate"].ToString(), Convert.ToDouble(dr["ProductPrice"].ToString()), Convert.ToDouble(dr["Salestax"].ToString()), Convert.ToInt32(dr["Rev01"].ToString()), dr["accholdername"].ToString(), dr["chequebank"].ToString());
    //                        Session["DailyLogID"] = ID;
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                    }
    //                }
    //                int GroomerAppointmentId = 0;
    //                if (Session["GroomerAppointmentId"] != null) { GroomerAppointmentId = Convert.ToInt32(Session["GroomerAppointmentId"].ToString()); }

    //                objGroomer.Modify_AppointmentStatus(Convert.ToInt32(GroomerAppointmentId));
    //                objGroomer.GroomerUpdatePresentedStatus(GroomerAppointmentId);
    //                if (ID > 0)
    //                {
    //                    Session["appt_end_time"] = null;
    //                    Session["appt_start_time"] = null;
    //                    Session["AptCompTime"] = null;
    //                    objGroomer.updateExcelExported(Convert.ToInt32(ID), 0);
    //                    objGroomer.updateExcelExportedEndingMileage(Convert.ToInt32(ID), 0);
    //                    //Insert Appointment txn date details.
    //                    objGroomer.InsertAppDate(ID);
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //    return ID;
    //}

    #endregion

    #region Clear Session
    protected void ClearSession()
    {
        Session.Remove("NextDate");
        Session.Remove("NextStartTime");
        Session.Remove("NextEndTime");
        Session.Remove("AppointmentDetails");
        Session["CustLastName"] = "";
        Session["JobM"] = "";
        Session["zipCode"] = "";
        Session["Pet"] = "";
        Session["FT22"] = "";
        Session["FT44"] = "";
        Session["FT88"] = "";
        Session["FT132"] = "";
        Session["FTCat"] = "";
        Session["TB"] = "";
        Session["Wham"] = "";
        Session["rdoRevenue"] = "";
        Session["RevenuAmt"] = "";
        Session["ExtraServices"] = "";
        Session["Comments"] = "";
        Session["rdoDrive"] = "";
        Session["rdoPet"] = "";
        Session["productPrice"] = "";
        Session["SaleTax"] = "";
        Session["rdoTip"] = "";
        Session["tipAmt"] = "";
        Session["rdoPrior"] = "";
        Session["PriorRev"] = "";
        Session["rdoRebookD"] = "";
        Session["rday"] = "";
        Session["rmonth"] = "";
        Session["ryear"] = "";
        Session["rAppStartTimeHr"] = "";
        Session["rAppStartTimeMin1"] = "";
        Session["rAppStartTimeMin"] = "";
        Session["rAppEndTimeHr"] = "";
        Session["rAppEndTimeMin1"] = "";
        Session["rAppEndTimeMin"] = "";
    }
    #endregion

    #region Clear Fields
    public void clear()
    {
        txtFleaandTick22.Text = "";
        txtFleaandTick44.Text = "";
        txtFleaandTick88.Text = "";
        txtFleaandTick132.Text = "";
        txtFleaandTickCat.Text = "";
        txtTB.Text = "";
        txtWham.Text = "";
        txtJob.Text = ""; txtZipCode.Text = ""; txtPets.Text = "";

        lblNextAppDate.Text = "";
        lblNextTime.Text = "";
        lblNextEndTime.Text = "";
        txtServicesforPet1.Text = "";
        txtServicesforPet2.Text = "";
        txtServicesforPet3.Text = "";
        txtServicesforPet4.Text = "";
        txtServicesforPet5.Text = "";
        txtServicesforPet6.Text = "";
        btnSubmit.Enabled = false;
    }
    #endregion

    #region Radio Button Selection Changed 
    protected void rdoRevenue_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdoRevenue.SelectedIndex == 2)
            {
                chkdetails.Visible = true;
                txtcname.TabIndex = 30;
                txtcaddr.TabIndex = 31;
                
            }
            else if (rdoRevenue.SelectedIndex != 2 && rdoTip.SelectedIndex != 1 && rdoPrior.SelectedIndex != 1)
            {
                chkdetails.Visible = false;
                txtcname.TabIndex = 0;
                txtcaddr.TabIndex = 0;
               
            }
            
            fillTempData();
        }
        catch
        {
        }
    }
    protected void rdoTip_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdoTip.SelectedIndex == 1)
            {
                chkdetails.Visible = true;
                txtcname.TabIndex = 30;
                txtcaddr.TabIndex = 31;
            }
            else if (rdoRevenue.SelectedIndex != 2 && rdoTip.SelectedIndex != 1 && rdoPrior.SelectedIndex != 1)
            {
                chkdetails.Visible = false;
                txtcname.TabIndex = 0;
                txtcaddr.TabIndex = 0;
            }
            fillTempData();
        }
        catch
        {
        }
    }
    protected void rdoPrior_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdoPrior.SelectedIndex == 1)
            {
                chkdetails.Visible = true;
                txtcname.TabIndex = 30;
                txtcaddr.TabIndex = 31;
            }
            else if (rdoRevenue.SelectedIndex != 2 && rdoTip.SelectedIndex != 1 && rdoPrior.SelectedIndex != 1)
            {
                chkdetails.Visible = false;
                txtcname.TabIndex = 0;
                txtcaddr.TabIndex = 0;
            }
            fillTempData();
        }
        catch
        {
        }
    }
    protected void rdoDriveTime_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  rdoPetTime.Focus();
    }
    protected void rdoPetTime_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  txtProductPrice.Focus();
    }
    protected void rdoRebook_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdoRebook.SelectedValue.Equals("1"))
            {
                divNextAppoint.Visible = true;
                fillTempData();
                Session["CustName"] = txtCustName.Text;
                Session["PageFrom"] = "OPR";
                Response.Redirect("CalendarView.aspx");
            }
            else
            {
                divNextAppoint.Visible = false;
                btnConfirm_Click(sender, EventArgs.Empty);
            }
            btnRebookNextApp.Focus();
        }
        catch
        {

        }
    }
    #endregion

    #region Message Status
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

    #region Button Start & End Code
    protected void btnStartApt_Click(object sender, EventArgs e)
    {
        string appt_start_time = DateTime.Now.ToString("hh:mm tt");
        Session["appt_start_time"] = appt_start_time;
        lblApptStartTime.Text = appt_start_time.ToString();
        btnStartApt.Enabled = false;
        btnEndApt.Enabled = true;
        bool startTimeCheck = objGroomer.UpdateGroomerAppointmentStartDate(Session["GroomerAppointmentId"].ToString(), appt_start_time.ToString());
        if (txtCustName.Text != "") btnCustSync.Focus();
        else
            txtCustName.Focus();
    }
    protected void btnEndApt_Click(object sender, EventArgs e)
    {
        string appt_end_time = string.Empty;
        try
        {
            if (lblApptStartTime.Text != "")
            {
                lblAppSubmit.Text = "";
                appt_end_time = DateTime.Now.ToString("hh:mm tt");
                Session["appt_end_time"] = appt_end_time;
                lblApptEndTime.Text = appt_end_time;
                lblApptCompleteTime.Text = (double)(Convert.ToDateTime(lblApptEndTime.Text) - Convert.ToDateTime(lblApptStartTime.Text)).TotalMinutes + "  Minutes";
                Session["AptCompTime"] = lblApptCompleteTime.Text;
                bool endTimeCheck = objGroomer.UpdateGroomerAppointmentEndDate(Session["GroomerAppointmentId"].ToString(), appt_end_time.ToString());
                divError.Visible = false;
                btnEndApt.Enabled = false;
                //     btnSubmit.Focus();
            }
            else
            {
                lblApptStartTime.Text = string.Empty;
                btnStartApt.Enabled = true;
                btnEndApt.Enabled = true;
                ErrMessage("First Click Appointment Start Time Button");
            }
        }
        catch
        {
            lblApptStartTime.Text = string.Empty;
            btnStartApt.Enabled = true;
            btnEndApt.Enabled = true;
        }
    }
    #endregion

    #region Old Appointments in calendar
    //Old Appointments
    //protected DataSet OldGetCurrentMonthData(DateTime apptDate)
    //{
    //    DataSet dsMonth = new DataSet();
    //    //ConnectionStringSettings cs;
    //    //cs = ConfigurationManager.ConnectionStrings["ConnectionString"];
    //    //String connString = cs.ConnectionString;

    //    SqlConnection dbConnection = new SqlConnection(@"Data Source=XEONSERVER;Initial Catalog=fritzyslive_new;Integrated Security=True");
    //    String query;
    //    query = "SELECT AppointmentDate FROM  GroomerAppointment where GID=" + Session["GId"].ToString();
    //    SqlCommand dbCommand = new SqlCommand(query, dbConnection);
    //    dbCommand.Parameters.Add(new SqlParameter("@AppointmentDate", apptDate));
    //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(dbCommand);
    //    try
    //    {
    //        sqlDataAdapter.Fill(dsMonth);
    //    }
    //    catch (Exception Ex)
    //    {
    //        string error = Ex.Message;
    //    }
    //    return dsMonth;
    //}

    //protected DateTime OldGetFirstDayOfNextMonth()
    //{
    //    int monthNumber, yearNumber;
    //    if (rbkOldCalendar.VisibleDate.Month == 12)
    //    {
    //        monthNumber = 1;
    //        yearNumber = rbkOldCalendar.VisibleDate.Year + 1;
    //    }
    //    else
    //    {
    //        monthNumber = rbkOldCalendar.VisibleDate.Month + 1;
    //        yearNumber = rbkOldCalendar.VisibleDate.Year;
    //    }
    //    DateTime lastDate = new DateTime(yearNumber, monthNumber, 1);
    //    return lastDate;
    //}
    //protected void FillOldAppointmentDataset()
    //{
    //    DateTime firstDate = new DateTime(rbkOldCalendar.VisibleDate.Year,
    //        rbkOldCalendar.VisibleDate.Month, 1);
    //    DateTime lastDate = OldGetFirstDayOfNextMonth();
    //    dsOldAppointment = OldGetCurrentMonthData(firstDate);
    //}
    //protected void rbkOldCalendar_DayRender(object sender, DayRenderEventArgs e)
    //{
    //    DateTime nextDate;
    //    try
    //    {
    //        if (dsOldAppointment != null)
    //        {
    //            foreach (DataRow dr in dsOldAppointment.Tables[0].Rows)
    //            {
    //                nextDate = (DateTime)dr["AppointmentDate"];
    //                if (nextDate == e.Day.Date)
    //                {
    //                    e.Cell.BackColor = System.Drawing.Color.Red;
    //                    e.Cell.ToolTip = "Appointment is Booked.";

    //                    //e.Cell.Text = "Booked";
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception Ex)
    //    {
    //        string error = Ex.Message;
    //    }

    //}
    //protected void rdoFromRebook_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        if (rdoFromRebook.SelectedValue.Equals("1"))
    //        {
    //            divOldAppointments.Visible = true;
    //            rbkOldCalendar.VisibleDate = DateTime.Today;
    //            FillOldAppointmentDataset();
    //        }
    //        else
    //        {
    //            divOldAppointments.Visible = false;

    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    //protected void rbkOldCalendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    //{
    //    FillOldAppointmentDataset();
    //}
    //protected void rbkOldCalendar_SelectionChanged(object sender, EventArgs e)
    //{
    //    string selectedDate = rbkOldCalendar.SelectedDate.Date.ToString();

    //}


    #endregion

    #region CheckAppointmentTime

    protected void btnCheckAppointmentTime_Click(object sender, EventArgs e)
    {
        Response.Redirect("CalendarView.aspx");
    }
    #endregion

    #region Load Old Appointments
    public DataSet loadOldApp()
    {
        DataSet dsApps = new DataSet();
        dsApps = objGroomer.getOldApp(Session["GId"].ToString(), Convert.ToInt32(Session["GroomerAppointmentId"].ToString()));
        return dsApps;
    }
    #endregion

    #region Month Changed
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    #endregion

    #region Confirm 
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        CustomerName = txtCustLastName.Text.Trim();
        Job = txtJob.Text.Trim();
        ZipCode = txtZipCode.Text.Trim();
        Pets = txtPets.Text.Trim();
        Rebook = rdoRebook.SelectedValue;
        string lbldesc = lbl_description.Text;
        string searchstring = lbl_description.Text;

        #region App String
        if (searchstring.ToLower().Contains("rbk") || searchstring.ToLower().Contains("rec"))
        {
            FromRebook = "1";
        }
        else
        {
            FromRebook = "0";
        }
        if (searchstring.Contains("*"))
        {
            New = "1";
        }
        else
        {
            New = "0";
        }
        #endregion

        TimeIn = lblApptStartTime.Text;
        TimeOut = lblApptEndTime.Text;
        if (!(null == (Session["pettime"])))
        {
            PetTime = Session["pettime"].ToString();
        }
        else
        {
            PetTime = "0";
        }
        #region Other Code
        //PetTime = lblApptCompleteTime.Text;//txtPetTime.Text;
        ExtraServices = txtExtraServices.Text.Trim();
        //add txtComments here 16jan13
        comments = txtComments.Text.Trim();
        driveTime = rdoDriveTime.SelectedValue;
        rpetTime = rdoPetTime.SelectedValue;
        // FleaandTick
        if (txtFleaandTick22.Text.Trim() != "") { FleaandTick22 = Convert.ToInt32(txtFleaandTick22.Text.Trim()); }
        if (txtFleaandTick44.Text.Trim() != "") { FleaandTick44 = Convert.ToInt32(txtFleaandTick44.Text.Trim()); }
        if (txtFleaandTick88.Text.Trim() != "") { FleaandTick88 = Convert.ToInt32(txtFleaandTick88.Text.Trim()); }
        if (txtFleaandTick132.Text.Trim() != "") { FleaandTick132 = Convert.ToInt32(txtFleaandTick132.Text.Trim()); }
        if (txtFleaandTickCat.Text.Trim() != "") { FleaandTickCat = Convert.ToInt32(txtFleaandTickCat.Text.Trim()); }
        if (txtTB.Text.Trim() != "") { TB = Convert.ToInt32(txtTB.Text.Trim()); }
        if (txtWham.Text.Trim() != "") { Wham = Convert.ToInt32(txtWham.Text.Trim()); }
        // Revenue 
        if (rdoRevenue.SelectedValue != "0") { RevenueCreditCard = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCreditCard = Convert.ToDouble(txtRevenue.Text.Trim()); } }
        if (rdoRevenue.SelectedValue != "1") { RevenueCCY = 0; } else { if (txtRevenue.Text != "") { RevenueCCY = Convert.ToDouble(txtRevenue.Text.Trim()); } }
        if (rdoRevenue.SelectedValue != "2") { RevenueCheck = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCheck = Convert.ToDouble(txtRevenue.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
        if (rdoRevenue.SelectedValue != "3") { RevenueCash = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCash = Convert.ToDouble(txtRevenue.Text.Trim()); } }
        if (rdoRevenue.SelectedValue != "4") { RevenueInvoice = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueInvoice = Convert.ToDouble(txtRevenue.Text.Trim()); } }
        // Tip
        if (rdoTip.SelectedValue != "0") { TipCreditCard = 0; } else { if (txtTip.Text.Trim() != "") { TipCreditCard = Convert.ToDouble(txtTip.Text.Trim()); } }
        if (rdoTip.SelectedValue != "1") { TipCheck = 0; } else { if (txtTip.Text.Trim() != "") { TipCheck = Convert.ToDouble(txtTip.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
        if (rdoTip.SelectedValue != "2") { TipCash = 0; } else { if (txtTip.Text.Trim() != "") { TipCash = Convert.ToDouble(txtTip.Text.Trim()); } }
        if (rdoTip.SelectedValue != "3") { TipInvoice = 0; } else { if (txtTip.Text.Trim() != "") { TipInvoice = Convert.ToDouble(txtTip.Text.Trim()); } }
        // Prior Amount
        if (rdoPrior.SelectedValue != "0") { PriorCreditCard = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCreditCard = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } }
        if (rdoPrior.SelectedValue != "1") { PriorCheck = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCheck = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
        if (rdoPrior.SelectedValue != "2") { PriorCash = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCash = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } }

        if (txtProductPrice.Text == "")
            txtProductPrice.Text = "0.0";
        if (txtSalestax.Text == "")
            txtSalestax.Text = "0.0";

        if (rdoRevenue.SelectedValue == "0" || rdoRevenue.SelectedValue == "3")
            Revnue01 = 0;
        else
            Revnue01 = 1;

        if (rdoRevenue.SelectedValue == "0" || rdoTip.SelectedValue == "0" || rdoPrior.SelectedValue == "0")
        {
        }
        else
        {
            CreditCardExpir = "";
        }
        #endregion Other Code

        #region If Rebook
        if (rdoRebook.SelectedValue == "1")
        {
            NextAppomentDate = lblNextAppDate.Text;
            NextAppomentTime = lblNextStartTime.Text;
            NextAppointmentEndTime = lblNextEndTime.Text;
        }
        #endregion

        #region If Not Rebook
        else
        {
            NextAppomentDate = "";
            NextAppomentTime = "";
            NextAppointmentEndTime = "";
        }
        #endregion

        ServicesForPet1 = txtServicesforPet1.Text.Trim();
        ServicesForPet2 = txtServicesforPet2.Text.Trim();
        ServicesForPet3 = txtServicesforPet3.Text.Trim();
        ServicesForPet4 = txtServicesforPet4.Text.Trim();
        ServicesForPet5 = txtServicesforPet5.Text.Trim();
        ServicesForPet6 = txtServicesforPet6.Text.Trim();

        #region Inserts appointment details in temp table.
        CreditCardNo = "";
        CreditCardExpir = "";
        CreditCardORChkName = "";
        CreditCardORChkAddr = "";
        SecurityCode = "";
        Session["AptDateFormat"] = lbl_time.Text;
        Session["AptString"] = lbl_description.Text;
        Session["AppStartTime"] = lblApptStartTime.Text;
        Session["AppEndTime"] = lblApptEndTime.Text;
        #endregion

        #region future date
        nextfdate = lblnextapp.Text;
        nextfstart = lblexpstart.Text;
        nextfend = lblexpend.Text;
        #region storepage data
        DataTable dtdetails = new DataTable();
        #region  #region Rowstart
        dtdetails.Columns.Add("AppStartTime");
        dtdetails.Columns.Add("AppEndTime");
        dtdetails.Columns.Add("AppDateTime");
        dtdetails.Columns.Add("Description");
        dtdetails.Columns.Add("CustumerName");
        dtdetails.Columns.Add("Date");
        dtdetails.Columns.Add("LastName");
        dtdetails.Columns.Add("JobMileage");
        dtdetails.Columns.Add("ZipCode");
        dtdetails.Columns.Add("Pets");
        dtdetails.Columns.Add("NextAppointmentTime");
        dtdetails.Columns.Add("ExpStartTime");
        dtdetails.Columns.Add("ExpEndTime");
        dtdetails.Columns.Add("Rebook");
        dtdetails.Columns.Add("FromRebook");
        dtdetails.Columns.Add("NextStartTime");
        dtdetails.Columns.Add("NextEndTime");
        #endregion  #region Rowstart
        #region hidden services
        dtdetails.Columns.Add("ServicesforPet1");
        dtdetails.Columns.Add("ServicesforPet2");
        dtdetails.Columns.Add("ServicesforPet3");
        dtdetails.Columns.Add("ServicesforPet4");
        dtdetails.Columns.Add("ServicesforPet5");
        dtdetails.Columns.Add("ServicesforPet6");
        dtdetails.Columns.Add("NewRadio");
        #endregion hidden services
        #region supplies
        dtdetails.Columns.Add("FleaandTick22");
        dtdetails.Columns.Add("FleaandTick44");
        dtdetails.Columns.Add("FleaandTick88");
        dtdetails.Columns.Add("FleaandTick132");
        dtdetails.Columns.Add("FleaandTickCat");
        dtdetails.Columns.Add("TB");
        dtdetails.Columns.Add("Wham");
        #endregion supplies
        #region Revenue
        //dtdetails.Columns.Add("RevenueCreditCard");
        //dtdetails.Columns.Add("RevenueCCY");
        //dtdetails.Columns.Add("RevenueCheck");
        //dtdetails.Columns.Add("RevenueCash");
        //dtdetails.Columns.Add("RevenueInvoice");
        dtdetails.Columns.Add("RevenueType");
        dtdetails.Columns.Add("RevenueAmount");

        dtdetails.Columns.Add("ApptChanges");
        dtdetails.Columns.Add("CommentDiv");

        dtdetails.Columns.Add("PetTimeGoodBad1");
        dtdetails.Columns.Add("PetTimeGoodBad2");
        #endregion Revenue
        #region Product
        dtdetails.Columns.Add("ProductPrice");
        dtdetails.Columns.Add("ProductSalesTax");
        #endregion Product
        #region Tip
        //dtdetails.Columns.Add("TipCreditCard");
        //dtdetails.Columns.Add("TipCheck");
        //dtdetails.Columns.Add("TipCash");
        //dtdetails.Columns.Add("TipInvoice");
        dtdetails.Columns.Add("Tiptype");
        dtdetails.Columns.Add("TipAmount");
        #endregion Tip
        #region Prior Revenue
        //dtdetails.Columns.Add("PriorCreditCard");
        //dtdetails.Columns.Add("PriorCheck");
        //dtdetails.Columns.Add("PriorCash");
        dtdetails.Columns.Add("PriorType");
        dtdetails.Columns.Add("PriorAmount");
        #endregion Prior Revenue
        #region CheckDetail
        dtdetails.Columns.Add("NameOnCheck");
        dtdetails.Columns.Add("AddressOnCheck");
        #endregion CheckDetail
        DataRow dr = dtdetails.NewRow();
        #region Rowstart
        dr["AppStartTime"] = lblApptStartTime.Text.Trim();
        dr["AppEndTime"] = lblApptEndTime.Text.Trim();
        dr["AppDateTime"] = lbl_time.Text.Trim();
        dr["Description"] = lbl_description.Text.Trim();
        dr["CustumerName"] = txtCustName.Text.Trim();
        dr["Date"] = txtDate.Text.Trim();
        dr["LastName"] = txtCustLastName.Text.Trim();
        dr["JobMileage"] = txtJob.Text.Trim();
        dr["ZipCode"] = txtZipCode.Text.Trim();
        dr["Pets"] = txtPets.Text.Trim();
        dr["NextAppointmentTime"] = lblnextapp.Text.Trim();
        dr["ExpStartTime"] = lblexpstart.Text.Trim();
        dr["ExpEndTime"] = lblexpend.Text.Trim();
        dr["Rebook"] = rdoRebook.SelectedValue;
        dr["FromRebook"] = lblNextAppDate.Text.Trim();
        dr["NextStartTime"] = lblNextStartTime.Text.Trim();
        dr["NextEndTime"] = lblNextEndTime.Text.Trim();
        #endregion Rowstart
        #region hidden services
        dr["ServicesforPet1"] = txtServicesforPet1.Text.Trim();
        dr["ServicesforPet2"] = txtServicesforPet2.Text.Trim();
        dr["ServicesforPet3"] = txtServicesforPet3.Text.Trim();
        dr["ServicesforPet4"] = txtServicesforPet4.Text.Trim();
        dr["ServicesforPet5"] = txtServicesforPet5.Text.Trim();
        dr["ServicesforPet6"] = txtServicesforPet6.Text.Trim();
        dr["NewRadio"] = rdoNew.SelectedValue;
        #endregion hidden services
        #region supplies
        dr["FleaandTick22"] = txtFleaandTick22.Text.Trim();
        dr["FleaandTick44"] = txtFleaandTick44.Text.Trim();
        dr["FleaandTick88"] = txtFleaandTick88.Text.Trim();
        dr["FleaandTick132"] = txtFleaandTick132.Text.Trim();
        dr["FleaandTickCat"] = txtFleaandTickCat.Text.Trim();
        dr["TB"] = txtTB.Text.Trim();
        dr["Wham"] = txtWham.Text.Trim();
        #endregion supplies
        #region Revenue
        dr["RevenueType"] = rdoRevenue.SelectedValue;
        dr["RevenueAmount"] = txtRevenue.Text.Trim();
        dr["ApptChanges"] = txtExtraServices.Text.Trim();
        dr["CommentDiv"] = txtComments.Text.Trim();
        dr["PetTimeGoodBad1"] = rdoDriveTime.SelectedValue;
        dr["PetTimeGoodBad2"] = rdoPetTime.SelectedValue;
        #endregion Revenue
        #region Product
        dr["ProductPrice"] = txtProductPrice.Text.Trim();
        dr["ProductSalesTax"] = txtSalestax.Text.Trim();
        #endregion Product
        #region Tip
        dr["Tiptype"] = rdoTip.SelectedValue;
        dr["TipAmount"] = txtTip.Text.Trim();
        #endregion Tip
        #region Prior Revenue
        dr["PriorType"] = rdoPrior.SelectedValue;
        dr["PriorAmount"] = txtPriorRevenue.Text.Trim();
        #endregion Prior Revenue
        #region CheckDetail
        dr["NameOnCheck"] = txtcname.Text.Trim();
        dr["AddressOnCheck"] = txtcaddr.Text.Trim();
        #endregion CheckDetail
        dtdetails.Rows.Add(dr);
        #endregion storepage data
        Session["AppointmentDetails"] = dtdetails;
        Session["CustName"] = txtCustName.Text.Trim();
        #endregion
    }
    #endregion Confirm 

    #region  Make Instant Payment save this page data so that it may be bind after payment successful or unsuccessfull attempt
    protected void btnMakePayment_Click(object sender, EventArgs e)
    {
        #region Code Umesh
        if (rdoRevenue.SelectedValue.ToString() != "1")
        {
            if (rdoRevenue.SelectedValue.ToString() == "0" || rdoTip.SelectedValue.ToString() == "0" || rdoPrior.SelectedValue.ToString() == "0")
            {
                if (txtRevenue.Text != "")
                {
                    CustomerName = txtCustLastName.Text.Trim();
                    Job = txtJob.Text.Trim();
                    ZipCode = txtZipCode.Text.Trim();
                    Pets = txtPets.Text.Trim();
                    Rebook = rdoRebook.SelectedValue;
                    string lbldesc = lbl_description.Text;
                    Session["AptString"] = lbl_description.Text;
                    string searchstring = lbl_description.Text;
                    if (searchstring.ToLower().Contains("rbk") || searchstring.ToLower().Contains("rec")) FromRebook = "1";
                    else FromRebook = "0";
                    if (searchstring.Contains("*")) New = "1";
                    else New = "0";
                    TimeIn = lblApptStartTime.Text;//Session["appt_start_time"].ToString();
                    TimeOut = lblApptEndTime.Text;//Session["appt_end_time"].ToString();
                    if (!(null == (Session["pettime"]))) PetTime = Session["pettime"].ToString();
                    else PetTime = "0";

                    #region Page Data
                    //PetTime = lblApptCompleteTime.Text;//txtPetTime.Text;
                    ExtraServices = txtExtraServices.Text.Trim();
                    //add txtComments here 16jan13
                    comments = txtComments.Text.Trim();
                    driveTime = rdoDriveTime.SelectedValue;
                    rpetTime = rdoPetTime.SelectedValue;
                    // FleaandTick
                    if (txtFleaandTick22.Text.Trim() != "") { FleaandTick22 = Convert.ToInt32(txtFleaandTick22.Text.Trim()); }
                    if (txtFleaandTick44.Text.Trim() != "") { FleaandTick44 = Convert.ToInt32(txtFleaandTick44.Text.Trim()); }
                    if (txtFleaandTick88.Text.Trim() != "") { FleaandTick88 = Convert.ToInt32(txtFleaandTick88.Text.Trim()); }
                    if (txtFleaandTick132.Text.Trim() != "") { FleaandTick132 = Convert.ToInt32(txtFleaandTick132.Text.Trim()); }
                    if (txtFleaandTickCat.Text.Trim() != "") { FleaandTickCat = Convert.ToInt32(txtFleaandTickCat.Text.Trim()); }
                    if (txtTB.Text.Trim() != "") { TB = Convert.ToInt32(txtTB.Text.Trim()); }
                    if (txtWham.Text.Trim() != "") { Wham = Convert.ToInt32(txtWham.Text.Trim()); }
                    // Revenue 
                    if (rdoRevenue.SelectedValue != "0") { RevenueCreditCard = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCreditCard = Convert.ToDouble(txtRevenue.Text.Trim()); } }
                    if (rdoRevenue.SelectedValue != "1") { RevenueCCY = 0; } else { if (txtRevenue.Text != "") { RevenueCCY = Convert.ToDouble(txtRevenue.Text.Trim()); } }
                    if (rdoRevenue.SelectedValue != "2") { RevenueCheck = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCheck = Convert.ToDouble(txtRevenue.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
                    if (rdoRevenue.SelectedValue != "3") { RevenueCash = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCash = Convert.ToDouble(txtRevenue.Text.Trim()); } }
                    if (rdoRevenue.SelectedValue != "4") { RevenueInvoice = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueInvoice = Convert.ToDouble(txtRevenue.Text.Trim()); } }
                    // Tip
                    if (rdoTip.SelectedValue != "0") { TipCreditCard = 0; } else { if (txtTip.Text.Trim() != "") { TipCreditCard = Convert.ToDouble(txtTip.Text.Trim()); } }
                    if (rdoTip.SelectedValue != "1") { TipCheck = 0; } else { if (txtTip.Text.Trim() != "") { TipCheck = Convert.ToDouble(txtTip.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
                    if (rdoTip.SelectedValue != "2") { TipCash = 0; } else { if (txtTip.Text.Trim() != "") { TipCash = Convert.ToDouble(txtTip.Text.Trim()); } }
                    if (rdoTip.SelectedValue != "3") { TipInvoice = 0; } else { if (txtTip.Text.Trim() != "") { TipInvoice = Convert.ToDouble(txtTip.Text.Trim()); } }
                    // Prior Amount
                    if (rdoPrior.SelectedValue != "0") { PriorCreditCard = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCreditCard = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } }
                    if (rdoPrior.SelectedValue != "1") { PriorCheck = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCheck = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
                    if (rdoPrior.SelectedValue != "2") { PriorCash = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCash = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } }

                    if (txtProductPrice.Text == "")
                        txtProductPrice.Text = "0.0";
                    if (txtSalestax.Text == "")
                        txtSalestax.Text = "0.0";

                    if (rdoRevenue.SelectedValue == "0" || rdoRevenue.SelectedValue == "3")
                        Revnue01 = 0;
                    else
                        Revnue01 = 1;

                    if (rdoRevenue.SelectedValue == "0" || rdoTip.SelectedValue == "0" || rdoPrior.SelectedValue == "0")
                    {
                    }
                    else
                    {
                        CreditCardExpir = "";
                    }
                    // Rebook
                    if (rdoRebook.SelectedValue == "1")
                    {
                        NextAppomentDate = lblNextAppDate.Text;
                        NextAppomentTime = lblNextStartTime.Text;
                        NextAppointmentEndTime = lblNextEndTime.Text;
                    }
                    else
                    {
                        NextAppomentDate = "";
                        NextAppomentTime = "";
                        NextAppointmentEndTime = "";
                    }
                    ServicesForPet1 = txtServicesforPet1.Text.Trim();
                    ServicesForPet2 = txtServicesforPet2.Text.Trim();
                    ServicesForPet3 = txtServicesforPet3.Text.Trim();
                    ServicesForPet4 = txtServicesforPet4.Text.Trim();
                    ServicesForPet5 = txtServicesforPet5.Text.Trim();
                    ServicesForPet6 = txtServicesforPet6.Text.Trim();
                    #endregion

                    // Inserts appointment details in temp table.
                    CreditCardNo = "";
                    CreditCardExpir = "";
                    CreditCardORChkName = "";
                    CreditCardORChkAddr = "";
                    SecurityCode = "";
                    Session["AptDateFormat"] = lbl_time.Text;
                    Session["AptString"] = lbl_description.Text;
                    //Session["DailyLogID"] = RecID.ToString();
                    Session["AppStartTime"] = lblApptStartTime.Text;
                    Session["AppEndTime"] = lblApptEndTime.Text;
                    //Session["ApptTimings"] = ddlIN.SelectedItem.Text + "," + ddlOUT.SelectedItem.Text;

                    // future date
                    nextfdate = lblnextapp.Text;
                    nextfstart = lblexpstart.Text;
                    nextfend = lblexpend.Text;

                    #region storepage data
                    DataTable dtdetails = new DataTable();
                    #region  #region Rowstart
                    dtdetails.Columns.Add("AppStartTime");
                    dtdetails.Columns.Add("AppEndTime");
                    dtdetails.Columns.Add("AppDateTime");
                    dtdetails.Columns.Add("Description");
                    dtdetails.Columns.Add("CustumerName");
                    dtdetails.Columns.Add("Date");
                    dtdetails.Columns.Add("LastName");
                    dtdetails.Columns.Add("JobMileage");
                    dtdetails.Columns.Add("ZipCode");
                    dtdetails.Columns.Add("Pets");
                    dtdetails.Columns.Add("NextAppointmentTime");
                    dtdetails.Columns.Add("ExpStartTime");
                    dtdetails.Columns.Add("ExpEndTime");
                    dtdetails.Columns.Add("Rebook");
                    dtdetails.Columns.Add("FromRebook");
                    dtdetails.Columns.Add("NextStartTime");
                    dtdetails.Columns.Add("NextEndTime");
                    #endregion  #region Rowstart
                    #region hidden services
                    dtdetails.Columns.Add("ServicesforPet1");
                    dtdetails.Columns.Add("ServicesforPet2");
                    dtdetails.Columns.Add("ServicesforPet3");
                    dtdetails.Columns.Add("ServicesforPet4");
                    dtdetails.Columns.Add("ServicesforPet5");
                    dtdetails.Columns.Add("ServicesforPet6");
                    dtdetails.Columns.Add("NewRadio");
                    #endregion hidden services
                    #region supplies
                    dtdetails.Columns.Add("FleaandTick22");
                    dtdetails.Columns.Add("FleaandTick44");
                    dtdetails.Columns.Add("FleaandTick88");
                    dtdetails.Columns.Add("FleaandTick132");
                    dtdetails.Columns.Add("FleaandTickCat");
                    dtdetails.Columns.Add("TB");
                    dtdetails.Columns.Add("Wham");
                    #endregion supplies
                    #region Revenue
                    //dtdetails.Columns.Add("RevenueCreditCard");
                    //dtdetails.Columns.Add("RevenueCCY");
                    //dtdetails.Columns.Add("RevenueCheck");
                    //dtdetails.Columns.Add("RevenueCash");
                    //dtdetails.Columns.Add("RevenueInvoice");
                    dtdetails.Columns.Add("RevenueType");
                    dtdetails.Columns.Add("RevenueAmount");

                    dtdetails.Columns.Add("ApptChanges");
                    dtdetails.Columns.Add("CommentDiv");

                    dtdetails.Columns.Add("PetTimeGoodBad1");
                    dtdetails.Columns.Add("PetTimeGoodBad2");
                    #endregion Revenue
                    #region Product
                    dtdetails.Columns.Add("ProductPrice");
                    dtdetails.Columns.Add("ProductSalesTax");
                    #endregion Product
                    #region Tip
                    //dtdetails.Columns.Add("TipCreditCard");
                    //dtdetails.Columns.Add("TipCheck");
                    //dtdetails.Columns.Add("TipCash");
                    //dtdetails.Columns.Add("TipInvoice");
                    dtdetails.Columns.Add("Tiptype");
                    dtdetails.Columns.Add("TipAmount");
                    #endregion Tip
                    #region Prior Revenue
                    //dtdetails.Columns.Add("PriorCreditCard");
                    //dtdetails.Columns.Add("PriorCheck");
                    //dtdetails.Columns.Add("PriorCash");
                    dtdetails.Columns.Add("PriorType");
                    dtdetails.Columns.Add("PriorAmount");
                    #endregion Prior Revenue
                    #region CheckDetail
                    dtdetails.Columns.Add("NameOnCheck");
                    dtdetails.Columns.Add("AddressOnCheck");
                    #endregion CheckDetail
                    DataRow dr = dtdetails.NewRow();
                    #region Rowstart
                    dr["AppStartTime"] = lblApptStartTime.Text.Trim();
                    dr["AppEndTime"] = lblApptEndTime.Text.Trim();
                    dr["AppDateTime"] = lbl_time.Text.Trim();
                    dr["Description"] = lbl_description.Text.Trim();
                    dr["CustumerName"] = txtCustName.Text.Trim();
                    dr["Date"] = txtDate.Text.Trim();
                    dr["LastName"] = txtCustLastName.Text.Trim();
                    dr["JobMileage"] = txtJob.Text.Trim();
                    dr["ZipCode"] = txtZipCode.Text.Trim();
                    dr["Pets"] = txtPets.Text.Trim();
                    dr["NextAppointmentTime"] = lblnextapp.Text.Trim();
                    dr["ExpStartTime"] = lblexpstart.Text.Trim();
                    dr["ExpEndTime"] = lblexpend.Text.Trim();
                    dr["Rebook"] = rdoRebook.SelectedValue;
                    dr["FromRebook"] = lblNextAppDate.Text.Trim();
                    dr["NextStartTime"] = lblNextStartTime.Text.Trim();
                    dr["NextEndTime"] = lblNextEndTime.Text.Trim();
                    #endregion Rowstart
                    #region hidden services
                    dr["ServicesforPet1"] = txtServicesforPet1.Text.Trim();
                    dr["ServicesforPet2"] = txtServicesforPet2.Text.Trim();
                    dr["ServicesforPet3"] = txtServicesforPet3.Text.Trim();
                    dr["ServicesforPet4"] = txtServicesforPet4.Text.Trim();
                    dr["ServicesforPet5"] = txtServicesforPet5.Text.Trim();
                    dr["ServicesforPet6"] = txtServicesforPet6.Text.Trim();
                    dr["NewRadio"] = rdoNew.SelectedValue;
                    #endregion hidden services
                    #region supplies
                    dr["FleaandTick22"] = txtFleaandTick22.Text.Trim();
                    dr["FleaandTick44"] = txtFleaandTick44.Text.Trim();
                    dr["FleaandTick88"] = txtFleaandTick88.Text.Trim();
                    dr["FleaandTick132"] = txtFleaandTick132.Text.Trim();
                    dr["FleaandTickCat"] = txtFleaandTickCat.Text.Trim();
                    dr["TB"] = txtTB.Text.Trim();
                    dr["Wham"] = txtWham.Text.Trim();
                    #endregion supplies
                    #region Revenue
                    dr["RevenueType"] = rdoRevenue.SelectedValue;
                    dr["RevenueAmount"] = txtRevenue.Text.Trim();
                    dr["ApptChanges"] = txtExtraServices.Text.Trim();
                    dr["CommentDiv"] = txtComments.Text.Trim();
                    dr["PetTimeGoodBad1"] = rdoDriveTime.SelectedValue;
                    dr["PetTimeGoodBad2"] = rdoPetTime.SelectedValue;
                    #endregion Revenue
                    #region Product
                    dr["ProductPrice"] = txtProductPrice.Text.Trim();
                    dr["ProductSalesTax"] = txtSalestax.Text.Trim();
                    #endregion Product
                    #region Tip
                    dr["Tiptype"] = rdoTip.SelectedValue;
                    dr["TipAmount"] = txtTip.Text.Trim();
                    #endregion Tip
                    #region Prior Revenue
                    dr["PriorType"] = rdoPrior.SelectedValue;
                    dr["PriorAmount"] = txtPriorRevenue.Text.Trim();
                    #endregion Prior Revenue
                    #region CheckDetail
                    dr["NameOnCheck"] = txtcname.Text.Trim();
                    dr["AddressOnCheck"] = txtcaddr.Text.Trim();
                    #endregion CheckDetail
                    dtdetails.Rows.Add(dr);
                    #endregion storepage data

                    Session["AppointmentDetails"] = dtdetails;
                    Session["CustName"] = txtCustName.Text;
                    Response.Redirect("PaymentInfo.aspx", false);
                }
                else txtRevenue.Focus();
            }
            else btnMakePayment.Focus();
        }
        else btnMakePayment.Focus();

        #endregion Code Umesh
    }
    #endregion

    #region Sync Appt To Member Profile
    protected void btnCustSync_Click(object sender, EventArgs e)
    {
        if (txtCustName.Text == "")
        {
            ErrMessage("Please Fill Member Email to synchronized the appointment");
            txtCustName.Focus();
        }
        else
        {
            DataSet ds = objGroomer.getCustomerforSync(txtCustName.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.Count > 0)
                if (txtCustName.Text == ds.Tables[0].Rows[0]["UserName"].ToString())
                {
                    Session["ProfileConnected"] = "Yes";
                    Session["CustName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                    int apid = Convert.ToInt32(Session["GroomerAppointmentId"]);
                    txtZipCode.Text = ds.Tables[0].Rows[0]["Zip"].ToString();
                    txtCustLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    objGroomer.UpdateSyncCustName(apid, txtCustName.Text);
                    SuccesfullMessage("Appointment successfully synchronized to " + txtCustName.Text.Trim() + " profile.");
                    // btnCustSync.Enabled = false;
                    btnRevSync.Visible = true;
                }
                else
                {
                    ErrMessage("Customer Not Found!!! Please check customer email or contact to administrator");
                    txtCustName.Focus();
                }
            else
            {
                ErrMessage("Customer Not Found!!! Please check customer email or contact to administrator");
                txtCustName.Focus();
            }
        }

    }

    #endregion

    #region  Verify Payment
    protected void btnCheckPayment_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        DataSet ds = objGroomer.VerifySyncAppPaymentDetails(Convert.ToInt32(Session["SyncId"]));
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!(null == ds.Tables[0].Rows[0]["tipamt"]))
            {
                string t = ds.Tables[0].Rows[0]["tipamt"].ToString();
                txtTip.Text = t;
                Session["TipAmt"] = ds.Tables[0].Rows[0]["tipamt"].ToString();
            }
            string p = ds.Tables[0].Rows[0]["pstatus"].ToString();

            Session["PayID"] = ds.Tables[0].Rows[0]["payid"].ToString();
            if (p == "Paid")
            {
                SuccesfullMessage("Payment transaction has been successful!!!");
                txtCustName.Focus();
                txtRevenue.Enabled = false;
                txtTip.Enabled = false;
                txtPriorRevenue.Enabled = false;
                btnCancelRev.Enabled = false;
            }
            else
            {
                ErrMessage("Payment transaction is Unsuccessfull!!!");
                txtCustName.Focus();
            }
        }
        FillAppointmentLogDetails();
    }
    #endregion

    #region Revenue Synchronize Button
    protected void btnRevSync_Click(object sender, EventArgs e)
    {
        string p = Session["ProfileConnected"].ToString();
        if (!(null == Session["ProfileConnected"]) && "Yes" == p)
        {
            if (rdoRevenue.SelectedValue.ToString() == "0" || rdoTip.SelectedValue.ToString() == "0" || rdoPrior.SelectedValue.ToString() == "0")
            {
                if (txtRevenue.Text != "")
                {
                    string custname = "";
                    int GroomerAppointmentId = Convert.ToInt32(Session["GroomerAppointmentId"]);

                    custname = txtCustName.Text;
                    if (rdoRevenue.SelectedValue.ToString() == "0") revamt = txtRevenue.Text == "" ? 0 : Convert.ToDecimal(txtRevenue.Text);
                    else revamt = 0;

                    if (rdoTip.SelectedValue.ToString() == "0") tipamt = txtTip.Text == "" ? 0 : Convert.ToDecimal(txtTip.Text);
                    else tipamt = 0;

                    if (rdoPrior.SelectedValue.ToString() == "0") prioramt = txtPriorRevenue.Text == "" ? 0 : Convert.ToDecimal(txtPriorRevenue.Text);
                    else prioramt = 0;

                    decimal totalamt = Math.Round((revamt + tipamt + prioramt), 2);

                    int gid = Convert.ToInt32(Session["GId"]);
                    int syncid = objGroomer.InsertSyncAppointment(GroomerAppointmentId, gid, custname, lbl_description.Text, lbl_time.Text, revamt, tipamt, prioramt, totalamt, "Unpaid");

                    Session["SyncId"] = syncid;
                    btnCheckPayment.Visible = true;
                    btnRevSync.Enabled = false;
                    btnMakePayment.Visible = false;
                    Session["ProfileConnected"] = "Yes";
                    SuccesfullMessage("Revenue Synchronized successfully to customer profile");
                    txtCustName.Focus();
                    btnCancelRev.Visible = true;
                    FillAppointmentLogDetails();

                    //disable custumer sync button
                    btnCustSync.Enabled = false;

                    // show and enable  CancelRev Button 
                    btnCancelRev.Enabled = true;
                    btnCancelRev.Visible = true;

                    //  hide and disable  RevSync Button 
                    btnRevSync.Enabled = false;
                    btnRevSync.Visible = false;
                }
                else
                {
                    ErrMessage("Please fill revenue amount to synchronized.");
                    txtRevenue.Focus();
                }
            }
            else
            {
                ErrMessage("Please choose option credit card for Revenue,Tip and Prior revenue amount ");
                txtRevenue.Focus();
            }
        }
        else
        {
            btnCustSync.Enabled = true;
            txtRevenue.Focus();
        }
    }
    #endregion

    #region  Cancel Sync Revenue
    protected void btnCancelRev_Click(object sender, EventArgs e)
    {
        int sid;
        if (!(null == Session["SyncId"]))
        {
            sid = Convert.ToInt32(Session["SyncId"]);
            objGroomer.deleteSyncRevenu(sid, Session["RevAmtToSync"].ToString(), Convert.ToInt32(Session["GroomerAppointmentId"].ToString()));
            txtRevenue.Text = Session["RevAmtToSync"].ToString();
            txtTip.Text = string.Empty;
            txtPriorRevenue.Text = string.Empty;
            SuccesfullMessage("Synchronized Revenue is successfully cancel from customer profile.");
            txtCustName.Focus();
            btnCheckPayment.Visible = false;
            btnRevSync.Visible = false;
            btnCancelRev.Enabled = false;
            btnMakePayment.Visible = true;
            FillAppointmentLogDetails();

            //enable custumer sync button
            btnCustSync.Enabled = true;

            // hide and disable  CancelRev Button 
            btnCancelRev.Enabled = false;
            btnCancelRev.Visible = false;

            // show and enable  RevSync Button 
            btnRevSync.Enabled = true;
            btnRevSync.Visible = true;
        }
    }
    #endregion

    #region ReSchedule Next Appointment
    protected void btnReSchedule_Click(object sender, EventArgs e)
    {
        fillTempData();
        Session["CustName"] = txtCustName.Text;
        Session["PageFrom"] = "OP";
        Response.Redirect("CalendarView.aspx");
    }
    #endregion

    #region Reebok From Calender
    protected void btnRebookNextApp_Click(object sender, EventArgs e)
    {
        fillTempData();
        Session["CustName"] = txtCustName.Text;
        Session["PageFrom"] = "OPR";
        Response.Redirect("CalendarView.aspx");
    }
    #endregion

    #region fillTempData
    public void fillTempData()
    {
        CustomerName = txtCustLastName.Text.Trim();
        Job = txtJob.Text.Trim();
        ZipCode = txtZipCode.Text.Trim();
        Pets = txtPets.Text.Trim();
        Rebook = rdoRebook.SelectedValue;
        //new 1April13
        string lbldesc = lbl_description.Text;
        if (lbldesc.ToLower().Contains("rbk") || lbldesc.ToLower().Contains("rec"))
        {
            FromRebook = "1";
        }
        else
        {
            FromRebook = "0";
        }
        if (lbldesc.Contains("*"))
        {
            New = "1";
        }
        else
        {
            New = "0";
        }
        TimeIn = lblApptStartTime.Text;//Session["appt_start_time"].ToString();
        TimeOut = lblApptEndTime.Text;//Session["appt_end_time"].ToString();
        if (!(null == (Session["pettime"])))
        {
            PetTime = Session["pettime"].ToString();
        }
        else
        {
            PetTime = "0";
        }
        ExtraServices = txtExtraServices.Text.Trim();
        //add txtComments here 16jan13
        comments = txtComments.Text.Trim();
        driveTime = rdoDriveTime.SelectedValue;
        rpetTime = rdoPetTime.SelectedValue;
        // FleaandTick
        if (txtFleaandTick22.Text.Trim() != "") { FleaandTick22 = Convert.ToInt32(txtFleaandTick22.Text.Trim()); }
        if (txtFleaandTick44.Text.Trim() != "") { FleaandTick44 = Convert.ToInt32(txtFleaandTick44.Text.Trim()); }
        if (txtFleaandTick88.Text.Trim() != "") { FleaandTick88 = Convert.ToInt32(txtFleaandTick88.Text.Trim()); }
        if (txtFleaandTick132.Text.Trim() != "") { FleaandTick132 = Convert.ToInt32(txtFleaandTick132.Text.Trim()); }
        if (txtFleaandTickCat.Text.Trim() != "") { FleaandTickCat = Convert.ToInt32(txtFleaandTickCat.Text.Trim()); }
        if (txtTB.Text.Trim() != "") { TB = Convert.ToInt32(txtTB.Text.Trim()); }
        if (txtWham.Text.Trim() != "") { Wham = Convert.ToInt32(txtWham.Text.Trim()); }
        // Revenue 
        if (rdoRevenue.SelectedValue != "0") { RevenueCreditCard = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCreditCard = Convert.ToDouble(txtRevenue.Text.Trim()); } }
        if (rdoRevenue.SelectedValue != "1") { RevenueCCY = 0; } else { if (txtRevenue.Text != "") { RevenueCCY = Convert.ToDouble(txtRevenue.Text.Trim()); } }
        if (rdoRevenue.SelectedValue != "2") { RevenueCheck = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCheck = Convert.ToDouble(txtRevenue.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
        if (rdoRevenue.SelectedValue != "3") { RevenueCash = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCash = Convert.ToDouble(txtRevenue.Text.Trim()); } }
        if (rdoRevenue.SelectedValue != "4") { RevenueInvoice = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueInvoice = Convert.ToDouble(txtRevenue.Text.Trim()); } }
        // Tip
        if (rdoTip.SelectedValue != "0") { TipCreditCard = 0; } else { if (txtTip.Text.Trim() != "") { TipCreditCard = Convert.ToDouble(txtTip.Text.Trim()); } }
        if (rdoTip.SelectedValue != "1") { TipCheck = 0; } else { if (txtTip.Text.Trim() != "") { TipCheck = Convert.ToDouble(txtTip.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
        if (rdoTip.SelectedValue != "2") { TipCash = 0; } else { if (txtTip.Text.Trim() != "") { TipCash = Convert.ToDouble(txtTip.Text.Trim()); } }
        if (rdoTip.SelectedValue != "3") { TipInvoice = 0; } else { if (txtTip.Text.Trim() != "") { TipInvoice = Convert.ToDouble(txtTip.Text.Trim()); } }
        // Prior Amount
        if (rdoPrior.SelectedValue != "0") { PriorCreditCard = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCreditCard = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } }
        if (rdoPrior.SelectedValue != "1") { PriorCheck = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCheck = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
        if (rdoPrior.SelectedValue != "2") { PriorCash = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCash = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } }

        if (txtProductPrice.Text == "")
            txtProductPrice.Text = "0.0";
        if (txtSalestax.Text == "")
            txtSalestax.Text = "0.0";

        if (rdoRevenue.SelectedValue == "0" || rdoRevenue.SelectedValue == "3")
            Revnue01 = 0;
        else
            Revnue01 = 1;

        if (rdoRevenue.SelectedValue == "0" || rdoTip.SelectedValue == "0" || rdoPrior.SelectedValue == "0")
        {
        }
        else
        {
            CreditCardExpir = "";
        }
        // Rebook
        if (rdoRebook.SelectedValue == "1")
        {
            NextAppomentDate = lblNextAppDate.Text;
            NextAppomentTime = lblNextStartTime.Text;
            NextAppointmentEndTime = lblNextEndTime.Text;
        }
        else
        {
            NextAppomentDate = "";
            NextAppomentTime = "";
            NextAppointmentEndTime = "";
        }

        ServicesForPet1 = txtServicesforPet1.Text.Trim();
        ServicesForPet2 = txtServicesforPet2.Text.Trim();
        ServicesForPet3 = txtServicesforPet3.Text.Trim();
        ServicesForPet4 = txtServicesforPet4.Text.Trim();
        ServicesForPet5 = txtServicesforPet5.Text.Trim();
        ServicesForPet6 = txtServicesforPet6.Text.Trim();

        // Inserts appointment details in temp table.
        CreditCardNo = "";
        CreditCardExpir = "";
        CreditCardORChkName = "";
        CreditCardORChkAddr = "";
        SecurityCode = "";
        // Insert TempDailyOperationLog Details
        int RecID = objGroomer.InsertTempDailyOperationLog(Convert.ToInt32(Session["GroomerAppointmentId"]), strGId, strVanID, strBeginningMileage, strTotalHours, strEndingMileage, strFuelPurchased, strPriceperGallon, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, comments, driveTime, rpetTime, FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham, RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, RevenueCCY, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, CreditCardNo, CreditCardExpir, CreditCardORChkName, CreditCardORChkAddr, SecurityCode, NextAppomentDate, NextAppomentTime, NextAppointmentEndTime, ServicesForPet1, ServicesForPet2, ServicesForPet3, ServicesForPet4, ServicesForPet5, ServicesForPet6, Convert.ToInt32(GroomerAppointmentId), Session["AppointmentDate"].ToString(), Convert.ToDouble(txtProductPrice.Text), Convert.ToDouble(txtSalestax.Text), Revnue01, NameOnCheque, Bankname);
        if (RecID > 0)
        {
            Session["DailyLogID"] = RecID;
            Session["AptDateFormat"] = lbl_time.Text;
            Session["AptString"] = lbl_description.Text;
            Session["AppStartTime"] = lblApptStartTime.Text;
            Session["AppEndTime"] = lblApptEndTime.Text;

            // future date
            nextfdate = lblnextapp.Text;
            nextfstart = lblexpstart.Text;
            nextfend = lblexpend.Text;

            #region storepage data
            DataTable dtdetails = new DataTable();
            #region  #region Rowstart
            dtdetails.Columns.Add("AppStartTime");
            dtdetails.Columns.Add("AppEndTime");
            dtdetails.Columns.Add("AppDateTime");
            dtdetails.Columns.Add("Description");
            dtdetails.Columns.Add("CustumerName");
            dtdetails.Columns.Add("Date");
            dtdetails.Columns.Add("LastName");
            dtdetails.Columns.Add("JobMileage");
            dtdetails.Columns.Add("ZipCode");
            dtdetails.Columns.Add("Pets");
            dtdetails.Columns.Add("NextAppointmentTime");
            dtdetails.Columns.Add("ExpStartTime");
            dtdetails.Columns.Add("ExpEndTime");
            dtdetails.Columns.Add("Rebook");
            dtdetails.Columns.Add("FromRebook");
            dtdetails.Columns.Add("NextStartTime");
            dtdetails.Columns.Add("NextEndTime");
            #endregion  #region Rowstart
            #region hidden services
            dtdetails.Columns.Add("ServicesforPet1");
            dtdetails.Columns.Add("ServicesforPet2");
            dtdetails.Columns.Add("ServicesforPet3");
            dtdetails.Columns.Add("ServicesforPet4");
            dtdetails.Columns.Add("ServicesforPet5");
            dtdetails.Columns.Add("ServicesforPet6");
            dtdetails.Columns.Add("NewRadio");
            #endregion hidden services
            #region supplies
            dtdetails.Columns.Add("FleaandTick22");
            dtdetails.Columns.Add("FleaandTick44");
            dtdetails.Columns.Add("FleaandTick88");
            dtdetails.Columns.Add("FleaandTick132");
            dtdetails.Columns.Add("FleaandTickCat");
            dtdetails.Columns.Add("TB");
            dtdetails.Columns.Add("Wham");
            #endregion supplies
            #region Revenue
            //dtdetails.Columns.Add("RevenueCreditCard");
            //dtdetails.Columns.Add("RevenueCCY");
            //dtdetails.Columns.Add("RevenueCheck");
            //dtdetails.Columns.Add("RevenueCash");
            //dtdetails.Columns.Add("RevenueInvoice");
            dtdetails.Columns.Add("RevenueType");
            dtdetails.Columns.Add("RevenueAmount");

            dtdetails.Columns.Add("ApptChanges");
            dtdetails.Columns.Add("CommentDiv");

            dtdetails.Columns.Add("PetTimeGoodBad1");
            dtdetails.Columns.Add("PetTimeGoodBad2");
            #endregion Revenue
            #region Product
            dtdetails.Columns.Add("ProductPrice");
            dtdetails.Columns.Add("ProductSalesTax");
            #endregion Product
            #region Tip
            //dtdetails.Columns.Add("TipCreditCard");
            //dtdetails.Columns.Add("TipCheck");
            //dtdetails.Columns.Add("TipCash");
            //dtdetails.Columns.Add("TipInvoice");
            dtdetails.Columns.Add("Tiptype");
            dtdetails.Columns.Add("TipAmount");
            #endregion Tip
            #region Prior Revenue
            //dtdetails.Columns.Add("PriorCreditCard");
            //dtdetails.Columns.Add("PriorCheck");
            //dtdetails.Columns.Add("PriorCash");
            dtdetails.Columns.Add("PriorType");
            dtdetails.Columns.Add("PriorAmount");
            #endregion Prior Revenue
            #region CheckDetail
            dtdetails.Columns.Add("NameOnCheck");
            dtdetails.Columns.Add("AddressOnCheck");
            #endregion CheckDetail
            DataRow dr = dtdetails.NewRow();
            #region Rowstart
            dr["AppStartTime"] = lblApptStartTime.Text.Trim();
            dr["AppEndTime"] = lblApptEndTime.Text.Trim();
            dr["AppDateTime"] = lbl_time.Text.Trim();
            dr["Description"] = lbl_description.Text.Trim();
            dr["CustumerName"] = txtCustName.Text.Trim();
            dr["Date"] = txtDate.Text.Trim();
            dr["LastName"] = txtCustLastName.Text.Trim();
            dr["JobMileage"] = txtJob.Text.Trim();
            dr["ZipCode"] = txtZipCode.Text.Trim();
            dr["Pets"] = txtPets.Text.Trim();
            dr["NextAppointmentTime"] = lblnextapp.Text.Trim();
            dr["ExpStartTime"] = lblexpstart.Text.Trim();
            dr["ExpEndTime"] = lblexpend.Text.Trim();

            if (Session["NextEndTime"] == null)
            {
                dr["NextStartTime"] = lblNextStartTime.Text.Trim();
                dr["NextEndTime"] = lblNextEndTime.Text.Trim();
            }
            else
            {
                dr["NextStartTime"] = Convert.ToString(Session["NextStartTime"]);
                dr["NextEndTime"] = Convert.ToString(Session["NextEndTime"]);
            }

            dr["Rebook"] = rdoRebook.SelectedValue;
            dr["FromRebook"] = lblNextAppDate.Text.Trim();
         
            #endregion Rowstart
            #region hidden services
            dr["ServicesforPet1"] = txtServicesforPet1.Text.Trim();
            dr["ServicesforPet2"] = txtServicesforPet2.Text.Trim();
            dr["ServicesforPet3"] = txtServicesforPet3.Text.Trim();
            dr["ServicesforPet4"] = txtServicesforPet4.Text.Trim();
            dr["ServicesforPet5"] = txtServicesforPet5.Text.Trim();
            dr["ServicesforPet6"] = txtServicesforPet6.Text.Trim();
            dr["NewRadio"] = rdoNew.SelectedValue;
            #endregion hidden services
            #region supplies
            dr["FleaandTick22"] = txtFleaandTick22.Text.Trim();
            dr["FleaandTick44"] = txtFleaandTick44.Text.Trim();
            dr["FleaandTick88"] = txtFleaandTick88.Text.Trim();
            dr["FleaandTick132"] = txtFleaandTick132.Text.Trim();
            dr["FleaandTickCat"] = txtFleaandTickCat.Text.Trim();
            dr["TB"] = txtTB.Text.Trim();
            dr["Wham"] = txtWham.Text.Trim();
            #endregion supplies
            #region Revenue
            dr["RevenueType"] = rdoRevenue.SelectedValue;
            dr["RevenueAmount"] = txtRevenue.Text.Trim();
            dr["ApptChanges"] = txtExtraServices.Text.Trim();
            dr["CommentDiv"] = txtComments.Text.Trim();
            dr["PetTimeGoodBad1"] = rdoDriveTime.SelectedValue;
            dr["PetTimeGoodBad2"] = rdoPetTime.SelectedValue;
            #endregion Revenue
            #region Product
            dr["ProductPrice"] = txtProductPrice.Text.Trim();
            dr["ProductSalesTax"] = txtSalestax.Text.Trim();
            #endregion Product
            #region Tip
            dr["Tiptype"] = rdoTip.SelectedValue;
            dr["TipAmount"] = txtTip.Text.Trim();
            #endregion Tip
            #region Prior Revenue
            dr["PriorType"] = rdoPrior.SelectedValue;
            dr["PriorAmount"] = txtPriorRevenue.Text.Trim();
            #endregion Prior Revenue
            #region CheckDetail
            dr["NameOnCheck"] = txtcname.Text.Trim();
            dr["AddressOnCheck"] = txtcaddr.Text.Trim();
            #endregion CheckDetail
            dtdetails.Rows.Add(dr);
            #endregion storepage data

            Session["AppointmentDetails"] = dtdetails;
        }
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