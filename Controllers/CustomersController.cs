using AMDT_Assessment.Response;
using AMDT_Assessment.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace AMDT_Assessment.Controllers
{
   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {


        private readonly IConfiguration _configuration;

        public CustomersController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        //Get All Role Types
        [HttpGet]
        public CustomerResponse GetAllCustomers()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            CustomerResponse response = new CustomerResponse();
            CustomerService customerService = new CustomerService();
            response = customerService.GetAllCustomer(connection);
            return response;
        }
        //Get Role Type By Id
        [HttpGet]
        [Route("{id}")]
        public CustomerResponse GetCustomerById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            CustomerResponse response = new CustomerResponse();
            CustomerService customerService = new CustomerService();
            response = customerService.GetCustomerById(connection, id);
            return response;
        }
        //Add Role Type
        [HttpPost]
        public CustomerResponse AddCustomer(Customer Customer)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            CustomerResponse response = new CustomerResponse();
            CustomerService customerService = new CustomerService();
            response = customerService.AddCustomer(connection, Customer);
            return response;
        }

        //Update Role Type
        [HttpPut]
        public CustomerResponse UpdateCustomer(Customer Customer)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            CustomerResponse response = new CustomerResponse();
            CustomerService customerService = new CustomerService();
            response = customerService.UpdateCustomer(connection, Customer);
            return response;
        }

        //Delete Role Type
        [HttpDelete]
        [Route("{id}")]
        public CustomerResponse DeleteCustomer(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            CustomerResponse response = new CustomerResponse();
            CustomerService customerService = new CustomerService();
            response = customerService.DeleteCustomer(connection, id);
            return response;
        }


    }
}
