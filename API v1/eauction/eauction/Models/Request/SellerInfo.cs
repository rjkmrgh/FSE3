using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Models
{
    public class SellerInfo
    {
        public string SellerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
