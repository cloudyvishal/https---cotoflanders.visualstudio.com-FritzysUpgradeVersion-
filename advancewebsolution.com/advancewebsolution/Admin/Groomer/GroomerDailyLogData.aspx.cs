using advancewebtosolution.BO;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

    public partial class Admin_Groomer_GroomerDailyLogData : System.Web.UI.Page
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
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                GetGroomerDailyLogData();
            }
        }
        public void GetGroomerDailyLogData()
        {
            Groomer objgroomer = new Groomer();
            DataSet ds = new DataSet();
            ds = objgroomer.GetGroomerDailyLogData(Convert.ToInt32(Request.QueryString["GID"].ToString()), ddlLastweek.SelectedItem.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdGroomer.DataSource = ds;
                GrdGroomer.DataBind();
                lblName.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                lblBeginningMileage.Text = ds.Tables[0].Rows[0]["BeginningMileage"].ToString();
                lblEndingMileage.Text = ds.Tables[0].Rows[0]["EndingMileage"].ToString();
                lblDate.Text = ds.Tables[0].Rows[0]["addedon"].ToString();
                Session["SheetName"] = ds.Tables[1].Rows[0]["SheetName"].ToString();
                dvgroomers.Visible = true;
                divError.Visible = false;
            }
            else
            {
                divError.Visible = true;
                dvgroomers.Visible = false;
                ErrorMessage("Sorry, No records found.");
            }
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
                HeaderCell.ColumnSpan = 3;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Flea & Tick";
                HeaderCell.ColumnSpan = 5;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Other Product";
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
                GrdGroomer.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
        protected void lnkNorec_Click(object sender, EventArgs e)
        {
            Response.Redirect("GroomersForData.aspx?SearchFor=0&SearchText=");
        }
        protected void ddlLastweek_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroomerDailyLogData();
        }

        public void BindDropDown()
        {
            ArrayList AlDay = new ArrayList();
            for (int i = 0; i < 8; i++)
            {
                DateTime dt = System.DateTime.Today.AddDays(-i);
                //AlDay.Add(dt.ToLongDateString());
                AlDay.Add(dt.Date);
            }
            ddlLastweek.DataSource = AlDay;
            ddlLastweek.DataBind();
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            HtmlForm frm = new HtmlForm();
            Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
            Response.AddHeader("content-disposition", "attachment;filename=" + Session["SheetName"].ToString() + ".xls");
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
    }
