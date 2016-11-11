using HicPicDataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

namespace advancewebtosolution.BO
{
    public class Appointment
    {
        public Appointment()
        {
            //
            // TODO: Add constructor logic here
            //

        }

        public static void FillDropDownList(System.Web.UI.WebControls.DropDownList ddl, System.Data.DataSet ds, string valueField, string textField)
        {
            ddl.Items.Clear();
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataSource = ds;
            ddl.DataBind();

        }
        public void AddAppointmentslots(DateTime @AppDate, int APTId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddAppointmentslots", new SqlParameter[] { new SqlParameter("@AppDate",  AppDate),
                           new SqlParameter("@APTId",  APTId)
      });
            DB.Dispose();
        }

        public DataSet GetAppointmentslots(DateTime AppDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAppointmentslots", new SqlParameter[] { new SqlParameter("@AppDate", AppDate) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetAppointmentslotsByTime(DateTime AppDate, int APTId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAppointmentslotsByTime", new SqlParameter[] {
            new SqlParameter("@AppDate", AppDate) ,
         new SqlParameter("@APTId", APTId)
        });
            DB.Dispose();
            return ds;
        }
        public DataSet GetAppointmentslotsToEdit(DateTime AppDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAppointmentslotsToEdit", new SqlParameter[] { new SqlParameter("@AppDate", AppDate) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetAppointmentsetDate()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAppointmentsetDate", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet GetAppointmentTime()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAppointmentTime", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public void DeleteAppointmentslots(DateTime @AppDate)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteAppointmentslots", new SqlParameter[] { new SqlParameter("@AppDate",  AppDate)

      });
            DB.Dispose();

        }

        public DataSet GetAppointmentslotsByDate(DateTime AppDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAppointmentslotsByDate", new SqlParameter[] { new SqlParameter("@AppDate", AppDate) });
            DB.Dispose();
            return ds;
        }
        public void AddAppointmentDate(DateTime @AppDate)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddAppointmentDate", new SqlParameter[] { new SqlParameter("@AppDate",  AppDate)

      });
            DB.Dispose();

        }
        public DataSet GetAppointmentDate()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAppointmentDate", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet UpdateAppointmentdateStatus(string AdId)
        {
            DBConnection DB = new DBConnection();
            DataSet DS = DB.ExecuteDataSet("UpdateAppointmentdateStatus", new SqlParameter[] { new SqlParameter("@AdId", AdId) });
            DB.Dispose();
            return DS;
        }

        public void DeleteAppointmentsDate(DateTime @AppDate)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteAppointmentsDate", new SqlParameter[] { new SqlParameter("@AppDate",  AppDate)

      });
            DB.Dispose();

        }
    }
}