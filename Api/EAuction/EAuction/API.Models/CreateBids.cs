using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.API.Models
{
    public class CreateBids
    {
        [Required]
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required] 
        public string City { get; set; }
        [Required] 
        public string State { get; set; }
        [Required] 
        public string Pin { get; set; }
        [Required] 
        public string Phone { get; set; }
        [Required] 
        public string Email { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal BidAmount { get; set; }
    }
}
}
