using JustASecond.DAL.Data;
using JustASecond.DAL.Interfaces;
using JustASecond.DAL.Repos;

namespace JustASecond.DAL.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        private IOrderRepo _orderRepo;
        private IProductRepo _productRepo;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public IOrderRepo OrderRepo { get => _orderRepo ?? new OrderRepo(_db); }
        public IProductRepo ProductRepo { get => _productRepo ?? new ProductRepo(_db); }

        public Task Commit()
        {
            return _db.SaveChangesAsync();
        }

        public async Task Rollback()
        {
            await _db.DisposeAsync();
        }
    }
}
