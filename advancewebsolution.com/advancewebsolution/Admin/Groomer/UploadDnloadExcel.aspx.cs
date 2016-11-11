using System;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using advancewebtosolution.BO;
using System.Collections.Generic;

public partial class Admin_Groomer_UploadDnloadExcel : System.Web.UI.Page
{
    #region Constructor
    public Admin_Groomer_UploadDnloadExcel()
    {
        //create if not exists
        if (!Directory.Exists(Server.MapPath("~/Admin/ExcelFile")))
            Directory.CreateDirectory(Server.MapPath("~/Admin/ExcelFile"));
    }
    #endregion

    string ExcelFilePath = "";

    #region Global Variable

    Groomer objgroomer = new Groomer();
    int rDriveTimeData, rPetTimeData;
    string ExcelToexportstatus = "";

    //private Excel.Application excelApp = new Excel.ApplicationClass();
    //object missing = System.Reflection.Missing.Value;
    //Excel.Worksheet excelSheet1 = new Microsoft.Office.Interop.Excel.Worksheet();


    #region Testing Truncate tables Don't UnComment It
    protected void btnTruncateTables_Click(object sender, EventArgs e)
    {
        try
        {
            Groomer objgr = new Groomer();
            objgr.TruncateTables();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    public string VanId_Data, BeginningMileage_Data, TotlaHours_Data, EndingMileage_Data, FuelPurchased_Data, PricePerGallon_Data, CustomerName_Data, Job_Data, ZipCode_Data, Pets_Data, Rebook_Data, FromRebook_Data, New_Data, TimeIn_Data, TimeOut_Data, PetTime_Data, ExtraServices_Data, comments_Data, FleaandTick22_Data, FleaandTick44_Data, FleaandTick88_Data, FleaandTick132_Data, FleaandTickCat_Data, TB_Data, Wham_Data, RevenueCreditCard_Data, RevenueCheck_Data, RevenueCash_Data, RevCCY_Data, RevenueInvoice_Data, TipCreditCard_Data, TipCheck_Data, TipCash_Data, TipInvoice_Data, PriorCreditCard_Data, PriorCheck_Data, PriorCash_Data, NextAppointmentDate_Data, NextAppointmentTime_Data, ServicesForPet_Data, Addedon_Data, ProductPrice_Data, SalesTax_Data, Rev01_Data, CreditCardNo_Data, CreditCardExpir_Data, CreditCardName_Data, CreditCardAddr_Data, TxnStatus, DailylogId, ExcelRowId, CreditCardNumber_data, TxnRefNo, AuthCode;
    string ExcelFilePath1 = "";
    string ExistsExcelFilePath1;
    #endregion

    #region Global Variable Excel Generate

    DataSet dsExInv = new DataSet();
    DataSet dsNoExpInv = new DataSet();
    int data_rowInv = 0, secRowInv = 0;

    //private Excel.Application excelAppInv = new Excel.ApplicationClass();
    //object missingInv = System.Reflection.Missing.Value;
    //Excel.Worksheet excelSheetInv2 = new Microsoft.Office.Interop.Excel.Worksheet();

    #region Excel 1 Requirement
    private Excel.Application excelApp = null;
    object missing = null;
    Excel.Worksheet excelSheet1 = null;

    string DLId;
    Groomer ObjGroomer = new Groomer();
    DataSet dsEx;
    DataSet ds;
    DataSet dsNoExp = new DataSet();
    string strdate = String.Empty, strSelDate = "";
    string flagSuccMsg = "";
    int secRow = 0, data_row = 0;
    public string VanId, BeginningMileage, TotlaHours, EndingMileage, FuelPurchased, PricePerGallon, CustomerName1, Job1, ZipCode1, Pets1, Rebook1, FromRebook1, New1, TimeIn1, TimeOut1, PetTime1, ExtraServices1, comments1, rDriveTime1, rPetTime1, FleaandTick221, FleaandTick441, FleaandTick881, FleaandTick1321, FleaandTickCat1, TB1, Wham1, RevenueCreditCard1, RevenueCheck1, RevenueCash1, RevenueInvoice1, TipCreditCard1, TipCheck1, TipCash1, TipInvoice1, PriorCreditCard1, PriorCheck1, PriorCash1, NextAppointmentDate, NextAppointmentTime, ServicesForPet, Addedon, ProductPrice1, SalesTax1, Rev01, CreditCardNo1, CreditCardExpir1, CreditCardName, CreditCardAddr, SecurityCode1;
    #endregion

    #region Excel 2 Requirement
    private Excel.Application excelAppInv = null;
    object missingInv = null;
    Excel.Worksheet excelSheetInv2 = null;
    public string EarWipes_Data, FleaTick22_Data, FleaTick44_Data, FleaTick88_Data, FleaTick132_Data, FleaTickcAT_Data, Toothbrushes_Data, Wipes_Data,
                 WhamInv_Data, Towels_Data, CottonSwabs_Data, PaperTowels_Data, GarbageBags_Data, Treats_Data, VetWrap_Data, Envelopes_Data, Receipts_Data, BusinessCards_Data;
    public string EarWipes, FleaTick22, FleaTick44, FleaTick88, FleaTick132, FleaTickcAT, Toothbrushes, Wipes,
                 WhamInv, Towels, CottonSwabs, PaperTowels, GarbageBags, Treats, VetWrap, Envelopes, Receipts, BusinessCards;
    string Other1, Other2, Other3, Other4, Other5, Marketing1, Marketing2, Marketing3, Marketing4, Marketing5, Liquid1, Liquid2, Liquid3,
           Liquid4, Liquid5, Liquid6, Liquid7, Liquid8, Liquid9, Liquid10, Liquid11, Liquid12, Liquid13, Liquid14, Liquid15, Liquid16, Liquid17, Liquid18,
          Liquid19, Liquid20, Liquid21, Liquid22, Liquid23, Liquid24, Liquid25;
    string Other1_Data, Other2_Data, Other3_Data, Other4_Data, Other5_Data, Marketing1_Data, Marketing2_Data, Marketing3_Data, Marketing4_Data, Marketing5_Data, Liquid1_Data, Liquid2_Data, Liquid3_Data,
         Liquid4_Data, Liquid5_Data, Liquid6_Data, Liquid7_Data, Liquid8_Data, Liquid9_Data, Liquid10_Data, Liquid11_Data, Liquid12_Data, Liquid13_Data, Liquid14_Data, Liquid15_Data, Liquid16_Data, Liquid17_Data, Liquid18_Data,
         Liquid19_Data, Liquid20_Data, Liquid21_Data, Liquid22_Data, Liquid23_Data, Liquid24_Data, Liquid25_Data;
    #endregion

    #region  Excel 3 Requirement

    DataSet dsNoExpEnd = new DataSet();
    DataSet dsExEnd = new DataSet();

    int data_rowEnd = 0, secRowEnd = 0;

    Excel.Workbook excelWorkBook = null;

    private Excel.Application excelAppEnd = null;
    object missingEnd = null;
    Excel.Worksheet excelSheetEnd3 = null;
    #endregion

    #region  Excel 4 Requirement GiftTab

    DataSet dsNoExpGift = new DataSet();
    DataSet dsExGift = new DataSet();
    private Excel.Application excelAppGift = null;
    object missingGift = null;
    Excel.Worksheet excelSheetGift4 = null;
    #endregion

    #endregion

    #region  Initialize Excel Four Object
    protected void InitializeExcel1()
    {
        try
        {
            excelApp = new Microsoft.Office.Interop.Excel.Application();
            missing = System.Reflection.Missing.Value;
            excelSheet1 = new Microsoft.Office.Interop.Excel.Worksheet();
        }
        catch
        {
            ErrMessage("Server Error.");
        }
    }

    protected void InitializeExcel2()
    {
        try
        {
            excelAppInv = new Microsoft.Office.Interop.Excel.Application();
            missingInv = System.Reflection.Missing.Value;
            excelSheetInv2 = new Microsoft.Office.Interop.Excel.Worksheet();
        }
        catch
        {
            ErrMessage("Server Error.");
        }
    }

    protected void InitializeExcel3()
    {
        try
        {
            excelAppEnd = new Microsoft.Office.Interop.Excel.Application();
            missingEnd = System.Reflection.Missing.Value;
            excelSheetEnd3 = new Microsoft.Office.Interop.Excel.Worksheet();
        }
        catch 
        {
            ErrMessage("Server Error.");
        }
    }

    protected void InitializeExcel4()
    {
        try
        {
            excelAppGift = new Microsoft.Office.Interop.Excel.Application();
            missingGift = System.Reflection.Missing.Value;
            excelSheetGift4 = new Microsoft.Office.Interop.Excel.Worksheet();
        }
        catch 
        {
            ErrMessage("Server Error.");
        }
    }

    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        #region oldcode
        try
        {
            InitializeExcel1();
            InitializeExcel2();
            InitializeExcel3();
            InitializeExcel4();
            ExcelFilePath = System.Configuration.ConfigurationManager.AppSettings["ExcelFile"].ToString();
            ExcelFilePath = ExcelFilePath.Substring(0, ExcelFilePath.LastIndexOf('/') + 1);

            if (!IsPostBack)
                if (Request.QueryString["Msg"] == "0")
                    SuccesfullMessage("The file has been uploaded.");
            if (Request.QueryString["Msg"] == "1")
                SuccesfullMessage("Data pushed successfully.");
            getServerFiles();
            excelApp.Quit();
            excelAppInv.Quit();
            excelAppEnd.Quit();
            excelAppGift.Quit();
        }
        catch 
        {
            ErrMessage("Server Error.");
        }
        #endregion
        #region mycode
        #endregion
    }
    #endregion

    #region Message
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
    #endregion

    #region Button 1 Upload Sheet
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            string SaveLocation = Server.MapPath(ExcelFilePath) + "\\" + fn;
            string ExistFileName = "";

            Groomer objgr = new Groomer();
            DataSet ds = new DataSet();
            try
            {
                if (FileUpload1.PostedFile.FileName != "")
                {
                    if (fn.Contains(".xls"))
                    {
                        bool FileName = false;
                        ds = objgr.GetUnlockExcelFileName();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (ds.Tables[0].Rows[i]["FileName"].ToString() == fn)
                                {
                                    FileName = true;
                                    ExistFileName = ds.Tables[0].Rows[i]["FileName"].ToString();
                                }
                            }
                        }
                        if (FileName == true)
                        {
                            string ExistingFile = Server.MapPath(ExcelFilePath) + "\\" + ExistFileName;
                            objgr.DeleteExcelFile(fn);
                            File.Delete(ExistingFile);

                            objgr.AddExcelFile(fn);
                            FileUpload1.PostedFile.SaveAs(SaveLocation);
                            Response.Redirect("UploadDnloadExcel.aspx?Msg=0", false);
                        }
                        else
                        {
                            FileUpload1.PostedFile.SaveAs(SaveLocation);
                            objgr.AddExcelFile(fn);
                            Response.Redirect("UploadDnloadExcel.aspx?Msg=0", false);
                        }
                    }
                    else { ErrMessage("Please select only excel file "); }
                }
                else
                {
                    ErrMessage("Please select excel file");
                }
            }
            catch 
            {
                ErrMessage("Server Error.");
            }
            
        }
        catch
        {
            ErrMessage("Server Error.");
        }
    }
    #endregion

    #region Button 2 Push To Spreedsheet

    #region Push To SpreedSheet Button
    protected void Push_Click(object sender, EventArgs e)
    {
        try
        {
            GetServerExcelFilePath();
            ExportToExcelNew();
            ExportToExcelNewInventroy();
            ExportToExcelGift();
            ExportToExcelEndingMileage();

            Response.Redirect("UploadDnloadExcel.aspx?Msg=1", false);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("The password you supplied is not correct."))
            {
                ErrMessage("An error occurred as the password was invalid for the Excel file");
            }
        }
    }
    #endregion


    #region Push to Spreed sheet Code Requirement Function

    #region 1. DailyOperatrionLog
    public void ExportToExcelNew()
    {
        try
        {
            dsNoExp = ObjGroomer.GetUuExportedgroomerlogdata();
            if (dsNoExp.Tables[0].Rows.Count > 0)
            {
                string password = "";
                DataSet dsExLog = ObjGroomer.getExcelData();

                if (dsExLog.Tables.Count > 0)
                {
                    if (dsExLog.Tables[0].Rows.Count > 0)
                    {
                        password = dsExLog.Tables[0].Rows[0]["SpreadsheetPassword"].ToString().Trim();
                    }
                }
                excelWorkBook = excelApp.Workbooks.Open(ExistsExcelFilePath1, 0, false, 5, password, password, true, Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);


                #region oldregion
                Excel.Range range = null;
                NextRow:
                for (int rowcount = data_row; rowcount < dsNoExp.Tables[0].Rows.Count; rowcount++)
                {
                    DateTime dt = Convert.ToDateTime(dsNoExp.Tables[0].Rows[rowcount]["Addedon"]);

                    strSelDate = getMonth(dt.Month.ToString()) + " " + dt.Day + "," + " " + dt.Year;
                    getCell();
                    strdate = dsNoExp.Tables[0].Rows[rowcount]["Addedon"].ToString();
                    ExcelToexportstatus = dsNoExp.Tables[0].Rows[rowcount]["ExcelExported"].ToString();

                    int numSheets = excelWorkBook.Sheets.Count;
                    excelApp.Visible = false;
                    Excel.Sheets excelSheets = excelWorkBook.Worksheets;
                    for (int sheetNum = 1; sheetNum < numSheets; sheetNum++)
                    {
                        excelSheet1 = (Excel.Worksheet)excelSheets.get_Item(sheetNum);
                        string strWorksheetName = excelSheet1.Name;
                        if (strWorksheetName == dsNoExp.Tables[0].Rows[rowcount]["sheetName"].ToString())
                        {
                            excelSheet1 = (Excel.Worksheet)excelSheets.get_Item(dsNoExp.Tables[0].Rows[rowcount]["sheetName"].ToString());
                            if (dsEx.Tables[0].Rows.Count > 0)
                            {
                                getDailyOperationLog(rowcount, dsNoExp);
                                #region writing in excel

                                #region export to  Parant cell
                                if (excelSheet1 != null)
                                {
                                    range = excelSheet1.get_Range(VanId, VanId);
                                    excelSheet1.get_Range(VanId, VanId).Value2 = VanId_Data;
                                }
                                #endregion
                                for (int r = 8; r < 381; r = r + 12)
                                {
                                    range = excelSheet1.get_Range("B" + r, "B" + r);
                                    strdate = excelSheet1.get_Range("B" + r, "B" + r).Text.ToString();
                                    if (strdate == string.Empty)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if (strdate == strSelDate)
                                        {
                                            secRow = r + 2;

                                            excelSheet1.get_Range(BeginningMileage + r, BeginningMileage + r).Value2 = BeginningMileage_Data;
                                            excelSheet1.get_Range(TotlaHours + r, TotlaHours + r).Value2 = TotlaHours_Data;
                                            excelSheet1.get_Range(EndingMileage + r, EndingMileage + r).Value2 = EndingMileage_Data;
                                            excelSheet1.get_Range(FuelPurchased + r, FuelPurchased + r).Value2 = FuelPurchased_Data;
                                            excelSheet1.get_Range(PricePerGallon + r, PricePerGallon + r).Value2 = PricePerGallon_Data;

                                            #region export to  secondary cell
                                            for (int k = secRow; k < (secRow + 10); k++)
                                            {
                                                range = excelSheet1.get_Range("A" + k, "A" + k);
                                                //check if job is null
                                                if (range != null)
                                                {
                                                    if (excelSheet1.get_Range("A" + k, "A" + k).Text.ToString() == string.Empty)
                                                    {
                                                        #region fileds
                                                        excelSheet1.get_Range(Job1 + k, Job1 + k).Value2 = Job_Data;
                                                        excelSheet1.get_Range(CustomerName1 + k, CustomerName1 + k).Value2 = CustomerName_Data;
                                                        excelSheet1.get_Range(ZipCode1 + k, ZipCode1 + k).Value2 = ZipCode_Data;
                                                        excelSheet1.get_Range(Pets1 + k, Pets1 + k).Value2 = Pets_Data;
                                                        excelSheet1.get_Range(Rebook1 + k, Rebook1 + k).Value2 = Rebook_Data;
                                                        excelSheet1.get_Range(NextAppointmentDate + k, NextAppointmentDate + k).Value2 = NextAppointmentDate_Data + "," + NextAppointmentTime_Data + "," + ServicesForPet_Data;
                                                        excelSheet1.get_Range(FromRebook1 + k, FromRebook1 + k).Value2 = FromRebook_Data;
                                                        excelSheet1.get_Range(New1 + k, New1 + k).Value2 = New_Data;
                                                        excelSheet1.get_Range(PetTime1 + k, PetTime1 + k).Value2 = PetTime_Data;
                                                        excelSheet1.get_Range(ExtraServices1 + k, ExtraServices1 + k).Value2 = ExtraServices_Data;
                                                        //new
                                                        excelSheet1.get_Range(comments1 + k, comments1 + k).Value2 = comments_Data;
                                                        excelSheet1.get_Range(rDriveTime1 + k, rDriveTime1 + k).Value2 = rDriveTimeData;
                                                        excelSheet1.get_Range(rPetTime1 + k, rPetTime1 + k).Value2 = rPetTimeData;

                                                        excelSheet1.get_Range(FleaandTick221 + k, FleaandTick221 + k).Value2 = FleaandTick22_Data;
                                                        excelSheet1.get_Range(FleaandTick441 + k, FleaandTick441 + k).Value2 = FleaandTick44_Data;
                                                        excelSheet1.get_Range(FleaandTick881 + k, FleaandTick881 + k).Value2 = FleaandTick88_Data;
                                                        excelSheet1.get_Range(FleaandTick1321 + k, FleaandTick1321 + k).Value2 = FleaandTick132_Data;
                                                        excelSheet1.get_Range(FleaandTickCat1 + k, FleaandTickCat1 + k).Value2 = FleaandTickCat_Data;
                                                        excelSheet1.get_Range(TB1 + k, TB1 + k).Value2 = TB_Data;
                                                        excelSheet1.get_Range(Wham1 + k, Wham1 + k).Value2 = Wham_Data;
                                                        #endregion
                                                        #region revenue 7 cells
                                                        excelSheet1.get_Range(RevenueCreditCard1 + k, RevenueCreditCard1 + k).Value2 = RevenueCreditCard_Data;
                                                        excelSheet1.get_Range(RevenueCheck1 + k, RevenueCheck1 + k).Value2 = RevenueCheck_Data;
                                                        excelSheet1.get_Range(RevenueCash1 + k, RevenueCash1 + k).Value2 = RevenueCash_Data;
                                                        excelSheet1.get_Range(RevenueInvoice1 + k, RevenueInvoice1 + k).Value2 = RevenueInvoice_Data;
                                                        if (RevCCY_Data != "")
                                                        {
                                                            excelSheet1.get_Range(RevenueCreditCard1 + k, RevenueCreditCard1 + k).Value2 = RevCCY_Data;
                                                        }
                                                        //no data field found
                                                        excelSheet1.get_Range(ProductPrice1 + k, ProductPrice1 + k).Value2 = ProductPrice_Data;
                                                        excelSheet1.get_Range(SalesTax1 + k, SalesTax1 + k).Value2 = SalesTax_Data;

                                                        #endregion
                                                        #region Tip 4 cells
                                                        excelSheet1.get_Range(TipCreditCard1 + k, TipCreditCard1 + k).Value2 = TipCreditCard_Data;
                                                        excelSheet1.get_Range(TipCheck1 + k, TipCheck1 + k).Value2 = TipCheck_Data;
                                                        excelSheet1.get_Range(TipCash1 + k, TipCash1 + k).Value2 = TipCash_Data;
                                                        excelSheet1.get_Range(TipInvoice1 + k, TipInvoice1 + k).Value2 = TipInvoice_Data;
                                                        #endregion
                                                        #region Prior Revenue 8 cells
                                                        excelSheet1.get_Range(PriorCreditCard1 + k, PriorCreditCard1 + k).Value2 = PriorCreditCard_Data;
                                                        excelSheet1.get_Range(PriorCheck1 + k, PriorCheck1 + k).Value2 = PriorCheck_Data;
                                                        excelSheet1.get_Range(PriorCash1 + k, PriorCash1 + k).Value2 = PriorCash_Data;

                                                        //Bind all Data  in CreditCardNo_Data so apply this variable to all
                                                        excelSheet1.get_Range(CreditCardNo1 + k, CreditCardNo1 + k).Value2 = CreditCardNo_Data;
                                                        excelSheet1.get_Range(CreditCardExpir1 + k, CreditCardExpir1 + k).Value2 = CreditCardNo_Data;
                                                        excelSheet1.get_Range(CreditCardName + k, CreditCardName + k).Value2 = CreditCardNo_Data;
                                                        excelSheet1.get_Range(CreditCardAddr + k, CreditCardAddr + k).Value2 = CreditCardNo_Data;
                                                        excelSheet1.get_Range(SecurityCode1 + k, SecurityCode1 + k).Value2 = CreditCardNo_Data;

                                                        excelSheet1.get_Range(EndingMileage + k, EndingMileage + k).VerticalAlignment = VerticalAlign.Middle;
                                                        excelSheet1.get_Range(EndingMileage + k, EndingMileage + k).Value2 = AuthCode;


                                                        if (CreditCardNumber_data == "ccy")
                                                            excelSheet1.get_Range(CreditCardNo1 + k, CreditCardNo1 + k).Value2 = CreditCardNumber_data;
                                                        /* * */
                                                        #endregion

                                                        data_row = rowcount + 1;

                                                        #region update ExcelExported

                                                        /*update ExcelExported filed 1 in Dailyoperationlog Table once data exported in excel file */
                                                        ObjGroomer.updateExcelExported(Convert.ToInt32(dsNoExp.Tables[0].Rows[rowcount]["DailyLogId"].ToString()), 1);
                                                        if (EndingMileage_Data != "0")
                                                        {
                                                            ObjGroomer.updateExcelExportedEndingMileage(Convert.ToInt32(dsNoExp.Tables[0].Rows[rowcount]["DailyLogId"].ToString()), 1);
                                                        }
                                                        #endregion
                                                        flagSuccMsg = "S";
                                                        goto NextRow;
                                                        #endregion

                                                    }
                                                    else
                                                    {
                                                        if (ExcelRowId == k.ToString())
                                                        {
                                                            #region overwrite transation
                                                            #region fileds
                                                            excelSheet1.get_Range(Job1 + k, Job1 + k).Value2 = Job_Data;
                                                            excelSheet1.get_Range(CustomerName1 + k, CustomerName1 + k).Value2 = CustomerName_Data;
                                                            excelSheet1.get_Range(ZipCode1 + k, ZipCode1 + k).Value2 = ZipCode_Data;
                                                            excelSheet1.get_Range(Pets1 + k, Pets1 + k).Value2 = Pets_Data;
                                                            excelSheet1.get_Range(Rebook1 + k, Rebook1 + k).Value2 = Rebook_Data;
                                                            excelSheet1.get_Range(NextAppointmentDate + k, NextAppointmentDate + k).Value2 = NextAppointmentDate_Data + "," + NextAppointmentTime_Data + "," + ServicesForPet_Data;
                                                            excelSheet1.get_Range(FromRebook1 + k, FromRebook1 + k).Value2 = FromRebook_Data;
                                                            excelSheet1.get_Range(New1 + k, New1 + k).Value2 = New_Data;
                                                            excelSheet1.get_Range(PetTime1 + k, PetTime1 + k).Value2 = PetTime_Data;
                                                            excelSheet1.get_Range(ExtraServices1 + k, ExtraServices1 + k).Value2 = ExtraServices_Data;
                                                            //new
                                                            excelSheet1.get_Range(FleaandTick221 + k, FleaandTick221 + k).Value2 = FleaandTick22_Data;
                                                            excelSheet1.get_Range(FleaandTick441 + k, FleaandTick441 + k).Value2 = FleaandTick44_Data;
                                                            excelSheet1.get_Range(FleaandTick881 + k, FleaandTick881 + k).Value2 = FleaandTick88_Data;
                                                            excelSheet1.get_Range(FleaandTick1321 + k, FleaandTick1321 + k).Value2 = FleaandTick132_Data;
                                                            excelSheet1.get_Range(FleaandTickCat1 + k, FleaandTickCat1 + k).Value2 = FleaandTickCat_Data;
                                                            excelSheet1.get_Range(TB1 + k, TB1 + k).Value2 = TB_Data;
                                                            excelSheet1.get_Range(Wham1 + k, Wham1 + k).Value2 = Wham_Data;

                                                            #endregion
                                                            #region revenue 7 cells
                                                            excelSheet1.get_Range(RevenueCreditCard1 + k, RevenueCreditCard1 + k).Value2 = RevenueCreditCard_Data;
                                                            excelSheet1.get_Range(RevenueCheck1 + k, RevenueCheck1 + k).Value2 = RevenueCheck_Data;
                                                            excelSheet1.get_Range(RevenueCash1 + k, RevenueCash1 + k).Value2 = RevenueCash_Data;
                                                            excelSheet1.get_Range(RevenueInvoice1 + k, RevenueInvoice1 + k).Value2 = RevenueInvoice_Data;
                                                            if (RevCCY_Data != "")
                                                            {
                                                                excelSheet1.get_Range(RevenueCreditCard1 + k, RevenueCreditCard1 + k).Value2 = RevCCY_Data;
                                                            }
                                                            //no data field found
                                                            excelSheet1.get_Range(ProductPrice1 + k, ProductPrice1 + k).Value2 = ProductPrice_Data;
                                                            excelSheet1.get_Range(SalesTax1 + k, SalesTax1 + k).Value2 = SalesTax_Data;
                                                            #endregion
                                                            #region Tip 4 cells
                                                            excelSheet1.get_Range(TipCreditCard1 + k, TipCreditCard1 + k).Value2 = TipCreditCard_Data;
                                                            excelSheet1.get_Range(TipCheck1 + k, TipCheck1 + k).Value2 = TipCheck_Data;
                                                            excelSheet1.get_Range(TipCash1 + k, TipCash1 + k).Value2 = TipCash_Data;
                                                            excelSheet1.get_Range(TipInvoice1 + k, TipInvoice1 + k).Value2 = TipInvoice_Data;
                                                            #endregion
                                                            #region Prior Revenue 8 cells
                                                            excelSheet1.get_Range(PriorCreditCard1 + k, PriorCreditCard1 + k).Value2 = PriorCreditCard_Data;
                                                            excelSheet1.get_Range(PriorCheck1 + k, PriorCheck1 + k).Value2 = PriorCheck_Data;
                                                            excelSheet1.get_Range(PriorCash1 + k, PriorCash1 + k).Value2 = PriorCash_Data;
                                                            //Bind all Data  in CreditCardNo_Data so apply this variable to all
                                                            excelSheet1.get_Range(CreditCardNo1 + k, CreditCardNo1 + k).Value2 = CreditCardNo_Data;
                                                            excelSheet1.get_Range(CreditCardExpir1 + k, CreditCardExpir1 + k).Value2 = CreditCardNo_Data;
                                                            excelSheet1.get_Range(CreditCardName + k, CreditCardName + k).Value2 = CreditCardNo_Data;
                                                            excelSheet1.get_Range(CreditCardAddr + k, CreditCardAddr + k).Value2 = CreditCardNo_Data;
                                                            excelSheet1.get_Range(SecurityCode1 + k, SecurityCode1 + k).Value2 = CreditCardNo_Data;
                                                            if (CreditCardNumber_data == "ccy")
                                                                excelSheet1.get_Range(CreditCardNo1 + k, CreditCardNo1 + k).Value2 = CreditCardNumber_data;
                                                            /* * */
                                                            #endregion
                                                            #region Inventory 27 cell

                                                            #endregion
                                                            data_row = rowcount + 1;
                                                            flagSuccMsg = "S";


                                                            #region update ExcelExported
                                                            /*update ExcelExported filed 1 in Dailyoperationlog Table once data exported in excel file */
                                                            ObjGroomer.updateExcelExported(Convert.ToInt32(dsNoExp.Tables[0].Rows[rowcount]["DailyLogId"].ToString()), 1);
                                                            if (EndingMileage_Data != "")
                                                            {
                                                                ObjGroomer.updateExcelExportedEndingMileage(Convert.ToInt32(dsNoExp.Tables[0].Rows[rowcount]["DailyLogId"].ToString()), 1);
                                                            }
                                                            #endregion

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
                                            }// for loop end of export to  secondary cell
                                            #endregion
                                        }
                                    }
                                }

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
                }
                #endregion
                #region close file
                excelApp.DisplayAlerts = false;
                excelApp.ActiveWorkbook.Save();
                excelApp.ActiveWorkbook.Close(true, ExistsExcelFilePath1, missing);
                excelApp.Quit();
                releaseObject(excelApp);
                releaseObject(excelSheet1);
                releaseObject(excelWorkBook);
                #endregion
            }
        }
        catch (Exception ex)
        {
            // throw ex;
            string error = ex.ToString();
            lblError.Visible = true; divError.Visible = true;
            lblError.Text = error;
            releaseObject(excelWorkBook);
        }
        //finally
        //{
        //    excelApp.DisplayAlerts = false;
        //    excelApp.ActiveWorkbook.Save();
        //    excelApp.ActiveWorkbook.Close(true, ExistsExcelFilePath1, missing);
        //    excelApp.Quit();
        //    releaseObject(excelApp);
        //    releaseObject(excelSheet1);
        //    releaseObject(excelWorkBook);
        //}
    }
    #endregion

    #region 2.Get UnExported groomerInventorydata
    public void ExportToExcelNewInventroy()
    {
        try
        {
            dsNoExpInv = ObjGroomer.GetUnExportedgroomerInventorydata();
            if (dsNoExpInv.Tables[0].Rows.Count > 0)
            {
                string password = "";

                DataSet dsExLog = ObjGroomer.getExcelData();
                if (dsExLog.Tables.Count > 0)
                {
                    if (dsExLog.Tables[0].Rows.Count > 0)
                    {
                        password = dsExLog.Tables[0].Rows[0]["SpreadsheetPassword"].ToString().Trim();
                    }
                }

                Excel.Workbook excelWorkBook = excelAppInv.Workbooks.Open(ExistsExcelFilePath1, 0, false, 5, password, password, true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);
                Excel.Range range = null;
                NextRow:
                for (int rowcountInv = data_rowInv; rowcountInv < dsNoExpInv.Tables[0].Rows.Count; rowcountInv++)
                {
                    DateTime dt = Convert.ToDateTime(dsNoExpInv.Tables[0].Rows[rowcountInv]["TodaysDate"]);

                    strSelDate = getMonth(dt.Month.ToString()) + " " + dt.Day + "," + " " + dt.Year;
                    getCellInventroy();
                    strdate = dsNoExpInv.Tables[0].Rows[rowcountInv]["TodaysDate"].ToString();

                    int numSheets = excelWorkBook.Sheets.Count;
                    excelAppInv.Visible = false;
                    Excel.Sheets excelSheetsInv = excelWorkBook.Worksheets;
                    for (int sheetNum = 1; sheetNum < numSheets; sheetNum++)
                    {
                        excelSheetInv2 = (Excel.Worksheet)excelSheetsInv.get_Item(sheetNum);
                        string strWorksheetName = excelSheetInv2.Name;
                        if (strWorksheetName == dsNoExpInv.Tables[0].Rows[rowcountInv]["sheetName"].ToString())
                        {
                            excelSheetInv2 = (Excel.Worksheet)excelSheetsInv.get_Item(dsNoExpInv.Tables[0].Rows[rowcountInv]["sheetName"].ToString());
                            if (dsExInv.Tables[0].Rows.Count > 0)
                            {
                                getDailyOperationLogInventroy(rowcountInv, dsNoExpInv);
                                #region writing in excel

                                #region export to  Parant cell
                                if (excelSheetInv2 != null)
                                {
                                }
                                #endregion
                                for (int r = 8; r < 381; r = r + 12)
                                {
                                    range = excelSheetInv2.get_Range("B" + r, "B" + r);
                                    strdate = excelSheetInv2.get_Range("B" + r, "B" + r).Text.ToString();
                                    if (strdate == string.Empty)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if (strdate == strSelDate)
                                        {
                                            secRowInv = r + 2;

                                            excelSheetInv2.get_Range(FleaTick22 + r, FleaTick22 + r).Value2 = FleaTick22_Data;
                                            excelSheetInv2.get_Range(FleaTick44 + r, FleaTick44 + r).Value2 = FleaTick44_Data;
                                            excelSheetInv2.get_Range(FleaTick88 + r, FleaTick88 + r).Value2 = FleaTick88_Data;
                                            excelSheetInv2.get_Range(FleaTick132 + r, FleaTick132 + r).Value2 = FleaTick132_Data;
                                            excelSheetInv2.get_Range(FleaTickcAT + r, FleaTickcAT + r).Value2 = FleaTickcAT_Data;

                                            excelSheetInv2.get_Range(Toothbrushes + r, Toothbrushes + r).Value2 = Toothbrushes_Data;
                                            excelSheetInv2.get_Range(WhamInv + r, WhamInv + r).Value2 = WhamInv_Data;
                                            excelSheetInv2.get_Range(Towels + r, Towels + r).Value2 = Towels_Data;
                                            excelSheetInv2.get_Range(Treats + r, Treats + r).Value2 = Treats_Data;
                                            excelSheetInv2.get_Range(CottonSwabs + r, CottonSwabs + r).Value2 = CottonSwabs_Data;
                                            excelSheetInv2.get_Range(EarWipes + r, EarWipes + r).Value2 = EarWipes_Data;
                                            excelSheetInv2.get_Range(VetWrap + r, VetWrap + r).Value2 = VetWrap_Data;
                                            excelSheetInv2.get_Range(PaperTowels + r, PaperTowels + r).Value2 = PaperTowels_Data;
                                            excelSheetInv2.get_Range(GarbageBags + r, GarbageBags + r).Value2 = GarbageBags_Data;
                                            excelSheetInv2.get_Range(Receipts + r, Receipts + r).Value2 = Receipts_Data;
                                            excelSheetInv2.get_Range(Envelopes + r, Envelopes + r).Value2 = Envelopes_Data;
                                            excelSheetInv2.get_Range(BusinessCards + r, BusinessCards + r).Value2 = BusinessCards_Data;

                                            excelSheetInv2.get_Range(Other1 + r, Other1 + r).Value2 = Other1_Data;
                                            excelSheetInv2.get_Range(Other2 + r, Other2 + r).Value2 = Other2_Data;
                                            excelSheetInv2.get_Range(Other3 + r, Other3 + r).Value2 = Other3_Data;
                                            excelSheetInv2.get_Range(Other4 + r, Other4 + r).Value2 = Other4_Data;
                                            excelSheetInv2.get_Range(Other5 + r, Other5 + r).Value2 = Other5_Data;

                                            excelSheetInv2.get_Range(Marketing1 + r, Marketing1 + r).Value2 = Marketing1_Data;
                                            excelSheetInv2.get_Range(Marketing2 + r, Marketing2 + r).Value2 = Marketing2_Data;
                                            excelSheetInv2.get_Range(Marketing3 + r, Marketing3 + r).Value2 = Marketing3_Data;
                                            excelSheetInv2.get_Range(Marketing4 + r, Marketing4 + r).Value2 = Marketing4_Data;
                                            excelSheetInv2.get_Range(Marketing5 + r, Marketing5 + r).Value2 = Marketing5_Data;
                                            //added comments in to excel 16jan13
                                            excelSheetInv2.get_Range(comments1 + r, comments1 + r).Value2 = comments_Data;

                                            excelSheetInv2.get_Range(Liquid1 + r, Liquid1 + r).Value2 = Liquid1_Data;
                                            excelSheetInv2.get_Range(Liquid2 + r, Liquid2 + r).Value2 = Liquid2_Data;
                                            excelSheetInv2.get_Range(Liquid3 + r, Liquid3 + r).Value2 = Liquid3_Data;
                                            excelSheetInv2.get_Range(Liquid4 + r, Liquid4 + r).Value2 = Liquid4_Data;
                                            excelSheetInv2.get_Range(Liquid5 + r, Liquid5 + r).Value2 = Liquid5_Data;
                                            excelSheetInv2.get_Range(Liquid6 + r, Liquid6 + r).Value2 = Liquid6_Data;
                                            excelSheetInv2.get_Range(Liquid7 + r, Liquid7 + r).Value2 = Liquid7_Data;
                                            excelSheetInv2.get_Range(Liquid8 + r, Liquid8 + r).Value2 = Liquid8_Data;
                                            excelSheetInv2.get_Range(Liquid9 + r, Liquid9 + r).Value2 = Liquid9_Data;
                                            excelSheetInv2.get_Range(Liquid10 + r, Liquid10 + r).Value2 = Liquid10_Data;
                                            excelSheetInv2.get_Range(Liquid11 + r, Liquid11 + r).Value2 = Liquid11_Data;
                                            excelSheetInv2.get_Range(Liquid12 + r, Liquid12 + r).Value2 = Liquid12_Data;
                                            excelSheetInv2.get_Range(Liquid13 + r, Liquid13 + r).Value2 = Liquid13_Data;
                                            excelSheetInv2.get_Range(Liquid14 + r, Liquid14 + r).Value2 = Liquid14_Data;
                                            excelSheetInv2.get_Range(Liquid15 + r, Liquid15 + r).Value2 = Liquid15_Data;
                                            excelSheetInv2.get_Range(Liquid16 + r, Liquid16 + r).Value2 = Liquid16_Data;
                                            excelSheetInv2.get_Range(Liquid17 + r, Liquid17 + r).Value2 = Liquid17_Data;
                                            excelSheetInv2.get_Range(Liquid18 + r, Liquid18 + r).Value2 = Liquid18_Data;
                                            excelSheetInv2.get_Range(Liquid19 + r, Liquid19 + r).Value2 = Liquid19_Data;
                                            excelSheetInv2.get_Range(Liquid20 + r, Liquid20 + r).Value2 = Liquid20_Data;
                                            excelSheetInv2.get_Range(Liquid21 + r, Liquid21 + r).Value2 = Liquid21_Data;
                                            excelSheetInv2.get_Range(Liquid22 + r, Liquid22 + r).Value2 = Liquid22_Data;
                                            excelSheetInv2.get_Range(Liquid23 + r, Liquid23 + r).Value2 = Liquid23_Data;
                                            excelSheetInv2.get_Range(Liquid24 + r, Liquid24 + r).Value2 = Liquid24_Data;
                                            excelSheetInv2.get_Range(Liquid25 + r, Liquid25 + r).Value2 = Liquid25_Data;

                                            data_rowInv = rowcountInv + 1;
                                            #region update ExcelExported

                                            /*update ExcelExported filed 1 in Dailyoperationlog Table once data exported in excel file */
                                            ObjGroomer.updateExcelExportedInventory(Convert.ToInt32(dsNoExpInv.Tables[0].Rows[rowcountInv]["InventroyId"].ToString()), 1);
                                            goto NextRow;
                                            #endregion
                                        }
                                    }
                                }
                                #endregion

                                //}for loop end here 

                                if (flagSuccMsg == "S")
                                {
                                    lblError.Attributes.Add("Class", "successTable");
                                    lblError.Visible = true; divError.Visible = true;
                                    lblError.Text = "Data Successfuly exported to Excel file !!!!";
                                }
                                //CloseApp:
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
                }

                #region close file
                excelAppInv.DisplayAlerts = false;
                excelAppInv.ActiveWorkbook.Save();
                excelAppInv.ActiveWorkbook.Close(true, ExistsExcelFilePath1, missingInv);
                excelAppInv.Quit();
                releaseObject(excelAppInv);
                releaseObject(excelSheetInv2);
                releaseObject(excelWorkBook);
                #endregion
            }
        }
        catch (Exception ex)
        {
            //throw ex;
            string error = ex.ToString();
            lblError.Visible = true; divError.Visible = true;
            lblError.Text = error;
        }

    }
    #endregion

    #region 3.UnExported PrePayment Information
    public void ExportToExcelGift()
    {
        try
        {
            dsNoExpGift = ObjGroomer.GetPrePaymentData();
            // need to export pre-payment data here
            if (dsNoExpGift.Tables[0].Rows.Count > 0)
            {
                string password = "";

                DataSet dsExLog = ObjGroomer.getExcelData();

                if (dsExLog.Tables.Count > 0)
                {
                    if (dsExLog.Tables[0].Rows.Count > 0)
                    {
                        password = dsExLog.Tables[0].Rows[0]["SpreadsheetPassword"].ToString().Trim();
                    }
                }
                Excel.Workbook excelWorkBook = excelAppGift.Workbooks.Open(ExistsExcelFilePath1, 0, false, 5, password, password, true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);
                Excel.Range range = null;
                NextRow:
                for (int rowcount = data_row; rowcount < dsNoExpGift.Tables[0].Rows.Count; rowcount++)
                {
                    DateTime dt = Convert.ToDateTime(dsNoExpGift.Tables[0].Rows[rowcount]["Addedon"]);

                    strSelDate = getMonth(dt.Month.ToString()) + " " + dt.Day + "," + " " + dt.Year;
                    getCellforPrePayment();
                    strdate = dsNoExpGift.Tables[0].Rows[rowcount]["Addedon"].ToString();

                    int numSheets = excelWorkBook.Sheets.Count;
                    excelAppGift.Visible = false;
                    Excel.Sheets excelSheets = excelWorkBook.Worksheets;
                    for (int sheetNum = 1; sheetNum < numSheets; sheetNum++)
                    {
                        excelSheet1 = (Excel.Worksheet)excelSheets.get_Item(sheetNum);
                        string strWorksheetName = excelSheet1.Name;
                        if (strWorksheetName == "GiftCards")
                        {
                            excelSheet1 = (Excel.Worksheet)excelSheets.get_Item("GiftCards");
                            if (dsExGift.Tables[0].Rows.Count > 0)
                            {
                                getPrePaymentLog(rowcount, dsNoExpGift);
                                #region writing in excel

                                //#region export to  Parant cell
                                //if (excelSheet1 != null)
                                //{
                                //    range = excelSheet1.get_Range(VanId, VanId);
                                //    excelSheet1.get_Range(VanId, VanId).Value2 = VanId_Data;
                                //}
                                #endregion
                                for (int r = 8; r < 381; r = r + 12)
                                {
                                    range = excelSheet1.get_Range("B" + r, "B" + r);
                                    strdate = excelSheet1.get_Range("B" + r, "B" + r).Text.ToString();
                                    if (strdate == string.Empty)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if (strdate == strSelDate)
                                        {
                                            secRow = r + 2;


                                            #region export to  secondary cell
                                            for (int k = secRow; k < (secRow + 10); k++)
                                            {
                                                range = excelSheet1.get_Range("A" + k, "A" + k);
                                                //check if job is null
                                                if (range != null)
                                                {
                                                    if (excelSheet1.get_Range("A" + k, "A" + k).Text.ToString() == string.Empty)
                                                    {
                                                        #region fileds
                                                        excelSheet1.get_Range(Job1 + k, Job1 + k).Value2 = Job_Data;
                                                        excelSheet1.get_Range(CustomerName1 + k, CustomerName1 + k).Value2 = CustomerName_Data;

                                                        //excelSheet1.get_Range("U" + k, "U" + k).Value2 = CreditCardNumber_data;
                                                        //excelSheet1.get_Range(CreditCardNo1 + k, CreditCardNo1 + k).Value2 = CreditCardNumber_data;
                                                        #endregion
                                                        #region revenue 7 cells
                                                        excelSheet1.get_Range(RevenueCreditCard1 + k, RevenueCreditCard1 + k).Value2 = RevenueCreditCard_Data;


                                                        #endregion
                                                        #region Tip 4 cells
                                                        excelSheet1.get_Range(TipCreditCard1 + k, TipCreditCard1 + k).Value2 = TipCreditCard_Data;

                                                        #endregion
                                                        #region Prior Revenue 8 cells
                                                        excelSheet1.get_Range(PriorCreditCard1 + k, PriorCreditCard1 + k).Value2 = PriorCreditCard_Data;

                                                        //Bind all Data  in CreditCardNo_Data so apply this variable to all
                                                        excelSheet1.get_Range(CreditCardNo1 + k, CreditCardNo1 + k).Value2 = CreditCardNo_Data;
                                                        excelSheet1.get_Range(CreditCardExpir1 + k, CreditCardExpir1 + k).Value2 = CreditCardNo_Data;
                                                        excelSheet1.get_Range(CreditCardName + k, CreditCardName + k).Value2 = CreditCardNo_Data;
                                                        excelSheet1.get_Range(CreditCardAddr + k, CreditCardAddr + k).Value2 = CreditCardNo_Data;
                                                        excelSheet1.get_Range(SecurityCode1 + k, SecurityCode1 + k).Value2 = CreditCardNo_Data;
                                                        excelSheet1.get_Range(EndingMileage + k, EndingMileage + k).VerticalAlignment = VerticalAlign.Middle;
                                                        excelSheet1.get_Range(EndingMileage + k, EndingMileage + k).Value2 = AuthCode;

                                                        if (CreditCardNumber_data == "ccy")
                                                            excelSheet1.get_Range(CreditCardNo1 + k, CreditCardNo1 + k).Value2 = CreditCardNumber_data;
                                                        /* * */
                                                        #endregion
                                                        //break;
                                                        //ObjGroomer.ModifyExportFlag(DailylogId, k);
                                                        data_row = rowcount + 1;

                                                        ObjGroomer.updatePrepaymentExcelExported(Convert.ToInt32(dsNoExpGift.Tables[0].Rows[rowcount]["prePayId"].ToString()));

                                                        flagSuccMsg = "S";
                                                        goto NextRow;
                                                        #endregion

                                                    }
                                                    else
                                                    {
                                                        if (ExcelRowId == k.ToString())
                                                        {
                                                            #region overwrite transation
                                                            #region fileds
                                                            excelSheet1.get_Range(Job1 + k, Job1 + k).Value2 = Job_Data;
                                                            excelSheet1.get_Range(CustomerName1 + k, CustomerName1 + k).Value2 = CustomerName_Data;


                                                            // excelSheet1.get_Range("U" + k, "U" + k).Value2 = CreditCardNumber_data;
                                                            // excelSheet1.get_Range(CreditCardNo1 + k, CreditCardNo1 + k).Value2 = CreditCardNumber_data;
                                                            #endregion
                                                            #region revenue 7 cells
                                                            excelSheet1.get_Range(RevenueCreditCard1 + k, RevenueCreditCard1 + k).Value2 = RevenueCreditCard_Data;

                                                            #endregion
                                                            #region Tip 4 cells
                                                            excelSheet1.get_Range(TipCreditCard1 + k, TipCreditCard1 + k).Value2 = TipCreditCard_Data;

                                                            #endregion
                                                            #region Prior Revenue 8 cells
                                                            excelSheet1.get_Range(PriorCreditCard1 + k, PriorCreditCard1 + k).Value2 = PriorCreditCard_Data;

                                                            //Bind all Data  in CreditCardNo_Data so apply this variable to all
                                                            excelSheet1.get_Range(CreditCardNo1 + k, CreditCardNo1 + k).Value2 = CreditCardNo_Data;
                                                            excelSheet1.get_Range(CreditCardExpir1 + k, CreditCardExpir1 + k).Value2 = CreditCardNo_Data;
                                                            excelSheet1.get_Range(CreditCardName + k, CreditCardName + k).Value2 = CreditCardNo_Data;
                                                            excelSheet1.get_Range(CreditCardAddr + k, CreditCardAddr + k).Value2 = CreditCardNo_Data;
                                                            excelSheet1.get_Range(SecurityCode1 + k, SecurityCode1 + k).Value2 = CreditCardNo_Data;
                                                            if (CreditCardNumber_data == "ccy")
                                                                excelSheet1.get_Range(CreditCardNo1 + k, CreditCardNo1 + k).Value2 = CreditCardNumber_data;
                                                            /* * */
                                                            #endregion

                                                            //break;
                                                            //ObjGroomer.ModifyExportFlag(DailylogId, k);
                                                            data_row = rowcount + 1;
                                                            flagSuccMsg = "S";


                                                            #region update ExcelExported

                                                            ObjGroomer.updatePrepaymentExcelExported(Convert.ToInt32(dsNoExpGift.Tables[0].Rows[rowcount]["prePayId"].ToString()));

                                                            #endregion

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
                                            }// for loop end of export to  secondary cell

                                        }
                                    }
                                }

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
                }
                #region close file
                excelAppGift.DisplayAlerts = false;
                excelAppGift.ActiveWorkbook.Save();
                excelAppGift.ActiveWorkbook.Close(true, ExistsExcelFilePath1, missingGift);
                excelAppGift.Quit();
                releaseObject(excelAppGift);
                releaseObject(excelSheet1);
                releaseObject(excelWorkBook);
                #endregion
            }
        }
        catch (Exception ex)
        {
            //throw ex;
            string error = ex.ToString();
            lblError.Visible = true; divError.Visible = true;
            lblError.Text = error;
        }
    }
    #endregion

    #region 4. Get Unexported groomerlogdataEnding
    public void ExportToExcelEndingMileage()
    {
        try
        {
            dsNoExpEnd = ObjGroomer.GetUuExportedgroomerlogdataEndingM();
            if (dsNoExpEnd.Tables[0].Rows.Count > 0)
            {
                string password = "";

                DataSet dsExLog = ObjGroomer.getExcelData();
                if (dsExLog.Tables.Count > 0)
                {
                    if (dsExLog.Tables[0].Rows.Count > 0)
                    {
                        password = dsExLog.Tables[0].Rows[0]["SpreadsheetPassword"].ToString().Trim();
                    }
                }

                Excel.Workbook excelWorkBook = excelAppEnd.Workbooks.Open(ExistsExcelFilePath1, 0, false, 5, password, password, true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);
                Excel.Range range = null;
                NextRow:
                for (int rowcountEnd = data_rowEnd; rowcountEnd < dsNoExpEnd.Tables[0].Rows.Count; rowcountEnd++)
                {
                    DateTime dt = Convert.ToDateTime(dsNoExpEnd.Tables[0].Rows[rowcountEnd]["Addedon"]);

                    strSelDate = getMonth(dt.Month.ToString()) + " " + dt.Day + "," + " " + dt.Year;
                    getCellEndingMileage();
                    strdate = dsNoExpEnd.Tables[0].Rows[rowcountEnd]["Addedon"].ToString();

                    int numSheets = excelWorkBook.Sheets.Count;
                    excelAppEnd.Visible = false;
                    Excel.Sheets excelSheetsEnd = excelWorkBook.Worksheets;
                    for (int sheetNum = 1; sheetNum < numSheets; sheetNum++)
                    {
                        excelSheetEnd3 = (Excel.Worksheet)excelSheetsEnd.get_Item(sheetNum);
                        string strWorksheetName = excelSheetEnd3.Name;
                        if (strWorksheetName == dsNoExpEnd.Tables[0].Rows[rowcountEnd]["sheetName"].ToString())
                        {
                            excelSheetEnd3 = (Excel.Worksheet)excelSheetsEnd.get_Item(dsNoExpEnd.Tables[0].Rows[rowcountEnd]["sheetName"].ToString());
                            if (dsExEnd.Tables[0].Rows.Count > 0)
                            {
                                getDailyOperationLogEndingMileage(rowcountEnd, dsNoExpEnd);
                                #region writing in excel

                                #region export to  Parant cell
                                if (excelSheetEnd3 != null)
                                {
                                }
                                #endregion
                                for (int r = 8; r < 381; r = r + 12)
                                {
                                    range = excelSheetEnd3.get_Range("B" + r, "B" + r);
                                    strdate = excelSheetEnd3.get_Range("B" + r, "B" + r).Text.ToString();
                                    if (strdate == string.Empty)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if (strdate == strSelDate)
                                        {
                                            secRowEnd = r + 2;
                                            excelSheetEnd3.get_Range(TotlaHours + r, TotlaHours + r).Value2 = TotlaHours_Data;
                                            excelSheetEnd3.get_Range(EndingMileage + r, EndingMileage + r).Value2 = EndingMileage_Data;
                                            excelSheetEnd3.get_Range(FuelPurchased + r, FuelPurchased + r).Value2 = FuelPurchased_Data;
                                            excelSheetEnd3.get_Range(PricePerGallon + r, PricePerGallon + r).Value2 = PricePerGallon_Data;
                                            #region update ExcelExported
                                            data_rowEnd = rowcountEnd + 1;
                                            /*update ExcelExported filed 1 in Dailyoperationlog Table once data exported in excel file */
                                            ObjGroomer.updateExcelExportedEndingMileage(Convert.ToInt32(dsNoExpEnd.Tables[0].Rows[rowcountEnd]["DailyLogId"].ToString()), 1);
                                            //ObjGroomer.updateExcelExportedEndingMileage(Convert.ToInt32(dsNoExpEnd.Tables[0].Rows[rowcountEnd]["pfieldid"].ToString()), 1);
                                            goto NextRow;
                                            #endregion
                                        }
                                    }
                                }
                                #endregion
                                //}for loop end here 
                            }
                        }
                    }
                }

                #region close file
                excelAppEnd.DisplayAlerts = false;
                excelAppEnd.ActiveWorkbook.Save();
                excelAppEnd.ActiveWorkbook.Close(true, ExistsExcelFilePath1, missingEnd);
                excelAppEnd.Quit();
                releaseObject(excelAppEnd);
                releaseObject(excelSheetEnd3);
                releaseObject(excelWorkBook);
                #endregion
            }
        }
        catch (Exception ex)
        {
            // throw ex;
            string error = ex.ToString();
            lblError.Visible = true; divError.Visible = true;
            lblError.Text = error;
        }
        //catch (System.Runtime.InteropServices.COMException ex)
        //{
        //}
    }

    #endregion

    #endregion

    #region Support Functions

    public void getCellInventroy()
    {
        #region get Excel data
        dsExInv = ObjGroomer.getExcelData();
        if (dsExInv.Tables[0].Rows.Count > 0)
        {
            FleaTick22 = dsExInv.Tables[0].Rows[0]["FleaTick22"].ToString().Trim();
            FleaTick44 = dsExInv.Tables[0].Rows[0]["FleaTick44"].ToString().Trim();
            FleaTick88 = dsExInv.Tables[0].Rows[0]["FleaTick88"].ToString().Trim();
            FleaTick132 = dsExInv.Tables[0].Rows[0]["FleaTick132"].ToString().Trim();
            FleaTickcAT = dsExInv.Tables[0].Rows[0]["FleaTickcAT"].ToString().Trim();
            Toothbrushes = dsExInv.Tables[0].Rows[0]["Toothbrushes"].ToString().Trim();
            WhamInv = dsExInv.Tables[0].Rows[0]["WhamInv"].ToString().Trim();
            Towels = dsExInv.Tables[0].Rows[0]["Towels"].ToString().Trim();
            CottonSwabs = dsExInv.Tables[0].Rows[0]["CottonSwabs"].ToString().Trim();
            PaperTowels = dsExInv.Tables[0].Rows[0]["PaperTowels"].ToString().Trim();
            GarbageBags = dsExInv.Tables[0].Rows[0]["GarbageBags"].ToString().Trim();
            Treats = dsExInv.Tables[0].Rows[0]["Treats"].ToString().Trim();
            VetWrap = dsExInv.Tables[0].Rows[0]["VetWrap"].ToString().Trim();
            EarWipes = dsExInv.Tables[0].Rows[0]["Wipes"].ToString().Trim();
            Envelopes = dsExInv.Tables[0].Rows[0]["Envelopes"].ToString().Trim();
            Receipts = dsExInv.Tables[0].Rows[0]["Receipts"].ToString().Trim();
            BusinessCards = dsExInv.Tables[0].Rows[0]["BusinessCards"].ToString().Trim();
            Other1 = dsExInv.Tables[0].Rows[0]["Other1"].ToString().Trim();
            Other2 = dsExInv.Tables[0].Rows[0]["Other2"].ToString().Trim();
            Other3 = dsExInv.Tables[0].Rows[0]["Other3"].ToString().Trim();
            Other4 = dsExInv.Tables[0].Rows[0]["Other4"].ToString().Trim();
            Other5 = dsExInv.Tables[0].Rows[0]["Other5"].ToString().Trim();

            Marketing1 = dsExInv.Tables[0].Rows[0]["Marketing1"].ToString().Trim();
            Marketing2 = dsExInv.Tables[0].Rows[0]["Marketing2"].ToString().Trim();
            Marketing3 = dsExInv.Tables[0].Rows[0]["Marketing3"].ToString().Trim();
            Marketing4 = dsExInv.Tables[0].Rows[0]["Marketing4"].ToString().Trim();
            Marketing5 = dsExInv.Tables[0].Rows[0]["Marketing5"].ToString().Trim();
            //assign data to comments variable from db 16jan13
            comments1 = dsExInv.Tables[0].Rows[0]["Comments"].ToString().Trim();
            rDriveTime1 = dsExInv.Tables[0].Rows[0]["Drive_Time"].ToString().Trim();
            rPetTime1 = dsExInv.Tables[0].Rows[0]["Pet_Time"].ToString().Trim();

            Liquid1 = dsExInv.Tables[0].Rows[0]["Liquid1"].ToString().Trim();
            Liquid2 = dsExInv.Tables[0].Rows[0]["Liquid2"].ToString().Trim();
            Liquid3 = dsExInv.Tables[0].Rows[0]["Liquid3"].ToString().Trim();
            Liquid4 = dsExInv.Tables[0].Rows[0]["Liquid4"].ToString().Trim();
            Liquid5 = dsExInv.Tables[0].Rows[0]["Liquid5"].ToString().Trim();
            Liquid6 = dsExInv.Tables[0].Rows[0]["Liquid6"].ToString().Trim();
            Liquid7 = dsExInv.Tables[0].Rows[0]["Liquid7"].ToString().Trim();
            Liquid8 = dsExInv.Tables[0].Rows[0]["Liquid8"].ToString().Trim();
            Liquid9 = dsExInv.Tables[0].Rows[0]["Liquid9"].ToString().Trim();
            Liquid10 = dsExInv.Tables[0].Rows[0]["Liquid10"].ToString().Trim();
            Liquid11 = dsExInv.Tables[0].Rows[0]["Liquid11"].ToString().Trim();
            Liquid12 = dsExInv.Tables[0].Rows[0]["Liquid12"].ToString().Trim();
            Liquid13 = dsExInv.Tables[0].Rows[0]["Liquid13"].ToString().Trim();
            Liquid14 = dsExInv.Tables[0].Rows[0]["Liquid14"].ToString().Trim();
            Liquid15 = dsExInv.Tables[0].Rows[0]["Liquid15"].ToString().Trim();
            Liquid16 = dsExInv.Tables[0].Rows[0]["Liquid16"].ToString().Trim();
            Liquid17 = dsExInv.Tables[0].Rows[0]["Liquid17"].ToString().Trim();
            Liquid18 = dsExInv.Tables[0].Rows[0]["Liquid18"].ToString().Trim();
            Liquid19 = dsExInv.Tables[0].Rows[0]["Liquid19"].ToString().Trim();
            Liquid20 = dsExInv.Tables[0].Rows[0]["Liquid20"].ToString().Trim();
            Liquid21 = dsExInv.Tables[0].Rows[0]["Liquid21"].ToString().Trim();
            Liquid22 = dsExInv.Tables[0].Rows[0]["Liquid22"].ToString().Trim();
            Liquid23 = dsExInv.Tables[0].Rows[0]["Liquid23"].ToString().Trim();
            Liquid24 = dsExInv.Tables[0].Rows[0]["Liquid24"].ToString().Trim();
            Liquid25 = dsExInv.Tables[0].Rows[0]["Liquid25"].ToString().Trim();
        }
        #endregion
    }
    public void getCellforPrePayment()
    {
        #region get Excel data
        dsExGift = ObjGroomer.getExcelData();
        if (dsExGift.Tables[0].Rows.Count > 0)
        {
            CustomerName1 = dsExGift.Tables[0].Rows[0]["CustomerName"].ToString().Trim();
            Job1 = dsExGift.Tables[0].Rows[0]["Job"].ToString().Trim();

            RevenueCreditCard1 = dsExGift.Tables[0].Rows[0]["RevenueCreditCard"].ToString().Trim();
            TipCreditCard1 = dsExGift.Tables[0].Rows[0]["TipCreditCard"].ToString().Trim();
            PriorCreditCard1 = dsExGift.Tables[0].Rows[0]["PriorCreditCard"].ToString().Trim();
            Addedon = dsExGift.Tables[0].Rows[0]["Addedon"].ToString().Trim();

            CreditCardNo1 = dsExGift.Tables[0].Rows[0]["CreditCardNo"].ToString().Trim();
            CreditCardExpir1 = dsExGift.Tables[0].Rows[0]["CreditCardExpir"].ToString().Trim();
            CreditCardName = dsExGift.Tables[0].Rows[0]["CreditCardName"].ToString().Trim();
            CreditCardAddr = dsExGift.Tables[0].Rows[0]["CreditCardAddr"].ToString().Trim();
            SecurityCode1 = dsExGift.Tables[0].Rows[0]["SecurityCode"].ToString().Trim();
            //CreditCardNo1 = dsEx.Tables[0].Rows[0]["CreditCard"].ToString().Trim();
            //CreditCardExpir1 = dsEx.Tables[0].Rows[0]["ValidMonth"].ToString().Trim() + "-" + dsEx.Tables[0].Rows[0]["ValidYear"].ToString().Trim();
            //CreditCardName = dsEx.Tables[0].Rows[0]["FirstName"].ToString().Trim() + " " + dsEx.Tables[0].Rows[0]["LastName"].ToString().Trim();
            //CreditCardAddr = dsEx.Tables[0].Rows[0]["Address1"].ToString().Trim() + " " + dsEx.Tables[0].Rows[0]["Address2"].ToString().Trim();
            //SecurityCode1 = dsEx.Tables[0].Rows[0]["VerificationCode"].ToString().Trim();
        }
        #endregion
    }
    public void getPrePaymentLog(int m, DataSet ds)
    {
        #region get cell data
        dsNoExpGift = ds;
        if (dsNoExpGift.Tables[0].Rows.Count > 0)
        {

            CustomerName_Data = dsNoExpGift.Tables[0].Rows[m]["TotalAmt"].ToString() + " " + dsNoExpGift.Tables[0].Rows[m]["payDescription"].ToString();
            Job_Data = dsNoExpGift.Tables[0].Rows[m]["FirstName"].ToString() + " " + dsNoExpGift.Tables[0].Rows[m]["LastName"].ToString();
            Addedon_Data = dsNoExpGift.Tables[0].Rows[m]["Addedon"].ToString();

            RevenueCreditCard_Data = dsNoExpGift.Tables[0].Rows[m]["RevAmt"].ToString(); if (RevenueCreditCard_Data == "0.000") { RevenueCreditCard_Data = ""; }
            TipCreditCard_Data = dsNoExpGift.Tables[0].Rows[m]["TipAmt"].ToString(); if (TipCreditCard_Data == "0.000") { TipCreditCard_Data = ""; }
            PriorCreditCard_Data = dsNoExpGift.Tables[0].Rows[m]["PriorAmt"].ToString(); if (PriorCreditCard_Data == "0.000") { PriorCreditCard_Data = ""; }

            //CreditCardNo1 = dsEx.Tables[0].Rows[0]["CreditCard"].ToString().Trim();
            //CreditCardExpir1 = dsEx.Tables[0].Rows[0]["ValidMonth"].ToString().Trim() + "-" + dsEx.Tables[0].Rows[0]["ValidYear"].ToString().Trim();
            //CreditCardName = dsEx.Tables[0].Rows[0]["FirstName"].ToString().Trim() + " " + dsEx.Tables[0].Rows[0]["LastName"].ToString().Trim();
            //CreditCardAddr = dsEx.Tables[0].Rows[0]["Address1"].ToString().Trim() + " " + dsEx.Tables[0].Rows[0]["Address2"].ToString().Trim();
            //    SecurityCode1 = dsEx.Tables[0].Rows[0]["VerificationCode"].ToString().Trim();

            //CreditCardNo_Data = "";
            //CreditCardNo_Data = dsNoExp.Tables[0].Rows[m]["CreditCard"].ToString();
            ////  DateTime dt1 = Convert.ToDateTime(dsNoExp.Tables[0].Rows[m]["ValidYear"].ToString());
            ////  CreditCardExpir_Data = dt1.ToShortDateString();
            //CreditCardExpir_Data = dsNoExp.Tables[0].Rows[m]["ValidMonth"].ToString() + "/" + dsNoExp.Tables[0].Rows[m]["ValidYear"].ToString();
            ////  CreditCardName_Data = dsNoExp.Tables[0].Rows[m]["FirstName"].ToString() + " " + dsNoExp.Tables[0].Rows[m]["LastName"].ToString();
            //CreditCardName_Data = dsNoExp.Tables[0].Rows[m]["FirstName"].ToString() + " " + dsNoExp.Tables[0].Rows[m]["LastName"].ToString();
            ////CreditCardName_Data1 = dsNoExp.Tables[0].Rows[m]["LastName"].ToString();
            //CreditCardAddr_Data = dsNoExp.Tables[0].Rows[m]["Address1"].ToString() + " " + dsNoExp.Tables[0].Rows[m]["Address2"].ToString() + "," + dsNoExp.Tables[0].Rows[m]["City"].ToString() + "," + dsNoExp.Tables[0].Rows[m]["State"].ToString() + "," + dsNoExp.Tables[0].Rows[m]["Zip"].ToString();

            //string creditcardnumberch = dsNoExp.Tables[0].Rows[m]["CreditCard"].ToString();

        }
        #endregion
    }
    public void getDailyOperationLogInventroy(int mInv, DataSet dsInv)
    {
        #region get cell data
        dsNoExpInv = dsInv;
        if (dsNoExpInv.Tables[0].Rows.Count > 0)
        {
            FleaTick22_Data = dsNoExpInv.Tables[0].Rows[mInv]["FleaTick22"].ToString(); if (Convert.ToInt32(FleaTick22_Data) == 0) { FleaTick22_Data = ""; }
            FleaTick44_Data = dsNoExpInv.Tables[0].Rows[mInv]["FleaTick44"].ToString(); if (Convert.ToInt32(FleaTick44_Data) == 0) { FleaTick44_Data = ""; }
            FleaTick88_Data = dsNoExpInv.Tables[0].Rows[mInv]["FleaTick88"].ToString(); if (Convert.ToInt32(FleaTick88_Data) == 0) { FleaTick88_Data = ""; }
            FleaTick132_Data = dsNoExpInv.Tables[0].Rows[mInv]["FleaTick132"].ToString(); if (Convert.ToInt32(FleaTick132_Data) == 0) { FleaTick132_Data = ""; }
            FleaTickcAT_Data = dsNoExpInv.Tables[0].Rows[mInv]["FleaTickcAT"].ToString(); if (Convert.ToInt32(FleaTickcAT_Data) == 0) { FleaTickcAT_Data = ""; }
            Toothbrushes_Data = dsNoExpInv.Tables[0].Rows[mInv]["Toothbrushes"].ToString(); if (Convert.ToInt32(Toothbrushes_Data) == 0) { Toothbrushes_Data = ""; }
            WhamInv_Data = dsNoExpInv.Tables[0].Rows[mInv]["Wham"].ToString(); if (Convert.ToInt32(WhamInv_Data) == 0) { WhamInv_Data = ""; }
            Towels_Data = dsNoExpInv.Tables[0].Rows[mInv]["Towels"].ToString(); if (Convert.ToInt32(Towels_Data) == 0) { Towels_Data = ""; }

            CottonSwabs_Data = dsNoExpInv.Tables[0].Rows[mInv]["CottonSwabs"].ToString(); if (Convert.ToInt32(CottonSwabs_Data) == 0) { CottonSwabs_Data = ""; }
            PaperTowels_Data = dsNoExpInv.Tables[0].Rows[mInv]["PaperTowels"].ToString(); if (Convert.ToInt32(PaperTowels_Data) == 0) { PaperTowels_Data = ""; }
            GarbageBags_Data = dsNoExpInv.Tables[0].Rows[mInv]["GarbageBags"].ToString(); if (Convert.ToInt32(GarbageBags_Data) == 0) { GarbageBags_Data = ""; }
            Treats_Data = dsNoExpInv.Tables[0].Rows[mInv]["Treats"].ToString(); if (Convert.ToInt32(Treats_Data) == 0) { Treats_Data = ""; }
            VetWrap_Data = dsNoExpInv.Tables[0].Rows[mInv]["VetWrap"].ToString(); if (Convert.ToInt32(VetWrap_Data) == 0) { VetWrap_Data = ""; }
            EarWipes_Data = dsNoExpInv.Tables[0].Rows[mInv]["Wipes"].ToString(); if (Convert.ToInt32(EarWipes_Data) == 0) { EarWipes_Data = ""; }
            Envelopes_Data = dsNoExpInv.Tables[0].Rows[mInv]["Envelopes"].ToString(); if (Convert.ToInt32(Envelopes_Data) == 0) { Envelopes_Data = ""; }
            Receipts_Data = dsNoExpInv.Tables[0].Rows[mInv]["Receipts"].ToString(); if (Convert.ToInt32(Receipts_Data) == 0) { Receipts_Data = ""; }
            BusinessCards_Data = dsNoExpInv.Tables[0].Rows[mInv]["BusinessCards"].ToString(); if (Convert.ToInt32(BusinessCards_Data) == 0) { BusinessCards_Data = ""; }

            Other1_Data = dsNoExpInv.Tables[0].Rows[mInv]["Other1"].ToString(); if (Other1_Data == "") { Other1_Data = ""; }
            Other2_Data = dsNoExpInv.Tables[0].Rows[mInv]["Other2"].ToString(); if (Other2_Data == "") { Other2_Data = ""; }
            Other3_Data = dsNoExpInv.Tables[0].Rows[mInv]["Other3"].ToString(); if (Other3_Data == "") { Other3_Data = ""; }
            Other4_Data = dsNoExpInv.Tables[0].Rows[mInv]["Other4"].ToString(); if (Other4_Data == "") { Other4_Data = ""; }
            Other5_Data = dsNoExpInv.Tables[0].Rows[mInv]["Other5"].ToString(); if (Other5_Data == "") { Other5_Data = ""; }

            Marketing1_Data = dsNoExpInv.Tables[0].Rows[mInv]["Marketing1"].ToString(); if (Marketing1_Data == "") { Marketing1_Data = ""; }
            Marketing2_Data = dsNoExpInv.Tables[0].Rows[mInv]["Marketing2"].ToString(); if (Marketing2_Data == "") { Marketing2_Data = ""; }
            Marketing3_Data = dsNoExpInv.Tables[0].Rows[mInv]["Marketing3"].ToString(); if (Marketing3_Data == "") { Marketing3_Data = ""; }
            Marketing4_Data = dsNoExpInv.Tables[0].Rows[mInv]["Marketing4"].ToString(); if (Marketing4_Data == "") { Marketing4_Data = ""; }
            Marketing5_Data = dsNoExpInv.Tables[0].Rows[mInv]["Marketing5"].ToString(); if (Marketing5_Data == "") { Marketing5_Data = ""; }

            //Comments 16jan13
            // comments_Data = dsNoExpInv.Tables[0].Rows[mInv]["Comments"].ToString(); if (comments_Data == "") { comments_Data = ""; }
            Liquid1_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid1"].ToString(); if (Liquid1_Data == "") { Liquid1_Data = ""; }
            Liquid2_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid2"].ToString(); if (Liquid2_Data == "") { Liquid2_Data = ""; }
            Liquid3_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid3"].ToString(); if (Liquid3_Data == "") { Liquid3_Data = ""; }
            Liquid4_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid4"].ToString(); if (Liquid4_Data == "") { Liquid4_Data = ""; }
            Liquid5_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid5"].ToString(); if (Liquid5_Data == "") { Liquid5_Data = ""; }
            Liquid6_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid6"].ToString(); if (Liquid6_Data == "") { Liquid6_Data = ""; }
            Liquid7_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid7"].ToString(); if (Liquid7_Data == "") { Liquid7_Data = ""; }
            Liquid8_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid8"].ToString(); if (Liquid8_Data == "") { Liquid8_Data = ""; }
            Liquid9_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid9"].ToString(); if (Liquid9_Data == "") { Liquid9_Data = ""; }
            Liquid10_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid10"].ToString(); if (Liquid10_Data == "") { Liquid10_Data = ""; }
            Liquid11_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid11"].ToString(); if (Liquid11_Data == "") { Liquid11_Data = ""; }
            Liquid12_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid12"].ToString(); if (Liquid12_Data == "") { Liquid12_Data = ""; }
            Liquid13_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid13"].ToString(); if (Liquid13_Data == "") { Liquid13_Data = ""; }
            Liquid14_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid14"].ToString(); if (Liquid14_Data == "") { Liquid14_Data = ""; }
            Liquid15_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid15"].ToString(); if (Liquid15_Data == "") { Liquid15_Data = ""; }
            Liquid16_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid16"].ToString(); if (Liquid16_Data == "") { Liquid16_Data = ""; }
            Liquid17_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid17"].ToString(); if (Liquid17_Data == "") { Liquid17_Data = ""; }
            Liquid18_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid18"].ToString(); if (Liquid18_Data == "") { Liquid18_Data = ""; }
            Liquid19_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid19"].ToString(); if (Liquid19_Data == "") { Liquid19_Data = ""; }
            Liquid20_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid20"].ToString(); if (Liquid20_Data == "") { Liquid20_Data = ""; }
            Liquid21_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid21"].ToString(); if (Liquid21_Data == "") { Liquid21_Data = ""; }
            Liquid22_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid22"].ToString(); if (Liquid22_Data == "") { Liquid22_Data = ""; }
            Liquid23_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid23"].ToString(); if (Liquid23_Data == "") { Liquid23_Data = ""; }
            Liquid24_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid24"].ToString(); if (Liquid24_Data == "") { Liquid24_Data = ""; }
            Liquid25_Data = dsNoExpInv.Tables[0].Rows[mInv]["Liquid25"].ToString(); if (Liquid25_Data == "") { Liquid25_Data = ""; }
        }
        #endregion
    }
    public void getDailyOperationLogEndingMileage(int m, DataSet ds)
    {
        #region get cell data
        dsNoExp = ds;
        if (dsNoExp.Tables[0].Rows.Count > 0)
        {
            ExcelRowId = dsNoExp.Tables[0].Rows[m]["ExcelRowId"].ToString();
            DLId = dsNoExp.Tables[0].Rows[m]["DailylogId"].ToString();

            //TotlaHours_Data = dsNoExp.Tables[0].Rows[m]["TotalHours"].ToString();
            TotlaHours_Data = dsNoExp.Tables[0].Rows[m]["TotlaHours"].ToString();
            EndingMileage_Data = dsNoExp.Tables[0].Rows[m]["EndingMileage"].ToString();
            //Dec2013
            FuelPurchased_Data = dsNoExp.Tables[0].Rows[m]["FuelPurchased"].ToString(); if (FuelPurchased_Data == "0.0000") { FuelPurchased_Data = ""; }
            PricePerGallon_Data = dsNoExp.Tables[0].Rows[m]["PricePerGallon"].ToString(); if (PricePerGallon_Data == "0.0000") { PricePerGallon_Data = ""; }

        }
        #endregion
    }
    public void getDailyOperationLog(int m, DataSet ds)
    {
        #region get cell data
        dsNoExp = ds;
        if (dsNoExp.Tables[0].Rows.Count > 0)
        {
            ExcelRowId = dsNoExp.Tables[0].Rows[m]["ExcelRowId"].ToString();
            DLId = dsNoExp.Tables[0].Rows[m]["DailylogId"].ToString();
            VanId_Data = dsNoExp.Tables[0].Rows[m]["VanId"].ToString();
            BeginningMileage_Data = dsNoExp.Tables[0].Rows[m]["BeginningMileage"].ToString();
            TotlaHours_Data = dsNoExp.Tables[0].Rows[m]["TotlaHours"].ToString();
            EndingMileage_Data = dsNoExp.Tables[0].Rows[m]["EndingMileage"].ToString();
            //Dec2013
            FuelPurchased_Data = dsNoExp.Tables[0].Rows[m]["FuelPurchased"].ToString(); if (FuelPurchased_Data == "0.0000") { FuelPurchased_Data = ""; }
            PricePerGallon_Data = dsNoExp.Tables[0].Rows[m]["PricePerGallon"].ToString(); if (PricePerGallon_Data == "0.0000") { PricePerGallon_Data = ""; }
            CustomerName_Data = dsNoExp.Tables[0].Rows[m]["CustomerName"].ToString() + "," + dsNoExp.Tables[0].Rows[m]["DateTimeFormat"].ToString() + "," + dsNoExp.Tables[0].Rows[m]["Others"].ToString() + "," + dsNoExp.Tables[0].Rows[m]["TimeIn"].ToString() + " " + "" + "--" + dsNoExp.Tables[0].Rows[m]["TimeOut"].ToString() + " " + "";
            Job_Data = dsNoExp.Tables[0].Rows[m]["Job"].ToString();
            ZipCode_Data = dsNoExp.Tables[0].Rows[m]["ZipCode"].ToString();
            Pets_Data = dsNoExp.Tables[0].Rows[m]["Pets"].ToString();

            Rebook_Data = dsNoExp.Tables[0].Rows[m]["Rebook"].ToString();
            FromRebook_Data = dsNoExp.Tables[0].Rows[m]["FromRebook"].ToString();
            New_Data = dsNoExp.Tables[0].Rows[m]["New"].ToString();
            TimeIn_Data = dsNoExp.Tables[0].Rows[m]["TimeIn"].ToString();
            TimeOut_Data = dsNoExp.Tables[0].Rows[m]["TimeOut"].ToString();
            PetTime_Data = dsNoExp.Tables[0].Rows[m]["PetTime"].ToString();
            ExtraServices_Data = dsNoExp.Tables[0].Rows[m]["ExtraServices"].ToString();
            //new
            comments_Data = dsNoExp.Tables[0].Rows[m]["Comments"].ToString();
            if ((dsNoExp.Tables[0].Rows[m]["Drive_Time"]) != System.DBNull.Value)
            {
                rDriveTimeData = Convert.ToInt32(dsNoExp.Tables[0].Rows[m]["Drive_Time"]);
            }
            else
            {
                rDriveTimeData = 0;
            }
            if (dsNoExp.Tables[0].Rows[m]["Pet_Time"] != System.DBNull.Value)
            {
                rPetTimeData = Convert.ToInt32(dsNoExp.Tables[0].Rows[m]["Pet_Time"]);
            }
            else { rPetTimeData = 0; }
            FleaandTick22_Data = dsNoExp.Tables[0].Rows[m]["FleaandTick22"].ToString(); if (FleaandTick22_Data == "0.000") { FleaandTick22_Data = ""; }
            FleaandTick44_Data = dsNoExp.Tables[0].Rows[m]["FleaandTick44"].ToString(); if (FleaandTick44_Data == "0.000") { FleaandTick44_Data = ""; }
            FleaandTick88_Data = dsNoExp.Tables[0].Rows[m]["FleaandTick88"].ToString(); if (FleaandTick88_Data == "0.000") { FleaandTick88_Data = ""; }
            FleaandTick132_Data = dsNoExp.Tables[0].Rows[m]["FleaandTick132"].ToString(); if (FleaandTick132_Data == "0.000") { FleaandTick132_Data = ""; }
            FleaandTickCat_Data = dsNoExp.Tables[0].Rows[m]["FleaandTickCat"].ToString(); if (FleaandTickCat_Data == "0.000") { FleaandTickCat_Data = ""; }
            TB_Data = dsNoExp.Tables[0].Rows[m]["TB"].ToString(); if (TB_Data == "0.000") { TB_Data = ""; }
            Wham_Data = dsNoExp.Tables[0].Rows[m]["Wham"].ToString(); if (Wham_Data == "0.000") { Wham_Data = ""; }
            RevenueCreditCard_Data = dsNoExp.Tables[0].Rows[m]["RevenueCreditCard"].ToString(); if (RevenueCreditCard_Data == "0.000") { RevenueCreditCard_Data = ""; }
            RevenueCheck_Data = dsNoExp.Tables[0].Rows[m]["RevenueCheck"].ToString(); if (RevenueCheck_Data == "0.000") { RevenueCheck_Data = ""; }
            RevenueCash_Data = dsNoExp.Tables[0].Rows[m]["RevenueCash"].ToString(); if (RevenueCash_Data == "0.000") { RevenueCash_Data = ""; }
            RevenueInvoice_Data = dsNoExp.Tables[0].Rows[m]["RevenueInvoice"].ToString(); if (RevenueInvoice_Data == "0.000") { RevenueInvoice_Data = ""; }
            RevCCY_Data = dsNoExp.Tables[0].Rows[m]["RevenueCCY"].ToString(); if (RevCCY_Data == "0.0000") { RevCCY_Data = ""; }
            TipCreditCard_Data = dsNoExp.Tables[0].Rows[m]["TipCreditCard"].ToString(); if (TipCreditCard_Data == "0.000") { TipCreditCard_Data = ""; }
            TipCheck_Data = dsNoExp.Tables[0].Rows[m]["TipCheck"].ToString(); if (TipCheck_Data == "0.000") { TipCheck_Data = ""; }
            TipCash_Data = dsNoExp.Tables[0].Rows[m]["TipCash"].ToString(); if (TipCash_Data == "0.000") { TipCash_Data = ""; }
            TipInvoice_Data = dsNoExp.Tables[0].Rows[m]["TipInvoice"].ToString(); if (TipInvoice_Data == "0.000") { TipInvoice_Data = ""; }
            PriorCreditCard_Data = dsNoExp.Tables[0].Rows[m]["PriorCreditCard"].ToString(); if (PriorCreditCard_Data == "0.000") { PriorCreditCard_Data = ""; }
            PriorCheck_Data = dsNoExp.Tables[0].Rows[m]["PriorCheck"].ToString(); if (PriorCheck_Data == "0.000") { PriorCheck_Data = ""; }
            PriorCash_Data = dsNoExp.Tables[0].Rows[m]["PriorCash"].ToString(); if (PriorCash_Data == "0.000") { PriorCash_Data = ""; }

            DateTime dt = Convert.ToDateTime(dsNoExp.Tables[0].Rows[m]["NextAppointmentDate"].ToString());
            NextAppointmentDate_Data = dt.ToShortDateString();
            if (NextAppointmentDate_Data == "1/1/1900")
            {
                NextAppointmentDate_Data = "";
            }
            if (Rebook_Data != "")
            {
                ServicesForPet_Data = "";
                if (dsNoExp.Tables[0].Rows[m]["ServicesForPet1"].ToString() != "")
                {
                    ServicesForPet_Data += dsNoExp.Tables[0].Rows[m]["ServicesForPet1"].ToString();
                }
                if (dsNoExp.Tables[0].Rows[m]["ServicesForPet2"].ToString() != "")
                {
                    ServicesForPet_Data += "," + dsNoExp.Tables[0].Rows[m]["ServicesForPet2"].ToString();
                }
                if (dsNoExp.Tables[0].Rows[m]["ServicesForPet3"].ToString() != "")
                {
                    ServicesForPet_Data += "," + dsNoExp.Tables[0].Rows[m]["ServicesForPet3"].ToString();
                }
                if (dsNoExp.Tables[0].Rows[m]["ServicesForPet4"].ToString() != "")
                {
                    ServicesForPet_Data += "," + dsNoExp.Tables[0].Rows[m]["ServicesForPet4"].ToString();
                }
                if (dsNoExp.Tables[0].Rows[m]["ServicesForPet5"].ToString() != "")
                {
                    ServicesForPet_Data += "," + dsNoExp.Tables[0].Rows[m]["ServicesForPet5"].ToString();
                }
                if (dsNoExp.Tables[0].Rows[m]["ServicesForPet6"].ToString() != "")
                {
                    ServicesForPet_Data += "," + dsNoExp.Tables[0].Rows[m]["ServicesForPet6"].ToString();
                }
                if (NextAppointmentDate_Data == "")
                {
                    NextAppointmentTime_Data = "";
                }
                else
                {
                    NextAppointmentTime_Data = dsNoExp.Tables[0].Rows[m]["NextAppointmentTime"].ToString() + "  " + dsNoExp.Tables[0].Rows[m]["NextAppointmentEndTime"].ToString();
                }
            }
            Addedon_Data = dsNoExp.Tables[0].Rows[m]["Addedon"].ToString();
            ProductPrice_Data = dsNoExp.Tables[0].Rows[m]["ProductPrice"].ToString();
            SalesTax_Data = dsNoExp.Tables[0].Rows[m]["SalesTax"].ToString();
            Rev01_Data = dsNoExp.Tables[0].Rows[m]["Rev01"].ToString();

            CreditCardNo_Data = "";
            CreditCardNo_Data = dsNoExp.Tables[0].Rows[m]["CreditCard"].ToString();
            CreditCardExpir_Data = dsNoExp.Tables[0].Rows[m]["ValidMonth"].ToString() + "/" + dsNoExp.Tables[0].Rows[m]["ValidYear"].ToString();

            CreditCardName_Data = dsNoExp.Tables[0].Rows[m]["FirstName"].ToString() + " " + dsNoExp.Tables[0].Rows[m]["LastName"].ToString();
            CreditCardAddr_Data = dsNoExp.Tables[0].Rows[m]["Address1"].ToString() + " " + dsNoExp.Tables[0].Rows[m]["City"].ToString() + "," + dsNoExp.Tables[0].Rows[m]["State"].ToString() + "," + dsNoExp.Tables[0].Rows[m]["Zip"].ToString();
            string ChequeDetails = "";
            if (dsNoExp.Tables[0].Rows[m]["accholdername"].ToString() != "" && !(null == dsNoExp.Tables[0].Rows[m]["accholdername"]) || dsNoExp.Tables[0].Rows[m]["chequebank"].ToString() != "" && !(null == dsNoExp.Tables[0].Rows[m]["chequebank"]))
            {
                ChequeDetails = "Name on Check:" + dsNoExp.Tables[0].Rows[m]["accholdername"].ToString() + ",Address on Check:" + dsNoExp.Tables[0].Rows[m]["chequebank"].ToString();
            }
            string Revenueccy = "";

            if (dsNoExp.Tables[0].Rows[m]["RevenueCCY"].ToString() != "" && !(null == dsNoExp.Tables[0].Rows[m]["RevenueCCY"]))
            {
                if (Convert.ToDouble(dsNoExp.Tables[0].Rows[m]["RevenueCCY"].ToString()) > 0)
                {
                    Revenueccy = "ccy";
                }
            }

            //string Status = "";
            TxnRefNo = dsNoExp.Tables[0].Rows[m]["BillTxnRefNo"].ToString();
            AuthCode = "";
            if (dsNoExp.Tables[0].Rows[m]["Authcode"].ToString().Trim() != "" && !(null == dsNoExp.Tables[0].Rows[m]["Authcode"]))
            {
                AuthCode = "'" + dsNoExp.Tables[0].Rows[m]["Authcode"].ToString();
            }
            if ((!(null == dsNoExp.Tables[0].Rows[m]["IsSucceded"])) && (dsNoExp.Tables[0].Rows[m]["IsSucceded"].ToString() != ""))
            {

                if (Convert.ToBoolean(dsNoExp.Tables[0].Rows[m]["IsSucceded"].ToString()).Equals(false))
                {
                    AuthCode = "Failed ";
                }
            }

            //Bind all data in one filed 
            if (CreditCardExpir_Data == "1/1/1900")
                CreditCardNo_Data = "";
            else
                if (!(string.IsNullOrEmpty(CreditCardNo_Data)))
            {
                if (ChequeDetails != "")
                {
                    CreditCardNo_Data = CreditCardNo_Data + ", " + CreditCardExpir_Data + ", " + CreditCardName_Data + "," + CreditCardAddr_Data + "," + ChequeDetails;
                }
                else
                {
                    CreditCardNo_Data = CreditCardNo_Data + ", " + CreditCardExpir_Data + ", " + CreditCardName_Data + "," + CreditCardAddr_Data;
                }
            }
            else
            {
                CreditCardNo_Data = "";
                if (ChequeDetails != "")
                {
                    CreditCardNo_Data = ChequeDetails;
                }
                if (Revenueccy != "")
                {
                    if (CreditCardNo_Data == "")
                    {
                        CreditCardNo_Data = Revenueccy;
                    }
                    else
                    {
                        CreditCardNo_Data = CreditCardNo_Data + "," + Revenueccy;
                    }
                }
            }


            string creditcardnumberch = dsNoExp.Tables[0].Rows[m]["CreditCard"].ToString();
            if (creditcardnumberch != "" && creditcardnumberch != "ccy")
            {
                CreditCardNumber_data = "0";
            }
            else
            {
                CreditCardNumber_data = " ";
            }
            if (creditcardnumberch == "ccy")
                CreditCardNumber_data = "ccy";
        }
        #endregion
    }
    public void getCellEndingMileage()
    {
        #region get Excel data
        dsExEnd = ObjGroomer.getExcelData();
        if (dsExEnd.Tables[0].Rows.Count > 0)
        {
            TotlaHours = dsExEnd.Tables[0].Rows[0]["TotlaHours"].ToString().Trim();
            EndingMileage = dsExEnd.Tables[0].Rows[0]["EndingMileage"].ToString().Trim();
            //Dec2013
            FuelPurchased = dsExEnd.Tables[0].Rows[0]["FuelPurchased"].ToString().Trim();
            if (FuelPurchased_Data == "0.0000" || FuelPurchased_Data == "" || FuelPurchased_Data == null)
            {
                FuelPurchased_Data = "";
            }
            PricePerGallon = dsExEnd.Tables[0].Rows[0]["PricePerGallon"].ToString().Trim();
            if (PricePerGallon_Data == "0.0000" || PricePerGallon_Data == "" || PricePerGallon_Data == null)
            {
                PricePerGallon_Data = "";
            }
        }
        #endregion
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
            //if (FuelPurchased == "0" || FuelPurchased == "" || FuelPurchased == null)
            //{
            //    FuelPurchased_Data = "";
            //}
            PricePerGallon = dsEx.Tables[0].Rows[0]["PricePerGallon"].ToString().Trim();
            //if (PricePerGallon == "0" && PricePerGallon == "0" || PricePerGallon == "" || PricePerGallon == null)
            //{
            //    PricePerGallon = "";
            //}
            CustomerName1 = dsEx.Tables[0].Rows[0]["CustomerName"].ToString().Trim();
            Job1 = dsEx.Tables[0].Rows[0]["Job"].ToString().Trim();
            ZipCode1 = dsEx.Tables[0].Rows[0]["ZipCode"].ToString().Trim();
            Pets1 = dsEx.Tables[0].Rows[0]["Pets"].ToString().Trim();
            Rebook1 = dsEx.Tables[0].Rows[0]["Rebook"].ToString().Trim();
            FromRebook1 = dsEx.Tables[0].Rows[0]["FromRebook"].ToString().Trim();
            New1 = dsEx.Tables[0].Rows[0]["New"].ToString().Trim();
            TimeIn1 = dsEx.Tables[0].Rows[0]["TimeIn"].ToString().Trim();
            TimeOut1 = dsEx.Tables[0].Rows[0]["TimeOut"].ToString().Trim();
            PetTime1 = dsEx.Tables[0].Rows[0]["PetTime"].ToString().Trim();
            ExtraServices1 = dsEx.Tables[0].Rows[0]["ExtraServices"].ToString().Trim();
            //new
            comments1 = dsEx.Tables[0].Rows[0]["Comments"].ToString().Trim();
            rPetTime1 = dsEx.Tables[0].Rows[0]["Pet_Time"].ToString().Trim();
            rDriveTime1 = dsEx.Tables[0].Rows[0]["Drive_Time"].ToString().Trim();

            FleaandTick221 = dsEx.Tables[0].Rows[0]["FleaandTick22"].ToString().Trim();
            FleaandTick441 = dsEx.Tables[0].Rows[0]["FleaandTick44"].ToString().Trim();
            FleaandTick881 = dsEx.Tables[0].Rows[0]["FleaandTick88"].ToString().Trim();
            FleaandTick1321 = dsEx.Tables[0].Rows[0]["FleaandTick132"].ToString().Trim();
            FleaandTickCat1 = dsEx.Tables[0].Rows[0]["FleaandTickCat"].ToString().Trim();
            TB1 = dsEx.Tables[0].Rows[0]["TB"].ToString().Trim();
            Wham1 = dsEx.Tables[0].Rows[0]["Wham"].ToString().Trim();
            RevenueCreditCard1 = dsEx.Tables[0].Rows[0]["RevenueCreditCard"].ToString().Trim();
            RevenueCheck1 = dsEx.Tables[0].Rows[0]["RevenueCheck"].ToString().Trim();
            RevenueCash1 = dsEx.Tables[0].Rows[0]["RevenueCash"].ToString().Trim();
            RevenueInvoice1 = dsEx.Tables[0].Rows[0]["RevenueInvoice"].ToString().Trim();
            TipCreditCard1 = dsEx.Tables[0].Rows[0]["TipCreditCard"].ToString().Trim();
            TipCheck1 = dsEx.Tables[0].Rows[0]["TipCheck"].ToString().Trim();
            TipCash1 = dsEx.Tables[0].Rows[0]["TipCash"].ToString().Trim();
            TipInvoice1 = dsEx.Tables[0].Rows[0]["TipInvoice"].ToString().Trim();
            PriorCreditCard1 = dsEx.Tables[0].Rows[0]["PriorCreditCard"].ToString().Trim();
            PriorCheck1 = dsEx.Tables[0].Rows[0]["PriorCheck"].ToString().Trim();
            PriorCash1 = dsEx.Tables[0].Rows[0]["PriorCash"].ToString().Trim();
            NextAppointmentDate = dsEx.Tables[0].Rows[0]["NextAppointmentDate"].ToString().Trim();
            NextAppointmentTime = dsEx.Tables[0].Rows[0]["NextAppointmentTime"].ToString().Trim();
            ServicesForPet = dsEx.Tables[0].Rows[0]["ServicesForPet"].ToString().Trim();
            Addedon = dsEx.Tables[0].Rows[0]["Addedon"].ToString().Trim();

            ProductPrice1 = dsEx.Tables[0].Rows[0]["ProductPrice"].ToString().Trim();
            SalesTax1 = dsEx.Tables[0].Rows[0]["SalesTax"].ToString().Trim();
            Rev01 = dsEx.Tables[0].Rows[0]["Rev01"].ToString().Trim();
            CreditCardNo1 = dsEx.Tables[0].Rows[0]["CreditCardNo"].ToString().Trim();
            CreditCardExpir1 = dsEx.Tables[0].Rows[0]["CreditCardExpir"].ToString().Trim();
            CreditCardName = dsEx.Tables[0].Rows[0]["CreditCardName"].ToString().Trim();
            CreditCardAddr = dsEx.Tables[0].Rows[0]["CreditCardAddr"].ToString().Trim();
            SecurityCode1 = dsEx.Tables[0].Rows[0]["SecurityCode"].ToString().Trim();
            //CreditCardNo1 = dsEx.Tables[0].Rows[0]["CreditCard"].ToString().Trim();
            //CreditCardExpir1 = dsEx.Tables[0].Rows[0]["ValidMonth"].ToString().Trim() + "-" + dsEx.Tables[0].Rows[0]["ValidYear"].ToString().Trim();
            //CreditCardName = dsEx.Tables[0].Rows[0]["FirstName"].ToString().Trim() + " " + dsEx.Tables[0].Rows[0]["LastName"].ToString().Trim();
            //CreditCardAddr = dsEx.Tables[0].Rows[0]["Address1"].ToString().Trim() + " " + dsEx.Tables[0].Rows[0]["Address2"].ToString().Trim();
            //SecurityCode1 = dsEx.Tables[0].Rows[0]["VerificationCode"].ToString().Trim();
        }
        #endregion
    }

    #endregion

    #endregion

    #region Button 3 Download Sheet
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        string ctrlName = ((Button)sender).ID;
        DownloadFile(true, ((Button)sender).Text);
    }
    protected void btnLockDownLoad_Click(object sender, EventArgs e)
    {
        if (Session["FId"] != null)
        {
            Groomer objgr = new Groomer();
            objgr.UpdateExcelFileStatus(Session["FId"].ToString());
        }
        string ctrlName = ((Button)sender).ID;
        DownloadFile(true, ((Button)sender).Text);
        Response.Redirect("UploadDnloadExcel.aspx");
    }

    private void DownloadFile(bool forceDownload, string fname)
    {
        try
        {
            DirectoryInfo dr = new DirectoryInfo(Server.MapPath(ExcelFilePath));
            FileInfo[] files = dr.GetFiles();
            if (files.Length > 0)
            {
                string path = MapPath(ExcelFilePath + fname);
                string name = Path.GetFileName(path);
                string ext = Path.GetExtension(path);
                string type = "";
                // set known types based on file extension  
                if (ext != null)
                    switch (ext.ToLower())
                    {
                        case ".htm":
                        case ".html":
                            type = "text/HTML";
                            break;

                        case ".txt":
                            type = "text/plain";
                            break;

                        case ".doc":
                        case ".rtf":
                            type = "Application/msword";
                            break;
                        case ".xls":
                            // type = "application/octet-stream";
                            type = "application/Excel";
                            break;
                        case ".xlsx":
                            type = "application/octet-stream";
                            break;
                    }
                if (forceDownload)
                    Response.AppendHeader("content-disposition", "attachment; filename=" + name);
                if (type != "")
                    Response.ContentType = type;
                Response.WriteFile(path);
                Response.End();
            }
            else
            {
                ErrMessage("Sorry! No  Uploaded File  Found .Please Upload New Sheet and try again..");
            }
        }
        catch
        {
            ErrMessage("Sorry! Previous  Uploaded File Not Found .Please Upload New Sheet and try again..");
        }
    }

    #endregion

    #region Get Server File Name For Download On Page Load
    public void getServerFiles()
    {
        string fpath = "";
        fpath = Server.MapPath(@ExcelFilePath);
        string[] filePaths = Directory.GetFiles(fpath);
        Groomer objgr = new Groomer();
        DataSet ds = new DataSet();
        ds = objgr.GetUnlockExcelFileName();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Button button1 = new Button();
                button1.ID = "btn" + 1;
                button1.Text = Path.GetFileName(ds.Tables[0].Rows[i]["FileName"].ToString());
                button1.Click += new System.EventHandler(btnDownload_Click);
                button1.CssClass = "btnLnk";
                Button button2 = new Button();
                button2.ID = "btn" + 2;
                button2.Text = Path.GetFileName(ds.Tables[0].Rows[i]["FileName"].ToString());
                button2.Click += new System.EventHandler(btnLockDownLoad_Click);
                button2.CssClass = "btnLnk";
                Panel1.Controls.Add(button1);
                Session["FId"] = ds.Tables[0].Rows[i]["FId"].ToString();
            }
        }
    }
    #endregion

    #region Get Already Saved File On Server For Push Button
    protected void GetServerExcelFilePath()
    {
        try
        {
            ds = ObjGroomer.GetUnlockExcelFileName();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["status"].ToString() == "Unlock")
                {
                    string ExcelFileName;
                    ds.Tables[0].Rows[0]["FileName"].ToString();
                    ExcelFilePath1 = System.Configuration.ConfigurationManager.AppSettings["Excelpath"].ToString();
                    string[] filePaths = Directory.GetFiles(Server.MapPath(ExcelFilePath1));
                    int count = filePaths.Length;

                    for (int i = 0; i < count; i++)
                    {
                        ExcelFilePath1 = filePaths[i];
                        ExcelFileName = Path.GetFileName(ExcelFilePath1);
                        if (ExcelFileName == ds.Tables[0].Rows[0]["FileName"].ToString())
                            ExistsExcelFilePath1 = ExcelFilePath1;
                    }
                }
                else
                    ExistsExcelFilePath1 = "Locked";
            }
        }
        catch (Exception ex)
        {
            ErrMessage("Exception: " + ex.Message);
        }
    }
    #endregion

    #region Get Month
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

    #endregion



    #region Release Object
    private void releaseObject(object obj)
    {
        try
        {
            if (obj != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                //    obj = null;
            }
        }
        catch 
        {
            //   obj = null;
        }
        finally
        {
            GC.Collect();
            //GC.SuppressFinalize(obj);
        }
    }
    #endregion
}
