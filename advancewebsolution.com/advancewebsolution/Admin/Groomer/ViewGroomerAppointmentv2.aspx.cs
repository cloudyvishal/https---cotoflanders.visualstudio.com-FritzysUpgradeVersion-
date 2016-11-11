using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HicPicDataAccess;
using System.Data.SqlClient;
using advancewebtosolution.BO;
using System.Globalization;

public partial class Admin_Groomer_ViewGroomerAppointmentv2 : Page
{
    #region GetAdimn Date
    DateTime adminConfirmtxtDate = Convert.ToDateTime(DateTime.Now);
    string adminConfirmDate = string.Empty;
    string[] calYearMonthDate = new string[2];
    string calYear = string.Empty;
    string calMonth = string.Empty;
    string calDate1 = string.Empty;
    string[] calCompleteTime = new string[2];
    string calStartTime = string.Empty;
    string calStartMinute = string.Empty;
    string calStartHour = string.Empty;
    string calEndTime = string.Empty;
    string calEndMinute = string.Empty;
    string calEndHour = string.Empty;
    string calStartSecond = string.Empty;
    string calEndSecond = string.Empty;
    string DateReturn = string.Empty;
    string AMPMStart = string.Empty;
    string AMPMEnd = string.Empty;
    string StartTime = string.Empty;
    string EndTime = string.Empty;
    #endregion GetAdimn Date

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Add"] = "false";
            var c = new HttpCookie("Addexceptional");
            c.Expires = DateTime.Now.AddMinutes(-1);
            Response.Cookies.Remove("Addexceptional");
            BindGroomersAppointment();
            BindDayYear();
            DvAptGrid.Attributes["class"] = "ViewAptGrid";
        }
    }
    #endregion Page Load

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

    #region BindGroomer
    public void BindGroomers()
    {
        Groomer objGroomer = new Groomer();
        DataSet ds = new DataSet();
        ds = objGroomer.BindGroomers();
        ddlGroomerlist.Items.Clear();
        ListItem lst = new ListItem();
        lst.Selected = true; lst.Value = "0";
        lst.Text = "Select One";
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlGroomerlist.DataTextField = "name";
            ddlGroomerlist.DataValueField = "Gid";
            ddlGroomerlist.DataSource = ds.Tables[0];
            ddlGroomerlist.DataBind();
        }
        ddlGroomerlist.Items.Insert(0, lst);
    }

    #endregion BindGroomer

    #region CheckBox

    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */
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
        checkid += "alert('Select Atleast One Groomer Appointment');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Delete Selected User(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Delete Groomer Appointment(s) ?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);
        btnDeleteAppointment.Attributes.Add("onclick", "return val(2);");
    }
    #endregion CheckBox

    #region BindData
    /* Bind User function is use to bind all users to grid */
    public void BindGroomersAppointment()
    {
        Groomer ObjGroomer = new Groomer();
        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataView dv = new DataView();
        DateTime TodaysDate = System.DateTime.Now;
        DateTime olddate = Convert.ToDateTime("01/01/0001");
        ds = ObjGroomer.GetGroomersTodaysAppointment();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdUsers.Visible = true;
            dt1 = ds.Tables[0];
            dv = dt1.DefaultView;
            dv.Sort = "Name ASC,AppointmentDate ASC,ExpPetTime ASC,SequenceNo ASC";
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
            {
                if ((SortExpression == "Name") && (SortDirection == "ASC"))
                {
                    dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo ASC";
                }
                if ((SortExpression == "Name") && (SortDirection == "DESC"))
                {
                    dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo Asc";
                }
                if ((SortExpression == "AppointmentDate") && (SortDirection == "ASC"))
                {
                    dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo ASC";
                }
                if ((SortExpression == "AppointmentDate") && (SortDirection == "DESC"))
                {
                    dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo Asc";
                }
                if ((SortExpression == "SequenceNo") && (SortDirection == "ASC"))
                {
                    dv.Sort = SortExpression + " " + SortDirection + "," + "Name ASC";
                }
                if ((SortExpression == "SequenceNo") && (SortDirection == "DESC"))
                {
                    dv.Sort = SortExpression + " " + SortDirection + "," + "Name ASC";
                }
                if ((SortExpression == "ExpPetTime") && (SortDirection == "ASC"))
                {
                    dv.Sort = SortExpression + " " + SortDirection + "," + "Name ASC";
                }
                if ((SortExpression == "ExpPetTime") && (SortDirection == "DESC"))
                {
                    dv.Sort = SortExpression + " " + SortDirection + "," + "Name ASC";
                }
            }
            GrdUsers.DataSource = dv;
            GrdUsers.DataBind();
            CheckAll();
            check();
        }
        else
        {
            GrdUsers.Visible = false;
            ErrorMessage("Sorry, No appointment scheduled for today");
        }
    }
    public void BindGroomersAppointmentByDate(DateTime dt)
    {
        Groomer ObjGroomer = new Groomer();
        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataView dv = new DataView();
        try
        {
            #region BindApp
            Session["CalenderDateSelected"] = dt;
            ds = ObjGroomer.GetGroomersTodaysAppointmentByDate(dt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdUsers.Visible = true;
                dt1 = ds.Tables[0];
                dv = dt1.DefaultView;
                dv.Sort = "Name ASC,AppointmentDate ASC,ExpPetTime ASC,SequenceNo ASC";
                if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                {
                    if ((SortExpression == "Name") && (SortDirection == "ASC"))
                    {
                        dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo ASC";
                    }
                    if ((SortExpression == "Name") && (SortDirection == "DESC"))
                    {
                        dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo Asc";
                    }
                    if ((SortExpression == "AppointmentDate") && (SortDirection == "ASC"))
                    {
                        dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo ASC";
                    }
                    if ((SortExpression == "AppointmentDate") && (SortDirection == "DESC"))
                    {
                        dv.Sort = SortExpression + " " + SortDirection + "," + "SequenceNo Asc";
                    }
                    if ((SortExpression == "SequenceNo") && (SortDirection == "ASC"))
                    {
                        dv.Sort = SortExpression + " " + SortDirection + "," + "Name ASC";
                    }
                    if ((SortExpression == "SequenceNo") && (SortDirection == "DESC"))
                    {
                        dv.Sort = SortExpression + " " + SortDirection + "," + "Name ASC";
                    }
                    if ((SortExpression == "ExpPetTime") && (SortDirection == "ASC"))
                    {
                        dv.Sort = SortExpression + " " + SortDirection + "," + "Name ASC";
                    }
                    if ((SortExpression == "ExpPetTime") && (SortDirection == "DESC"))
                    {
                        dv.Sort = SortExpression + " " + SortDirection + "," + "Name ASC";
                    }
                }
                divError.Visible = false;
                GrdUsers.DataSource = dv;
                GrdUsers.DataBind();
                CheckAll();
                check();
            }
            else
            {
                GrdUsers.Visible = false;
                ErrorMessage("Sorry, No appointment scheduled for " + dt.ToString("MM'/'dd'/'yy"));
            }
            #endregion BindApp
        }
        catch (Exception ex)
        {
            ErrorMessage("Error: " + ex);
        }
    }
    #endregion

    #region MessageBox
    private void MessageBox(string strMsg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert(" + "'" + strMsg + "'" + ")</script>";
        Page.Controls.Add(lbl);
    }
    #endregion MessageBox

    #region GrdUsers Events
    protected void GrdUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        int rowindex = GrdUsers.SelectedIndex;
        try
        {
            BindGroomers();
            Label lblAppointmentID = (Label)GrdUsers.Rows[rowindex].FindControl("lblAppointmentID");
            Label lblSequenceNo = (Label)GrdUsers.Rows[rowindex].FindControl("lblSequenceNo");
            Label groomername = (Label)GrdUsers.Rows[rowindex].FindControl("lblName");
            Label groomerId = (Label)GrdUsers.Rows[rowindex].FindControl("lblGID");
            Label lblAppointmentDate = (Label)GrdUsers.Rows[rowindex].FindControl("lblAppointmentDate");
            Label lblCustName = (Label)GrdUsers.Rows[rowindex].FindControl("lblCustName");
            Label lblCustEmail = (Label)GrdUsers.Rows[rowindex].FindControl("lblcustEmail");
            Label lblString = (Label)GrdUsers.Rows[rowindex].FindControl("lblString");
            Label lblExpectedTotalRevenue = (Label)GrdUsers.Rows[rowindex].FindControl("lblExpectedTotalRevenue");
            Label lbltxtExpectedPetTime1 = (Label)GrdUsers.Rows[rowindex].FindControl("lbltxtExpectedPetTime");
            Label lblAptSTime = (Label)GrdUsers.Rows[rowindex].FindControl("lblAptSTime");
            Label lblAptETime = (Label)GrdUsers.Rows[rowindex].FindControl("lblAptETime");

            hfAppointmentId.Value = lblAppointmentID.Text;
            txtDate.Text = lblAppointmentDate.Text;
            ddlGroomerlist.ClearSelection();
            ddlGroomerlist.Items.FindByValue(groomerId.Text).Selected = true;
            txtOthers.Text = lblString.Text;
            txtCustomerName.Text = lblCustName.Text != "No Name" ? lblCustName.Text : "";
            txtCustEmail.Text = lblCustEmail.Text != "No Email" ? lblCustEmail.Text : "";
            txtTotalRevnueExpected.Text = lblExpectedTotalRevenue.Text;
            txtExpectedpettime.Text = lbltxtExpectedPetTime1.Text;
            txtSequence.Text = lblSequenceNo.Text;
            Session["EditMode"] = "0";
            lblUpdateError.Text = "";
            lblDoubleBook.Visible = false;
            this.ModalPopupExtender1.Show();
            pnlpopup.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
        }
        catch
        {

        }
    }
  

    protected void GrdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdUsers.PageIndex = e.NewPageIndex;
        if (Session["CalenderDateSelected"] == null)
            BindGroomersAppointment();
        else
            BindGroomersAppointmentByDate(Convert.ToDateTime(Session["CalenderDateSelected"].ToString()));
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
        if (Session["CalenderDateSelected"] == null)
            BindGroomersAppointment();
        else
            BindGroomersAppointmentByDate(Convert.ToDateTime(Session["CalenderDateSelected"].ToString()));
    }

    protected void GrdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlName = (DropDownList)e.Row.FindControl("ddlName");
            DropDownList ddlStatusPresented = (DropDownList)e.Row.FindControl("ddlStatusPresented");
            Label lblGId = (Label)e.Row.FindControl("lblGId");
            Label lblAStatusId = (Label)e.Row.FindControl("lblAStatusId");
            Label lblSPresented = (Label)e.Row.FindControl("lblSPresented");
            Label lblGroomerCompletedStatus = (Label)e.Row.FindControl("lblStatus");
            LinkButton lbkBtn = (LinkButton)e.Row.Cells[16].Controls[0];
            if (lblGroomerCompletedStatus.Text == "YES")
                lbkBtn.Enabled = false;
            Groomer objGroomer = new Groomer();
            DataSet ds = new DataSet();
            ds = objGroomer.BindGroomers();
            if (GrdUsers.EditIndex == e.Row.RowIndex)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlName.DataTextField = "Name";
                    ddlName.DataValueField = "Gid";
                    ddlName.DataSource = ds.Tables[0];
                    ddlName.DataBind();
                    ddlName.SelectedValue = lblGId.Text.ToString();
                }
                ddlStatusPresented.Items.Remove("NO");
                ddlStatusPresented.Items.Remove("YES");
                ddlStatusPresented.Items.Insert(0, "NO");
                ddlStatusPresented.Items.Insert(1, "YES");
                ddlStatusPresented.Text = lblSPresented.Text.ToString();
            }
        }
    }
    protected void GrdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int AppointmentIDs;
        Groomer objGroomer = new Groomer();
        DataSet ds5 = new DataSet();
        GridViewRow row = GrdUsers.Rows[e.RowIndex];
        if (row != null)
        {
            AppointmentIDs = Convert.ToInt32(GrdUsers.DataKeys[e.RowIndex].Value);
            Label lblGId = (Label)GrdUsers.Rows[e.RowIndex].FindControl("lblGId");
            objGroomer.DeleteGroomerAppointment(AppointmentIDs);
            ds5 = objGroomer.GetPreviousGroomersSequenceforUpdate(Convert.ToInt32(lblGId.Text), Session["SelectedDate"].ToString());
            if (ds5.Tables[0].Rows.Count > 0)
            {
                for (int n = 0; n < ds5.Tables[0].Rows.Count; n++)
                {
                    objGroomer.UpdateGroomerSequence(Convert.ToInt32(lblGId.Text), Convert.ToDateTime(Session["SelectedDate"]), n + 1, Convert.ToInt32(ds5.Tables[0].Rows[n]["AppointmentId"]));
                    if (Session["CalenderDateSelected"] == null)
                        BindGroomersAppointment();
                    else
                        BindGroomersAppointmentByDate(Convert.ToDateTime(Session["CalenderDateSelected"].ToString()));
                    SuccessMessage("Groomer(s) appointment deleted successfully.");
                }
            }
            else
            {
                if (Session["CalenderDateSelected"] == null)
                    BindGroomersAppointment();
                else
                    BindGroomersAppointmentByDate(Convert.ToDateTime(Session["CalenderDateSelected"].ToString()));
                SuccessMessage("Groomer(s) appointment deleted successfully.");
            }
        }
    }

    protected void GrdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            int rowIndex = ((GridViewRow)((ImageButton)e.CommandSource).NamingContainer).RowIndex;
            int Id = Convert.ToInt32(e.CommandArgument);
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteGroomerAppointment", new SqlParameter[] { new SqlParameter("@AppointmentId", Id) });
            DB.Dispose();
            if (Session["CalenderDateSelected"] == null)
                BindGroomersAppointment();
            else
                BindGroomersAppointmentByDate(Convert.ToDateTime(Session["CalenderDateSelected"].ToString()));
            SuccessMessage("Groomer(s) appointment deleted successfully.");
        }
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
        if (Session["CalenderDateSelected"] == null)
            BindGroomersAppointment();
        else
            BindGroomersAppointmentByDate(Convert.ToDateTime(Session["CalenderDateSelected"].ToString()));
    }

    #endregion

    #endregion GrdUsers Events

    #region Calender
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddGroomerAppointment.aspx");
    }

    protected void calDate_SelectionChanged(object sender, EventArgs e)
    {
        if (calDate.SelectedDate != null)
        {
            Session["CalenderDateSelected"] = calDate.SelectedDate;
            BindGroomersAppointmentByDate(calDate.SelectedDate);
            if (calDate.SelectedDate >= DateTime.Now.Date)
                btnAdd.Visible = true;
            else
                btnAdd.Visible = false;
        }
        else
        {
            MessageBox("Please Choose a Date");
        }
    }

    public void BindDayYear()
    {
        string[] day = new string[31];
        for (int i = 0; i < 31; i++)
        {
            day[i] = (i + 1).ToString();
        }
        string[] Years = new string[5];
        for (int i = 0; i < 5; i++)
        {
            Years[i] = (DateTime.Now.Year - i).ToString();
        }
        ddlYear.DataSource = Years;
        ddlYear.DataBind();
    }

    #region Selected Appointment Permanently Delete
    protected void btnDeleteAppointment_Click(object sender, EventArgs e)
    {
        List<string> appointmentIds = new List<string>();
        foreach (string key in Request.Form.Keys)
        {
            if (key.StartsWith("chkDelete"))
            {
                appointmentIds.Add(key.Substring(9));
            }
        }
        if (appointmentIds.Count > 0)
        {
            Groomer g = new Groomer();
            foreach (string apptId in appointmentIds)
            {
                g.DeleteGroomerAppointment(int.Parse(apptId));
            }

            SuccessMessage("Selected Appointment Deleted Successfully..");

            if (Session["CalenderDateSelected"] == null)
                BindGroomersAppointment();
            else
                BindGroomersAppointmentByDate(Convert.ToDateTime(Session["CalenderDateSelected"].ToString()));
        }
        else
        {
            ErrorMessage("Please Select Appointment To Delete.");
        }
    }

    #endregion Selected Appointment

    #region  delete whole month appointment 
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string month = ddlMonth.SelectedValue + "/" + "1" + "/" + ddlYear.SelectedValue;
        DateTime dtSelectedDate = new DateTime();
        string.Format("{0:HH:mm:ss tt}", DateTime.Now);
        dtSelectedDate = Convert.ToDateTime(month);
        DateTime todaysdate = new DateTime();
        todaysdate = System.DateTime.Today.AddMonths(-2);

        if (dtSelectedDate < todaysdate)
        {
            DateTime enddate;
            enddate = dtSelectedDate.Date.AddMonths(1);
            Groomer objGroomer = new Groomer();
            string stDate = dtSelectedDate.ToString().Replace("12:00:00 AM", string.Format("{0:HH:mm:ss tt}", DateTime.Now));
            string endDate = enddate.AddDays(-1).ToString().Replace("12:00:00 AM", string.Format("{0:HH:mm:ss tt}", DateTime.Now));
            objGroomer.DeleteOldGroomerAppointment(stDate, endDate);
            if (Session["CalenderDateSelected"] == null)
                BindGroomersAppointment();
            else
                BindGroomersAppointmentByDate(Convert.ToDateTime(Session["CalenderDateSelected"].ToString()));
            SuccessMessage("Groomer(s) appointment deleted successfully.");
        }
        else
        {
            ErrorMessage("Select month should be two months less than current Month.");
        }
    }
    #endregion  delete whole month appointment 
    protected void calDate_DayRender(object sender, DayRenderEventArgs e)
    {
        if (Session["Add"].ToString() == "false" && Session["Add"] != null)
        {
            if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
                DateTime dt = new DateTime();
                string t = "2013-12-22 00:00:00.000";
                dt = Convert.ToDateTime(t);
                if (e.Day.Date == dt)
                {
                    e.Day.IsSelectable = true;
                    e.Cell.ForeColor = System.Drawing.Color.Gray;
                }
            }
            if (Session["SelectedDate"] != null)
            {
                DateTime TodaysDate = Convert.ToDateTime(Session["SelectedDate"]);
            }
            else
            {
                DateTime TodaysDate = System.DateTime.Now;
            }
        }
        else if (Session["addexceptional"] != null)
        {

        }
    }

    protected void exceptionbtn_add_Click(object sender, EventArgs e)
    {
        Session["Add"] = "true";
    }

    #endregion Calender

    #region Update on PopUp
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int AppointmentId = hfAppointmentId.Value != "" ? Convert.ToInt32(hfAppointmentId.Value) : 0;
        if (AppointmentId > 0)
        {
            GetAdminConfirmDate();

            #region "Update Appointment"
            if (!string.IsNullOrEmpty(DateReturn.ToString()))
            {
                Groomer objGroomer = new Groomer();
                DataSet dsseq = new DataSet();
                DataSet ds4 = new DataSet();
                string ApptString = txtOthers.Text;
                dsseq = objGroomer.GetMaxSequencenoOfGroomer(Convert.ToInt32(ddlGroomerlist.SelectedValue), DateReturn.ToString());
                #region 1
                if (dsseq.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(txtSequence.Text) > Convert.ToInt32(dsseq.Tables[0].Rows[0]["sequence"]))
                    {
                        //ErrorMessage("Please enter sequence no in proper order.");
                        lblDoubleBook.Visible = true;
                        txtSequence.Text = dsseq.Tables[0].Rows[0]["sequence"].ToString();
                    }
                    else
                    {
                        //Get Next groomer sequence and update the sequence and then insert new appointment
                        ds4 = objGroomer.GetGroomerNextsequenceForupdate(Convert.ToInt32(dsseq.Tables[0].Rows[0]["GId"]), Convert.ToDateTime(DateReturn), Convert.ToInt32(txtSequence.Text));
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            for (int m = 0; m < ds4.Tables[0].Rows.Count; m++)
                            {
                                int h = Convert.ToInt32(ds4.Tables[0].Rows[m]["SequenceNo"]) + 1;
                                objGroomer.UpdateGroomerSequence(Convert.ToInt32(ds4.Tables[0].Rows[0]["GId"]), Convert.ToDateTime(DateReturn), h, Convert.ToInt32(ds4.Tables[0].Rows[m]["AppointmentId"]));
                            }
                        }

                        int i = objGroomer.UpdateGroomerAppointmentByAdmin(AppointmentId, Convert.ToInt32(ddlGroomerlist.SelectedValue),
                            Convert.ToDateTime(DateReturn.ToString()), "", "",
                            txtTotalRevnueExpected.Text, txtOthers.Text, txtDate.Text,
                            Convert.ToInt32(txtSequence.Text), Convert.ToDecimal(txtExpectedpettime.Text),
                            txtCustomerName.Text, txtCustEmail.Text, StartTime, EndTime);
                        if (i > 0)
                        {
                            // MakeRecConfirmAppointment(AppointmentId, i, txtOthers.Text);
                            SuccessMessage("Appointment Updated Successfully");
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "AppUpdatedSuccessfully", "<script>alert('Appointment Updated Successfully');</script>", false);
                            hfAppointmentId.Value = string.Empty;
                            this.ModalPopupExtender1.Hide();
                            hfAppointmentId.Value = string.Empty;
                        }
                        else
                        {
                            ErrorMessage("Appointment Updation Field Try Again..");
                            hfAppointmentId.Value = string.Empty;
                            this.ModalPopupExtender1.Show();
                            pnlpopup.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                        }
                    }
                }
                #endregion 1 if

                #region 2 else
                else
                {
                    txtSequence.Text = "1";
                    int i = objGroomer.UpdateGroomerAppointmentByAdmin(AppointmentId, Convert.ToInt32(ddlGroomerlist.SelectedValue),
                        Convert.ToDateTime(DateReturn.ToString()), "", "",
                        txtTotalRevnueExpected.Text, txtOthers.Text, txtDate.Text,
                        Convert.ToInt32(txtSequence.Text), Convert.ToDecimal(txtExpectedpettime.Text),
                        txtCustomerName.Text, txtCustEmail.Text, StartTime, EndTime);
                    if (i > 0)
                    {
                        // MakeRecConfirmAppointment(AppointmentId, i, txtOthers.Text);
                        SuccessMessage("Appointment Updated Successfully");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "AppUpdatedSuccessfully", "<script>alert('Appointment Updated Successfully');</script>", false);
                        hfAppointmentId.Value = string.Empty;
                        this.ModalPopupExtender1.Hide();
                        hfAppointmentId.Value = string.Empty;
                        Response.Redirect("ViewGroomerAppointment.aspx");
                    }
                }
                #endregion 2 else
            }
            else
            {
                lblUpdateError.Text = "Please Follow Military date format and enter time  in proper order. ";
                this.ModalPopupExtender1.Show();
                return;
            }
            #endregion "Update Appointment"
        }
        if (Session["CalenderDateSelected"] == null)
            BindGroomersAppointment();
        else
            BindGroomersAppointmentByDate(Convert.ToDateTime(Session["CalenderDateSelected"].ToString()));
    }
    protected void ddlGroomerlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroomerlist.SelectedValue != "0")
        {
            GetAdminConfirmDate();
            if (DateReturn.ToString() != "")
            {
                GetMaxSequencenoOfGroomer();
                divError.Visible = false;
            }
        }
        this.ModalPopupExtender1.Show();
        pnlpopup.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
    }

    protected void GetAdminConfirmDate()
    {
        if (txtDate.Text != "")
        {
            #region GetAdimn Date
            try
            {
                adminConfirmDate = txtDate.Text;
                calYearMonthDate = adminConfirmDate.Split('.');
                if (!(calYearMonthDate[0].Length > 6))
                {
                    calCompleteTime = calYearMonthDate[1].Split('-');
                    var startDate = DateTime.ParseExact(calYearMonthDate[0] + " " + calCompleteTime[0], "yyMMdd HHmm", CultureInfo.InvariantCulture);
                    var endDate = DateTime.ParseExact(calYearMonthDate[0] + " " + calCompleteTime[1], "yyMMdd HHmm", CultureInfo.InvariantCulture);
                    if (startDate <= endDate)
                    {
                        if (startDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            ErrorMessage("Sorry ! You have selected a sunday for Groomer Service please choose another day.");
                            txtDate.Focus();
                            return;
                        }
                        else
                        {
                            DateReturn = startDate.ToString();
                            DateTime dtstart1 = DateTime.ParseExact(calCompleteTime[0], "HHmm", CultureInfo.InvariantCulture);
                            StartTime = dtstart1.ToString("hh:mm tt");
                            DateTime dtend1 = DateTime.ParseExact(calCompleteTime[1], "HHmm", CultureInfo.InvariantCulture);
                            EndTime = dtend1.ToString("hh:mm tt");
                            btnUpdate.Enabled = true;
                            txtExpectedpettime.Text = (dtend1.Subtract(dtstart1)).TotalHours.ToString("N2");
                            divError.Visible = false;
                        }
                    }
                    else
                    {
                        ErrorMessage("Start date must be less than end date.");
                        txtDate.Focus();
                        return;
                    }
                }
                else
                {
                    ErrorMessage("Please Check Date..Please follow Military Date Format (yyMMdd.HHmm-HHmm)");
                    txtDate.Focus();
                    return;
                }
            }
            catch
            {
                ErrorMessage("Please Check Date Formate must match Military Date Formate(yyMMdd.HHmm-HHmm) ");
                txtDate.Focus();
                return;
            }
            #endregion GetAdimn Date
        }
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        GetAdminConfirmDate();
        if (DateReturn.ToString() != "")
        {
            Groomer objGroomer = new Groomer();
            DataSet dsseq = new DataSet();
            dsseq = objGroomer.GetMaxSequencenoOfGroomer(Convert.ToInt32(ddlGroomerlist.SelectedValue), DateReturn.ToString());
            if (dsseq.Tables[0].Rows.Count > 0)
            {
                if (dsseq.Tables[0].Rows[0]["sequence"].ToString() != "")
                {
                    lblDoubleBook.Visible = true;
                    txtSequence.Text = dsseq.Tables[0].Rows[0]["sequence"].ToString();
                }
                else
                {
                    lblDoubleBook.Visible = false;
                    txtSequence.Text = "1";
                }
            }
            else
            {
                lblDoubleBook.Visible = false;
                txtSequence.Text = "1";
            }
            txtOthers.Focus();
        }
        this.ModalPopupExtender1.Show();
        pnlpopup.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
    }
    protected void txtCustEmail_Chenged(object sender, EventArgs e)
    {
        if (txtCustEmail.Text != "")
        {
            Groomer objGroomer = new Groomer();
            DataSet ds = new DataSet();
            ds = objGroomer.GetUserInfoUsingEmail(txtCustEmail.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    txtCustomerName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtTotalRevnueExpected.Focus();
                    divError.Visible = false;
                }
            }
            else
            {
                ErrorMessage("Incorrect User Email...Please Try Again");
                txtCustEmail.Focus();
            }
        }
        else
        {
            ErrorMessage("Please Fill Custumer Email To Connect To Member Profile");
            txtCustEmail.Focus();
        }
        this.ModalPopupExtender1.Show();
        pnlpopup.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
    }
    public void GetMaxSequencenoOfGroomer()
    {
        Groomer objGroomer = new Groomer();
        DataSet dsseq = new DataSet();
        dsseq = objGroomer.GetMaxSequencenoOfGroomer(Convert.ToInt32(ddlGroomerlist.SelectedValue), DateReturn.ToString());
        if (dsseq.Tables[0].Rows.Count > 0)
        {
            if (dsseq.Tables[0].Rows[0]["sequence"].ToString() != "")
            {
                lblDoubleBook.Visible = true;
                txtOthers.Focus();
                txtSequence.Text = dsseq.Tables[0].Rows[0]["sequence"].ToString();
            }
            else
            {
                lblDoubleBook.Visible = false;
                txtSequence.Text = "1";
            }
        }
        else
        {
            lblDoubleBook.Visible = false;
            txtSequence.Text = "1";
        }
    }
    protected void ClearPopUpForEdit()
    {
        hfAppointmentId.Value = string.Empty;
        ddlGroomerlist.Items.Clear();
        txtDate.Text = string.Empty;
        txtOthers.Text = string.Empty;
        txtCustomerName.Text = string.Empty;
        txtCustEmail.Text = string.Empty;
        txtTotalRevnueExpected.Text = string.Empty;
        txtExpectedpettime.Text = string.Empty;
        txtSequence.Text = string.Empty;
        btnUpdate.Enabled = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearPopUpForEdit();
    }

    #endregion Update on PopUp  

    #region COnvert Date To Military Date Time Formate
    private string ConvertToMilitaryDatatime(DateTime dt)
    {
        string militaryDateTime = string.Empty;
        try
        {
            if (dt.ToString().Contains("AM"))
            {
                if (dt.Minute == 0)
                {
                    militaryDateTime = dt.Date.ToString("yyMMdd") + "." + dt.Hour + "00-" + (dt.Hour + 2) + "00";
                }
                else
                {
                    militaryDateTime = dt.Date.ToString("yyMMdd") + "." + dt.Hour + dt.Minute + "-" + (dt.Hour + 2) + "00"; ;
                }
            }
            else if (dt.ToString().Contains("PM"))
            {
                if (dt.Minute == 0)
                {
                    militaryDateTime = dt.Date.ToString("yyMMdd") + "." + dt.Hour + "00-" + (dt.Hour + 2) + "00";
                }
                else
                {
                    militaryDateTime = dt.Date.ToString("yyMMdd") + "." + dt.Hour + dt.Minute + "-" + (dt.Hour + 2) + "00"; ;
                }
            }
            CalculateTimeDifference(new DateTime().Add(new TimeSpan(dt.Hour, dt.Minute, 0)).ToString("yy/MM/dd hh:mm tt"), new DateTime().Add(new TimeSpan(dt.Hour + 2, dt.Minute, 0)).ToString("yy/MM/dd hh:mm tt"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return militaryDateTime;
    }
    #endregion COnvert Date To Military Date Time Formate

    #region Calculate Pet Time
    private void CalculateTimeDifference(string d1, string d2)
    {
        if (d1 != "" && d2 != "")
        {
            try
            {
                txtExpectedpettime.Text = (Convert.ToDateTime(d2) - Convert.ToDateTime(d1)).TotalHours.ToString();
            }
            catch
            {
                txtExpectedpettime.Text = "0";
            }
        }
    }
    #endregion

    #region Rec Appoinment
    protected void MakeRecConfirmAppointment(int AppointmentId, int GAppId, string AppString)
    {
        List<DateTime> dtToSetRecAppointment = new List<DateTime>();
        try
        {
            if (!(string.IsNullOrEmpty(AppString)))
            {
                string AppointmentsSpan = "";
                string[] apptstr = AppString.Split(',');
                if (apptstr.Length > 0)
                {
                    #region Get Rec Number Irespective Of Position 
                    for (int i = 0; i < apptstr.Length; i++)
                    {
                        if (!(null == apptstr[i]))
                        {
                            if (apptstr[i].ToLower().ToString().Trim().StartsWith("rec") && apptstr[i].ToString().Trim().Length <= 5)
                            {
                                AppointmentsSpan = apptstr[i].ToString().Trim().Substring(3).ToString();
                                break;
                            }
                        }
                    }
                    #endregion Get Rec Number Irespective Of Position 
                }

                int number = AppointmentsSpan != "" ? Convert.ToInt32(AppointmentsSpan) : 0;
                if (number > 0)
                {
                    dtToSetRecAppointment = SetAppointmentAfterWeekRecurrence(number, Convert.ToDateTime(DateReturn.ToString()));
                }
                #region Insert/Update Rec Appointment in Appointment Table to view Member
                Groomer objGroomer = new Groomer();
                if (dtToSetRecAppointment.Count > 0)
                {
                    foreach (DateTime dt in (List<DateTime>)dtToSetRecAppointment)
                    {
                        string MilitaryDateTime = ConvertToMilitaryDatatime(dt);
                        objGroomer.MakeRecConfirmAppointment(AppointmentId, GAppId, dt, txtCustEmail.Text, MilitaryDateTime);
                    }
                }
                #endregion Insert/Update Rec Appointment in Appointment Table to view Member
            }
        }
        catch
        {

        }
    }

    #region Get All Date Between date choosen By Admin and next Six Month
    protected List<DateTime> SetAppointmentAfterWeekRecurrence(int i, DateTime dtPresent)
    {
        DateTime dtFutureSixMonthDay = dtPresent.AddMonths(6);
        List<DateTime> dts = new List<DateTime>();
        for (DateTime dtPresent1 = dtPresent.AddDays(i * 7); dtPresent1.Date <= dtFutureSixMonthDay; dtPresent1 = dtPresent1.AddDays(i * 7))
        {
            dts.Add(dtPresent1);
        }
        return dts;
    }
    #endregion  Get All Date Between date choosen By Admin and next Six Month
    #endregion Rec Appoinment

    #region Selected Appointment Status Change
    protected void btnChangeStatus_Click(object sender, EventArgs e)
    {
        List<string> appointmentIds = new List<string>();
        foreach (string key in Request.Form.Keys)
        {
            if (key.StartsWith("chkDelete"))
            {
                appointmentIds.Add(key.Substring(9));
            }
        }
        if (appointmentIds.Count > 0)
        {
            try
            {
                Groomer g = new Groomer();
                foreach (string apptId in appointmentIds)
                {
                    g.ActiveInActiveGroomerAppointment(int.Parse(apptId));
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangeAppStatusSuccess", "<script>alert('Selected Appointment(s) Status Successfully changed..');</script>", false);
                SuccessMessage("Selected Appointment(s) Status Successfully changed..");

                if (Session["CalenderDateSelected"] == null)
                    BindGroomersAppointment();
                else
                    BindGroomersAppointmentByDate(Convert.ToDateTime(Session["CalenderDateSelected"].ToString()));
            }
            catch
            { }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangeAppStatusError", "<script>alert('Please Select Appointment(s) To Change Status.');</script>", false);
            ErrorMessage("Please Select Appointment(s) To Change Status.");
        }
    }

    #endregion Selected Appointment

    #region Push/UnPush Update DOL Table and Update Export to excel Column
    protected void btnPush_Click(object sender, EventArgs e)
    {
        List<string> appointmentIds = new List<string>();
        foreach (string key in Request.Form.Keys)
        {
            if (key.StartsWith("chkDelete"))
            {
                appointmentIds.Add(key.Substring(9));
            }
        }

        if (appointmentIds.Count > 0)
        {
            try
            {
                Groomer g = new Groomer();
                foreach (string apptId in appointmentIds)
                {
                    g.PushUnPushGroomerAppointment(int.Parse(apptId));
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "<script>alert('Selected Appointment UnPush Successfully..');</script>", false);
                SuccessMessage("Selected appointments UnPush Successfully..");
                if (Session["CalenderDateSelected"] == null)
                    BindGroomersAppointment();
                else
                    BindGroomersAppointmentByDate(Convert.ToDateTime(Session["CalenderDateSelected"].ToString()));
            }
            catch
            { }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ChooseAppopi", "<script>alert('Please Select Appointment To Push/UnPush.');</script>", false);
            ErrorMessage("Please Select Appointment To Reset.");
        }
    }
    #endregion

    #region Calender Visible MOnth changed
    protected void calDate_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        calDate.Visible = true;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowCalender", "ShowCalender()", true);
    }
    #endregion
}
