using advancewebtosolution.BO;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace advancewebtosolution
{
    public partial class Admin_Baner_ReadXmml : System.Web.UI.Page
    {
        PagedDataSource pgds = new PagedDataSource();
        string PageName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PageName"] != null)
            {
                PageName = Convert.ToString(Request.QueryString["PageName"]);

            }
            if (!IsPostBack)
            {
                BindData();
            }

        }
        private void BindData()
        {

            string myXMLfile = ContentManager.GetPhysicalPath(Session["HomePath"].ToString()) + "banners_Cat1.xml";

            DataSet mydataset = new DataSet();
            System.IO.FileStream fsReadXml = new System.IO.FileStream
                (myXMLfile, System.IO.FileMode.Open);
            try
            {
                mydataset.ReadXml(fsReadXml);
                string myName = PageName;
                DataTable dt = null;
                if (mydataset.Tables.Count > 0)
                {

                    DataView dv = new DataView(mydataset.Tables[3]);
                    dv.RowFilter = "PageNames ='" + myName + "'";
                    dt = dv.ToTable();
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                pgds.AllowPaging = true;
                pgds.PageSize = 1000;
                pgds.DataSource = ds.Tables[0].DefaultView;
                //lblMsg.Text = "";
                dtlPhoto.Visible = true;
                dtlPhoto.DataSource = pgds;
                dtlPhoto.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                fsReadXml.Close();
            }

        }

        protected void dtlPhotoCategory_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblPhoto = (Label)e.Item.FindControl("lblFileName");
                HtmlImage imgPhoto = (HtmlImage)e.Item.FindControl("ImgShow");
                string ss = lblPhoto.Text;
                string PhotoPath1 = ss.Replace("..", "~");
                string PhotoPath = ContentManager.GetPhysicalPath(ConfigurationManager.AppSettings["HomePath"].ToString()) + PhotoPath1.Trim();
                imgPhoto.Src = PhotoPath1;
            }
        }


    }
}