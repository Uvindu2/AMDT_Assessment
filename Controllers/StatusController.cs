using AMDT_Assessment.Models;
using AMDT_Assessment.Response;
using AMDT_Assessment.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace AMDT_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
   
            private readonly IConfiguration _configuration;

            public StatusController(IConfiguration configuration)
            {
                _configuration = configuration;

            }
        //Get All Status
            [HttpGet]
            [Route("GetAllStatus")]
            public StatusResponse GetAllStatus()
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            StatusResponse response = new StatusResponse();
            StatusService statusService = new StatusService();
                response = statusService.GetAllStatus(connection);
                return response;
            }
        //Get Status By Id
            [HttpGet]
            [Route("GetStatusById/{id}")]
            public StatusResponse GetStatusById(int id)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            StatusResponse response = new StatusResponse();
            StatusService statusService = new StatusService();
                response = statusService.GetStatusById(connection, id);
                return response;
            }
        //Add Status
            [HttpPost]
            [Route("AddStatus")]
            public StatusResponse AddStatus(Status status)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            StatusResponse response = new StatusResponse();
            StatusService statusService = new StatusService();
                response = statusService.AddStatus(connection, status);
                return response;
            }
        //Update Status
            [HttpPut]
            [Route("UpdateStatus")]
            public StatusResponse UpdateStatus(Status status)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            StatusResponse response = new StatusResponse();
                StatusService statusService = new StatusService();
                response = statusService.UpdateStatus(connection, status);
                return response;
            }
        //Delete Status
            [HttpDelete]
            [Route("DeleteStatus")]
            public StatusResponse DeleteStatus(int id)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            StatusResponse response = new StatusResponse();
            StatusService statusService = new StatusService();
                response = statusService.DeleteStatus(connection, id);
                return response;
            }


        
    }
}
