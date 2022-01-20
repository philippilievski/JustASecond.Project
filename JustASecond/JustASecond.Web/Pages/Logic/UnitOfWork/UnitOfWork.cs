using JustASecond.DAL.Data;
using JustASecond.Web.Pages.Logic.UnitOfWork.Repositories;

namespace JustASecond.Web.Pages.Logic.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        public OrderPositionRepository OrderPositionRepository { get; set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

            OrderPositionRepository ??= new OrderPositionRepository(dbContext);
        }
    }
}
