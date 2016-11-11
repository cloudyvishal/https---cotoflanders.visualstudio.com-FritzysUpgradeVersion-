using System;
using System.Web.UI.WebControls;
using System.Data;
using advancewebtosolution.BO;

namespace advancewebtosolution
{
    public partial class Admin_Groomer_GroomerForMonthlyLog : System.Web.UI.Page
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
                Utility.Setserial(GrdUsers, "srno");
                divsearch.Visible = true;

            }
            else
            {
                if ((Convert.ToInt32(ddlSearch.SelectedIndex) > 0) && (txtSearch.Text != ""))
                {
                    txtSearch.Text = "";
                    ddlSearch.SelectedIndex = 0;

                    ErrorMessage("Sorry, No records found.");
                }
                divsearch.Visible = false;
                GrdUsers.Visible = false;
                //btnAdd.Visible = false;
                ErrorMessage("Sorry, No records found.");

            }
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
            Response.Redirect("GroomerForMonthlyLog.aspx?SearchFor=" + ddlSearch.SelectedValue + "&SearchText=" + txtSearch.Text.Trim());
        }
        protected void btnViewall_Click(object sender, EventArgs e)
        {
            Response.Redirect("GroomerForMonthlyLog.aspx?SearchFor=0&SearchText=");
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
}