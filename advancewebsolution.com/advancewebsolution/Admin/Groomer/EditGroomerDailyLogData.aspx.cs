using System;
using System.Data;
using System.Collections;
using advancewebtosolution.BO;


    public partial class Admin_Groomer_EditGroomerDailyLogData : System.Web.UI.Page
    {
        #region "Global Variable"
        double RevenueCreditCard = 0;
        double RevenueCheck = 0;
        double RevenueCash = 0;
        double RevenueInvoice = 0;
        double TipCreditCard = 0;
        double TipCheck = 0;
        double TipInvoice = 0;
        double PriorCash = 0;
        double PriorCreditCard = 0;
        double PriorCheck = 0;
        #endregion
        public void ErrorMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        public void SuccessMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDayYear();
                BindDropDown();
                GetGroomerDailyLogData();
            }
        }
        public void GetGroomerDailyLogData()
        {
            Groomer objgroomer = new Groomer();
            DataSet ds = new DataSet();
            ds = objgroomer.GetGroomerDailyLogData(Convert.ToInt32(Request.QueryString["GID"].ToString()), ddlLastweek.SelectedItem.Value.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtVanID.Text = ds.Tables[0].Rows[0]["VanId"].ToString();
                txtBeginningMileage.Text = ds.Tables[0].Rows[0]["BeginningMileage"].ToString();
                txtTotalHours.Text = ds.Tables[0].Rows[0]["TotlaHours"].ToString();
                txtEndingMileage.Text = ds.Tables[0].Rows[0]["EndingMileage"].ToString();
                txtFuelPurchased.Text = ds.Tables[0].Rows[0]["FuelPurchased"].ToString();
                txtPriceperGallon.Text = ds.Tables[0].Rows[0]["PricePerGallon"].ToString();
                txtDate.Text = ds.Tables[0].Rows[0]["Addedon"].ToString();
                txtCustLastName.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                txtJob.Text = ds.Tables[0].Rows[0]["Job"].ToString();
                txtZipCode.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString();

                if (ds.Tables[0].Rows[0]["Rebook"].ToString() == "1")
                    rdoRebook.SelectedValue = "1";
                else
                    rdoRebook.SelectedValue = "0";

                if (ds.Tables[0].Rows[0]["FromRebook"].ToString() == "1")
                    rdoFromRebook.SelectedValue = "1";
                else
                    rdoFromRebook.SelectedValue = "0";

                if (ds.Tables[0].Rows[0]["New"].ToString() == "1")
                    rdoNew.SelectedValue = "1";
                else
                    rdoNew.SelectedValue = "0";

                txtPets.Text = ds.Tables[0].Rows[0]["Pets"].ToString();
                txtTimeIn.Text = ds.Tables[0].Rows[0]["TimeIn"].ToString();
                txtTimeOut.Text = ds.Tables[0].Rows[0]["TimeOut"].ToString();
                txtPetTime.Text = ds.Tables[0].Rows[0]["PetTime"].ToString();
                txtExtraServices.Text = ds.Tables[0].Rows[0]["ExtraServices"].ToString();
                txtFleaandTick22.Text = ds.Tables[0].Rows[0]["FleaandTick22"].ToString();
                txtFleaandTick44.Text = ds.Tables[0].Rows[0]["FleaandTick44"].ToString();
                txtFleaandTick88.Text = ds.Tables[0].Rows[0]["FleaandTick88"].ToString();
                txtFleaandTick132.Text = ds.Tables[0].Rows[0]["FleaandTick132"].ToString();
                txtFleaandTickCat.Text = ds.Tables[0].Rows[0]["FleaandTickCat"].ToString();
                txtTB.Text = ds.Tables[0].Rows[0]["TB"].ToString();
                txtWham.Text = ds.Tables[0].Rows[0]["Wham"].ToString();

                if (ds.Tables[0].Rows[0]["RevenueCreditCard"].ToString() != "0.0000")
                {
                    rdoRevenue.SelectedValue = "0";
                    txtRevenue.Text = ds.Tables[0].Rows[0]["RevenueCreditCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RevenueCheck"].ToString() != "0.0000")
                {
                    rdoRevenue.SelectedValue = "1";
                    txtRevenue.Text = ds.Tables[0].Rows[0]["RevenueCheck"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RevenueCash"].ToString() != "0.0000")
                {
                    rdoRevenue.SelectedValue = "2";
                    txtRevenue.Text = ds.Tables[0].Rows[0]["RevenueCash"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RevenueInvoice"].ToString() != "0.0000")
                {
                    rdoRevenue.SelectedValue = "3";
                    txtRevenue.Text = ds.Tables[0].Rows[0]["RevenueInvoice"].ToString();
                }


                if (ds.Tables[0].Rows[0]["TipCreditCard"].ToString() != "0.0000")
                {
                    rdoTip.SelectedValue = "0";
                    txtTip.Text = ds.Tables[0].Rows[0]["TipCreditCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TipCheck"].ToString() != "0.0000")
                {
                    rdoTip.SelectedValue = "1";
                    txtTip.Text = ds.Tables[0].Rows[0]["TipCheck"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TipCash"].ToString() != "0.0000")
                {
                    rdoTip.SelectedValue = "2";
                    txtTip.Text = ds.Tables[0].Rows[0]["TipCash"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TipInvoice"].ToString() != "0.0000")
                {
                    rdoTip.SelectedValue = "3";
                    txtTip.Text = ds.Tables[0].Rows[0]["TipInvoice"].ToString();
                }

                if (ds.Tables[0].Rows[0]["PriorCreditCard"].ToString() != "0.0000")
                {
                    rdoPrior.SelectedValue = "0";
                    txtPriorRevenue.Text = ds.Tables[0].Rows[0]["PriorCreditCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PriorCheck"].ToString() != "0.0000")
                {
                    rdoPrior.SelectedValue = "1";
                    txtPriorRevenue.Text = ds.Tables[0].Rows[0]["PriorCheck"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PriorCash"].ToString() != "0.0000")
                {
                    rdoPrior.SelectedValue = "2";
                    txtPriorRevenue.Text = ds.Tables[0].Rows[0]["PriorCash"].ToString();
                }

                divError.Visible = false;
                dvoperations.Visible = true;
            }
            else
            {
                divError.Visible = true;
                lblErrorDate.Visible = false;
                dvoperations.Visible = false;
                ErrorMessage("Sorry, No records found.");
            }
        }
        protected void ddlLastweek_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroomerDailyLogData();
        }
        public void BindDropDown()
        {
            ArrayList AlDay = new ArrayList();
            for (int i = 0; i < 8; i++)
            {
                DateTime dt = System.DateTime.Today.AddDays(-i);
                //AlDay.Add(dt.ToLongDateString());
                AlDay.Add(dt.Date);
            }
            ddlLastweek.DataSource = AlDay;
            ddlLastweek.DataBind();
        }
        public void BindDayYear()
        {
            string[] day = new string[31];
            for (int i = 0; i < 31; i++)
            {
                day[i] = (i + 1).ToString();
            }
            dddDay.DataSource = day;
            dddDay.DataBind();
            string[] Years = new string[10];
            for (int i = 0; i < 10; i++)
            {
                Years[i] = (DateTime.Now.Year + i).ToString();
            }
            ddlYear.DataSource = Years;
            ddlYear.DataBind();
        }

        public void GroomerDailyOperationsLog()
        {
            if (rdoRevenue.SelectedItem.Value.ToString() == "0")
                RevenueCreditCard = Convert.ToDouble(txtRevenue.Text);
            if (rdoRevenue.SelectedItem.Value.ToString() == "1")
                RevenueCheck = Convert.ToDouble(txtRevenue.Text);
            if (rdoRevenue.SelectedItem.Value.ToString() == "2")
                RevenueCash = Convert.ToDouble(txtRevenue.Text);
            if (rdoRevenue.SelectedItem.Value.ToString() == "3")
                RevenueInvoice = Convert.ToDouble(txtRevenue.Text);

            if (rdoTip.SelectedItem.Value.ToString() == "0")
                TipCreditCard = Convert.ToDouble(txtTip.Text);
            if (rdoTip.SelectedItem.Value.ToString() == "1")
                TipCheck = Convert.ToDouble(txtTip.Text);
            if (rdoTip.SelectedItem.Value.ToString() == "2")
                RevenueCash = Convert.ToDouble(txtTip.Text);
            if (rdoTip.SelectedItem.Value.ToString() == "3")
                TipInvoice = Convert.ToDouble(txtTip.Text);

            if (rdoPrior.SelectedItem.Value.ToString() == "0")
                PriorCreditCard = Convert.ToDouble(txtPriorRevenue.Text);
            if (rdoPrior.SelectedItem.Value.ToString() == "1")
                PriorCheck = Convert.ToDouble(txtPriorRevenue.Text);
            if (rdoPrior.SelectedItem.Value.ToString() == "2")
                PriorCash = Convert.ToDouble(txtPriorRevenue.Text);


            string str123 = ddlMonth.SelectedValue + "/" + dddDay.SelectedValue + "/" + ddlYear.SelectedValue;
            string str1232 = ddlMonth.SelectedValue + "/" + dddDay.SelectedValue + "/" + ddlYear.SelectedValue + " " + ddlhr.SelectedItem.Text + ":00 " + ddlmin.SelectedItem.Text;
            string time = ddlhr.SelectedItem.Text + ":00 " + ddlmin.SelectedItem.Text;

            DateTime dt2 = new DateTime();
            dt2 = Convert.ToDateTime("10/10/2008 10:10:00 AM");
            TimeSpan ts1;

            DateTime dt1 = new DateTime();
            try
            {
                dt1 = Convert.ToDateTime(str123.ToString());
                ts1 = dt1.Date - DateTime.Now; ;
                lblErrorDate.Text = "";
            }
            catch
            {
                ts1 = Convert.ToDateTime("10/10/2008 10:10:00 AM") - DateTime.Now;
                lblErrorDate.Visible = true;
                lblErrorDate.Text = "Please select date greater than today's date";
            }
            if ((dt1.Date > DateTime.Now))
            {
                Groomer ObjUser = new Groomer();
                int i = ObjUser.UpdateGroomerDailyOperationsLog(Convert.ToInt32(Request.QueryString["GID"].ToString()), txtVanID.Text, Convert.ToInt32(txtBeginningMileage.Text), txtTotalHours.Text, Convert.ToInt32(txtEndingMileage.Text), Convert.ToDouble(txtFuelPurchased.Text), Convert.ToDouble(txtPriceperGallon.Text), txtCustLastName.Text + " " + txtDescription.Text, txtJob.Text, txtZipCode.Text, Convert.ToInt32(txtPets.Text), Convert.ToInt32(rdoRebook.SelectedValue), Convert.ToInt32(rdoFromRebook.SelectedValue), Convert.ToInt32(rdoNew.SelectedValue), txtTimeIn.Text, txtTimeOut.Text, txtPetTime.Text, txtExtraServices.Text, Convert.ToInt32(txtFleaandTick22.Text), Convert.ToInt32(txtFleaandTick44.Text), Convert.ToInt32(txtFleaandTick88.Text), Convert.ToInt32(txtFleaandTick132.Text), Convert.ToInt32(txtFleaandTickCat.Text), Convert.ToInt32(txtTB.Text), Convert.ToInt32(txtWham.Text), RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, TipCreditCard, TipCheck, RevenueCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, Convert.ToDateTime(str1232), time, txtServicesforPet1.Text, txtServicesforPet2.Text, txtServicesforPet3.Text, txtServicesforPet4.Text, txtServicesforPet5.Text, txtServicesforPet6.Text, ddlLastweek.SelectedItem.Value.ToString());
                if (i >= 0)
                {
                   
                    divError.Visible = true;
                    SuccessMessage("Groomer daily log data updated successfully.");
                }
            }
            else
            {
                lblErrorDate.Visible = true;
                divError.Visible = false;
                lblErrorDate.Text = "Please select date greater than today's date";
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GroomerDailyOperationsLog();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("GroomersForData.aspx?SearchFor=0&SearchText=");
        }
    }
