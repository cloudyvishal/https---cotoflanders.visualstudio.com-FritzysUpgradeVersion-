using advancewebtosolution.BO;
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

public partial class Admin_ChangePassword : System.Web.UI.Page
{

    /* Error message and success messages are use to display messages to user*/
    public void ErrMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    public void SuccesfullMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnApply_Click(object sender, EventArgs e)
    {
        Global ObjGlobal = new Global();
        int i =  ObjGlobal.ChangeUserName(Convert.ToInt32(Session["AdminID"].ToString()), txtCurrentPassword.Text.Trim(), txtNewPassword.Text.Trim() );
        if (i == 0)
        {
            ErrMessage("Please enter correct password.");

        }
        else
        {
            SuccesfullMessage("Password changed successfully.");
        }
    }

}
