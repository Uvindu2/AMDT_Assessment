using System.Collections.Generic;

namespace AMDT_Assessment.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public User User { get; set; }

        public Login login { get; set; }
    
        public List<User> listUser { get; set; }

        public Status status { get; set; }
        public List<Status> listStatus { get; set; }

        public RoleType roleType { get; set; }
        public List<RoleType> listRoleType { get; set; }
    }
}
