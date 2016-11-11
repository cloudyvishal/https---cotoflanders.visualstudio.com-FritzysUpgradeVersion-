using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Xml;
using advancewebtosolution.BO;

namespace advancewebtosolution
{
    public partial class Admin_Baner_ManageBaner : System.Web.UI.Page
    {
        #region Declear
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
        #endregion
        protected void BindData(int ID)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Session["HomePath"] + "banners_Cat.xml");
            DataTable dt = ds.Tables.Add("ThumbImages");
            dt.Columns.Add("ImageName", typeof(string));
            dt.Columns.Add("CouponName", typeof(string));
            if (ds.Tables[3].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                {
                    if (ds.Tables[3].Rows[i]["Banners_Id"].ToString() == ID.ToString())
                    {
                        dt.Rows.Add(new object[] { ds.Tables[3].Rows[i]["imagePath"].ToString(), ds.Tables[3].Rows[i]["link"].ToString() });

                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                GrdBaner.Visible = true;
                btnDelete.Visible = true;
                GrdBaner.DataSource = dt;
                GrdBaner.DataBind();
                Utility.Setserial(GrdBaner, "srno");
                CheckAll();
                check();
                divError.Visible = false;
            }
            else
            {
                GrdBaner.Visible = false;
                btnDelete.Visible = false;
                ErrMessage("No banner found for " + ddlPage.SelectedItem.Text.ToLowerInvariant() + " Page - " + ddlUserType.SelectedItem.Text.ToLowerInvariant());
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(0);
                HtmlHead hh = this.Master.Page.Header;
                HtmlMeta hm = new HtmlMeta();
                hm.Attributes.Add("http-equiv", "Refresh");

                hh.Controls.Add(hm);
                Banner newObj = new Banner();
                DataSet ds = newObj.GetDefaultCouponName();
                ImgCoupon.ImageUrl = Session["HomePath"] + "StoreData/Coupon/" + ds.Tables[0].Rows[0]["DefaultCouponName"].ToString();
                ViewState["DefaultCoupon"] = ds.Tables[0].Rows[0]["DefaultCouponName"].ToString();
            }
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
                        ImageName2 = Utility.RandomNumber().ToString() + ".jpeg";
                        string virtualpath2 = Session["HomePath"] + "StoreData/Baner/" + ddlPage.SelectedItem.Text + "/" + ImageName2;
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

                                string virtualpath = Session["HomePath"] + "StoreData/Coupon/" + ddlPage.SelectedItem.Text + "/" + ImageName2;
                                string fullpath = ContentManager.GetPhysicalPath(virtualpath);

                                System.Drawing.Image image1 = System.Drawing.Image.FromStream(FlvCoupon.PostedFile.InputStream);
                                Bitmap myBitmap1 = ResizeImage(FlvCoupon.PostedFile.InputStream, 666, 256);
                                myBitmap1.Save(fullpath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                myBitmap1.Dispose();
                                ImgCoupon = ImageName2;
                            }
                        }
                        AddBannerToXml(virtualpath2, ImageName2, ImgCoupon);
                        BindData(Convert.ToInt32(ddlUserType.SelectedValue));
                    }
                    else
                    { ErrMessage("File Format Not Supported"); }
                }
                else
                {
                    ErrMessage("Please select banner to upload coupon.");
                }
            }
        }

        #region Dropdown Event
        protected void ddlPetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData(Convert.ToInt32(ddlUserType.SelectedValue));
        }
        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrdBaner.Visible = false;
            btnDelete.Visible = false;
            Banner ObjBanner = new Banner();
            DataSet ds = ObjBanner.GetUserTypeID(Convert.ToInt32(ddlPage.SelectedValue));
            DataTable dt = ds.Tables.Add("ThumbImages");
            dt.Columns.Add("UserTypeName", typeof(string));
            dt.Columns.Add("UsertyptID", typeof(string));
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt.Rows.Add(new object[] { "Unregistered User", ds.Tables[0].Rows[0]["BannerID"].ToString() });
                dt.Rows.Add(new object[] { "Registerd User - Cat", ds.Tables[0].Rows[1]["BannerID"].ToString() });
                dt.Rows.Add(new object[] { "Registerd User - Dog", ds.Tables[0].Rows[2]["BannerID"].ToString() });
                dt.Rows.Add(new object[] { "Registerd User - Cat & Dog", ds.Tables[0].Rows[3]["BannerID"].ToString() });
            }
            ddlUserType.DataTextField = "UserTypeName";
            ddlUserType.DataValueField = "UsertyptID";
            ddlUserType.DataSource = dt; ;
            ddlUserType.DataBind();
            ddlUserType.SelectedIndex = 0;
            BindData(Convert.ToInt32(ddlUserType.SelectedValue));
        }
        #endregion

        protected void GrdBaner_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lb = (Label)e.Row.FindControl("lblImageName");

                HyperLink lnkEdit = (HyperLink)e.Row.FindControl("lnkEdit");
                lnkEdit.NavigateUrl = "UpdateCoupon.aspx?ID=" + lb.Text + "&PageName=" + ddlPage.SelectedItem.Text;

                HtmlImage imgThumb = (HtmlImage)e.Row.FindControl("imgThumb");
                imgThumb.Src = Session["HomePath"] + lb.Text.Substring(3);
                string str = lb.Text;
                HtmlImage ImageCoupon = (HtmlImage)e.Row.FindControl("ImageCoupon");
                if (str != "")
                {
                    char[] separator = new char[] { '/' };
                    string[] Tempstr = str.Split(separator);
                    lb.Text = Tempstr[Tempstr.Length - 1].ToString();

                    string imagepath = Session["HomePath"] + "StoreData/Coupon/" + ddlPage.SelectedItem.Text + "/" + Tempstr[Tempstr.Length - 1].ToString();
                    string fulpath = ContentManager.GetPhysicalPath(imagepath);
                    if (System.IO.File.Exists(fulpath))
                    {
                        ImageCoupon.Src = imagepath;
                    }
                    else
                    {
                        ImageCoupon.Src = Session["HomePath"] + "StoreData/Coupon/Not.jpg";
                    }


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



        /* As banner rotating through flash so that we need add this information to the .XML file */
        public void AddBannerToXml(string tempPath, string ImageName2, string ImageCoupon)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Session["HomePath"].ToString() + "banners_Cat.xml");
            //Create a new node
            XmlNodeList Node;
            Node = xmldoc.GetElementsByTagName("bannerName");
            XmlElement banners = xmldoc.CreateElement("banners");
            XmlElement banner = xmldoc.CreateElement("banner");
            XmlElement name = xmldoc.CreateElement("name");
            XmlElement body = xmldoc.CreateElement("body");
            XmlElement imagePath = xmldoc.CreateElement("imagePath");
            XmlElement link = xmldoc.CreateElement("link");
            name.InnerText = "New";
            body.InnerText = "Lorem Ipsum";
            imagePath.InnerText = "../StoreData/Baner/" + ddlPage.SelectedItem.Text + "/" + ImageName2;
            link.InnerText = Session["HomePath"] + "PrintCoupon.aspx?CouponID=" + ImageCoupon + "&PageName=" + ddlPage.SelectedItem.Text;
            banner.AppendChild(name);
            banner.AppendChild(body);
            banner.AppendChild(imagePath);
            banner.AppendChild(link);
            XmlNodeList Node1;
            Node1 = xmldoc.GetElementsByTagName("banners");
            Node1.Item(Convert.ToInt32(ddlUserType.SelectedValue)).AppendChild(banner);   // Important Count
            XmlNodeList Node2;
            Node2 = xmldoc.GetElementsByTagName("bannerName");
            Node2.Item(Convert.ToInt32(ddlUserType.SelectedValue)).FirstChild.InnerText = Node1.Item(Convert.ToInt32(ddlUserType.SelectedValue)).ChildNodes.Count.ToString();
            xmldoc.Save(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "banners_Cat.xml"));
        }


        public bool CheckPet(string FileName)
        {
            string physicalpath = ContentManager.GetPhysicalPath(Session["HomePath"] + "StoreData/Baner/" + ddlPage.SelectedItem.Text);
            DirectoryInfo dir = new DirectoryInfo(physicalpath);
            FileInfo[] jpgfiles = dir.GetFiles();
            for (int i = 0; i < jpgfiles.Length; i++)
            {
                if (jpgfiles[i].ToString() == FileName)
                {
                    return false;
                }

            }
            return true;
        }
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

                    char[] separator1 = new char[] { '/' };
                    string[] str1 = arrStr.Split(separator1);

                    string LogicalPath = Session["HomePath"] + arrStr.Substring(3); ;
                    string physicalPath = ContentManager.GetPhysicalPath(LogicalPath);

                    string LogicalPath1 = Session["HomePath"] + "StoreData/Coupon/" + ddlPage.SelectedItem.Text + "/" + str1[str1.Length - 1].ToString();
                    //string LogicalPath1 = Session["HomePath"] + arrStr.Substring(3); ;

                    string physicalPath1 = ContentManager.GetPhysicalPath(LogicalPath1);

                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                        if (System.IO.File.Exists(physicalPath1))
                            System.IO.File.Delete(physicalPath1);
                    }
                    SuccesfullMessage("Banner(s) deleted successfully");
                }


                BindData(Convert.ToInt32(ddlUserType.SelectedValue));
            }



        }

        public void DeleteFromXml(string str)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Session["HomePath"].ToString() + "banners_Cat.xml");
            XmlNodeList Node1;
            Node1 = xmldoc.GetElementsByTagName("banner");

            for (int i = 0; i < Node1.Count; i++)
            {
                XmlElement id = (XmlElement)xmldoc.GetElementsByTagName("banner")[i];

                if (id.ChildNodes.Item(2).InnerText.ToString() == str)
                {
                    id.ParentNode.RemoveChild(id);
                }
            }
            XmlNodeList Node2;
            Node2 = xmldoc.GetElementsByTagName("banners");
            int c = Node2.Item(Convert.ToInt32(ddlUserType.SelectedValue)).ChildNodes.Count;
            XmlNodeList Node3;
            Node3 = xmldoc.GetElementsByTagName("bannerName");
            Node3.Item(Convert.ToInt32(ddlUserType.SelectedValue)).FirstChild.InnerText = Node2.Item(Convert.ToInt32(ddlUserType.SelectedValue)).ChildNodes.Count.ToString();
            xmldoc.Save(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "banners_Cat.xml"));
        }


        //Event use for pagination
        protected void GrdBaner_DataBound(object sender, EventArgs e)
        {
            GridViewRow gvr = GrdBaner.BottomPagerRow;
            Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
            lb1.Text = Convert.ToString(GrdBaner.PageIndex + 1);
            int[] page = new int[7];
            page[0] = GrdBaner.PageIndex - 2;
            page[1] = GrdBaner.PageIndex - 1;
            page[2] = GrdBaner.PageIndex;
            page[3] = GrdBaner.PageIndex + 1;
            page[4] = GrdBaner.PageIndex + 2;
            page[5] = GrdBaner.PageIndex + 3;
            page[6] = GrdBaner.PageIndex + 4;
            for (int i = 0; i < 7; i++)
            {
                if (i != 3)
                {
                    if (page[i] < 1 || page[i] > GrdBaner.PageCount)
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
            if (GrdBaner.PageIndex == 0)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
                lb.Visible = false;

            }
            if (GrdBaner.PageIndex == GrdBaner.PageCount - 1)
            {
                LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
                lb.Visible = false;
                lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
                lb.Visible = false;

            }
            if (GrdBaner.PageIndex > GrdBaner.PageCount - 5)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
                lbmore.Visible = false;
            }
            if (GrdBaner.PageIndex < 4)
            {
                Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
                lbmore.Visible = false;
            }
        }
        protected void GrdBaner_RowCreated(object sender, GridViewRowEventArgs e)
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
            GrdBaner.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
            BindData(Convert.ToInt32(ddlUserType.SelectedValue));
        }

        protected void btnDefaultCoupon_Click(object sender, EventArgs e)
        {
            if (fluDefaultCoupon.PostedFile != null)
            {
                string ImageName2 = System.IO.Path.GetFileName(fluDefaultCoupon.PostedFile.FileName);
                if (ImageName2 != "")
                {
                    string ext = System.IO.Path.GetExtension(fluDefaultCoupon.FileName);
                    if (ImageName2 != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".GIF" || ext == ".jpeg" || ext == ".JPEG" || ext == ".PNG" || ext == ".JPG")
                    {
                        string virtualpath2 = Session["HomePath"] + "StoreData/Coupon/" + ImageName2;
                        string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);

                        string virtualpath1 = Session["HomePath"] + "StoreData/Coupon/" + ViewState["DefaultCoupon"].ToString();
                        string fullpath1 = ContentManager.GetPhysicalPath(virtualpath1);

                        FileInfo TheFile = new FileInfo(fullpath1);
                        if (TheFile.Exists)
                        {
                            File.Delete(fullpath1);
                        }
                        ImgCoupon.ImageUrl = "";
                        System.Drawing.Image image = System.Drawing.Image.FromStream(fluDefaultCoupon.PostedFile.InputStream);
                        Bitmap myBitmap = ResizeImage(fluDefaultCoupon.PostedFile.InputStream, 666, 256);
                        myBitmap.Save(fullpath2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        myBitmap.Dispose();

                        ImgCoupon.Dispose();
                        ImgCoupon.EnableViewState = false;
                        divError.Visible = false;
                        Banner ObjBanner = new Banner();
                        ObjBanner.UpdateDefaultBannerCouponName(ImageName2);
                        ViewState["DefaultCoupon"] = ImageName2.ToString();
                        Response.Redirect("ManageBaner.aspx", true);

                    }
                    else
                    { ErrMessage("File format not supported"); }
                }
                else
                {
                    ErrMessage("Please select file to upload");
                }
            }
            else
            {
                ErrMessage("Please select file to upload");
            }
        }
        protected void GrdBaner_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdBaner.PageIndex = e.NewPageIndex;
            BindData(Convert.ToInt32(ddlUserType.SelectedValue));
        }
    }
}