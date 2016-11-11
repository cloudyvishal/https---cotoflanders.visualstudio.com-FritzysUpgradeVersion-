using advancewebtosolution.BO;
using System;
    public partial class Admin_Groomer_AddGroomer : System.Web.UI.Page
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Groomer ObjGroomer = new Groomer();
            int Count = ObjGroomer.AddGroomer(txtEmailID.Text.Trim(), txtPassword.Text.Trim(), txtName.Text.Trim(), txtAddress.Text.Trim(), txtHomePhone.Text.Trim(), txtPersonalCell.Text.Trim(), txtZipCode.Text, txtSheetName.Text, txtBaseCity.Text, txtState.Text, ddlTimeZone.SelectedValue.ToString());
            if (Count == 2)
            {
                SuccesfullMessage("Groomer added successfully.");
                txtEmailID.Text = "";
                txtPassword.Text = "";
                txtName.Text = "";
                txtAddress.Text = "";
                txtHomePhone.Text = "";
                txtPersonalCell.Text = "";
                txtZipCode.Text = "";
                txtSheetName.Text = "";
                txtState.Text = "";
                txtBaseCity.Text = "";
            }
            if (Count == 0)
            {
                ErrMessage("Duplicate email id.");
            }
            if (Count == 1)
            {
                ErrMessage("Duplicate sheet name.");
            }

        }
    }
