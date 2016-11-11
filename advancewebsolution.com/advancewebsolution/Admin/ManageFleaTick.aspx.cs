using advancewebtosolution.BO;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageFleaTick : System.Web.UI.Page
{
    advancewebtosolution.BO.Services ObjService = new advancewebtosolution.BO.Services();
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

    private void BindGrid()
    {
        DataSet ds = new DataSet();
        ds = ObjService.GetFleaServices();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdServiceHome.Visible = true;
            btnRemove.Visible = true;

            GrdServiceHome.DataSource = ds.Tables[0];
            GrdServiceHome.DataBind();
            CheckAll();
            check();
            Utility.Setserial(GrdServiceHome, "srno");
        }
        else
        {
            GrdServiceHome.Visible = false;
            divError.Visible = true;
            ErrMessage("Please set service for home page(active service only) ");
            btnRemove.Visible = false;
        }

        ViewState["Cat"] = "False";
        ViewState["Dog"] = "False";
        ViewState["CatID"] = "";
        ViewState["DogID"] = "";


        if (ds.Tables[0].Rows.Count > 0)
            ViewState["Cat"] = "False";
        if (ds.Tables[1].Rows.Count > 0)
            ViewState["Dog"] = "False";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["ServiceType"].ToString() == "0")
            {
                ViewState["Cat"] = "True";
                ViewState["CatID"] = ds.Tables[0].Rows[i]["ServiceID"].ToString();

            }
            if (ds.Tables[0].Rows[i]["ServiceType"].ToString() == "1")
            {
                ViewState["Dog"] = "True";
                ViewState["DogID"] = ds.Tables[0].Rows[i]["ServiceID"].ToString();
            }

        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlCat.DataTextField = "ServiceTitle";
            ddlCat.DataValueField = "ServiceID";
            ddlCat.DataSource = ds.Tables[1];
            ddlCat.DataBind();
            divCat.Visible = true;
            ListItem lst = new ListItem();
            lst.Text = "Select One";
            lst.Value = "0";
            ddlCat.Items.Insert(0, lst);
            if (ViewState["CatID"].ToString() != "")
            {
                ddlCat.SelectedValue = ViewState["CatID"].ToString();
            }
            else
            {
                ddlCat.SelectedValue = "0";
            }
        }
        else
        {
            divCat.Visible = false;
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            ddlDog.DataTextField = "ServiceTitle";
            ddlDog.DataValueField = "ServiceID";
            ddlDog.DataSource = ds.Tables[2];
            ddlDog.DataBind();
            divDog.Visible = true;
            ListItem lst = new ListItem();
            lst.Text = "Select One";
            lst.Value = "0";
            ddlDog.Items.Insert(0, lst);
            if (ViewState["DogID"].ToString() != "")
            {
                ddlDog.SelectedValue = ViewState["DogID"].ToString();
            }
            else
            {
                ddlDog.SelectedValue = "0";
            }
        }
        else
        {
            divDog.Visible = false;
        }
    }

    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)GrdServiceHome.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in GrdServiceHome.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in GrdServiceHome.Rows)
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

        foreach (GridViewRow grv in GrdServiceHome.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select Atleast One service');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Remove Selected service(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Change Status of service(s) ?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        btnRemove.Attributes.Add("onclick", "return val(1);");

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= GrdServiceHome.Rows.Count - 1; i++)
        {
            CheckBox chk = (CheckBox)GrdServiceHome.Rows[i].FindControl("chkSelect");
            if (chk.Checked)
            {
                advancewebtosolution.BO.Services ObjService = new advancewebtosolution.BO.Services();
                Label lblServiceID = (Label)GrdServiceHome.Rows[i].FindControl("lblServiceID");
                Label lblServiceType = (Label)GrdServiceHome.Rows[i].FindControl("lblServiceType");
                if (lblServiceType.Text == "0")
                {
                    ObjService.UpdateIsHome(Convert.ToInt32(lblServiceID.Text), 0);
                    ViewState["Cat"] = "False";
                }
                else
                {
                    ObjService.UpdateIsHome(Convert.ToInt32(lblServiceID.Text), 1);
                    ViewState["Dog"] = "False";
                }
            }
        }

        BindGrid();
    }

    protected void btnDog_Click(object sender, EventArgs e)
    {
        if (ViewState["Dog"].ToString() == "True")
        {
            divError.Visible = true;
            ErrMessage("Only one dog service can be added");
        }
        else
        {
            ObjService.SetServiceFlea(Convert.ToInt32(ddlDog.SelectedValue));
            ViewState["Dog"] = "True";
            divError.Visible = false;

        }
        BindGrid();
    }

    protected void btnCat_Click(object sender, EventArgs e)
    {
        if (ViewState["Cat"].ToString() == "True")
        {
            divError.Visible = true;
            ErrMessage("Only one cat service can be added");
        }
        else
        {
            ObjService.SetServiceFlea(Convert.ToInt32(ddlCat.SelectedValue));
            ViewState["Cat"] = "True";
            divError.Visible = false;

        }
        BindGrid();
    }
}
