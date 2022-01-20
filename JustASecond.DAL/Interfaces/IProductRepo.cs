using JustASecond.DAL.Data.Models;

namespace JustASecond.DAL.Interfaces
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task Add(Product product);
        Task Remove(Product product);
        Task Update(Product product);
    }
}
