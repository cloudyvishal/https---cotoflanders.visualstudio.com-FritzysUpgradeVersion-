using advancewebtosolution.BO;
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_Product_Flea : System.Web.UI.UserControl
{
    advancewebtosolution.BO.Products ObjProducts = new advancewebtosolution.BO.Products();
    #region Bind data
    public void BindData()
    {
       DataSet ds = new DataSet();
        ds = ObjProducts.GetAllProductsFleaFront();
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
            }
        }
    }
}