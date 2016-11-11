using System;
using System.Data;
using One2Print.Library.Security;
using System.IO;
using System.Drawing;
using advancewebtosolution.BO;

public partial class Admin_Services_AddService : System.Web.UI.Page
{
    advancewebtosolution.BO.Services objServicess = new advancewebtosolution.BO.Services();
    #region 
    /* Region to set FCK Editor content */
    protected void BindFckEditor()
    {
        //FCKeditor2.ImageBrowserURL = Session["HomePath"] + "FCKeditor/FCKeditor/editor/filemanager/browser/default/browser.html?Type=Images&Connector=connectors/php/connector.php";
        //FCKeditor2.BasePath = "~/FCKeditor/FCKeditor/";
        FCKeditor2.Height = 300;
        FCKeditor2.Width = 800;
       
        FCKeditor2.SkinPath = "skins/silver/";
        //FCKeditor2.ImageDlgHideLink = true;
        //FCKeditor2.ImageUpload = false;
        //FCKeditor2.ImageDlgHideAdvanced = true;
    }
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
    #endregion 

    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        {
            BindFckEditor();
            ImgService.Visible = false;
        }
    }
    #region Event
    /* Region is use to save the content of services */
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["ImageName"] != null)
            {
                string FileName;
                DataSet ds = new DataSet();
                FileName = txtPageName.Text + ".htm";
                //Add to Database
                int count = objServicess.AddService(Convert.ToInt32(ddlServiceType.SelectedValue),
                                        txtServiceTitle.Text.Trim(),
                                        txtServiceDesc.Text.Trim(),
                                        FileName,
                                        Convert.ToInt32(ddlStatus.SelectedValue),
                                        ViewState["ImageName"].ToString());
                if (count == 1)
                {
                    SuccessMessage("Service added successfully");
                    txtServiceTitle.Text = "";
                    txtServiceDesc.Text = "";
                    txtPageName.Text = "";
                    FCKeditor2.Value = "";
                    ImgService.ImageUrl = Session["HomePath"] + "StoreData/Images/Not.jpg";
                    //Add to Store data folder create File 
                    ContentManager.SaveRightHandSectionContent(FCKeditor2.Value, FileName);
                }
                else
                {
                    ErrorMessage("Duplicate service name");
                }
            }
            else
            {
                ErrorMessage("Please upload image");
            }
        }
        catch  { }
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageServices.aspx?SearchFor=0&SearchText=");
    }
    /* This event is use to Upload image after verification */
    protected void btnUpload_Click1(object sender, EventArgs e)
    {
        try
        {
            if (flUploadDetail.PostedFile != null)
            {

                string ImageName2 = System.IO.Path.GetFileName(flUploadDetail.PostedFile.FileName);
                if (ImageName2 != "")
                {
                    string ext = System.IO.Path.GetExtension(flUploadDetail.FileName);
                    if (ImageName2 != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".GIF" || ext == ".jpeg" || ext == ".JPEG" || ext == ".PNG" || ext == ".JPG")
                    {
                        string NewImageName = RandomStringsAndNumbers.Generate() + ext;
                        string virtualpath2 = Session["HomePath"] + "StoreData/Images/" + NewImageName;
                        string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);


                        System.Drawing.Image image = System.Drawing.Image.FromStream(flUploadDetail.PostedFile.InputStream);
                        Bitmap myBitmap = ResizeImage(flUploadDetail.PostedFile.InputStream, 88, 144);
                        myBitmap.Save(fullpath2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        myBitmap.Dispose();

                        ViewState["ImageName"] = NewImageName.ToString();
                        ImgService.Visible = true;
                        ImgService.ImageUrl = Session["HomePath"] + "StoreData/Images/" + NewImageName;
                        divError.Visible = false;
                    }
                    else
                    { ErrorMessage("File Format Not Supported."); }
                }
                else
                {
                    ErrorMessage("Please upload Image.");
                }
            }
            else
            {
                ErrorMessage("Please upload Image.");
            }
        }
        catch { }
    }

    /* This function is use to resize the inmage to require size and also maintain original ratio of image*/
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
}
