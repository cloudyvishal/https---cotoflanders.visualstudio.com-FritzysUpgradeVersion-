using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CyberSourceStore
{
	/// <summary>
	/// Summary description for DisplayError.
	/// </summary>
	public partial class DisplayError : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected string mMessage;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Exception exception = (Exception) Session["Exception"];
			if (exception != null)
			{
				mMessage = ConvertNewLinesToHTML( exception.ToString() );
				Session.Remove( "Exception" );
			}
			else
			{
				mMessage = (string) Session["ErrorMessage"];
				Session.Remove( "ErrorMessage" );
			}
			
		}

		private static string ConvertNewLinesToHTML( string str )
		{
			return( str.Replace( Environment.NewLine, "<br>" ) );
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
