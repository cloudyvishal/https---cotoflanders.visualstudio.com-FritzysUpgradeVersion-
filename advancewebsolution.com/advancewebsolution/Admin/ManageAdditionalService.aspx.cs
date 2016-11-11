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
using System.IO;
using advancewebtosolution.BO;

/*
 This page use to add additional services edit additional services .
 in this page we are using eventbubbling to edit the grid row.
 also facility to delete the additional service 
 
 */
public partial class Admin_Additional_Service_ManageAdditionalService : System.Web.UI.Page
{
    #region Declare
    int AdditionalServiceID;

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

    public void SuccesfullMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
   
    private void MessageBox(string strMsg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert(" + "'" + strMsg + "'" + ")</script>";
        Page.Controls.Add(lbl);
    }

    public void ErrMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    
    
    
    #endregion

    #region Bind 
    /*
        GetAdditionalServices function use to get all additional services 
     */
    private void BindGrid()
    {
        StoreFront ObjStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        ds = ObjStoreFront.GetAdditionalServices(Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
        ddlSearch.SelectedValue = Request.QueryString["SearchFor"].ToString();
        txtSearch.Text = Request.QueryString["SearchText"].ToString(); 
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvAdditionalServices.Visible = true;
            btnDelete.Visible = true;
            btnStatus.Visible = true;
            //lblNorec.Visible = false;

            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;

            gdvAdditionalServices.DataSource = dv;
            gdvAdditionalServices.DataBind();
            CheckAll();
            check();
            Utility.Setserial(gdvAdditionalServices, "srno");
            divsearch.Visible = true;
            btnExport.Visible = true;
            btnImport.Visible = true;
        }
        else
        {
            //lblNorec.Visible = true;
            btnDelete.Visible = false;
            btnNew.Visible = true;
            btnStatus.Visible = false;
            gdvAdditionalServices.Visible = false;
            divsearch.Visible = false;
            ErrMessage("Sorry, No records found.");
             if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) && (txtSearch.Text != ""))
            {
                txtSearch.Text = "";
                ddlSearch.SelectedIndex = 0;
                lnkNorec.Visible = true;
                btnNew.Visible = false;
                // btnAdd.Visible = false;
                 btnExport.Visible = false;
                 btnImport.Visible = false;
                //lblMsg.Visible = true;
                 ErrMessage("Sorry, No records found.");
            }

        }
    }

    protected void check()
    {
        string checkid = "";
        checkid += "function val(id){";
        checkid += "var flg=0;";

        foreach (GridViewRow grv in gdvAdditionalServices.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select atleast one service');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do you want to delete selected service(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do you want to change the status of selected service(s) ? ')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        //btnactdeact.Attributes.Add("onclick", "return val(0);");
        btnDelete.Attributes.Add("onclick", "return val(1);");
        btnStatus.Attributes.Add("onclick", "return val(2);");

    }

    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)gdvAdditionalServices.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in gdvAdditionalServices.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in gdvAdditionalServices.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            str = str + "document.getElementById('" + chk1.ClientID + "').checked=false;";
        }
        str = str + "}}";
        Page.ClientScript.RegisterStartupScript(GetType(), "sss", str, true);
    }
    #endregion 
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    #region "Grid Event"
    /* Gride event to edit the row 
     check to this event is that duplicate Service Name . otherwise update service 
     */
    protected void gdvAdditionalServices_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gdvAdditionalServices.Rows[e.RowIndex];
        if (row != null)
        {
            AdditionalServiceID = Convert.ToInt32(gdvAdditionalServices.DataKeys[e.RowIndex].Value);
            Label lblServiceName = (Label)gdvAdditionalServices.Rows[e.RowIndex].FindControl("lblServiceName");
            TextBox txtServiceName = (TextBox)gdvAdditionalServices.Rows[e.RowIndex].FindControl("txtServiceName");
                       
            if (txtServiceName.Text=="")
            {
                MessageBox("Please enter Service name.");
            }
            else
            {
                StoreFront ObjStoreFront = new StoreFront();
                int Count = ObjStoreFront.UpdateAdditionalServices(AdditionalServiceID, txtServiceName.Text.Trim());
               
                if (Count == 1)
                {
                    SuccesfullMessage("Service updated successfully.");
                    gdvAdditionalServices.EditIndex = -1;
                    BindGrid();
                }
                else
                {
                    SuccesfullMessage("Duplicate additional service.");
                    gdvAdditionalServices.EditIndex = -1;
                    BindGrid();
                }
            }
        }
    }

    /*Grideview row editing event */
    protected void gdvAdditionalServices_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdvAdditionalServices.EditIndex = e.NewEditIndex;
        BindGrid();

    }

    protected void gdvAdditionalServices_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvAdditionalServices.EditIndex = -1;
        BindGrid();
    }
    
    protected void gdvAdditionalServices_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvAdditionalServices.SelectedIndex = -1;
        gdvAdditionalServices.PageIndex = e.NewPageIndex;
        BindGrid();

    }

    /* Gride Sorting event*/
    protected void gdvAdditionalServices_Sorting(object sender, GridViewSortEventArgs e)
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
        gdvAdditionalServices.PageIndex = 0;
        BindGrid();
    }

    #endregion

    #region Event 
    protected void btnNew_Click(object sender, EventArgs e)
    {
        divAddService.Visible = true;
    }

    /* To change status of additional sservice */
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        string StrAdditionalServiceID = Utility.GetCheckedRow(gdvAdditionalServices, "chkSelect");
        if (StrAdditionalServiceID != "")
        {
            StoreFront ObjStoreFront = new StoreFront();
            ObjStoreFront.UpdateAdditionalServiceStatus(StrAdditionalServiceID);
            BindGrid();
        }
    }
    /* Delete additional service */
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string StrAdditionalServiceID = Utility.GetCheckedRow(gdvAdditionalServices, "chkSelect");
        if (StrAdditionalServiceID != "")
        {
            StoreFront ObjStoreFront = new StoreFront();
            int Count = ObjStoreFront.DeleteAdditionalServices(StrAdditionalServiceID);
            if (Count == 0)
            {
                ErrMessage("Service(s) in use. It cannot be deleted unless all references to it are deleted");
            }
            else
            {
                SuccesfullMessage("Service(s) deleted successfully.");
            }
        }
       
        BindGrid();
        
    }

    /* Add additional service use to add service */
    protected void ImgSubmitService_Click(object sender, EventArgs e)
    {
        StoreFront ObjStoreFront = new StoreFront();
        int count = ObjStoreFront.AddAdditionalService(txtServiceName.Text.Trim());
        if (count == 1)
        {
            SuccesfullMessage("Service added successfully.");
            txtServiceName.Text = "";
            BindGrid();
        }
        else
        {
            ErrMessage("Duplicate service name.");
            txtServiceName.Text = "";
        }
    }

    /* This event is used to Export all suggestion in the form of CSV format*/
    protected void btnExport_Click(object sender, EventArgs e)
    {
        StoreFront ObjStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        ds = ObjStoreFront.GetAdditionalServicesExport();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            Response.ContentType = "Application/x-msexcel";
            Response.AddHeader("content-disposition", "attachment;filename=AdditionalServices.csv");
            Response.Write(ToCSV(dt));
            Response.End();
        }
    }

    /* This event is used to Import all suggestion in the form of CSV format*/
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string Service, StrStatus;
        int Status;

        string Error = string.Empty;


        StoreFront ObjStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        string strExtension;
        strExtension = Path.GetExtension(flUpload.Value);
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
                if (recordArray[0].Replace(",", "") == "ServiceName")
                {
                    continue;
                }
                else
                {
                    if (recordArray.Length == 2)
                    {
                        Service = (recordArray[0].Trim().Replace('#', ','));
                        StrStatus = (recordArray[1].Trim().Replace('#', ','));
                        if (StrStatus == "Active") Status = 1;
                        else if (StrStatus == "InActive") Status = 0;
                        else Status = 1;

                        int Dup = ObjStoreFront.AddAdditionalServiceExcel(Service, Status);
                        if (Dup == 0)
                        {
                            if (Error == "") Error = "Duplicate Additional service - " + Service;
                            else Error = Error + ", " + Service;
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
        BindGrid();
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
                if (i != 1)
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
                    if (j != 1)
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
    protected void gdvAdditionalServices_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = gdvAdditionalServices.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(gdvAdditionalServices.PageIndex + 1);
        int[] page = new int[7];
        page[0] = gdvAdditionalServices.PageIndex - 2;
        page[1] = gdvAdditionalServices.PageIndex - 1;
        page[2] = gdvAdditionalServices.PageIndex;
        page[3] = gdvAdditionalServices.PageIndex + 1;
        page[4] = gdvAdditionalServices.PageIndex + 2;
        page[5] = gdvAdditionalServices.PageIndex + 3;
        page[6] = gdvAdditionalServices.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > gdvAdditionalServices.PageCount)
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
        if (gdvAdditionalServices.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (gdvAdditionalServices.PageIndex == gdvAdditionalServices.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;

        }
        if (gdvAdditionalServices.PageIndex > gdvAdditionalServices.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (gdvAdditionalServices.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    protected void gdvAdditionalServices_RowCreated(object sender, GridViewRowEventArgs e)
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
        gdvAdditionalServices.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        BindGrid();
    }

    #endregion

    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageAdditionalService.aspx?SearchFor=0&SearchText=");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageAdditionalService.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageAdditionalService.aspx?SearchFor=0" + "&SearchText=");
    }
}
