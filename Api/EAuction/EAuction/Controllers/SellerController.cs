using EAuction.API.Models;
using EAuction.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController : ControllerBase
    {
        
        private List<Product> Products { get; set; }

        public SellerController()
        {
            Products = new List<Product>();
            Products.Add(new Product()
            {
                ProductName = "TV",
                ShortDescription = "LCD",
                Category = Category.SCULPTOR,
                LongDescription = "LCD TV Model",
                StartingPrice = 1000,
                BidEndDate = new DateTime(2022, 08, 01)
            });
            Products.Add(new Product()
            {
                ProductName = "IPod",
                ShortDescription = "v0.0",
                Category = Category.PAINTING,
                LongDescription = "iPod large Model",
                StartingPrice = 3000,
                BidEndDate = new DateTime(2022, 09, 01)
            });
            Products.Add(new Product()
            {
                ProductName = "iPhone",
                ShortDescription = "12",
                Category = Category.SCULPTOR,
                LongDescription = "iPhone 12 max Model",
                StartingPrice = 1000,
                BidEndDate = new DateTime(2022, 11, 01)
            });
            Products.Add(new Product()
            {
                ProductName = "iMac",
                ShortDescription = "screen",
                Category = Category.SCULPTOR,
                LongDescription = "iMac TV Model",
                StartingPrice = 32000,
                BidEndDate = new DateTime(2022, 09, 01)
            });
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

        [HttpPost("AddProduct")]
        public ActionResult Create([FromBody] CreateProduct product)
        {
            if (!ModelState.IsValid)
            {

            }
            Products.Add(new Product()
            {
                ProductName = product.ProductName,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                Category = product.Category,
                StartingPrice = product.StartingPrice,
                BidEndDate = product.BidEndDate
            });
            return null;
        }

        [HttpGet("productId")]
        public Product GetProduct(int productId)
        {
            return Products.Where(x => x.ProductId == productId).FirstOrDefault();
        }
        //// GET: SellerController
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //// GET: SellerController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: SellerController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: SellerController/Create
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult Create(IFormCollection collection)
        ////{
        ////    try
        ////    {
        ////        return RedirectToAction(nameof(Index));
        ////    }
        ////    catch
        ////    {
        ////        return View();
        ////    }
        ////}

        //// GET: SellerController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: SellerController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: SellerController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: SellerController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
