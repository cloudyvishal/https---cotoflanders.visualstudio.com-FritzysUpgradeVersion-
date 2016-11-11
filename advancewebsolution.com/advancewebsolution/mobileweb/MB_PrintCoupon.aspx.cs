using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using advancewebtosolution.BO;

public partial class Mobile_MB_PrintCoupon : System.Web.UI.Page
{
    int PageId = 0;
    int UserId = 0;
    public void ErrMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string Name;
            if (!IsPostBack)
            {
                Name = (string)Session["UserType"];
                string ImagePath = "";
                if (Name == "4")
                {

                    PageId = 0;
                    UserId = 0;
                }
                if (Name == "1")
                {

                    PageId = 0;
                    UserId = 1;
                }
                if (Name == "2")
                {

                    PageId = 0;
                    UserId = 2;
                }
                if (Name == "3")
                {

                    PageId = 0;
                    UserId = 3;
                }

                Banner objB = new Banner();
                DataSet ds = new DataSet();
                ds = objB.GetPageIdandUserId(PageId, UserId);

                Banner newObj = new Banner();
                DataSet dsCoupon = newObj.GetDefaultCopon(PageId, UserId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dlCoupon.Visible = true;
                    dvNocoupon.Visible = false;
                    dvDefaultCoupon.Visible = false;
                    dlCoupon.DataSource = ds;
                    dlCoupon.DataBind();
                }
                else if (dsCoupon.Tables[0].Rows.Count > 0)
                {
                    dlCoupon.Visible = false;
                    dvNocoupon.Visible = false;
                    dvDefaultCoupon.Visible = true;
                    ImagePath = Session["HomePath"] + "StoreData/BannerNew/" + dsCoupon.Tables[0].Rows[0]["bannername"].ToString();
                    string imagepath = ImagePath;
                    string fulpath = ContentManager.GetPhysicalPath(imagepath);
                    if (System.IO.File.Exists(fulpath))
                    {
                        ImgGift.ImageUrl = imagepath;
                    }
                    else
                    {
                        dvNocoupon.Visible = true;
                        dlCoupon.Visible = false;
                        dvDefaultCoupon.Visible = false;
                    }
                }
                else
                {
                    dvNocoupon.Visible = true;
                    dlCoupon.Visible = false;
                    dvDefaultCoupon.Visible = false;
                }
            }
        }
        catch (Exception ex) { throw ex; }
    }
    protected void dlCoupon_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            Banner objB = new Banner();
            for (int i = 0; i <= dlCoupon.Items.Count - 1; i++)
            {
                Label lblBannerId = (Label)dlCoupon.Items[i].FindControl("lblBannerId");
                Button btnPrint = (Button)dlCoupon.Items[i].FindControl("btnPrint");
                btnPrint.PostBackUrl = "PrintfinalCoupon.aspx?CouponID=" + lblBannerId.Text;

            }
        }
        catch (Exception ex) { throw ex; }
    }
    protected void dlCoupon_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int BannerId = (int)dlCoupon.DataKeys[e.Item.ItemIndex];
        if (e.CommandName == "Print")
        {
            MessageBox1(string.Concat("PrintfinalCoupon.aspx?&CouponID=", BannerId));
        }
    }

    private void MessageBox1(string strmsg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.open(" + "'" + strmsg + "','popuppage','status=no,toolbar=no,width=850,height=550,menubar=no,resizable=yes,location=no,scrollbars=yes,left=0,top=0'" + ")</script>";
        Page.Controls.Add(lbl);
    }
}
