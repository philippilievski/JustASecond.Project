using JustASecond.DAL.Data;
using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<WaiterCall>> GetPendingWaiterCalls()
        {
            return await _context.WaiterCalls
                                    .Include(x => x.Table)
                                    .Where(x => x.AcceptedAt == null)
                                    .ToArrayAsync();
        }

        public async Task<IEnumerable<WaiterCall>> GetCompletedWaiterCalls()
        {
            return await _context.WaiterCalls
                                    .Include(x => x.Table)
                                    .Where(x => x.AcceptedAt != null)
                                    .ToArrayAsync();
        }
    }
}
