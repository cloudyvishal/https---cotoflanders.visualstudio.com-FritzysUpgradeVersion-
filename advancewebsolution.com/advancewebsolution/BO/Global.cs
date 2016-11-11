using System.Data;
using System.Data.SqlClient;
using HicPicDataAccess;
using System.Drawing;
using System.Drawing.Imaging;
using System;

namespace advancewebtosolution.BO
{
    public class Global
    {
        public Global()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region ForgotPassword
        public DataSet GetPassword(string UserName)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("ForgotPassword", new SqlParameter[] { new SqlParameter("@UserName", UserName) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetPasswordAdmin(string UserName)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("ForgotPasswordFront", new SqlParameter[] { new SqlParameter("@UserName", UserName) });
            DB.Dispose();
            return ds;
        }


        public int ChangeUserName(int UserID, string CurrentPassword, string NewPassword)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("ChangeUserName", new SqlParameter[] {
                    new SqlParameter("@UserID", UserID),
                    new SqlParameter("@CurrentPassword", CurrentPassword),
                    new SqlParameter("@NewPassword", NewPassword) ,
                    new SqlParameter("@Status", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Status", DataRowVersion.Default, 0)});

            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Status"]).Value.ToString());
            return Count;
        }


        #endregion

        #region Suggestion
        public void AddSuggestion(string Name, string Email, string Phone, string Comment)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddSuggestion", new SqlParameter[] { new SqlParameter("@Name", Name), new SqlParameter("@Email", Email), new SqlParameter("@Phone", Phone), new SqlParameter("@Comment", Comment) });
            DB.Dispose();
        }

        public void DeleteSuggestion(string SuggestionID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteSuggestion", new SqlParameter[] { new SqlParameter("@SuggestionID", SuggestionID) });
            DB.Dispose();
        }
        public DataSet GetAllSuggestion(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllSuggestion", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetSuggestion(int SuggestionID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetSuggestion", new SqlParameter[] { new SqlParameter("@SuggestionID", SuggestionID) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetAllSuggestionExport(DateTime StartDate, DateTime EndDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllSuggestionExport", new SqlParameter[] { new SqlParameter("@StartDate", StartDate), new SqlParameter("@EndDate", EndDate) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetTopSuggestion()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetTopSuggestion", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        #endregion

        #region News
        public DataSet GetAllNews(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllNews", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetNewsOnStoreFront()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetNewsOnStoreFront", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public void AddNews(string NewsTitle, string ShortDescription, string Description)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddNews", new SqlParameter[] { new SqlParameter("@NewsTitle", NewsTitle), new SqlParameter("@ShortDescription", ShortDescription), new SqlParameter("@Description", Description) });
            DB.Dispose();
        }

        public void UpdateNews(int NewsID, string NewsTitle, string ShortDescription, string Description)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateNews", new SqlParameter[] { new SqlParameter("@NewsID", NewsID), new SqlParameter("@NewsTitle", NewsTitle), new SqlParameter("@ShortDescription", ShortDescription), new SqlParameter("@Description", Description) });
            DB.Dispose();
        }

        public void DeleteNews(string NewsID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteNews", new SqlParameter[] { new SqlParameter("@NewsID", NewsID) });
            DB.Dispose();
        }
        public void UpdateNewsStatus(string NewsID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateNewsStatus", new SqlParameter[] { new SqlParameter("@NewsID", NewsID) });
            DB.Dispose();
        }
        public DataSet GetNews(int NewsID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetNews", new SqlParameter[] { new SqlParameter("@NewsID", NewsID) });
            DB.Dispose();
            return ds;
        }
        public void NewsDown(int Position)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("NewsDown", new SqlParameter[] { new SqlParameter("@Position", Position) });
            DB.Dispose();
        }

        public void NewsUp(int Position)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("NewsUp", new SqlParameter[] { new SqlParameter("@Position", Position) });
            DB.Dispose();
        }

        public void NewsPosition(int NewsID, int Position)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("NewsPosition", new SqlParameter[] { new SqlParameter("@NewsID", NewsID), new SqlParameter("@Position", Position) });
            DB.Dispose();
        }

        #endregion

        #region Friendss
        public DataSet GetAllFriend(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllFriend", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }
        public void AddFriend(string Title, string Description, string Logo, string RefLink)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddFriend", new SqlParameter[] { new SqlParameter("@Title", Title), new SqlParameter("@Description", Description), new SqlParameter("@Logo", Logo), new SqlParameter("@RefLink", RefLink) });
            DB.Dispose();
        }

        public void UpdateFriends(int FriendID, string Title, string Description, string Logo, string RefLink)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateFriends", new SqlParameter[] { new SqlParameter("@FriendID", FriendID), new SqlParameter("@Title", Title), new SqlParameter("@Description", Description), new SqlParameter("@Logo", Logo), new SqlParameter("@RefLink", RefLink) });
            DB.Dispose();
        }

        public void DeleteFriend(string FriendID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteFriend", new SqlParameter[] { new SqlParameter("@FriendID", FriendID) });
            DB.Dispose();
        }
        public void UpdateFriendStatus(string FriendID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateFriendStatus", new SqlParameter[] { new SqlParameter("@FriendID", FriendID) });
            DB.Dispose();
        }
        public DataSet GetFriend(int FriendID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetFriend", new SqlParameter[] { new SqlParameter("@FriendID", FriendID) });
            DB.Dispose();
            return ds;
        }

        public void FriendDown(int Position)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("FriendDown", new SqlParameter[] { new SqlParameter("@Position", Position) });
            DB.Dispose();
        }

        public void FriendUp(int Position)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("FriendUp", new SqlParameter[] { new SqlParameter("@Position", Position) });
            DB.Dispose();
        }

        public void FriendPosition(int FriendID, int Position)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("FriendPosition", new SqlParameter[] { new SqlParameter("@FriendID", FriendID), new SqlParameter("@Position", Position) });
            DB.Dispose();
        }

        #endregion

        #region Front
        public DataSet GetAllFriendFront()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllFriendFront", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        #endregion

        #region Service Location
        public DataSet GetZipCodeFront(string Zipcode)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetZipCodeFront", new SqlParameter[] { new SqlParameter("@Zipcode", Zipcode) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetServiceLocations(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetServiceLocations", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetServiceLocationsExport()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetServiceLocationsExport", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public void ChangeServiceLocationStatus(string ZipCodeID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("ChangeServiceLocationStatus", new SqlParameter[] { new SqlParameter("@ZipCodeID", ZipCodeID) });
            DB.Dispose();
        }

        public void ChangeServiceLocationAvailable(string ZipCodeID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("ChangeServiceLocationAvailable", new SqlParameter[] { new SqlParameter("@ZipCodeID", ZipCodeID) });
            DB.Dispose();
        }

        public void DeleteServiceLocation(string ZipCodeID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteServiceLocation", new SqlParameter[] { new SqlParameter("@ZipCodeID", ZipCodeID) });
            DB.Dispose();
        }

        public int AddZipCode(string ZipCode, string City, string State, int Status, string ZipType)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddZipCode", new SqlParameter[] { new SqlParameter("@ZipCode", ZipCode),
                           new SqlParameter("@City", City),
                           new SqlParameter("@State", State),
                           new SqlParameter("@Status", Status),
                           new SqlParameter("@ZipType", ZipType),
        new SqlParameter("@ZipCodeID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "ZipCodeID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@ZipCodeID"]).Value.ToString());
            return Count;
        }



        #endregion

        #region "Image Functions"
        public static Bitmap CreateThumbnail(System.Drawing.Image lcFilename, int lnWidth, int lnHeight)
        {

            System.Drawing.Bitmap bmpOut = null;
            try
            {

                Bitmap loBMP = new Bitmap(lcFilename);

                ImageFormat loFormat = loBMP.RawFormat;
                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                //*** If the image is smaller than a thumbnail just return it

                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)

                    return loBMP;

                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;

                    lnNewWidth = lnWidth;

                    decimal lnTemp = loBMP.Height * lnRatio;

                    lnNewHeight = (int)lnTemp;

                }

                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;

                    lnNewHeight = lnHeight;

                    decimal lnTemp = loBMP.Width * lnRatio;

                    lnNewWidth = (int)lnTemp;
                }

                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);

                Graphics g = Graphics.FromImage(bmpOut);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);

                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();

            }

            catch
            {
                return null;
            }

            return bmpOut;

        }
        public static Bitmap CheckImageAspectRatio(System.Drawing.Image lcFilename)
        {
            int lnWidth = 80;
            System.Drawing.Bitmap bmpOut = null;
            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);
                ImageFormat loFormat = loBMP.RawFormat;
                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                //*** If the image is smaller than a thumbnail just return it
                //&& loBMP.Height < lnHeight
                if (loBMP.Width < lnWidth)
                    return loBMP;
                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnWidth / loBMP.Height;
                    lnNewHeight = lnWidth;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }
                // System.Drawing.Image imgOut =
                // loBMP.GetThumbnailImage(lnNewWidth,lnNewHeight,
                // null,IntPtr.Zero);


                // *** This code creates cleaner (though bigger) thumbnails and properly
                // *** and handles GIF files better by generating a white background for
                // *** transparent images (as opposed to black)
                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);
                loBMP.Dispose();
            }
            catch
            {
                return null;
            }
            return bmpOut;
        }
        #endregion

        #region ContactUs
        public DataSet GetContactInfo(int ContactID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetContactInfo", new SqlParameter[] { new SqlParameter("@ContactID", ContactID) });
            DB.Dispose();
            return ds;
        }
        #endregion

        #region Users
        public DataSet GetAllUserFront(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllUserFront", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }

        #region Users Admin Delete
        public DataSet DeleteUsers(string UserID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteUsers", new SqlParameter[] { new SqlParameter("@UserID", UserID) });
            DB.Dispose();
            return ds;
        }
        public DataSet ActiveInActiveUsers(string UserID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_ActiveInActiveUsers", new SqlParameter[] { new SqlParameter("@UserID", UserID) });
            DB.Dispose();
            return ds;
        }
        #endregion

        public DataSet GetUserInfo(int UserID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUserInfo", new SqlParameter[] { new SqlParameter("@UserID", UserID) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetAllUserFrontExport(DateTime StartDate, DateTime EndDate)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllUserFrontExport", new SqlParameter[] { new SqlParameter("@StartDate", StartDate), new SqlParameter("@EndDate", EndDate) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetPetServices(int PetID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPetServices", new SqlParameter[] { new SqlParameter("@PetID", PetID) });
            DB.Dispose();
            return ds;
        }
       
        public DataSet GetTopUserFront()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetTopUserFront", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public DataSet GetTopContactUS()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetTopContactUS", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet GetTopAppointment()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetTopAppointment", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public void DeleteUserPet(int PetID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteUserPet", new SqlParameter[] { new SqlParameter("@PetID", PetID) });
            DB.Dispose();
        }
        #endregion

        #region State
        public DataSet GetAllState()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllState", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        #endregion

        #region User Access
        public int AddUserAccess(int UserType, string PageName, string Module)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddAdminUserAccess", new SqlParameter[] {
                    new SqlParameter("@UserType", UserType),
                    new SqlParameter("@PageName", PageName),
                    new SqlParameter("@Module", Module) ,
                    new SqlParameter("@Status", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Status", DataRowVersion.Default, 0)});

            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Status"]).Value.ToString());
            return Count;
        }
        public DataSet GetAllUserType()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllUserType", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet DeleteUserAccess(string AccessID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteUserAccess", new SqlParameter[] { new SqlParameter("@AccessID", AccessID) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetPageName(int UserType)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetCurrentPage", new SqlParameter[] { new SqlParameter("@UserType", UserType) });
            DB.Dispose();
            return ds;
        }

        public DataSet ChangeUserAccess(string AccessID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("ChangeUserAccess", new SqlParameter[] { new SqlParameter("@AccessID", AccessID) });
            DB.Dispose();
            return ds;
        }
        #endregion


        #region  Pages

        public DataSet GetAllPages()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPages", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        #endregion

        #region Meta

        public DataSet GetMeta(string SearchFor, string SearchText, int PageID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetMeta", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText), new SqlParameter("@PageID", PageID) });
            DB.Dispose();
            return ds;
        }


        public DataSet GetPageList()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPageList", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public void DeleteMetaTag(string MetaID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteMetaTag", new SqlParameter[] { new SqlParameter("@MetaID", MetaID) });
            DB.Dispose();
        }

        public DataSet AddMeta(int PageID, string MetaName, string MetaContent, string keywords)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("AddMeta", new SqlParameter[] { new SqlParameter("@PageID", PageID), new SqlParameter("@MetaName", MetaName),
            new SqlParameter("@MetaContent", MetaContent),
        new SqlParameter("@Keywords", keywords)
        });
            DB.Dispose();
            return ds;
        }

        public DataSet GetMetaDetail(int MetaID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetMetaDetail", new SqlParameter[] { new SqlParameter("@MetaID", MetaID) });
            DB.Dispose();
            return ds;
        }


        public void UpdateMeta(int MetaID, string MetaName, string MetaContent, string Keywords)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteScaler("UpdateMeta", new SqlParameter[] { new SqlParameter("@MetaID", MetaID), new SqlParameter("@MetaName", MetaName),
            new SqlParameter("@MetaContent", MetaContent),new SqlParameter("@Keywords", Keywords) });
            DB.Dispose();

        }

        public DataSet GetMetaFront(String PageName)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetMetaFront", new SqlParameter[] { new SqlParameter("@PageName", PageName) });
            DB.Dispose();
            return ds;
        }
        public DataSet UpdateTitle(int PageID, string PageTitle)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("UpdateTitle", new SqlParameter[] { new SqlParameter("@PageID", PageID), new SqlParameter("@PageTitle", PageTitle) });
            DB.Dispose();
            return ds;
        }

        #endregion

        #region AddmitionalServices
        public DataSet GetAllAdditionalServicesAdmin()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAdditionalServicesAdmin", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }


        #endregion

        #region Email
        public DataSet GetAllMail()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllMail", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public DataSet UpdateSubject(string PageName, string Subject)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("UpdateSubject", new SqlParameter[] { new SqlParameter("@PageName", PageName), new SqlParameter("@Subject", Subject) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetEmailSubject(string PageName)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetEmailSubject", new SqlParameter[] { new SqlParameter("@PageName", PageName) });
            return ds;
        }

        #endregion

        #region Pet
        public DataSet getPetInfo(int PetID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("getPetInfo", new SqlParameter[] { new SqlParameter("@PetID", PetID) });
            DB.Dispose();
            return ds;
        }
        public void UpdatePetAdmin(int PetID, int PetType, string PetName, int BreedID, int Years, decimal Weight, decimal Length, int Spa, int StyleID, string AdditionalService)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteScaler("UpdatePetAdmin", new SqlParameter[] { new SqlParameter("@PetID", PetID),
            new SqlParameter("@PetType", PetType),
            new SqlParameter("@PetName", PetName),
            new SqlParameter("@BreedID", BreedID),
            new SqlParameter("@Years", Years),
            new SqlParameter("@Weight", Weight),
            new SqlParameter("@Length", Length),
            new SqlParameter("@Spa", Spa),
            new SqlParameter("@StyleID", StyleID),
            new SqlParameter("@AdditionalService", AdditionalService),
        });
            DB.Dispose();

        }
        public DataSet DeleteAllBannerNow()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteAllBannerNow", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet DeleteAllRow()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteAllRow", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        #endregion

        public DataSet GetBackup()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_BackUp", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
    }
}