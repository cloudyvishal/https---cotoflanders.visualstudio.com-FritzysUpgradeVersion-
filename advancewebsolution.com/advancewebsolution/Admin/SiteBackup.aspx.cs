using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.IO.Compression;
using Ionic.Zip;
using advancewebtosolution.BO;
using System.Collections.Generic;
using System.Net;
using System.Web;

public partial class SiteBackup : System.Web.UI.Page
{
    #region Constructor
    public SiteBackup()
    {
        //create if not exists
        if (!Directory.Exists(Server.MapPath("~/SiteBackUp")))
            Directory.CreateDirectory(Server.MapPath("~/SiteBackUp"));
        if (!Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings["DLPathNew"])))
            Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings["DLPathNew"]));
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void SuccesfullMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    public void ErrorMessage(string Message)
    {
        divError.Visible = true;
        lblError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }

    #region Create and download website Backup
    protected void btnSiteDownload_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.BufferOutput = false;
    
        string sitebkp = Request.PhysicalApplicationPath.ToString();

        string backupFileName = "FritzyCodeBackup" + DateTime.Now.ToString("yyyy-MMM-dd-HHmmss") + ".zip";

        string fileStoragePath = sitebkp + "SiteBackUp\\" + backupFileName;
       
        ZipFile zip = new ZipFile(backupFileName);

        zip.AddDirectory(sitebkp); // AddDirectory recurses subdirectories

        zip.Save(fileStoragePath);

        SuccesfullMessage("Website backup Successfully Downloaded.");
        Response.Redirect(Session["HomePath"].ToString() + "SiteBackUp//" + backupFileName);
    }
    #endregion

    #region Create db backup and save
    protected void btndatabasedwn_Click(object sender, EventArgs e)
    {
        try
        {
            Groomer obj = new Groomer();
            string dbbkp = Server.MapPath("~");
            string dbbackupFileName = "Fritzyslive_new" + DateTime.Now.ToString("yyyy-MMM-dd-HHmmss") + ".bak";
            string fileStoragePath = dbbkp + "Download\\" + dbbackupFileName;
            obj.CreateDBBackup(fileStoragePath);
            SuccesfullMessage("Database backup completed successfully.");
        }
        catch (Exception ex)
        {
            ErrorMessage("Exception :" + ex.Message);
        }
    }
    #endregion

    #region download  recent db backup created
    protected void btnDatabaseDownload_Click(object sender, EventArgs e)
    {
        try {
            string filename = "";
            DirectoryInfo info1 = new DirectoryInfo(Server.MapPath(ConfigurationManager.AppSettings["DLPathNew"]));
            SortedDictionary<DateTime, string> dbfiles = new SortedDictionary<DateTime, string>();

            foreach (FileInfo f1 in info1.GetFiles())
            {
                if (f1.Extension == ".bak")
                {
                    dbfiles.Add(f1.CreationTime, f1.Name);
                }
            }
            filename = dbfiles.OrderByDescending(a => a.Key).FirstOrDefault().Value;

            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            // string filePath = Session["HomePath"].ToString() + "Download/" + filename;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            byte[] data = req.DownloadData(Server.MapPath("~/Download/" + filename));
            response.BinaryWrite(data);
            response.End();
        }
        catch
        {
            ErrorMessage("Sorry No Backup files found Please create backup first..");
        }
    }
    #endregion

    private void ZipFile(string srcFile, string dstFile)
    {
        FileStream fsIn = null; // will open and read the srcFile
        FileStream fsOut = null; // will be used by the GZipStream for output to the dstFile
        GZipStream zip = null;
        byte[] buffer;
        int count = 0;

        try
        {
            fsOut = new FileStream(dstFile, FileMode.Create, FileAccess.Write, FileShare.None);
            zip = new GZipStream(fsOut, CompressionMode.Compress, true);

            fsIn = new FileStream(srcFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            buffer = new byte[fsIn.Length];
            count = fsIn.Read(buffer, 0, buffer.Length);
            fsIn.Close();
            fsIn = null;

            // compress to the destination file
            zip.Write(buffer, 0, buffer.Length);
        }
        catch (Exception ex)
        {
            // handle or display the error 
            System.Diagnostics.Debug.Assert(false, ex.ToString());
        }
        finally
        {
            if (zip != null)
            {
                zip.Close();
                zip = null;
            }
            if (fsOut != null)
            {
                fsOut.Close();
                fsOut = null;
            }
            if (fsIn != null)
            {
                fsIn.Close();
                fsIn = null;
            }
        }
    }
}
