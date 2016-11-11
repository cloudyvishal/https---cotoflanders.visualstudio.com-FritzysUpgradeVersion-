using System.Web;
using System.IO;
public class ContentManager
{
    public ContentManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string GetPhysicalPath(string virtualPath)
    {
        string filepath = "";
        if (virtualPath.IndexOf("localhost:") >= 0)
        {
            string path = virtualPath.Replace(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host, "");
            if (path.IndexOf(":") >= 0)
            {
                int lenindex = path.IndexOf('/');
                path = path.Remove(0, lenindex);
            }
            filepath = HttpContext.Current.Server.MapPath(path.Replace(HttpContext.Current.Request.Url.Scheme + "://www." + HttpContext.Current.Request.Url.Host, ""));
        }
        else
        {
            string path = virtualPath.Replace(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host, "");
            filepath = HttpContext.Current.Server.MapPath(path.Replace(HttpContext.Current.Request.Url.Scheme + "://www." + HttpContext.Current.Request.Url.Host, ""));
        }
        return filepath;
    }
    public static string GetStaticeContentEmail(string FileName)
    {
        string content = "";

        string appPath = System.Web.HttpContext.Current.Session["HomePath"] + "StoreData/Email/";
        appPath = GetPhysicalPath(appPath);
        System.Web.HttpContext.Current.Session["StaticSectionPhysicalPath"] = appPath;

        string FilePath = appPath + "\\" + FileName;
        if (FilePath.IndexOf(".htm") > 0)
        {
            if (!System.IO.File.Exists(FilePath))
            {
                FilePath = FilePath.Replace(".htm", ".txt");
            }
        }
        else if (FilePath.IndexOf(".txt") > 0)
        {
            if (!System.IO.File.Exists(FilePath))
            {
                FilePath = FilePath.Replace(".txt", ".htm");
            }
        }
        FileInfo f = new FileInfo(FilePath);
        if (f.Exists)
        {
            FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            content = sr.ReadToEnd();
            sr.Close();
            file.Close();
        }
        return content;
    }
}
