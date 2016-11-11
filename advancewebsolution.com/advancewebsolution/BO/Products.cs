using System;
using HicPicDataAccess;
using System.Data;
using System.Data.SqlClient;

namespace advancewebtosolution.BO
{
    public partial class Products
    {
        public Products()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet GetAllProducts(string SearchFor, string SearchText)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllProducts", new SqlParameter[] { new SqlParameter("@SearchFor", SearchFor), new SqlParameter("@SearchText", SearchText) });
            DB.Dispose();
            return ds;
        }

        public void DeleteProducts(string ProductID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("DeleteProducts", new SqlParameter[] { new SqlParameter("@ProductID", ProductID) });
            DB.Dispose();
        }

        public void AddProducts(string ProductName, string Description, decimal price, string ImageName, int status)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("AddProducts", new SqlParameter[] { new SqlParameter("@ProductName", ProductName), new SqlParameter("@Description", Description), new SqlParameter("@price", price), new SqlParameter("@ImageName", ImageName), new SqlParameter("@status", status) });
            DB.Dispose();
        }

        public void UpdateProductStatus(string ProductID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateProductStatus", new SqlParameter[] { new SqlParameter("@ProductID", ProductID) });
            DB.Dispose();
        }

        public DataSet GetProductDetail(int ProductID)
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetProductDetail", new SqlParameter[] { new SqlParameter("@ProductID", ProductID) });
            DB.Dispose();
            return ds;
        }

        public void UpdateProduct(int ProductID, string ProductName, string Description, decimal price, string ImageName, int status)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateProduct", new SqlParameter[] { new SqlParameter("@ProductID", ProductID), new SqlParameter("@ProductName", ProductName), new SqlParameter("@Description", Description), new SqlParameter("@price", price), new SqlParameter("@ImageName", ImageName), new SqlParameter("@status", status) });
            DB.Dispose();
        }

        public void UpdateHomeProduct(string ProductID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateHomeProduct", new SqlParameter[] { new SqlParameter("@ProductID", ProductID) });
            DB.Dispose();
        }
        public void UpdateFleaProduct(string ProductID)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("UpdateFleaProduct", new SqlParameter[] { new SqlParameter("@ProductID", ProductID) });
            DB.Dispose();
        }
        public DataSet GetAllProductsFront()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllProductsFront", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet GetAllProductsHomeFront()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllProductsHomeFront", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }

        public DataSet GetAllProductsFleaFront()
        {
            DBConnection DB = new DBConnection();
            DataSet ds = new DataSet();
            ds = DB.ExecuteDataSet("GetAllProductsFleaFront", new SqlParameter[] { });
            DB.Dispose();
            return ds;
        }
        public void ProductDown(int Position)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("ProductDown", new SqlParameter[] { new SqlParameter("@Position", Position) });
            DB.Dispose();
        }

        public void ProductUp(int Position)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("ProductUp", new SqlParameter[] { new SqlParameter("@Position", Position) });
            DB.Dispose();
        }

        public void ProductPosition(int ProductID, int Position)
        {
            DBConnection DB = new DBConnection();
            DB.ExecuteNonQuery("ProductPosition", new SqlParameter[] { new SqlParameter("@ProductID", ProductID), new SqlParameter("@Position", Position) });
            DB.Dispose();
        }
    }
}