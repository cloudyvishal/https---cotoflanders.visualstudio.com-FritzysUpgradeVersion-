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
//using System.Web.UI.WebControls.Literal;

public partial class MB_ServiceDetails : System.Web.UI.Page
{
//protected System.Web.UI.WebControls.Literal litContent;
    public void BindData(int ServiceID, int PageID)
    {
        try
        {
            StoreFront ObjService = new StoreFront();
            DataSet ds = new DataSet();
            ds = ObjService.GetServiceDetailFront(ServiceID, PageID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (PageID == 1)
                {
                    ImgService.ImageUrl = Session["HomePath"] + "StoreData/Images/" + ds.Tables[0].Rows[0]["Image"].ToString();
                    lblTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                    litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/" + ds.Tables[0].Rows[0]["PageName"].ToString()));
                }
                if (PageID == 2)
                {
                    ImgService.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[0]["Image"].ToString();
                    lblTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                }
                if (PageID == 3)
                {
                    ImgService.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["Image"].ToString();
                    lblTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int ServiceID = Convert.ToInt32(Request.QueryString["ID"].ToString());
            int PageID = Convert.ToInt32(Request.QueryString["Page"].ToString());
            BindData(ServiceID, PageID);
        }
    }
}
