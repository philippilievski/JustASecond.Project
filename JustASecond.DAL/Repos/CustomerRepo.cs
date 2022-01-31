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

        public async Task<Customer> GetCustomerById(int customerid)
        {
            return await db.Customers.Where(x => x.Id == customerid).FirstAsync();
        }

        public async Task<Order> GetOrderFromCustomer(Customer customer)
        {
            var order = db.Orders
                            .Include(x=> x.OrderPositions)
                            .Where(x => x.Customer.Id == customer.Id && x.Sent == false)
                            .FirstOrDefaultAsync();
            return await order;
        }

        public async Task AddOrderPosition(OrderPosition orderPosition)
        {
            await db.OrderPositions
                .AddAsync(orderPosition);
        }
    }
}
