using System;
using advancewebtosolution.BO;

public partial class Admin_LocationService_AddServiceLocation : System.Web.UI.Page
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
        Global ObjGlobal = new Global();
        int Count = ObjGlobal.AddZipCode(txtZipCode.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(), Convert.ToInt32(ddlStatus.SelectedValue), ddlZipType.SelectedValue.ToString());
        if (Count == 1)
        {
            SuccesfullMessage("Zip Code added successfully");
            txtZipCode.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            
        }
        else
        {
            ErrMessage("Duplicate Zip Code");
        }
    }
}
