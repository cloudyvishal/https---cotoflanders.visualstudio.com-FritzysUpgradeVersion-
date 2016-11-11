using System;
using HicPicDataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace advancewebtosolution.BO
{
    public class Groomer
    {
        public Groomer()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Umesh Code
        #region CheckEmailExists
        public DataSet GetUserInfoUsingEmail(string usermail)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GetUserInformation", new SqlParameter[] {
            new SqlParameter("@UserName", usermail)
        });
            DB.Dispose();
            return ds;
        }

        #endregion CheckEmailExists
        #region BindUserAppointmentForPaymentMobile
        public DataSet BindUserAppointmentForPayment(int userid, string usermail)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_BindUserAppointmentForPayment", new SqlParameter[] { new SqlParameter("@userId", userid), new SqlParameter("@usermail", usermail) });
            DB.Dispose();
            return ds;
        }
        #endregion BindUserAppointmentForPaymentMobile
        #endregion Umesh Code

        #region MakeRecConfirmAppointment Use for Manage Appointment on admin And Also View Groomer Appointment (Edit)
        #region Admin REC Confirm
        public void MakeRecConfirmAppointment(int AppointmentId, int GroomerAppointmentId, DateTime dt, string userEmail, string MilitaryDateTime)
        {
            #region Insert/Update Rec Appointment in Appointment Table to view Member
            try
            {
                DBConnection DB = new DBConnection();
                DB.ExecuteDataSet("sp_InsertUpdateRecAppointmentToMember", new SqlParameter[] {
                    new SqlParameter("@AppointmentId", AppointmentId),
                    new SqlParameter("@GroomerAppointmentId", GroomerAppointmentId),
                        new SqlParameter("@dt", dt),
                    new SqlParameter("@userEmail", userEmail),
                    new SqlParameter("@MilitaryDateTime", MilitaryDateTime)
                });
                DB.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion Insert/Update Rec Appointment in Appointment Table to view Member
        }
        #endregion  Admin REC Confirm

        #endregion MakeRecConfirmAppointment Use for Manage Appointment on admin And Also View Groomer Appointment (Edit)

        #region Used To Delete All previous  Appoinments from Appointments And GroomerAppointments(make Both Tanbles Empty) and Preserve Prepaid Appointment
        public DataSet DeleteFutureAppointments()
        {
            try
            {
                DataSet ds = new DataSet();
                DBConnection DB = new DBConnection();
                ds = DB.ExecuteDataSet("DeleteFutureAppointments", new SqlParameter[] { });
                DB.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Used To Delete All previous  Appoinments from Appointments And GroomerAppointments(make Both Tanbles Empty) and Preserve Prepaid Appointment

        #region MakeRecConfirmAppointment Use for Manage Appointment on admin
        public void MakeRecConfirmAppointmentByGroomer(int GroomerAppointmentId, DateTime dt, string userEmail, string MilitaryDateTime)
        {
            #region Insert/Update Rec Appointment in Appointment Table to view Member
            try
            {
                DBConnection DB = new DBConnection();
                DB.ExecuteDataSet("sp_InsertUpdateRecAppointmentToMemberByGroomer", new SqlParameter[] {
                    new SqlParameter("@GroomerAppointmentId", GroomerAppointmentId),
                        new SqlParameter("@dt", dt),
                    new SqlParameter("@userEmail", userEmail),
                    new SqlParameter("@MilitaryDateTime", MilitaryDateTime)
                });
                DB.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion Insert/Update Rec Appointment in Appointment Table to view Member
        }
        public void MakeRecConfirmAppointmentByGroomerForSheet(int GroomerAppointmentId, DateTime dt, string userEmail, string MilitaryDateTime)
        {
            #region Insert/Update Rec Appointment in Appointment Table to view Member
            try
            {
                DBConnection DB = new DBConnection();
                DB.ExecuteDataSet("sp_InsertUpdateRecAppointmentToMemberByGroomer", new SqlParameter[] {
                    new SqlParameter("@GroomerAppointmentId", GroomerAppointmentId),
                        new SqlParameter("@dt", dt),
                    new SqlParameter("@userEmail", userEmail),
                    new SqlParameter("@MilitaryDateTime",MilitaryDateTime)
                });
                DB.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion Insert/Update Rec Appointment in Appointment Table to view Member
        }
        #endregion MakeRecConfirmAppointment Use for Manage Appointment on admin

        public DataSet GetAllGroomers(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllGroomers", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }
        public DataSet BindInsertUpdateAdminRevenue(int appId)
        {
            DBConnection db = new DBConnection();
            DataSet ds = new DataSet();
            ds = db.ExecuteDataSet("getInsertUpdateAdminRevenue", new SqlParameter[] { new SqlParameter("@appId", appId) });
            db.Dispose();
            return ds;
        }

        public DataSet DeleteGroomer(string GID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteGroomer", new SqlParameter[] { new SqlParameter("@GID", GID) });
            DB.Dispose();
            return ds;
        }
        public int AddGroomer(string UserName, string Password, string Name, string Address, string HomePhone, string PersonalCellPhone, string ZipCode, string SheetName, string BaseCity, string State, string GTimeZone)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddGroomer", new SqlParameter[] { new SqlParameter("@UserName", UserName), new SqlParameter("@Password", Password),
                           new SqlParameter("@Name", Name),
                           new SqlParameter("@Address", Address),
                           new SqlParameter("@HomePhone", HomePhone),
                           new SqlParameter("@PersonalCellPhone", PersonalCellPhone),
                           new SqlParameter("@ZipCode", ZipCode),
                           new SqlParameter("@SheetName", SheetName),
                           new SqlParameter("@BaseCity",BaseCity),
                           new SqlParameter("@State",State),
                           new SqlParameter("@GTimeZone",GTimeZone),
        new SqlParameter("@GID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "GID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@GID"]).Value.ToString());
            return Count;
        }
        public DataSet GetGroomer(int GID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomer", new SqlParameter[] { new SqlParameter("@GID", GID) });
            DB.Dispose();
            return ds;
        }

        #region Get Top 1 Groomer Name
        public DataSet GetGroomername(string groomer)
        {
            DataSet dsGroomer = new DataSet();
            try
            {
                DBConnection DB = new DBConnection();
                dsGroomer = DB.ExecuteDataSet("GetGroomerIDbyname", new SqlParameter[] { new SqlParameter("@Groomername", groomer) });
                DB.Dispose();
                return dsGroomer;
            }
            catch
            {
            }
            return dsGroomer;
        }
        #endregion

        public DataSet CheckApptExists(int GID, string aptdate, string aptdatetime)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("IsApptExists", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@Date", aptdate), new SqlParameter("@DateTime", aptdatetime) });
            DB.Dispose();
            return ds;
        }

        // March2014
        //Jan 2016 By Umesh Insert to Appointment table first and then Groomer Appointment

        #region Bind Appointment and Groomer Appointment From Admin Sheet By Umesh Jan 2016
        public int InsertGroomerAppointment(int GID, string AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, int SequenceNo, decimal ExpPetTime, string ZipCode, string ApptStart_Time, string NameofCustomer, string custEmail, string ExpEndTime, int UserAppID)
        {
            try
            {
                DBConnection DB = new DBConnection();
                DB.ExecuteNonQuery("InsertGroomerAppointment", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@AppointmentDate", AppointmentDate),
                           new SqlParameter("@StartTime", StartTime),
                           new SqlParameter("@EndTime", EndTime),
                           new SqlParameter("@ExpectedTotalRevenue", ExpectedTotalRevenue),
                           new SqlParameter("@Others", Others),
                           new SqlParameter("@DateTimeFormat", DateTimeFormat),
                           new SqlParameter("@SequenceNo", SequenceNo),
                           new SqlParameter("@ExpPetTime",ExpPetTime),
                           new SqlParameter("@ExpStartTime",ApptStart_Time),
                           new SqlParameter("@CustomerName",NameofCustomer),
                           new SqlParameter("@custEmail",custEmail),
                           new SqlParameter("@Zipcode",ZipCode),
                           new SqlParameter("@ExpEndTime",ExpEndTime),
                           new SqlParameter("@UserAppID",UserAppID),
        new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
                DB.Dispose();
                int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
                return Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Bind Appointment and Groomer Appointment From Admin Sheet By Umesh Jan 2016

        #region match prepayappid
        public DataSet MatchPrepayAppID()
        {
            DBConnection DB = new DBConnection();
            DataSet dsAppts = new DataSet();
            dsAppts = DB.ExecuteDataSet("GetAllPrepayAppIDforUploadMatch", new SqlParameter[] { });
            DB.Dispose();
            return dsAppts;
        }
        #endregion match prepayappid

        #region Method Call In Uploading Grmmer Sheet
        public DataSet GetAppts(int GID, string Apptdate)
        {
            DBConnection DB = new DBConnection();
            DataSet dsAppts = new DataSet();
            dsAppts = DB.ExecuteDataSet("GetgroomerdatewiseAppts", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@ApptDate", Convert.ToDateTime(Apptdate)) });
            DB.Dispose();
            return dsAppts;
        }
        #endregion Method Call In Uploading Grmmer Sheet

        public bool IsGroomerExists(string groomer)
        {
            DataSet dsGroomer = new DataSet();
            bool isAvail = false;
            try
            {
                DBConnection DB = new DBConnection();
                dsGroomer = DB.ExecuteDataSet("GetGroomerbyname", new SqlParameter[] { new SqlParameter("@Groomername", groomer) });
                DB.Dispose();
                if (dsGroomer.Tables.Count > 0)
                {
                    if (dsGroomer.Tables[0].Rows.Count > 0)
                    {
                        if (!(dsGroomer.Tables[0].Rows[0]["NAME"].ToString().Equals("")))
                        {
                            isAvail = true;
                        }
                    }
                }
            }
            catch
            {
            }
            return isAvail;
        }

        public int UpdateGroomer(int GID, string UserName, string Name, string Address, string HomePhone, string PersonalCellPhone, string ZipCode, string BaseCity, string State, string SheetName, string GTimeZone)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateGroomer", new SqlParameter[] {new SqlParameter("@GID", GID), new SqlParameter("@UserName", UserName),
                           new SqlParameter("@Name", Name),
                           new SqlParameter("@Address", Address),
                           new SqlParameter("@HomePhone", HomePhone),
                           new SqlParameter("@PersonalCellPhone", PersonalCellPhone),
                           new SqlParameter("@ZipCode", ZipCode),
                           new SqlParameter("@BaseCity",BaseCity),
                           new SqlParameter("@State",State),
                           new SqlParameter("@SheetName",SheetName),
                           new SqlParameter("@GTimeZone",GTimeZone),
        new SqlParameter("@Return", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Return", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Return"]).Value.ToString());
            return Count;
        }
        public DataSet GetGroomersAppointment(DateTime AppointmentDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomersAppointment", new SqlParameter[] { new SqlParameter("@AppointmentDate", AppointmentDate) });
            DB.Dispose();
            return ds;
        }
        #region To Get App List Binding On Groomer Under Admin Panel
        public DataSet GetGroomersTodaysAppointment()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GetGroomersTodayAppointment", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        #endregion To Get App List Binding On Groomer Under Admin Panel
        public DataSet GetGroomersTodaysAppointmentByDate(DateTime dt)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GetGroomersAppointmentByDate", new SqlParameter[] { new SqlParameter("@AppointmentDate", dt.ToString("MM'/'dd'/'yy")) });
            DB.Dispose();
            return ds;
        }
        #region  "call by mobileapp and desktop  to bind uncomplete app +Rec Appointment"
        public DataSet GetFutureAppointment(int userid, string usermail)
        {
            DataSet ds = new DataSet();
            try
            {
                DBConnection DB = new DBConnection();

                ds = DB.ExecuteDataSet("GetAllUserFutureApp", new SqlParameter[] { new SqlParameter("@userId", userid), new SqlParameter("@usermail", usermail) });
                DB.Dispose();
            }
            catch { }
            return ds;
        }
        #region Get Past Appointments TO Bind On Member Account
        public DataSet GetPastAppointment(int userid, string usermail)
        {
            DataSet ds = new DataSet();
            try
            {
                DBConnection DB = new DBConnection();
                ds = DB.ExecuteDataSet("GetPastAppointments", new SqlParameter[] {
            new SqlParameter("@custEmail", usermail),
            new SqlParameter("@custId", userid)
               });
                DB.Dispose();
            }
            catch { }
            return ds;
        }
        #endregion Get Past Appointments TO Bind On Member Account
        #endregion

        #region Method to bind Future appointment on Payment Page
        public DataSet GetPaymentFutureAppointment(int userid, string usermail)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_BindUserAppointmentForPayment", new SqlParameter[] { new SqlParameter("@userId", userid), new SqlParameter("@usermail", usermail) });
            DB.Dispose();
            return ds;
        }
        #endregion
        public DataSet GetCustAppointmentbyID(int appid)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetCustAppointmentbyId", new SqlParameter[] { new SqlParameter("@appId", appid) });
            DB.Dispose();
            return ds;
        }

        #region  Function to bind on desktop to get All User Scheduled Id from Groomer Appointment 
        public DataSet GetFutureAppointmentID()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllUserFutureAppID", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        #endregion

        #region Function to bind on desktop to get All Payment AppointmentId from PrePayment using Groomer Appointment 
        public DataSet GetAllPreAppointmentID()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllPrepayAppID", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        #endregion

        public int AddGroomerAppointment(int GID, DateTime AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, int SequenceNo, decimal ExpPetTime, string custname,
            string custemail, string expectStartTime, int UserAppID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddGroomerAppointment", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@AppointmentDate", AppointmentDate),
                           new SqlParameter("@StartTime", StartTime),
                           new SqlParameter("@EndTime", EndTime),
                           new SqlParameter("@ExpectedTotalRevenue", ExpectedTotalRevenue),
                           new SqlParameter("@Others", Others),
                           new SqlParameter("@DateTimeFormat", DateTimeFormat),
                           new SqlParameter("@SequenceNo", SequenceNo),
                           new SqlParameter("@ExpPetTime",ExpPetTime),
                           new SqlParameter("@CustomerName",custname),
                            new SqlParameter("@custEmail",custemail),
                              new SqlParameter("@ExpStartTime",expectStartTime),
                              new SqlParameter("@UserAppID",UserAppID),
        new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
            return Count;
        }
        #region This function is used for adding appointment to reflect to three pannel (User,Admin,Groomer)
        public int AddGroomerAppointmentByAdmin(int GID, DateTime AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, int SequenceNo, decimal ExpPetTime,
            string custname, string custemail, string expectStartTime, string expectendTime)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("sp_AddGroomerAppointmentByAdmin", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@AppointmentDate", AppointmentDate),
                           new SqlParameter("@StartTime", StartTime),
                           new SqlParameter("@EndTime", EndTime),
                           new SqlParameter("@ExpectedTotalRevenue", ExpectedTotalRevenue),
                           new SqlParameter("@Others", Others),
                           new SqlParameter("@DateTimeFormat", DateTimeFormat),
                           new SqlParameter("@SequenceNo", SequenceNo),
                           new SqlParameter("@ExpPetTime",ExpPetTime),
                           new SqlParameter("@CustomerName",custname),
                           new SqlParameter("@custEmail",custemail),
                           new SqlParameter("@ExpStartTime",expectStartTime),
                           new SqlParameter("@ExpEndTime",expectendTime),
        new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
            return Count;
        }
        #endregion This function is used for adding appointment to reflect to three pannel (User,Admin,Groomer)

        #region  update GroomerAppointmentByAdmin return GAppId
        public int UpdateGroomerAppointmentByAdmin(int AppointmentId, int GID, DateTime AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, int SequenceNo, decimal ExpPetTime, string custname, string custemail, string expectStartTime,string ExpEndTime)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("sp_UpdateGroomerAppointmentByAdmin",
                new SqlParameter[] { new SqlParameter("@AppointmentID",AppointmentId),
                new SqlParameter("@GID", GID), new SqlParameter("@AppointmentDate", AppointmentDate),
                           new SqlParameter("@StartTime", StartTime),
                           new SqlParameter("@EndTime", EndTime),
                           new SqlParameter("@ExpectedTotalRevenue", ExpectedTotalRevenue),
                           new SqlParameter("@Others", Others),
                           new SqlParameter("@DateTimeFormat", DateTimeFormat),
                           new SqlParameter("@SequenceNo", SequenceNo),
                           new SqlParameter("@ExpPetTime",ExpPetTime),
                           new SqlParameter("@CustomerName",custname),
                           new SqlParameter("@custEmail",custemail),
                           new SqlParameter("@ExpStartTime",expectStartTime),
                           new SqlParameter("@ExpEndTime",ExpEndTime),
        new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
            return Count;
        }
        #endregion  update GroomerAppointmentByAdmin return GAppId

        #region Admin COnfirm Code
        public int ConfirmAppointment(int GAppointmentId, int GID, DateTime AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, int SequenceNo, decimal ExpPetTime, string custname, string custemail, string ExpStartTime, string ExpEndTime, int UserAppID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("ConfirmAppointment",
                           new SqlParameter[] {
                           new SqlParameter("@GAppointmentId",GAppointmentId),
                           new SqlParameter("@GID", GID),
                           new SqlParameter("@AppointmentDate", AppointmentDate),
                           new SqlParameter("@StartTime", StartTime),
                           new SqlParameter("@EndTime", EndTime),
                           new SqlParameter("@ExpectedTotalRevenue", ExpectedTotalRevenue),
                           new SqlParameter("@Others", Others),
                           new SqlParameter("@DateTimeFormat", DateTimeFormat),
                           new SqlParameter("@SequenceNo", SequenceNo),
                           new SqlParameter("@ExpPetTime",ExpPetTime),
                           new SqlParameter("@CustomerName",custname),
                           new SqlParameter("@custEmail",custemail),
                           new SqlParameter("@ExpStartTime",ExpStartTime),
                           new SqlParameter("@ExpEndTime",ExpEndTime),
                           new SqlParameter("@UserAppID",UserAppID),
        new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
            return Count;
        }
        #endregion Admin COnfirm Code

        public DataSet GetGroomerDailyLogData(int GID, string Date)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomerDailyLogData", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@Date", Date) });
            DB.Dispose();
            return ds;
        }
        public int UpdateGroomerDailyOperationsLog(int GId, string VanId, int BeginningMileage, string TotlaHours, int EndingMileage, double FuelPurchased,
        double PricePerGallon, string CustomerName, string Job, string ZipCode, int Pets, int Rebook, int FromRebook, int New, string TimeIn, string TimeOut,
        string PetTime, string ExtraServices, int FleaandTick22, int FleaandTick44, int FleaandTick88, int FleaandTick132, int FleaandTickCat,
        int TB, int Wham, double RevenueCreditCard, double RevenueCheck, double RevenueCash, double RevenueInvoice, double TipCreditCard, double TipCheck,
        double TipCash, double TipInvoice, double PriorCreditCard, double PriorCheck, double PriorCash, DateTime NextAppointmentDate, string NextAppointmentTime,
        string ServicesForPet1, string ServicesForPet2, string ServicesForPet3, string ServicesForPet4, string ServicesForPet5, string ServicesForPet6, string Addedon)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateGroomerDailyOperationsLog", new SqlParameter[]
                               {
                           new SqlParameter("@GId", GId),
                           new SqlParameter("@VanId", VanId),
                           new SqlParameter("@BeginningMileage", BeginningMileage),
                           new SqlParameter("@TotlaHours", TotlaHours),
                           new SqlParameter("@EndingMileage", EndingMileage),
                           new SqlParameter("@FuelPurchased", FuelPurchased),
                           new SqlParameter("@PricePerGallon", PricePerGallon),
                           new SqlParameter("@CustomerName", CustomerName),
                           new SqlParameter("@Job", Job),
                           new SqlParameter("@ZipCode", ZipCode),
                           new SqlParameter("@Pets", Pets),
                           new SqlParameter("@Rebook", Rebook),
                           new SqlParameter("@FromRebook", FromRebook),
                           new SqlParameter("@New", New),
                           new SqlParameter("@TimeIn", TimeIn),
                           new SqlParameter("@TimeOut", TimeOut),
                           new SqlParameter("@PetTime", PetTime),
                           new SqlParameter("@ExtraServices", ExtraServices),
                           new SqlParameter("@FleaandTick22", FleaandTick22),
                           new SqlParameter("@FleaandTick44", FleaandTick44),
                           new SqlParameter("@FleaandTick88", FleaandTick88),
                           new SqlParameter("@FleaandTick132", FleaandTick132),
                           new SqlParameter("@FleaandTickCat", FleaandTickCat),
                           new SqlParameter("@TB", TB),
                           new SqlParameter("@Wham", Wham),
                           new SqlParameter("@RevenueCreditCard", RevenueCreditCard),
                           new SqlParameter("@RevenueCheck", RevenueCheck),
                           new SqlParameter("@RevenueCash", RevenueCash),
                           new SqlParameter("@RevenueInvoice", RevenueInvoice),
                           new SqlParameter("@TipCreditCard", TipCreditCard),
                           new SqlParameter("@TipCheck", TipCheck),
                           new SqlParameter("@TipCash", TipCash),
                           new SqlParameter("@TipInvoice", TipInvoice),
                           new SqlParameter("@PriorCreditCard", PriorCreditCard),
                           new SqlParameter("@PriorCheck", PriorCheck),
                           new SqlParameter("@PriorCash", PriorCash),
                           new SqlParameter("@NextAppointmentDate", NextAppointmentDate),
                           new SqlParameter("@NextAppointmentTime", NextAppointmentTime),
                           new SqlParameter("@ServicesForPet1", ServicesForPet1),
                           new SqlParameter("@ServicesForPet2", ServicesForPet2),
                           new SqlParameter("@ServicesForPet3", ServicesForPet3),
                           new SqlParameter("@ServicesForPet4", ServicesForPet4),
                           new SqlParameter("@ServicesForPet5", ServicesForPet5),
                           new SqlParameter("@ServicesForPet6", ServicesForPet6),
                           new SqlParameter("@Addedon", Addedon),

                           new SqlParameter("@DailyLogId", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "DailyLogId", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@DailyLogId"]).Value.ToString());
            return Count;
        }
        public DataSet GetGroomerMonthlyLogData(int GID, string StartDate, string EndDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomerMonthlyLogData", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@StartDate", StartDate), new SqlParameter("@EndDate", EndDate) });
            DB.Dispose();
            return ds;
        }

        public DataSet BindGroomers()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("BindGroomers", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet GetGroomersdateappointment(int AppointmentId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomersdateappointment", new SqlParameter[] { new SqlParameter("@AppointmentId", AppointmentId) });
            DB.Dispose();
            return ds;
        }

        public int UpdateGroomerAppointment(int AppointmentID, int GId, string AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string custEmail, int SequenceNo, string DateTimeFormat, int Astatus, decimal ExpPetTime, string ExpStartTime, bool Pstatus, string PresentedTime)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateGroomerAppointment", new SqlParameter[] {new SqlParameter("@AppointmentID", AppointmentID),new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", AppointmentDate),
                           new SqlParameter("@StartTime", StartTime),
                           new SqlParameter("@EndTime", EndTime),
                           new SqlParameter("@ExpectedTotalRevenue", ExpectedTotalRevenue),
                           new SqlParameter("@Others", Others),
                           new SqlParameter("@custEmail", custEmail),
                           new SqlParameter("@SequenceNo", SequenceNo),
                           new SqlParameter("@DateTimeFormat", @DateTimeFormat),
                           new SqlParameter("@Astatus", Astatus),
                           new SqlParameter("@ExpPetTime",ExpPetTime),
                           new SqlParameter("@ExpStartTime",ExpStartTime),
                           new SqlParameter("@Pstatus",Pstatus),
                           new SqlParameter("@PresentedTime",PresentedTime),

         new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
            return Count;
        }

        public DataSet GetGroomersSequence(string AppointmentDate, int AppointmentId, int GId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomersSequence", new SqlParameter[] { new SqlParameter("@AppointmentDate", AppointmentDate), new SqlParameter("@AppointmentId", AppointmentId), new SqlParameter("@GId", GId) });
            DB.Dispose();
            return ds;
        }

        #region Permanenlty delete selected appointments records
        public DataSet DeleteGroomerAppointment(int AppointmentId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteGroomerAppointment", new SqlParameter[] { new SqlParameter("@AppointmentId", @AppointmentId) });
            DB.Dispose();
            return ds;
        }
        #endregion

        #region  delete DeleteConfirmGroomerAppointment
        public int DeleteConfirmGroomerAppointment(int AppointmentId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteConfirmGroomerAppointment", new SqlParameter[] { new SqlParameter("@AppointmentId", @AppointmentId) });
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentId"]).Value.ToString());
            return Count;
        }
        #endregion

        //July2014
        //Jan 2016 By Umesh

        #region Mobile and Desktop Function to delete future appointment from mobile panel(if Parent is choosen to delete then auto its childs should be deleted)
        public void DeleteCustomerAppointment(int AppointmentId, string confirmstatus, int userid, string usermail, DateTime date)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteCustomerFutureAppointmentR", new SqlParameter[] { new SqlParameter("@AppointmentId", @AppointmentId),
            new SqlParameter("@confirmstatus", @confirmstatus),
            new SqlParameter("@datetime", @date),
            new SqlParameter("@userid", @userid),
            new SqlParameter("@usermail", @usermail)
        });
            DB.Dispose();
        }
        #endregion Mobile and Desktop Function to delete future appointment from mobile panel(if Parent is choosen to delete then auto its childs should be deleted)
        public int AssignGroomerAppointment(int GID, DateTime AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, string custname, int SequenceNo, decimal ExpPetTime)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AssignGroomerAppointment", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@AppointmentDate", AppointmentDate),
                           new SqlParameter("@StartTime", StartTime),
                           new SqlParameter("@EndTime", EndTime),
                           new SqlParameter("@ExpectedTotalRevenue", ExpectedTotalRevenue),
                           new SqlParameter("@Others", Others),
                           new SqlParameter("@DateTimeFormat", DateTimeFormat),
                           new SqlParameter("@CustomerName", custname),
                           new SqlParameter("@SequenceNo", SequenceNo),
                           new SqlParameter("@ExpPetTime",ExpPetTime),
        new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
            return Count;
        }

        public DataSet GetGroomersSequenceforUpdate(int GId, string AppointmentDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomersSequenceforUpdate", new SqlParameter[] { new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", AppointmentDate) });
            DB.Dispose();
            return ds;
        }

        public DataSet UpdateGroomerSequence(int GID, DateTime  AppointmentDate, int SequenceNo, int AppointmentId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("UpdateGroomerSequence", new SqlParameter[] {
            new SqlParameter("@GID", GID),
            new SqlParameter("@AppointmentDate", AppointmentDate),
            new SqlParameter("@SequenceNo", SequenceNo),
            new SqlParameter("@AppointmentId", AppointmentId) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetPreviousGroomersSequenceforUpdate(int GId, string AppointmentDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPreviousGroomersSequenceforUpdate", new SqlParameter[] { new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", AppointmentDate) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetPreviousGroomersSequenceforUpdate1(int GId, string AppointmentDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPreviousGroomersSequenceforUpdate1", new SqlParameter[] { new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", AppointmentDate) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetMaxSequencenoOfGroomer(int GId, string AppointmentDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetMaxSequencenoOfGroomer", new SqlParameter[] { new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", Convert.ToDateTime(AppointmentDate).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetGroomerNextsequenceForupdate(int GId, DateTime AppointmentDate, int Sequence)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomerNextsequenceForupdate", new SqlParameter[] { new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", AppointmentDate), new SqlParameter("@Sequence", Sequence) });
            DB.Dispose();
            return ds;
        }
        public void ChangeGroomerAppointmentStatus(string AppointmentId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("ChangeGroomerAppointmentStatus", new SqlParameter[] { new SqlParameter("@AppointmentId", @AppointmentId) });
            DB.Dispose();
        }

        #region added for Groomer Excel Export
        public void EditExcel(string password, string VanId, string BeginningMileage, string TotlaHours, string EndingMileage, string FuelPurchased, string PricePerGallon, string CustomerName, string Job, string ZipCode, string Pets, string Rebook, string FromRebook, string New, string TimeIn, string TimeOut, string PetTime, string ExtraServices, string comments, string FleaandTick22, string FleaandTick44, string FleaandTick88, string FleaandTick132, string FleaandTickCat, string TB, string Wham, string RevenueCreditCard, string RevenueCheck, string RevenueCash, string RevenueInvoice, string TipCreditCard, string TipCheck, string TipCash, string TipInvoice, string PriorCreditCard, string PriorCheck, string PriorCash, string NextAppointmentDate, string NextAppointmentTime, string ServicesForPet, string Addedon, string FleaTick22, string FleaTick44, string FleaTick88, string FleaTick132, string FleaTickcAT, string Toothbrushes, string WhamInv, string Towels, string CottonPads, string CottonSwabs, string PaperTowels, string GarbageBags, string Treats, string VetWrap, string Wipes, string QuickStop, string LiquidBandaid, string Envelopes, string Receipts, string BusinessCards, string BladesSharpened, string ScissorsSharpened, string SunGuard, string EZShed, string EZDematt, string SkunkKit, string Other, string ProductPrice, string SalesTax, string Rev01, string CreditCardNo, string CreditCardExpir, string CreditCardName, string CreditCardAddr, string SecurityCode, string Other1,
            string Other2, string Other3, string Other4, string Other5, string Marketing1, string Marketing2, string Marketing3, string Marketing4, string Marketing5, string Liquid1, string Liquid2, string Liquid3, string Liquid4, string Liquid5, string Liquid6, string Liquid7, string Liquid8, string Liquid9, string Liquid10, string Liquid11, string Liquid12, string Liquid13, string Liquid14, string Liquid15, string Liquid16, string Liquid17, string Liquid18, string Liquid19, string Liquid20, string Liquid21, string Liquid22, string Liquid23, string Liquid24, string Liquid25)
        {
            try {
                string TEMP = (VanId + "," + BeginningMileage + "," + TotlaHours + "," + EndingMileage + "," + FuelPurchased + "," + PricePerGallon + "," + CustomerName + "," + Job + "," + ZipCode + "," + Pets + "," + Rebook + "," + FromRebook + "," + New + "," + TimeIn + "," + TimeOut + "," + PetTime + "," + ExtraServices + "," + comments + "," + FleaandTick22 + "," + FleaandTick44 + "," + FleaandTick88 + "," + FleaandTick132 + "," + FleaandTickCat + "," + TB + "," + Wham + "," + RevenueCreditCard + "," + RevenueCheck + "," + RevenueCash + "," + RevenueInvoice + "," + TipCreditCard + "," + TipCheck + "," + TipCash + "," + TipInvoice + "," + PriorCreditCard + "," + PriorCheck + "," + PriorCash + "," + NextAppointmentDate + "," + NextAppointmentTime + "," + ServicesForPet + "," + Addedon + "," + FleaTick22 + "," + FleaTick44 + "," + FleaTick88 + "," + FleaTick132 + "," + FleaTickcAT + "," + Toothbrushes + "," + WhamInv + "," + Towels + "," + CottonPads + "," + CottonSwabs + "," + PaperTowels + "," + GarbageBags + "," + Treats + "," + VetWrap + "," + Wipes + "," + QuickStop + "," + LiquidBandaid + "," + Envelopes + "," + Receipts + "," + BusinessCards + "," + BladesSharpened + "," + ScissorsSharpened + "," + SunGuard + "," + EZShed + "," + EZDematt + "," + SkunkKit + "," + Other);
                DBConnection DB = new DBConnection();
                DB.ExecuteNonQuery("sp_ManageExcel", new SqlParameter[] {
             new SqlParameter("@VanId" ,VanId),new SqlParameter("@BeginningMileage" ,BeginningMileage),
    new SqlParameter("@TotlaHours" ,TotlaHours),new SqlParameter("@EndingMileage" ,EndingMileage),
    new SqlParameter("@FuelPurchased" ,FuelPurchased),new SqlParameter("@PricePerGallon" ,PricePerGallon),
    new SqlParameter("@CustomerName" ,CustomerName),new SqlParameter("@Job" ,Job),new SqlParameter("@ZipCode" ,ZipCode),new SqlParameter("@Pets ",Pets),
    new SqlParameter("@Rebook" ,Rebook),new SqlParameter("@FromRebook" ,FromRebook),new SqlParameter("@New" ,New),
    new SqlParameter("@TimeIn" ,TimeIn),new SqlParameter("@TimeOut" ,TimeOut),new SqlParameter("@PetTime" ,PetTime),
    new SqlParameter("@ExtraServices" ,ExtraServices), new SqlParameter("@Comments" ,comments),new SqlParameter("@FleaandTick22" ,FleaandTick22),
    new SqlParameter("@FleaandTick44" ,FleaandTick44),new SqlParameter("@FleaandTick88" ,FleaandTick88),
    new SqlParameter("@FleaandTick132" ,FleaandTick132),new SqlParameter("@FleaandTickCat" ,FleaandTickCat),
    new SqlParameter("@TB" ,TB),new SqlParameter("@Wham" ,Wham),new SqlParameter("@RevenueCreditCard" ,RevenueCreditCard),
    new SqlParameter("@RevenueCheck" ,RevenueCheck),new SqlParameter("@RevenueCash" ,RevenueCash),new SqlParameter("@RevenueInvoice" ,RevenueInvoice),
    new SqlParameter("@TipCreditCard" ,TipCreditCard),new SqlParameter("@TipCheck" ,TipCheck),new SqlParameter("@TipCash" ,TipCash),
    new SqlParameter("@TipInvoice" ,TipInvoice),new SqlParameter("@PriorCreditCard" ,PriorCreditCard),
    new SqlParameter("@PriorCheck" ,PriorCheck),new SqlParameter("@PriorCash" ,PriorCash),
    new SqlParameter("@NextAppointmentDate",NextAppointmentDate),new SqlParameter("@NextAppointmentTime" ,NextAppointmentTime),
    new SqlParameter("@ServicesForPet" ,ServicesForPet),new SqlParameter("@Addedon" ,Addedon),
    new SqlParameter("@FleaTick22" ,FleaTick22),new SqlParameter("@FleaTick44" ,FleaTick44),new SqlParameter("@FleaTick88" ,FleaTick88),
    new SqlParameter("@FleaTick132" ,FleaTick132),new SqlParameter("@FleaTickcAT" ,FleaTickcAT),
    new SqlParameter("@Toothbrushes" ,Toothbrushes),new SqlParameter("@WhamInv" ,WhamInv),new SqlParameter("@Towels" ,Towels),
    new SqlParameter("@CottonPads" ,CottonPads),new SqlParameter("@CottonSwabs" ,CottonSwabs),
    new SqlParameter("@PaperTowels" ,PaperTowels),new SqlParameter("@GarbageBags" ,GarbageBags),
    new SqlParameter("@Treats" ,Treats),new SqlParameter("@VetWrap" ,VetWrap),new SqlParameter("@Wipes" ,Wipes),
    new SqlParameter("@QuickStop" ,QuickStop),new SqlParameter("@LiquidBandaid" ,LiquidBandaid),
    new SqlParameter("@Envelopes" ,Envelopes),new SqlParameter("@Receipts" ,Receipts),new SqlParameter("@BusinessCards" ,BusinessCards),
    new SqlParameter("@BladesSharpened" ,BladesSharpened),new SqlParameter("@ScissorsSharpened" ,ScissorsSharpened),
    new SqlParameter("@SunGuard" ,SunGuard),new SqlParameter("@EZShed" ,EZShed),new SqlParameter("@EZDematt" ,EZDematt),
    new SqlParameter("@SkunkKit" ,SkunkKit),new SqlParameter("@Other" ,Other),
    new SqlParameter("@ProductPrice" ,ProductPrice),new SqlParameter("@SalesTax" ,SalesTax),new SqlParameter("@Rev01",Rev01),
    new SqlParameter("@CreditCardNo",CreditCardNo),
    new SqlParameter("@CreditCardExpir",CreditCardExpir),
    new SqlParameter("@CreditCardName",CreditCardName),
    new SqlParameter("@CreditCardAddr",CreditCardAddr),
    new SqlParameter("@SecurityCode",SecurityCode),

    new SqlParameter("@Other1",Other1),
    new SqlParameter("@Other2",Other2),
    new SqlParameter("@Other3",Other3),
    new SqlParameter("@Other4",Other4),
    new SqlParameter("@Other5",Other5),

    new SqlParameter("@Marketing1",Marketing1),
    new SqlParameter("@Marketing2",Marketing2),
    new SqlParameter("@Marketing3",Marketing3),
    new SqlParameter("@Marketing4",Marketing4),
    new SqlParameter("@Marketing5",Marketing5),

    new SqlParameter("@Liquid1",Liquid1),
      new SqlParameter("@Liquid2",Liquid2),
        new SqlParameter("@Liquid3",Liquid3),
          new SqlParameter("@Liquid4",Liquid4),
            new SqlParameter("@Liquid5",Liquid5),
              new SqlParameter("@Liquid6",Liquid6),
                new SqlParameter("@Liquid7",Liquid7),
                  new SqlParameter("@Liquid8",Liquid8),
                    new SqlParameter("@Liquid9",Liquid9),
                      new SqlParameter("@Liquid10",Liquid10),
                        new SqlParameter("@Liquid11",Liquid11),
                          new SqlParameter("@Liquid12",Liquid12),
                            new SqlParameter("@Liquid13",Liquid13),
                              new SqlParameter("@Liquid14",Liquid14),
                                new SqlParameter("@Liquid15",Liquid15),
                                    new SqlParameter("@Liquid16",Liquid16),
                                      new SqlParameter("@Liquid17",Liquid17),
                                        new SqlParameter("@Liquid18",Liquid18),
                                          new SqlParameter("@Liquid19",Liquid19),
                                            new SqlParameter("@Liquid20",Liquid20),
                                              new SqlParameter("@Liquid21",Liquid21),
                                                new SqlParameter("@Liquid22",Liquid22),
                                                  new SqlParameter("@Liquid23",Liquid23),
                                                  new SqlParameter("@Liquid24",Liquid24),
                                                   new SqlParameter("@Liquid25",Liquid25),
                                                   new SqlParameter("@Password",password)
         });
                DB.Dispose();
            }
            catch { }
        }

        #region Get All From LogExcel
        public DataSet getExcelData()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_getExcelData", new SqlParameter[] { new SqlParameter("@logid", "") });
            DB.Dispose();
            return ds;
        }
        #endregion

        //Added 16jan13
        //Dec2013
        public DataSet getInventoryLabels()
        {
            //  SqlConnection con = new SqlConnection(@"Data Source=INDIA-PC;Initial Catalog=fritzyslive_new;User ID=sa;Password=123");
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            //SqlConnection con = new SqlConnection(@"Data Source=MANOJ;Initial Catalog=fritzyslive_new;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            DataSet ds = new DataSet();
            string getLabels = "Select * from InventoryLiquids";
            cmd.CommandText = getLabels;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "InventoryLiquids");
            return ds;
        }

        public void updateLabels(string liq1, string liq2, string liq3, string liq4, string liq5, string liq6, string liq7, string liq8,
            string liq9, string liq10, string liq11, string liq12, string liq13, string liq14, string liq15, string liq16, string liq17, string liq18,
            string liq19, string liq20, string liq21, string liq22, string liq23, string liq24, string liq25,
            string FleaTick22, string FleaTick44, string FleaTick88, string FleaTick132, string FleaTickCat, string Toothbrushes,
            string Wham, string Towels, string Treats, string Wipes, string CottonSwabs, string VetWrap, string PaperTowels,
            string GarbageBags, string Receipts, string Envelopes, string BusinessCards, string Other1, string Other2, string Other3, string Other4, string Other5,
            string Marketing1, string Marketing2, string Marketing3, string Marketing4, string Marketing5)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=MANOJ;Initial Catalog=fritzyslive_new;Integrated Security=True");
            /// SqlConnection con = new SqlConnection(@"Data Source=INDIA-PC;Initial Catalog=fritzyslive_new;User ID=sa;Password=123");
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            con.Open();
            string updateQuery = "update InventoryLiquids set Liquid1=@liq1,Liquid2=@liq2,Liquid3=@liq3,Liquid4=@liq4,Liquid5=@liq5,Liquid6=@liq6,Liquid7=@liq7,Liquid8=@liq8,Liquid9=@liq9,Liquid10=@liq10,Liquid11=@liq11,Liquid12=@liq12,Liquid13=@liq13,Liquid14=@liq14,Liquid15=@liq15,Liquid16=@liq16,Liquid17=@liq17,Liquid18=@liq18,Liquid19=@liq19,Liquid20=@liq20,Liquid21=@liq21,Liquid22=@liq22,Liquid23=@liq23,Liquid24=@liq24,Liquid25=@liq25,";
            updateQuery += "FleaTick22=@FleaTick22,FleaTick44=@FleaTick44,FleaTick88=@FleaTick88,FleaTick132=@FleaTick132,FleaTickCat=@FleaTickCat,Toothbrushes=@Toothbrushes,Wham=@Wham,Towels=@Towels,Treats=@Treats,Wipes=@Wipes,CottonSwabs=@CottonSwabs,VetWrap=@VetWrap,PaperTowels=@PaperTowels,GarbageBags=@GarbageBags,Receipts=@Receipts,Envelopes=@Envelopes,BusinessCards=@BusinessCards,";
            updateQuery += "Other1=@Other1,Other2=@Other2,Other3=@Other3,Other4=@Other4,Other5=@Other5,Marketing1=@Marketing1,Marketing2=@Marketing2,Marketing3=@Marketing3,Marketing4=@Marketing4,Marketing5=@Marketing5 where id=@liqId";
            SqlCommand cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@liq1", liq1);
            cmd.Parameters.AddWithValue("@liq2", liq2);
            cmd.Parameters.AddWithValue("@liq3", liq3);
            cmd.Parameters.AddWithValue("@liq4", liq4);
            cmd.Parameters.AddWithValue("@liq5", liq5);
            cmd.Parameters.AddWithValue("@liq6", liq6);
            cmd.Parameters.AddWithValue("@liq7", liq7);
            cmd.Parameters.AddWithValue("@liq8", liq8);
            cmd.Parameters.AddWithValue("@liq9", liq9);
            cmd.Parameters.AddWithValue("@liq10", liq10);
            cmd.Parameters.AddWithValue("@liq11", liq11);
            cmd.Parameters.AddWithValue("@liq12", liq12);
            cmd.Parameters.AddWithValue("@liq13", liq13);
            cmd.Parameters.AddWithValue("@liq14", liq14);
            cmd.Parameters.AddWithValue("@liq15", liq15);
            cmd.Parameters.AddWithValue("@liq16", liq16);
            cmd.Parameters.AddWithValue("@liq17", liq17);
            cmd.Parameters.AddWithValue("@liq18", liq18);
            cmd.Parameters.AddWithValue("@liq19", liq19);
            cmd.Parameters.AddWithValue("@liq20", liq20);
            cmd.Parameters.AddWithValue("@liq21", liq21);
            cmd.Parameters.AddWithValue("@liq22", liq22);
            cmd.Parameters.AddWithValue("@liq23", liq23);
            cmd.Parameters.AddWithValue("@liq24", liq24);
            cmd.Parameters.AddWithValue("@liq25", liq25);
            cmd.Parameters.AddWithValue("@FleaTick22", FleaTick22);
            cmd.Parameters.AddWithValue("@FleaTick44", FleaTick44);
            cmd.Parameters.AddWithValue("@FleaTick88", FleaTick88);
            cmd.Parameters.AddWithValue("@FleaTick132", FleaTick132);
            cmd.Parameters.AddWithValue("@FleaTickCat", FleaTickCat);
            cmd.Parameters.AddWithValue("@Toothbrushes", Toothbrushes);
            cmd.Parameters.AddWithValue("@Wham", Wham);
            cmd.Parameters.AddWithValue("@Towels", Towels);
            cmd.Parameters.AddWithValue("@Treats", Treats);
            cmd.Parameters.AddWithValue("@Wipes", Wipes);
            cmd.Parameters.AddWithValue("@CottonSwabs", CottonSwabs);
            cmd.Parameters.AddWithValue("@VetWrap", VetWrap);
            cmd.Parameters.AddWithValue("@PaperTowels", PaperTowels);
            cmd.Parameters.AddWithValue("@GarbageBags", GarbageBags);
            cmd.Parameters.AddWithValue("@Receipts", Receipts);
            cmd.Parameters.AddWithValue("@Envelopes", Envelopes);
            cmd.Parameters.AddWithValue("@BusinessCards", BusinessCards);
            cmd.Parameters.AddWithValue("@Other1", Other1);
            cmd.Parameters.AddWithValue("@Other2", Other2);
            cmd.Parameters.AddWithValue("@Other3", Other3);
            cmd.Parameters.AddWithValue("@Other4", Other4);
            cmd.Parameters.AddWithValue("@Other5", Other5);
            cmd.Parameters.AddWithValue("@Marketing1", Marketing1);
            cmd.Parameters.AddWithValue("@Marketing2", Marketing2);
            cmd.Parameters.AddWithValue("@Marketing3", Marketing3);
            cmd.Parameters.AddWithValue("@Marketing4", Marketing4);
            cmd.Parameters.AddWithValue("@Marketing5", Marketing5);
            cmd.Parameters.AddWithValue("@liqId", 1);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet getDailyOperatrionLog(string @GID, string @DailyLogID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_getDailyOperatrionLog", new SqlParameter[] { new SqlParameter("@Gid", @GID), new SqlParameter("@DailyLogID", @DailyLogID) });
            DB.Dispose();
            return ds;
        }

        public void ModifyExportFlag(string DailylogId, int ExcelRowId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("sp_UpdateExportToExcelFlag", new SqlParameter[] { new SqlParameter("@DailylogId", @DailylogId), new SqlParameter("@ExcelRowId", ExcelRowId) });
            DB.Dispose();
        }

        public DataSet GroomerOperationToExport(string Gid)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GroomerOperationToExport", new SqlParameter[] { new SqlParameter("@Gid", @Gid) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetGroomerAppointmentDetails(int DailyLogID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomerAppointmentDetails", new SqlParameter[] { new SqlParameter("@DailyLogID", DailyLogID) });
            DB.Dispose();
            return ds;
        }

        #region  delete month appointment From Admin Groomer
        public DataSet DeleteOldGroomerAppointment(string AppointmentDate, string Enddate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteOldGroomerAppointment", new SqlParameter[] { new SqlParameter("@AppointmentDate", AppointmentDate), new SqlParameter("@Enddate", Enddate) });
            DB.Dispose();
            return ds;
        }
        #endregion  delete month appointment From Admin Groomer
        public void UpdateExcelFileStatus(string FID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateExcelFileStatus", new SqlParameter[] { new SqlParameter("@FID", FID) });
            DB.Dispose();
        }

        public DataSet GetExcelFileName()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetExcelFileName", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public DataSet GetUnlockExcelFileName()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUnlockExcelFileName", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public void AddExcelFile(string FileName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddExcelFile", new SqlParameter[] {
        new SqlParameter("@FileName", FileName)
        });
            DB.Dispose();
        }

        public void DeleteExcelFile(string FileName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteExcelFile", new SqlParameter[] { new SqlParameter("@FileName", FileName) });
            DB.Dispose();
        }

        public void UpdateExcelFileStatusUnlock(string FID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateExcelFileStatusUnlock", new SqlParameter[] { new SqlParameter("@FID", FID) });
            DB.Dispose();
        }

        public void updateExcelExported(int DailyLogId, int Flag)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("updateExcelExported", new SqlParameter[] { new SqlParameter("@DailyLogId", DailyLogId), new SqlParameter("@Flag", Flag) });
            DB.Dispose();
        }

        public void updateExcelExportedEndingMileage(int DailyLogId, int Flag)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("updateExcelExportedEndingMileage", new SqlParameter[] { new SqlParameter("@DailyLogId", DailyLogId), new SqlParameter("@Flag", Flag) });
            DB.Dispose();
        }


        public void updateExcelExportedInventory(int InvId, int Flag)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("updateExcelExportedInventory", new SqlParameter[] { new SqlParameter("@InvId", InvId), new SqlParameter("@Flag", Flag) });
            DB.Dispose();
        }

        public void AddPasswordLog(string FileName, string strNewPassword)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("InsertSPSheetPWDLog", new SqlParameter[] { new SqlParameter("@FileName", FileName), new SqlParameter("@Password", strNewPassword) });
            DB.Dispose();
        }
        #endregion

        public DataSet getExcelPasswordLog(string filename)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetSpreadSheetPasswordLog", new SqlParameter[] { new SqlParameter("@FileName", filename) });
            DB.Dispose();
            return ds;
        }

        #region Push to spreed sheet Button Functionality

        #region 1. Daily Operation Log
        public DataSet GetUuExportedgroomerlogdata()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUuExportedgroomerlogdata", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        #endregion ShoppetInfo_t

        #region 2.Get UnExported groomerInventorydata
        public DataSet GetUnExportedgroomerInventorydata()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUnExportedgroomerInventorydata", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        #endregion Inventorydata

        #region 3.UnExported PrePayment Information
        public DataSet GetPrePaymentData()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPrePaymentDataLog", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public void updatePrepaymentExcelExported(int prePayId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdatePrepaymentExcelExported", new SqlParameter[] { new SqlParameter("@prePayId", prePayId) });
            DB.Dispose();
        }
        #endregion

        #region 4.Get Unexported groomerlogdataEnding
        public DataSet GetUuExportedgroomerlogdataEndingM()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUuExportedgroomerlogdataEndingM", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        #endregion

        #endregion

        #region Push/UnPush Groomer Appointment in Spreadsheet
        public int PushUnPushGroomerAppointment(int GroomerAppointmentId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_PushUnPushGroomerAppointment",
                new SqlParameter[] {
                    new SqlParameter("@GroomerAppointmentId", GroomerAppointmentId),
                 new SqlParameter("@GroomerAppointmentId", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@GroomerAppointmentId"]).Value.ToString());
            return Count;
        }
        #endregion

        #region Refund 
        public DataSet GetDataForRefundPayment(int AppointmentId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GetDataForRefundPayment", new SqlParameter[] { new SqlParameter("@AppointmentId", AppointmentId) });
            DB.Dispose();
            return ds;
        }
        public void UpdateAppointmentAfterRefund(int AppointmentId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("sp_UpdateAppointmentAfterRefund", new SqlParameter[] { new SqlParameter("@AppointmentId", AppointmentId) });
            DB.Dispose();
        }
        #endregion

        #region ActiveInActiveGroomerAppointment
        public void ActiveInActiveGroomerAppointment(int GroomerAppointmentId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("sp_ActiveInActiveGroomerAppointment", new SqlParameter[] { new SqlParameter("@GroomerAppointmentId", GroomerAppointmentId) });
            DB.Dispose();
        }

        #endregion

        #region Create Db Backup
        public void CreateDBBackup(string PathToSave)
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            DB.ExecuteDataSet("sp_CreateDatabaseBackup", new SqlParameter[] {
                new SqlParameter("@DatabaseName",builder.InitialCatalog),
                 new SqlParameter("@PathToSave", PathToSave)
            });
            DB.Dispose();
        }
        #endregion

        #region Truncate tables
        public void TruncateTables()
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteDataSet("sp_truncateTables", new SqlParameter[] { });
            DB.Dispose();
        }
        #endregion

    }
}