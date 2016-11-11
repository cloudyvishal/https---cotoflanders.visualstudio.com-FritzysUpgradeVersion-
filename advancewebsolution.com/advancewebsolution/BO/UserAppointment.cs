using HicPicDataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

namespace advancewebtosolution.BO
{
    public class UserAppointment
    {
        public UserAppointment()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region setAppointment and AddPetAppointmentServices
        //function to call frm mobile and desktop schedule 
        public int AddAppointment(int UserID, DateTime Date1, string Time1, string Time2, int IsFlexible, int FlexID, string FlexDay, string FlexHr, int IsPrimery, string Address, int ConfirmBy, string Note, string petid)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddAppointment", new SqlParameter[] { new SqlParameter("@UserID", UserID),
                           new SqlParameter("@Date", Date1),
                           new SqlParameter("@Time1", Time1),
                           new SqlParameter("@Time2", Time2),
                           new SqlParameter("@IsFlexible", IsFlexible),
                           new SqlParameter("@FlexID", FlexID),
                           new SqlParameter("@FlexDay", FlexDay),
                           new SqlParameter("@FlexHr", FlexHr),
                           new SqlParameter("@IsPrimery", IsPrimery),
                           new SqlParameter("@Address", Address),
                           new SqlParameter("@ConfirmBy ", ConfirmBy ),
                           new SqlParameter("@Note", Note),
                           new SqlParameter("@PetId",petid ),
        new SqlParameter("@AppointmentID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "AppointmentID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@AppointmentID"]).Value.ToString());
            return Count;
        }

        public void AddPetAppointmentServices(int UserID, int PetId, int AppointmentId, string OtherServiceID)
        {
            if (OtherServiceID != "Select Service")
            {
                DBConnection DB = new DBConnection();
                DB.ExecuteNonQuery("AddPetAppointmentServices", new SqlParameter[] {
                           new SqlParameter("@UserID", UserID),
                           new SqlParameter("@AppointmentId", AppointmentId),
                           new SqlParameter("@PetId", PetId),
                           new SqlParameter("@OtherServiceID", OtherServiceID)
        });
                DB.Dispose();
            }
        }
        #endregion setAppointment and AddPetAppointmentServices
        public DataSet GetAppStatus(int id)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("getAppStatus", new SqlParameter[] { new SqlParameter("@id", id) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetAllAppointment()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllAppointment", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        #region Permanent delete Appointment
        public DataSet DeleteAppointment(int AppointmentID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteAppointment", new SqlParameter[] { new SqlParameter("@AppointmentID", AppointmentID) });
            DB.Dispose();
            return ds;
        }
        #endregion Permanent delete Appointment

        #region ActiveInActiveAppointment

        public void ActiveInActiveAppointmentFromAdmin(int AppointmentId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("sp_ActiveInActiveAppointmentFromAdmin", new SqlParameter[] { new SqlParameter("@AppointmentId", AppointmentId) });
            DB.Dispose();
        }
        #endregion

        public DataSet GetAppointment(int AppointmentID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAppointment", new SqlParameter[] { new SqlParameter("@AppointmentID", AppointmentID) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetAllAppointmentExport(DateTime StartDate, DateTime EndDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllAppointmentExport", new SqlParameter[] { new SqlParameter("@StartDate", StartDate), new SqlParameter("@EndDate", EndDate) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetAppointmentStatus(string p)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAppointmentStatus", new SqlParameter[] { new SqlParameter("@AppointmentID", Convert.ToInt32(p)) });
            DB.Dispose();
            return ds;
        }
    }
}