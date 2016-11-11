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
using System.IO;

public partial class ManageProfile : System.Web.UI.Page
{
    Groomer ObjUser = new Groomer();
    static string currPass = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                GroomerGetProfile();
            }
            catch 
            {

            }
        }
    }

    private int GId
    {
        get
        {
            if (Session["GId"] != null)
            {
                return int.Parse(Session["GId"].ToString());
            }
            else
                return 0;
        }
    }

    public void GroomerGetProfile()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = ObjUser.GroomerGetProfile(GId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtEmailID.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtHomePhone.Text = ds.Tables[0].Rows[0]["HomePhone"].ToString();
                txtPersonalCellPhone.Text = ds.Tables[0].Rows[0]["PersonalCellPhone"].ToString();
                txtCurrentPassword.Text = ds.Tables[0].Rows[0]["password"].ToString().Trim();
                currPass = ds.Tables[0].Rows[0]["password"].ToString().Trim();
                txtBaseCity.Text = ds.Tables[0].Rows[0]["BaseCity"].ToString().Trim();
                txtState.Text = ds.Tables[0].Rows[0]["State"].ToString().Trim();
                txtZipcode.Text = ds.Tables[0].Rows[0]["Zipcode"].ToString().Trim();
                lblTimeZone.Text  = ds.Tables[0].Rows[0]["GTimeZone"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void GroomerUpdateProfile()
    {
        try
        {
            if (currPass == txtCurrentPassword.Text.Trim())
            {
                if (txtCurrentPassword.Text.Trim() == txtNewPassword.Text.Trim()) { ErrMessage("New Password cant be a Current password"); }
                else
                {
                    if (txtNewPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
                    {
                        ObjUser.GroomerUpdateProfile(GId, txtEmailID.Text, txtNewPassword.Text.Trim(), txtName.Text, txtAddress.Text, txtHomePhone.Text, txtPersonalCellPhone.Text, txtBaseCity.Text, txtState.Text, txtZipcode.Text);
                        GroomerGetProfile();
                        SuccesfullMessage("Password updated successfully");
                    }
                    else { ErrMessage("Confirm Password Not matches with New Password"); }

                }
            }
            else { ErrMessage("Current Password is wrong!!!"); }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            GroomerUpdateProfile();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void btnProfile_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUser.GroomerUpdateProfile(GId, txtEmailID.Text, "", txtName.Text, txtAddress.Text, txtHomePhone.Text, txtPersonalCellPhone.Text, txtBaseCity.Text, txtState.Text, txtZipcode.Text);
            SuccesfullMessage("Profile updated successfully");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

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
}
