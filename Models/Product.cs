using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {
        public int id { get; set; }
        public string productName { get; set; }
        public string prodctCategory { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public string description { get; set; }
        public string model { get; set; }
        public string imageUrl { get; set; }
        public string colour { get; set; }

        public Boolean cartStatus { get; set; }
    }
}