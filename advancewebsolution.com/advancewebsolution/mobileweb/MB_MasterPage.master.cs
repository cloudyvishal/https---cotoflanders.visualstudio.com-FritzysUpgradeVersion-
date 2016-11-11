using System;
using System.Data;
using System.Xml;

public partial class MB_MasterPage : System.Web.UI.MasterPage
{
    /*
         *  Session["MemberName"] = Use for Registered User Name
         *  Session["UserID"] = Used For database User ID 
         *  Session["IsLogin"] used for to chaeck User is login or not 
         *  Session["UserType"]  Used for User type that is 
         *  1 - Cat User
         *  2 - Dog User 
         *  3 - Cat-Dog User 
         *  Default Cat-Dog User 
         *  Cookies["IsLogin"] is used to check whether user is login or not which will work irrespective to remember me on this PC
         */
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string Name;

            if (Session["UserID"] != null)
            {
                dvLogin.Visible = true;
                dvLogoutusers.Visible = false;
            }
            else
            {
                dvLogoutusers.Visible = true;
                dvLogin.Visible = false;
                Session["UserType"] = "4";
            }

            string path = Convert.ToString(Session["HomePath"]);
            Name = (string)Session["UserType"];
            string xmlfile = path + "banners_Cat1.xml";

            //string FileName = xmlfile;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlfile);

            int i = 0;
            XmlNodeList xnList = xmlDoc.SelectNodes("/rotator/bannerName/banners/banner");
            foreach (XmlNode node in xnList)
            {
                if (node["BannerId"] != null)
                {
                    switch (Convert.ToInt32(Name))
                    {
                        //Unregistered User
                        case 4:
                            string homepath = node["PageNames"].InnerText;
                            Name = "0";
                            if (homepath == "Home1")
                            {
                                string priority = node["BannerId"].InnerText;
                                string firstName = node["link"].InnerText;
                                string lastName = node["virtualmobilepath1"].InnerText;
                                int length = firstName.Length;
                                int last = firstName.LastIndexOf("=");
                                string value = firstName.Substring(last + 1);

                                if (Convert.ToInt32(value) == Convert.ToInt32(Name))
                                {
                                    if (int.Parse(priority) > 0)
                                    {
                                        if (i == 0)
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' class='active' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }
                                        else
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }

                                        XmlElement xmlElement = xmlDoc.DocumentElement;
                                        XmlNodeList FirstImage = xmlElement.ChildNodes;
                                        DataSet dataset = new DataSet();
                                        dataset.ReadXml(path + "banners_Cat1.xml");
                                        Name = "4";
                                        i++;
                                    }
                                    //}
                                }
                            }
                            break;
                        //Registered Cat User
                        case 1:
                            string homepath1 = node["PageNames"].InnerText;
                            if (homepath1 == "Home2")
                            {
                                string priority = node["BannerId"].InnerText;
                                string firstName = node["link"].InnerText;
                                string lastName = node["virtualmobilepath1"].InnerText;
                                int length = firstName.Length;
                                int last = firstName.LastIndexOf("=");
                                string value = firstName.Substring(last + 1);
                                if (Convert.ToInt32(value) == Convert.ToInt32(Name))
                                {
                                    if (int.Parse(priority) > 0)
                                    {
                                        if (i == 0)
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' class='active' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }
                                        else
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }

                                        XmlElement xmlElement = xmlDoc.DocumentElement;
                                        XmlNodeList FirstImage = xmlElement.ChildNodes;
                                        DataSet dataset = new DataSet();
                                        dataset.ReadXml(path + "banners_Cat1.xml");
                                        i++;
                                    }
                                    // }
                                }
                            }
                            break;
                        //Registered Dog User
                        case 2:
                            string homepath2 = node["PageNames"].InnerText;
                            if (homepath2 == "Home3")
                            {
                                string priority = node["BannerId"].InnerText;
                                string firstName = node["link"].InnerText;
                                string lastName = node["virtualmobilepath1"].InnerText;
                                int length = firstName.Length;
                                int last = firstName.LastIndexOf("=");
                                string value = firstName.Substring(last + 1);
                                if (Convert.ToInt32(value) == Convert.ToInt32(Name))
                                {
                                    if (int.Parse(priority) > 0)
                                    {
                                        if (i == 0)
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' class='active' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }
                                        else
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }

                                        XmlElement xmlElement = xmlDoc.DocumentElement;
                                        XmlNodeList FirstImage = xmlElement.ChildNodes;
                                        DataSet dataset = new DataSet();
                                        dataset.ReadXml(path + "banners_Cat1.xml");
                                        i++;
                                    }
                                }
                            }
                            break;
                        //Registered Cat & Dog User
                        case 3:
                            string homepath3 = node["PageNames"].InnerText;
                            if (homepath3 == "Home4")
                            {
                                string priority = node["BannerId"].InnerText;
                                string firstName = node["link"].InnerText;
                                string lastName = node["virtualmobilepath1"].InnerText;
                                int length = firstName.Length;
                                int last = firstName.LastIndexOf("=");
                                string value = firstName.Substring(last + 1);
                                if (Convert.ToInt32(value) == Convert.ToInt32(Name))
                                {
                                    if (int.Parse(priority) > 0)
                                    {
                                        if (i == 0)
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' class='active' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }
                                        else
                                        {
                                            homebanner.InnerHtml += "<img style='cursor:pointer;' src='" + lastName + "' height='124' width='320' onclick='window.location.href=\"MB_PrintCoupon.aspx\"'/>";
                                        }

                                        XmlElement xmlElement = xmlDoc.DocumentElement;
                                        XmlNodeList FirstImage = xmlElement.ChildNodes;
                                        DataSet dataset = new DataSet();
                                        dataset.ReadXml(path + "banners_Cat1.xml");
                                        i++;
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }
        catch (Exception ex) { throw ex; }
    }
}
