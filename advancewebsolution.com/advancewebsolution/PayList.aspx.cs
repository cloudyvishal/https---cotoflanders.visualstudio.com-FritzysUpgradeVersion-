using System;
using System.Data;
using advancewebtosolution.BO;

public partial class PayList : System.Web.UI.Page
{
    StoreFront ObjStoreFront = new StoreFront();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!(null == Request.QueryString["msg"]))
            {
                string s = Request.QueryString["msg"].ToString();
                lblsmsg.Visible = true;
            }
        }
    }

    public void bindSyncLink()
    {
        DataSet ds = new DataSet();
        if (!(null == Session["UserName"]))
        {
            ds = ObjStoreFront.GetAppInfoforPayment(Session["UserName"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnSycAppLink.Enabled = true;
            }
            else
            {
                btnSycAppLink.Enabled = false;
            }
        }
    }


    protected void btnSycAppLink_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PaymentInfo.aspx");
    }
}
