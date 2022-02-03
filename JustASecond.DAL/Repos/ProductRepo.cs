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

        /// <summary>
        /// Fügt der Datenbank ein Produkt hinzu
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task Add(Product product)
        {
            await db.AddAsync(product);
            await db.SaveChangesAsync();
        }


        /// <summary>
        /// Holt sich alle Produkte aus der Datenbank
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var query = from p in db.Products
                        select p;

            return await query.ToListAsync();
        }

        /// <summary>
        /// Entfernt ein Produkt aus der Datenbank
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task Remove(Product product)
        {
            db.Remove(product);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Updatet ein Produkt aus der Datenbank
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task Update(Product product)
        {
            db.Update(product);
            await db.SaveChangesAsync();
        }
    }
}
