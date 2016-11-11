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

public partial class Admin_ManageEmail : System.Web.UI.Page
{
    public void BindData()
    {
        Global ObjUser = new Global();
        DataSet ds = new DataSet();
        ds = ObjUser.GetAllMail();
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdEmail.DataSource = ds.Tables[0];
            grdEmail.DataBind();
            Utility.Setserial(grdEmail, "srno");
        }
        else
        {

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
}
