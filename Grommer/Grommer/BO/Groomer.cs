using System;
using System.Data;
using System.Configuration;
using System.Web;
using HicPicDataAccess;
using System.Data.SqlClient;
using System.Globalization;

/// <summary>
/// Summary description for Groomer
/// </summary>
public class Groomer
{
    public Groomer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet GetGroomerUser(string UserName, string Password)
    {
        try
        {
            DBConnection DB = new DBConnection();
            DataSet DT = new DataSet();
            DT = DB.ExecuteDataSet("GetGroomerUser", new SqlParameter[] { new SqlParameter("@UserName", UserName), new SqlParameter("@PassWord", Password) });
            DB.Dispose();
            return DT;
        }
        catch (SqlException ex)
        {
            string Error = ex.Message;
            return null;
        }
    }
    //New
    public DataSet getOldApp(string gid, int appId)
    {
        try
        {
            DBConnection DB = new DBConnection();
            DataSet DT = new DataSet();
            DT = DB.ExecuteDataSet("sp_GetNextAppointmentDetails", new SqlParameter[] { new SqlParameter("@GID", gid), new SqlParameter("@GroomerAppointmentId", appId) });
            DB.Dispose();
            return DT;
        }
        catch (SqlException ex)
        {
            string Error = ex.Message;
            return null;
        }
    }

    public DataSet GroomerGetProfile(int GId)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        DT = DB.ExecuteDataSet("GroomerGetProfile", new SqlParameter[] { new SqlParameter("@GId", GId) });
        DB.Dispose();
        return DT;
    }
    // New add code here for comments,drive time,pet time
    public int GroomerDailyOperationsLog(int GId, string VanId, int BeginningMileage, string TotlaHours, int EndingMileage, double FuelPurchased,
       double PricePerGallon, string CustomerName, string Job, string ZipCode, int Pets, int Rebook, int FromRebook, int New, string TimeIn, string TimeOut,
       string PetTime, string ExtraServices, int FleaandTick22, int FleaandTick44, int FleaandTick88, int FleaandTick132, int FleaandTickCat,
       int TB, int Wham, double RevenueCreditCard, double RevenueCheck, double RevenueCash, double RevenueInvoice, double TipCreditCard, double TipCheck,
       double TipCash, double TipInvoice, double PriorCreditCard, double PriorCheck, double PriorCash, DateTime NextAppointmentDate, string NextAppointmentTime,
       string ServicesForPet1, string ServicesForPet2, string ServicesForPet3, string ServicesForPet4, string ServicesForPet5, string ServicesForPet6)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("GroomerDailyOperationsLog", new SqlParameter[]
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
                           new SqlParameter("@DailyLogId", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "DailyLogId", DataRowVersion.Default, 0)});
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@DailyLogId"]).Value.ToString());
        return Count;
    }

    public int GroomerAddInventroyRequest(int GId, string FleaTick22, string FleaTick44, string FleaTick88, string FleaTick132, string FleaTickcAT,
        string Toothbrushes, string Wham, string Towels, string CottonPads, string CottonSwabs, string PaperTowels, string GarbageBags, string Treats, string VetWrap,
        string Wipes, string QuickStop, string LiquidBandaid, string Envelopes, string Receipts, string BusinessCards, string BladesSharpened,
        string ScissorsSharpened, string SunGuard, string EZShed, string EZDematt, string SkunkKit, string Other, string Other1,
        string Other2, string Other3, string Other4, string Other5, string Marketing1, string Marketing2, string Marketing3, string Marketing4, string Marketing5, string Liquid1, string Liquid2, string Liquid3, string Liquid4, string Liquid5, string Liquid6, string Liquid7, string Liquid8, string Liquid9, string Liquid10, string Liquid11, string Liquid12, string Liquid13, string Liquid14, string Liquid15, string Liquid16, string Liquid17, string Liquid18, string Liquid19, string Liquid20, string Liquid21, string Liquid22, string Liquid23, string Liquid24, string Liquid25)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("GroomerAddInventroyRequest", new SqlParameter[]
                           {
                           new SqlParameter("@GId", GId),
                           new SqlParameter("@FleaTick22", FleaTick22),
                           new SqlParameter("@FleaTick44", FleaTick44),
                           new SqlParameter("@FleaTick88", FleaTick88),
                           new SqlParameter("@FleaTick132", FleaTick132),
                           new SqlParameter("@FleaTickcAT", FleaTickcAT),
                           new SqlParameter("@Toothbrushes", Toothbrushes),
                           new SqlParameter("@Wham", Wham),
                           new SqlParameter("@Towels", Towels),
                           new SqlParameter("@CottonPads", CottonPads),
                           new SqlParameter("@CottonSwabs", CottonSwabs),
                           new SqlParameter("@PaperTowels", PaperTowels),
                           new SqlParameter("@GarbageBags", GarbageBags),
                           new SqlParameter("@Treats", Treats),
                           new SqlParameter("@VetWrap", VetWrap),
                           new SqlParameter("@Wipes", Wipes),
                           new SqlParameter("@QuickStop", QuickStop),
                           new SqlParameter("@LiquidBandaid", LiquidBandaid),
                           new SqlParameter("@Envelopes", Envelopes),
                           new SqlParameter("@Receipts", Receipts),
                           new SqlParameter("@BusinessCards", BusinessCards),
                           new SqlParameter("@BladesSharpened", BladesSharpened),
                           new SqlParameter("@ScissorsSharpened", ScissorsSharpened),
                           new SqlParameter("@SunGuard", SunGuard),
                           new SqlParameter("@EZShed", EZShed),
                           new SqlParameter("@EZDematt", EZDematt),
                           new SqlParameter("@SkunkKit", SkunkKit),
                           new SqlParameter("@Other", Other),
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
                           new SqlParameter("@InventroyId", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "InventroyId", DataRowVersion.Default, 0)});
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@InventroyId"]).Value.ToString());
        return Count;
    }
    //New 2April1013
    public DataSet getInventoryData(int gid)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());


        //SqlConnection con = new SqlConnection(@"Data Source=DOTNET;Initial Catalog=fritzyslive_new;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        con.Open();
        DataSet ds = new DataSet();
        string getData = "Select * from GroomerInventroyRequest where Gid=@gid order by InventroyId desc";
        cmd.Parameters.AddWithValue("@gid", gid);
        cmd.CommandText = getData;
        cmd.Connection = con;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(ds, "GroomerInventroyRequest");
        return ds;
    }
    //Added 17jan13
    public DataSet getInventoryLabels()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
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

    public void GroomerUpdateProfile(int GId, string UserName, string password, string Name, string Address, string HomePhone, string PersonalCellPhone, string BaseCity, string State, string Zipcode)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("GroomerUpdateProfile", new SqlParameter[] {
                           new SqlParameter("@GId", GId),
                           new SqlParameter("@UserName", UserName),
                           new SqlParameter("@Name", Name),
                           new SqlParameter("@Address", Address),
                           new SqlParameter("@HomePhone", HomePhone),
                           new SqlParameter("@password", password),
                           new SqlParameter("@PersonalCellPhone", PersonalCellPhone),
                           new SqlParameter("@BaseCity", BaseCity),
                           new SqlParameter("@State", State),
                           new SqlParameter("@Zipcode", Zipcode),});
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
    }

    public DataSet GrmmoerGetPassword(string UserName)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("GrmmoerGetPassword", new SqlParameter[] { new SqlParameter("@UserName", UserName) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return DT;
    }

    public DataSet GetGroomersMileage(string Date)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("GetGroomersMileage", new SqlParameter[] { new SqlParameter("@Date", Date) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return DT;
    }

    public DataSet GetGroomerYesterdayMileage(string Date, string GID, string VanID)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("GetGroomerYesterdayMileage", new SqlParameter[] { new SqlParameter("@Date", Date), new SqlParameter("@GID", GID), new SqlParameter("@VanID", VanID) });
        }
        catch
        {
        }
        DB.Dispose();
        return DT;
    }

    #region Dashboard Get All List Of Appointment incomplete Yesterday  and Todays
    public DataSet getAppointmentDtls(string strGID)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("sp_getAppointmentDtls", new SqlParameter[] { new SqlParameter("@GID", strGID) });
        }
        catch 
        {
        }
        DB.Dispose();
        return DT;
    }
    public DataSet getAppointmentDtlsByAppointmentId(int AppId)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("sp_getAppointmentDtlsByAppId", new SqlParameter[] { new SqlParameter("@AppId", AppId) });
        }
        catch
        {
        }
        DB.Dispose();
        return DT;
    }
    #endregion

    public DataSet getAppointmentDetails(string AptID)
    {
        DBConnection DB = new DBConnection();
        DataSet DsAptinfo = new DataSet();
        try
        {
            DsAptinfo = DB.ExecuteDataSet("sp_GetAppointmentDetails", new SqlParameter[] { new SqlParameter("@AppointmentId", Convert.ToInt32(AptID)) });
        }
        catch
        {

        }
        DB.Dispose();
        return DsAptinfo;
    }

    public DataSet getAppointmentAllDetails(string AptID)
    {
        DBConnection DB = new DBConnection();
        DataSet DsAptinfo = new DataSet();
        try
        {
            DsAptinfo = DB.ExecuteDataSet("sp_GetAppointmentAllDetails",
                new SqlParameter[] { new SqlParameter("@AppointmentId", Convert.ToInt32(AptID)) });
        }
        catch
        { }
        DB.Dispose();
        return DsAptinfo;
    }

    #region dailyOperationLog Page Load
    public DataSet getParantFields(string GID, string flag)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("sp_getDailyOperationLog",
                new SqlParameter[] { new SqlParameter("@GId", GID),
                new SqlParameter("@Flag", flag) });
        }
        catch
        {
        }
        DB.Dispose();
        return DT;
    }

    public DataSet getDailyOperationLogUsingVanIdAndGId(string GID, string Addedon, int VanId)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        Addedon = DateTime.Today.ToString("yyyy/M/d");
        try
        {
            DT = DB.ExecuteDataSet("sp_getDailyOperationLogUsingVanIdAndGId", new SqlParameter[] {
         new SqlParameter("@GId", GID),
        new SqlParameter("@Addedon", Convert.ToDateTime(Addedon)),
        new SqlParameter("@VanId", VanId)
       });
        }
        catch
        {
        }
        DB.Dispose();
        return DT;
    }

    public DataSet CheckParantFields(string GID, string Addedon)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        Addedon = System.DateTime.Today.ToString("yyyy/M/d");
        try
        {
            DT = DB.ExecuteDataSet("sp_CheckDailyOperationLogforEndingMileage", new SqlParameter[] { new SqlParameter("@GId", GID), new SqlParameter("@Addedon", Convert.ToDateTime(Addedon)) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return DT;
    }
    #region To Check Appointment id in Daily Operation Log
    public bool CheckAppointment(int GroomerAppointmentId)
    {
        bool IsExists = false;
        DBConnection DB = new DBConnection();
        try
        {
            DataSet dsAppointment = new DataSet();
            dsAppointment = DB.ExecuteDataSet("sp_CheckAppointmentExists", new SqlParameter[] { new SqlParameter("@AppointmentId", GroomerAppointmentId) });
            if (dsAppointment.Tables.Count > 0)
            {
                if (dsAppointment.Tables[0].Rows.Count > 0)
                {
                    IsExists = true;
                }
            }
        }
        catch
        {
        }
        return IsExists;
    }
    #endregion
    public DataSet GetUserInfoUsingUserName(string UserName)
    {
        DBConnection DB = new DBConnection();
        DataSet ds = new DataSet();
        ds = DB.ExecuteDataSet("sp_GetUserInfo", new SqlParameter[] { new SqlParameter("@UserName", UserName) });
        DB.Dispose();
        return ds;
    }
    #region  check for the same appointment in DailyOperatrionLog 
    public bool CheckAppRecordinDB(string GID, string VanID, string BeginningMileage, string ExtraServices, string CustomerName, string Job, string ZipCode, string Pets, string PetTime, string addeon, string TimeIn, string TimeOut)
    {
        bool IsExists = false;
        DBConnection DB = new DBConnection();
        try
        {
            DataSet dsAppointment = new DataSet();
            dsAppointment = DB.ExecuteDataSet("sp_CheckApptRecordExists", new SqlParameter[] { new SqlParameter("@GId", GID),
            new SqlParameter("@VanID", VanID),new SqlParameter("@BeginningMileage", BeginningMileage),new SqlParameter("@ExtraServices", ExtraServices),
            new SqlParameter("@CustomerName", CustomerName), new SqlParameter("@Job", Job), new SqlParameter("@ZipCode", ZipCode),
            new SqlParameter("@Pets", Pets), new SqlParameter("@PetTime", PetTime), new SqlParameter("@Addedon", Convert.ToDateTime(addeon)),
            new SqlParameter("@TimeIn", TimeIn),new SqlParameter("@TimeOut", TimeOut)});
            if (dsAppointment.Tables.Count > 0 && (dsAppointment.Tables[0].Rows.Count > 0)) IsExists = true;
        }
        catch 
        {
            return IsExists;
        }
        return IsExists;
    }
    #endregion

    public int InsertTempDailyOperationLog(int AppointmentID, string GId, string VanId, string BeginningMileage, string TotlaHours, string EndingMileage, string FuelPurchased, string PricePerGallon, string CustomerName, string Job, string ZipCode, string Pets, string Rebook, string FromRebook, string New, string TimeIn, string TimeOut, string PetTime, string ExtraServices, string comments, string driveTime, string rPetTime, int FleaandTick22, int FleaandTick44, int FleaandTick88, int FleaandTick132, int FleaandTickCat, int TB, int Wham, double RevenueCreditCard, double RevenueCheck, double RevenueCash, double RevenueInvoice, double RevenueCCY, double TipCreditCard, double TipCheck, double TipCash, double TipInvoice, double PriorCreditCard, double PriorCheck, double PriorCash, string CreditCardNo, string CreditCardExpir, string CreditCardORChkName, string CreditCardORChkAddr, string SecurityCode, string NextAppointmentDate, string NextAppointmentTime, string NextAppointmentEndTime, string ServicesForPet1, string ServicesForPet2, string ServicesForPet3, string ServicesForPet4, string ServicesForPet5, string ServicesForPet6, int GroomerAppointmentId, string @Addedon, double ProductPrice, double Salestax, int Rev01, string CustNameOnCheque, string BankOnCheque)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("sp_InsertTempDailyOperationLog", new SqlParameter[] {
                           new SqlParameter("@GId",GId),
                           new SqlParameter("@VanId",VanId),
                           new SqlParameter("@BeginningMileage",BeginningMileage),
                           new SqlParameter("@TotlaHours",TotlaHours),
                           new SqlParameter("@EndingMileage",EndingMileage),
                           new SqlParameter("@FuelPurchased",FuelPurchased),
                           new SqlParameter("@PricePerGallon",PricePerGallon),
                           new SqlParameter("@CustomerName",CustomerName),
                           new SqlParameter("@Job",Job),
                           new SqlParameter("@ZipCode",ZipCode),
                            new SqlParameter("@Pets",Pets),
                            new SqlParameter("@Rebook",Rebook),
                            new SqlParameter("@FromRebook",FromRebook),
                            new SqlParameter("@New",New),
                            new SqlParameter("@TimeIn",TimeIn),
                            new SqlParameter("@TimeOut",TimeOut),
                            new SqlParameter("@PetTime",PetTime),
                            new SqlParameter("@ExtraServices",ExtraServices),
                            new SqlParameter("@Comments",comments),
                            new SqlParameter("@Drive_Time",driveTime),
                            new SqlParameter("@Pet_Time",rPetTime),
                            new SqlParameter("@FleaandTick22",FleaandTick22),
                            new SqlParameter("@FleaandTick44",FleaandTick44),
                            new SqlParameter("@FleaandTick88",FleaandTick88),
                            new SqlParameter("@FleaandTick132",FleaandTick132),
                            new SqlParameter("@FleaandTickCat",FleaandTickCat),
                            new SqlParameter("@TB",TB),
                            new SqlParameter("@Wham",Wham),
                            new SqlParameter("@RevenueCreditCard",RevenueCreditCard),
                            new SqlParameter("@RevenueCheck",RevenueCheck),
                            new SqlParameter("@RevenueCash",RevenueCash),
                            new SqlParameter("@RevenueInvoice",RevenueInvoice),
                            new SqlParameter("@RevenueCCY",RevenueCCY),
                            new SqlParameter("@TipCreditCard",TipCreditCard),
                            new SqlParameter("@TipCheck",TipCheck),
                            new SqlParameter("@TipCash",TipCash),
                            new SqlParameter("@TipInvoice",TipInvoice),
                            new SqlParameter("@PriorCreditCard",PriorCreditCard),
                            new SqlParameter("@PriorCheck",PriorCheck),
                            new SqlParameter("@PriorCash",PriorCash),
                            new SqlParameter("@CreditCardNo",CreditCardNo),
                            new SqlParameter("@CreditCardExpir",CreditCardExpir),
                            new SqlParameter("@CreditCardORChkName",CreditCardORChkName),
                            new SqlParameter("@CreditCardORChkAddr",CreditCardORChkAddr),
                            new SqlParameter("@SecurityCode",SecurityCode),
                            new SqlParameter("@NextAppointmentDate",NextAppointmentDate),
                            new SqlParameter("@NextAppointmentTime",NextAppointmentTime),
                            new SqlParameter("@NextAppointmentEndTime",NextAppointmentEndTime),
                            new SqlParameter("@ServicesForPet1",ServicesForPet1),
                            new SqlParameter("@ServicesForPet2",ServicesForPet2),
                            new SqlParameter("@ServicesForPet3",ServicesForPet3),
                            new SqlParameter("@ServicesForPet4",ServicesForPet4),
                            new SqlParameter("@ServicesForPet5",ServicesForPet5),
                            new SqlParameter("@ServicesForPet6",ServicesForPet6),
                            new SqlParameter("@AppointmentId",GroomerAppointmentId),
                            new SqlParameter("@Addedon",Convert.ToDateTime(@Addedon)),
                            new SqlParameter("@ProductPrice",ProductPrice),
                            new SqlParameter("@Salestax",Salestax),
                            new SqlParameter("@Rev01",Rev01),
                            new SqlParameter("@NameOnCheque",CustNameOnCheque),
                            new SqlParameter("@BankOnCheque",BankOnCheque),
                            new SqlParameter("@Srno", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Srno", DataRowVersion.Default, 0)});
        }
        catch
        {
            return 0;
        }
        DB.Dispose();
        return int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Srno"]).Value.ToString());
    }

    #region Reebok Not Rebook Details Submit in Daily Operation Log
    public int InsertDailyOperationLog(string GId, string VanId, string BeginningMileage, string TotlaHours,
        string EndingMileage, string FuelPurchased, string PricePerGallon, string CustomerName, string Job,
        string ZipCode, string Pets, string Rebook, string FromRebook, string New, string TimeIn, string TimeOut, string PetTime,
        string ExtraServices, string comments, string driveTime, string rPetTime,
        int FleaandTick22, int FleaandTick44, int FleaandTick88, int FleaandTick132, int FleaandTickCat, int TB, int Wham,
        double RevenueCreditCard, double RevenueCheck, double RevenueCash, double RevenueInvoice, double RevenueCCY,
        double TipCreditCard, double TipCheck, double TipCash, double TipInvoice,
        double PriorCreditCard, double PriorCheck, double PriorCash,
        string CreditCardNo, string CreditCardExpir,
        string CreditCardORChkName, string CreditCardORChkAddr, string SecurityCode,
        string NextAppointmentDate, string NextAppointmentTime, string NextAppointmentEndTime,
        string ServicesForPet1, string ServicesForPet2, string ServicesForPet3, string ServicesForPet4, string ServicesForPet5, string ServicesForPet6,
        int GroomerAppointmentId, string @Addedon, double ProductPrice, double Salestax, int Rev01, string CustNameOnCheque, string BankOnCheque)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("sp_InsertDailyOperationLog", new SqlParameter[] {
                           new SqlParameter("@GId",GId),
                           new SqlParameter("@VanId",VanId),
                           new SqlParameter("@BeginningMileage",BeginningMileage),
                           new SqlParameter("@TotlaHours",TotlaHours),
                           new SqlParameter("@EndingMileage",EndingMileage),
                           new SqlParameter("@FuelPurchased",FuelPurchased),
                           new SqlParameter("@PricePerGallon",PricePerGallon),
                           new SqlParameter("@CustomerName",CustomerName),
                           new SqlParameter("@Job",Job),
                           new SqlParameter("@ZipCode",ZipCode),
                            new SqlParameter("@Pets",Pets),
                            new SqlParameter("@Rebook",Rebook),
                            new SqlParameter("@FromRebook",FromRebook),
                            new SqlParameter("@New",New),
                            new SqlParameter("@TimeIn",TimeIn),
                            new SqlParameter("@TimeOut",TimeOut),
                            new SqlParameter("@PetTime",PetTime),
                            new SqlParameter("@ExtraServices",ExtraServices),
                            new SqlParameter("@Comments",comments),
                            new SqlParameter("@Drive_Time",driveTime),
                            new SqlParameter("@Pet_Time",rPetTime),
                            new SqlParameter("@FleaandTick22",FleaandTick22),
                            new SqlParameter("@FleaandTick44",FleaandTick44),
                            new SqlParameter("@FleaandTick88",FleaandTick88),
                            new SqlParameter("@FleaandTick132",FleaandTick132),
                            new SqlParameter("@FleaandTickCat",FleaandTickCat),
                            new SqlParameter("@TB",TB),
                            new SqlParameter("@Wham",Wham),
                            new SqlParameter("@RevenueCreditCard",RevenueCreditCard),
                            new SqlParameter("@RevenueCheck",RevenueCheck),
                            new SqlParameter("@RevenueCash",RevenueCash),
                            new SqlParameter("@RevenueInvoice",RevenueInvoice),
                            new SqlParameter("@RevenueCCY",RevenueCCY),
                            new SqlParameter("@TipCreditCard",TipCreditCard),
                            new SqlParameter("@TipCheck",TipCheck),
                            new SqlParameter("@TipCash",TipCash),
                            new SqlParameter("@TipInvoice",TipInvoice),
                            new SqlParameter("@PriorCreditCard",PriorCreditCard),
                            new SqlParameter("@PriorCheck",PriorCheck),
                            new SqlParameter("@PriorCash",PriorCash),
                            new SqlParameter("@CreditCardNo",CreditCardNo),
                            new SqlParameter("@CreditCardExpir",CreditCardExpir),
                            new SqlParameter("@CreditCardORChkName",CreditCardORChkName),
                            new SqlParameter("@CreditCardORChkAddr",CreditCardORChkAddr),
                            new SqlParameter("@SecurityCode",SecurityCode),
                            new SqlParameter("@NextAppointmentDate",NextAppointmentDate),
                            new SqlParameter("@NextAppointmentTime",NextAppointmentTime),
                            new SqlParameter("@NextAppointmentEndTime",NextAppointmentEndTime),
                            new SqlParameter("@ServicesForPet1",ServicesForPet1),
                            new SqlParameter("@ServicesForPet2",ServicesForPet2),
                            new SqlParameter("@ServicesForPet3",ServicesForPet3),
                            new SqlParameter("@ServicesForPet4",ServicesForPet4),
                            new SqlParameter("@ServicesForPet5",ServicesForPet5),
                            new SqlParameter("@ServicesForPet6",ServicesForPet6),
                            new SqlParameter("@AppointmentId",GroomerAppointmentId),
                            new SqlParameter("@Addedon",Convert.ToDateTime(@Addedon)),
                            new SqlParameter("@ProductPrice",ProductPrice),
                            new SqlParameter("@Salestax",Salestax),
                            new SqlParameter("@Rev01",Rev01),
                            new SqlParameter("@NameOnCheque",CustNameOnCheque),
                            new SqlParameter("@BankOnCheque",BankOnCheque),
                            new SqlParameter("@DailyLogId", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "DailyLogId", DataRowVersion.Default, 0)});
        }
        catch 
        {
            return 0;
        }
        DB.Dispose();
        return int.Parse(((SqlParameter)DB.LastCommand.Parameters["@DailyLogId"]).Value.ToString());


    }
    #endregion

    #region Update Groomer Appointment After Complete
    public void Modify_AppointmentStatus(int GroomerAppointmentId, int DailyLogId, int Flag1, int Flag2, string InTime, string OutTime)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("sp_Modify_AppointmentStatus", new SqlParameter[] {
                new SqlParameter("@AppointmentId", GroomerAppointmentId),
                new SqlParameter("@DailyLogId", DailyLogId),
                new SqlParameter("@Flag1", Flag1),
                 new SqlParameter("@Flag2", Flag2),
                  new SqlParameter("@InTime", InTime),
                   new SqlParameter("@OutTime", OutTime)
            });
        }
        catch
        {
        }
        DB.Dispose();
    }
    #endregion

    #region Insert Daily Log Details at appointment  Start of day and end of day
    public void insertParantFields(string @GID, string @VanId, string @BeginningMileage, string @TotlaHours, string @EndingMileage, string @FuelPurchased, string @PricePerGallon, string Addedon, string @flag, string @PfieldId, DateTime @FirstAppointmentDate)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("sp_ManageParantFields", new SqlParameter[] {
                           new SqlParameter("@GId", @GID),
                           new SqlParameter("@VanId", @VanId),
                           new SqlParameter("@BeginningMileage", @BeginningMileage),
                           new SqlParameter("@TotalHours", @TotlaHours),
                           new SqlParameter("@EndingMileage", @EndingMileage),
                           new SqlParameter("@FuelPurchased", @FuelPurchased),
                           new SqlParameter("@PricePerGallon",@PricePerGallon),
                           new SqlParameter("@Addedon",Convert.ToDateTime(@Addedon)),
                           new SqlParameter("@PfieldId",@PfieldId),
                           new SqlParameter("@flag",@flag),
                            new SqlParameter("@FirstAppointmentDate",@FirstAppointmentDate)
            });
        }
        catch 
        {
        }
        DB.Dispose();
    }
    #endregion
    public void UpdateParantFields(string @GID, string @TotlaHours, string @EndingMileage, int @PfieldId)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("sp_UpdateParantFieldsEndingMileage", new SqlParameter[] {
                           new SqlParameter("@GId", @GID),
                           new SqlParameter("@TotalHours", @TotlaHours),
                           new SqlParameter("@EndingMileage", @EndingMileage),
                           new SqlParameter("@PfieldId",@PfieldId),
                          });
        }
        catch
        {
        }
        DB.Dispose();
    }

    public DataSet GetgroomerTodaysAppointment(int GID, string AppointmentDate)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("GetgroomerTodaysAppointment", new SqlParameter[] { new SqlParameter("@GId", GID), new SqlParameter("@AppointmentDate", AppointmentDate) });
        }
        catch
        {
        }
        DB.Dispose();
        return DT;
    }

    //public void GroomerUpdatePresentedStatus(int GroomerAppointmentId)
    //{
    //    DBConnection DB = new DBConnection();
    //    try
    //    {
    //        DB.ExecuteNonQuery("GroomerUpdatePresentedStatus", new SqlParameter[] { new SqlParameter("@AppointmentId", GroomerAppointmentId) });
    //    }
    //    catch
    //    {
    //    }

    //    DB.Dispose();
    //}

    public void GroomerUpdateApptPresentedStatus(int GroomerAppointmentId, string LoggedInTime)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("GroomerUpdateApptPresentedStatus", new SqlParameter[] { new SqlParameter("@AppointmentId", GroomerAppointmentId), new SqlParameter("@PresentedTime", LoggedInTime) });
        }
        catch
        {
        }

        DB.Dispose();
    }

    public void GroomerUpdateApptSTimeETime(int GroomerAppointmentId, string STime, string ETime)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("sp_GroomerUpdateApptSTimeETime", new SqlParameter[]
            {
                new SqlParameter("@AppointmentId", GroomerAppointmentId),
                new SqlParameter("@StartTime", STime),
                 new SqlParameter("@EndTime", ETime)
            });
        }
        catch
        {

        }

        DB.Dispose();
    }


    #endregion
    public DataSet getGroomercurrentoperationlog(string @GID, string @DailyLogID)
    {
        DBConnection DB = new DBConnection();
        DataSet ds = new DataSet();
        try
        {
            ds = DB.ExecuteDataSet("getGroomercurrentoperationlog", new SqlParameter[] { new SqlParameter("@Gid", @GID), new SqlParameter("@DailyLogID", @DailyLogID) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return ds;
    }
    public DataSet getExcelData()
    {
        DBConnection DB = new DBConnection();
        DataSet ds = new DataSet();
        try
        {
            ds = DB.ExecuteDataSet("sp_getExcelData", new SqlParameter[] { new SqlParameter("@logid", "") });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return ds;
    }
    public DataSet GetUnlockExcelFileName()
    {
        DBConnection DB = new DBConnection();
        DataSet ds = new DataSet();
        try
        {
            ds = DB.ExecuteDataSet("GetUnlockExcelFileName", new SqlParameter[] { });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return ds;
    }
    public DataSet getGroomeroperationlogForEndingMileage(int @GID)
    {
        DBConnection DB = new DBConnection();
        DataSet ds = new DataSet();
        try
        {
            ds = DB.ExecuteDataSet("getGroomeroperationlogForEndingMileage", new SqlParameter[] { new SqlParameter("@Gid", @GID) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return ds;
    }

    #region 
    public void updateExcelExported(int DailyLogId, int Flag1, int Flag2)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("updateExcelExported", new SqlParameter[] { new SqlParameter("@DailyLogId", DailyLogId),
                new SqlParameter("@Flag1", Flag1),
                 new SqlParameter("@Flag2", Flag2)
            });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
    }
    #endregion
    public void InsertAppDate(int DLId)
    {
        try
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("InsertAppTxnDate", new SqlParameter[] { new SqlParameter("@DailyLogID", DLId) });
            DB.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void updateExcelExportedEndingMileage(int DailyLogId, int Flag)
    {
        try
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("updateExcelExportedEndingMileage", new SqlParameter[] { new SqlParameter("@DailyLogId", DailyLogId), new SqlParameter("@Flag", Flag) });
            DB.Dispose();
        }
        catch
        {
        }
    }

    public DataSet getGroomercurrentInventorylogForExport(int @GID, int @InvId)
    {
        DBConnection DB = new DBConnection();
        DataSet ds = new DataSet();
        try
        {
            ds = DB.ExecuteDataSet("getGroomercurrentInventorylogForExport", new SqlParameter[] { new SqlParameter("@Gid", @GID), new SqlParameter("@InvId", @InvId) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return ds;
    }
    public void updateExcelExportedInventory(int InvId, int Flag)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("updateExcelExportedInventory", new SqlParameter[] { new SqlParameter("@InvId", InvId), new SqlParameter("@Flag", Flag) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
    }
    public DataSet GetQueueExportdata()
    {
        DBConnection DB = new DBConnection();
        DataSet ds = new DataSet();
        try
        {
            ds = DB.ExecuteDataSet("GetQueueExportdata", new SqlParameter[] { });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return ds;
    }

    public void sp_GroomerData()
    {
        try
        {
            DBConnection db = new DBConnection();
            db.ExecuteNonQuery("sp_cybersourcedata", new SqlParameter[] { });
            db.Dispose();
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
    }

    //Dec2013
    public void UpdateLogIDInSyncApp(int LogID, int syncid)
    {
        DBConnection db = new DBConnection();
        db.ExecuteNonQuery("UpdateLogIdInSyncApp", new SqlParameter[]{
                 new SqlParameter("@logid",Convert.ToInt32(LogID)),
                 new SqlParameter("@syncid",Convert.ToInt32(syncid))
         });
        db.Dispose();
    }

    //Feb2014
    public void UpdateSyncCustName(int appid, string custname)
    {
        DBConnection db = new DBConnection();
        db.ExecuteNonQuery("UpdateSyncCustName", new SqlParameter[]{
                 new SqlParameter("@custEmail",custname),
                 new SqlParameter("@AppointmentID",appid)
         });
        db.Dispose();
    }

    public void UpdateLogID(int LogID, string recid)
    {
        DBConnection db = new DBConnection();
        db.ExecuteNonQuery("UpdatePaymentLogID", new SqlParameter[]{
                 new SqlParameter("@DailyLogID",Convert.ToInt32(LogID)),
                 new SqlParameter("@RecID",Convert.ToInt32(recid))
         });

        db.Dispose();
    }
    #region Next Rec Appointment
    public DataSet GetNextrecappdetails(int appid)
    {
        DBConnection DB = new DBConnection();
        DataSet ds = new DataSet();
        ds = DB.ExecuteDataSet("GetNextrecAppdetails", new SqlParameter[] { new SqlParameter("@AppointmentID", appid) });
        DB.Dispose();
        return ds;

    }
    #endregion
    //Jan2014
    public void UpdateNextGroomerAppointment(int GroomerAppointmentId, string AppointmentDate, string ExpStartTime, string ExpEndTime, string DateTimeFormat, decimal ExpPetTime)
    {
        DBConnection DB = new DBConnection();
        DB.ExecuteNonQuery("UpdateNextGroomerAppointment",
                           new SqlParameter[] {new SqlParameter("@AppointmentId",GroomerAppointmentId),
                           new SqlParameter("@AppointmentDate", AppointmentDate),
                           new SqlParameter("@ExpStartTime", ExpStartTime),
                           new SqlParameter("@ExpEndTime", ExpEndTime),
                           new SqlParameter("@DateTimeFormat", @DateTimeFormat),
                           new SqlParameter("@ExpPetTime", ExpPetTime)
        });
        DB.Dispose();
    }

    public DataSet VerifySyncAppPaymentDetails(int syncid)
    {
        DBConnection DB = new DBConnection();
        DataSet ds = new DataSet();
        ds = DB.ExecuteDataSet("VerifySyncAppPayment", new SqlParameter[] { new SqlParameter("@syncid", syncid) });
        DB.Dispose();
        return ds;
    }

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
            throw Ex;
        }
    }

    #region Sync rev to member profile 
    public int InsertSyncAppointment(int appid, int gid, string custname, string appString, string appdatetime, decimal revenueamt, decimal tipamt, decimal prioramt, decimal totalamt, string pstatus)
    {
        DBConnection db = new DBConnection();
        int Count = db.ExecuteNonQuery("InsertSyncAppDetails", new SqlParameter[]{
                           new SqlParameter("@apptid",appid),
                           new SqlParameter("@gid",gid),
                           new SqlParameter("@customername", custname),
                           new SqlParameter("@appString", appString),
                           new SqlParameter("@appDateTime", appdatetime),
                           new SqlParameter("@revenueamt",revenueamt),
                           new SqlParameter("@tipamt", tipamt),
                           new SqlParameter("@prioramt", prioramt),
                           new SqlParameter("@totalamt",totalamt),
                           new SqlParameter("@pstatus",pstatus),

                            new SqlParameter("@syncid", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "syncid", DataRowVersion.Default, 0)});
        db.Dispose();
        int syncid = int.Parse(((SqlParameter)db.LastCommand.Parameters["@syncid"]).Value.ToString());
        return syncid;
    }
    #endregion

    #region Cancel Sync Revenue and set admin revenue again
    public DataSet deleteSyncRevenu(int id, string RevAmtToSync, int GAppId)
    {
        DBConnection DB = new DBConnection();
        DataSet ds = new DataSet();
        ds = DB.ExecuteDataSet("DeleteSyncRevenue", new SqlParameter[] {
            new SqlParameter("@syncid", id),
            new SqlParameter("@RevAmtToSync",RevAmtToSync),
            new SqlParameter("@GAppId",GAppId)
        });
        DB.Dispose();
        return ds;
    }
    #endregion
    //April2014
    public DataSet getPrePayAppointmentDtls(int appid)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("sp_getPrePayAppointmentDtls", new SqlParameter[] { new SqlParameter("@AppointmentId", appid) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return DT;
    }
    //used to upadte payment info after redirect from cybersource pay page
    public void UpdatePrePayAppointmentDtls(int appid, double revamt, double prioramt, double tipamt, double totamt)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("UpdatePrepaymentAmount", new SqlParameter[] {
                new SqlParameter("@AppointmentId", appid),
                new SqlParameter("@RevAmt", revamt),
                 new SqlParameter("@PriorAmt", prioramt),
                  new SqlParameter("@TipAmt", tipamt),
                   new SqlParameter("@TotalAmt", (revamt+prioramt+tipamt)),
            });
        }
        catch
        {
        }
        DB.Dispose();
    }


    // Payment Sync

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

    public void GetShopperInfo(int GId, string FirstName, string LastName, string Address1, string City, string State, string Zip, string Country, string Phone, string Email
        , string CardType, string CreditCardNo, string ValidYear, string ValidMonth,
        string VerificationCode, decimal Payment_Amount, decimal SandH, decimal Tax, string ordno, int AppointmentId, string CCV)
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
         new SqlParameter("@Address1",Address1),
         new SqlParameter("@City",City),
         new SqlParameter("@State",State),
         new SqlParameter("@Zip",Zip),
         new SqlParameter("@Country",Country),
         new SqlParameter("@Phone",Phone),
         new SqlParameter("@Email",Email),
         new SqlParameter("@Cardtype",CardType),
         new SqlParameter("@CreditCardNo",Convert.ToInt64(cardno)),
         new SqlParameter("@ValidYear",ValidYear),
         new SqlParameter("@ValidMonth",ValidMonth),
         new SqlParameter("@VerificationCode",VerificationCode),
         new SqlParameter("@Payment_Amount",Payment_Amount),
         new SqlParameter("@SandH",SandH),
         new SqlParameter("@Tax",Tax),
         new SqlParameter("@OrdRefNo", ordno),
          new SqlParameter("@CCV", CCV),
         new SqlParameter("@AppointmentId",AppointmentId),
         new SqlParameter("@PayID",SqlDbType.Int,10,ParameterDirection.Output,true,0,0,"Payment_ID",DataRowVersion.Default,0)});
            int PaymentID = Convert.ToInt32(((SqlParameter)db.LastCommand.Parameters["@PayID"]).Value.ToString());
            HttpContext.Current.Session["PayID"] = PaymentID.ToString();
            db.Dispose();
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
    }

    public void GetCreditCardInfo(int GId, string CreditCardNo, string ValidYear, string ValidMonth, string VerificationCode)
    {
        DBConnection db = new DBConnection();
        db.ExecuteNonQuery("GetCreditCardInfo", new SqlParameter[]{
            new SqlParameter("@GID",GId),
            new SqlParameter("@CreditCardNo",CreditCardNo),
            new SqlParameter("@ValidYear",ValidYear),
            new SqlParameter("@ValidMonth",ValidMonth),
            new SqlParameter("@VerificationCode",VerificationCode)});
    }

    public bool CheckOrderRefNo(string OrdNumber)
    {
        bool OrdRefnoPresent = false;
        try
        {
            DBConnection DB = new DBConnection();
            //  string cmdstr = "Select OrderRefNumber from ShopperInfo_t where OrderRefNo='" + OrdNumber + "'";
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

    public DataSet GetAptdetails(int DailyLogId)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("sp_GetApttemplogdetails", new SqlParameter[] { new SqlParameter("@DailyLogId", DailyLogId) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return DT;
    }

    public DataSet GetAptdetailsforpayment(int DailyLogId)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("sp_GetAptlogdetailsforpay", new SqlParameter[] { new SqlParameter("@DailyLogId", DailyLogId) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return DT;
    }

    public DataSet GetSubmitOrder(int DailyLogId, int Gid)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("sp_SelectSubOrder", new SqlParameter[] { new SqlParameter("@DailyLogId", DailyLogId), new SqlParameter("@GId", Gid) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return DT;
    }

    public DataSet GetFinalPaymentInfo(int DailyLogId, int @Payment_ID)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("sp_FinalPaymentInfo", new SqlParameter[] { new SqlParameter("@Payment_ID", Payment_ID), new SqlParameter("@DailyLogId", DailyLogId) });
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
        return DT;
    }

    public void UpdatePaymentAmount(decimal Payment_Amount, decimal SandH, decimal Tax, int Payment_ID)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("sp_InserPaymentAmount", new SqlParameter[] {
                           new SqlParameter("@Payment_Amount", Payment_Amount),
                           new SqlParameter("@SandH", SandH),
                           new SqlParameter("@Tax", Tax),
                           new SqlParameter("@Payment_ID", Payment_ID)});
        }
        catch (Exception Ex)
        {
            string error = Ex.Message;
        }
        DB.Dispose();
    }

    #region get All Appointment Of a groomer of particular hour 
    public DataSet GetApptSchedules(string Apptdt, int time, int gid)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("sp_GetApptSchedules", new SqlParameter[] {
                new SqlParameter("@ApptDate", Apptdt),
                new SqlParameter("@TIME", time),
                new SqlParameter("@GID", gid)
            });
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        DB.Dispose();
        return DT;
    }

    #endregion

    #region update other tables details  here
    public int InsertAppointmentPrePayment(int userid, decimal revenueamt, decimal PriorAmt, decimal TipAmt, decimal TotalAmt, string payDescription, int PaymentId, int appid)
    {
        try
        {
            DBConnection db = new DBConnection();
            int Count = db.ExecuteNonQuery("InsertAppointmentPrePayment", new SqlParameter[]{
                           new SqlParameter("@UserId",userid),
                           new SqlParameter("@RevAmt",revenueamt),
                           new SqlParameter("@PriorAmt", PriorAmt),
                           new SqlParameter("@TipAmt",TipAmt),
                           new SqlParameter("@TotalAmt", TotalAmt),
                           new SqlParameter("@payDescription", payDescription),
                           new SqlParameter("@PaymentId",PaymentId),
                           new SqlParameter("@AppointmentId",appid),
                           new SqlParameter("@Addedon",System.DateTime.Now)
        });
            db.Dispose();
            return Count;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    public void UpdatePrePayStatus(int appid, string pstaus)
    {
        try
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdatePayStatusInGroomerApp", new SqlParameter[] {
                        new SqlParameter("@AppointmentId", appid),
                        new SqlParameter("@paidStatus", pstaus),
                        new SqlParameter("@IsMember", '0')
                      });
            DB.Dispose();
        }
        catch
        {

        }
    }

    #region Make RBK APpointment
    public void SetRBKAppointmentToMemberProfile(string UserEmail, int GAppId, DateTime nextDt, string st, string et, string MilitaryDateTime, string Revenue)
    {
        try
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("sp_SetRBKAppointmentToMemberProfile", new SqlParameter[] {
                new SqlParameter("@UserEmail", UserEmail),
                new SqlParameter("@GroomerAppointmentId",GAppId),
                        new SqlParameter("@nextDt", nextDt),
                        new SqlParameter("@st", st),
                        new SqlParameter("@et",et),
                        new SqlParameter("@MilitaryDateTime",MilitaryDateTime), new SqlParameter("@Revenue",Revenue)
                      });
            DB.Dispose();
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    //for operation log page if groomer appointment is not day first appointment
    public static DataSet GetTodaysDailyOperationLog(int Gid)
    {
        DBConnection DB = new DBConnection();
        DataSet DT = new DataSet();
        try
        {
            DT = DB.ExecuteDataSet("sp_GetTodaysDailyOperationLog", new SqlParameter[] {
                   new SqlParameter("@Gid", Gid)
            });
        }
        catch
        {
        }
        DB.Dispose();
        return DT;
    }


    #region  Update the start time of the Groomer Appointment
    public bool UpdateGroomerAppointmentStartDate(string appId, string startTime)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DB.ExecuteNonQuery("UpdateGroomerAppointmentStartTime", new SqlParameter[] {
                new SqlParameter("@AppointmentID", appId),
            new SqlParameter("@StartTime", startTime)
            });
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion


    #region  Update the End time of the Groomer Appointment
    public bool UpdateGroomerAppointmentEndDate(string appId, string endTime)
    {
        DBConnection DB = new DBConnection();
        try
        {
            DataSet dsAppointment = new DataSet();
            DB.ExecuteNonQuery("UpdateGroomerAppointmentEndTime", new SqlParameter[] {
                new SqlParameter("@AppointmentID", appId),
                new SqlParameter("@EndTime", endTime)
            });
            return true;
        }
        catch 
        {
            return false;
        }
    }
    #endregion


    #region Time Formatter
    public string Time24Formatter(string time)
    {
        DateTime format12 = Convert.ToDateTime(time);
        string format24 = format12.ToString("HH:mm", CultureInfo.CurrentCulture);
        return format24; ;
    }
    #endregion

}
