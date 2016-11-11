using System;
using System.Linq;
using System.Data;
using advancewebtosolution.BO;
//using Excel = Microsoft.Office.Interop.Excel;

    public partial class Admin_Groomer_EditExcel : System.Web.UI.Page
    {
        Groomer ObjGroomer = new Groomer();
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindExcelData();
                BindInventoryLabels();
            }
        }
        
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string ServicesForPet = txtService4Pet1.Text.Trim() + " , " + txtService4Pet1.Text.Trim() + " , " + txtService4Pet2.Text.Trim() + " , " + txtService4Pet3.Text.Trim() + " , " + txtService4Pet4.Text.Trim() + " , " + txtService4Pet5.Text.Trim() + " , " + txtService4Pet6.Text.Trim();
            //int Count = ObjGroomer.EditExcel("'" + txtVanID.Text.Trim() + "'", "'" + txtMileage.Text.Trim() + "'", "'" + txtTotHrs.Text.Trim() + "'", "'" + txtEndMileage.Text.Trim() + "'", "'" + txtFuelPur.Text.Trim() + "'", "'" + txtPricePerGallon.Text.Trim() + "'", "'" + txtDesc.Text.Trim() + "'", "'" + txtJob.Text.Trim() + "'", "'" + txtZipCode.Text.Trim() + "'", "'" + txtPets.Text.Trim() + "'", "'" + txtRebook.Text.Trim() + "'", "'" + txtFromRebook.Text.Trim() + "'", "'" + txtNew.Text.Trim() + "'", "''", "''", "'" + txtPetTime.Text.Trim() + "'", "'" + txtExtraServ.Text.Trim() + "'", "'" + txtFleaNTick22.Text.Trim() + "'", "'" + txtFleaNTick44.Text.Trim() + "'", "'" + txtFleaNTick88.Text.Trim() + "'", "'" + txtFleaNTick132.Text.Trim() + "'", "'" + txtFleaNTickCat.Text.Trim() + "'", "'" + txtTB.Text.Trim() + "'", "'" + txtWham.Text.Trim() + "'", "'" + txtCreditCard.Text.Trim() + "'", "'" + txtCheck.Text.Trim() + "'", "'" + txtCash.Text.Trim() + "'", "'" + txtInvoice.Text.Trim() + "'", "'" + txtTCreditCard.Text.Trim() + "'", "'" + txtTCheck.Text.Trim() + "'", "'" + txtTCash.Text.Trim() + "'", "'" + txtTInvoice.Text.Trim() + "'", "'" + txtPCreditCard.Text.Trim() + "'", "'" + txtPCheck.Text.Trim() + "'", "'" + txtPCash.Text.Trim() + "'", "'" + txtAppDate.Text.Trim() + "'", "'" + txtAppTime.Text.Trim() + "'", "'" + ServicesForPet + "'", "''", "'" + txtFleaNTick22lbs.Text.Trim() + "'", "'" + txtFleaNTick44lbs.Text.Trim() + "'", "'" + txtFleaNTick88lbs.Text.Trim() + "'", "'" + txtFleaNTick132lbs.Text.Trim() + "'", "'" + txtFleaNTickCatInv.Text.Trim() + "'", "'" + txtToothbrushes.Text.Trim() + "'", "'" + txtWham2.Text.Trim() + "'", "'" + txtTowels.Text.Trim() + "'", "'" + txtCottonPads.Text.Trim() + "'", "'" + txtCottonSwabs.Text.Trim() + "'", "'" + txtPaperT.Text.Trim() + "'", "'" + txtGarbageBags.Text.Trim() + "'", "'" + txtTreats.Text.Trim() + "'", "'" + txtVetWrap.Text.Trim() + "'", "'" + txtWipes.Text.Trim() + "'", "'" + txtQuickStop.Text.Trim() + "'", "'" + txtLqBandaid.Text.Trim() + "'", "'" + txtEnvelopes.Text.Trim() + "'", "'" + txtReceipts.Text.Trim() + "'", "'" + txtBusinessCards.Text.Trim() + "'", "'" + txtBlades.Text.Trim() + "'", "'" + txtScissors.Text.Trim() + "'", "'" + txtSunguard.Text.Trim() + "'", "'" + txtEZShed.Text.Trim() + "'", "'" + txtEZDematt.Text.Trim() + "'", "'" + txtSkunkKit.Text.Trim() + "'", "'" + txtOther.Text.Trim() + "'");
            try
            {
                ObjGroomer.EditExcel(txtPassword.Text.Trim(), txtVanID.Text.Trim(), txtMileage.Text.Trim(), txtTotHrs.Text.Trim(), txtEndMileage.Text.Trim(), txtFuelPur.Text.Trim(), txtPricePerGallon.Text.Trim(), txtDesc.Text.Trim(), txtJob.Text.Trim(), txtZipCode.Text.Trim(), txtPets.Text.Trim(), txtRebook.Text.Trim(), txtFromRebook.Text.Trim(), txtNew.Text.Trim(), "", "", txtPetTime.Text.Trim(), txtExtraServ.Text.Trim(), txtComments.Text.Trim(), txtFleaNTick22.Text.Trim(), txtFleaNTick44.Text.Trim(), txtFleaNTick88.Text.Trim(), txtFleaNTick132.Text.Trim(), txtFleaNTickCat.Text.Trim(), txtTB.Text.Trim(), txtWham.Text.Trim(), txtCreditCard.Text.Trim(), txtCheck.Text.Trim(), txtCash.Text.Trim(), txtInvoice.Text.Trim(), txtTCreditCard.Text.Trim(), txtTCheck.Text.Trim(), txtTCash.Text.Trim(), txtTInvoice.Text.Trim(), txtPCreditCard.Text.Trim(), txtPCheck.Text.Trim(), txtPCash.Text.Trim(), txtAppDate.Text.Trim(), txtAppTime.Text.Trim(), ServicesForPet, "", txtFleaNTick22lbs.Text.Trim(), txtFleaNTick44lbs.Text.Trim(), txtFleaNTick88lbs.Text.Trim(), txtFleaNTick132lbs.Text.Trim(), txtFleaNTickCatInv.Text.Trim(), txtToothbrushes.Text.Trim(), txtWham2.Text.Trim(), txtTowels.Text.Trim(), "", txtCottonSwabs.Text.Trim(), txtPaperT.Text.Trim(), txtGarbageBags.Text.Trim(), txtTreats.Text.Trim(), txtVetWrap.Text.Trim(), txtWipes.Text.Trim(), "", "", txtEnvelopes.Text.Trim(), txtReceipts.Text.Trim(), txtBusinessCards.Text.Trim(), "", "", "", "", "", "", "", txtProductPrice.Text.Trim(), txtSalestax.Text.Trim(), txtRev01.Text.Trim(), txtCreditCardNo.Text.Trim(), txtCreditCardExp.Text.Trim(), txtCreditCardName.Text.Trim(), txtAddrsOfCC.Text.Trim(), txtSecurityCode.Text.Trim(), txtOther1.Text.Trim(), txtOther2.Text.Trim(), txtOther3.Text.Trim(), txtOther4.Text.Trim(), txtOther5.Text.Trim(), txtMarketing1.Text.Trim(), txtMarketing2.Text.Trim(), txtMarketing3.Text.Trim(), txtMarketing4.Text.Trim(), txtMarketing5.Text.Trim(),
                    txtLiquid1.Text.Trim(), txtLiquid2.Text.Trim(), txtLiquid3.Text.Trim(), txtLiquid4.Text.Trim(), txtLiquid5.Text.Trim(), txtLiquid6.Text.Trim(), txtLiquid7.Text.Trim(), txtLiquid8.Text.Trim(), txtLiquid9.Text.Trim(), txtLiquid10.Text.Trim(), txtLiquid11.Text.Trim(), txtLiquid12.Text.Trim(), txtLiquid13.Text.Trim(), txtLiquid14.Text.Trim(), txtLiquid15.Text.Trim(), txtLiquid16.Text.Trim(), txtLiquid17.Text.Trim(), txtLiquid18.Text.Trim(), txtLiquid19.Text.Trim(), txtLiquid20.Text.Trim(), txtLiquid21.Text.Trim(), txtLiquid22.Text.Trim(), txtLiquid23.Text.Trim(), txtLiquid24.Text.Trim(), txtLiquid25.Text.Trim());
                ObjGroomer.updateLabels(txtLiq1.Text, txtLiq2.Text, txtLiq3.Text, txtLiq4.Text, txtLiq5.Text, txtLiq6.Text, txtLiq7.Text, txtLiq8.Text, txtLiq9.Text, txtLiq10.Text, txtLiq11.Text, txtLiq12.Text, txtLiq13.Text, txtLiq14.Text, txtLiq15.Text, txtLiq16.Text, txtLiq17.Text, txtLiq18.Text, txtLiq19.Text, txtLiq20.Text, txtLiq21.Text, txtLiq22.Text, txtLiq23.Text, txtLiq24.Text, txtLiq25.Text, txtFT22.Text, txtFT44.Text, txtFT88.Text, txtFT132.Text, txtFTCat.Text, txtToothb.Text, txtWhamData.Text, txtTowelsData.Text, txtTreatsData.Text, txtEarWipes.Text, txtCottonSwabsData.Text, txtVetWrapData.Text, txtPaperTowels.Text, txtGarbageBagsData.Text, txtReceiptsData.Text, txtEnvelopesData.Text, txtBusinessCardsData.Text, txtOther1Data.Text, txtOther2Data.Text, txtOther3Data.Text, txtOther4Data.Text, txtOther5Data.Text, txtMarketing1Data.Text, txtMarketing2Data.Text, txtMarketing3Data.Text, txtMarketing4Data.Text, txtMarketing5Data.Text);
                BindInventoryLabels();
               
                SuccesfullMessage("Excel field updated successfully.");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                ErrMessage("System failed to modify details, Please try again....");
            }
        }

        public void BindExcelData()
        {
            ds = ObjGroomer.getExcelData();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPassword.Text = ds.Tables[0].Rows[0]["SpreadsheetPassword"].ToString().Trim().Trim().Trim();
                txtVanID.Text = ds.Tables[0].Rows[0]["VanId"].ToString().Trim().Trim().Trim();
                txtMileage.Text = ds.Tables[0].Rows[0]["BeginningMileage"].ToString().Trim().Trim();
                txtTotHrs.Text = ds.Tables[0].Rows[0]["TotlaHours"].ToString().Trim();
                txtEndMileage.Text = ds.Tables[0].Rows[0]["EndingMileage"].ToString().Trim();
                txtFuelPur.Text = ds.Tables[0].Rows[0]["FuelPurchased"].ToString().Trim();
                txtPricePerGallon.Text = ds.Tables[0].Rows[0]["PricePerGallon"].ToString().Trim();
                txtDesc.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString().Trim();
                txtJob.Text = ds.Tables[0].Rows[0]["Job"].ToString().Trim();
                txtZipCode.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString().Trim();
                txtPets.Text = ds.Tables[0].Rows[0]["Pets"].ToString().Trim();
                txtRebook.Text = ds.Tables[0].Rows[0]["Rebook"].ToString().Trim();
                txtFromRebook.Text = ds.Tables[0].Rows[0]["FromRebook"].ToString().Trim();
                txtNew.Text = ds.Tables[0].Rows[0]["New"].ToString().Trim();
                txtPetTime.Text = ds.Tables[0].Rows[0]["PetTime"].ToString().Trim();
                txtExtraServ.Text = ds.Tables[0].Rows[0]["ExtraServices"].ToString().Trim();

                txtFleaNTick22.Text = ds.Tables[0].Rows[0]["FleaandTick22"].ToString().Trim();
                txtFleaNTick44.Text = ds.Tables[0].Rows[0]["FleaandTick44"].ToString().Trim();
                txtFleaNTick88.Text = ds.Tables[0].Rows[0]["FleaandTick88"].ToString().Trim();
                txtFleaNTick132.Text = ds.Tables[0].Rows[0]["FleaandTick132"].ToString().Trim();
                txtFleaNTickCat.Text = ds.Tables[0].Rows[0]["FleaandTickCat"].ToString().Trim();
                txtTB.Text = ds.Tables[0].Rows[0]["TB"].ToString().Trim();
                txtWham.Text = ds.Tables[0].Rows[0]["Wham"].ToString().Trim();
                txtCreditCard.Text = ds.Tables[0].Rows[0]["RevenueCreditCard"].ToString().Trim();
                txtCheck.Text = ds.Tables[0].Rows[0]["RevenueCheck"].ToString().Trim();
                txtCash.Text = ds.Tables[0].Rows[0]["RevenueCash"].ToString().Trim();
                txtInvoice.Text = ds.Tables[0].Rows[0]["RevenueInvoice"].ToString().Trim();
                txtTCreditCard.Text = ds.Tables[0].Rows[0]["TipCreditCard"].ToString().Trim();
                txtTCheck.Text = ds.Tables[0].Rows[0]["TipCheck"].ToString().Trim();
                txtTCash.Text = ds.Tables[0].Rows[0]["TipCash"].ToString().Trim();
                txtTInvoice.Text = ds.Tables[0].Rows[0]["TipInvoice"].ToString().Trim();
                txtPCreditCard.Text = ds.Tables[0].Rows[0]["PriorCreditCard"].ToString().Trim();
                txtPCheck.Text = ds.Tables[0].Rows[0]["PriorCheck"].ToString().Trim();
                txtPCash.Text = ds.Tables[0].Rows[0]["PriorCash"].ToString().Trim();
                txtAppDate.Text = ds.Tables[0].Rows[0]["NextAppointmentDate"].ToString().Trim();
                txtAppTime.Text = ds.Tables[0].Rows[0]["NextAppointmentTime"].ToString().Trim();
                txtFleaNTick22lbs.Text = ds.Tables[0].Rows[0]["FleaTick22"].ToString().Trim();
                txtFleaNTick44lbs.Text = ds.Tables[0].Rows[0]["FleaTick44"].ToString().Trim();
                txtFleaNTick88lbs.Text = ds.Tables[0].Rows[0]["FleaTick88"].ToString().Trim();
                txtFleaNTick132lbs.Text = ds.Tables[0].Rows[0]["FleaTick132"].ToString().Trim();
                txtFleaNTickCatInv.Text = ds.Tables[0].Rows[0]["FleaTickcAT"].ToString().Trim();
                txtToothbrushes.Text = ds.Tables[0].Rows[0]["Toothbrushes"].ToString().Trim();
                txtWham2.Text = ds.Tables[0].Rows[0]["WhamInv"].ToString().Trim();
                txtTowels.Text = ds.Tables[0].Rows[0]["Towels"].ToString().Trim();
                txtCottonSwabs.Text = ds.Tables[0].Rows[0]["CottonSwabs"].ToString().Trim();
                txtPaperT.Text = ds.Tables[0].Rows[0]["PaperTowels"].ToString().Trim();
                txtGarbageBags.Text = ds.Tables[0].Rows[0]["GarbageBags"].ToString().Trim();
                txtTreats.Text = ds.Tables[0].Rows[0]["Treats"].ToString().Trim();
                txtVetWrap.Text = ds.Tables[0].Rows[0]["VetWrap"].ToString().Trim();
                txtWipes.Text = ds.Tables[0].Rows[0]["Wipes"].ToString().Trim();
                txtEnvelopes.Text = ds.Tables[0].Rows[0]["Envelopes"].ToString().Trim();
                txtReceipts.Text = ds.Tables[0].Rows[0]["Receipts"].ToString().Trim();
                txtBusinessCards.Text = ds.Tables[0].Rows[0]["BusinessCards"].ToString().Trim();
                txtProductPrice.Text = ds.Tables[0].Rows[0]["ProductPrice"].ToString().Trim();
                txtSalestax.Text = ds.Tables[0].Rows[0]["SalesTax"].ToString().Trim();
                txtRev01.Text = ds.Tables[0].Rows[0]["Rev01"].ToString().Trim();
                txtCreditCardNo.Text = ds.Tables[0].Rows[0]["CreditCardNo"].ToString().Trim();
                txtCreditCardExp.Text = ds.Tables[0].Rows[0]["CreditCardExpir"].ToString().Trim();
                txtCreditCardName.Text = ds.Tables[0].Rows[0]["CreditCardName"].ToString().Trim();
                txtAddrsOfCC.Text = ds.Tables[0].Rows[0]["CreditCardAddr"].ToString().Trim();
                txtSecurityCode.Text = ds.Tables[0].Rows[0]["SecurityCode"].ToString().Trim();

                //added 16jan13
                txtComments.Text = ds.Tables[0].Rows[0]["Comments"].ToString().Trim();
                txtDrivetime.Text = ds.Tables[0].Rows[0]["Drive_Time"].ToString().Trim();
                txtrPettime.Text = ds.Tables[0].Rows[0]["Pet_Time"].ToString().Trim();

                string[] strSplit = ds.Tables[0].Rows[0]["ServicesForPet"].ToString().Trim().Split(',');
                txtService4Pet1.Text = strSplit.ElementAt(0).Trim();
                txtService4Pet2.Text = strSplit.ElementAt(1).Trim();
                txtService4Pet3.Text = strSplit.ElementAt(2).Trim();
                txtService4Pet4.Text = strSplit.ElementAt(3).Trim();
                txtService4Pet5.Text = strSplit.ElementAt(4).Trim();
                txtService4Pet6.Text = strSplit.ElementAt(5).Trim();

                txtOther1.Text = ds.Tables[0].Rows[0]["Other1"].ToString().Trim();
                txtOther2.Text = ds.Tables[0].Rows[0]["Other2"].ToString().Trim();
                txtOther3.Text = ds.Tables[0].Rows[0]["Other3"].ToString().Trim();
                txtOther4.Text = ds.Tables[0].Rows[0]["Other4"].ToString().Trim();
                txtOther5.Text = ds.Tables[0].Rows[0]["Other5"].ToString().Trim();

                txtMarketing1.Text = ds.Tables[0].Rows[0]["Marketing1"].ToString().Trim();
                txtMarketing2.Text = ds.Tables[0].Rows[0]["Marketing2"].ToString().Trim();
                txtMarketing3.Text = ds.Tables[0].Rows[0]["Marketing3"].ToString().Trim();
                txtMarketing4.Text = ds.Tables[0].Rows[0]["Marketing4"].ToString().Trim();
                txtMarketing5.Text = ds.Tables[0].Rows[0]["Marketing5"].ToString().Trim();

                txtLiquid1.Text = ds.Tables[0].Rows[0]["Liquid1"].ToString().Trim();
                txtLiquid2.Text = ds.Tables[0].Rows[0]["Liquid2"].ToString().Trim();
                txtLiquid3.Text = ds.Tables[0].Rows[0]["Liquid3"].ToString().Trim();
                txtLiquid4.Text = ds.Tables[0].Rows[0]["Liquid4"].ToString().Trim();
                txtLiquid5.Text = ds.Tables[0].Rows[0]["Liquid5"].ToString().Trim();
                txtLiquid6.Text = ds.Tables[0].Rows[0]["Liquid6"].ToString().Trim();
                txtLiquid7.Text = ds.Tables[0].Rows[0]["Liquid7"].ToString().Trim();
                txtLiquid8.Text = ds.Tables[0].Rows[0]["Liquid8"].ToString().Trim();
                txtLiquid9.Text = ds.Tables[0].Rows[0]["Liquid9"].ToString().Trim();
                txtLiquid10.Text = ds.Tables[0].Rows[0]["Liquid10"].ToString().Trim();
                txtLiquid11.Text = ds.Tables[0].Rows[0]["Liquid11"].ToString().Trim();
                txtLiquid12.Text = ds.Tables[0].Rows[0]["Liquid12"].ToString().Trim();
                txtLiquid13.Text = ds.Tables[0].Rows[0]["Liquid13"].ToString().Trim();
                txtLiquid14.Text = ds.Tables[0].Rows[0]["Liquid14"].ToString().Trim();
                txtLiquid15.Text = ds.Tables[0].Rows[0]["Liquid15"].ToString().Trim();
                txtLiquid16.Text = ds.Tables[0].Rows[0]["Liquid16"].ToString().Trim();
                txtLiquid17.Text = ds.Tables[0].Rows[0]["Liquid17"].ToString().Trim();
                txtLiquid18.Text = ds.Tables[0].Rows[0]["Liquid18"].ToString().Trim();
                txtLiquid19.Text = ds.Tables[0].Rows[0]["Liquid19"].ToString().Trim();
                txtLiquid20.Text = ds.Tables[0].Rows[0]["Liquid20"].ToString().Trim();
                txtLiquid21.Text = ds.Tables[0].Rows[0]["Liquid21"].ToString().Trim();
                txtLiquid22.Text = ds.Tables[0].Rows[0]["Liquid22"].ToString().Trim();
                txtLiquid23.Text = ds.Tables[0].Rows[0]["Liquid23"].ToString().Trim();
                txtLiquid24.Text = ds.Tables[0].Rows[0]["Liquid24"].ToString().Trim();
                txtLiquid25.Text = ds.Tables[0].Rows[0]["Liquid25"].ToString().Trim();
            }
        }

        public void BindInventoryLabels()
        {
            ds = ObjGroomer.getInventoryLabels();
            if (ds.Tables[0].Rows.Count > 0)
            {                
                //TextBoxes
                txtLiq1.Text = ds.Tables[0].Rows[0]["Liquid1"].ToString();
                txtLiq2.Text = ds.Tables[0].Rows[0]["Liquid2"].ToString();
                txtLiq3.Text = ds.Tables[0].Rows[0]["Liquid3"].ToString();
                txtLiq4.Text = ds.Tables[0].Rows[0]["Liquid4"].ToString();
                txtLiq5.Text = ds.Tables[0].Rows[0]["Liquid5"].ToString();
                txtLiq6.Text = ds.Tables[0].Rows[0]["Liquid6"].ToString();
                txtLiq7.Text = ds.Tables[0].Rows[0]["Liquid7"].ToString();
                txtLiq8.Text = ds.Tables[0].Rows[0]["Liquid8"].ToString();
                txtLiq9.Text = ds.Tables[0].Rows[0]["Liquid9"].ToString();
                txtLiq10.Text = ds.Tables[0].Rows[0]["Liquid10"].ToString();
                txtLiq11.Text = ds.Tables[0].Rows[0]["Liquid11"].ToString();
                txtLiq12.Text = ds.Tables[0].Rows[0]["Liquid12"].ToString();
                txtLiq13.Text = ds.Tables[0].Rows[0]["Liquid13"].ToString();
                txtLiq14.Text = ds.Tables[0].Rows[0]["Liquid14"].ToString();
                txtLiq15.Text = ds.Tables[0].Rows[0]["Liquid15"].ToString();
                txtLiq16.Text = ds.Tables[0].Rows[0]["Liquid16"].ToString();
                txtLiq17.Text = ds.Tables[0].Rows[0]["Liquid17"].ToString();
                txtLiq18.Text = ds.Tables[0].Rows[0]["Liquid18"].ToString();
                txtLiq19.Text = ds.Tables[0].Rows[0]["Liquid19"].ToString();
                txtLiq20.Text = ds.Tables[0].Rows[0]["Liquid20"].ToString();
                txtLiq21.Text = ds.Tables[0].Rows[0]["Liquid21"].ToString();
                txtLiq22.Text = ds.Tables[0].Rows[0]["Liquid22"].ToString();
                txtLiq23.Text = ds.Tables[0].Rows[0]["Liquid23"].ToString();
                txtLiq24.Text = ds.Tables[0].Rows[0]["Liquid24"].ToString();
                txtLiq25.Text = ds.Tables[0].Rows[0]["Liquid25"].ToString();
                txtFT22.Text = ds.Tables[0].Rows[0]["FleaTick22"].ToString();
                txtFT44.Text = ds.Tables[0].Rows[0]["FleaTick44"].ToString();
                txtFT88.Text = ds.Tables[0].Rows[0]["FleaTick88"].ToString();
                txtFT132.Text = ds.Tables[0].Rows[0]["FleaTick132"].ToString();
                txtFTCat.Text = ds.Tables[0].Rows[0]["FleaTickCat"].ToString();
                txtToothb.Text = ds.Tables[0].Rows[0]["Toothbrushes"].ToString();
                txtWhamData.Text = ds.Tables[0].Rows[0]["Wham"].ToString();
                txtTowelsData.Text = ds.Tables[0].Rows[0]["Towels"].ToString();
                txtTreatsData.Text = ds.Tables[0].Rows[0]["Treats"].ToString();
                txtEarWipes.Text = ds.Tables[0].Rows[0]["Wipes"].ToString();
                txtCottonSwabsData.Text = ds.Tables[0].Rows[0]["CottonSwabs"].ToString();
                txtVetWrapData.Text = ds.Tables[0].Rows[0]["VetWrap"].ToString();
                txtPaperTowels.Text = ds.Tables[0].Rows[0]["PaperTowels"].ToString();
                txtGarbageBagsData.Text = ds.Tables[0].Rows[0]["GarbageBags"].ToString();
                txtReceiptsData.Text = ds.Tables[0].Rows[0]["Receipts"].ToString();
                txtEnvelopesData.Text = ds.Tables[0].Rows[0]["Envelopes"].ToString();
                txtBusinessCardsData.Text = ds.Tables[0].Rows[0]["BusinessCards"].ToString();
                txtOther1Data.Text = ds.Tables[0].Rows[0]["Other1"].ToString();
                txtOther2Data.Text = ds.Tables[0].Rows[0]["Other2"].ToString();
                txtOther3Data.Text = ds.Tables[0].Rows[0]["Other3"].ToString();
                txtOther4Data.Text = ds.Tables[0].Rows[0]["Other4"].ToString();
                txtOther5Data.Text = ds.Tables[0].Rows[0]["Other5"].ToString();
                txtMarketing1Data.Text = ds.Tables[0].Rows[0]["Marketing1"].ToString();
                txtMarketing2Data.Text = ds.Tables[0].Rows[0]["Marketing2"].ToString();
                txtMarketing3Data.Text = ds.Tables[0].Rows[0]["Marketing3"].ToString();
                txtMarketing4Data.Text = ds.Tables[0].Rows[0]["Marketing4"].ToString();
                txtMarketing5Data.Text = ds.Tables[0].Rows[0]["Marketing5"].ToString();
            }
        }

        public void ErrMessage(string Message)
        {

            lblError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        public void SuccesfullMessage(string Message)
        {

            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditExcel.aspx");
        }
    }
