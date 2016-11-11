using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
{

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
        if (!(null == Session["Style"]))
            stylesheet.Href = Convert.ToString(Session["Style"]);
        if (!(IsPostBack))
            if (Request.QueryString.Count > 0)
                if (!(null == Request.QueryString["Msg"]))
                    if (Request.QueryString["Msg"].Equals("Timeout"))
                        ErrMessage("Your Session has been expired. Please Login Again");
        txtUsername.Focus();
    }


    protected void btnSignin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
                ErrMessage("Please Enter UserName/Password.");
            else
            {
                Groomer ObjUser = new Groomer();
                DataSet ds = ObjUser.GetGroomerUser(txtUsername.Text, txtPassword.Text);
                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["GroomerUserName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                        Session["GId"] = ds.Tables[0].Rows[0]["GId"].ToString();
                        Session["UserTimeZone"] = ds.Tables[0].Rows[0]["GTimeZone"].ToString();
                        Session["PageFrom"] = "Default.aspx";
                        Response.Redirect("Dashboard.aspx", false);
                    }
                    else ErrMessage("Please verify your username and password");

            }
        }
        catch
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}
