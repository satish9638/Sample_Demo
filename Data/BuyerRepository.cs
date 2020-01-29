using Microsoft.EntityFrameworkCore;
using Sample_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Test.Data
{
    public class BuyerRepository : IBuyerRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public BuyerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Buyer> InsertBuyerAsync(Buyer buyer)
        {
            _dbContext.Buyer.Add(buyer);
            await _dbContext.SaveChangesAsync();
            return buyer;
        }

        public Buyer GetBuyerByEvent(int EventId)
        {
            var buyer = _dbContext.Buyer.FirstOrDefault(x => x.EventId == EventId && x.TesterKey == "satishmiroliya14");            
            return buyer;
        }
    }
}
