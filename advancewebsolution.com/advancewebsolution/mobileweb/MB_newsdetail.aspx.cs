using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using advancewebtosolution.BO;

public partial class Mobile_MB_newsdetail : System.Web.UI.Page
{
    public void BindData()
    {
        try
        {
            StoreFront ObjNews = new StoreFront();
            DataSet ds = new DataSet();
            ds = ObjNews.GetNewsFront(Convert.ToInt32(Request.QueryString["ID"].ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblnewstitle.Text = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
                litContent.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            }
        }
        catch(Exception ex) { throw ex; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }

    }
}
