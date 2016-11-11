using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
using advancewebtosolution.BO;


    public partial class Admin_Baner_UploadBannerNew : System.Web.UI.Page
    {
        int PageId;
        int UserId;
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
            checkid += "alert('Select atleast one banner to delete.');return false;}";
            checkid += "if(flg==1 && id==1){";
            checkid += "if(!confirm('Do you want to delete selected banner from list?')){return false;}}";
            checkid = checkid + "}";
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "myscript2", checkid, true);

            btnDelete.Attributes.Add("onclick", "return val(1);");
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
        #region "CreateFillDataTable"
        private void FillDataTableWithRequiredData(DataTable myDataTable)
        {
            DataSet ds = new DataSet();
            DataSet dsDefault = new DataSet();
            Banner objB = new Banner();
            ds = objB.GetBannerList();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int BannerId = 0;
                    int BId = 0;
                    string BannerName = "";
                    string BannerPath = "";
                    string virtualmobilepath = "";
                    string UsedForms = "";
                    string FormNameList = "";
                    BId = Convert.ToInt32(ds.Tables[0].Rows[i]["BId"]);
                    BannerId = Convert.ToInt32(ds.Tables[0].Rows[i]["BannerId"]);
                    BannerName = Convert.ToString(ds.Tables[0].Rows[i]["BannerName"]);
                    BannerPath = Convert.ToString(ds.Tables[0].Rows[i]["BannerPath"]);
                    virtualmobilepath = Convert.ToString(ds.Tables[0].Rows[i]["virtualmobilepath"]);
                    //virtualmobilepath=Convert.ToString(ds.Tables[0].Rows[i]["virtualmobilepath"]);
                    DataSet ds2 = new DataSet();
                    ds2 = objB.CheckUsedDefaultBanner(BId);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                        {
                            if (j == 4 || j == 8 || j == 12 || j == 16 || j == 20 || j == 24 || j == 28 || j == 32 || j == 36 || j == 40 || j == 44)
                            {
                                FormNameList = FormNameList + Convert.ToString(ds2.Tables[0].Rows[j]["pageName"]) + "," + "<br/>";
                            }
                            else
                            {
                                FormNameList = FormNameList + Convert.ToString(ds2.Tables[0].Rows[j]["pageName"]) + ",";
                            }
                            if (FormNameList == "ContactUs_Unregister")
                            {
                                FormNameList = "ContactUs1";
                            }
                            if (FormNameList == "Service_Unregister")
                            {
                                FormNameList = "Services1";
                            }
                        }
                    }

                    if (FormNameList.Length == 0)
                    {
                        FormNameList = "NOT IN USE";
                    }
                    else
                    {
                        FormNameList = FormNameList.Remove(FormNameList.Length - 1);
                    }

                    //if (FormNameList.Length > 50)
                    //{
                    //    FormNameList = FormNameList.Substring(0, 50) + " <br />" + FormNameList.Substring(50) + "<br />" + FormNameList.Substring(100);
                    //}
                    UsedForms = FormNameList;
                    AddDataToTable(Convert.ToString(BannerId), BannerName, BannerPath, UsedForms, myDataTable, Convert.ToString(BId), virtualmobilepath);
                }
            }


        }
        private DataTable CreateDataTable()
        {
            DataTable myDataTable = new DataTable();
            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "BannerId";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "BannerName";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "BannerPath";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "UsedForms";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "BId";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "virtualmobilepath";
            myDataTable.Columns.Add(myDataColumn);

            //Fill Data Table With Required Data
            FillDataTableWithRequiredData(myDataTable);

            return myDataTable;
        }
        private void AddDataToTable(string BannerId, string BannerName, string BannerPath, string UsedForms, DataTable myTable, string BId, string virtualmobilepath)
        {
            DataRow row;
            row = myTable.NewRow();
            row["BId"] = BId;
            row["BannerId"] = BannerId;
            row["BannerName"] = BannerName;
            row["BannerPath"] = BannerPath;
            row["UsedForms"] = UsedForms;
            row["virtualmobilepath"] = virtualmobilepath;
            myTable.Rows.Add(row);
        }
        #endregion
        protected void BindData()
        {
            DataTable myDt = new DataTable();
            myDt = CreateDataTable();
            if (myDt.Rows.Count > 0)
            {
                BindBannerId();
                ViewState["myDt"] = myDt;

                GrdBaner.Visible = true;
                GrdBaner.DataSource = myDt;
                GrdBaner.DataBind();
                CheckAll();
                check();
                Utility.Setserial(GrdBaner, "srno");
                divError.Visible = false;
            }
            else
            {
                GrdBaner.Visible = false;
                ErrMessage("No banner found");
            }

        }

        private void BindBannerId()
        {
            int cnt = 0;
            int i = 1;
            Banner objB = new Banner();
            DataSet ds = new DataSet();
            ds = objB.GetBannerList();
            if (ds.Tables[1].Rows.Count > 0)
            {
                for (i = 1; i <= ds.Tables[1].Rows.Count; i++)
                {

                    DataRow row = ds.Tables[1].Rows[i - 1];
                    int BId = Convert.ToInt32(row["BId"]);
                    if (i != BId)
                    {
                        cnt++;
                        txtId.Text = Convert.ToString(i);
                        break;
                    }

                }
                if (cnt == 0)
                {
                    txtId.Text = Convert.ToString(i);
                }

            }
            else
            {
                txtId.Text = Convert.ToString(ds.Tables[0].Rows.Count + 1);
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                BindBannerId();
            }
        }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (flv.PostedFile.ToString() == "")
                {
                    BindData();
                    ErrMessage("Please select file to upload.");
                }
                else
                {
                    string ImageName2 = System.IO.Path.GetFileName(flv.PostedFile.FileName);
                    string ImageNameMobile = System.IO.Path.GetFileName(flv.PostedFile.FileName);
                    if (ImageName2 != "")
                    {
                        string ext = System.IO.Path.GetExtension(flv.FileName);
                        string extMobile = System.IO.Path.GetExtension(flv.FileName);
                        if (ImageName2 != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".GIF" || ext == ".jpeg" || ext == ".JPEG" || ext == ".PNG" || ext == ".JPG"
                            && ImageNameMobile != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".GIF" || ext == ".jpeg" || ext == ".JPEG" || ext == ".PNG" || ext == ".JPG")
                        {
                            Banner objB = new Banner();
                            int MaxB = 0;
                            int BId = Convert.ToInt32(txtId.Text);
                            MaxB = objB.GetMaxBannerId();
                            MaxB = MaxB + 1;
                            ImageName2 = Convert.ToString(MaxB) + ImageName2;
                            ImageNameMobile = Convert.ToString(MaxB) + ImageNameMobile;

                            string virtualpath2 = Session["HomePath"] + "StoreData/BannerNew/" + ImageName2;
                            string virtualpathmobile = Session["HomePath"] + "StoreData/MobileBannerNew/" + ImageNameMobile;

                            string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);
                            string fullpathmobile = ContentManager.GetPhysicalPath(virtualpathmobile);

                            System.Drawing.Image image = System.Drawing.Image.FromStream(flv.PostedFile.InputStream);
                            Bitmap myBitmap = ResizeImage(flv.PostedFile.InputStream, 666, 256);
                            myBitmap.Save(fullpath2, System.Drawing.Imaging.ImageFormat.Jpeg);
                            myBitmap.Dispose();

                            System.Drawing.Image imagemobile = System.Drawing.Image.FromStream(flv.PostedFile.InputStream);
                            Bitmap myBitmapmobile = ResizeImage(flv.PostedFile.InputStream, 320, 124);
                            myBitmapmobile.Save(fullpathmobile, System.Drawing.Imaging.ImageFormat.Jpeg);
                            myBitmapmobile.Dispose();

                            objB.InsertInBannerList(ImageName2, virtualpath2, BId, virtualpathmobile);
                            divError.Visible = true;
                            SuccesfullMessage("Banner uploaded successfully.");
                            BindData();
                        }
                        else
                        {
                            BindData();
                            ErrMessage("File format not supported");
                        }
                    }
                    else
                    {
                        BindData();
                        ErrMessage("Please select file to upload.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
        #region "Grid Events"
        protected void GrdBaner_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdBaner.PageIndex = e.NewPageIndex;
            BindData();
        }
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
            BindData();
        }
        #endregion
        protected void btnDelete_Click(object sender, EventArgs e)
        {


            for (int i = 0; i <= GrdBaner.Rows.Count - 1; i++)
            {
                CheckBox chk = (CheckBox)GrdBaner.Rows[i].FindControl("chkSelect");
                if (chk.Checked)
                {
                    Label lblId = (Label)GrdBaner.Rows[i].FindControl("lblId");

                    Label lblUserForms = (Label)GrdBaner.Rows[i].FindControl("lblUserForms");

                    Banner objB = new Banner();
                    objB.DeleteUnusedBanner(Convert.ToInt32(lblId.Text));
                    SuccesfullMessage("Selected banner deleted successfully.");

                }
            }
            BindData();
            //ManageBannerSequence();
            SetBannerinXML();
            // SetBannersInXML();


        }



        #region "Create XML"

        private void SetBannerinXML()
        {
            BannerOrder objBannerOrder = new BannerOrder();
            string virtualpath2 = string.Empty;
            string virtualpathmobile = string.Empty;
            string ImageName2 = string.Empty;
            string BannerId = string.Empty;
            string PgName = string.Empty;
            string IsCoupon = string.Empty;

            DataTable OrderDt = (DataTable)ViewState["myDt"];
            DataSet dsDefault = new DataSet();
            DataSet dsPages = new DataSet();
            dsPages = objBannerOrder.GetPagesNames();
            for (int j = 0; j < dsPages.Tables[0].Rows.Count; j++)
            {
                DataRow PageRow = dsPages.Tables[0].Rows[j];
                PageId = Convert.ToInt32(PageRow["PageId"]);
                UserId = Convert.ToInt32(PageRow["UserId"]);
                dsDefault = objBannerOrder.GetBannerList(PageId, UserId);
                string strPgName = GetPageNameForSequence(Convert.ToString(PageId), Convert.ToString(UserId));
                DeleteFromXml(strPgName, PageId, UserId);

                for (int k = 0; k < dsDefault.Tables[0].Rows.Count; k++)
                {
                    DataRow BannerRow = dsDefault.Tables[0].Rows[k];
                    BannerId = Convert.ToString(BannerRow["BannerID"]);
                    for (int i = 0; i < OrderDt.Rows.Count; i++)
                    {
                        DataRow defaultRow = OrderDt.Rows[i];
                        if (BannerId == Convert.ToString(defaultRow["BId"]))
                        {
                            virtualpath2 = Convert.ToString(defaultRow["BannerPath"]);
                            virtualpathmobile = Convert.ToString(defaultRow["virtualmobilepath"]);
                            ImageName2 = Convert.ToString(defaultRow["BannerName"]);
                            AddBannerToXml(virtualpath2, ImageName2, IsCoupon, strPgName, Convert.ToString(PageId), Convert.ToString(UserId), virtualpathmobile, BannerId);
                        }
                    }
                }

            }


        }

        private string GetPageNameForSequence(string PageId, string UserID)
        {
            string strPageName = string.Empty;
            switch (PageId)
            {
                case "0":
                    switch (UserID)
                    {
                        case "0":
                            strPageName = "Home1";
                            break;
                        case "1":
                            strPageName = "Home2";
                            break;
                        case "2":
                            strPageName = "Home3";
                            break;
                        case "3":
                            strPageName = "Home4";
                            break;
                        default: break;
                    }
                    break;
                case "1":
                    switch (UserID)
                    {
                        case "0":
                            strPageName = "Service_Unregister";
                            break;
                        case "1":
                            strPageName = "Services2";
                            break;
                        case "2":
                            strPageName = "Services3";
                            break;
                        case "3":
                            strPageName = "Services4";
                            break;
                        default: break;
                    }
                    break;
                case "2":
                    switch (UserID)
                    {
                        case "0":
                            strPageName = "ServiceDetail1";
                            break;
                        case "1":
                            strPageName = "ServiceDetail2";
                            break;
                        case "2":
                            strPageName = "ServiceDetail3";
                            break;
                        case "3":
                            strPageName = "ServiceDetail4";
                            break;
                        default: break;
                    }
                    break;
                case "3":
                    switch (UserID)
                    {
                        case "0":
                            strPageName = "Product1";
                            break;
                        case "1":
                            strPageName = "Product2";
                            break;
                        case "2":
                            strPageName = "Product3";
                            break;
                        case "3":
                            strPageName = "Product4";
                            break;
                        default: break;
                    }
                    break;
                case "4":
                    switch (UserID)
                    {
                        case "0":
                            strPageName = "Flea1";
                            break;
                        case "1":
                            strPageName = "Flea2";
                            break;
                        case "2":
                            strPageName = "Flea3";
                            break;
                        case "3":
                            strPageName = "Flea4";
                            break;
                        default: break;
                    }
                    break;
                case "5":
                    switch (UserID)
                    {
                        case "0":
                            strPageName = "FritzyFriend1";
                            break;
                        case "1":
                            strPageName = "Friend2";
                            break;
                        case "2":
                            strPageName = "Friend3";
                            break;
                        case "3":
                            strPageName = "Friend4";
                            break;
                        default: break;
                    }
                    break;
                case "6":
                    switch (UserID)
                    {
                        case "0":
                            strPageName = "AboutUs1";
                            break;
                        case "1":
                            strPageName = "AboutUs2";
                            break;
                        case "2":
                            strPageName = "AboutUs3";
                            break;
                        case "3":
                            strPageName = "AboutUs4";
                            break;
                        default: break;
                    }
                    break;
                case "7":
                    switch (UserID)
                    {
                        case "0":
                            strPageName = "ContactUs_Unregister";
                            break;
                        case "1":
                            strPageName = "ContactUs2";
                            break;
                        case "2":
                            strPageName = "ContactUs3";
                            break;
                        case "3":
                            strPageName = "ContactUs4";
                            break;
                        default: break;
                    }
                    break;
                case "8":
                    switch (UserID)
                    {
                        case "0":
                            strPageName = "Registration1";
                            break;
                        case "1":
                            strPageName = "Registration2";
                            break;
                        case "2":
                            strPageName = "Registration3";
                            break;
                        case "3":
                            strPageName = "Registration4";
                            break;
                        default: break;
                    }
                    break;
                case "9":
                    switch (UserID)
                    {
                        case "0":
                            strPageName = "NewsDetail1";
                            break;
                        case "1":
                            strPageName = "NewsDetail2";
                            break;
                        case "2":
                            strPageName = "NewsDetail3";
                            break;
                        case "3":
                            strPageName = "NewsDetail4";
                            break;
                        default: break;
                    }
                    break;
                case "10":
                    switch (UserID)
                    {
                        case "0":
                            strPageName = "MobilePage1";
                            break;
                        case "1":
                            strPageName = "MobilePage2";
                            break;
                        case "2":
                            strPageName = "MobilePage3";
                            break;
                        case "3":
                            strPageName = "MobilePage4";
                            break;
                    }
                    break;


            }
            return strPageName;
        }
        public void AddBannerToXml(string tempPath, string ImageName2, string ImageCoupon, string PageName, string PageId, string UserId, string virtualpathmobile, string BannerId)
        {

            XmlDocument xmldoc = new XmlDocument();
            string homepath = Session["HomePath"].ToString();
            xmldoc.Load(Session["HomePath"].ToString() + BannerOrder.BannerXml);
            //Create a new node
            XmlNodeList Node;
            Node = xmldoc.GetElementsByTagName("bannerName");
            XmlElement banners = xmldoc.CreateElement("banners");
            XmlElement banner = xmldoc.CreateElement("banner");
            XmlElement name = xmldoc.CreateElement("name");
            XmlElement body = xmldoc.CreateElement("body");
            XmlElement imagePath = xmldoc.CreateElement("imagePath");
            XmlElement link = xmldoc.CreateElement("link");
            XmlElement PageNames = xmldoc.CreateElement("PageNames");
            XmlElement virtualmobilepath = xmldoc.CreateElement("virtualmobilepath1");
            XmlElement BannerId1 = xmldoc.CreateElement("BannerId");

            name.InnerText = "New";
            body.InnerText = "Lorem Ipsum";
            imagePath.InnerText = "../StoreData/BannerNew/" + ImageName2;
            link.InnerText = Session["HomePath"] + "PrintCoupon1.aspx?CouponID=" + ImageCoupon + "&PageName=" + PageName + "&PageId=" + PageId + "&UserId=" + UserId;
            PageNames.InnerText = PageName;
            virtualmobilepath.InnerText = "../StoreData/MobileBannerNew/" + ImageName2;
            BannerId1.InnerText = BannerId;

            banner.AppendChild(name);
            banner.AppendChild(body);
            banner.AppendChild(imagePath);
            banner.AppendChild(link);
            banner.AppendChild(PageNames);
            banner.AppendChild(virtualmobilepath);
            banner.AppendChild(BannerId1);
            int tempNodeId1 = 0;
            tempNodeId1 = GetPagesNode(Convert.ToInt32(PageId), Convert.ToInt32(UserId));
            XmlNodeList Node1;
            Node1 = xmldoc.GetElementsByTagName("banners");
            Node1.Item(tempNodeId1).AppendChild(banner);   // Important Count
            XmlNodeList Node2;
            Node2 = xmldoc.GetElementsByTagName("bannerName");
            Node2.Item(tempNodeId1).FirstChild.InnerText = Node1.Item(tempNodeId1).ChildNodes.Count.ToString();
            xmldoc.Save(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + BannerOrder.BannerXml));

        }

        public int GetPagesNode(int pgId, int usId)
        {
            int BannerID = 0;
            Banner ObjBanner = new Banner();
            DataSet ds = ObjBanner.GetPageanduserTypes(pgId, usId);

            if (ds.Tables[0].Rows.Count > 0)
            {
                BannerID = Convert.ToInt32(ds.Tables[0].Rows[0]["BannerID"].ToString());
            }
            return BannerID;
        }
        public void DeleteFromXml(string PageName, int PageId, int UserId)
        {
            int PId = PageId;
            int UId = UserId;
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Session["HomePath"].ToString() + BannerOrder.BannerXml);
            XmlNodeList Node1;

            Node1 = xmldoc.GetElementsByTagName("banner");
            int Totalcnt = Node1.Count;
            for (int i = 0; i < Node1.Count; i++)
            {
                XmlElement id = (XmlElement)xmldoc.GetElementsByTagName("banner")[i];

                if (id.ChildNodes.Item(4).InnerText.ToString() == PageName)
                {
                    id.ParentNode.RemoveChild(id);
                    i = i - 1;
                }
            }
            int tempNodeId = 0;
            tempNodeId = GetPagesNode(PId, UId);
            XmlNodeList Node2;
            Node2 = xmldoc.GetElementsByTagName("banners");
            int c = Node2.Item(tempNodeId).ChildNodes.Count;
            XmlNodeList Node3;
            Node3 = xmldoc.GetElementsByTagName("bannerName");
            Node3.Item(tempNodeId).FirstChild.InnerText = Node2.Item(tempNodeId).ChildNodes.Count.ToString();
            xmldoc.Save(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "banners_Cat1.xml"));
        }
        #endregion
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageBaners.aspx");
        }
        protected void GrdBaner_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }


    }
