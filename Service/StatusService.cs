using AMDT_Assessment.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using Microsoft.AspNetCore.Mvc;
using AMDT_Assessment.Response;

namespace AMDT_Assessment.Service
{
    public class StatusService
    {
        //Get All Status
        public StatusResponse GetAllStatus(SqlConnection connection)
        {
            StatusResponse response = new StatusResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select * from status", connection);
            DataTable dt = new DataTable();
            List<Status> listStatus = new List<Status>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Status status = new Status();
                    status.StatusID = Convert.ToInt32(dt.Rows[i]["StatusID"]);
                    status.StatusName = Convert.ToString(dt.Rows[i]["StatusName"]);
                    status.CreatedAt = Convert.ToDateTime(dt.Rows[i]["CreatedAt"]);
                    status.ModifiedAt = Convert.ToDateTime(dt.Rows[i]["ModifiedAt"]);
                    listStatus.Add(status);
                }
            }
            if (listStatus.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listStatus = listStatus;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listStatus = null;
            }

            return response;
         
        }


        //Get All Status By Id
        public StatusResponse GetStatusById(SqlConnection connection, int id)
        {
            StatusResponse response = new StatusResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select * from status where StatusID='" + id + "'", connection);
            DataTable dt = new DataTable();
            Status Statuss = new Status();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Status status = new Status();

                status.StatusID = Convert.ToInt32(dt.Rows[0]["StatusID"]);
                status.StatusName = Convert.ToString(dt.Rows[0]["StatusName"]);
                status.CreatedAt = Convert.ToDateTime(dt.Rows[0]["CreatedAt"]);
                status.ModifiedAt = Convert.ToDateTime(dt.Rows[0]["ModifiedAt"]);

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.status = status;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.status = null;
            }
            return response;
        }

        //Add Status
        public StatusResponse AddStatus(SqlConnection connection, Status status)
        {
            StatusResponse response = new StatusResponse();
            SqlCommand cmd = new SqlCommand("INSERT into status(StatusName,CreatedAt,ModifiedAt)" +
                " values('" + status.StatusName + "',GETDATE(),GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Status Addded";
                response.status = status;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data inserted";
                response.status = null;
            }
            return response;
        }

        //Update Status
        public StatusResponse UpdateStatus(SqlConnection connection, Status status)
        {
            StatusResponse response = new StatusResponse();
            SqlCommand cmd = new SqlCommand("Update status set StatusName='" + status.StatusName + "',CreatedAt=GETDATE(),ModifiedAt=GETDATE() where StatusID='" + status.StatusID + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();


            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Status Updated";
                response.status = status;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data Updated";
                response.status = null;
            }
            return response;
        }

        //Delete Status
        public StatusResponse DeleteStatus(SqlConnection connection, int id)
        {
            StatusResponse response = new StatusResponse();
            SqlCommand cmd = new SqlCommand("Delete from status where StatusID ='" + id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {

                response.StatusCode = 204;
                response.StatusMessage = "Status Deleted";

            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Status Deleted";

            }
            return response;
        }
    }
}