using System;
using System.ComponentModel.DataAnnotations;

namespace AMDT_Assessment.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="invalid email address")]  //Emai validation
        public string Email { get; set; }
       [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        public string DateofBirth { get; set; }
       [Required(ErrorMessage ="Role Type is required")]
        public string RoleType { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}


    }
}
