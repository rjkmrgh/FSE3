using eauction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Builder
{
    public class BidBuilder : IBuilder
    {
        private readonly Bids _bid = new Bids();
        public BidBuilder WithName(string name)
        {
            _bid.FirstName = name;
            return this;
        }
        public BidBuilder WithAmount(decimal amount)
        {
            _bid.BidAmount = amount;
            return this;
        }
        public BidBuilder WithPhone(string phone)
        {
            _bid.Phone = phone;
            return this;
        }
        public BidBuilder WithEmail(string email)
        {
            _bid.Email = email;
            return this;
        }
        public Bids Build()
        {
            return _bid;
        }
    }
}
