using System;

namespace AMDT_Assessment.Models
{
    public class Status
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}
    }
}
