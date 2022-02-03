using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Data.ModelViews;
using JustASecond.Web.Data.ModelViews;

namespace JustASecond.DAL.Interfaces
{
    public interface IOrderRepo
    {
        Task<IEnumerable<OrderView>> GetAllOrders();
        Task<IEnumerable<Order>> GetAllPendingOrders();
        Task<IEnumerable<Order>> GetAllCompletedOrders();
        Task AddOrder(Order order);
        Task<Order> GetOrder(int orderId);
        Task AddTable(Table table);
        Task<IEnumerable<Table>> GetTables();
        Task AddWaiterCall(WaiterCall call);
        Task<IEnumerable<OrderPositionView>> GetAllPositionsFromOrder(int orderId);
        Task<int?> GetHighestPositionFromOrderposition(Order order);
        Task<Table> GetTableByID(int tableid);
        Task<List<OrderPosition>> GetOrderPositionsFromOrder(Order order);
        Task<OrderPosition> GetOrderPositionFromProductId(int orderId, int productId);
        Task RemoveOrderPosition(int orderId, int position);
        Task SetOrderPositionAmount(int orderId, int position, int amount);
        Task<List<Order>> GetOrderHistoryFromCustomer(Customer customer);
        Task SetOrderSent(int orderId, bool sent);
        Task SetOrderCompleted(int orderId, DateTime? completedDate);
    }
}
