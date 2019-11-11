using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1.ProductManagement
{
    internal class ProductDAO
    {
        //All Stored Procedure names go here. Verify the actual/correct names later.
        const string GETALL = "sp_GetAllProducts";
        const string GETDETAILS = "sp_GetProductDetails";
        const string INSERT = "sp_CreateProduct";
        const string UPDATE = "sp_UpdateProduct";

        SqlConnection connection;
        string connectionString = @"server=(local)\sqldev2016;initial catalog=Northwind;integrated security=sspi";

        #region Helper Methods for connection management
        private void CreateConnection()
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);
        }
        private void OpenConnection()
        {
            if (connection == null) CreateConnection();
            if (connection.State != ConnectionState.Open) connection.Open();
        }
        private void CloseConnection()
        {
            if (connection != null)
                if (connection.State != ConnectionState.Closed) connection.Close();
            connection = null;
        }
        private Product CreateProductFromReader(SqlDataReader reader)
        {
            Product p = new Product();
            p.ProductId = Convert.ToInt32("0" + reader["ProductId"].ToString());
            p.ProductName = reader["ProductName"].ToString();
            p.UnitPrice = Convert.ToDecimal("0" + reader["UnitPrice"].ToString());
            p.UnitsInStock = Convert.ToInt16("0" + reader["UnitsInStock"].ToString());
            p.Discontinued = Convert.ToBoolean(reader["Discontinued"].ToString());
            p.CategoryId = Convert.ToInt32("0" + reader["CategoryId"].ToString());
            return p;
        }
        #endregion

        #region DataAccess Public Methods 
        public List<Product> GetProducts(string criteria)
        {
            //Check whether the argument is passed or not
            /*if (string.IsNullOrEmpty(criteria))
            {
                throw new ArgumentNullException(nameof(criteria), "Required argument missing.");
            }*/

            List<Product> productList = new List<Product>();
            //Create the command and setup the parameters 
            CreateConnection();
            SqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = GETALL;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@search", criteria);
            //Open the connection and execute the statements within the try catch block 
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var product = CreateProductFromReader(reader);
                    productList.Add(product);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (reader != null) if (!reader.IsClosed) reader.Close();
                CloseConnection();
            }
            return productList;
        }
        public Product GetProduct(int productId)
        {
            if (productId == 0)
                throw new ArgumentNullException(nameof(productId), "Argument expected.");

            Product item = new Product();
            CreateConnection();
            SqlCommand command = new SqlCommand(GETDETAILS, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@productId", productId);
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                    item = CreateProductFromReader(reader);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (reader != null) if (!reader.IsClosed) reader.Close();
                CloseConnection();
            }
            return item;
        }
        public void CreateProduct(Product item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Required argument missing.");

            CreateConnection();
            //BUild a command and assign all the parameters 
            SqlCommand command = new SqlCommand(INSERT, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@productName";
            p1.SqlDbType = SqlDbType.VarChar;
            p1.Size = 50;
            p1.Direction = ParameterDirection.Input;
            p1.Value = item.ProductName;
            command.Parameters.Add(p1);

            command.Parameters.Add(new SqlParameter("@unitPrice", item.UnitPrice));
            command.Parameters.Add(new SqlParameter("@unitsInStock", item.UnitsInStock));
            command.Parameters.AddWithValue("@discontinued", item.Discontinued);
            command.Parameters.AddWithValue("@categoryId", item.CategoryId);

            OpenConnection();
            SqlTransaction trans = connection.BeginTransaction();
            command.Transaction = trans;
            try
            {
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (SqlException)
            {
                trans.Rollback();
                throw;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdateProduct(Product item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Required argument missing.");

            CreateConnection();
            //BUild a command and assign all the parameters 
            SqlCommand command = new SqlCommand(UPDATE, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@productName";
            p1.SqlDbType = SqlDbType.VarChar;
            p1.Size = 50;
            p1.Direction = ParameterDirection.Input;
            p1.Value = item.ProductName;
            command.Parameters.Add(p1);

            command.Parameters.Add(new SqlParameter("@unitPrice", item.UnitPrice));
            command.Parameters.Add(new SqlParameter("@unitsInStock", item.UnitsInStock));
            command.Parameters.AddWithValue("@discontinued", item.Discontinued);
            command.Parameters.AddWithValue("@categoryId", item.CategoryId);
            command.Parameters.AddWithValue("@productId", item.ProductId);


            OpenConnection();
            SqlTransaction trans = connection.BeginTransaction();
            command.Transaction = trans;
            try
            {
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (SqlException)
            {
                trans.Rollback();
                throw;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion 




    }
}
