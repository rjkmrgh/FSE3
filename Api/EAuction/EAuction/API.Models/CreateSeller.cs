using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.API.Models
{
    public class CreateSeller
    {
        [Required]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 5 characters required")]
        [StringLength(30, ErrorMessage = "Maximum 30")]
        public string FirstName { get; set; }
        [Required]
        //[RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [StringLength(25, MinimumLength =3 , ErrorMessage = "Maximum 25 or Minimum 3 characters allowed")]
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

        public string Email { get; set; }
    }
}
