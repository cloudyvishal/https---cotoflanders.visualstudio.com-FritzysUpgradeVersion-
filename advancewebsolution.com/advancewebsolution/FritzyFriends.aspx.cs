using System;
using System.Data;
using System.Web.UI;
using advancewebtosolution.BO;

public partial class FritzyFriends : System.Web.UI.Page
{
    /*
        Bind all friend information to the datalist friend from database 
     */
    #region declar 
    public void BindData()
    {
        Global ObjGlobal = new Global();
        DataSet ds = new DataSet();
        ds = ObjGlobal.GetAllFriendFront();
        if (ds.Tables[0].Rows.Count > 0)
        {
            dtlFriends.Visible = true;
            dtlFriends.DataSource = ds.Tables[0];
            dtlFriends.DataBind();
        }
        else
        {
            dtlFriends.Visible = false;

        }

    }
    #endregion
    /*
        Literal control is used to load friend header from Friend.htm file where this file content can be updated by admin section 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/StaticeContent/Friend.htm"));
        }

        if (Session["MemberName"] != null)
        {
            divUserName.Attributes.Add("style", "Display:block");
            lblWelcome.Text = "Welcome - " + Session["MemberName"].ToString();

            DataSet ds = new DataSet();
            if (!(null == Session["UserName"]))
            {
                ctlZipcode.Visible = false;
                imgbtnMakePayment.Visible = true;
            }
            else
            {
                divUserName.Attributes.Add("style", "Display:none");
                ctlZipcode.Visible = true;
                imgbtnMakePayment.Visible = false;
            }
        }
        if (Session["MemberName"] != null)
        {
            ctlZipcode.Visible = false;
            
                imgbtnMakePayment.Visible = true;
        }
        else
        {
            ctlZipcode.Visible = true;
            imgbtnMakePayment.Visible = false;
        }
    }
    protected void imgbtnMakePayment_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/PaymentPrepaid.aspx");
    }
}
