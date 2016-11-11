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
using System.IO;
using advancewebtosolution.BO;

public partial class Admin_Friends_ManageFriends : System.Web.UI.Page
{
    #region Decler
    DataTable dtOrder = new DataTable();
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
    /* Use to store Sort expression */
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
    /* Use to store Sort Direction*/
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
    /* function is use to bind all friend data from database */
    public void Bind()
    {
        Global ObjUser = new Global();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        ds = ObjUser.GetAllFriend(Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
        ddlSearch.SelectedValue = Request.QueryString["SearchFor"].ToString();
        txtSearch.Text = Request.QueryString["SearchText"].ToString();
        dtOrder = ds.Tables[0];
        ViewState["MaxPosition"] = ds.Tables[1].Rows[0]["Position"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdFriends.Visible = true;
            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;

            GrdFriends.DataSource = dv;
            GrdFriends.DataBind();
            CheckAll();
            check();
            Utility.Setserial(GrdFriends, "srno");
            btnDelete.Visible = true;
            btnStatus.Visible = true;
            divsearch.Visible = true;
        }
        else
        {
            if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) && (txtSearch.Text != ""))
            {
                txtSearch.Text = "";
                ddlSearch.SelectedIndex = 0;
                lnkNorec.Visible = true;
                // btnAdd.Visible = false;
                // btnExport.Visible = false;
                //lblMsg.Visible = true;
                ErrMessage1("Sorry, No records found.");
            }
            divsearch.Visible = false;
            GrdFriends.Visible = false;
            btnDelete.Visible = false;
            btnStatus.Visible = false;
            ErrMessage1("Sorry, No records found.");
        }
    }

    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */

  
    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)GrdFriends.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in GrdFriends.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in GrdFriends.Rows)
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

        foreach (GridViewRow grv in GrdFriends.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select Atleast One Friend(s)');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Delete Selected Friend(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Change Status of Friend(s) ?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        //btnactdeact.Attributes.Add("onclick", "return val(0);");
        btnDelete.Attributes.Add("onclick", "return val(1);");
        btnStatus.Attributes.Add("onclick", "return val(2);");

    }
    #endregion

    protected void BindFckEditor()
    {
        FCKeditor2.Value = ContentManager.GetStaticeContent("Friend.htm").Replace("~", "#");
        FCKeditor2.Height = 300;
        FCKeditor2.Width = 810;
        FCKeditor2.SkinPath = "skins/silver/";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
            BindFckEditor();
        }
    }
    
    #region Btn Event
    /* Event is use to delete the friend */
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ViewState["Count"] = "0";

        for (int i = 0; i <= GrdFriends.Rows.Count - 1; i++)
        {
            CheckBox chk = (CheckBox)GrdFriends.Rows[i].FindControl("chkSelect");
            if (chk.Checked)
            {
                Label Position = (Label)GrdFriends.Rows[i].FindControl("lblPosition");
                Label FriendID = (Label)GrdFriends.Rows[i].FindControl("lblID");
                DeletePosition(Convert.ToInt32(Position.Text), Convert.ToInt32(FriendID.Text));
            }
        }
        Bind();
        ViewState["Count"] = "0";
        SuccesfullMessage1("Friend(s) deleted successfully.");
    }

    public void DeletePosition(int Position, int FriendID)
    {
        if (ViewState["Count"].ToString() != "0")
        { Position = Position - (Convert.ToInt32(ViewState["Count"].ToString()) + 1); }
        
        Global ObjUser = new Global();
        ObjUser.DeleteFriend(FriendID.ToString());

        for (int i = Position + 1; i <= Convert.ToInt32(ViewState["MaxPosition"].ToString()); i++)
        {
            ObjUser.FriendDown(i);
        }

        ViewState["Count"] = Convert.ToInt32(ViewState["Count"].ToString()) + 1;
        
    }

    /*Event is use to delete the data*/
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        string FriendID = Utility.GetCheckedRow(GrdFriends, "chkSelect");
        if (FriendID != "")
        {
            Global ObjUser = new Global();
            ObjUser.UpdateFriendStatus(FriendID);
            Bind();
        }
    }
    #endregion

    #region Grd Event
    /* Event Sorting */
    protected void GrdFriends_Sorting(object sender, GridViewSortEventArgs e)
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
        GrdFriends.PageIndex = 0;
        Bind();
    }
    //Event Pagging 
    protected void GrdFriends_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdFriends.PageIndex = e.NewPageIndex;
        Bind();
    }
    #endregion

    #region "SaveFile"
    protected void SaveFile(string StrContent)
    {
        string Fullpath = Session["HomePath"] + "StoreData/StaticeContent/" + "Friend.htm";
        string fullpath2 = ContentManager.GetPhysicalPath(Fullpath);
        FileStream file = new FileStream(fullpath2, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(StrContent);
        sw.Close();
        file.Close();
        SuccesfullMessage("Your content has been saved successfully. ");
        BindFckEditor();
        Bind();
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
    protected void GrdFriends_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = GrdFriends.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(GrdFriends.PageIndex + 1);
        int[] page = new int[7];
        page[0] = GrdFriends.PageIndex - 2;
        page[1] = GrdFriends.PageIndex - 1;
        page[2] = GrdFriends.PageIndex;
        page[3] = GrdFriends.PageIndex + 1;
        page[4] = GrdFriends.PageIndex + 2;
        page[5] = GrdFriends.PageIndex + 3;
        page[6] = GrdFriends.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > GrdFriends.PageCount)
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
        if (GrdFriends.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (GrdFriends.PageIndex == GrdFriends.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;

        }
        if (GrdFriends.PageIndex > GrdFriends.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (GrdFriends.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    protected void GrdFriends_RowCreated(object sender, GridViewRowEventArgs e)
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
        GrdFriends.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        Bind();
    }

    protected void GrdProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblID = (Label)e.Row.FindControl("lblID");
            DropDownList ddllist = (DropDownList)e.Row.FindControl("ddlList");
            ddllist.DataTextField = "Position";
            ddllist.DataValueField = "FriendID";
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
                Obj.FriendDown(i);
            }
        }
        else
        {
            for (int j = OldIndex - 1; j > NewIndex - 1; j--)
            {
                Obj.FriendUp(j);
            }
        }
        Obj.FriendPosition(ID, NewIndex);
        Bind();
    }
    #endregion

    #region Pagging 
    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageFriends.aspx?SearchFor=0&SearchText=");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageFriends.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageFriends.aspx?SearchFor=0" + "&SearchText=");
    }
    protected void btnPreview_Click1(object sender, EventArgs e)
    {
        string url = "../../FritzyFriends.aspx";
        string script = "window.open('" + url + "','')";
        if (!ClientScript.IsClientScriptBlockRegistered("NewWindow"))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "NewWindow", script, true);
        }
    }
    #endregion 
}
