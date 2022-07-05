using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Models.Request
{
    public class CreateBuyerBid
    {
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Minimum 5  and Maximum 30 characters allowed")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Minimum 3 and Maximum 25 characters allowed")]
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
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required]
        public decimal BidAmount { get; set; }
    }
}
