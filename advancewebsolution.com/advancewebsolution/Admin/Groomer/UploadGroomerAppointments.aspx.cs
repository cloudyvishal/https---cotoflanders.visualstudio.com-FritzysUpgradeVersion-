using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using advancewebtosolution.BO;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Admin_Groomer_UploadGroomerAppointments : System.Web.UI.Page
{
    #region Constructor
    public Admin_Groomer_UploadGroomerAppointments()
    {
        //create directory if not exists
        if (!Directory.Exists(Server.MapPath("~/Admin/Groomer/AppointmentFiles")))
            Directory.CreateDirectory(Server.MapPath("~/Admin/Groomer/AppointmentFiles"));
    }
    #endregion

    #region "Global Variable"
    int NoofInsertedAppt = 0;
    int noOfInvalidAppointment = 0;
    int noOfCanceledAppointment = 0;
    // int NoofRECInsertedAppt = 0;
    int SeqNum = 0;

    DataSet objDataset1 = new DataSet();
    string StartHours = string.Empty, StartMinutes = string.Empty, AppStartTime = string.Empty;
    string AppEndTime = string.Empty;
    Groomer objgroomer = new Groomer();
    int UserAppId = 0;
    #endregion

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

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    #endregion Page Load

    #region Mesages
    public void ErrMessage(string Message)
    {
        lblError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    public void SuccesfullMessage(string Message)
    {
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    #endregion Mesages

    #region Check Excel Data
    public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
    {
        Int32 result;
        return Int32.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
    }

    protected bool CheckZipCode(string code)
    {
        bool blnValidateNumeric = (isNumeric(code, System.Globalization.NumberStyles.Integer));
        return blnValidateNumeric;
    }
    protected bool IsValidRevAmt(string expRev)
    {
        // check all validations.
        bool IsValidRev = true;
        if (expRev == "" || expRev.Length > 8)
        {
            IsValidRev = false;
        }
        Regex regEx = new Regex("^\\d*(\\.\\d{1,4})?$");
        Match mtExpRev = Regex.Match(expRev, regEx.ToString());

        if (!(mtExpRev.Success))
        {
            IsValidRev = false;
        }
        return IsValidRev;
    }

    protected bool IsValidAppointment(string dtApptDate, string dtTime, string Others, string gname, string exppettime, int Seqno, string AptSTime, string ExpApptTime)
    {
        bool IsValidAppt = true;
        try
        {
            // check all validations.
            if (null == dtApptDate || dtApptDate == "" || dtTime == "" || Others == "" || gname == "" || exppettime == "" || exppettime == "0" || exppettime == "0.00" || Seqno == 0 || AptSTime == "" || ExpApptTime == "")
            {
                IsValidAppt = false;
            }
            // check for groomer exist in admin site.
            bool IsGroomerAvail = objgroomer.IsGroomerExists(gname);
            if (IsGroomerAvail.Equals(false))
            {
                IsValidAppt = false;
            }
            //--------------
            if (exppettime.Length > 12)
            {
                IsValidAppt = false;
            }

            Regex regEx = new Regex("^\\d*(\\.\\d{1,4})?$");

            Match mtExpPetTime = Regex.Match(exppettime, regEx.ToString());

            if (!(mtExpPetTime.Success))
            {
                IsValidAppt = false;
            }

            if (AptSTime != "")
            {
                string[] arrSTime = new string[3];
                if (AptSTime.Contains(" "))
                {
                    arrSTime = AptSTime.Split(' ');
                }
                string tt = "";
                string hour = "";
                if (arrSTime.Length > 0)
                {
                    string timepart = arrSTime[1].Trim().ToString();

                    if (timepart.Contains(":"))
                    {
                        string[] arrTPart = new string[3];
                        arrTPart = timepart.Split(':');
                        if (arrTPart.Length > 0)
                        {
                            if (!(null == arrTPart[0]))
                            {
                                hour = arrTPart[0].ToString();
                            }
                        }
                    }
                    
                    if (!(null == arrSTime[2]))
                    {
                        tt = arrSTime[2].Trim().ToString();
                    }
                }

                if (Convert.ToInt32(hour) >= 1 && Convert.ToInt32(hour) < 6 && tt.Equals("AM") || Convert.ToInt32(hour) == 12 && tt.Equals("AM"))
                {
                    IsValidAppt = false;
                }
            }
        }
        catch 
        {
            IsValidAppt = false;
        }
        return IsValidAppt;
    }


    protected bool CheckIsValidTimeSpanAppt(int gid, string Apptdate, string aptSTiming, string ExpEndTime)
    {
        bool IsValid = true;
        try
        {
            Groomer objgroomer = new Groomer();
            DataSet dsAppts = objgroomer.GetAppts(gid, Apptdate);
            if (dsAppts.Tables.Count > 0)
            {
                if (dsAppts.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drows in dsAppts.Tables[0].Rows)
                    {
                        string fromhh = "", fromm = "", tohh = "", tomm = "";

                        if (drows["FROMHOURS"].ToString() != "" && drows["FROMMINUTES"].ToString() != "" && drows["TOHOURS"].ToString() != "" && drows["TOMINUTES"].ToString() != "")
                        {
                            fromhh = drows["FROMHOURS"].ToString();
                            fromm = drows["FROMMINUTES"].ToString();
                            tohh = drows["TOHOURS"].ToString();
                            tomm = drows["TOMINUTES"].ToString();

                            string[] arrUploadSTime = new string[3];
                            if (aptSTiming.Contains(":"))
                            {
                                arrUploadSTime = aptSTiming.Split(':');
                            }
                            if (arrUploadSTime.Length > 0)
                            {
                                string hour = arrUploadSTime[0].ToString();
                                string min = arrUploadSTime[1].ToString();
                                string tt = "";
                                if (arrUploadSTime[2].ToString().Contains(" "))
                                {
                                    string[] arrtt = new string[2];
                                    arrtt = arrUploadSTime[2].ToString().Split(' ');
                                    tt = arrtt[1].ToString();
                                }
                                if (tt.Equals("PM"))
                                {
                                    if (Convert.ToInt32(hour) < 12)
                                    {
                                        hour = (12 + Convert.ToInt32(hour)).ToString();
                                    }
                                }
                                string endhours = "";
                                string endminutes = "";
                                if (ExpEndTime != "")
                                {
                                    string endtt = "";
                                    string[] arrUploadETime = new string[2];
                                    if (ExpEndTime.Contains(":") && ExpEndTime.Contains(" "))
                                    {
                                        arrUploadETime = ExpEndTime.Split(':');
                                        if (arrUploadETime.Length > 0)
                                        {
                                            endhours = arrUploadETime[0].ToString();
                                            string[] arrendtt = new string[2];
                                            arrendtt = arrUploadETime[1].ToString().Split(' ');
                                            endminutes = arrendtt[0].ToString();
                                            endtt = arrendtt[1].ToString();
                                        }
                                        if (endtt.Equals("PM"))
                                        {
                                            if (Convert.ToInt32(endhours) < 12)
                                            {
                                                endhours = (12 + Convert.ToInt32(endhours)).ToString();
                                            }
                                        }
                                    }
                                }
                                TimeSpan start = new TimeSpan(Convert.ToInt32(fromhh), Convert.ToInt32(fromm), 0);
                                TimeSpan end = new TimeSpan(Convert.ToInt32(tohh), Convert.ToInt32(tomm), 0);
                                TimeSpan newtime = new TimeSpan(Convert.ToInt32(hour), Convert.ToInt32(min), 0);
                                TimeSpan newEndtime = new TimeSpan(Convert.ToInt32(endhours), Convert.ToInt32(endminutes), 0);

                                // if ((newtime > start) && (newtime < end) || newEndtime > start && newEndtime <= end)
                                if ((newtime > start) && (newtime < end) || newEndtime > start && newEndtime < end)
                                {
                                    // IsValid = false;
                                    IsValid = true;
                                    SeqNum = Convert.ToInt32(drows["SequenceNo"].ToString()) + 1;
                                    break;
                                }
                                if (newtime == start)
                                {
                                    IsValid = true;
                                    SeqNum = Convert.ToInt32(drows["SequenceNo"].ToString()) + 1;
                                    // IsValid = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        catch 
        {
            IsValid = false;
        }
        return IsValid;
    }

    #endregion Check Excel Data

    #region MailSend
    protected void SendMailPrePaid(DataSet ds)
    {
        try
        {
            string Mailbody = ContentManager.GetStaticeContentEmail("PrePaymentAppointments.htm").Replace("~", "#");
            string strAppointment = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strAppointment += "<tr><td>" + (i + 1) + "</td>";
                strAppointment += "<td>" + ds.Tables[0].Rows[i]["AppointmentID"].ToString() + "</td>";
                strAppointment += "<td>" + ds.Tables[0].Rows[i]["FirstName"].ToString() + "</td>";
                strAppointment += "<td>" + ds.Tables[0].Rows[i]["Name"].ToString() + "</td>";
                strAppointment += "<td> $ " + ds.Tables[0].Rows[i]["ExpectedTotalRevenue"].ToString().Split('.').First() + "</td>";
                strAppointment += "<td>" + ds.Tables[0].Rows[i]["AppointmentDate"].ToString() + "</td>";
                strAppointment += "<td>" + ds.Tables[0].Rows[i]["Others"].ToString() + "</td></tr>";
            }
            Mailbody = Mailbody.Replace("<!--<tr></tr>-->", strAppointment);
            SendMail ObjMail = new SendMail();
            ObjMail.SendMailPrePaid(Mailbody);
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }
    }
    #endregion

    #region Button Submit
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (ApptFile.HasFile)
            {
                string fn = Path.GetFileName(ApptFile.PostedFile.FileName);
                string filepath = ApptFile.PostedFile.FileName;
                string p = ApptFile.FileName.ToString();
                string strFileType = Path.GetExtension(ApptFile.FileName).ToString().ToLower();
                #region checkFile
                if (ApptFile.PostedFile.FileName != "")
                {
                    #region Upload Files is  an excel File
                    if (strFileType == ".xls" || strFileType == ".xlsx")
                    {
                        #region  check for xls file
                        if (btnUpload.CausesValidation == true)
                        {
                            Cache.Remove("AppointToCompare");
                            ApptFile.Enabled = false;
                            btnUpload.Enabled = false;

                            #region Delete the previous appointments started from Last week w.r.t. current minute starting from today+ all Future Appointment and Preserve Prepaid Appointment.
                            DataSet dsAppointment = objgroomer.DeleteFutureAppointments();
                            Cache["AppointToCompare"] = dsAppointment;
                            lblError.Text = string.Empty;
                            #endregion Delete the previous appointments started from Last week w.r.t. current minute starting from today+ all Future Appointment and Preserve Prepaid Appointment.

                            #region Send Future Paid Appointment to Admin
                            if (dsAppointment.Tables[0].Rows.Count > 0)
                                SendMailPrePaid(dsAppointment);
                            #endregion

                            #region GetAppointment from ExcelSheet  To UpDate Wesite

                            string filename = Path.GetFileNameWithoutExtension(filepath);
                            string file_ext = Path.GetExtension(filepath);
                            string dtm = (Convert.ToDateTime(DateTime.Now.Date)).ToString("dd-MMM-yyyy") + " " + (DateTime.Now.ToLongTimeString()).ToString();
                            string filedatetime = dtm.Replace(":", "_");
                            string file = filename + filedatetime.ToString() + file_ext;
                            //save the file to the server 
                            ApptFile.PostedFile.SaveAs(Server.MapPath("AppointmentFiles/") + file);

                            String sConnectionString = "";
                            #region OLEDB Connection
                            if (strFileType.Trim() == ".xls")
                            {
                                sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= '" + Server.MapPath("AppointmentFiles/") + file + "' " + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                            }
                            else if (strFileType.Trim() == ".xlsx")
                            {
                                sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= '" + Server.MapPath("AppointmentFiles/") + file + "' " + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                            }

                            #endregion

                            #region Get Sheet Names form GroomerExcel

                            DataTable bindDT = new DataTable();
                            using (OleDbConnection objConn = new OleDbConnection(sConnectionString))
                            {
                                try
                                {
                                    objConn.Open();
                                    DataTable dt = objConn.GetSchema("Tables");
                                    bindDT = new DataTable();
                                    DataColumn dc = new DataColumn("Sheet Name");
                                    dc.ColumnName = "SheetName";
                                    bindDT.Columns.Add(dc);
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        DataRow drow = bindDT.NewRow();
                                        drow[dc] = dr["TABLE_NAME"].ToString();
                                        bindDT.Rows.Add(drow);
                                    }
                                }
                                catch 
                                {
                                    ErrMessage("Server Error");
                                    return;
                                }
                            }


                            string sheetName = string.Empty;
                            foreach (DataRow row1 in bindDT.Rows)
                            {
                                sheetName = row1[0].ToString();
                            }
                            #endregion

                            #region Get Records of first sheetNames form GroomerExcel
                            using (OleDbConnection objConn = new OleDbConnection(sConnectionString))
                            {
                                string select = string.Format("SELECT * FROM [{0}]", sheetName.Trim());
                                OleDbCommand objCmdSelect = new OleDbCommand(select, objConn);
                                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                                objAdapter1.SelectCommand = objCmdSelect;
                                objAdapter1.Fill(objDataset1, "XLData");
                                string ExpEndTimeStr = "";
                                int row = 0;
                                string NameofCustomer = string.Empty;
                                string Apptdate = string.Empty;
                                string custEmail = string.Empty;
                                string ApptStart_Time = string.Empty;
                                string ApptString = string.Empty;
                                string ExpApptTime = string.Empty;
                                string scheduledBy = string.Empty;
                                string Start_FullTimeMiLitary = string.Empty;
                                string End_FullTimeMiLitary = string.Empty;
                                string MiLitarySTET = string.Empty;
                                string gname = string.Empty, dtTime = string.Empty, StartTm = string.Empty, Start_EndTime = string.Empty;
                                decimal time = 0;
                                try
                                {
                                    for (row = 0; row < (objDataset1.Tables["XLData"].Rows.Count); row++)
                                    {
                                        string RowInitialValue = objDataset1.Tables["XLData"].Rows[row]["Cleared"].ToString();
                                        int gid = 0;
                                        #region Count Row And Insert 
                                        if (!(RowInitialValue).Equals(""))
                                        {
                                            #region RowInitialValue
                                            
                                            string dtPart2 = "";
                                            DateTime dateStartTimeSheet;
                                            try
                                            {
                                                Apptdate = objDataset1.Tables["XLData"].Rows[row]["Date"].ToString().Trim();
                                                if (DateTime.TryParseExact(objDataset1.Tables["XLData"].Rows[row]["Time"].ToString().Trim(), "yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateStartTimeSheet))
                                                    ApptStart_Time = dateStartTimeSheet.ToString();
                                                else
                                                    ApptStart_Time = Convert.ToDateTime(objDataset1.Tables["XLData"].Rows[row]["Date"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss tt");
                                                ApptStart_Time = objDataset1.Tables["XLData"].Rows[row]["Time"] != null ? Convert.ToDateTime(objDataset1.Tables["XLData"].Rows[row]["Time"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss tt") : null;
                                                ApptString = objDataset1.Tables["XLData"].Rows[row]["Regarding"].ToString().Trim() ?? string.Empty;
                                                ExpApptTime = objDataset1.Tables["XLData"].Rows[row]["Duration"].ToString().Trim();
                                                NameofCustomer = objDataset1.Tables["XLData"].Rows[row]["Scheduled With"].ToString().Trim();
                                                custEmail = objDataset1.Tables["XLData"].Rows[row]["Email Address"].ToString().Trim();
                                                scheduledBy = objDataset1.Tables["XLData"].Rows[row]["Scheduled By"].ToString().Trim();
                                                gname = objDataset1.Tables["XLData"].Rows[row]["Scheduled For"].ToString().Trim();

                                            }
                                            catch { }
                                            #endregion RowInitialValue

                                            #region first get groomer id by groomer name.
                                            DataSet ds = objgroomer.GetGroomername(gname);
                                            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                            {
                                                gid = Convert.ToInt32(ds.Tables[0].Rows[0]["GID"].ToString());

                                                DataSet dsseq = new DataSet();
                                                dsseq = objgroomer.GetMaxSequencenoOfGroomer(gid, Apptdate);
                                                SeqNum = 0;
                                                if (dsseq.Tables.Count > 0)
                                                    SeqNum = dsseq.Tables[0].Rows.Count > 0 ? Convert.ToInt32(dsseq.Tables[0].Rows[0]["sequence"].ToString()) : 1;
                                            }
                                            #endregion first get groomer id by groomer name.

                                            if (!ApptString.ToLower().StartsWith("cx") && gid>0)
                                            {
                                                //User App ID
                                                if (ApptString.Contains('!'))
                                                {
                                                    string[] getId = ApptString.Split('!');
                                                    string tempappid = getId[1]; //objDataset1.Tables["XLData"].Rows[row][13].ToString();
                                                    bool result = Int32.TryParse(tempappid, out UserAppId);
                                                    ///  UserAppId = Convert.ToInt32(tempappid);
                                                }
                                                string ZipCode, zip = "";
                                               

                                                #region ApptString Not Empty 
                                                if (ApptString != "")
                                                {
                                                    string[] arraptstr = new string[25];
                                                    arraptstr = ApptString.Split(',');
                                                    #region if AppString Has Some Text 
                                                    if (arraptstr.Length > 0)
                                                    {
                                                        for (int i = 0; i < arraptstr.Length; i++)
                                                        {

                                                            if (!(null == arraptstr[i]))
                                                            {
                                                                if (arraptstr[i].Trim().Length == 5 || arraptstr[i].Trim().Length == 6)
                                                                {
                                                                    string zcode = "";
                                                                    if (arraptstr[i].Trim().Length == 5)
                                                                    {
                                                                        //check for five digit integer value.
                                                                        zcode = arraptstr[i].Trim().ToString();
                                                                    }
                                                                    else
                                                                    {
                                                                        if (arraptstr[i].Trim().ToString().StartsWith("*"))
                                                                        {
                                                                            zcode = arraptstr[i].Trim().ToString().Substring(1, arraptstr[i].Trim().ToString().Length - 1);
                                                                        }
                                                                    }
                                                                    // check for valid zip code
                                                                    bool IsValidZip = CheckZipCode(zcode);

                                                                    if (IsValidZip.Equals(true))
                                                                    {
                                                                        zip = zcode;
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    #endregion if AppString Has Some Text 
                                                }
                                                #endregion ApptString Not Empty

                                                ZipCode = zip;
                                                bool IsValidApptDate = false;

                                                #region Apptdate Not Empty
                                                if (Apptdate != "")
                                                {
                                                    string AptDt = Apptdate;
                                                    if (Apptdate.Contains(' '))
                                                    {
                                                        string[] arraptdt = Apptdate.Split(' ');
                                                        AptDt = arraptdt[0].ToString();
                                                    }
                                                    Regex regexDt = new Regex("^(((0?[1-9]|1[012])/(0?[1-9]|1\\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\\d)\\d{2}|0?2/29/((19|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$");

                                                    AptDt = "";
                                                    Match mtApptDt = Regex.Match(AptDt, regexDt.ToString());
                                                    if (mtApptDt.Success) IsValidApptDate = true;
                                                    IsValidApptDate = true;
                                                }
                                                #endregion Apptdate Not Empty

                                                #region IsValidApptDate
                                                if (IsValidApptDate.Equals(true))
                                                {
                                                    string year = Convert.ToDateTime(Apptdate).ToString("yy");

                                                    string mon = Convert.ToDateTime(Apptdate).Month.ToString();
                                                    if (mon.Length == 1) mon = "0" + Convert.ToDateTime(Apptdate).Month.ToString();
                                                    string dd = Convert.ToDateTime(Apptdate).Day.ToString();
                                                    if (dd.Length == 1) dd = "0" + Convert.ToDateTime(Apptdate).Day.ToString();
                                                    string dtPart1 = year + mon + dd;
                                                    dtPart2 = dtPart1 + ".";
                                                }
                                                #endregion IsValidApptDate

                                                #region get start time.
                                                Start_FullTimeMiLitary = string.Empty;
                                                End_FullTimeMiLitary = string.Empty;
                                                string[] arraptStiming0 = null;
                                                if (ApptStart_Time != "")
                                                {
                                                    // Start Time Ex.- 12/30/1899 7:00:00 AM
                                                    string ActualAptSTime = "";
                                                    if (ApptStart_Time.Contains(" "))
                                                    {
                                                        arraptStiming0 = ApptStart_Time.Split(' ');
                                                        if (arraptStiming0.Length > 1) ActualAptSTime = arraptStiming0[1].ToString();
                                                    }
                                                    if (ActualAptSTime.Contains(":"))
                                                    {
                                                        string[] arraptStiming1 = ActualAptSTime.Split(':');
                                                        if (arraptStiming1.Length > 1 && !(null == arraptStiming1[1]))
                                                        {
                                                            try
                                                            {
                                                                #region Fromate AppointmentDate into Military Date Time Formate

                                                                StartTm = arraptStiming0[2].ToString();
                                                                string StartHoursString = arraptStiming1[0];
                                                                if (StartHoursString.Length == 1) StartHoursString = "0" + StartHoursString;

                                                                if (StartTm == "PM") StartHours += 12;
                                                                StartHours = StartHoursString.ToString();
                                                                string StartMinutesString = arraptStiming1[1];
                                                                if (StartMinutesString.Length == 1) StartMinutesString = "0" + StartMinutesString;
                                                                StartMinutes = StartMinutesString;
                                                                AppStartTime = StartHours + ":" + StartMinutes + " " + StartTm;
                                                                #endregion Fromate AppointmentDate into Military Date Time Formate
                                                            }
                                                            catch 
                                                            {

                                                            }
                                                            Start_FullTimeMiLitary = StartHours.ToString() + StartMinutes.ToString();
                                                        }

                                                        #region  get end time.
                                                        ExpEndTimeStr = "";
                                                        if (ExpApptTime != "")
                                                        {
                                                            #region Duration
                                                            if (ExpApptTime.Contains(' '))
                                                            {
                                                                string[] arrEndTimes = ExpApptTime.Split(' ');
                                                                int arrlen = arrEndTimes.Length;
                                                                int EndHours = 0, EndMinutes = 0;
                                                                if (arrlen <= 2)
                                                                {
                                                                    if (!(null == arrEndTimes[0]) && !(null == arrEndTimes[1]))
                                                                    {
                                                                        if (arrEndTimes[1].ToString().Equals("hour") || arrEndTimes[1].ToString().Equals("hours"))
                                                                        {
                                                                            EndHours = Convert.ToInt32(arrEndTimes[0].ToString());
                                                                        }
                                                                        else if (arrEndTimes[1].ToString().Equals("minute") || arrEndTimes[1].ToString().Equals("minutes"))
                                                                        {
                                                                            EndMinutes = Convert.ToInt32(arrEndTimes[0].ToString());
                                                                        }
                                                                    }
                                                                }
                                                                else if (!(null == arrEndTimes[2]) && arrlen == 4 && (arrEndTimes[1].ToString().Equals("hour") || arrEndTimes[1].ToString().Equals("hours")) && (arrEndTimes[3].ToString().Equals("minute") || arrEndTimes[3].ToString().Equals("minutes")))
                                                                {
                                                                    EndHours = Convert.ToInt32(arrEndTimes[0].ToString());
                                                                    EndMinutes = Convert.ToInt32(arrEndTimes[2].ToString());
                                                                }
                                                                TimeSpan Stime = new TimeSpan(Convert.ToInt16(StartHours), Convert.ToInt16(StartMinutes), 0);
                                                                TimeSpan Etime = new TimeSpan(EndHours, EndMinutes, 0);
                                                                TimeSpan CalcTime = Stime + Etime;
                                                                time = 0;
                                                                time = Math.Round(Convert.ToDecimal(new TimeSpan(EndHours, EndMinutes, 0).TotalHours), 2);

                                                                string EndMin = CalcTime.Minutes.ToString();

                                                                if (EndMin.Equals("0")) EndMin = "00";
                                                                string EndHoursStr = CalcTime.Hours.ToString();
                                                                string tt = "AM";

                                                                if (CalcTime.Hours >= 12)
                                                                {
                                                                    string time_str = CalcTime.Hours + ":00:00";
                                                                    TimeSpan time_span = TimeSpan.Parse(time_str);
                                                                    DateTime d = new DateTime(time_span.Ticks);
                                                                    string tm = d.ToString("HH");
                                                                    EndHoursStr = tm;
                                                                    tt = "PM";
                                                                }
                                                                string CalcTimeMinutesString = CalcTime.Minutes.ToString().Length == 1 ? "0" + CalcTime.Minutes.ToString() : CalcTime.Minutes.ToString();
                                                                ExpEndTimeStr = EndHoursStr + ":" + CalcTimeMinutesString + " " + tt;
                                                                string EndMinString = EndMin.ToString().Length == 1 ? "0" + EndMin.ToString() : EndMin.ToString();
                                                                string EndHoursStrString = EndHoursStr.Length == 1 ? "0" + EndHoursStr.ToString() : EndHoursStr.ToString();
                                                                Start_EndTime = EndHoursStrString + ":" + EndMinString + " " + tt;
                                                                End_FullTimeMiLitary = EndHoursStrString + EndMinString;

                                                                AppEndTime = Start_EndTime;

                                                                string newApptdate = Convert.ToDateTime(Apptdate).ToString("MM/dd/yyyy");
                                                                newApptdate += " " + AppStartTime;
                                                                Apptdate = newApptdate.ToString();
                                                            }

                                                            #endregion Duration
                                                        }
                                                        #endregion  get end time.
                                                    }
                                                }
                                                #endregion get start time.

                                                #region ApptString Contains("$")
                                                string ExpRevAmount = "";
                                                if (ApptString.Contains("$"))
                                                {
                                                    string[] apptstr = ApptString.Split(',');

                                                    if (apptstr.Length > 0)
                                                    {
                                                        for (int i = 0; i < apptstr.Length; i++)
                                                        {
                                                            if (!(null == apptstr[i]) && apptstr[i].ToString().Trim().StartsWith("$"))
                                                            {
                                                                ExpRevAmount = apptstr[i].ToString().Trim().Substring(1).ToString();
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                                #endregion ApptString Contains("$")

                                                #region Actual Military Time After Formated
                                                MiLitarySTET = Start_FullTimeMiLitary + "-" + End_FullTimeMiLitary;
                                                dtTime = dtPart2 + Start_FullTimeMiLitary + "-" + End_FullTimeMiLitary;
                                                #endregion Actual Military Time After Formated

                                                string ExpectedPetTime = time.ToString();

                                                bool IsValidAppt = IsValidAppointment(Apptdate, dtTime, ApptString, gname, ExpectedPetTime, SeqNum, ApptStart_Time, ExpApptTime);

                                                bool IsValidApptRevenue = IsValidRevAmt(ExpRevAmount);
                                                if (IsValidApptRevenue.Equals(false)) ExpRevAmount = "0";

                                                #region Insert the Appointment details in db.

                                                // Check Is Valid appointment and make sure no same appointment alredy present in exsting system.
                                                bool IsValidApptment = true;
                                                DataSet dsapP = objgroomer.CheckApptExists(gid, Apptdate, dtTime);
                                                if (dsapP.Tables.Count > 0 && dsapP.Tables[0].Rows.Count > 0)
                                                {
                                                    SeqNum = Convert.ToInt32(dsapP.Tables[0].Rows[0]["SequenceNo"].ToString()) + 1;
                                                    IsValidApptment = true;
                                                }

                                                // Check Is Valid appointment and make sure no same appointment present(i.e. for within same time span.)
                                                string aptSTiming = "";
                                                try
                                                {
                                                    if (arraptStiming0.Length >= 3)
                                                        aptSTiming = arraptStiming0[1].ToString() + " " + arraptStiming0[2].ToString();
                                                }
                                                catch
                                                {

                                                }
                                                if (IsValidApptment.Equals(true))
                                                    IsValidApptment = CheckIsValidTimeSpanAppt(gid, Apptdate, aptSTiming, ExpEndTimeStr);

                                                #region  IsValidApptment.
                                                if (IsValidApptment.Equals(true))
                                                {
                                                    #region True
                                                    int ApptID = objgroomer.InsertGroomerAppointment(gid, Apptdate, "", "", ExpRevAmount, ApptString, dtTime, SeqNum, Convert.ToDecimal(ExpectedPetTime), ZipCode, aptSTiming, NameofCustomer, custEmail, ExpEndTimeStr, UserAppId);
                                                    if (ApptID > 0)
                                                    {
                                                        NoofInsertedAppt++;

                                                        #region Create recurring appointments.

                                                        if (ApptString.ToLower().Contains("rec"))
                                                        {
                                                            #region Get Rec Number
                                                            string AppointmentsSpan = "";
                                                            string[] apptstr = ApptString.Split(',');
                                                            if (apptstr.Length > 0)
                                                            {
                                                                for (int i = 0; i < apptstr.Length; i++)
                                                                {
                                                                    if (!(null == apptstr[i]) && apptstr[i].ToString().ToLower().Trim().StartsWith("rec") && apptstr[i].ToString().Trim().Length <= 5)
                                                                    {
                                                                        AppointmentsSpan = apptstr[i].ToString().Trim().Substring(3).ToString();
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                            #endregion Get Rec Number

                                                            #region  appointmentsSlot and Rec Appointment Insert.
                                                            List<DateTime> dts = new List<DateTime>();
                                                            if (AppointmentsSpan != "")
                                                            {
                                                                int i = Convert.ToInt16(AppointmentsSpan);
                                                                DateTime dtPresent = Convert.ToDateTime(Apptdate);

                                                                #region Rec validation
                                                                DateTime dtFutureSixMonthDay = dtPresent.AddMonths(6);
                                                                for (DateTime dtPresent1 = dtPresent.AddDays(i * 7); dtPresent1.Date <= dtFutureSixMonthDay; dtPresent1 = dtPresent1.AddDays(i * 7))
                                                                {
                                                                    DataSet dsseqNo = objgroomer.GetMaxSequencenoOfGroomer(gid, dtPresent1.ToString());
                                                                    int SeqNumber = 0;
                                                                    if (dsseqNo.Tables.Count > 0)
                                                                    {
                                                                        if (dsseqNo.Tables[0].Rows.Count > 0)
                                                                            SeqNumber = Convert.ToInt32(dsseqNo.Tables[0].Rows[0]["sequence"].ToString());
                                                                        else SeqNumber = 1;
                                                                    }

                                                                    dsapP = objgroomer.CheckApptExists(gid, Apptdate, dtTime);
                                                                    if (dsapP.Tables.Count > 0 && dsapP.Tables[0].Rows.Count > 0)
                                                                    {
                                                                        SeqNum = Convert.ToInt32(dsapP.Tables[0].Rows[0]["SequenceNo"].ToString()) + 1;
                                                                        IsValidApptment = true;
                                                                    }
                                                                    //Check Is Valid appointment and make sure no same appointment present(i.e. for within same time span.)
                                                                    if (IsValidApptment.Equals(true))
                                                                        IsValidApptment = CheckIsValidTimeSpanAppt(gid, dtPresent1.ToString(), aptSTiming, ExpEndTimeStr);
                                                                    if (IsValidApptment.Equals(true))
                                                                    {
                                                                        try
                                                                        {
                                                                            #region Rec Appointment Save to Members Profile
                                                                            objgroomer.MakeRecConfirmAppointmentByGroomerForSheet(ApptID, dtPresent1, custEmail, dtPresent1.Date.ToString("yyMMdd") + "." + MiLitarySTET);
                                                                            NoofInsertedAppt++;
                                                                            //NoofRECInsertedAppt++;
                                                                            #endregion Rec Appointment Save to Members Profile
                                                                        }
                                                                        catch 
                                                                        {

                                                                        }
                                                                    }
                                                                }
                                                                #endregion
                                                            }

                                                            #endregion  appointmentsSlot and Rec Appointment Insert.

                                                        }
                                                        #endregion Create recurring appointments.
                                                    }
                                                    #endregion

                                                }
                                                else
                                                {
                                                    ////Not A valid appointment
                                                    noOfInvalidAppointment++;
                                                }
                                                #endregion  IsValidApptment.
                                                //}

                                                #endregion Insert the Appointment details in db.
                                            }
                                            else
                                            {
                                                //count canceled appointment
                                                noOfCanceledAppointment++;
                                            }
                                        }
                                        #endregion Count Row And Insert 
                                    }
                                }
                                catch 
                                {
                                    //Response.Write(row + y.Message);
                                }
                            }
                            #endregion

                            #endregion

                            ApptFile.Enabled = true;
                            btnUpload.Enabled = true;
                            //Bind Grid
                            BindData();
                            SuccesfullMessage(NoofInsertedAppt.ToString() + " Groomer Appointment(s) created Successfully.");
                        }
                        #endregion  
                    }
                    #endregion 
                    else ErrMessage("Only excel files allowed.");
                }
                #endregion 
            }
            else ErrMessage("Please Select file to upload the appointments.");
        }
        catch 
        {
            ErrMessage("Error occured while uploading the appointments data.Please Try again");
        }
    }
    #endregion

    #region Rec Appoinment
    //protected void MakeRecConfirmAppointment(int GAppId, string AppString)
    //{
    //    List<DateTime> dtToSetRecAppointment = new List<DateTime>();
    //    try
    //    {
    //        if (!(string.IsNullOrEmpty(AppString)))
    //        {
    //            string AppointmentsSpan = "";
    //            string[] apptstr = ApptString.Split(',');
    //            if (apptstr.Length > 0)
    //            {
    //                #region Get Rec Number Irespective Of Position 
    //                for (int i = 0; i < apptstr.Length; i++)
    //                {
    //                    if (!(null == apptstr[i]))
    //                    {
    //                        if (apptstr[i].ToLower().ToString().Trim().StartsWith("rec") && apptstr[i].ToString().Trim().Length <= 5)
    //                        {
    //                            AppointmentsSpan = apptstr[i].ToString().Trim().Substring(3).ToString();
    //                            break;
    //                        }
    //                    }
    //                }
    //                #endregion Get Rec Number Irespective Of Position 
    //            }

    //            int number = AppointmentsSpan != "" ? Convert.ToInt32(AppointmentsSpan) : 0;
    //            if (number > 0)
    //            {
    //                dtToSetRecAppointment = SetAppointmentAfterWeekRecurrence(number, Convert.ToDateTime(Apptdate.ToString()));
    //            }
    //            #region Insert/Update Rec Appointment in Appointment Table to view Member
    //            Groomer objGroomer = new Groomer();
    //            if (dtToSetRecAppointment.Count > 0)
    //            {
    //                objGroomer.MakeRecConfirmAppointmentByGroomer(GAppId, dtToSetRecAppointment, custEmail);
    //                NoofRECInsertedAppt += dtToSetRecAppointment.Count;
    //            }
    //            #endregion Insert/Update Rec Appointment in Appointment Table to view Member
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

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

    #region Release Object
    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception ex)
        {
            obj = null;
            Response.Write("Unable to release the Object " + ex.ToString());
        }
        finally
        {
            GC.Collect();
            //GC.SuppressFinalize(obj);
        }
    }
    #endregion Release Object

    #region GridEvent

    /* Code to manage view state for sortExpression */
    private string SortExpression
    {
        get
        {
            if (ViewState["SortExpression"] != null)
                return (string)ViewState["SortExpression"];
            else
                return string.Empty;
        }
        set
        {
            if (ViewState["SortExpression"] == null)
                ViewState.Add("SortExpression", value);
            else
                ViewState["SortExpression"] = value;
        }
    }
    /* Code to manage view state for sortdirection*/
    private string SortDirection
    {
        get
        {
            if (ViewState["SortDirection"] != null)
                return (string)ViewState["SortDirection"];
            else
                return "ASC";
        }
        set
        {
            if (ViewState["SortDirection"] == null)
                ViewState.Add("SortDirection", value);
            else
                ViewState["SortDirection"] = value;
        }
    }
    //Event use for pagination
    protected void grdAppointment_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = grdAppointment.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(grdAppointment.PageIndex + 1);
        int[] page = new int[7];
        page[0] = grdAppointment.PageIndex - 2;
        page[1] = grdAppointment.PageIndex - 1;
        page[2] = grdAppointment.PageIndex;
        page[3] = grdAppointment.PageIndex + 1;
        page[4] = grdAppointment.PageIndex + 2;
        page[5] = grdAppointment.PageIndex + 3;
        page[6] = grdAppointment.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > grdAppointment.PageCount)
                {
                    LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                    lb.Visible = false;
                }
                else
                {
                    LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                    lb.Text = Convert.ToString(page[i]);

                    lb.CommandName = "PageNo";
                    lb.CommandArgument = lb.Text;
                }
            }
        }
        if (grdAppointment.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;
        }
        if (grdAppointment.PageIndex == grdAppointment.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;
        }
        if (grdAppointment.PageIndex > grdAppointment.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (grdAppointment.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    protected void grdAppointment_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewRow gvr = e.Row;
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p0");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p1");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p2");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p4");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p5");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p6");
            lb.Command += new CommandEventHandler(lb_Command);
        }
    }

    void lb_Command(object sender, CommandEventArgs e)
    {
        grdAppointment.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        BindData();
    }

    protected void grdAppointment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAppointment.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void grdAppointment_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (SortExpression != e.SortExpression)
        {
            SortExpression = e.SortExpression;
            SortDirection = "ASC";
        }
        else
        {
            if (SortDirection == "ASC")
            {
                SortDirection = "DESC";
            }
            else
            {
                SortDirection = "ASC";
            }
        }
        grdAppointment.PageIndex = 0;
        BindData();
    }

    #endregion

    #region Bind grid using cache
    private void BindData()
    {
        if (Cache["AppointToCompare"] != null)
        {
            DataTable dt = new DataTable();
            DataView dv = new DataView();
            DataSet ds = (DataSet)Cache["AppointToCompare"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                pnlMatch.Visible = true;
                lblMessage.Visible = true;
                dt = ds.Tables[0];
                dv = dt.DefaultView;
                if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                    dv.Sort = SortExpression + " " + SortDirection;
                grdAppointment.DataSource = dv;
                grdAppointment.DataBind();
                lblError.Visible = false;
                Utility.Setserial(grdAppointment, "srno");
            }
            else
            {
                pnlMatch.Visible = false;
                lblMessage.Visible = false;
                ErrMessage("No Appointments record found.");
            }
        }
    }
    #endregion

}
