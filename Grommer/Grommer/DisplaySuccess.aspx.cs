using System;
using System.Configuration;
using System.Web;

namespace CyberSourceStore
{
    /// <summary>
    /// Summary description for DisplaySuccess.
    /// </summary>
    public partial class DisplaySuccess : System.Web.UI.Page
    {
        protected string mMessage;

        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (Session["GId"] != null)
            {
                
                string orderNumber = (string)Session["OrderNumber"];
                mMessage = String.Format("Thank you,Your payment transaction has been successful. Your payment number is {0}.  ", orderNumber);


            }
            //	Session.Abandon();
        }

        protected void btndone_Click(object sender, EventArgs e)
        {
            PaymentDoneMessage("Your payment is made for groomer service.");
            Session["OrderNumber"] = null;
            Session["GroomerAppointmentId"] = null;
            Response.Redirect("Dashboard.aspx");

        }
        private void PaymentDoneMessage(string body)
        {
            try
            {
                string Date_time = DateTime.Now.ToString();
                string datenew = Date_time.ToString();
                string Appoinment = Session["GroomerAppointmentId"].ToString();
                string Appoinment_Date = Session["AppointmentDate"].ToString();
                string emailadd = Session["emailid"].ToString();
                string totalprice = Session["totalprice"].ToString();
                string CC_Name1 = Session["CC_Name"].ToString();
                string CC_Name2 = Session["CC_Name1"].ToString();
                string CC_Name = CC_Name1 + "" + CC_Name2;
              
                string Mailbody = ContentManager.GetStaticeContentEmail("PaymentEmail.htm").Replace("~", "#");
                Mailbody = Mailbody.Replace("<!-- Date -->", Date_time);
                Mailbody = Mailbody.Replace("<!-- Appoinment -->", Appoinment);
                Mailbody = Mailbody.Replace("<!-- Appoinment_Date -->", Appoinment_Date);
                Mailbody = Mailbody.Replace("<!-- Total_Amount -->", totalprice);
                Mailbody = Mailbody.Replace("<!-- CC_Name -->", CC_Name);
                Mailbody = Mailbody.Replace("<!-- Details -->", mMessage);
                SendMail ObjMail = new SendMail();


                ObjMail.PaymentMail(ConfigurationManager.AppSettings["FromEmail"].ToString(),
                                    datenew, Appoinment, Appoinment_Date, emailadd, totalprice, CC_Name, mMessage, Mailbody);


            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        protected void Page_Init(object Sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            // Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();

            Response.Expires = -1500;
            Response.CacheControl = "no-cache";
            Response.Cache.SetExpires(DateTime.Now);
        }




        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
