using advancewebtosolution.BO;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Admin_MetaTags : System.Web.UI.Page
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

    public void BindPages()
    {
        Global ObjGlobal = new Global();
        DataSet ds = new DataSet();
        ds = ObjGlobal.GetPageList();
        ddlPage.DataTextField = "PageName";
        ddlPage.DataValueField = "PageID";
        ddlPage.DataSource = ds.Tables[0];
        ddlPage.DataBind();

        ddlPage.SelectedValue = Request.QueryString["PageID"].ToString();
    }
    /* This function is use to show all the location service area*/
    public void Bind(int PageID)
    {
        Global ObjGlobal = new Global();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        ds = ObjGlobal.GetMeta(Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString(), PageID);
        ddlSearch.SelectedValue = Request.QueryString["SearchFor"].ToString();
        txtSearch.Text = Request.QueryString["SearchText"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdMeta.Visible = true;
            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;
            GrdMeta.DataSource = dv;
            GrdMeta.DataBind();
            CheckAll();
            check();
            Utility.Setserial(GrdMeta, "srno");
            GrdMeta.Visible = true;
            btnDelete.Visible = true;
            divSelectPage.Visible = true;
            btnAdd.Visible = false;
            
            
        }
        else
        {
            
            btnAdd.Visible = true;
            btnDelete.Visible = false;
            GrdMeta.Visible = false;
            ErrMessage("Sorry, No records found.");
        }

        txtPageTitle.Text = ds.Tables[1].Rows[0]["PageTitle"].ToString();
    }

    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */
    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)GrdMeta.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in GrdMeta.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in GrdMeta.Rows)
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

        foreach (GridViewRow grv in GrdMeta.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Please select meta tag');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do you want to delete the selected meta tag?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do you want to change the status of the following meta tag ?')){return false;}}";
        checkid += "if(flg==1 && id==3){";
        checkid += "if(!confirm('Do you want to change the Meta tag status ?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        btnDelete.Attributes.Add("onclick", "return val(1);");


    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPages();
            Bind(Convert.ToInt32(Request.QueryString["PageID"].ToString()));
        }
    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSearch.SelectedIndex = 0;
        txtSearch.Text = "";
        Response.Redirect("MetaTags.aspx?PageID=" + Convert.ToInt32(ddlPage.SelectedValue) + "&SearchFor=0&SearchText=");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string MetaID = Utility.GetCheckedRow(GrdMeta, "chkSelect");
        if (MetaID != "")
        {
            Global ObjGlobal = new Global();
            ObjGlobal.DeleteMetaTag(MetaID);
            Bind(Convert.ToInt32(ddlPage.SelectedValue));
            divError.Visible = true;
            SuccesfullMessage("Meta tag deleted successfully.");
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Global ObjGlobal = new Global();
        ObjGlobal.AddMeta(Convert.ToInt32(ddlPage.SelectedValue), txtName.Text.Trim(), txtContent.Text.Trim(),txtKeywords.Text.Trim());
        txtName.Text = "";
        txtContent.Text = "";
        divError.Visible = false;
        Bind(Convert.ToInt32(ddlPage.SelectedValue));
    }
    protected void GrdMeta_Sorting(object sender, GridViewSortEventArgs e)
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
        GrdMeta.PageIndex = 0;
        Bind(Convert.ToInt32(ddlPage.SelectedValue));
    }
    protected void GrdMeta_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdMeta.PageIndex = e.NewPageIndex;
        Bind(Convert.ToInt32(ddlPage.SelectedValue));
    }

    protected void GrdMeta_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = GrdMeta.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(GrdMeta.PageIndex + 1);
        int[] page = new int[7];
        page[0] = GrdMeta.PageIndex - 2;
        page[1] = GrdMeta.PageIndex - 1;
        page[2] = GrdMeta.PageIndex;
        page[3] = GrdMeta.PageIndex + 1;
        page[4] = GrdMeta.PageIndex + 2;
        page[5] = GrdMeta.PageIndex + 3;
        page[6] = GrdMeta.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > GrdMeta.PageCount)
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
        if (GrdMeta.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (GrdMeta.PageIndex == GrdMeta.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;

        }
        if (GrdMeta.PageIndex > GrdMeta.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (GrdMeta.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }

    protected void GrdMeta_RowCreated(object sender, GridViewRowEventArgs e)
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
        GrdMeta.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        Bind(Convert.ToInt32(ddlPage.SelectedValue));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("MetaTags.aspx?PageID=" + Convert.ToInt32(ddlPage.SelectedValue) + "&SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
    }
    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("MetaTags.aspx?PageID=" + Convert.ToInt32(ddlPage.SelectedValue) + "&SearchFor=0&SearchText=");
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("MetaTags.aspx?PageID=" + Convert.ToInt32(ddlPage.SelectedValue) + "&SearchFor=0&SearchText=");
    }

    protected void btnUpdatePageTitle_Click(object sender, EventArgs e)
    {
        Global ObjGlobal = new Global();
        ObjGlobal.UpdateTitle(Convert.ToInt32(ddlPage.SelectedValue), txtPageTitle.Text.Trim() );
        Bind(Convert.ToInt32(ddlPage.SelectedValue));
    }
}
