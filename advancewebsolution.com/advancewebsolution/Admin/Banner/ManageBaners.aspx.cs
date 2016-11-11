using advancewebtosolution.BO;
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Xml;
public partial class ManageBaners : System.Web.UI.Page
{
    #region "Declare Variables"
    PagedDataSource pgds = new PagedDataSource();
    PagedDataSource pgdsbannerlist = new PagedDataSource();
    DataSet ds = new DataSet();
    int PageId = 0;
    int UserID = 0;
    int cnt;
    #endregion

    #region "Page Load"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            BindSequenceData();
            SetBannersInXML();
        }
    }
    #endregion

    #region "Manage orders"
    private void BindSequenceData()
    {
        BannerOrder objOrder = new BannerOrder();
        DataSet dsOrder = new DataSet();
        PageId = Convert.ToInt32(ddlPage.SelectedValue);
        UserID = Convert.ToInt32(ddlUserType.SelectedValue);
        cnt = 0;
        dsOrder = objOrder.GetBannerList(PageId, UserID);
        if (dsOrder.Tables.Count > 0)
        {
            pgds.AllowPaging = true;
            pgds.PageSize = 100000;
            pgds.DataSource = dsOrder.Tables[0].DefaultView;
            //lblMsg.Text = "";
            dtlOrder.Visible = true;
            dtlOrder.DataSource = pgds;
            dtlOrder.DataBind();
        }

    }
    #endregion

    #region "Functions"

    protected void BindData()
    {
        try
        {
            DataTable myDt = new DataTable();
            myDt = CreateDataTable();
            if (myDt.Rows.Count > 0)
            {
                ViewState["myDt"] = myDt;
                divError.Visible = false;
                pgdsbannerlist.AllowPaging = true;
                pgdsbannerlist.PageSize = 1000;
                pgdsbannerlist.DataSource = myDt.DefaultView;
                dtBannerlIst.Visible = true;
                dtBannerlIst.DataSource = pgdsbannerlist;
                dtBannerlIst.DataBind();
            }
            else
            {
                ErrMessage("No banner found");
            }
        }
        catch
        { }
    }
    private DataTable CreateDataTable()
    {
        try
        {
            DataTable myDataTable = new DataTable();
            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "BannerId";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "virtualmobilepath";
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

            //Fill Data Table With Required Data
            FillDataTableWithRequiredData(myDataTable);

            return myDataTable;
        }
        catch (Exception ex) { throw ex; }
    }
    private void FillDataTableWithRequiredData(DataTable myDataTable)
    {
        try
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
                    string UsedForms = "";
                    string virtualmobilepath = "";
                    BId = Convert.ToInt32(ds.Tables[0].Rows[i]["BId"]);
                    BannerId = Convert.ToInt32(ds.Tables[0].Rows[i]["BannerId"]);
                    BannerName = Convert.ToString(ds.Tables[0].Rows[i]["BannerName"]);
                    BannerPath = Convert.ToString(ds.Tables[0].Rows[i]["BannerPath"]);
                    virtualmobilepath = Convert.ToString(ds.Tables[0].Rows[i]["virtualmobilepath"]);
                    //Find Set Banner
                    DataSet ds1 = new DataSet();
                    ds1 = objB.CheckUsedBannerList(BannerId);
                    string FormNameList = "";
                    if (ds1.Tables[0].Rows.Count > 0)
                    {

                        for (int k = 0; k < ds1.Tables[0].Rows.Count; k++)
                        {
                            string pgNm = "";
                            pgNm = Convert.ToString(ds1.Tables[0].Rows[k]["pageName"]);
                            FormNameList = FormNameList + ", " + pgNm;
                        }
                        FormNameList = FormNameList.Remove(0, 1);
                    }
                    //Find is Banner Set Default For any Form
                    DataSet ds2 = new DataSet();
                    ds2 = objB.CheckUsedDefaultBanner(BannerId);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                        {
                            FormNameList = FormNameList + ", Default-" + Convert.ToString(ds2.Tables[0].Rows[j]["pageName"]);
                        }
                    }
                    if (FormNameList.Length == 0) FormNameList = "NOT IN USE";
                    UsedForms = FormNameList;
                    AddDataToTable(Convert.ToString(BannerId), BannerName, BannerPath, UsedForms, myDataTable, Convert.ToString(BId), virtualmobilepath);
                }
            }
        }
        catch
        { }
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

    #region "Error Message"
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

    #region "Dropdown Events"
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindSequenceData();
        SetBannersInXML();
    }
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSequenceData();
        SetBannersInXML();
    }
    #endregion


    #region "Save Button"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SetBannersInXML();
    }
    #endregion

    #region "XML Functions"
    private void SetBannersInXML()
    {
        try
        {
            Banner objB = new Banner();
            BannerOrder objBannerOrder = new BannerOrder();
            PageId = Convert.ToInt32(ddlPage.SelectedValue);
            UserID = Convert.ToInt32(ddlUserType.SelectedValue);
            string PageName = string.Empty;
            string virtualpath2 = string.Empty;
            string virtualmobilepath = string.Empty;
            string ImageName2 = string.Empty;
            string BannerId = string.Empty;
            string PgName = string.Empty;
            string IsCoupon = string.Empty;
            int boolIscoupon = 0;
            string strPgName = GetPageNameForSequence(Convert.ToString(PageId), Convert.ToString(UserID));
            DeleteFromXml(strPgName, PageId, UserID);
            DataTable OrderDt = (DataTable)ViewState["myDt"];
            foreach (DataListItem item in dtlOrder.Items)
            {
                TextBox myTextBox = (TextBox)item.FindControl("txtId");
                Label lblPageName = (Label)item.FindControl("lblPageName");
                Label lblIsCoupon = (Label)item.FindControl("lblIsCoupon");
                Label lblId = (Label)item.FindControl("lblId");
                CheckBox chkIsCOupon = (CheckBox)item.FindControl("chkIsCOupon");
                if (chkIsCOupon.Checked)
                {
                    boolIscoupon = 1;
                }
                else
                {
                    boolIscoupon = 0;
                }

                BannerId = myTextBox.Text;
                PgName = strPgName;
                IsCoupon = lblIsCoupon.Text;
                int Id = Convert.ToInt32(lblId.Text);
                if (BannerId != "")
                {
                    for (int i = 0; i < OrderDt.Rows.Count; i++)
                    {
                        DataRow row = OrderDt.Rows[i];
                        if (BannerId == Convert.ToString(row["BId"]))
                        {
                            virtualpath2 = Convert.ToString(row["BannerPath"]);
                            ImageName2 = Convert.ToString(row["BannerName"]);
                            virtualmobilepath = Convert.ToString(row["virtualmobilepath"]);
                            objBannerOrder.UpdateBannerSequence(Id, Convert.ToInt32(BannerId), boolIscoupon);
                            if (PageId != 12)
                            {
                                AddBannerToXml(virtualpath2, ImageName2, IsCoupon, strPgName, Convert.ToString(PageId), Convert.ToString(UserID), virtualmobilepath, BannerId);
                            }
                            break;
                        }
                        else
                        {
                            objBannerOrder.UpdateBannerSequence(Id, 0, 0);
                        }


                    }
                }
                else
                {
                    objBannerOrder.UpdateBannerSequence(Id, 0, 0);
                }

            }
            DataSet dsDefault = new DataSet();
            int emtCnt = 0;
            int EID = 0;
            DataSet dsPages = new DataSet();
            dsPages = objBannerOrder.GetPagesNames();
            for (int j = 0; j < dsPages.Tables[0].Rows.Count; j++)
            {
                DataRow PageRow = dsPages.Tables[0].Rows[j];
                PageId = Convert.ToInt32(PageRow["PageId"]);
                UserID = Convert.ToInt32(PageRow["UserId"]);
                strPgName = GetPageNameForSequence(Convert.ToString(PageId), Convert.ToString(UserID));
                dsDefault = objBannerOrder.GetBannerList(PageId, UserID);
                if (dsDefault.Tables[1].Rows.Count > 0)
                {
                    DataRow countRow = dsDefault.Tables[1].Rows[0];

                    if (dsDefault.Tables[4].Rows.Count > 0)
                    {
                        DataRow checkDefRow = dsDefault.Tables[4].Rows[0];
                        if (Convert.ToInt32(checkDefRow["defbannercount"]) == 0)
                        {
                            if (Convert.ToInt32(countRow["bannercount"]) == 0)
                            {
                                DeleteFromXml(strPgName, PageId, UserID);
                                objBannerOrder.UpdateBannerSequenceByPage(strPgName);
                            }
                        }
                    }


                    if (Convert.ToString(countRow["bannercount"]) == "0")
                    {
                        DeleteFromXml(strPgName, PageId, UserID);
                        emtCnt = dsDefault.Tables[0].Rows.Count;
                        int Kcount = dsDefault.Tables[2].Rows.Count;
                        for (int k = 0; k < dsDefault.Tables[2].Rows.Count; k++)
                        {
                            DataRow BannerRow = dsDefault.Tables[2].Rows[k];

                            if (emtCnt <= Kcount)
                            {
                                DataRow emptyRow = dsDefault.Tables[0].Rows[k];
                                EID = Convert.ToInt32(emptyRow["ID"]);
                            }

                            BannerId = Convert.ToString(BannerRow["BannerId"]);
                            boolIscoupon = Convert.ToInt32(BannerRow["IsCoupon"]);
                            for (int i = 0; i < OrderDt.Rows.Count; i++)
                            {

                                DataRow defaultRow = OrderDt.Rows[i];

                                if (BannerId == Convert.ToString(defaultRow["BId"]))
                                {
                                    virtualpath2 = Convert.ToString(defaultRow["BannerPath"]);
                                    ImageName2 = Convert.ToString(defaultRow["BannerName"]);
                                    objBannerOrder.UpdateBannerSequence(EID, Convert.ToInt32(BannerId), boolIscoupon);
                                    AddBannerToXml(virtualpath2, ImageName2, IsCoupon, strPgName, Convert.ToString(PageId), Convert.ToString(UserID), virtualmobilepath, BannerId);
                                }

                            }
                        }
                    }
                }

            }

            BindData();
            BindSequenceData();
        }
        catch { }
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
            //case "10":
            //    switch (UserID)
            //    {
            //        case "0":
            //            strPageName = "Default1";
            //            break;
            //        case "1":
            //            strPageName = "Default2";
            //            break;
            //        case "2":
            //            strPageName = "Default3";
            //            break;
            //        case "3":
            //            strPageName = "Default4";
            //            break;
            //        default: break;
            //    }
            //    break;

            // New Addtion 23July2013
            case "11":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_FritzyFreshSpa1";
                        break;
                    case "1":
                        strPageName = "Cat_FritzyFreshSpa2";
                        break;
                    case "2":
                        strPageName = "Cat_FritzyFreshSpa3";
                        break;
                    case "3":
                        strPageName = "Cat_FritzyFreshSpa4";
                        break;
                    default: break;
                }
                break;

            case "12":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_Cuts_and_Trims1";
                        break;
                    case "1":
                        strPageName = "Cat_Cuts_and_Trims2";
                        break;
                    case "2":
                        strPageName = "Cat_Cuts_and_Trims3";
                        break;
                    case "3":
                        strPageName = "Cat_Cuts_and_Trims4";
                        break;
                    default: break;
                }
                break;
            case "13":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_Flea_and_Tick1";
                        break;
                    case "1":
                        strPageName = "Cat_Flea_and_Tick2";
                        break;
                    case "2":
                        strPageName = "Cat_Flea_and_Tick3";
                        break;
                    case "3":
                        strPageName = "Cat_Flea_and_Tick4";
                        break;
                    default: break;
                }
                break;
            case "14":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_BrushOut1";
                        break;
                    case "1":
                        strPageName = "Cat_BrushOut2";
                        break;
                    case "2":
                        strPageName = "Cat_BrushOut3";
                        break;
                    case "3":
                        strPageName = "Cat_BrushOut4";
                        break;
                    default: break;
                }
                break;
            case "15":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_Blueberry_Facial1";
                        break;
                    case "1":
                        strPageName = "Cat_Blueberry_Facial2";
                        break;
                    case "2":
                        strPageName = "Cat_Blueberry_Facial3";
                        break;
                    case "3":
                        strPageName = "Cat_Blueberry_Facial4";
                        break;
                    default: break;
                }
                break;
            case "16":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_De_Shedding1";
                        break;
                    case "1":
                        strPageName = "Cat_De_Shedding2";
                        break;
                    case "2":
                        strPageName = "Cat_De_Shedding3";
                        break;
                    case "3":
                        strPageName = "Cat_De_Shedding4";
                        break;
                    default: break;
                }
                break;
            case "17":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_Holidays1";
                        break;
                    case "1":
                        strPageName = "Cat_Holidays2";
                        break;
                    case "2":
                        strPageName = "Cat_Holidays3";
                        break;
                    case "3":
                        strPageName = "Cat_Holidays4";
                        break;
                    default: break;
                }
                break;
            case "18":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_Medicated_Bath1";
                        break;
                    case "1":
                        strPageName = "Cat_Medicated_Bath2";
                        break;
                    case "2":
                        strPageName = "Cat_Medicated_Bath3";
                        break;
                    case "3":
                        strPageName = "Cat_Medicated_Bath4";
                        break;
                    default: break;
                }
                break;
            case "19":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_Pad_Treatment1";
                        break;
                    case "1":
                        strPageName = "Cat_Pad_Treatment2";
                        break;
                    case "2":
                        strPageName = "Cat_Pad_Treatment3";
                        break;
                    case "3":
                        strPageName = "Cat_Pad_Treatment4";
                        break;
                    default: break;
                }
                break;
            case "20":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_Remoisturizing1";
                        break;
                    case "1":
                        strPageName = "Cat_Remoisturizing2";
                        break;
                    case "2":
                        strPageName = "Cat_Remoisturizing3";
                        break;
                    case "3":
                        strPageName = "Cat_Remoisturizing4";
                        break;
                    default: break;
                }
                break;
            case "21":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_SuperBowl1";
                        break;
                    case "1":
                        strPageName = "Cat_SuperBowl2";
                        break;
                    case "2":
                        strPageName = "Cat_SuperBowl3";
                        break;
                    case "3":
                        strPageName = "Cat_SuperBowl4";
                        break;
                    default: break;
                }
                break;
            case "22":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_Teeth_Brushing1";
                        break;
                    case "1":
                        strPageName = "Cat_Teeth_Brushing2";
                        break;
                    case "2":
                        strPageName = "Cat_Teeth_Brushing3";
                        break;
                    case "3":
                        strPageName = "Cat_Teeth_Brushing4";
                        break;
                    default: break;
                }
                break;
            case "23":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_ValentinesDay1";
                        break;
                    case "1":
                        strPageName = "Cat_ValentinesDay2";
                        break;
                    case "2":
                        strPageName = "Cat_ValentinesDay3";
                        break;
                    case "3":
                        strPageName = "Cat_ValentinesDay4";
                        break;
                    default: break;
                }
                break;
            case "24":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Cat_MothersDay1";
                        break;
                    case "1":
                        strPageName = "Cat_MothersDay2";
                        break;
                    case "2":
                        strPageName = "Cat_MothersDay3";
                        break;
                    case "3":
                        strPageName = "Cat_MothersDay4";
                        break;
                    default: break;
                }
                break;
            case "25":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_FritzyFreshSpa1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_FritzyFreshSpa2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_FritzyFreshSpa3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_FritzyFreshSpa4";
                        break;
                    default: break;
                }
                break;
            case "26":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_Anal_Gland_Expression1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_Anal_Gland_Expression2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_Anal_Gland_Expression3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_Anal_Gland_Expression4";
                        break;
                    default: break;
                }
                break;
            case "27":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_Blueberry_Facial1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_Blueberry_Facial2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_Blueberry_Facial3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_Blueberry_Facial4";
                        break;
                    default: break;
                }
                break;
            case "28":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_BrushOut1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_BrushOut2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_BrushOut3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_BrushOut4";
                        break;
                    default: break;
                }
                break;
            case "29":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_Cuts_and_Trims1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_Cuts_and_Trims2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_Cuts_and_Trims3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_Cuts_and_Trims4";
                        break;
                    default: break;
                }
                break;
            case "30":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_De_Shedding1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_De_Shedding2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_De_Shedding3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_De_Shedding4";
                        break;
                    default: break;
                }
                break;
            case "31":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_Flea_and_Tick1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_Flea_and_Tick2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_Flea_and_Tick3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_Flea_and_Tick4";
                        break;
                    default: break;
                }
                break;
            case "32":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_Holidays1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_Holidays2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_Holidays3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_Holidays4";
                        break;
                    default: break;
                }
                break;
            case "33":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_Medicated_Bath1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_Medicated_Bath2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_Medicated_Bath3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_Medicated_Bath4";
                        break;
                    default: break;
                }
                break;
            case "34":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_Pad_Treatment1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_Pad_Treatment2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_Pad_Treatment3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_Pad_Treatment4";
                        break;
                    default: break;
                }
                break;
            case "35":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_Remoisturizing1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_Remoisturizing2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_Remoisturizing3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_Remoisturizing4";
                        break;
                    default: break;
                }
                break;
            case "36":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_SuperBowl1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_SuperBowl2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_SuperBowl3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_SuperBowl4";
                        break;
                    default: break;
                }
                break;
            case "37":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_Teeth_Brushing1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_Teeth_Brushing2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_Teeth_Brushing3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_Teeth_Brushing4";
                        break;
                    default: break;
                }
                break;
            case "38":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_ValentinesDay1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_ValentinesDay2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_ValentinesDay3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_ValentinesDay4";
                        break;
                    default: break;
                }
                break;
            case "39":
                switch (UserID)
                {
                    case "0":
                        strPageName = "Dog_and_Pet_MothersDay1";
                        break;
                    case "1":
                        strPageName = "Dog_and_Pet_MothersDay2";
                        break;
                    case "2":
                        strPageName = "Dog_and_Pet_MothersDay3";
                        break;
                    case "3":
                        strPageName = "Dog_and_Pet_MothersDay4";
                        break;
                    default: break;
                }
                break;


        }
        return strPageName;
    }
    public void AddBannerToXml(string tempPath, string ImageName2, string ImageCoupon, string PageName, string PageId, string UserId, string virtualmobilepath, string BannerId)
    {
        try
        {
            XmlDocument xmldoc = new XmlDocument();
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
            XmlElement virtualmobilepath1 = xmldoc.CreateElement("virtualmobilepath1");
            XmlElement BannerId2 = xmldoc.CreateElement("BannerId");

            name.InnerText = "New";
            body.InnerText = "Lorem Ipsum";
            imagePath.InnerText = "../StoreData/BannerNew/" + ImageName2;
            virtualmobilepath1.InnerText = virtualmobilepath;
            BannerId2.InnerText = BannerId;
            link.InnerText = Session["HomePath"] + "PrintCoupon1.aspx?CouponID=" + ImageCoupon + "&PageName=" + PageName + "&PageId=" + PageId + "&UserId=" + UserId;
            PageNames.InnerText = PageName;
            banner.AppendChild(name);
            banner.AppendChild(body);
            banner.AppendChild(imagePath);
            banner.AppendChild(link);
            banner.AppendChild(PageNames);
            banner.AppendChild(virtualmobilepath1);
            banner.AppendChild(BannerId2);

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
        catch (Exception Ex) { ErrMessage(Ex.Message.ToString()); }
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
        try
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
        catch (Exception Ex) { ErrMessage(Ex.Message.ToString()); }
    }
    #endregion
    protected void dtlOrder_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            DataRowView rowView = (DataRowView)e.Item.DataItem;
            CheckBox chkIsCOupon = (CheckBox)e.Item.FindControl("chkIsCOupon");
            Label lblSrNo = (Label)e.Item.FindControl("lblSrNo");
            cnt = cnt + 1;
            lblSrNo.Text = Convert.ToString(cnt);

            string strIsCoupon = Convert.ToString(rowView["IsCoupon"]);
            switch (strIsCoupon)
            {
                case "True":
                    chkIsCOupon.Checked = true;
                    break;
                case "False":
                    chkIsCOupon.Checked = false;
                    break;
                default: break;
            }
        }
    }

    protected void btnResetPriority_Click(object sender, EventArgs e)
    {
        ManageBannerSequence();
    }

    protected void ManageBannerSequence()
    {
        try
        {

            Banner objB = new Banner();
            BannerOrder objBannerOrder = new BannerOrder();
            PageId = Convert.ToInt32(ddlPage.SelectedValue);
            string PageName = string.Empty;
            string virtualpath2 = string.Empty;
            string virtualmobilepath = string.Empty;
            string ImageName2 = string.Empty;
            string BannerId = string.Empty;
            string PgName = string.Empty;
            string IsCoupon = string.Empty;
            int boolIscoupon = 0;
            int uId = 0;
            for (int tempuid = 0; tempuid < 4; tempuid++)
            {
                if (uId == 0)
                {
                    UserID = 0;

                }
                else
                {
                    uId++;
                    UserID = uId;

                }
                string strPgName = GetPageNameForSequence(Convert.ToString(PageId), Convert.ToString(UserID));
                DataTable OrderDt = (DataTable)ViewState["myDt"];
                foreach (DataListItem item in dtlOrder.Items)
                {
                    TextBox myTextBox = (TextBox)item.FindControl("txtId");
                    Label lblPageName = (Label)item.FindControl("lblPageName");
                    Label lblIsCoupon = (Label)item.FindControl("lblIsCoupon");
                    Label lblId = (Label)item.FindControl("lblId");
                    CheckBox chkIsCOupon = (CheckBox)item.FindControl("chkIsCOupon");

                    int MaxB = 0;
                    MaxB = objB.GetMaxBannerId();
                    BannerId = Convert.ToString(MaxB);
                    IsCoupon = Convert.ToBoolean(false).ToString();
                    int Id = Convert.ToInt32(lblId.Text);
                    if (BannerId != "")
                    {
                        for (int i = 0; i < OrderDt.Rows.Count; i++)
                        {
                            DataRow row = OrderDt.Rows[i];
                            if (BannerId == Convert.ToString(row["BId"]))
                            {
                                virtualpath2 = Convert.ToString(row["BannerPath"]);
                                ImageName2 = Convert.ToString(row["BannerName"]);
                                virtualmobilepath = Convert.ToString(row["virtualmobilepath"]);
                                objBannerOrder.UpdateBannerSequence(Id, Convert.ToInt32(BannerId), boolIscoupon);
                                if (PageId != 10)
                                {
                                    AddBannerToXml(virtualpath2, ImageName2, IsCoupon, strPgName, Convert.ToString(PageId), Convert.ToString(UserID), virtualmobilepath, BannerId);
                                }
                                break;
                            }
                            else
                            {
                                objBannerOrder.UpdateBannerSequence(Id, 0, 0);
                            }


                        }
                    }
                    else
                    {
                        objBannerOrder.UpdateBannerSequence(Id, 0, 0);
                    }

                }
            }
        }
        catch (Exception ex)
        {
            ErrMessage(ex.Message.ToString());
        }
    }
}
