using AMDT_Assessment.Models;
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
    public class ProductsController : Controller
    {


        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        //Get All Role Types
        [HttpGet]
        
        public ProductResponse GetAllProducts()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            ProductResponse response = new ProductResponse();
            ProductService ProductService = new ProductService();
            response = ProductService.GetAllProduct(connection);
            return response;
        }
        //Get Role Type By Id
        [HttpGet]
        [Route("{id}")]
        public ProductResponse GetProductById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            ProductResponse response = new ProductResponse();
            ProductService ProductService = new ProductService();
            response = ProductService.GetProductById(connection, id);
            return response;
        }
        //Add Role Type
        [HttpPost]
        
        public ProductResponse AddProduct(Product product)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            ProductResponse response = new ProductResponse();
            ProductService ProductService = new ProductService();
            response = ProductService.AddProduct(connection, product);
            return response;
        }

        //Update Role Type
        [HttpPut]
    
        public ProductResponse UpdateProduct(Product product)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            ProductResponse response = new ProductResponse();
            ProductService ProductService = new ProductService();
            response = ProductService.UpdateProduct(connection, product);
            return response;
        }

        //Delete Role Type
        [HttpDelete]
        [Route("{id}")]
        public ProductResponse DeleteProduct(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            ProductResponse response = new ProductResponse();
            ProductService ProductService = new ProductService();
            response = ProductService.DeleteProduct(connection, id);
            return response;
        }


    }
}
