using System;
using System.ComponentModel.DataAnnotations;

namespace AMDT_Assessment.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [EmailAddress]  //Emai validation
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateofBirth { get; set; }
        public int RoleType { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}


    }
}
