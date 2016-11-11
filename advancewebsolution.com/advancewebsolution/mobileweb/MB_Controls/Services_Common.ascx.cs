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
/*


common services  service control use when user type is 3 that is user is intersted in cat and dog 
when user register from there we descide that user type 

This control will countain one header service which is set from the admin
and remain all top 8 services will display in datalist.
all the content of services will manage from admin side 

On clicking service will redirect to the service detail page 


*/
public partial class Controls_Services_Common : System.Web.UI.UserControl
{
    #region Bind data
    PagedDataSource PageDs = new PagedDataSource();
    PagedDataSource PageDsCat = new PagedDataSource();
    public void BindData()
    {
        try
        {
            // Dataset will countain 4 table 0 - all cat services,
            // Table 1 - all dog services, 
            // Table 2 - Dog main service which is displayed on homepage 
            // Table 3 - cat main service which is displayed on homepage

            #region Dog
            StoreFront ObjService = new StoreFront();
            DataSet ds = new DataSet();
            ds = ObjService.GetAllCatDogService();
            if (ds.Tables[1].Rows.Count > 0)
            {
                int currpage;
                PageDs.DataSource = ds.Tables[1].DefaultView;
                PageDs.AllowPaging = true;
                PageDs.PageSize = 50;

                if (ViewState["CurrentPage"] != null)
                {
                    currpage = Convert.ToInt32(ViewState["CurrentPage"]);
                }
                else
                {
                    currpage = 1;
                }
                ViewState["CurrentPage"] = currpage;
                PageDs.CurrentPageIndex = currpage - 1;

                bool check = false;
                if (PageDs.IsFirstPage)
                {
                    check = true;

                }
                else if (PageDs.IsLastPage)
                {
                    check = true;
                }
                if (PageDs.PageCount == 1)
                {
                }
                else if (PageDs.PageCount > 1 && check == false)
                {
                }
                if (ds.Tables[1].Rows.Count == 0)
                {
                    dlDog.Visible = false;
                }
                else
                {
                    Session["PDSAllNewestProviders"] = PageDs;
                    dlDog.DataSource = PageDs;
                    dlDog.DataBind();
                }
            }
            else
            {
                dlDog.Visible = false;
            }

            #endregion Dg

            #region Cat
            if (ds.Tables[0].Rows.Count > 0)
            {
                int currpage;
                PageDsCat.DataSource = ds.Tables[0].DefaultView;
                PageDsCat.AllowPaging = true;
                PageDsCat.PageSize = 50;

                if (ViewState["CurrentPage_Cat"] != null)
                {
                    currpage = Convert.ToInt32(ViewState["CurrentPage_Cat"]);
                }
                else
                {
                    currpage = 1;
                }
                ViewState["CurrentPage_Cat"] = currpage;
                PageDsCat.CurrentPageIndex = currpage - 1;

                bool check = false;
                if (PageDsCat.IsFirstPage)
                {
                    check = true;

                }
                else if (PageDsCat.IsLastPage)
                {
                    check = true;
                }
                if (PageDsCat.PageCount == 1)
                {
                    
                }
                else if (PageDsCat.PageCount > 1 && check == false)
                {
                    
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    dlCat.Visible = false;
                }
                else
                {
                    Session["PDSAllNewestProviders_Cat"] = PageDsCat;
                    dlCat.DataSource = PageDsCat;
                    dlCat.DataBind();
                }

            }
            else
            {
                dlCat.Visible = false;
            }

            #endregion

            #region Header Services

            StoreFront ObjStoreFront = new StoreFront();
            DataSet ds_Service = new DataSet();
            ds_Service = ObjStoreFront.GetAllServicePageServices(Convert.ToInt32(Session["UserType"].ToString()));

            if (ds_Service.Tables[1].Rows.Count > 0)
            {
                ImgDog.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds_Service.Tables[1].Rows[0]["ImageName"].ToString();
                ImgDog.ToolTip = ds_Service.Tables[1].Rows[0]["Description"].ToString();
                divDogService.InnerText = ds_Service.Tables[1].Rows[0]["Description"].ToString();
            }
            if (ds_Service.Tables[0].Rows.Count > 0)
            {
                imgCatservice.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds_Service.Tables[0].Rows[0]["ImageName"].ToString();
                imgCatservice.ToolTip = ds_Service.Tables[0].Rows[0]["Description"].ToString();
                divCatService.InnerText = ds_Service.Tables[0].Rows[0]["Description"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        #endregion
    }
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    #region Previous Next Cat
    protected void lnkPrev_Cat_Click(object sender, EventArgs e)
    {
        try
        {
            PageDsCat = (PagedDataSource)Session["PDSAllNewestProviders_Cat"];
            if (!PageDsCat.IsFirstPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage_Cat"])) - 1;
                ViewState["CurrentPage_Cat"] = currPage.ToString();
                BindData();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkNext_Cat_Click(object sender, EventArgs e)
    {
        try
        {
            PageDsCat = (PagedDataSource)Session["PDSAllNewestProviders_Cat"];
            if (!PageDsCat.IsLastPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage_Cat"])) + 1;
                ViewState["CurrentPage_Cat"] = currPage.ToString();
                BindData();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Prev Next Dog
    protected void lnkPrev_Click(object sender, EventArgs e)
    {
        try
        {
            PageDs = (PagedDataSource)Session["PDSAllNewestProviders"];
            if (!PageDs.IsFirstPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage"])) - 1;
                ViewState["CurrentPage"] = currPage.ToString();
                BindData();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkNext_Click(object sender, EventArgs e)
    {
        try
        {
            PageDs = (PagedDataSource)Session["PDSAllNewestProviders"];
            if (!PageDs.IsLastPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage"])) + 1;
                ViewState["CurrentPage"] = currPage.ToString();
                BindData();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
}
