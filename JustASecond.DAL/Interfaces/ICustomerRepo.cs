using JustASecond.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustASecond.DAL.Interfaces
{
    public interface ICustomerRepo
    {
        Task AddCustomer(Customer customer);
        Task<Customer> GetCustomerById(int customerid);
        Task<List<Customer>> GetAllCustomers();
        Task<Order> GetOrderFromCustomer(Customer customer);
    }
}
