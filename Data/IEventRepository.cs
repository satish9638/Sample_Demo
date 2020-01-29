using Sample_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Test.Data
{
    public interface IEventRepository
    {
        Task<Event> GetDefaultEvent();
    }
}
