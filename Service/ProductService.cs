using AMDT_Assessment.Models;
using AMDT_Assessment.Response;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using WebApplication1.Models;

namespace AMDT_Assessment.Service
{
    public class ProductService
    {

        //Get all Rle Types
        public ProductResponse GetAllProduct(SqlConnection connection)
        {
            ProductResponse response = new ProductResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Product", connection);
            DataTable dt = new DataTable();
            List<Product> listProduct = new List<Product>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Product product = new Product();
                    product.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    product.productName = Convert.ToString(dt.Rows[i]["productName"]);
                    product.prodctCategory = Convert.ToString(dt.Rows[i]["prodctCategory"]);
                    product.quantity = Convert.ToInt32(dt.Rows[i]["quantity"]);
                    product.unitPrice = Convert.ToInt32(dt.Rows[i]["unitPrice"]);
                    product.description = Convert.ToString(dt.Rows[i]["description"]);
                    product.model = Convert.ToString(dt.Rows[i]["model"]);
                    product.imageUrl = Convert.ToString(dt.Rows[i]["imageUrl"]);
                    product.colour = Convert.ToString(dt.Rows[i]["colour"]);

                    listProduct.Add(product);
                }
            }
            if (listProduct.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listProduct = listProduct;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listProduct = null;
            }
            return response;
        }

        //Get Role Type By Id
        public ProductResponse GetProductById(SqlConnection connection, int id)
        {
            ProductResponse response = new ProductResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Product where id='" + id + "'", connection);
            DataTable dt = new DataTable();
            Product Products = new Product();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Product product = new Product();

                product.productName = dt.Rows[0]["productName"].ToString();
                product.prodctCategory = dt.Rows[0]["prodctCategory"].ToString();
                product.id = Convert.ToInt32(dt.Rows[0]["id"]);
                product.quantity = Convert.ToInt32(dt.Rows[0]["quantity"]);
                product.unitPrice = Convert.ToDecimal(dt.Rows[0]["unitPrice"]);
                product.description = dt.Rows[0]["description"].ToString();
                product.model = dt.Rows[0]["model"].ToString();
                product.colour = dt.Rows[0]["colour"].ToString();
                product.imageUrl = dt.Rows[0]["imageUrl"].ToString();
                product.cartStatus = Convert.ToBoolean(dt.Rows[0]["cartStatus"]);

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.product = product;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.product = null;
            }
            return response;
        }


        //Add Role Type
        public ProductResponse AddProduct(SqlConnection connection, Product product)
        {
            ProductResponse response = new ProductResponse();
            SqlCommand cmd = new SqlCommand("INSERT into Product(productName,prodctCategory,quantity,unitPrice,description,model,colour,cartStatus)" +
                " values('" + product.productName + "','" + product.prodctCategory + "','" + product.quantity + "','" + product.unitPrice + "','" + product.description + "','" + product.model + "','" + product.colour + "','" + product.cartStatus + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Role Type Addded";
                response.product = product;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data inserted";
                response.product = null;
            }
            return response;
        }

        //Update Role Type
        public ProductResponse UpdateProduct(SqlConnection connection, Product product)
        {
            ProductResponse response = new ProductResponse();
            SqlCommand cmd = new SqlCommand("Update Product set productName='" + product.productName + "',prodctCategory='" + product.prodctCategory + "'," +
                "quantity='" + product.quantity + "',unitPrice='" + product.unitPrice + "',description='" + product.description + "',model='" + product.model + "',colour='" + product.colour + "',cartStatus='" + product.cartStatus + "' where id='" + product.id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();


            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Status Updated";
                response.product = product;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data Updated";
                response.product = null;
            }
            return response;
        }

        //Delate Role Type
        public ProductResponse DeleteProduct(SqlConnection connection, int id)
        {
            ProductResponse response = new ProductResponse();
            SqlCommand cmd = new SqlCommand("Delete from Product where id ='" + id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 204;
                response.StatusMessage = "Product Deleted";

            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Product Deleted";

            }
            return response;
        }








    }
}
