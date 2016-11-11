using HicPicDataAccess;
using System;
using System.Data.SqlClient;

namespace advancewebtosolution.BO
{
    public class dbRestore
    {
        public dbRestore()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void InserInDBTable(string dbbkname, string extname, string dbrestorepath)
        {
            try
            {
                DBConnection DB = new DBConnection();
                DB.ExecuteNonQuery("sp_RestoreDb", new SqlParameter[] {
                    new SqlParameter("@dbbkname", dbbkname),new SqlParameter("@extname", extname),
            new SqlParameter("@dbrestorepath",dbrestorepath)});

                DB.Dispose();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }


    }
}