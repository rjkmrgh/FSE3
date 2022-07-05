using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Models
{
    public class UpdateBid
    {
        public string ProductId { get; set; }

        public string Email { get; set; }

        public int BidAmount { get; set; }
    }
}
