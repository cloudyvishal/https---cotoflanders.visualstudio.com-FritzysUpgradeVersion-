using System;
using System.Data;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;
using System.Drawing;
using System.Xml;
using advancewebtosolution.BO;

namespace advancewebtosolution
{
    public partial class Admin_Baner_ManageBanerNew : System.Web.UI.Page
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


        #endregion
        #region "CreateFillDataTable"
        private void FillDataTableWithRequiredData(DataTable myDataTable)
        {
            DataSet ds = new DataSet();
            DataSet dsDefault = new DataSet();
            Banner objB = new Banner();
            ds = objB.GetBannerList();

            int PageId = 0;
            int UserID = 0;
            PageId = Convert.ToInt32(ddlPage.SelectedValue);
            UserID = Convert.ToInt32(ddlUserType.SelectedValue);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int BannerId = 0;
                    string BannerName = "";
                    string BannerPath = "";

                    BannerId = Convert.ToInt32(ds.Tables[0].Rows[i]["BannerId"]);
                    BannerName = Convert.ToString(ds.Tables[0].Rows[i]["BannerName"]);
                    BannerPath = Convert.ToString(ds.Tables[0].Rows[i]["BannerPath"]);

                    //Find frequency and iscoupon
                    DataSet ds1 = new DataSet();
                    ds1 = objB.GetFrequencyFromSetBanner(BannerId, UserID, PageId);
                    int Freq = 0;
                    bool isCop = false;
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        Freq = Convert.ToInt32(ds1.Tables[0].Rows[0]["frequency"]);
                        isCop = Convert.ToBoolean(ds1.Tables[0].Rows[0]["iscoupon"]);
                    }
                    //FindDefault Banner
                    bool DefaultBan = false;
                    dsDefault = objB.GetDefaultBanner(PageId, UserID, BannerId);
                    if (dsDefault.Tables[0].Rows.Count > 0)
                    {
                        DefaultBan = true;
                        isCop = Convert.ToBoolean(dsDefault.Tables[0].Rows[0]["IsDefaultCoupon"]);
                    }
                    AddDataToTable(Convert.ToString(BannerId), BannerName, BannerPath, DefaultBan, isCop, Freq, myDataTable);
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
            myDataColumn.ColumnName = "IsDefaultCoupon";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Boolean");
            myDataColumn.ColumnName = "IsCoupon";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "Frequency";
            myDataTable.Columns.Add(myDataColumn);

            //Fill Data Table With Required Data
            FillDataTableWithRequiredData(myDataTable);

            return myDataTable;
        }
        private void AddDataToTable(string BannerId, string BannerName, string BannerPath, bool IsDefaultCoupon, bool IsCoupon, int Frequency, DataTable myTable)
        {
            DataRow row;
            row = myTable.NewRow();

            row["BannerId"] = BannerId;
            row["BannerName"] = BannerName;
            row["BannerPath"] = BannerPath;
            row["IsDefaultCoupon"] = IsDefaultCoupon;
            row["IsCoupon"] = IsCoupon;
            row["Frequency"] = Frequency;
            myTable.Rows.Add(row);
        }
        #endregion
        #region "Set Possion of Banner"
        private int[] GetBannerPostionArray(int[] BannerIdA, int[] FreqA)
        {
            int[] BanrIdArr = BannerIdA;
            int[] FrequencyArr = FreqA;
            int M = 0;
            for (int i = 0; i < FrequencyArr.Length; i++)
            {
                M = M + FrequencyArr[i];
            }
            int[] PositionArray = new int[M];
            int BanId = 0;
            int Freq = 0;
            for (int j = 0; j < FrequencyArr.Length; j++)
            {
                BanId = BanrIdArr[j];
                double X = 0;
                int XP = 0;
                Freq = FrequencyArr[j];
                X = j;
                for (int k = 0; k < Freq; k++)
                {
                    X = j + ((double)(M * k) / (double)Freq);
                    X = Math.Round(X, MidpointRounding.AwayFromZero);
                    XP = Convert.ToInt32(X);
                    if (PositionArray[XP] <= 0)
                    {
                        PositionArray[XP] = BanId;
                    }
                    else
                    {
                        for (int cnt = 0; cnt < M; cnt++)
                        {
                            int Prev = 0;
                            int nxt = 0;
                            Prev = cnt - 1;
                            nxt = cnt + 1;
                            if (cnt == 0) Prev = 0;
                            if (cnt == M - 1) nxt = M - 1;
                            if (PositionArray[Prev] == BanId || PositionArray[nxt] == BanId)
                            {
                            }
                            else
                            {
                                if (PositionArray[cnt] <= 0)
                                {
                                    PositionArray[cnt] = BanId;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            for (int z = 0; z < PositionArray.Length; z++)
            {
                if (PositionArray[z] == 0)
                {
                    PositionArray[z] = BanrIdArr[0];
                }
            }
            return PositionArray;
        }
        private int[] GetDecendingFreqArray()
        {
            int PageId = 0;
            int UserID = 0;
            int[] BannP = null;
            PageId = Convert.ToInt32(ddlPage.SelectedValue);
            UserID = Convert.ToInt32(ddlUserType.SelectedValue);
            Banner objB = new Banner();
            DataSet ds = new DataSet();
            ds = objB.GetBannerIdFrequencyFromSetBanner(UserID, PageId);
            int cnt = ds.Tables[0].Rows.Count;
            if (cnt > 0)
            {
                int[] BanrIdArr = new int[cnt];
                int[] FrequencyArr = new int[cnt];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    BanrIdArr[i] = Convert.ToInt32(ds.Tables[0].Rows[i]["BannerId"]);
                    FrequencyArr[i] = Convert.ToInt32(ds.Tables[0].Rows[i]["frequency"]);
                }
                BannP = GetBannerPostionArray(BanrIdArr, FrequencyArr);
            }
            return BannP;
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
                v.Sort = "Frequency DESC";
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
            //DataSet ds = new DataSet();
            //Banner objB = new Banner();
            //ds = objB.GetBannerList();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    GrdBaner.Visible = true;

            //    GrdBaner.DataSource = ds;
            //    GrdBaner.DataBind();
            //    Utility.Setserial(GrdBaner, "srno");
            //   divError.Visible = false;
            //}
            //else
            //{
            //    GrdBaner.Visible = false;          
            //    ErrMessage("No banner found" );
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //DataSet ds = new DataSet();
                //ds = objB.GetUserTypeList();
                //DataSet ds1 = new DataSet();
                //ds1 = objB.GetPageTitleList();
                //objU.FillDropDownList(ddlPage, ds1, "PageId", "PageName", "", "", "");
                //objU.FillDropDownList(ddlUserType, ds, "UserId", "UserName", "", "", "");
                //Banner newObj = new Banner();
                //DataSet ds = newObj.GetDefaultCouponName();
                //ImgCoupon.ImageUrl = Session["HomePath"] + "StoreData/Coupon/" + ds.Tables[0].Rows[0]["DefaultCouponName"].ToString();
                //ViewState["DefaultCoupon"] = ds.Tables[0].Rows[0]["DefaultCouponName"].ToString();

                Utility objU = new Utility();
                BindData();
                HtmlHead hh = this.Master.Page.Header;
                HtmlMeta hm = new HtmlMeta();
                hm.Attributes.Add("http-equiv", "Refresh");
                hh.Controls.Add(hm);
                string s = ddlUserType.SelectedItem.Text;
            }
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

        protected void GrdBaner_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Banner objB = new Banner();
            //int PageId = 0;
            //int UserID = 0;
            //PageId = Convert.ToInt32(ddlPage.SelectedValue);
            //UserID = Convert.ToInt32(ddlUserType.SelectedValue);
            //for (int i = 0; i <= GrdBaner.Rows.Count - 1; i++)
            //{
            //    CheckBox chkCoupon = (CheckBox)GrdBaner.Rows[i].FindControl("chkCoupon");
            //    Label lblBannerId = (Label)GrdBaner.Rows[i].FindControl("lblBannerId");
            //    TextBox txtFrequency = (TextBox)GrdBaner.Rows[i].FindControl("txtFrequency");

            //    DataSet ds = new DataSet();            
            //    ds = objB.GetFrequencyFromSetBanner(Convert.ToInt32(lblBannerId.Text),UserID,PageId);

            //    int Freq = 0;
            //    bool isCop = false;
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        Freq = Convert.ToInt32(ds.Tables[0].Rows[0]["frequency"]);
            //        isCop = Convert.ToBoolean(ds.Tables[0].Rows[0]["iscoupon"]);              
            //    }
            //    chkCoupon.Checked = isCop;
            //    txtFrequency.Text = Convert.ToString(Freq);
            //    ds.Dispose();
            //}
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
        private string GetPageLabelName(int PageId, int UserID)
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

            if (PageId == 2 && UserID == 0) pageName = "ServiceDetail1";
            if (PageId == 2 && UserID == 1) pageName = "ServiceDetail2";
            if (PageId == 2 && UserID == 2) pageName = "ServiceDetail3";
            if (PageId == 2 && UserID == 3) pageName = "ServiceDetail4";

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
            if (PageId == 5 && UserID == 0) pageName = "FritzyFriend1";
            if (PageId == 5 && UserID == 1) pageName = "FritzyFriend2";
            if (PageId == 5 && UserID == 2) pageName = "FritzyFriend3";
            if (PageId == 5 && UserID == 3) pageName = "FritzyFriend4";

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

            if (PageId == 9 && UserID == 0) pageName = "NewsDetail1";
            if (PageId == 9 && UserID == 1) pageName = "NewsDetail2";
            if (PageId == 9 && UserID == 2) pageName = "NewsDetail3";
            if (PageId == 9 && UserID == 3) pageName = "NewsDetail4";

            return pageName;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ids = 0;
            Banner objB = new Banner();
            int PageId = 0;
            int UserID = 0;
            PageId = Convert.ToInt32(ddlPage.SelectedValue);
            UserID = Convert.ToInt32(ddlUserType.SelectedValue);
            string PageName = "";
            PageName = GetPageLabelName(PageId, UserID);
            int cnt = 0;
            int DefaultBannId = 0;
            bool DefaultCoupon = false;
            int cntRdo = 0;
            for (int j = 0; j <= GrdBaner.Rows.Count - 1; j++)
            {
                TextBox txtFrequency1 = (TextBox)GrdBaner.Rows[j].FindControl("txtFrequency");
                Label lblBannerId5 = (Label)GrdBaner.Rows[j].FindControl("lblBannerId");
                RadioButton radioDefault = (RadioButton)GrdBaner.Rows[j].FindControl("rdoDefaultBanner");
                CheckBox chkCoupon5 = (CheckBox)GrdBaner.Rows[j].FindControl("chkCoupon");
                if (txtFrequency1.Text.Trim() == "") txtFrequency1.Text = "0";
                if (Convert.ToInt32(txtFrequency1.Text) > 0)
                {
                    cnt = cnt + 1;
                }

                if (radioDefault.Checked == true)
                {
                    cntRdo = cntRdo + 1;
                }
                //string check = Request.Form["gvradio"] ;
                if (radioDefault.Checked == true)
                {
                    DefaultBannId = Convert.ToInt32(lblBannerId5.Text);
                    DefaultCoupon = chkCoupon5.Checked;
                }

            }
            if (cntRdo == 0)
            {
                RadioButton radioDefault1 = (RadioButton)GrdBaner.Rows[0].FindControl("rdoDefaultBanner");
                radioDefault1.Checked = true;
                Label lblBannerId7 = (Label)GrdBaner.Rows[0].FindControl("lblBannerId");
                CheckBox chkCoupon7 = (CheckBox)GrdBaner.Rows[0].FindControl("chkCoupon");
                DefaultBannId = Convert.ToInt32(lblBannerId7.Text);
                DefaultCoupon = chkCoupon7.Checked;
            }
            if (cnt == 0)
            {
                objB.DeleteDefaultBanner(PageId, UserID);
                objB.DeletePreviousSetBanner(PageId, UserID);
                //            objB.InsertInDefaultBanner(PageId, UserID, DefaultBannId, "", "", DefaultCoupon);
                DeleteFromXml(PageName);
                ///////////
                DataSet dsDef = new DataSet();
                dsDef = objB.GetBannerImageNameandpath(DefaultBannId);

                string DefImageName2 = "";
                string Defvirtualpath2 = "";

                if (dsDef.Tables[0].Rows.Count > 0)
                {
                    DefImageName2 = dsDef.Tables[0].Rows[0]["BannerName"].ToString();
                    Defvirtualpath2 = dsDef.Tables[0].Rows[0]["BannerPath"].ToString();
                }
                string imgDefC = "";
                if (DefaultCoupon == false)
                {
                    imgDefC = "No";
                }
                else
                {
                    imgDefC = DefImageName2;
                }
                AddBannerToXml(Defvirtualpath2, DefImageName2, imgDefC, PageName);
                SuccesfullMessage("Default Banner set successfully.");
                return;
            }
            for (int k = 0; k <= GrdBaner.Rows.Count - 1; k++)
            {
                TextBox txtFrequency2 = (TextBox)GrdBaner.Rows[k].FindControl("txtFrequency");
                if (cnt == 1) cnt = 2;
                if (Convert.ToInt32(txtFrequency2.Text) >= cnt)
                {
                    ErrMessage("Set Correct Frequency.");
                    return;
                }
            }
            //delete previous set frequency of that page and usertype
            objB.DeletePreviousSetBanner(PageId, UserID);
            for (int i = 0; i <= GrdBaner.Rows.Count - 1; i++)
            {

                CheckBox chkCoupon = (CheckBox)GrdBaner.Rows[i].FindControl("chkCoupon");
                Label lblBannerId = (Label)GrdBaner.Rows[i].FindControl("lblBannerId");
                TextBox txtFrequency = (TextBox)GrdBaner.Rows[i].FindControl("txtFrequency");
                if (Convert.ToInt32(txtFrequency.Text) > 0)
                {
                    //          ids = objB.InsertInSetBanner(PageId, UserID, Convert.ToInt32(lblBannerId.Text), Convert.ToInt32(txtFrequency.Text), chkCoupon.Checked, PageName);
                }
            }
            // SuccesfullMessage("Banner set successfully.");
            int[] PositionArray = GetDecendingFreqArray();

            string ImageName2 = "";
            string virtualpath2 = "";

            //Delete prevoius nodes elements from XML
            DeleteFromXml(PageName);

            //using position of banner in the array rotating the loop
            for (int s = 0; PositionArray.Length > s; s++)
            {
                string ImageCoupon = "";
                int BanrId = 0;
                BanrId = PositionArray[s];
                string PageName1 = "";
                Banner objB1 = new Banner();
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                DataSet dsCoupon = new DataSet();
                ds = objB1.GetBannerImageNameandpath(BanrId);
                ds1 = objB1.GetPagesNameFromSetBanners(ids);
                dsCoupon = objB1.CheckIsCoupon(PageId, UserID, BanrId);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ImageName2 = ds.Tables[0].Rows[0]["BannerName"].ToString();
                    virtualpath2 = ds.Tables[0].Rows[0]["BannerPath"].ToString();
                }

                if (dsCoupon.Tables[0].Rows.Count > 0)
                {
                    bool s1 = Convert.ToBoolean(dsCoupon.Tables[0].Rows[0]["IsCoupon"].ToString());

                    if (s1 == true)
                    {
                        ImageCoupon = ImageName2;
                    }
                    else
                    {
                        ImageCoupon = "No";
                    }
                }
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    PageName1 = ds1.Tables[0].Rows[0]["pagename"].ToString();
                }

                //Add nodes in to XML
                AddBannerToXml(virtualpath2, ImageName2, ImageCoupon, PageName);
            }
            BindData();
            SuccesfullMessage("Banner set successfully.");

        }

        /* As banner rotating through flash so that we need add this information to the .XML file */
        public void AddBannerToXml(string tempPath, string ImageName2, string ImageCoupon, string PageName)
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
            XmlElement PageNames = xmldoc.CreateElement("PageNames");

            name.InnerText = "New";
            body.InnerText = "Lorem Ipsum";
            imagePath.InnerText = "../StoreData/BannerNew/" + ImageName2;
            //link.InnerText = Session["HomePath"] + "PrintCoupon.aspx?CouponID=" + ImageCoupon + "&PageName=" + ddlPage.SelectedItem.Text;
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
            xmldoc.Save(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "banners_Cat.xml"));
        }

        public void DeleteFromXml(string PageName)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Session["HomePath"].ToString() + "banners_Cat.xml");
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
            xmldoc.Save(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "banners_Cat.xml"));
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
    }
}
