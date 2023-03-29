
using AMDT_Assessment.Common;
using AMDT_Assessment.Models;
using AMDT_Assessment.Response;
using JwtAuthDemo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AMDT_Assessment.Service
{
    public class UserService
    {
        private readonly string key;

        private readonly IConfiguration iconfiguration;
        public UserService(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        public UserService()
        {
        }


        //Get all User Details
        [Authorize]
        public UserResponse GetAllUsers(SqlConnection connection)
        {
            UserResponse response = new UserResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select * from userDetails", connection);
            DataTable dt = new DataTable();
            List<User> listUsers = new List<User>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    User user = new User();
                    user.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
                    user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    user.DateofBirth = Convert.ToString(dt.Rows[i]["DateofBirth"]);
                    user.RoleType = Convert.ToString(dt.Rows[i]["RoleType"]);
                    user.Status = Convert.ToString(dt.Rows[i]["Status"]);
                    user.CreatedAt = Convert.ToDateTime(dt.Rows[i]["CreatedAt"]);
                    user.ModifiedAt = Convert.ToDateTime(dt.Rows[i]["ModifiedAt"]);
                    listUsers.Add(user);
                }
            }
            if (listUsers.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listUser = listUsers;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listUser = null;
            }
            return response;
        }

        //Get user details by  id
        [Authorize]

        public UserResponse GetUserById(SqlConnection connection, int id)
        {
            UserResponse response = new UserResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select * from userDetails where UserID='" + id + "'", connection);
            DataTable dt = new DataTable();
            User Users = new User();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                User user = new User();
                user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                user.DateofBirth = Convert.ToString(dt.Rows[0]["DateofBirth"]);
                user.RoleType = Convert.ToString(dt.Rows[0]["RoleType"]);
                user.Status = Convert.ToString(dt.Rows[0]["Status"]);
                user.CreatedAt = Convert.ToDateTime(dt.Rows[0]["CreatedAt"]);
                user.ModifiedAt = Convert.ToDateTime(dt.Rows[0]["ModifiedAt"]);

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.User = user;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.User = null;
            }
            return response;
        }

        //Get User details with role name and status name by email
        [Authorize]

        public UserResponse GetUserByEmail(SqlConnection connection, string email)
        {
            UserResponse response = new UserResponse();
            SqlDataAdapter da = new SqlDataAdapter("SELECT UserDetails.UserID,UserDetails.FirstName,UserDetails.LastName,UserDetails.Email,UserDetails.Password,UserDetails.DateofBirth,UserDetails.RoleType,UserDetails.Status,UserDetails.CreatedAt,UserDetails.ModifiedAt,RoleType.RoleName,status.StatusName FROM UserDetails JOIN RoleType ON UserDetails.RoleType = RoleType.RoleID JOIN Status ON Status.StatusID = UserDetails.Status where UserDetails.Email='" + email + "'", connection);
            DataTable dt = new DataTable();
            User Users = new User();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                User user = new User();
                user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                user.DateofBirth = Convert.ToString(dt.Rows[0]["DateofBirth"]);
                user.RoleType = Convert.ToString(dt.Rows[0]["RoleName"]);
                user.Status = Convert.ToString(dt.Rows[0]["StatusName"]);
                user.CreatedAt = Convert.ToDateTime(dt.Rows[0]["CreatedAt"]);
                user.ModifiedAt = Convert.ToDateTime(dt.Rows[0]["ModifiedAt"]);



                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.User = user;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.User = null;
            }
            return response;
        }

        //Add User
        [Authorize]

        public UserResponse AddUser(SqlConnection connection, User user)
        {
            UserResponse response = new UserResponse();
            SqlCommand cmd = new SqlCommand("INSERT into userDetails(FirstName,LastName,Email,Password,DateofBirth,RoleType,Status,CreatedAt,ModifiedAt)" +
                " values('" + user.FirstName + "','" + user.LastName + "','" + user.Email + "','" + CommonMethods.CovertToEncrypt(user.Password) + "','" + user.DateofBirth + "','" + Convert.ToInt32(user.RoleType) + "','" + Convert.ToInt32(user.Status) + "',GETDATE(),GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "User Addded";
                response.User = user;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data inserted";
                response.User = null;
            }
            return response;
        }

        //Update User
        [Authorize]

        public UserResponse UpdateUser(SqlConnection connection, User user)
        {
            UserResponse response = new UserResponse();
            SqlCommand cmd = new SqlCommand("Update userDetails set FirstName='" + user.FirstName + "',LastName='" + user.LastName + "',Email='" + user.Email + "',Password='" + CommonMethods.CovertToEncrypt(user.Password)
                + "',DateofBirth='" + user.DateofBirth + "',RoleType='" + user.RoleType + "',Status='" + user.Status + "',CreatedAt=GETDATE()," +
                "ModifiedAt=GETDATE() where UserID='" + user.UserID + "'", connection);
            connection.Open();

            int i = cmd.ExecuteNonQuery();
            connection.Close();


            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "User Updated";
                response.User = user;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data Updated";
                response.User = null;
            }
            return response;
        }
        //Delete User
        [Authorize]

        public UserResponse DeleteUser(SqlConnection connection, int id)
        {
            UserResponse response = new UserResponse();
            SqlCommand cmd = new SqlCommand("Delete from userDetails where UserID='" + id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 204;
                response.StatusMessage = "User Deleted";

            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No user Deleted";

            }
            return response;
        }

        //User login with Authenticate
        public JwtAuthResponse Login(SqlConnection connection, Login login)
        {

            JwtAuthResponse response = new JwtAuthResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select Email,Password from userDetails where Email='" + login.Email + "' AND Password='" + CommonMethods.CovertToEncrypt(login.Password) + "'", connection);

            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {

                var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Constants.JWT_TOKEN_VALIDITY_MINS);
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(Constants.JWT_SECURITY_KEY);
                var securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                  {
                    new Claim(ClaimTypes.Email, login.Email)
                  }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                var token = jwtSecurityTokenHandler.WriteToken(securityToken);

                return new JwtAuthResponse
                {
                     StatusCode = 200,
                     StatusMessage = "user login",
                     token =token,
                     email = login.Email,
                     expires_in = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
                };

            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "invalid email or password";

            }
            return response;
        }
    }
}
