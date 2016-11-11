using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.IO.Compression;
using System.Data.SqlClient;
using System.Threading;

public partial class _Default : System.Web.UI.Page
{

    string constr = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        constr = ConfigurationManager.ConnectionStrings["DBConstr"].ConnectionString;
        if (!IsPostBack)
        {
            // Page.Form.Attributes.Add("enctype", "multipart/form-data");
            lblMessage.Text = "";
        }


    }



    protected void btnrestore_Click(object sender, EventArgs e)
    {


        try
        {
            if (uplfile.HasFile)
            {
                //gets file info
                lblMessage.Text = "";
                decimal Filesize = Convert.ToDecimal(uplfile.PostedFile.ContentLength);
                string Filename = uplfile.FileName;
                string id = Guid.NewGuid().ToString();
                string tempfile = "C:\\Tempdb\\" + Filename;
                string TargetDirectory = "C:\\TempDB\\DBfile" + id + ".bak";
                // string TargetDirectory = "\\xeonserver\\Dot Net\\" + id + ".bak";
                byte[] oBuffer;
                GZipStream oZipper;
                //  string fname = uplfile.PostedFile.FileName;
                if (!(File.Exists(TargetDirectory)))
                {

                    //   File.Copy(fname,tempfile,true);
                    uplfile.PostedFile.SaveAs(tempfile);
                    //using (FileStream inputFile = File.Open(fname, FileMode.Open), outputFile = File.Create(TargetDirectory))
                    using (FileStream inputFile = File.Open(/*uplfile.PostedFile.FileName*/tempfile, FileMode.Open, FileAccess.Read), outputFile = File.Create(TargetDirectory))
                    {
                        using (oZipper = new GZipStream(inputFile, CompressionMode.Decompress))
                        {
                            oBuffer = new byte[inputFile.Length];
                            int counter;
                            while ((counter = oZipper.Read(oBuffer, 0, oBuffer.Length)) != 0)
                            {
                                outputFile.Write(oBuffer, 0, counter);
                            }

                        }

                        oBuffer = null;

                    }

                    //starts the db restore process

                    string backupFile = TargetDirectory;
                    string dbName = ConfigurationManager.AppSettings["DBName"].ToString();
                    string Datafilename = ConfigurationManager.AppSettings["DataFileName"].ToString();
                    string LogFileName = ConfigurationManager.AppSettings["LogFileName"].ToString();
                    string DataFilePath = ConfigurationManager.AppSettings["DataFilePath"].ToString();
                    string LogFilePath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
                    //get this value from session.
                    //if(!(null==Session[""])
                    // {
                    //String uid=Session[""].ToString();
                    //}
                    //hardcoded for test.

                    string uid = null;
                    if (!(null == Session["AdminUserType"]))
                    {
                        uid = Session["AdminUserType"].ToString();
                    }
                    if (dbName != null && Datafilename != null && LogFileName != null && DataFilePath != null && LogFilePath != null && uid != null)
                    {


                        try
                        {

                            using (SqlConnection con = new SqlConnection(constr))
                            {
                                con.Open();
                                string strupdatedb = "Alter database " + dbName + " Set multi_user";

                                SqlCommand cmd = new SqlCommand("SP_InsertLog", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@UploadedBy", SqlDbType.VarChar).Value = uid;
                                cmd.Parameters.Add("@UploadedFileName", SqlDbType.VarChar).Value = Filename;
                                cmd.Parameters.Add("@UploadedFileSize", SqlDbType.Decimal).Value = Filesize;
                                SqlParameter param = new SqlParameter("@LogID", SqlDbType.Int);
                                param.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(param);
                                bool IsSucceded = Convert.ToBoolean(cmd.ExecuteNonQuery());
                                int Log_id = 0;
                                if (IsSucceded.Equals(true))
                                {
                                    // Log_id=param.ParameterName["@LogID"].ToString();
                                    Log_id = Convert.ToInt32(cmd.Parameters["@LogID"].Value);
                                }
                                cmd = new SqlCommand(strupdatedb, con);
                                cmd.CommandType = CommandType.Text;
                                bool issucess = Convert.ToBoolean(cmd.ExecuteNonQuery());

                                //actual restore process starts here.
                                SqlCommand cmdnew = new SqlCommand("RESTOREDB", con);
                                cmdnew.Parameters.Add("@DBName", SqlDbType.VarChar).Value = dbName;
                                cmdnew.Parameters.Add("@BackupFilePath", SqlDbType.VarChar).Value = backupFile;
                                cmdnew.Parameters.Add("@DataName", SqlDbType.VarChar).Value = Datafilename;
                                cmdnew.Parameters.Add("@DataFileName", SqlDbType.VarChar).Value = DataFilePath;
                                cmdnew.Parameters.Add("@LogName", SqlDbType.VarChar).Value = LogFileName;
                                cmdnew.Parameters.Add("@LogFileName", SqlDbType.VarChar).Value = LogFilePath;
                                cmdnew.CommandType = CommandType.StoredProcedure;
                                // cmdnew.CommandTimeout = 2500;         
                                //trans = con.BeginTransaction();
                                //cmdnew.Transaction = trans;
                                bool Success = Convert.ToBoolean(cmdnew.ExecuteNonQuery());
                                //   trans.Commit();



                                lblMessage.Text = "";
                                int Result = 0;
                                if (Success.Equals(true))
                                {

                                    Result = 1;
                                    lblMessage.Text = "Database Restore process completed successfully";
                                }

                                //updates the log entry status for success or not.
                                string cmdstr = "Update DBRestoreLog SET uploadenddatetime=getdate(),IsSucceded=" + Result + " where srno=" + Log_id;
                                cmd = new SqlCommand(cmdstr, con);
                                bool IsSuccess = Convert.ToBoolean(cmd.ExecuteNonQuery());


                            }
                        }
                        catch
                        {
                            lblMessage.Text = "Error occured while processing the request.";
                        }
                    }
                }
                //delete the file after completiong of db restore process.
                File.Delete(TargetDirectory);
                File.Delete(tempfile);

            }



        }
        catch
        {
            lblMessage.Text = "Error occured while processing the request.";
        }



    }
}
