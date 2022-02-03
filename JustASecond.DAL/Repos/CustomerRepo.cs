using JustASecond.DAL.Data;
using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustASecond.DAL.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private ApplicationDbContext db;
        public CustomerRepo(ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;
        }

        /// <summary>
        /// Fügt einen Kunden zur Datenbank hinzu
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Task</returns>
        public async Task AddCustomer(Customer customer)
        {
            await db.Customers.AddAsync(customer);
            await db.SaveChangesAsync();
        }

        public Task AddCustomer(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Holt einen Kunden mit übergebener ID aus der Datenbank
        /// </summary>
        /// <param name="customerid">ID from Customer</param>
        /// <returns>Customer</returns>
        public async Task<Customer> GetCustomerById(int customerid)
        {
            return await db.Customers.Where(x => x.Id == customerid).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Holt eine Bestellung aus der Datenbank, welche bereits vorhanden aber noch nicht abgeschickt wurde
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<Order> GetPendingOrderFromCustomer(Customer customer)
        {
            var order = db.Orders
                            .Include(x=> x.OrderPositions)
                            .Where(x => x.Customer.Id == customer.Id && x.Sent == false)
                            .FirstOrDefaultAsync();
            return await order;
        }
    }
}
