using JustASecond.DAL.Data;
using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Data.ModelViews;
using JustASecond.DAL.Interfaces;
using JustASecond.Web.Data.ModelViews;
using Microsoft.EntityFrameworkCore;

namespace JustASecond.DAL.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private ApplicationDbContext db;

        public OrderRepo(ApplicationDbContext db)
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }

            this.db = db;
        }

        public async Task<IEnumerable<OrderView>> GetAllOrders()
        {
            return await db.Orders!
                .Select(x => new OrderView
                {
                    Id = x.Id,
                    CreateDate = x.CreatedDate,
                    Table = new TableView
                    {
                        Id = x.Table.Id,
                        HasCalled = x.Table.HasCalled
                    }
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllPendingOrders()
        {
            return await db.Orders!
                .Include(x => x.Table)
                .Where(x => x.Sent && x.Completed == null)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> GetAllCompletedOrders()
        {
            return await db.Orders!
                .Include(x => x.Table)
                .Where(x => x.Completed != null)
                .ToArrayAsync();
        }

        public async Task AddOrder(Order order)
        {
            await db.Orders!.AddAsync(order);
            await db.SaveChangesAsync();
        }

        public async Task AddTable(Table table)
        {
            await db.Tables!.AddAsync(table);
            await db.SaveChangesAsync();
        }

        public async Task AddWaiterCall(WaiterCall call)
        {
            await db.WaiterCalls!.AddAsync(call);
            await db.SaveChangesAsync();
        }

        public async Task AddWaiterOrder(WaiterOrder waiterOrder)
        {
            await db.WaiterOrders!.AddAsync(waiterOrder);
            await db.SaveChangesAsync();
        }

        public async Task<Order> GetOrder(int orderId)
        {
            var query = from o in db.Orders
                        where o.Id == orderId
                        select o;

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Table>> GetTables()
        {
            var query = from o in db.Tables
                        select o;

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<WaiterCall>> GetWaiterCalls(string waiterId)
        {
            var query = from w in db.WaiterCalls
                        where w.WaiterId == waiterId
                        select w;

            return await query.ToListAsync();
        }

        public async Task<WaiterOrder> GetWaiterOrder(int orderId, string waiterId)
        {
            var query = from w in db.WaiterOrders
                        where w.OrderId == orderId && w.WaiterId == waiterId
                        select w;

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> OrderExists(int orderId)
        {
            var query = from o in db.Orders
                        where o.Id == orderId
                        select o;

            return await query.AnyAsync();
        }

        public async Task RemoveOrder(Order order)
        {
            db.Orders!.Remove(order);
            await db.SaveChangesAsync();
        }

        public async Task RemoveTable(Table table)
        {
            db.Tables!.Remove(table);
            await db.SaveChangesAsync();
        }

        public async Task RemoveWaiterCall(WaiterCall call)
        {
            db.WaiterCalls!.Remove(call);
            await db.SaveChangesAsync();
        }

        public async Task RemoveWaiterOrder(WaiterOrder waiterOrder)
        {
            db.WaiterOrders!.Remove(waiterOrder);
            await db.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            db.Orders!.Update(order);
            await db.SaveChangesAsync();
        }

        public async Task UpdateWaiterOrder(WaiterOrder waiterOrder)
        {
            db.WaiterOrders!.Update(waiterOrder);
            await db.SaveChangesAsync();
        }

        public async Task<bool> WaiterOrderExists(int orderId, string waiterId)
        {
            var query = from w in db.WaiterOrders
                        where w.OrderId == orderId && w.WaiterId == waiterId
                        select w;

            return await query.AnyAsync();
        }

        public async Task<IEnumerable<OrderPositionView>> GetAllPositionsFromOrder(int orderId)
        {
            return await db.OrderPositions!
                .Where(x => x.OrderId == orderId)
                .Include(x => x.Product)
                .Select(x => new OrderPositionView
                {
                    OrderId = x.OrderId,
                    Position = x.Position,
                    Amount = x.Amount,
                    Product = new ProductView
                    {
                        Id = x.Product.Id,
                        Title = x.Product.Title,
                        Price = x.Product.Price
                    }
                })
                .ToListAsync();
        }

        public async Task<int?> GetHighestPositionFromOrderposition(Order order)
        {
            int? highest = await db.OrderPositions
                            .Where(x => x.OrderId == order.Id)
                            .MaxAsync(x => (int?)x.Position);

            if (highest == null)
            {
                highest = 0;
                return highest;
            }

            return highest;
        }

        public async Task<int> GetHighestOrderID()
        {
            var highest = db.Orders
                            .MaxAsync(x => x.Id);

            return await highest;
        }

        public async Task<Table> GetTableByID(int tableid)
        {
            var table = db.Tables!
                            .Where(x => x.Id == tableid)
                            .FirstOrDefaultAsync();

            return await table;
        }

        public async Task<List<OrderPosition>> GetOrderPositionsFromOrder(Order order)
        {
            var orderpositions = db.OrderPositions!
                                    .Include(x => x.Order)
                                    .Include(x => x.Product)
                                    .Where(x => x.Order!.Id == order.Id)
                                    .ToListAsync();

            return await orderpositions;
        }

        public async Task<OrderPosition> GetOrderPositionFromProductId(int orderId, int productId)
        {
            return await db.OrderPositions
                .Include(x => x.Product)
                .Where(x => x.OrderId == orderId && x.Product.Id == productId)
                .FirstOrDefaultAsync();
        }

        public async Task RemoveOrderPosition(int orderId, int position)
        {
            var foundOrderPosition = await db.OrderPositions
                .Where(x => x.OrderId == orderId && x.Position == position)
                .FirstOrDefaultAsync();
            db.OrderPositions.Remove(foundOrderPosition);
        }

        public async Task SetOrderPositionAmount(int orderId, int position, int amount)
        {
            var orderPosition = await db.OrderPositions
                .Where(x => x.OrderId == orderId && x.Position == position)
                .FirstOrDefaultAsync();
            orderPosition.Amount = amount;
            db.OrderPositions.Update(orderPosition);
        }

        public async Task SetOrderCompleted(int orderId, DateTime? completedDate)
        {
            var order = await db.Orders
                .Where(x => x.Id == orderId)
                .FirstOrDefaultAsync();
            order.Completed = completedDate;
            db.Orders.Update(order);
        }

        public async Task SetOrderSent(int orderId, bool sent)
        {
            var orderupdated = await db.Orders
                            .Where(x => x.Id == orderId)
                            .FirstOrDefaultAsync();
            orderupdated.Sent = sent;
            db.Orders.Update(orderupdated);
        }

        public async Task<List<Order>> GetOrderHistoryFromCustomer(Customer customer)
        {

            return await db.Orders
                            .Include(x => x.Customer)
                            .Include(x => x.OrderPositions)
                            .Where(x => x.Customer == customer)
                            .Where(x => x.Sent == true)
                            .ToListAsync();
        }
    }
}