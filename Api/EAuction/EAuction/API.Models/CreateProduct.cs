using EAuction.Models;
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
        public Category Category { get; set; }
        [Required]
        public decimal StartingPrice { get; set; }
        [Required]
        public DateTime BidEndDate { get; set; }
        [Required]
        public CreateSeller SellerDetails { get; set; }
        public CreateProduct()
        {
            SellerDetails = new CreateSeller();
        }
    }
}
