using HicPicDataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

namespace advancewebtosolution.BO
{
    public class BannerOrder
    {
        public BannerOrder()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public const string BannerXml = "banners_Cat1.xml";
        public const string BannerMobileXML = "Banner_Mobile.xml";
        public DataSet GetBannerList(int PageId, int UserId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GetBannerOrderList", new SqlParameter[] { new SqlParameter("@PageId", PageId), new SqlParameter("@UserId", UserId) });
            DB.Dispose();
            return ds;
        }



        public DataSet GetMobileBannerList(int PageId, int UserID)
        {
            DBConnection DB = new DBConnection();
            DataSet dsnew = new DataSet();
            dsnew = DB.ExecuteDataSet("sp_GetMobileBannerOrderList", new SqlParameter[] { new SqlParameter("@PageId", PageId), new SqlParameter("@UserId", UserID) });
            DB.Dispose();
            return dsnew;
        }

        public DataSet UpdateBannerSequence(int Id, int BannerId, int IsCoupon)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("UpdateBannerSequence", new SqlParameter[] { new SqlParameter("@Id", Id), new SqlParameter("@BannerId", BannerId), new SqlParameter("@IsCoupon", IsCoupon) });
            DB.Dispose();
            return ds;
        }
        public DataSet UpdateBannerSequenceByPage(string PageName)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("UpdateBannerSequenceByPage", new SqlParameter[] { new SqlParameter("@PageName", PageName) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetPagesNames()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPagesNames", new SqlParameter[] {
           });
            DB.Dispose();
            return ds;
        }

        public DataSet GetBannerListMobile(string UserID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GetBannerOrderListMobile", new SqlParameter[] {
            new SqlParameter("@UserId", UserID) });
            DB.Dispose();
            return ds;
        }

        public DataSet UpdateBannerSequenceMobile(int Id, int BannerId, int IsCoupon, int boolIscoupon)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("UpdateBannerSequenceMobile", new SqlParameter[] {
            new SqlParameter("@Id", Id),
            new SqlParameter("@BannerId", BannerId),
            new SqlParameter("@IsCoupon", IsCoupon) });
            DB.Dispose();
            return ds;
        }

        public DataSet UpdateBannerSequenceByUser(int UserID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("UpdateBannerSequenceByUId", new SqlParameter[] { new SqlParameter("@PageName", UserID) });
            DB.Dispose();
            return ds;
        }
    }
}