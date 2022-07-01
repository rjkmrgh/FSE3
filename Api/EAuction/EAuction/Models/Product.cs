using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Category Category { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime BidEndDate { get; set; }

    }
}
