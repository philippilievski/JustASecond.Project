using JustASecond.DAL.Data.Models;
using JustASecond.Web.Data.ModelViews;

namespace JustASecond.DAL.Interfaces
{
    public interface IOrderRepo
    {
        Task AddOrder(Order order);
        Task RemoveOrder(Order order);
        Task<Order> GetOrder(string orderId);
        Task<bool> OrderExists(string orderId);
        Task UpdateOrder(Order order);

        Task AddWaiterOrder(WaiterOrder waiterOrder);
        Task RemoveWaiterOrder(WaiterOrder waiterOrder);
        Task<WaiterOrder> GetWaiterOrder(string orderId, string waiterId);
        Task<bool> WaiterOrderExists(string orderId, string waiterId);
        Task UpdateWaiterOrder(WaiterOrder waiterOrder);

        Task AddTable(Table table);
        Task RemoveTable(Table table);
        Task<IEnumerable<Table>> GetTables();


        Task AddWaiterCall(WaiterCall call);
        Task RemoveWaiterCall(WaiterCall call);
        Task<IEnumerable<WaiterCall>> GetWaiterCalls(string waiterId);

        Task<IEnumerable<OrderPositionView>> GetPositionsAllFromOrder(int orderId);
    }
}
