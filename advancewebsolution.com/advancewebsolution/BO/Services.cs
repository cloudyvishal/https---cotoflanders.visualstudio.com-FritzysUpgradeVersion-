using HicPicDataAccess;
using System.Data;
using System.Data.SqlClient;

namespace advancewebtosolution.BO
{
    public partial class Services
    {
        public Services()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet IsServiceExist(string FileName)
        {
            try
            {
                DBConnection DB = new DBConnection();
                DataSet DT = new DataSet();

                DT = DB.ExecuteDataSet("IsServiceExist", new SqlParameter[] { new SqlParameter("@FileName", FileName) });
                DB.Dispose();
                return DT;
            }
            catch (SqlException ex)
            {
                string Error = ex.Message;
                return null;

            }
        }

        public void DeleteService(string Fid)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteService", new SqlParameter[] { new SqlParameter("@Fid", @Fid) });
            DB.Dispose();
        }

        public DataSet GetAllServices(int type, string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("GetAllServices", new SqlParameter[] { new SqlParameter("@type", type), new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return DS;
        }

        public DataSet GetServiceDetail(int ServiceID)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("GetServiceDetail", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID) });
            DB.Dispose();
            return DS;
        }

        public int UpdateAdminUser(int UserID, string FirstName, string LastName, string Username, string Password, string Email, string Mobile, string Add1, string Add2)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateAdminUser", new SqlParameter[] {
                           new SqlParameter("@UserID", UserID),
                           new SqlParameter("@FirstName", FirstName),
                           new SqlParameter("@LastName", LastName),
                           new SqlParameter("@Username", Username),
                           new SqlParameter("@Password", Password),
                           new SqlParameter("@Email", Email),
                           new SqlParameter("@Phone", Mobile),
                           new SqlParameter("@Add1", Add1),
                           new SqlParameter("@Add2", Add2),
        new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "UserID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@UserID"]).Value.ToString());
            return Count;
        }

        public int AddService(int ServiceType, string ServiceTitle, string ServiceDescription, string PageName, int Status, string Image)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddService", new SqlParameter[] { new SqlParameter("@ServiceType", ServiceType),
                           new SqlParameter("@ServiceTitle", ServiceTitle),
                           new SqlParameter("@ServiceDescription", ServiceDescription),
                           new SqlParameter("@PageName", PageName),
                           new SqlParameter("@Status", Status),
                           new SqlParameter("@Image", Image),
        new SqlParameter("@ServiceID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "ServiceID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@ServiceID"]).Value.ToString());
            return Count;
        }

        public DataSet UpdateStatus(string ServiceID)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("UpdateStatus", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID) });
            DB.Dispose();
            return DS;
        }

        public DataSet SetIsFlea(string ServiceID, int PetType)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("SetIsFlea", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID), new SqlParameter("@ServiceType", PetType) });
            DB.Dispose();
            return DS;
        }

        public DataSet SetIsHome(string ServiceID, int PetType)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("SetIsHome", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID), new SqlParameter("@ServiceType", PetType) });
            DB.Dispose();
            return DS;
        }

        public void UpdateService(int ServiceID, int ServiceType, string ServiceTitle, string ServiceDescription, int Status, string Image)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateService", new SqlParameter[] {
                           new SqlParameter("@ServiceID", ServiceID),
                           new SqlParameter("@ServiceType", ServiceType),
                           new SqlParameter("@ServiceTitle", ServiceTitle),
                           new SqlParameter("@ServiceDescription", ServiceDescription),
                           new SqlParameter("@Status", Status),
                           new SqlParameter("@Image", Image) });
            DB.Dispose();
        }

        public void UpdateIsHome(int ServiceID, int ServiceType)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateIsHome", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID), new SqlParameter("@ServiceType", ServiceType) });
        }

        public DataSet GetAllHomeServices()
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("GetAllHomeServices", new SqlParameter[] { });
            DB.Dispose();
            return DS;
        }


        public DataSet GetFleaServices()
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("GetFleaServices", new SqlParameter[] { });
            DB.Dispose();
            return DS;
        }

        public void SetService(int ServiceID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("SetService", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID) });
            DB.Dispose();
        }


        public void SetServiceFlea(int ServiceID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("SetServiceFlea", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID) });
            DB.Dispose();
        }

        public void UpdateIsFlea(int ServiceID, int ServiceType)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateIsFlea", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID), new SqlParameter("@ServiceType", ServiceType) });
            DB.Dispose();
        }


        public DataSet UpdateOrder(int ServiceID, int OrderID)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("UpdateOrder", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID), new SqlParameter("@OrderID", OrderID) });
            DB.Dispose();
            return DS;
        }

        public void SetPositionDown(int Position, int PetType)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("SetPositionDown", new SqlParameter[] { new SqlParameter("@Position", Position), new SqlParameter("@PetType", PetType) });
        }

        public void SetPositionUp(int Position, int PetType)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("SetPositionUp", new SqlParameter[] { new SqlParameter("@Position", Position), new SqlParameter("@ServiceType", PetType) });
        }

        public void SetNewPosition(int ServiceID, int Position)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("SetPosition", new SqlParameter[] { new SqlParameter("@ServiceID", ServiceID), new SqlParameter("@Position", Position) });
        }


    }
}