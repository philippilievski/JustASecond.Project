using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Data.ModelViews;
using JustASecond.Web.Data.ModelViews;

namespace JustASecond.DAL.Interfaces
{
    public interface IOrderRepo
    {
        Task<IEnumerable<OrderView>> GetAllOrders();
        Task AddOrder(Order order);
        Task RemoveOrder(Order order);
        Task<Order> GetOrder(int orderId);
        Task<bool> OrderExists(int orderId);
        Task UpdateOrder(Order order);

        Task AddWaiterOrder(WaiterOrder waiterOrder);
        Task RemoveWaiterOrder(WaiterOrder waiterOrder);
        Task<WaiterOrder> GetWaiterOrder(int orderId, string waiterId);
        Task<bool> WaiterOrderExists(int orderId, string waiterId);
        Task UpdateWaiterOrder(WaiterOrder waiterOrder);

        Task AddTable(Table table);
        Task RemoveTable(Table table);
        Task<IEnumerable<Table>> GetTables();


        Task AddWaiterCall(WaiterCall call);
        Task RemoveWaiterCall(WaiterCall call);
        Task<IEnumerable<WaiterCall>> GetWaiterCalls(string waiterId);

        Task<IEnumerable<OrderPositionView>> GetAllPositionsFromOrder(int orderId);
    }
}
