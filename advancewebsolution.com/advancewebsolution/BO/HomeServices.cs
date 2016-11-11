using System;
using HicPicDataAccess;
using System.Data;
using System.Data.SqlClient;

namespace advancewebtosolution.BO
{
    public class HomeServices
    {
        public HomeServices()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet GetAllHomeServiceAdmin(int UserType)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllHomeServiceAdmin", new SqlParameter[] { new SqlParameter("@UserType", UserType) });
            DB.Dispose();
            return ds;
        }


        public void UpdateService(int ServiceID, string Title, string Description, string ImageName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateHomeService", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID), new SqlParameter("@Title", Title), new SqlParameter("@Description", Description), new SqlParameter("@ImageName", ImageName) });
            DB.Dispose();
        }

        public DataSet GetHomeServiceDetail(int ServiceID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetHomeServiceDetail", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID) });
            DB.Dispose();
            return ds;
        }

        //Flea & Tick Services Method

        public DataSet GetAllFleaTickServiceAdmin(int UserType)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllFlea&TickServiceAdmin", new SqlParameter[] { new SqlParameter("@UserType", UserType) });
            DB.Dispose();
            return ds;
        }

        public void UpdateFleaandTickServices(int ServiceID, string Title, string Description, string ImageName)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateFleaandTickServices", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID), new SqlParameter("@Title", Title), new SqlParameter("@Description", Description), new SqlParameter("@ImageName", ImageName) });
            DB.Dispose();
        }

        public DataSet GetFleatickServiceDetail(int ServiceID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetFleatickServiceDetail", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID) });
            DB.Dispose();
            return ds;
        }

    }
}