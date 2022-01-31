using JustASecond.DAL.Data;
using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustASecond.DAL.Repos
{
    public class WaiterRepo : IWaiterRepo
    {
        private ApplicationDbContext _context;

        public WaiterRepo(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task AddWaiterCall(WaiterCall waiterCall)
        {
            await _context.WaiterCalls.AddAsync(waiterCall);
        }
        public async Task<IEnumerable<WaiterCall>> GetWaiterCalls()
        {
            return await _context.WaiterCalls.Include(x => x.Table).ToArrayAsync();
        }
    }
}
