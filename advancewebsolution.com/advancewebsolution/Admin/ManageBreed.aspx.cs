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

public partial class Admin_Breed_ManageBreed : System.Web.UI.Page
{
    #region Declare
    int BreedID;
    string PetTypeID="2";
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
    /* Region is use to bind all pet information from database fro this we need pet type cat or dog */
    private void BindGrid(string PetType)
    {
        StoreFront ObjStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        ds = ObjStoreFront.GetBreed(PetType, Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
        ddlSearch.SelectedValue = Request.QueryString["SearchFor"].ToString();
        txtSearch.Text = Request.QueryString["SearchText"].ToString(); 
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
            divSelectPet.Visible = true;
            btnExport.Visible = true;
            btnImport.Visible = true;
            divsearch.Visible = true;
        }
        else
        {
            divsearch.Visible = false;
            divSelectPet.Visible = false;
            //lblNorec.Visible = true;
            btnDelete.Visible = false;
            btnNew.Visible = true;
            btnStatus.Visible = false;
            gdvBreed.Visible = false;
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
                divSelectPet.Visible = false;
                //lblMsg.Visible = true;
                ErrMessage("Sorry, No records found.");
            }
        }
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
        checkid += "alert('Select atleast one Breed');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do you want to delete selected Breed(s)?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do you want to change status of Breed(s)?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        //btnactdeact.Attributes.Add("onclick", "return val(0);");
        btnDelete.Attributes.Add("onclick", "return val(1);");
        btnStatus.Attributes.Add("onclick", "return val(2);");

    }
    #endregion 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid(PetTypeID);
        }
    }

    #region "Grid Event"

    protected void gdvBreed_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            Label lblPetTypeID = (Label)e.Row.FindControl("lblPetTypeID");
            Label lblPetName = (Label)e.Row.FindControl("lblPetName");
            switch (lblPetTypeID.Text)
            {
                case "1":
                    lblPetName.Text = "Dog";
                    break;
                case "0":
                    lblPetName.Text = "Cat";
                    break;
            }
        }
    }

    protected void gdvBreed_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gdvBreed.Rows[e.RowIndex];
        if (row != null)
        {
            BreedID = Convert.ToInt32(gdvBreed.DataKeys[e.RowIndex].Value);
            Label lblBreedName = (Label)gdvBreed.Rows[e.RowIndex].FindControl("lblBreedName");
            
            TextBox txtBreedName = (TextBox)gdvBreed.Rows[e.RowIndex].FindControl("txtBreedName");

            if (txtBreedName.Text == "")
            {
                MessageBox("Please enter Breed Name.");
            }

            else
            {
                StoreFront ObjStoreFront = new StoreFront();
                int Count = ObjStoreFront.UpdateBreed(BreedID, txtBreedName.Text.Trim());

                if (Count == 1)
                {
                    SuccesfullMessage("Breed updated successfully.");
                    gdvBreed.EditIndex = -1;
                    BindGrid(ddlPetList.SelectedValue);

                }
                else
                {

                    ErrMessage("Duplicate breed name.");
                    gdvBreed.EditIndex = -1;
                    BindGrid(ddlPetList.SelectedValue);
                }


            }
           
        }
    }
    
    protected void gdvBreed_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdvBreed.EditIndex = e.NewEditIndex;
        BindGrid(ddlPetList.SelectedValue);

    }
    
    protected void gdvBreed_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvBreed.EditIndex = -1;
        BindGrid(ddlPetList.SelectedValue);
    }
    
    protected void gdvBreed_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvBreed.SelectedIndex = -1;
        gdvBreed.PageIndex = e.NewPageIndex;
        BindGrid(ddlPetList.SelectedValue);

    }

    /* Grid Sorting event*/
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
        BindGrid(PetTypeID);
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

    #region Event 
    protected void btnNew_Click(object sender, EventArgs e)
    {
        divAddBreed.Visible = true;
        //Response.Redirect("AddService.aspx");
    }
    /* This event is use to change the status of Breed use GetCheckedRow() function to get all checked rows */
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        string StrBreedID = Utility.GetCheckedRow(gdvBreed, "chkSelect");
        if (StrBreedID != "")
        {
            StoreFront ObjStoreFront = new StoreFront();
            ObjStoreFront.UpdateBreedStatus(StrBreedID);
            BindGrid(ddlPetList.SelectedValue);
        }
    }

    /* function delete use GetCheckedRow() from utility to get checked row id for gride  */
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string StrBreedID = Utility.GetCheckedRow(gdvBreed, "chkSelect");
        if (StrBreedID != "")
        {
            StoreFront ObjStoreFront = new StoreFront();
            int Count = ObjStoreFront.DeleteBreed(StrBreedID);
            if (Count == 0)
            {
                ErrMessage("Breed(s) in use. It cannot be deleted unless all references to it are deleted");
            }
            else
            {
                SuccesfullMessage("Breed(s) deleted successfully.");
            }
        }
        BindGrid(ddlPetList.SelectedValue);
    }
    /* on submit it will add all breed information to databse with validating duplicate entry*/
    protected void ImgSubmitService_Click(object sender, EventArgs e)
    {
        StoreFront ObjStoreFront = new StoreFront();
        int count = ObjStoreFront.AddBreed(txtBreedName.Text.Trim(),Convert.ToInt32(ddlPetType.SelectedValue));
        if (count == 1)
        {
            SuccesfullMessage("Breed Name added successfully.");
            txtBreedName.Text = "";
            BindGrid(ddlPetList.SelectedValue);
        }
        else
        {
            ErrMessage("Duplicate Breed name.");
            txtBreedName.Text = "";
        }
    }

    /* ddlPetList index changing event to manage pagging */
    protected void ddlPetList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid(ddlPetList.SelectedValue);
    }

    /* This event is used to Import all suggestion in the form of CSV format*/
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string BreedName, StrPet, StrStatus;
        int PetType;
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
                if (recordArray[0].Replace(",", "") == "BreedName")
                {
                    continue;
                }
                else
                {
                    if (recordArray.Length == 3)
                    {
                        BreedName = (recordArray[0].Trim().Replace('#', ','));
                      

                        StrStatus = recordArray[1].Trim().Replace('#', ',');
                        if (StrStatus == "Active") Status = 1;
                        else if (StrStatus == "Inactive") Status = 0;
                        else Status = 1;

                        StrPet = (recordArray[2].Trim().Replace('#', ',').ToLower());
                        if (StrPet == "cat")
                            PetType = 0;
                        else
                            PetType = 1;
                        int Dup = ObjStoreFront.AddBreedExcel(BreedName, PetType, Status);

                        if (Dup == 0)
                        {
                            if (Error == "") Error = "Duplicate Breed name - " +  BreedName;
                            else Error = Error + ", " + BreedName;
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
            else ErrMessage(Error);
        }

        else
        {
            ErrMessage("Sorry, File Format Not Supported. You can upload files in .csv format only.");
        } 
        BindGrid(PetTypeID);
    }

    /* This event is used to Export all suggestion in the form of CSV format*/
    protected void btnExport_Click(object sender, EventArgs e)
    {
        StoreFront ObjStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        ds = ObjStoreFront.GetBreedExport();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            Response.ContentType = "Application/x-msexcel";
            Response.AddHeader("content-disposition", "attachment;filename=Breed.csv");
            Response.Write(ToCSV(dt));
            Response.End();
        }
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
                if (i != 2)
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

                    myString = row[column].ToString().Replace(',', ' ' );
                    myString = Regex.Replace(myString, "\r\n", " ");
                    if (j != 2)
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
        BindGrid(PetTypeID);
    }

    #endregion

    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageBreed.aspx?SearchFor=0&SearchText=");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageBreed.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageBreed.aspx?SearchFor=0" + "&SearchText=");
    }
}
