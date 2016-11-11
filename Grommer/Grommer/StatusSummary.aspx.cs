using System;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;

public partial class StatusSummary : System.Web.UI.Page
{
    string ExistsExcelFilePath1;
    string ExcelFilePath = "";
    string strdate = String.Empty, strSelDate = "";
    int secRow = 0;
    Groomer ObjGroomer = new Groomer();

    #region GlobalCellvariable
    public string pets = "", RepPets = "", RbkPets = "", pfRbk = "", NewPets = "",
            NRbkPets = "",
            Hours = "",
            FandT22 = "",
            FandT44 = "",
            FandT88 = "",
            FandT132 = "",
            FandTcat = "",
            TB = "",
            Wham = "",
            Appts = "",
            Rev = "",
            Tips = "",
            DepAmt = "",
            Deposit = "",
            Fuel = "";
    #endregion
    private int GId
    {
        get
        {
            if (!(null == Session["GId"]))
            {
                return int.Parse(Session["GId"].ToString());
            }
            else
                return 0;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GetServerExcelFilePath();
            ReadExcel();
        }
        catch 
        {
        }
    }
    private void ReadExcel()
    {

        try
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            
            DateTime dt = System.DateTime.Now.Date; ;
            strSelDate = getMonth(dt.Month.ToString()) + " " + dt.Day + "," + " " + dt.Year;
            getCell();
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(ExistsExcelFilePath1, 0, true, 5, "albhistar1", "albhistar1", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Worksheet excelSheet = new Microsoft.Office.Interop.Excel.Worksheet();

            range = xlWorkSheet.UsedRange;
            int numSheets = xlWorkBook.Sheets.Count;
            Excel.Sheets excelSheets = xlWorkBook.Worksheets;
            for (int sheetNum = 1; sheetNum < numSheets; sheetNum++)
            {
                excelSheet = (Excel.Worksheet)excelSheets.get_Item(sheetNum);
                DataSet dsg = new DataSet();
                dsg = ObjGroomer.GroomerGetProfile(GId);
                string strWorksheetName = excelSheet.Name;

                if (dsg.Tables.Count > 0)
                {
                    if (dsg.Tables[0].Rows.Count > 0)
                    {
                        if (strWorksheetName == dsg.Tables[0].Rows[0]["SheetName"].ToString())
                        {
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
                                    if (strdate == strSelDate)
                                    {
                                        secRow = r + 2;
                                        lblPets.Text = Convert.ToString(excelSheet.get_Range(pets + r, pets + r).Value2);
                                        lblRptPets.Text = Convert.ToString(excelSheet.get_Range(RepPets + r, RepPets + r).Value2);
                                        lblRbkPets.Text = Convert.ToString(excelSheet.get_Range(RbkPets + r, RbkPets + r).Value2);
                                        lblPFRbk.Text = Convert.ToString(excelSheet.get_Range(pfRbk + r, pfRbk + r).Value2);
                                        lblNewPets.Text = Convert.ToString(excelSheet.get_Range(NewPets + r, NewPets + r).Value2);
                                        lblNRbkPets.Text = Convert.ToString(excelSheet.get_Range(NRbkPets + r, NRbkPets + r).Value2);
                                        if (Convert.ToString(excelSheet.get_Range(Hours + r, Hours + r).Value2) == "")
                                            lblHours.Text = "0";
                                        else
                                            lblHours.Text = Convert.ToString(excelSheet.get_Range(Hours + r, Hours + r).Value2);
                                        lblFandT22.Text = Convert.ToString(excelSheet.get_Range(FandT22 + r, FandT22 + r).Value2);
                                        lblFandT44.Text = Convert.ToString(excelSheet.get_Range(FandT44 + r, FandT44 + r).Value2);
                                        lblFandT88.Text = Convert.ToString(excelSheet.get_Range(FandT88 + r, FandT88 + r).Value2);
                                        lblFandT132.Text = Convert.ToString(excelSheet.get_Range(FandT132 + r, FandT132 + r).Value2);
                                        lblFandTcat.Text = Convert.ToString(excelSheet.get_Range(FandTcat + r, FandTcat + r).Value2);
                                        lblTB.Text = Convert.ToString(excelSheet.get_Range(TB + r, TB + r).Value2);
                                        lblWham.Text = Convert.ToString(excelSheet.get_Range(Wham + r, Wham + r).Value2);
                                        lblAppts.Text = Convert.ToString(excelSheet.get_Range(Appts + r, Appts + r).Value2);
                                        lblRev.Text = Convert.ToString(excelSheet.get_Range(Rev + r, Rev + r).Value2);
                                        lblTips.Text = Convert.ToString(excelSheet.get_Range(Tips + r, Tips + r).Value2);
                                        
                                        if (Convert.ToString(excelSheet.get_Range(Fuel + r, Fuel + r).Value2) == "")
                                            lblFuel.Text = "0";
                                        else
                                            lblFuel.Text = Convert.ToString(excelSheet.get_Range(Fuel + r, Fuel + r).Value2);

                                    }
                                }
                                if (r == 380)
                                {
                                    lblPetsMonthSummary1.Text = Convert.ToString(excelSheet.get_Range(pets + r, pets + r).Value2);
                                    lblRptPetsm.Text = Convert.ToString(excelSheet.get_Range(RepPets + r, RepPets + r).Value2);
                                    lblRbkPetsm.Text = Convert.ToString(excelSheet.get_Range(RbkPets + r, RbkPets + r).Value2);
                                    lblPFRbkm.Text = Convert.ToString(excelSheet.get_Range(pfRbk + r, pfRbk + r).Value2);
                                    lblNewPetsm.Text = Convert.ToString(excelSheet.get_Range(NewPets + r, NewPets + r).Value2);
                                    lblNRbkPetsm.Text = Convert.ToString(excelSheet.get_Range(NRbkPets + r, NRbkPets + r).Value2);
                                    lblHoursm.Text = Convert.ToString(excelSheet.get_Range(Hours + r, Hours + r).Value2);
                                    lblFandT22m.Text = Convert.ToString(excelSheet.get_Range(FandT22 + r, FandT22 + r).Value2);
                                    lblFandT44m.Text = Convert.ToString(excelSheet.get_Range(FandT44 + r, FandT44 + r).Value2);
                                    lblFandT88m.Text = Convert.ToString(excelSheet.get_Range(FandT88 + r, FandT88 + r).Value2);
                                    lblFandT132m.Text = Convert.ToString(excelSheet.get_Range(FandT132 + r, FandT132 + r).Value2);
                                    lblFandTcatm.Text = Convert.ToString(excelSheet.get_Range(FandTcat + r, FandTcat + r).Value2);
                                    lblTBm.Text = Convert.ToString(excelSheet.get_Range(TB + r, TB + r).Value2);
                                    lblWhamm.Text = Convert.ToString(excelSheet.get_Range(Wham + r, Wham + r).Value2);
                                    lblApptsm.Text = Convert.ToString(excelSheet.get_Range(Appts + r, Appts + r).Value2);
                                    lblRevm.Text = Convert.ToString(excelSheet.get_Range(Rev + r, Rev + r).Value2);
                                    lblTipsm.Text = Convert.ToString(excelSheet.get_Range(Tips + r, Tips + r).Value2);
                                    if (Convert.ToString(excelSheet.get_Range(Fuel + r, Fuel + r).Value2) == "")
                                        lblFuelm.Text = "0";
                                    else
                                        lblFuelm.Text = Convert.ToString(excelSheet.get_Range(Fuel + r, Fuel + r).Value2);

                                }
                                if (r == 368)
                                {
                                    lblDeposit.Text = "$" + Convert.ToString(excelSheet.get_Range(Deposit + r, Deposit + r).Value2);
                                }
                            }

                        }
                    }
                }
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch 
        {
            obj = null;
        }
        finally
        {
            GC.Collect();
        }
    }
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
    protected void GetServerExcelFilePath()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = ObjGroomer.GetUnlockExcelFileName();

            if (ds.Tables.Count > 0)
            {
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

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void getCell()
    {
        #region get Excel data
        pets = "E";
        RepPets = "F";
        RbkPets = "G";
        pfRbk = "H";
        NewPets = "I";
        NRbkPets = "J";
        Hours = "K";
        FandT22 = "L";
        FandT44 = "M";
        FandT88 = "N";
        FandT132 = "O";
        FandTcat = "P";
        TB = "Q";
        Wham = "R";
        Appts = "S";
        Rev = "AB";
        Tips = "AO";
        DepAmt = "AS";
        Fuel = "BD";
        Deposit = "AS";
        #endregion
    }

}
