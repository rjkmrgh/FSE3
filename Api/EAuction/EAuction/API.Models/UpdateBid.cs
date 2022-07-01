using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.API.Models
{
    public class UpdateBid
    {
        [Required]
        public int ProductId { get; set; }
        [Required] 
        public string Email { get; set; }
        [Required] 
        public int BidAmount { get; set; }
    }
}
