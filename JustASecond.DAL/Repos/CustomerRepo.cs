using JustASecond.DAL.Data;
using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Holt einen Kunden mit übergebener ID aus der Datenbank
        /// </summary>
        /// <param name="customerid">ID from Customer</param>
        /// <returns>Customer</returns>
        public async Task<Customer> GetCustomerById(int customerid)
        {
            return await db.Customers.Where(x => x.Id == customerid).FirstAsync();
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
