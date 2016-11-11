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
using System.Xml;
using advancewebtosolution.BO;


    public partial class Admin_Baner_SetDefaultCouponandBanner : System.Web.UI.Page
    {
        int PageId = 0;
        int UserID = 0;
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
        #endregion

        #region "CreateFillDataTable"
        private void FillDataTableWithRequiredData(DataTable myDataTable)
        {
            int BannerId = 0;
            string BannerName = "";
            string BannerPath = "";
            bool DefaultBan = false;
            bool DefCp = false;
            DataSet ds = new DataSet();
            DataSet dsDefault = new DataSet();
            DataSet dsDefaultCp = new DataSet();
            Banner objB = new Banner();
            ds = objB.GetBannerList();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    BannerId = Convert.ToInt32(ds.Tables[0].Rows[i]["BannerId"]);
                    BannerName = Convert.ToString(ds.Tables[0].Rows[i]["BannerName"]);
                    BannerPath = Convert.ToString(ds.Tables[0].Rows[i]["BannerPath"]);
                    //FindDefault Banner

                    dsDefault = objB.GetoneDefaultBanner(PageId, UserID);
                    if (dsDefault.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["BannerId"]) == Convert.ToInt32(dsDefault.Tables[0].Rows[0]["BannerId"]))
                        {
                            DefaultBan = true;
                        }
                        else
                        {
                            DefaultBan = false;
                        }
                    }
                    //FindDefault Coupon

                    dsDefaultCp = objB.GetoneDefaultCoupon(PageId, UserID);
                    if (dsDefaultCp.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["BannerId"]) == Convert.ToInt32(dsDefaultCp.Tables[0].Rows[0]["BannerId"]))
                        {
                            DefCp = true;
                        }
                        else
                        {
                            DefCp = false;
                        }

                    }
                    AddDataToTable(Convert.ToString(BannerId), BannerName, BannerPath, DefaultBan, myDataTable, DefCp);
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
            myDataColumn.DataType = Type.GetType("System.Boolean");
            myDataColumn.ColumnName = "DefaultBan";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Boolean");
            myDataColumn.ColumnName = "DefCp";
            myDataTable.Columns.Add(myDataColumn);


            //Fill Data Table With Required Data
            FillDataTableWithRequiredData(myDataTable);

            return myDataTable;
        }
        private void AddDataToTable(string BannerId, string BannerName, string BannerPath, bool DefaultBan, DataTable myTable, bool DefCp)
        {
            DataRow row;
            row = myTable.NewRow();

            row["BannerId"] = BannerId;
            row["BannerName"] = BannerName;
            row["BannerPath"] = BannerPath;
            row["DefaultBan"] = DefaultBan;
            row["DefCp"] = DefCp;
            myTable.Rows.Add(row);
        }
        #endregion
        protected void BindData()
        {
            DataTable myDt = new DataTable();
            myDt = CreateDataTable();
            if (myDt.Rows.Count > 0)
            {
                //Sort Data Table
                DataView v = myDt.DefaultView;
                // v.Sort = "Frequency DESC";
                myDt = v.ToTable();

                GrdBaner.Visible = true;
                GrdBaner.DataSource = myDt;
                GrdBaner.DataBind();
                Utility.Setserial(GrdBaner, "srno");
                divError.Visible = false;
            }
            else
            {
                GrdBaner.Visible = false;
                ErrMessage("No banner found");
            }

            lblGridCount.Text = GrdBaner.Rows.Count.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PageId = Convert.ToInt32(ddlPage.SelectedValue);
            UserID = Convert.ToInt32(ddlUserType.SelectedValue);
            if (!IsPostBack)
            {
                Utility objU = new Utility();
                BindData();
                HtmlHead hh = this.Master.Page.Header;
                HtmlMeta hm = new HtmlMeta();
                hm.Attributes.Add("http-equiv", "Refresh");
                hh.Controls.Add(hm);
            }
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
        protected void GrdBaner_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdBaner.PageIndex = e.NewPageIndex;
            BindData();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Banner objB = new Banner();

            PageId = Convert.ToInt32(ddlPage.SelectedValue);
            UserID = Convert.ToInt32(ddlUserType.SelectedValue);
            string PageName = "";
            // PageName = GetPageLabelName(PageId, UserID); 
            PageName = GetPageNameForSequence(PageId, UserID);

            int DefaultBannId = 0;
            int DefaultCouponBannId = 0;
            for (int j = 0; j <= GrdBaner.Rows.Count - 1; j++)
            {

                Label lblBannerId5 = (Label)GrdBaner.Rows[j].FindControl("lblBannerId");
                RadioButton radioDefault = (RadioButton)GrdBaner.Rows[j].FindControl("rdoDefaultBanner");
                CheckBox chkDefaultCoupon = (CheckBox)GrdBaner.Rows[j].FindControl("chkDefaultCoupon");

                if (chkDefaultCoupon.Checked == true)
                {
                    DefaultCouponBannId = Convert.ToInt32(lblBannerId5.Text.ToString());
                }

                if (radioDefault.Checked == true)
                {
                    DefaultBannId = Convert.ToInt32(lblBannerId5.Text.ToString());
                }
            }
            objB.DeleteDefaultCopon(PageId, UserID);
            objB.InsertInDefaultCopon(DefaultCouponBannId, PageId, UserID);

            //delete previous Banner and insert New Banner in defaultBanner table
            objB.DeleteDefaultBanner(PageId, UserID);
            objB.InsertInDefaultBanner(DefaultBannId, PageId, UserID);

            objB.DeletePreviousSetBanner(PageId, UserID);
            DeleteFromXml(PageName);

            DataSet dsDefault = new DataSet();
            DataSet dsDef = new DataSet();
            dsDefault = objB.GetoneDefaultBanner(PageId, UserID);
            if (dsDefault.Tables[0].Rows.Count > 0)
            {
                dsDef = objB.GetBannerImageNameandpath(Convert.ToInt32(dsDefault.Tables[0].Rows[0]["BannerId"].ToString()));
            }
            string DefImageName2 = "";
            string Defvirtualpath2 = "";

            if (dsDef.Tables[0].Rows.Count > 0)
            {
                DefImageName2 = dsDef.Tables[0].Rows[0]["BannerName"].ToString();
                Defvirtualpath2 = dsDef.Tables[0].Rows[0]["BannerPath"].ToString();
            }

            AddBannerToXml(Defvirtualpath2, DefImageName2, DefImageName2, PageName);
            SuccesfullMessage("Default Banner set successfully.");

        }

        //public void AddBannerToXml()
        //{
        //    DataSet dsDefault = new DataSet();
        //    DataSet dsDef = new DataSet();
        //    Banner objB = new Banner();
        //    dsDefault = objB.GetoneDefaultBanner();
        //    if (dsDefault.Tables[0].Rows.Count > 0)
        //    {
        //        dsDef = objB.GetBannerImageNameandpath(Convert.ToInt32(dsDefault.Tables[0].Rows[0]["BannerId"].ToString()));
        //    }
        //    string DefImageName2 = "";
        //    string Defvirtualpath2 = "";

        //    if (dsDef.Tables[0].Rows.Count > 0)
        //    {
        //        DefImageName2 = dsDef.Tables[0].Rows[0]["BannerName"].ToString();
        //        Defvirtualpath2 = dsDef.Tables[0].Rows[0]["BannerPath"].ToString();
        //    }
        //    string imgDefC = "";


        //    DataSet dspagename1 = new DataSet();
        //    Banner objBan=new Banner();
        //    dspagename1 = objBan.GetPagenamefromSetBanner();
        //    int BannerID = 0;
        //    Banner ObjBanner = new Banner();
        //    DataSet ds1 = new DataSet();
        //    DataSet ds2 = new DataSet();
        //    string BannerID1 = "";
        //    if (dspagename1.Tables[0].Rows.Count > 0)
        //    {
        //        for (int j = 0; dspagename1.Tables[0].Rows.Count > j; j++)
        //        {
        //            ds1 = ObjBanner.GetPageanduserTypes(Convert.ToInt32(dspagename1.Tables[0].Rows[j]["userid"].ToString()), Convert.ToInt32(dspagename1.Tables[0].Rows[j]["pageid"].ToString()));

        //            for (int k = 0; ds1.Tables[0].Rows.Count > k; k++)
        //            {
        //                BannerID1 = ds1.Tables[0].Rows[k]["BannerID"].ToString() + ',' + BannerID1;
        //            }
        //        }
        //    }
        //    ds2 = objBan.GetNotPageanduserTypes(BannerID1);
        //    for (int l = 0; ds2.Tables[0].Rows.Count > l; l++)
        //    {

        //            XmlDocument xmldoc = new XmlDocument();
        //            xmldoc.Load(Session["HomePath"].ToString() + "banners_Cat1.xml");
        //            //Create a new node
        //            XmlNodeList Node;
        //            Node = xmldoc.GetElementsByTagName("bannerName");
        //            XmlElement banners = xmldoc.CreateElement("banners");
        //            XmlElement banner = xmldoc.CreateElement("banner");
        //            XmlElement name = xmldoc.CreateElement("name");
        //            XmlElement body = xmldoc.CreateElement("body");
        //            XmlElement imagePath = xmldoc.CreateElement("imagePath");
        //            XmlElement link = xmldoc.CreateElement("link");
        //            XmlElement PageNames = xmldoc.CreateElement("PageNames");

        //            name.InnerText = "New"; 
        //            body.InnerText = "Lorem Ipsum";
        //            imagePath.InnerText = "../StoreData/BannerNew/" + DefImageName2;
        //            link.InnerText = Session["HomePath"] + "PrintCoupon1.aspx?CouponID=" + imgDefC + "&PageName=" + ds2.Tables[0].Rows[l]["pagename"].ToString() + "&PageId=" + Convert.ToInt32(ds2.Tables[0].Rows[l]["pageid"].ToString()) + "&UserId=" + Convert.ToInt32(ds2.Tables[0].Rows[l]["UserCount"].ToString());
        //            //PageNames.InnerText = PageName;
        //            PageNames.InnerText = ds2.Tables[0].Rows[l]["pagename"].ToString();
        //            banner.AppendChild(name);
        //            banner.AppendChild(body);
        //            banner.AppendChild(imagePath);
        //            banner.AppendChild(link);
        //            banner.AppendChild(PageNames);
        //            int tempNodeId1 = 0;
        //            //tempNodeId1 = GetPagesNode();
        //            tempNodeId1 = Convert.ToInt32(ds2.Tables[0].Rows[l]["BannerID"].ToString());
        //            XmlNodeList Node1;
        //            Node1 = xmldoc.GetElementsByTagName("banners");
        //            Node1.Item(tempNodeId1).AppendChild(banner);   // Important Count
        //            XmlNodeList Node2;
        //            Node2 = xmldoc.GetElementsByTagName("bannerName");
        //            Node2.Item(tempNodeId1).FirstChild.InnerText = Node1.Item(tempNodeId1).ChildNodes.Count.ToString();
        //            xmldoc.Save(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "banners_Cat1.xml"));
        //        }
        //}

        public void DeleteFromXml(string PageName)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Session["HomePath"].ToString() + "banners_Cat1.xml");
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
            tempNodeId = GetPagesNode();
            XmlNodeList Node2;
            Node2 = xmldoc.GetElementsByTagName("banners");
            int c = Node2.Item(tempNodeId).ChildNodes.Count;
            XmlNodeList Node3;
            Node3 = xmldoc.GetElementsByTagName("bannerName");
            Node3.Item(tempNodeId).FirstChild.InnerText = Node2.Item(tempNodeId).ChildNodes.Count.ToString();
            xmldoc.Save(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "banners_Cat1.xml"));
        }

        public int GetPagesNode()
        {
            int BannerID = 0;
            Banner ObjBanner = new Banner();
            DataSet ds = ObjBanner.GetPageanduserTypes(Convert.ToInt32(ddlPage.SelectedValue), Convert.ToInt32(ddlUserType.SelectedValue));

            if (ds.Tables[0].Rows.Count > 0)
            {
                BannerID = Convert.ToInt32(ds.Tables[0].Rows[0]["BannerID"].ToString());
            }
            return BannerID;
        }

        public void AddBannerToXml(string tempPath, string ImageName2, string ImageCoupon, string PageName)
        {

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Session["HomePath"].ToString() + "banners_Cat1.xml");
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

            name.InnerText = "New";
            body.InnerText = "Lorem Ipsum";
            imagePath.InnerText = "../StoreData/BannerNew/" + ImageName2;
            link.InnerText = Session["HomePath"] + "PrintCoupon1.aspx?CouponID=" + ImageCoupon + "&PageName=" + ddlPage.SelectedItem.Text + "&PageId=" + Convert.ToInt32(ddlPage.SelectedValue) + "&UserId=" + Convert.ToInt32(ddlUserType.SelectedValue);
            PageNames.InnerText = PageName;
            banner.AppendChild(name);
            banner.AppendChild(body);
            banner.AppendChild(imagePath);
            banner.AppendChild(link);
            banner.AppendChild(PageNames);
            int tempNodeId1 = 0;
            tempNodeId1 = GetPagesNode();
            XmlNodeList Node1;
            Node1 = xmldoc.GetElementsByTagName("banners");
            Node1.Item(tempNodeId1).AppendChild(banner);   // Important Count
            XmlNodeList Node2;
            Node2 = xmldoc.GetElementsByTagName("bannerName");
            Node2.Item(tempNodeId1).FirstChild.InnerText = Node1.Item(tempNodeId1).ChildNodes.Count.ToString();
            xmldoc.Save(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "banners_Cat1.xml"));
        }

        private string GetPageNameForSequence(int PageId, int UserID)
        {
            //For Pages
            //Home
            string pageName = "";
            if (PageId == 0 && UserID == 0) pageName = "Home1";
            if (PageId == 0 && UserID == 1) pageName = "Home2";
            if (PageId == 0 && UserID == 2) pageName = "Home3";
            if (PageId == 0 && UserID == 3) pageName = "Home4";

            //Services
            if (PageId == 1 && UserID == 0) pageName = "Services1";
            if (PageId == 1 && UserID == 1) pageName = "Services2";
            if (PageId == 1 && UserID == 2) pageName = "Services3";
            if (PageId == 1 && UserID == 3) pageName = "Services4";

            // ServiceDetail

            if (PageId == 2 && UserID == 0) pageName = "ServiceD1";
            if (PageId == 2 && UserID == 1) pageName = "ServiceD2";
            if (PageId == 2 && UserID == 2) pageName = "ServiceD3";
            if (PageId == 2 && UserID == 3) pageName = "ServiceD4";

            //Product


            if (PageId == 3 && UserID == 0) pageName = "Product1";
            if (PageId == 3 && UserID == 1) pageName = "Product2";
            if (PageId == 3 && UserID == 2) pageName = "Product3";
            if (PageId == 3 && UserID == 3) pageName = "Product4";

            //Flea
            if (PageId == 4 && UserID == 0) pageName = "Flea1";
            if (PageId == 4 && UserID == 1) pageName = "Flea2";
            if (PageId == 4 && UserID == 2) pageName = "Flea3";
            if (PageId == 4 && UserID == 3) pageName = "Flea4";

            //Fritzy Friend
            if (PageId == 5 && UserID == 0) pageName = "Friend1";
            if (PageId == 5 && UserID == 1) pageName = "Friend2";
            if (PageId == 5 && UserID == 2) pageName = "Friend3";
            if (PageId == 5 && UserID == 3) pageName = "Friend4";

            //About Us
            if (PageId == 6 && UserID == 0) pageName = "AboutUs1";
            if (PageId == 6 && UserID == 1) pageName = "AboutUs2";
            if (PageId == 6 && UserID == 2) pageName = "AboutUs3";
            if (PageId == 6 && UserID == 3) pageName = "AboutUs4";

            //ContactUs
            if (PageId == 7 && UserID == 0) pageName = "ContactUs1";
            if (PageId == 7 && UserID == 1) pageName = "ContactUs2";
            if (PageId == 7 && UserID == 2) pageName = "ContactUs3";
            if (PageId == 7 && UserID == 3) pageName = "ContactUs4";

            //Registration
            if (PageId == 8 && UserID == 0) pageName = "Registration1";
            if (PageId == 8 && UserID == 1) pageName = "Registration2";
            if (PageId == 8 && UserID == 2) pageName = "Registration3";
            if (PageId == 8 && UserID == 3) pageName = "Registration4";

            //NewsDetail

            if (PageId == 9 && UserID == 0) pageName = "News Details1";
            if (PageId == 9 && UserID == 1) pageName = "News Details2";
            if (PageId == 9 && UserID == 2) pageName = "News Details3";
            if (PageId == 9 && UserID == 3) pageName = "News Details4";

            return pageName;
        }

        #region Dropdown Event
        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        #endregion


        //public void DeleteFromXml()
        //{
        //    DataSet dspagename = new DataSet();
        //    Banner objBan=new Banner();
        //    dspagename = objBan.GetPagenamefromSetBanner();
        //    int BannerID = 0;
        //    Banner ObjBanner = new Banner();
        //    DataSet ds = new DataSet();
        //    for (int j = 0; dspagename.Tables[0].Rows.Count > j; j++)
        //    {

        //        ds = ObjBanner.GetPageanduserTypes(Convert.ToInt32(dspagename.Tables[0].Rows[j]["userid"].ToString()), Convert.ToInt32(dspagename.Tables[0].Rows[j]["pageid"].ToString()));

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //           // BannerID = Convert.ToInt32(ds.Tables[0].Rows[i]["BannerID"].ToString());

        //            XmlDocument xmldoc = new XmlDocument();
        //            xmldoc.Load(Session["HomePath"].ToString() + "banners_Cat1.xml");
        //            XmlNodeList Node1;

        //            Node1 = xmldoc.GetElementsByTagName("banner");
        //            int Totalcnt = Node1.Count;
        //            for (int i = 0; i < Node1.Count; i++)
        //            {
        //                XmlElement id = (XmlElement)xmldoc.GetElementsByTagName("banner")[i];

        //                if (id.ChildNodes.Item(4).InnerText.ToString() != dspagename.Tables[0].Rows[j]["pagename"].ToString())
        //                {
        //                    id.ParentNode.RemoveChild(id);
        //                    i = i - 1;
        //                }
        //            }
        //            int tempNodeId = 0;
        //            //tempNodeId = GetPagesNode();
        //            tempNodeId = Convert.ToInt32(ds.Tables[0].Rows[0]["BannerID"].ToString());
        //            XmlNodeList Node2;
        //            Node2 = xmldoc.GetElementsByTagName("banners");
        //            int c = Node2.Item(tempNodeId).ChildNodes.Count;
        //            XmlNodeList Node3;
        //            Node3 = xmldoc.GetElementsByTagName("bannerName");
        //            Node3.Item(tempNodeId).FirstChild.InnerText = Node2.Item(tempNodeId).ChildNodes.Count.ToString();
        //            xmldoc.Save(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "banners_Cat1.xml"));
        //        }
        //    }
        //}

    }
