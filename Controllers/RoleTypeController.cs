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
    public class RoleTypeController : ControllerBase
    {
    

            private readonly IConfiguration _configuration;

            public RoleTypeController(IConfiguration configuration)
            {
                _configuration = configuration;

            }

            [HttpGet]
            [Route("GetAllRoleTypes")]
            public Response GetAllRoleTypes()
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
                Response response = new Response();
            RoleTypeService roleTypeService = new RoleTypeService();
            response = roleTypeService.GetAllRoleType(connection);
                return response;
            }

            [HttpGet]
            [Route("GetRoleTypeById/{id}")]
            public Response GetRoleTypeById(int id)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
                Response response = new Response();
            RoleTypeService roleTypeService = new RoleTypeService();
                response = roleTypeService.GetRoleTypeById(connection, id);
                return response;
            }
            [HttpPost]
            [Route("AddRoleType")]
            public Response AddRoleType(RoleType roleType)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
                Response response = new Response();
                RoleTypeService roleTypeService = new RoleTypeService();
                response = roleTypeService.AddRoleType(connection, roleType);
                return response;
            }
            [HttpPut]
            [Route("UpdateRoleType")]
            public Response UpdateRoleType(RoleType roleType, int id)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
                Response response = new Response();
            RoleTypeService roleTypeService = new RoleTypeService();
                response = roleTypeService.UpdateRoleType(connection, roleType);
                return response;
            }

            [HttpDelete]
            [Route("DeleteRoleType")]
            public Response DeleteRoleType(int id)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("UserManageCon").ToString());
                Response response = new Response();
            RoleTypeService roleTypeService = new RoleTypeService();
                response = roleTypeService.DeleteRoleType(connection, id);
                return response;
            }



        
    }
}
