using System;
using System.Data;
using System.Web.UI;
using advancewebtosolution.BO;

public partial class mobileweb_Cat_Service_1 : System.Web.UI.Page
{
    // Need to set
    int ServiceId=87;
    int pageid=1;
    advancewebtosolution.BO.StoreFront ObjService = new advancewebtosolution.BO.StoreFront();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindData(ServiceId, pageid);
            }
        }
        catch(Exception ex) { throw ex; }
    }

    public void BindData(int ServiceID, int PageID)
    {
        DataSet ds = new DataSet();
        ds = ObjService.GetServiceDetailFront(ServiceID, PageID);
        try
        {
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
        catch(Exception ex) { throw ex; }
    }
}
