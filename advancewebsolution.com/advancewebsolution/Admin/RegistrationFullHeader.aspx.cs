using System;
using System.IO;
using advancewebtosolution.BO;

public partial class Admin_RegistrationFullHeader : System.Web.UI.Page
{
    #region "bindData"
    /* Error message and success messages are use to display messages to user*/
    public void SuccessMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    /* Function to bind FCK Editor containt */
    protected void BindFckEditor()
    {
        FCKeditor2.ImageBrowserURL = Session["HomePath"] + "FCKeditor/FCKeditor/editor/filemanager/browser/default/browser.html?Type=Images&Connector=connectors/aspx/connector.aspx";
        FCKeditor2.BasePath = "~/FCKeditor/FCKeditor/";
        string FileName = "Registratio_Full.htm";
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
    //function to save file of content 
    protected void SaveFile(string StrContent)
    {
        string Fullpath = Session["HomePath"] + "StoreData/Registratio_Full.htm";
        string fullpath2 = ContentManager.GetPhysicalPath(Fullpath);
        FileStream file = new FileStream(fullpath2, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(StrContent);
        sw.Close();
        file.Close();
        SuccessMessage("Your content has been saved. ");
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
