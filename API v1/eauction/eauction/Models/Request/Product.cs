using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Category { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime BidEndDate { get; set; }

       // public Seller SellerDetails { get; set; }
    }
}
