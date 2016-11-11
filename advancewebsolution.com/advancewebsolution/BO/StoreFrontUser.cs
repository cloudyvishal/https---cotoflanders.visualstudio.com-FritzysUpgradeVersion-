using HicPicDataAccess;
using System.Data;
using System.Data.SqlClient;

namespace advancewebtosolution.BO
{
    public class StoreFrontUser
    {
        public StoreFrontUser()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        //mobile and Desktop both

        //function to get appointment details  when user comes using query string
        public DataSet GetPaymentAppointmentDetail(int AppId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("sp_GetPaymentAppointmentDetail", new SqlParameter[] { new SqlParameter("@GAppId", AppId) });
            DB.Dispose();
            return ds;
        }
        public DataSet GetPaymentAppointmentByGrommerDetail(int AppId)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPaymentAppointmentByGrommerDetail", new SqlParameter[] { new SqlParameter("@GAppId", AppId) });
            DB.Dispose();
            return ds;
        }
        #region Mobile Basic Registration
        public int AddUserBasic(string FirstName, string LastName, string Street, string City, string State, string Zip, string Phone, int ReferralID, string UserName, string Password, int Status)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddUser_Basic", new SqlParameter[] { new SqlParameter("@FirstName", FirstName),
                           new SqlParameter("@LastName", LastName),
                           new SqlParameter("@Street", Street),
                           new SqlParameter("@City", City),
                           new SqlParameter("@State", State),
                           new SqlParameter("@Zipcode", Zip),
                           new SqlParameter("@Phone", Phone),
                           new SqlParameter("@ReferralID", ReferralID),
                           new SqlParameter("@UserName", UserName),
                           new SqlParameter("@Password", Password),
                           new SqlParameter("@Status", Status),
        new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "UserID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@UserID"]).Value.ToString());
            return Count;
        }
        #endregion

        #region Add Full Mobile Regis
        public int AddUserFull(string FirstName, string LastName, string Street, string City, string State, string Zip, string Phone, int ReferralID, string UserName, string Password, string AltMobile, string AltContact, string AltStreet, string AltCity, string AltState, string AltZip, string AltPhone, string PreferredGroomer, int Status)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddUser_Full", new SqlParameter[] { new SqlParameter("@FirstName", FirstName),
                           new SqlParameter("@LastName", LastName),
                           new SqlParameter("@Street", Street),
                           new SqlParameter("@City", City),
                           new SqlParameter("@State", State),
                           new SqlParameter("@Zipcode", Zip),
                           new SqlParameter("@Phone", Phone),
                           new SqlParameter("@ReferralID", ReferralID),
                           new SqlParameter("@UserName", UserName),
                           new SqlParameter("@Password", Password),

                           new SqlParameter("@AltMobile", AltMobile),
                           new SqlParameter("@AltContact", AltContact),
                           new SqlParameter("@AltStreet", AltStreet),
                           new SqlParameter("@AltCity", AltCity),
                           new SqlParameter("@AltState", AltState),
                           new SqlParameter("@AltZipcode", AltZip ),
                           new SqlParameter("@AltPhone", AltPhone),
                           new SqlParameter("@PreferredGroomer", PreferredGroomer),
                           new SqlParameter("@Status", Status),

            new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "UserID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@UserID"]).Value.ToString());
            return Count;
        }
        #endregion

        #region add/update pet 
        public string AddPet(int UserID, int Pettype, string PetName, int BreedID, int Years, decimal Weight, decimal Length)
        {
            string TempName = string.Empty;
            if (Pettype == 0) TempName = "Cat";
            else TempName = "dog";
            string str = "Pet = " + TempName + "<br>Pet Name = " + PetName + "<br> Breed Name = BreedID " +
                          "<br>Years = " + Years + "<br>Weight = " + Weight + "  lbs <br> Fur Length = " + Length + " inches<br><br><br>";
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddPet", new SqlParameter[] {
                                    new SqlParameter("@UserID", UserID),
                                    new SqlParameter("@Pettype", Pettype),
                                    new SqlParameter("@PetName", PetName),
                                    new SqlParameter("@BreedID", BreedID),
                                    new SqlParameter("@Year", Years),
                                    new SqlParameter("@Weight", Weight),
                                    new SqlParameter("@Length", Length)
                                    });
            DB.Dispose();
            return str;
        }
        public string UpdatePet(int PetID, int UserID, int Pettype, string PetName, int BreedID, int Years, decimal Weight, decimal Length)
        {
            string TempName = string.Empty;
            if (Pettype == 0) TempName = "Cat";
            else TempName = "dog";
            string str = "Pet = " + TempName + "<br>Pet Name = " + PetName + "<br> Breed Name = BreedID " +
                          "<br>Years = " + Years + "<br>Weight = " + Weight + "  lbs <br> Fur Length = " + Length + "  inches<br><br><br>";
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdatePet", new SqlParameter[] {
                                    new SqlParameter("@PetID", PetID),
                                    new SqlParameter("@UserID", UserID),
                                    new SqlParameter("@Pettype", Pettype),
                                    new SqlParameter("@PetName", PetName),
                                    new SqlParameter("@BreedID", BreedID),
                                    new SqlParameter("@Year", Years),
                                    new SqlParameter("@Weight", Weight),
                                    new SqlParameter("@Length", Length)
                                    });
            DB.Dispose();
            return str;
        }
        #endregion add/update pet 

        #region PetAddUpdate
        public string AddPetFull(int UserID, int Pettype, string PetName, int BreedID, int Years, decimal Weight, decimal Length, int Spa, int StyleID, string OtherServices)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddPetFull", new SqlParameter[] {
                                    new SqlParameter("@UserID", UserID),
                                    new SqlParameter("@Pettype", Pettype),
                                    new SqlParameter("@PetName", PetName),
                                    new SqlParameter("@BreedID", BreedID),
                                    new SqlParameter("@Year", Years),
                                    new SqlParameter("@Weight", Weight),
                                    new SqlParameter("@Length", Length),
                                    new SqlParameter("@Spa", Spa),
                                    new SqlParameter("@StyleID", StyleID),
                                    new SqlParameter("@OtherServiceID", OtherServices),
                                    new SqlParameter("@Return", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Return", DataRowVersion.Default, 0)});

            DB.Dispose();
            string Count = ((SqlParameter)DB.LastCommand.Parameters["@Return"]).Value.ToString();
            return Count;
        }


        public void UpdatePetFull(int PetID, int UserID, int Pettype, string PetName, int BreedID, int Years, decimal Weight, decimal Length, int Spa, int StyleID, string OtherServices)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdatePetFull", new SqlParameter[] {
                                    new SqlParameter("@PetID", PetID),
                                    new SqlParameter("@UserID", UserID),
                                    new SqlParameter("@Pettype", Pettype),
                                    new SqlParameter("@PetName", PetName),
                                    new SqlParameter("@BreedID", BreedID),
                                    new SqlParameter("@Year", Years),
                                    new SqlParameter("@Weight", Weight),
                                    new SqlParameter("@Length", Length),
                                    new SqlParameter("@Spa", Spa),
                                    new SqlParameter("@StyleID", StyleID),
                                    new SqlParameter("@OtherServiceID", OtherServices)
                                    });
            DB.Dispose();
            char[] splitter = { ',' };
            string[] arInfo = OtherServices.Split(splitter);
        }

        #endregion PetAddUpdate
        public int UpdateUser(int UserID, string FirstName, string LastName, string Street, string City, string State, string Zip, string Phone, int ReferralID, string AltMobile, string AltContact, string AltStreet, string AltCity, string AltState, string AltZip, string AltPhone, string PreferredGroomer, int Status, string Email)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateUser", new SqlParameter[] { new SqlParameter("@UserID", UserID),
                           new SqlParameter("@FirstName", FirstName),
                           new SqlParameter("@LastName", LastName),
                           new SqlParameter("@Street", Street),
                           new SqlParameter("@City", City),
                           new SqlParameter("@State", State),
                           new SqlParameter("@Zipcode", Zip),
                           new SqlParameter("@Phone", Phone),
                           new SqlParameter("@ReferralID", ReferralID),
                           new SqlParameter("@AltMobile", AltMobile),
                           new SqlParameter("@AltContact", AltContact),
                           new SqlParameter("@AltStreet", AltStreet),
                           new SqlParameter("@AltCity", AltCity),
                           new SqlParameter("@AltState", AltState),
                           new SqlParameter("@AltZipcode", AltZip ),
                           new SqlParameter("@AltPhone", AltPhone),
                           new SqlParameter("@PreferredGroomer", PreferredGroomer),
                           new SqlParameter("@Status", Status),
                           new SqlParameter("@Email", Email),
                           new SqlParameter("@Return", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "Return", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@Return"]).Value.ToString());
            return Count;
        }

        public DataSet GetBreedFront(string PetType)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetBreedFront", new SqlParameter[] { new SqlParameter("@PetTypeID", PetType) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetPetFront(string Breed)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetPetFront", new SqlParameter[] { new SqlParameter("@BreedID", Breed) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetAllBreed()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllBreed", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet GetBreedFrontAll()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetBreedFrontAll", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet GetReferalSourceFront()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetReferalSourceFront", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet GetUser(int UserID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetUserFront", new SqlParameter[] { new SqlParameter("@UserID", UserID) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetRevenueDetails(int AppID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetRevenueDetails", new SqlParameter[] { new SqlParameter("@AppID", AppID) });
            DB.Dispose();
            return ds;
        }
        // desktop function to bind pet
        public DataSet GetAllPetFront(int UserID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllPetFront", new SqlParameter[] { new SqlParameter("@UserID", UserID) });
            DB.Dispose();
            return ds;
        }

        public DataSet DeleteAllPet(int UserID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("DeleteAllPet", new SqlParameter[] { new SqlParameter("@UserID", UserID) });
            DB.Dispose();
            return ds;
        }

        public DataSet IsFullProfile(int UserID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("IsFullProfile", new SqlParameter[] { new SqlParameter("@UserID", UserID) });
            DB.Dispose();
            return ds;
        }

        public DataSet GetStyleFront()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetStyleFront", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public DataSet GetAllFlexible()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllFlexible", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }



        public void UpdateUserType(int UserID, int Status)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteDataSet("UpdateUserType", new SqlParameter[] { new SqlParameter("@UserID", UserID), new SqlParameter("@Status", Status) });
            DB.Dispose();
        }
        //function to call from desktop
        public void DeletePet(int PetID, int Status, int userId)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeletePet", new SqlParameter[] { new SqlParameter("@PetID", PetID), new SqlParameter("@Status", Status), new SqlParameter("@userId", userId) });
            DB.Dispose();
        }

     

        public int AddUserExcel(string FirstName, string LastName, string Street, string City, string State, string Zip, string Phone,
            string UserName, string Password, string AltMobile, string AltContact, string AltStreet, string AltCity, string AltState,
            string AltZip, string AltPhone, string PreferredGroomer, int UserType)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddUserExcel", new SqlParameter[] { new SqlParameter("@FirstName", FirstName),
                           new SqlParameter("@LastName", LastName),
                           new SqlParameter("@Street", Street),
                           new SqlParameter("@City", City),
                           new SqlParameter("@State", State),
                           new SqlParameter("@Zipcode", Zip),
                           new SqlParameter("@Phone", Phone),
                           new SqlParameter("@UserName", UserName),
                           new SqlParameter("@Password", Password),
                           new SqlParameter("@AltMobile", AltMobile),
                           new SqlParameter("@AltContact", AltContact),
                           new SqlParameter("@AltStreet", AltStreet),
                           new SqlParameter("@AltCity", AltCity),
                           new SqlParameter("@AltState", AltState),
                           new SqlParameter("@AltZipcode", AltZip ),
                           new SqlParameter("@AltPhone", AltPhone),
                           new SqlParameter("@PreferredGroomer", PreferredGroomer),
                           new SqlParameter("@UserType", UserType),

            new SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "UserID", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@UserID"]).Value.ToString());
            return Count;
        }



        public int UpdateMember(int UserID, string FirstName, string LastName, string Street, string City, string State, string Zip,
            string Phone, string AltMobile,
            string AltContact,
            string AltStreet, string AltCity, string AltState, string AltZip,
            string AltPhone,
            int ReferalSource,
            string PreferredGroomer,
            string UserName,
            string Password)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateMember", new SqlParameter[] { new SqlParameter("@UserID", UserID),
                           new SqlParameter("@FirstName", FirstName),
                           new SqlParameter("@LastName", LastName),
                           new SqlParameter("@Street", Street),
                           new SqlParameter("@City", City),
                           new SqlParameter("@State", State),
                           new SqlParameter("@Zipcode", Zip),
                           new SqlParameter("@Phone", Phone),
                           new SqlParameter("@AltMobile", AltMobile),

                           new SqlParameter("@AltContact", AltContact),
                           new SqlParameter("@AltStreet", AltStreet),
                           new SqlParameter("@AltCity", AltCity),
                           new SqlParameter("@AltState", AltState),
                           new SqlParameter("@AltZipcode", AltZip ),
                           new SqlParameter("@AltPhone", AltPhone),
                           new SqlParameter("@ReferalSource", ReferalSource),

                           new SqlParameter("@PreferredGroomer", PreferredGroomer),
                            new SqlParameter("@UserName", UserName),
                           new SqlParameter("@Password", Password),
            new SqlParameter("@ReturnVaule", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "ReturnVaule", DataRowVersion.Default, 0)});
            DB.Dispose();
            int Count = int.Parse(((SqlParameter)DB.LastCommand.Parameters["@ReturnVaule"]).Value.ToString());
            return Count;
        }
    }
}