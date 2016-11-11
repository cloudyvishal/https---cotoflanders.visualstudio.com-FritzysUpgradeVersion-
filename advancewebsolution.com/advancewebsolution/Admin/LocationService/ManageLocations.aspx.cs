using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using advancewebtosolution.BO;

public partial class Admin_LocationService_ManageLocations : System.Web.UI.Page
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

    #region Binddata
    /* This function is use to show all the location service area*/
    public void Bind()
    {
        Global ObjGlobal = new Global();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        //ds = ObjGlobal.GetServiceLocations();
        ds = ObjGlobal.GetServiceLocations(Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
        ddlSearch.SelectedValue = Request.QueryString["SearchFor"].ToString();
        txtSearch.Text = Request.QueryString["SearchText"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdLocationService.Visible = true;
            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;

            GrdLocationService.DataSource = dv;
            GrdLocationService.DataBind();
            CheckAll();
            check();
            Utility.Setserial(GrdLocationService, "srno");

            btnAvailable.Visible = true;
            btnDelete.Visible = true;
            btnExport.Visible = true;
            btnAdd.Visible = true;
            btnImport.Visible = true;
            divsearch.Visible = true;
        }
        else
        {
            if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) &&  (txtSearch.Text != ""))
            {
                txtSearch.Text = "";
                ddlSearch.SelectedIndex = 0;
                lnkNorec.Visible = true;
                btnAdd.Visible = false;
                btnImport.Visible = false;
                //lblMsg.Visible = true;
                ErrMessage("Sorry, No records found.");
            }
            divsearch.Visible = false;
            GrdLocationService.Visible = false;
            btnAvailable.Visible = false;
            btnDelete.Visible = false;
            btnExport.Visible = false;
            ErrMessage("Sorry, No records found.");
            //btnStatus.Visible = false;
        }
    }

    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */
    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)GrdLocationService.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in GrdLocationService.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in GrdLocationService.Rows)
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

        foreach (GridViewRow grv in GrdLocationService.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select atleast one Zip code');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do you want to delete the following zipcode(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do you want to change the status of the following zipcode(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==3){";
        checkid += "if(!confirm('Do you want to change the avalibility status ?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        //btnactdeact.Attributes.Add("onclick", "return val(0);");
        btnDelete.Attributes.Add("onclick", "return val(1);");
        //btnStatus.Attributes.Add("onclick", "return val(2);");
        btnAvailable.Attributes.Add("onclick", "return val(3);");


    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageLocations.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
    }

    #region ButtonClick
    /* This event is use delete the location service */
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ZipCodeID = Utility.GetCheckedRow(GrdLocationService, "chkSelect");
        if (ZipCodeID != "")
        {
            Global ObjGlobal = new Global();
            ObjGlobal.DeleteServiceLocation(ZipCodeID);
            Bind();
            divError.Visible = true;
            SuccesfullMessage("Location(s) deleted successfully.");
        }
    }
    /* This event is use change status of location service */
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        string ZipCodeID = Utility.GetCheckedRow(GrdLocationService, "chkSelect");
        if (ZipCodeID != "")
        {
            Global ObjGlobal = new Global();
            ObjGlobal.ChangeServiceLocationStatus(ZipCodeID);
            Bind();
            divError.Visible = false;
        }
    }

    protected void btnAvailable_Click(object sender, EventArgs e)
    {
        string ZipCodeID = Utility.GetCheckedRow(GrdLocationService, "chkSelect");
        if (ZipCodeID != "")
        {
            Global ObjGlobal = new Global();
            ObjGlobal.ChangeServiceLocationAvailable(ZipCodeID);
            Bind();
            divError.Visible = false;
        }
    }

    /* Event is use to Export all service Location */
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Global ObjGlobal = new Global();
        DataSet ds = new DataSet();
        ds = ObjGlobal.GetServiceLocationsExport();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            Response.ContentType = "Application/x-msexcel";
            Response.AddHeader("content-disposition", "attachment;filename=LocationService.csv");
            Response.Write(ToCSV(dt));
            Response.End();
        }
    }

    /* Event is use to import a location service file */
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string Zipcode, City, State, ZipType, StrStatus;
        int Status;

        string Error = string.Empty;
        

        Global ObjZip = new Global();
        DataSet ds = new DataSet();
        string strExtension;
        strExtension = Path.GetExtension(flUpload.Value);
        if (strExtension == ".CSV" || strExtension == ".csv")
        {
            string fileName;
            string line;
            string fileDir;
            StreamReader sr;
            fileDir = Server.MapPath("../../StoreData/");
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
                if (recordArray[0].Replace(",", "") == "Zipcode")
                {
                    continue;
                }
                else
                {
                    if (recordArray.Length == 5)
                    {
                        Zipcode = (recordArray[0].Trim().Replace('#', ','));
                        City = recordArray[1].Trim().Replace('#', ',');
                        State = recordArray[2].Trim().Replace('#', ',');
                        StrStatus = recordArray[3].Trim().Replace('#', ',');
                        ZipType = recordArray[4].Trim().Replace('#', ',');
                        if (StrStatus == "Available") Status = 1;
                        else if (StrStatus == "UnAvailable") Status = 0;
                        else Status = 1;


                        int Dup = ObjZip.AddZipCode(Zipcode, City, State, Status, ZipType);
                        if (Dup == 0)
                        {
                            if (Error == "") Error = "Duplicate Zipcode - " +  Zipcode;
                            else Error = Error + ", " + Zipcode;
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
                SuccesfullMessage("Record Added successfully.");
            else ErrMessage( Error);
        }

        else
        {
            ErrMessage("Sorry, File Format Not Supported. You can upload files in .csv format only.");
        }
        Bind();
    }
    #endregion

    #region Grid Event
    /* Event Sorting */
    protected void GrdLocationService_Sorting(object sender, GridViewSortEventArgs e)
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
        GrdLocationService.PageIndex = 0;
        Bind();
    }
    /* Event pagging */
    protected void GrdLocationService_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLocationService.PageIndex = e.NewPageIndex;
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
        if (dataTable.Columns.Count != 0)
        {
            int i = 0;
            //loop thru each of the columns for headers
            foreach (DataColumn column in dataTable.Columns)
            {
                //append the column name followed by the separator
                if (i != 4)
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

                    myString = row[column].ToString();
                    myString = Regex.Replace(myString, "\r\n", " ");
                    if (j != 4)
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
    #endregion

    #region GridEvent
    //Event use for pagination
    protected void GrdLocationService_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = GrdLocationService.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(GrdLocationService.PageIndex + 1);
        int[] page = new int[7];
        page[0] = GrdLocationService.PageIndex - 2;
        page[1] = GrdLocationService.PageIndex - 1;
        page[2] = GrdLocationService.PageIndex;
        page[3] = GrdLocationService.PageIndex + 1;
        page[4] = GrdLocationService.PageIndex + 2;
        page[5] = GrdLocationService.PageIndex + 3;
        page[6] = GrdLocationService.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > GrdLocationService.PageCount)
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
        if (GrdLocationService.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (GrdLocationService.PageIndex == GrdLocationService.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;

        }
        if (GrdLocationService.PageIndex > GrdLocationService.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (GrdLocationService.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    protected void GrdLocationService_RowCreated(object sender, GridViewRowEventArgs e)
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
        GrdLocationService.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        Bind();
    }

    #endregion

    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageLocations.aspx?SearchFor=0&SearchText=");
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageLocations.aspx?SearchFor=0&SearchText=");
    }
}
