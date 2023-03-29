using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthDemo
{
    [Serializable]
    public class JwtAuthResponse
    {
       public int StatusCode { get; set; }
       public string StatusMessage { get; set; }
        public string token { get; set; }
        public string email { get; set; }
        public int expires_in { get; set; }
    }
}
