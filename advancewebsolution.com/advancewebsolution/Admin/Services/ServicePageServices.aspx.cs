using advancewebtosolution.BO;
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Services_ServicePageServices : System.Web.UI.Page
{
    #region Bind
    public void BindData()
    {
        ServicePage  ObjHome = new ServicePage();
        DataSet ds = new DataSet();
        ds = ObjHome.GetServicePageAdmin(Convert.ToInt32(ddlUserType.SelectedValue));
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdService.Visible = true;
            GrdService.DataSource = ds.Tables[0];
            GrdService.DataBind();
            Utility.Setserial(GrdService, "srno");
        }
        else
        {
            GrdService.Visible = true;
        }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }
    protected void GrdService_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblImageName = (Label)e.Row.FindControl("lblImageName");
            HtmlImage imgThumb = (HtmlImage)e.Row.FindControl("ImageCoupon");
            string Temp = Session["HomePath"] + "StoreData/ServicePageServices/" + lblImageName.Text;

            string fulpath = ContentManager.GetPhysicalPath(Temp);
            if (System.IO.File.Exists(fulpath))
            {
                imgThumb.Src = Session["HomePath"] + "StoreData/ServicePageServices/" + lblImageName.Text;
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