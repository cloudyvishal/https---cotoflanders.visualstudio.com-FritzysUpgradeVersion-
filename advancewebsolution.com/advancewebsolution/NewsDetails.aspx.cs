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

public partial class NewsDetails : System.Web.UI.Page
{
     /*
        Bind Data is used to bind all news detail of releated news (request query string NewsID )
     */
    public void BindData()
    {
        StoreFront ObjNews = new StoreFront();
        DataSet ds = new DataSet();
        ds = ObjNews.GetNewsFront(Convert.ToInt32(Request.QueryString["ID"].ToString()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblNewsTitle.Text = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
            litContent.Text = ds.Tables[0].Rows[0]["Description"].ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }

    }
}
