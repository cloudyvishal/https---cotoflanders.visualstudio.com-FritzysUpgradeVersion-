using advancewebtosolution.BO;
using System;
using System.Data;
using System.Web.UI.WebControls;


public partial class Search : System.Web.UI.Page
{
    PagedDataSource PageDs = new PagedDataSource();
    PagedDataSource PageDsProd = new PagedDataSource();
    private void BindData()
    {
        StoreFront ObjService = new StoreFront();
        DataSet DS = new DataSet();
        DS = ObjService.GetServiceSearch(Request.QueryString["Key"].ToString());
        try
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                lblTitle.Text = "Fritzy's Pet Care Pros offer the following services :";
                int currpage;
                PageDs.DataSource = DS.Tables[0].DefaultView;
                PageDs.AllowPaging = true;
                PageDs.PageSize = 10;

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
                    lnkPrev.Visible = false;
                    lnkNext.Visible = true;

                }
                else if (PageDs.IsLastPage)
                {
                    check = true;
                    lnkPrev.Visible = true;
                    lnkNext.Visible = false;
                }
                if (PageDs.PageCount == 1)
                {
                    lnkPrev.Visible = false;
                    lnkNext.Visible = false;
                    lnkPrev.CssClass = "linkDisable";
                    lnkNext.CssClass = "linkDisable";
                }
                else if (PageDs.PageCount > 1 && check == false)
                {
                    lnkPrev.Visible = true;
                    lnkNext.Visible = true;
                }


                if (DS.Tables[0].Rows.Count == 0)
                {
                    dlService.Visible = false;
                }
                else
                {
                    Session["PDSAllNewestProviders"] = PageDs;
                    dlService.DataSource = PageDs;
                    dlService.DataBind();
                }
                if ((lnkPrev.Visible == true) && (lnkNext.Visible == true))
                {
                    lblLine.Visible = true;
                }
                else
                {
                    lblLine.Visible = false;
                }
            }
            else
            {
                dlService.Visible = false;
                lnkPrev.Visible = false;
                lnkNext.Visible = false;
                lblLine.Visible = false;
                lblTitle.Text = "No record found.";
            }
        }
        catch
        {
        }

    }
    protected void lnkPrev_Click(object sender, EventArgs e)
    {
        PageDs = (PagedDataSource)Session["PDSAllNewestProviders"];
        if (!PageDs.IsFirstPage)
        {
            int currPage = (Convert.ToInt32(ViewState["CurrentPage"])) - 1;
            ViewState["CurrentPage"] = currPage.ToString();
            BindData();

        }
    }
    protected void lnkNext_Click(object sender, EventArgs e)
    {
        PageDs = (PagedDataSource)Session["PDSAllNewestProviders"];
        if (!PageDs.IsLastPage)
        {
            int currPage = (Convert.ToInt32(ViewState["CurrentPage"])) + 1;
            ViewState["CurrentPage"] = currPage.ToString();
            BindData();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            BindProduct();
        }
    }
    protected void dlService_ItemDataBound(object sender, DataListItemEventArgs e)
    {

    }

    private void BindProduct()
    {
        StoreFront ObjService = new StoreFront();
        DataSet DS = new DataSet();
        DS = ObjService.GetProductSearch(Request.QueryString["Key"].ToString());
        try
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                lblProdTitle.Text = "Fritzy's Pet Care Pros offer the following products :";
                int currpage;
                PageDsProd.DataSource = DS.Tables[0].DefaultView;
                PageDsProd.AllowPaging = true;
                PageDsProd.PageSize = 10;

                if (ViewState["CurrentPage_Prod"] != null)
                {
                    currpage = Convert.ToInt32(ViewState["CurrentPage_Prod"]);
                }
                else
                {
                    currpage = 1;
                }
                ViewState["CurrentPage_Prod"] = currpage;
                PageDsProd.CurrentPageIndex = currpage - 1;

                bool check = false;
                if (PageDsProd.IsFirstPage)
                {
                    check = true;
                    lnkProdPrev.Visible = false;
                    lnkProdNext.Visible = true;

                }
                else if (PageDsProd.IsLastPage)
                {
                    check = true;
                    lnkProdPrev.Visible = true;
                    lnkProdNext.Visible = false;
                }
                if (PageDsProd.PageCount == 1)
                {
                    lnkProdPrev.Visible = false;
                    lnkProdNext.Visible = false;
                    lnkProdPrev.CssClass = "linkDisable";
                    lnkProdNext.CssClass = "linkDisable";
                }
                else if (PageDsProd.PageCount > 1 && check == false)
                {
                    lnkProdPrev.Visible = true;
                    lnkProdNext.Visible = true;
                }
                if (DS.Tables[0].Rows.Count == 0)
                {
                    dlProducts.Visible = false;
                }
                else
                {
                    Session["PDSAllProducts"] = PageDsProd;
                    dlProducts.DataSource = PageDsProd;
                    dlProducts.DataBind();
                }
                if ((lnkProdPrev.Visible == true) && (lnkProdNext.Visible == true))
                {
                    lblProdLine.Visible = true;
                }
                else
                {
                    lblProdLine.Visible = false;
                }
            }
            else
            {
                dlProducts.Visible = false;
                lnkProdPrev.Visible = false;
                lnkProdNext.Visible = false;
                lblProdLine.Visible = false;
                lblProdTitle.Text = "No record found.";
            }
        }
        catch 
        {
        }
    }
    protected void lnkProdPrev_Click(object sender, EventArgs e)
    {
        PageDsProd = (PagedDataSource)Session["PDSAllProducts"];
        if (!PageDsProd.IsFirstPage)
        {
            int currPage = (Convert.ToInt32(ViewState["CurrentPage_Prod"])) - 1;
            ViewState["CurrentPage_Prod"] = currPage.ToString();
            BindProduct();
        }
    }
    protected void lnkProdNext_Click(object sender, EventArgs e)
    {
        PageDsProd = (PagedDataSource)Session["PDSAllProducts"];
        if (!PageDsProd.IsLastPage)
        {
            int currPage = (Convert.ToInt32(ViewState["CurrentPage_Prod"])) + 1;
            ViewState["CurrentPage_Prod"] = currPage.ToString();
            BindProduct();
        }
    }
}
