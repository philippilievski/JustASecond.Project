using JustASecond.DAL.Data;
using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustASecond.DAL.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private ApplicationDbContext _db;

        public OrderRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddOrder(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
        }

        public async Task AddTable(Table table)
        {
            await _db.Tables.AddAsync(table);
            await _db.SaveChangesAsync();
        }

        public async Task AddWaiterCall(WaiterCall call)
        {
            await _db.WaiterCalls.AddAsync(call);
            await _db.SaveChangesAsync();
        }

        public async Task AddWaiterOrder(WaiterOrder waiterOrder)
        {
            await _db.WaiterOrders.AddAsync(waiterOrder);
            await _db.SaveChangesAsync();
        }

        public async Task<Order> GetOrder(string orderId)
        {
            var query = from o in _db.Orders
                        where o.Id == orderId
                        select o;

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Table>> GetTables()
        {
            var query = from o in _db.Tables
                       select o;

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<WaiterCall>> GetWaiterCalls(string waiterId)
        {
            var query = from w in _db.WaiterCalls
                        where w.WaiterId == waiterId
                        select w;

            return await query.ToListAsync();
        }

        public async Task<WaiterOrder> GetWaiterOrder(string orderId, string waiterId)
        {
            var query = from w in _db.WaiterOrders
                        where w.OrderId == orderId && w.WaiterId == waiterId
                        select w;

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> OrderExists(string orderId)
        {
            var query = from o in _db.Orders
                        where o.Id == orderId
                        select o;

            return await query.AnyAsync();
        }

        public async Task RemoveOrder(Order order)
        {
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveTable(Table table)
        {
            _db.Tables.Remove(table);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveWaiterCall(WaiterCall call)
        {
            _db.WaiterCalls.Remove(call);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveWaiterOrder(WaiterOrder waiterOrder)
        {
            _db.WaiterOrders.Remove(waiterOrder);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateWaiterOrder(WaiterOrder waiterOrder)
        {
            _db.WaiterOrders.Update(waiterOrder);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> WaiterOrderExists(string orderId, string waiterId)
        {
            var query = from w in _db.WaiterOrders
                        where w.OrderId == orderId && w.WaiterId == waiterId
                        select w;

            return await query.AnyAsync();
        }
    }
}