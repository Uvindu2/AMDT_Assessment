using System;

namespace AMDT_Assessment.Models
{
    public class RoleType
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}
    }
}
