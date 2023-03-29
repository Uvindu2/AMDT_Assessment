using System.Collections.Generic;
using AMDT_Assessment.Models;

namespace AMDT_Assessment.Response
{
    public class RoleTypeResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public RoleType roleType { get; set; }
        public List<RoleType> listRoleType { get; set; }
    }
}
