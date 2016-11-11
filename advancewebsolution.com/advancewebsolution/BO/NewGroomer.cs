using System;
using HicPicDataAccess;
using System.Data;
using System.Data.SqlClient;
using HicPicData;

namespace advancewebtosolution.BO
{
    public class NewGroomer
    {
        public NewGroomer()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet GetAllGroomers(string SearchFor, string SearchText)
        {

            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllGroomers", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }

        public DataSet DeleteGroomer(string GID)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteGroomer", new SqlParameter[] { new SqlParameter("@GID", GID) });
            DB.Dispose();
            return ds;
        }

        public int AddGroomer(string UserName, string Password, string Name, string Address, string HomePhone, string PersonalCellPhone, string ZipCode, string SheetName, string BaseCity, string State)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("AddGroomer", new SqlParameter[] { new SqlParameter("@UserName", UserName), new SqlParameter("@Password", Password),
                           new SqlParameter("@Name", Name),
                           new SqlParameter("@Address", Address),
                           new SqlParameter("@HomePhone", HomePhone),
                           new SqlParameter("@PersonalCellPhone", PersonalCellPhone),
                           new SqlParameter("@ZipCode", ZipCode),
                           new SqlParameter("@SheetName", SheetName),
                           new SqlParameter("@BaseCity",BaseCity),
                           new SqlParameter("@State",State),

        new SqlParameter("@GID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "GID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@GID"]).Value.ToString());
            return Count;
        }

        public DataSet GetGroomer(int GID)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomer", new SqlParameter[] { new SqlParameter("@GID", GID) });
            DB.Dispose();
            return ds;
        }
        public int UpdateGroomer(int GID, string UserName, string Name, string Address, string HomePhone, string PersonalCellPhone, string ZipCode, string BaseCity, string State, string SheetName)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("UpdateGroomer", new SqlParameter[] {new SqlParameter("@GID", GID), new SqlParameter("@UserName", UserName),
                           new SqlParameter("@Name", Name),
                           new SqlParameter("@Address", Address),
                           new SqlParameter("@HomePhone", HomePhone),
                           new SqlParameter("@PersonalCellPhone", PersonalCellPhone),
                           new SqlParameter("@ZipCode", ZipCode),
                            new SqlParameter("@BaseCity",BaseCity),
                           new SqlParameter("@State",State),
                           new SqlParameter("@SheetName",SheetName),

        new SqlParameter("@Return", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Return", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Return"]).Value.ToString());
            return Count;
        }

        public DataSet GetGroomersAppointment(DateTime AppointmentDate)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomersAppointment", new SqlParameter[] { new SqlParameter("@AppointmentDate", AppointmentDate) });
            DB.Dispose();
            return ds;
        }
        public int AddGroomerAppointment(int GID, string AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, int SequenceNo, decimal ExpPetTime)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("AddGroomerAppointment", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@AppointmentDate", AppointmentDate),
                           new SqlParameter("@StartTime", StartTime),
                           new SqlParameter("@EndTime", EndTime),
                           new SqlParameter("@ExpectedTotalRevenue", ExpectedTotalRevenue),
                           new SqlParameter("@Others", Others),
                           new SqlParameter("@DateTimeFormat", DateTimeFormat),
                           new SqlParameter("@SequenceNo", SequenceNo),
                           new SqlParameter("@ExpPetTime",ExpPetTime),
        new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
            return Count;
        }

        public DataSet GetGroomerDailyLogData(int GID, string Date)
        {
            NewDBConnection DB = new NewDBConnection();
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
            NewDBConnection DB = new NewDBConnection();
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
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomerMonthlyLogData", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@StartDate", StartDate), new SqlParameter("@EndDate", EndDate) });
            DB.Dispose();
            return ds;
        }

        public DataSet BindGroomers()
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("BindGroomers", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet GetGroomersdateappointment(int AppointmentId)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomersdateappointment", new SqlParameter[] { new SqlParameter("@AppointmentId", AppointmentId) });
            DB.Dispose();
            return ds;
        }

        public int UpdateGroomerAppointment(int AppointmentID, int GId, string AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, int SequenceNo, string DateTimeFormat, int Astatus, decimal ExpPetTime, bool Pstatus)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("UpdateGroomerAppointment", new SqlParameter[] {new SqlParameter("@AppointmentID", AppointmentID),new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", AppointmentDate),
                           new SqlParameter("@StartTime", StartTime),
                           new SqlParameter("@EndTime", EndTime),
                           new SqlParameter("@ExpectedTotalRevenue", ExpectedTotalRevenue),
                           new SqlParameter("@Others", Others),
                           new SqlParameter("@SequenceNo", SequenceNo),
                           new SqlParameter("@DateTimeFormat", @DateTimeFormat),
                           new SqlParameter("@Astatus", Astatus),
                           new SqlParameter("@ExpPetTime",ExpPetTime),
                           new SqlParameter("@Pstatus",Pstatus),


         new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
            return Count;
        }

        public DataSet GetGroomersSequence(string AppointmentDate, int AppointmentId, int GId)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomersSequence", new SqlParameter[] { new SqlParameter("@AppointmentDate", AppointmentDate), new SqlParameter("@AppointmentId", AppointmentId), new SqlParameter("@GId", GId) });
            DB.Dispose();
            return ds;
        }

        public DataSet DeleteGroomerAppointment(int AppointmentId)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteGroomerAppointment", new SqlParameter[] { new SqlParameter("@AppointmentId", @AppointmentId) });
            DB.Dispose();
            return ds;
        }

        public int AssignGroomerAppointment(int GID, string AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, int SequenceNo, decimal ExpPetTime)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("AssignGroomerAppointment", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@AppointmentDate", AppointmentDate),
                           new SqlParameter("@StartTime", StartTime),
                           new SqlParameter("@EndTime", EndTime),
                           new SqlParameter("@ExpectedTotalRevenue", ExpectedTotalRevenue),
                           new SqlParameter("@Others", Others),
                           new SqlParameter("@DateTimeFormat", DateTimeFormat),
                           new SqlParameter("@SequenceNo", SequenceNo),
                           new SqlParameter("@ExpPetTime",ExpPetTime),


        new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
            return Count;
        }

        public DataSet GetGroomersSequenceforUpdate(int GId, string AppointmentDate)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomersSequenceforUpdate", new SqlParameter[] { new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", AppointmentDate) });
            DB.Dispose();
            return ds;
        }

        public DataSet UpdateGroomerSequence(int GID, string AppointmentDate, int SequenceNo, int AppointmentId)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("UpdateGroomerSequence", new SqlParameter[] { new SqlParameter("@GID", GID), new SqlParameter("@AppointmentDate", AppointmentDate), new SqlParameter("@SequenceNo", SequenceNo), new SqlParameter("@AppointmentId", AppointmentId) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetPreviousGroomersSequenceforUpdate(int GId, string AppointmentDate)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPreviousGroomersSequenceforUpdate", new SqlParameter[] { new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", AppointmentDate) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetPreviousGroomersSequenceforUpdate1(int GId, string AppointmentDate)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPreviousGroomersSequenceforUpdate1", new SqlParameter[] { new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", AppointmentDate) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetMaxSequencenoOfGroomer(int GId, string AppointmentDate)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetMaxSequencenoOfGroomer", new SqlParameter[] { new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", AppointmentDate) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetGroomerNextsequenceForupdate(int GId, string AppointmentDate, int Sequence)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomerNextsequenceForupdate", new SqlParameter[] { new SqlParameter("@GId", GId), new SqlParameter("@AppointmentDate", AppointmentDate), new SqlParameter("@Sequence", Sequence) });
            DB.Dispose();
            return ds;
        }
        public void ChangeGroomerAppointmentStatus(string AppointmentId)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("ChangeGroomerAppointmentStatus", new SqlParameter[] { new SqlParameter("@AppointmentId", @AppointmentId) });
            DB.Dispose();
        }

        #region added for Groomer Excel Export
        public void EditExcel(string VanId, string BeginningMileage, string TotlaHours, string EndingMileage, string FuelPurchased, string PricePerGallon, string CustomerName, string Job, string ZipCode, string Pets, string Rebook, string FromRebook, string New, string TimeIn, string TimeOut, string PetTime, string ExtraServices, string FleaandTick22, string FleaandTick44, string FleaandTick88, string FleaandTick132, string FleaandTickCat, string TB, string Wham, string RevenueCreditCard, string RevenueCheck, string RevenueCash, string RevenueInvoice, string TipCreditCard, string TipCheck, string TipCash, string TipInvoice, string PriorCreditCard, string PriorCheck, string PriorCash, string NextAppointmentDate, string NextAppointmentTime, string ServicesForPet, string Addedon, string FleaTick22, string FleaTick44, string FleaTick88, string FleaTick132, string FleaTickcAT, string Toothbrushes, string WhamInv, string Towels, string CottonPads, string CottonSwabs, string PaperTowels, string GarbageBags, string Treats, string VetWrap, string Wipes, string QuickStop, string LiquidBandaid, string Envelopes, string Receipts, string BusinessCards, string BladesSharpened, string ScissorsSharpened, string SunGuard, string EZShed, string EZDematt, string SkunkKit, string Other, string ProductPrice, string SalesTax, string Rev01, string CreditCardNo, string CreditCardExpir, string CreditCardName, string CreditCardAddr, string SecurityCode, string Other1,
            string Other2, string Other3, string Other4, string Other5, string Marketing1, string Marketing2, string Marketing3, string Marketing4, string Marketing5, string Liquid1, string Liquid2, string Liquid3, string Liquid4, string Liquid5, string Liquid6, string Liquid7, string Liquid8, string Liquid9, string Liquid10, string Liquid11, string Liquid12, string Liquid13, string Liquid14, string Liquid15, string Liquid16, string Liquid17, string Liquid18, string Liquid19, string Liquid20, string Liquid21, string Liquid22, string Liquid23, string Liquid24, string Liquid25)
        {
            string TEMP = (VanId + "," + BeginningMileage + "," + TotlaHours + "," + EndingMileage + "," + FuelPurchased + "," + PricePerGallon + "," + CustomerName + "," + Job + "," + ZipCode + "," + Pets + "," + Rebook + "," + FromRebook + "," + New + "," + TimeIn + "," + TimeOut + "," + PetTime + "," + ExtraServices + "," + FleaandTick22 + "," + FleaandTick44 + "," + FleaandTick88 + "," + FleaandTick132 + "," + FleaandTickCat + "," + TB + "," + Wham + "," + RevenueCreditCard + "," + RevenueCheck + "," + RevenueCash + "," + RevenueInvoice + "," + TipCreditCard + "," + TipCheck + "," + TipCash + "," + TipInvoice + "," + PriorCreditCard + "," + PriorCheck + "," + PriorCash + "," + NextAppointmentDate + "," + NextAppointmentTime + "," + ServicesForPet + "," + Addedon + "," + FleaTick22 + "," + FleaTick44 + "," + FleaTick88 + "," + FleaTick132 + "," + FleaTickcAT + "," + Toothbrushes + "," + WhamInv + "," + Towels + "," + CottonPads + "," + CottonSwabs + "," + PaperTowels + "," + GarbageBags + "," + Treats + "," + VetWrap + "," + Wipes + "," + QuickStop + "," + LiquidBandaid + "," + Envelopes + "," + Receipts + "," + BusinessCards + "," + BladesSharpened + "," + ScissorsSharpened + "," + SunGuard + "," + EZShed + "," + EZDematt + "," + SkunkKit + "," + Other);
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("sp_ManageExcel", new SqlParameter[] {
             new SqlParameter("@VanId" ,VanId),new SqlParameter("@BeginningMileage" ,BeginningMileage),
    new SqlParameter("@TotlaHours" ,TotlaHours),new SqlParameter("@EndingMileage" ,EndingMileage),
    new SqlParameter("@FuelPurchased" ,FuelPurchased),new SqlParameter("@PricePerGallon" ,PricePerGallon),
    new SqlParameter("@CustomerName" ,CustomerName),new SqlParameter("@Job" ,Job),new SqlParameter("@ZipCode" ,ZipCode),new SqlParameter("@Pets ",Pets),
    new SqlParameter("@Rebook" ,Rebook),new SqlParameter("@FromRebook" ,FromRebook),new SqlParameter("@New" ,New),
    new SqlParameter("@TimeIn" ,TimeIn),new SqlParameter("@TimeOut" ,TimeOut),new SqlParameter("@PetTime" ,PetTime),
    new SqlParameter("@ExtraServices" ,ExtraServices),new SqlParameter("@FleaandTick22" ,FleaandTick22),
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
                                                   new SqlParameter("@Liquid25",Liquid25)


         });
            DB.Dispose();

        }

        public DataSet getExcelData()
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_getExcelData", new SqlParameter[] { new SqlParameter("@logid", "") });
            DB.Dispose();
            return ds;
        }

        public DataSet getDailyOperatrionLog(string @GID, string @DailyLogID)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_getDailyOperatrionLog", new SqlParameter[] { new SqlParameter("@Gid", @GID), new SqlParameter("@DailyLogID", @DailyLogID) });
            DB.Dispose();
            return ds;
        }

        public void ModifyExportFlag(string DailylogId, int ExcelRowId)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("sp_UpdateExportToExcelFlag", new SqlParameter[] { new SqlParameter("@DailylogId", @DailylogId), new SqlParameter("@ExcelRowId", ExcelRowId) });
            DB.Dispose();
        }

        public DataSet GroomerOperationToExport(string Gid)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GroomerOperationToExport", new SqlParameter[] { new SqlParameter("@Gid", @Gid) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetGroomerAppointmentDetails(int DailyLogID)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetGroomerAppointmentDetails", new SqlParameter[] { new SqlParameter("@DailyLogID", DailyLogID) });
            DB.Dispose();
            return ds;
        }
        public DataSet DeleteOldGroomerAppointment(DateTime AppointmentDate, DateTime Enddate)
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteOldGroomerAppointment", new SqlParameter[] { new SqlParameter("@AppointmentDate", AppointmentDate), new SqlParameter("@Enddate", Enddate) });
            DB.Dispose();
            return ds;
        }

        public void UpdateExcelFileStatus(string FID)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("UpdateExcelFileStatus", new SqlParameter[] { new SqlParameter("@FID", FID) });
            DB.Dispose();
        }

        public DataSet GetExcelFileName()
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetExcelFileName", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public DataSet GetUnlockExcelFileName()
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUnlockExcelFileName", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public void AddExcelFile(string FileName)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("AddExcelFile", new SqlParameter[] {
        new SqlParameter("@FileName", FileName)

        });
            DB.Dispose();
        }

        public void DeleteExcelFile(string FileName)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("DeleteExcelFile", new SqlParameter[] { new SqlParameter("@FileName", FileName) });
            DB.Dispose();
        }

        public void UpdateExcelFileStatusUnlock(string FID)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("UpdateExcelFileStatusUnlock", new SqlParameter[] { new SqlParameter("@FID", FID) });
            DB.Dispose();
        }

        public void updateExcelExported(int DailyLogId, int Flag)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("updateExcelExported", new SqlParameter[] { new SqlParameter("@DailyLogId", DailyLogId), new SqlParameter("@Flag", Flag) });
            DB.Dispose();
        }
        public void updateExcelExportedEndingMileage(int DailyLogId, int Flag)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("updateExcelExportedEndingMileage", new SqlParameter[] { new SqlParameter("@DailyLogId", DailyLogId), new SqlParameter("@Flag", Flag) });
            DB.Dispose();
        }

        public DataSet GetUuExportedgroomerlogdata()
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUuExportedgroomerlogdata", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public DataSet GetUnExportedgroomerInventorydata()
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUnExportedgroomerInventorydata", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public DataSet GetUuExportedgroomerlogdataEndingM()
        {
            NewDBConnection DB = new NewDBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUuExportedgroomerlogdataEndingM", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public void updateExcelExportedInventory(int InvId, int Flag)
        {
            NewDBConnection DB = new NewDBConnection();
            DB.ExecuteNonQuery("updateExcelExportedInventory", new SqlParameter[] { new SqlParameter("@InvId", InvId), new SqlParameter("@Flag", Flag) });
            DB.Dispose();
        }
        #endregion
    }
}