using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CaptchaDotNet2.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using System.Text;
using advancewebtosolution.BO;

public partial class MB_Registration : System.Web.UI.Page
{
    string PetTypeID = "0";
    /*
        Page Load 
     *   BindState - function use to bind all states from Us.
     *   GetBreed - function use to set breed in all dropdown list - six dropdown.
     *   GetReferal is used to set referral source from database managed by admin 
     *   Bind User =-  use to bind all information about user Personal info, Pet info
     *   BindPet - function use to bind all information releated to pet 
     *   litContent - use to set registration header from RegistrationUpdate.htm which is manage by admin
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
            int n = txtPhone.Text.Length;
            int UserID = ObjNewUser.AddUserBasic(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtStreet.Text.Trim(), txtCity.Text.Trim(), ddlState.SelectedValue, txtZip.Text.Trim(), txtPhone.Text.Trim(), Convert.ToInt32(ddlReferralSource.SelectedValue), txtEmailReg.Text.Trim(), txtPasswordReg.Text.Trim(), Status);
            if (UserID != 0)
            {
                if ((dvPet1.Visible == true) && (txtPetName1.Text.Trim() != "") && (ddlBreed1.SelectedIndex != 0) && (txtPetDOB1.Text.Trim() != "") && (txtPetWeight1.Text.Trim() != "") && (txtPetLength1.Text.Trim() != ""))
                {
                    ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType1.SelectedValue), txtPetName1.Text.Trim(), Convert.ToInt32(ddlBreed1.SelectedValue), Convert.ToInt32(txtPetDOB1.Text.Trim()), Convert.ToDecimal(txtPetWeight1.Text.Trim()), Convert.ToDecimal(txtPetLength1.Text.Trim()));
                }
                if ((dvPet2.Visible == true) && (txtPetName2.Text.Trim() != "") && (ddlBreed2.SelectedIndex != 0) && (txtDOB2.Text.Trim() != "") && (txtPetWeight2.Text.Trim() != "") && (txtPetLength2.Text.Trim() != ""))
                {
                    ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType2.SelectedValue), txtPetName2.Text.Trim(), Convert.ToInt32(ddlBreed2.SelectedValue), Convert.ToInt32(txtDOB2.Text.Trim()), Convert.ToDecimal(txtPetWeight2.Text.Trim()), Convert.ToDecimal(txtPetLength2.Text.Trim()));
                }
                if ((dvPet3.Visible == true) && (txtPetName3.Text.Trim() != "") && (ddlBreed3.SelectedIndex != 0) && (txtDOB3.Text.Trim() != "") && (txtPetWeight3.Text.Trim() != "") && (txtPetLength3.Text.Trim() != ""))
                {
                    ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType3.SelectedValue), txtPetName3.Text.Trim(), Convert.ToInt32(ddlBreed3.SelectedValue), Convert.ToInt32(txtDOB3.Text.Trim()), Convert.ToDecimal(txtPetWeight3.Text.Trim()), Convert.ToDecimal(txtPetLength3.Text.Trim()));
                }
                if ((dvPet4.Visible == true) && (txtPetName4.Text.Trim() != "") && (ddlBreed4.SelectedIndex != 0) && (txtDOB4.Text.Trim() != "") && (txtPetWeight4.Text.Trim() != "") && (txtPetLength4.Text.Trim() != ""))
                {
                    ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType4.SelectedValue), txtPetName4.Text.Trim(), Convert.ToInt32(ddlBreed4.SelectedValue), Convert.ToInt32(txtDOB4.Text.Trim()), Convert.ToDecimal(txtPetWeight4.Text.Trim()), Convert.ToDecimal(txtPetLength4.Text.Trim()));
                }
                if ((dvPet5.Visible == true) && (txtPetName5.Text.Trim() != "") && (ddlBreed5.SelectedIndex != 0) && (txtDOB5.Text.Trim() != "") && (txtPetWeight5.Text.Trim() != "") && (txtPetLength5.Text.Trim() != ""))
                {
                    ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType5.SelectedValue), txtPetName5.Text.Trim(), Convert.ToInt32(ddlBreed5.SelectedValue), Convert.ToInt32(txtDOB5.Text.Trim()), Convert.ToDecimal(txtPetWeight5.Text.Trim()), Convert.ToDecimal(txtPetLength5.Text.Trim()));
                }
                if ((dvPet6.Visible == true) && (txtPetName6.Text.Trim() != "") && (ddlBreed6.SelectedIndex != 0) && (txtDOB6.Text.Trim() != "") && (txtPetWeight6.Text.Trim() != "") && (txtPetLength6.Text.Trim() != ""))
                {
                    ObjNewUser.AddPet(UserID, Convert.ToInt32(ddlPetType6.SelectedValue), txtPetName6.Text.Trim(), Convert.ToInt32(ddlBreed6.SelectedValue), Convert.ToInt32(txtDOB6.Text.Trim()), Convert.ToDecimal(txtPetWeight6.Text.Trim()), Convert.ToDecimal(txtPetLength6.Text.Trim()));
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
                Response.Redirect("~/mobileweb/MB_index.aspx");
            }
            else
            {
                lblCaptchaError.Visible = true;
                lblCaptchaError.Text = "We’re sorry, this username already exists.";
            }
        }
        catch (Exception ex) { throw ex; }
    }

    #region Delete
    protected void imgDelete1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            dvPet1.Visible = false;
            if (Convert.ToInt32(PetID1.Text.Trim()) > 0)
            {
                StoreFrontUser ObjDelPet = new StoreFrontUser();
                ObjDelPet.DeletePet(Convert.ToInt32(PetID1.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
                string Body = "Pet = " + ddlPetType1.SelectedItem.Text + "<br>Pet Name = " + txtPetName1.Text.Trim() + "<br> Breed Name = " + ddlBreed1.SelectedItem.Text +
                              "<br>Years = " + txtPetDOB1.Text.Trim() + "<br>Weight = " + txtPetWeight1.Text.Trim() + "<br> Fur Length = " + txtPetLength1.Text.Trim() + "<br><br><br>";
                PetDeleteMail(Body);
            }
        }
        catch (Exception ex) { throw ex; }
    }
    protected void imgDelete2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            dvPet2.Visible = false;
            if (Convert.ToInt32(PetID2.Text.Trim()) > 0)
            {
                StoreFrontUser ObjDelPet = new StoreFrontUser();
                ObjDelPet.DeletePet(Convert.ToInt32(PetID2.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
                int Status = GetUpdatedPet();
                string Body = "Pet = " + ddlPetType2.SelectedItem.Text + "<br>Pet Name = " + txtPetName2.Text.Trim() + "<br> Breed Name = " + ddlBreed2.SelectedItem.Text +
                              "<br>Years = " + txtDOB2.Text.Trim() + "<br>Weight = " + txtPetWeight2.Text.Trim() + "<br> Fur Length = " + txtPetLength2.Text.Trim() + "<br><br><br>";
                PetDeleteMail(Body);
            }
        }
        catch (Exception ex) { throw ex; }
    }
    protected void imgDelete3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            dvPet3.Visible = false;
            if (Convert.ToInt32(PetID3.Text.Trim()) > 0)
            {
                StoreFrontUser ObjDelPet = new StoreFrontUser();
                int Status = GetUpdatedPet();
                ObjDelPet.DeletePet(Convert.ToInt32(PetID3.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
                string Body = "Pet = " + ddlPetType3.SelectedItem.Text + "<br>Pet Name = " + txtPetName3.Text.Trim() + "<br> Breed Name = " + ddlBreed3.SelectedItem.Text +
                              "<br>Years = " + txtDOB3.Text.Trim() + "<br>Weight = " + txtPetWeight3.Text.Trim() + "<br> Fur Length = " + txtPetLength3.Text.Trim() + "<br><br><br>";
                PetDeleteMail(Body);
            }
        }
        catch (Exception ex) { throw ex; }
    }
    protected void imgDelete4_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            dvPet4.Visible = false;
            if (Convert.ToInt32(PetID4.Text.Trim()) > 0)
            {
                StoreFrontUser ObjDelPet = new StoreFrontUser();
                ObjDelPet.DeletePet(Convert.ToInt32(PetID4.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
                string Body = "Pet = " + ddlPetType4.SelectedItem.Text + "<br>Pet Name = " + txtPetName4.Text.Trim() + "<br> Breed Name = " + ddlBreed4.SelectedItem.Text +
                              "<br>Years = " + txtDOB4.Text.Trim() + "<br>Weight = " + txtPetWeight4.Text.Trim() + "<br> Fur Length = " + txtPetLength4.Text.Trim() + "<br><br><br>";
                PetDeleteMail(Body);
            }
        }
        catch (Exception ex) { throw ex; }
    }
    protected void imgDelete5_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            dvPet5.Visible = false;
            if (Convert.ToInt32(PetID5.Text.Trim()) > 0)
            {
                StoreFrontUser ObjDelPet = new StoreFrontUser();
                ObjDelPet.DeletePet(Convert.ToInt32(PetID5.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
                string Body = "Pet = " + ddlPetType5.SelectedItem.Text + "<br>Pet Name = " + txtPetName5.Text.Trim() + "<br> Breed Name = " + ddlBreed5.SelectedItem.Text +
                              "<br>Years = " + txtDOB5.Text.Trim() + "<br>Weight = " + txtPetWeight5.Text.Trim() + "<br> Fur Length = " + txtPetLength5.Text.Trim() + "<br><br><br>";
                PetDeleteMail(Body);
            }
        }
        catch (Exception ex) { throw ex; }
    }
    protected void imgDelete6_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            dvPet6.Visible = false;
            if (Convert.ToInt32(PetID6.Text.Trim()) > 0)
            {
                StoreFrontUser ObjDelPet = new StoreFrontUser();
                ObjDelPet.DeletePet(Convert.ToInt32(PetID6.Text.Trim()), GetUpdatedPet(), Convert.ToInt32(Session["UserID"].ToString()));
                string Body = "Pet = " + ddlPetType6.SelectedItem.Text + "<br>Pet Name = " + txtPetName6.Text.Trim() + "<br> Breed Name = " + ddlBreed6.SelectedItem.Text +
                              "<br>Years = " + txtDOB6.Text.Trim() + "<br>Weight = " + txtPetWeight6.Text.Trim() + "<br> Fur Length = " + txtPetLength6.Text.Trim() + "<br><br><br>";
                PetDeleteMail(Body);
            }
        }
        catch (Exception ex) { throw ex; }
    }
    #endregion
    #region function
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

    public void PetAddMail(string body)
    {
        try
        {
            string Mailbody = ContentManager.GetStaticeContentEmail("AddPet.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- Update -->", body);
            Mailbody = Mailbody.Replace("<!-- UserName -->", txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim());
            SendMail ObjMail = new SendMail();
            ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), Convert.ToString(Session["MemberName"]) + " User add pet", Mailbody);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void PetDeleteMail(string body)
    {
        try
        {
            string Mailbody = ContentManager.GetStaticeContentEmail("DeletePet.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- Update -->", body);
            Mailbody = Mailbody.Replace("<!-- UserName -->", txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim());
            SendMail ObjMail = new SendMail();
            ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), Convert.ToString(Session["MemberName"]) + " User delete pet", Mailbody);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void PetUpdateMail(string body)
    {
        try
        {
            string Mailbody = ContentManager.GetStaticeContentEmail("PetUpdate.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- Update -->", body);
            Mailbody = Mailbody.Replace("<!-- UserName -->", txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim());
            SendMail ObjMail = new SendMail();
            ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), Convert.ToString(Session["MemberName"]) + " User pet updated", Mailbody);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateUserInfoMail()
    {
        try
        {
            string str = string.Empty;
            DataTable dt = (DataTable)ViewState["UserInformation"];
            if (txtFirstName.Text.Trim() != dt.Rows[0]["FirstName"].ToString())
                str = str + "FirstName = " + txtFirstName.Text.Trim() + "<br>";
            if (txtLastName.Text.Trim() != dt.Rows[0]["LastName"].ToString())
                str = str + "LastName = " + txtLastName.Text.Trim() + "<br>";
            if ((txtStreet.Text.Trim() != dt.Rows[0]["Street"].ToString()) || (txtCity.Text.Trim() != dt.Rows[0]["City"].ToString()) || (ddlState.SelectedValue != dt.Rows[0]["State"].ToString()) || (txtZip.Text.Trim() != dt.Rows[0]["Zip"].ToString()))
            {
                str = str + "Address = " + txtStreet.Text.Trim() + "," +
                    txtCity.Text.Trim() + "," +
                    ddlState.SelectedValue + "," +
                    txtZip.Text.Trim() + "<br>";
            }
            if (txtPhone.Text.Trim() != dt.Rows[0]["Phone"].ToString())
                str = str + "Phone = " + txtPhone.Text.Trim() + "<br>";
            if (txtAltMobile.Text.Trim() != dt.Rows[0]["AltMobile"].ToString())
                str = str + "Alternate Mobile = " + txtAltMobile.Text.Trim() + "<br>";



            if (ddlReferralSource.SelectedValue != dt.Rows[0]["ReferralID"].ToString())
                str = str + "Referral Source = " + ddlReferralSource.SelectedValue + "<br>";

            if (str != string.Empty)
            {
                string Mailbody = ContentManager.GetStaticeContentEmail("UpdateUser.htm").Replace("~", "#");
                Mailbody = Mailbody.Replace("<!-- Update -->", str);
                Mailbody = Mailbody.Replace("<!-- UserName -->", dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString());
                SendMail ObjMail = new SendMail();
                ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), Convert.ToString(Session["MemberName"]) + " Update user profile", Mailbody);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string IsPetUpdate(int count)
    {
        try
        {
            string str = string.Empty;
            DataTable dt = (DataTable)ViewState["Pet"];
            switch (count)
            {
                case 1:
                    if (ddlPetType1.SelectedValue != dt.Rows[0]["PetType"].ToString() || txtPetName1.Text.Trim() != dt.Rows[0]["PetName"].ToString() || ddlBreed1.SelectedValue != dt.Rows[0]["BreedID"].ToString() || txtPetDOB1.Text.Trim() != dt.Rows[0]["Years"].ToString() || txtPetWeight1.Text.Trim() != dt.Rows[0]["Weight"].ToString() || txtPetLength1.Text.Trim() != dt.Rows[0]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType1.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName1.Text + "<br>" +
                        "Breed Name = " + ddlBreed1.SelectedItem.Text + "<br>" +
                        "Year = " + txtPetDOB1.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight1.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength1.Text.Trim();
                    }
                    break;
                case 2:
                    if (ddlPetType2.SelectedValue != dt.Rows[1]["PetType"].ToString() || txtPetName2.Text.Trim() != dt.Rows[1]["PetName"].ToString() || ddlBreed2.SelectedValue != dt.Rows[1]["BreedID"].ToString() || txtDOB2.Text.Trim() != dt.Rows[1]["Years"].ToString() || txtPetWeight2.Text.Trim() != dt.Rows[1]["Weight"].ToString() || txtPetLength2.Text.Trim() != dt.Rows[1]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType2.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName2.Text + "<br>" +
                        "Breed Name = " + ddlBreed2.SelectedItem.Text + "<br>" +
                        "Year = " + txtDOB2.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight2.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength2.Text.Trim();
                    }
                    break;
                case 3:
                    if (ddlPetType3.SelectedValue != dt.Rows[2]["PetType"].ToString() || txtPetName3.Text.Trim() != dt.Rows[2]["PetName"].ToString() || ddlBreed3.SelectedValue != dt.Rows[2]["BreedID"].ToString() || txtDOB3.Text.Trim() != dt.Rows[2]["Years"].ToString() || txtPetWeight3.Text.Trim() != dt.Rows[2]["Weight"].ToString() || txtPetLength3.Text.Trim() != dt.Rows[2]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType3.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName3.Text + "<br>" +
                        "Breed Name = " + ddlBreed3.SelectedItem.Text + "<br>" +
                        "Year = " + txtDOB3.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight3.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength3.Text.Trim();
                    }
                    break;
                case 4:
                    if (ddlPetType4.SelectedValue != dt.Rows[3]["PetType"].ToString() || txtPetName4.Text.Trim() != dt.Rows[3]["PetName"].ToString() || ddlBreed4.SelectedValue != dt.Rows[3]["BreedID"].ToString() || txtDOB4.Text.Trim() != dt.Rows[3]["Years"].ToString() || txtPetWeight4.Text.Trim() != dt.Rows[3]["Weight"].ToString() || txtPetLength4.Text.Trim() != dt.Rows[3]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType4.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName4.Text + "<br>" +
                        "Breed Name = " + ddlBreed4.SelectedItem.Text + "<br>" +
                        "Year = " + txtDOB4.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight4.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength4.Text.Trim();
                    }
                    break;
                case 5:
                    if (ddlPetType5.SelectedValue != dt.Rows[4]["PetType"].ToString() || txtPetName5.Text.Trim() != dt.Rows[4]["PetName"].ToString() || ddlBreed5.SelectedValue != dt.Rows[4]["BreedID"].ToString() || txtDOB5.Text.Trim() != dt.Rows[4]["Years"].ToString() || txtPetWeight5.Text.Trim() != dt.Rows[4]["Weight"].ToString() || txtPetLength5.Text.Trim() != dt.Rows[4]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType5.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName5.Text + "<br>" +
                        "Breed Name = " + ddlBreed5.SelectedItem.Text + "<br>" +
                        "Year = " + txtDOB5.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight5.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength5.Text.Trim();
                    }
                    break;
                case 6:
                    if (ddlPetType6.SelectedValue != dt.Rows[5]["PetType"].ToString() || txtPetName6.Text.Trim() != dt.Rows[5]["PetName"].ToString() || ddlBreed6.SelectedValue != dt.Rows[5]["BreedID"].ToString() || txtDOB6.Text.Trim() != dt.Rows[5]["Years"].ToString() || txtPetWeight6.Text.Trim() != dt.Rows[5]["Weight"].ToString() || txtPetLength6.Text.Trim() != dt.Rows[5]["Length"].ToString())
                    {
                        str = "Pet = " + ddlPetType6.SelectedItem.Text + "<br>" +
                        "Pet Name = " + txtPetName6.Text + "<br>" +
                        "Breed Name = " + ddlBreed6.SelectedItem.Text + "<br>" +
                        "Year = " + txtDOB6.Text.Trim() + "<br>" +
                        "Weight = " + txtPetWeight6.Text.Trim() + "<br>" +
                        "Length = " + txtPetLength6.Text.Trim();
                    }
                    break;
            }
            return str;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion 
    #region Dropdown event

    /* This region include all pet type selected index change event */
    protected void ddlPetType1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetBreed1(ddlPetType1.SelectedValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
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
    }
    #endregion 
}
