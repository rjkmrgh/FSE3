using eauction.Models.Request;
using eauction.Services.Buyer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Controllers
{
    [ApiController]
    [Route("v1/buyer")]
    public class BuyerController : Controller
    {

        private readonly IBuyerService _buyerService;

        public BuyerController(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }
        [HttpGet("getbuyer")]
        public IActionResult Get()
        {
            var resp = "success buyer";
            return Ok(resp);
        }

        [HttpPost("place-bid")]
        public IActionResult PlaceBid([FromBody]CreateBuyerBid bid)
        {
            var resp = _buyerService.PlaceBid(bid);
            if (resp.Result == "Success")
            {
                return Ok("Added Successfully.!");
            }
            else
            {
                return BadRequest("Invalid Bid. Unable to add..!");
            }
        }

        [HttpPost("update-bid")]
        public IActionResult UpdateBid([FromBody]UpdateBidRequest newBid)
        {
            var resp = _buyerService.UpdateBid(newBid);
            if (resp.Result == "Success")
            {
                return Ok("Updated Successfully.!");
            }
            else
            {
                return BadRequest("Invalid Bid. BidEndDate is expired... Unable to update..!");
            }
        }
    }
}
