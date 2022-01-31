using JustASecond.DAL.Data;
using JustASecond.DAL.Data.Models;
using JustASecond.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustASecond.DAL.Repos
{
    public class ProductRepo : IProductRepo
    {
        private ApplicationDbContext db;

        public ProductRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Add(Product product)
        {
            await db.AddAsync(product);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var query = from p in db.Products
                        select p;

            return await query.ToListAsync();
        }

        public async Task Remove(Product product)
        {
            db.Remove(product);
            await db.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            db.Update(product);
            await db.SaveChangesAsync();
        }
    }
}
