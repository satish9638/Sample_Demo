using Sample_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Test.Data
{
    public interface IBuyerRepository
    {
        Task<Buyer> InsertBuyerAsync(Buyer buyer);
        Buyer GetBuyerByEvent(int EventId);
    }
}
