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

public partial class Admin_StaticWebPages : System.Web.UI.Page
{

    public void BindData()
    {
        Global ObjUser = new Global();
        DataSet ds = new DataSet();
        ds = ObjUser.GetAllPages();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdFileManager.DataSource = ds.Tables[0];
            GrdFileManager.DataBind();
            Utility.Setserial(GrdFileManager, "srno");
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
