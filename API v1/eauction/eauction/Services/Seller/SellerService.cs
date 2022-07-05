using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using eauction.DataSource;
using eauction.Models;
using eauction.Models.Dynamo;
using eauction.Models.Request;
using eauction.Models.Response;
using EAuction.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Services.Seller
{
    public class SellerService : ISellerService
    {
        private Products ProductDetails { get; set; }
        public IDynamoDBContext _dynamoDBContext { get; }

        public SellerService(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        public string ValidateProductRequest(CreateProduct product)
        {
            string sellerRowId = "Seller_" + generateRowId();

            if (product.BidEndDate < DateTime.Today)
            {
                return  "BidEndDate should be future date.";
            }
            if (!Enum.IsDefined(typeof(Category), product.Category.ToUpper()))
            {
                return  "Invalid Category...";
            }
            return "valid";
        }
        public async Task<Product> AddProduct(CreateProduct product)
        {
            string sellerRowId =  "Seller_" + generateRowId();
         
            SellerInfo s = new SellerInfo() { 
                Email = product.SellerDetails.Email,
                Phone = product.SellerDetails.Phone,
                FirstName = product.SellerDetails.FirstName,
                LastName = product.SellerDetails.LastName,
                Address = product.SellerDetails.Address,
                City = product.SellerDetails.City,
                State = product.SellerDetails.State,
                Pin = product.SellerDetails.Pin,
                SellerId = sellerRowId
            };

            await _dynamoDBContext.SaveAsync(s);

            string prodRowId = "Prod_" + generateRowId();
            Product p = new Product()
            {
                ProductId = prodRowId,
                ProductName = product.ProductName,
                Category = product.Category.ToString(),
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                StartingPrice = product.StartingPrice,
                BidEndDate = product.BidEndDate
            };
            await _dynamoDBContext.SaveAsync(p);
            
            return p;
        }

        public async Task<string> DeleteProduct(string productid)
        {
            DateTime bidDate = DateTime.Today;
            var pTask = GetDBProductDetails(productid);
            
            foreach (var item in pTask.Result)
            {
                bidDate = item.BidEndDate;
            }
            if (bidDate > DateTime.Today)
            {
                await _dynamoDBContext.DeleteAsync<Product>(productid);
            }
            else
            {
                return "Unabled to delete... BidEnd date is crossed..!";
            }
            return "Deleted Successfully!";
        }

        public ProductBids GetProductDetails(int productid)
        {
            throw new NotImplementedException();
        }

        public List<AvailableProducts> GetProducts()
        {
            List<AvailableProducts> response = new List<AvailableProducts>();
            
            try
            {
                var resp = TestData.GetProducuts();
                foreach (var item in resp)
                {
                    response.Add(new AvailableProducts()
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName
                    });
                }
                
            }
            catch (Exception e)
            {

                throw ;
            }
            return response;
        }

        /// <summary>
        /// get product id and name
        /// </summary>
        /// <returns></returns>
        public async Task<List<AvailableProducts>> GetDBAvailableProducts()
        {
            List<AvailableProducts> response = new List<AvailableProducts>();

            try
            {
                var conditions = new List<ScanCondition>();
                var resp = await _dynamoDBContext.ScanAsync<Product>(conditions).GetRemainingAsync();
                foreach (var item in resp)
                {
                    response.Add(new AvailableProducts()
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName
                    });
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return response;
        }
        /// <summary>
        /// Show bids
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public ProductBidsDetails GetProductBidsDetails(string productid)
        {
            ProductBidsDetails pb = new ProductBidsDetails();

            var pTask = GetDBProductDetails(productid);

            foreach (var item in pTask.Result)
            {
                pb.ProductName = item.ProductName;
                pb.ShortDescription = item.ShortDescription;
                pb.LongDescription = item.LongDescription;
                pb.Category = item.Category;
                pb.StartingPrice = item.StartingPrice;
                pb.BidEndDate = item.BidEndDate;
            }

            var pbTask = GetDBProductBidsDetails(productid);

            foreach (var item in pbTask.Result)
            {
                pb.BidsDetails.Add(new Bids()
                {
                    FirstName = item.FirstName,
                    BidAmount = item.BidAmount,
                    Email = item.Email,
                    Phone = item.Phone
                });                 
            }

            return pb;
        }
        
        /// <summary>
        /// Show bids - to get product info for product id
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public async Task<List<Product>> GetDBProductDetails(string productid)
        {
            List<Product> response = null;
            try
            {
                var conditions = new List<ScanCondition>();
                conditions.Add(new ScanCondition("ProductId", ScanOperator.Equal, productid));
                response = await _dynamoDBContext.ScanAsync<Product>(conditions).GetRemainingAsync();                 
            }
            catch (Exception e)
            {
                throw;
            }
            return response;
        }
        /// <summary>
        /// Show bids - to get Bids info for product id
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public async Task<List<ProductBids>> GetDBProductBidsDetails(string productid)
        {
            List<ProductBids> response = null;

            try
            {
                var conditions = new List<ScanCondition>();
                conditions.Add(new ScanCondition("ProductId", ScanOperator.Equal, productid));
                response = await _dynamoDBContext.ScanAsync<ProductBids>(conditions).GetRemainingAsync();

            }
            catch (Exception e)
            {
                throw;
            }
            return response;
        }

         
        private string generateRowId()
        {
            Random random = new Random();
            var ts = new DateTime().Ticks.ToString();
            var randid = random.Next();
             
            return String.Format("{0}_{1}", ts, randid);
        }
    }
}
