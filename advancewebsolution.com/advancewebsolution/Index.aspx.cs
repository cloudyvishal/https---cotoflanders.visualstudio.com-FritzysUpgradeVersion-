using System;
using System.Data;
using System.Web;
using System.Web.UI;
using advancewebtosolution.BO;
using advancewebtosolution.BO.CaptchaClass;
using System.Configuration;

public partial class Index : Page
{
    StoreFront objStoreFront = new StoreFront();

    /*
     Bind data function use to bind front end data that is cat and dog set for front end 
     */

    #region Declare
    public void ErrMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    public void SuccesfullMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }

    public void BindData()
    {
        if (Request.Cookies["IsLogin"] == null)
        {
            HttpCookie c = new HttpCookie("IsLogin", "0");
            c.Expires =  DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
            Response.Cookies.Add(c);
        }


        StoreFront ObjStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        if (Session["UserType"].ToString() == "4")
        {
            ds = ObjStoreFront.GetHomePageServices(4);
        }
        else
        {
            ds = ObjStoreFront.GetHomePageServices(Convert.ToInt32(Session["UserType"].ToString()));
        }

        if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "1"))
        {
            divCatService.InnerHtml = ds.Tables[0].Rows[0]["Description"].ToString();
            imgCatservice.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
            imgCatservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();
        }
        if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[1]["PetType"].ToString() == "2"))
        {
            divDogService.InnerHtml = ds.Tables[0].Rows[1]["Description"].ToString();
            imgDogservice.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[1]["ImageName"].ToString();
            imgDogservice.ToolTip = ds.Tables[0].Rows[1]["Description"].ToString();
        }
    }
    #endregion

    /*
        PlaceHolder is used to hole flash file as the file is set from Admin   = 
     *  This file will change as per user type 1(Cat) 2(Dog) 3(cat&Dog) 
     */

    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        {
            #region Check SignOut
            try

            {
                if (!string.IsNullOrEmpty(Request.QueryString.ToString()))
                {
                    string strReq = "";
                    strReq = Request.RawUrl;
                    strReq = strReq.Substring(strReq.IndexOf('?') + 1);
                    if (!strReq.Equals(""))
                    {
                        strReq = DecryptQueryString(strReq);
                        string[] arrMsgs = strReq.Split('&');
                        string[] arrIndMsg;
                        arrIndMsg = arrMsgs[0].Split('='); //Get the Signout
                        string strMsg = arrIndMsg[1].ToString().Trim();
                        if (strMsg == "SignOut")
                        {
                            clearHiistory();
                        }
                    }
                }
            }
            catch
            {
                clearHiistory();
            }
            #endregion
            #region Code
            if ((Request.Cookies["remUsername"] != null) && (Request.Cookies["remPassword"] != null) && (Request.Cookies["IsLogin"].Value.ToString() == "1"))// && (Session["IsLogin"] == null))
            {
                if ((Session["MemberName"] != null) && (Session["UserID"] != null)  && Session["UserName"] != null)
                {
                    string UserName = Request.Cookies["remUsername"].Value.ToString();
                    string Password = Request.Cookies["remPassword"].Value.ToString();

                    StoreFront objStoreFront = new StoreFront();
                    DataSet ds = new System.Data.DataSet();
                    ds = objStoreFront.GetLoginUser(UserName, Password);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["UserName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                        Session["MemberName"] = ds.Tables[0].Rows[0]["FullName"].ToString();
                        Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                        Session["IsLogin"] = "1";
                        Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                    }
                }
            }

            BindData();
            if (Session["MemberName"] != null)
            {
                divUserName.Attributes.Add("style", "Display:block");
                lblWelcome.Text = "Welcome - " + Session["MemberName"].ToString();

                DataSet ds = new DataSet();
                if (!(null == Session["UserName"]))
                {
                    ctlZipcode.Visible = false;
                    imgbtnMakePayment.Visible = true;
                }
                else
                {
                    divUserName.Attributes.Add("style", "Display:none");
                    ctlZipcode.Visible = true;
                    imgbtnMakePayment.Visible = false;
                }
            }
            #endregion
        }
    }
    protected void clearHiistory()
    {
        this.Response.Cache.SetExpires(DateTime.UtcNow.AddYears(-4));
        this.Response.Cache.SetValidUntilExpires(false);
        this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        this.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        this.Response.Cache.SetNoStore();
        this.Response.ExpiresAbsolute = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
        this.Response.Expires = 0;
        this.Response.CacheControl = "no-cache";
        this.Response.AppendHeader("Pragma", "no-cache");
        this.Response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate, post-check=0, pre-check=0");
        string sb;
        sb = "<script language=javascript>\n";
        sb += "window.onload = window.history.forward(0);";
        sb += "\n</script>";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "clientScript", sb);
    }
    protected void imgbtnMakePayment_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/PaymentPrepaid.aspx");
    }

    #region "Encryption"
    public string EncryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
    }
    #endregion

    #region "Decryption"
    private string DecryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
    }
    #endregion
}
