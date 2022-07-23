using eauction.DataSource;
using eauction.Models.Request;
using eauction.Services.Seller;
using EAuction.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Controllers
{
    [ApiController]
    [Route("v1/seller")]
    public class SellerController : Controller
    {
        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet("getseller")]
        public IActionResult Get()
        {
            var resp = "success seller";
            return Ok(resp);
        }

        #region DynamoDB
        [HttpGet("products")]
        public IActionResult GetDBProducts()
        {
            var resp = _sellerService.GetDBAvailableProducts();
            //resp.Wait();
            return Ok(resp.Result);
        }


        [HttpGet("show-bids")]
        public IActionResult GetProductDetails(string productId)
        {
            var resp = _sellerService.GetProductBidsDetails(productId);
            return Ok(resp);
        }

        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody]CreateProduct product)
        {
            var result = _sellerService.ValidateProductRequest(product);
            if (result.Item2)
            {
                var resp = _sellerService.AddProduct(product);
                resp.Wait();
                return Ok(resp.Result);
            }
            return BadRequest(result.Item1);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteProduct([FromBody] ProductRequest product)
        {
            var resp = _sellerService.DeleteProduct(product.ProductId);
            return Ok(resp.Result);
        }
        #endregion

        //#region local
        //[HttpGet("getproducts")]
        //public IActionResult GetProducts()
        //{
        //    var resp = _sellerService.GetProducts();
        //    return Ok(resp);
        //}

        //[HttpGet("get-product-seller")]
        //public IActionResult GetProductsDetails()
        //{
        //    var resp = _sellerService.GetProducts();
        //    return Ok(resp);
        //}
        //#endregion
    }
}
