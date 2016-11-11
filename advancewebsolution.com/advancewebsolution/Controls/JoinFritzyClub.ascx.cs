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
/*
 
 This user control is use to set images for Join fritzy's club and MyAccount 
 *accourding to the user login status .
 * also on clicking will redirect to respective pages 
 
 */
public partial class Controls_JoinFritzyClub : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberName"] != null)
        {
            ImgRegORMyAccount.ImageUrl = "../images/myaccount.jpg";
            ImgRegORMyAccount.ToolTip = "MY ACCOUNT";
        }
        else
        {
            ImgRegORMyAccount.ImageUrl = "../images/join_fritzys_club.jpg";
            ImgRegORMyAccount.ToolTip = "JOIN FRITZY'S CLUB";
        }
    }

    protected void ImgRegORMyAccount_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["MemberName"] != null)
        {
            Response.Redirect("MyAccount.aspx");
        }
        else
        {
            Response.Redirect("Registration_Basic.aspx");
        }
    }
}
