using Microsoft.EntityFrameworkCore;
using Sample_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Test.Data
{
    public class EventRepository : IEventRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public EventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Event> GetDefaultEvent()
        {
            return await _dbContext.Event.FirstOrDefaultAsync();
        }
    }
}
