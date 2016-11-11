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

public partial class MB_aboutus : System.Web.UI.Page
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
        try
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
        catch(Exception ex) { throw ex; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                BindData();
                litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/StaticeContent/AboutUs.htm"));
            }
            catch(Exception ex) { throw ex; }
        }


    }
    protected void dtlNews_ItemDataBound(object sender, DataListItemEventArgs e)
    {
    }
}
