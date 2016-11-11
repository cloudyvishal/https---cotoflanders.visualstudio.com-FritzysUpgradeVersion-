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

public partial class Admin_UserAccess : System.Web.UI.Page
{
    public void BindData()
    {
        Global Glo = new Global();
        DataSet ds = new DataSet();
        ds = Glo.GetAllUserType();
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdAccess.DataSource = ds.Tables[0];
            grdAccess.DataBind();
            btnDelete.Visible = true;
            btnStatus.Visible = true;
            CheckAll();
            check();
            Utility.Setserial(grdAccess, "srno");
            grdAccess.Visible = true;
        }
        else
        {
            btnDelete.Visible = false;
            btnStatus.Visible = false;
            grdAccess.Visible = false;
            lblError.Text = "No record found";
        }
    }

    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)grdAccess.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in grdAccess.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in grdAccess.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            str = str + "document.getElementById('" + chk1.ClientID + "').checked=false;";
        }
        str = str + "}}";
        Page.ClientScript.RegisterStartupScript(GetType(), "sss", str, true);
    }

    protected void check()
    {
        string checkid = "";
        checkid += "function val(id){";
        checkid += "var flg=0;";

        foreach (GridViewRow grv in grdAccess.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select Atleast One User Access ');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Delete Selected User Access(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Change Status of User Type(s) ?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        //btnactdeact.Attributes.Add("onclick", "return val(0);");
        btnDelete.Attributes.Add("onclick", "return val(1);");
        btnStatus.Attributes.Add("onclick", "return val(2);");

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    public void ErrorMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }

    public void SuccessMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }


    protected void ImgSubmitService_Click(object sender, EventArgs e)
    {
        Global ObjAccess = new Global();
        int count  = ObjAccess.AddUserAccess(Convert.ToInt32(ddlUserType.SelectedValue), ddlModule.SelectedValue, ddlModule.SelectedItem.Text);
        if (count == 0)
        {
            ErrorMessage("Duplicate entry");
        }
        else
        {
            SuccessMessage("Access added successfully");
        }
        BindData();
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string AccessID = Utility.GetCheckedRow(grdAccess, "chkSelect");
        if (AccessID != "")
        {
            Global ObjGlo = new Global();
            ObjGlo.DeleteUserAccess(AccessID);
            BindData();
        }
    }
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        string AccessID = Utility.GetCheckedRow(grdAccess, "chkSelect");
        if (AccessID != "")
        {
            Global ObjGlo = new Global();
            ObjGlo.ChangeUserAccess(AccessID);
            BindData();
        }
    }
    protected void grdAccess_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAccess.PageIndex = e.NewPageIndex;
        BindData();
    }
}
