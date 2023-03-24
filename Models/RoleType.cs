using System;
using System.ComponentModel.DataAnnotations;

namespace AMDT_Assessment.Models
{
    public class RoleType
    {
        public int RoleID { get; set; }
        [Required(ErrorMessage = "RoleName is required")]
        public string RoleName { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}
    }
}
