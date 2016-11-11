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
using System.IO;
using advancewebtosolution.BO;

public partial class Admin_ViewEmail : System.Web.UI.Page
{

    public void SuccessMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string FileName = Request.QueryString["File"].ToString();
        if (FileName == "Appointment.htm")
        {
            Page.Title = "View - Appointment Mail";
            lblHead.Text = "Appointment";
        }
        else if (FileName == "ContactUs.htm")
        {
            lblHead.Text = "Contact Us ";
            Page.Title = "View - Contact Us Mail";
        }
        else if (FileName == "ForgotPassword.htm")
        {
            lblHead.Text = "Forgot Password";
            Page.Title = "View - Forgot Password Mail";
        }
        else if (FileName == "Registration.htm")
        {
            lblHead.Text = "Registration";
            Page.Title = "View - Registration Mail";
        }
        else if (FileName == "Suggestion.htm")
        {
            lblHead.Text = "Suggestion";
            Page.Title = "View - Suggestion Mail";
        }


        ViewState["FileName"] = FileName;

        if (!IsPostBack)
        {
            BindFckEditor();
            BindSubject();
        }


    }
    public void BindSubject()
    {
        Global ObjSubjec = new Global();
        DataSet ds_Subject = ObjSubjec.GetEmailSubject(Request.QueryString["File"].ToString());
        txtSubject.Text = ds_Subject.Tables[0].Rows[0]["Subject"].ToString();
    }

    protected void BindFckEditor()
    {



        string FileName = ViewState["FileName"].ToString();
        FCKeditor2.Value = ContentManager.GetStaticeContentEmail(FileName).Replace("~", "#");
        FCKeditor2.Height = 300;
        FCKeditor2.Width = 810;
        FCKeditor2.SkinPath = "skins/silver/";
    }
    #region "SaveFile"
    protected void SaveFile(string StrContent)
    {
        Global ObjGlobal = new Global();
        ObjGlobal.UpdateSubject(Request.QueryString["File"].ToString(), txtSubject.Text.Trim());

        string Fullpath = Session["HomePath"] + "StoreData/Email/" + ViewState["FileName"].ToString();
        string fullpath2 = ContentManager.GetPhysicalPath(Fullpath);
        FileStream file = new FileStream(fullpath2, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(StrContent);
        sw.Close();
        file.Close();
        SuccessMessage("Your content has been saved. ");
        BindFckEditor();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveFile(FCKeditor2.Value);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageEmail.aspx");
    }
    #endregion
}
