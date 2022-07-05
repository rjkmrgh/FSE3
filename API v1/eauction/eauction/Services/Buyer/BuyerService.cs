using Amazon.DynamoDBv2.DataModel;
using eauction.Models;
using eauction.Models.Dynamo;
using eauction.Models.Request;
using eauction.Services.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Services.Buyer
{
    public class BuyerService : IBuyerService
    {


        public IDynamoDBContext _dynamoDBContext { get; }
        private readonly ISellerService _sellerService;

        public BuyerService(IDynamoDBContext dynamoDBContext, ISellerService sellerService)
        {
            _dynamoDBContext = dynamoDBContext;
            _sellerService = sellerService;
        }
        public async Task<string> PlaceBid(CreateBuyerBid bid)
        {

            var prod = _sellerService.GetProductBidsDetails(bid.ProductId);

            if (!string.IsNullOrEmpty(prod.ProductName) && prod.BidEndDate > DateTime.Today &&
                prod.BidsDetails.Where(p => p.Email == bid.Email).Count() == 0)
            {
                ProductBids pb = new ProductBids()
                {
                    Email = bid.Email,
                    Phone = bid.Phone,
                    FirstName = bid.FirstName,
                    LastName = bid.LastName,
                    Address = bid.Address,
                    City = bid.City,
                    State = bid.State,
                    Pin = bid.Pin,
                    BidAmount = bid.BidAmount,
                    ProductId = bid.ProductId
                };

                await _dynamoDBContext.SaveAsync(pb);
                
                return "Success";
            }
            else
                return "Invalid Bid. Unable to add..!";

        }

        public async Task<string> UpdateBid(UpdateBidRequest bid)
        {
            var prod = _sellerService.GetDBProductDetails(bid.ProductId);
            DateTime bidEndDate = DateTime.Today;

            foreach (var item in prod.Result)
            {
                if (item.BidEndDate < DateTime.Today)
                {
                    return "BidEndDate is expired..";
                }
            }

            var bids = _sellerService.GetDBProductBidsDetails(bid.ProductId);
            foreach (var item in bids.Result)
            {
                if (item.Email == bid.Email)
                {

                    ProductBids pb = new ProductBids()
                    {
                        Email = bid.Email,
                        BidAmount = bid.BidAmount,
                        Phone = item.Phone,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Address = item.Address,
                        City = item.City,
                        State = item.State,
                        Pin = item.Pin,
                        ProductId = item.ProductId
                    };

                    await _dynamoDBContext.SaveAsync(pb);

                }
            }
            return "Success";
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
