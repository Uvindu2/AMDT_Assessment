using AMDT_Assessment.Response;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using WebApplication1.Models;

namespace AMDT_Assessment.Service
{
    public class CustomerService
    {
        public CustomerResponse GetAllCustomer(SqlConnection connection)
        {
            CustomerResponse response = new CustomerResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Customer", connection);
            DataTable dt = new DataTable();
            List<Customer> listCustomer = new List<Customer>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Customer cus = new Customer();
                    cus.firstName = dt.Rows[i]["firstName"].ToString();
                    cus.lastName = dt.Rows[i]["lastName"].ToString();
                    cus.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    cus.address = dt.Rows[i]["address"].ToString();
                    cus.email = dt.Rows[i]["email"].ToString();
                    cus.telephone = Convert.ToInt32(dt.Rows[i]["telephone"]);
                    cus.postalCode = Convert.ToInt32(dt.Rows[i]["postalCode"]);
                    cus.nic = dt.Rows[i]["nic"].ToString();

                    listCustomer.Add(cus);
                }
            }
            if (listCustomer.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listCustomer = listCustomer;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listCustomer = null;
            }
            return response;
        }


        //Get Role Type By Id
        public CustomerResponse GetCustomerById(SqlConnection connection, int id)
        {
            CustomerResponse response = new CustomerResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Customer where RoleID='" + id + "'", connection);
            DataTable dt = new DataTable();
            Customer Customers = new Customer();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Customer cus = new Customer();

                cus.firstName = dt.Rows[0]["firstName"].ToString();
                cus.lastName = dt.Rows[0]["lastName"].ToString();
                cus.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                cus.address = dt.Rows[0]["address"].ToString();
                cus.email = dt.Rows[0]["email"].ToString();
                cus.telephone = Convert.ToInt32(dt.Rows[0]["telephone"]);
                cus.postalCode = Convert.ToInt32(dt.Rows[0]["postalCode"]);
                cus.nic = dt.Rows[0]["nic"].ToString();

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.customer = cus;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.customer = null;
            }
            return response;
        }


        //Add Role Type
        public CustomerResponse AddCustomer(SqlConnection connection, Customer customer)
        {
            CustomerResponse response = new CustomerResponse();
            SqlCommand cmd = new SqlCommand("INSERT into Customer(firstName,lastName,email,address,telephone,postalCode,nic)" +
                " values('" + customer.firstName + "','" + customer.lastName + "','" + customer.email + "','" + customer.address + "','" + customer.telephone + "','" + customer.postalCode + "','" + customer.nic + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Role Type Addded";
                response.customer = customer;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data inserted";
                response.customer = null;
            }
            return response;
        }

        //Update Role Type
        public CustomerResponse UpdateCustomer(SqlConnection connection, Customer customer)
        {
            CustomerResponse response = new CustomerResponse();
            SqlCommand cmd = new SqlCommand("Update Customer set firstName='" + customer.firstName + "',lastName='" + customer.lastName + "'," +
                "email='" + customer.email + "',address='" + customer.address + "',telephone='" + customer.telephone + "',postalCode='" + customer.postalCode + "',nic='" + customer.nic + "' where Id='" + customer.Id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();


            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Status Updated";
                response.customer = customer;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data Updated";
                response.customer = null;
            }
            return response;
        }

        //Delate Role Type
        public CustomerResponse DeleteCustomer(SqlConnection connection, int id)
        {
            CustomerResponse response = new CustomerResponse();
            SqlCommand cmd = new SqlCommand("Delete from Customer where id ='" + id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 204;
                response.StatusMessage = "Customer Deleted";

            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Customer Deleted";

            }
            return response;
        }
    }
}
