using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using System.Net.Mail;
using advancewebtosolution.BO;
using System.Text;

public partial class MB_appointment_registration : System.Web.UI.Page
{
    string PetTypeID = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ViewState["IsPet"] = "0";

                GetBreed1(PetTypeID);
                GetBreed2(PetTypeID);
                GetBreed3(PetTypeID);
                GetBreed4(PetTypeID);
                GetBreed5(PetTypeID);
                GetBreed6(PetTypeID);


                GetReferal();
                ViewState["RowID"] = 0;
                dvPet2.Visible = false;
                dvPet3.Visible = false;
                dvPet4.Visible = false;
                dvPet5.Visible = false;
                dvPet6.Visible = false;
                BindState();
            }
            catch (Exception ex) { throw ex; }
        }
    }
    #region Bind
    /* This region use to bind all data breed releated */
    public void GetBreed1(string PetType)
    {
        try
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
        catch (Exception ex) { throw ex; }
    }
    public void GetBreed2(string PetType)
    {
        try
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
        catch (Exception ex) { throw ex; }
    }
    public void GetBreed3(string PetType)
    {
        try
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
        catch (Exception ex) { throw ex; }
    }
    public void GetBreed4(string PetType)
    {
        try
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
        catch (Exception ex) { throw ex; }
    }
    public void GetBreed5(string PetType)
    {
        try
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
        catch (Exception ex) { throw ex; }
    }
    public void GetBreed6(string PetType)
    {
        try
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
        catch (Exception ex) { throw ex; }
    }


    public void GetReferal()
    {
        try
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
        catch (Exception ex) { throw ex; }
    }

    public void BindState()
    {
        try
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
            }
            ddlState.Items.Insert(0, lst);
        }
        catch (Exception ex) { throw ex; }
    }
    #endregion

    protected void imgAddmore_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["RowID"].ToString() == "0")
            {
                dvPet2.Visible = true;
                ViewState["RowID"] = "1";
                ViewState["IsPet"] = "1";
            }
            else if (ViewState["RowID"].ToString() == "1")
            {
                dvPet3.Visible = true;
                ViewState["RowID"] = "2";
            }
            else if (ViewState["RowID"].ToString() == "2")
            {
                dvPet4.Visible = true;
                ViewState["RowID"] = "3";
            }
            else if (ViewState["RowID"].ToString() == "3")
            {
                dvPet5.Visible = true;
                ViewState["RowID"] = "4";
            }
            else if (ViewState["RowID"].ToString() == "4")
            {
                dvPet6.Visible = true;
                ViewState["RowID"] = "5";

            }
            else if (ViewState["RowID"].ToString() == "5")
            {
                imgAddmore.Visible = false;
                lblMessageSix.Visible = true;
                lblMessageSix.Text = "You can add only six pets";
            }
        }
        catch (Exception ex) { throw ex; }
    }
    public int CheckStatus()
    {
        try
        {
            int c = 0;
            int d = 0;
            if ((dvPet1.Visible == true) && (ViewState["RowID"].ToString() != "0"))
            {
                if (ddlPetType1.SelectedValue == "0") c = c + 1;
                else d = d + 1;
            }
            if (dvPet2.Visible == true)
            {
                if (ddlPetType2.SelectedValue == "0") c = c + 1;
                else d = d + 1;
            }
            if (dvPet3.Visible == true)
            {
                if (ddlPetType3.SelectedValue == "0") c = c + 1;
                else d = d + 1;
            }
            if (dvPet4.Visible == true)
            {
                if (ddlPetType4.SelectedValue == "0") c = c + 1;
                else d = d + 1;
            }
            if (dvPet5.Visible == true)
            {
                if (ddlPetType5.SelectedValue == "0") c = c + 1;
                else d = d + 1;
            }
            if (dvPet6.Visible == true)
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
        catch (Exception ex) { throw ex; }
    }

    public int CheckPet()
    {
        try
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
        catch (Exception ex) { throw ex; }
    }
    protected void IdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            lblCaptchaError.Visible = false;
            lblCaptchaError.Text = "";
            StoreFrontUser ObjNewUser = new StoreFrontUser();
            int Status = 3;
            int Type = CheckPet();
            if (Type == 3)
                Status = CheckStatus();
            else
                Status = Type;
            Session["UserType"] = Status.ToString();
            Session["MemberName"] = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            int UserID = ObjNewUser.AddUserFull(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtStreet.Text.Trim(), txtCity.Text.Trim(), ddlState.SelectedItem.Text, txtZip.Text.Trim(), txtPhone.Text.Trim(), Convert.ToInt32(ddlReferralSource.SelectedValue), txtEmailReg.Text.Trim(), txtPasswordReg.Text.Trim(), txtAltMobile.Text.Trim(), txtAltContact.Text.Trim(), txtAltStreet.Text.Trim(), txtAltCity.Text.Trim(), ddlState1.SelectedItem.Text, txtAltZip.Text.Trim(), txtAltPhone.Text.Trim(), txtGroomer.Text.Trim(), Status);
            if (UserID != 0)
            {
                if (dvPet1.Visible == true)
                {
                    if ((txtPetName1.Text.Trim() != "") && (ddlBreed1.SelectedIndex != 0) && (txtPetDOB1.Text.Trim() != "") && (txtPetWeight1.Text.Trim() != "") && (txtPetLength1.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType1.SelectedValue), txtPetName1.Text.Trim(), Convert.ToInt32(ddlBreed1.SelectedValue), Convert.ToInt32(txtPetDOB1.Text.Trim()), Convert.ToDecimal(txtPetWeight1.Text.Trim()), Convert.ToDecimal(txtPetLength1.Text.Trim()));
                }
                if (dvPet1.Visible == true)
                {
                    if ((txtPetName2.Text.Trim() != "") && (ddlBreed2.SelectedIndex != 0) && (txtDOB2.Text.Trim() != "") && (txtPetWeight2.Text.Trim() != "") && (txtPetLength2.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType2.SelectedValue), txtPetName2.Text.Trim(), Convert.ToInt32(ddlBreed2.SelectedValue), Convert.ToInt32(txtDOB2.Text.Trim()), Convert.ToDecimal(txtPetWeight2.Text.Trim()), Convert.ToDecimal(txtPetLength2.Text.Trim()));
                }
                if (dvPet1.Visible == true)
                {
                    if ((txtPetName3.Text.Trim() != "") && (ddlBreed3.SelectedIndex != 0) && (txtDOB3.Text.Trim() != "") && (txtPetWeight3.Text.Trim() != "") && (txtPetLength3.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType3.SelectedValue), txtPetName3.Text.Trim(), Convert.ToInt32(ddlBreed3.SelectedValue), Convert.ToInt32(txtDOB3.Text.Trim()), Convert.ToDecimal(txtPetWeight3.Text.Trim()), Convert.ToDecimal(txtPetLength3.Text.Trim()));
                }
                if (dvPet1.Visible == true)
                {
                    if ((txtPetName4.Text.Trim() != "") && (ddlBreed4.SelectedIndex != 0) && (txtDOB4.Text.Trim() != "") && (txtPetWeight4.Text.Trim() != "") && (txtPetLength4.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType4.SelectedValue), txtPetName4.Text.Trim(), Convert.ToInt32(ddlBreed4.SelectedValue), Convert.ToInt32(txtDOB4.Text.Trim()), Convert.ToDecimal(txtPetWeight4.Text.Trim()), Convert.ToDecimal(txtPetLength4.Text.Trim()));
                }
                if (dvPet1.Visible == true)
                {
                    if ((txtPetName5.Text.Trim() != "") && (ddlBreed5.SelectedIndex != 0) && (txtDOB5.Text.Trim() != "") && (txtPetWeight5.Text.Trim() != "") && (txtPetLength5.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType5.SelectedValue), txtPetName5.Text.Trim(), Convert.ToInt32(ddlBreed5.SelectedValue), Convert.ToInt32(txtDOB5.Text.Trim()), Convert.ToDecimal(txtPetWeight5.Text.Trim()), Convert.ToDecimal(txtPetLength5.Text.Trim()));
                }
                if (dvPet1.Visible == true)
                {
                    if ((txtPetName6.Text.Trim() != "") && (ddlBreed6.SelectedIndex != 0) && (txtDOB6.Text.Trim() != "") && (txtPetWeight6.Text.Trim() != "") && (txtPetLength6.Text.Trim() != ""))
                        ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType6.SelectedValue), txtPetName6.Text.Trim(), Convert.ToInt32(ddlBreed6.SelectedValue), Convert.ToInt32(txtDOB6.Text.Trim()), Convert.ToDecimal(txtPetWeight6.Text.Trim()), Convert.ToDecimal(txtPetLength6.Text.Trim()));
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
                Response.Redirect("MB_index.aspx");
            }
            else
            {
                lblCaptchaError.Visible = true;
                lblCaptchaError.Text = "We’re sorry, this username already exists.";
            }
        }
        catch (Exception ex) { throw ex; }
    }


    #region Dropdown event

    /* This region include all pet type selected index change event */
    protected void ddlPetType1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetBreed1(ddlPetType1.SelectedValue);
        }
        catch (Exception ex) { throw ex; }
    }
    protected void ddlPetType2_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetBreed2(ddlPetType2.SelectedValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlPetType3_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetBreed3(ddlPetType3.SelectedValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlPetType4_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetBreed4(ddlPetType4.SelectedValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlPetType5_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetBreed5(ddlPetType5.SelectedValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlPetType6_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetBreed6(ddlPetType6.SelectedValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        #endregion
    }
}
