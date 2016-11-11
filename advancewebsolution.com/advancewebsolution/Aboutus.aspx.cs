using System;
using System.Data;
using System.Web.UI.WebControls;
using advancewebtosolution.BO;
using System.Web.UI;

public partial class Aboutus : System.Web.UI.Page
    {
        #region "Declare Variables"
        PagedDataSource PageDs = new PagedDataSource();
        #endregion
        /*
            Bind Data function use to bind All news Using Datalist 
        *   Where Page Size is 8 as per req. 
        *   and one Literal control is used to load content of the about us html file where this file can be updated by admin from admin section.
        *   
        */
        protected void BindData()
        {
            Global ObjGlobal = new Global();
            DataSet ds = new DataSet();
            ds = ObjGlobal.GetNewsOnStoreFront();
            if (ds.Tables[0].Rows.Count > 0)
            {
                PageDs.DataSource = ds.Tables[0].DefaultView;
                PageDs.AllowPaging = true;
                PageDs.PageSize = 8;
                dtlNews.DataSource = PageDs;
                dtlNews.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            if (!(null == Session["UserName"]))
            {
                ctlZipcode.Visible = false;
                imgbtnMakePayment.Visible = true;
            }
            else
            {
                ctlZipcode.Visible = true;
                imgbtnMakePayment.Visible = false;
            }
            BindData();
                litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/StaticeContent/AboutUs.htm"));
            }


        }
    protected void imgbtnMakePayment_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/PaymentPrepaid.aspx");
    }
    protected void dtlNews_ItemDataBound(object sender, DataListItemEventArgs e)
        {
        }

    }
