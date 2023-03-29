using AMDT_Assessment.Models;
using System.Collections.Generic;
using WebApplication1.Models;

namespace AMDT_Assessment.Response
{
    public class ProductResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Product product { get; set; }
        public List<Product> listProduct { get; set; }
    }
}
