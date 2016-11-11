using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
using advancewebtosolution.BO;
using advancewebtosolution.BO.CaptchaClass;

public partial class Admin_Appointment : System.Web.UI.Page
{
    #region declr
    /* Error message and success messages are use to display messages to user*/
    public void ErrMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    public void SuccesfullMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }

    /* Code to manage view state for sortExpression */
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
    /* Code to manage view state for sortdirection*/
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

    /* Bind Data is use to bind all information to this page that is user Appointment */

    public void BindData()
    {
        UserAppointment App = new UserAppointment();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        ds = App.GetAllAppointment();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;
            grdAppointment.DataSource = dv;
            grdAppointment.DataBind();
            btnDelete.Visible = true;
            lblError.Visible = false;
            CheckAll();
            check();
            Utility.Setserial(grdAppointment, "srno");
        }
        else
        {
            btnDelete.Visible = false;
            grdAppointment.Visible = false;
            ErrMessage("No record found");
        }
    }

    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)grdAppointment.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in grdAppointment.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in grdAppointment.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            str = str + "document.getElementById('" + chk1.ClientID + "').checked=false;";
        }
        str = str + "}}";
        Page.ClientScript.RegisterStartupScript(GetType(), "sss", str, true);
    }

    protected void check()
    {
        string checkid = "";
        checkid += "function val(id){";
        checkid += "var flg=0;";

        foreach (GridViewRow grv in grdAppointment.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select Atleast One Appointment');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Delete Selected Appointment(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Change Status of Appointment(s) ?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);
        //btnactdeact.Attributes.Add("onclick", "return val(0);");
        btnDelete.Attributes.Add("onclick", "return val(1);");
        //btnStatus.Attributes.Add("onclick", "return val(2);");
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    #region button
    protected void btnDelete_Click1(object sender, EventArgs e)
    {
        try
        {
            string AppointmentID = Utility.GetCheckedRow(grdAppointment, "chkSelect");
            if (AppointmentID != "")
            {
                string[] arrIds = AppointmentID.Split(',');
                if (arrIds.Length > 0)
                {
                    foreach (string apptId in arrIds)
                    {
                        UserAppointment App = new UserAppointment();
                        App.DeleteAppointment(int.Parse(apptId));
                    }
                }

                BindData();
                SuccesfullMessage("Appointment(s) deleted successfully");
            }
        }
        catch  { }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            UserAppointment App = new UserAppointment();
            DataSet ds = new DataSet();
            ds = App.GetAllAppointmentExport(Convert.ToDateTime(txtStartDate.Text.Trim()), Convert.ToDateTime(txtEndDate.Text.Trim()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                Response.ContentType = "Application/vnd.ms-msexcel";
                Response.AddHeader("content-disposition", "attachment;filename=Appointment.csv");
                Response.Write(ToCSV(dt));
                Response.End();
            }
            else
            {
                ErrMessage("No record found");
            }
        }
        catch  { }
    }
    #endregion

    #region Selected Appointment Active/Inactive
    protected void btnActiveInActive_Click1(object sender, EventArgs e)
    {
        try
        {
            string AppointmentID = Utility.GetCheckedRow(grdAppointment, "chkSelect");
            if (AppointmentID != "")
            {
                string[] arrIds = AppointmentID.Split(',');
                if (arrIds.Length > 0)
                {
                    foreach (string apptId in arrIds)
                    {
                        UserAppointment App = new UserAppointment();
                        App.ActiveInActiveAppointmentFromAdmin(int.Parse(apptId));
                    }
                }
                BindData();
                SuccesfullMessage("Appointment(s) Active/InActive successfully");
            }
        }
        catch  { }
    }

    #endregion Selected Appointment



    #region GridEvent
    //Event use for pagination
    protected void grdAppointment_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = grdAppointment.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(grdAppointment.PageIndex + 1);
        int[] page = new int[7];
        page[0] = grdAppointment.PageIndex - 2;
        page[1] = grdAppointment.PageIndex - 1;
        page[2] = grdAppointment.PageIndex;
        page[3] = grdAppointment.PageIndex + 1;
        page[4] = grdAppointment.PageIndex + 2;
        page[5] = grdAppointment.PageIndex + 3;
        page[6] = grdAppointment.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > grdAppointment.PageCount)
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
        if (grdAppointment.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;
        }
        if (grdAppointment.PageIndex == grdAppointment.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;
        }
        if (grdAppointment.PageIndex > grdAppointment.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (grdAppointment.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    protected void grdAppointment_RowCreated(object sender, GridViewRowEventArgs e)
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
        grdAppointment.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        BindData();
    }

    protected void grdAppointment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAppointment.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void grdAppointment_Sorting(object sender, GridViewSortEventArgs e)
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
        grdAppointment.PageIndex = 0;
        BindData();
    }
    #endregion

    #region Function for Excel Export
    private string ToCSV(DataTable dataTable)
    {
        try
        {
            string myString;
            //create the stringbuilder that would hold the data
            StringBuilder sb = new StringBuilder();
            //check if there are columns in the datatable
            int i = 0;
            if (dataTable.Columns.Count != 0)
            {
                //loop thru each of the columns for headers
                foreach (DataColumn column in dataTable.Columns)
                {
                    //append the column name followed by the separator
                    if (i == 0)
                    {
                        sb.Append("FirstName" + ',');
                        i++;
                    }
                    else
                        sb.Append(column.ColumnName + ',');
                }
                //append a carriage return
                sb.Append("\r\n");
                //loop thru each row of the datatable
                foreach (DataRow row in dataTable.Rows)
                {
                    //loop thru each column in the datatable
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        //get the value for the row on the specified column
                        // and append the separator
                        myString = row[column].ToString().Replace(',', ' ');
                        myString = Regex.Replace(myString, "\r\n", " ");

                        sb.Append(myString + ',');
                    }
                    //append a carriage return
                    sb.Append("\r\n");
                }
            }
            return sb.ToString();
        }
        catch (Exception ex) { throw ex; }
        
    }
    #endregion

    public string EncryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
    }

}
