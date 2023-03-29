using System;
using System.ComponentModel.DataAnnotations;

namespace AMDT_Assessment.Models
{
    public class Status
    {
        public int StatusID { get; set; }
        [Required(ErrorMessage = "Status Name is required")]
        public string StatusName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}
    }
}
