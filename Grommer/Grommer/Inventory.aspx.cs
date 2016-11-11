using System;
using System.Data;

public partial class Inventory : System.Web.UI.Page
{
    string strMsg;
    Groomer ObjGroomer = new Groomer();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        strMsg = Request.QueryString["msg"] != null ? Request.QueryString["msg"] : "";

        if (!IsPostBack)
        {
            if (strMsg == "S") { SuccesfullMessage("Inventory added successfully"); }
            else if (strMsg != "S") { divError.Visible = false; }
        }
        BindInventoryLabels();
    }

    public void BindInventoryLabels()
    {
        ds = ObjGroomer.getInventoryLabels();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblliq1.Text = ds.Tables[0].Rows[0]["Liquid1"].ToString() + ":";
            lblliq2.Text = ds.Tables[0].Rows[0]["Liquid2"].ToString() + ":";
            lblliq3.Text = ds.Tables[0].Rows[0]["Liquid3"].ToString() + ":";
            lblliq4.Text = ds.Tables[0].Rows[0]["Liquid4"].ToString() + ":";
            lblliq5.Text = ds.Tables[0].Rows[0]["Liquid5"].ToString() + ":";
            lblliq6.Text = ds.Tables[0].Rows[0]["Liquid6"].ToString() + ":";
            lblliq7.Text = ds.Tables[0].Rows[0]["Liquid7"].ToString() + ":";
            lblliq8.Text = ds.Tables[0].Rows[0]["Liquid8"].ToString() + ":";
            lblliq9.Text = ds.Tables[0].Rows[0]["Liquid9"].ToString() + ":";
            lblliq10.Text = ds.Tables[0].Rows[0]["Liquid10"].ToString() + ":";
            lblliq11.Text = ds.Tables[0].Rows[0]["Liquid11"].ToString() + ":";
            lblliq12.Text = ds.Tables[0].Rows[0]["Liquid12"].ToString() + ":";
            lblliq13.Text = ds.Tables[0].Rows[0]["Liquid13"].ToString() + ":";
            lblliq14.Text = ds.Tables[0].Rows[0]["Liquid14"].ToString() + ":";
            lblliq15.Text = ds.Tables[0].Rows[0]["Liquid15"].ToString() + ":";
            lblliq16.Text = ds.Tables[0].Rows[0]["Liquid16"].ToString() + ":";
            lblliq17.Text = ds.Tables[0].Rows[0]["Liquid17"].ToString() + ":";
            lblliq18.Text = ds.Tables[0].Rows[0]["Liquid18"].ToString() + ":";
            lblliq19.Text = ds.Tables[0].Rows[0]["Liquid19"].ToString() + ":";
            lblliq20.Text = ds.Tables[0].Rows[0]["Liquid20"].ToString() + ":";
            lblliq21.Text = ds.Tables[0].Rows[0]["Liquid21"].ToString() + ":";
            lblliq22.Text = ds.Tables[0].Rows[0]["Liquid22"].ToString() + ":";
            lblliq23.Text = ds.Tables[0].Rows[0]["Liquid23"].ToString() + ":";
            lblliq24.Text = ds.Tables[0].Rows[0]["Liquid24"].ToString() + ":";
            lblliq25.Text = ds.Tables[0].Rows[0]["Liquid25"].ToString() + ":";
            lblFleaTick22.Text = ds.Tables[0].Rows[0]["FleaTick22"].ToString() + ":";
            lblFleaTick44.Text = ds.Tables[0].Rows[0]["FleaTick44"].ToString() + ":";
            lblFleaTick88.Text = ds.Tables[0].Rows[0]["FleaTick88"].ToString() + ":";
            lblFleaTick132.Text = ds.Tables[0].Rows[0]["FleaTick132"].ToString() + ":";
            lblFleaTickCat.Text = ds.Tables[0].Rows[0]["FleaTickCat"].ToString() + ":";
            lblToothbrushes.Text = ds.Tables[0].Rows[0]["Toothbrushes"].ToString() + ":";
            lblWham.Text = ds.Tables[0].Rows[0]["Wham"].ToString() + ":";
            lblTowels.Text = ds.Tables[0].Rows[0]["Towels"].ToString() + ":";
            lblTreats.Text = ds.Tables[0].Rows[0]["Treats"].ToString() + ":";
            lblCottonPads.Text = ds.Tables[0].Rows[0]["Wipes"].ToString() + ":";
            lblCottonSwabs.Text = ds.Tables[0].Rows[0]["CottonSwabs"].ToString() + ":";
            lblVetWrap.Text = ds.Tables[0].Rows[0]["VetWrap"].ToString() + ":";
            lblPaperTowels.Text = ds.Tables[0].Rows[0]["PaperTowels"].ToString() + ":";
            lblGarbageBags.Text = ds.Tables[0].Rows[0]["GarbageBags"].ToString() + ":";
            lblReceipts.Text = ds.Tables[0].Rows[0]["Receipts"].ToString() + ":";
            lblEnvelopes.Text = ds.Tables[0].Rows[0]["Envelopes"].ToString() + ":";
            lblBusinessCards.Text = ds.Tables[0].Rows[0]["BusinessCards"].ToString() + ":";
            lblOther1.Text = ds.Tables[0].Rows[0]["Other1"].ToString() + ":";
            lblOther2.Text = ds.Tables[0].Rows[0]["Other2"].ToString() + ":";
            lblOther3.Text = ds.Tables[0].Rows[0]["Other3"].ToString() + ":";
            lblOther4.Text = ds.Tables[0].Rows[0]["Other4"].ToString() + ":";
            lblOther5.Text = ds.Tables[0].Rows[0]["Other5"].ToString() + ":";
            lblMarketing1.Text = ds.Tables[0].Rows[0]["Marketing1"].ToString() + ":";
            lblMarketing2.Text = ds.Tables[0].Rows[0]["Marketing2"].ToString() + ":";
            lblMarketing3.Text = ds.Tables[0].Rows[0]["Marketing3"].ToString() + ":";
            lblMarketing4.Text = ds.Tables[0].Rows[0]["Marketing4"].ToString() + ":";
            lblMarketing5.Text = ds.Tables[0].Rows[0]["Marketing5"].ToString() + ":";
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

    public void GroomerAddInventroyRequest()
    {
        try
        {
            Groomer ObjUser = new Groomer();
            string todaysdate = Convert.ToString(System.DateTime.Now);
            int i = ObjUser.GroomerAddInventroyRequest(GId, txtFleaTick22.Text, txtFleaTick44.Text, txtFleaTick88.Text, txtFleaTick132.Text, txtFleaTickCat.Text, txtToothbrushes.Text, txtWham.Text, txtTowels.Text, txtCottonPads.Text, txtCottonSwabs.Text, txtPaperTowels.Text, txtGarbageBags.Text, txtTreats.Text, txtVetWrap.Text, txtCottonPads.Text, "", "", txtEnvelopes.Text, txtReceipts.Text, txtBusinessCards.Text, "", "", "", "", "", "", "", txtOther1.Text.Trim(), txtOther2.Text.Trim(), txtOther3.Text.Trim(), txtOther4.Text.Trim(), txtOther5.Text.Trim(), txtMarketing1.Text.Trim(), txtMarketing2.Text.Trim(), txtMarketing3.Text.Trim(), txtMarketing4.Text.Trim(), txtMarketing5.Text.Trim(), txtLiquid1.Text.Trim(), txtLiquid2.Text.Trim(), txtLiquid3.Text.Trim(), txtLiquid4.Text.Trim(), txtLiquid5.Text.Trim(), txtLiquid6.Text.Trim(), txtLiquid7.Text.Trim(), txtLiquid8.Text.Trim(), txtLiquid9.Text.Trim(), txtLiquid10.Text.Trim(), txtLiquid11.Text.Trim(), txtLiquid12.Text.Trim(), txtLiquid13.Text.Trim(), txtLiquid14.Text.Trim(), txtLiquid15.Text.Trim(), txtLiquid16.Text.Trim(), txtLiquid17.Text.Trim(), txtLiquid18.Text.Trim(), txtLiquid19.Text.Trim(), txtLiquid20.Text.Trim(), txtLiquid21.Text.Trim(), txtLiquid22.Text.Trim(), txtLiquid23.Text.Trim(), txtLiquid24.Text.Trim(), txtLiquid25.Text.Trim());
            if (i >= 0)
            {
                ObjGroomer.updateExcelExportedInventory(i, 0);
                clearInventory();
                Response.Redirect("Inventory.aspx?msg=S", false);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            GroomerAddInventroyRequest();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void clearInventory()
    {
        txtFleaTick22.Text = "";
        txtFleaTick44.Text = "";
        txtFleaTick88.Text = "";
        txtFleaTick132.Text = "";
        txtFleaTickCat.Text = "";
        txtToothbrushes.Text = "";
        txtWham.Text = "";
        txtTowels.Text = "";
        txtCottonPads.Text = "";
        txtCottonSwabs.Text = "";
        txtPaperTowels.Text = "";
        txtGarbageBags.Text = "";
        txtTreats.Text = "";
        txtVetWrap.Text = "";
        txtEnvelopes.Text = "";
        txtReceipts.Text = "";
        txtBusinessCards.Text = "";
    }

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
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        divError.Visible = false;
        ds = ObjGroomer.getInventoryData(GId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtFleaTick22.Text = ds.Tables[0].Rows[0]["FleaTick22"].ToString();
            txtFleaTick44.Text = ds.Tables[0].Rows[0]["FleaTick44"].ToString();
            txtFleaTick88.Text = ds.Tables[0].Rows[0]["FleaTick88"].ToString();
            txtFleaTick132.Text = ds.Tables[0].Rows[0]["FleaTick132"].ToString();
            txtFleaTickCat.Text = ds.Tables[0].Rows[0]["FleaTickcAT"].ToString();
            txtToothbrushes.Text = ds.Tables[0].Rows[0]["Toothbrushes"].ToString();
            txtWham.Text = ds.Tables[0].Rows[0]["Wham"].ToString();

            txtTowels.Text = ds.Tables[0].Rows[0]["Towels"].ToString();
            txtTreats.Text = ds.Tables[0].Rows[0]["Treats"].ToString();
            txtCottonPads.Text = ds.Tables[0].Rows[0]["CottonPads"].ToString();
            txtCottonSwabs.Text = ds.Tables[0].Rows[0]["CottonSwabs"].ToString();
            txtVetWrap.Text = ds.Tables[0].Rows[0]["VetWrap"].ToString();

            txtPaperTowels.Text = ds.Tables[0].Rows[0]["PaperTowels"].ToString();
            txtGarbageBags.Text = ds.Tables[0].Rows[0]["GarbageBags"].ToString();

            txtReceipts.Text = ds.Tables[0].Rows[0]["Receipts"].ToString();
            txtEnvelopes.Text = ds.Tables[0].Rows[0]["Envelopes"].ToString();
            txtBusinessCards.Text = ds.Tables[0].Rows[0]["BusinessCards"].ToString();
            txtOther1.Text = ds.Tables[0].Rows[0]["Other1"].ToString();
            txtOther2.Text = ds.Tables[0].Rows[0]["Other2"].ToString();
            txtOther3.Text = ds.Tables[0].Rows[0]["Other3"].ToString();
            txtOther4.Text = ds.Tables[0].Rows[0]["Other4"].ToString();
            txtOther5.Text = ds.Tables[0].Rows[0]["Other5"].ToString();

            txtLiquid1.Text = ds.Tables[0].Rows[0]["Liquid1"].ToString();
            txtLiquid2.Text = ds.Tables[0].Rows[0]["Liquid2"].ToString();
            txtLiquid3.Text = ds.Tables[0].Rows[0]["Liquid3"].ToString();
            txtLiquid4.Text = ds.Tables[0].Rows[0]["Liquid4"].ToString();
            txtLiquid5.Text = ds.Tables[0].Rows[0]["Liquid5"].ToString();
            txtLiquid6.Text = ds.Tables[0].Rows[0]["Liquid6"].ToString();
            txtLiquid7.Text = ds.Tables[0].Rows[0]["Liquid7"].ToString();
            txtLiquid8.Text = ds.Tables[0].Rows[0]["Liquid8"].ToString();
            txtLiquid9.Text = ds.Tables[0].Rows[0]["Liquid9"].ToString();
            txtLiquid10.Text = ds.Tables[0].Rows[0]["Liquid10"].ToString();
            txtLiquid11.Text = ds.Tables[0].Rows[0]["Liquid11"].ToString();
            txtLiquid12.Text = ds.Tables[0].Rows[0]["Liquid12"].ToString();
            txtLiquid13.Text = ds.Tables[0].Rows[0]["Liquid13"].ToString();
            txtLiquid14.Text = ds.Tables[0].Rows[0]["Liquid14"].ToString();
            txtLiquid15.Text = ds.Tables[0].Rows[0]["Liquid15"].ToString();
            txtLiquid16.Text = ds.Tables[0].Rows[0]["Liquid16"].ToString();
            txtLiquid17.Text = ds.Tables[0].Rows[0]["Liquid17"].ToString();
            txtLiquid18.Text = ds.Tables[0].Rows[0]["Liquid18"].ToString();
            txtLiquid19.Text = ds.Tables[0].Rows[0]["Liquid19"].ToString();
            txtLiquid20.Text = ds.Tables[0].Rows[0]["Liquid20"].ToString();
            txtLiquid21.Text = ds.Tables[0].Rows[0]["Liquid21"].ToString();
            txtLiquid22.Text = ds.Tables[0].Rows[0]["Liquid22"].ToString();
            txtLiquid23.Text = ds.Tables[0].Rows[0]["Liquid23"].ToString();
            txtLiquid24.Text = ds.Tables[0].Rows[0]["Liquid24"].ToString();
            txtLiquid25.Text = ds.Tables[0].Rows[0]["Liquid25"].ToString();

            txtMarketing1.Text = ds.Tables[0].Rows[0]["Marketing1"].ToString();
            txtMarketing2.Text = ds.Tables[0].Rows[0]["Marketing2"].ToString();
            txtMarketing3.Text = ds.Tables[0].Rows[0]["Marketing3"].ToString();
            txtMarketing4.Text = ds.Tables[0].Rows[0]["Marketing4"].ToString();
            txtMarketing5.Text = ds.Tables[0].Rows[0]["Marketing5"].ToString();
        }
    }
}
