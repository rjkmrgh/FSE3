using EAuction.API.Models;
using EAuction.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Controllers
{
    public class BuyerController : Controller
    {
        private static ProductBids ProductBids { get; set; }

        public BuyerController()
        {

        }
        static BuyerController()
        {
            LoadProductBids();
        }
        private static void LoadProductBids()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Models\\Bids.json");
            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                ProductBids = JsonConvert.DeserializeObject<ProductBids>(json);
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("place-bid")]
        public Bids PlaceBid(CreateBids bids)
        {
            var newBid = new Bids()
            {
                ProductId = bids.ProductId
            };
            newBid.BuyerDetails.Add(new Buyer()
            {
                FirstName = bids.FirstName,
                LastName = bids.LastName,
                Address = bids.Address,
                City = bids.City,
                Email = bids.Email,
                Phone = bids.Phone,
                State = bids.State,
                Pin = bids.Pin,
                BidAmount = bids.BidAmount
            });
            ProductBids.ProdBids.Add(newBid);
            return newBid;
        }

        [HttpPost("update-bid")]
        public string UpdateBid(UpdateBid newBid)
        {
            var bids = ProductBids.ProdBids.Where(x => x.ProductId == newBid.ProductId).ToList();
             
            return "";
        }
    }
}
