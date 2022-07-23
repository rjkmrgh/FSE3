using eauction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.Builder
{
    public interface IBuilder
    {
        Bids Build();
    }
    
}
