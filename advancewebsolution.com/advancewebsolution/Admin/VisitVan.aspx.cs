using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using advancewebtosolution.BO;

public partial class Admin_VisitVan : System.Web.UI.Page
{
    #region

    /* Error message and success messages are use to display messages to user*/
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

    public void ErrMessage1(string Message)
    {
        divError1.Visible = true;
        lblError1.Attributes.Add("Class", "errorTable");
        lblError1.Visible = true;
        lblError1.Text = Message;
    }
    public void SuccessMessage1(string Message)
    {
        divError1.Visible = true;
        lblError1.Attributes.Add("Class", "successTable");
        lblError1.Visible = true;
        lblError1.Text = Message;
    }

    /* Check all function is use for gride header checkbox to chaeck all function which is register client script */
    public void CheckAll()
    {
        CheckBox chkall;
        chkall = (CheckBox)GrdVan.HeaderRow.FindControl("chkall");
        chkall.Attributes.Add("onclick", "checkall()");
        string str;
        str = "function checkall()";
        str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
        str = str + "{";
        foreach (GridViewRow gvr in GrdVan.Rows)
        {
            CheckBox checkall;
            checkall = (CheckBox)gvr.FindControl("chkSelect");
            str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
        }
        str = str + "}";
        str = str + "else";
        str = str + "{";
        foreach (GridViewRow grv in GrdVan.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            str = str + "document.getElementById('" + chk1.ClientID + "').checked=false;";
        }
        str = str + "}}";
        Page.ClientScript.RegisterStartupScript(GetType(), "sss", str, true);
    }

    /* Check function is use to check select at least one row of grid which is register client script */
    protected void check()
    {
        string checkid = "";
        checkid += "function val(id){";
        checkid += "var flg=0;";

        foreach (GridViewRow grv in GrdVan.Rows)
        {
            CheckBox chk1;
            chk1 = (CheckBox)grv.FindControl("chkSelect");
            checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
            checkid += "flg=1;}";
        }
        checkid += "if(flg!=1){";
        checkid += "alert('Select Atleast One file');return false;}";
        checkid += "if(flg==1 && id==1){";
        checkid += "if(!confirm('Do You Want To Delete Selected file(s) ?')){return false;}}";
        checkid += "if(flg==1 && id==2){";
        checkid += "if(!confirm('Do You Want To Change Status of file(s) ?')){return false;}}";
        checkid = checkid + "}";
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

        //btnactdeact.Attributes.Add("onclick", "return val(0);");
        btnDelete.Attributes.Add("onclick", "return val(1);");
         

    }
    public void BindFiles()
    {
        String Path = ContentManager.GetPhysicalPath(Session["HomePath"] + "StoreData/VisitVan");
        DirectoryInfo di = new DirectoryInfo(Path);
        FileInfo[] rgFiles = di.GetFiles();
        if (rgFiles.Length > 0)
        {
            GrdVan.Visible = true;
            btnDelete.Visible = true;
            GrdVan.DataSource = rgFiles;
            GrdVan.DataBind();
            CheckAll();
            check();
            Utility.Setserial(GrdVan, "srno");
        }
        else
        {
            GrdVan.Visible = false;
            btnDelete.Visible = false;

            ErrorMessage("Sorry, No records found.");
        }
    }

    #endregion 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFiles();
            BindFckEditor();
        }
    }


    #region Images
    /* Page index changing*/
    protected void GrdVan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdVan.PageIndex = e.NewPageIndex;
        BindFiles();
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        Bitmap bmIP = new Bitmap(fuFile.PostedFile.InputStream);
        if (bmIP.Width > 100 | bmIP.Height > 100)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    /* event for file upload with verification*/
    protected void btnUp_Click(object sender, EventArgs e)
    {
        if (fuFile.PostedFile != null)
        {

            string ImageName2 = System.IO.Path.GetFileName(fuFile.PostedFile.FileName);
            if (ImageName2 != "")
            {
                string ext = System.IO.Path.GetExtension(fuFile.FileName);
                if (ImageName2 != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".GIF" || ext == ".jpeg" || ext == ".JPEG" || ext == ".PNG" || ext == ".JPG")
                {
                     
                    string virtualpath2 = Session["HomePath"] + "StoreData/VisitVan/" + ImageName2;
                    string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);
                    
                    System.Drawing.Image image = System.Drawing.Image.FromStream(fuFile.PostedFile.InputStream);
                    Bitmap myBitmap = ResizeImage(fuFile.PostedFile.InputStream, 666, 378);
                    myBitmap.Save(fullpath2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    myBitmap.Dispose(); 
                    divError.Visible = false;
                }
                else
                { ErrorMessage("Sorry, File Format Not Supported."); }
            }
            else
            {
                ErrorMessage("Please upload Image.");
            }
        }
        BindFiles();
    }

    /* Event to delete the image */
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int CheckDelete = 0;
        for (int i = 0; i <= GrdVan.Rows.Count - 1; i++)
        {
            CheckBox chk = (CheckBox)GrdVan.Rows[i].FindControl("chkSelect");
            if (chk.Checked)
            {
                CheckDelete = 1;
                Label lblName = (Label)GrdVan.Rows[i].FindControl("lblName");
                string LogicalPath = Session["HomePath"] + "StoreData/VisitVan/" + lblName.Text;
                string physicalPath = ContentManager.GetPhysicalPath(LogicalPath);
                if (System.IO.File.Exists(physicalPath))
                {
                    System.IO.File.Delete(physicalPath);
                }
                SuccessMessage("File(s) Deleted successfully.");
            }
        }
        if (CheckDelete == 0)
        {
            ErrorMessage("Please Select At Least One Department.");
        }
        else
            BindFiles();


        
    }

    /* function to resize the image */
    private Bitmap ResizeImage(Stream streamImage, int maxWidth, int maxHeight)
    {
        Bitmap originalImage = new Bitmap(streamImage);

        int sourceWidth = originalImage.Width;
        int sourceHeight = originalImage.Height;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        //float maxWidth = 88;
        //float maxHeight = 144;

        nPercentW = ((float)maxWidth / (float)sourceWidth);
        nPercentH = ((float)maxHeight / (float)sourceHeight);


        if (nPercentH < nPercentW)
            nPercent = nPercentH;
        else
            nPercent = nPercentW;

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);
        return new Bitmap(originalImage, destWidth, destHeight);
    }
    #endregion 


    #region Footer
    protected void BindFckEditor()
    {
        //FCKeditor2.ImageBrowserURL = Session["HomePath"] + "FCKeditor/FCKeditor/editor/filemanager/browser/default/browser.html?Type=Images&Connector=connectors/aspx/connector.aspx";
        //FCKeditor2.BasePath = "~/FCKeditor/FCKeditor/";
        string FileName = "VisitOurVan.htm";
        FCKeditor2.Value = ContentManager.GetStaticeContent(FileName).Replace("~", "#");
        FCKeditor2.Height = 300;
        FCKeditor2.Width = 810;
        FCKeditor2.SkinPath = "skins/silver/";
    }


    #region "SaveFile"
    protected void SaveFile(string StrContent)
    {
        string Fullpath = Session["HomePath"] + "StoreData/StaticeContent/" + "VisitOurVan.htm";
        string fullpath2 = ContentManager.GetPhysicalPath(Fullpath);
        FileStream file = new FileStream(fullpath2, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(StrContent);
        sw.Close();
        file.Close();
        SuccessMessage1("Your content has been saved successfully. ");
        BindFiles();
        BindFckEditor();
    }
    #endregion

    #region "Save Btn"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveFile(FCKeditor2.Value);
    }
    #endregion 
    #endregion 

    #region GridEvent
    //Event use for pagination
    protected void GrdVan_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = GrdVan.BottomPagerRow;
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(GrdVan.PageIndex + 1);
        int[] page = new int[7];
        page[0] = GrdVan.PageIndex - 2;
        page[1] = GrdVan.PageIndex - 1;
        page[2] = GrdVan.PageIndex;
        page[3] = GrdVan.PageIndex + 1;
        page[4] = GrdVan.PageIndex + 2;
        page[5] = GrdVan.PageIndex + 3;
        page[6] = GrdVan.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > GrdVan.PageCount)
                {
                    LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                    lb.Visible = false;
                }
                else
                {
                    LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                    lb.Text = Convert.ToString(page[i]);

                    lb.CommandName = "PageNo";
                    lb.CommandArgument = lb.Text;

                }
            }
        }
        if (GrdVan.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (GrdVan.PageIndex == GrdVan.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;

        }
        if (GrdVan.PageIndex > GrdVan.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (GrdVan.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    protected void GrdVan_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewRow gvr = e.Row;
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p0");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p1");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p2");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p4");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p5");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p6");
            lb.Command += new CommandEventHandler(lb_Command);
        }
    }

    void lb_Command(object sender, CommandEventArgs e)
    {
        GrdVan.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        BindFiles();
    }

    #endregion

    protected void btnPreview_Click1(object sender, EventArgs e)
    {
        string url = "../Visitourvan.aspx";
        string script = "window.open('" + url + "','')";
        if (!ClientScript.IsClientScriptBlockRegistered("NewWindow"))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "NewWindow", script, true);
        }
    }
    protected void GrdVan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lb = (Label)e.Row.FindControl("lblName");
            HtmlImage imgThumb = (HtmlImage)e.Row.FindControl("imgThumb");
            imgThumb.Src = Session["HomePath"] + "StoreData/VisitVan/" + lb.Text;
        }

    }
}
