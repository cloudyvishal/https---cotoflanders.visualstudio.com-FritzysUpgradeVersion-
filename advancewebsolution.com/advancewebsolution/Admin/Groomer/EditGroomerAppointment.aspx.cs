using advancewebtosolution.BO;
using System;
using System.Data;

namespace advancewebtosolution
{
    public partial class Admin_Groomer_EditGroomerAppointment : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGroomers();
                GetGroomersappointment();
            }
        }
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

        public void BindGroomers()
        {
            Groomer objGroomer = new Groomer();
            DataSet ds = new DataSet();
            ds = objGroomer.BindGroomers();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlGroomerlist.DataTextField = "Name";
                ddlGroomerlist.DataValueField = "Gid";
                ddlGroomerlist.DataSource = ds.Tables[0];
                ddlGroomerlist.DataBind();
            }
        }
        public void GetGroomersappointment()
        {
            Groomer objGroomer = new Groomer();
            DataSet ds1 = new DataSet();
            ds1 = objGroomer.GetGroomersdateappointment(Convert.ToInt32(Request.QueryString["AppointmentId"]));
            if (ds1.Tables[0].Rows.Count > 0)
            {
                txtDate.Text = ds1.Tables[0].Rows[0]["AppointmentDate"].ToString();
                txtTotalRevnueExpected.Text = ds1.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString();
               
                ddlGroomerlist.SelectedValue = ds1.Tables[0].Rows[0]["GID"].ToString();
                txtOthers.Text = ds1.Tables[0].Rows[0]["Others"].ToString();
                txtSequence.Text = ds1.Tables[0].Rows[0]["SequenceNo"].ToString();
                txtDate.Text = ds1.Tables[0].Rows[0]["DateTimeFormat"].ToString();

            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Groomer objGroomer = new Groomer();
            DataSet ds2 = new DataSet();
            ds2 = objGroomer.GetGroomersSequence(Session["SelectedDate"].ToString(), Convert.ToInt32(Request.QueryString["AppointmentId"]), Convert.ToInt32(ddlGroomerlist.SelectedValue));
            bool SquenceNo = false;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    if (txtSequence.Text == ds2.Tables[0].Rows[j]["SequenceNo"].ToString())
                    {
                        SquenceNo = true;
                    }
                }
                if (SquenceNo == true)
                {
                    ErrorMessage("Sequence Number already exist.");
                }
                else
                {
                    SuccessMessage("Groomer appointment updated sucessfully");

                }

            }
            else
            {
                SuccessMessage("Groomer appointment updated sucessfully");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewGroomerAppointment.aspx?SearchFor=0&SearchText=");
        }

    }
}