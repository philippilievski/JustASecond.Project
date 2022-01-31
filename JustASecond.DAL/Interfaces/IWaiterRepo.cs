using JustASecond.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustASecond.DAL.Interfaces
{
    public interface IWaiterRepo
    {
        public Task AddWaiterCall(WaiterCall waiterCall);

        public Task<IEnumerable<WaiterCall>> GetWaiterCalls();


    }
}
