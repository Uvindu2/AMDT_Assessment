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
    public class RoleTypeController : ControllerBase
    {
    

            private readonly IConfiguration _configuration;

            public RoleTypeController(IConfiguration configuration)
            {
                _configuration = configuration;

            }

        //Get All Role Types
            [HttpGet]
            [Route("GetAllRoleTypes")]
            public RoleTypeResponse GetAllRoleTypes()
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            RoleTypeResponse response = new RoleTypeResponse();
            RoleTypeService roleTypeService = new RoleTypeService();
            response = roleTypeService.GetAllRoleType(connection);
                return response;
            }
        //Get Role Type By Id
            [HttpGet]
            [Route("GetRoleTypeById/{id}")]
            public RoleTypeResponse GetRoleTypeById(int id)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            RoleTypeResponse response = new RoleTypeResponse();
            RoleTypeService roleTypeService = new RoleTypeService();
                response = roleTypeService.GetRoleTypeById(connection, id);
                return response;
            }
        //Add Role Type
            [HttpPost]
            [Route("AddRoleType")]
            public RoleTypeResponse AddRoleType(RoleType roleType)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            RoleTypeResponse response = new RoleTypeResponse();
                RoleTypeService roleTypeService = new RoleTypeService();
                response = roleTypeService.AddRoleType(connection, roleType);
                return response;
            }

        //Update Role Type
            [HttpPut]
            [Route("UpdateRoleType")]
            public RoleTypeResponse UpdateRoleType(RoleType roleType)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            RoleTypeResponse response = new RoleTypeResponse();
            RoleTypeService roleTypeService = new RoleTypeService();
                response = roleTypeService.UpdateRoleType(connection, roleType);
                return response;
            }

        //Delete Role Type
            [HttpDelete]
            [Route("DeleteRoleType/{id}")]
            public RoleTypeResponse DeleteRoleType(int id)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
            RoleTypeResponse response = new RoleTypeResponse();
            RoleTypeService roleTypeService = new RoleTypeService();
                response = roleTypeService.DeleteRoleType(connection, id);
                return response;
            }



        
    }
}
