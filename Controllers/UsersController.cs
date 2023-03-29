using AMDT_Assessment.Common;
using AMDT_Assessment.Models;
using AMDT_Assessment.Response;
using AMDT_Assessment.Service;
using JwtAuthDemo;
using Microsoft.AspNetCore.Authorization;
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
        //Get All Users
        [Authorize]
        [HttpGet]
        [Route("GetAllUsers")]
        
        public UserResponse GetAllUsers()
        {
            SqlConnection connection=new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            UserResponse response = new UserResponse();
            UserService userService= new UserService();
            response=userService.GetAllUsers(connection);
            return response;
        }
        //Get User By Id
        [HttpGet]
        [Route("GetUserById/{id}")]
        public UserResponse GetUserById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            UserResponse response = new UserResponse();
            UserService userService = new UserService();
            response = userService.GetUserById(connection,id);
            return response;
        }

        //Get User Details By email
        [HttpGet]
        [Route("GetUserByEmail/{email}")]
        public UserResponse GetUserByEmail(string email)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            UserResponse response = new UserResponse();
            UserService userService = new UserService();
            response = userService.GetUserByEmail(connection,email);
            return response;
        }
        //Add User
        [HttpPost]
        [Route("AddUser")]
        public UserResponse AddUser(User user)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            UserResponse response = new UserResponse();
            UserService userService = new UserService();
            response = userService.AddUser(connection,user);
            return response;
        }
        //Update User
        [HttpPut]
        [Route("UpdateUser")]
        public UserResponse UpdateUser(User user)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            UserResponse response = new UserResponse();
            UserService userService = new UserService();
            response = userService.UpdateUser(connection, user);
            return response;
        }
        //Delete User
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public UserResponse DeleteUser(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            UserResponse response = new UserResponse();
            UserService userService = new UserService();
            response = userService.DeleteUser(connection,id);
            return response;
        }

        //User login
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public JwtAuthResponse Login(Login login)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            JwtAuthResponse response = new JwtAuthResponse();
            UserService userService = new UserService();
            response = userService.Login(connection,login);

        

            return response;
        }


    }
}
