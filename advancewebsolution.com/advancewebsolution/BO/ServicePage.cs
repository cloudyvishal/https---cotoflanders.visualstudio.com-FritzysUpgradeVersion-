using HicPicDataAccess;
using System.Data;
using System.Data.SqlClient;

namespace advancewebtosolution.BO
{
    public class ServicePage
    {
        public ServicePage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet GetServicePageAdmin(int UserType)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetServicePageAdmin", new SqlParameter[] { new SqlParameter("@UserType", UserType) });
            DB.Dispose();
            return ds;
        }


        public void UpdateServicePageServices(int ServiceID, string Title, string Description, string ImageName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateServicePageServices", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID), new SqlParameter("@Title", Title), new SqlParameter("@Description", Description), new SqlParameter("@ImageName", ImageName) });
            DB.Dispose();
        }

        public DataSet GetServicePageServiceDetail(int ServiceID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetServicePageServiceDetail", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID) });
            DB.Dispose();
            return ds;
        }
    }
}