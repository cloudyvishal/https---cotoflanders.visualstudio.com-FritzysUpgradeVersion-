using System;
using System.Data;
using advancewebtosolution.BO;

public partial class Admin_ContactUsDetail : System.Web.UI.Page
{
    public void Bind(int ContatID)
    {
        Global Obj_Global = new Global();
        DataSet ds = new DataSet();
        ds = Obj_Global.GetContactInfo(ContatID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblFName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            lblLName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            lblPhone.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            lblMessage.Text = ds.Tables[0].Rows[0]["Message"].ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int ContatID = 0;
            if (Request.QueryString["ID"].ToString() != "")
            {
                ContatID = int.Parse(Request.QueryString["ID"].ToString());
                Bind(ContatID);

            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["p"].ToString() == "1")
            Response.Redirect("AdminHome.aspx");
        else
            Response.Redirect("ContactUs.aspx?SearchFor=0&SearchText=");
    }
}
