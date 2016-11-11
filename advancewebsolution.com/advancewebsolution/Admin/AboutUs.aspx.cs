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
using System.IO;
using advancewebtosolution.BO;

public partial class Admin_AboutUs : System.Web.UI.Page
{
    #region "bindData"

    public void SuccessMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }

    protected void BindFckEditor()
    {
        FCKeditor2.ImageBrowserURL = Session["HomePath"] + "FCKeditor/FCKeditor/editor/filemanager/browser/default/browser.html?Type=Images&Connector=connectors/aspx/connector.aspx";
        FCKeditor2.BasePath = "~/FCKeditor/FCKeditor/";
        string FileName = "AboutUs.htm";
        FCKeditor2.Value = ContentManager.GetRightHandSectionFileContent(FileName).Replace("~", "#");
        FCKeditor2.Height = 300;
        FCKeditor2.Width = 810;
        FCKeditor2.SkinPath = "skins/silver/";
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFckEditor();
        }
    }

    #region "SaveFile"
    protected void SaveFile(string StrContent)
    {
        try
        {
            string Fullpath = Session["HomePath"] + "StoreData/AboutUs.htm";
            string fullpath2 = ContentManager.GetPhysicalPath(Fullpath);
            FileStream file = new FileStream(fullpath2, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(StrContent);
            sw.Close();
            file.Close();
            SuccessMessage("Your content has been saved. ");
        }
        catch  { }
    }
    #endregion

    #region "Save Btn"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveFile(FCKeditor2.Value);
    }
    #endregion 
   
    #region "cancelBtn"
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHome.aspx");
    }
    #endregion
}
