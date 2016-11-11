using advancewebtosolution.BO;
using System;

public partial class Admin_Agents_AddAgent : System.Web.UI.Page
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

    protected void AddUser_Click(object sender, EventArgs e)
    {
        try
        {
            User ObjUser = new User();
            int Count = ObjUser.AddAdminUser(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtAddress1.Text.Trim(), txtAddress2.Text.Trim(), 2);
            if (Count == 1)
            {
                SuccesfullMessage("Agent added successfully");
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
            }
            else
            {
                ErrMessage("Duplicate username or Email");
            }
        }
        catch  { }
    }
}
