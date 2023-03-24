using System.Collections.Generic;
using AMDT_Assessment.Models;

namespace AMDT_Assessment.Response
{
    public class UserResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public User User { get; set; }
        public List<User> listUser { get; set; }

        public Tokens token { get; set; }

    }
}
