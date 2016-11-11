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

public partial class Admin_AdminHome : System.Web.UI.Page
{

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

    #region BindData
    /* Function use to bind all data to grid*/
    public void BindData()
    {
        try
        {
            Global ObjSuggest = new Global();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataView dv = new DataView();
            ds = ObjSuggest.GetTopSuggestion();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdSuggestion.Visible = true;
                dt = ds.Tables[0];
                dv = dt.DefaultView;
                if ((SortExpression != string.Empty) && (SortDirection != string.Empty))
                    dv.Sort = SortExpression + " " + SortDirection;
                GrdSuggestion.DataSource = dv;
                GrdSuggestion.DataBind();
                Utility.Setserial(GrdSuggestion, "srno");
                lblNorec.Visible = false;
                lnkSuggestion.Visible = true;
            }
            else
            {
                lnkSuggestion.Visible = false;
                lblNorec.Visible = true;
                GrdSuggestion.Visible = false;
            }
        }
        catch  { }
    }

    public void BindUsers()
    {
        try
        {
            Global ObjUser = new Global();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataView dv = new DataView();
            ds = ObjUser.GetTopUserFront();
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
                lblNoUser.Visible = false;
                lnkUser.Visible = true;
            }
            else
            {
                lblNoUser.Visible = true;
                GrdUsers.Visible = false;
                lnkUser.Visible = false;
            }
        }
        catch  { }
    }

    public void BindContactUS()
    {
        try
        {
            Global ObjContactUS = new Global();
            DataSet ds = new DataSet();
            ds = ObjContactUS.GetTopContactUS();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdContactUs.Visible = true;
                grdContactUs.DataSource = ds.Tables[0];
                grdContactUs.DataBind();
                Utility.Setserial(grdContactUs, "srnoContact");
                lblNoContactus.Visible = false;
                hypContactUS.Visible = true;
            }
            else
            {
                lblNoContactus.Visible = true;
                grdContactUs.Visible = false;
                hypContactUS.Visible = false;
            }
        }
        catch  { }
    }

    //This Function is used to bind only non-recurrence appointments
    private void BindAppointment()
    {
        try
        {
            Global ObjAppointment = new Global();
            DataSet ds = new DataSet();
            ds = ObjAppointment.GetTopAppointment();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdAppointment.Visible = true;
                grdAppointment.DataSource = ds.Tables[0];
                grdAppointment.DataBind();
                Utility.Setserial(grdAppointment, "srnoAppointment");
                lblNoAppointment.Visible = false;
            }
            else
            {
                lblNoAppointment.Visible = true;
                grdAppointment.Visible = false;
            }
        }
        catch  { }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblDate.Text = DateTime.Now.Date.ToString("dd MMM yyyy");
            BindData();
            BindUsers();
            BindContactUS();
            BindAppointment();
        }
    }
}
