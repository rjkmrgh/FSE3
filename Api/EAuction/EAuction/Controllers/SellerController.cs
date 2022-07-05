using EAuction.API.Models;
using EAuction.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController : ControllerBase
    {
        
        private List<Product> Products { get; set; }
        private static ProductBids ProductBids { get; set; }

        public SellerController()
        {
            Products = new List<Product>(); 
            LoadProducts();
            //LoadProductBids();
            
        }
        
        [HttpGet("Products")]
        public IEnumerable<Product> GetProducts()
        {
            return Products;//.Select(x => x.ProductName).ToList();
        }

        [HttpGet("ProductName")]
        public Product GetProductByName(string productName)
        {
            return Products.Where(x => x.ProductName == productName).FirstOrDefault();
        }

        [HttpGet("productId")]
        public Product GetProduct(int productId)
        {
            return Products.Where(x => x.ProductId == productId).FirstOrDefault();
        }

        [HttpPost("AddProduct")]
        public Product Create([FromBody] CreateProduct product)
        {

            if (product.BidEndDate < DateTime.Today)
            {
                throw new Exception("BidEndDate should be future date.");
            }
            Product pd = new Product()
            {
                ProductName = product.ProductName,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                Category = product.Category,
                StartingPrice = product.StartingPrice,
                BidEndDate = product.BidEndDate,
                ProductId = 1
            };

            Seller s = new Seller()
            {
                FirstName = product.SellerDetails.FirstName
            };
            Products.Add(pd);
            return pd;
        }

        // POST: SellerController/Delete/5
        [HttpPost]
        public int Delete(int ProductId)
        {
            Product pd = Products.Where(x => x.ProductId == ProductId).FirstOrDefault();
            
            if(pd != null)
            {
                if (pd.BidEndDate < DateTime.Today)
                {
                    throw new Exception("Bid end date crossed..");
                }

            }
            Products.Remove(pd);
           return 0;
        }

        private void LoadProducts()
        {
            Products.Add(new Product()
            {
                ProductId = 1,
                ProductName = "TV",
                ShortDescription = "LCD",
                Category = Category.SCULPTOR,
                LongDescription = "LCD TV Model",
                StartingPrice = 1000,
                BidEndDate = new DateTime(2022, 08, 01)
            });
            Products.Add(new Product()
            {
                ProductId = 2,
                ProductName = "IPod",
                ShortDescription = "v0.0",
                Category = Category.PAINTING,
                LongDescription = "iPod large Model",
                StartingPrice = 3000,
                BidEndDate = new DateTime(2022, 09, 01)
            });
            Products.Add(new Product()
            {
                ProductId = 3,
                ProductName = "iPhone",
                ShortDescription = "12",
                Category = Category.SCULPTOR,
                LongDescription = "iPhone 12 max Model",
                StartingPrice = 1000,
                BidEndDate = new DateTime(2022, 11, 01)
            });
            Products.Add(new Product()
            {
                ProductId = 4,
                ProductName = "iMac",
                ShortDescription = "screen",
                Category = Category.SCULPTOR,
                LongDescription = "iMac TV Model",
                StartingPrice = 32000,
                BidEndDate = new DateTime(2022, 09, 01)
            });
            Products.Add(new Product()
            {
                ProductId = 5,
                ProductName = "Laptop",
                ShortDescription = "Laptop screen",
                Category = Category.SCULPTOR,
                LongDescription = "iMac Laptop Model",
                StartingPrice = 5000,
                BidEndDate = new DateTime(2022, 12, 01)
            });
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
    }
}
