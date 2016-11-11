using advancewebtosolution.BO;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Admin_EditMeta : System.Web.UI.Page
{
    /* Error message and success messages are use to display messages to user*/
    public void ErrMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    public void SuccesfullMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }


    public void Bind(int MetaID)
    {
        DataSet ds = new DataSet();
        Global ObjGlobal = new Global();
        ds = ObjGlobal.GetMetaDetail(MetaID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtName .Text = ds.Tables[0].Rows[0]["Name"].ToString();
            txtContent.Text = ds.Tables[0].Rows[0]["MetaContent"].ToString();
            txtKeywords.Text = ds.Tables[0].Rows[0]["Keywords"].ToString();
        }
        else
        {

        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["MetaID"] != "")
            {
                int UserID = int.Parse(Request.QueryString["MetaID"]);
                Bind(UserID);
            }
            else
            {
                Response.Redirect("MetaTag.aspx?SearchFor=0&SearchText=");
            }
        }
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Global ObjUser = new Global();
        ObjUser.UpdateMeta(int.Parse(Request.QueryString["MetaID"]), txtName.Text.Trim(), txtContent.Text.Trim(),txtKeywords.Text.Trim());
        SuccesfullMessage("Meta tag updated successfully.");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MetaTags.aspx?PageID="+ Request.QueryString["PageID"].ToString()+ "&SearchFor=0&SearchText=");
    }
}
