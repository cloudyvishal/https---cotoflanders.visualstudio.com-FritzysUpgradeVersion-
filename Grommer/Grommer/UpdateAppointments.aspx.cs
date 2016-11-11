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
using System.Data.SqlClient;

public partial class UpdateAppointments : System.Web.UI.Page
{
    Groomer objgroomer = new Groomer();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            grdOldApp.DataSource = (DataSet)Session["appData"];
            grdOldApp.DataBind();
        }
       
    }
    protected void rbkOldCalendar_SelectionChanged(object sender, EventArgs e)
    {
        string selDate = rbkOldCalendar.SelectedDate.Date.ToString();
        Response.Redirect("CalendarView.aspx?rbkDate="+ selDate+ "&From=UA");
        
    }

   
    protected void grdOldApp_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdOldApp.EditIndex = e.NewEditIndex;
        grdOldApp.DataSource = (DataSet)Session["appData"];
        grdOldApp.DataBind();

    }
    protected void btnGoback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Operations.aspx");
    }
}
