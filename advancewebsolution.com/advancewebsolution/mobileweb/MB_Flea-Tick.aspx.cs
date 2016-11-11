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
using advancewebtosolution.BO;

public partial class MB_Flea_Tick : System.Web.UI.Page
{
    public void BindData()
    {
        try
        {
            StoreFront ObjStoreFront = new StoreFront();
            DataSet ds = new DataSet();
            if (Session["UserType"].ToString() == "4")
            {
                ds = ObjStoreFront.GetFleaandTickServices(4);
            }
            else
            {
                ds = ObjStoreFront.GetFleaandTickServices(Convert.ToInt32(Session["UserType"].ToString()));
            }

            if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "1"))
            {
                divCatService.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                imgCatservice.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
                imgCatservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();
            }
            if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[1]["PetType"].ToString() == "2"))
            {
                divDogService.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                imgDogservice.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[1]["ImageName"].ToString();
                imgDogservice.ToolTip = ds.Tables[0].Rows[1]["Description"].ToString();
            }
        }
        catch(Exception ex) { throw ex; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType"].ToString() != "0")
            {
                if (!IsPostBack)
                {
                    BindData();
                }
            }
            else
            {
                Session["UserType"] = "4";
                if (!IsPostBack)
                {
                    BindData();
                }
            }
        }
        catch(Exception ex) { throw ex; }
    }
}
