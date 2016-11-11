using HicPicDataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace advancewebtosolution.BO
{
    public class StoreFront
    {
        public StoreFront()
        {
        }
        #region Check Login User Mobile
        public DataSet GetLoginUser(string UserName, string Password)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetLoginUser", new SqlParameter[] { new SqlParameter("@UserName", UserName), new SqlParameter("@Password", Password) });
            DB.Dispose();
            return ds;
        }
        #endregion
        //Dec2013
        #region User Payment
        public DataSet GetAppInfoforPayment(string UserName)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetApptInfoforPayment", new SqlParameter[] { new SqlParameter("@UserName", UserName) });
            DB.Dispose();
            return ds;
        }
        public DataSet UpdateSyncAppStatus(int syncid, string pstatus, int payid, decimal tip)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("UpdateStatusInSyncApp", new SqlParameter[] { new SqlParameter("@syncid", syncid), new SqlParameter("@pstatus", pstatus), new SqlParameter("@payid", payid), new SqlParameter("@tipamt", tip) });
            DB.Dispose();
            return ds;
        }
        public bool CheckOrderRefNo(string OrdNumber)
        {
            bool OrdRefnoPresent = false;

            try
            {
                DBConnection DB = new DBConnection();
                SqlDataReader drOrder = (SqlDataReader)DB.ExecuteReader("sp_CheckOrderRef", new SqlParameter[] { new SqlParameter("@OrderNo", OrdNumber) });

                if (drOrder.HasRows)
                {
                    OrdRefnoPresent = true;
                }
                drOrder.Close();
                DB.Dispose();

            }
            catch (Exception Ex)
            {
                string error = Ex.Message;
            }
            return OrdRefnoPresent;
        }

        #region mobile payment and desktop payment

        public int InsertUpdateAppointmentToGroomerAppointment(int GAppointmentId, int GID, DateTime AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, int SequenceNo, decimal ExpPetTime, string custname, string custemail, string expectStartTime, int UserAppID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("sp_AddAppointmentToGroomerAppointment", new SqlParameter[] { new SqlParameter("@GAppointmentId",GAppointmentId),
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
                              new SqlParameter("@UserAppID",UserAppID),
        new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
            return Count;
        }

        #region Save Shopper Info Before Payment
        public void GetShopperInfo(int GId, string FirstName, string LastName, string streetAddress, string City, string State, string Zip,
            string Country, string Phone, string Email, string CardType, string CreditCardNo,
            string ValidYear, string ValidMonth, string VerificationCode, decimal Payment_Amount, decimal SandH, decimal Tax, string ordno, int AppointmentId, string CCV)
        {
            try
            {
                //new Code for R & D
                string card = CreditCardNo;
                string cardno = card.Substring(card.Length - 4);
                //end           
                DBConnection db = new DBConnection();
                db.ExecuteNonQuery("GetShopperInfo", new SqlParameter[]{
             new SqlParameter("@GID",GId),
             new SqlParameter("@FirstName",FirstName),
             new SqlParameter("@LastName",LastName),
             new SqlParameter("@Address1",streetAddress),
             new SqlParameter("@City",City),
             new SqlParameter("@State",State),
             new SqlParameter("@Zip",Zip),
             new SqlParameter("@Country",Country),
             new SqlParameter("@Phone",Phone),
             new SqlParameter("@Email",Email),
             new SqlParameter("@Cardtype",CardType),
             new SqlParameter("@CreditCardNo",CreditCardNo),
             new SqlParameter("@ValidYear",ValidYear),
             new SqlParameter("@ValidMonth",ValidMonth),
             new SqlParameter("@VerificationCode",VerificationCode),
             new SqlParameter("@Payment_Amount",Payment_Amount),
             new SqlParameter("@SandH",SandH),
             new SqlParameter("@Tax",Tax),
             new SqlParameter("@OrdRefNo", ordno),
              new SqlParameter("@CCV", CCV),
             new SqlParameter("@AppointmentId",AppointmentId),
             new SqlParameter("@PayID",SqlDbType.Int,10,ParameterDirection.Output,true,0,0,"Payment_ID",DataRowVersion.Default,0)
            });
                int PaymentID = Convert.ToInt32(((SqlParameter)db.LastCommand.Parameters["@PayID"]).Value.ToString());
                HttpContext.Current.Session["PayID"] = PaymentID.ToString();
                db.Dispose();
            }
            catch (Exception Ex)
            {
                string error = Ex.Message;
            }
        }
        #endregion

        #region Update Shopper Info After Success Payment
        public void UpdatePGResponseDetails(string result, string dailylogid, string responseid, string PayID, string Response, string BillTxnRefNumber, string AuthCode, string ResponseToken)
        {
            try
            {
                DBConnection db = new DBConnection();
                db.ExecuteNonQuery("UpdateShopperResponse", new SqlParameter[]{
                 new SqlParameter("@Result",result),
                 new SqlParameter("@DailyLogID",Convert.ToInt32(dailylogid)),
                 new SqlParameter("@ResponseID",responseid),
                 new SqlParameter("@PaymentID",Convert.ToInt32(PayID)),
                 new SqlParameter("@Response",Response),
                 new SqlParameter("@BillTxnRefno",Convert.ToString(BillTxnRefNumber)),
                 new SqlParameter("@Authcode",Convert.ToString(AuthCode)),
                  new SqlParameter("@ResponseToken",Convert.ToString(ResponseToken))
         });
                db.Dispose();
            }
            catch (Exception Ex)
            {
                string error = Ex.Message;
            }
        }
        #endregion

        #endregion

        public int InsertSyncAppointment(int appid, int gid, string custname, decimal revenueamt, decimal tipamt, decimal prioramt, decimal totalamt, string pstatus)
        {
            DBConnection db = new DBConnection();
            int Count = 0;
            try
            {
                Count = db.ExecuteNonQuery("InsertSyncAppDetails", new SqlParameter[]{
                           new SqlParameter("@apptid",appid),
                           new SqlParameter("@gid",gid),
                           new SqlParameter("@customername", custname),
                           new SqlParameter("@revenueamt",revenueamt),
                           new SqlParameter("@tipamt", tipamt),
                           new SqlParameter("@prioramt", prioramt),
                           new SqlParameter("@totalamt",totalamt),
                           new SqlParameter("@pstatus",pstatus)
        });

            }
            catch { }
            db.Dispose();
            return Count;
        }

        // April 25, 2014
        //call from mobile and desktop

        #region Insert Update To Prepayment Table After Successfull Payment
        public int InsertAppointmentPrePayment(int userid, decimal revenueamt, decimal PriorAmt, decimal TipAmt, string payDescription, int PaymentId, int appid, string FirstName, string LastName)
        {
            DBConnection db = new DBConnection();
            int Count = db.ExecuteNonQuery("InsertAppointmentPrePayment", new SqlParameter[]{
                           new SqlParameter("@UserId",userid),
                           new SqlParameter("@RevAmt",revenueamt),
                           new SqlParameter("@PriorAmt", PriorAmt),
                           new SqlParameter("@TipAmt",TipAmt),
                           new SqlParameter("@TotalAmt", (revenueamt+PriorAmt+TipAmt)),
                           new SqlParameter("@payDescription", payDescription),
                           new SqlParameter("@PaymentId",PaymentId),
                           new SqlParameter("@AppointmentID",appid),
                           new SqlParameter("@FirstName",FirstName),
                            new SqlParameter("@LastName",LastName),
                           new SqlParameter("@Addedon",System.DateTime.Now)
        });
            db.Dispose();
            return Count;
        }

        #endregion

        #region Upddate Groomer Appointment
        public void UpdatePrePayStatus(int appid, string pstaus)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdatePayStatusInGroomerApp", new SqlParameter[] {
                        new SqlParameter("@AppointmentID", appid),
                        new SqlParameter("@paidStatus", pstaus),
                        new SqlParameter("@IsMember", '1')
                      });
            DB.Dispose();

        }
        #endregion

        public DataSet getCustomerforSync(string custname)
        {
            DBConnection DB = new DBConnection();
            DataSet DT = new DataSet();
            try
            {
                DT = DB.ExecuteDataSet("CheckCustomerforSync", new SqlParameter[] { new SqlParameter("@CustomerName", custname) });
            }
            catch (Exception Ex)
            {
                string error = Ex.Message;
            }
            DB.Dispose();
            return DT;
        }


        #endregion

        public DataSet GetHomePageServices(int UserType)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetHomePageServices", new SqlParameter[] { new SqlParameter("@UserType", UserType) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetServicePageServices(int UserType, int PetType)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetServicePageServices", new SqlParameter[] { new SqlParameter("@UserType", UserType), new SqlParameter("@PetType", PetType) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetAllServicePageServices(int UserType)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllServicePageServices", new SqlParameter[] { new SqlParameter("@UserType", UserType) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetFleaPageServices()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetFleaPageServices", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }


        #region "ContactUS"
        public void AddContactus(string FirstName, string LastName, string Email, string Mobile, string Message)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddContactus", new SqlParameter[] {
                           new SqlParameter("@FirstName", FirstName),
                           new SqlParameter("@LastName", LastName),
                           new SqlParameter("@Email", Email),
                           new SqlParameter("@Mobile", Mobile),
                           new SqlParameter("@Message", Message) });
            DB.Dispose();
        }

        public DataSet GetAllContactus(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllContactus", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }

        public void DeleteContactUs(string ContactID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteContactUs", new SqlParameter[] { new SqlParameter("@ContactID", ContactID) });
            DB.Dispose();
        }

        public DataSet GetAllContactUsExport(DateTime StartDate, DateTime EndDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllContactUsExport", new SqlParameter[] { new SqlParameter("@StartDate", StartDate), new SqlParameter("@EndDate", EndDate) });
            DB.Dispose();
            return ds;
        }
        #endregion "ContactUS"

        #region Service Page
        public DataSet GetAllDogService()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllDogService", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public DataSet GetAllCatService()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllCatService", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public DataSet GetAllCatDogService()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllCatDogService", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet GetServiceDetailFront(int ServiceID, int Page)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("GetServiceDetailFront", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID), new SqlParameter("@Page", Page) });
            DB.Dispose();
            return DS;
        }
        #endregion Service Page

        #region "Baner"
        public DataSet GetBanerPages()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetBanerPages", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet GetBanerImage(int BanerID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetBanerImage", new SqlParameter[] { new SqlParameter("@BanerID", BanerID) });
            DB.Dispose();
            return ds;
        }

        public void UpdateBanerImage(int BanerID, string ImageName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateBanerImage", new SqlParameter[] {
                           new SqlParameter("@BanerID", BanerID),
                           new SqlParameter("@ImageName", ImageName) });
            DB.Dispose();
        }
        public int CheckPET(int PetID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("CheckPET", new SqlParameter[] { new SqlParameter("@PetID", PetID), new SqlParameter("@Check", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Check", DataRowVersion.Default, 0) });
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Check"]).Value.ToString());
            return Count;

        }

        public void DeleteBanner(string BannerID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteBanner", new SqlParameter[] { new SqlParameter("@BannerID", BannerID) });
            DB.Dispose();
        }

        public void AddBanner(int PetType, string ImageName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddBanner", new SqlParameter[] {
                           new SqlParameter("@PetType", PetType),
                           new SqlParameter("@ImageName", ImageName) });
            DB.Dispose();
        }

        public DataSet GetBanerID(int Count, string PageName)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetBanerID", new SqlParameter[] {
                           new SqlParameter("@Count", Count),
                           new SqlParameter("@PageName", PageName) });
            return ds;
        }
        #endregion "Baner"

        #region "Additional Services"

        public DataSet GetAdditionalServices(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAdditionalServices", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetAdditionalServicesExport()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAdditionalServicesExport", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public int DeleteAdditionalServices(string AdditionalServiceID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteAdditionalServices", new SqlParameter[] { new SqlParameter("@AdditionalServiceID", AdditionalServiceID),
             new SqlParameter("@Return_Value", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Return_Value", DataRowVersion.Default, 0)});

            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Return_Value"]).Value.ToString());
            return Count;
        }

        public DataSet UpdateAdditionalServiceStatus(string AdditionalServiceID)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("UpdateAdditionalServiceStatus", new SqlParameter[] { new SqlParameter("@AdditionalServiceID", AdditionalServiceID) });
            DB.Dispose();
            return DS;
        }


        public int UpdateAdditionalServices(int AdditionalServiceID, string ServiceName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateAdditionalServices", new SqlParameter[] {
                        new SqlParameter("@AdditionalServiceID", AdditionalServiceID),
                        new SqlParameter("@ServiceName", ServiceName),
                        new SqlParameter("@Return_Value", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Return_Value", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Return_Value"]).Value.ToString());
            return Count;
        }

        public int AddAdditionalService(string ServiceName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddAdditionalServices", new SqlParameter[] { new SqlParameter("@ServiceName", ServiceName),

        new SqlParameter("@AdditionalServiceID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AdditionalServiceID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AdditionalServiceID"]).Value.ToString());
            return Count;
        }

        public int AddAdditionalServiceExcel(string ServiceName, int Status)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddAdditionalServicesExcel", new SqlParameter[] { new SqlParameter("@ServiceName", ServiceName), new SqlParameter("@Status", Status),

        new SqlParameter("@AdditionalServiceID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AdditionalServiceID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AdditionalServiceID"]).Value.ToString());
            return Count;
        }


        #endregion "Additional Services"

        #region "Breed"

        public DataSet GetBreed(string PetTypeID, string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetBreed", new SqlParameter[] { new SqlParameter("@PetTypeID", PetTypeID), new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetBreedExport()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetBreedExport", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public int DeleteBreed(string BreedID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteBreed", new SqlParameter[] { new SqlParameter("@BreedID", BreedID),
            new SqlParameter("@Return_Value", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Return_Value", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Return_Value"]).Value.ToString());
            return Count;
        }

        public DataSet UpdateBreedStatus(string BreedID)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("UpdateBreedStatus", new SqlParameter[] { new SqlParameter("@BreedID", BreedID) });
            DB.Dispose();
            return DS;
        }
        public int UpdateBreed(int BreedID, string BreedName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateBreed", new SqlParameter[] {
                    new SqlParameter("@BreedID", BreedID),
                    new SqlParameter("@BreedName", BreedName),
                    new SqlParameter("@Return_Value", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Return_Value", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Return_Value"]).Value.ToString());
            return Count;
        }


        public int AddBreed(string BreedName, int PetType)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddBreed", new SqlParameter[] { new SqlParameter("@BreedName", BreedName),new SqlParameter("@PetType", PetType),

        new SqlParameter("@BreedID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "BreedID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@BreedID"]).Value.ToString());
            return Count;
        }

        public int AddBreedExcel(string BreedName, int PetType, int Status)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddBreedExcel", new SqlParameter[] { new SqlParameter("@BreedName", BreedName),new SqlParameter("@PetType", PetType), new SqlParameter("@Status", Status),

        new SqlParameter("@BreedID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "BreedID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@BreedID"]).Value.ToString());
            return Count;
        }
        #endregion "Additional Services"

        #region "Style"

        public DataSet GetStyle(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetStyle", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetStyleExport()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetStyleExport", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public int DeleteStyle(string StyleID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteStyle", new SqlParameter[] { new SqlParameter("@StyleID", StyleID) ,
            new SqlParameter("@Return_Value", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Return_Value", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Return_Value"]).Value.ToString());
            return Count;
        }

        public DataSet UpdateStyleStatus(string StyleID)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("UpdateStyleStatus", new SqlParameter[] { new SqlParameter("@StyleID", StyleID) });
            DB.Dispose();
            return DS;
        }

        public int UpdateStyle(int StyleID, string StyleName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateStyle", new SqlParameter[] {
                            new SqlParameter("@StyleID", StyleID),
                            new SqlParameter("@StyleName", StyleName),
                            new SqlParameter("@Return_Value", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Return_Value", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Return_Value"]).Value.ToString());
            return Count;
        }

        public int AddStyle(string StyleName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddStyle", new SqlParameter[] { new SqlParameter("@StyleName", StyleName),

        new SqlParameter("@StyleID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "StyleID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@StyleID"]).Value.ToString());
            return Count;
        }

        public int AddStyleExcel(string StyleName, int Status)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddStyleExcel", new SqlParameter[] { new SqlParameter("@StyleName", StyleName), new SqlParameter("@Status", Status),

        new SqlParameter("@StyleID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "StyleID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@StyleID"]).Value.ToString());
            return Count;
        }
        #endregion "Additional Services"

        #region "ReferalSource"

        public DataSet GetReferalSource(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetReferalSource", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }

        public int DeleteReferalSource(string ReferalID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteReferalSource", new SqlParameter[] { new SqlParameter("@ReferalID", ReferalID) ,
             new SqlParameter("@Count", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Count", DataRowVersion.Default, 0)});
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Count"]).Value.ToString());

            DB.Dispose();
            return Count;
        }

        public DataSet UpdateReferalSourceStatus(string ReferalID)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("UpdateReferalSourceStatus", new SqlParameter[] { new SqlParameter("@ReferalID", ReferalID) });
            DB.Dispose();
            return DS;
        }

        public int UpdateReferalSource(int ReferalID, string ReferalName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateReferalSource", new SqlParameter[] {
                           new SqlParameter("@ReferalID", ReferalID),
                           new SqlParameter("@ReferalName", ReferalName),
                           new SqlParameter("@Return_Value", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Return_Value", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Return_Value"]).Value.ToString());
            return Count;
        }

        public int AddReferalSource(string ReferalName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddReferalSource", new SqlParameter[] { new SqlParameter("@ReferalName", ReferalName),

        new SqlParameter("@ReferalID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "ReferalID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@ReferalID"]).Value.ToString());
            return Count;
        }
        #endregion "Additional Services"

        #region New
        public DataSet GetNewsFront(int NewsID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetNewsFront", new SqlParameter[] { new SqlParameter("@NewsID", NewsID) });
            DB.Dispose();
            return ds;
        }
        #endregion

        #region Search
        public DataSet GetServiceSearch(string Key)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GetServicesBySearch", new SqlParameter[] { new SqlParameter("@KeyWord", Key) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetProductSearch(string Key)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GetProductBySearch", new SqlParameter[] { new SqlParameter("@KeyWord", Key) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetFriendSearch(string Key)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GetFriendSearch", new SqlParameter[] { new SqlParameter("@KeyWord", Key) });
            DB.Dispose();
            return ds;
        }
        #endregion

        public DataSet GetFleaandTickServices(int UserType)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetFleaandTickServices", new SqlParameter[] { new SqlParameter("@UserType", UserType) });
            DB.Dispose();
            return ds;
        }

    }
}