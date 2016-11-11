using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using CyberSource;
using System.Net.Mail;
using System.Text;
using CyberSource.Clients;
using CyberSource.Clients.SoapServiceReference;
using CyberSource.Client;

public partial class PaymentInfo : System.Web.UI.Page
{
    #region "Global Variable"
    string strGId;
    Groomer objGroomer = new Groomer();
    private ReplyMessage reply;
    decimal RevenueCost, TipCost, PriorRevenueCost, totalAmount;
    CyberSource.Clients.Configuration config;
    int AppointmentId;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(null == Session["GId"])) { strGId = Session["GId"].ToString(); } else { Response.Redirect("Default.aspx?Msg=Timeout", false); }
            if (null == Session["AptString"]) { Response.Redirect("dashboard.aspx", false); }
            if (!(null == Session["GId"]))
            {
                strGId = Session["GId"].ToString();
                if (!Page.IsPostBack)
                {
                    AppointmentId = Convert.ToInt32(Session["GroomerAppointmentId"].ToString());
                    AutofillDetails();
                    Session["Paycount"] = 1;
                    Session["IsExecuted"] = "0";
                }
            }
            getAppointmentDtls();
        }
        catch 
        {
            Response.Redirect("Operations.aspx", false);
        }
    }
    #endregion Page Load

    #region Auto Fill
    protected void AutofillDetails()
    {
        try
        {
            DataSet Ds = new DataSet();
            Groomer objGroomer = new Groomer();
            //if (!(null == Session["DailyLogID"])) { DailyLogId = Convert.ToInt32(Session["DailyLogID"].ToString()); }
            //    Ds = objGroomer.GetSubmitOrder(DailyLogId, int.Parse(strGId));
            //Ds = objGroomer.GetAptdetails(DailyLogId);
            RevenueCost = 0; TipCost = 0; PriorRevenueCost = 0;
            string userEmail = string.Empty;
            if (!(null == Session["AppointmentDetails"]))
            {
                DataTable dtdetails = (DataTable)Session["AppointmentDetails"];
                #region Payment Amount
                foreach (DataRow dr in dtdetails.Rows)
                {
                    if (!(String.IsNullOrEmpty(dr["CustumerName"].ToString())))
                    {
                        userEmail = dr["CustumerName"].ToString().Trim();
                    }

                    if (!(String.IsNullOrEmpty(dr["RevenueAmount"].ToString())))
                    {
                        txtRevenueCost.Text = Math.Round(Convert.ToDouble(dr["RevenueAmount"].ToString()), 2).ToString();
                        RevenueCost = decimal.Parse(dr["RevenueAmount"].ToString());
                    }
                    if (!(String.IsNullOrEmpty(dr["TipAmount"].ToString())))
                    {
                        txtTipCost.Text = Math.Round(Convert.ToDouble(dr["TipAmount"].ToString()), 2).ToString();
                        TipCost = decimal.Parse(dr["TipAmount"].ToString());
                    }
                    if (!(String.IsNullOrEmpty(dr["PriorAmount"].ToString())))
                    {
                        txtPriorRevenueCost.Text = Math.Round(Convert.ToDouble(dr["PriorAmount"].ToString()), 2).ToString();
                        PriorRevenueCost = decimal.Parse(dr["PriorAmount"].ToString());
                    }
                    if (txtRevenueCost.Text == "" || txtRevenueCost.Text == "0")
                    { txtRevenueCost.ReadOnly=false; txtRevenueCost.Text = string.Empty; txtRevenueCost.Focus(); }
                    else { txtRevenueCost.ReadOnly = true; txtTipCost.Focus(); }
                    lblTotalCost.Text = Math.Round(Convert.ToDouble((RevenueCost + TipCost + PriorRevenueCost).ToString()), 2).ToString();
                }
                #endregion Payment Amount

                #region userInfo
                DataSet ds = new DataSet();

                if (!(String.IsNullOrEmpty(userEmail)))
                {
                    ds = objGroomer.GetUserInfoUsingUserName(userEmail);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UserInformation"] = (DataTable)ds.Tables[0];
                        ViewState["UserMail"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                        txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                        txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                        txtAddress1.Text = ds.Tables[0].Rows[0]["Street"].ToString();
                        txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                        txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                        txtZip.Text = ds.Tables[0].Rows[0]["Zip"].ToString();
                        txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                        Session["UserEmail"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                        txtCountry.Text = "USA";
                    }
                }
                #endregion userInfo
            }

            // restore the card details in session.

            if (!(null == Session["CardDetails"]))
            {
                if (Session["CardDetails"].ToString() != "")
                {
                    DataTable dtdetails = (DataTable)Session["CardDetails"];

                    foreach (DataRow dr in dtdetails.Rows)
                    {
                        txtFirstName.Text = dr[0].ToString();
                        txtLastName.Text = dr[1].ToString();
                        txtAddress1.Text = dr[2].ToString();
                        txtAddress2.Text = dr[3].ToString();
                        txtCity.Text = dr[4].ToString();
                        txtPhone.Text = dr[5].ToString();
                        drpCardType.SelectedValue = dr[6].ToString();
                        txtCardNumber.Text = dr[7].ToString();
                        drpMonth.SelectedValue = dr[8].ToString();
                        txtExpYear.Text = dr[9].ToString();
                        txtVerificationNo.Text = dr[10].ToString();
                    }
                }
            }
        }
        catch 
        {
            Response.Redirect("Default.aspx?Msg=Timeout", false);
        }
    }
    #endregion
    public void getAppointmentDtls()
    {
        try
        {
            if ((!(null == Session["AptDateFormat"])) && (!(null == Session["AptString"])))
            {
                lbl_time.Text = Session["AptDateFormat"].ToString();
                lbl_description.Text = Session["AptString"].ToString();
            }
           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private int GId
    {
        get
        {
            if (Session["GId"] != null)
            {
                return int.Parse(Session["GId"].ToString());
            }
            else
                return 0;
        }
    }

    #region  Make New Oder
    protected string GetOrderRefNumber()
    {
        string OrdNumber = "";
        try
        {
            OrdNumber = (new Random()).Next().ToString();
            bool IsOrdnoPresent = objGroomer.CheckOrderRefNo(OrdNumber);

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
    #endregion

    #region Make Payment
    protected void btnSubmitInfo_Click(object sender, EventArgs e)
    {
        string email = ConfigurationManager.AppSettings["FromEmail"].ToString();
        string ToEmail = ConfigurationManager.AppSettings["ToEmail"].ToString();
        RevenueCost = txtRevenueCost.Text != "" ? Convert.ToDecimal(txtRevenueCost.Text) : 0;
        PriorRevenueCost = txtPriorRevenueCost.Text != "" ? Convert.ToDecimal(txtPriorRevenueCost.Text) : 0;
        TipCost = txtTipCost.Text != "" ? Convert.ToDecimal(txtTipCost.Text) : 0;
        totalAmount = Convert.ToDecimal(RevenueCost) + Convert.ToDecimal(TipCost) + Convert.ToDecimal(PriorRevenueCost);
        if (totalAmount <= (-1))
        {
            lblerrormsg.Visible = true;
            txtTipCost.Focus();
            return;
        }
        else
        {
            if (Page.IsValid.Equals(true))
            {
                //check to avoid duplicate transactions.
                if (!(null == Session["IsExecuted"]))
                {
                    if (Session["IsExecuted"].Equals("0"))
                    {
                        if (!(null == Session["GId"]))
                        {
                            btnSubmitInfo.Enabled = false;
                            // set up Order number uniquely.
                            string OrderRefNo = GetOrderRefNumber();
                            Session["OrderNumber"] = OrderRefNo;
                           
                            //update new tip and revenue for appointment log page
                            DataTable dtdetails = (DataTable)Session["AppointmentDetails"];

                            #region Forloop
                            foreach (DataRow dr in dtdetails.Rows)
                            {
                                #region Start
                                #region Rowstart
                                dr["AppStartTime"] = dr["AppStartTime"];
                                dr["AppEndTime"] = dr["AppEndTime"];
                                dr["AppDateTime"] = dr["AppDateTime"];
                                dr["Description"] = dr["Description"];
                                dr["CustumerName"] = dr["CustumerName"];
                                dr["Date"] = dr["Date"];
                                dr["LastName"] = dr["LastName"];
                                dr["JobMileage"] = dr["JobMileage"];
                                dr["ZipCode"] = dr["ZipCode"];
                                dr["Pets"] = dr["Pets"];
                                dr["NextAppointmentTime"] = dr["NextAppointmentTime"];
                                dr["ExpStartTime"] = dr["ExpStartTime"];
                                dr["ExpEndTime"] = dr["ExpEndTime"];
                                dr["Rebook"] = dr["Rebook"];
                                dr["FromRebook"] = dr["FromRebook"];
                                dr["NextStartTime"] = dr["NextStartTime"];
                                dr["NextEndTime"] = dr["NextEndTime"];
                                #endregion Rowstart
                                #region hidden services
                                dr["ServicesforPet1"] = dr["ServicesforPet1"];
                                dr["ServicesforPet2"] = dr["ServicesforPet2"];
                                dr["ServicesforPet3"] = dr["ServicesforPet3"];
                                dr["ServicesforPet4"] = dr["ServicesforPet4"];
                                dr["ServicesforPet5"] = dr["ServicesforPet5"];
                                dr["ServicesforPet6"] = dr["ServicesforPet6"];
                                dr["NewRadio"] = dr["NewRadio"];
                                #endregion hidden services
                                #region supplies
                                dr["FleaandTick22"] = dr["FleaandTick22"];
                                dr["FleaandTick44"] = dr["FleaandTick44"];
                                dr["FleaandTick88"] = dr["FleaandTick88"];
                                dr["FleaandTick132"] = dr["FleaandTick132"];
                                dr["FleaandTickCat"] = dr["FleaandTickCat"];
                                dr["TB"] = dr["TB"];
                                dr["Wham"] = dr["Wham"];
                                #endregion supplies
                                #region Revenue
                                dr["RevenueType"] = dr["RevenueType"];
                                dr["RevenueAmount"] = RevenueCost.ToString();
                                dr["ApptChanges"] = dr["ApptChanges"];
                                dr["CommentDiv"] = dr["CommentDiv"];
                                dr["PetTimeGoodBad1"] = dr["PetTimeGoodBad1"];
                                dr["PetTimeGoodBad2"] = dr["PetTimeGoodBad2"];
                                #endregion Revenue
                                #region Product
                                dr["ProductPrice"] = dr["ProductPrice"];
                                dr["ProductSalesTax"] = dr["ProductSalesTax"];
                                #endregion Product
                                #region Tip
                                dr["Tiptype"] = dr["Tiptype"];
                                dr["TipAmount"] = TipCost.ToString();
                                #endregion Tip
                                #region Prior Revenue
                                dr["PriorType"] = dr["PriorType"];
                                dr["PriorAmount"] = PriorRevenueCost.ToString();
                                #endregion Prior Revenue
                                #region CheckDetail
                                dr["NameOnCheck"] = dr["NameOnCheck"];
                                dr["AddressOnCheck"] = dr["AddressOnCheck"];
                                #endregion CheckDetail
                                #endregion Start
                            }
                            #endregion Forloop

                            Session["AppointmentDetails"] = dtdetails;
                            objGroomer.GetShopperInfo(GId, txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress1.Text.Trim(), txtCity.Text.Trim(),
                            txtState.Text.Trim(), txtZip.Text.Trim(), txtCountry.Text.Trim(), txtPhone.Text.Trim(), email, drpCardType.SelectedItem.Text, txtCardNumber.Text.Trim(),
                            txtExpYear.Text.Trim(), drpMonth.SelectedValue, "", Convert.ToDecimal(lblTotalCost.Text),
                            decimal.Parse("0"), decimal.Parse("0"), OrderRefNo, Convert.ToInt32(Session["GroomerAppointmentId"].ToString()), txtVerificationNo.Text.Trim());

                            Session["emailid"] = email;
                            Session["totalprice"] = lblTotalCost.Text.Trim().ToString();
                            Session["CC_Name"] = txtFirstName.Text.Trim().ToString();
                            Session["CC_Name1"] = txtLastName.Text.Trim().ToString();

                            string errorMessage = (string)Session["ErrorMessage"];

                            // set up Items info
                            Items shoppingCart = new Items();
                            shoppingCart.productName = "Pets Treatment";
                            shoppingCart.unitPrice = totalAmount;
                            shoppingCart.quantity = 1;
                            Session["ShoppingCart"] = shoppingCart;

                            // set up customer info.
                            Shopper shopper;
                            shopper.firstName = txtFirstName.Text.Trim();
                            shopper.lastName = txtLastName.Text.Trim();
                            shopper.email = ToEmail;
                            shopper.street1 = txtAddress1.Text.Trim();
                            shopper.city = txtCity.Text.Trim();
                            shopper.state = txtState.Text.Trim();
                            shopper.postalCode = txtZip.Text.Trim();
                            shopper.country = txtCountry.Text.Trim();
                            Session["Shopper"] = shopper;

                            // set up credit card info.
                            CreditCard card;
                            card.accountNumber = txtCardNumber.Text.Trim();
                            card.expirationMonth = drpMonth.SelectedValue.ToString();
                            card.expirationYear = txtExpYear.Text.Trim();
                            card.cvNumber = txtVerificationNo.Text.Trim();

                            Global1 global = ((Global1)this.Context.ApplicationInstance);
                            // CalculateTax(global.icsClient);
                            Authorize(ref card);
                            Session["IsExecuted"] = "1";
                        }
                    }
                }

            }
        }
    }
    #endregion Make Payment
    protected void configure()
    {
        try
        {
            config = new CyberSource.Clients.Configuration();
            config.KeyFilename = ConfigurationManager.AppSettings["cybs.keyFilename"].ToString();
            config.KeysDirectory = Server.MapPath("~/") + "Keys";
            config.MerchantID = ConfigurationManager.AppSettings["cybs.merchantID"].ToString();
            config.ServerURL = ConfigurationManager.AppSettings["cybs.serverURL"].ToString();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private void Authorize(ref CreditCard card1)
    {
        try
        {
            // create request object
            RequestMessage request = new RequestMessage();
            BillTo billTo = new BillTo();
            configure();
            // add general fields
            if (!(null == Session["OrderNumber"])) request.merchantReferenceCode = (string)Session["OrderNumber"];

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
        catch (BugException e)
        {
            Session["Exception"] = e;
            HandleReply();
        }
        catch (NonCriticalTransactionException e)
        {
            Session["Exception"] = e;
            HandleReply();
        }
        catch (CriticalTransactionException e)
        {
            // The transaction may have been successfully processed by
            // CyberSource.  Aside from redirecting to an error page, you should
            // make sure that someone gets notified of the occurrence of this
            // exception so that they could check the outcome of the transaction
            // on the CyberSource Support Screens.  For example, you could
            // post an event log or send an email to a monitored address.
            Session["Exception"] = e;
            HandleReply();
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

    #region Payment Mail
    private void PaymentDoneMessage(decimal r, decimal r1, decimal t)
    {
        try
        {
            string Date_time = DateTime.Now.ToString();
            string datenew = Date_time.ToString();
            string emailadd = Session["emailid"].ToString();
            string body = emailadd + " Has Paid Successfully.";
            string totalprice = (r + r1 + t).ToString();
            string CC_Name1 = Session["CC_Name"].ToString();
            string CC_Name2 = Session["CC_Name1"].ToString();
            string CC_Name = CC_Name1 + " " + CC_Name2;
            string orderno = (string)Session["OrderNumber"];
            string UserAppID = Session["GroomerAppointmentId"].ToString();
            string Mailbody = ContentManager.GetStaticeContentEmail("PrePaymentEmail.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- Date -->", Date_time);
            Mailbody = Mailbody.Replace("<!-- UserAppId -->", UserAppID);
            Mailbody = Mailbody.Replace("<!-- Total_Amount -->", totalprice);
            Mailbody = Mailbody.Replace("<!-- CC_Name -->", CC_Name);
            Mailbody = Mailbody.Replace("<!-- orderNumber -->", orderno);
            Mailbody = Mailbody.Replace("<!-- Rev_Amount -->", r.ToString());
            Mailbody = Mailbody.Replace("<!-- Prior_Amount -->", r1.ToString());
            Mailbody = Mailbody.Replace("<!-- Tip_Amount -->", t.ToString());
            Mailbody = Mailbody.Replace("<!-- Details -->", body);
            SendMail ObjMail = new SendMail();
            MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["ToEmail"]);
            objMailMsg.BodyEncoding = Encoding.UTF8;
            objMailMsg.Subject = "Groomer Panel:Payment Details For Fritzys Pet Care Pros Mobile Grooming Services";
            objMailMsg.Body = Mailbody;
            objMailMsg.Priority = MailPriority.High;
            objMailMsg.IsBodyHtml = true;
            SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
            objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
            objSMTPClient.EnableSsl = true;
            objSMTPClient.Send(objMailMsg);
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }
    }
    #endregion

    #region Handle Reply
    private void HandleReply()
    {
        string ResponseID = "", Responsemsg = "", billtxnrefno = "", authCode = "", msg = "";
        int reasonCode;
        bool IsResponsefound = true;
        reasonCode = int.Parse(reply.reasonCode);
        Groomer objGroomer = new Groomer();

        #region switch
        switch (reasonCode)
        {
            #region Success
            case 100:
                IsResponsefound = false;
                ResponseID = reply.requestID;
                string REQUEST_TOKEN = reply.requestToken;
                if (reply.invalidField != null) Responsemsg = EnumerateValues(reply.invalidField);
                if (reply.ccAuthReply.authorizationCode != null) authCode = reply.ccAuthReply.authorizationCode;
                string payid = "0";
                if(Session["DailyLogID"]!=null)
                 payid= Session["DailyLogID"].ToString() != "" ? Session["DailyLogID"].ToString() : "0";

                Session["AptString"] = null;
                Session["TipAmt"] = txtTipCost.Text;
                Session["LastName"] = txtLastName.Text;
                Session["NewZip"] = txtZip.Text;
                totalAmount = (lblTotalCost.Text == "") ? 0 : Convert.ToDecimal(lblTotalCost.Text);
                try
                {
                    objGroomer.UpdatePGResponseDetails(reasonCode.ToString(), "0", ResponseID, Session["PayID"].ToString(), Responsemsg, billtxnrefno, authCode, REQUEST_TOKEN);
                    // insert/update  other related tables to populated this appointment effect on users and admin pannel end
                    objGroomer.InsertAppointmentPrePayment(0, RevenueCost, PriorRevenueCost, TipCost, totalAmount, " ", Convert.ToInt32(Session["PayID"].ToString()), Convert.ToInt32(Session["GroomerAppointmentId"].ToString()));
                    objGroomer.UpdatePrePayStatus(Convert.ToInt32(Session["GroomerAppointmentId"].ToString()), "PrePaid");
                    PaymentDoneMessage(RevenueCost, PriorRevenueCost, TipCost);
                }
                catch
                {
                    Response.Redirect("Dashboard.aspx", false);
                }
                break;
            #endregion Success

            #region failT
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
                #endregion failT
        }
        #endregion switch

        #region Redirect Back to Appointment log page
        if (IsResponsefound) Response.Redirect("Operations.aspx?" + EncryptQueryString(string.Format("msg={0}", "U")), false);
        else Response.Redirect("Operations.aspx?" + EncryptQueryString(string.Format("msg={0}", "P")), false);
        #endregion 
    }
    #endregion 

    

    #region Claculate Tax
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        //lblTotalCost.Text = (decimal.Parse(lblRevenueCost.Text) + decimal.Parse(lblTipCost.Text) + decimal.Parse(lblPriorRevenueCost.Text)).ToString();
    }

    protected void btneditapt_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtdetails = new DataTable();
            dtdetails.Columns.Add("Firstname");
            dtdetails.Columns.Add("Lastname");
            dtdetails.Columns.Add("Address1");
            dtdetails.Columns.Add("Address2");
            dtdetails.Columns.Add("city");
            dtdetails.Columns.Add("phone");
            dtdetails.Columns.Add("cctype");
            dtdetails.Columns.Add("ccnumber");
            dtdetails.Columns.Add("expmonth");
            dtdetails.Columns.Add("expyear");
            dtdetails.Columns.Add("ccvno");

            DataRow dr = dtdetails.NewRow();
            dr[0] = txtFirstName.Text;
            dr[1] = txtLastName.Text;
            dr[2] = txtAddress1.Text;
            dr[3] = txtAddress2.Text;
            dr[4] = txtCity.Text;
            dr[5] = txtPhone.Text;
            dr[6] = drpCardType.SelectedValue.ToString();
            dr[7] = txtCardNumber.Text;
            dr[8] = drpMonth.SelectedValue.ToString();
            dr[9] = txtExpYear.Text;
            dr[10] = txtVerificationNo.Text;
            dtdetails.Rows.Add(dr);
            if (txtTipCost.Text != "")
            {
                Session["TipAmt"] = txtTipCost.Text;
            }

            Session["CardDetails"] = dtdetails;
            Response.Redirect("Operations.aspx?" + EncryptQueryString(string.Format("msg={0}", "E")), false);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion Claculate Tax

    #region Get All Amount to Pay
    protected void txtTipCost_TextChanged(object sender, EventArgs e)
    {
        if (txtTipCost.Text != "")
        {
         
            decimal t = Convert.ToDecimal(txtTipCost.Text);
            if (t <= (-1))
            {
                lblerrormsg.Visible = true;
                txtTipCost.Focus();
            }
            else
            {
                TipCost = txtTipCost.Text != "" ? decimal.Parse(txtTipCost.Text) : 0;
                RevenueCost = txtRevenueCost.Text != "" ? decimal.Parse(txtRevenueCost.Text) : 0;
                PriorRevenueCost = txtPriorRevenueCost.Text != "" ? decimal.Parse(txtPriorRevenueCost.Text) : 0;
                lblTotalCost.Text = Math.Round(Convert.ToDouble((RevenueCost + TipCost + PriorRevenueCost).ToString()), 2).ToString();
                Session["TipAmt"] = TipCost;
                txtPriorRevenueCost.Focus();
            }
        }
        else
        {
            txtTipCost.Text = "0";
            lblerrormsg.Visible = false;
            TipCost = txtTipCost.Text != "" ? decimal.Parse(txtTipCost.Text) : 0;
            RevenueCost = txtRevenueCost.Text != "" ? decimal.Parse(txtRevenueCost.Text) : 0;
            PriorRevenueCost = txtPriorRevenueCost.Text != "" ? decimal.Parse(txtPriorRevenueCost.Text) : 0;
            lblTotalCost.Text = Math.Round(Convert.ToDouble((RevenueCost + TipCost + PriorRevenueCost).ToString()), 2).ToString();
            Session["TipAmt"] = TipCost;
        }
    }
    protected void txtRevenueCost_TextChanged(object sender, EventArgs e)
    {
        if (txtRevenueCost.Text != "")
        {
            double t = Convert.ToDouble(txtRevenueCost.Text);
            if (t <= (-1))
            {
                lblerrormsg.Visible = true;
                txtRevenueCost.Focus();
            }
            else
            {
                TipCost = txtTipCost.Text != "" ? decimal.Parse(txtTipCost.Text) : 0;
                RevenueCost = txtRevenueCost.Text != "" ? decimal.Parse(txtRevenueCost.Text) : 0;
                PriorRevenueCost = txtPriorRevenueCost.Text != "" ? decimal.Parse(txtPriorRevenueCost.Text) : 0;
                lblTotalCost.Text = Math.Round(Convert.ToDouble((RevenueCost + TipCost + PriorRevenueCost).ToString()), 2).ToString();
                Session["RevenueCost"] = RevenueCost;
                txtTipCost.Focus();
            }
        }
        else
        {
            txtRevenueCost.Text = "0";
            lblerrormsg.Visible = false;
            TipCost = txtTipCost.Text != "" ? decimal.Parse(txtTipCost.Text) : 0;
            RevenueCost = txtRevenueCost.Text != "" ? decimal.Parse(txtRevenueCost.Text) : 0;
            PriorRevenueCost = txtPriorRevenueCost.Text != "" ? decimal.Parse(txtPriorRevenueCost.Text) : 0;
            lblTotalCost.Text = Math.Round(Convert.ToDouble((RevenueCost + TipCost + PriorRevenueCost).ToString()), 2).ToString();
            Session["RevenueCost"] = RevenueCost;
        }
    }
    protected void txtPriorRevenueCost_TextChanged(object sender, EventArgs e)
    {
        if (txtPriorRevenueCost.Text != "")
        {
            decimal t = Convert.ToDecimal(txtPriorRevenueCost.Text);
            if (t <= (-1))
            {
                lblerrormsg.Visible = true;
                txtPriorRevenueCost.Focus();
            }
            else
            {
                TipCost = txtTipCost.Text != "" ? decimal.Parse(txtTipCost.Text) : 0;
                RevenueCost = txtRevenueCost.Text != "" ? decimal.Parse(txtRevenueCost.Text) : 0;
                PriorRevenueCost = txtPriorRevenueCost.Text != "" ? decimal.Parse(txtPriorRevenueCost.Text) : 0;
                lblTotalCost.Text = Math.Round(Convert.ToDouble((RevenueCost + TipCost + PriorRevenueCost).ToString()), 2).ToString();
                Session["PriorRevenueCost"] = PriorRevenueCost;
                txtFirstName.Focus();
            }
        }
        else
        {
            txtPriorRevenueCost.Text = "0";
            lblerrormsg.Visible = false;
            TipCost = txtTipCost.Text != "" ? decimal.Parse(txtTipCost.Text) : 0;
            RevenueCost = txtRevenueCost.Text != "" ? decimal.Parse(txtRevenueCost.Text) : 0;
            PriorRevenueCost = txtPriorRevenueCost.Text != "" ? decimal.Parse(txtPriorRevenueCost.Text) : 0;
            lblTotalCost.Text = Math.Round(Convert.ToDouble((RevenueCost + TipCost + PriorRevenueCost).ToString()), 2).ToString();
            Session["PriorRevenueCost"] = PriorRevenueCost;
        }
    }
    #endregion Get All Amount to Pay

    #region Enc/Desc
    public string EncryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
    }
    private string DecryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
    }
    #endregion

}
