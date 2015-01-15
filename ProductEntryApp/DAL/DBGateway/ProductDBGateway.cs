using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProductEntryApp.DAL.DAO;


namespace ProductEntryApp.DAL.DBGateway
{
    public class ProductDbGateway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionStringForProduct"].ConnectionString;

        private static SqlConnection aSqlConnection;
        private SqlCommand aSqlCommand;

        public ProductDbGateway()
        {
            aSqlConnection = new SqlConnection(connectionString);
        }

        public void Save(Product aProduct)
        {
            SqlConnection aSqlConnection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_Product VALUES ('" + aProduct.ProductCode + "','" + aProduct.Description
                           + "','" + aProduct.Quantity + "')";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
        }

        public Product HasProductCode(string code)
        {
            aSqlConnection.Open();
            string query = "SELECT *FROM t_Product WHERE Code='" + code + "';";
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
            Product aProduct;

            if (aDataReader.HasRows)
            {
                aProduct = new Product();
                aDataReader.Read();
                aProduct.Quantity = Convert.ToInt32(aDataReader["Quantity"]);
                aDataReader.Close();
                aSqlConnection.Close();
                return aProduct;
            }
            else
            {
                aSqlConnection.Close();
                return null;
            }

        }

        public void Update(Product aProduct)
        {
            string query = "Update t_Product  SET Quantity+='" + aProduct.Quantity + "' WHERE Code='" + aProduct.ProductCode +"'";

            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
        }

          public int GetTotalQuantity()
        {
            string query = "SELECT SUM(Quantity) AS TotalQuantity FROM t_Product";

            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
            Product aProduct = new Product();
            aDataReader.Read();
            aProduct.Quantity = Convert.ToInt32(aDataReader["TotalQuantity"]);
            aDataReader.Close();
            aSqlConnection.Close();
            return aProduct.Quantity;
        }

             public List<Product> GetAll()
            {
                string query = "SELECT * FROM t_Product";

                aSqlConnection.Open();
                aSqlCommand = new SqlCommand(query, aSqlConnection);
                SqlDataReader aDataReader = aSqlCommand.ExecuteReader();

                List<Product> productList = new List<Product>();

                while (aDataReader.Read())
                {
                    Product aProduct =new Product();
                    aProduct.ProductCode = aDataReader["Code"].ToString();
                    aProduct.Description = aDataReader["Description"].ToString();
                    aProduct.Quantity = Convert.ToInt32(aDataReader["Quantity"]);

                    productList.Add(aProduct);
                }
                aDataReader.Close();
                aSqlConnection.Close();
                return productList;
     
             }

             } 
    }
