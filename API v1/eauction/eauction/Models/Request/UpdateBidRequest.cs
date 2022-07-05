using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Models.Request
{
    public class UpdateBidRequest
    {
        [Required]
        public string ProductId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int BidAmount { get; set; }
    }
}
