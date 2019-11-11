using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1.ProductManagement
{
    public class ProductManagement
    {
        static string connection = @"server=(local)\sqldev2016;initial catalog=northwind;integrated security=sspi";
        public void GetProductDetail(int ProductId)
        {
            SqlConnection con = new SqlConnection(connection);
            string command = "SELECT * FROM Products WHERE ProductId=" + ProductId;
        }        
    }
}
