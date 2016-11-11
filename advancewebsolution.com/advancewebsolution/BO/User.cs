using HicPicDataAccess;
using System.Data;
using System.Data.SqlClient;

namespace advancewebtosolution.BO
{
    public class User
    {
        public User()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet GetUser(string LoginID, string Password)
        {
            try
            {
                DBConnection DB = new DBConnection();
                DataSet DT = new DataSet();

                DT = DB.ExecuteDataSet("GetUserLogin", new SqlParameter[] { new SqlParameter("@Username", LoginID), new SqlParameter("@PassWord", Password) });
                DB.Dispose();
                return DT;
            }
            catch (SqlException ex)
            {
                string Error = ex.Message;
                return null;
            }
        }

        public DataSet GetAllUser(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllUser", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }
        //Dec2013
        public DataSet GetAllAgent(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllAgents", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetAllManager(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllManager", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }


        public void ChangeUserStatus(string UserID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("ChangeUserStatus", new SqlParameter[] { new SqlParameter("@UserID", UserID) });
            DB.Dispose();
        }
        public void DeleteUser(string UserID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteUser", new SqlParameter[] { new SqlParameter("@UserID", UserID) });
            DB.Dispose();
        }
        public int AddAdminUser(string FirstName, string LastName, string Username, string Password, string Email, string Mobile, string Add1, string Add2, int UserType)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddAdminUser", new SqlParameter[] { new SqlParameter("@FirstName", FirstName), new SqlParameter("@LastName", LastName),
                           new SqlParameter("@Username", Username),
                           new SqlParameter("@Password", Password),
                           new SqlParameter("@Email", Email),
                           new SqlParameter("@Phone", Mobile),
                           new SqlParameter("@Add1", Add1),
                           new SqlParameter("@Add2", Add2),
                           new SqlParameter("@UserType", UserType),
        new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "UserID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@UserID"]).Value.ToString());
            return Count;
        }
        public DataSet GetUserDetail(int UserID)
        {
            DBConnection DB = new DBConnection();
            DataSet DT = new DataSet();
            DT = DB.ExecuteDataSet("GetUserDetail", new SqlParameter[] { new SqlParameter("@UserID", UserID) });
            DB.Dispose();
            return DT;

        }

        public int UpdateAdminUser(int UserID, string FirstName, string LastName, string Username, string Password, string Email, string Mobile, string Add1, string Add2, int UserType)
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
                           new SqlParameter("@UserType", UserType),
        new SqlParameter("@Return_Value", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "UserID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Return_Value"]).Value.ToString());
            return Count;
        }
    }
}