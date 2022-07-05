using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Models
{
    public class Bids
    {
        //public string BidAmount { get; set; }
        //public string Name { get; set; }
        //public string Phone { get; set; }
        //public string Email { get; set; }
        public int ProductId { get; set; }

        public List<Buyer> BuyerDetails { get; set; }
        public Bids()
        {
            BuyerDetails = new List<Buyer>();
        }
    }
}

