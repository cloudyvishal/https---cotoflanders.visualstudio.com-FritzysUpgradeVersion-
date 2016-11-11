using advancewebtosolution.BO;
using System;
using System.Data;
using System.Web.UI.WebControls;

/*
 
 
 CAt service control use when user type is 1 that is user is intersted in only dog
 when user register from there we descide that user type 
 
  This control will countain one header service which is set from the admin
  and remain all top 8 services will display in datalist.
  all the content of services will manage from admin side 
 
   On clicking service will redirect to the service detail page 
 
 
 */
public partial class Controls_Service_Dog : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            BindHeader();
        }
    }

    #region Links
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

    #region Bind data
    PagedDataSource PageDs = new PagedDataSource();
    public void BindData()
    {
        try
        {
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
            if (ds.Tables[3].Rows.Count > 0)
            {

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void BindHeader()
    {
        try
        {
            StoreFront ObjStoreFront = new StoreFront();
            DataSet ds = new DataSet();
            ds = ObjStoreFront.GetServicePageServices(Convert.ToInt32(Session["UserType"].ToString()), 2);
            if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "2"))
            {
                imgDogservice.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
                imgDogservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();
                divDogService.InnerHtml = ds.Tables[0].Rows[0]["Description"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
}
