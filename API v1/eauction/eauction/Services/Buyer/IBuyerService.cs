using eauction.Models;
using eauction.Models.Dynamo;
using eauction.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Services.Buyer
{
    public interface IBuyerService
    {
        Task<string> PlaceBid(CreateBuyerBid bid);

        Task<string> UpdateBid(UpdateBidRequest bid);
    }
}
