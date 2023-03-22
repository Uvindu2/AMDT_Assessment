using AMDT_Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace AMDT_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpGet]
        [Route("GetAllUsers")]
        public Response GetAllUsers()
        {
            SqlConnection connection=new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            Response response = new Response();
            DAL dal= new DAL();
            response=dal.GetAllUsers(connection);
            return response;
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public Response GetUserById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetUserById(connection,id);
            return response;
        }


        [HttpGet]
        [Route("GetUserByEmail/{email}")]
        public Response GetUserByEmail(string email)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetUserByEmail(connection,email);
            return response;
        }

        [HttpPost]
        [Route("AddUser")]
        public Response AddUser(User user)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddUser(connection,user);
            return response;
        }
        [HttpPut]
        [Route("UpdateUser")]
        public Response UpdateUser(User user,int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UpdateUser(connection, user);
            return response;
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public Response DeleteUser(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteUser(connection, id);
            return response;
        }

        [HttpPost]
        [Route("Login")]
        public Response Login(Login login)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.Login(connection,login);
            return response;
        }


    }
}
