using JustASecond.DAL.Data;
using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        /// <summary>
        /// Fügt der Datenbank einen neuen WaiterCall hinzu
        /// </summary>
        /// <param name="waiterCall"></param>
        /// <returns></returns>
        public async Task AddWaiterCall(WaiterCall waiterCall)
        {
            await _context.WaiterCalls.AddAsync(waiterCall);
        }

        /// <summary>
        /// Holt sich alle WaiterCalls aus der Datenbank
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<WaiterCall>> GetWaiterCalls()
        {
            return await _context.WaiterCalls
                                    .Include(x => x.Table)
                                    .ToArrayAsync();
        }
    }
}
