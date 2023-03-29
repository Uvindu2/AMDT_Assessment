using System.Collections.Generic;
using WebApplication1.Models;

namespace AMDT_Assessment.Response
{
    public class CustomerResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Customer customer { get; set; }
        public List<Customer> listCustomer { get; set; }
    }
}
