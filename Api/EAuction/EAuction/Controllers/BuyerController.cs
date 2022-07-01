using EAuction.API.Models;
using EAuction.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Controllers
{
    public class BuyerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("place-bid")]
        public string PlaceBid(CreateBids bids)
        {

            return "";
        }

        [HttpPost("update-bid")]
        public string UpdateBid(UpdateBid newBid)
        {

            return "";
        }
    }
}
