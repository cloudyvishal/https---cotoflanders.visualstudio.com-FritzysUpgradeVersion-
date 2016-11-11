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
using System.IO;
using advancewebtosolution.BO;

public partial class Admin_FileManager : System.Web.UI.Page
{
    public void BindData()
    {
        #region region file
        string physicalpath = ContentManager.GetPhysicalPath(Session["HomePath"] + "StoreData/StaticeContent");
        DirectoryInfo dir = new DirectoryInfo(physicalpath);
        FileInfo[] jpgfiles = dir.GetFiles();
        DataSet ds = new DataSet();
        DataTable dt = ds.Tables.Add("ThumbImages");
        dt.Columns.Add("ImageName", typeof(string));
        dt.Columns.Add("FileSize", typeof(decimal));
        dt.Columns.Add("FileType", typeof(string));
        dt.Columns.Add("LastModified", typeof(string));
        dt.Columns.Add("fullpath", typeof(string));

        foreach (FileInfo f in jpgfiles)
        {
            string fullpath = Session["HomePath"] + "StoreData" + "//" + f.Name;
            string ext = f.Extension;
            string filetype = ext.Replace(".", "") + "";
            dt.Rows.Add(new object[] { f.Name, Convert.ToDecimal(f.Length) / 1000, filetype, f.LastWriteTime, fullpath });
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdFileManager.Visible = true;

            GrdFileManager.DataSource = ds.Tables[0];
            GrdFileManager.DataBind();
        }
        else
        {
            GrdFileManager.Visible = false;
        }
        #endregion
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
}
 