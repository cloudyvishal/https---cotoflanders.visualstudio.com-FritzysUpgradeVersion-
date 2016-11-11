using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using advancewebtosolution.BO;

public partial class AppointmentNew : System.Web.UI.Page
{
    #region Var
    int PetValue;
    Hashtable hashTable = new Hashtable();
    int IsFlexible;
    int IsPrimery;
    string FlexTime = string.Empty;
    string Address = string.Empty;
    string AddPetMail = string.Empty;
    string UpdatePetMail = string.Empty;
    string TempAddPetMail = string.Empty;
    string UpdatePet = string.Empty;
    string Addpet = string.Empty;
    string str123 = string.Empty;
    string str1232 = string.Empty;
    int PetId;
    #endregion Var
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        if (Session["UserName"] == null | Session["MemberName"] == null | Session["UserID"] == null)
            Response.Redirect(Session["HomePath"] + "default.aspx");
        if (!IsPostBack)
        {
            Calendar1.SelectedDate = System.DateTime.Now;
            txtSelectDate.Text = Calendar1.SelectedDate.ToShortDateString();
            ViewState["RowID"] = "";
            ViewState["IsPet"] = "0";
            GetAllBreed();
            GetStyle();
            BindPet();
            BindFlex();
            FillDropdown();
            litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/StaticeContent/Appointment.htm"));
        }
    }

    #region Bind
    public void GetBreed()
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront("0");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ListItem lst = new ListItem();
            lst.Value = "0"; lst.Text = "Select One";

            ddlBreed1.DataTextField = "BreedName";
            ddlBreed1.DataValueField = "BreedID";
            ddlBreed1.DataSource = ds.Tables[0];
            ddlBreed1.DataBind();
            //ddlBreed1.Items.Insert(0, lst);

            ddlBreed2.DataTextField = "BreedName";
            ddlBreed2.DataValueField = "BreedID";
            ddlBreed2.DataSource = ds.Tables[0];
            ddlBreed2.DataBind();
            //ddlBreed2.Items.Insert(0, lst);

            ddlBreed3.DataTextField = "BreedName";
            ddlBreed3.DataValueField = "BreedID";
            ddlBreed3.DataSource = ds.Tables[0];
            ddlBreed3.DataBind();
            //ddlBreed3.Items.Insert(0, lst);

            ddlBreed4.DataTextField = "BreedName";
            ddlBreed4.DataValueField = "BreedID";
            ddlBreed4.DataSource = ds.Tables[0];
            ddlBreed4.DataBind();
            //ddlBreed4.Items.Insert(0, lst);

            ddlBreed5.DataTextField = "BreedName";
            ddlBreed5.DataValueField = "BreedID";
            ddlBreed5.DataSource = ds.Tables[0];
            ddlBreed5.DataBind();
            //ddlBreed5.Items.Insert(0, lst);

            ddlBreed6.DataTextField = "BreedName";
            ddlBreed6.DataValueField = "BreedID";
            ddlBreed6.DataSource = ds.Tables[0];
            ddlBreed6.DataBind();
            //ddlBreed6.Items.Insert(0, lst);
        }
        ds.Dispose();
    }

    public void GetStyle()
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetStyleFront();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ListItem lst1 = new ListItem();
            lst1.Value = "0"; lst1.Text = "Natural - No Cut";

            ddlStyle1.DataTextField = "StyleName";
            ddlStyle1.DataValueField = "StyleID";
            ddlStyle1.DataSource = ds.Tables[0];
            ddlStyle1.DataBind();
            //ddlStyle1.Items.Insert(0, lst1);

            ddlStyle2.DataTextField = "StyleName";
            ddlStyle2.DataValueField = "StyleID";
            ddlStyle2.DataSource = ds.Tables[0];
            ddlStyle2.DataBind();
            //ddlStyle2.Items.Insert(0, lst1);

            ddlStyle3.DataTextField = "StyleName";
            ddlStyle3.DataValueField = "StyleID";
            ddlStyle3.DataSource = ds.Tables[0];
            ddlStyle3.DataBind();
            //ddlStyle3.Items.Insert(0, lst1);

            ddlStyle4.DataTextField = "StyleName";
            ddlStyle4.DataValueField = "StyleID";
            ddlStyle4.DataSource = ds.Tables[0];
            ddlStyle4.DataBind();
            ///ddlStyle4.Items.Insert(0, lst1);

            ddlStyle5.DataTextField = "StyleName";
            ddlStyle5.DataValueField = "StyleID";
            ddlStyle5.DataSource = ds.Tables[0];
            ddlStyle5.DataBind();
            //ddlStyle5.Items.Insert(0, lst1);

            ddlStyle6.DataTextField = "StyleName";
            ddlStyle6.DataValueField = "StyleID";
            ddlStyle6.DataSource = ds.Tables[0];
            ddlStyle6.DataBind();
            //ddlStyle6.Items.Insert(0, lst1);
        }
        else
        {
            ddlStyle1.Items.Clear();
            ddlStyle2.Items.Clear();
            ddlStyle3.Items.Clear();
            ddlStyle4.Items.Clear();
            ddlStyle5.Items.Clear();
            ddlStyle6.Items.Clear();
            //ListItem lst1 = new ListItem();
            //lst1.Selected = true; lst1.Value = "0"; lst1.Text = "Select One";
            //ddlStyle1.Items.Insert(0, lst1);
            //ddlStyle2.Items.Insert(0, lst1);
            //ddlStyle3.Items.Insert(0, lst1);
            //ddlStyle4.Items.Insert(0, lst1);
            //ddlStyle5.Items.Insert(0, lst1);
            //ddlStyle6.Items.Insert(0, lst1);
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            lstAddservices1.DataTextField = "ServiceName";
            lstAddservices1.DataValueField = "AdditionalServiceID";
            lstAddservices1.DataSource = ds.Tables[1];
            lstAddservices1.DataBind();
            lstAddservices1.Items.Insert(0, new ListItem("Select Service"));

            lstAddservices2.DataTextField = "ServiceName";
            lstAddservices2.DataValueField = "AdditionalServiceID";
            lstAddservices2.DataSource = ds.Tables[1];
            lstAddservices2.DataBind();
            lstAddservices2.Items.Insert(0, new ListItem("Select Service"));

            //lstAddservices2.DataTextField = "ServiceName";
            //lstAddservices2.DataValueField = "AdditionalServiceID";
            //lstAddservices2.DataSource = ds.Tables[1];
            //lstAddservices2.DataBind();

            lstAddservices3.DataTextField = "ServiceName";
            lstAddservices3.DataValueField = "AdditionalServiceID";
            lstAddservices3.DataSource = ds.Tables[1];
            lstAddservices3.DataBind();
            lstAddservices3.Items.Insert(0, new ListItem("Select Service"));

            lstAddservices4.DataTextField = "ServiceName";
            lstAddservices4.DataValueField = "AdditionalServiceID";
            lstAddservices4.DataSource = ds.Tables[1];
            lstAddservices4.DataBind();
            lstAddservices4.Items.Insert(0, new ListItem("Select Service"));

            lstAddservices5.DataTextField = "ServiceName";
            lstAddservices5.DataValueField = "AdditionalServiceID";
            lstAddservices5.DataSource = ds.Tables[1];
            lstAddservices5.DataBind();
            lstAddservices5.Items.Insert(0, new ListItem("Select Service"));

            lstAddservices6.DataTextField = "ServiceName";
            lstAddservices6.DataValueField = "AdditionalServiceID";
            lstAddservices6.DataSource = ds.Tables[1];
            lstAddservices6.DataBind();
            lstAddservices6.Items.Insert(0, new ListItem("Select Service"));
        }
        else
        {
            lstAddservices1.Items.Clear();
            lstAddservices2.Items.Clear();
            lstAddservices3.Items.Clear();
            lstAddservices4.Items.Clear();
            lstAddservices5.Items.Clear();
            lstAddservices6.Items.Clear();
            ListItem lst1 = new ListItem();
            lst1.Selected = true; lst1.Value = "0"; lst1.Text = "Select Services";
            lstAddservices1.Items.Insert(0, lst1);
            lstAddservices2.Items.Insert(0, lst1);
            lstAddservices3.Items.Insert(0, lst1);
            lstAddservices4.Items.Insert(0, lst1);
            lstAddservices5.Items.Insert(0, lst1);
            lstAddservices6.Items.Insert(0, lst1);
        }
        ds.Dispose();
    }

    public string GetAdditionalServices(string Ids)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();

        ds = ObjReg.GetStyleFront();
        DataTable dt_AdditionalServices = ds.Tables[1];
        string[] temp = Ids.Split(',');
        string str = string.Empty;
        for (int i = 0; i < temp.Length; i++)
        {
            for (int j = 0; j < dt_AdditionalServices.Rows.Count; j++)
            {
                if (dt_AdditionalServices.Rows[j]["AdditionalServiceID"].ToString() == temp[i])
                {
                    if (str == "")
                    {

                        str = dt_AdditionalServices.Rows[j]["ServiceName"].ToString();
                    }
                    else
                    {

                        str = str + "," + dt_AdditionalServices.Rows[j]["ServiceName"].ToString();
                    }
                }
            }
        }
        ds.Dispose();
        if (str == "")
            return "Select Service";
        else
            return str;
    }

    public void BindPet()
    {
        ListItem lst1 = new ListItem();
        ListItem lststyle = new ListItem();
        lst1.Value = "0"; lst1.Text = "Select One";
        //Dec2013
        lststyle.Value = "0"; lststyle.Text = "Natural - No Cut";
        p1.Visible = false;
        p2.Visible = false;
        p3.Visible = false;
        p4.Visible = false;
        p5.Visible = false;
        p6.Visible = false;
        StoreFrontUser ObjPet = new StoreFrontUser();
        DataSet ds = new DataSet();
        if (Session["UserID"] != null)
        {
            ds = ObjPet.GetAllPetFront(Convert.ToInt32(Session["UserID"].ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["Pet"] = (DataTable)ds.Tables[0];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            ViewState["RowID"] = 0;
                            ViewState["IsPet"] = "1";
                            p1.Visible = true;
                            txtPetName1.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtPetDOB1.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight1.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength1.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID1.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType1.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed1("0");
                            else
                                GetBreed1("1");
                            ddlBreed1.SelectedValue = (ds.Tables[0].Rows[i]["BreedID"].ToString());
                            imgDelete1.Visible = true;
                            if (ds.Tables[0].Rows[i]["Spa"].ToString() == "True")
                                chkSpa1.Checked = true;
                            else
                                chkSpa1.Checked = false;
                            if ((ds.Tables[0].Rows[i]["StyleID"].ToString() != "0") && (ds.Tables[0].Rows[i]["StyleID"].ToString() != ""))
                                ddlStyle1.SelectedValue = ds.Tables[0].Rows[i]["StyleID"].ToString();
                            ddlStyle1.Items.Insert(0, lststyle);
                            if (ds.Tables[0].Rows[i]["AdditionalService"] != DBNull.Value)
                                txtAddServices1.Text = GetAdditionalServices(ds.Tables[0].Rows[i]["AdditionalService"].ToString());
                            txtAddServicesID1.Text = ds.Tables[0].Rows[i]["AdditionalService"].ToString();
                            break;
                        case 1:
                            ViewState["RowID"] = 1;
                            p2.Visible = true;
                            txtPetName2.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtDOB2.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight2.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength2.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID2.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType2.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed2("0");
                            else
                                GetBreed2("1");
                            ddlBreed2.SelectedValue = ds.Tables[0].Rows[i]["BreedID"].ToString();
                            imgDelete2.Visible = true;

                            if (ds.Tables[0].Rows[i]["Spa"].ToString() == "True")
                                chkSpa2.Checked = true;
                            else
                                chkSpa2.Checked = false;
                            if ((ds.Tables[0].Rows[i]["StyleID"].ToString() != "0") && (ds.Tables[0].Rows[i]["StyleID"].ToString() != ""))
                                ddlStyle2.SelectedValue = ds.Tables[0].Rows[i]["StyleID"].ToString();
                            ddlStyle2.Items.Insert(0, lststyle);
                            if (ds.Tables[0].Rows[i]["AdditionalService"] != DBNull.Value)
                                txtAddServices2.Text = GetAdditionalServices(ds.Tables[0].Rows[i]["AdditionalService"].ToString());
                            txtAddServicesID2.Text = ds.Tables[0].Rows[i]["AdditionalService"].ToString();
                            break;
                        case 2:
                            ViewState["RowID"] = 2;
                            p3.Visible = true;
                            txtPetName3.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtDOB3.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight3.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength3.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID3.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType3.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed3("0");
                            else
                                GetBreed3("1");
                            ddlBreed3.SelectedValue = (ds.Tables[0].Rows[i]["BreedID"].ToString());
                            imgDelete3.Visible = true;

                            if (ds.Tables[0].Rows[i]["Spa"].ToString() == "True")
                                chkSpa3.Checked = true;
                            else
                                chkSpa3.Checked = false;
                            if ((ds.Tables[0].Rows[i]["StyleID"].ToString() != "0") && (ds.Tables[0].Rows[i]["StyleID"].ToString() != ""))
                                ddlStyle3.SelectedValue = ds.Tables[0].Rows[i]["StyleID"].ToString();
                            ddlStyle3.Items.Insert(0, lststyle);
                            if (ds.Tables[0].Rows[i]["AdditionalService"] != DBNull.Value)
                                txtAddServices3.Text = GetAdditionalServices(ds.Tables[0].Rows[i]["AdditionalService"].ToString());
                            txtAddServicesID3.Text = ds.Tables[0].Rows[i]["AdditionalService"].ToString();
                            break;
                        case 3:
                            ViewState["RowID"] = 3;
                            p4.Visible = true;
                            txtPetName4.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtDOB4.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight4.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength4.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID4.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType4.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed4("0");
                            else
                                GetBreed4("1");
                            ddlBreed4.SelectedValue = (ds.Tables[0].Rows[i]["BreedID"].ToString());
                            imgDelete4.Visible = true;

                            if (ds.Tables[0].Rows[i]["Spa"].ToString() == "True")
                                chkSpa4.Checked = true;
                            else
                                chkSpa4.Checked = false;
                            if ((ds.Tables[0].Rows[i]["StyleID"].ToString() != "0") && (ds.Tables[0].Rows[i]["StyleID"].ToString() != ""))
                                ddlStyle4.SelectedValue = ds.Tables[0].Rows[i]["StyleID"].ToString();
                            ddlStyle4.Items.Insert(0, lststyle);
                            if (ds.Tables[0].Rows[i]["AdditionalService"] != DBNull.Value)
                                txtAddServices4.Text = GetAdditionalServices(ds.Tables[0].Rows[i]["AdditionalService"].ToString());
                            txtAddServicesID4.Text = ds.Tables[0].Rows[i]["AdditionalService"].ToString();
                            break;
                        case 4:
                            ViewState["RowID"] = 4;
                            p5.Visible = true;
                            txtPetName5.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtDOB5.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight5.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength5.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID5.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType5.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed5("0");
                            else
                                GetBreed5("1");
                            ddlBreed5.SelectedValue = (ds.Tables[0].Rows[i]["BreedID"].ToString());
                            imgDelete5.Visible = true;

                            if (ds.Tables[0].Rows[i]["Spa"].ToString() == "True")
                                chkSpa5.Checked = true;
                            else
                                chkSpa5.Checked = false;
                            if ((ds.Tables[0].Rows[i]["StyleID"].ToString() != "0") && (ds.Tables[0].Rows[i]["StyleID"].ToString() != ""))
                                ddlStyle5.SelectedValue = ds.Tables[0].Rows[i]["StyleID"].ToString();
                            ddlStyle5.Items.Insert(0, lststyle);
                            if (ds.Tables[0].Rows[i]["AdditionalService"] != DBNull.Value)
                                txtAddServices5.Text = GetAdditionalServices(ds.Tables[0].Rows[i]["AdditionalService"].ToString());
                            txtAddServicesID5.Text = ds.Tables[0].Rows[i]["AdditionalService"].ToString();
                            break;
                        case 5:
                            ViewState["RowID"] = 5;
                            p6.Visible = true;
                            txtPetName6.Text = ds.Tables[0].Rows[i]["PetName"].ToString();
                            txtDOB6.Text = ds.Tables[0].Rows[i]["Years"].ToString();
                            txtPetWeight6.Text = ds.Tables[0].Rows[i]["Weight"].ToString();
                            txtPetLength6.Text = ds.Tables[0].Rows[i]["Length"].ToString();
                            PetID6.Text = ds.Tables[0].Rows[i]["PetID"].ToString();
                            ddlPetType6.SelectedValue = ds.Tables[0].Rows[i]["Pettype"].ToString();
                            if (ds.Tables[0].Rows[i]["Pettype"].ToString() == "0")
                                GetBreed6("0");
                            else
                                GetBreed6("1");
                            ddlBreed6.SelectedValue = (ds.Tables[0].Rows[i]["BreedID"].ToString());
                            imgAddmore.Visible = false;
                            imgDelete6.Visible = true;

                            if (ds.Tables[0].Rows[i]["Spa"].ToString() == "True")
                                chkSpa6.Checked = true;
                            else
                                chkSpa6.Checked = false;
                            if ((ds.Tables[0].Rows[i]["StyleID"].ToString() != "0") && (ds.Tables[0].Rows[i]["StyleID"].ToString() != ""))
                                ddlStyle6.SelectedValue = ds.Tables[0].Rows[i]["StyleID"].ToString();
                            ddlStyle6.Items.Insert(0, lststyle);
                            if (ds.Tables[0].Rows[i]["AdditionalService"] != DBNull.Value)
                                txtAddServices6.Text = GetAdditionalServices(ds.Tables[0].Rows[i]["AdditionalService"].ToString());
                            txtAddServicesID6.Text = ds.Tables[0].Rows[i]["AdditionalService"].ToString();
                            break;
                        default:
                            p1.Visible = true;
                            ViewState["RowID"] = 0;
                            break;
                    }
                }

                //if (ds.Tables[2].Rows.Count > 0)
                //{
                //    string[] strDate = ds.Tables[2].Rows[0]["Date1"].ToString().Split('/');
                //    dddDay.SelectedValue = strDate[0];
                //    ddlMonth.SelectedValue = strDate[1];
                //    ddlYear.SelectedValue = strDate[2];
                //    ddlhr.SelectedValue = ds.Tables[2].Rows[0]["Time1"].ToString();
                //    ddlmin.SelectedValue = ds.Tables[2].Rows[0]["Time2"].ToString();
                //    if (ds.Tables[2].Rows[0]["Time2"].ToString() == "1")
                //    {
                //        chkalt.Checked = true;
                //        divalt.Attributes.Add("Style", "Display:block");
                //        ddlFlexDay.SelectedValue = ds.Tables[2].Rows[0]["FlexDay"].ToString();
                //        ddlFlexHr.SelectedValue = ds.Tables[2].Rows[0]["FlexHr"].ToString();
                //    }
                //}
            }
            else
            {
                p1.Visible = true;
                ViewState["RowID"] = 0;
                ViewState["IsPet"] = "0";

                ListItem lst5 = new ListItem();
                //Dec2013
                lst5.Value = "0"; lst5.Text = "Natural - No Cut";
                ddlStyle1.Items.Insert(0, lst5);
                ddlStyle2.Items.Insert(0, lst5);
                ddlStyle3.Items.Insert(0, lst5);
                ddlStyle4.Items.Insert(0, lst5);
                ddlStyle5.Items.Insert(0, lst5);
                ddlStyle6.Items.Insert(0, lst5);
                txtAddServices1.Text = GetAdditionalServices("1");
                txtAddServicesID1.Text = txtAddServices1.Text;
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                txtPrimary.Text = ds.Tables[1].Rows[0]["Street"].ToString() + ", " + ds.Tables[1].Rows[0]["City"].ToString() + ", " + ds.Tables[1].Rows[0]["State"].ToString() + ", " + ds.Tables[1].Rows[0]["Zip"].ToString();
                ViewState["UserName"] = ds.Tables[1].Rows[0]["UserName"].ToString();
            }
            ds.Dispose();
        }
        else
        {
            Response.Redirect("Index.aspx");
        }
    }

    //public void BindDayYear()
    //{
    //    DateTime dt = new DateTime();
    //    string[] day = new string[31];
    //    for (int i = 0; i < 31; i++)
    //    {
    //        day[i] = (i + 1).ToString();
    //    }
    //    dddDay.DataSource = day;
    //    dddDay.DataBind();
    //    string[] Years = new string[10];
    //    for (int i = 0; i < 10; i++)
    //    {
    //        Years[i] = (DateTime.Now.Year + i).ToString();
    //    }
    //    ddlYear.DataSource = Years;
    //    ddlYear.DataBind();
    //    DateTime dtToday = new DateTime();
    //    dtToday = DateTime.Today;
    //    int yrToday = dtToday.Year;
    //    int dayToday = dtToday.Day;
    //    int mnToday = dtToday.Month;
    //    ddlMonth.SelectedValue = mnToday.ToString();
    //    ddlYear.SelectedValue = yrToday.ToString();
    //    dddDay.SelectedValue = dayToday.ToString();
    //    CalendarExtender1.SelectedDate = DateTime.Today;

    //}

    public void BindAdditionalServices()
    {
    }

    public void GetBreed1(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Value = "0"; lst.Text = "Select One";

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBreed1.DataTextField = "BreedName";
            ddlBreed1.DataValueField = "BreedID";
            ddlBreed1.DataSource = ds.Tables[0];
            ddlBreed1.DataBind();
            ddlBreed1.Items.Insert(0, lst);
        }
        else
        {
            ddlBreed1.Items.Clear();
            ddlBreed1.Items.Insert(0, lst);
        }
        ds.Dispose();
    }

    public void GetBreed2(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Value = "0"; lst.Text = "Select One";
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBreed2.DataTextField = "BreedName";
            ddlBreed2.DataValueField = "BreedID";
            ddlBreed2.DataSource = ds.Tables[0];
            ddlBreed2.DataBind();
            ddlBreed2.Items.Insert(0, lst);
        }
        else
        {
            ddlBreed2.Items.Clear();
            ddlBreed2.Items.Insert(0, lst);
        }
        ds.Dispose();
    }

    public void GetBreed3(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Value = "0"; lst.Text = "Select One";
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBreed3.DataTextField = "BreedName";
            ddlBreed3.DataValueField = "BreedID";
            ddlBreed3.DataSource = ds.Tables[0];
            ddlBreed3.DataBind();
            ddlBreed3.Items.Insert(0, lst);
        }
        else
        {
            ddlBreed3.Items.Clear();
            ddlBreed3.Items.Insert(0, lst);
        }
        ds.Dispose();
    }

    public void GetBreed4(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Value = "0"; lst.Text = "Select One";
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBreed4.DataTextField = "BreedName";
            ddlBreed4.DataValueField = "BreedID";
            ddlBreed4.DataSource = ds.Tables[0];
            ddlBreed4.DataBind();
            ddlBreed4.Items.Insert(0, lst);
        }
        else
        {
            ddlBreed4.Items.Clear();
            ddlBreed4.Items.Insert(0, lst);
        }
        ds.Dispose();
    }

    public void GetBreed5(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Value = "0"; lst.Text = "Select One";
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBreed5.DataTextField = "BreedName";
            ddlBreed5.DataValueField = "BreedID";
            ddlBreed5.DataSource = ds.Tables[0];
            ddlBreed5.DataBind();
            ddlBreed5.Items.Insert(0, lst);
        }
        else
        {
            ddlBreed5.Items.Clear();
            ddlBreed5.Items.Insert(0, lst);
        }
        ds.Dispose();
    }

    public void GetBreed6(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Value = "0"; lst.Text = "Select One";
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBreed6.DataTextField = "BreedName";
            ddlBreed6.DataValueField = "BreedID";
            ddlBreed6.DataSource = ds.Tables[0];
            ddlBreed6.DataBind();
            ddlBreed6.Items.Insert(0, lst);
        }
        else
        {
            ddlBreed6.Items.Clear();
            ddlBreed6.Items.Insert(0, lst);
        }
        ds.Dispose();
    }

    public void GetPet1(string Breed)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetPetFront(Breed);
        ListItem lst = new ListItem();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlPetType1.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            ddlPetType1.SelectedValue = "0";
            ddlPetType1.Text = "Cat";
        }
        ds.Dispose();
    }
    public void GetPet2(string Breed)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetPetFront(Breed);
        ListItem lst = new ListItem();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlPetType2.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            ddlPetType2.SelectedValue = "0";
            ddlPetType2.Text = "Cat";
        }
        ds.Dispose();
    }

    public void GetPet3(string Breed)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetPetFront(Breed);
        ListItem lst = new ListItem();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlPetType3.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            ddlPetType3.SelectedValue = "0";
            ddlPetType3.Text = "Cat";
        }
        ds.Dispose();
    }
    public void GetPet4(string Breed)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetPetFront(Breed);
        ListItem lst = new ListItem();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlPetType4.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            ddlPetType4.SelectedValue = "0";
            ddlPetType4.Text = "Cat";
        }
        ds.Dispose();
    }
    public void GetPet5(string Breed)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetPetFront(Breed);
        ListItem lst = new ListItem();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlPetType5.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            ddlPetType5.SelectedValue = "0";
            ddlPetType5.Text = "Cat";
        }
        ds.Dispose();
    }
    public void GetPet6(string Breed)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetPetFront(Breed);
        ListItem lst = new ListItem();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlPetType6.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            ddlPetType6.SelectedValue = "0";
            ddlPetType6.Text = "Cat";
        }
        ds.Dispose();
    }
    public void BindFlex()
    {
        StoreFrontUser ObjFlex = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjFlex.GetAllFlexible();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlFlex.DataValueField = "FlexID";
            ddlFlex.DataTextField = "FlexName";
            ListItem lst = new ListItem();
            lst.Value = "0"; lst.Text = "Select One";

            ddlFlex.DataSource = ds.Tables[0];
            ddlFlex.DataBind();
            //ddlFlex.Items.Insert(0, lst);
        }
    }
    #endregion
    public void GetAllBreed()
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetAllBreed();
        ListItem lst = new ListItem();
        lst.Value = "0"; lst.Text = "Select One";

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBreed1.DataTextField = "BreedName";
            ddlBreed1.DataValueField = "BreedID";
            ddlBreed1.DataSource = ds.Tables[0];
            ddlBreed1.DataBind();
            ddlBreed1.Items.Insert(0, lst);

            ddlBreed2.DataTextField = "BreedName";
            ddlBreed2.DataValueField = "BreedID";
            ddlBreed2.DataSource = ds.Tables[0];
            ddlBreed2.DataBind();
            ddlBreed2.Items.Insert(0, lst);

            ddlBreed3.DataTextField = "BreedName";
            ddlBreed3.DataValueField = "BreedID";
            ddlBreed3.DataSource = ds.Tables[0];
            ddlBreed3.DataBind();
            ddlBreed3.Items.Insert(0, lst);

            ddlBreed4.DataTextField = "BreedName";
            ddlBreed4.DataValueField = "BreedID";
            ddlBreed4.DataSource = ds.Tables[0];
            ddlBreed4.DataBind();
            ddlBreed4.Items.Insert(0, lst);

            ddlBreed5.DataTextField = "BreedName";
            ddlBreed5.DataValueField = "BreedID";
            ddlBreed5.DataSource = ds.Tables[0];
            ddlBreed5.DataBind();
            ddlBreed5.Items.Insert(0, lst);

            ddlBreed6.DataTextField = "BreedName";
            ddlBreed6.DataValueField = "BreedID";
            ddlBreed6.DataSource = ds.Tables[0];
            ddlBreed6.DataBind();
            ddlBreed6.Items.Insert(0, lst);
        }
        else
        {
            ddlBreed1.Items.Clear();
            ddlBreed1.Items.Insert(0, lst);

            ddlBreed2.Items.Clear();
            ddlBreed2.Items.Insert(0, lst);

            ddlBreed3.Items.Clear();
            ddlBreed3.Items.Insert(0, lst);

            ddlBreed4.Items.Clear();
            ddlBreed4.Items.Insert(0, lst);

            ddlBreed5.Items.Clear();
            ddlBreed5.Items.Insert(0, lst);

            ddlBreed6.Items.Clear();
            ddlBreed6.Items.Insert(0, lst);
        }
        ds.Dispose();
    }
    private void FillDropdown()
    {
        string str123 = txtSelectDate.Text;
        DateTime dtTime = Convert.ToDateTime(str123);
        Appointment objApp = new Appointment();
        DataSet DS = new DataSet();
        DataSet DS1 = new DataSet();
        DS = objApp.GetAppointmentslotsToEdit(dtTime);
        if (DS.Tables[0].Rows.Count > 0)
        {
            Appointment.FillDropDownList(ddlhr, DS, "APTId", "APTTime");
            ViewState["DateType"] = "1";
        }
        else
        {
            DS1 = objApp.GetAppointmentTime();
            Appointment.FillDropDownList(ddlhr, DS1, "APTId", "APTTime");
            ViewState["DateType"] = "0";
        }
    }

    #region Event
    /*
     *  This event use to add another pet row up to 6 rows 
     * ViewState["RowID"] save current row count .
     * and use to set Style and breed selected value 
    */
    protected void imgAddmore_Click(object sender, ImageClickEventArgs e)
    {
        ListItem lst = new ListItem();
        //Dec2013
        lst.Value = "0"; lst.Text = "Natural - No Cut";
        if (ViewState["RowID"].ToString() == "0")
        {
            p2.Visible = true;
            //ddlBreed2.Items.Insert(0, lst);
            string S = ddlBreed2.SelectedValue;
            ViewState["IsPet"] = "1";
            ViewState["RowID"] = "1";
            ddlStyle2.Items.Insert(0, lst);
            ddlStyle2.SelectedIndex = 0;
            imgDelete2.Visible = true;
            //ddlStyle2.SelectedIndex = 0;
            //ddlBreed2.Items.Insert(0, lst);
        }
        else if (ViewState["RowID"].ToString() == "1")
        {
            p3.Visible = true;
            ViewState["RowID"] = "2";
            ddlStyle3.Items.Insert(0, lst);
            ddlStyle3.SelectedIndex = 0;
            imgDelete3.Visible = true;
            //ddlStyle3.SelectedIndex = 0;
            //ddlBreed3.Items.Insert(0, lst);
        }
        else if (ViewState["RowID"].ToString() == "2")
        {
            p4.Visible = true;
            ViewState["RowID"] = "3";
            ddlStyle4.Items.Insert(0, lst);
            ddlStyle4.SelectedIndex = 0;
            imgDelete4.Visible = true;
            //ddlStyle4.SelectedIndex = 0;
            //ddlBreed4.Items.Insert(0, lst);
        }
        else if (ViewState["RowID"].ToString() == "3")
        {
            p5.Visible = true;
            ViewState["RowID"] = "4";
            ddlStyle5.Items.Insert(0, lst);
            ddlStyle5.SelectedIndex = 0;
            imgDelete5.Visible = true;
            //ddlStyle5.Items.Insert(0, lst);
            //ddlBreed5.Items.Insert(0, lst);
        }
        else if (ViewState["RowID"].ToString() == "4")
        {
            p6.Visible = true;
            ViewState["RowID"] = "5";
            ddlStyle6.Items.Insert(0, lst);
            ddlStyle6.SelectedIndex = 0;
            imgDelete6.Visible = true;
            //ddlStyle6.Items.Insert(0, lst);
            //ddlBreed6.Items.Insert(0, lst);
        }
        else if (ViewState["RowID"].ToString() == "5")
        {
            imgAddmore.Visible = false;
            lblMessageSix.Visible = true;
            lblMessageSix.Text = "You can add only six pets";
        }
    }
    /*  Comment
        1. Check for valid date.
        2. Check for at least one pet 
        3. If pet information avalible then update pet information in database Or if new pet information added then add to database 
        4. Update user information.
     */

    public bool checkPetSelection()
    {
        bool isPet = false;
        if (chkPet1.Checked == true)
        {
            isPet = true;
            PetValue = 1;
            hashTable.Add(1, PetID1.Text);
        }
        if (chkPet2.Checked == true)
        {
            isPet = true;
            PetValue = 2;
            hashTable.Add(2, PetID2.Text);
        }
        if (chkPet3.Checked == true)
        {
            isPet = true;
            PetValue = 3;
            hashTable.Add(3, PetID3.Text);
        }
        if (chkPet4.Checked == true)
        {
            isPet = true;
            PetValue = 4;
            hashTable.Add(4, PetID4.Text);
        }
        if (chkPet5.Checked == true)
        {
            isPet = true;
            PetValue = 5;
            hashTable.Add(5, PetID5.Text);
        }
        if (chkPet6.Checked == true)
        {
            isPet = true;
            PetValue = 6;
            hashTable.Add(6, PetID6.Text);
        }
        else
        {
            if (PetValue == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notify()", true);
                isPet = false;
                PetValue = 0;
            }
        }
        return isPet;
    }

    protected void IdNext_Click(object sender, ImageClickEventArgs e)
    {
        bool chkPet = checkPetSelection();

        if (chkPet == true)
        {
            lblerror.Visible = false;
            DateTime dt = new DateTime();
            dt = Convert.ToDateTime(txtDate.Text);

            TimeSpan ts = dt.Date - DateTime.Now; ;
            str123 = txtSelectDate.Text;
            str1232 = txtSelectDate.Text + " " + ddlhr.SelectedItem.Text;
            DateTime dt2 = new DateTime();
            dt2 = Convert.ToDateTime("10/10/2008 10:10:00 AM");
            TimeSpan ts1;

            DateTime dt1 = new DateTime();
            try
            {
                dt1 = Convert.ToDateTime(str1232.ToString());
                ts1 = dt1.Date - DateTime.Now;
                lblErrorDate.Text = "";
            }
            catch
            {
                ts1 = Convert.ToDateTime("10/10/2008 10:10:00 AM") - DateTime.Now;
                lblErrorDate.Visible = true;
                lblErrorDate.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/StaticeContent/AppointmentMessage.htm"));
                lblErrorDate.Focus();
                lblNoPet.Text = "";
            }
            int Status = 3;
            int Type = CheckPet();
            if (Type == 3)
                Status = CheckStatus();
            else
                Status = Type;
            Session["UserType"] = Status.ToString();

            if (dt1.DayOfWeek == DayOfWeek.Sunday)
            {
                lblErrorDate.Text = "Sorry! We don't provide services on sunday.";
                return;
            }
            Appointment objApp = new Appointment();
            DataSet DsTime = new DataSet();
            if (Convert.ToString(ViewState["DateType"]) == "1")
            {
                DsTime = objApp.GetAppointmentslotsByTime(Convert.ToDateTime(str123), Convert.ToInt32(ddlhr.SelectedValue));
                if (DsTime.Tables[0].Rows.Count == 0)
                {

                    lblErrorDate.Text = "Time slots are not available for selected date.";
                    return;
                }
            }
            if ((dt1 > DateTime.Now) && (ViewState["IsPet"].ToString() != "0"))
            {
                lblErrorDate.Text = "";
                StoreFrontUser ObjUpdateUser = new StoreFrontUser();
                int UserID = Convert.ToInt32(Session["UserID"].ToString());
                int spa = 0;
                string IsSpa = string.Empty;
                string SpaString = string.Empty;
                #region date Notes
                IsFlexible = 0;
                IsPrimery = 0;
                FlexTime = "-";
                Address = string.Empty;
                if (chkalt.Checked == true)
                {
                    IsFlexible = 1;
                    FlexTime = ddlFlex.SelectedItem.Text;
                }
                else
                    IsFlexible = 0;

                if (red1.Checked == true)
                {
                    IsPrimery = 0;
                    Address = txtPrimary.Text;
                }
                else
                {
                    IsPrimery = 1;
                    Address = txtAlternat.Text;
                }
                #endregion date Notes

                #region
                if (p1.Visible == true)
                {
                    AddPetMail = string.Empty;
                    UpdatePetMail = string.Empty;
                    PetId = Convert.ToInt32(PetID1.Text);
                    if ((txtPetName1.Text.Trim() != "") && (txtPetDOB1.Text.Trim() != "") && (txtPetWeight1.Text.Trim() != "") && (txtPetLength1.Text.Trim() != ""))
                    {
                        if (chkSpa1.Checked == true) { spa = 1; IsSpa = "Yes"; }
                        else { spa = 0; IsSpa = "No"; }
                        if (PetID1.Text == "0")
                        {
                            string Pet1Id = ObjUpdateUser.AddPetFull(UserID, Convert.ToInt32(ddlPetType1.SelectedValue), txtPetName1.Text.Trim(), Convert.ToInt32(ddlBreed1.SelectedValue), Convert.ToInt32(txtPetDOB1.Text.Trim()), Convert.ToDecimal(txtPetWeight1.Text.Trim()), Convert.ToDecimal(txtPetLength1.Text.Trim()), spa, Convert.ToInt32(ddlStyle1.SelectedValue), (txtAddServicesID1.Text.Trim()));
                            string TempName = string.Empty;
                            if (Convert.ToInt32(ddlPetType1.SelectedValue) == 0) TempName = "Cat";
                            else TempName = "dog";
                            TempAddPetMail = "Pet = " + TempName + "<br>Pet Name = " + txtPetName1.Text.Trim() + "<br> Breed Name = BreedID " +
                                          "<br>Years = " + Convert.ToInt32(txtPetDOB1.Text.Trim()) + "<br>Weight = " + Convert.ToDecimal(txtPetWeight1.Text.Trim()) + " lbs<br> Fur Length = " + Convert.ToDecimal(txtPetLength1.Text.Trim()) + "  inches<br>" +
                                          "Spa = " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                                          "<br><br>";
                            hashTable[1] = Convert.ToInt32(Pet1Id);
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text);
                            if (ddlStyle1.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle1.SelectedItem.Text);
                            if (txtAddServices1.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices1.Text.Trim().Substring(0, 1) == ",") ? txtAddServices1.Text.Trim().Remove(0, 1) : txtAddServices1.Text.Trim());
                            AddPetMail = TempAddPetMail;
                            UpdatePetMail = string.Empty;
                        }
                        else
                        {
                            ObjUpdateUser.UpdatePetFull(Convert.ToInt32(PetID1.Text), UserID, Convert.ToInt32(ddlPetType1.SelectedValue), txtPetName1.Text.Trim(), Convert.ToInt32(ddlBreed1.SelectedValue), Convert.ToInt32(txtPetDOB1.Text.Trim()), Convert.ToDecimal(txtPetWeight1.Text.Trim()), Convert.ToDecimal(txtPetLength1.Text.Trim()), spa, Convert.ToInt32(ddlStyle1.SelectedValue), (txtAddServicesID1.Text.Trim()));
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(1);
                            else UpdatePet = UpdatePet + IsPetUpdate(1);
                            string pettype1 = string.Empty;
                            if (ddlPetType1.SelectedValue == "0") pettype1 = "Cat";
                            else pettype1 = "dog";
                            TempAddPetMail = "Pet = " + pettype1 + "<br>Pet Name = " + txtPetName1.Text.Trim() + "<br> Breed Name = BreedID " +
                         "<br>Years = " + txtPetDOB1.Text.Trim() + "<br>Weight = " + txtPetWeight1.Text.Trim() + " lbs <br> Fur Length = " + txtPetLength1.Text.Trim() + " inches <br>" +
                         "Spa = " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                         "<br><br>";
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed1.SelectedItem.Text);
                            if (ddlStyle1.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle1.SelectedItem.Text);
                            if (txtAddServices1.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices1.Text.Trim().Substring(0, 1) == ",") ? txtAddServices1.Text.Trim().Remove(0, 1) : txtAddServices1.Text.Trim());
                            UpdatePetMail = TempAddPetMail;
                            AddPetMail = string.Empty;
                        }
                        if (chkPet1.Checked)
                        {
                            SetAppointment(1, (txtAddServicesID1.Text.Trim()));
                        }
                    }
                }
                #endregion

                #region
                if (p2.Visible == true)
                {
                    AddPetMail = string.Empty;
                    UpdatePetMail = string.Empty;
                    PetId = Convert.ToInt32(PetID2.Text);
                    if ((txtPetName2.Text.Trim() != "") && (txtDOB2.Text.Trim() != "") && (txtPetWeight2.Text.Trim() != "") && (txtPetLength2.Text.Trim() != ""))
                    {
                        if (chkSpa1.Checked == true) { spa = 1; IsSpa = "Yes"; }
                        else { spa = 0; IsSpa = "No"; }
                        if (PetID2.Text == "0")
                        {

                            string Pet2Id = ObjUpdateUser.AddPetFull(UserID, Convert.ToInt32(ddlPetType2.SelectedValue), txtPetName2.Text.Trim(), Convert.ToInt32(ddlBreed2.SelectedValue), Convert.ToInt32(txtDOB2.Text.Trim()), Convert.ToDecimal(txtPetWeight2.Text.Trim()), Convert.ToDecimal(txtPetLength2.Text.Trim()), spa, Convert.ToInt32(ddlStyle2.SelectedValue), txtAddServicesID2.Text.Trim());
                            string TempName = string.Empty;
                            if (Convert.ToInt32(ddlPetType2.SelectedValue) == 0) TempName = "Cat";
                            else TempName = "dog";
                            TempAddPetMail = "Pet = " + TempName + "<br>Pet Name = " + txtPetName2.Text.Trim() + "<br> Breed Name = BreedID " +
                                          "<br>Years = " + Convert.ToInt32(txtDOB2.Text.Trim()) + "<br>Weight = " + Convert.ToDecimal(txtPetWeight2.Text.Trim()) + " lbs<br> Fur Length = " + Convert.ToDecimal(txtPetLength2.Text.Trim()) + "   inches<br>" +
                                          "Spa =  " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                                          "<br><br>";
                            hashTable[2] = Convert.ToInt32(Pet2Id);
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed2.SelectedItem.Text);
                            if (ddlStyle2.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle2.SelectedItem.Text);
                            if (txtAddServices2.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices2.Text.Trim().Substring(0, 1) == ",") ? txtAddServices2.Text.Trim().Remove(0, 1) : txtAddServices2.Text.Trim());
                            AddPetMail = TempAddPetMail;
                            UpdatePetMail = string.Empty;
                        }
                        else
                        {
                            ObjUpdateUser.UpdatePetFull(Convert.ToInt32(PetID2.Text), UserID, Convert.ToInt32(ddlPetType2.SelectedValue), txtPetName2.Text.Trim(), Convert.ToInt32(ddlBreed2.SelectedValue), Convert.ToInt32(txtDOB2.Text.Trim()), Convert.ToDecimal(txtPetWeight2.Text.Trim()), Convert.ToDecimal(txtPetLength2.Text.Trim()), spa, Convert.ToInt32(ddlStyle2.SelectedValue), txtAddServicesID2.Text.Trim());
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(2);
                            else UpdatePet = UpdatePet + IsPetUpdate(2);
                            string pettype2 = string.Empty;
                            if (ddlPetType2.SelectedValue == "0") pettype2 = "Cat";
                            else pettype2 = "dog";

                            string strupdate2 = "Pet = " + pettype2 + "<br>Pet Name = " + txtPetName2.Text.Trim() + "<br> Breed Name = BreedID " +
                        "<br>Years = " + txtDOB2.Text.Trim() + "<br>Weight = " + txtPetWeight2.Text.Trim() + " lbs <br>Fur Length = " + txtPetLength2.Text.Trim() + " inches <br>" +
                        "Spa =  " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                        "<br><br>";
                            TempAddPetMail = strupdate2;
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed2.SelectedItem.Text);
                            if (ddlStyle2.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle2.SelectedItem.Text);
                            if (txtAddServices2.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices2.Text.Trim().Substring(0, 1) == ",") ? txtAddServices2.Text.Trim().Remove(0, 1) : txtAddServices2.Text.Trim());
                            UpdatePetMail = TempAddPetMail;
                            AddPetMail = string.Empty;
                        }
                        if (chkPet2.Checked)
                        {
                            SetAppointment(2, (txtAddServicesID2.Text.Trim()));
                        }
                    }
                }
                #endregion

                #region
                if (p3.Visible == true)
                {
                    AddPetMail = string.Empty;
                    UpdatePetMail = string.Empty;
                    PetId = Convert.ToInt32(PetID3.Text);
                    if ((txtPetName3.Text.Trim() != "") && (txtDOB3.Text.Trim() != "") && (txtPetWeight3.Text.Trim() != "") && (txtPetLength3.Text.Trim() != ""))
                    {
                        if (chkSpa1.Checked == true) { spa = 1; IsSpa = "Yes"; }
                        else { spa = 0; IsSpa = "No"; }
                        if (PetID3.Text == "0")
                        {
                            string Pet3Id = ObjUpdateUser.AddPetFull(UserID, Convert.ToInt32(ddlPetType3.SelectedValue), txtPetName3.Text.Trim(), Convert.ToInt32(ddlBreed3.SelectedValue), Convert.ToInt32(txtDOB3.Text.Trim()), Convert.ToDecimal(txtPetWeight3.Text.Trim()), Convert.ToDecimal(txtPetLength3.Text.Trim()), spa, Convert.ToInt32(ddlStyle3.SelectedValue), txtAddServicesID3.Text.Trim());
                            string TempName = string.Empty;
                            if (Convert.ToInt32(ddlPetType3.SelectedValue) == 0) TempName = "Cat";
                            else TempName = "dog";
                            TempAddPetMail = "Pet = " + TempName + "<br>Pet Name = " + txtPetName3.Text.Trim() + "<br> Breed Name = BreedID " +
                                          "<br>Years = " + Convert.ToInt32(txtDOB3.Text.Trim()) + "<br>Weight = " + Convert.ToDecimal(txtPetWeight3.Text.Trim()) + " lbs <br> Fur Length = " + Convert.ToDecimal(txtPetLength3.Text.Trim()) + "   inches<br>" +
                                          "Spa =  " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                                          "<br><br>";
                            hashTable[3] = Convert.ToInt32(Pet3Id);
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed3.SelectedItem.Text);
                            if (ddlStyle3.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle3.SelectedItem.Text);
                            if (txtAddServices3.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices3.Text.Trim().Substring(0, 1) == ",") ? txtAddServices3.Text.Trim().Remove(0, 1) : txtAddServices3.Text.Trim());
                            AddPetMail = TempAddPetMail;
                            UpdatePetMail = string.Empty;
                        }
                        else
                        {

                            ObjUpdateUser.UpdatePetFull(Convert.ToInt32(PetID3.Text), UserID, Convert.ToInt32(ddlPetType3.SelectedValue), txtPetName3.Text.Trim(), Convert.ToInt32(ddlBreed3.SelectedValue), Convert.ToInt32(txtDOB3.Text.Trim()), Convert.ToDecimal(txtPetWeight3.Text.Trim()), Convert.ToDecimal(txtPetLength3.Text.Trim()), spa, Convert.ToInt32(ddlStyle3.SelectedValue), txtAddServicesID3.Text.Trim());
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(3);
                            else UpdatePet = UpdatePet + IsPetUpdate(3);
                            string pettype3 = string.Empty;
                            if (ddlPetType3.SelectedValue == "0") pettype3 = "Cat";
                            else pettype3 = "dog";

                            string strupdate3 = "Pet = " + pettype3 + "<br>Pet Name = " + txtPetName3.Text.Trim() + "<br> Breed Name = BreedID " +
                        "<br>Years = " + txtDOB3.Text.Trim() + "<br>Weight = " + txtPetWeight3.Text.Trim() + " lbs <br> Fur Length = " + txtPetLength3.Text.Trim() + " inches <br>" +
                        "Spa =  " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                        "<br><br>";
                            TempAddPetMail = strupdate3;
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed3.SelectedItem.Text);
                            if (ddlStyle3.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle3.SelectedItem.Text);
                            if (txtAddServices3.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices3.Text.Trim().Substring(0, 1) == ",") ? txtAddServices3.Text.Trim().Remove(0, 1) : txtAddServices3.Text.Trim());
                            UpdatePetMail = TempAddPetMail;
                            AddPetMail = string.Empty;
                        }
                        if (chkPet3.Checked)
                        {
                            SetAppointment(3, (txtAddServicesID3.Text.Trim()));
                        }
                    }
                }
                #endregion

                #region
                if (p4.Visible == true)
                {
                    AddPetMail = string.Empty;
                    UpdatePetMail = string.Empty;
                    PetId = Convert.ToInt32(PetID4.Text);
                    if ((txtPetName4.Text.Trim() != "") && (txtDOB4.Text.Trim() != "") && (txtPetWeight4.Text.Trim() != "") && (txtPetLength4.Text.Trim() != ""))
                    {
                        if (chkSpa1.Checked == true) { spa = 1; IsSpa = "Yes"; }
                        else { spa = 0; IsSpa = "No"; }
                        if (PetID4.Text == "0")
                        {

                            string Pet4Id = ObjUpdateUser.AddPetFull(UserID, Convert.ToInt32(ddlPetType4.SelectedValue), txtPetName4.Text.Trim(), Convert.ToInt32(ddlBreed4.SelectedValue), Convert.ToInt32(txtDOB4.Text.Trim()), Convert.ToDecimal(txtPetWeight4.Text.Trim()), Convert.ToDecimal(txtPetLength4.Text.Trim()), spa, Convert.ToInt32(ddlStyle4.SelectedValue), txtAddServicesID4.Text.Trim());
                            string TempName = string.Empty;
                            if (Convert.ToInt32(ddlPetType4.SelectedValue) == 0) TempName = "Cat";
                            else TempName = "dog";
                            TempAddPetMail = "Pet = " + TempName + "<br>Pet Name = " + txtPetName4.Text.Trim() + "<br> Breed Name = BreedID " +
                                          "<br>Years = " + Convert.ToInt32(txtDOB4.Text.Trim()) + "<br>Weight = " + Convert.ToDecimal(txtPetWeight4.Text.Trim()) + " lbs <br> Fur Length = " + Convert.ToDecimal(txtPetLength2.Text.Trim()) + "  inches<br>" +
                                          "Spa =  " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                                          "<br><br>";
                            hashTable[4] = Convert.ToInt32(Pet4Id);
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed4.SelectedItem.Text);
                            if (ddlStyle4.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle4.SelectedItem.Text);
                            if (txtAddServices4.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices4.Text.Trim().Substring(0, 1) == ",") ? txtAddServices4.Text.Trim().Remove(0, 1) : txtAddServices4.Text.Trim());
                            AddPetMail = TempAddPetMail;
                            UpdatePetMail = string.Empty;
                        }
                        else
                        {

                            ObjUpdateUser.UpdatePetFull(Convert.ToInt32(PetID4.Text), UserID, Convert.ToInt32(ddlPetType4.SelectedValue), txtPetName4.Text.Trim(), Convert.ToInt32(ddlBreed4.SelectedValue), Convert.ToInt32(txtDOB4.Text.Trim()), Convert.ToDecimal(txtPetWeight4.Text.Trim()), Convert.ToDecimal(txtPetLength4.Text.Trim()), spa, Convert.ToInt32(ddlStyle4.SelectedValue), txtAddServicesID4.Text.Trim());
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(4);
                            else UpdatePet = UpdatePet + IsPetUpdate(4);
                            string pettype4 = string.Empty;
                            if (ddlPetType4.SelectedValue == "0") pettype4 = "Cat";
                            else pettype4 = "dog";

                            string strupdate4 = "Pet = " + pettype4 + "<br>Pet Name = " + txtPetName4.Text.Trim() + "<br> Breed Name = BreedID " +
                        "<br>Years = " + txtDOB4.Text.Trim() + "<br>Weight = " + txtPetWeight4.Text.Trim() + " lbs <br> Fur Length = " + txtPetLength4.Text.Trim() + " inches <br>" +
                        "Spa =  " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                        "<br><br>";
                            TempAddPetMail = strupdate4;
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed4.SelectedItem.Text);
                            if (ddlStyle4.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle4.SelectedItem.Text);
                            if (txtAddServices4.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices4.Text.Trim().Substring(0, 1) == ",") ? txtAddServices4.Text.Trim().Remove(0, 1) : txtAddServices4.Text.Trim());
                            UpdatePetMail = TempAddPetMail;
                            AddPetMail = string.Empty;
                        }
                        if (chkPet4.Checked)
                        {
                            SetAppointment(4, (txtAddServicesID4.Text.Trim()));
                        }
                    }
                }
                #endregion

                #region
                if (p5.Visible == true)
                {
                    AddPetMail = string.Empty;
                    UpdatePetMail = string.Empty;
                    PetId = Convert.ToInt32(PetID5.Text);
                    if ((txtPetName5.Text.Trim() != "") && (txtDOB5.Text.Trim() != "") && (txtPetWeight5.Text.Trim() != "") && (txtPetLength5.Text.Trim() != ""))
                    {
                        if (chkSpa1.Checked == true) { spa = 1; IsSpa = "Yes"; }
                        else { spa = 0; IsSpa = "No"; }
                        if (PetID5.Text == "0")
                        {

                            string Pet5Id = ObjUpdateUser.AddPetFull(UserID, Convert.ToInt32(ddlPetType5.SelectedValue), txtPetName5.Text.Trim(), Convert.ToInt32(ddlBreed5.SelectedValue), Convert.ToInt32(txtDOB5.Text.Trim()), Convert.ToDecimal(txtPetWeight5.Text.Trim()), Convert.ToDecimal(txtPetLength5.Text.Trim()), spa, Convert.ToInt32(ddlStyle5.SelectedValue), txtAddServicesID5.Text.Trim());
                            string TempName = string.Empty;
                            if (Convert.ToInt32(ddlPetType5.SelectedValue) == 0) TempName = "Cat";
                            else TempName = "dog";
                            TempAddPetMail = "Pet = " + TempName + "<br>Pet Name = " + txtPetName5.Text.Trim() + "<br> Breed Name = BreedID " +
                                          "<br>Years = " + Convert.ToInt32(txtDOB5.Text.Trim()) + "<br>Weight = " + Convert.ToDecimal(txtPetWeight5.Text.Trim()) + " lbs<br> Fur Length = " + Convert.ToDecimal(txtPetLength5.Text.Trim()) + "   inches<br>" +
                                          "Spa =  " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                                          "<br><br>";
                            //update hashTable here
                            hashTable[5] = Convert.ToInt32(Pet5Id);
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed5.SelectedItem.Text);
                            if (ddlStyle5.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle5.SelectedItem.Text);
                            if (txtAddServices5.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices5.Text.Trim().Substring(0, 1) == ",") ? txtAddServices5.Text.Trim().Remove(0, 1) : txtAddServices5.Text.Trim());
                            AddPetMail = TempAddPetMail;
                            UpdatePetMail = string.Empty;
                        }
                        else
                        {

                            ObjUpdateUser.UpdatePetFull(Convert.ToInt32(PetID5.Text), UserID, Convert.ToInt32(ddlPetType5.SelectedValue), txtPetName5.Text.Trim(), Convert.ToInt32(ddlBreed5.SelectedValue), Convert.ToInt32(txtDOB5.Text.Trim()), Convert.ToDecimal(txtPetWeight5.Text.Trim()), Convert.ToDecimal(txtPetLength5.Text.Trim()), spa, Convert.ToInt32(ddlStyle5.SelectedValue), txtAddServicesID5.Text.Trim());
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(5);
                            else UpdatePet = UpdatePet + IsPetUpdate(5);
                            string pettype5 = string.Empty;
                            if (ddlPetType5.SelectedValue == "0") pettype5 = "Cat";
                            else pettype5 = "dog";
                            string strupdate5 = "Pet = " + pettype5 + "<br>Pet Name = " + txtPetName5.Text.Trim() + "<br> Breed Name = BreedID " +
                        "<br>Years = " + txtDOB5.Text.Trim() + "<br>Weight = " + txtPetWeight5.Text.Trim() + " lbs <br> Fur Length = " + txtPetLength5.Text.Trim() + " inches <br>" +
                        "Spa =  " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                        "<br><br>";
                            TempAddPetMail = strupdate5;
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed5.SelectedItem.Text);
                            if (ddlStyle5.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle5.SelectedItem.Text);
                            if (txtAddServices5.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices5.Text.Trim().Substring(0, 1) == ",") ? txtAddServices5.Text.Trim().Remove(0, 1) : txtAddServices5.Text.Trim());
                            UpdatePetMail = TempAddPetMail;
                            AddPetMail = string.Empty;
                        }
                        if (chkPet5.Checked)
                        {
                            SetAppointment(5, (txtAddServicesID5.Text.Trim()));
                        }
                    }
                }
                #endregion

                #region
                if (p6.Visible == true)
                {
                    AddPetMail = string.Empty;
                    UpdatePetMail = string.Empty;
                    PetId = Convert.ToInt32(PetID6.Text);
                    if ((txtPetName6.Text.Trim() != "") && (txtDOB6.Text.Trim() != "") && (txtPetWeight6.Text.Trim() != "") && (txtPetLength6.Text.Trim() != ""))
                    {
                        if (chkSpa1.Checked == true) { spa = 1; IsSpa = "Yes"; }
                        else { spa = 0; IsSpa = "No"; }
                        if (PetID6.Text == "0")
                        {
                            string Pet6Id = ObjUpdateUser.AddPetFull(UserID, Convert.ToInt32(ddlPetType6.SelectedValue), txtPetName6.Text.Trim(), Convert.ToInt32(ddlBreed6.SelectedValue), Convert.ToInt32(txtDOB6.Text.Trim()), Convert.ToDecimal(txtPetWeight6.Text.Trim()), Convert.ToDecimal(txtPetLength6.Text.Trim()), spa, Convert.ToInt32(ddlStyle6.SelectedValue), txtAddServicesID6.Text.Trim());
                            string TempName = string.Empty;
                            if (Convert.ToInt32(ddlPetType6.SelectedValue) == 0) TempName = "Cat";
                            else TempName = "dog";
                            TempAddPetMail = "Pet = " + TempName + "<br>Pet Name = " + txtPetName6.Text.Trim() + "<br> Breed Name = BreedID " +
                                          "<br>Years = " + Convert.ToInt32(txtDOB6.Text.Trim()) + "<br>Weight = " + Convert.ToDecimal(txtPetWeight6.Text.Trim()) + " lbs<br> Fur Length = " + Convert.ToDecimal(txtPetLength6.Text.Trim()) + "   inches<br>" +
                                          "Spa =  " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                                          "<br><br>";
                            hashTable[6] = Convert.ToInt32(Pet6Id);
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed6.SelectedItem.Text);
                            if (ddlStyle6.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle6.SelectedItem.Text);
                            if (txtAddServices6.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices6.Text.Trim().Substring(0, 1) == ",") ? txtAddServices6.Text.Trim().Remove(0, 1) : txtAddServices6.Text.Trim());
                            AddPetMail = TempAddPetMail;
                            UpdatePetMail = string.Empty;
                        }
                        else
                        {
                            ObjUpdateUser.UpdatePetFull(Convert.ToInt32(PetID6.Text), UserID, Convert.ToInt32(ddlPetType6.SelectedValue), txtPetName6.Text.Trim(), Convert.ToInt32(ddlBreed6.SelectedValue), Convert.ToInt32(txtDOB6.Text.Trim()), Convert.ToDecimal(txtPetWeight6.Text.Trim()), Convert.ToDecimal(txtPetLength6.Text.Trim()), spa, Convert.ToInt32(ddlStyle6.SelectedValue), txtAddServicesID6.Text.Trim());
                            if (UpdatePet == "") UpdatePet = IsPetUpdate(6);
                            else UpdatePet = UpdatePet + IsPetUpdate(6);
                            string pettype6 = string.Empty;
                            if (ddlPetType6.SelectedValue == "0") pettype6 = "Cat";
                            else pettype6 = "dog";
                            string strupdate6 = "Pet = " + pettype6 + "<br>Pet Name = " + txtPetName6.Text.Trim() + "<br> Breed Name = BreedID " +
                        "<br>Years = " + txtDOB6.Text.Trim() + "<br>Weight = " + txtPetWeight6.Text.Trim() + "lbs <br>  Fur Length = " + txtPetLength6.Text.Trim() + "inches <br>" +
                        "Spa =  " + IsSpa + " <br> Style = StyleID <br> Additional Services = AdditionalService" +
                        "<br><br>";
                            TempAddPetMail = strupdate6;
                            TempAddPetMail = TempAddPetMail.Replace("BreedID", ddlBreed6.SelectedItem.Text);
                            if (ddlStyle6.SelectedValue == "0") TempAddPetMail = TempAddPetMail.Replace("StyleID", "Natural - No Cut");
                            else TempAddPetMail = TempAddPetMail.Replace("StyleID", ddlStyle6.SelectedItem.Text);
                            if (txtAddServices6.Text == "Select Service") TempAddPetMail = TempAddPetMail.Replace("AdditionalService", "No");
                            else TempAddPetMail = TempAddPetMail.Replace("AdditionalService", (txtAddServices6.Text.Trim().Substring(0, 1) == ",") ? txtAddServices6.Text.Trim().Remove(0, 1) : txtAddServices6.Text.Trim());
                            UpdatePetMail = TempAddPetMail;
                            AddPetMail = string.Empty;
                        }
                        if (chkPet6.Checked)
                        {
                            SetAppointment(6, (txtAddServicesID6.Text.Trim()));
                        }
                    }
                }
                #endregion


                StoreFrontUser str = new StoreFrontUser();
                str.UpdateUserType(UserID, Status);
                lblSuccess.ForeColor = System.Drawing.Color.Green;
                lblSuccess.Text = "Your appointment has been scheduled successfully";
                lblErrorDate.Text = "";
                lblErrorDate.Visible = false;
                lblNoPet.Visible = false;
                Response.Redirect("~/ThankYou.aspx");
            }
            else
            {
                if (ViewState["IsPet"].ToString() == "0")
                {
                    lblNoPet.Visible = true;
                    lblNoPet.Text = "Please fill pet(s) information ";
                    lblErrorDate.Text = "";
                }
                else
                {
                    lblErrorDate.Visible = true;
                    lblErrorDate.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/StaticeContent/AppointmentMessage.htm"));
                    lblErrorDate.Focus();
                    lblNoPet.Text = "";
                }
            }
        }
        else
        {
            lblerror.Visible = true;
            lblerror.Text = "Please select Pet";

        }
    }


    #region SetAppointment and AddPetAppointmentServices
    private void SetAppointment(int i, string OtherServiceID)
    {
        if (hashTable[i] != null)
        {
            UserAppointment ObjAppointment = new UserAppointment();
            string tt = string.IsNullOrEmpty(ddlhr.SelectedItem.Text)?"AM": Convert.ToDateTime(ddlhr.SelectedItem.Text).ToString("tt");
            int AppointmentID = ObjAppointment.AddAppointment(Convert.ToInt32(Session["UserID"].ToString()), Convert.ToDateTime(str1232.ToString()), ddlhr.SelectedItem.Text, tt, IsFlexible, int.Parse(ddlFlex.SelectedValue), ddlFlexDay.SelectedValue, ddlFlexHr.SelectedValue, IsPrimery, Address, Convert.ToInt32(redConfirmBy.SelectedValue), idtextarea.Text, hashTable[i].ToString());
            AddPetAppointmentServices(Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(hashTable[i].ToString()), AppointmentID, OtherServiceID);
            SendMail ObjMail = new SendMail();
            string AddUpdatePet = AddPetMail != string.Empty ? AddPetMail : UpdatePetMail;
            string d = txtSelectDate.Text;
            DateTime dt_ = Convert.ToDateTime(d);
            //string T = ddlhr.SelectedItem.Text + " -" + ddlmin.SelectedItem.Text;
            string T = ddlhr.SelectedItem.Text;

            //Send Mail to Member
            string Mailbody = ContentManager.GetStaticeContentEmail("Appointment.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- UserName -->", Session["MemberName"].ToString());
            Mailbody = Mailbody.Replace("<!-- Date -->", dt_.ToString("MMM-dd-yyyy"));
            Mailbody = Mailbody.Replace("<!-- Time -->", T);
            Mailbody = Mailbody.Replace("<!-- Flex -->", FlexTime);
            Mailbody = Mailbody.Replace(" <!-- Pets -->", AddUpdatePet);

            //Global ObjSubjec = new Global();
            //DataSet ds_Subject = ObjSubjec.GetEmailSubject("Appointment.htm");
            UserAppointment App = new UserAppointment();
            DataSet ds = new DataSet();
            ds = App.GetAppointment(AppointmentID);

            ObjMail.AppointmentMail(Convert.ToString(Session["UserName"]), Convert.ToString(Session["MemberName"]) + "'s  appointment request at Fritzy's Pet Care Pros.", Mailbody);

            //Send Mail to Admin
            string MailbodyAdmin = ContentManager.GetStaticeContentEmail("Appointment_Admin.htm").Replace("~", "#");
            MailbodyAdmin = MailbodyAdmin.Replace("<!-- UserName -->", Session["MemberName"].ToString());
            MailbodyAdmin = MailbodyAdmin.Replace("<!-- Address -->", ds.Tables[0].Rows[0]["Address"].ToString());
            MailbodyAdmin = MailbodyAdmin.Replace("<!-- Email -->", ds.Tables[0].Rows[0]["UserName"].ToString());
            MailbodyAdmin = MailbodyAdmin.Replace("<!-- ConfirmBy -->", ds.Tables[0].Rows[0]["ConfirmBy"].ToString());
            MailbodyAdmin = MailbodyAdmin.Replace("<!-- Phone -->", ds.Tables[0].Rows[0]["Phone"].ToString());
            MailbodyAdmin = MailbodyAdmin.Replace("<!-- Note -->", ds.Tables[0].Rows[0]["Note"].ToString());
            MailbodyAdmin = MailbodyAdmin.Replace("<!-- Date -->", dt_.ToString("MMM-dd-yyyy"));
            MailbodyAdmin = MailbodyAdmin.Replace("<!-- Time -->", T);
            MailbodyAdmin = MailbodyAdmin.Replace("<!-- Flex -->", FlexTime);
            MailbodyAdmin = MailbodyAdmin.Replace(" <!-- Pets -->", AddUpdatePet);

            ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), "Appointment by " + Convert.ToString(Session["MemberName"]), MailbodyAdmin);
            MailbodyAdmin = MailbodyAdmin.Replace("Admin", Convert.ToString(Session["MemberName"]));

            if (AddPetMail != string.Empty)
            {
                PetAddMail(AddPetMail);
            }

            if (UpdatePetMail != string.Empty)
            {
                PetUpdateMail(UpdatePetMail);
            }
            ClearAppointmentAbdScheduleedFields(i);
        }
    }
    private void AddPetAppointmentServices(int UserID, int PetId, int AppointmentId, string OtherServiceID)
    {
        UserAppointment ObjAppointment = new UserAppointment();
        ObjAppointment.AddPetAppointmentServices(UserID, PetId, AppointmentId, OtherServiceID);
    }
    protected void ClearAppointmentAbdScheduleedFields(int PetValue)
    {
        if (PetValue == 1)
        {
            chkSpa1.Checked = false;
            chkPet1.Checked = false;
            foreach (ListItem item in lstAddservices1.Items)
            {
                item.Selected = false;
            }
            txtAddServices1.Text = string.Empty;
        }
        else if (PetValue == 2)
        {
            chkSpa2.Checked = false;
            chkPet2.Checked = false;
            foreach (ListItem item in lstAddservices2.Items)
            {
                item.Selected = false;
            }
            txtAddServices2.Text = string.Empty;
        }
        else if (PetValue == 3)
        {
            chkSpa3.Checked = false;
            chkPet3.Checked = false;
            foreach (ListItem item in lstAddservices3.Items)
            {
                item.Selected = false;
            }
            txtAddServices3.Text = string.Empty;
        }
        else if (PetValue == 4)
        {
            chkSpa4.Checked = false;
            chkPet4.Checked = false;
            foreach (ListItem item in lstAddservices4.Items)
            {
                item.Selected = false;
            }
            txtAddServices4.Text = string.Empty;
        }
        else if (PetValue == 5)
        {
            chkSpa5.Checked = false;
            chkPet5.Checked = false;
            foreach (ListItem item in lstAddservices5.Items)
            {
                item.Selected = false;
            }
            txtAddServices5.Text = string.Empty;
        }
        else if (PetValue == 6)
        {
            chkSpa6.Checked = false;
            chkPet6.Checked = false;
            foreach (ListItem item in lstAddservices6.Items)
            {
                item.Selected = false;
            }
            txtAddServices6.Text = string.Empty;
        }
    }

    #endregion SetAppointment and AddPetAppointmentServices

    /* Comment
     Check status used to Set user type 
      1 - Cat 
      2 - Dog 
      3 - Cat and Dog 
      as per his pet type 
    */

    public int CheckStatus()
    {
        int c = 0;
        int d = 0;
        if ((p1.Visible == true) && (ViewState["IsPet"].ToString() != "0"))
        {
            if (ddlPetType1.SelectedValue == "0") c = c + 1;
            else d = d + 1;
        }
        if (p2.Visible == true)
        {
            if (ddlPetType2.SelectedValue == "0") c = c + 1;
            else d = d + 1;
        }
        if (p3.Visible == true)
        {
            if (ddlPetType3.SelectedValue == "0") c = c + 1;
            else d = d + 1;
        }
        if (p4.Visible == true)
        {
            if (ddlPetType4.SelectedValue == "0") c = c + 1;
            else d = d + 1;
        }
        if (p5.Visible == true)
        {
            if (ddlPetType5.SelectedValue == "0") c = c + 1;
            else d = d + 1;
        }
        if (p6.Visible == true)
        {
            if (ddlPetType6.SelectedValue == "0") c = c + 1;
            else d = d + 1;
        }
        int status = 3;
        if ((c == 0) && (d == 0))
            status = 3;
        if ((c > 0) && (d > 0))
            status = 3;
        if ((c > 0) && (d == 0))
            status = 1;
        if ((c == 0) && (d > 0))
            status = 2;
        return status;
    }
    /*
       Check pet use to Check whether user have fill at least one pet.
    */
    public int CheckPet()
    {
        if (ViewState["IsPet"].ToString() == "0")
        {
            if ((txtPetName1.Text.Trim() != "") && (ddlBreed1.SelectedIndex != 0) && (txtPetDOB1.Text.Trim() != "") && (txtPetWeight1.Text.Trim() != "") && (txtPetLength1.Text.Trim() != ""))
            {
                ViewState["IsPet"] = "1";
                ViewState["RowID"] = "0";
                return Convert.ToInt32(ddlPetType1.SelectedValue) + 1;
            }
            else
                return 3;
        }
        else
            return 3;
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MyAccount.aspx");
    }
    #endregion

    #region pet type selected index change
    protected void ddlPetType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed1(ddlPetType1.SelectedValue);
        txtPetName1.Focus();
    }
    protected void ddlPetType2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed2(ddlPetType2.SelectedValue);
        txtPetName2.Focus();
    }
    protected void ddlPetType3_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed3(ddlPetType3.SelectedValue);
        txtPetName3.Focus();
    }
    protected void ddlPetType4_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed4(ddlPetType4.SelectedValue);
        txtPetName4.Focus();
    }
    protected void ddlPetType5_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed5(ddlPetType5.SelectedValue);
        txtPetName5.Focus();
    }
    protected void ddlPetType6_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed6(ddlPetType6.SelectedValue);
        txtPetName6.Focus();
    }
    #endregion


    #region Delete pet button
    protected void imgDelete1_Click(object sender, ImageClickEventArgs e)
    {
        p1.Visible = false;
        string ch = string.Empty;
        if (chkSpa1.Checked) ch = "True";
        else ch = "False";
        string AddSer = string.Empty;
        if (txtAddServices1.Text.Trim().Remove(0, 1) == "Select Service") AddSer = "No";
        else AddSer = txtAddServices1.Text.Trim().Remove(0, 1);
        string style = string.Empty;
        if (ddlStyle1.SelectedValue == "0") style = "Natural - No Cut";
        else style = ddlStyle1.SelectedItem.Text;
        if (Convert.ToInt32(PetID1.Text.Trim()) > 0)
        {
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID1.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
            string Body = "Pet = " + ddlPetType1.SelectedItem.Text + "<br>Pet Name = " + txtPetName1.Text.Trim() + "<br> Breed Name = " + ddlBreed1.SelectedItem.Text +
                          "<br>Years = " + txtPetDOB1.Text.Trim() + "<br>Weight = " + txtPetWeight1.Text.Trim() + "<br> Fur Length = " + txtPetLength1.Text.Trim() + "<br>" + "Spa = " + ch + "<br>" + "Style = " + style + "<br>" + "Additional Services = " + AddSer + "<br><br>";
            PetDeleteMail(Body);
        }
        Response.Redirect("AppointmentNew.aspx");
    }
    protected void imgDelete2_Click(object sender, ImageClickEventArgs e)
    {
        p2.Visible = false;
        string ch = string.Empty;
        if (chkSpa2.Checked) ch = "True";
        else ch = "False";

        string AddSer = string.Empty;
        if (txtAddServices2.Text.Trim().Remove(0, 1) == "Select Service") AddSer = "No";
        else AddSer = txtAddServices2.Text.Trim().Remove(0, 1);
        string style = string.Empty;
        if (ddlStyle2.SelectedValue == "0") style = "Natural - No Cut";
        else style = ddlStyle2.SelectedItem.Text;
        if (Convert.ToInt32(PetID2.Text.Trim()) > 0)
        {
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID2.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
            string Body = "Pet = " + ddlPetType2.SelectedItem.Text + "<br>Pet Name = " + txtPetName2.Text.Trim() + "<br> Breed Name = " + ddlBreed2.SelectedItem.Text +
                          "<br>Years = " + txtDOB2.Text.Trim() + "<br>Weight = " + txtPetWeight2.Text.Trim() + "<br> Fur Length = " + txtPetLength2.Text.Trim() + "<br>" + "Spa = " + ch + "<br>" + "Style = " + style + "<br>" + "Additional Services = " + AddSer + "<br><br>";
            PetDeleteMail(Body);
        }
        Response.Redirect("AppointmentNew.aspx");
    }
    protected void imgDelete3_Click(object sender, ImageClickEventArgs e)
    {
        p3.Visible = false;
        string ch = string.Empty;
        if (chkSpa3.Checked) ch = "True";
        else ch = "False";
        string AddSer = string.Empty;
        if (txtAddServices3.Text.Trim().Remove(0, 1) == "Select Service") AddSer = "Natural - No Cut";
        else AddSer = txtAddServices3.Text.Trim().Remove(0, 1);
        string style = string.Empty;
        if (ddlStyle3.SelectedValue == "0") style = "No";
        else style = ddlStyle3.SelectedItem.Text;
        if (Convert.ToInt32(PetID3.Text.Trim()) > 0)
        {
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID3.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
            string Body = "Pet = " + ddlPetType3.SelectedItem.Text + "<br>Pet Name = " + txtPetName3.Text.Trim() + "<br> Breed Name = " + ddlBreed3.SelectedItem.Text +
                          "<br>Years = " + txtDOB3.Text.Trim() + "<br>Weight = " + txtPetWeight3.Text.Trim() + "<br> Fur Length = " + txtPetLength3.Text.Trim() + "<br>" + "Spa = " + ch + "<br>" + "Style = " + style + "<br>" + "Additional Services = " + AddSer + "<br><br>";
            PetDeleteMail(Body);
        }
        Response.Redirect("AppointmentNew.aspx");
    }
    protected void imgDelete4_Click(object sender, ImageClickEventArgs e)
    {
        p4.Visible = false;
        string ch = string.Empty;
        if (chkSpa4.Checked) ch = "True";
        else ch = "False";
        string AddSer = string.Empty;
        if (txtAddServices4.Text.Trim().Remove(0, 1) == "Select Service") AddSer = "Natural - No Cut";
        else AddSer = txtAddServices4.Text.Trim().Remove(0, 1);
        string style = string.Empty;
        if (ddlStyle4.SelectedValue == "0") style = "No";
        else style = ddlStyle4.SelectedItem.Text;
        if (Convert.ToInt32(PetID4.Text.Trim()) > 0)
        {
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID4.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
            string Body = "Pet = " + ddlPetType4.SelectedItem.Text + "<br>Pet Name = " + txtPetName4.Text.Trim() + "<br> Breed Name = " + ddlBreed4.SelectedItem.Text +
                          "<br>Years = " + txtDOB4.Text.Trim() + "<br>Weight = " + txtPetWeight4.Text.Trim() + "<br> Fur Length = " + txtPetLength4.Text.Trim() + "<br>" + "Spa = " + ch + "<br>" + "Style = " + style + "<br>" + "Additional Services = " + AddSer + "<br><br>";
            PetDeleteMail(Body);
        }
        Response.Redirect("AppointmentNew.aspx");
    }
    protected void imgDelete5_Click(object sender, ImageClickEventArgs e)
    {
        p5.Visible = false;
        string ch = string.Empty;
        if (chkSpa5.Checked) ch = "True";
        else ch = "False";
        string AddSer = string.Empty;
        if (txtAddServices5.Text.Trim().Remove(0, 1) == "Select Service") AddSer = "No";
        else AddSer = txtAddServices5.Text.Trim().Remove(0, 1);
        string style = string.Empty;
        if (ddlStyle5.SelectedValue == "0") style = "Natural - No Cut";
        else style = ddlStyle5.SelectedItem.Text;
        if (Convert.ToInt32(PetID5.Text.Trim()) > 0)
        {
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID5.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
            string Body = "Pet = " + ddlPetType5.SelectedItem.Text + "<br>Pet Name = " + txtPetName5.Text.Trim() + "<br> Breed Name = " + ddlBreed5.SelectedItem.Text +
                          "<br>Years = " + txtDOB5.Text.Trim() + "<br>Weight = " + txtPetWeight5.Text.Trim() + "<br> Fur Length = " + txtPetLength5.Text.Trim() + "<br>" + "Spa = " + ch + "<br>" + "Style = " + style + "<br>" + "Additional Services = " + AddSer + "<br><br>";
            PetDeleteMail(Body);
        }
        Response.Redirect("AppointmentNew.aspx");
    }
    protected void imgDelete6_Click(object sender, ImageClickEventArgs e)
    {
        p6.Visible = false;
        string ch = string.Empty;
        if (chkSpa6.Checked) ch = "True";
        else ch = "False";
        string AddSer = string.Empty;
        if (txtAddServices6.Text.Trim().Remove(0, 1) == "Select Service") AddSer = "No";
        else AddSer = txtAddServices6.Text.Trim().Remove(0, 1);
        string style = string.Empty;
        if (ddlStyle6.SelectedValue == "0") style = "Natural - No Cut";
        else style = ddlStyle6.SelectedItem.Text;
        if (Convert.ToInt32(PetID6.Text.Trim()) > 0)
        {
            StoreFrontUser ObjDelPet = new StoreFrontUser();
            ObjDelPet.DeletePet(Convert.ToInt32(PetID6.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
            string Body = "Pet = " + ddlPetType6.SelectedItem.Text + "<br>Pet Name = " + txtPetName6.Text.Trim() + "<br> Breed Name = " + ddlBreed6.SelectedItem.Text +
                         "<br>Years = " + txtDOB6.Text.Trim() + "<br>Weight = " + txtPetWeight6.Text.Trim() + "<br> Fur Length = " + txtPetLength6.Text.Trim() + "<br>" + "Spa = " + ch + "<br>" + "Style = " + style + "<br>" + "Additional Services = " + AddSer + "<br><br>";
            PetDeleteMail(Body);
        }
        Response.Redirect("AppointmentNew.aspx");
    }

    public int GetUpdatedPet()
    {
        int Status = 3;
        int Type = CheckPet();
        if (Type == 3)
            Status = CheckStatus();
        else
            Status = Type;
        Session["UserType"] = Status.ToString();
        return Status;
    }
    #endregion


    #region function to Send Mail
    public void PetAddMail(string body)
    {
        try
        {
            SendMail ObjMail = new SendMail();
            //send mail to admin 
            string Mailbody = ContentManager.GetStaticeContentEmail("AddPet.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace(" <!-- AddPet -->", body);
            Mailbody = Mailbody.Replace("<!-- UserName -->", Session["MemberName"].ToString());
            ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), Convert.ToString(Session["MemberName"]) + " added pet at Fritzy's Pet Care Pros", Mailbody);

            //send mail to member
            Mailbody = ContentManager.GetStaticeContentEmail("AddPetMember.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace(" <!-- AddPet -->", body);
            Mailbody = Mailbody.Replace("<!-- UserName -->", Session["MemberName"].ToString());
            ObjMail.AppointmentMail(Session["UserName"].ToString(), "New Pet added details  at Fritzy's Pet Care Pros", Mailbody);
        }
        catch
        {
        }
    }
    public void PetDeleteMail(string body)
    {
        try
        {
            SendMail ObjMail = new SendMail();
            //send mail to admin 
            string Mailbody = ContentManager.GetStaticeContentEmail("DeletePet.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- Deleted -->", body);
            Mailbody = Mailbody.Replace("<!-- UserName -->", Session["MemberName"].ToString());
            ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), Convert.ToString(Session["MemberName"]) + " deleted pet", Mailbody);

            //send mail to member
            Mailbody = ContentManager.GetStaticeContentEmail("DeletePetMember.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- Deleted -->", body);
            Mailbody = Mailbody.Replace("<!-- UserName -->", Session["MemberName"].ToString());
            ObjMail.AppointmentMail(Session["UserName"].ToString(), "Deleted pet details  at Fritzy's Pet Care Pros", Mailbody);

        }
        catch
        {
        }
    }
    public void PetUpdateMail(string body)
    {
        try
        {
            SendMail ObjMail = new SendMail();
            //send mail to admin 
            string Mailbody = ContentManager.GetStaticeContentEmail("PetUpdate.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- Update -->", body);
            Mailbody = Mailbody.Replace("<!-- UserName -->", Session["MemberName"].ToString());
            ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), Convert.ToString(Session["MemberName"]) + " updated pet ", Mailbody);

            //send mail to member
            Mailbody = ContentManager.GetStaticeContentEmail("PetUpdateMember.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- Update -->", body);
            Mailbody = Mailbody.Replace("<!-- UserName -->", Session["MemberName"].ToString());
            ObjMail.AppointmentMail(Session["UserName"].ToString(), "Updated pet details  at Fritzy's Pet Care Pros", Mailbody);
        }
        catch
        {
        }
    }

    public string IsPetUpdate(int count)
    {
        string str = string.Empty;
        DataTable dt = (DataTable)ViewState["Pet"];
        switch (count)
        {
            case 1:
                string Spa = "False";
                if (chkSpa1.Checked) Spa = "True";
                string Style = string.Empty;
                if (ddlStyle1.SelectedValue != "0") Style = ddlStyle1.SelectedItem.Text;
                string AdditionalServices = "No";
                if (txtAddServices1.Text == "Select Service") AdditionalServices = txtAddServices1.Text.Trim().Remove(0, 1);
                if (ddlPetType1.SelectedValue != dt.Rows[0]["PetType"].ToString() || txtPetName1.Text.Trim() != dt.Rows[0]["PetName"].ToString() || ddlBreed1.SelectedValue != dt.Rows[0]["BreedID"].ToString() || txtPetDOB1.Text.Trim() != dt.Rows[0]["Years"].ToString() || txtPetWeight1.Text.Trim() != dt.Rows[0]["Weight"].ToString() || txtPetLength1.Text.Trim() != dt.Rows[0]["Length"].ToString() || ddlStyle1.SelectedValue != dt.Rows[0]["StyleID"].ToString() || txtAddServicesID1.Text != dt.Rows[0]["AdditionalService"].ToString() || Spa.ToString() != dt.Rows[0]["Spa"].ToString())
                {
                    str = "Pet = " + ddlPetType1.SelectedItem.Text + "<br>" +
                    "Pet Name = " + txtPetName1.Text + "<br>" +
                    "Breed Name = " + ddlBreed1.SelectedItem.Text + "<br>" +
                    "Year = " + txtPetDOB1.Text.Trim() + "<br>" +
                    "Weight = " + txtPetWeight1.Text.Trim() + "<br>" +
                    "Length = " + txtPetLength1.Text.Trim() + "<br>" +
                    "Spa = " + Spa + "<br>" +
                    "Style = " + Style + "<br>" +
                    "Additional Services = " + txtAddServices1.Text.Trim() + "<br><br>";
                }
                break;
            case 2:
                string Spa2 = "False";
                if (chkSpa2.Checked) Spa2 = "True";
                string Style2 = "No";
                if (ddlStyle2.SelectedValue != "0") Style2 = ddlStyle2.SelectedItem.Text;
                string AdditionalServices2 = "No";
                if (txtAddServices2.Text != "Select Service") AdditionalServices2 = txtAddServices2.Text.Trim().Remove(0, 1);
                if (ddlPetType2.SelectedValue != dt.Rows[1]["PetType"].ToString() || txtPetName2.Text.Trim() != dt.Rows[1]["PetName"].ToString() || ddlBreed2.SelectedValue != dt.Rows[1]["BreedID"].ToString() || txtDOB2.Text.Trim() != dt.Rows[1]["Years"].ToString() || txtPetWeight2.Text.Trim() != dt.Rows[1]["Weight"].ToString() || txtPetLength2.Text.Trim() != dt.Rows[1]["Length"].ToString())
                {
                    str = "Pet = " + ddlPetType2.SelectedItem.Text + "<br>" +
                    "Pet Name = " + txtPetName2.Text + "<br>" +
                    "Breed Name = " + ddlBreed2.SelectedItem.Text + "<br>" +
                    "Year = " + txtDOB2.Text.Trim() + "<br>" +
                    "Weight = " + txtPetWeight2.Text.Trim() + "<br>" +
                    "Length = " + txtPetLength2.Text.Trim() + "<br>" +
                    "Spa = " + Spa2 + "<br>" +
                    "Style = " + Style2 + "<br>" +
                    "Additional Services = " + txtAddServices2.Text.Trim() + "<br><br>";
                }
                break;
            case 3:
                string Spa3 = "False";
                if (chkSpa3.Checked) Spa3 = "True";
                string Style3 = "No";
                if (ddlStyle3.SelectedValue != "0") Style3 = ddlStyle3.SelectedItem.Text;
                string AdditionalServices3 = "No";
                if (txtAddServices3.Text == "Select Service") AdditionalServices3 = txtAddServices3.Text.Trim().Remove(0, 1);
                if (ddlPetType3.SelectedValue != dt.Rows[2]["PetType"].ToString() || txtPetName3.Text.Trim() != dt.Rows[2]["PetName"].ToString() || ddlBreed3.SelectedValue != dt.Rows[2]["BreedID"].ToString() || txtDOB3.Text.Trim() != dt.Rows[2]["Years"].ToString() || txtPetWeight3.Text.Trim() != dt.Rows[2]["Weight"].ToString() || txtPetLength3.Text.Trim() != dt.Rows[2]["Length"].ToString())
                {
                    str = "Pet = " + ddlPetType3.SelectedItem.Text + "<br>" +
                    "Pet Name = " + txtPetName3.Text + "<br>" +
                    "Breed Name = " + ddlBreed3.SelectedItem.Text + "<br>" +
                    "Year = " + txtDOB3.Text.Trim() + "<br>" +
                    "Weight = " + txtPetWeight3.Text.Trim() + "<br>" +
                    "Length = " + txtPetLength3.Text.Trim() + "<br>" +
                    "Spa = " + Spa3 + "<br>" +
                    "Style = " + Style3 + "<br>" +
                    "Additional Services = " + txtAddServices3.Text.Trim() + "<br><br>";
                }
                break;
            case 4:
                string Spa4 = "False";
                if (chkSpa4.Checked) Spa4 = "True";
                string Style4 = "No";
                if (ddlStyle4.SelectedValue != "0") Style4 = ddlStyle4.SelectedItem.Text;
                string AdditionalServices4 = "No";
                if (txtAddServices4.Text == "Select Service") AdditionalServices4 = txtAddServices4.Text.Trim().Remove(0, 1);
                if (ddlPetType4.SelectedValue != dt.Rows[3]["PetType"].ToString() || txtPetName4.Text.Trim() != dt.Rows[3]["PetName"].ToString() || ddlBreed4.SelectedValue != dt.Rows[3]["BreedID"].ToString() || txtDOB4.Text.Trim() != dt.Rows[3]["Years"].ToString() || txtPetWeight4.Text.Trim() != dt.Rows[3]["Weight"].ToString() || txtPetLength4.Text.Trim() != dt.Rows[3]["Length"].ToString())
                {
                    str = "Pet = " + ddlPetType4.SelectedItem.Text + "<br>" +
                    "Pet Name = " + txtPetName4.Text + "<br>" +
                    "Breed Name = " + ddlBreed4.SelectedItem.Text + "<br>" +
                    "Year = " + txtDOB4.Text.Trim() + "<br>" +
                    "Weight = " + txtPetWeight4.Text.Trim() + "<br>" +
                    "Length = " + txtPetLength4.Text.Trim() + "<br>" +
                    "Spa = " + Spa4 + "<br>" +
                    "Style = " + Style4 + "<br>" +
                    "Additional Services = " + txtAddServices4.Text.Trim() + "<br><br>";
                }
                break;
            case 5:
                string Spa5 = "False";
                if (chkSpa5.Checked) Spa5 = "True";
                string Style5 = "No";
                if (ddlStyle5.SelectedValue != "0") Style5 = ddlStyle5.SelectedItem.Text;
                string AdditionalServices5 = "No";
                if (txtAddServices5.Text == "Select Service") AdditionalServices5 = txtAddServices5.Text.Trim().Remove(0, 1);
                if (ddlPetType5.SelectedValue != dt.Rows[4]["PetType"].ToString() || txtPetName5.Text.Trim() != dt.Rows[4]["PetName"].ToString() || ddlBreed5.SelectedValue != dt.Rows[4]["BreedID"].ToString() || txtDOB5.Text.Trim() != dt.Rows[4]["Years"].ToString() || txtPetWeight5.Text.Trim() != dt.Rows[4]["Weight"].ToString() || txtPetLength5.Text.Trim() != dt.Rows[4]["Length"].ToString())
                {
                    str = "Pet = " + ddlPetType5.SelectedItem.Text + "<br>" +
                    "Pet Name = " + txtPetName5.Text + "<br>" +
                    "Breed Name = " + ddlBreed5.SelectedItem.Text + "<br>" +
                    "Year = " + txtDOB5.Text.Trim() + "<br>" +
                    "Weight = " + txtPetWeight5.Text.Trim() + "<br>" +
                    "Length = " + txtPetLength5.Text.Trim() + "<br>" +
                    "Spa = " + Spa5 + "<br>" +
                    "Style = " + Style5 + "<br>" +
                    "Additional Services = " + txtAddServices5.Text.Trim() + "<br><br>";
                }
                break;
            case 6:
                string Spa6 = "False";
                if (chkSpa6.Checked) Spa6 = "True";
                string Style6 = "No";
                if (ddlStyle6.SelectedValue != "0") Style6 = ddlStyle6.SelectedItem.Text;
                string AdditionalServices6 = "No";
                if (txtAddServices6.Text == "Select Service") AdditionalServices6 = txtAddServices6.Text.Trim().Remove(0, 1);
                if (ddlPetType6.SelectedValue != dt.Rows[5]["PetType"].ToString() || txtPetName6.Text.Trim() != dt.Rows[5]["PetName"].ToString() || ddlBreed6.SelectedValue != dt.Rows[5]["BreedID"].ToString() || txtDOB6.Text.Trim() != dt.Rows[5]["Years"].ToString() || txtPetWeight6.Text.Trim() != dt.Rows[5]["Weight"].ToString() || txtPetLength6.Text.Trim() != dt.Rows[5]["Length"].ToString())
                {
                    str = "Pet = " + ddlPetType6.SelectedItem.Text + "<br>" +
                    "Pet Name = " + txtPetName6.Text + "<br>" +
                    "Breed Name = " + ddlBreed6.SelectedItem.Text + "<br>" +
                    "Year = " + txtDOB6.Text.Trim() + "<br>" +
                    "Weight = " + txtPetWeight6.Text.Trim() + "<br>" +
                    "Length = " + txtPetLength6.Text.Trim() + "<br>" +
                    "Spa = " + Spa6 + "<br>" +
                    "Style = " + Style6 + "<br>" +
                    "Additional Services = " + txtAddServices6.Text.Trim() + "<br><br>";
                }
                break;
        }
        return str;
    }
    #endregion


    protected void Button1_Click(object sender, EventArgs e)
    {
        FillDropdown();
    }

    #region Calender
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
        }
        DateTime TodaysDate = System.DateTime.Now;
        if (TodaysDate.Date > e.Day.Date)
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
        }
        if (e.Day.Date == new DateTime(e.Day.Date.Year, 01, 01))
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
        }
        if (e.Day.Date == new DateTime(e.Day.Date.Year, 07, 4))
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
        }
        if (e.Day.Date == new DateTime(e.Day.Date.Year, 12, 25))
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
        }
        //may
        if (e.Day.Date == new DateTime(2010, 05, 31))
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
        }
        //september
        if (e.Day.Date == new DateTime(2010, 09, 06))
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
        }
        //november
        if (e.Day.Date == new DateTime(2010, 11, 25))
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
        }
        Appointment objApp = new Appointment();
        DataSet DS = new DataSet();
        DS = objApp.GetAppointmentDate();
        if (DS.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                if (e.Day.Date == Convert.ToDateTime(DS.Tables[0].Rows[i]["AppDate"].ToString()))
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime TodaysDate = System.DateTime.Now;
        DateTime SelectedDate = Calendar1.SelectedDate.Date;
        int day = SelectedDate.Day;
        int year = SelectedDate.Year;
        int month = SelectedDate.Month;
        txtSelectDate.Text = Calendar1.SelectedDate.ToShortDateString();
        FillDropdown();
        //dddDay.SelectedValue = day.ToString();
        //ddlMonth.SelectedValue = month.ToString();
        if (SelectedDate.Day > TodaysDate.Day)
        {
            lblErrorDate.Text = "";
            //ddlYear.SelectedValue = year.ToString();
        }
    }
    #endregion Calender

    #region Breed Bind
    protected void ddlBreed1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPet1(ddlBreed1.SelectedValue);
        txtPetDOB1.Focus();
    }
    protected void ddlBreed2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPet2(ddlBreed2.SelectedValue);
        txtDOB2.Focus();
    }
    protected void ddlBreed3_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPet3(ddlBreed3.SelectedValue);
        txtDOB3.Focus();
    }
    protected void ddlBreed4_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPet4(ddlBreed4.SelectedValue);
        txtDOB4.Focus();
    }
    protected void ddlBreed5_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPet5(ddlBreed5.SelectedValue);
        txtDOB5.Focus();
    }
    protected void ddlBreed6_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPet6(ddlBreed6.SelectedValue);
        txtDOB6.Focus();
    }
    #endregion Breed Bind

}
