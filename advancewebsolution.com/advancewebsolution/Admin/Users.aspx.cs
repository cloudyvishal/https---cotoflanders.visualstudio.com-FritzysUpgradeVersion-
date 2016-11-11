using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using advancewebtosolution.BO;

public partial class Admin_Users : System.Web.UI.Page
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

    #region BindData
    /* Bind User function is use to bind all users to grid */
    public void BindUsers()
    {
        Global ObjUser = new Global();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        ds = ObjUser.GetAllUserFront(Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdUsers.Visible = true;
            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;

            GrdUsers.DataSource = dv;
            GrdUsers.DataBind();
            CheckAll();
            check();
            Utility.Setserial(GrdUsers, "srno");
            btnDelete.Visible = true;
            divsearch.Visible = true;
            btnImport.Visible = true;
            btnExport.Visible = true;
            if (Convert.ToInt32(Session["AdminUserType"].ToString()) != 1)
            {
                btnDelete.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
            }

        }
        else
        {
            if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) && (txtSearch.Text != ""))
            {
                txtSearch.Text = "";
                ddlSearch.SelectedIndex = 0;
                lnkNorec.Visible = true;
                //btnAdd.Visible = false;
                btnImport.Visible = false;
                btnExport.Visible = false;
                ErrorMessage("Sorry, No records found.");
            }
            divsearch.Visible = false;
            GrdUsers.Visible = false;
            btnDelete.Visible = false;
            lnkNorec.Visible = true;
            //btnAdd.Visible = false;
            btnImport.Visible = false;
            btnExport.Visible = false;
            btnExpo.Visible = false;
            ErrorMessage("Sorry, No records found.");

        }
    }

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
        checkid += "alert('Select Atleast One User(s)');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Delete Selected User(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Change Status of User(s) ?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        btnDelete.Attributes.Add("onclick", "return val(1);");

    }

    #endregion 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUsers();
        }
    }

    #region Event 

    /* Page index change event*/
    protected void GrdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdUsers.PageIndex = e.NewPageIndex;
        BindUsers();
    }

    //Button delete event 
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string UserID = Utility.GetCheckedRow(GrdUsers, "chkSelect");
        if (UserID != "")
        {
            Global ObjUser = new Global();
            ObjUser.DeleteUsers(UserID);
            BindUsers();
            lblError.Text = "User(s) deleted Successfully.";
        }
    }

    protected void btnDelete_Click1(object sender, EventArgs e)
    {
        string UserID = Utility.GetCheckedRow(GrdUsers, "chkSelect");
        if (UserID != "")
        {
            Global ObjUser = new Global();
            ObjUser.DeleteUsers(UserID);
            BindUsers();
            SuccessMessage("User(s) deleted Successfully.");
            lnkNorec.Visible = false;
        }
        else ErrorMessage("Please Select User (s) to delete.");
    }

    /* Function is use t Export data from database to excel with */
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Global ObjUser = new Global();
        DataSet ds = new DataSet();
        ds = ObjUser.GetAllUserFrontExport(Convert.ToDateTime(txtStartDate.Text.Trim()), Convert.ToDateTime(txtEndDate.Text.Trim()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            Response.ContentType = "Application/vnd.ms-msexcel";
            Response.AddHeader("content-disposition", "attachment;filename=Member.csv");
            Response.Write(ToCSV(dt));
            Response.End();

        }
        else
        {
            btnExport.Visible = false;
            ErrorMessage("Sorry,No records found");
        }
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
        BindUsers();
    }

    /* Function is use t Import data ti database from excel with */
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string FirstName, LastName, Street, City, State, Zip, Phone, UserName, Password, AltMobile, AltContact, AltStreet, AltCity, AltState, AltZip, AltPhone, PreferredGroomer;
        int UserType;

        string Error = string.Empty;


        StoreFrontUser ObjNewUser = new StoreFrontUser();
        DataSet ds = new DataSet();
        string strExtension;
        strExtension = Path.GetExtension(flUpload.Value);
        if (strExtension == "")
        { ErrorMessage("Please select file to upload"); }
        if (strExtension == ".CSV" || strExtension == ".csv")
        {
            string fileName;
            string line;
            string fileDir;
            StreamReader sr;
            fileDir = Server.MapPath("../StoreData/");
            fileName = fileDir + "/" + Convert.ToString(DateTime.Now.Ticks) + ".txt";
            flUpload.PostedFile.SaveAs(fileName);
            sr = File.OpenText(fileName);
            int recordCount = 0;
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                string[] recordArray;
                char[] splitter = { ',' };
                recordArray = line.Split(splitter);
                if (recordArray[0].Replace(",", "") == "FirstName")
                {
                    continue;
                }
                else
                {
                    if (recordArray.Length == 18)
                    {
                        FirstName = (recordArray[0].Trim().Replace('#', ','));
                        LastName = (recordArray[1].Trim().Replace('#', ','));
                        Street = (recordArray[2].Trim().Replace('#', ','));
                        City = (recordArray[3].Trim().Replace('#', ','));
                        State = (recordArray[4].Trim().Replace('#', ','));
                        Zip = (recordArray[5].Trim().Replace('#', ','));
                        Phone = (recordArray[6].Trim().Replace('#', ','));
                        UserName = (recordArray[7].Trim().Replace('#', ','));
                        Password = (recordArray[8].Trim().Replace('#', ','));
                        AltMobile = (recordArray[9].Trim().Replace('#', ','));
                        AltContact = (recordArray[10].Trim().Replace('#', ','));
                        AltStreet = (recordArray[11].Trim().Replace('#', ','));
                        AltCity = (recordArray[12].Trim().Replace('#', ','));
                        AltState = (recordArray[13].Trim().Replace('#', ','));
                        AltZip = (recordArray[14].Trim().Replace('#', ','));
                        AltPhone = (recordArray[15].Trim().Replace('#', ','));
                        PreferredGroomer = (recordArray[16].Trim().Replace('#', ','));
                        if (recordArray[17].Trim().ToLower() == "cat")
                            UserType = 1;
                        else if (recordArray[17].Trim().ToLower() == "dog")
                            UserType = 2;
                        else
                            UserType = 3;




                        int Dup = ObjNewUser.AddUserExcel(FirstName, LastName, Street, City, State, Zip, Phone, UserName, Password, AltMobile, AltContact, AltStreet, AltCity, AltState, AltZip, AltPhone, PreferredGroomer, UserType);
                        if (Dup == 0)
                        {
                            if (Error == "") Error = "Duplicate record - " + UserName;
                            else Error = Error + ", " + UserName;
                        }
                        recordCount++;
                    }

                    else
                    {
                        Error = "coloumn count does not match";
                    }
                }
            }
            if (Error == "")
                SuccessMessage("Record Added successfully");
            else ErrorMessage(Error);
        }

        else
        {
            ErrorMessage("File format does not support. only .csv format allowed.");
        }
        BindUsers();
    }
    #endregion 

    #region Function for Excel Export
    private string ToCSV(DataTable dataTable)
    {

        string myString;
        //create the stringbuilder that would hold the data
        StringBuilder sb = new StringBuilder();
        //check if there are columns in the datatable
        if (dataTable.Columns.Count != 0)
        {
            int i = 0;
            //loop thru each of the columns for headers
            foreach (DataColumn column in dataTable.Columns)
            {
                //append the column name followed by the separator
                if (i != 26)
                {
                    sb.Append(column.ColumnName + ',');
                    i++;
                }
                else
                {
                    sb.Append(column.ColumnName);
                }
            }
            //append a carriage return
            sb.Append("\r\n");
            int j = 0;
            //loop thru each row of the datatable
            foreach (DataRow row in dataTable.Rows)
            {
                j = 0;
                //loop thru each column in the datatable
                foreach (DataColumn column in dataTable.Columns)
                {
                    //get the value for the row on the specified column
                    // and append the separator


                    myString = row[column].ToString().Replace(',', ' ');
                    myString = Regex.Replace(myString, "\r\n", " ");

                    if (j != 26)
                    {
                        sb.Append(myString + ',');
                        j++;
                    }
                    else
                    {
                        sb.Append(myString);
                    }
                }
                //append a carriage return
                sb.Append("\r\n");
            }
        }
        return sb.ToString();
    }

    private string ToCSV1(DataTable dataTable)
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlSearch.SelectedValue != "")
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                Response.Redirect("Users.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
            }
            else
            {
                ErrorMessage("Please Type Some Hints to Start Search Member ");
            }
        }
        else
        {
            ErrorMessage("PLease Select Any Option to Search Member");
        }
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("Users.aspx?SearchFor=0&SearchText=");
    }
    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("Users.aspx?SearchFor=0&SearchText=");
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
        BindUsers();
    }

    #endregion

    protected void btnActiveInActive_Click(object sender, EventArgs e)
    {
        string UserID = Utility.GetCheckedRow(GrdUsers, "chkSelect");
        if (UserID != "")
        {
            Global ObjUser = new Global();
            ObjUser.ActiveInActiveUsers(UserID);
            BindUsers();
            SuccessMessage("User(s) Status Changed Successfully.");
            lnkNorec.Visible = false;
        }
        else ErrorMessage("Please Select User (s) to change status.");
    }
}
