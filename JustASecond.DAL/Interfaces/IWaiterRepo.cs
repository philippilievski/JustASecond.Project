using JustASecond.DAL.Data.Models;

namespace JustASecond.DAL.Interfaces
{
    public interface IWaiterRepo
    {
        Task AddWaiterCall(WaiterCall waiterCall);
        Task<IEnumerable<WaiterCall>> GetPendingWaiterCalls();
        Task<IEnumerable<WaiterCall>> GetCompletedWaiterCalls();
    }
}
