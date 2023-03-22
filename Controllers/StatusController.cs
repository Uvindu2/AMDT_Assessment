using AMDT_Assessment.Models;
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

            [HttpGet]
            [Route("GetAllStatus")]
            public Response GetAllStatus()
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
                Response response = new Response();
            StatusService statusService = new StatusService();
                response = statusService.GetAllStatus(connection);
                return response;
            }

            [HttpGet]
            [Route("GetStatusById/{id}")]
            public Response GetStatusById(int id)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
                Response response = new Response();
            StatusService statusService = new StatusService();
                response = statusService.GetStatusById(connection, id);
                return response;
            }
            [HttpPost]
            [Route("AddStatus")]
            public Response AddStatus(Status status)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
                Response response = new Response();
            StatusService statusService = new StatusService();
                response = statusService.AddStatus(connection, status);
                return response;
            }
            [HttpPut]
            [Route("UpdateStatus")]
            public Response UpdateStatus(Status status, int id)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
                Response response = new Response();
                StatusService statusService = new StatusService();
                response = statusService.UpdateStatus(connection, status);
                return response;
            }

            [HttpDelete]
            [Route("DeleteStatus")]
            public Response DeleteStatus(int id)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
                Response response = new Response();
            StatusService statusService = new StatusService();
                response = statusService.DeleteStatus(connection, id);
                return response;
            }


        
    }
}
