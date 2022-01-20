using JustASecond.DAL.Data.Models;

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
        Task UpdateOrder(WaiterOrder waiterOrder);

        Task AddTable(Table table);
        Task RemoveTable(Table table);
        Task<IEnumerable<Table>> GetTables();
    }
}
