using HicPicDataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

namespace advancewebtosolution.BO
{
    public class Banner
    {
        public Banner()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet GetUserTypeID(int PageID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUserTypeID", new SqlParameter[] { new SqlParameter("@PageID", PageID) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetDefaultCouponName()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetDefaultCouponName", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public DataSet UpdateDefaultBannerCouponName(string CouponName)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("UpdateDefaultBannerCouponName", new SqlParameter[] { new SqlParameter("@CouponName", CouponName) });
            DB.Dispose();
            return ds;
        }

        public int AddBanner(int PageType, int UserType, string BannerName, string ImagePath, string CouponLink, string MaxPosition, string NumberOfRepeation)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddBanner", new SqlParameter[] { new SqlParameter("@PageType", PageType),
                           new SqlParameter("@UserType", UserType),
                           new SqlParameter("@BannerName", BannerName),
                           new SqlParameter("@ImagePath", ImagePath),
                           new SqlParameter("@CouponLink", CouponLink),
                           new SqlParameter("@MaxPosition", MaxPosition),
                            new SqlParameter("@NumberOfRepeation",NumberOfRepeation),
        new SqlParameter("@BannerID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "BannerID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@BannerID"]).Value.ToString());
            return Count;
        }

        public int GetMaxBannerId()
        {
            object objMax;
            int maxBannerId = 0;

            DBConnection DB = new DBConnection();
            objMax = DB.ExecuteScaler("GetMaxBannerId", new SqlParameter[] { });
            DB.Dispose();
            if (objMax != DBNull.Value)
            {
                maxBannerId = Convert.ToInt32(objMax);
            }
            return maxBannerId;
        }


        public int getMaxMobileId()
        {
            object objMaxMobileBanner;
            int maxBannerMobileBannerId = 0;

            DBConnection DB = new DBConnection();
            objMaxMobileBanner = DB.ExecuteScaler("GetMaxMobileBannerId", new SqlParameter[] { });
            DB.Dispose();
            if (objMaxMobileBanner != DBNull.Value)
            {
                maxBannerMobileBannerId = Convert.ToInt32(objMaxMobileBanner);
            }
            return maxBannerMobileBannerId;
        }

       
        public void InsertInBannerList(string BannerName, string bannerpath, int BId, string virtualmobilepath)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("InsertInBannerList", new SqlParameter[] {
            new SqlParameter("@BannerName", BannerName),
            new SqlParameter("@bannerpath", bannerpath),
            new SqlParameter("@BId", BId),
            new SqlParameter("@virtualmobilepath", virtualmobilepath),
        });
            DB.Dispose();
        }
        public DataSet GetBannerList()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetBannerList", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public int InsertInSetBanner(int PageId, int UserId, int BannerId, int Frequency, bool IsCoupon, string PageName, int BannerOrder)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("InsertInSetBanner", new SqlParameter[] {
            new SqlParameter("@PageId", PageId),
            new SqlParameter("@UserId", UserId),
            new SqlParameter("@BannerId", BannerId),
            new SqlParameter("@Frequency", Frequency),
            new SqlParameter("@IsCoupon", IsCoupon) ,
            new SqlParameter("@PageName", PageName) ,
            new SqlParameter("@BannerOrder", BannerOrder),
            new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Id", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Id"]).Value.ToString());
            return Count;

        }

        public DataSet GetFrequencyFromSetBanner(int BannerId, int UserId, int PageId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetFrequencyFromSetBanner", new SqlParameter[] {
                    new SqlParameter("@BannerId", BannerId),
            new SqlParameter("@UserId", UserId),
            new SqlParameter("@PageId", PageId)});
            DB.Dispose();
            return ds;
        }

        public DataSet GetUserTypeList()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUserTypeList", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public DataSet GetPageTitleList()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPageTitleList", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public void DeletePreviousSetBanner(int PageId, int UserId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeletePreviousSetBanner", new SqlParameter[] {
            new SqlParameter("@PageId", PageId),
            new SqlParameter("@UserId", UserId)});
            DB.Dispose();
        }

        public void InsertImage(string ImagePath)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("spInsertImage", new SqlParameter[] {
            new SqlParameter("@ImagePath", ImagePath)});
            DB.Dispose();
        }


        public DataSet GetUploadImage()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("spSelectImages", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }


        public void DeleteImage(int MobileBannerId, int BannerId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("SpDeleteImage", new SqlParameter[] {
            new SqlParameter("@MobileBannerId", MobileBannerId),new SqlParameter("BannerId",BannerId)});
            DB.Dispose();
        }


       

        public DataSet GetXML()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("proc_XMLImages", new SqlParameter[] {
        });
          
            DB.Dispose();
            return ds;
        }


        public DataSet GetCategoryImages(string UserId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("spSelectImagescategory", new SqlParameter[] {
             new SqlParameter("@UserId", UserId)
            });
            DB.Dispose();
            return ds;
        }

        public DataSet GetBannerIdFrequencyFromSetBanner(int UserId, int PageId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetBannerIdFrequencyFromSetBanner", new SqlParameter[] {
            new SqlParameter("@UserId", UserId),
            new SqlParameter("@PageId", PageId)});
            DB.Dispose();
            return ds;
        }

        public DataSet GetBannerImageNameandpath(int BannerId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetBannerImageNameandpath", new SqlParameter[] {
             new SqlParameter("@BannerId", BannerId)
           });
            DB.Dispose();
            return ds;
        }


        public DataSet GetPagesNameFromSetBanners(int Id)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPagesNameFromSetBanners", new SqlParameter[] {
             new SqlParameter("@Id", Id)});
            DB.Dispose();
            return ds;
        }

        public DataSet GetPageanduserTypes(int PageId, int UserCount)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPageanduserTypes", new SqlParameter[] {
             new SqlParameter("@PageId", PageId),
             new SqlParameter("@UserCount", UserCount) });
            DB.Dispose();
            return ds;
        }
        public DataSet CheckIsCoupon(int PageId, int UserId, int BannerId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("CheckIsCoupon", new SqlParameter[] {
             new SqlParameter("@PageId", PageId),
             new SqlParameter("@UserId", UserId),
             new SqlParameter("@BannerId", BannerId) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetDefaultBanner(int PageId, int UserId, int BannerId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetDefaultBanner", new SqlParameter[] {
             new SqlParameter("@PageId", PageId),
             new SqlParameter("@UserId", UserId),
             new SqlParameter("@BannerId", BannerId)});
            DB.Dispose();
            return ds;
        }
        public int InsertInDefaultBanner(int BannerId, int PageId, int UserId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("InsertInDefaultBanner", new SqlParameter[] {
            new SqlParameter("@BannerId", BannerId),
             new SqlParameter("@PageId", PageId),
             new SqlParameter("@UserId", UserId),
            new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Id", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Id"]).Value.ToString());
            return Count;
        }

        public void DeleteDefaultBanner(int PageId, int UserId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteDefaultBanner", new SqlParameter[] {
            new SqlParameter("@PageId", PageId),
             new SqlParameter("@UserId", UserId)});
            DB.Dispose();
        }

        public DataSet GetPageIdandUserId(int PageId, int UserId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPageIdandUserId", new SqlParameter[] {
            new SqlParameter("@PageId", PageId),
            new SqlParameter("@UserId", UserId)});
            DB.Dispose();
            return ds;
        }

        public DataSet CheckUsedDefaultBanner(int BannerId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("CheckUsedDefaultBanner", new SqlParameter[] {
             new SqlParameter("@BannerId", BannerId)});
            DB.Dispose();
            return ds;
        }
        public DataSet CheckUsedBannerList(int BannerId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("CheckUsedBannerList", new SqlParameter[] {
             new SqlParameter("@BannerId", BannerId)});
            DB.Dispose();
            return ds;
        }
        public void DeleteUnusedBanner(int BannerId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteUnusedBanner", new SqlParameter[] {
            new SqlParameter("@BannerId", BannerId)});
            DB.Dispose();
        }
        public void DeleteMobileBanner(int MobileBannerId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteMobileBanner", new SqlParameter[]{
            new SqlParameter("MobileBannerId",MobileBannerId)});
            DB.Dispose();
        }
        public int InsertInDefaultCopon(int BannerId, int PageId, int UserId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("InsertInDefaultCopon", new SqlParameter[] {
            new SqlParameter("@BannerId", BannerId),
             new SqlParameter("@PageId", PageId),
             new SqlParameter("@UserId", UserId),
            new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Id", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Id"]).Value.ToString());
            return Count;
        }
        public void DeleteDefaultCopon(int PageId, int UserId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteDefaultCopon", new SqlParameter[] {
             new SqlParameter("@PageId", PageId),
             new SqlParameter("@UserId", UserId)});
            DB.Dispose();
        }

        public DataSet GetDefaultCopon(int PageId, int UserId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetDefaultCopon", new SqlParameter[] {
            new SqlParameter("@PageId", PageId),
            new SqlParameter("@UserId", UserId)});
            DB.Dispose();
            return ds;
        }
        public DataSet GetDefaultCoponForBanId(int PageId, int UserId, int BannerId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetDefaultCoponForBanId", new SqlParameter[] {
             new SqlParameter("@PageId", PageId),
             new SqlParameter("@UserId", UserId),
             new SqlParameter("@BannerId", BannerId)});
            DB.Dispose();
            return ds;
        }

        public DataSet GetOrderOfBannerId(int PageId, int UserId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetOrderOfBannerId", new SqlParameter[] {
            new SqlParameter("@PageId", PageId),
            new SqlParameter("@UserId", UserId)});
            DB.Dispose();
            return ds;
        }

        public DataSet GetoneDefaultBanner(int PageId, int UserId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetoneDefaultBanner", new SqlParameter[] {  new SqlParameter("@PageId", PageId),
            new SqlParameter("@UserId", UserId)});

            DB.Dispose();
            return ds;
        }

        public DataSet GetoneDefaultCoupon(int PageId, int UserId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetoneDefaultCoupon", new SqlParameter[] {
            new SqlParameter("@PageId", PageId),
            new SqlParameter("@UserId", UserId) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetPagenamefromSetBanner()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPagenamefromSetBanner", new SqlParameter[] {
           });
            DB.Dispose();
            return ds;
        }

        public DataSet GetNotPageanduserTypes(string BannerId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetNotPageanduserTypes", new SqlParameter[] {
             new SqlParameter("@BannerId", BannerId)
             });
            DB.Dispose();
            return ds;
        }
        public int newbannerupdate(int img_id, int priority, string category)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("newbannerupdate", new SqlParameter[] {
            new SqlParameter("@BannerId", img_id),
             new SqlParameter("@PageId", priority),
             new SqlParameter("@UserId", category),
            });
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Id"]).Value.ToString());
            return Count;
        }


        public DataSet CheckUsedMobileBanner(int MobileBannerId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("CheckUsedMobileBannerList", new SqlParameter[] {
             new SqlParameter("@MobileBannerId", MobileBannerId)});
            DB.Dispose();
            return ds;
        }

        public void DeleteUnusedMobileBanner(int MobileBannerId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteUnusedMobileBanner", new SqlParameter[] {
            new SqlParameter("@MobileBannerId", MobileBannerId)});
            DB.Dispose();
        }



        public DataSet CheckUsedMobileBannerList(int BannerId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("CheckUsedMobileDefaultBanner", new SqlParameter[] {
             new SqlParameter("@BannerId", BannerId)});
            DB.Dispose();
            return ds;
        }

        public DataSet GetXMLNewMobile()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            DB.ExecuteDataSet("proc_XMLImagesMobile", new SqlParameter[] { });
          
            DB.Dispose();
            return ds;
        }

        public void UpdateImagePriority(int Id, int Priority, string Category, int boolIscoupon)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("sp_updateimagepriority", new SqlParameter[] {
            new SqlParameter("@MobileBannerId", Id),
            new SqlParameter("@priority", Priority),
            new SqlParameter("@category", Category),
            new SqlParameter("@IsCoupon", boolIscoupon)

        });
            DB.Dispose();
        }

        public void UpdateImagePriority(int @BannerId, int BannerOrder, int UserID, int boolIscoupon)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateImagePriorityToMobile", new SqlParameter[] {
            new SqlParameter("@BannerId", @BannerId),
            new SqlParameter("@BannerOrder", BannerOrder),
            new SqlParameter("@UserId", UserID),
            new SqlParameter("@IsCoupon", boolIscoupon)

        });
            DB.Dispose();
        }

        public void UpdateImagePriorityToMobile(int BannerId, string BannerOrder, string UserID, int boolIscoupon)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateImagePriorityToMobile", new SqlParameter[]{
            new SqlParameter("@BannerId", BannerId),
            new SqlParameter("@BannerOrder", BannerOrder),
            new SqlParameter("@UserId", UserID),
            new SqlParameter("@IsCoupon", boolIscoupon)
        });
            DB.Dispose();
        }

        public DataSet UpdateNewImagePriority(int BannerId)
        {
            DBConnection DB = new DBConnection();
            DataSet dspriority = new DataSet();
            DB.ExecuteDataSet("sp_SetNewImagePriority", new SqlParameter[] {
             new SqlParameter("@BannerId", BannerId)});
            DB.Dispose();
            return dspriority;
        }
    }
}