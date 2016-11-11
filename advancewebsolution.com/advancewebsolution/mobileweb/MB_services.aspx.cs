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

public partial class MB_services : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType"].ToString() == "4")
            {
                if (Request.QueryString["PetID"] != null)
                {
                    if (Request.QueryString["PetID"] == "Cat")
                    {
                        Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                        Control bodyCntrl1 = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl1);
                    }
                    else if (Request.QueryString["PetID"] == "Dog")
                    {
                        Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                        Control bodyCntrl2 = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl2);
                    }

                }
                else
                {
                    Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                    plcServices.Controls.Add(bodyCntrl);

                    Control bodyCntrl2 = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                    plcServices.Controls.Add(bodyCntrl2);
                }
            }
            else
            {

                if (Session["UserType"].ToString() == "3")
                {
                    if (Request.QueryString["PetID"] != null)
                    {
                        if (Request.QueryString["PetID"] == "Cat")
                        {
                            Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl1 = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl1);
                        }
                        else if (Request.QueryString["PetID"] == "Dog")
                        {
                            Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl2 = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl2);
                        }

                    }
                    else
                    {
                        Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                        Control bodyCntrl6 = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl6);
                    }

                }


                if (Session["UserType"].ToString() == "2")
                {
                    if (Request.QueryString["PetID"] != null)
                    {
                        if (Request.QueryString["PetID"] == "Cat")
                        {
                            Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl1 = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl1);
                        }
                        else if (Request.QueryString["PetID"] == "Dog")
                        {
                            Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl2 = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl2);
                        }

                    }
                    else
                    {
                        Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                        Control bodyCntrl2 = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl2);
                    }
                }

                if (Session["UserType"].ToString() == "1")
                {
                    if (Request.QueryString["PetID"] != null)
                    {
                        if (Request.QueryString["PetID"] == "Cat")
                        {
                            Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl1 = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl1);
                        }
                        else if (Request.QueryString["PetID"] == "Dog")
                        {
                            Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                            plcServices.Controls.Add(bodyCntrl);

                            Control bodyCntrl2 = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                            plcServices.Controls.Add(bodyCntrl2);
                        }

                    }
                    else
                    {

                        Control bodyCntrl2 = LoadControl("~/mobileweb/MB_Controls/Services_Cat.ascx");
                        plcServices.Controls.Add(bodyCntrl2);

                        Control bodyCntrl = LoadControl("~/mobileweb/MB_Controls/Services_Dog.ascx");
                        plcServices.Controls.Add(bodyCntrl);

                    }
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}