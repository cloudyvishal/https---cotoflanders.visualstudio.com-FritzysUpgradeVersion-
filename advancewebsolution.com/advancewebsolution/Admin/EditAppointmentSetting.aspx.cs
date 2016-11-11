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
using System.Globalization;
using advancewebtosolution.BO;

public partial class Admin_EditAppointmentSetting : System.Web.UI.Page
{
    string dt = string.Empty;
    PagedDataSource pgds = new PagedDataSource();
    protected void Page_Load(object sender, EventArgs e)
    {            
        if (Request.QueryString["dt"] != null)
        {
            dt = Convert.ToString(Request.QueryString["dt"]);
        }
        if (!IsPostBack)
        {
            txtDate.Text = dt;
            BindData();
            BindDataToEdit();
        }

    }

    protected void BindDataToEdit()
    {
        try
        {
            DataSet DS = new DataSet();
            Appointment objApp = new Appointment();
            DS = objApp.GetAppointmentslotsToEdit(Convert.ToDateTime(dt));
            foreach (DataListItem item in dtlTime.Items)
            {
                Label lblTimeId = (Label)item.FindControl("lblTimeId");
                CheckBox chkTime = (CheckBox)item.FindControl("chkTime");
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    DataRow row = DS.Tables[0].Rows[i];
                    string TimeId = Convert.ToString(row["APTId"]);
                    if (lblTimeId.Text == TimeId)
                    {
                        chkTime.Checked = true;

                    }


                }
            }
        }
        catch  { }
    }
    protected void BindData()
    {
        try
        {
            DataSet DS = new DataSet();
            Appointment objApp = new Appointment();
            DS = objApp.GetAppointmentTime();

            if (DS.Tables[0].Rows.Count > 0)
            {

                pgds.AllowPaging = true;
                pgds.PageSize = 24;
                pgds.DataSource = DS.Tables[0].DefaultView;
                dtlTime.Visible = true;
                dtlTime.DataSource = pgds;
                dtlTime.DataBind();

            }
            else
            {


            }
        }
        catch  { }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Appointment objApp = new Appointment();
            objApp.DeleteAppointmentslots(Convert.ToDateTime(dt));
            foreach (DataListItem item in dtlTime.Items)
            {
                Label lblTimeId = (Label)item.FindControl("lblTimeId");
                CheckBox chkTime = (CheckBox)item.FindControl("chkTime");
                if (chkTime.Checked)
                {
                    objApp.AddAppointmentslots(Convert.ToDateTime(txtDate.Text), Convert.ToInt32(lblTimeId.Text));
                }
            }
            Response.Redirect("AppointmentSettings.aspx");
        }
        catch  { }
    }
}
