﻿using AMDT_Assessment.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace AMDT_Assessment.Service
{
    public class RoleTypeService
    {
        public Response GetAllRoleType(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from RoleType", connection);
            DataTable dt = new DataTable();
            List<RoleType> listRoleType = new List<RoleType>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RoleType roleType = new RoleType();
                    roleType.RoleID = Convert.ToInt32(dt.Rows[i]["RoleID"]);
                    roleType.RoleName = Convert.ToString(dt.Rows[i]["RoleName"]);
                    roleType.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    roleType.CreatedAt = Convert.ToDateTime(dt.Rows[i]["CreatedAt"]);
                    roleType.ModifiedAt = Convert.ToDateTime(dt.Rows[i]["ModifiedAt"]);
                    listRoleType.Add(roleType);
                }
            }
            if (listRoleType.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listRoleType = listRoleType;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listRoleType = null;
            }
            return response;
        }

        public Response GetRoleTypeById(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from RoleType where RoleID='" + id + "'", connection);
            DataTable dt = new DataTable();
            RoleType RoleTypes = new RoleType();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                RoleType roleType = new RoleType();

                roleType.RoleID = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                roleType.RoleName = Convert.ToString(dt.Rows[0]["RoleName"]);
                roleType.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                roleType.CreatedAt = Convert.ToDateTime(dt.Rows[0]["CreatedAt"]);
                roleType.ModifiedAt = Convert.ToDateTime(dt.Rows[0]["ModifiedAt"]);

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.roleType = roleType;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.roleType = null;
            }
            return response;
        }


        public Response AddRoleType(SqlConnection connection, RoleType roleType)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT into RoleType(RoleName,Status,CreatedAt,ModifiedAt)" +
                " values('" + roleType.RoleName + "','"+roleType.Status+"',GETDATE(),GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Role Type Addded";
                response.roleType = roleType;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data inserted";
                response.status = null;
            }
            return response;
        }

        public Response UpdateRoleType(SqlConnection connection, RoleType roleType)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update RoleType set RoleName='" + roleType.RoleName + "',Status='"+roleType.Status+ "',CreatedAt=GETDATE(),ModifiedAt=GETDATE() where RoleID='" + roleType.RoleID + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();


            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Status Updated";
                response.roleType = roleType;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data Updated";
                response.roleType = null;
            }
            return response;
        }

        public Response DeleteRoleType(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from RoleType where RoleID +'" + id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 204;
                response.StatusMessage = "RoleType Deleted";

            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No RoleType Deleted";

            }
            return response;
        }








    }
}
