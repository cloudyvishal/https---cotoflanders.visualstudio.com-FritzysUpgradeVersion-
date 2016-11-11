using System;
using advancewebtosolution.BO;

public partial class Admin_News_AddNews : System.Web.UI.Page
{

    #region
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
    protected void BindFckEditor()
    {
        FCKeditor2.Height = 500;
        FCKeditor2.Width = 640;
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
    protected void AddNews_Click(object sender, EventArgs e)
    {
        Global ObjNews = new Global();
        ObjNews.AddNews(txtTitle.Text.Trim(), txtShortDesc.Text.Trim(), FCKeditor2.Value);
        SuccessMessage("News Added successfully.");
        txtShortDesc.Text = "";
        txtTitle.Text = "";
        FCKeditor2.Value = "";
        SuccessMessage("News added successfully.");
    }
}
