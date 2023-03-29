using AMDT_Assessment.Models;
using System.Collections.Generic;

namespace AMDT_Assessment.Response
{
    public class StatusResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Status status { get; set; }
        public List<Status> listStatus { get; set; }
    }
}
