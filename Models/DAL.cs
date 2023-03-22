
using AMDT_Assessment.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace AMDT_Assessment.Models
{
    public class DAL
    {
        public Response GetAllUsers(SqlConnection connection)
        {
           Response response=new Response();
           SqlDataAdapter da=new SqlDataAdapter("Select * from userDetails",connection);
            DataTable dt = new DataTable();
            List<User>listUsers = new List<User>();
            da.Fill(dt);
            if(dt.Rows.Count > 0 )
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    User user = new User();
                    user.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
                    user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    user.DateofBirth = Convert.ToString(dt.Rows[i]["DateofBirth"]);
                    user.RoleType = Convert.ToInt32(dt.Rows[i]["RoleType"]);
                    user.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    user.CreatedAt = Convert.ToDateTime(dt.Rows[i]["CreatedAt"]);
                    user.ModifiedAt = Convert.ToDateTime(dt.Rows[i]["ModifiedAt"]);
                    listUsers.Add(user);
                }
            }
            if(listUsers.Count > 0 )
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listUser = listUsers;
            }
            else
            {
                response.StatusCode=100;
                response.StatusMessage = "No Data Found";
                response.listUser = null;
            }
            return response;
        }

        public Response GetUserById(SqlConnection connection, int id)
        {
            Response response = new Response();
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
                user.RoleType = Convert.ToInt32(dt.Rows[0]["RoleType"]);
                user.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
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

        public Response GetUserByEmail(SqlConnection connection, string email)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT UserDetails.UserID,UserDetails.FirstName,UserDetails.LastName,UserDetails.Email,UserDetails.Password,UserDetails.DateofBirth,UserDetails.RoleType,UserDetails.Status,UserDetails.CreatedAt,UserDetails.ModifiedAt,RoleType.RoleName,status.StatusName FROM UserDetails JOIN RoleType ON UserDetails.RoleType = RoleType.RoleID JOIN Status ON Status.StatusID = UserDetails.Status where UserDetails.Email='"+email+"'", connection);
            DataTable dt = new DataTable();
            User Users = new User();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                RoleType roleType = new RoleType();
                Status status = new Status();
                User user = new User();
                user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                user.DateofBirth = Convert.ToString(dt.Rows[0]["DateofBirth"]);
                user.RoleType = Convert.ToInt32(dt.Rows[0]["RoleType"]);
                user.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                user.CreatedAt = Convert.ToDateTime(dt.Rows[0]["CreatedAt"]);
                user.ModifiedAt = Convert.ToDateTime(dt.Rows[0]["ModifiedAt"]);
                roleType.RoleName = Convert.ToString(dt.Rows[0]["RoleName"]);
                status.StatusName= Convert.ToString(dt.Rows[0]["StatusName"]);

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.User = user;
                response.roleType = roleType;
                response.status = status;   
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.User = null;
            }
            return response;
        }

        public Response AddUser(SqlConnection connection, User user)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT into userDetails(FirstName,LastName,Email,Password,DateofBirth,RoleType,Status,CreatedAt,ModifiedAt)" +
                " values('"+user.FirstName+"','"+user.LastName+"','"+user.Email+ "','"+CommonMethods.CovertToEncrypt(user.Password) + "','"+user.DateofBirth + "','"+user.RoleType+ "','"+user.Status+ "',GETDATE(),GETDATE())", connection);
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

        public Response UpdateUser(SqlConnection connection, User user)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update userDetails set FirstName='" + user.FirstName + "',LastName='" + user.LastName + "',Email='" + user.Email + "',Password='" + user.Password + "',DateofBirth='" + user.DateofBirth + "',RoleType='" + user.RoleType + "',Status='" + user.Status + "',CreatedAt=GETDATE(),ModifiedAt=GETDATE() where UserID='" + user.UserID+"'",connection);
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

        public Response DeleteUser(SqlConnection connection,int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from userDetails where UserID +'"+id+"'", connection);
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

        public Response Login(SqlConnection connection,Login login)
        {
        
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select Email,Password from userDetails where Email='" + login.Email + "' AND Password='" + login.Password + "'",connection);

            DataTable dt = new DataTable();
            da.Fill(dt);
        

            if (dt.Rows.Count > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "user login";
                
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
