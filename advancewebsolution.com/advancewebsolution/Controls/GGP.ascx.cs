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

public partial class Controls_GGP : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnGift.ImageUrl = Session["HomePath"] + "Images/giftcard.jpg";
        btnGrommer.ImageUrl = Session["HomePath"] + "Images/btn_groomers_blog.jpg";
        btnPetLover.ImageUrl = Session["HomePath"] + "Images/btn_pet_lovers_blog.jpg";
        btnAppointment.ImageUrl = Session["HomePath"] + "Images/make_appointment_now.jpg";
    }
}
