using eauction.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.API.Models
{
    public class CreateProduct
    {       
        [Required]
        [StringLength(30, MinimumLength =5, ErrorMessage = "Minimum 5  and Maximum 30 characters required")]
        public string ProductName { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string LongDescription { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int StartingPrice { get; set; }
        [Required]
        public DateTime BidEndDate { get; set; }
        [Required]
        public CreateSeller SellerDetails { get; set; }
    }
}
