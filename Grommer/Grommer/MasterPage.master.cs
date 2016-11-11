using System;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try {
            stylesheet.Href = Convert.ToString(Session["Style"]);
            if (Session["GId"]!=null && Session["GroomerUserName"]!=null)
                lblname.Text = Session["GroomerUserName"].ToString();
            else Response.Redirect("Default.aspx?Msg=Timeout", false);
        }
        catch
        {
            stylesheet.Href= "themes/screen.css";
        }
    }

    public void btnLogOut_OnServerClick(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Default.aspx");
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
}
