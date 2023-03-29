using System;
using System.ComponentModel.DataAnnotations;

namespace JwtAuthDemo
{
    [Serializable]
    public class AuthenticationRequest
    {
        [Required(ErrorMessage = "Email is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
