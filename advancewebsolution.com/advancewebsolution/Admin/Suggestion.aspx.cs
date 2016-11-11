using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
using advancewebtosolution.BO;

public partial class Admin_Suggestion : System.Web.UI.Page
{
    #region Declare
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
    #endregion 

    #region BindData
    /* Function use to bind all data to grid*/
    public void Bind()
    {
        Global ObjSuggest = new Global();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        //ds = ObjSuggest.GetAllSuggestion();
        ds = ObjSuggest.GetAllSuggestion(Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
        ddlSearch.SelectedValue = Request.QueryString["SearchFor"].ToString();
        txtSearch.Text = Request.QueryString["SearchText"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdSuggestion.Visible = true;
            btnDelete.Visible = true;
            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;

            GrdSuggestion.DataSource = dv;
            GrdSuggestion.DataBind();
            CheckAll();
            check();
            Utility.Setserial(GrdSuggestion, "srno");
            divsearch.Visible = true;
            btnExport.Visible = true;
            //lblMsg.Visible = false;
        }
        else
        {
            if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) && (txtSearch.Text != ""))
            {
                txtSearch.Text = "";
                ddlSearch.SelectedIndex = 0;
                lnkNorec.Visible = true;
               // btnAdd.Visible = false;
                btnExport.Visible = false;
                //lblMsg.Visible = true;
                ErrMessage("Sorry, No records found.");
            }
            divsearch.Visible = false;
            GrdSuggestion.Visible = false;
            btnDelete.Visible = false;
            btnExport.Visible = false;

            ErrMessage("Sorry, No records found.");
        }
    }

    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */
    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)GrdSuggestion.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in GrdSuggestion.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in GrdSuggestion.Rows)
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

        foreach (GridViewRow grv in GrdSuggestion.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select Atleast One Suggestion');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Delete Selected Suggestion(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Change Status of Suggestion(s) ?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);
        btnDelete.Attributes.Add("onclick", "return val(1);");
    }

    #endregion 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    #region Event 
    /* Delete event delete suggestion from list*/
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string SuggestionID = Utility.GetCheckedRow(GrdSuggestion, "chkSelect");
        if (SuggestionID != "")
        {
            Global ObjUser = new Global();
            ObjUser.DeleteSuggestion(SuggestionID);
            Bind();
            SuccesfullMessage("Suggestion(s) deleted successfully");
        }
    }
    /* This event is used to Export all suggestion in the form of CSV format*/
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Global ObjSuggest = new Global();
        DataSet ds = new DataSet();
        ds = ObjSuggest.GetAllSuggestionExport(Convert.ToDateTime(txtStartDate.Text.Trim()), Convert.ToDateTime(txtEndDate.Text.Trim()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            Response.ContentType = "Application/vnd.ms-msexcel";
            Response.AddHeader("content-disposition", "attachment;filename=Suggestion.csv");
            Response.Write(ToCSV(dt));
            Response.End();
        }
        else
        {
            ErrMessage("No record found");
        }
    }


    /* Page change index*/
    protected void GrdSuggestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdSuggestion.PageIndex = e.NewPageIndex;
        Bind();
    }

    /* Event for sorting */
    protected void GrdSuggestion_Sorting(object sender, GridViewSortEventArgs e)
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
        GrdSuggestion.PageIndex = 0;
        Bind();
    }

    #endregion 

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
                    sb.Append("VisitorName" + ',');
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
                    myString = row[column].ToString().Replace(',',' ');
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

    #region GridEvent
    //Event use for pagination
    protected void GrdSuggestion_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = GrdSuggestion.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(GrdSuggestion.PageIndex + 1);
        int[] page = new int[7];
        page[0] = GrdSuggestion.PageIndex - 2;
        page[1] = GrdSuggestion.PageIndex - 1;
        page[2] = GrdSuggestion.PageIndex;
        page[3] = GrdSuggestion.PageIndex + 1;
        page[4] = GrdSuggestion.PageIndex + 2;
        page[5] = GrdSuggestion.PageIndex + 3;
        page[6] = GrdSuggestion.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > GrdSuggestion.PageCount)
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
        if (GrdSuggestion.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (GrdSuggestion.PageIndex == GrdSuggestion.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;

        }
        if (GrdSuggestion.PageIndex > GrdSuggestion.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (GrdSuggestion.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    protected void GrdSuggestion_RowCreated(object sender, GridViewRowEventArgs e)
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
        GrdSuggestion.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        Bind();
    }

    #endregion

    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("Suggestion.aspx?SearchFor=0&SearchText=");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Suggestion.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("Suggestion.aspx?SearchFor=0" + "&SearchText=");
    }
}
