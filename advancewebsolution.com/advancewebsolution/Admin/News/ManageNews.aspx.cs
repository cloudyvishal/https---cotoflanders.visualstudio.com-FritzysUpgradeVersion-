using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using advancewebtosolution.BO;

/* This page is use to manage News Add, Edit, delete */
public partial class Admin_News_ManageNews : System.Web.UI.Page
{
    DataTable dtOrder = new DataTable();
    #region Declare
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

    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */

    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)GrdNews.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in GrdNews.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in GrdNews.Rows)
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

        foreach (GridViewRow grv in GrdNews.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select at least one News Item ');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm(' 	 Do you want to delete the selected News Item(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do you want to change the status of the selected News Item(s) ? ')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        btnDelete.Attributes.Add("onclick", "return val(1);");
        btnStatus.Attributes.Add("onclick", "return val(2);");
    }

    public void BindGrid()
    {
        Global ObjUser = new Global();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        ds = ObjUser.GetAllNews(Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
        ddlSearch.SelectedValue = Request.QueryString["SearchFor"].ToString();
        txtSearch.Text = Request.QueryString["SearchText"].ToString();
        dtOrder = ds.Tables[0];
        ViewState["MaxPosition"] = ds.Tables[1].Rows[0]["Position"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdNews.Visible = true;
            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;

            GrdNews.DataSource = dv;
            GrdNews.DataBind();
            CheckAll();
            check();
            Utility.Setserial(GrdNews, "srno");
            btnAdd.Visible = true;
            btnDelete.Visible = true;
            btnStatus.Visible = true;
            btnPreview.Visible = true;
            divsearch.Visible = true;
        }
        else
        {
            if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) && (txtSearch.Text != ""))
            {
                txtSearch.Text = "";
                ddlSearch.SelectedIndex = 0;
                lnkNorec.Visible = true;
                btnPreview.Visible = false;
                ErrMessage1("Sorry, No records found.");
            }
            divsearch.Visible = false;
            GrdNews.Visible = false;
            btnDelete.Visible = false;
            btnStatus.Visible = false;
            btnPreview.Visible = false;
            ErrMessage1("Sorry, No records found.");
        }
    }

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
    public void ErrMessage1(string Message)
    {
        divError1.Visible = true;
        lblError1.Attributes.Add("Class", "errorTable");
        lblError1.Visible = true;
        lblError1.Text = Message;
    }
    public void SuccesfullMessage1(string Message)
    {
        divError1.Visible = true;
        lblError1.Attributes.Add("Class", "successTable");
        lblError1.Visible = true;
        lblError1.Text = Message;
    }
    #endregion 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            BindFckEditor();
        }
    }
    
    #region event 
    /*This event is use to delete news from database*/
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ViewState["Count"] = "0";
        for (int i = 0; i <= GrdNews.Rows.Count - 1; i++)
        {
            CheckBox chk = (CheckBox)GrdNews.Rows[i].FindControl("chkSelect");
            if (chk.Checked)
            {
                Label Position = (Label)GrdNews.Rows[i].FindControl("lblPosition");
                Label ItemID = (Label)GrdNews.Rows[i].FindControl("lblID");
                DeletePosition(Convert.ToInt32(Position.Text), Convert.ToInt32(ItemID.Text));
            }
        }
        BindGrid(); 
        SuccesfullMessage1("News deleted successfully");
    }

    public void DeletePosition(int Position, int ItemID)
    {
        if (ViewState["Count"].ToString() != "0")
        { Position = Position - (Convert.ToInt32(ViewState["Count"].ToString()) + 1); }

        Global ObjUser = new Global();
        ObjUser.DeleteNews(ItemID.ToString());

        for (int i = Position + 1; i <= Convert.ToInt32(ViewState["MaxPosition"].ToString()); i++)
        {
            ObjUser.NewsDown(i);
        }
        ViewState["Count"] = Convert.ToInt32(ViewState["Count"].ToString()) + 1;
    }
    /* Use to change the status of news*/
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        string UserID = Utility.GetCheckedRow(GrdNews, "chkSelect");
        if (UserID != "")
        {
            Global ObjUser = new Global();
            ObjUser.UpdateNewsStatus(UserID);
            BindGrid();
        }
    }

    /* Page index changing event to manage pagging */
    protected void GrdNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdNews.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    /* Event For sorting */
    protected void GrdNews_Sorting(object sender, GridViewSortEventArgs e)
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
        GrdNews.PageIndex = 0;
        BindGrid();
    }
    #endregion 

    protected void BindFckEditor()
    {
        string FileName = "AboutUs.htm";
        FCKeditor2.Value = ContentManager.GetStaticeContent(FileName).Replace("~", "#");
        FCKeditor2.Height = 300;
        FCKeditor2.Width = 810;
        FCKeditor2.SkinPath = "skins/silver/";
    }
    
    #region "SaveFile"
    protected void SaveFile(string StrContent)
    {
        string Fullpath = Session["HomePath"] + "StoreData/StaticeContent/" + "AboutUs.htm";
        string fullpath2 = ContentManager.GetPhysicalPath(Fullpath);
        FileStream file = new FileStream(fullpath2, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(StrContent);
        sw.Close();
        file.Close();
        SuccesfullMessage("Your content has been saved successfully. ");
        BindFckEditor();
        BindGrid();
    }
    #endregion

    #region "Save Btn"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveFile(FCKeditor2.Value);
    }
    #endregion 

    #region GridEvent
    //Event use for pagination
    protected void GrdNews_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = GrdNews.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(GrdNews.PageIndex + 1);
        int[] page = new int[7];
        page[0] = GrdNews.PageIndex - 2;
        page[1] = GrdNews.PageIndex - 1;
        page[2] = GrdNews.PageIndex;
        page[3] = GrdNews.PageIndex + 1;
        page[4] = GrdNews.PageIndex + 2;
        page[5] = GrdNews.PageIndex + 3;
        page[6] = GrdNews.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > GrdNews.PageCount)
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
        if (GrdNews.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (GrdNews.PageIndex == GrdNews.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;

        }
        if (GrdNews.PageIndex > GrdNews.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (GrdNews.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    protected void GrdNews_RowCreated(object sender, GridViewRowEventArgs e)
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
        GrdNews.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        BindGrid();
    }

    #endregion

    #region Search
    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageNews.aspx?SearchFor=0&SearchText=");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageNews.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageNews.aspx?SearchFor=0" + "&SearchText=");
    }
    #endregion 

    #region Position
    protected void GrdProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblID = (Label)e.Row.FindControl("lblID");
            DropDownList ddllist = (DropDownList)e.Row.FindControl("ddlList");
            ddllist.DataTextField = "Position";
            ddllist.DataValueField = "NewsID";
            ddllist.DataSource = dtOrder;
            ddllist.DataBind();
            ddllist.SelectedValue = lblID.Text;
        }
    }

    protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlOrder = (DropDownList)sender;
        Label lb = (Label)ddlOrder.Parent.FindControl("lblPosition");
        Label lblID = (Label)ddlOrder.Parent.FindControl("lblID");
        int OldIndex = Convert.ToInt32(lb.Text);
        int NewIndex = Convert.ToInt32(ddlOrder.SelectedItem.Text);
        int ID = Convert.ToInt32(lblID.Text);
        Global Obj = new Global();
        if (OldIndex < NewIndex)
        {
            for (int i = (OldIndex + 1); i < NewIndex + 1; i++)
            {
                Obj.NewsDown(i);
            }
        }
        else
        {
            for (int j = OldIndex - 1; j > NewIndex - 1; j--)
            {
                Obj.NewsUp(j);
            }
        }
        Obj.NewsPosition(ID, NewIndex);
        BindGrid();
    }
    #endregion 
   
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        string url = "../../AboutUs.aspx";
        string script = "window.open('" + url + "','')";
        if (!ClientScript.IsClientScriptBlockRegistered("NewWindow"))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "NewWindow", script, true);
        }
    }
}
