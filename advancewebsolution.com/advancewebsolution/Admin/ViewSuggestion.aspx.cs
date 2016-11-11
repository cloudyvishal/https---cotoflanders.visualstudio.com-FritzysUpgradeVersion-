using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using advancewebtosolution.BO;

public partial class Admin_ViewSuggestion : System.Web.UI.Page
{

    /* Bind function use to get all contant from database using suggestion ID */
    public void Bind(int SuggestionID)
    {
        Global Obj_Global = new Global();
        DataSet ds = new DataSet();
        ds = Obj_Global.GetSuggestion(SuggestionID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblName.Text = ds.Tables[0].Rows[0]["VisiterName"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            lblPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            lblComment.Text = ds.Tables[0].Rows[0]["Comment"].ToString();

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int SuggestionID = 0;
            if (Request.QueryString["SuggestionID"].ToString() != "")
            {
                SuggestionID = int.Parse(Request.QueryString["SuggestionID"].ToString());
                Bind(SuggestionID);

            }
        }
    }
}
