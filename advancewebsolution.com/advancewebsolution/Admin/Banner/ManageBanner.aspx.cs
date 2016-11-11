using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;
using System.Drawing;
using System.Xml;
using advancewebtosolution.BO;

namespace advancewebtosolution
{
    public partial class Admin_Baner_ManageBanner : System.Web.UI.Page
    {
        string[] type = new string[2];

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

        /* Bind Pet information to grid */
        protected void Bind(int PetType)
        {
            DataSet ds = new DataSet();
            if (PetType == 1)
            {
                ViewState["PetType"] = "1";
                ds.ReadXml(Session["HomePath"] + "banners.xml");
            }
            if (PetType == 2)
            {
                ViewState["PetType"] = "2";
                ds.ReadXml(Session["HomePath"] + "banners_Dog.xml");
            }
            if (PetType == 3)
            {
                ViewState["PetType"] = "3";
                ds.ReadXml(Session["HomePath"] + "banners_Cat_Dog.xml");
            }
            if (ds.Tables.Count == 3)
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    GrdBaner.Visible = true;
                    btnDelete.Visible = true;
                    GrdBaner.DataSource = ds.Tables[2];
                    GrdBaner.DataBind();
                    Utility.Setserial(GrdBaner, "srno");
                    CheckAll();
                    check();

                }
                else
                {
                    GrdBaner.Visible = false;
                    btnDelete.Visible = false;
                    ErrMessage("No record found");
                }
            }
            else
            {
                btnDelete.Visible = false;
                GrdBaner.Visible = false;
                ErrMessage("No record found");
            }
        }

        /* Check all function is use for gride header checkbox to chaeck all function which is register client script */
        public void CheckAll()
        {
            CheckBox chkall;
            chkall = (CheckBox)GrdBaner.HeaderRow.FindControl("chkall");
            chkall.Attributes.Add("onclick", "checkall()");
            string str;
            str = "function checkall()";
            str = str + "{if(document.getElementById('" + chkall.ClientID + "').checked==true)";
            str = str + "{";
            foreach (GridViewRow gvr in GrdBaner.Rows)
            {
                CheckBox checkall;
                checkall = (CheckBox)gvr.FindControl("chkSelect");
                str = str + "document.getElementById('" + checkall.ClientID + "').checked=true;";
            }
            str = str + "}";
            str = str + "else";
            str = str + "{";
            foreach (GridViewRow grv in GrdBaner.Rows)
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

            foreach (GridViewRow grv in GrdBaner.Rows)
            {
                CheckBox chk1;
                chk1 = (CheckBox)grv.FindControl("chkSelect");
                checkid += "if(document.getElementById('" + chk1.ClientID + "').checked==true){";
                checkid += "flg=1;}";
            }
            checkid += "if(flg!=1){";
            checkid += "alert('Select Atleast One Banner');return false;}";
            checkid += "if(flg==1 && id==1){";
            checkid += "if(!confirm('Do You Want To Delete Selected Banner(s) ?')){return false;}}";
            checkid += "if(flg==1 && id==2){";
            checkid += "if(!confirm('Do You Want To Change Status of Banner(s) ?')){return false;}}";
            checkid = checkid + "}";
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

            //btnactdeact.Attributes.Add("onclick", "return val(0);");
            btnDelete.Attributes.Add("onclick", "return val(1);");
            //btnStatus.Attributes.Add("onclick", "return val(2);");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind(1);
            }
        }

        protected void GrdBaner_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdBaner.PageIndex = e.NewPageIndex;
            Bind(Convert.ToInt32(ViewState["PetType"].ToString()));
        }

        /* On row data bound we bind actual banner name to the grid where Grid name and banner name is same while uploding  */
        protected void GrdBaner_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lb = (Label)e.Row.FindControl("lblImageName");

                string str = lb.Text.ToString();
                if (str != "")
                {
                    char[] separator = new char[] { '/' };
                    string[] Tempstr = str.Split(separator);
                    lb.Text = Tempstr[Tempstr.Length - 1].ToString();
                }
            }
        }

        /* On upload click it will upload banner which is required field as well coupon which is optional 
            while name of banner and coupon is same while storing  the data

         */
        protected void btnUp_Click(object sender, EventArgs e)
        {
            if (flv.PostedFile.ToString() == "")
            {
                ErrMessage("Please selecct file to upload.");
            }
            else if (!CheckPet(System.IO.Path.GetFileName(flv.PostedFile.FileName)))
            {
                ErrMessage("Duplicate banner name");
            }
            else
            {
                string ImageName2 = System.IO.Path.GetFileName(flv.PostedFile.FileName);
                if (ImageName2 != "")
                {
                    string ext = System.IO.Path.GetExtension(flv.FileName);
                    if (ImageName2 != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".GIF" || ext == ".jpeg" || ext == ".JPEG" || ext == ".PNG" || ext == ".JPG")
                    {
                        string tempPath = string.Empty;
                        if (ViewState["PetType"].ToString() == "1")
                        {
                            tempPath = "StoreData/Banner/Cat/img/" + ImageName2;
                        }
                        if (ViewState["PetType"].ToString() == "2")
                        {
                            tempPath = "StoreData/Banner/Dog/img/" + ImageName2;
                        }
                        if (ViewState["PetType"].ToString() == "3")
                        {
                            tempPath = "StoreData/Banner/Cat_Dog/img/" + ImageName2;
                        }

                        string virtualpath2 = Session["HomePath"] + tempPath;
                        string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);

                        System.Drawing.Image image = System.Drawing.Image.FromStream(flv.PostedFile.InputStream);
                        Bitmap myBitmap = ResizeImage(flv.PostedFile.InputStream, 666, 256);
                        myBitmap.Save(fullpath2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        myBitmap.Dispose();

                        divError.Visible = false;


                        string ImgCoupon = System.IO.Path.GetFileName(FlvCoupon.PostedFile.FileName);
                        if (ImgCoupon != "")
                        {
                            string ext1 = System.IO.Path.GetExtension(FlvCoupon.FileName);
                            if (ImgCoupon != "" && ext1 == ".gif" || ext1 == ".jpg" || ext1 == ".png" || ext1 == ".GIF" || ext1 == ".jpeg" || ext1 == ".JPEG" || ext1 == ".PNG" || ext1 == ".JPG")
                            {

                                string virtualpath = Session["HomePath"] + "StoreData/Coupon/" + ImageName2;
                                string fullpath = ContentManager.GetPhysicalPath(virtualpath);

                                System.Drawing.Image image1 = System.Drawing.Image.FromStream(FlvCoupon.PostedFile.InputStream);
                                Bitmap myBitmap1 = ResizeImage(FlvCoupon.PostedFile.InputStream, 666, 256);
                                myBitmap1.Save(fullpath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                myBitmap1.Dispose();

                            }
                        }
                        else
                            ImageName2 = "No";
                        AddBannerToXml(tempPath, ImageName2);
                        Bind(Convert.ToInt32(ViewState["PetType"].ToString()));


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

        /* On Delete banner click banner is delete as well it will delete respective coupon */
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string BannerID = Utility.GetCheckedRowString(GrdBaner, "chkSelect");
            if (BannerID != "")
            {
                char[] separator = new char[] { ',' };
                string[] str = BannerID.Split(separator);

                foreach (string arrStr in str)
                {
                    DeleteFromXml(arrStr);

                    string LogicalPath = Session["HomePath"] + arrStr.Substring(3); ;
                    string physicalPath = ContentManager.GetPhysicalPath(LogicalPath);

                    string LogicalPath1 = Session["HomePath"] + "StoreData/Coupon/" + arrStr.Substring(28); ;
                    string physicalPath1 = ContentManager.GetPhysicalPath(LogicalPath1);

                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                        System.IO.File.Delete(physicalPath1);
                    }
                    SuccesfullMessage("Banner(s) deleted successfully");
                }


                Bind(Convert.ToInt32(ViewState["PetType"].ToString()));
            }

        }

        /**/
        public bool CheckPet(string FileName)
        {
            DataSet objDataSet = new DataSet();
            objDataSet.ReadXml(GetPath());
            if (objDataSet.Tables.Count == 3)
            {
                for (int i = 0; i < objDataSet.Tables[2].Rows.Count; i++)
                {
                    string str = objDataSet.Tables[2].Rows[i]["imagePath"].ToString();
                    char[] separator = new char[] { '/' };
                    string[] Tempstr = str.Split(separator);
                    if (FileName == Tempstr[Tempstr.Length - 1].ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        protected void ddlPetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind(Convert.ToInt32(ddlPetType.SelectedValue));
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

        /* As banner rotating through flash so that we need add this information to the .XML file */
        public void AddBannerToXml(string tempPath, string ImgCoupon)
        {
            string Path = string.Empty;
            if (ViewState["PetType"].ToString() == "1")
            {
                Path = Session["HomePath"] + "banners.xml";
            }
            if (ViewState["PetType"].ToString() == "2")
            {
                Path = Session["HomePath"] + "banners_Dog.xml";
            }
            if (ViewState["PetType"].ToString() == "3")
            {
                Path = Session["HomePath"] + "banners_Cat_Dog.xml";
            }

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Path);
            //Create a new node
            XmlNodeList Node;
            Node = xmldoc.GetElementsByTagName("numberOfBanners");
            XmlNodeList Node_Count;
            Node_Count = xmldoc.GetElementsByTagName("banner");
            for (int i = 0; i < Node.Count; i++)
            {
                XmlElement id = (XmlElement)xmldoc.GetElementsByTagName("numberOfBanners")[i];
                id.InnerText = (Node_Count.Count + 1).ToString();
            }
            XmlElement banners = xmldoc.CreateElement("banners");
            XmlElement banner = xmldoc.CreateElement("banner");
            XmlElement name = xmldoc.CreateElement("name");
            XmlElement body = xmldoc.CreateElement("body");
            XmlElement imagePath = xmldoc.CreateElement("imagePath");
            XmlElement link = xmldoc.CreateElement("link");
            name.InnerText = "OnE";
            body.InnerText = "Lorem Ipsum";
            imagePath.InnerText = "../" + tempPath;
            link.InnerText = Session["HomePath"] + "PrintCoupon.aspx?CouponID=" + ImgCoupon;
            banner.AppendChild(name);
            banner.AppendChild(body);
            banner.AppendChild(imagePath);
            banner.AppendChild(link);
            XmlNodeList Node1;
            Node1 = xmldoc.GetElementsByTagName("banners");
            Node1.Item(0).AppendChild(banner);

            xmldoc.Save(ContentManager.GetPhysicalPath(Path));
        }
        /* function is use to delete the banner information from XML file */
        public void DeleteFromXml(string str)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(GetPath());

            XmlNodeList Node;
            Node = xmldoc.GetElementsByTagName("numberOfBanners");
            XmlNodeList Node_Count;
            Node_Count = xmldoc.GetElementsByTagName("banner");
            for (int i = 0; i < Node.Count; i++)
            {
                XmlElement id = (XmlElement)xmldoc.GetElementsByTagName("numberOfBanners")[i];
                id.InnerText = (Node_Count.Count - 1).ToString();
            }


            XmlNodeList Node1;
            Node1 = xmldoc.GetElementsByTagName("banner");
            for (int i = 0; i < Node1.Count; i++)
            {
                XmlElement id = (XmlElement)xmldoc.GetElementsByTagName("banner")[i];

                if (id.ChildNodes.Item(2).InnerText.ToString() == str)
                {
                    id.ParentNode.RemoveChild(id);
                    //id.ParentNode.AppendChild(banner);
                }
            }
            xmldoc.Save(ContentManager.GetPhysicalPath(GetPath()));
        }

        public string GetPath()
        {
            string Path = string.Empty;
            if (ViewState["PetType"].ToString() == "1")
            {
                Path = Session["HomePath"] + "banners.xml";
            }
            if (ViewState["PetType"].ToString() == "2")
            {
                Path = Session["HomePath"] + "banners_Dog.xml";
            }
            if (ViewState["PetType"].ToString() == "3")
            {
                Path = Session["HomePath"] + "banners_Cat_Dog.xml";
            }
            return Path;
        }
    }
}