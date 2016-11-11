using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using advancewebtosolution.BO;

public partial class Admin_AppointmentDateSetting : System.Web.UI.Page
{
    #region "Declare Variable"
    PagedDataSource pgds = new PagedDataSource();
    #endregion

    #region "Page Load"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    #endregion

    #region "Sorting"
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

    #region "Save Button"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDate.Text == string.Empty)
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.Text = "Please select date to set.";
            return;
        }
        Appointment objApp = new Appointment();
        DataSet DS = new DataSet();
        DS = objApp.GetAppointmentslotsByDate(Convert.ToDateTime(txtDate.Text));
        if (DS.Tables[0].Rows.Count > 0)
        {
            divError.Visible = true;
            lblError.Visible = true;
            lblError.Text = "Date are already allocated to selected date.";
            return;
        }
        else
        {
            objApp.AddAppointmentDate(Convert.ToDateTime(txtDate.Text));
            divError.Visible = true;
            lblError.Visible = true;
            lblError.Text = "date allocated Sucessfully.";
        }
        Response.Redirect("AppointmentDateSetting.aspx");
    }
    #endregion

    #region BindData
    /* Region is use to bind all pet information from database fro this we need pet type cat or dog */
    private void BindGrid()
    {
        try
        {
            Appointment ObjApp = new Appointment();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataView dv = new DataView();
            ds = ObjApp.GetAppointmentDate();

            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvBreed.Visible = true;
                btnDelete.Visible = true;
                btnStatus.Visible = true;
                //lblNorec.Visible = false;
                dt = ds.Tables[0];
                dv = dt.DefaultView;
                if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                    dv.Sort = SortExpression + " " + SortDirection;
                gdvBreed.DataSource = dv;
                gdvBreed.DataBind();
                CheckAll();
                check();
                Utility.Setserial(gdvBreed, "srno");
            }
            else
            {
                btnDelete.Visible = false;
                gdvBreed.Visible = false;
                btnStatus.Visible = false;
            }
        }
        catch  { }
    }
    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */
    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)gdvBreed.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in gdvBreed.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in gdvBreed.Rows)
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

        foreach (GridViewRow grv in gdvBreed.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select atleast one date');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do you want to delete selected date?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do you want to change status of date?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);
        //btnactdeact.Attributes.Add("onclick", "return val(0);");
        btnDelete.Attributes.Add("onclick", "return val(1);");
        btnStatus.Attributes.Add("onclick", "return val(2);");
    }
    #endregion

    #region "Grid Events"
    protected void gdvBreed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void gdvBreed_Sorting(object sender, GridViewSortEventArgs e)
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
        gdvBreed.PageIndex = 0;
        BindGrid();
    }
    protected void gdvBreed_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvBreed.SelectedIndex = -1;
        gdvBreed.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void gdvBreed_RowCreated(object sender, GridViewRowEventArgs e)
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
        gdvBreed.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        BindGrid();
    }

    protected void gdvBreed_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = gdvBreed.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(gdvBreed.PageIndex + 1);
        int[] page = new int[7];
        page[0] = gdvBreed.PageIndex - 2;
        page[1] = gdvBreed.PageIndex - 1;
        page[2] = gdvBreed.PageIndex;
        page[3] = gdvBreed.PageIndex + 1;
        page[4] = gdvBreed.PageIndex + 2;
        page[5] = gdvBreed.PageIndex + 3;
        page[6] = gdvBreed.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > gdvBreed.PageCount)
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
        if (gdvBreed.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;
        }
        if (gdvBreed.PageIndex == gdvBreed.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;
        }
        if (gdvBreed.PageIndex > gdvBreed.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (gdvBreed.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    #endregion

    #region "Delete Button"
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Appointment ObjApp = new Appointment();
            for (int i = 0; i <= gdvBreed.Rows.Count - 1; i++)
            {
                CheckBox chk = (CheckBox)gdvBreed.Rows[i].FindControl("chkSelect");
                Label lblDate = (Label)gdvBreed.Rows[i].FindControl("lblDate");
                if (chk.Checked)
                {
                    ObjApp.DeleteAppointmentsDate(Convert.ToDateTime(Convert.ToDateTime(lblDate.Text)));
                }
            }
            lblError.Text = "Date deleted successfully.";
            BindGrid();
        }
        catch  { }
    }
    #endregion

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        try
        {
            #region oldregion
            DateTime TodaysDate = System.DateTime.Now;////////paetd by mmohit   

            ///       if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday && e.Day.Date < TodaysDate)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
                //December
                DateTime dt = new DateTime();
                string t = "2013-12-22 00:00:00.000";
                dt = Convert.ToDateTime(t);
                if (e.Day.Date == dt)
                {
                    e.Day.IsSelectable = true;
                    e.Cell.ForeColor = System.Drawing.Color.Black;
                }
            }
            ///    DateTime TodaysDate = System.DateTime.Now;
            if (TodaysDate.Date > e.Day.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
            if (e.Day.Date == new DateTime(e.Day.Date.Year, 01, 01))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
            if (e.Day.Date == new DateTime(e.Day.Date.Year, 07, 4))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
            if (e.Day.Date == new DateTime(e.Day.Date.Year, 12, 25))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
            //may
            if (e.Day.Date == new DateTime(2010, 05, 31))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
            //september
            if (e.Day.Date == new DateTime(2010, 09, 06))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
            //november
            if (e.Day.Date == new DateTime(2010, 11, 25))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
            #endregion
        }
        catch  { }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime TodaysDate = System.DateTime.Now;
        DateTime SelectedDate = Calendar1.SelectedDate.Date;
        int day = SelectedDate.Day;
        int year = SelectedDate.Year;
        int month = SelectedDate.Month;
        txtDate.Text = Calendar1.SelectedDate.ToShortDateString();
        //dddDay.SelectedValue = day.ToString();
        //ddlMonth.SelectedValue = month.ToString();
        lblError.Visible = false;
        if (SelectedDate.Year > TodaysDate.Year)
        {
            //ddlYear.SelectedValue = year.ToString();
        }
    }
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        try
        {
            string AdId = Utility.GetCheckedRow(gdvBreed, "chkSelect");
            if (AdId != "")
            {
                Appointment ObjApp = new Appointment();
                ObjApp.UpdateAppointmentdateStatus(AdId);
                BindGrid();
            }
        }
        catch  { }
    }
}
