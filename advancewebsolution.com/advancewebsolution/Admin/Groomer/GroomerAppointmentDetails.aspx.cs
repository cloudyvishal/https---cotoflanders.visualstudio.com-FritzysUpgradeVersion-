using advancewebtosolution.BO;
using System;
using System.Data;
namespace advancewebtosolution
{
    public partial class Admin_Groomer_GroomerAppointmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetGroomerAppointmentDetails();
        }
        public void GetGroomerAppointmentDetails()
        {
            Groomer objgroomer = new Groomer();
            DataSet ds = new DataSet();
            ds = objgroomer.GetGroomerAppointmentDetails(Convert.ToInt32(Request.QueryString["DailyLogID"].ToString()));

            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdGroomer.DataSource = ds;
                GrdGroomer.DataBind();
            }

        }
        protected void lnkNorec_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExportToExcel.aspx");
        }
    }
}