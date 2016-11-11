using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Linq;
using System.Web.UI.HtmlControls;
using advancewebtosolution.BO;
    public partial class Admin_Groomer_GroomerMonthlyOperationLog : Page
    {
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

        #region SetTotalVariable
        decimal RevenueCreditCardTotal = 0;
        decimal RevenueCheckTotal = 0;
        decimal RevenueCashTotal = 0;
        decimal RevenueInvoiceTotal = 0;
        decimal TipCreditCardTotal = 0;
        decimal TipCheckTotal = 0;
        decimal TipCashTotal = 0;
        decimal PriorCreditCardTotal = 0;
        decimal PriorCheckTotal = 0;
        decimal PriorCashTotal = 0;
        decimal TipInvoiceTotal = 0;
        int PetsTotal = 0;
        int RebookTotal = 0;
        int FromRebookTotal = 0;
        int NewTotal = 0;
        int TotlaHoursTotal = 0;
        int FleaandTick22Total = 0;
        int FleaandTick44Total = 0;
        int FleaandTick88Total = 0;
        int FleaandTick132Total = 0;
        int FleaandTickCatTotal = 0;
        int TBTotal = 0;
        int WhamTotal = 0;
        decimal FuelPurchasedTotal = 0;
        decimal PricePerGallonTotal = 0;

        //for suppler
        int FleaTick22Total = 0;
        int FleaTick44Total = 0;
        int FleaTick88Total = 0;
        int FleaTick132Total = 0;
        int FleaTickcATTotal = 0;
        int ToothbrushesTotal = 0;
        int WhamInventoryTotal = 0;
        int TowelsTotal = 0;
        int CottonPadsTotal = 0;
        int CottonSwabsTotal = 0;
        int PaperTowelsTotal = 0;
        int GarbageBagsTotal = 0;
        int TreatsTotal = 0;
        int VetWrapTotal = 0;
        int WipesTotal = 0;
        int EnvelopesTotal = 0;
        int QuickStopTotal = 0;
        int LiquidBandaidTotal = 0;
        int ReceiptsTotal = 0;
        int BusinessCardsTotal = 0;
        int BladesSharpenedTotal = 0;
        int ScissorsSharpenedTotal = 0;
        int SunGuardTotal = 0;
        int EZShedTotal = 0;
        int EZDemattTotal = 0;
        int SkunkKitTotal = 0;
        int OtherTotal = 0;


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dvgroomers.Visible = false;
            }
        }
        public void GetGroomerMonthlyLogData()
        {
            Groomer objgroomer = new Groomer();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            ds = objgroomer.GetGroomerMonthlyLogData(Convert.ToInt32(Request.QueryString["GID"].ToString()), txtStartDate.Text, txtEndDate.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int count = 0; count < ds.Tables[1].Columns.Count; count++)
                    {
                        ds.Tables[0].Columns.Add(ds.Tables[1].Columns[count].ColumnName, ds.Tables[1].Columns[count].DataType);
                        ds.Tables[0].Rows[0][ds.Tables[0].Columns.Count - 1] = ds.Tables[1].Rows[0][count];

                    }
                }
                dvgroomers.Visible = true;
                GrdGroomer.DataSource = ds.Tables[0];
                GrdGroomer.DataBind();
                dvgroomers.Visible = true;
                divError.Visible = false;
            }
            else
            {
                dvgroomers.Visible = false;
                divError.Visible = true;
                dvgroomers.Visible = false;
                ErrorMessage("Sorry, No records found.");
            }

           
        }

        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            GetGroomerMonthlyLogData();
        }

        protected void GrdGroomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Credit card Revenue
                decimal RevenueCreditCardrowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RevenueCreditCard"));
                RevenueCreditCardTotal = RevenueCreditCardTotal + RevenueCreditCardrowTotal;
                decimal RevenueCheckrowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RevenueCheck"));
                RevenueCheckTotal = RevenueCheckTotal + RevenueCheckrowTotal;
                decimal RevenueCashrowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RevenueCash"));
                RevenueCashTotal = RevenueCashTotal + RevenueCashrowTotal;
                decimal RevenueInvoicerowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RevenueInvoice"));
                RevenueInvoiceTotal = RevenueInvoiceTotal + RevenueInvoicerowTotal;

                // Tip Revenue
                decimal TipCreditCardrowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TipCreditCard"));
                TipCreditCardTotal = TipCreditCardTotal + TipCreditCardrowTotal;
                decimal TipCheckrowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TipCheck"));
                TipCheckTotal = TipCheckTotal + TipCheckrowTotal;
                decimal TipCashrowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TipCash"));
                TipCashTotal = TipCashTotal + TipCashrowTotal;
                decimal TipInvoicerowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TipInvoice"));
                TipInvoiceTotal = TipInvoiceTotal + TipInvoicerowTotal;

                //prior revenue
                decimal PriorCreditCardrowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PriorCreditCard"));
                PriorCreditCardTotal = PriorCreditCardTotal + PriorCreditCardrowTotal;
                decimal PriorCheckrowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PriorCheck"));
                PriorCheckTotal = PriorCheckTotal + PriorCheckrowTotal;
                decimal PriorCashrowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PriorCash"));
                PriorCashTotal = PriorCashTotal + PriorCashrowTotal;

                //Appointment variable
                int PetsrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pets"));
                PetsTotal = PetsTotal + PetsrowTotal;
                int RebookrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Rebook"));
                RebookTotal = RebookTotal + RebookrowTotal;
                int FromRebookrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FromRebook"));
                FromRebookTotal = FromRebookTotal + FromRebookrowTotal;
                int NewrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "New"));
                NewTotal = NewTotal + NewrowTotal;
                int TotlaHoursrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotlaHours"));
                TotlaHoursTotal = TotlaHoursTotal + TotlaHoursrowTotal;
                int FleaandTick22rowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FleaandTick22"));
                FleaandTick22Total = FleaandTick22Total + FleaandTick22rowTotal;
                int FleaandTick44rowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FleaandTick44"));
                FleaandTick44Total = FleaandTick44Total + FleaandTick44rowTotal;
                int FleaandTick88rowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FleaandTick88"));
                FleaandTick88Total = FleaandTick88Total + FleaandTick88rowTotal;
                int FleaandTick132rowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FleaandTick132"));
                FleaandTick132Total = FleaandTick132Total + FleaandTick132rowTotal;
                int FleaandTickCatrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FleaandTickCat"));
                FleaandTickCatTotal = FleaandTickCatTotal + FleaandTickCatrowTotal;
                int TBrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TB"));
                TBTotal = TBTotal + TBrowTotal;
                int WhamrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Wham"));
                WhamTotal = WhamTotal + WhamrowTotal;
                decimal FuelPurchasedrowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FuelPurchased"));
                FuelPurchasedTotal = FuelPurchasedTotal + FuelPurchasedrowTotal;
                decimal PricePerGallonrowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PricePerGallon"));
                PricePerGallonTotal = PricePerGallonTotal + PricePerGallonrowTotal;

                //Supplier variable
                int FleaTick22rowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FleaTick22"));
                FleaTick22Total = FleaTick22Total + FleaTick22rowTotal;
                int FleaTick44rowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FleaTick44"));
                FleaTick44Total = FleaTick44Total + FleaTick44rowTotal;
                int FleaTick88rowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FleaTick88"));
                FleaTick88Total = FleaTick88Total + FleaTick88rowTotal;
                int FleaTick132rowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FleaTick132"));
                FleaTick132Total = FleaTick132Total + FleaTick132rowTotal;
                int FleaTickcATrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FleaTickcAT"));
                FleaTickcATTotal = FleaTickcATTotal + FleaTickcATrowTotal;
                int ToothbrushesrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Toothbrushes"));
                ToothbrushesTotal = ToothbrushesTotal + ToothbrushesrowTotal;
                int WhamInventoryrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WhamInventory"));
                WhamInventoryTotal = WhamInventoryTotal + WhamInventoryrowTotal;
                int TowelsrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Towels"));
                TowelsTotal = TowelsTotal + TowelsrowTotal;
                int CottonPadsrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CottonPads"));
                CottonPadsTotal = CottonPadsTotal + CottonPadsrowTotal;
                int CottonSwabsrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CottonSwabs"));
                CottonSwabsTotal = CottonSwabsTotal + CottonSwabsrowTotal;
                int PaperTowelsrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PaperTowels"));
                PaperTowelsTotal = PaperTowelsTotal + PaperTowelsrowTotal;
                int GarbageBagsrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "GarbageBags"));
                GarbageBagsTotal = GarbageBagsTotal + GarbageBagsrowTotal;
                int TreatsrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Treats"));
                TreatsTotal = TreatsTotal + TreatsrowTotal;
                int VetWraprowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "VetWrap"));
                VetWrapTotal = VetWrapTotal + VetWraprowTotal;
                int WipesrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Wipes"));
                WipesTotal = WipesTotal + WipesrowTotal;
                int EnvelopesrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Envelopes"));
                EnvelopesTotal = EnvelopesTotal + EnvelopesrowTotal;
                int QuickStoprowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QuickStop"));
                QuickStoprowTotal = QuickStoprowTotal + QuickStoprowTotal;
                int LiquidBandaidrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LiquidBandaid"));
                LiquidBandaidTotal = LiquidBandaidTotal + LiquidBandaidrowTotal;
                int ReceiptsrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Receipts"));
                ReceiptsTotal = ReceiptsTotal + ReceiptsrowTotal;
                int BusinessCardsrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BusinessCards"));
                BusinessCardsTotal = BusinessCardsTotal + BusinessCardsrowTotal;
                int BladesSharpenedrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BladesSharpened"));
                BladesSharpenedTotal = BladesSharpenedTotal + BladesSharpenedrowTotal;
                int ScissorsSharpenedrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ScissorsSharpened"));
                ScissorsSharpenedTotal = ScissorsSharpenedTotal + ScissorsSharpenedrowTotal;
                int SunGuardrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SunGuard"));
                SunGuardTotal = SunGuardTotal + SunGuardrowTotal;
                int EZShedrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "EZShed"));
                EZShedTotal = EZShedTotal + EZShedrowTotal;
                int EZDemattrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "EZDematt"));
                EZDemattTotal = EZDemattTotal + EZDemattrowTotal;
                int SkunkKitrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SkunkKit"));
                SkunkKitTotal = SkunkKitTotal + SkunkKitrowTotal;
                int OtherrowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Other"));
                OtherTotal = OtherTotal + OtherrowTotal;

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //Credit card Revenue
                Label lblRevenueCreditCardTotal = (Label)e.Row.FindControl("lblRevenueCreditCardTotal");
                lblRevenueCreditCardTotal.Text = RevenueCreditCardTotal.ToString("c");
                Label lblRevenueCheckTotal = (Label)e.Row.FindControl("lblRevenueCheckTotal");
                lblRevenueCheckTotal.Text = RevenueCheckTotal.ToString("c");
                Label lblRevenueCashTotal = (Label)e.Row.FindControl("lblRevenueCashTotal");
                lblRevenueCashTotal.Text = RevenueCashTotal.ToString("c");
                Label lblRevenueInvoiceTotal = (Label)e.Row.FindControl("lblRevenueInvoiceTotal");
                lblRevenueInvoiceTotal.Text = RevenueInvoiceTotal.ToString("c");

                // Tip Revenue
                Label lblTipCreditCardTotal = (Label)e.Row.FindControl("lblTipCreditCardTotal");
                lblTipCreditCardTotal.Text = TipCreditCardTotal.ToString("c");
                Label lblTipCheckTotal = (Label)e.Row.FindControl("lblTipCheckTotal");
                lblTipCheckTotal.Text = TipCheckTotal.ToString("c");
                Label lblTipCashTotal = (Label)e.Row.FindControl("lblTipCashTotal");
                lblTipCashTotal.Text = TipCashTotal.ToString("c");
                Label lblTipInvoiceTotal = (Label)e.Row.FindControl("lblTipInvoiceTotal");
                lblTipInvoiceTotal.Text = TipInvoiceTotal.ToString("c");

                //prior revenue
                Label lblPriorCreditCardTotal = (Label)e.Row.FindControl("lblPriorCreditCardTotal");
                lblPriorCreditCardTotal.Text = PriorCreditCardTotal.ToString("c");
                Label lblPriorCheckTotal = (Label)e.Row.FindControl("lblPriorCheckTotal");
                lblPriorCheckTotal.Text = PriorCheckTotal.ToString("c");
                Label lblPriorCashTotal = (Label)e.Row.FindControl("lblPriorCashTotal");
                lblPriorCashTotal.Text = PriorCashTotal.ToString("c");

                //for Appointment 
                Label lblPetsTotal = (Label)e.Row.FindControl("lblPetsTotal");
                lblPetsTotal.Text = PetsTotal.ToString();
                Label lblRebookPetsTotal = (Label)e.Row.FindControl("lblRebookPetsTotal");
                lblRebookPetsTotal.Text = RebookTotal.ToString();
                Label lblPetsfromRebookTotal = (Label)e.Row.FindControl("lblPetsfromRebookTotal");
                lblPetsfromRebookTotal.Text = FromRebookTotal.ToString();
                Label lblNewPetsTotal = (Label)e.Row.FindControl("lblNewPetsTotal");
                lblNewPetsTotal.Text = NewTotal.ToString();
                Label lblHoursTotal = (Label)e.Row.FindControl("lblHoursTotal");
                lblHoursTotal.Text = TotlaHoursTotal.ToString();
                Label lblFleaandTick22Total = (Label)e.Row.FindControl("lblFleaandTick22Total");
                lblFleaandTick22Total.Text = FleaandTick22Total.ToString();
                Label lblFleaandTick44Total = (Label)e.Row.FindControl("lblFleaandTick44Total");
                lblFleaandTick44Total.Text = FleaandTick44Total.ToString();
                Label lblFleaandTick88Total = (Label)e.Row.FindControl("lblFleaandTick88Total");
                lblFleaandTick88Total.Text = FleaandTick88Total.ToString();
                Label lblFleaandTick132Total = (Label)e.Row.FindControl("lblFleaandTick132Total");
                lblFleaandTick132Total.Text = FleaandTick132Total.ToString();
                Label lblFleaandTickCatTotal = (Label)e.Row.FindControl("lblFleaandTickCatTotal");
                lblFleaandTickCatTotal.Text = FleaandTickCatTotal.ToString();
                Label lblTBTotal = (Label)e.Row.FindControl("lblTBTotal");
                lblTBTotal.Text = TBTotal.ToString();
                Label lblWhamTotal = (Label)e.Row.FindControl("lblWhamTotal");
                lblWhamTotal.Text = WhamTotal.ToString();
                Label lblFuelPurchasedTotal = (Label)e.Row.FindControl("lblFuelPurchasedTotal");
                lblFuelPurchasedTotal.Text = FuelPurchasedTotal.ToString("c");
                Label lblPricePerGallonTotal = (Label)e.Row.FindControl("lblPricePerGallonTotal");
                lblPricePerGallonTotal.Text = PricePerGallonTotal.ToString("c");

                //For Suppliers check out
                Label lblFleaTick22Total = (Label)e.Row.FindControl("lblFleaTick22Total");
                lblFleaTick22Total.Text = FleaTick22Total.ToString();
                Label lblFleaTick44Total = (Label)e.Row.FindControl("lblFleaTick44Total");
                lblFleaTick44Total.Text = FleaTick44Total.ToString();
                Label lblFleaTick88Total = (Label)e.Row.FindControl("lblFleaTick88Total");
                lblFleaTick88Total.Text = FleaTick88Total.ToString();
                Label lblFleaTick132Total = (Label)e.Row.FindControl("lblFleaTick132Total");
                lblFleaTick132Total.Text = FleaTick132Total.ToString();
                Label lblFleaTickcATTotal = (Label)e.Row.FindControl("lblFleaTickcATTotal");
                lblFleaTickcATTotal.Text = FleaTickcATTotal.ToString();
                Label lblToothbrushesTotal = (Label)e.Row.FindControl("lblToothbrushesTotal");
                lblToothbrushesTotal.Text = ToothbrushesTotal.ToString();
                Label lblWhamInventoryTotal = (Label)e.Row.FindControl("lblWhamInventoryTotal");
                lblWhamInventoryTotal.Text = WhamInventoryTotal.ToString();
                Label lblTowelsTotal = (Label)e.Row.FindControl("lblTowelsTotal");
                lblTowelsTotal.Text = TowelsTotal.ToString();
                Label lblCottonPadsTotal = (Label)e.Row.FindControl("lblCottonPadsTotal");
                lblCottonPadsTotal.Text = CottonPadsTotal.ToString();
                Label lblCottonSwabsTotal = (Label)e.Row.FindControl("lblCottonSwabsTotal");
                lblCottonSwabsTotal.Text = CottonSwabsTotal.ToString();
                Label lblPaperTowelsTotal = (Label)e.Row.FindControl("lblPaperTowelsTotal");
                lblPaperTowelsTotal.Text = PaperTowelsTotal.ToString();
                Label lblGarbageBagsTotal = (Label)e.Row.FindControl("lblGarbageBagsTotal");
                lblGarbageBagsTotal.Text = GarbageBagsTotal.ToString();
                Label lblTreatsTotal = (Label)e.Row.FindControl("lblTreatsTotal");
                lblTreatsTotal.Text = TreatsTotal.ToString();
                Label lblVetWrapTotal = (Label)e.Row.FindControl("lblVetWrapTotal");
                lblVetWrapTotal.Text = VetWrapTotal.ToString();
                Label lblWipesTotal = (Label)e.Row.FindControl("lblWipesTotal");
                lblWipesTotal.Text = WipesTotal.ToString();
                Label lblEnvelopesTotal = (Label)e.Row.FindControl("lblEnvelopesTotal");
                lblEnvelopesTotal.Text = EnvelopesTotal.ToString();
                Label lblQuickStopTotal = (Label)e.Row.FindControl("lblQuickStopTotal");
                lblQuickStopTotal.Text = QuickStopTotal.ToString();
                Label lblLiquidBandaidTotal = (Label)e.Row.FindControl("lblLiquidBandaidTotal");
                lblLiquidBandaidTotal.Text = LiquidBandaidTotal.ToString();
                Label lblReceiptsTotal = (Label)e.Row.FindControl("lblReceiptsTotal");
                lblReceiptsTotal.Text = ReceiptsTotal.ToString();
                Label lblBusinessCardsTotal = (Label)e.Row.FindControl("lblBusinessCardsTotal");
                lblBusinessCardsTotal.Text = BusinessCardsTotal.ToString();
                Label lblBladesSharpenedTotal = (Label)e.Row.FindControl("lblBladesSharpenedTotal");
                lblBladesSharpenedTotal.Text = BladesSharpenedTotal.ToString();
                Label lblScissorsSharpenedTotal = (Label)e.Row.FindControl("lblScissorsSharpenedTotal");
                lblScissorsSharpenedTotal.Text = ScissorsSharpenedTotal.ToString();
                Label lblSunGuardTotal = (Label)e.Row.FindControl("lblSunGuardTotal");
                lblSunGuardTotal.Text = SunGuardTotal.ToString();
                Label lblEZShedTotal = (Label)e.Row.FindControl("lblEZShedTotal");
                lblEZShedTotal.Text = EZShedTotal.ToString();
                Label lblEZDemattTotal = (Label)e.Row.FindControl("lblEZDemattTotal");
                lblEZDemattTotal.Text = EZDemattTotal.ToString();
                Label lblSkunkKitTotal = (Label)e.Row.FindControl("lblSkunkKitTotal");
                lblSkunkKitTotal.Text = SkunkKitTotal.ToString();
                Label lblOtherTotal = (Label)e.Row.FindControl("lblOtherTotal");
                lblOtherTotal.Text = OtherTotal.ToString();

            }
        }
        protected void GrdGroomer_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow =
                new GridViewRow(0, 0, DataControlRowType.Header,
                DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Appointment";
                HeaderCell.ColumnSpan = 5;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = " ";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Flea & Tick";
                HeaderCell.ColumnSpan = 7;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = " ";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revenue";
                HeaderCell.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Tip Revenue";
                HeaderCell.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Prior Revenue";
                HeaderCell.ColumnSpan = 3;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Fuel";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Supplies Checked Out";
                HeaderCell.ColumnSpan = 27;
                HeaderGridRow.Cells.Add(HeaderCell);

                GrdGroomer.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            HtmlForm frm = new HtmlForm();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=monthlyreport.xls");
            //Response.AddHeader("content-disposition", "attachment;filename=" + Session["SheetName"].ToString() + ".xls");
            Response.Charset = "";
            // If you want the option to open the Excel file without saving then
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            frm.Controls.Add(GrdGroomer);
            this.Controls.Add(frm);
            frm.RenderControl(htmlWrite);

            //GrdGroomer.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        protected void lnkNorec_Click(object sender, EventArgs e)
        {
            Response.Redirect("GroomerForMonthlyLog.aspx?SearchFor=0&SearchText=");
        }
    }
