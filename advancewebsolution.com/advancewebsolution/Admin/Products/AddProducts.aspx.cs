using System;
using One2Print.Library.Security;
using System.IO;
using System.Drawing;
using advancewebtosolution.BO;

public partial class Admin_Products_AddProducts : System.Web.UI.Page
{
    string NewImageName = string.Empty;
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ImgProduct.ImageUrl = Session["HomePath"] + "StoreData/Product/Not.jpg";
            ViewState["ImageName"] = "";
        }
    }

    protected void btnUpload_Click1(object sender, EventArgs e)
    {
        if (flUploadDetail.PostedFile != null)
        {
                
            string ImageName2 = System.IO.Path.GetFileName(flUploadDetail.PostedFile.FileName);
            if (ImageName2 != "")
            {
                string ext = System.IO.Path.GetExtension(flUploadDetail.FileName);
                if (ImageName2 != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".GIF" || ext == ".jpeg" || ext == ".JPEG" || ext == ".PNG" || ext == ".JPG")
                {
                    NewImageName = RandomStringsAndNumbers.Generate() + ext;
                    string virtualpath2 = Session["HomePath"] + "StoreData/Product/" + NewImageName;
                    string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);


                    System.Drawing.Image image = System.Drawing.Image.FromStream(flUploadDetail.PostedFile.InputStream);
                    Bitmap myBitmap = ResizeImage(flUploadDetail.PostedFile.InputStream, 88, 144);
                    myBitmap.Save(fullpath2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    myBitmap.Dispose();

                    ViewState["ImageName"] = NewImageName.ToString();
                    ImgProduct.Visible = true;
                    ImgProduct.ImageUrl = Session["HomePath"] + "StoreData/Product/" + NewImageName;
                    divError.Visible = false;
                }
                else
                { ErrorMessage("File Format Not Supported"); }
            }
            else
            {
                ErrorMessage("You Forgot To Select File Please Select File & Then Try.");
            }
        }
        else
        {
            ErrorMessage("You Forgot To Select File Please Select File & Then Try.");
        }
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        advancewebtosolution.BO.Products ObjProduct = new advancewebtosolution.BO.Products();
        ObjProduct.AddProducts(txtProductName.Text, txtProductDescription.Text.Trim(), Convert.ToDecimal(txtPrice.Text.Trim()), ViewState["ImageName"].ToString(), Convert.ToInt32(ddlStatus.SelectedValue));
        SuccessMessage("Product added successfully");
        txtProductName.Text = "";
        txtPrice.Text = "";
        txtProductDescription.Text  = "";
        ddlStatus.SelectedValue = "1";
        ImgProduct.ImageUrl = Session["HomePath"] + "StoreData/Product/Not.jpg"; 
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageProducts.aspx?SearchFor=0&SearchText=");
    }
}
