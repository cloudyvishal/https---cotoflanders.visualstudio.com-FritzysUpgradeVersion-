using System;
using System.Data;
using One2Print.Library.Security;
using System.IO;
using System.Drawing;
using advancewebtosolution.BO;

public partial class Admin_Products_EditProducts : System.Web.UI.Page
{
    advancewebtosolution.BO.Products ObjProduct = new advancewebtosolution.BO.Products();
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
    protected void BindProduct(int ProductID)
    {
        DataSet ds = new DataSet();
        ds = ObjProduct.GetProductDetail(ProductID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
            txtProductName.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();
            txtProductDescription.Text = ds.Tables[0].Rows[0]["ProductDescription"].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
            
            if (ds.Tables[0].Rows[0]["ImageName"].ToString() != "")
            {
                ImgProduct.ImageUrl = Session["HomePath"] + "StoreData/Product/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
                ViewState["ImageName"] = ds.Tables[0].Rows[0]["ImageName"].ToString();
            }
            else
                ImgProduct.ImageUrl = Session["HomePath"] + "StoreData/Product/Not.jpg";
        }
        else
        {

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ProductID"] != "")
            {
                int ProductID = int.Parse(Request.QueryString["ProductID"]);
                BindProduct(ProductID);
                 
            }
            else
            {
                Response.Redirect("ManagesServices.aspx");
            }
        }
    }
    /* This event is use to upload the image */
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
                    string NewImageName = RandomStringsAndNumbers.Generate() + ext;
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
                { ErrMessage("Sorry, File Format Not Supported."); }
            }
            else
            {
                ErrMessage("Please upload Image.");
            }
        }
    }
    /* This function is use to resize the image but keeping the image ratio .*/
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
       string str = Request.QueryString["ProductID"].ToString();
        int id = Convert.ToInt32(str);
        ObjProduct.UpdateProduct(id, txtProductName.Text.Trim(), txtProductDescription.Text.Trim(), Convert.ToDecimal(txtPrice.Text.Trim()), ViewState["ImageName"].ToString(), Convert.ToInt32(ddlStatus.SelectedValue));
        SuccesfullMessage("Product updated successfully.");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageProducts.aspx?SearchFor=0&SearchText=");
    }
}
