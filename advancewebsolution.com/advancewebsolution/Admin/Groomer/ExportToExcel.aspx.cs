using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;
using advancewebtosolution.BO;
    public partial class Admin_Groomer_ExportToExcel : System.Web.UI.Page
    {
        private Excel.Application excelApp = new Excel.Application();
        Groomer ObjGroomer = new Groomer();
        DataSet dsEx;
        string strdate = String.Empty, strSelDate = "";
        string flagSuccMsg = "";
        int secRow = 0, data_row = 0;
        string strDailyLogID = "";

        public string VanId, BeginningMileage, TotlaHours, EndingMileage, FuelPurchased, PricePerGallon, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham, RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, NextAppointmentDate, NextAppointmentTime, ServicesForPet, Addedon, FleaTick22, FleaTick44, FleaTick88, FleaTick132, FleaTickcAT, Toothbrushes, WhamInv, Towels, CottonPads, CottonSwabs, PaperTowels, GarbageBags, Treats, VetWrap, Wipes, QuickStop, LiquidBandaid, Envelopes, Receipts, BusinessCards, BladesSharpened, ScissorsSharpened, SunGuard, EZShed, EZDematt, SkunkKit, Other, ProductPrice, SalesTax, Rev01, CreditCardNo, CreditCardExpir, CreditCardName, CreditCardAddr, SecurityCode;
        public string VanId_Data, BeginningMileage_Data, TotlaHours_Data, EndingMileage_Data, FuelPurchased_Data, PricePerGallon_Data, CustomerName_Data, Job_Data, ZipCode_Data, Pets_Data, Rebook_Data, FromRebook_Data, New_Data, TimeIn_Data, TimeOut_Data, PetTime_Data, ExtraServices_Data, FleaandTick22_Data, FleaandTick44_Data, FleaandTick88_Data, FleaandTick132_Data, FleaandTickCat_Data, TB_Data, Wham_Data, RevenueCreditCard_Data, RevenueCheck_Data, RevenueCash_Data, RevenueInvoice_Data, TipCreditCard_Data, TipCheck_Data, TipCash_Data, TipInvoice_Data, PriorCreditCard_Data, PriorCheck_Data, PriorCash_Data, NextAppointmentDate_Data, NextAppointmentTime_Data, ServicesForPet_Data, Addedon_Data, FleaTick22_Data, FleaTick44_Data, FleaTick88_Data, FleaTick132_Data, FleaTickcAT_Data, Toothbrushes_Data, WhamInv_Data, Towels_Data, CottonPads_Data, CottonSwabs_Data, PaperTowels_Data, GarbageBags_Data, Treats_Data, VetWrap_Data, Wipes_Data, QuickStop_Data, LiquidBandaid_Data, Envelopes_Data, Receipts_Data, BusinessCards_Data, BladesSharpened_Data, ScissorsSharpened_Data, SunGuard_Data, EZShed_Data, EZDematt_Data, SkunkKit_Data, Other_Data, ProductPrice_Data, SalesTax_Data, Rev01_Data, CreditCardNo_Data, CreditCardExpir_Data, CreditCardName_Data, CreditCardAddr_Data, SecurityCode_Data, DailylogId, ExcelRowId;
        public string Other1, Other2, Other3, Other4, Other5, Marketing1, Marketing2, Marketing3, Marketing4, Marketing5, Liquid1, Liquid2, Liquid3, Liquid4, Liquid5, Liquid6, Liquid7, Liquid8, Liquid9, Liquid10, Liquid11, Liquid12, Liquid13, Liquid14, Liquid15, Liquid16, Liquid17, Liquid18, Liquid19, Liquid20, Liquid21, Liquid22, Liquid23, Liquid24, Liquid25;
        string ExcelFilePath = "";
        string ExistsExcelFilePath1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ExcelFilePath = System.Configuration.ConfigurationManager.AppSettings["ExcelFile"].ToString();
            GetServerExcelFilePath();
            if (!IsPostBack)
            {
                txtStartDate.Text = DateTime.Now.Date.ToShortDateString();
                BindGroomersDDL();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

            strDailyLogID = Utility.GetCheckedRow(GrdUsers, "chkSelect");
            if (strDailyLogID != "")
            {
                ExportToExcelNew(ddlGroomerlist.SelectedValue, txtStartDate.Text.Trim(), strDailyLogID);
            }

        }

        #region Export groomers details in excel

        public string getMonth(string mon)
        {
            if (mon == "1") { return "January"; }
            else if (mon == "2") { return "February"; }
            else if (mon == "3") { return "March"; }
            else if (mon == "4") { return "April"; }
            else if (mon == "5") { return "May"; }
            else if (mon == "6") { return "June"; }
            else if (mon == "7") { return "July"; }
            else if (mon == "8") { return "August"; }
            else if (mon == "9") { return "September"; }
            else if (mon == "10") { return "October"; }
            else if (mon == "11") { return "November"; }
            else if (mon == "12") { return "December"; }
            return "";
        }

        public void ExportToExcelNew(string GID, string strDate, string DailyLogID)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(strDate);
                strSelDate = getMonth(dt.Month.ToString()) + " " + dt.Day + "," + " " + dt.Year;

                getCell();
                object missing = System.Reflection.Missing.Value;

                //Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(@"D:\\Monthly4", 0, false, 5, "albhistar1", "albhistar1", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(ExistsExcelFilePath1, 0, false, 5, "albhistar1", "albhistar1", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);

                Excel.Range range = null;
                dsEx = ObjGroomer.getDailyOperatrionLog(GID, DailyLogID);

                //excelApp.Visible = false;
                //Excel.Sheets excelSheets = excelWorkBook.Worksheets;
                //Excel.Worksheet excelSheet = (Excel.Worksheet)excelSheets.get_Item(dsEx.Tables[0].Rows[0]["SheetName"].ToString());
                int numSheets = excelWorkBook.Sheets.Count;
                excelApp.Visible = false;
                Excel.Worksheet excelSheet = new Microsoft.Office.Interop.Excel.Worksheet();
                Excel.Sheets excelSheets = excelWorkBook.Worksheets;
                // Iterate through the sheets. They are indexed starting at 1.
                // bool checkSheet = false;
                for (int sheetNum = 1; sheetNum < numSheets; sheetNum++)
                {

                    excelSheet = (Excel.Worksheet)excelSheets.get_Item(sheetNum);
                    string strWorksheetName = excelSheet.Name;
                    if (strWorksheetName == dsEx.Tables[0].Rows[0]["SheetName"].ToString())
                    {
                        excelSheet = (Excel.Worksheet)excelSheets.get_Item(dsEx.Tables[0].Rows[0]["SheetName"].ToString());

                        if (dsEx.Tables[0].Rows.Count > 0)
                        {

                            NextRow:
                            for (int m = data_row; m < dsEx.Tables[0].Rows.Count; m++)
                            {
                                getDailyOperationLog(m, GID, DailyLogID, dsEx);
                                #region writing in excel

                                #region export to  Parant cell
                                if (excelSheet != null)
                                {
                                    //Response.Write(VanId);
                                    range = excelSheet.get_Range(VanId, VanId);
                                    excelSheet.get_Range(VanId, VanId).Value2 = VanId_Data;
                                }
                                #endregion

                                //for (int r = 8; r < excelSheet.Rows.Count; r = r + 12)
                                //{
                                for (int r = 8; r < 381; r = r + 12)
                                {
                                    range = excelSheet.get_Range("B" + r, "B" + r);
                                    strdate = excelSheet.get_Range("B" + r, "B" + r).Text.ToString();
                                    if (strdate == string.Empty)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        //if (strdate == "November 1, 2009")
                                        if (strdate == strSelDate)
                                        {
                                            //starting row = r.ToString();
                                            secRow = r + 2;

                                            excelSheet.get_Range(BeginningMileage + r, BeginningMileage + r).Value2 = BeginningMileage_Data;
                                            excelSheet.get_Range(TotlaHours + r, TotlaHours + r).Value2 = TotlaHours_Data;
                                            excelSheet.get_Range(EndingMileage + r, EndingMileage + r).Value2 = EndingMileage_Data;
                                            excelSheet.get_Range(FuelPurchased + r, FuelPurchased + r).Value2 = FuelPurchased_Data;
                                            excelSheet.get_Range(PricePerGallon + r, PricePerGallon + r).Value2 = PricePerGallon_Data;

                                            #region export to  secondary cell
                                            for (int k = secRow; k < (secRow + 10); k++)
                                            {

                                                range = excelSheet.get_Range("A" + k, "A" + k);
                                                //check if job is null
                                                if (range != null)
                                                {
                                                    if (excelSheet.get_Range("A" + k, "A" + k).Text.ToString() == string.Empty)
                                                    {
                                                        #region fileds
                                                        excelSheet.get_Range(Job + k, Job + k).Value2 = Job_Data;
                                                        excelSheet.get_Range(CustomerName + k, CustomerName + k).Value2 = CustomerName_Data;
                                                        excelSheet.get_Range(ZipCode + k, ZipCode + k).Value2 = ZipCode_Data;
                                                        excelSheet.get_Range(Pets + k, Pets + k).Value2 = Pets_Data;
                                                        excelSheet.get_Range(Rebook + k, Rebook + k).Value2 = Rebook_Data;
                                                        excelSheet.get_Range(NextAppointmentDate + k, NextAppointmentDate + k).Value2 = NextAppointmentDate_Data + "," + NextAppointmentTime_Data + "," + ServicesForPet_Data;
                                                        excelSheet.get_Range(FromRebook + k, FromRebook + k).Value2 = FromRebook_Data;
                                                        excelSheet.get_Range(New + k, New + k).Value2 = New_Data;
                                                        excelSheet.get_Range(PetTime + k, PetTime + k).Value2 = PetTime_Data;
                                                        excelSheet.get_Range(ExtraServices + k, ExtraServices + k).Value2 = ExtraServices_Data;
                                                        excelSheet.get_Range(FleaandTick22 + k, FleaandTick22 + k).Value2 = FleaandTick22_Data;
                                                        excelSheet.get_Range(FleaandTick44 + k, FleaandTick44 + k).Value2 = FleaandTick44_Data;
                                                        excelSheet.get_Range(FleaandTick88 + k, FleaandTick88 + k).Value2 = FleaandTick88_Data;
                                                        excelSheet.get_Range(FleaandTick132 + k, FleaandTick132 + k).Value2 = FleaandTick132_Data;
                                                        excelSheet.get_Range(FleaandTickCat + k, FleaandTickCat + k).Value2 = FleaandTickCat_Data;
                                                        excelSheet.get_Range(TB + k, TB + k).Value2 = TB_Data;
                                                        excelSheet.get_Range(Wham + k, Wham + k).Value2 = Wham_Data;
                                                        #endregion
                                                        #region revenue 7 cells
                                                        excelSheet.get_Range(RevenueCreditCard + k, RevenueCreditCard + k).Value2 = RevenueCreditCard_Data;
                                                        excelSheet.get_Range(RevenueCheck + k, RevenueCheck + k).Value2 = RevenueCheck_Data;
                                                        excelSheet.get_Range(RevenueCash + k, RevenueCash + k).Value2 = RevenueCash_Data;
                                                        excelSheet.get_Range(RevenueInvoice + k, RevenueInvoice + k).Value2 = RevenueInvoice_Data;
                                                        //no data field found
                                                        //excelSheet.get_Range(ProductPrice + k, ProductPrice + k).Value2 = ProductPrice_Data;
                                                        //excelSheet.get_Range(SalesTax + k, SalesTax + k).Value2 = SalesTax_Data;
                                                        //excelSheet.get_Range(Rev01 + k, Rev01 + k).Value2 = Rev01_Data;
                                                        #endregion
                                                        #region Tip 4 cells
                                                        excelSheet.get_Range(TipCreditCard + k, TipCreditCard + k).Value2 = TipCreditCard_Data;
                                                        excelSheet.get_Range(TipCheck + k, TipCheck + k).Value2 = TipCheck_Data;
                                                        excelSheet.get_Range(TipCash + k, TipCash + k).Value2 = TipCash_Data;
                                                        excelSheet.get_Range(TipInvoice + k, TipInvoice + k).Value2 = TipInvoice_Data;
                                                        #endregion
                                                        #region Prior Revenue 8 cells
                                                        excelSheet.get_Range(PriorCreditCard + k, PriorCreditCard + k).Value2 = PriorCreditCard_Data;
                                                        excelSheet.get_Range(PriorCheck + k, PriorCheck + k).Value2 = PriorCheck_Data;
                                                        excelSheet.get_Range(PriorCash + k, PriorCash + k).Value2 = PriorCash_Data;

                                                        excelSheet.get_Range(CreditCardNo + k, CreditCardNo + k).Value2 = CreditCardNo_Data;
                                                        excelSheet.get_Range(CreditCardExpir + k, CreditCardExpir + k).Value2 = CreditCardExpir_Data;
                                                        excelSheet.get_Range(CreditCardName + k, CreditCardName + k).Value2 = CreditCardName_Data;
                                                        excelSheet.get_Range(CreditCardAddr + k, CreditCardAddr + k).Value2 = CreditCardAddr_Data;
                                                        excelSheet.get_Range(SecurityCode + k, SecurityCode + k).Value2 = SecurityCode_Data;
                                                        /* * */
                                                        #endregion
                                                        #region Inventory 27 cell
                                                        excelSheet.get_Range(FleaTick22 + k, FleaTick22 + k).Value2 = FleaTick22_Data;
                                                        excelSheet.get_Range(FleaTick44 + k, FleaTick44 + k).Value2 = FleaTick44_Data;
                                                        excelSheet.get_Range(FleaTick88 + k, FleaTick88 + k).Value2 = FleaTick88_Data;
                                                        excelSheet.get_Range(FleaTick132 + k, FleaTick132 + k).Value2 = FleaTick132_Data;
                                                        excelSheet.get_Range(FleaTickcAT + k, FleaTickcAT + k).Value2 = FleaTickcAT_Data;

                                                        excelSheet.get_Range(Toothbrushes + k, Toothbrushes + k).Value2 = Toothbrushes_Data;
                                                        excelSheet.get_Range(WhamInv + k, WhamInv + k).Value2 = WhamInv_Data;
                                                        excelSheet.get_Range(Towels + k, Towels + k).Value2 = Towels_Data;
                                                        //excelSheet.get_Range(CottonPads + k, CottonPads + k).Value2 = CottonPads_Data;
                                                        //excelSheet.get_Range(CottonSwabs + k, CottonSwabs + k).Value2 = CottonSwabs_Data;

                                                        excelSheet.get_Range(PaperTowels + k, PaperTowels + k).Value2 = PaperTowels_Data;
                                                        excelSheet.get_Range(GarbageBags + k, GarbageBags + k).Value2 = GarbageBags_Data;
                                                        excelSheet.get_Range(Treats + k, Treats + k).Value2 = Treats_Data;
                                                        excelSheet.get_Range(VetWrap + k, VetWrap + k).Value2 = VetWrap_Data;
                                                        excelSheet.get_Range(Wipes + k, Wipes + k).Value2 = Wipes_Data;

                                                        //excelSheet.get_Range(QuickStop + k, QuickStop + k).Value2 = QuickStop_Data;
                                                        //excelSheet.get_Range(LiquidBandaid + k, LiquidBandaid + k).Value2 = LiquidBandaid_Data;
                                                        //excelSheet.get_Range(Envelopes + k, Envelopes + k).Value2 = Envelopes_Data;
                                                        //excelSheet.get_Range(Receipts + k, Receipts + k).Value2 = Receipts_Data;
                                                        //excelSheet.get_Range(BusinessCards + k, BusinessCards + k).Value2 = BusinessCards_Data;

                                                        //excelSheet.get_Range(BladesSharpened + k, BladesSharpened + k).Value2 = BladesSharpened_Data;
                                                        //excelSheet.get_Range(ScissorsSharpened + k, ScissorsSharpened + k).Value2 = ScissorsSharpened_Data;
                                                        //excelSheet.get_Range(SunGuard + k, SunGuard + k).Value2 = SunGuard_Data;
                                                        //excelSheet.get_Range(EZShed + k, EZShed + k).Value2 = EZShed_Data;
                                                        //excelSheet.get_Range(EZDematt + k, EZDematt + k).Value2 = EZDematt_Data;

                                                        //excelSheet.get_Range(SkunkKit + k, SkunkKit + k).Value2 = SkunkKit_Data;
                                                        //excelSheet.get_Range(Other + k, Other + k).Value2 = Other_Data; ;
                                                        #endregion
                                                        //break;
                                                        data_row = m + 1;
                                                        flagSuccMsg = "S";
                                                        ObjGroomer.ModifyExportFlag(DailylogId, k);
                                                        goto NextRow;

                                                    }
                                                    else
                                                    {
                                                        if (ExcelRowId == k.ToString())
                                                        {
                                                            #region overwrite transation
                                                            #region fileds
                                                            excelSheet.get_Range(Job + k, Job + k).Value2 = Job_Data;
                                                            excelSheet.get_Range(CustomerName + k, CustomerName + k).Value2 = CustomerName_Data;
                                                            excelSheet.get_Range(ZipCode + k, ZipCode + k).Value2 = ZipCode_Data;
                                                            excelSheet.get_Range(Pets + k, Pets + k).Value2 = Pets_Data;
                                                            excelSheet.get_Range(Rebook + k, Rebook + k).Value2 = Rebook_Data;
                                                            excelSheet.get_Range(NextAppointmentDate + k, NextAppointmentDate + k).Value2 = NextAppointmentDate_Data + "," + NextAppointmentTime_Data + "," + ServicesForPet_Data;
                                                            excelSheet.get_Range(FromRebook + k, FromRebook + k).Value2 = FromRebook_Data;
                                                            excelSheet.get_Range(New + k, New + k).Value2 = New_Data;
                                                            excelSheet.get_Range(PetTime + k, PetTime + k).Value2 = PetTime_Data;
                                                            excelSheet.get_Range(ExtraServices + k, ExtraServices + k).Value2 = ExtraServices_Data;
                                                            excelSheet.get_Range(FleaandTick22 + k, FleaandTick22 + k).Value2 = FleaandTick22_Data;
                                                            excelSheet.get_Range(FleaandTick44 + k, FleaandTick44 + k).Value2 = FleaandTick44_Data;
                                                            excelSheet.get_Range(FleaandTick88 + k, FleaandTick88 + k).Value2 = FleaandTick88_Data;
                                                            excelSheet.get_Range(FleaandTick132 + k, FleaandTick132 + k).Value2 = FleaandTick132_Data;
                                                            excelSheet.get_Range(FleaandTickCat + k, FleaandTickCat + k).Value2 = FleaandTickCat_Data;
                                                            excelSheet.get_Range(TB + k, TB + k).Value2 = TB_Data;
                                                            excelSheet.get_Range(Wham + k, Wham + k).Value2 = Wham_Data;
                                                            #endregion
                                                            #region revenue 7 cells
                                                            excelSheet.get_Range(RevenueCreditCard + k, RevenueCreditCard + k).Value2 = RevenueCreditCard_Data;
                                                            excelSheet.get_Range(RevenueCheck + k, RevenueCheck + k).Value2 = RevenueCheck_Data;
                                                            excelSheet.get_Range(RevenueCash + k, RevenueCash + k).Value2 = RevenueCash_Data;
                                                            excelSheet.get_Range(RevenueInvoice + k, RevenueInvoice + k).Value2 = RevenueInvoice_Data;
                                                            //no data field found
                                                            //excelSheet.get_Range(ProductPrice + k, ProductPrice + k).Value2 = ProductPrice_Data;
                                                            //excelSheet.get_Range(SalesTax + k, SalesTax + k).Value2 = SalesTax_Data;
                                                            //excelSheet.get_Range(Rev01 + k, Rev01 + k).Value2 = Rev01_Data;
                                                            #endregion
                                                            #region Tip 4 cells
                                                            excelSheet.get_Range(TipCreditCard + k, TipCreditCard + k).Value2 = TipCreditCard_Data;
                                                            excelSheet.get_Range(TipCheck + k, TipCheck + k).Value2 = TipCheck_Data;
                                                            excelSheet.get_Range(TipCash + k, TipCash + k).Value2 = TipCash_Data;
                                                            excelSheet.get_Range(TipInvoice + k, TipInvoice + k).Value2 = TipInvoice_Data;
                                                            #endregion
                                                            #region Prior Revenue 8 cells
                                                            excelSheet.get_Range(PriorCreditCard + k, PriorCreditCard + k).Value2 = PriorCreditCard_Data;
                                                            excelSheet.get_Range(PriorCheck + k, PriorCheck + k).Value2 = PriorCheck_Data;
                                                            excelSheet.get_Range(PriorCash + k, PriorCash + k).Value2 = PriorCash_Data;

                                                            excelSheet.get_Range(CreditCardNo + k, CreditCardNo + k).Value2 = CreditCardNo_Data;
                                                            excelSheet.get_Range(CreditCardExpir + k, CreditCardExpir + k).Value2 = CreditCardExpir_Data;
                                                            excelSheet.get_Range(CreditCardName + k, CreditCardName + k).Value2 = CreditCardName_Data;
                                                            excelSheet.get_Range(CreditCardAddr + k, CreditCardAddr + k).Value2 = CreditCardAddr_Data;
                                                            excelSheet.get_Range(SecurityCode + k, SecurityCode + k).Value2 = SecurityCode_Data;
                                                            /* * */
                                                            #endregion
                                                            #region Inventory 27 cell
                                                            excelSheet.get_Range(FleaTick22 + k, FleaTick22 + k).Value2 = FleaTick22_Data;
                                                            excelSheet.get_Range(FleaTick44 + k, FleaTick44 + k).Value2 = FleaTick44_Data;
                                                            excelSheet.get_Range(FleaTick88 + k, FleaTick88 + k).Value2 = FleaTick88_Data;
                                                            excelSheet.get_Range(FleaTick132 + k, FleaTick132 + k).Value2 = FleaTick132_Data;
                                                            excelSheet.get_Range(FleaTickcAT + k, FleaTickcAT + k).Value2 = FleaTickcAT_Data;

                                                            excelSheet.get_Range(Toothbrushes + k, Toothbrushes + k).Value2 = Toothbrushes_Data;
                                                            excelSheet.get_Range(WhamInv + k, WhamInv + k).Value2 = WhamInv_Data;
                                                            excelSheet.get_Range(Towels + k, Towels + k).Value2 = Towels_Data;
                                                            //excelSheet.get_Range(CottonPads + k, CottonPads + k).Value2 = CottonPads_Data;
                                                            //excelSheet.get_Range(CottonSwabs + k, CottonSwabs + k).Value2 = CottonSwabs_Data;

                                                            excelSheet.get_Range(PaperTowels + k, PaperTowels + k).Value2 = PaperTowels_Data;
                                                            excelSheet.get_Range(GarbageBags + k, GarbageBags + k).Value2 = GarbageBags_Data;
                                                            excelSheet.get_Range(Treats + k, Treats + k).Value2 = Treats_Data;
                                                            excelSheet.get_Range(VetWrap + k, VetWrap + k).Value2 = VetWrap_Data;
                                                            excelSheet.get_Range(Wipes + k, Wipes + k).Value2 = Wipes_Data;

                                                            //excelSheet.get_Range(QuickStop + k, QuickStop + k).Value2 = QuickStop_Data;
                                                            //excelSheet.get_Range(LiquidBandaid + k, LiquidBandaid + k).Value2 = LiquidBandaid_Data;
                                                            //excelSheet.get_Range(Envelopes + k, Envelopes + k).Value2 = Envelopes_Data;
                                                            //excelSheet.get_Range(Receipts + k, Receipts + k).Value2 = Receipts_Data;
                                                            //excelSheet.get_Range(BusinessCards + k, BusinessCards + k).Value2 = BusinessCards_Data;

                                                            //excelSheet.get_Range(BladesSharpened + k, BladesSharpened + k).Value2 = BladesSharpened_Data;
                                                            //excelSheet.get_Range(ScissorsSharpened + k, ScissorsSharpened + k).Value2 = ScissorsSharpened_Data;
                                                            //excelSheet.get_Range(SunGuard + k, SunGuard + k).Value2 = SunGuard_Data;
                                                            //excelSheet.get_Range(EZShed + k, EZShed + k).Value2 = EZShed_Data;
                                                            //excelSheet.get_Range(EZDematt + k, EZDematt + k).Value2 = EZDematt_Data;

                                                            //excelSheet.get_Range(SkunkKit + k, SkunkKit + k).Value2 = SkunkKit_Data;
                                                            //excelSheet.get_Range(Other + k, Other + k).Value2 = Other_Data; ;
                                                            #endregion
                                                            //break;
                                                            data_row = m + 1;
                                                            flagSuccMsg = "S";
                                                            ObjGroomer.ModifyExportFlag(DailylogId, k);
                                                            goto NextRow;
                                                            #endregion
                                                        }
                                                        if (k == (secRow + 9))
                                                        {
                                                            flagSuccMsg = "N";
                                                            goto CloseApp;
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion
                                        }


                                    }
                                }
                                #endregion

                            }
                            BindGroomersAppointment();
                            if (flagSuccMsg == "S")
                            {
                                lblError.Attributes.Add("Class", "successTable");
                                lblError.Visible = true; divError.Visible = true;
                                lblError.Text = "Data Successfuly exported to Excel file !!!!";
                            }
                            CloseApp:
                            if (flagSuccMsg == "N")
                            {
                                lblError.Attributes.Add("Class", "successTable");
                                lblError.Visible = true; divError.Visible = true;
                                lblError.Text = "No Cell available, Already 10 Transations done!!!";
                            }
                            if (flagSuccMsg == "")
                            {
                                lblError.Attributes.Add("Class", "errorTable");
                                lblError.Visible = true; divError.Visible = true;
                                lblError.Text = "Date Not Found!!!";
                            }
                        }
                        else
                        {
                            lblError.Attributes.Add("Class", "errorTable");
                            lblError.Visible = true; divError.Visible = true;
                            lblError.Text = "No Data Available in Operation Log!!!";
                        }
                    }
                }
                #region close file
                //excelApp.Save(@"D:\\Monthly4");
                // excelApp.SaveWorkspace(ExcelFilePath);
                //excelApp.Save(ExcelFilePath);
                //excelWorkBook.Close(true, @"D:\\Monthly2", null);
                //excelWorkBook.Close(true, ExcelFilePath, null);
                //foreach (Excel.Workbook wkb in excelApp.Workbooks)
                //{
                //    wkb.Save();

                //}
                //excelApp.ActiveWorkbook.Save();

                //excelApp.Workbooks.Close();

                //object fileName = "D:\\sandeep\\Projects2005\\FritzyLive\\Admin\\ExcelFile\\Monthly Operations Log - AR.xls";
                //Excel.Workbook workbook = this.excelApp.Workbooks.get_Item(fileName);
                //workbook.Close(true, misValue, misValue);

                excelApp.DisplayAlerts = false;
                excelApp.ActiveWorkbook.Save();

                ////excelWorkBook.SaveAs("D:\\sandeep\\Projects2005\\FritzyLive\\Admin\\ExcelFile\\Monthly Operations Log - AR.xls",Excel.XlFileFormat.xlXMLSpreadsheet,
                //    missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlNoChange,missing, missing, missing, missing, missing);
                //excelApp.ActiveWorkbook.Saved = true;

                //excelWorkBook.Close(true, "D:\\sandeep\\Projects2005\\FritzyLive\\Admin\\ExcelFile\\Monthly Operations Log - AR.xls", misValue);
                excelApp.ActiveWorkbook.Close(true, ExistsExcelFilePath1, missing);
                //excelApp.ActiveWorkbook.Close(true, "C:\\Inetpub\\wwwroot\\advancedweb2solutions.com\\Admin\\ExcelFile\\Monthly Operations Log - AR.xls", missing);

                excelApp.Quit();
                releaseObject(excelApp);
                releaseObject(excelSheet);
                releaseObject(excelWorkBook);

                #endregion

            }

            catch (Exception ex)
            {
                string error = ex.ToString();
                lblError.Visible = true; divError.Visible = true;
                lblError.Text = error;
                //Response.Write(error);
            }
        }


        protected void GetServerExcelFilePath()
        {

            DataSet ds = ObjGroomer.GetUnlockExcelFileName();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["status"].ToString() == "Unlock")
                {
                    string ExcelFileName;
                    ds.Tables[0].Rows[0]["FileName"].ToString();
                    ExcelFilePath = System.Configuration.ConfigurationManager.AppSettings["Excelpath"].ToString();
                    string[] filePaths = Directory.GetFiles(ExcelFilePath);
                    int count = filePaths.Length;
                    for (int i = 0; i < count; i++)
                    {
                        ExcelFilePath = filePaths[i];
                        ExcelFileName = System.IO.Path.GetFileName(ExcelFilePath);
                        if (ExcelFileName == ds.Tables[0].Rows[0]["FileName"].ToString())
                        {
                            ExistsExcelFilePath1 = ExcelFilePath;
                        }
                    }
                }

                else
                {
                    ExistsExcelFilePath1 = "Locked";
                }
            }


        }

        public void getCell()
        {
            #region get Excel data
            dsEx = ObjGroomer.getExcelData();
            if (dsEx.Tables[0].Rows.Count > 0)
            {
                VanId = dsEx.Tables[0].Rows[0]["VanId"].ToString();
                BeginningMileage = dsEx.Tables[0].Rows[0]["BeginningMileage"].ToString().Trim();
                TotlaHours = dsEx.Tables[0].Rows[0]["TotlaHours"].ToString().Trim();
                EndingMileage = dsEx.Tables[0].Rows[0]["EndingMileage"].ToString().Trim();
                FuelPurchased = dsEx.Tables[0].Rows[0]["FuelPurchased"].ToString().Trim();
                PricePerGallon = dsEx.Tables[0].Rows[0]["PricePerGallon"].ToString().Trim();
                CustomerName = dsEx.Tables[0].Rows[0]["CustomerName"].ToString().Trim();
                Job = dsEx.Tables[0].Rows[0]["Job"].ToString().Trim();
                ZipCode = dsEx.Tables[0].Rows[0]["ZipCode"].ToString().Trim();
                Pets = dsEx.Tables[0].Rows[0]["Pets"].ToString().Trim();
                Rebook = dsEx.Tables[0].Rows[0]["Rebook"].ToString().Trim();
                FromRebook = dsEx.Tables[0].Rows[0]["FromRebook"].ToString().Trim();
                New = dsEx.Tables[0].Rows[0]["New"].ToString().Trim();
                TimeIn = dsEx.Tables[0].Rows[0]["TimeIn"].ToString().Trim();
                TimeOut = dsEx.Tables[0].Rows[0]["TimeOut"].ToString().Trim();
                PetTime = dsEx.Tables[0].Rows[0]["PetTime"].ToString().Trim();
                ExtraServices = dsEx.Tables[0].Rows[0]["ExtraServices"].ToString().Trim();
                FleaandTick22 = dsEx.Tables[0].Rows[0]["FleaandTick22"].ToString().Trim();
                FleaandTick44 = dsEx.Tables[0].Rows[0]["FleaandTick44"].ToString().Trim();
                FleaandTick88 = dsEx.Tables[0].Rows[0]["FleaandTick88"].ToString().Trim();
                FleaandTick132 = dsEx.Tables[0].Rows[0]["FleaandTick132"].ToString().Trim();
                FleaandTickCat = dsEx.Tables[0].Rows[0]["FleaandTickCat"].ToString().Trim();
                TB = dsEx.Tables[0].Rows[0]["TB"].ToString().Trim();
                Wham = dsEx.Tables[0].Rows[0]["Wham"].ToString().Trim();
                RevenueCreditCard = dsEx.Tables[0].Rows[0]["RevenueCreditCard"].ToString().Trim();
                RevenueCheck = dsEx.Tables[0].Rows[0]["RevenueCheck"].ToString().Trim();
                RevenueCash = dsEx.Tables[0].Rows[0]["RevenueCash"].ToString().Trim();
                RevenueInvoice = dsEx.Tables[0].Rows[0]["RevenueInvoice"].ToString().Trim();
                TipCreditCard = dsEx.Tables[0].Rows[0]["TipCreditCard"].ToString().Trim();
                TipCheck = dsEx.Tables[0].Rows[0]["TipCheck"].ToString().Trim();
                TipCash = dsEx.Tables[0].Rows[0]["TipCash"].ToString().Trim();
                TipInvoice = dsEx.Tables[0].Rows[0]["TipInvoice"].ToString().Trim();
                PriorCreditCard = dsEx.Tables[0].Rows[0]["PriorCreditCard"].ToString().Trim();
                PriorCheck = dsEx.Tables[0].Rows[0]["PriorCheck"].ToString().Trim();
                PriorCash = dsEx.Tables[0].Rows[0]["PriorCash"].ToString().Trim();
                NextAppointmentDate = dsEx.Tables[0].Rows[0]["NextAppointmentDate"].ToString().Trim();
                NextAppointmentTime = dsEx.Tables[0].Rows[0]["NextAppointmentTime"].ToString().Trim();
                ServicesForPet = dsEx.Tables[0].Rows[0]["ServicesForPet"].ToString().Trim();
                Addedon = dsEx.Tables[0].Rows[0]["Addedon"].ToString().Trim();
                FleaTick22 = dsEx.Tables[0].Rows[0]["FleaTick22"].ToString().Trim();
                FleaTick44 = dsEx.Tables[0].Rows[0]["FleaTick44"].ToString().Trim();
                FleaTick88 = dsEx.Tables[0].Rows[0]["FleaTick88"].ToString().Trim();
                FleaTick132 = dsEx.Tables[0].Rows[0]["FleaTick132"].ToString().Trim();
                FleaTickcAT = dsEx.Tables[0].Rows[0]["FleaTickcAT"].ToString().Trim();
                Toothbrushes = dsEx.Tables[0].Rows[0]["Toothbrushes"].ToString().Trim();
                WhamInv = dsEx.Tables[0].Rows[0]["WhamInv"].ToString().Trim();
                Towels = dsEx.Tables[0].Rows[0]["Towels"].ToString().Trim();
                CottonPads = dsEx.Tables[0].Rows[0]["CottonPads"].ToString().Trim();
                CottonSwabs = dsEx.Tables[0].Rows[0]["CottonSwabs"].ToString().Trim();
                PaperTowels = dsEx.Tables[0].Rows[0]["PaperTowels"].ToString().Trim();
                GarbageBags = dsEx.Tables[0].Rows[0]["GarbageBags"].ToString().Trim();
                Treats = dsEx.Tables[0].Rows[0]["Treats"].ToString().Trim();
                VetWrap = dsEx.Tables[0].Rows[0]["VetWrap"].ToString().Trim();
                Wipes = dsEx.Tables[0].Rows[0]["Wipes"].ToString().Trim();
                QuickStop = dsEx.Tables[0].Rows[0]["QuickStop"].ToString().Trim();
                LiquidBandaid = dsEx.Tables[0].Rows[0]["LiquidBandaid"].ToString().Trim();
                Envelopes = dsEx.Tables[0].Rows[0]["Envelopes"].ToString().Trim();
                Receipts = dsEx.Tables[0].Rows[0]["Receipts"].ToString().Trim();
                BusinessCards = dsEx.Tables[0].Rows[0]["BusinessCards"].ToString().Trim();
                BladesSharpened = dsEx.Tables[0].Rows[0]["BladesSharpened"].ToString().Trim();
                ScissorsSharpened = dsEx.Tables[0].Rows[0]["ScissorsSharpened"].ToString().Trim();
                SunGuard = dsEx.Tables[0].Rows[0]["SunGuard"].ToString().Trim();
                EZShed = dsEx.Tables[0].Rows[0]["EZShed"].ToString().Trim();
                EZDematt = dsEx.Tables[0].Rows[0]["EZDematt"].ToString().Trim();
                SkunkKit = dsEx.Tables[0].Rows[0]["SkunkKit"].ToString().Trim();
                Other = dsEx.Tables[0].Rows[0]["Other"].ToString().Trim();

                Other1 = dsEx.Tables[0].Rows[0]["Other1"].ToString().Trim();
                Other2 = dsEx.Tables[0].Rows[0]["Other2"].ToString().Trim();
                Other3 = dsEx.Tables[0].Rows[0]["Other3"].ToString().Trim();
                Other4 = dsEx.Tables[0].Rows[0]["Other4"].ToString().Trim();
                Other5 = dsEx.Tables[0].Rows[0]["Other5"].ToString().Trim();

                Marketing1 = dsEx.Tables[0].Rows[0]["Marketing1"].ToString().Trim();
                Marketing2 = dsEx.Tables[0].Rows[0]["Marketing2"].ToString().Trim();
                Marketing3 = dsEx.Tables[0].Rows[0]["Marketing3"].ToString().Trim();
                Marketing4 = dsEx.Tables[0].Rows[0]["Marketing4"].ToString().Trim();
                Marketing5 = dsEx.Tables[0].Rows[0]["Marketing5"].ToString().Trim();
                Liquid1 = dsEx.Tables[0].Rows[0]["Liquid1"].ToString().Trim();
                Liquid2 = dsEx.Tables[0].Rows[0]["Liquid2"].ToString().Trim();
                Liquid3 = dsEx.Tables[0].Rows[0]["Liquid3"].ToString().Trim();
                Liquid4 = dsEx.Tables[0].Rows[0]["Liquid4"].ToString().Trim();
                Liquid5 = dsEx.Tables[0].Rows[0]["Liquid5"].ToString().Trim();
                Liquid6 = dsEx.Tables[0].Rows[0]["Liquid6"].ToString().Trim();
                Liquid7 = dsEx.Tables[0].Rows[0]["Liquid7"].ToString().Trim();
                Liquid8 = dsEx.Tables[0].Rows[0]["Liquid8"].ToString().Trim();
                Liquid9 = dsEx.Tables[0].Rows[0]["Liquid9"].ToString().Trim();
                Liquid10 = dsEx.Tables[0].Rows[0]["Liquid10"].ToString().Trim();
                Liquid11 = dsEx.Tables[0].Rows[0]["Liquid11"].ToString().Trim();
                Liquid12 = dsEx.Tables[0].Rows[0]["Liquid12"].ToString().Trim();
                Liquid13 = dsEx.Tables[0].Rows[0]["Liquid13"].ToString().Trim();
                Liquid14 = dsEx.Tables[0].Rows[0]["Liquid14"].ToString().Trim();
                Liquid15 = dsEx.Tables[0].Rows[0]["Liquid15"].ToString().Trim();
                Liquid16 = dsEx.Tables[0].Rows[0]["Liquid16"].ToString().Trim();
                Liquid17 = dsEx.Tables[0].Rows[0]["Liquid17"].ToString().Trim();
                Liquid18 = dsEx.Tables[0].Rows[0]["Liquid18"].ToString().Trim();
                Liquid19 = dsEx.Tables[0].Rows[0]["Liquid19"].ToString().Trim();
                Liquid20 = dsEx.Tables[0].Rows[0]["Liquid20"].ToString().Trim();
                Liquid21 = dsEx.Tables[0].Rows[0]["Liquid21"].ToString().Trim();
                Liquid22 = dsEx.Tables[0].Rows[0]["Liquid22"].ToString().Trim();
                Liquid23 = dsEx.Tables[0].Rows[0]["Liquid23"].ToString().Trim();
                Liquid24 = dsEx.Tables[0].Rows[0]["Liquid24"].ToString().Trim();
                Liquid25 = dsEx.Tables[0].Rows[0]["Liquid25"].ToString().Trim();

                ProductPrice = dsEx.Tables[0].Rows[0]["ProductPrice"].ToString().Trim();
                SalesTax = dsEx.Tables[0].Rows[0]["SalesTax"].ToString().Trim();
                Rev01 = dsEx.Tables[0].Rows[0]["Rev01"].ToString().Trim();
                CreditCardNo = dsEx.Tables[0].Rows[0]["CreditCardNo"].ToString().Trim();
                CreditCardExpir = dsEx.Tables[0].Rows[0]["CreditCardExpir"].ToString().Trim();
                CreditCardName = dsEx.Tables[0].Rows[0]["CreditCardName"].ToString().Trim();
                CreditCardAddr = dsEx.Tables[0].Rows[0]["CreditCardAddr"].ToString().Trim();
                SecurityCode = dsEx.Tables[0].Rows[0]["SecurityCode"].ToString().Trim(); ;

            }
            #endregion
        }

        public void getDailyOperationLog(int m, string GID, string DailyLogID, DataSet ds)
        {
            #region get cell data
            dsEx = ds;
            if (dsEx.Tables[0].Rows.Count > 0)
            {
                ExcelRowId = dsEx.Tables[0].Rows[m]["ExcelRowId"].ToString();
                DailylogId = dsEx.Tables[0].Rows[m]["DailylogId"].ToString();
                VanId_Data = dsEx.Tables[0].Rows[m]["VanId"].ToString();
                BeginningMileage_Data = dsEx.Tables[0].Rows[m]["BeginningMileage"].ToString();
                TotlaHours_Data = dsEx.Tables[0].Rows[m]["TotlaHours"].ToString();
                EndingMileage_Data = dsEx.Tables[0].Rows[m]["EndingMileage"].ToString();
                //Dec2013
                FuelPurchased_Data = dsEx.Tables[0].Rows[m]["FuelPurchased"].ToString(); if (FuelPurchased_Data == "0") { FuelPurchased_Data = ""; }
                PricePerGallon_Data = dsEx.Tables[0].Rows[m]["PricePerGallon"].ToString(); if (PricePerGallon_Data == "0") { PricePerGallon_Data = ""; }

                CustomerName_Data = dsEx.Tables[0].Rows[m]["CustomerName"].ToString();
                Job_Data = dsEx.Tables[0].Rows[m]["Job"].ToString();
                ZipCode_Data = dsEx.Tables[0].Rows[m]["ZipCode"].ToString();
                Pets_Data = dsEx.Tables[0].Rows[m]["Pets"].ToString();
                Rebook_Data = dsEx.Tables[0].Rows[m]["Rebook"].ToString();
                FromRebook_Data = dsEx.Tables[0].Rows[m]["FromRebook"].ToString();
                New_Data = dsEx.Tables[0].Rows[m]["New"].ToString();
                TimeIn_Data = dsEx.Tables[0].Rows[m]["TimeIn"].ToString();
                TimeOut_Data = dsEx.Tables[0].Rows[m]["TimeOut"].ToString();
                PetTime_Data = dsEx.Tables[0].Rows[m]["PetTime"].ToString();
                ExtraServices_Data = dsEx.Tables[0].Rows[m]["ExtraServices"].ToString();

                FleaandTick22_Data = dsEx.Tables[0].Rows[m]["FleaandTick22"].ToString(); if (FleaandTick22_Data == "0.000") { FleaandTick22_Data = ""; }
                FleaandTick44_Data = dsEx.Tables[0].Rows[m]["FleaandTick44"].ToString(); if (FleaandTick44_Data == "0.000") { FleaandTick44_Data = ""; }
                FleaandTick88_Data = dsEx.Tables[0].Rows[m]["FleaandTick88"].ToString(); if (FleaandTick88_Data == "0.000") { FleaandTick88_Data = ""; }
                FleaandTick132_Data = dsEx.Tables[0].Rows[m]["FleaandTick132"].ToString(); if (FleaandTick132_Data == "0.000") { FleaandTick132_Data = ""; }
                FleaandTickCat_Data = dsEx.Tables[0].Rows[m]["FleaandTickCat"].ToString(); if (FleaandTickCat_Data == "0.000") { FleaandTickCat_Data = ""; }
                TB_Data = dsEx.Tables[0].Rows[m]["TB"].ToString(); if (TB_Data == "0.000") { TB_Data = ""; }
                Wham_Data = dsEx.Tables[0].Rows[m]["Wham"].ToString(); if (Wham_Data == "0.000") { Wham_Data = ""; }
                RevenueCreditCard_Data = dsEx.Tables[0].Rows[m]["RevenueCreditCard"].ToString(); if (RevenueCreditCard_Data == "0.000") { RevenueCreditCard_Data = ""; }
                RevenueCheck_Data = dsEx.Tables[0].Rows[m]["RevenueCheck"].ToString(); if (RevenueCheck_Data == "0.000") { RevenueCheck_Data = ""; }
                RevenueCash_Data = dsEx.Tables[0].Rows[m]["RevenueCash"].ToString(); if (RevenueCash_Data == "0.000") { RevenueCash_Data = ""; }
                RevenueInvoice_Data = dsEx.Tables[0].Rows[m]["RevenueInvoice"].ToString(); if (RevenueInvoice_Data == "0.000") { RevenueInvoice_Data = ""; }
                TipCreditCard_Data = dsEx.Tables[0].Rows[m]["TipCreditCard"].ToString(); if (TipCreditCard_Data == "0.000") { TipCreditCard_Data = ""; }
                TipCheck_Data = dsEx.Tables[0].Rows[m]["TipCheck"].ToString(); if (TipCheck_Data == "0.000") { TipCheck_Data = ""; }
                TipCash_Data = dsEx.Tables[0].Rows[m]["TipCash"].ToString(); if (TipCash_Data == "0.000") { TipCash_Data = ""; }
                TipInvoice_Data = dsEx.Tables[0].Rows[m]["TipInvoice"].ToString(); if (TipInvoice_Data == "0.000") { TipInvoice_Data = ""; }
                PriorCreditCard_Data = dsEx.Tables[0].Rows[m]["PriorCreditCard"].ToString(); if (PriorCreditCard_Data == "0.000") { PriorCreditCard_Data = ""; }
                PriorCheck_Data = dsEx.Tables[0].Rows[m]["PriorCheck"].ToString(); if (PriorCheck_Data == "0.000") { PriorCheck_Data = ""; }
                PriorCash_Data = dsEx.Tables[0].Rows[m]["PriorCash"].ToString(); if (PriorCash_Data == "0.000") { PriorCash_Data = ""; }
                NextAppointmentDate_Data = dsEx.Tables[0].Rows[m]["NextAppointmentDate"].ToString();
                NextAppointmentTime_Data = dsEx.Tables[0].Rows[m]["NextAppointmentTime"].ToString();
                if (Rebook_Data != "")
                {
                    ServicesForPet_Data = "";
                    if (dsEx.Tables[0].Rows[m]["ServicesForPet1"].ToString() != "")
                    {
                        ServicesForPet_Data += dsEx.Tables[0].Rows[m]["ServicesForPet1"].ToString();
                    }
                    if (dsEx.Tables[0].Rows[m]["ServicesForPet2"].ToString() != "")
                    {
                        ServicesForPet_Data += "," + dsEx.Tables[0].Rows[m]["ServicesForPet2"].ToString();
                    }
                    if (dsEx.Tables[0].Rows[m]["ServicesForPet3"].ToString() != "")
                    {
                        ServicesForPet_Data += "," + dsEx.Tables[0].Rows[m]["ServicesForPet3"].ToString();
                    }
                    if (dsEx.Tables[0].Rows[m]["ServicesForPet4"].ToString() != "")
                    {
                        ServicesForPet_Data += "," + dsEx.Tables[0].Rows[m]["ServicesForPet4"].ToString();
                    }
                    if (dsEx.Tables[0].Rows[m]["ServicesForPet5"].ToString() != "")
                    {
                        ServicesForPet_Data += "," + dsEx.Tables[0].Rows[m]["ServicesForPet5"].ToString();
                    }
                    if (dsEx.Tables[0].Rows[m]["ServicesForPet6"].ToString() != "")
                    {
                        ServicesForPet_Data += "," + dsEx.Tables[0].Rows[m]["ServicesForPet6"].ToString();
                    }
                }
                Addedon_Data = dsEx.Tables[0].Rows[m]["Addedon"].ToString();
                if (dsEx.Tables[1].Rows.Count > 0)
                {
                    FleaTick22_Data = dsEx.Tables[1].Rows[0]["FleaTick22"].ToString(); if (Convert.ToInt32(FleaTick22_Data) == 0) { FleaTick22_Data = ""; }
                    FleaTick44_Data = dsEx.Tables[1].Rows[0]["FleaTick44"].ToString(); if (Convert.ToInt32(FleaTick44_Data) == 0) { FleaTick44_Data = ""; }
                    FleaTick88_Data = dsEx.Tables[1].Rows[0]["FleaTick88"].ToString(); if (Convert.ToInt32(FleaTick88_Data) == 0) { FleaTick88_Data = ""; }
                    FleaTick132_Data = dsEx.Tables[1].Rows[0]["FleaTick132"].ToString(); if (Convert.ToInt32(FleaTick132_Data) == 0) { FleaTick132_Data = ""; }
                    FleaTickcAT_Data = dsEx.Tables[1].Rows[0]["FleaTickcAT"].ToString(); if (Convert.ToInt32(FleaTickcAT_Data) == 0) { FleaTickcAT_Data = ""; }
                    Toothbrushes_Data = dsEx.Tables[1].Rows[0]["Toothbrushes"].ToString(); if (Convert.ToInt32(Toothbrushes_Data) == 0) { Toothbrushes_Data = ""; }
                    WhamInv_Data = dsEx.Tables[1].Rows[0]["WhamInv"].ToString(); if (Convert.ToInt32(WhamInv_Data) == 0) { WhamInv_Data = ""; }
                    Towels_Data = dsEx.Tables[1].Rows[0]["Towels"].ToString(); if (Convert.ToInt32(Towels_Data) == 0) { Towels_Data = ""; }
                    CottonPads_Data = dsEx.Tables[1].Rows[0]["CottonPads"].ToString(); if (Convert.ToInt32(CottonPads_Data) == 0) { CottonPads_Data = ""; }
                    CottonSwabs_Data = dsEx.Tables[1].Rows[0]["CottonSwabs"].ToString(); if (Convert.ToInt32(CottonSwabs_Data) == 0) { CottonSwabs_Data = ""; }
                    PaperTowels_Data = dsEx.Tables[1].Rows[0]["PaperTowels"].ToString(); if (Convert.ToInt32(PaperTowels_Data) == 0) { PaperTowels_Data = ""; }
                    GarbageBags_Data = dsEx.Tables[1].Rows[0]["GarbageBags"].ToString(); if (Convert.ToInt32(GarbageBags_Data) == 0) { GarbageBags_Data = ""; }
                    Treats_Data = dsEx.Tables[1].Rows[0]["Treats"].ToString(); if (Convert.ToInt32(Treats_Data) == 0) { Treats_Data = ""; }
                    VetWrap_Data = dsEx.Tables[1].Rows[0]["VetWrap"].ToString(); if (Convert.ToInt32(VetWrap_Data) == 0) { VetWrap_Data = ""; }
                    Wipes_Data = dsEx.Tables[1].Rows[0]["Wipes"].ToString(); if (Convert.ToInt32(Wipes_Data) == 0) { Wipes_Data = ""; }
                    QuickStop_Data = dsEx.Tables[1].Rows[0]["QuickStop"].ToString(); if (Convert.ToInt32(QuickStop_Data) == 0) { QuickStop_Data = ""; }
                    LiquidBandaid_Data = dsEx.Tables[1].Rows[0]["LiquidBandaid"].ToString(); if (Convert.ToInt32(LiquidBandaid_Data) == 0) { LiquidBandaid_Data = ""; }
                    Envelopes_Data = dsEx.Tables[1].Rows[0]["Envelopes"].ToString(); if (Convert.ToInt32(Envelopes_Data) == 0) { Envelopes_Data = ""; }
                    Receipts_Data = dsEx.Tables[1].Rows[0]["Receipts"].ToString(); if (Convert.ToInt32(Receipts_Data) == 0) { Receipts_Data = ""; }
                    BusinessCards_Data = dsEx.Tables[1].Rows[0]["BusinessCards"].ToString(); if (Convert.ToInt32(BusinessCards_Data) == 0) { BusinessCards_Data = ""; }
                    BladesSharpened_Data = dsEx.Tables[1].Rows[0]["BladesSharpened"].ToString(); if (Convert.ToInt32(BladesSharpened_Data) == 0) { BladesSharpened_Data = ""; }
                    ScissorsSharpened_Data = dsEx.Tables[1].Rows[0]["ScissorsSharpened"].ToString(); if (Convert.ToInt32(ScissorsSharpened_Data) == 0) { ScissorsSharpened_Data = ""; }
                    SunGuard_Data = dsEx.Tables[1].Rows[0]["SunGuard"].ToString(); if (Convert.ToInt32(SunGuard_Data) == 0) { SunGuard_Data = ""; }
                    EZShed_Data = dsEx.Tables[1].Rows[0]["EZShed"].ToString(); if (Convert.ToInt32(EZShed_Data) == 0) { EZShed_Data = ""; }
                    EZDematt_Data = dsEx.Tables[1].Rows[0]["EZDematt"].ToString(); if (Convert.ToInt32(EZDematt_Data) == 0) { EZDematt_Data = ""; }
                    SkunkKit_Data = dsEx.Tables[1].Rows[0]["SkunkKit"].ToString(); if (Convert.ToInt32(SkunkKit_Data) == 0) { SkunkKit_Data = ""; }
                    Other_Data = dsEx.Tables[1].Rows[0]["Other"].ToString();
                }
                /* ProductPrice = dsEx.Tables[0].Rows[m][""].ToString(); 
                 SalesTax = dsEx.Tables[0].Rows[m][""].ToString();
             if (RevenueCheck_Data != "" || RevenueCash_Data != "") { Rev01_Data = ""; } 
                 Rev01_Data = dsEx.Tables[0].Rows[m][""].ToString(); */
                CreditCardNo_Data = dsEx.Tables[0].Rows[m]["CreditCardNo"].ToString(); //only last three no
                CreditCardExpir_Data = dsEx.Tables[0].Rows[m]["CreditCardExpir"].ToString();
                CreditCardName_Data = dsEx.Tables[0].Rows[m]["CreditCardORChkName"].ToString();
                CreditCardAddr_Data = dsEx.Tables[0].Rows[m]["CreditCardORChkAddr"].ToString();
                SecurityCode_Data = dsEx.Tables[0].Rows[m]["SecurityCode"].ToString();


            }
            #endregion
        }

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

        #endregion

        public void BindGroomersDDL()
        {
            Groomer objGroomer = new Groomer();
            DataSet ds = new DataSet();
            ds = objGroomer.BindGroomers();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ListItem lst = new ListItem();
                lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
                ddlGroomerlist.DataTextField = "name";
                ddlGroomerlist.DataValueField = "Gid";
                ddlGroomerlist.DataSource = ds.Tables[0];
                ddlGroomerlist.DataBind();
                ddlGroomerlist.Items.Insert(0, lst);
            }
        }

        protected void ddlGroomerlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGroomersAppointment();
        }

        #region grid code

        protected void GrdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblExportToExcel = (Label)e.Row.FindControl("lblExportToExcel");
                if (lblExportToExcel.Text == "True") { lblExportToExcel.Text = "Y"; }
                else { lblExportToExcel.Text = "N"; }
            }


        }


        #region BindData
        /* Bind User function is use to bind all users to grid */
        public void BindGroomersAppointment()
        {


            Groomer ObjGroomer = new Groomer();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dt1 = new DataTable();
            DataView dv = new DataView();


            ds = ObjGroomer.GroomerOperationToExport(ddlGroomerlist.SelectedValue.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnExport.Visible = true;
                GrdUsers.Visible = true;
                dt1 = ds.Tables[0];
                dv = dt1.DefaultView;
                if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                {
                    if ((SortExpression == "SequenceNo") && (SortDirection == "ASC"))
                    {
                        dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo ASC";
                    }
                    if ((SortExpression == "SequenceNo") && (SortDirection == "DESC"))
                    {
                        dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo Asc";
                    }

                }


                GrdUsers.DataSource = dv;
                GrdUsers.DataBind();
                CheckAll();
                check();
                divError.Visible = false;

                ds1 = ObjGroomer.GetUnlockExcelFileName();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0]["Status"].ToString() == "Lock")
                    {
                        btnExport.Visible = false;
                    }
                    else
                    {
                        btnExport.Visible = true;
                    }
                }

            }
            else
            {
                btnExport.Visible = false;
                GrdUsers.Visible = false;
                ErrorMessage("Sorry, No Details found for this date.");
                Session["SelectedDate"] = txtStartDate.Text.Trim();

            }
            // }
        }

        #endregion

        #region Declare
        /* Error message and success messages are use to display messages to user*/
        public void ErrorMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }
        public void SuccessMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        /* These two varibles are used for Sorting to maintain sort expression and sortdirection */
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
        #endregion

        protected void GrdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdUsers.PageIndex = e.NewPageIndex;
            BindGroomersAppointment();
        }

        /* Grid Sorting event*/
        protected void GrdUsers_Sorting(object sender, GridViewSortEventArgs e)
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
            GrdUsers.PageIndex = 0;
            BindGroomersAppointment();
        }

        #region GridEvent
        //Event use for pagination
        protected void GrdUsers_DataBound(object sender, EventArgs e)
        {
            GridViewRow gvr = GrdUsers.BottomPagerRow;
            Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
            lb1.Text = Convert.ToString(GrdUsers.PageIndex + 1);
            int[] page = new int[7];
            page[0] = GrdUsers.PageIndex - 2;
            page[1] = GrdUsers.PageIndex - 1;
            page[2] = GrdUsers.PageIndex;
            page[3] = GrdUsers.PageIndex + 1;
            page[4] = GrdUsers.PageIndex + 2;
            page[5] = GrdUsers.PageIndex + 3;
            page[6] = GrdUsers.PageIndex + 4;
            for (int i = 0; i < 7; i++)
            {
                if (i != 3)
                {
                    if (page[i] < 1 || page[i] > GrdUsers.PageCount)
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
            if (GrdUsers.PageIndex == 0)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
                lb.Visible = false;

            }
            if (GrdUsers.PageIndex == GrdUsers.PageCount - 1)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
                lb.Visible = false;

            }
            if (GrdUsers.PageIndex > GrdUsers.PageCount - 5)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
                lbmore.Visible = false;
            }
            if (GrdUsers.PageIndex < 4)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
                lbmore.Visible = false;
            }
        }
        protected void GrdUsers_RowCreated(object sender, GridViewRowEventArgs e)
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
            GrdUsers.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
            BindGroomersAppointment();
        }
        #endregion

        #region Grid CheckBox
        /* Check all function is use for grid header checkbox to chaeck all function which is register client script */
        public void CheckAll()
        {
            CheckBox chkall;
            chkall = (CheckBox)GrdUsers.HeaderRow.FindControl("chkall");
            chkall.Attributes.Add("onclick", "checkall()");
            string str;
            str = "function checkall()";
            str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
            str = str + "{";
            foreach (GridViewRow gvr in GrdUsers.Rows)
            {
                CheckBox checkall;
                checkall = (CheckBox)gvr.FindControl("chkSelect");
                str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
            }
            str = str + "}";
            str = str + "else";
            str = str + "{";
            foreach (GridViewRow grv in GrdUsers.Rows)
            {
                CheckBox chk1;
                chk1 = (CheckBox)grv.FindControl("chkSelect");
                str = str + "document.getElementById('" + chk1.ClientID + "').checked=false;";
            }
            str = str + "}}";
            Page.ClientScript.RegisterStartupScript(GetType(), "sss", str, true);
        }

        /* Check function is use to check select at least one row of grid which is register client script */
        protected void check()
        {
            string checkid = "";
            checkid += "function val(id){";
            checkid += "var flg=0;";

            foreach (GridViewRow grv in GrdUsers.Rows)
            {
                CheckBox chk1;
                chk1 = (CheckBox)grv.FindControl("chkSelect");
                checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
                checkid += "flg=1;}";
            }
            checkid += "if(flg!=1){";
            checkid += "alert('Select Atleast One Transaction(s)');return false;}";
            checkid += "if(flg==1 && id==1){";
            checkid += "if(!confirm('Do You Want To Export Selected Transaction(s) ?')){return false;}}";
            checkid += "if(flg==1 && id==2){";
            checkid += "if(!confirm('Do You Want To Change Status of Transaction(s) ?')){return false;}}";
            checkid = checkid + "}";
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

            btnExport.Attributes.Add("onclick", "return val(1);");

        }
        #endregion

        #endregion


    }