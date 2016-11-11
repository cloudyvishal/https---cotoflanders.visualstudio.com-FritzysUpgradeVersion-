using System;
using System.Diagnostics;

public partial class RDPServer : System.Web.UI.Page
{
    Process process;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnConnect_Click(object sender, EventArgs e)
    {
         string executable = Environment.ExpandEnvironmentVariables(@"mstsc.exe");
         string ServerIP ="208.109.218.160";
            if (executable != null)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = executable;
                startInfo.Arguments = "/v " + ServerIP;
                startInfo.UseShellExecute = false;
                process = Process.Start(startInfo);
                
            }
           
        }
    
}
