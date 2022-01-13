using JustASecond.DAL.Data;
using JustASecond.DAL.Interfaces;

namespace JustASecond.DAL.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

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
