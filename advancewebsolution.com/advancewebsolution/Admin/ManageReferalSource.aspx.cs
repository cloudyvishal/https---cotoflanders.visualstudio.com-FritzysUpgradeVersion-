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
using advancewebtosolution.BO;
/*
page is use to Add, Edit, Update data from database from Referal source 
*/
public partial class Admin_ReferalSource_ManageReferalSource : System.Web.UI.Page
{
    #region Declare
    int ReferalID;

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
    /* This function is use to bind all data of GetReferalSource() from database */
    private void BindGrid()
    {
        StoreFront ObjStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        ds = ObjStoreFront.GetReferalSource(Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
        ddlSearch.SelectedValue = Request.QueryString["SearchFor"].ToString();
        txtSearch.Text = Request.QueryString["SearchText"].ToString(); 
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvReferalSource.Visible = true;
            btnDelete.Visible = true;
            btnStatus.Visible = true;
            //lblNorec.Visible = false;
            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;

            gdvReferalSource.DataSource = dv;
            gdvReferalSource.DataBind();
            CheckAll();
            check();
            Utility.Setserial(gdvReferalSource, "srno");
            divsearch.Visible = true;
        }
        else
        {
                      
            divsearch.Visible = false;
            //lblNorec.Visible = true;
            btnDelete.Visible = false;
            btnNew.Visible = true;
            btnStatus.Visible = false;
            gdvReferalSource.Visible = false;
            ErrMessage("Sorry, No Referral Source found.");
            if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) && (txtSearch.Text != ""))
            {
                txtSearch.Text = "";
                ddlSearch.SelectedIndex = 0;
                lnkNorec.Visible = true;
                btnNew.Visible = false;
                // btnAdd.Visible = false;
                // btnExport.Visible = false;
                //lblMsg.Visible = true;
                ErrMessage("Sorry, No Referral Source found.");
            }

        }
    }
   
    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */
    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)gdvReferalSource.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in gdvReferalSource.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in gdvReferalSource.Rows)
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

        foreach (GridViewRow grv in gdvReferalSource.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select Atleast One Referral Name');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Delete Selected Referral Name(s)?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Change Status of Referral Name(s)?')){return false;}}";
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
            BindGrid();
        }
    }

    #region "Grid Event"
    /* This is gride event that use to update referal source after verification for duplicate source name */
    protected void gdvReferalSource_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gdvReferalSource.Rows[e.RowIndex];
        if (row != null)
        {
            ReferalID = Convert.ToInt32(gdvReferalSource.DataKeys[e.RowIndex].Value);
            Label lblReferalName = (Label)gdvReferalSource.Rows[e.RowIndex].FindControl("lblReferalName");
            TextBox txtReferalName = (TextBox)gdvReferalSource.Rows[e.RowIndex].FindControl("txtReferalName");

            if (txtReferalName.Text == "")
            {
                MessageBox("Please enter Referral Name.");
            }

            else
            {
                StoreFront ObjStoreFront = new StoreFront();
                int Count = ObjStoreFront.UpdateReferalSource(ReferalID, txtReferalName.Text.Trim());

                if (Count == 1)
                {
                    SuccesfullMessage("Referral Name updated successfully.");
                    gdvReferalSource.EditIndex = -1;
                    BindGrid();
                    

                }
                else
                {
                    ErrMessage("Duplicate Referral Name.");
                    gdvReferalSource.EditIndex = -1;
                    BindGrid();
                }


            }
        }
    }
    protected void gdvReferalSource_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdvReferalSource.EditIndex = e.NewEditIndex;
        BindGrid();

    }
    protected void gdvReferalSource_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvReferalSource.EditIndex = -1;
        BindGrid();
    }
    protected void gdvReferalSource_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvReferalSource.SelectedIndex = -1;
        gdvReferalSource.PageIndex = e.NewPageIndex;
        BindGrid();

    }

    /* Grid Sorting event*/
    protected void gdvReferalSource_Sorting(object sender, GridViewSortEventArgs e)
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
        gdvReferalSource.PageIndex = 0;
        BindGrid();
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

    #region event 
    protected void btnNew_Click(object sender, EventArgs e)
    {
        divAddReferalSource.Visible = true;
    }
    /* This event is use to change status of referral source */
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        string StrReferalID = Utility.GetCheckedRow(gdvReferalSource, "chkSelect");
        if (StrReferalID != "")
        {
            StoreFront ObjStoreFront = new StoreFront();
            ObjStoreFront.UpdateReferalSourceStatus(StrReferalID);
            BindGrid();
        }
    }
    /* Event for delete the referral */
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string StrReferalID = Utility.GetCheckedRow(gdvReferalSource, "chkSelect");
        if (StrReferalID != "")
        {
            StoreFront ObjStoreFront = new StoreFront();
            int Count = ObjStoreFront.DeleteReferalSource(StrReferalID);
            if (Count == 0)
            {
                ErrMessage("Referal source(s) in use. It cannot be deleted unless all references to it are deleted");
            }
            else
            {
                SuccesfullMessage("Referral Name(s) deleted successfully.");
            }
        }
        BindGrid();
    }
    /* Region is use to add referral source with verification to database*/
    protected void ImgSubmitService_Click(object sender, EventArgs e)
    {
        StoreFront ObjStoreFront = new StoreFront();
        int count = ObjStoreFront.AddReferalSource(txtReferalName.Text.Trim());
        if (count == 1)
        {
            SuccesfullMessage("Referral Name added successfully.");
            txtReferalName.Text = "";
           
            BindGrid();
        }
        else
        {
            ErrMessage("Please enter Referral Name.");
            txtReferalName.Text = "";
        }
    }
    #endregion 

    #region GridEvent
    //Event use for pagination
    protected void gdvReferalSource_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = gdvReferalSource.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(gdvReferalSource.PageIndex + 1);
        int[] page = new int[7];
        page[0] = gdvReferalSource.PageIndex - 2;
        page[1] = gdvReferalSource.PageIndex - 1;
        page[2] = gdvReferalSource.PageIndex;
        page[3] = gdvReferalSource.PageIndex + 1;
        page[4] = gdvReferalSource.PageIndex + 2;
        page[5] = gdvReferalSource.PageIndex + 3;
        page[6] = gdvReferalSource.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > gdvReferalSource.PageCount)
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
        if (gdvReferalSource.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (gdvReferalSource.PageIndex == gdvReferalSource.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;

        }
        if (gdvReferalSource.PageIndex > gdvReferalSource.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (gdvReferalSource.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    protected void gdvReferalSource_RowCreated(object sender, GridViewRowEventArgs e)
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
        gdvReferalSource.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        BindGrid();
    }

    #endregion

    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageReferalSource.aspx?SearchFor=0&SearchText=");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageReferalSource.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageReferalSource.aspx?SearchFor=0" + "&SearchText=");
    }
}
