using advancewebtosolution.BO;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Products_ManageProducts : System.Web.UI.Page
{
    advancewebtosolution.BO.Products objProducts = new advancewebtosolution.BO.Products();
    DataTable dtOrder = new DataTable();
    #region Declear 
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

    /* Code to manage view state for sortExpression */
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
    /* This function is use to bind all data from services using getall services*/

    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */


    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)GrdProducts.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in GrdProducts.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in GrdProducts.Rows)
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

        foreach (GridViewRow grv in GrdProducts.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select Atleast One Product(s)');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Delete Selected Product(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Change Status of Product(s) ?')){return false;}}";

        checkid += "if(flg==1 && id==3){";
        checkid += "if(!confirm('Do You Want To Change Home Page Product(s) ?')){return false;}}";

        checkid += "if(flg==1 && id==4){";
        checkid += "if(!confirm('Do You Want To Change Flea Tick & Hot Spot Page Product(s) ?')){return false;}}";

        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        //btnactdeact.Attributes.Add("onclick", "return val(0);");
        btnDelete.Attributes.Add("onclick", "return val(1);");
        btnStatus.Attributes.Add("onclick", "return val(2);");
        btnHome.Attributes.Add("onclick", "return val(3);");
        btnFlea.Attributes.Add("onclick", "return val(4);");

    }
    public void Bind()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        ds = objProducts.GetAllProducts(Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
        ddlSearch.SelectedValue = Request.QueryString["SearchFor"].ToString();
        txtSearch.Text = Request.QueryString["SearchText"].ToString();
        dtOrder = ds.Tables[0];
        ViewState["MaxPosition"] = ds.Tables[1].Rows[0]["Position"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdProducts.Visible = true;
            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;

            GrdProducts.DataSource = dv;
            GrdProducts.DataBind();
            CheckAll();
            check();
            Utility.Setserial(GrdProducts, "srno");
            btnDelete.Visible = true;
            btnStatus.Visible = true;
            divsearch.Visible = true;
            btnFlea.Visible = true;
            btnHome.Visible = true;
            btnNew.Visible = true;
            btnPreview.Visible = true;
        }
        else
        {
            if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) && (txtSearch.Text != ""))
            {
                txtSearch.Text = "";
                ddlSearch.SelectedIndex = 0;
                lnkNorec.Visible = true;
                btnFlea.Visible = false;
                btnHome.Visible = false;
                btnNew.Visible = false;
                btnPreview.Visible = false;
                
               // btnImport.Visible = false;
                //lblMsg.Visible = true;
                ErrMessage("Sorry, No records found.");
            }
            divsearch.Visible = false;
            GrdProducts.Visible = false;
            btnDelete.Visible = false;
            btnStatus.Visible = false;
        }
    }
    #endregion 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    #region btn
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProducts.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ViewState["Count"] = "0";
        for (int i = 0; i <= GrdProducts.Rows.Count - 1; i++)
        {
            CheckBox chk = (CheckBox)GrdProducts.Rows[i].FindControl("chkSelect");
            if (chk.Checked)
            {
                Label Position = (Label)GrdProducts.Rows[i].FindControl("lblPosition");
                Label ProdictID = (Label)GrdProducts.Rows[i].FindControl("lblID");
                DeletePosition(Convert.ToInt32(Position.Text), Convert.ToInt32(ProdictID.Text));
            }
        }
        Bind();
        SuccesfullMessage("Product(s) deleted successfully.");
    }

    public void DeletePosition(int Position, int ProductID)
    {
        objProducts.DeleteProducts(ProductID.ToString());
        if (ViewState["Count"].ToString() != "0")
        { Position = Position - (Convert.ToInt32(ViewState["Count"].ToString()) + 1); }

        for (int i = Position + 1; i <= Convert.ToInt32(ViewState["MaxPosition"].ToString()); i++)
        {
            objProducts.ProductDown(i);
        }
        ViewState["Count"] = Convert.ToInt32(ViewState["Count"].ToString()) + 1;
    }

    protected void btnStatus_Click(object sender, EventArgs e)
    {
        string ProductID = Utility.GetCheckedRow(GrdProducts, "chkSelect");
        if (ProductID != "")
        {
            objProducts.UpdateProductStatus(ProductID);
            Bind();
        }
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        string ProductID = Utility.GetCheckedRow(GrdProducts, "chkSelect");
        char[] separator = new char[] { ',' };
        string[] str = ProductID.Split(separator);

        if (str.Length <= 2)
        {
           objProducts.UpdateHomeProduct(ProductID);
            Bind();
        }
        else
        {
            ErrMessage("You can not set more than two products.");
        }
        Bind();
    }

    protected void btnFlea_Click(object sender, EventArgs e)
    {
        string ProductID = Utility.GetCheckedRow(GrdProducts, "chkSelect");
        char[] separator = new char[] { ',' };
        string[] str = ProductID.Split(separator);

        if (str.Length <= 2)
        {
            objProducts.UpdateFleaProduct(ProductID);
            Bind();
        }
        else
        {
            ErrMessage("You can not set more than two products.");
        }
        Bind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageProducts.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
    }
    #endregion 
    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageProducts.aspx?SearchFor=0&SearchText=");
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageProducts.aspx?SearchFor=0&SearchText=");
    }

    #region Grid
    protected void GrdProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdProducts.PageIndex = e.NewPageIndex;
        Bind();
    }

    protected void GrdProducts_Sorting(object sender, GridViewSortEventArgs e)
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
        GrdProducts.PageIndex = 0;
        Bind();
    }

    protected void GrdProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblID = (Label)e.Row.FindControl("lblID");
            DropDownList ddllist = (DropDownList)e.Row.FindControl("ddlList");
            ddllist.DataTextField = "Position";
            ddllist.DataValueField = "ProductID";
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
        if (OldIndex < NewIndex)
        {
            for (int i = (OldIndex + 1); i < NewIndex + 1; i++)
            {
                objProducts.ProductDown(i);
            }
        }
        else
        {
            for (int j = OldIndex - 1; j > NewIndex - 1; j--)
            {
                objProducts.ProductUp(j);
            }
        }
        objProducts.ProductPosition(ID, NewIndex);
        Bind();
    }
    #endregion

    protected void btnPreview_Click1(object sender, EventArgs e)
    {
        string url = "../../Products.aspx";
        string script = "window.open('" + url + "','')";
        if (!ClientScript.IsClientScriptBlockRegistered("NewWindow"))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "NewWindow", script, true);
        }
    }
}
