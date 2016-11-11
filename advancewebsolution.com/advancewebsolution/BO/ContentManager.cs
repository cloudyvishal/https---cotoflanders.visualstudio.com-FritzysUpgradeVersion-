using System.IO;
using System.Web;

namespace advancewebtosolution.BO
{
    public class ContentManager
    {
        public ContentManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static void SaveContent(string fileContent, string filename)
        {
            string FilePath = System.Web.HttpContext.Current.Session["StaticContentPhysicalPath"].ToString();

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            string FullPath = FilePath + filename;
            FileStream file = new FileStream(FullPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(fileContent);
            sw.Close();
            file.Close();
        }

        public static void SaveRightHandSectionContent(string fileContent, string filename)
        {

            string FilePath = System.Web.HttpContext.Current.Session["HomePath"] + "StoreData/";
            FilePath = GetPhysicalPath(FilePath);
            System.Web.HttpContext.Current.Session["StaticSectionPhysicalPath"] = FilePath;

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            string FullPath = FilePath + filename;
            FileStream file = new FileStream(FullPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(fileContent);
            sw.Close();
            file.Close();
        }

        public static string GetFileContent(string FileName)
        {
            string content = "";
            string appPath = System.Web.HttpContext.Current.Session["StaticContentPhysicalPath"].ToString();
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

        public static string GetRightHandSectionFileContent(string FileName)
        {
            string content = "";

            string appPath = System.Web.HttpContext.Current.Session["HomePath"] + "StoreData/";
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

        public static string GetFileContentRightSection(string FileName)
        {
            string content = "";
            string appPath = System.Web.HttpContext.Current.Session["StaticContentPhysicalPath"].ToString();
            string FilePath = appPath + FileName;

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


        public static string GetFileContentView(string FileName)
        {
            string content = "";
            string appPath = System.Web.HttpContext.Current.Session["StaticContentPhysicalPath"].ToString();
            string FilePath = FileName;

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
            FileInfo f = new FileInfo(FilePath);//D:\Development_Work\EdCode\Code\advancedweb2solutions.com\StoreData\StaticeContent\FooterContent.htm

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

        public static string GetFileContent1(string FileName)
        {
            string content = "";
            string appPath = System.Web.HttpContext.Current.Session["ProductContentPhysicalPath"].ToString();
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


        public static void SaveContent1(string fileContent, string filename)
        {

            string FilePath = System.Web.HttpContext.Current.Session["ProductContentPhysicalPath"].ToString();

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            string FullPath = FilePath + "\\" + filename;
            FileStream file = new FileStream(FullPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(fileContent);
            sw.Close();
            file.Close();
        }

        public static void SetSession(HttpContext context, int StoreID)
        {
            context.Session["StaticContentPath"] = context.Session["HomePath"] + "storedata/customcontent/";
            context.Session["StaticContentPhysicalPath"] = GetPhysicalPath((string)context.Session["StaticContentPath"]);

            context.Session["StaticRightHandSectionPath"] = context.Session["HomePath"] + "StoreData/";
            context.Session["StaticRightHandSectionPhysicalPath"] = GetPhysicalPath((string)context.Session["StaticRightHandSectionPath"]);


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

        public string GetPhysicalPath1(string virtualPath)
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

        public static string GetStaticeContent(string FileName)
        {
            string content = "";

            string appPath = System.Web.HttpContext.Current.Session["HomePath"] + "StoreData/StaticeContent/";
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

        public static string GetPhysicalPathnew(string dbrestorepath)
        {
            string filepath = "";
            if (dbrestorepath.IndexOf("localhost:") >= 0)
            {
                string path = dbrestorepath.Replace(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host, "");
                if (path.IndexOf(":") >= 0)
                {
                    int lenindex = path.IndexOf('/');
                    path = path.Remove(0, lenindex);
                }
                filepath = HttpContext.Current.Server.MapPath(path.Replace(HttpContext.Current.Request.Url.Scheme + "://www." + HttpContext.Current.Request.Url.Host, ""));
            }
            else
            {
                string path = dbrestorepath.Replace(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host, "");
                filepath = HttpContext.Current.Server.MapPath(path.Replace(HttpContext.Current.Request.Url.Scheme + "://www." + HttpContext.Current.Request.Url.Host, ""));
            }
            return filepath;
        }
    }
}