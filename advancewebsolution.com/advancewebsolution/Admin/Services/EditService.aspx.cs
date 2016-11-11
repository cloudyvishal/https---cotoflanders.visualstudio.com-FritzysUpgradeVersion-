using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using One2Print.Library.Security;
using System.IO;
using System.Drawing;
using advancewebtosolution.BO;

public partial class Admin_Services_EditService : System.Web.UI.Page
{
    #region 
    /* this function is use to get service detail from database which require service ID .
        also shows the image of service and ciontent of service file.
     */
    advancewebtosolution.BO.Services objServices = new advancewebtosolution.BO.Services();
    protected void GetServiceDetail(int ServiceID)
    {
       DataSet ds = new DataSet();
        ds = objServices.GetServiceDetail(ServiceID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["Status1"].ToString();
            txtServiceTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
            txtServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
            txtPageName.Text = ds.Tables[0].Rows[0]["PageName"].ToString();
            lblFileName.Text = ds.Tables[0].Rows[0]["PageName"].ToString();

           // ddlType.SelectedValue =  (ds.Tables[0].Rows[0]["ServiceType"].ToString());
            //PetType=Convert.ToInt32(ds.Tables[0].Rows[0]["ServiceType"].ToString());

            //Bind Html file to FCK Editor
            BindFckEditor(ds.Tables[0].Rows[0]["PageName"].ToString());
            if (ds.Tables[0].Rows[0]["Image"].ToString() != "")
            {
                ImgService.ImageUrl = Session["HomePath"] + "StoreData/Images/" + ds.Tables[0].Rows[0]["Image"].ToString();
                ViewState["ImageName"] = ds.Tables[0].Rows[0]["Image"].ToString();
            }
            else
                ImgService.ImageUrl = Session["HomePath"] + "StoreData/Images/Not.jpg";
        }
        else
        {

        }
    }
    /* Use to set FCK Editor     */
    protected void BindFckEditor(string FileName)
    {
        FCKeditor2.Value = ContentManager.GetRightHandSectionFileContent(FileName).Replace("~", "#");
        FCKeditor2.Height = 300;
        FCKeditor2.Width = 800;
        FCKeditor2.SkinPath = "skins/silver/";
    }
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
    #endregion
    int ServiceID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ServiceID"] != "")
            {
                 ServiceID = int.Parse(Request.QueryString["ServiceID"]);
                GetServiceDetail(ServiceID);
            }
            else
            {
                Response.Redirect("ManagesServices.aspx");
            }
        }
       
    }

    #region Event 
    /* Use to Upadte the serice to database*/
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objServices.UpdateService(Convert.ToInt32(Request.QueryString["ServiceID"].ToString()),Convert.ToInt32(Session["PetTypes"].ToString()), txtServiceTitle.Text.Trim(), txtServiceDesc.Text.Trim(), Convert.ToInt32(ddlStatus.SelectedValue), ViewState["ImageName"].ToString());
        ContentManager.SaveRightHandSectionContent(FCKeditor2.Value, txtPageName.Text);
        SuccesfullMessage("Service updated successfully.");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageServices.aspx?SearchFor=0&SearchText=");
    }
    /* This event is use to upload the image */
    protected void btnUpload_Click(object sender, EventArgs e)
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
                    { ErrMessage("Sorry, File Format Not Supported."); }
                }
                else
                {
                    ErrMessage("Please upload Image.");
                }
            }
        }
        catch  { }
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

    protected void btnPreview_Click1(object sender, EventArgs e)
    {
        string url = "../../ServiceDetails.aspx?ID=" + ServiceID + "&Page=1";
        MessageBox1(url);
    }
    private void MessageBox1(string strmsg)
    {

        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.open(" + "'" + strmsg + "','downloadpdf','status=yes,toolbar=yes,resizable=1,menubar=yes,height=700,width=700,location=yes,scrollbars=yes,left=0,top=0'" + ")</script>";
        Page.Controls.Add(lbl);
    }

    #endregion 
}
