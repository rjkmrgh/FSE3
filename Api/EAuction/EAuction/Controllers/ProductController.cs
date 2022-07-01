﻿using EAuction.Models;
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
    public class ProductController : ControllerBase
    {

        private List<Product> Products { get; set; }

        public ProductController()
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
            }) ;
        }

        [HttpGet("Products")]
        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        [HttpGet("ProductName")]
        public Product GetProductByName(string productName)
        {
            return Products.Where(x => x.ProductName == productName).FirstOrDefault();
        }
        // GET: ProductController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: ProductController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: ProductController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ProductController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
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

        //// GET: ProductController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ProductController/Edit/5
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

        //// GET: ProductController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ProductController/Delete/5
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
