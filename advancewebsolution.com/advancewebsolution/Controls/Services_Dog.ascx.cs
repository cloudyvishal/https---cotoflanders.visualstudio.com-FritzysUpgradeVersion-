using System;
using System.Data;
using System.Web.UI.WebControls;
using advancewebtosolution.BO;


    /*


    CAt service control use when user type is 1 that is user is intersted in only dog
    when user register from there we descide that user type 

    This control will countain one header service which is set from the admin
    and remain all top 8 services will display in datalist.
    all the content of services will manage from admin side 

    On clicking service will redirect to the service detail page 


    */
    public partial class Services_Dog : System.Web.UI.UserControl
    {
        #region Bind data
        PagedDataSource PageDs = new PagedDataSource();
        public void BindData()
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
                if ((lnkPrev.Visible == true) && (lnkNext.Visible == true))
                {
                    lblDivider.Visible = true;
                }
                else
                {
                    lblDivider.Visible = false;
                }
            }
            else
            {
                dlDog.Visible = false;
                lnkPrev.Visible = false;
                lnkNext.Visible = false;
            }
            if (ds.Tables[3].Rows.Count > 0)
            {

            }
        }

        public void BindHeader()
        {
            StoreFront ObjStoreFront = new StoreFront();
            DataSet ds = new DataSet();
            if (Request.Cookies["IsLogin"].Value.ToString() == "0")
                ds = ObjStoreFront.GetServicePageServices(0, 2);
            else
                ds = ObjStoreFront.GetServicePageServices(Convert.ToInt32(Session["UserType"].ToString()), 2);
            if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "2"))
            {
                imgDogservice.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
                imgDogservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();
                divDogService.InnerText = ds.Tables[0].Rows[0]["Description"].ToString();
            }
        }
        #endregion
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
        #endregion
    }
