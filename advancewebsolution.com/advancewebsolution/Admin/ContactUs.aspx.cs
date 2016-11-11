using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Text;
using advancewebtosolution.BO;

public partial class Admin_ContactUs : System.Web.UI.Page
{
    /* Error message and success messages are use to display messages to user*/
    public void SuccesfullMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }

    public void ErrMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "errorTable");
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

    /* Uae to bind data from database admin dont have facility to edit this message */
    private void BindGrid()
    {
        StoreFront ObjStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();

        //ds = ObjStoreFront.GetAllContactus();
         ds = ObjStoreFront.GetAllContactus(Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
        ddlSearch.SelectedValue = Request.QueryString["SearchFor"].ToString();
        txtSearch.Text = Request.QueryString["SearchText"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnDelete.Visible = true;
            gdvContactUs.Visible = true;

            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;
            gdvContactUs.DataSource = dv;
            gdvContactUs.DataBind();
            CheckAll();
            check();
            Utility.Setserial(gdvContactUs, "srno");
            divsearch.Visible = true;
        }
        else
        {
            if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) && (txtSearch.Text != ""))
            {
                txtSearch.Text = "";
                ddlSearch.SelectedIndex = 0;
                lnkNorec.Visible = true;
                ErrMessage("Sorry no records found.");
            }
            divsearch.Visible = false;
            btnDelete.Visible = false;
           gdvContactUs.Visible = false;
           ErrMessage("Sorry no records found.");
        }
    }

    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */
    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)gdvContactUs.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in gdvContactUs.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in gdvContactUs.Rows)
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

        foreach (GridViewRow grv in gdvContactUs.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select Atleast One Message');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Delete Selected Message(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Change Status of Message(s) ?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        btnDelete.Attributes.Add("onclick", "return val(1);");

    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    /* Event is use to delete record from database */
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ContactID = Utility.GetCheckedRow(gdvContactUs, "chkSelect");
        if (ContactID != "")
        {
            StoreFront ObjStoreFront = new StoreFront();
            ObjStoreFront.DeleteContactUs(ContactID);
        }
        BindGrid();
        SuccesfullMessage("Deleted successfully");
    }
    /*Page change event*/
    protected void gdvContactUs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvContactUs.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void gdvContactUs_Sorting(object sender, GridViewSortEventArgs e)
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
        gdvContactUs.PageIndex = 0;
        BindGrid();
    }

    #region GridEvent
    //Event use for pagination
    protected void gdvContactUs_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = gdvContactUs.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(gdvContactUs.PageIndex + 1);
        int[] page = new int[7];
        page[0] = gdvContactUs.PageIndex - 2;
        page[1] = gdvContactUs.PageIndex - 1;
        page[2] = gdvContactUs.PageIndex;
        page[3] = gdvContactUs.PageIndex + 1;
        page[4] = gdvContactUs.PageIndex + 2;
        page[5] = gdvContactUs.PageIndex + 3;
        page[6] = gdvContactUs.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > gdvContactUs.PageCount)
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
        if (gdvContactUs.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (gdvContactUs.PageIndex == gdvContactUs.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;

        }
        if (gdvContactUs.PageIndex > gdvContactUs.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (gdvContactUs.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    protected void gdvContactUs_RowCreated(object sender, GridViewRowEventArgs e)
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
        gdvContactUs.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        BindGrid();
    }

    #endregion

    #region Search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactUs.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
    }
    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactUs.aspx?SearchFor=0&SearchText=");
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactUs.aspx?SearchFor=0&SearchText=");
    }
    #endregion 

    #region Export
    protected void btnExport_Click(object sender, EventArgs e)
    {
        StoreFront ObjStoreFront = new StoreFront();
        
        DataSet ds = new DataSet();
        ds = ObjStoreFront.GetAllContactUsExport(Convert.ToDateTime(txtStartDate.Text.Trim()), Convert.ToDateTime(txtEndDate.Text.Trim()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            Response.ContentType = "Application/vnd.ms-msexcel";
            Response.AddHeader("content-disposition", "attachment;filename=ContactUs.csv");
            Response.Write(ToCSV(dt));
            Response.End();
        }
        else
        {
            ErrMessage("No record found");
        }
    }

    #region Function for Excel Export
    private string ToCSV(DataTable dataTable)
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
    #endregion

    #endregion 

}
