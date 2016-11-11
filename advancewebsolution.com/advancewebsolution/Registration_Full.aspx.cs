using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CaptchaDotNet2.Security.Cryptography;
using System.Net.Mail;
using System.Text;
using advancewebtosolution.BO;

public partial class Registration_Full : System.Web.UI.Page
{
    public delegate void CaptchaEventHandler();
    string PetTypeID = "0";

    #region Captcha Code
    private string color = "#ffffff";
    protected string style;
    //private event CaptchaEventHandler success;
    //private event CaptchaEventHandler failure;
    private void SetCaptcha()
    {
        // Set image
        string s = RandomText.Generate();

        // Encrypt
        string ens = Encryptor.Encrypt(s, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));

        // Save to session
        Session["captcha"] = s.ToLower();

        // Set url
        imgCaptcha.ImageUrl = "~/Captcha.ashx?w=305&h=92&c=" + ens + "&bc=" + color;
    }
   
    public string BackgroundColor
    {
        set { color = value.Trim("#".ToCharArray()); }
        get { return color; }
    }
    public string Style
    {
        set { style = value; }
        get { return style; }
    }
    //public event CaptchaEventHandler Success
    //{
    //    add { success += value; }
    //    remove { success += null; }
    //}
    //public event CaptchaEventHandler Failure
    //{
    //    add { failure += value; }
    //    remove { failure += null; }
    //}

    #endregion

    #region Bind
    public void GetBreed1(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";

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
            ddlBreed1.Items.Insert(0, lst);
        }
    }
    public void GetBreed2(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
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
            ddlBreed2.Items.Insert(0, lst);
        }
    }
    public void GetBreed3(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
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
            ddlBreed3.Items.Insert(0, lst);
        }
    }
    public void GetBreed4(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
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
            ddlBreed4.Items.Insert(0, lst);
        }
    }
    public void GetBreed5(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
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
            ddlBreed5.Items.Insert(0, lst);
        }
    }
    public void GetBreed6(string PetType)
    {
        StoreFrontUser ObjReg = new StoreFrontUser();
        DataSet ds = new DataSet();
        ds = ObjReg.GetBreedFront(PetType);
        ListItem lst = new ListItem();
        lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";
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
            ddlBreed6.Items.Insert(0, lst);
        }
    }
    
    public void GetReferal()
    {
        StoreFrontUser ObjRef = new StoreFrontUser();
        DataSet ds1 = new DataSet();
        ds1 = ObjRef.GetReferalSourceFront();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            ListItem lst = new ListItem();
            lst.Selected = true; lst.Value = "0"; lst.Text = "Select One";

            ddlReferralSource.DataTextField = "ReferalName";
            ddlReferralSource.DataValueField = "ReferalID";
            ddlReferralSource.DataSource = ds1.Tables[0];
            ddlReferralSource.DataBind();
            ddlReferralSource.Items.Insert(0, lst);
        }
    }

    public void BindState()
    {
        Global ObjState = new Global();
        DataSet ds = new DataSet();
        ListItem lst = new ListItem();
        lst.Text = "State";
        lst.Value = "0";

        ds = ObjState.GetAllState();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlState.DataValueField = "StateShortName";
            ddlState.DataTextField = "StateShortName";
            ddlState.DataSource = ds.Tables[0];
            ddlState.DataBind();
            ddlState1.DataValueField = "StateShortName";
            ddlState1.DataTextField = "StateShortName";
            ddlState1.DataSource = ds.Tables[0];
            ddlState1.DataBind();
        }
        ddlState.Items.Insert(0, lst);
        ddlState1.Items.Insert(0, lst);
    }
    #endregion 

    /*  Page Load 
        On page load only one row is visible .
     *  so that row id = 0; ViewState["RowID"] = 0
     *  GetReferal is used to set referral source from database managed by admin
     *  SetCaptcha is used to set captcha control 
     *  GetBreed1,GetBreed2,GetBreed3,GetBreed4,GetBreed5,GetBreed6 are use to set breed in all dropdown list - six dropdown.
     *  BindState use to bind state will bind all the state from US 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["IsPet"] = "0";
            SetCaptcha();

            GetBreed1(PetTypeID);
            GetBreed2(PetTypeID);
            GetBreed3(PetTypeID);
            GetBreed4(PetTypeID);
            GetBreed5(PetTypeID);
            GetBreed6(PetTypeID);

            GetReferal();
            ViewState["RowID"] = 0;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/StaticeContent/Registratio_Full.htm"));
            BindState();
        }
    }

    #region Event
    /* This region Use to reset captcha text */
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        txtConfirmReg.Text = string.Empty;
        SetCaptcha();
    }

    /* This event is use to set new row for pet and maintain the row count asuser can add only six pet */
    protected void imgAddmore_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["RowID"].ToString() == "0")
        {
            p2.Visible = true;
            ViewState["RowID"] = "1";
            ViewState["IsPet"] = "1";
        }
        else if (ViewState["RowID"].ToString() == "1")
        {
            p3.Visible = true;
            ViewState["RowID"] = "2";
        }
        else if (ViewState["RowID"].ToString() == "2")
        {
            p4.Visible = true;
            ViewState["RowID"] = "3";
        }
        else if (ViewState["RowID"].ToString() == "3")
        {
            p5.Visible = true;
            ViewState["RowID"] = "4";
        }
        else if (ViewState["RowID"].ToString() == "4")
        {
            p6.Visible = true;
            ViewState["RowID"] = "5";
        }
        else if (ViewState["RowID"].ToString() == "5")
        {
            imgAddmore.Visible = false;
            lblMessageSix.Visible = true;
            lblMessageSix.Text = "You can add only six pets";
        }
    }

    /* 
    *  This event is used to add new member data to database with check and 
       Add pet information to database.
    *  also set if Isrember function as per user choice 
    *  send a mail to user to "Welcome User"
    */
    protected void IdSubmit_Click(object sender, ImageClickEventArgs e)
    {
        string str = Session["captcha"].ToString();
        if (txtConfirmReg.Text.ToLower() != Session["captcha"].ToString())
        {
            lblCaptchaError.Visible = true;
            lblCaptchaError.Text = "Please enter correct confirmation code";
        }
        else
        {
            lblCaptchaError.Visible = false;
            lblCaptchaError.Text = "";
            StoreFrontUser ObjNewUser = new StoreFrontUser();
            //int UserID = ObjNewUser.AddUserBasic(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtStreet.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(), txtZip.Text.Trim(), txtPhone.Text.Trim(), Convert.ToInt32(ddlReferralSource.SelectedValue), txtEmailReg.Text.Trim(), txtPasswordReg.Text.Trim());
            int Status = 3;
            int Type = CheckPet();
            if (Type == 3)
                Status = CheckStatus();
            else
                Status = Type;
            Session["UserType"] = Status.ToString();
            Session["MemberName"] = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            int UserID = ObjNewUser.AddUserFull(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtStreet.Text.Trim(), txtCity.Text.Trim(), ddlState.SelectedItem.Text , txtZip.Text.Trim(), txtPhone.Text.Trim(), Convert.ToInt32(ddlReferralSource.SelectedValue), txtEmailReg.Text.Trim(), txtPasswordReg.Text.Trim(), txtAltMobile.Text.Trim(), txtAltContact.Text.Trim(), txtAltStreet.Text.Trim(), txtAltCity.Text.Trim(), ddlState1.SelectedItem.Text, txtAltZip.Text.Trim(), txtAltPhone.Text.Trim(), txtGroomer.Text.Trim(), Status);
            if (UserID != 0)
            {
                if (p1.Visible == true)
                {
                    if ((txtPetName1.Text.Trim() != "") && (ddlBreed1.SelectedIndex != 0) && (txtPetDOB1.Text.Trim() != "") && (txtPetWeight1.Text.Trim() != "") && (txtPetLength1.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType1.SelectedValue), txtPetName1.Text.Trim(), Convert.ToInt32(ddlBreed1.SelectedValue), Convert.ToInt32(txtPetDOB1.Text.Trim()), Convert.ToDecimal(txtPetWeight1.Text.Trim()), Convert.ToDecimal(txtPetLength1.Text.Trim()));
                }
                if (p2.Visible == true)
                {
                    if ((txtPetName2.Text.Trim() != "") && (ddlBreed2.SelectedIndex != 0) && (txtDOB2.Text.Trim() != "") && (txtPetWeight2.Text.Trim() != "") && (txtPetLength2.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType2.SelectedValue), txtPetName2.Text.Trim(), Convert.ToInt32(ddlBreed2.SelectedValue), Convert.ToInt32(txtDOB2.Text.Trim()), Convert.ToDecimal(txtPetWeight2.Text.Trim()), Convert.ToDecimal(txtPetLength2.Text.Trim()));
                }
                if (p3.Visible == true)
                {
                    if ((txtPetName3.Text.Trim() != "") && (ddlBreed3.SelectedIndex != 0) && (txtDOB3.Text.Trim() != "") && (txtPetWeight3.Text.Trim() != "") && (txtPetLength3.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType3.SelectedValue), txtPetName3.Text.Trim(), Convert.ToInt32(ddlBreed3.SelectedValue), Convert.ToInt32(txtDOB3.Text.Trim()), Convert.ToDecimal(txtPetWeight3.Text.Trim()), Convert.ToDecimal(txtPetLength3.Text.Trim()));
                }
                if (p4.Visible == true)
                {
                    if ((txtPetName4.Text.Trim() != "") && (ddlBreed4.SelectedIndex != 0) && (txtDOB4.Text.Trim() != "") && (txtPetWeight4.Text.Trim() != "") && (txtPetLength4.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType4.SelectedValue), txtPetName4.Text.Trim(), Convert.ToInt32(ddlBreed4.SelectedValue), Convert.ToInt32(txtDOB4.Text.Trim()), Convert.ToDecimal(txtPetWeight4.Text.Trim()), Convert.ToDecimal(txtPetLength4.Text.Trim()));
                }
                if (p5.Visible == true)
                {
                    if ((txtPetName5.Text.Trim() != "") && (ddlBreed5.SelectedIndex != 0) && (txtDOB5.Text.Trim() != "") && (txtPetWeight5.Text.Trim() != "") && (txtPetLength5.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType5.SelectedValue), txtPetName5.Text.Trim(), Convert.ToInt32(ddlBreed5.SelectedValue), Convert.ToInt32(txtDOB5.Text.Trim()), Convert.ToDecimal(txtPetWeight5.Text.Trim()), Convert.ToDecimal(txtPetLength5.Text.Trim()));
                }
                if (p6.Visible == true)
                {
                    if ((txtPetName6.Text.Trim() != "") && (ddlBreed6.SelectedIndex != 0) && (txtDOB6.Text.Trim() != "") && (txtPetWeight6.Text.Trim() != "") && (txtPetLength6.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType6.SelectedValue), txtPetName6.Text.Trim(), Convert.ToInt32(ddlBreed6.SelectedValue), Convert.ToInt32(txtDOB6.Text.Trim()), Convert.ToDecimal(txtPetWeight6.Text.Trim()), Convert.ToDecimal(txtPetLength6.Text.Trim()));
                }


                if (chkRemember.Checked == true)
                {
                    HttpContext.Current.Request.Cookies.Clear();
                    if (Request.Cookies["remUsername"] == null)
                    {
                        HttpCookie c = new HttpCookie("remUsername", txtEmailReg.Text);
                        c.Expires =  DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
                        Response.Cookies.Add(c);
                    }
                    if (Request.Cookies["remPassword"] == null)
                    {
                        HttpCookie c = new HttpCookie("remPassword", txtPasswordReg.Text);
                        c.Expires =  DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
                        Response.Cookies.Add(c);
                    }
                }
                else
                {
                    Response.Cookies["remUsername"].Expires = DateTime.Now.AddYears(-30);
                    Response.Cookies["remPassword"].Expires = DateTime.Now.AddYears(-30);
                }
                if ((Request.Cookies["IsLogin"] == null) || (Request.Cookies["IsLogin"].ToString() == "0"))
                {
                    HttpCookie c = new HttpCookie("IsLogin", "1");
                    c.Expires = new DateTime(2050, 12, 1);
                    Response.Cookies.Add(c);
                }
                Session["MemberName"] = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
                Session["UserID"] = UserID.ToString();
                Session["UserName"] = txtEmailReg.Text.Trim();
                Session["IsLogin"] = "1";

                string Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();

                 try
                {
                    //send mail to Admin
                    string Message = ContentManager.GetStaticeContentEmail("RegistrationAdmin.htm").Replace("~", "#");
                    Message = Message.Replace("<!-- Name -->", Name);
                    Message = Message.Replace("<!-- Username -->", txtEmailReg.Text.Trim());
                    MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["ToEmail"]);
                    objMailMsg.BodyEncoding = Encoding.UTF8;
                    objMailMsg.Subject = "Registration Successfully Completed By  " + Name;
                    objMailMsg.Body = Message;
                    objMailMsg.Priority = MailPriority.High;
                    objMailMsg.IsBodyHtml = true;
                    SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
                    objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
                    objSMTPClient.EnableSsl = true;
                    objSMTPClient.Send(objMailMsg);

                    //send mail to member
                    Message = ContentManager.GetStaticeContentEmail("Registration.htm").Replace("~", "#");
                    Message = Message.Replace("<!-- Name -->", Name);
                    Message = Message.Replace("<!-- Username -->", txtEmailReg.Text.Trim());

                    objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], txtEmailReg.Text.Trim());
                    objMailMsg.BodyEncoding = Encoding.UTF8;
                    objMailMsg.Subject = "Welcome to Fritzy's Club: Registration Successfully Completed";
                    objMailMsg.Body = Message;
                    objMailMsg.Priority = MailPriority.High;
                    objMailMsg.IsBodyHtml = true;
                    objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
                    objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
                    objSMTPClient.EnableSsl = true;
                    objSMTPClient.Send(objMailMsg);
                }
                catch
                {
                }
                Response.Redirect("~/Appointment.aspx");
            }
            else
            {
                lblCaptchaError.Visible = true;
                lblCaptchaError.Text = "We’re sorry, this username already exists.";
            }
        }
    }
    /* this event reset the al field of page */
    protected void IdReset_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Registration_Full.aspx");
    }

    /* 
    *  This function use tocheck the user type as per user pet selection 
       1 - Cat intreated user
    *  2 - Dog intreated user
    *  3 - CatandDog intreated user
    */
    public int CheckStatus()
    {
        int c = 0;
        int d = 0;
        if ((p1.Visible == true) && (ViewState["RowID"].ToString() != "0"))
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

    public int CheckPet()
    {
        if (ViewState["IsPet"].ToString() == "0")
        {
            if ((txtPetName1.Text.Trim() != "") && (ddlBreed1.SelectedIndex != 0) && (txtPetDOB1.Text.Trim() != "") && (txtPetWeight1.Text.Trim() != "") && (txtPetLength1.Text.Trim() != ""))
            {
                ViewState["RowID"] = "0";
                return Convert.ToInt32(ddlPetType1.SelectedValue) + 1;
            }
            else
                return 3;
        }
        else
            return 3;
    }
    #endregion 

    #region Drop Event
    /* This region include all pet type selected index change event */
    protected void ddlPetType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed1(ddlPetType1.SelectedValue);
    }
    protected void ddlPetType2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed2(ddlPetType2.SelectedValue);
    }
    protected void ddlPetType3_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed3(ddlPetType3.SelectedValue);
    }
    protected void ddlPetType4_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed4(ddlPetType4.SelectedValue);
    }
    protected void ddlPetType5_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed5(ddlPetType5.SelectedValue);
    }
    protected void ddlPetType6_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBreed6(ddlPetType6.SelectedValue);
    }
    #endregion 
}
