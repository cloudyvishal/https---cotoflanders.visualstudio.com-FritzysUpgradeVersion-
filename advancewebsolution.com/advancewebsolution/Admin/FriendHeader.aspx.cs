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
/* Page is use to manage friends header countaint using fckeditor */
public partial class Admin_FriendHeader : System.Web.UI.Page
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
    /* Bind the FCK Editor with friend hader htm file in FCK editor and also update the file*/
    protected void BindFckEditor()
    {
        FCKeditor2.ImageBrowserURL = Session["HmePath"] + "FCKeditor/FCKeditor/editor/filemanager/browser/default/browser.html?Type=Images&Connector=connectors/aspx/connector.aspx";
        FCKeditor2.BasePath = "~/FCKeditor/FCKeditor/";
        string FileName = "Friend.htm";
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
    /* Save the file countaint in */
    protected void SaveFile(string StrContent)
    {
        string Fullpath = Session["HomePath"] + "StoreData/Friend.htm";
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
        Response.Redirect("~/Admin/AdminHome.aspx");
    }
    #endregion
}
