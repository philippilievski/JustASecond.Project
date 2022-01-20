using JustASecond.DAL.Data;
using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustASecond.DAL.Repos
{
    public class ProductRepo : IProductRepo
    {
        private ApplicationDbContext _db;

        public ProductRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(Product product)
        {
            await _db.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var query = from p in _db.Products
                        select p;

            return await query.ToListAsync();
        }

        public async Task Remove(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
        }
    }
}
