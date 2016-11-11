using advancewebtosolution.BO;
using System;
using System.Data;


public partial class Admin_Groomer_EditGroomer : System.Web.UI.Page
{
    int GID;
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
        if (Request.QueryString["GID"] != null)
        {
            GID = Convert.ToInt32(Request.QueryString["GID"].ToString());
        }
        if (!IsPostBack)
        {
            GetGroomer();
        }
    }

    public void GetGroomer()
    {
        Groomer objGroomer = new Groomer();
        DataSet ds = new DataSet();
        ds = objGroomer.GetGroomer(GID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtEmailID.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            txtHomePhone.Text = ds.Tables[0].Rows[0]["HomePhone"].ToString();
            txtPersonalCell.Text = ds.Tables[0].Rows[0]["PersonalCellPhone"].ToString();
            txtZipCode.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString();
            txtBaseCity.Text = ds.Tables[0].Rows[0]["BaseCity"].ToString();
            txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
            txtSheetName.Text = ds.Tables[0].Rows[0]["SheetName"].ToString();
            ddlTimeZone.SelectedValue = ds.Tables[0].Rows[0]["GTimeZone"].ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Groomer ObjGroomer = new Groomer();
        int Count = ObjGroomer.UpdateGroomer(GID, txtEmailID.Text.Trim(), txtName.Text.Trim(), txtAddress.Text.Trim(), txtHomePhone.Text.Trim(), txtPersonalCell.Text.Trim(), txtZipCode.Text, txtBaseCity.Text, txtState.Text, txtSheetName.Text, ddlTimeZone.SelectedValue);
        if (Count == 2)
        {
            SuccesfullMessage("Groomer updated successfully.");
        }
        if (Count == 0)
        {
            ErrMessage("Duplicate emailid.");
        }
        if (Count == 1)
        {
            ErrMessage("Duplicate sheet name.");
        }

    }

}

