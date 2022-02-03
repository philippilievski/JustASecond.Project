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

        /// <summary>
        /// Holt alle Bestellungen aus der Datenbank
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Holt alle Bestellungen, welche abgesendet wurden aus der Datenbank
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Fügt der Datenbank eine Bestellung hinzu
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task AddOrder(Order order)
        {
            await db.Orders!.AddAsync(order);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Fügt der Datenbank einen Tisch hinzu
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public async Task AddTable(Table table)
        {
            await db.Tables!.AddAsync(table);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Fügt der Datenbank einen WaiterCall hinzu
        /// </summary>
        /// <param name="call"></param>
        /// <returns></returns>
        public async Task AddWaiterCall(WaiterCall call)
        {
            await db.WaiterCalls!.AddAsync(call);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Holt sich eine Bestellung mit einer gewissen ID aus der Datenbank
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<Order> GetOrder(int orderId)
        {
            var query = from o in db.Orders
                        where o.Id == orderId
                        select o;

            return await query.FirstOrDefaultAsync();
        }


        /// <summary>
        /// Holt sich alle Tische aus der Datenbank
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Table>> GetTables()
        {
            var query = from o in db.Tables
                        select o;

            return await query.ToListAsync();
        }

        /// <summary>
        /// Holt sich alle Bestellpositionen einer Bestellung aus der Datenbank
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Holt sich die höchte Bestellpositionsnummer einer Bestellung aus der Datenbank
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Holt sich den Tisch einer übergebenen ID aus der Datenbank
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public async Task<Table> GetTableByID(int tableid)
        {
            var table = db.Tables!
                            .Where(x => x.Id == tableid)
                            .FirstOrDefaultAsync();

            return await table;
        }


        /// <summary>
        /// Holt sich alle Bestellpositionen der übergebenen Bestellung aus der Datenbank
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Entfernt eine Bestellposition aus der Datenbank
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public async Task RemoveOrderPosition(int orderId, int position)
        {
            var foundOrderPosition = await db.OrderPositions
                .Where(x => x.OrderId == orderId && x.Position == position)
                .FirstOrDefaultAsync();
            db.OrderPositions.Remove(foundOrderPosition);
        }


        /// <summary>
        /// Setzt die Anzahl eines Artikels einer Bestellposition
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="position"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Setzt die Eigenschaft Sent der übergebenen Bestellung auf true
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task SetOrderSent(int orderId, bool sent)
        {
            var orderupdated = await db.Orders
                            .Where(x => x.Id == orderId)
                            .FirstOrDefaultAsync();
            orderupdated.Sent = sent;
            db.Orders.Update(orderupdated);
        }

        /// <summary>
        /// Holt sich alle Bestellungen eines Kunden, welche bereits abgeschickt wurden
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
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