using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using advancewebtosolution.BO;

public partial class Admin_Services_ManageServices : System.Web.UI.Page
{
    advancewebtosolution.BO.Services objServices = new advancewebtosolution.BO.Services();

    #region declear
    int ServiceIDs;
    DataTable dtOrder = new DataTable();
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
    private void BindGrid(int type)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        ds = objServices.GetAllServices(type, Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
        ddlSearch.SelectedValue = Request.QueryString["SearchFor"].ToString();
        txtSearch.Text = Request.QueryString["SearchText"].ToString();
        ViewState["MaxPosition"] = ds.Tables[1].Rows[0]["Position"].ToString();
        dtOrder = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvStaticFiles.Visible = true;
            btnDelete.Visible = true;
            btnStatus.Visible = true;
            //lblNorec.Visible = false;
            dt = ds.Tables[0];
            dv = dt.DefaultView;
            if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                dv.Sort = SortExpression + " " + SortDirection;
            gdvStaticFiles.DataSource = dv;
            gdvStaticFiles.DataBind();
            CheckAll();
            check();
            Utility.Setserial(gdvStaticFiles, "srno");
            lstOrder.DataTextField = "ServiceTitle";
            lstOrder.DataValueField = "ServiceID";
            lstOrder.DataSource = ds.Tables[0];
            lstOrder.DataBind();
            lstOrder.SelectedIndex = Convert.ToInt32(ViewState["Count"].ToString());
            if (ViewState["Show"].ToString() == "0")
            {
                divOrder.Attributes.Add("Style", "display:block");
                ViewState["Show"] = "1";
            }
            divsearch.Visible = true;
            btnSetFlea.Visible = true;
            //btnSetHome.Visible = true;
            divSelectpet.Visible = true; btnNew.Visible = true;
            divSelectpet.Visible = true;
            divPet.Visible = true;
            btnLink.Visible = false;
        }
        else
        {
            

            divsearch.Visible = false;
            btnDelete.Visible = false;
            btnNew.Visible = true;
            btnStatus.Visible = false;
            gdvStaticFiles.Visible = false;
            btnLink.Visible = false;
            ErrMessage("Sorry, No records found.");

            if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) && (txtSearch.Text != ""))
            {
                txtSearch.Text = "";
                ddlSearch.SelectedIndex = 0;
                btnNew.Visible = false;
                btnLink.Visible = true;
                btnSetFlea.Visible = false;
                btnSetHome.Visible = false;
                ErrMessage("Sorry, No records found.");
                divPet.Visible = false;
            }
        }
        BindData();
    }
    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */

    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)gdvStaticFiles.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in gdvStaticFiles.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in gdvStaticFiles.Rows)
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

        foreach (GridViewRow grv in gdvStaticFiles.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select Atleast One service');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Delete Selected service(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Change Status of service(s) ?')){return false;}}";

        checkid += "if(flg==1 && id==3){";
        checkid += "if(!confirm('Do You Want To Change The Home Page Service(s) ?')){return false;}}";

        checkid += "if(flg==1 && id==4){";
        checkid += "if(!confirm('Do You Want To Change The Flea Tick & Hot Spot Page Service(s) ?')){return false;}}";

        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        //btnactdeact.Attributes.Add("onclick", "return val(0);");
        btnDelete.Attributes.Add("onclick", "return val(1);");
        btnStatus.Attributes.Add("onclick", "return val(2);");
        btnSetHome.Attributes.Add("onclick", "return val(3);");
        btnSetFlea.Attributes.Add("onclick", "return val(4);");
    }
    public void BindData()
    {
        //if (Request.QueryString["UserType"] != null)
        //{
        //    ddlUserType.SelectedItem.Value = Request.QueryString["UserType"];
        //}
        ServicePage ObjHome = new ServicePage();
        DataSet ds = new DataSet();
       // ds = ObjHome.GetServicePageAdmin(Convert.ToInt32(ddlUserType.SelectedValue));
        ds = ObjHome.GetServicePageAdmin(Convert.ToInt32(Session["UserType"]));
        if (ds.Tables[0].Rows.Count > 0)
        {
            ServiceIDs = Convert.ToInt32(ds.Tables[0].Rows[0]["ServiceID"].ToString());
            GrdService.Visible = true;
            GrdService.DataSource = ds.Tables[0];
            GrdService.DataBind();
            Utility.Setserial(GrdService, "srno");
        }
        else
        {
            GrdService.Visible = true;
        }
    }
    #endregion 


    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            ViewState["Show"] = "1";
            ViewState["Count"] = "0";
            BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
            if (Session["UserType"] != null)
            {

                ddlUserType.SelectedValue = Session["UserType"].ToString();
            }
            else
            {
                Session["UserType"] = "4";
            }
        }
    }

    protected void GrdService_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblImageName = (Label)e.Row.FindControl("lblImageName");
            HtmlImage imgThumb = (HtmlImage)e.Row.FindControl("ImageCoupon");
            Label lblServiceID1 = (Label)e.Row.FindControl("lblServiceID");

            int SID = Convert.ToInt32(lblServiceID1.Text);

            string Temp = Convert.ToString(Session["HomePath"]);

            string fulpath = ContentManager.GetPhysicalPath(Temp) + "StoreData\\ServicePageServices\\" + lblImageName.Text; 
            if (System.IO.File.Exists(fulpath))
            {
                imgThumb.Src = Session["HomePath"] + "StoreData/ServicePageServices/" + lblImageName.Text;
            }
            else
            {
                //imgThumb.Src = Session["HomePath"] + "StoreData/HomeServices/Not.jpg";
            }

           
            HyperLink lblServiceTitle = (HyperLink)e.Row.FindControl("lblServiceTitle");
            lblServiceTitle.NavigateUrl = "EditServicePageServices.aspx?ServiceID=" + SID + "&UserType=" + ddlUserType.SelectedValue;
        }
    }
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["UserType"] = Convert.ToString(ddlUserType.SelectedValue).ToString();
        BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
    }
    #region Button
    /* Delete function is use to delete the entery from the  database as well use to delete service page from store data*/
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ViewState["Count"] = "0";
        for (int i = 0; i <= gdvStaticFiles.Rows.Count - 1; i++)
        {
            CheckBox chk = (CheckBox)gdvStaticFiles.Rows[i].FindControl("chkSelect");
            if (chk.Checked)
            {
                Label lblImageName = (Label)gdvStaticFiles.Rows[i].FindControl("lblImage");
                string LogicalPath = Session["HomePath"] + "StoreData/Images/" + lblImageName.Text;
                string physicalPath = ContentManager.GetPhysicalPath(LogicalPath);
                if (System.IO.File.Exists(physicalPath))
                {
                    System.IO.File.Delete(physicalPath);
                }
                Label lblFileName = (Label)gdvStaticFiles.Rows[i].FindControl("lblFile");
                LogicalPath = Session["HomePath"] + "StoreData/" + lblFileName.Text;
                physicalPath = ContentManager.GetPhysicalPath(LogicalPath);
                if (System.IO.File.Exists(physicalPath))
                {
                    System.IO.File.Delete(physicalPath);
                }

                Label Position = (Label)gdvStaticFiles.Rows[i].FindControl("lblPosition");
                Label ServiceID = (Label)gdvStaticFiles.Rows[i].FindControl("lblServiceID");
                DeletePosition(Convert.ToInt32(Position.Text), Convert.ToInt32(ServiceID.Text));
            }
        }

         
        BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
        SuccesfullMessage("Service(s) deleted successfully.");
    }

    public void DeletePosition(int Position, int ServiceID )
    {
        try
        {
            objServices.DeleteService(ServiceID.ToString());

            if (ViewState["Count"].ToString() != "0")
            { Position = Position - (Convert.ToInt32(ViewState["Count"].ToString()) + 1); }

            for (int i = Position + 1; i < Convert.ToInt32(ViewState["MaxPosition"].ToString()); i++)
            {
                objServices.SetPositionDown(i, Convert.ToInt32(ddlPet.SelectedValue));
            }
            ViewState["Count"] = Convert.ToInt32(ViewState["Count"].ToString()) + 1;
        }
        catch  { }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddService.aspx");
    }

    #endregion 
    

    #region Status
    /* Event use to change the status of the service*/
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        string ServiceID = Utility.GetCheckedRow(gdvStaticFiles, "chkSelect");
        if (ServiceID != "")
        {
            objServices.UpdateStatus(ServiceID);
        }
        BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
    }

    /* Event use to Set Home Page service  */
    protected void btnSetHome_Click(object sender, EventArgs e)
    {
        try
        {
            string ServiceID = Utility.GetCheckedRow(gdvStaticFiles, "chkSelect");
            char[] separator = new char[] { ',' };
            string[] str = ServiceID.Split(separator);

            if (str.Length <= 1)
            {
                objServices.SetIsHome(ServiceID, Convert.ToInt32(ddlPet.SelectedValue));
            }
            else
            {
                ErrMessage("You can not set more than two services.");
            }
            BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
        }
        catch  { }
    }

    /* Event use to set flea  service*/
    protected void btnSetFlea_Click(object sender, EventArgs e)
    {
       
        string ServiceID = Utility.GetCheckedRow(gdvStaticFiles, "chkSelect");
        char[] separator = new char[] { ',' };
        string[] str = ServiceID.Split(separator);

        if (str.Length <= 1)
        {
           objServices.SetIsFlea(ServiceID, Convert.ToInt32(ddlPet.SelectedValue));
        }
        else
        {
             ErrMessage("You can not set more than two services.");
        }
        BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
    }

    #endregion


    #region Btn Up Down 
    protected void btnUP_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Count"] = lstOrder.SelectedIndex - 1;
            for (int i = 1; i < lstOrder.Items.Count; i++)
            {
                if (lstOrder.Items[i].Selected == true)
                {
                    string TempValue = lstOrder.Items[i].Value;
                    string TempText = lstOrder.Items[i].Value;
                    lstOrder.Items.RemoveAt(i);
                    ListItem lst = new ListItem();
                    lst.Text = TempText;
                    lst.Value = TempValue;
                    lstOrder.Items.Insert(i - 1, lst);
                }
            }
            for (int i = 0; i < lstOrder.Items.Count; i++)
            {
                objServices.UpdateOrder(Convert.ToInt32(lstOrder.Items[i].Value), i + 1);
            }

            ViewState["Show"] = "0";
            BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
        }
        catch  { }

    }
    protected void btnDown_Click(object sender, EventArgs e)
    {
        ViewState["Count"] = lstOrder.SelectedIndex + 1;
        for (int i = 0; i < lstOrder.Items.Count -1; i++)
        {
            if (lstOrder.Items[i].Selected == true)
            {
                string TempValue = lstOrder.Items[i].Value;
                string TempText = lstOrder.Items[i].Value;
                lstOrder.Items.RemoveAt(i);
                ListItem lst = new ListItem();
                lst.Text = TempText;
                lst.Value = TempValue;
                lstOrder.Items.Insert(i + 1, lst);
            }
        }
        for (int i = 0; i < lstOrder.Items.Count; i++)
        {
            objServices.UpdateOrder(Convert.ToInt32(lstOrder.Items[i].Value), i + 1);
        }
        
        ViewState["Show"] = "0";
        BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
    }

    protected void gdvStaticFiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblServiceID = (Label)e.Row.FindControl("lblServiceID");
            DropDownList ddllist = (DropDownList)e.Row.FindControl("ddlList");
            ddllist.DataTextField = "Position";
            ddllist.DataValueField = "ServiceID";
            ddllist.DataSource = dtOrder;
            ddllist.DataBind();

            ddllist.SelectedValue = lblServiceID.Text;
            Session["PetTypes"] = ddlPet.SelectedValue;
           // ddllist.Attributes.Add("OnChange", "Check();");
        }
    }

    protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlOrder = (DropDownList)sender;
            Label lb = (Label)ddlOrder.Parent.FindControl("lblPosition");
            Label lblServiceID = (Label)ddlOrder.Parent.FindControl("lblServiceID");
            int OldIndex = Convert.ToInt32(lb.Text);
            int NewIndex = Convert.ToInt32(ddlOrder.SelectedItem.Text);
            int ServiceID = Convert.ToInt32(lblServiceID.Text);
            if (OldIndex < NewIndex)
            {
                for (int i = (OldIndex + 1); i < NewIndex + 1; i++)
                {

                    objServices.SetPositionDown(i, Convert.ToInt32(ddlPet.SelectedValue));
                }
            }
            else
            {
                for (int j = OldIndex - 1; j > NewIndex - 1; j--)
                {
                    objServices.SetPositionUp(j, Convert.ToInt32(ddlPet.SelectedValue));
                }
            }
            objServices.SetNewPosition(ServiceID, NewIndex);
            BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
        }
        catch  { }
    }

    #endregion 

    #region GridEvent
    //Event use for pagination
    protected void gdvStaticFiles_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = gdvStaticFiles.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(gdvStaticFiles.PageIndex + 1);
        int[] page = new int[7];
        page[0] = gdvStaticFiles.PageIndex - 2;
        page[1] = gdvStaticFiles.PageIndex - 1;
        page[2] = gdvStaticFiles.PageIndex;
        page[3] = gdvStaticFiles.PageIndex + 1;
        page[4] = gdvStaticFiles.PageIndex + 2;
        page[5] = gdvStaticFiles.PageIndex + 3;
        page[6] = gdvStaticFiles.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > gdvStaticFiles.PageCount)
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
        if (gdvStaticFiles.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (gdvStaticFiles.PageIndex == gdvStaticFiles.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;

        }
        if (gdvStaticFiles.PageIndex > gdvStaticFiles.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (gdvStaticFiles.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }

    protected void gdvStaticFiles_RowCreated(object sender, GridViewRowEventArgs e)
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

    /*Event fro sorting */
    protected void gdvStaticFiles_Sorting(object sender, GridViewSortEventArgs e)
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
        gdvStaticFiles.PageIndex = 0;
        BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
    }

    protected void ddlPet_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
    }
    void lb_Command(object sender, CommandEventArgs e)
    {
        gdvStaticFiles.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
    }

    /* Page index changing event to manage pagging */
    protected void gdvStaticFiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvStaticFiles.PageIndex = e.NewPageIndex;
        BindGrid(Convert.ToInt32(ddlPet.SelectedValue));
    }

    #endregion

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageServices.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
    }
    protected void lnkNorec_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageServices.aspx?SearchFor=0&SearchText=");
    }
    protected void btnViewall_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageServices.aspx?SearchFor=0&SearchText=");
    }

    protected void btnLink_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageServices.aspx?SearchFor=0&SearchText=");
    }
    protected void btnPreview_Click1(object sender, EventArgs e)
    {
        string url = "../../Services.aspx";
        string script = "window.open('" + url + "','')";
        if (!ClientScript.IsClientScriptBlockRegistered("NewWindow"))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "NewWindow", script, true);
        }
    }
}
