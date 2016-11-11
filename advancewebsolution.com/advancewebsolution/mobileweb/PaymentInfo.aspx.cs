using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Security.Cryptography;
using System.Web.Services.Protocols;
using CyberSource.Client;
using advancewebtosolution.BO;
using advancewebtosolution.BO.CaptchaClass;
using System.ServiceModel.Security;
using CyberSource.Clients.SoapServiceReference;
using CyberSource.Clients;

public partial class mobileweb_PaymentInfo : System.Web.UI.Page
{
    #region Vari
    StoreFront objStoreFront = new StoreFront();
    decimal RevenueCost, TipCost, PriorRevenueCost, totalAmount;
    private ReplyMessage reply;
    CyberSource.Clients.Configuration config;
    int userID;
    int AppointmentId;
    string PayStatus = string.Empty;
    string StartTime = string.Empty;
    string AppointmentDate = string.Empty;
    int GroomerAppId;

    private string SortExpression
    {
        get
        {
            if (ViewState["SortExpression"] != null)
                return (string)ViewState["SortExpression"];
            else
                return string.Empty;
        }
        set
        {
            if (ViewState["SortExpression"] == null)
                ViewState.Add("SortExpression", value);
            else
                ViewState["SortExpression"] = value;
        }
    }

    private string SortDirection
    {
        get
        {
            if (ViewState["SortDirection"] != null)
                return (string)ViewState["SortDirection"];
            else
                return "ASC";
        }
        set
        {
            if (ViewState["SortDirection"] == null)
                ViewState.Add("SortDirection", value);
            else
                ViewState["SortDirection"] = value;
        }
    }
    #endregion Vari

    #region "Encryption"
    public string EncryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
    }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] == null | Session["MemberName"] == null | Session["UserID"] == null)
                Response.Redirect(Session["MobilePath"] + "default.aspx");
            if (!Page.IsPostBack)
            {
                if (!(null == Session["UserName"]) && !(null == Session["UserID"]))
                {
                    userID = Convert.ToInt32(Session["UserID"].ToString());
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
                            string payAppID = "", type = "";
                            arrIndMsg = arrMsgs[0].Split('='); //Get the Appointmentid
                            payAppID = arrIndMsg[1].ToString().Trim();
                            try
                            {
                                AppointmentId = Convert.ToInt32(payAppID.ToString());
                                arrIndMsg = arrMsgs[1].Split('='); //Get the Type
                                type = arrIndMsg[1].ToString().Trim();
                                Session["PaymentAppointmentID"] = payAppID;
                                #region Find Appointment  Information if user coming by query string
                                StoreFrontUser Obj = new StoreFrontUser();
                                DataSet ds1 = new DataSet();
                                ds1 = Obj.GetPaymentAppointmentDetail(AppointmentId);
                                BindToHiddenFieldAppointmentInformation(ds1);

                                ds1 = Obj.GetPaymentAppointmentByGrommerDetail(AppointmentId);
                                BindPayMentFieldsForPayment(ds1);

                                lblFutureAppointmentLabel.Visible = false;
                                GrdFutureApp.Visible = false;
                                #endregion Find Appointment  Information if user coming by query string
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    else
                    {
                        BindAppointments();
                    }
                    StoreFrontUser ObjUser = new StoreFrontUser();
                    DataSet ds = new DataSet();
                    ds = ObjUser.GetUser(Convert.ToInt32(Session["UserID"].ToString()));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UserInformation"] = (DataTable)ds.Tables[0];
                        ViewState["UserMail"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                        billTo_firstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                        billTo_lastname.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                        billTo_street1.Text = ds.Tables[0].Rows[0]["Street"].ToString();
                        billTo_state.Text = ds.Tables[0].Rows[0]["State"].ToString();
                        billTo_city.Text = ds.Tables[0].Rows[0]["City"].ToString();
                        billTo_postalCode.Text = ds.Tables[0].Rows[0]["Zip"].ToString();
                        txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                        billTo_email.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                        billTo_country.Text = "USA";
                    }
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
                Session["Paycount"] = 1;
                Session["IsExecuted"] = "0";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string DecryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
    }

    #endregion Page Load

    #region Futute  Payment GridView
    protected void GrdFutureApp_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = GrdFutureApp.BottomPagerRow;

        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(GrdFutureApp.PageIndex + 1);
        int[] page = new int[7];
        page[0] = GrdFutureApp.PageIndex - 2;
        page[1] = GrdFutureApp.PageIndex - 1;
        page[2] = GrdFutureApp.PageIndex;
        page[3] = GrdFutureApp.PageIndex + 1;
        page[4] = GrdFutureApp.PageIndex + 2;
        page[5] = GrdFutureApp.PageIndex + 3;
        page[6] = GrdFutureApp.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > GrdFutureApp.PageCount)
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
        if (GrdFutureApp.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;
        }
        if (GrdFutureApp.PageIndex == GrdFutureApp.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;
        }
        if (GrdFutureApp.PageIndex > GrdFutureApp.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (GrdFutureApp.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }

    protected void GrdFutureApp_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (SortExpression != e.SortExpression)
        {
            SortExpression = e.SortExpression;
            SortDirection = "ASC";
        }
        else
        {
            if (SortDirection == "ASC")
            {
                SortDirection = "DESC";
            }
            else
            {
                SortDirection = "ASC";
            }
        }
        GrdFutureApp.PageIndex = 0;
        BindAppointments();
    }

    protected void GrdFutureApp_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
        }
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
        GrdFutureApp.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        BindAppointments();
    }

    protected void GrdFutureApp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdFutureApp.PageIndex = e.NewPageIndex;
        BindAppointments();
    }
    #endregion Futute  Payment GridView    

    #region Bind Futute  Payment GridView if (AppId > 0 && PayStatus == "Pending")
    public void BindAppointments()
    {
        try
        {
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            DataView dv = new DataView();
            Groomer obj = new Groomer();
            ds = obj.BindUserAppointmentForPayment(Convert.ToInt32(Session["UserID"].ToString()), Session["UserName"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdFutureApp.Visible = true;
                dt1 = ds.Tables[0];
                dv = dt1.DefaultView;
                GrdFutureApp.DataSource = dv;
                GrdFutureApp.DataBind();
                txtRevenueCost.Enabled = true;
                txtRevenueCost.Text = string.Empty;
                txtPriorRevenue.Enabled = true;
                txtPriorRevenue.Text = string.Empty;
                txtTipAmt.Enabled = true;
                txtTipAmt.Text = string.Empty;
                lblTotalAmt.Text = string.Empty;
            }
            else
            {
                lblfutureinfo.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion Bind Futute  Payment GridView

    #region Payment 
    protected string GetOrderRefNumber()
    {
        string OrdNumber = "";
        try
        {
            OrdNumber = (new Random()).Next().ToString();
            bool IsOrdnoPresent = objStoreFront.CheckOrderRefNo(OrdNumber);

            if (IsOrdnoPresent.Equals(true))
            {
                OrdNumber = GetOrderRefNumber();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return OrdNumber;
    }

    protected void configure()
    {
        config = new CyberSource.Clients.Configuration();
        config.KeyFilename = ConfigurationManager.AppSettings["cybs.keyFilename"].ToString();
        config.KeysDirectory = Server.MapPath("~") + "Keys";
        config.MerchantID = ConfigurationManager.AppSettings["cybs.merchantID"].ToString();
        config.ServerURL = ConfigurationManager.AppSettings["cybs.serverURL"].ToString();
    }

    private void Authorize(ref CreditCard card1)
    {
        try
        {
            RequestMessage request = new RequestMessage();
            BillTo billTo = new BillTo();
            configure();

            // add general fields
            if (!(null == Session["OrderNumber"]))
            {
                request.merchantReferenceCode = (string)Session["OrderNumber"];
            }

            request.ccAuthService = new CCAuthService();
            request.ccAuthService.run = "true";

            // add purchasing info
            PurchaseTotals purchaseTotals = new PurchaseTotals();
            purchaseTotals.currency = "USD";
            request.purchaseTotals = purchaseTotals;

            // add shopper info
            Shopper shopper = (Shopper)Session["Shopper"];
            Global1.AddShopperFields(ref billTo, shopper);
            request.billTo = billTo;

            //add item info
            Items items = (Items)Session["ShoppingCart"];
            Global1.AddItemFields(ref request, items);

            // add card info
            Card card = new Card();
            card.accountNumber = card1.accountNumber;
            card.expirationMonth = card1.expirationMonth;
            card.expirationYear = card1.expirationYear;
            card.cvNumber = card1.cvNumber;
            request.card = card;

            // send request now
            reply = SoapClient.RunTransaction(config, request);
            // process the transaction as per response.
            HandleReply();
        }
        catch (SoapHeaderException she)
        {
            Session["Exception"] = she;
            lblerrormsg.Text = Session["Exception"].ToString();
            lblerrormsg.Visible = true;
        }
        catch (CryptographicException ce)
        {
            Session["Exception"] = ce;
            lblerrormsg.Text = Session["Exception"].ToString();
            lblerrormsg.Visible = true;
        }
        catch (MessageSecurityException mse)
        {
            Session["Exception"] = mse;
            lblerrormsg.Text = Session["Exception"].ToString();
            lblerrormsg.Visible = true;
        }
        catch (WebException we)
        {
            Session["Error"] = we;
            lblerrormsg.Text = Session["Exception"].ToString();
            lblerrormsg.Visible = true;
        }
        catch (Exception e)
        {
            Session["Error"] = e;
            lblerrormsg.Text = Session["Exception"].ToString();
            lblerrormsg.Visible = true;
        }
    }

    private static string EnumerateValues(string[] array)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (string val in array)
        {
            sb.Append(val + "\n");
        }
        return (sb.ToString());
    }

    private void HandleReply()
    {
        try
        {
            int reasonCode;
            string ResponseID, Responsemsg = "", billtxnrefno = "", authCode = "", msg;
            bool IsResponsefound = true;
            reasonCode = int.Parse(reply.reasonCode);
            #region switch
            switch (reasonCode)
            {
                #region Success
                case 100:
                    IsResponsefound = false;
                    ResponseID = reply.requestID;
                    string REQUEST_TOKEN = reply.requestToken;
                    if (reply.invalidField != null)
                        Responsemsg = EnumerateValues(reply.invalidField);
                    if (reply.ccAuthReply.authorizationCode != null)
                        authCode = reply.ccAuthReply.authorizationCode;
                    #region Success Redirect if Query string
                    if (!(String.IsNullOrEmpty(Request.QueryString.ToString())))
                    {
                        objStoreFront.UpdatePGResponseDetails(reasonCode.ToString(), "0", ResponseID, Session["PayID"].ToString(), Responsemsg, billtxnrefno, authCode, REQUEST_TOKEN);
                        RevenueCost = (txtRevenueCost.Text == "") ? 0 : Convert.ToDecimal(txtRevenueCost.Text);
                        PriorRevenueCost = (txtPriorRevenue.Text == "") ? 0 : Convert.ToDecimal(txtPriorRevenue.Text);
                        TipCost = (txtTipAmt.Text == "") ? 0 : Convert.ToDecimal(txtTipAmt.Text);
                        objStoreFront.InsertAppointmentPrePayment(Convert.ToInt32(Session["UserID"]), RevenueCost, PriorRevenueCost, TipCost, "Success Payment ", Convert.ToInt32(Session["PayID"]), Convert.ToInt32(GroomerAppId), billTo_firstName.Text, billTo_lastname.Text);
                        objStoreFront.UpdatePrePayStatus(GroomerAppId, "PrePaid");
                        PaymentDoneMessage();
                        lblsmsg.Visible = true;
                        btnSubmitInfo.Enabled = false;
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Payment", "paymentSuccess();", true);
                        Session.Remove("PaymentAppointmentID");
                        ClearCreditCardDetails();
                        Response.Redirect("~/mobileweb/MB_MyAccount.aspx?" + EncryptQueryString(string.Format("msg ={0}&Revenue ={1}&AdditionalRevenue={2}&Tip={3}", "S", RevenueCost, PriorRevenueCost, TipCost)), false);
                    }
                    #endregion Success Redirect if Query string

                    #region Success Redirect if No Query string
                    else
                    {
                        objStoreFront.UpdatePGResponseDetails(reasonCode.ToString(), "0", ResponseID, Session["PayID"].ToString(), Responsemsg, billtxnrefno, authCode, REQUEST_TOKEN);
                        objStoreFront.InsertAppointmentPrePayment(Convert.ToInt32(Session["UserID"]), RevenueCost, PriorRevenueCost, TipCost, "Success Payment ", Convert.ToInt32(Session["PayID"]), Convert.ToInt32(GroomerAppId), billTo_firstName.Text, billTo_lastname.Text);
                        objStoreFront.UpdatePrePayStatus(GroomerAppId, "PrePaid");
                        PaymentDoneMessage();
                        lblsmsg.Visible = true;
                        btnSubmitInfo.Enabled = false;
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Payment", "paymentSuccess();", true);
                        Session.Remove("PaymentAppointmentID");
                        ClearCreditCardDetails();
                        Response.Redirect("~/mobileweb/MB_MyAccount.aspx?" + EncryptQueryString(string.Format("msg ={0}&Revenue ={1}&AdditionalRevenue={2}&Tip={3}", "S", RevenueCost, PriorRevenueCost, TipCost)), false);
                    }
                    #endregion Success Redirect if No Query string
                    break;
                #endregion Success

                #region Fail
                case 101:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "The request is missing one or more fields.";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 102:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "One or more fields in the request contains invalid data";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 104:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "The merchantReferenceCode sent with this authorization request matches the merchantReferenceCode of another authorization request that you sent in the last 15 minutes.";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 110:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Partial amount was approved";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 150:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "General system failure.";
                    msg = String.Format("Your payment transaction has been UnSuccessful");

                    break;
                case 151:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "The request was received but there was a server timeout. This error does not include timeouts between the client and the server";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 152:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "The request was received, but a service did not finish running in time";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 200:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "The authorization request was approved by the issuing bank but declined by CyberSource because it did not pass the Address Verification Service (AVS) check.";
                    msg = String.Format("Your payment transaction has been UnSuccessful");

                    break;
                case 201:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "The issuing bank has questions about the request. You do not receive an authorization code programmatically, but you might receive one verbally by calling the processor";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 202:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Your card has expired.";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 203:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Card Authorization failed.";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 204:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Insufficient funds in the account";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 205:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Stolen or lost card";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 207:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = " Issuing bank unavailable";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 208:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Inactive card or card not authorized for card-not-present transactions";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 209:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "American Express Card Identification Digits (CID) did not match";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 210:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "The card has reached the credit limit";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 211:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Invalid Card Verification Number (CVN)";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 220:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Generic Decline";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 221:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "The customer matched an entry on the processor's negative file";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 222:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "customer's account is frozen";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 230:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "The authorization request was approved by the issuing bank but declined by CyberSource because it did not pass the card verification number (CVN) check";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 231:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Invalid account number";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 232:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "The card type is not accepted by the payment processor";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 233:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "General decline by the processor";
                    msg = String.Format("Your payment transaction has been UnSuccessful");

                    break;
                case 234:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 235:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 236:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 237:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 238:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 239:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 240:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 241:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 242:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 243:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 246:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");

                    break;
                case 247:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 248:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                case 250:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                default:
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "";
                    msg = String.Format("Your payment transaction has been UnSuccessful");
                    break;
                    #endregion Fail
            }
            #endregion switch

            if (IsResponsefound)
            {
                lblerrormsg.Text = Session["ErrorMessage"].ToString();
                lblerrormsg.Visible = true;
                Response.Redirect("~/mobileweb/MB_MyAccount.aspx?" + EncryptQueryString(string.Format("msg ={0}&Revenue ={1}&AdditionalRevenue={2}&Tip={3}", "U", 0, 0, 0)), false);
            }
        }
        catch
        {
            Session.Remove("PaymentAppointmentID");
        }
    }
    #endregion Payment 

    #region Payment Mail
    private void PaymentDoneMessage()
    {
        try
        {
            string Date_time = DateTime.Now.ToString();
            string datenew = Date_time.ToString();
            string emailadd = Session["emailid"].ToString();
            string body = emailadd + " Has Paid Successfully.";
            string totalprice = totalAmount.ToString();
            string CC_Name1 = Session["CC_Name"].ToString();
            string CC_Name2 = Session["CC_Name1"].ToString();
            string CC_Name = CC_Name1 + " " + CC_Name2;
            string orderno = (string)Session["OrderNumber"];
            string UserAppID = GroomerAppId.ToString();
            string Mailbody = ContentManager.GetStaticeContentEmail("PrePaymentEmail.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- Date -->", Date_time);
            Mailbody = Mailbody.Replace("<!-- UserAppId -->", UserAppID);
            Mailbody = Mailbody.Replace("<!-- Total_Amount -->", totalprice);
            Mailbody = Mailbody.Replace("<!-- CC_Name -->", CC_Name);
            Mailbody = Mailbody.Replace("<!-- orderNumber -->", orderno);
            Mailbody = Mailbody.Replace("<!-- Rev_Amount -->", RevenueCost.ToString());
            Mailbody = Mailbody.Replace("<!-- Prior_Amount -->", PriorRevenueCost.ToString());
            Mailbody = Mailbody.Replace("<!-- Tip_Amount -->", TipCost.ToString());
            Mailbody = Mailbody.Replace("<!-- Details -->", body);
            SendMail ObjMail = new SendMail();
            //for Admin
            ObjMail.PrePaymentMail(Mailbody);
            // for Member
            ObjMail.PrePaymentMail(Session["MemberName"].ToString(), Mailbody.Replace("Admin", Session["MemberName"].ToString()));

        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }
    }

    private void RequestRefundMail(string ToMail, string AppointmentDate, string r, string r1, string t, string total, string OderNo, string MailPage)
    {
        try
        {
            string Mailbody = ContentManager.GetStaticeContentEmail(MailPage).Replace("~", "#");
            Mailbody = Mailbody.Replace("<!--Member-->", Session["MemberName"].ToString());
            Mailbody = Mailbody.Replace(" <!-- Date -->", AppointmentDate);
            Mailbody = Mailbody.Replace("<!-- Total_Amount -->", total);
            Mailbody = Mailbody.Replace("<!-- Rev_Amount -->", r);
            Mailbody = Mailbody.Replace("<!-- Prior_Amount -->", r1);
            Mailbody = Mailbody.Replace("<!-- Tip_Amount -->", t);
            Mailbody = Mailbody.Replace(" <!-- orderNumber -->", OderNo);
            SendMail ObjMail = new SendMail();
            ObjMail.RefundRequest(Mailbody, ToMail);
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }
    }
    #endregion   

    #region Button Payment 
    protected void btnSubmitInfo_Click(object sender, EventArgs e)
    {
        #region Get AppointmentId from GridView If Visible 
        if (GrdFutureApp.Visible == true)
        {
            #region getRadioSelected
            foreach (GridViewRow row in GrdFutureApp.Rows)
            {
                //Find the Radio button control
                RadioButton rb = (RadioButton)row.FindControl("RadioButton1");
                Label lb = (Label)row.FindControl("lblAppointmentID");
                if (rb.Checked)
                {
                    Session["PaymentAppointmentID"] = lb.Text;
                    AppointmentId = Convert.ToInt32(Session["PaymentAppointmentID"].ToString());
                    StartTime = ((Label)(GrdFutureApp.Rows[row.RowIndex].Cells[3].FindControl("lblStartTime"))).Text;
                    AppointmentDate = ((Label)(GrdFutureApp.Rows[row.RowIndex].Cells[2].FindControl("lblAppointmentDate"))).Text;
                }
            }
            #endregion getRadioSelected
        }
        #endregion Get AppointmentId from GridView If Visible 
        #region Get AppointmentId from QueryString 
        else
        {
            #region Only 1Appointment Using Query string
            AppointmentId = Convert.ToInt32(Session["PaymentAppointmentID"].ToString());
            StartTime = string.Empty;
            AppointmentDate = hfLblAppointmentDate.Value != "" ? hfLblAppointmentDate.Value : DateTime.Now.ToString();
            #endregion Only 1Appointment Using Query string
        }
        #endregion Get AppointmentId from QueryString 

        try
        {
            if (Page.IsValid.Equals(true))
            {
                //check to avoid duplicate transactions.
                if (!(null == Session["IsExecuted"]))
                {
                    if (Session["IsExecuted"].Equals("0"))
                    {
                        Session["IsExecuted"] = "1";

                        btnSubmitInfo.Enabled = false;
                        lblerrormsg.Visible = false;

                        // set up Order number uniquely.
                        string OrderRefNo = GetOrderRefNumber();
                        Session["OrderNumber"] = OrderRefNo;
                        string email = billTo_email.Text;

                        //Get All Amount
                        RevenueCost = txtRevenueCost.Text != "" ? Convert.ToDecimal(txtRevenueCost.Text) : 0;
                        PriorRevenueCost = txtPriorRevenue.Text != "" ? Convert.ToDecimal(txtPriorRevenue.Text) : 0;
                        TipCost = txtTipAmt.Text != "" ? Convert.ToDecimal(txtTipAmt.Text) : 0;
                        totalAmount = Convert.ToDecimal(RevenueCost) + Convert.ToDecimal(TipCost) + Convert.ToDecimal(PriorRevenueCost);

                        if (totalAmount > 0)
                        {
                            //User Appointment =0 if No  Appointment Exist  or Not Selected
                            AppointmentId = AppointmentId > 0 ? AppointmentId : 0;
                            if (AppointmentId == 0)
                            {
                                StartTime = string.Empty;
                                AppointmentDate = DateTime.Now.ToString();
                            }

                            #region Check User Appointment First Insert/Update to Groomer Appointment 
                            GroomerAppId = objStoreFront.InsertUpdateAppointmentToGroomerAppointment(0, 0,
                                Convert.ToDateTime(AppointmentDate.ToString()), StartTime, "", txtRevenueCost.Text, "", "",
                                1, Convert.ToDecimal(1),
                                billTo_firstName.Text.Trim(), billTo_email.Text.Trim(), StartTime, AppointmentId);
                            #endregion Check User Appointment First Insert/Update to Groomer Appointment 

                            #region addeded to shopper info before payment  and set PayId 
                            objStoreFront.GetShopperInfo(0, billTo_firstName.Text.Trim(), billTo_lastname.Text.Trim(), billTo_street1.Text.Trim(), billTo_city.Text.Trim(),
                                billTo_state.Text.Trim(), billTo_postalCode.Text.Trim(), billTo_country.Text.Trim(), txtPhone.Text.Trim(), email, drpCardType.SelectedItem.Text, txtCardNumber.Text.Trim(),
                                txtExpYear.Text.Trim(), drpMonth.SelectedValue, "", totalAmount, decimal.Parse("0"), decimal.Parse("0"), OrderRefNo, GroomerAppId, txtVerificationNo.Text.Trim());

                            #endregion addeded to shopper info before payment  and set PayId 

                            Session["emailid"] = billTo_email.Text;
                            Session["totalprice"] = lblTotalAmt.Text.Trim().ToString();
                            Session["CC_Name"] = billTo_firstName.Text.Trim().ToString();
                            Session["CC_Name1"] = billTo_lastname.Text.Trim().ToString();
                            string errorMessage = (string)Session["ErrorMessage"];

                            #region Set Items 
                            // set up Items info
                            Items shoppingCart = new Items();
                            shoppingCart.productName = "Pets Treatment";
                            shoppingCart.unitPrice = totalAmount;
                            shoppingCart.quantity = 1;
                            Session["ShoppingCart"] = shoppingCart;

                            // set up customer info.
                            Shopper shopper;
                            shopper.firstName = billTo_firstName.Text.Trim();
                            shopper.lastName = billTo_lastname.Text.Trim();
                            shopper.email = billTo_email.Text.Trim();
                            shopper.street1 = billTo_street1.Text.Trim();
                            shopper.city = billTo_city.Text.Trim();
                            shopper.state = billTo_state.Text.Trim();
                            shopper.postalCode = billTo_postalCode.Text.Trim();
                            shopper.country = billTo_country.Text.Trim();
                            Session["Shopper"] = shopper;

                            // set up credit card info.
                            CreditCard card;
                            card.accountNumber = txtCardNumber.Text.Trim();
                            card.expirationMonth = drpMonth.SelectedValue.ToString();
                            card.expirationYear = txtExpYear.Text.Trim();
                            card.cvNumber = txtVerificationNo.Text.Trim();

                            #endregion Set Items 

                            // Calulates the Tax. 
                            Global1 global = (Global1)Context.ApplicationInstance;

                            // Authenticate Customer Credit Card details.
                            Authorize(ref card);
                        }
                        else
                        {
                            lblerrormsg.Visible = true;
                        }
                    }
                }
            }
        }
        catch
        {
            Session.Remove("PaymentAppointmentID");
        }
    }
    #endregion Button Payment

    #region Radio Button Checked/Unchecked in Grid Payment 
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GrdFutureApp.Rows)
        {
            RadioButton rb = (RadioButton)row.FindControl("RadioButton1");
            #region Checked
            if (rb.Checked)
            {
                int AppId = Convert.ToInt32(((Label)(GrdFutureApp.Rows[row.RowIndex].Cells[1].FindControl("lblAppointmentID"))).Text);
                PayStatus = ((Label)(GrdFutureApp.Rows[row.RowIndex].Cells[4].FindControl("lblPaymentStatus"))).Text;
                if (AppId > 0 && PayStatus == "Pending")
                {
                    StoreFrontUser Obj = new StoreFrontUser();
                    DataSet ds1 = new DataSet();
                    ds1 = Obj.GetPaymentAppointmentByGrommerDetail(AppId);
                    BindPayMentFieldsForPayment(ds1);
                }
                else
                {
                    ClearPaymentDetails();
                }
            }
            #endregion Checked
        }

    }
    protected void BindPayMentFieldsForPayment(DataSet ds1)
    {
        #region Table 2
        if (ds1.Tables.Count > 0)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {

                if (ds1.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    #region set Revenue set By Admin Only
                    if (ds1.Tables[0].Rows[0]["Status"].ToString() == "Pending")
                    {
                        try
                        {
                            if (ds1.Tables[0].Rows[0]["TotalRevenue"].ToString() != "")
                            {
                                txtRevenueCost.Text = ds1.Tables[0].Rows[0]["TotalRevenue"].ToString().Split('.').First();
                                if (txtRevenueCost.Text == "0") txtRevenueCost.Enabled = true;
                                else txtRevenueCost.Enabled = false;
                                //Empty other Fields
                                txtPriorRevenue.Enabled = true;
                                txtPriorRevenue.Text = string.Empty;
                                txtTipAmt.Text = string.Empty;
                                txtTipAmt.Enabled = true;
                                lblTotalAmt.Text = string.Empty;
                            }
                        }
                        catch
                        {
                            txtRevenueCost.Text = "0";
                        }
                        lblTotalAmt.Text = Convert.ToDecimal(txtRevenueCost.Text).ToString();
                    }
                    #endregion set Revenue set By Admin Only
                    #region set Revenue set By Groomer After Admin set Revenue
                    else if (ds1.Tables[0].Rows[0]["Status"].ToString() == "Completed")
                    {
                        try
                        {
                            if (ds1.Tables[0].Rows[0]["RevenueCreditCard"].ToString() != "0.0000")
                                txtRevenueCost.Text = ds1.Tables[0].Rows[0]["RevenueCreditCard"].ToString().Split('.').First();
                            else if (ds1.Tables[0].Rows[0]["RevenueCheck"].ToString() != "0.0000")
                                txtRevenueCost.Text = ds1.Tables[0].Rows[0]["RevenueCheck"].ToString().Split('.').First();
                            else if (ds1.Tables[0].Rows[0]["RevenueCash"].ToString() != "0.0000")
                                txtRevenueCost.Text = ds1.Tables[0].Rows[0]["RevenueCash"].ToString().Split('.').First();
                            else if (ds1.Tables[0].Rows[0]["RevenueInvoice"].ToString() != "0.0000")
                                txtRevenueCost.Text = ds1.Tables[0].Rows[0]["RevenueInvoice"].ToString().Split('.').First();
                            else if (ds1.Tables[0].Rows[0]["RevenueCCY"].ToString() != "0.0000")
                                txtRevenueCost.Text = ds1.Tables[0].Rows[0]["RevenueCCY"].ToString().Split('.').First();


                            ///check prior revenue here 
                            if (ds1.Tables[0].Rows[0]["PriorCreditCard"].ToString() != "0.0000")
                            {
                                txtPriorRevenue.Text = ds1.Tables[0].Rows[0]["PriorCreditCard"].ToString().Split('.').First();
                                txtPriorRevenue.Enabled = false;
                            }
                            else if (ds1.Tables[0].Rows[0]["PriorCheck"].ToString() != "0.0000")
                            {
                                txtPriorRevenue.Text = ds1.Tables[0].Rows[0]["PriorCheck"].ToString().Split('.').First();
                                txtPriorRevenue.Enabled = false;
                            }
                            else if (ds1.Tables[0].Rows[0]["PriorCash"].ToString() != "0.0000")
                            {
                                txtPriorRevenue.Text = ds1.Tables[0].Rows[0]["PriorCash"].ToString().Split('.').First();
                                txtPriorRevenue.Enabled = false;
                            }
                            else
                            {
                                txtPriorRevenue.Text = "0";
                                txtPriorRevenue.Enabled = true;
                            }

                            ///check tip ammount 
                            if (ds1.Tables[0].Rows[0]["TipCreditCard"].ToString() != "0.0000")
                            {
                                txtTipAmt.Text = ds1.Tables[0].Rows[0]["TipCreditCard"].ToString().Split('.').First();
                                txtTipAmt.Enabled = true;
                            }
                            else if (ds1.Tables[0].Rows[0]["TipCheck"].ToString() != "0.0000")
                            {
                                txtTipAmt.Text = ds1.Tables[0].Rows[0]["TipCheck"].ToString().Split('.').First();
                                txtTipAmt.Enabled = true;
                            }
                            else if (ds1.Tables[0].Rows[0]["TipCash"].ToString() != "0.0000")
                            {
                                txtTipAmt.Text = ds1.Tables[0].Rows[0]["TipCash"].ToString().Split('.').First();
                                txtTipAmt.Enabled = true;
                            }
                            else if (ds1.Tables[0].Rows[0]["TipInvoice"].ToString() != "0.0000")
                            {
                                txtTipAmt.Text = ds1.Tables[0].Rows[0]["TipInvoice"].ToString().Split('.').First();
                                txtTipAmt.Enabled = true;
                            }
                            else
                            {
                                txtTipAmt.Text = "0";
                                txtTipAmt.Enabled = true;
                            }
                            CheckAmount();
                        }
                        catch
                        {
                            txtRevenueCost.Text = "0";
                            txtRevenueCost.Enabled = true;
                            txtTipAmt.Text = "0";
                            txtTipAmt.Enabled = true;
                            txtPriorRevenue.Text = "0";
                            txtPriorRevenue.Enabled = true;
                        }
                        lblTotalAmt.Text = Convert.ToString(Convert.ToDecimal(txtRevenueCost.Text) + Convert.ToDecimal(txtPriorRevenue.Text) + Convert.ToDecimal(txtTipAmt.Text));
                    }
                    #endregion set Revenue set By Groomer After Admin set Revenue
                }
                else
                {
                    txtRevenueCost.Text = string.Empty;
                    txtRevenueCost.Enabled = true; ;
                    txtPriorRevenue.Enabled = true;
                    txtPriorRevenue.Text = string.Empty;
                    txtTipAmt.Text = string.Empty;
                    txtTipAmt.Enabled = true;
                    lblTotalAmt.Text = string.Empty;
                }
            }
        }
        #region Empty All Fields As No one set revenue
        else
        {
            txtRevenueCost.Text = string.Empty;
            txtRevenueCost.Enabled = true; ;
            txtPriorRevenue.Enabled = true;
            txtPriorRevenue.Text = string.Empty;
            txtTipAmt.Text = string.Empty;
            txtTipAmt.Enabled = true;
            lblTotalAmt.Text = string.Empty;
        }
        #endregion Empty All Fields As No one set revenue
        #endregion Table 2
    }

    private void CheckAmount()
    {
        if (txtRevenueCost.Text == "0") txtRevenueCost.Enabled = true;
        else txtRevenueCost.Enabled = false;
        if (txtPriorRevenue.Text == "0") txtPriorRevenue.Enabled = true;
        else txtPriorRevenue.Enabled = false;
        if (txtTipAmt.Text == "0") txtTipAmt.Enabled = true;
        else txtTipAmt.Enabled = false;
    }
    protected void BindToHiddenFieldAppointmentInformation(DataSet ds1)
    {
        if (ds1.Tables.Count > 0)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["GAppointmentDate"].ToString() != "")
                {
                    hfLblAppointmentDate.Value = ds1.Tables[0].Rows[0]["GAppointmentDate"].ToString();
                    hfLblStartTime.Value = ds1.Tables[0].Rows[0]["GStartTime"].ToString();
                }
                else
                {
                    hfLblAppointmentDate.Value = ds1.Tables[0].Rows[0]["AppointmentDate"].ToString();
                    hfLblStartTime.Value = ds1.Tables[0].Rows[0]["AppointmentStartTime"].ToString();
                }
            }
            else
            {
                hfLblAppointmentDate.Value = DateTime.Now.ToString();
                hfLblStartTime.Value = string.Empty;
            }
        }
        else
        {
            hfLblAppointmentDate.Value = DateTime.Now.ToString();
            hfLblStartTime.Value = string.Empty;
        }
    }
    #endregion Radio Button Checked/Unchecked in Grid Payment 

    #region ClearPayDetails
    protected void ClearPaymentDetails()
    {
        txtRevenueCost.Enabled = true;
        txtRevenueCost.Text = string.Empty;
        txtPriorRevenue.Enabled = true;
        txtPriorRevenue.Text = string.Empty;
        txtTipAmt.Enabled = true;
        txtTipAmt.Text = string.Empty;
        lblTotalAmt.Text = string.Empty;

    }
    protected void ClearCreditCardDetails()
    {
        drpCardType.SelectedIndex = 0;
        txtCardNumber.Text = string.Empty;
        drpMonth.SelectedIndex = 0;
        txtExpYear.Text = string.Empty;
        txtVerificationNo.Text = string.Empty;
    }
    #endregion ClearPayDetails

    #region To Cancel Selected Payment
    protected void GrdFutureApp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Refund")
        {
            int AppointmentId = Convert.ToInt32(e.CommandArgument);
            RequestRefund(AppointmentId);
            BindAppointments();
        }
    }
    #endregion

    #region Refund 
    private void RequestRefund(int AppointmentId)
    {

        try
        {
            Groomer objGroomer = new Groomer();
            #region Get Payment Details
            DataSet dsPaidDetails = objGroomer.GetDataForRefundPayment(AppointmentId);
            if (dsPaidDetails.Tables.Count > 0)
                if (dsPaidDetails.Tables[0].Rows.Count > 0)
                {
                    //Send Mail to Member and Admin
                    RequestRefundMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), dsPaidDetails.Tables[0].Rows[0]["AppointmentDate"].ToString(), dsPaidDetails.Tables[0].Rows[0]["RevAmt"].ToString().Split('.').First(), dsPaidDetails.Tables[0].Rows[0]["PriorAmt"].ToString().Split('.').First(), dsPaidDetails.Tables[0].Rows[0]["TipAmt"].ToString().Split('.').First(), dsPaidDetails.Tables[0].Rows[0]["TotalAmt"].ToString().Split('.').First(), dsPaidDetails.Tables[0].Rows[0]["OrderRefNumber"].ToString(), "PaymentRefundAdmin.htm");
                    RequestRefundMail(Convert.ToString(Session["UserName"]), dsPaidDetails.Tables[0].Rows[0]["AppointmentDate"].ToString(), dsPaidDetails.Tables[0].Rows[0]["RevAmt"].ToString().Split('.').First(), dsPaidDetails.Tables[0].Rows[0]["PriorAmt"].ToString().Split('.').First(), dsPaidDetails.Tables[0].Rows[0]["TipAmt"].ToString().Split('.').First(), dsPaidDetails.Tables[0].Rows[0]["TotalAmt"].ToString().Split('.').First(), dsPaidDetails.Tables[0].Rows[0]["OrderRefNumber"].ToString(), "PaymentRefundMember.htm");

                    #region Set This Appointment To UnPaid in Db table
                    Groomer obj = new Groomer();
                    obj.UpdateAppointmentAfterRefund(AppointmentId);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CancelSuccess", " CancelSuccess()", true);
                    #endregion

                    //Send Refund Request To CyberSource

                    #region Authorize And Request

                    #region Set Items 
                    //// set up Items info
                    //Items shoppingCart = new Items();
                    //shoppingCart.productName = "Pets Treatment Refunds";
                    //shoppingCart.unitPrice =Convert.ToDecimal(dsPaidDetails.Tables[0].Rows[0]["TotalAmt"].ToString().Split('.').First());
                    //shoppingCart.quantity = 1;
                    //Session["ShoppingCart"] = shoppingCart;

                    //// set up customer info.
                    //Shopper shopper;
                    //shopper.firstName = billTo_firstName.Text.Trim();
                    //shopper.lastName = billTo_lastname.Text.Trim();
                    //shopper.email = billTo_email.Text.Trim();
                    //shopper.street1 = billTo_street1.Text.Trim();
                    //shopper.city = billTo_city.Text.Trim();
                    //shopper.state = billTo_state.Text.Trim();
                    //shopper.postalCode = billTo_postalCode.Text.Trim();
                    //shopper.country = billTo_country.Text.Trim();
                    //Session["Shopper"] = shopper;

                    //// set up credit card info.
                    //CreditCard card;
                    //card.accountNumber = dsPaidDetails.Tables[0].Rows[0]["CreditCard"].ToString();
                    //card.expirationMonth = dsPaidDetails.Tables[0].Rows[0]["ValidMonth"].ToString();
                    //card.expirationYear = dsPaidDetails.Tables[0].Rows[0]["ValidYear"].ToString();
                    //card.cvNumber = dsPaidDetails.Tables[0].Rows[0]["CCV"].ToString();

                    #endregion

                    // Authenticate Customer.
                    //AuthorizeForRefund(dsPaidDetails.Tables[0].Rows[0]["REQUEST_ID"].ToString(), dsPaidDetails.Tables[0].Rows[0]["REQUEST_TOKEN"].ToString(),dsPaidDetails.Tables[0].Rows[0]["OrderRefNumber"].ToString(), dsPaidDetails.Tables[0].Rows[0]["TotalAmt"].ToString().Split('.').First(), ref card);
                    #endregion
                }
            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion

    #region Authorize For Payment Refund

    private void AuthorizeForRefund(string REQUEST_ID, string REQUEST_TOKEN, string OderNo, string Total)
    {
        try
        {
            #region  create request object
            //RequestMessage request = new RequestMessage();
            //BillTo billTo = new BillTo();
            //configure();
            //// add general fields
            //request.merchantReferenceCode = OderNo;
            //request.ccAuthService = new CCAuthService();
            //request.ccAuthService.run = "true";

            //// add purchasing info
            //PurchaseTotals purchaseTotals = new PurchaseTotals();
            //purchaseTotals.currency = "USD";
            //request.purchaseTotals = purchaseTotals;

            //// add shopper info
            //Shopper shopper = (Shopper)Session["Shopper"];
            //Global1.AddShopperFields(ref billTo, shopper);
            //request.billTo = billTo;


            //// add card info
            //Card card = new Card();
            //card.accountNumber = card1.accountNumber;
            //card.expirationMonth = card1.expirationMonth;
            //card.expirationYear = card1.expirationYear;
            //card.cvNumber = card1.cvNumber;
            //request.card = card;


            ////Void Service for Refund
            //VoidService reqVoid = new VoidService();
            //reqVoid.voidRequestID = REQUEST_ID;
            //reqVoid.voidRequestToken = REQUEST_TOKEN;
            //reqVoid.run = "true";
            //request.voidService = reqVoid;


            ////add item info
            //Items items = (Items)Session["ShoppingCart"];
            //Global1.AddItemFields(ref request, items);

            //// send request now
            //reply = SoapClient.RunTransaction(config, request);

            //// process the transaction as per response.
            //HandleRefundReply();
            #endregion
        }
        #region Catch
        catch (SoapHeaderException she)
        {
            Session["Exception"] = she;
            lblerrormsg.Text = Session["Exception"].ToString();
            lblerrormsg.Visible = true;
        }
        catch (CryptographicException ce)
        {
            Session["Exception"] = ce;
            lblerrormsg.Text = Session["Exception"].ToString();
            lblerrormsg.Visible = true;
        }
        catch (MessageSecurityException mse)
        {
            Session["Exception"] = mse;
            lblerrormsg.Text = Session["Exception"].ToString();
            lblerrormsg.Visible = true;
        }
        catch (WebException we)
        {
            Session["Error"] = we;
            lblerrormsg.Text = Session["Exception"].ToString();
            lblerrormsg.Visible = true;
        }
        catch (Exception e)
        {
            Session["Error"] = e;
            lblerrormsg.Text = Session["Exception"].ToString();
            lblerrormsg.Visible = true;
        }
        #endregion
    }
    #endregion

    #region Handle Reply from Refund
    private void HandleRefundReply()
    {
        int reasonCode;
        string ResponseID, Responsemsg = "", authCode = "";
        reasonCode = int.Parse(reply.reasonCode);
        switch (reasonCode)
        {
            #region Success
            case 100:
                ResponseID = reply.requestID;
                if (reply.invalidField != null)
                    Responsemsg = EnumerateValues(reply.invalidField);
                if (reply.ccAuthReply.authorizationCode != null)
                    authCode = reply.ccAuthReply.authorizationCode;
                #region Success Redirect if No Query string
                else
                {
                    Groomer obj = new Groomer();
                }
                #endregion Success Redirect if No Query string
                break;
                #endregion Success
        }
        Session.Remove("Shopper");
        Session.Remove("ShoppingCart");
    }
    #endregion

}
