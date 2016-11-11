using advancewebtosolution.BO;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class MB_Controls_Product_Flea : System.Web.UI.UserControl
{
    advancewebtosolution.BO.Products objProducts = new advancewebtosolution.BO.Products();
    #region Bind data
    public void BindData()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = objProducts.GetAllProductsFleaFront();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dlProducts.Visible = true;
                dlProducts.DataSource = ds.Tables[0];
                dlProducts.DataBind();
            }
            else
            {
                dlProducts.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void dlProducts_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if ((e.Item.ItemType != ListItemType.Header) && (e.Item.ItemType != ListItemType.Footer))
            {
                Label lblImageName = (Label)e.Item.FindControl("lblImage");
                HtmlImage ImgProduct = (HtmlImage)e.Item.FindControl("ImgProduct");

                string imagepath = Session["HomePath"].ToString() + "StoreData/Product/" + lblImageName.Text;
                string fulpath = ContentManager.GetPhysicalPath(imagepath);
                if (System.IO.File.Exists(fulpath))
                {
                    ImgProduct.Src = Session["HomePath"].ToString() + "StoreData/Product/" + lblImageName.Text;
                }
                else
                {
                    //ImgProduct.Src = Session["HomePath"] + "StoreData/Product/Not.jpg";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}