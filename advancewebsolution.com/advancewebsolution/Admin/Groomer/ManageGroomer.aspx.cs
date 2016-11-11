using advancewebtosolution.BO;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
    public partial class ManageGroomer : System.Web.UI.Page
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
        public void BindGroomers()
        {
            Groomer ObjGroomer = new Groomer();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataView dv = new DataView();
            ds = ObjGroomer.GetAllGroomers(Request.QueryString["SearchFor"].ToString(), Request.QueryString["SearchText"].ToString());
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

            }
            else
            {
                if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) && (txtSearch.Text != ""))
                {
                    txtSearch.Text = "";
                    ddlSearch.SelectedIndex = 0;
                    lnkNorec.Visible = true;
                    //btnAdd.Visible = false;

                    ErrorMessage("Sorry, No records found.");
                }
                divsearch.Visible = false;
                GrdUsers.Visible = false;
                btnDelete.Visible = false;
                lnkNorec.Visible = true;
                //btnAdd.Visible = false;

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
            checkid += "alert('Select Atleast One Groomer(s)');return false;}";
            checkid += "if(flg==1 && id==1){";
            checkid += "if(!confirm('Do You Want To Delete Selected Groomer(s) ?')){return false;}}";
            checkid += "if(flg==1 && id==2){";
            checkid += "if(!confirm('Do You Want To Change Status of Groomer(s) ?')){return false;}}";
            checkid = checkid + "}";
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);
            btnDelete.Attributes.Add("onclick", "return val(1);");
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGroomers();
            }
        }
        /* Page index change event*/
        protected void GrdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdUsers.PageIndex = e.NewPageIndex;
            BindGroomers();
        }

        //Button delete event 
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string GID = Utility.GetCheckedRow(GrdUsers, "chkSelect");
            if (GID != "")
            {
                Groomer ObjGroomer = new Groomer();
                ObjGroomer.DeleteGroomer(GID);
                BindGroomers();
                SuccessMessage("Groomer(s) deleted Successfully.");
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
            BindGroomers();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageGroomer.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
        }
        protected void btnViewall_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageGroomer.aspx?SearchFor=0&SearchText=");
        }
        protected void lnkNorec_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageGroomer.aspx?SearchFor=0&SearchText=");
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
            BindGroomers();
        }

        #endregion
    }
