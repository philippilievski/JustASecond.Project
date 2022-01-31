﻿using JustASecond.DAL.Data;
using JustASecond.DAL.Interfaces;
using JustASecond.DAL.Repos;
using System.Security.Cryptography;

namespace JustASecond.DAL.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        private IOrderRepo _orderRepo;
        private IProductRepo _productRepo;
        private ICustomerRepo _customerRepo;

        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IOrderRepo OrderRepo { get => _orderRepo ?? new OrderRepo(db); }
        public IProductRepo ProductRepo { get => _productRepo ?? new ProductRepo(db); }
        public ICustomerRepo CustomerRepo { get => _customerRepo ?? new CustomerRepo(db); }

        public Task SaveChanges()
        {
            return db.SaveChangesAsync();
        }

        public async Task Rollback()
        {
            await db.DisposeAsync();
        }
    }
}
