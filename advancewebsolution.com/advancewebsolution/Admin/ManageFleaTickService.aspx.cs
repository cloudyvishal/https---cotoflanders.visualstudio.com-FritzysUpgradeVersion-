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


public partial class Admin_ManageFleaTickService : System.Web.UI.Page
{
    #region Bind
    public void BindData()
    {
        HomeServices ObjHome = new HomeServices();
        DataSet ds = new DataSet();
        ds = ObjHome.GetAllFleaTickServiceAdmin(Convert.ToInt32(ddlUserType.SelectedValue));
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdServiceHome.Visible = true;
            GrdServiceHome.DataSource = ds.Tables[0];
            GrdServiceHome.DataBind();
            Utility.Setserial(GrdServiceHome, "srno");
        }
        else
        {
            GrdServiceHome.Visible = true;
        }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }
    protected void GrdServiceHome_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblImageName = (Label)e.Row.FindControl("lblImageName");
            HtmlImage imgThumb = (HtmlImage)e.Row.FindControl("ImageCoupon");
            string Temp = Session["HomePath"] + "StoreData/HomeServices/" + lblImageName.Text;

            string fulpath = ContentManager.GetPhysicalPath(Temp);
            if (System.IO.File.Exists(fulpath))
            {
                imgThumb.Src = Session["HomePath"] + "StoreData/HomeServices/" + lblImageName.Text;
            }
            else
            {
                //imgThumb.Src = Session["HomePath"] + "StoreData/HomeServices/Not.jpg";
            }
        }
    }
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
}
