using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Models.Response
{
    public class ProductBidsDetails
    {
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Category { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime BidEndDate { get; set; }

        public List<Bids> BidsDetails { get; set; }
        public ProductBidsDetails()
        {
            BidsDetails = new List<Bids>();
        }
    }
}
