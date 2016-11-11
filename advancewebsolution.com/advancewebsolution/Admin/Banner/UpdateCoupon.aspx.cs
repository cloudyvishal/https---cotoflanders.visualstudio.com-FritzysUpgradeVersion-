using System;
using System.IO;
using System.Drawing;
using System.Xml;
using advancewebtosolution.BO;

    public partial class UpdateCoupon : System.Web.UI.Page
    {

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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            if (flv.PostedFile.ToString() == "")
            {
                ErrMessage("Please selecct file to upload.");
            }
            else
            {
                string ImageName2 = System.IO.Path.GetFileName(flv.PostedFile.FileName);
                if (ImageName2 != "")
                {
                    string ext = System.IO.Path.GetExtension(flv.FileName);
                    if (ImageName2 != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".GIF" || ext == ".jpeg" || ext == ".JPEG" || ext == ".PNG" || ext == ".JPG")
                    {

                        string str = Request.QueryString["ID"].ToString();
                        char[] separator = new char[] { '/' };
                        string[] Tempstr = str.Split(separator);
                        string FileName = Tempstr[Tempstr.Length - 1].ToString();

                        string virtualpath2 = Session["HomePath"] + "StoreData/Coupon/" + Request.QueryString["PageName"].ToString() + "/" + FileName;
                        string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);

                        if (System.IO.File.Exists(fullpath2))
                        {
                            System.IO.File.Delete(fullpath2);
                        }

                        System.Drawing.Image image = System.Drawing.Image.FromStream(flv.PostedFile.InputStream);
                        Bitmap myBitmap = ResizeImage(flv.PostedFile.InputStream, 666, 256);
                        myBitmap.Save(fullpath2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        myBitmap.Dispose();
                        divError.Visible = false;

                        AddBannerToXml(virtualpath2, FileName);

                    }
                    else
                    { ErrMessage("File Format Not Supported"); }
                }
                else
                {
                    ErrMessage("Please select file to upload.");
                }
            }



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

        public void AddBannerToXml(string virtualpath2, string ImageName2)
        {

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Session["HomePath"].ToString() + "banners_Cat.xml");
            XmlNodeList Node1;
            Node1 = xmldoc.GetElementsByTagName("banner");
            for (int i = 0; i < Node1.Count; i++)
            {
                XmlElement id = (XmlElement)xmldoc.GetElementsByTagName("banner")[i];

                if (id.ChildNodes.Item(2).InnerText.ToString() == Request.QueryString["ID"].ToString())
                {
                    id.ChildNodes.Item(3).InnerText = Session["HomePath"] + "PrintCoupon.aspx?CouponID=" + ImageName2 + "&PageName=" + Request.QueryString["PageName"].ToString();
                }
            }
            xmldoc.Save(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "banners_Cat.xml"));
            Response.Redirect("ManageBaner.aspx");
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageBaner.aspx");
        }
    }