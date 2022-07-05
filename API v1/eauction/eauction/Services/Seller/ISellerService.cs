using eauction.Models;
using eauction.Models.Dynamo;
using eauction.Models.Response;
using EAuction.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Services.Seller
{
    public interface ISellerService
    {
        Task<Product> AddProduct(CreateProduct product);

        Task<string> DeleteProduct(string productid);

        List<AvailableProducts> GetProducts();

        Task<List<AvailableProducts>> GetDBAvailableProducts();

        Task<List<Product>> GetDBProductDetails(string productid);

        Task<List<ProductBids>> GetDBProductBidsDetails(string productid);

        ProductBidsDetails GetProductBidsDetails(string productid);

        string ValidateProductRequest(CreateProduct product);
    }
}
